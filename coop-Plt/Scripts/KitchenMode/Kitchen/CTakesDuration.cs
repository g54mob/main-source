using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CTakesDuration : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public float Total;

		public float Remaining;

		public bool Active;

		public bool Manual;

		public bool ManualNeedsEmptyHands;

		public DurationToolType RelevantTool;

		public InteractionMode Mode;

		public bool RequiresRelease;

		public bool PreserveProgress;

		public bool IsInverse;

		public bool IsLocked;

		public float CurrentChange;
	}
}
