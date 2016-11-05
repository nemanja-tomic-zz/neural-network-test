using System;
using System.Drawing;
using System.Windows.Forms;

namespace NeuralNetworkTest.UI
{
	public partial class Form1 : Form
	{
		public Trainer[] Dots = new Trainer[1000];
		private BufferedGraphicsContext _context;
		private BufferedGraphics _grafx;
		private Graphics _graphics;

		public Form1()
		{
			InitializeComponent();
			InitDrawingSurface();
		}

		private void Draw()
		{
			int count = 0;
			var perceptron = new Perceptron(3) { LearningConstant = 0.01 };

			foreach (var dot in Dots)
			{
				perceptron.Train(dot.Inputs, dot.Answer);
				count = count + 1;

				var guess = perceptron.FeedForward(dot.Inputs);
				if (guess > 0) _graphics.FillEllipse(Brushes.Red, (int)dot.Inputs[0], (int)dot.Inputs[1], 5, 5);
				else _graphics.DrawEllipse(Pens.Black, (int)dot.Inputs[0], (int)dot.Inputs[1], 5, 5);
				_grafx.Render();
			}
		}

		private void Setup()
		{
			var random = new Random();

			for (var i = 0; i < Dots.Length; i++)
			{
				double x = random.Next(0, Width);
				double y = random.Next(0, Height);
				var answer = y > F(x) ? -1 : 1;

				Dots[i] = new Trainer(x, y, answer);
			}

		}

		private static double F(double x)
		{
			return x / 2;
		}

		private void InitDrawingSurface()
		{
			_context = new BufferedGraphicsContext { MaximumBuffer = ClientSize };
			_grafx = _context.Allocate(CreateGraphics(), new Rectangle(0, 0, ClientSize.Width, ClientSize.Height));
			_graphics = _grafx.Graphics;
			_graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
		}

		private void initBtn_Click(object sender, EventArgs e)
		{
			_graphics.Clear(Color.White);
			DrawLine();
			Setup();
			Draw();
		}

		private void DrawLine()
		{
			_graphics.DrawLine(Pens.Black, 0, 0, ClientSize.Width, ClientSize.Height / 2);
			_grafx.Render();
		}
	}
}
