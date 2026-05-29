using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.World;
using UnityEngine;

public class ActiveWorldFrame : MonoBehaviour
{
	private Dictionary<WorldAnchor, Transform> _elements = new Dictionary<WorldAnchor, Transform>();

	private Dictionary<WorldAnchor, List<FrameGizmo>> _gizmos = new Dictionary<WorldAnchor, List<FrameGizmo>>();

	public WorldFrame ActiveFrame { get; private set; }

	private void Start()
	{
		ActiveFrame.SetFrameActive(this);
	}

	public void ClearActive()
	{
		ActiveFrame.SetFrameActive(null);
		ActiveFrame = null;
	}

	private void OnDestroy()
	{
		if (ActiveFrame != null)
		{
			ActiveFrame.SetFrameActive(null);
			ActiveFrame = null;
		}
	}

	public void AddWorldAnchor(ActiveWorldAnchor anchor)
	{
		_elements[anchor.Anchor] = anchor.transform;
	}

	public void AddGizmo(FrameGizmo gizmo, WorldAnchor anchor)
	{
		GetGizmos(anchor).Add(gizmo);
	}

	public List<FrameGizmo> GetGizmos(WorldAnchor anchor)
	{
		if (!_gizmos.TryGetValue(anchor, out var value))
		{
			value = new List<FrameGizmo>();
			_gizmos[anchor] = value;
		}
		return value;
	}

	public void SetActiveFrame(WorldFrame frame)
	{
		ActiveFrame = frame;
	}

	public void ButtonClicked(WorldAnchor anchor)
	{
		ActiveFrame.ButtonClicked(anchor);
	}

	public void ButtonClicked(FrameButton button)
	{
		ButtonClicked(button.Anchor);
	}

	public void UpdateAutoWorker(WorldAnchor anchor)
	{
		ActiveAutoCrafter activeAutoCrafter = GetAnchor(anchor)?.GetComponent<ActiveAutoCrafter>();
		if ((bool)activeAutoCrafter)
		{
			activeAutoCrafter.SetupWorker();
		}
	}

	public UITimerBar TriggerCooldown(WorldAnchor anchor, float duration)
	{
		Transform anchor2 = GetAnchor(anchor);
		UITimerBar result = FrameUI.Instance.ShowTimer(GetAnchor(anchor, "Cooldown"), duration);
		FrameButton component = anchor2.GetComponent<FrameButton>();
		if ((bool)component)
		{
			component.SetActive(active: false);
		}
		return result;
	}

	public void EnableButton(WorldAnchor anchor, bool enable = true)
	{
		FrameButton frameButton = GetAnchor(anchor)?.GetComponent<FrameButton>();
		if ((bool)frameButton)
		{
			frameButton.SetActive(enable);
		}
	}

	public UIProgressBar ShowProgress(WorldAnchor anchor, float progress)
	{
		Transform anchor2 = GetAnchor(anchor, "Cooldown");
		return FrameUI.Instance.ShowProgress(anchor2, progress);
	}

	public void ShowNeedItem(WorldAnchor anchor, ItemType type, int count)
	{
		Transform anchor2 = GetAnchor(anchor, "ItemCrafted");
		FrameUI.Instance.ShowNeedItem(anchor2, type, count);
	}

	public void ShowWarning(WorldAnchor anchor, string text)
	{
		Transform anchor2 = GetAnchor(anchor, "ItemCrafted");
		FrameUI.Instance.ShowWarning(anchor2, text);
	}

	public void ShowItemCrafted(WorldAnchor anchor, ItemType type, int count)
	{
		Transform anchor2 = GetAnchor(anchor, "ItemCrafted");
		FrameUI.Instance.ShowItemCrafted(anchor2, type, count);
		if (anchor.AnchorType != WorldAnchorType.AutoWorker)
		{
			UIInventoryHotbar.Instance.ItemHandCrafted(type, count);
		}
	}

	public Transform GetAnchor(WorldAnchor anchor, string child = null)
	{
		Transform transform = _elements[anchor];
		if (child == null)
		{
			return transform;
		}
		return transform.Find(child) ?? transform;
	}

	public virtual void UpdateUpgradeSlot(WorldAnchor anchor)
	{
		_elements[anchor].GetComponent<ActiveUpgradeSlot>().UpdateState();
	}

	public void UpdateUpgradeSlots()
	{
		ActiveUpgradeSlot[] componentsInChildren = GetComponentsInChildren<ActiveUpgradeSlot>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].UpdateState();
		}
	}

	public void TriggerGizmoStart(WorldAnchor slot)
	{
		foreach (FrameGizmo gizmo in GetGizmos(slot))
		{
			gizmo.OnStartGizmo();
		}
	}

	public void TriggerGizmoStop(WorldAnchor slot)
	{
		foreach (FrameGizmo gizmo in GetGizmos(slot))
		{
			gizmo.OnStopGizmo();
		}
	}

	public void TriggerGizmoClick(WorldAnchor slot, float progress)
	{
		foreach (FrameGizmo gizmo in GetGizmos(slot))
		{
			gizmo.OnClickGizmo(progress);
		}
	}
}
