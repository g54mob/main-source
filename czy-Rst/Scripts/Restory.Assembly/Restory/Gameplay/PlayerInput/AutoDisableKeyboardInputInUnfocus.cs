using System.Collections;
using Rewired;
using UnityEngine;

namespace Restory.Gameplay.PlayerInput
{
	public sealed class AutoDisableKeyboardInputInUnfocus : MonoBehaviour
	{
		[SerializeField]
		private float delayEnable = 0.1f;

		private bool hasRewiredInitialized;

		private Coroutine enableKeyboardCoroutine;

		private void Awake()
		{
			hasRewiredInitialized = ReInput.isReady;
			if (!hasRewiredInitialized)
			{
				ReInput.InitializedEvent += OnRewiredInitialized;
			}
		}

		private void OnDestroy()
		{
			ReInput.InitializedEvent -= OnRewiredInitialized;
		}

		private void OnRewiredInitialized()
		{
			hasRewiredInitialized = true;
			ReInput.InitializedEvent -= OnRewiredInitialized;
		}

		private void OnApplicationFocus(bool focus)
		{
			if (hasRewiredInitialized)
			{
				if (focus)
				{
					SetEnable(delayEnable, enable: true);
				}
				else
				{
					SetEnable(enable: false);
				}
			}
		}

		private void SetEnable(float time, bool enable)
		{
			CancelSetEnable();
			enableKeyboardCoroutine = StartCoroutine(SetEnableDelay(time, enable));
		}

		private IEnumerator SetEnableDelay(float time, bool enable)
		{
			yield return new WaitForSecondsRealtime(time);
			SetEnable(enable);
		}

		private void SetEnable(bool enable)
		{
			CancelSetEnable();
			if (ReInput.controllers?.Keyboard != null)
			{
				ReInput.controllers.Keyboard.enabled = enable;
			}
		}

		private void CancelSetEnable()
		{
			if (enableKeyboardCoroutine != null)
			{
				StopCoroutine(enableKeyboardCoroutine);
				enableKeyboardCoroutine = null;
			}
		}
	}
}
