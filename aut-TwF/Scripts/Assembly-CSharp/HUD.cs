using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

[RequireComponent(typeof(GraphicRaycaster))]
public class HUD : MonoBehaviour
{
	[Header("HUD")]
	[SerializeField]
	private FadeInOut fadeInOut;

	[SerializeField]
	private ModalWindow modalWindowPrefab;

	[SerializeField]
	private InputModalWindow inputModalWindowPrefab;

	private HUDMenu currentUI;

	private PlayerController playerController;

	private Canvas hudCanvas;

	private RectTransform worldObjectsContainer;

	private DepthOfField dof;

	private float startDofFocusDistance;

	private bool dofEnabledByDefault;

	private Coroutine changeSceneCoroutine;

	private ModalWindow currentModalWindow;

	public PlayerController PlayerController
	{
		get
		{
			return playerController;
		}
		set
		{
			playerController = value;
		}
	}

	public HUDMenu CurrentUI
	{
		get
		{
			return currentUI;
		}
		protected set
		{
			currentUI = value;
		}
	}

	public RectTransform WorldObjectsContainer
	{
		get
		{
			return worldObjectsContainer;
		}
		private set
		{
			worldObjectsContainer = value;
		}
	}

	public FadeInOut FadeInOut => fadeInOut;

	public ModalWindow CurrentModalWindow => currentModalWindow;

	protected virtual void Awake()
	{
		hudCanvas = GetComponent<Canvas>();
		fadeInOut.gameObject.SetActive(value: true);
		WorldObjectsContainer = new GameObject("WorldObjects", typeof(RectTransform)).GetComponent<RectTransform>();
		WorldObjectsContainer.SetParent(base.transform);
		WorldObjectsContainer.SetAsFirstSibling();
		WorldObjectsContainer.sizeDelta = GetComponent<RectTransform>().sizeDelta;
		worldObjectsContainer.anchoredPosition = Vector3.zero;
		worldObjectsContainer.AddComponent<Canvas>();
		worldObjectsContainer.AddComponent<CanvasScaler>();
		worldObjectsContainer.localScale = Vector3.one;
	}

	protected virtual void Start()
	{
		GameManager.instance.CurrentLevelController.PostProcessingProfile.profile.TryGet<DepthOfField>(out dof);
		startDofFocusDistance = dof.focusDistance.value;
		dofEnabledByDefault = dof.active;
		BlurBackground(enable: false);
		hudCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
	}

	private void Update()
	{
		ManageBackButtonPressed();
	}

	private void ManageBackButtonPressed()
	{
		if (changeSceneCoroutine == null && ((Keyboard.current != null && Keyboard.current[Key.Escape].wasPressedThisFrame) || (Gamepad.current != null && Gamepad.current[GamepadButton.East].wasPressedThisFrame)))
		{
			if ((bool)currentModalWindow)
			{
				currentModalWindow.CancelPressed();
			}
			else if ((bool)currentUI)
			{
				currentUI.BackButtonPressed();
			}
		}
	}

	protected void ShowMenu(HUDMenu menu)
	{
		if (CurrentUI != menu)
		{
			if ((bool)CurrentUI)
			{
				CurrentUI.gameObject.SetActive(value: false);
			}
			CurrentUI = menu;
			CurrentUI.gameObject.SetActive(value: true);
			if (CurrentUI.TryGetComponent<AutoTransformRebuild>(out var component))
			{
				component.RebuildTransform();
			}
		}
	}

	public ModalWindow ShowCustomModalWindow(ModalWindow modalWindow)
	{
		if ((bool)currentModalWindow)
		{
			UnityEngine.Object.Destroy(currentModalWindow.gameObject);
		}
		currentModalWindow = UnityEngine.Object.Instantiate(modalWindowPrefab, base.transform);
		return currentModalWindow;
	}

	public void ShowModalWindowOneButton(string bodyMessage, string header, Sprite sprite, Action yesAction, string yesButtonText = "")
	{
		if ((bool)currentModalWindow)
		{
			UnityEngine.Object.Destroy(currentModalWindow.gameObject);
		}
		currentModalWindow = UnityEngine.Object.Instantiate(modalWindowPrefab, base.transform);
		(currentModalWindow as DefaultModalWindow).SetUp(bodyMessage, header, sprite, yesAction, null, yesButtonText);
	}

	public void ShowModalWindowTwoButtons(string bodyMessage, string header, Sprite sprite, Action yesAction, Action noAction, string yesButtonText = "", string noButtonText = "")
	{
		if ((bool)currentModalWindow)
		{
			UnityEngine.Object.Destroy(currentModalWindow.gameObject);
		}
		currentModalWindow = UnityEngine.Object.Instantiate(modalWindowPrefab, base.transform);
		(currentModalWindow as DefaultModalWindow).SetUp(bodyMessage, header, sprite, yesAction, noAction, yesButtonText, noButtonText, forceShowBothButtons: true);
	}

	public void ShowInputModalWindow(string defaultInputText, string header, Action<string> yesAction, string yesButtonText = "", int characterLimit = -1)
	{
		if ((bool)currentModalWindow)
		{
			UnityEngine.Object.Destroy(currentModalWindow.gameObject);
		}
		currentModalWindow = UnityEngine.Object.Instantiate(inputModalWindowPrefab, base.transform);
		(currentModalWindow as InputModalWindow).SetUp(header, defaultInputText, yesAction, null, yesButtonText, "", forceShowBothButtons: false, characterLimit);
	}

	public void ShowInputModalWindowTwoButtons(string defaultInputText, string header, Action<string> yesAction, Action noAction, string yesButtonText = "", string noButtonText = "", int characterLimit = -1)
	{
		if ((bool)currentModalWindow)
		{
			UnityEngine.Object.Destroy(currentModalWindow.gameObject);
		}
		currentModalWindow = UnityEngine.Object.Instantiate(inputModalWindowPrefab, base.transform);
		(currentModalWindow as InputModalWindow).SetUp(header, defaultInputText, yesAction, null, yesButtonText, noButtonText, forceShowBothButtons: true, characterLimit);
	}

	public void CloseModalWindow()
	{
		if ((bool)currentModalWindow)
		{
			UnityEngine.Object.Destroy(currentModalWindow.gameObject);
		}
	}

	public void BlurBackground(bool enable)
	{
		dof.active = dofEnabledByDefault || enable;
		dof.focusDistance.value = (enable ? 0f : startDofFocusDistance);
	}
}
