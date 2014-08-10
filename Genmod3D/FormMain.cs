using SharpDX;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SD = System.Drawing;

namespace Genmod3D
{
    public partial class FormMain : Form
    {
        Device device;
        Timer timer;
        Effect shader;
        Camera camera = new Camera();
        Vertex[] grid;
        bool mdown = false;
        SD.Point mpos;

        private Control DisplayPanel
        {
            get
            {                
                return controlViewport;
            }
        }

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var pp = new PresentParameters(2048, 2048);
            device = new Device(new Direct3D(), 0, DeviceType.Hardware, IntPtr.Zero, CreateFlags.HardwareVertexProcessing, pp);

            shader = Effect.FromString(device, Properties.Resources.Shader, ShaderFlags.None);

            timer = new Timer();
            timer.Tick += timer_Tick;
            timer.Interval = 15;
            timer.Start();

            camera.Angle = new Vector2(0, 0.5f);
            camera.Distance = 20;

            List<Vertex> grid = new List<Vertex>();

            for(int la=-10;la<=10;la++)
            {
                grid.Add(new Vertex(la, 0, -10));
                grid.Add(new Vertex(la, 0, +10));
                grid.Add(new Vertex(-10, 0, la));
                grid.Add(new Vertex(+10, 0, la));
            }

            this.grid = grid.ToArray();
            DisplayPanel.MouseWheel += Panel2_MouseWheel;
            DisplayPanel.MouseMove += splitContainer_Panel2_MouseMove;
            DisplayPanel.MouseDown += splitContainer_Panel2_MouseDown;
            DisplayPanel.MouseUp += splitContainer_Panel2_MouseUp;
        }

        void Panel2_MouseWheel(object sender, MouseEventArgs e)
        {
            camera.Distance = Math.Max(1, camera.Distance - e.Delta / 100f);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            camera.Projection = Matrix.PerspectiveFovLH(1, DisplayPanel.ClientSize.Width / (float)DisplayPanel.ClientSize.Height, 0.1f, 1000f);
            camera.Update();

            device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.Gray, 1, 0);
            device.Viewport = new Viewport(0, 0, DisplayPanel.ClientSize.Width, DisplayPanel.ClientSize.Height);
            device.BeginScene();
            device.VertexDeclaration = Vertex.GetDeclaration(device);
            DrawGrid();
            device.EndScene();
            var rect = new Rectangle(0, 0, DisplayPanel.ClientSize.Width, DisplayPanel.ClientSize.Height);
            device.Present(rect, rect, DisplayPanel.Handle);
        }

        private void DrawGrid()
        {            
            shader.SetValue("World", Matrix.Identity);
            shader.SetValue("ViewProj", camera.View * camera.Projection);
            shader.SetValue("ColorAdd", new Vector4(0.7f, 0.7f, 0.7f, 1f));
            shader.SetValue("ColorMul", Color.Zero.ToVector4());
            shader.Begin();           
            shader.BeginPass(0);
            device.DrawUserPrimitives<Vertex>(PrimitiveType.LineList, grid.Length / 2, grid);
            shader.EndPass();
            shader.End();
        }

        private void splitContainer_Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if(mdown)
            {
                camera.Angle += new Vector2(e.X - mpos.X, e.Y - mpos.Y) / 300f;
                mpos = e.Location;
            }
        }

        private void splitContainer_Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                mpos = e.Location;
                mdown = true;
            }
        }

        private void splitContainer_Panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mdown = false;
        }
    }
}
