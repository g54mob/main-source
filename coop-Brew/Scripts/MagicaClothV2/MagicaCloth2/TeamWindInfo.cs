using Unity.Mathematics;

namespace MagicaCloth2
{
	public struct TeamWindInfo : IValid
	{
		public int windId;

		public float time;

		public float main;

		public float3 direction;

		public bool IsValid()
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		public void DebugLog()
		{
		}
	}
}
