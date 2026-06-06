using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedPodPanel : MonoBehaviour, IBuildablePanelElement
{
	[SerializeField]
	private DrifterSlot _drifterSlot;

	[SerializeField]
	private InventoryPanelItemSlot _medicationSlot;

	[SerializeField]
	private Slider _progressSlider;

	[SerializeField]
	private ChildBehaviourCache<CommunityInventoryItemSlot> _medicinesSlotCache;

	[Header("Status")]
	[SerializeField]
	private PlaceableAlertProperties _waitingForPatient;

	[SerializeField]
	private PlaceableAlertProperties _waitingForDoctor;

	[SerializeField]
	private PlaceableAlertProperties _treatingPatient;

	private MedPod _medPod;

	private List<ItemProperties> _medicines;

	public BuildablePanelElementId Id => BuildablePanelElementId.MedPod;

	private void OnDisable()
	{
		RemoveListeners();
		_medPod = null;
	}

	public bool Activate(Buildable buildable, bool finished)
	{
		Deactivate();
		if (finished && buildable.TryReturnBuildableExtendable<MedPod>(out _medPod))
		{
			_ = _medicines;
			_medicines = buildable.Community.Inventory.ReturnItemPropertiesWithTags(Item.Tags.Medicine);
			_medicinesSlotCache.Reset();
			foreach (ItemProperties medicine in _medicines)
			{
				_medicinesSlotCache.Get(active: true).Initialize(medicine);
			}
			_medicinesSlotCache.Trim();
			_medPod.OnUpdated += UpdateState;
			UpdateState(_medPod);
			base.gameObject.SetActive(value: true);
			return true;
		}
		return false;
	}

	public void Deactivate()
	{
		RemoveListeners();
		base.gameObject.SetActive(value: false);
	}

	private void UpdateState(MedPod medPod)
	{
		if (!(_medPod == null))
		{
			_drifterSlot.SetDrifter(_medPod.OccupyingPatient);
			_progressSlider.value = _medPod.Progress;
			if (_medPod.Medication == null)
			{
				_medicationSlot.Initialize(null, 0, showCounter: false);
			}
			else
			{
				_medicationSlot.Initialize(_medPod.Medication.Properties, 1, showCounter: false);
			}
			if (_medPod.OccupyingPatient == null)
			{
				_medPod.Buildable.SetStatus(_waitingForPatient);
			}
			else if (_medPod.Doctor == null)
			{
				_medPod.Buildable.SetStatus(_waitingForDoctor);
			}
			else
			{
				_medPod.Buildable.SetStatus(_treatingPatient);
			}
		}
	}

	private void RemoveListeners()
	{
		if ((bool)_medPod)
		{
			_medPod.OnUpdated -= UpdateState;
		}
	}
}
