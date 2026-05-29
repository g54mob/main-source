using System;
using System.Collections.Generic;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired
{
	public sealed class Keyboard : ControllerWithMap
	{
		private static Keyboard singleton;

		private readonly IUnifiedKeyboardSource _source;

		private ModifierKeyFlags currentModfierKeyFlags;

		private ModifierKeyFlags currentModfierKeyFlagsDouble;

		private Func<KeyboardKeyCode, int> _getKeyIndexDelegate;

		private readonly int[] keyCodeToKeyIndex;

		private static KeyboardKeyCode[] __keyIndexToKeyboardKeyCode;

		private readonly int maxKeyValue;

		private static Guid s_deviceInstanceGuid;

		private static KeyboardKeyCode[] keyIndexToKeyboardKeyCode => null;

		public override Guid deviceInstanceGuid => default(Guid);

		internal Keyboard(string name, IUnifiedKeyboardSource source)
			: base(0, default(InputSource), null, null, null, default(ControllerType), default(Guid), 0, null, null, null, null)
		{
		}

		private Keyboard(int controllerId, InputSource inputSource, string name, string hardwareIdentifier, HardwareControllerMap_Game hardwareMap, int buttonCount, Extension extension, ControllerDataUpdater dataUpdater)
			: base(0, default(InputSource), null, null, null, default(ControllerType), default(Guid), 0, null, null, null, null)
		{
		}

		public bool GetKey(KeyCode keyCode)
		{
			return false;
		}

		public bool GetKeyDown(KeyCode keyCode)
		{
			return false;
		}

		public bool GetKeyUp(KeyCode keyCode)
		{
			return false;
		}

		public bool GetKeyDoublePressHold(KeyCode keyCode, float speed)
		{
			return false;
		}

		public bool GetKeyDoublePressHold(KeyCode keyCode)
		{
			return false;
		}

		public bool GetKeyDoublePressDown(KeyCode keyCode, float speed)
		{
			return false;
		}

		public bool GetKeyDoublePressDown(KeyCode keyCode)
		{
			return false;
		}

		public bool GetKeyPrev(KeyCode keyCode)
		{
			return false;
		}

		public double GetKeyTimePressed(KeyCode keyCode)
		{
			return 0.0;
		}

		public double GetKeyTimeUnpressed(KeyCode keyCode)
		{
			return 0.0;
		}

		public bool GetModifierKey(ModifierKey key)
		{
			return false;
		}

		public bool GetModifierKeyDown(ModifierKey key)
		{
			return false;
		}

		public bool GetModifierKeyUp(ModifierKey key)
		{
			return false;
		}

		public bool GetModifierKeyPrev(ModifierKey key)
		{
			return false;
		}

		public double GetModifierKeyTimePressed(ModifierKey key)
		{
			return 0.0;
		}

		public double GetModifierKeyTimeUnpressed(ModifierKey key)
		{
			return 0.0;
		}

		public KeyCode GetKeyCodeByButtonIndex(int buttonIndex)
		{
			return default(KeyCode);
		}

		public KeyCode GetKeyCodeById(int elementIdentifierId)
		{
			return default(KeyCode);
		}

		public int GetButtonIndexByKeyCode(KeyCode keyCode)
		{
			return 0;
		}

		public ControllerElementIdentifier GetElementIdentifierByKeyCode(KeyCode keyCode)
		{
			return null;
		}

		public ControllerPollingInfo PollForFirstKey()
		{
			return default(ControllerPollingInfo);
		}

		public IEnumerable<ControllerPollingInfo> PollForAllKeys()
		{
			return null;
		}

		public IEnumerable<ControllerPollingInfo> PollForAllKeysDown()
		{
			return null;
		}

		public ControllerPollingInfo PollForFirstKeyDown()
		{
			return default(ControllerPollingInfo);
		}

		public override ControllerPollingInfo PollForFirstButton()
		{
			return default(ControllerPollingInfo);
		}

		public override ControllerPollingInfo PollForFirstButtonDown()
		{
			return default(ControllerPollingInfo);
		}

		public override IEnumerable<ControllerPollingInfo> PollForAllButtons()
		{
			return null;
		}

		public override IEnumerable<ControllerPollingInfo> PollForAllButtonsDown()
		{
			return null;
		}

		public static bool IsModifierKey(KeyCode key)
		{
			return false;
		}

		internal static bool IsModifierKey(KeyboardKeyCode key)
		{
			return false;
		}

		public static ModifierKey KeyCodeToModifierKey(KeyCode key)
		{
			return default(ModifierKey);
		}

		public static ModifierKeyFlags KeyCodeToModifierKeyFlags(KeyCode key)
		{
			return default(ModifierKeyFlags);
		}

		public static bool ModifierKeyFlagsContain(ModifierKeyFlags flags, ModifierKey key)
		{
			return false;
		}

		public static bool ModifierKeyFlagsContain(ModifierKeyFlags flags, KeyCode key)
		{
			return false;
		}

		public static ModifierKey ModifierKeyFlagsToModifierKey(ModifierKeyFlags flags)
		{
			return default(ModifierKey);
		}

		public static KeyCode ModifierKeyFlagsToKeyCode(ModifierKeyFlags flags)
		{
			return default(KeyCode);
		}

		public static ModifierKeyFlags ModifierKeyToModifierKeyFlags(ModifierKey key)
		{
			return default(ModifierKeyFlags);
		}

		public static string GetKeyName(KeyCode key)
		{
			return null;
		}

		public static string GetKeyName(KeyCode key, ModifierKeyFlags flags)
		{
			return null;
		}

		public static string ModifierKeyFlagsToString(ModifierKeyFlags flags, bool abbreviate)
		{
			return null;
		}

		public static string ModifierKeyFlagsToString(ModifierKeyFlags flags)
		{
			return null;
		}

		internal static KeyboardKeyCode KeyCodeToKeyboardKeyCode(KeyCode keyCode)
		{
			return default(KeyboardKeyCode);
		}

		internal static KeyCode KeyboardKeyCodeToKeyCode(KeyboardKeyCode keyCode)
		{
			return default(KeyCode);
		}

		internal static ModifierKeyFlags ConvertModifierKeyFlagsSingleToDouble(ModifierKeyFlags flags)
		{
			return default(ModifierKeyFlags);
		}

		internal static int GetDoubledModifierKeyCount(ModifierKeyFlags flags)
		{
			return 0;
		}

		[CustomObfuscation]
		internal static KeyboardKeyCode GetKeyboardKeyCodeByButtonIndex(int buttonIndex)
		{
			return default(KeyboardKeyCode);
		}

		internal static int GetElementIdentifierIdByKeyCode(KeyboardKeyCode keyCode)
		{
			return 0;
		}

		internal static void FixKeyboardAssignments(ref int elementIdentifierId, ref KeyCode keyCode)
		{
		}

		internal override void NFSHGTXxwNpYHMyToumsXPPmaYz(UpdateLoopType updateLoop)
		{
		}

		internal void UpdateData_AndroidKeyboardDisabled(UpdateLoopType updateLoop)
		{
		}

		internal bool GetKey(KeyboardKeyCode keyCode)
		{
			return false;
		}

		internal bool GetKeyPrev(KeyboardKeyCode keyCode)
		{
			return false;
		}

		internal bool AllRequiredKeysPressed(KeyboardKeyCode keyCode, ModifierKeyFlags doubledFlags)
		{
			return false;
		}

		internal bool IsAnyComponentKeyActive(KeyboardKeyCode keyCode, ModifierKeyFlags doubledFlags)
		{
			return false;
		}

		[CustomObfuscation]
		internal int GetButtonIndex(KeyboardKeyCode keyCode)
		{
			return 0;
		}

		[CustomObfuscation]
		internal override void rkMwVKpKBldofaAkcpvKkScWemJ(ControllerMap controllerMap)
		{
		}

		[CustomObfuscation]
		internal override void PMxkaaVQdHUeTTUjFcJkyHJzBKv(ControllerMap controllerMap, ActionElementMap map)
		{
		}

		internal override void CKSoitBPjLqWpFGpwBNgDbvTrVm()
		{
		}

		private bool GetControlButtons(out Button leftButton, out Button rightButton, ModifierKey key)
		{
			leftButton = null;
			rightButton = null;
			return false;
		}

		private void UpdateCurrentModifierKeyFlags()
		{
		}
	}
}
