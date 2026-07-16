using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ComputerScreenSwitch : MonoBehaviour
{
	[SerializeField]
	private Transform cameraPoint;

	[SerializeField]
	private Transform fallbackPoint;

	[SerializeField]
	private Canvas canvas;

	[SerializeField]
	private ComputerScreen[] screens;

	[SerializeField]
	private UIContentAnimator animatorLogoLine;

	[SerializeField]
	private TMP_Text[] labelsTime;

	[SerializeField]
	private TMP_Text[] labelsDay;

	private bool isUsingComputer;

	private UnityEvent onCleanup;

	private void Start()
	{
		canvas.worldCamera = GlobalReferences.GetCameraController().GetCamera();
		InputManager.OnCancelMenuWindow.AddListener(delegate
		{
			EventSystem.current.SetSelectedGameObject(null);
			if (isUsingComputer)
			{
				OnExitComputer();
			}
		});
		animatorLogoLine.BeginWithNormalState();
		for (int num = 0; num < screens.Length; num++)
		{
			GameObject screen = screens[num].screenObject;
			if (screen.GetComponent<UIContentAnimator>() != null)
			{
				screen.GetComponent<UIContentAnimator>().OnFinishedReverse.AddListener(delegate
				{
					screen.SetActive(value: false);
				});
				if (num == 0)
				{
					screen.GetComponent<UIContentAnimator>().BeginWithTargetState();
				}
				else
				{
					screen.GetComponent<UIContentAnimator>().BeginWithNormalState();
				}
			}
		}
		StartCoroutine(SetMainScreen());
	}

	private IEnumerator SetMainScreen()
	{
		yield return new WaitForSeconds(0.25f);
		screens[0].screenObject.SetActive(value: true);
		screens[0].isActive = true;
		if (screens[0].screenObject.GetComponent<UIContentAnimator>() != null)
		{
			screens[0].screenObject.GetComponent<UIContentAnimator>().BeginWithTargetState();
		}
		ReloadUtilities();
		StopCoroutine(SetMainScreen());
	}

	public void RemoveComputer(CharacterControllerComponent character)
	{
		if (!isUsingComputer)
		{
			GetComponent<RemovableInstance>().OnPlayerAction(character);
		}
	}

	public void OnEnterComputer(CharacterControllerComponent character)
	{
		if (character.socket.IsHoldingItem() && character.socket.itemObject == this)
		{
			character.socket.GetItemComponent().OnInteraction(character);
			return;
		}
		fallbackPoint.position = GlobalReferences.GetCameraController().GetCamera().transform.position;
		fallbackPoint.rotation = GlobalReferences.GetCameraController().GetCamera().transform.rotation;
		fallbackPoint.transform.parent = GlobalReferences.GetCharacterController().transform;
		GameStateManager.ChangeCharacterState(GameStateManager.CharacterState.MenuOpen);
		TweenerManager.Tween("EnterComputer", GlobalReferences.GetCameraController().GetCamera().transform, fallbackPoint, cameraPoint, TweenerManager.GetDefaultDuration(), TweenerManager.GetDefaultEaseCurve());
		isUsingComputer = true;
		InputManager.OnMainClick.AddListener(OnComputerClick);
		ReloadUtilities();
	}

	public void OnExitComputer()
	{
		Action executeOnFinish = delegate
		{
			GameStateManager.ChangeCharacterState(GameStateManager.CharacterState.CharacterMode);
			GetComponentInChildren<OverviewScreen>().ExitNameInputField();
			EventSystem.current.SetSelectedGameObject(null);
		};
		TweenerManager.TweenTimeAction("waitForDispatch", 1f, delegate
		{
			fallbackPoint.transform.parent = null;
		});
		TweenerManager.Tween("ExitComputer", GlobalReferences.GetCameraController().GetCamera().transform, cameraPoint, fallbackPoint, TweenerManager.GetDefaultDuration(), TweenerManager.GetDefaultEaseCurve(), executeOnFinish);
		SwitchScreen(0);
		isUsingComputer = false;
		InputManager.OnMainClick.RemoveListener(OnComputerClick);
	}

	private void OnComputerClick()
	{
		SoundManager.PlaySoundOnce("ui_button_tapping");
	}

	public void SwitchScreen(int screenIndex)
	{
		for (int i = 0; i < screens.Length; i++)
		{
			if (screenIndex == i)
			{
				screens[i].screenObject.SetActive(value: true);
				screens[i].isActive = true;
				if (screens[i].screenObject.GetComponent<UIContentAnimator>() != null)
				{
					screens[i].screenObject.GetComponent<UIContentAnimator>().OnPlay();
				}
				if (screens[i].showLogoLine)
				{
					animatorLogoLine.OnPlay();
				}
				else
				{
					animatorLogoLine.OnReverse();
				}
			}
			else
			{
				if (screens[i].screenObject.GetComponent<UIContentAnimator>() != null)
				{
					screens[i].screenObject.GetComponent<UIContentAnimator>().OnReverse();
				}
				else
				{
					screens[i].screenObject.SetActive(value: false);
				}
				screens[i].isActive = false;
			}
		}
	}

	public void ReturnToHome()
	{
		GameManager.ReturnToMenu();
	}

	private void ReloadUtilities()
	{
		WorldTime.SetWorldDayLabels(labelsDay);
		WorldTime.SetWorldTimeLabels(labelsTime);
		OptionsMenu componentInChildren = GetComponentInChildren<OptionsMenu>();
		if (componentInChildren != null)
		{
			componentInChildren.ReloadSettings();
		}
	}
}
