using MPUIKIT;
using UnityEngine;

public class ProductionBar : MonoBehaviour
{
	[SerializeField]
	private GameObject canvasParent;

	[SerializeField]
	private MPImage fill;

	private float fillAmount = -1f;

	public void UpdateVisual(float _fillAmount)
	{
		if (fillAmount != _fillAmount)
		{
			canvasParent.SetActive(_fillAmount > 0f);
			fill.fillAmount = _fillAmount;
			fillAmount = _fillAmount;
		}
	}
}
