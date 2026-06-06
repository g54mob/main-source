using UnityEngine;

public class FoodRationVisual : MonoBehaviour
{
	[SerializeField]
	private GameObject _halfEatenVisual;

	[SerializeField]
	private GameObject _uneatenVisual;

	public void UpdateVisual(int progress)
	{
		switch (progress)
		{
		case 0:
			_halfEatenVisual.SetActive(value: false);
			_uneatenVisual.SetActive(value: false);
			break;
		case 1:
			_halfEatenVisual.SetActive(value: true);
			_uneatenVisual.SetActive(value: false);
			break;
		default:
			_halfEatenVisual.SetActive(value: false);
			_uneatenVisual.SetActive(value: true);
			break;
		}
	}
}
