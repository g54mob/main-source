using UnityEngine;

public class NameChangeCanvasVirtualKeyboardAdjuster : MonoBehaviour
{
	[SerializeField]
	private RectTransform m_NameChangeCanvas;

	[SerializeField]
	private RectTransform m_VirtualKeyboard;

	[SerializeField]
	private GameObject m_CarretIcon;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	public void OnGamePadConnected(bool isConnected)
	{
	}
}
