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
		private sealed class lvxMoJcPVlyQpcgBiYvBbYBqsLO : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo YDjDCBVmlkHQnKMyHwfXVborvEXS;

			private int KjzQtaNmLSFADNQocZpcbdUSqwW;

			private int heukQwubtgAAwETRDLwZfpUeIur;

			public Keyboard OLVemnFdjzUkQSlFFFIOsrknazt;

			public int YBKQWYMmndbzkuXXQztgvLFZwRI;

			public int uJcWZGBmCYHxkpiRJZJswDwYrHj;

			public KeyCode HHrvkJLWWuMZlRnPTDXrRWkuwnr;

			public bool AwGVGVQsaoGItdGaToTlWzDGPJP;

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
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
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

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public lvxMoJcPVlyQpcgBiYvBbYBqsLO(int _003C_003E1__state)
			{
			}
		}

		private sealed class ijfBlaaxUXPnLkfRKSQvHNxjqPib : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo YDjDCBVmlkHQnKMyHwfXVborvEXS;

			private int KjzQtaNmLSFADNQocZpcbdUSqwW;

			private int heukQwubtgAAwETRDLwZfpUeIur;

			public Keyboard OLVemnFdjzUkQSlFFFIOsrknazt;

			public int ckCpFsbDuvAeUxoKVtopQXMWJaj;

			public int gRaIMGvpjpaiidvPhzBjgDTSNqW;

			public KeyCode GKZhhdJIUZxSFmOEVBCoatUmpjKG;

			public bool bNymppkIeRIXEHIkjDIBgrQPcrgA;

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
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
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

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public ijfBlaaxUXPnLkfRKSQvHNxjqPib(int _003C_003E1__state)
			{
			}
		}

		private static Keyboard IxKwReqqHqHAndZCSrZsJErZTUzP;

		private readonly IUnifiedKeyboardSource tfTCEMKNedpBjaNONhTolgkIZhi;

		private ModifierKeyFlags uBaSgdlxMLgqOkGGWGbVGuWPTwo;

		private ModifierKeyFlags AJroEAIPbEEYPvhIufuZDRGBVX;

		private Func<KeyboardKeyCode, int> jWIeUQjNbblGzYyMMZYQJnIXOfP;

		private readonly int[] frVkdiyPMRpSbAuPLPjICNDxFKx;

		private static KeyboardKeyCode[] smBYVkkEjjDuRBoKckGPCnIeVCsi;

		private readonly int dcyhTxNlXIboFTaCcNpudNNwGrFe;

		private static Guid oYunZpJTAzmevafAkzSDraYkhYX;

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

		internal static bool eksbghEhOKBZNEnNhISJASZGDta(KeyboardKeyCode P_0)
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

		internal static KeyboardKeyCode qthklQbUBzmBOpZEYEpKVrtPHCh(KeyCode P_0)
		{
			return default(KeyboardKeyCode);
		}

		internal static KeyCode CwEyEAHQIlCwjBoSEGLPqCPdhfXn(KeyboardKeyCode P_0)
		{
			return default(KeyCode);
		}

		internal static ModifierKeyFlags dWsINjihSZZcIGRVeoxKUAktRAe(ModifierKeyFlags P_0)
		{
			return default(ModifierKeyFlags);
		}

		internal static int KjkiXRDMBBfFknyqILvhEOKllhO(ModifierKeyFlags P_0)
		{
			return 0;
		}

		[CustomObfuscation(rename = false)]
		internal static KeyboardKeyCode GetKeyboardKeyCodeByButtonIndex(int buttonIndex)
		{
			return default(KeyboardKeyCode);
		}

		internal static int nyXPREKgPiGHoCrePoWzavIUtHwF(KeyboardKeyCode P_0)
		{
			return 0;
		}

		internal static void NQdXaQpkcYGJbwVZpDDAFkgrUtz(ref int P_0, ref KeyCode P_1)
		{
		}

		internal override void IdvXxslbVpgePKGcszHAudaDgmvT(UpdateLoopType P_0)
		{
		}

		internal void SEFrWMSpGIwcVxplmLSmAwyPPtI(UpdateLoopType P_0)
		{
		}

		internal bool WcOucUtnKGWGRHjhVcRwHvuvsTp(KeyboardKeyCode P_0)
		{
			return false;
		}

		internal bool tHHfyAXvqxFVDENIgpVrrEfkbuXA(KeyboardKeyCode P_0)
		{
			return false;
		}

		internal bool wybvTRpeYGNTcDZmbPWLhMoOgyC(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			return false;
		}

		internal bool atUKhgQMRDDKoWWDCTqZISYwqPl(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			return false;
		}

		[CustomObfuscation(rename = false)]
		internal int GetButtonIndex(KeyboardKeyCode keyCode)
		{
			return 0;
		}

		[CustomObfuscation(rename = false)]
		internal override void waxdHdNHlDhxzkjqsWWmSQZfsNN(ControllerMap controllerMap)
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void GwGsCBzrPvyJJTZjZfVGITmOBPf(ControllerMap controllerMap, ActionElementMap map)
		{
		}

		internal override void DcbUeIfyTfvTrRQxceAMfGCsJNs()
		{
		}

		private bool NzvDsxdDccsqUhTPRqVqeBdKQqgb(out Button P_0, out Button P_1, ModifierKey P_2)
		{
			P_0 = null;
			P_1 = null;
			return false;
		}

		private void CDDooGdebPFglUDoQdmixmbyJgH()
		{
		}
	}
}
