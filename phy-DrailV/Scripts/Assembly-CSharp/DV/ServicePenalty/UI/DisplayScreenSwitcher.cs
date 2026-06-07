using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace DV.ServicePenalty.UI
{
	public class DisplayScreenSwitcher : MonoBehaviour
	{
		private const float PLAYER_DISTANCE_CHECK_PERIOD = 5f;

		private const float PLAYER_NEAR_SCREEN_DISTANCE_THRESHOLD = 5f;

		public Color HIGHLIGHTED_COLOR = new Color(1f, 0.54f, 0f);

		public Color REGULAR_COLOR = new Color(0.74f, 0.57f, 0.27f);

		public List<TextMeshPro> allTextFields;

		public GameObject startScreenGO;

		public AudioClip inputActionSound;

		private IDisplayScreen idleScreen;

		private HashSet<InputAction> blockedInputs = new HashSet<InputAction>();

		private Coroutine checkIfPlayerNearScreenCoro;

		public IDisplayScreen CurrentScreen { get; private set; }

		public event Action<IDisplayScreen> DisplayScreenUpdated;

		private void Awake()
		{
			if (inputActionSound == null)
			{
				Debug.LogError("inputActionSound is missing!");
			}
			foreach (TextMeshPro allTextField in allTextFields)
			{
				allTextField.text = string.Empty;
			}
		}

		private void Start()
		{
			idleScreen = startScreenGO.GetComponent<IDisplayScreen>();
			if (idleScreen == null)
			{
				Debug.LogError("startScreenGO doesn't have required IDisplayScreen component attached. No screen will be displayed on start");
			}
			else
			{
				SetActiveDisplay(idleScreen);
			}
		}

		private void OnDestroy()
		{
			if (CurrentScreen != null)
			{
				CurrentScreen.Disable();
			}
		}

		public void SetActiveDisplay(IDisplayScreen nextScreen)
		{
			if (CurrentScreen != null)
			{
				CurrentScreen.Disable();
			}
			if (nextScreen != idleScreen)
			{
				if (checkIfPlayerNearScreenCoro == null)
				{
					checkIfPlayerNearScreenCoro = StartCoroutine(CheckIfPlayerNearScreen());
				}
			}
			else if (checkIfPlayerNearScreenCoro != null)
			{
				StopCoroutine(checkIfPlayerNearScreenCoro);
				checkIfPlayerNearScreenCoro = null;
			}
			IDisplayScreen currentScreen = CurrentScreen;
			CurrentScreen = nextScreen;
			CurrentScreen.Activate(currentScreen);
			this.DisplayScreenUpdated?.Invoke(CurrentScreen);
		}

		public void HandleInput(InputAction input)
		{
			if (!blockedInputs.Contains(input))
			{
				if (inputActionSound != null)
				{
					inputActionSound.Play(base.transform.position, 1f, 1f, 0f, 1f, 10f, default(AudioSourceCurves), null, base.transform);
				}
				if (CurrentScreen != null)
				{
					CurrentScreen.HandleInputAction(input);
				}
			}
		}

		private IEnumerator CheckIfPlayerNearScreen()
		{
			while (PlayerManager.PlayerTransform == null)
			{
				yield return WaitFor.Seconds(5f);
			}
			do
			{
				yield return WaitFor.Seconds(5f);
			}
			while (!((base.transform.position - PlayerManager.PlayerTransform.position).sqrMagnitude > 5f));
			SetActiveDisplay(idleScreen);
			checkIfPlayerNearScreenCoro = null;
		}

		public void ToggleAllInputs(bool on)
		{
			if (on)
			{
				blockedInputs.Clear();
			}
			else
			{
				BlockInputs(Enum.GetValues(typeof(InputAction)).Cast<InputAction>().ToArray());
			}
		}

		public void BlockInputs(params InputAction[] inputsToBlock)
		{
			foreach (InputAction item in inputsToBlock)
			{
				blockedInputs.Add(item);
			}
		}

		public void UnblockInputs(params InputAction[] inputsToUnblock)
		{
			foreach (InputAction item in inputsToUnblock)
			{
				blockedInputs.Remove(item);
			}
		}
	}
}
