using UnityEngine;
using UnityEngine.UI;

public class IconToggle : MonoBehaviour
{
	public Image TargetGraphic;

	public Color Off;

	public Color On;

	private Toggle toggle;

	public Image Alt;

	public Color OffAlt;

	public Color OnAlt;

	public bool UseAlt;

	public bool UseAccent = true;

	private void Awake()
	{
		toggle = GetComponent<Toggle>();
		OnValueChange();
	}

	public void OnValueChange()
	{
		TargetGraphic.color = ((!toggle.isOn) ? Off : (UseAccent ? HUD.GetAccentColor() : On));
		if (UseAlt)
		{
			Alt.color = (toggle.isOn ? OnAlt : OffAlt);
		}
	}
}
