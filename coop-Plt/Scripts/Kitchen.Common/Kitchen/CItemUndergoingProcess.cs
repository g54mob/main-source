using Unity.Entities;

namespace Kitchen
{
	public struct CItemUndergoingProcess : IComponentData
	{
		public int Process;

		public float Progress;

		public bool IsBad;

		public Entity Actor;

		public Entity Appliance;

		public bool IsSpecialFinish;

		public bool IsAutomatic;

		public float CurrentChange;

		public bool IsBeingSplit => Process == -1;
	}
}
