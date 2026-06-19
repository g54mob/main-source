using UnityEngine;

public class HealthBar : MonoBehaviour
{
	public GameObject root;

	public GameObject healthBarMaskPivot;

	public bool showHealthBarAtFullHealth;

	public SpriteRenderer bar;

	public SpriteRenderer background;

	public GameObject armorBarRoot;

	public GameObject armorBarMaskPivot;

	public SpriteRenderer armorBar;

	public SpriteRenderer armorBackground;

	public float barWidth = 20f;

	public bool autoSizeBar = true;

	public float resurrectionHealthRatioThreshold;

	public Color healthColor;

	public Color immuneColor;

	private void OnValidate()
	{
		Vector2 vector = new Vector2(barWidth * 0.0625f, 0.125f);
		if (autoSizeBar && bar != null && bar.size != vector)
		{
			bar.size = vector;
			background.size = new Vector2(barWidth * 0.0625f + 0.125f, 0.25f);
			healthBarMaskPivot.transform.localPosition = new Vector3((0f - barWidth) * 0.0625f * 0.5f, 0f, 0f);
			bar.transform.localPosition = new Vector3(barWidth * 0.0625f * 0.5f, 0f, 0f);
			armorBar.size = vector;
			armorBackground.size = new Vector2(barWidth * 0.0625f + 0.125f, 0.25f);
			armorBarMaskPivot.transform.localPosition = healthBarMaskPivot.transform.localPosition;
			armorBar.transform.localPosition = new Vector3(Mathf.Abs(armorBarMaskPivot.transform.localPosition.x), 0f, 0f);
		}
	}

	private void Start()
	{
		root.SetActive(value: false);
	}

	public void UpdateHealthBar(float value, int protectiveArmorValue, int maxProtectiveArmorValue, bool overrideShowHealthBar = false)
	{
		if (resurrectionHealthRatioThreshold > 0f)
		{
			if (value > resurrectionHealthRatioThreshold)
			{
				value -= resurrectionHealthRatioThreshold;
				value /= resurrectionHealthRatioThreshold;
			}
			else if (value <= resurrectionHealthRatioThreshold)
			{
				value /= resurrectionHealthRatioThreshold;
			}
		}
		if (Manager.prefs.hideInGameUI)
		{
			root.SetActive(value: false);
		}
		else if (!overrideShowHealthBar && ((!showHealthBarAtFullHealth && value >= 1f && (maxProtectiveArmorValue == 0 || protectiveArmorValue == maxProtectiveArmorValue)) || value <= 0f))
		{
			root.SetActive(value: false);
		}
		else
		{
			root.SetActive(value: true);
			healthBarMaskPivot.transform.localScale = new Vector3(Mathf.Clamp(value, 0f, 1f), 1f, 1f);
			armorBarRoot.SetActive(maxProtectiveArmorValue > 0);
			if (maxProtectiveArmorValue > 0)
			{
				float value2 = (float)protectiveArmorValue / (float)maxProtectiveArmorValue;
				armorBarMaskPivot.transform.localScale = new Vector3(Mathf.Clamp(value2, 0f, 1f), 1f, 1f);
			}
		}
		bar.color = ((maxProtectiveArmorValue > 0 && protectiveArmorValue > 0) ? immuneColor : healthColor);
	}
}
