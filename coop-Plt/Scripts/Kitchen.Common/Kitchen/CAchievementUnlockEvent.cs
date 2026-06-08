using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public struct CAchievementUnlockEvent : IComponentData
	{
		public FixedString32 Name;
	}
}
