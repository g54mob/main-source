using UnityEngine;
using UnityEngine.Localization.Components;

public class ToolWheelInputHintHandler : MonoBehaviour
{
	[SerializeField]
	private string m_ReferanceString;

	[SerializeField]
	private LocalizeStringEvent m_hintLocalizeEvent;

	private void Start()
	{
	}

	private void OnGamepadConnected(bool obj)
	{
	}
}
