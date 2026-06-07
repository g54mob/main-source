using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Libs;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace InputControl
{
	public class InputManager : SingletonMonoBehaviour<InputManager>
	{
		public enum RebindOperationResult
		{
			None = 0,
			Success = 100,
			Failed = 200
		}

		public enum RebindOperationErrorCode
		{
			None = 0,
			Cancel = 1,
			NotExistBinding = 2,
			SameKey = 4,
			UnavailablePair = 8,
			DuplicateBinding = 0x10
		}

		public static InputActionController Input;

		private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

		private UnityAction<RebindOperationResult, RebindOperationErrorCode> OnFinishAction;

		public static readonly string UnusedKey;

		private static string scheme;

		private InputAction rebindingInputAction;

		private int baseBindingIndex;

		private const int bindingMax = 2;

		private const int keybordBindingMax = 5;

		private string[] oldBinding;

		private string rebindingCategory;

		private Dictionary<string, List<(InputAction inputAction, int bindingIndex)>> targetBindings;

		private Dictionary<string, Dictionary<string, List<(InputAction inputAction, int bindingIndex)>>> duplicateBindings;

		private List<(InputAction inputAction, int bindingIndex)> reservationRebindInputActionList;

		private bool intialized;

		private readonly List<string> _padKeyBlackList;

		private string[] allowedModifiers;

		private Dictionary<string, string> replaceModifiers;

		private string rightShoulderPath;

		private string leftShoulderPath;

		private string rightTriggerPath;

		private string leftTriggerPath;

		public static string Scheme => null;

		public bool Initialized => false;

		public bool CameraScrollWasdIgnoreGameInputOk => false;

		public bool CameraMoveByStick => false;

		public event Action<InputAction> onChangeInput
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static bool IsMouseBindingForPath(string path)
		{
			return false;
		}

		public static bool IsGamePadBindingForPath(string path)
		{
			return false;
		}

		public static string GetBindingInputType(string path)
		{
			return null;
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public void ClearOnFinishAction()
		{
		}

		private void DisableIsHiddenInputAction()
		{
		}

		public void ResolveBindingOrder()
		{
		}

		private void CheckBindingDuplicate()
		{
		}

		private string GetReplaceName(InputAction inputAction, int bindingIndex)
		{
			return null;
		}

		private void UpdateInputActionSpriteFont()
		{
		}

		private void SaveOldBinding(InputAction inputAction, int bindingIndex)
		{
		}

		public void AddResevationInputAction(string actionMap, string actionName, int bindingIndex)
		{
		}

		private void ClearOldBinding()
		{
		}

		private void RestoreBinding()
		{
		}

		public bool RebindAction(InputAction inputAction, UnityAction<RebindOperationResult, RebindOperationErrorCode> OnFinishAction)
		{
			return false;
		}

		public bool RebindAction(InputAction inputAction, int bindingIndex, UnityAction<RebindOperationResult, RebindOperationErrorCode> OnFinishAction, bool isGamePadAction)
		{
			return false;
		}

		private void AddOtherAction(InputAction inputAction, bool isGamePadAction)
		{
		}

		private List<(InputAction, int)> GetRelatedActions(InputAction inputAction, bool isGamePadAction)
		{
			return null;
		}

		private void StartRebindOperation(InputAction inputAction, int bindingIndex)
		{
		}

		private void ApplyBindingOverride(InputAction inputAction, int bindingIndex, string path, bool onlyReservation = false)
		{
		}

		private void TrySaveRebindOperation(ref RebindOperationResult result, ref RebindOperationErrorCode errorCode, bool isSave = true)
		{
		}

		private void SwapBindings(InputAction duplicateAction, int duplicateBindingIndex)
		{
		}

		public string ReplaceModifier(string path)
		{
			return null;
		}

		private bool IsModifier(string path)
		{
			return false;
		}

		private void ClearOperation()
		{
		}

		private void FinishedRebindOperation(InputAction inputAction)
		{
		}

		private void EnableInputAction(InputAction inputAction)
		{
		}

		private void DisableInputAction(InputAction inputAction)
		{
		}

		public void CancelRebinding()
		{
		}

		public void DeleteRebinding(InputAction inputAction, int bindingIndex, bool isSave = true)
		{
		}

		private new void OnDestroy()
		{
		}

		public InputAction GetInputAction(MstGameActionEntities gameAction, bool useType2 = false)
		{
			return null;
		}

		public InputAction GetInputAction(string actionMap, string action)
		{
			return null;
		}

		public void ResetAllBinding()
		{
		}

		public void ResetBinding(List<(InputAction inputAction, int bindingIndex)> resetActions)
		{
		}

		private void RemoveBindingOverride(InputAction inputAction, int bindingIndex)
		{
		}

		private void NotificationResetAllBinding()
		{
		}

		public bool HoldAndKeepIfGamePad(InputAction inputAction, bool isGamePad)
		{
			return false;
		}

		public Vector2Int GetCameraMove(bool isGamePad, out bool stepMove)
		{
			stepMove = default(bool);
			return default(Vector2Int);
		}

		public Vector2 GetCameraZoom()
		{
			return default(Vector2);
		}

		public bool IsBlackListed(string input)
		{
			return false;
		}

		private bool IsAllowedPair(ref RebindOperationErrorCode errorCode)
		{
			return false;
		}

		private bool IsDuplicateBinding(ref RebindOperationErrorCode errorCode)
		{
			return false;
		}

		public void SetRebindingCategory(string category, List<(InputAction, int)> bindings)
		{
		}

		private void SetDuplicateBindings(string displayString, params (InputAction inputAction, int bindingIndex)[] bindings)
		{
		}

		private void RemoveDuplicateBindings((InputAction inputAction, int bindingIndex) binding, bool deleteKey = true)
		{
		}

		public bool HaveDuplicateBindings()
		{
			return false;
		}

		public List<(InputAction, int)> GetDuplicateActions()
		{
			return null;
		}

		private void SaveInput()
		{
		}

		public void LoadInput(bool copyFromOutGameInfo = false)
		{
		}

		public bool CheckInputDataJson(string targetJson)
		{
			return false;
		}

		public string GetSpriteFont(InputAction action, int bindingIndex = 0)
		{
			return null;
		}

		public string GetSpriteFont(InputBinding binding)
		{
			return null;
		}

		public string GetInputForPath(string path)
		{
			return null;
		}

		public string GetInputForBinding(InputBinding binding)
		{
			return null;
		}

		public void SetDropDownBinding(int setting, InputAction palletNext, InputAction palletPrev, InputAction holdMenu, InputAction openInventory)
		{
		}
	}
}
