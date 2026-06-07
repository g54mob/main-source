using System.Collections.Generic;
using DV.Interaction;
using DV.Utils;
using DV.VR;
using UnityEngine;

public class InWorldTooltip : AGrabHandler
{
	private class TelegrabbableTooltip : TelegrabbableInteractionTarget
	{
		public InWorldTooltip parentTooltip;

		public override bool RemoteInteractionOnly => true;

		public override bool IsTelegrabAllowed(Vector3 _)
		{
			return true;
		}

		protected override void OnHighlightChange(bool highlightOn)
		{
			if (highlightOn)
			{
				parentTooltip.ShowTooltip();
			}
			else
			{
				parentTooltip.HideTooltip();
			}
		}
	}

	[Header("Actual tooltip settings")]
	public Transform pointerAnchor;

	public Vector3 pointerOffset;

	public string messageToShow;

	public bool localizeMessage;

	public TutorialHelper.SoundType soundType = TutorialHelper.SoundType.Regular;

	private bool shown;

	public override bool IsItem => false;

	public override Vector3 GetAxis()
	{
		return Vector3.forward;
	}

	public override Vector3 GetAnchor()
	{
		return Vector3.zero;
	}

	public override void FeedPosition(Vector3 worldPosition)
	{
	}

	private void Awake()
	{
		interactionColliders = new HashSet<Collider>(GetComponentsInChildren<Collider>());
		if (VRManager.IsVREnabled())
		{
			base.gameObject.AddComponent<TelegrabbableTooltip>().parentTooltip = this;
		}
	}

	private void OnEnable()
	{
		if (!VRManager.IsVREnabled())
		{
			base.Hovered += ShowTooltip;
			base.UnHovered += HideTooltip;
		}
	}

	private void OnDisable()
	{
		if (!VRManager.IsVREnabled())
		{
			base.Hovered -= ShowTooltip;
			base.UnHovered -= HideTooltip;
		}
		HideTooltip();
	}

	private void ShowTooltip()
	{
		if (!shown && base.enabled)
		{
			shown = true;
			SingletonBehaviour<TutorialHelper>.Instance.ShowTutorialFloatie(messageToShow, pointerAnchor, pointerOffset, localizeMessage, targetIsUI: false, soundType);
		}
	}

	private void HideTooltip()
	{
		if (shown)
		{
			shown = false;
			SingletonBehaviour<TutorialHelper>.Instance.HideTutorialFloatie();
		}
	}
}
