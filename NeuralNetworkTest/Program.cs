using System;

namespace NeuralNetworkTest
{
	class Program
	{
		private const int Width = 1024;
		private const int Height = 768;
		private static readonly Trainer[] Dots = new Trainer[2000];

		static void Main()
		{
			Setup();

			Run();

			Draw();
		}

		private static void Run()
		{
			foreach (var dot in Dots)
			{
				
			}
		}

		private static void Draw()
		{
			int count = 0;
			var perceptron = new Perceptron(3) { LearningConstant = 0.01 };

			perceptron.Train(Dots[count].Inputs, Dots[count].Answer);
			count = (count + 1) % Dots.Length;

			for (int i = 0; i < count; i++)
			{
				int guess = perceptron.FeedForward(Dots[i].Inputs);
				if (guess > 0) Console.WriteLine("COOL");
			}
		}

		private static void Setup()
		{
			var random = new Random();

			for (var i = 0; i < Dots.Length; i++)
			{
				double x = random.Next(Width);
				double y = random.Next(Height);
				var answer = y < F(x) ? -1 : 1;

				Dots[i] = new Trainer(x, y, answer);
			}
		}

		private static double F(double x)
		{
			return 2 * x + 1;
		}
	}
}
