using DV.Interaction.Inputs;
using UnityEngine;

namespace DV.Utils
{
	public class RewiredPlatformInputFieldHandler : MonoBehaviour
	{
		private void Awake()
		{
			SingletonBehaviour<APlatformProvider>.Instance.OnTextInputStarted += OnTextInputStarted;
			SingletonBehaviour<APlatformProvider>.Instance.OnTextInputFinished += OnTextInputFinished;
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<APlatformProvider>.Instance.OnTextInputStarted -= OnTextInputStarted;
				SingletonBehaviour<APlatformProvider>.Instance.OnTextInputFinished -= OnTextInputFinished;
				OnTextInputFinished();
			}
		}

		private void OnTextInputFinished()
		{
			InputManager.SetKeyboardAndMouseEnabled(this, enabled: true);
		}

		private void OnTextInputStarted(APlatformProvider.TextInputRequest request)
		{
			InputManager.SetKeyboardAndMouseEnabled(this, enabled: false);
		}
	}
}
