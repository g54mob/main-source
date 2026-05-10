using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Popup))]
public class PopupFocusHandler : MonoBehaviour
{
	[SerializeField]
	private Selectable m_FocusOnShown;

	[SerializeField]
	private Selectable m_FocusOnHidden;

	[SerializeField]
	private bool m_GamepadOnly;

	private Popup m_Popup;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnPopupShown()
	{
	}

	private void OnPopupHidden()
	{
	}
}
