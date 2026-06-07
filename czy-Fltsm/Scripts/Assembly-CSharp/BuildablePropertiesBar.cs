using UnityEngine;

public class BuildablePropertiesBar : MonoBehaviour
{
	[SerializeField]
	private TextField _footPrint;

	[SerializeField]
	private IntField _weight;

	[SerializeField]
	private IntField _beauty;

	[SerializeField]
	private IntField _energy;

	public void Initialize(PlaceableProperties properties)
	{
		_footPrint.SetText(properties.GetFootprint());
		_beauty.SetInt(properties.BeautyScore);
		if (properties.TryGetEnergyCost(out var energyCost))
		{
			_energy.SetFloat(energyCost);
		}
		else
		{
			_energy.gameObject.SetActive(value: false);
		}
		_weight.SetFloat(properties.Weight);
		base.gameObject.SetActive(value: true);
	}
}
