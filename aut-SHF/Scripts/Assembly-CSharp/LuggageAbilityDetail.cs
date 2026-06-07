using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class LuggageAbilityDetail : MonoBehaviour
{
	[SerializeField]
	private Image luggageIcon;

	[SerializeField]
	private LuggageAbilityInfo[] luggageAbilityInfoList;

	[SerializeField]
	private RectTransform _windowRect;

	[SerializeField]
	private InputActionReference _inputAction;

	[SerializeField]
	private CanvasGroup _canvasGroup;

	private const float HeaderHeight = 90f;

	private const float StarHeight = 20f;

	private InputAction _action;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public void ShowLuggageAbilityDetail(eLuggage luggage)
	{
	}
}
