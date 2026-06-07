using TMPro;
using UnityEngine;

public class DrifterAttributeSpendablePointCounter : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _text;

	private DrifterAttributes _attributes;

	public void Initialize(DrifterAttributes attributes)
	{
		_attributes = attributes;
		UpdatePoints();
	}

	private void OnEnable()
	{
		if (_attributes != null)
		{
			_attributes.AvailableSpendingPointsUpdatedEvent.AddListener(UpdatePoints);
			UpdatePoints();
		}
	}

	private void OnDisable()
	{
		if (_attributes != null)
		{
			_attributes.AvailableSpendingPointsUpdatedEvent.RemoveListener(UpdatePoints);
		}
	}

	private void UpdatePoints()
	{
		_text.text = _attributes.SpendablePoints.ToString();
	}
}
