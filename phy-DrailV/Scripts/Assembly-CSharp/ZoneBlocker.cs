using System;
using System.Collections;
using DV.Util.EventWrapper;
using DV.Utils;
using UnityEngine;

public class ZoneBlocker : MonoBehaviour, ITeleportDestination, IPointable
{
	public GameObject blockerObjectsParent;

	public event_ Hovered;

	public event_ Unhovered;

	public HandIPointableSource lastSource;

	private bool tooltipShown;

	private Transform lastTooltipAnchor;

	private Vector3 lastTooltipOffset;

	public event Action Unblocked;

	public void DestroyBlockers()
	{
		SingletonBehaviour<CoroutineManager>.Instance.Run(DestroyBlockersCoro());
	}

	private IEnumerator DestroyBlockersCoro()
	{
		blockerObjectsParent.transform.SetParent(null);
		blockerObjectsParent.transform.position = new Vector3(0f, -5000f, 0f);
		yield return WaitFor.FixedUpdate;
		yield return WaitFor.EndOfFrame;
		UnityEngine.Object.Destroy(blockerObjectsParent);
		this.Unblocked?.Invoke();
	}

	public (Vector3 pos, Quaternion rot) GetTeleportPose()
	{
		return (pos: Vector3.zero, rot: Quaternion.identity);
	}

	public void AfterPlayerTeleported()
	{
	}

	public virtual void Hover(Vector3 position, Vector3 normal, HandIPointableSource source)
	{
		lastSource = source;
		Hovered.Invoke();
		if (!VRManager.IsVREnabled())
		{
			SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(GetHoverText());
		}
		string hoverTooltipMessage = GetHoverTooltipMessage();
		if (!string.IsNullOrEmpty(hoverTooltipMessage))
		{
			Transform hoverTooltipAnchor = GetHoverTooltipAnchor();
			Vector3 hoverTooltipOffset = GetHoverTooltipOffset();
			if (hoverTooltipAnchor != lastTooltipAnchor || hoverTooltipOffset != lastTooltipOffset || !tooltipShown)
			{
				SingletonBehaviour<TutorialHelper>.Instance.ShowTutorialFloatie(hoverTooltipMessage, hoverTooltipAnchor, hoverTooltipOffset, localize: false);
				tooltipShown = true;
				lastTooltipAnchor = hoverTooltipAnchor;
				lastTooltipOffset = hoverTooltipOffset;
			}
		}
	}

	protected virtual string GetHoverTooltipMessage()
	{
		return string.Empty;
	}

	protected virtual Transform GetHoverTooltipAnchor()
	{
		return null;
	}

	protected virtual Vector3 GetHoverTooltipOffset()
	{
		return Vector3.zero;
	}

	public virtual void Unhover()
	{
		Unhovered.Invoke();
		if (tooltipShown)
		{
			SingletonBehaviour<TutorialHelper>.Instance.HideTutorialFloatie();
			tooltipShown = false;
		}
	}

	public virtual string GetHoverText()
	{
		return string.Empty;
	}

	public virtual bool IsTeleportAllowed()
	{
		return false;
	}

	public virtual bool ShouldRotatePlayerOnTeleport()
	{
		return false;
	}
}
