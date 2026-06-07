using System.Collections.Generic;
using UnityEngine.Events;

namespace FIMSpace.FProceduralAnimation
{
	public class RAF_EventOnFallSwitch : RagdollAnimatorFeatureBase
	{
		public override bool OnInit()
		{
			RefreshHelperEvents(base.InitializedWith);
			base.ParentRagdollHandler.AddToOnFallModeSwitchActions(OnChange);
			return base.OnInit();
		}

		public override void OnDestroyFeature()
		{
			base.ParentRagdollHandler.RemoveFromOnFallModeSwitchActions(OnChange);
		}

		private void OnChange()
		{
			if (base.InitializedWith.Enabled)
			{
				if (base.ParentRagdollHandler.AnimatingMode == RagdollHandler.EAnimatingMode.Standing)
				{
					base.Helper.customEventsList[1].Invoke();
				}
				else
				{
					base.Helper.customEventsList[0].Invoke();
				}
			}
		}

		private bool RefreshHelperEvents(RagdollAnimatorFeatureHelper helper)
		{
			bool result = false;
			if (helper.customEventsList == null)
			{
				helper.customEventsList = new List<UnityEvent>();
				result = true;
			}
			while (helper.customEventsList.Count < 2)
			{
				helper.customEventsList.Add(new UnityEvent());
				result = true;
			}
			return result;
		}
	}
}
