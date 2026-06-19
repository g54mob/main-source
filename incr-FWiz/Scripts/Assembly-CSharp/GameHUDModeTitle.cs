using TMPro;
using UnityEngine;

public class GameHUDModeTitle : MonoBehaviour
{
	[SerializeField]
	private CanvasGroup _canvasGroup;

	[SerializeField]
	private TextMeshProUGUI _titleText;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnChangeMode(PlayerActionMode mode)
	{
	}
}
