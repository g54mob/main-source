using System.Runtime.Serialization;

namespace ConvNetSharp.Layers
{
	[DataContract]
	public sealed class InputLayer : LayerBase
	{
		public InputLayer(int inputWidth, int inputHeight, int inputDepth)
		{
			Init(inputWidth, inputHeight, inputDepth);
			base.OutputWidth = inputWidth;
			base.OutputHeight = inputHeight;
			base.OutputDepth = inputDepth;
		}

		public override Volume Forward(Volume input, bool isTraining = false)
		{
			base.InputActivation = input;
			base.OutputActivation = input;
			return base.OutputActivation;
		}

		public override void Backward()
		{
		}
	}
}
