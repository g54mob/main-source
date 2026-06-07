using UnityEngine;
using UnityEngine.UI;

public class TownEnergyImageTracker : TownEnergyTracker
{
	[SerializeField]
	private Image _image;

	public override void SetValue(float energy, float capacity)
	{
		_image.fillAmount = energy / capacity;
	}
}
