using DV.Hovering;
using DV.Utils;
using UnityEngine;

namespace DV.Signs
{
	public class SignHoverEventManager : MonoBehaviour
	{
		private void Start()
		{
			if (VRManager.IsVREnabled())
			{
				Object.Destroy(this);
			}
			else
			{
				SingletonBehaviour<NonVRHoverManager>.Instance.HoverChanged += OnHoverChanged;
			}
		}

		private void OnDestroy()
		{
			if (!VRManager.IsVREnabled() && !UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<NonVRHoverManager>.Instance.HoverChanged -= OnHoverChanged;
			}
		}

		private void OnHoverChanged(NonVRHoverManager.HoverType type, object obj, bool hovered)
		{
			if (type == NonVRHoverManager.HoverType.Sign)
			{
				SignHover signHover = obj as SignHover;
				if (hovered)
				{
					signHover.Hovered();
				}
				else
				{
					signHover.Unhovered();
				}
			}
		}
	}
}
