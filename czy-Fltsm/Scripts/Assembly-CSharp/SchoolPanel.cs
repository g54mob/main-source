using UnityEngine;
using UnityEngine.UI;

public class SchoolPanel : MonoBehaviour, IBuildablePanelElement
{
	[SerializeField]
	private ItemCounterSlot _studyItemSlot;

	[SerializeField]
	private Slider _remainingStudyTime;

	[SerializeField]
	private ChildBehaviourCache<SchoolPanelSlot> _slotCache;

	private School _school;

	private int _studyItemCount;

	public BuildablePanelElementId Id => BuildablePanelElementId.School;

	private void LateUpdate()
	{
		if (_school != null)
		{
			_studyItemSlot.SetCount(_school.Buildable.Community.Inventory.ReturnCount(_school.CommunityResearch.StudyItem), updateBackgroundColor: true);
			_remainingStudyTime.value = _school.CommunityResearch.RemainingStudyTimeNormalized();
		}
	}

	public bool Activate(Buildable buildable, bool finished)
	{
		Deactivate();
		if (finished && buildable.TryReturnBuildableExtendable<School>(out _school))
		{
			_studyItemSlot.Initialize(_school.CommunityResearch.StudyItem, _school.Buildable.Community.Inventory.ReturnCount(_school.CommunityResearch.StudyItem), showCounter: true);
			_remainingStudyTime.value = _school.CommunityResearch.RemainingStudyTimeNormalized();
			_school.OnCurrentDrifterUpdatedEvent.AddListener(UpdateStudentSlots);
			UpdateStudentSlots();
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

	private void RemoveListeners()
	{
		if ((bool)_school)
		{
			_school.OnCurrentDrifterUpdatedEvent.RemoveListener(UpdateStudentSlots);
			_school = null;
		}
	}

	private void UpdateStudentSlots()
	{
		_slotCache.Reset();
		for (int i = 0; i < _school.SlotCount; i++)
		{
			_slotCache.Get(active: true).Initialize(_school.GetStudent(i));
		}
		_slotCache.Trim();
	}
}
