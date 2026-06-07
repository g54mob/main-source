using TMPro;
using UnityEngine;

public class LabelFormatter : MonoBehaviour
{
	private TextMeshProUGUI label;

	public TextFormatType format;

	private void Awake()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		label = GetComponent<TextMeshProUGUI>();
		if (null != label)
		{
			label.enableWordWrapping = false;
			label.enableAutoSizing = false;
			if (format == TextFormatType.Small)
			{
				label.fontSize = 16f;
			}
			else if (format == TextFormatType.Normal)
			{
				label.fontSize = 20f;
			}
			else if (format == TextFormatType.Header)
			{
				label.fontSize = 24f;
			}
		}
		else
		{
			Debug.LogWarning("Did not find label to format on " + base.gameObject.name);
		}
	}
}
