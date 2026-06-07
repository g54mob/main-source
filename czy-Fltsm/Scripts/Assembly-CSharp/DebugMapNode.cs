using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebugMapNode : MonoBehaviour
{
	[SerializeField]
	private Image _icon;

	[SerializeField]
	private TextMeshProUGUI _label;

	public void Initialize(TileGeneratorNode node)
	{
		if ((bool)node.Icon)
		{
			_icon.sprite = node.Icon;
		}
		_label.text = node.Label;
		base.gameObject.SetActive(value: true);
		base.transform.localPosition = node.Position;
	}
}
