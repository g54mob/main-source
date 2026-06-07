using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DrifterDietRow : MonoBehaviour
{
	[SerializeField]
	private ChildBehaviourCache<DietBox> _dietBoxCache;

	[SerializeField]
	private Transition _transition;

	[Header("TEMP")]
	[SerializeField]
	private Image _foodIcon;

	[SerializeField]
	private Image _hungerIcon;

	[SerializeField]
	private Sprite _mortalDangerSprite;

	private DietBox _selectedBox;

	private int _selectedBoxIndex = -1;

	public Agent Drifter { get; private set; }

	public void Initialize(Agent drifter)
	{
		Drifter = drifter;
		_dietBoxCache.Reset();
		if (drifter.Vitals.TryReturnDiet(VitalType.Hunger, out var diet))
		{
			foreach (ItemProperties item in GameManager.Settings.ItemSettings.ReturnFoodItemProperties())
			{
				_dietBoxCache.Get().Initialize(drifter, diet, item);
			}
			if (diet.LastReservedItemToConsume == null)
			{
				_foodIcon.overrideSprite = null;
			}
			else
			{
				_foodIcon.overrideSprite = diet.LastReservedItemToConsume.InventorySprite;
			}
		}
		_hungerIcon.gameObject.SetActive(drifter.Vitals.Hunger.Amount != 0);
		_hungerIcon.overrideSprite = (drifter.Vitals.Hunger.IsInDangerOfDying() ? _mortalDangerSprite : null);
		_dietBoxCache.Trim();
	}

	public int Select(int index)
	{
		SelectBox(index);
		_transition.SetSelected();
		return _selectedBoxIndex;
	}

	public int SelectLeft(int index)
	{
		return SelectBox(index - 1);
	}

	public int SelectRight(int index)
	{
		return SelectBox(index + 1);
	}

	public void Deselect()
	{
		_selectedBox.OnDeselect();
		_selectedBox = null;
		_selectedBoxIndex = -1;
		_transition.SetNormal();
	}

	public void IncreaseSelected()
	{
		if ((bool)_selectedBox)
		{
			_selectedBox.UpdatePriority(increase: true, refresh: true);
		}
	}

	public void DecreaseSelected()
	{
		if ((bool)_selectedBox)
		{
			_selectedBox.UpdatePriority(increase: false, refresh: true);
		}
	}

	private int SelectBox(int index)
	{
		index = Mathf.Clamp(index, 0, _dietBoxCache.Instances.Count - 1);
		if (index == _selectedBoxIndex)
		{
			return index;
		}
		DietBox dietBox = _dietBoxCache.Instances[index];
		if (dietBox == null)
		{
			return _selectedBoxIndex;
		}
		if ((bool)_selectedBox)
		{
			_selectedBox.OnDeselect();
		}
		_selectedBoxIndex = index;
		_selectedBox = dietBox;
		_selectedBox.OnSelect();
		return index;
	}

	public void OnPointerEnter(PointerEventData pointerEventData)
	{
		AgentEvent.Dispatch(GameEventType.AgentFullscreenPanelRefresh, Drifter);
	}
}
