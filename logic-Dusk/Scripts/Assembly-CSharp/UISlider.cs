using UnityEngine;
using UnityEngine.UI;

public class UISlider : MonoBehaviour
{
	public Image sliderBar;

	public Color baseColorWhenSelected = Color.white;

	public Color baseColorWhenNotSelected = Color.gray;

	public Color barColorWhenSelected = Color.white;

	public Color barColorWhenNotSelected = Color.gray;

	private Image baseSlider;

	private void Awake()
	{
		baseSlider = base.gameObject.GetComponent<Image>();
		baseSlider.color = baseColorWhenNotSelected;
	}

	public void SetValue(float val)
	{
		Vector3 localScale = sliderBar.gameObject.transform.localScale;
		localScale.x = val;
		sliderBar.gameObject.transform.localScale = localScale;
	}

	public void SetFocus()
	{
		baseSlider.color = baseColorWhenSelected;
		sliderBar.color = barColorWhenSelected;
	}

	public void LoseFocus()
	{
		if (baseSlider != null)
		{
			baseSlider.color = baseColorWhenNotSelected;
		}
		sliderBar.color = barColorWhenNotSelected;
	}
}
