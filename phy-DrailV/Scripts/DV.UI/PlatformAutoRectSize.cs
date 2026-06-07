using System;
using System.Collections.Generic;
using DV;
using DV.Utils;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(RectTransform))]
public class PlatformAutoRectSize : MonoBehaviour
{
	[Serializable]
	private class PlatformRectMod
	{
		public APlatformProvider.Platform platform;

		[FormerlySerializedAs("inset")]
		[Tooltip("The offset of the RectTransform compared to the default settings, in CSS order.")]
		public Vector4 offest;

		[Tooltip("The size of the RectTransform with the current anchors. Set either value to 0 to leave unmodified.")]
		public Vector2 size;
	}

	[FormerlySerializedAs("rectSizes")]
	[SerializeField]
	private List<PlatformRectMod> rectMods;

	private void Start()
	{
		RectTransform component = GetComponent<RectTransform>();
		APlatformProvider.Platform currentPlatform = SingletonBehaviour<APlatformProvider>.Instance.CurrentPlatform;
		foreach (PlatformRectMod rectMod in rectMods)
		{
			if (currentPlatform.HasAnyByteFlag(rectMod.platform))
			{
				Vector4 offest = rectMod.offest;
				if (offest.x != 0f || offest.y != 0f)
				{
					Vector2 offsetMax = component.offsetMax;
					component.offsetMax = new Vector2(offsetMax.x + offest.y, offsetMax.y + offest.x);
				}
				if (offest.z != 0f || offest.w != 0f)
				{
					Vector2 offsetMin = component.offsetMin;
					component.offsetMin = new Vector2(offsetMin.x + offest.w, offsetMin.y + offest.z);
				}
				Vector2 size = rectMod.size;
				if (size.x != 0f)
				{
					component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size.x);
				}
				if (size.y != 0f)
				{
					component.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size.y);
				}
				break;
			}
		}
	}
}
