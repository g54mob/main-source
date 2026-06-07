using System.Text;
using DV.Utils;
using TMPro;
using UnityEngine;
using VRTK;
using Valve.VR;

namespace DV.Platform.SteamVr
{
	public static class SteamVRKeyboardHandler
	{
		private static string workingText;

		private static Option<APlatformProvider.TextInputRequest> pendingInputRequest;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		private static void Initialize()
		{
			APlatformProvider instance = SingletonBehaviour<APlatformProvider>.Instance;
			instance.OnCanStartTextInput.Add(CanStartTextInput);
			instance.OnTextInputStarted += OnTextInputStarted;
			instance.FileOrFolderOpened += OnFileOrFolderOpened;
		}

		private static bool CanStartTextInput()
		{
			if (!SteamVR.active)
			{
				return true;
			}
			for (SDK_BaseController.ControllerHand controllerHand = SDK_BaseController.ControllerHand.Left; controllerHand <= SDK_BaseController.ControllerHand.Right; controllerHand++)
			{
				VRTK_ControllerReference controllerReferenceForHand = VRTK_DeviceFinder.GetControllerReferenceForHand(controllerHand);
				if (controllerReferenceForHand.IsValid() && (bool)controllerReferenceForHand.scriptAlias && controllerReferenceForHand.scriptAlias.TryGetComponent<VRTK_ControllerEvents>(out var component) && (component.triggerPressed || component.triggerClicked))
				{
					return false;
				}
			}
			return true;
		}

		private static void OnTextInputStarted(APlatformProvider.TextInputRequest inputRequest)
		{
			if (SteamVR.active)
			{
				if (pendingInputRequest.IsSome(out var value))
				{
					FinishSteamVRKeyboard();
					value.OnTextInput?.Invoke(new APlatformProvider.TextInputResult(isFinished: true, saveText: false, null));
					SingletonBehaviour<APlatformProvider>.Instance.FinishTextInput();
					SteamVR.instance.overlay.HideKeyboard();
				}
				pendingInputRequest = inputRequest;
				workingText = inputRequest.InputField.text ?? "";
				SteamVR_Events.System(EVREventType.VREvent_KeyboardCharInput).Listen(OnSteamVRKeyboardCharInput);
				SteamVR_Events.System(EVREventType.VREvent_KeyboardDone).Listen(OnSteamVRKeyboardDone);
				SteamVR_Events.System(EVREventType.VREvent_KeyboardClosed).Listen(OnSteamVRKeyboardClosed);
				EVROverlayError eVROverlayError = SteamVR.instance.overlay.ShowKeyboard((inputRequest.InputField.contentType == TMP_InputField.ContentType.Password) ? 1 : 0, inputRequest.IsMultiLine ? 1 : 0, inputRequest.Description, (inputRequest.InputField.characterLimit == 0) ? uint.MaxValue : ((uint)inputRequest.InputField.characterLimit), inputRequest.InputField.text, bUseMinimalMode: true, 0uL);
				if (eVROverlayError != EVROverlayError.None)
				{
					Debug.LogError($"Failed to show SteamVR keyboard: {eVROverlayError}");
					FinishSteamVRKeyboard();
				}
			}
		}

		private static void OnSteamVRKeyboardCharInput(VREvent_t ev)
		{
			if (!pendingInputRequest.IsSome(out var value))
			{
				return;
			}
			VREvent_Keyboard_t keyboard = ev.data.keyboard;
			string text;
			using (PooledArray<byte> pooledArray = ArrayPool<byte>.New(8))
			{
				pooledArray[0] = keyboard.cNewInput0;
				pooledArray[1] = keyboard.cNewInput1;
				pooledArray[2] = keyboard.cNewInput2;
				pooledArray[3] = keyboard.cNewInput3;
				pooledArray[4] = keyboard.cNewInput4;
				pooledArray[5] = keyboard.cNewInput5;
				pooledArray[6] = keyboard.cNewInput5;
				pooledArray[7] = keyboard.cNewInput7;
				int i;
				for (i = 0; pooledArray[i] != 0 && i < 7; i++)
				{
				}
				text = Encoding.UTF8.GetString(pooledArray, 0, i);
			}
			switch (text)
			{
			case "\b":
				if (workingText.Length > 0)
				{
					workingText = workingText.Substring(0, workingText.Length - 1);
				}
				break;
			case "\u001b":
				OnSteamVRKeyboardDone(default(VREvent_t));
				return;
			case "\n":
				if (value.IsMultiLine)
				{
					workingText += text;
				}
				break;
			default:
				workingText += text;
				break;
			}
			value.OnTextInput?.Invoke(new APlatformProvider.TextInputResult(isFinished: false, saveText: true, workingText));
		}

		private static void OnSteamVRKeyboardDone(VREvent_t args)
		{
			if (pendingInputRequest.IsSome(out var value))
			{
				value.OnTextInput?.Invoke(new APlatformProvider.TextInputResult(isFinished: true, saveText: true, workingText));
				SingletonBehaviour<APlatformProvider>.Instance.FinishTextInput();
			}
			FinishSteamVRKeyboard();
		}

		private static void OnSteamVRKeyboardClosed(VREvent_t arg0)
		{
			if (pendingInputRequest.IsSome(out var value))
			{
				value.OnTextInput?.Invoke(new APlatformProvider.TextInputResult(isFinished: true, saveText: false, null));
				SingletonBehaviour<APlatformProvider>.Instance.FinishTextInput();
			}
			FinishSteamVRKeyboard();
		}

		private static void FinishSteamVRKeyboard()
		{
			SteamVR_Events.System(EVREventType.VREvent_KeyboardDone).Remove(OnSteamVRKeyboardDone);
			SteamVR_Events.System(EVREventType.VREvent_KeyboardClosed).Remove(OnSteamVRKeyboardClosed);
			SteamVR_Events.System(EVREventType.VREvent_KeyboardCharInput).Remove(OnSteamVRKeyboardCharInput);
			pendingInputRequest = default(Option<APlatformProvider.TextInputRequest>);
			workingText = null;
		}

		private static void OnFileOrFolderOpened()
		{
			if (SteamVR.active)
			{
				SteamVR.instance.overlay.ShowDashboard("system.desktop");
			}
		}
	}
}
