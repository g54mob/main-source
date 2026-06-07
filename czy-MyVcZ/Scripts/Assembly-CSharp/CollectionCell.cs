using System;
using UnityEngine;
using UnityEngine.UI;

public class CollectionCell : MonoBehaviour
{
	[SerializeField]
	private Image _animalIcon;

	[SerializeField]
	private Image _animalIconShadow;

	[SerializeField]
	private GameObject _selectFrame;

	public Animal Animal { get; private set; }

	public event Action<CollectionCell> OnSelectCollectionCell;

	public void Show(Animal animal)
	{
		Animal = animal;
		_animalIcon.sprite = Resources.Load<Sprite>(Animal.AnimalData.IconPath);
		_animalIconShadow.sprite = Resources.Load<Sprite>(Animal.AnimalData.IconShadowPath);
		UpdateCellState();
		base.gameObject.SetActive(value: true);
	}

	public void Hide()
	{
		Animal = null;
		base.gameObject.SetActive(value: false);
	}

	public void UpdateCellState()
	{
		if (Animal.IsCollected)
		{
			SetUnlock();
		}
		else
		{
			SetLock();
		}
	}

	public void SetUnlock()
	{
		_animalIcon.gameObject.SetActive(value: true);
		_animalIconShadow.gameObject.SetActive(value: false);
	}

	public void SetLock()
	{
		_animalIcon.gameObject.SetActive(value: false);
		_animalIconShadow.gameObject.SetActive(value: true);
	}

	public void SetSelect()
	{
		_selectFrame.SetActive(value: true);
	}

	public void SetUnselect()
	{
		_selectFrame.SetActive(value: false);
	}

	public void OnClickSelectButton()
	{
		this.OnSelectCollectionCell?.Invoke(this);
	}
}
