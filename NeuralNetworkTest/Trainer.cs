namespace NeuralNetworkTest
{
	public class Trainer
	{
		public double[] Inputs;
		public int Answer;

		public Trainer(double x, double y, int a)
		{
			Inputs = new double[3];
			Inputs[0] = x;
			Inputs[1] = y;
			Inputs[2] = 1;
			Answer = a;
		}
	}
}