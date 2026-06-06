using System;
using UnityEngine;

public class FocusView : MonoBehaviour
{
	private AnimalPrefab _focusableAnimalPrefab;

	public bool IsFocusing { get; private set; }

	public event Action<AnimalPrefab> OnShowFocusView;

	public event Action OnHideFocusView;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Hide();
		}
	}

	public void Show()
	{
		base.gameObject.SetActive(value: true);
		this.OnShowFocusView?.Invoke(_focusableAnimalPrefab);
		IsFocusing = true;
	}

	public void Hide()
	{
		IsFocusing = false;
		this.OnHideFocusView?.Invoke();
		base.gameObject.SetActive(value: false);
	}

	public void SetFocusableAnimal(AnimalPrefab animalPrefab)
	{
		_focusableAnimalPrefab = animalPrefab;
		if (!HasFocusableAnimal())
		{
			Hide();
		}
	}

	public bool HasFocusableAnimal()
	{
		return _focusableAnimalPrefab != null;
	}
}
