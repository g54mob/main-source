using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired
{
	public sealed class Keyboard : ControllerWithMap
	{
		private sealed class rxFaEIzQeCUvtZJyMZKJxDwDbcGy : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public Keyboard GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private int rQxXsDHwqrAGdbUKSjizQYdQKkCA;

			private int eolRghqutZOOIGqvOFTzJOGfYTsn;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(ControllerPollingInfo);
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public rxFaEIzQeCUvtZJyMZKJxDwDbcGy(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private sealed class IkUwFFIbjTXBLXajResnIDVhlCrh : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public Keyboard GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private int rQxXsDHwqrAGdbUKSjizQYdQKkCA;

			private int eolRghqutZOOIGqvOFTzJOGfYTsn;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(ControllerPollingInfo);
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public IkUwFFIbjTXBLXajResnIDVhlCrh(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private static Keyboard YjYKKlgaJQlKHVPsHLphCECUobgV;

		private readonly IUnifiedKeyboardSource vPTVBGMeTSLLhqcGnbvGjLFkMncb;

		private ModifierKeyFlags opaFEghCMbaskujcLLdCQPzQBjdj;

		private ModifierKeyFlags IRZacNAmKTcWsgHXVBUnRViHawMbb;

		private Func<KeyboardKeyCode, int> hiWCtFheHJBvkFQWZhrRITEVkrkNA;

		private readonly int[] nfBdsxGcSnOQTMYpOdFZnKqcjnilA;

		private static KeyboardKeyCode[] mXHlGxuBdNscjkKwbegOAdftDrrqA;

		private readonly int bSkEQoFNHmMejiZadjRvNbwinMCUE;

		private static Guid yokikIRxPHuRDmPVzFwYrBTdCeXH;

		private static KeyboardKeyCode[] dACURjPmCYbTzEYUAZAgPxmkuauy => null;

		public override Guid deviceInstanceGuid => default(Guid);

		internal Keyboard(string P_0, IUnifiedKeyboardSource P_1)
			: base(0, default(InputSource), null, null, null, default(ControllerType), default(Guid), 0, null, null, null, null)
		{
		}

		private Keyboard(int P_0, InputSource P_1, string P_2, string P_3, HardwareControllerMap_Game P_4, int P_5, Extension P_6, ControllerDataUpdater P_7)
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

		internal static bool wVmqsgOApqHhpSlhioGKGueFIHvD(KeyboardKeyCode P_0)
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

		internal static KeyboardKeyCode kEtfTVdBeByvgzacNiNLTEzUmusc(KeyCode P_0)
		{
			return default(KeyboardKeyCode);
		}

		internal static KeyCode SiQpXJLzEXeaVoEePDzKhMakYCUfA(KeyboardKeyCode P_0)
		{
			return default(KeyCode);
		}

		internal static ModifierKeyFlags nmwDMeCeKnoseUUzdfXRMUJcsxheA(ModifierKeyFlags P_0)
		{
			return default(ModifierKeyFlags);
		}

		internal static int SxabNIXxQbdKAbhMVvfcMfjmjWBn(ModifierKeyFlags P_0)
		{
			return 0;
		}

		[CustomObfuscation]
		internal static KeyboardKeyCode GetKeyboardKeyCodeByButtonIndex(int buttonIndex)
		{
			return default(KeyboardKeyCode);
		}

		internal static int jlNwGBEmXGMRExmAEcsgpQxZAkpeA(KeyboardKeyCode P_0)
		{
			return 0;
		}

		internal static void VEtEFJdPkgAIPgWrifMLJrFsdpef(ref int P_0, ref KeyCode P_1)
		{
		}

		internal override void OPzMeptHNTMsrWdWvslRxoVUdTujA(UpdateLoopType P_0)
		{
		}

		internal void AtZsPRMlIyAwbhaBjgudEKPCjOTUA(UpdateLoopType P_0)
		{
		}

		internal bool OqIVvNhSUckGdBVPATbxZKFuFBoR(KeyboardKeyCode P_0)
		{
			return false;
		}

		internal bool pWJCpPePiHmPfMQsjqxyqjShHDGz(KeyboardKeyCode P_0)
		{
			return false;
		}

		internal bool adWmGbiOufRWIJOuXfEhtFDuBHOA(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			return false;
		}

		internal bool ihAXxhYFApHXSIzqThzQCxbhfHWO(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			return false;
		}

		[CustomObfuscation]
		internal int GetButtonIndex(KeyboardKeyCode keyCode)
		{
			return 0;
		}

		[CustomObfuscation]
		internal override void cnpecuLKhtzxTyAKhiBbYvieXuGi(ControllerMap controllerMap)
		{
		}

		[CustomObfuscation]
		internal override void OkYVVItyDNIRrZjZSvdPINJLnmkM(ControllerMap controllerMap, ActionElementMap map)
		{
		}

		internal override void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
		{
		}

		internal override bool CPoVkJzroBtMRwmbFEndkvOzAAwfb(bool P_0)
		{
			return false;
		}

		private bool RkvDdcDkaSZgyZofWltlTuEZTRdP(out Button P_0, out Button P_1, ModifierKey P_2)
		{
			P_0 = null;
			P_1 = null;
			return false;
		}

		private void YqVdeXrtrrDmDGgAXWExvUSpFIGi()
		{
		}
	}
}
