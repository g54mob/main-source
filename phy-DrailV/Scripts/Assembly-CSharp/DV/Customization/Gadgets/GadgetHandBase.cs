using DV.Utils;
using UnityEngine;

namespace DV.Customization.Gadgets
{
	public abstract class GadgetHandBase : MonoBehaviour
	{
		private const string LOC_UNTAPE = "interaction/untape";

		private MountPoint targetHole;

		protected void OnUpdate(GadgetBase target, Rigidbody rb, MountPoint hole, bool use)
		{
			if (hole == null || hole.State != MountPoint.States.Taped || (target.GetValidRemovalMethodsMask() & GadgetBase.GadgetRemovalMethod.Remover) == 0)
			{
				hole = null;
			}
			if (targetHole != hole)
			{
				if (targetHole != null)
				{
					targetHole.IsHighlighted = false;
				}
				targetHole = hole;
				if (targetHole != null)
				{
					targetHole.IsHighlighted = true;
				}
			}
			if (target == null || (rb != null && IsSubcomponentOf(rb, target)))
			{
				return;
			}
			if (target.GetValidRemovalMethods().HasAnyFlag(GadgetBase.GadgetRemovalMethod.EmptyHand))
			{
				if (use)
				{
					target.PlayRemoveSound();
					TryGrab(target);
				}
				target.DrawHighlight(GadgetSystemUtility.COLOR_HIGHLIGHT_BAD, doLateUpdateOffset: true);
			}
			else if (hole != null)
			{
				if (!VRManager.IsVREnabled())
				{
					GadgetInteractor.ShowInteractionTextLMB("interaction/untape");
				}
				if (use)
				{
					hole.Drillable.SetMountPointState(hole.Index, MountPoint.States.None);
					SingletonBehaviour<GadgetSystemUtility>.Instance.SoundOnMountUntaped.Play(hole.transform.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, hole.transform);
					hole.IsHighlighted = false;
					targetHole = null;
				}
			}
		}

		protected abstract bool TryGrab(GadgetBase target);

		private static bool IsSubcomponentOf(Rigidbody hitRB, GadgetBase target)
		{
			Transform transform = target.transform;
			Transform parent = hitRB.transform.parent;
			while (parent != null)
			{
				if (parent == transform)
				{
					return true;
				}
				parent = parent.parent;
			}
			return false;
		}
	}
}
