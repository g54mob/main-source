using System;

namespace MalbersAnimations
{
	[Serializable]
	public class LayersActivation
	{
		public string layer;

		public bool activate;

		public StateTransition transA;

		public bool deactivate;

		public StateTransition transD;
	}
}
