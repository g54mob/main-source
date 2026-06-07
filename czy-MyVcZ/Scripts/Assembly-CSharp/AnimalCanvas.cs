using TMPro;
using UnityEngine;

public class AnimalCanvas : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _nameText;

	[SerializeField]
	private TextMeshProUGUI _incomeText;

	[SerializeField]
	private Animator _animator;

	private Animal _animal;

	[SerializeField]
	private Canvas _nameCanvas;

	public void Init(Animal animal)
	{
		_animal = animal;
		_animal.OnNameChanged += UpdateNameText;
		UpdateNameText(string.Empty);
		UpdateIncomeText();
	}

	public void Release()
	{
		_animal.OnNameChanged -= UpdateNameText;
		_animal = null;
	}

	public void UpdateNameText(string name)
	{
		_nameText.text = name;
	}

	public void UpdateIncomeText()
	{
		_incomeText.text = $"+{_animal.AnimalData.Income}";
	}

	public void PlayIncomeTextAnim()
	{
		_animator.SetTrigger("ShowIncome");
	}

	public void SetNameCanvasSortingOrder(int sortingOrder)
	{
		_nameCanvas.sortingOrder = sortingOrder;
	}
}
