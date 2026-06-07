using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class AnimalPos : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	private AnimalPrefab _currentAnimalPrefab;

	[SerializeField]
	private SortingGroup _sortingGroup;

	private int _currentSortingOrder;

	public void SetCurrentAnimalPrefab(AnimalPrefab animalPrefab)
	{
		_currentAnimalPrefab = animalPrefab;
	}

	private void Awake()
	{
		_sortingGroup = GetComponent<SortingGroup>();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		MonoSingleton<AnimalPickController>.Instance.OnPickAnimalSpawnPos(this);
	}

	public void SetPickState()
	{
		if (_sortingGroup == null)
		{
			_sortingGroup = GetComponent<SortingGroup>();
		}
		if (_sortingGroup != null)
		{
			_sortingGroup.sortingOrder = 1000;
		}
	}

	public void SetUnpickState()
	{
		if (_sortingGroup == null)
		{
			_sortingGroup = GetComponent<SortingGroup>();
		}
		if (_sortingGroup != null)
		{
			_sortingGroup.sortingOrder = _currentSortingOrder;
		}
	}

	public void SetPlaceUpperGround()
	{
		SetCurrentSortingOrder(1);
		if (_currentAnimalPrefab != null)
		{
			_currentAnimalPrefab.SetNameCanvasSortingOrder(1);
		}
	}

	public void SetPlaceLowerGround()
	{
		SetCurrentSortingOrder(0);
		if (_currentAnimalPrefab != null)
		{
			_currentAnimalPrefab.SetNameCanvasSortingOrder(0);
		}
	}

	public int GetCurrentSortingOrder()
	{
		return _currentSortingOrder;
	}

	public void SetCurrentSortingOrder(int sortingOrder)
	{
		_currentSortingOrder = sortingOrder;
		if (_sortingGroup == null)
		{
			_sortingGroup = GetComponent<SortingGroup>();
		}
		if (_sortingGroup == null)
		{
			Debug.LogWarning("SortingGroup component not found on " + base.gameObject.name + ". Cannot set sorting order.");
			return;
		}
		_sortingGroup.sortingOrder = _currentSortingOrder;
		if (_currentAnimalPrefab != null)
		{
			_currentAnimalPrefab.SetNameCanvasSortingOrder(_currentSortingOrder);
		}
	}

	public bool IsPickable()
	{
		return _currentAnimalPrefab != null;
	}
}
