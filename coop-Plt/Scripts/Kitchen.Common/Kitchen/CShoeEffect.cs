using Unity.Entities;

namespace Kitchen
{
	public struct CShoeEffect : IComponentData
	{
		public float SpeedModifier;

		public bool IgnoreMess;
	}
}
