using System;

namespace NeuralNetworkTest
{
	public class Perceptron
	{
		private readonly double[] _weights;
		public double LearningConstant { get; set; }

		public Perceptron(int n)
		{
			var randomator = new Random();
			_weights = new double[n];
			for (var i = 0; i < _weights.Length; i++)
			{
				_weights[i] = randomator.Next(-1, 1);
			}
		}

		public int FeedForward(double[] inputs)
		{
			double sum = 0;
			for (var i = 0; i < _weights.Length; i++)
			{
				sum += inputs[i] * _weights[i];
			}
			return Activate(sum);
		}

		public void Train(double[] inputs, int desired)
		{
			var guess = FeedForward(inputs);
			float error = desired - guess;
			for (var i = 0; i < _weights.Length; i++)
			{
				_weights[i] += LearningConstant * error * inputs[i];
			}
		}

		private static int Activate(double sum)
		{
			return sum > 0 ? 1 : -1;
		}
	}
}