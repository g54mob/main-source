using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToolTipInteract : MonoBehaviour
{
	[SerializeField]
	private Image image;

	[SerializeField]
	private TextMeshProUGUI textMesh;

	[SerializeField]
	private Sprite defaultSprite;

	public void ShowTooltipForInteract(string _text, Sprite _sprite = null)
	{
	}

	public void HideTooltipForInteract()
	{
	}
}
