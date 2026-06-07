using DV.Customization.Gadgets;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class DrillablePointsStateStep : AQuickTutorialStep
	{
		public delegate Drillable DrillableProvider();

		private readonly DrillableProvider provider;

		private Drillable drillable;

		private int lastInvalidIndex = -1;

		private readonly bool targetState;

		public DrillablePointsStateStep(Drillable drillable, bool targetState, AQuickTutorialMessage message, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
			: base(message, attentionPoint, attentionOffset, shouldRecheck)
		{
			this.drillable = drillable;
			this.targetState = targetState;
		}

		public DrillablePointsStateStep(DrillableProvider provider, bool targetState, AQuickTutorialMessage message, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
			: base(message, attentionPoint, attentionOffset, shouldRecheck)
		{
			this.provider = provider;
			this.targetState = targetState;
		}

		protected override void InternalMakeCurrent()
		{
			if (provider != null)
			{
				drillable = provider();
			}
			lastInvalidIndex = -1;
			for (int i = 0; i < drillable.MountPointCount; i++)
			{
				if ((int)drillable.GetMountPointState(i) > 0 != targetState)
				{
					lastInvalidIndex = i;
					AttentionPoint = drillable.GetMountPoint(lastInvalidIndex).transform;
					break;
				}
			}
			base.InternalMakeCurrent();
		}

		protected override bool InternalCheck()
		{
			if (lastInvalidIndex >= 0 && (int)drillable.GetMountPointState(lastInvalidIndex) > 0 == targetState)
			{
				int num = lastInvalidIndex;
				lastInvalidIndex = -1;
				for (int i = 1; i < drillable.MountPointCount; i++)
				{
					int index = (num + i) % drillable.MountPointCount;
					if ((int)drillable.GetMountPointState(index) > 0 != targetState)
					{
						lastInvalidIndex = i;
						AttentionPoint = drillable.GetMountPoint(lastInvalidIndex).transform;
						ShowVisual();
						break;
					}
				}
			}
			return lastInvalidIndex < 0;
		}
	}
}
