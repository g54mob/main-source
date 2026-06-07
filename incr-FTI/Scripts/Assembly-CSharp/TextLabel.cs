using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextLabel : MonoBehaviour
{
	public TextMeshProUGUI label;

	public void SetIndentLevel(int level)
	{
		if (base.gameObject.TryGetComponent<LayoutGroup>(out var component))
		{
			component.padding.left = 8 + level * 40;
		}
	}
}
