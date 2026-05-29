using System;

namespace FishNet.Serializing
{
	[Serializable]
	internal class TransformPackingData
	{
		public AutoPackType Position;

		public AutoPackType Rotation;

		public AutoPackType Scale;
	}
}
