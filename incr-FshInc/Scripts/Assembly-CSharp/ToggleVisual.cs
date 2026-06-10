using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleVisual : MonoBehaviour
{
	public Image iconImage;

	public Sprite onSprite;

	public Sprite offSprite;

	private Toggle toggle;

	private void Awake()
	{
		toggle = GetComponent<Toggle>();
		UpdateVisual(toggle.isOn);
		toggle.onValueChanged.AddListener(UpdateVisual);
	}

	private void OnDestroy()
	{
		if (toggle != null)
		{
			toggle.onValueChanged.RemoveListener(UpdateVisual);
		}
	}

	private void UpdateVisual(bool isOn)
	{
		if (!(iconImage == null))
		{
			iconImage.sprite = (isOn ? onSprite : offSprite);
		}
	}
}
