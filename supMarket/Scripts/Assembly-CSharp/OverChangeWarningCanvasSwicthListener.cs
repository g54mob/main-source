using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class OverChangeWarningCanvasSwicthListener : MonoBehaviour
{
	[SerializeField]
	private LocalizeStringEvent m_Description;

	[SerializeField]
	private Image m_RightClickImage;

	[SerializeField]
	private Sprite m_RightClick;

	[SerializeField]
	private Sprite m_XButton;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	private void OnGamePadConnected(bool obj)
	{
	}
}
