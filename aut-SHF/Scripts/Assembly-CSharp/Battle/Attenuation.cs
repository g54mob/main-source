using System;

namespace Battle
{
	[Serializable]
	public class Attenuation
	{
		[Label("有効：威力減衰")]
		public bool isAttenuation;

		[Label("減衰量")]
		public int attenuationPoint;

		[Label("減衰最小値")]
		public int minPoint;

		public int GetAttenuationPoint(int value)
		{
			return 0;
		}
	}
}
