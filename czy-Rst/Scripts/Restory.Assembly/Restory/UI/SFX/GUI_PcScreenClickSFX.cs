using FMODUnity;
using Restory.Audio;
using Restory.Gameplay.PlayerInput;
using Restory.UI.Presenters;
using Restory.Utils;
using Rewired;
using UnityEngine;
using Zenject;

namespace Restory.UI.SFX
{
	public sealed class GUI_PcScreenClickSFX : MonoBehaviour
	{
		private IAudioPlayerService audioPlayer;

		private IPlayerInput playerInput;

		private GUI_PcWindowsXpScreen pcWindowsXpScreen;

		[SerializeField]
		private EventReference mouseClickSound;

		private RectTransform rectTransform;

		[Inject]
		private void Construct(IPlayerInput playerInput, IAudioPlayerService audioPlayer, GUI_PcWindowsXpScreen pcWindowsXpScreen)
		{
			this.pcWindowsXpScreen = pcWindowsXpScreen;
			this.playerInput = playerInput;
			this.audioPlayer = audioPlayer;
		}

		private void Awake()
		{
			rectTransform = GetComponent<RectTransform>();
		}

		private void OnEnable()
		{
			ResolvePcScreenVisibilityChanged();
			pcWindowsXpScreen.OnIsVisibleChanged += ResolvePcScreenVisibilityChanged;
		}

		private void OnDisable()
		{
			if (pcWindowsXpScreen.MonoShellExists())
			{
				pcWindowsXpScreen.OnIsVisibleChanged -= ResolvePcScreenVisibilityChanged;
			}
		}

		private void ResolvePcScreenVisibilityChanged()
		{
			if (pcWindowsXpScreen.IsVisible)
			{
				playerInput.AddInputEventDelegate(ResolveMouseClicked, InputActionEventType.ButtonJustReleased, 81);
			}
			else
			{
				playerInput.RemoveInputEventDelegate(ResolveMouseClicked, InputActionEventType.ButtonJustReleased, 81);
			}
		}

		private void ResolveMouseClicked(InputActionEventData inputData)
		{
			Vector2 mousePosition = playerInput.GetMousePosition();
			if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, mousePosition))
			{
				audioPlayer.PlaySoundEventOneShot(mouseClickSound);
			}
		}
	}
}
