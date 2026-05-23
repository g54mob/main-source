using MPUIKIT;
using UnityEngine;
using UnityEngine.UI;

public class SelectUnitUI : MonoBehaviour
{
	[SerializeField]
	private GameObject canvas;

	[SerializeField]
	private Image image;

	[SerializeField]
	private MPImage mpImage;

	private bool animating;

	public void UpdateState(bool visible, Sprite sprite, float selectProgress)
	{
		if (selectProgress > 0.99f)
		{
			visible = false;
		}
		canvas.SetActive(visible);
		image.sprite = sprite;
		mpImage.fillAmount = selectProgress;
	}
}
