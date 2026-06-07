using System;
using I2.Loc;
using PajamaLlama.Debugs;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BoatPanel : MonoBehaviour, IBuildablePanelElement
{
	[Header("Components")]
	[SerializeField]
	private Button _reclaimButton;

	public LocalizedString ReclaimableTooltipText = "";

	public LocalizedString UnReclaimableTooltipText = "";

	[SerializeField]
	private DrifterEntryPanel _drifterEntryPanel;

	private Inventory _boatInventory;

	private Tooltip _reclaimButtonTooltip;

	public BuildablePanelElementId Id => BuildablePanelElementId.Boat;

	public Boat Boat { get; private set; }

	private void OnDisable()
	{
		_boatInventory.InventoryUpdatedEvent.RemoveListener(UpdatePanel);
		Boat boat = Boat;
		boat.BoatUpdatedEvent = (UnityAction<Boat>)Delegate.Remove(boat.BoatUpdatedEvent, new UnityAction<Boat>(UpdatePanel));
		Community.PlayerCommunity.BoatsUpdatedEvent -= UpdatePanel;
		Community.PlayerCommunity.MooringPointsUpdatedEvent -= UpdatePanel;
	}

	public bool Activate(Buildable buildable, bool finished)
	{
		if (finished && buildable.TryReturnBuildableExtendable<Boat>(out var buildableExtendable))
		{
			Boat = buildableExtendable;
			_reclaimButtonTooltip = _reclaimButton.GetComponent<Tooltip>();
			_boatInventory = Boat.Buildable.Inventory;
			UpdatePanel();
			Boat boat = Boat;
			boat.BoatUpdatedEvent = (UnityAction<Boat>)Delegate.Combine(boat.BoatUpdatedEvent, new UnityAction<Boat>(UpdatePanel));
			Community.PlayerCommunity.BoatsUpdatedEvent += UpdatePanel;
			Community.PlayerCommunity.MooringPointsUpdatedEvent += UpdatePanel;
			base.gameObject.SetActive(value: true);
			return true;
		}
		return false;
	}

	public void Deactivate()
	{
		base.gameObject.SetActive(value: false);
	}

	private void UpdatePanel()
	{
		UpdatePanel(null);
	}

	private void UpdatePanel(Boat boat = null)
	{
		if (!(Boat == null) && Boat.Active)
		{
			_reclaimButton.gameObject.SetActive(Boat.NeedsReclaiming());
			if (Boat.CanBeReclaimed())
			{
				_reclaimButton.interactable = true;
				_reclaimButtonTooltip.LocalizedText = ReclaimableTooltipText;
			}
			else
			{
				_reclaimButton.interactable = false;
				_reclaimButtonTooltip.LocalizedText = UnReclaimableTooltipText;
			}
			_drifterEntryPanel.UpdateDrifter(Boat.Captain);
		}
	}

	public void ReclaimBoat()
	{
		Boat.Reclaim();
	}

	public void SelectCaptain()
	{
		if (Boat.Captain != null)
		{
			Selector.Select(Boat.Captain.gameObject, ObjectType.CommunityMember);
		}
	}

	public void Hide()
	{
		if (base.gameObject.activeSelf)
		{
			Selector.Deselect(Boat.gameObject);
			Boat.Navigator.LineRenderer.EnablePathVisuals(enabled: false);
			OutlineRendererComponent componentInParent = Boat.GetComponentInParent<OutlineRendererComponent>();
			if (componentInParent == null)
			{
				Debugger.Error($"No outline renderer component found on {Boat.name}.", Boat);
			}
			else
			{
				componentInParent.ResetHighlightOutline();
			}
		}
	}

	public Inventory ReturnBoatInventory()
	{
		return _boatInventory;
	}
}
