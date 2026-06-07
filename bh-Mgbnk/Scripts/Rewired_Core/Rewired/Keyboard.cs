using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Interfaces;
using Rewired.Internal.Glyphs;
using Rewired.Internal.Localization;
using UnityEngine;

namespace Rewired
{
	public sealed class Keyboard : ControllerWithMap
	{
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		internal class ModifierKeyInfo
		{
			public readonly string shortName;

			public readonly string longName;

			public readonly string shortKey;

			public readonly string longKey;

			public ModifierKeyInfo(string P_0, string P_1, string P_2, string P_3)
			{
			}

			public string GetName(bool useShort)
			{
				return null;
			}

			public string GetKey(bool useShort)
			{
				return null;
			}
		}

		private class hpHzgEwOuSFebIuJHhOUAvbcUgEaB
		{
			public readonly fsKdBRjmVoMEpvprcZrtLlbvdaMy kLVhWgVklAkovRbbWBsPtweyjsjo;

			public readonly fsKdBRjmVoMEpvprcZrtLlbvdaMy mBpiXbCMNnlWAlgNMHsPleORglFpA;

			public hpHzgEwOuSFebIuJHhOUAvbcUgEaB(string P_0, string P_1)
			{
			}
		}

		private sealed class fsKdBRjmVoMEpvprcZrtLlbvdaMy
		{
			public readonly LocalizedString lLLAhoKbGnyZTLViCUVkTelToHXbb;

			public bool SeYMQkshvkRBMEyyUUbkrRPwgSBB;

			public fsKdBRjmVoMEpvprcZrtLlbvdaMy(LocalizedString P_0)
			{
			}
		}

		private sealed class MZAKWzmSMiCMuQCLOljwzGGkFpTo
		{
			public readonly KeyedGlyph eGAPLhXAVhhlGJijQjqVddQXOSfeA;

			public bool AkPkUlLKzXjQXsFAdrBDcdGqSkKR;

			public MZAKWzmSMiCMuQCLOljwzGGkFpTo(KeyedGlyph P_0)
			{
			}
		}

		private sealed class dmUDKkPtrEIsUdNuchuygbqtRhUn : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int iTlItIPONUUZyJOPkkpYMqgLJINo;

			private ControllerPollingInfo uZhWGYxrIqDtljYPLLRfgzMBAjJM;

			private int hTzTaniWSntTnBHFLAqyAYWqRzrsA;

			public Keyboard WgWwgjkenLdOGCMwIONiasdgXxUkA;

			private int gyaccmjpPgEcUNMVkmwKlCguSJDpA;

			private int XxveIZvUhfLHYfxMWONtCRAIURaO;

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
			public dmUDKkPtrEIsUdNuchuygbqtRhUn(int P_0)
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

		private sealed class MMtsuTYNhTwzlwnyEMGylARzGaPt : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int cZiaYqJHptdbCudOMtxqpoWYHTag;

			private ControllerPollingInfo ltaUPGVNaVoQihXklsLSkLlbxreT;

			private int OLnXVuMmovrGPgPAUEvHYvsjWFTV;

			public Keyboard kcqPPxVTlzoVeUeLTqVAiiYkZTfg;

			private int POWZEDwjClKNwSebEhGgWBGmxKMm;

			private int QuyuxVeQdRpwlwdDRfdhiVzJbsTI;

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
			public MMtsuTYNhTwzlwnyEMGylARzGaPt(int P_0)
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

		private const string kFdJOVYhkJXDdZkgOusERAxKLLKG = " + ";

		private static Keyboard IZKjUHSZnRkqRQtybtgutvvVgKXT;

		private static KeyboardKeyCode[] zMjluNMCZwhofQMGyobZQkSbjOIO;

		private static Guid QHsIuDtDWiLOYRnovEnvUcNHKlRk;

		private readonly IUnifiedKeyboardSource DMvfRLbwSeRowxJcmPesLdSNcLNhA;

		private ModifierKeyFlags FVzStiHLYfbvxcSnFHYWQrdJEFwF;

		private ModifierKeyFlags qMnmYSvKGDkotCELJzAOFrhUjbON;

		private Func<KeyboardKeyCode, int> UbXYpSHbAIHZmAPnShiXLDudzAby;

		private readonly int[] XVlWrTFTCHTrWYlqyqygQkJSPGkG;

		private readonly int vbVYzdlENjTjCYjinrtITvdNufRL;

		private readonly tmpzpaZXCvsusfPERWtQvkUUQTDv KlDSQgAfuwAKmgdOzvcOjQZiWhATA;

		private readonly lDKrtrlDbWluAJFFxknaEkZiWUrU MWNAkNXnOxuAiEgazHmzTxFzNtqF;

		private Dictionary<int, hpHzgEwOuSFebIuJHhOUAvbcUgEaB> LmmeDggrRvdysfrbGczkIDzlxToqb;

		private Dictionary<int, MZAKWzmSMiCMuQCLOljwzGGkFpTo> NYIJZHElJbgTRkFmJfimFADvwdJo;

		private static KeyboardKeyCode[] oWuJWYEbmxyydgxXoBLPTmnEHPPX => null;

		private Dictionary<int, hpHzgEwOuSFebIuJHhOUAvbcUgEaB> KmtrWzgZVSKuspXfqOcBCguYmmFH => null;

		private Dictionary<int, MZAKWzmSMiCMuQCLOljwzGGkFpTo> SupTIqpjHieQJKCZzKhjHNtqSRcTA => null;

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

		[IteratorStateMachine(typeof(dmUDKkPtrEIsUdNuchuygbqtRhUn))]
		public IEnumerable<ControllerPollingInfo> PollForAllKeys()
		{
			return null;
		}

		[IteratorStateMachine(typeof(MMtsuTYNhTwzlwnyEMGylARzGaPt))]
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

		internal static bool BBHQOtmOpKzBeqoPFlkQsNBLwqRj(KeyboardKeyCode P_0)
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

		public static string GetModifierKeyName(ModifierKey modifierKey)
		{
			return null;
		}

		public static string GetModifierKeyName(ModifierKey modifierKey, bool getShortName)
		{
			return null;
		}

		public static string ModifierKeyFlagsToString(ModifierKeyFlags flags, bool getShortName)
		{
			return null;
		}

		public static string ModifierKeyFlagsToString(ModifierKeyFlags flags)
		{
			return null;
		}

		public static object GetModifierKeyGlyph(ModifierKey modifierKey)
		{
			return null;
		}

		internal static string NrAgrljgKOxSXhgkxUckCtDILNWjA(ModifierKey P_0)
		{
			return null;
		}

		internal static KeyboardKeyCode XVdkvuoGDKxohBZUvsrVhHhCxiSJ(KeyCode P_0)
		{
			return default(KeyboardKeyCode);
		}

		internal static KeyCode LvowmrmGAMPVmXyxLIreIvQBSkOv(KeyboardKeyCode P_0)
		{
			return default(KeyCode);
		}

		internal static ModifierKeyFlags SsYNWLnlmjwfNjmYirjgTxFyenSE(ModifierKeyFlags P_0)
		{
			return default(ModifierKeyFlags);
		}

		internal static int imtvHUnUfMvFfurPtnCUylyeTnhl(ModifierKeyFlags P_0)
		{
			return 0;
		}

		[CustomObfuscation(rename = false)]
		internal static KeyboardKeyCode GetKeyboardKeyCodeByButtonIndex(int buttonIndex)
		{
			return default(KeyboardKeyCode);
		}

		internal static int YHInZoQWkLppjyCADRSwpbYjUCdC(KeyboardKeyCode P_0)
		{
			return 0;
		}

		internal static void FbQXIIsNODblhHYOtiejkukecbMNA(ref int P_0, ref KeyCode P_1)
		{
		}

		internal override void JXxDIRZpnsgiGXNGCAUihWVkSdwx(UpdateLoopType P_0)
		{
		}

		internal void GyoIYzBTWSggmvIUTyzTrngMEPzb(UpdateLoopType P_0)
		{
		}

		internal bool fWHzGSIrvBTWssJmmjvTCvRbhLRf(KeyboardKeyCode P_0)
		{
			return false;
		}

		internal bool WjkHQelnQmNbjxDxVGyuXUdWKDvf(KeyboardKeyCode P_0)
		{
			return false;
		}

		internal bool bEGRAFtbnjFKbJWLZGtTLsahiJYw(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			return false;
		}

		internal bool LPEWuLRNzXHCAtxNaBrnPoYTjNgb(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			return false;
		}

		[CustomObfuscation(rename = false)]
		internal int GetButtonIndex(KeyboardKeyCode keyCode)
		{
			return 0;
		}

		[CustomObfuscation(rename = false)]
		internal override void NgSVRXtzGmXahkQxjWThqqmlVJXH(ControllerMap controllerMap)
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void BEMHamOlnupxqKxDqmuyQAAUjGvI(ControllerMap controllerMap, ActionElementMap map)
		{
		}

		internal override void fDlKuMABpdnNzezjAcKGsqfGpGcE()
		{
		}

		internal override bool ElEvIvMPwHGEirtSjuwsUVBdtARp(bool P_0)
		{
			return false;
		}

		private bool ylVKrdZzrfjVGFwGkwCjCfEugErD(out Button P_0, out Button P_1, ModifierKey P_2)
		{
			P_0 = null;
			P_1 = null;
			return false;
		}

		private void frIMSRNKFEkfHRwZCWhcwEWHcPHs()
		{
		}

		private string xYmeialDIiKDjUSOHFgrigFpujfL(ModifierKey P_0, bool P_1)
		{
			return null;
		}

		private static bool YYZtayyhFYQJKDFEvTVoluCMqpQb(fsKdBRjmVoMEpvprcZrtLlbvdaMy P_0, string P_1, string P_2, DeviceLocalizationInfo P_3, out string P_4)
		{
			P_4 = null;
			return false;
		}

		private object NmjBduUDkYgdPBFRjfetRywKfykw(ModifierKey P_0)
		{
			return null;
		}

		private string HybfMFCXotJLLeDFEqQDpcbcVrK(ModifierKey P_0)
		{
			return null;
		}

		private static bool mudUxdYloFACcPsHyJuRotphUgLV(MZAKWzmSMiCMuQCLOljwzGGkFpTo P_0, string P_1, DeviceLocalizationInfo P_2, out object P_3)
		{
			P_3 = null;
			return false;
		}

		private static bool csHBbuSaRBUxZGqNINEkyNHtBEag(MZAKWzmSMiCMuQCLOljwzGGkFpTo P_0, string P_1, DeviceLocalizationInfo P_2, out string P_3)
		{
			P_3 = null;
			return false;
		}

		[CompilerGenerated]
		private void GMlqEdMyuccpBLFvAmbzaSmIFajd()
		{
		}

		[CompilerGenerated]
		private void HdNAhGBbDECvDFFkeQHnGbLZbzKAc()
		{
		}
	}
}
