using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Internal.Glyphs;
using Rewired.Internal.Localization;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired
{
	public sealed class Keyboard : ControllerWithMap
	{
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		[CustomObfuscation(rename = false)]
		internal class ModifierKeyInfo
		{
			public readonly string shortName;

			public readonly string longName;

			public readonly string shortKey;

			public readonly string longKey;

			public ModifierKeyInfo(string P_0, string P_1, string P_2, string P_3)
			{
				shortName = P_0;
				longName = P_1;
				shortKey = P_2;
				longKey = P_3;
			}

			public string GetName(bool useShort)
			{
				if (!useShort)
				{
					return longName;
				}
				return shortName;
			}

			public string GetKey(bool useShort)
			{
				if (!useShort)
				{
					return longKey;
				}
				return shortKey;
			}
		}

		private class pUCbDNBzXddUWfZdBnRuPFVGPZmz
		{
			public readonly dnLmCQexgDwxKOANksXDzCTvVPik sjIElpUxfRfRUqQAuNHkFWJKQfuJ;

			public readonly dnLmCQexgDwxKOANksXDzCTvVPik EYaJuFRcsmFpdjOTJHpGDWpcNFARb;

			public pUCbDNBzXddUWfZdBnRuPFVGPZmz(string P_0, string P_1)
			{
				if (!string.IsNullOrEmpty(P_0))
				{
					sjIElpUxfRfRUqQAuNHkFWJKQfuJ = new dnLmCQexgDwxKOANksXDzCTvVPik(new LocalizedString());
				}
				if (!string.IsNullOrEmpty(P_1))
				{
					EYaJuFRcsmFpdjOTJHpGDWpcNFARb = new dnLmCQexgDwxKOANksXDzCTvVPik(new LocalizedString());
				}
			}
		}

		private sealed class dnLmCQexgDwxKOANksXDzCTvVPik
		{
			public readonly LocalizedString ANnyYrpgRHgHrBXsbJxMFrsUzupD;

			public bool HXKhdHpexPYddGMtYPiGAoiZjeQX;

			public dnLmCQexgDwxKOANksXDzCTvVPik(LocalizedString P_0)
			{
				ANnyYrpgRHgHrBXsbJxMFrsUzupD = P_0;
			}
		}

		private sealed class OGJxJivAzTceTrClSrcSZPkuiElp
		{
			public readonly KeyedGlyph ANnyYrpgRHgHrBXsbJxMFrsUzupD;

			public bool YNWrmmBdJeaMqGJqqClqkervvJbTA;

			public OGJxJivAzTceTrClSrcSZPkuiElp(KeyedGlyph P_0)
			{
				ANnyYrpgRHgHrBXsbJxMFrsUzupD = P_0;
			}
		}

		private sealed class bwVQnvCwKtRMzGCCauvIOqIrpCcS : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public Keyboard zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private int EjCeOxlhYoefiiImdORGrPloAKagb;

			private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			[DebuggerHidden]
			public bwVQnvCwKtRMzGCCauvIOqIrpCcS(int P_0)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
				AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
				Keyboard keyboard = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					goto IL_00bf;
				}
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (ReInput._id != keyboard.oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(keyboard.oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return false;
				}
				EjCeOxlhYoefiiImdORGrPloAKagb = Consts.keyboardKeyValues.Count;
				PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
				goto IL_00cf;
				IL_00cf:
				if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < EjCeOxlhYoefiiImdORGrPloAKagb)
				{
					KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[PrfhaiCANHhjwtWLxlpNIHvkLSmF];
					if (keyboard.GetKey(keyCode))
					{
						vjnbYLtrPMftzpjohNfommerCnGo = new ControllerPollingInfo(true, -1, keyboard.id, keyboard._name, keyboard._type, ControllerElementType.Button, PrfhaiCANHhjwtWLxlpNIHvkLSmF, Pole.Positive, GetKeyName(keyCode), keyboard.AWCbIECppuLDtCThiwONsElGeIEub.buttonElementIdentifierIds[PrfhaiCANHhjwtWLxlpNIHvkLSmF], keyCode);
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
						return true;
					}
					goto IL_00bf;
				}
				return false;
				IL_00bf:
				PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
				goto IL_00cf;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				bwVQnvCwKtRMzGCCauvIOqIrpCcS bwVQnvCwKtRMzGCCauvIOqIrpCcS2;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					bwVQnvCwKtRMzGCCauvIOqIrpCcS2 = this;
				}
				else
				{
					bwVQnvCwKtRMzGCCauvIOqIrpCcS2 = new bwVQnvCwKtRMzGCCauvIOqIrpCcS(0);
					bwVQnvCwKtRMzGCCauvIOqIrpCcS2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				return bwVQnvCwKtRMzGCCauvIOqIrpCcS2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class UsaDkEHiCcJIIDoEISDWFhxtTjpk : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public Keyboard zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private int EjCeOxlhYoefiiImdORGrPloAKagb;

			private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			[DebuggerHidden]
			public UsaDkEHiCcJIIDoEISDWFhxtTjpk(int P_0)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
				AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
				Keyboard keyboard = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					goto IL_00bf;
				}
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (ReInput._id != keyboard.oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(keyboard.oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return false;
				}
				EjCeOxlhYoefiiImdORGrPloAKagb = Consts.keyboardKeyValues.Count;
				PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
				goto IL_00cf;
				IL_00cf:
				if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < EjCeOxlhYoefiiImdORGrPloAKagb)
				{
					KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[PrfhaiCANHhjwtWLxlpNIHvkLSmF];
					if (keyboard.GetKeyDown(keyCode))
					{
						vjnbYLtrPMftzpjohNfommerCnGo = new ControllerPollingInfo(true, -1, keyboard.id, keyboard._name, keyboard._type, ControllerElementType.Button, PrfhaiCANHhjwtWLxlpNIHvkLSmF, Pole.Positive, GetKeyName(keyCode), keyboard.AWCbIECppuLDtCThiwONsElGeIEub.buttonElementIdentifierIds[PrfhaiCANHhjwtWLxlpNIHvkLSmF], keyCode);
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
						return true;
					}
					goto IL_00bf;
				}
				return false;
				IL_00bf:
				PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
				goto IL_00cf;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				UsaDkEHiCcJIIDoEISDWFhxtTjpk usaDkEHiCcJIIDoEISDWFhxtTjpk;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					usaDkEHiCcJIIDoEISDWFhxtTjpk = this;
				}
				else
				{
					usaDkEHiCcJIIDoEISDWFhxtTjpk = new UsaDkEHiCcJIIDoEISDWFhxtTjpk(0);
					usaDkEHiCcJIIDoEISDWFhxtTjpk.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				return usaDkEHiCcJIIDoEISDWFhxtTjpk;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private const string fsEzSYWCOBmzejWMKKkbPUGrUcUW = " + ";

		private static Keyboard daIVciQEvCtqbioIoJuNBqfDhIkJ;

		private static KeyboardKeyCode[] BbTBqkAHAXBNNXAOEKDeeHQqnFzh;

		private static Guid TlqexZaxrTHNzaLvGPdgSakcLMHEb;

		private readonly IUnifiedKeyboardSource CLFHWOuPSRLahPSSrSHZoiqMbYrk;

		private ModifierKeyFlags FmksErTAobCBAhJGyShibXWVBRnTA;

		private ModifierKeyFlags roTfpKeksRizKimpmXsHMpDCggGX;

		private Func<KeyboardKeyCode, int> OEQHqUDBnBpEIAlwcyBrzArIsjqhb;

		private readonly int[] EILjPeSCmjzvfzZNxpyfRbFbplmf;

		private readonly int OVuXxxrWhkZTPkIISbbBytPyESOj;

		private readonly dXkbKlACvOfIDvWcTAscoLeMLyzQA sjhVFdqGbVsXsFrdQMPNGbdIcvVz;

		private readonly rYTUmemnGdLnxaNlvwFKulvqzdLl VaEVTwggattZRXRkmMjNgHHCFEFz;

		private Dictionary<int, pUCbDNBzXddUWfZdBnRuPFVGPZmz> NCbJgVOnBCwQlqYyLiWGjpfHgfmP;

		private Dictionary<int, OGJxJivAzTceTrClSrcSZPkuiElp> ynBDnbUMARgUCJVkJjqHTIZVPIyo;

		private static KeyboardKeyCode[] MDOCNgfDqGevDdmmteZQMMPbsmsL
		{
			get
			{
				if (BbTBqkAHAXBNNXAOEKDeeHQqnFzh == null)
				{
					int[] keyboardKeyValues = Consts._keyboardKeyValues;
					int num = keyboardKeyValues.Length;
					BbTBqkAHAXBNNXAOEKDeeHQqnFzh = new KeyboardKeyCode[num];
					for (int i = 0; i < num; i++)
					{
						BbTBqkAHAXBNNXAOEKDeeHQqnFzh[i] = (KeyboardKeyCode)keyboardKeyValues[i];
					}
				}
				return BbTBqkAHAXBNNXAOEKDeeHQqnFzh;
			}
		}

		private Dictionary<int, pUCbDNBzXddUWfZdBnRuPFVGPZmz> PwqSDuBEXumUoHiWpqrKpLxpWSGy
		{
			get
			{
				if (NCbJgVOnBCwQlqYyLiWGjpfHgfmP == null)
				{
					Rewired.Utils.Interfaces.IReadOnlyDictionary<int, ModifierKeyInfo> modifierKeyInfo = Consts.modifierKeyInfo;
					Dictionary<int, pUCbDNBzXddUWfZdBnRuPFVGPZmz> dictionary = new Dictionary<int, pUCbDNBzXddUWfZdBnRuPFVGPZmz>();
					foreach (KeyValuePair<int, ModifierKeyInfo> item in modifierKeyInfo)
					{
						if (item.Key != 0)
						{
							dictionary.Add(item.Key, new pUCbDNBzXddUWfZdBnRuPFVGPZmz(item.Value.shortKey, item.Value.longKey));
						}
					}
					NCbJgVOnBCwQlqYyLiWGjpfHgfmP = dictionary;
				}
				return NCbJgVOnBCwQlqYyLiWGjpfHgfmP;
			}
		}

		private Dictionary<int, OGJxJivAzTceTrClSrcSZPkuiElp> dTQNgGLlLMwkqYDJuIATEThzvrOt
		{
			get
			{
				if (ynBDnbUMARgUCJVkJjqHTIZVPIyo == null)
				{
					Rewired.Utils.Interfaces.IReadOnlyDictionary<int, ModifierKeyInfo> modifierKeyInfo = Consts.modifierKeyInfo;
					Dictionary<int, OGJxJivAzTceTrClSrcSZPkuiElp> dictionary = new Dictionary<int, OGJxJivAzTceTrClSrcSZPkuiElp>();
					foreach (KeyValuePair<int, ModifierKeyInfo> item in modifierKeyInfo)
					{
						if (item.Key != 0)
						{
							OGJxJivAzTceTrClSrcSZPkuiElp value = new OGJxJivAzTceTrClSrcSZPkuiElp(new KeyedGlyph());
							dictionary.Add(item.Key, value);
						}
					}
					ynBDnbUMARgUCJVkJjqHTIZVPIyo = dictionary;
				}
				return ynBDnbUMARgUCJVkJjqHTIZVPIyo;
			}
		}

		public override Guid deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return Guid.Empty;
				}
				return TlqexZaxrTHNzaLvGPdgSakcLMHEb;
			}
		}

		internal Keyboard(string P_0, IUnifiedKeyboardSource P_1)
			: this(0, P_1.inputSource, P_0, InputTools.FormatHardwareIdentifierString(P_0), P_1.hardwareMap, 132, P_1?.controllerExtension, new ControllerDataUpdater(P_1.inputSource, 0, 132, null))
		{
			TlqexZaxrTHNzaLvGPdgSakcLMHEb = MiscTools.CreateGuidHashSHA1("[Universal Keyboard]");
			sjhVFdqGbVsXsFrdQMPNGbdIcvVz = new dXkbKlACvOfIDvWcTAscoLeMLyzQA(delegate
			{
				IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
				for (int i = 0; i < values.Count; i++)
				{
					ufVAFIeJhcoXMNVXgQxvZoDqTBrV(values[i], true);
					ufVAFIeJhcoXMNVXgQxvZoDqTBrV(values[i], false);
				}
			});
			VaEVTwggattZRXRkmMjNgHHCFEFz = new rYTUmemnGdLnxaNlvwFKulvqzdLl(delegate
			{
				IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
				for (int i = 0; i < values.Count; i++)
				{
					YnjyYDNzuhQnRQpEQyWMfJSevvqE(values[i]);
				}
			});
			int[] keyboardKeyValues = Consts._keyboardKeyValues;
			int num = keyboardKeyValues.Length;
			for (int num2 = 0; num2 < num; num2++)
			{
				if (keyboardKeyValues[num2] > OVuXxxrWhkZTPkIISbbBytPyESOj)
				{
					OVuXxxrWhkZTPkIISbbBytPyESOj = keyboardKeyValues[num2];
				}
			}
			EILjPeSCmjzvfzZNxpyfRbFbplmf = new int[OVuXxxrWhkZTPkIISbbBytPyESOj + 1];
			ArrayTools.Fill(EILjPeSCmjzvfzZNxpyfRbFbplmf, -1);
			for (int num3 = 0; num3 < num; num3++)
			{
				EILjPeSCmjzvfzZNxpyfRbFbplmf[keyboardKeyValues[num3]] = num3;
			}
			CLFHWOuPSRLahPSSrSHZoiqMbYrk = P_1;
			if (LocalizationManager.isEnabled && LocalizationManager.autoPrefetch)
			{
				((gPdbPvViIcfmuVJElIIVfiLqZVrDA)sjhVFdqGbVsXsFrdQMPNGbdIcvVz).Localize();
			}
			if (GlyphManager.isEnabled && GlyphManager.autoPrefetch)
			{
				((IPrefetch)VaEVTwggattZRXRkmMjNgHHCFEFz).Prefetch();
			}
			pggOEkcvhxxBuBDIbrJuSafugeIK();
		}

		private Keyboard(int P_0, InputSource P_1, string P_2, string P_3, HardwareControllerMap_Game P_4, int P_5, Extension P_6, ControllerDataUpdater P_7)
			: base(P_0, P_1, P_2, P_2, P_3, ControllerType.Keyboard, Consts.hardwareTypeGuid_universalKeyboard, P_5, null, P_4, P_6, P_7)
		{
			daIVciQEvCtqbioIoJuNBqfDhIkJ = this;
		}

		public bool GetKey(KeyCode keyCode)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			if ((uint)keyCode > (uint)OVuXxxrWhkZTPkIISbbBytPyESOj)
			{
				return false;
			}
			int num = EILjPeSCmjzvfzZNxpyfRbFbplmf[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].value;
		}

		public bool GetKeyDown(KeyCode keyCode)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			if ((uint)keyCode > (uint)OVuXxxrWhkZTPkIISbbBytPyESOj)
			{
				return false;
			}
			int num = EILjPeSCmjzvfzZNxpyfRbFbplmf[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].justPressed;
		}

		public bool GetKeyUp(KeyCode keyCode)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			if ((uint)keyCode > (uint)OVuXxxrWhkZTPkIISbbBytPyESOj)
			{
				return false;
			}
			int num = EILjPeSCmjzvfzZNxpyfRbFbplmf[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].justReleased;
		}

		public bool GetKeyDoublePressHold(KeyCode keyCode, float speed)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			if ((uint)keyCode > (uint)OVuXxxrWhkZTPkIISbbBytPyESOj)
			{
				return false;
			}
			int num = EILjPeSCmjzvfzZNxpyfRbFbplmf[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].DoublePressedAndHeld(speed);
		}

		public bool GetKeyDoublePressHold(KeyCode keyCode)
		{
			if ((uint)keyCode > (uint)OVuXxxrWhkZTPkIISbbBytPyESOj)
			{
				return false;
			}
			int num = EILjPeSCmjzvfzZNxpyfRbFbplmf[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].DoublePressedAndHeld(0f);
		}

		public bool GetKeyDoublePressDown(KeyCode keyCode, float speed)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			if ((uint)keyCode > (uint)OVuXxxrWhkZTPkIISbbBytPyESOj)
			{
				return false;
			}
			int num = EILjPeSCmjzvfzZNxpyfRbFbplmf[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].JustDoublePressed(speed);
		}

		public bool GetKeyDoublePressDown(KeyCode keyCode)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			if ((uint)keyCode > (uint)OVuXxxrWhkZTPkIISbbBytPyESOj)
			{
				return false;
			}
			int num = EILjPeSCmjzvfzZNxpyfRbFbplmf[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].JustDoublePressed(0f);
		}

		public bool GetKeyPrev(KeyCode keyCode)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			if ((uint)keyCode > (uint)OVuXxxrWhkZTPkIISbbBytPyESOj)
			{
				return false;
			}
			int num = EILjPeSCmjzvfzZNxpyfRbFbplmf[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].valuePrev;
		}

		public double GetKeyTimePressed(KeyCode keyCode)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			if ((uint)keyCode > (uint)OVuXxxrWhkZTPkIISbbBytPyESOj)
			{
				return 0.0;
			}
			int num = EILjPeSCmjzvfzZNxpyfRbFbplmf[(int)keyCode];
			if (num < 0)
			{
				return 0.0;
			}
			return buttons[num].timePressed;
		}

		public double GetKeyTimeUnpressed(KeyCode keyCode)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			if ((uint)keyCode > (uint)OVuXxxrWhkZTPkIISbbBytPyESOj)
			{
				return 0.0;
			}
			int num = EILjPeSCmjzvfzZNxpyfRbFbplmf[(int)keyCode];
			if (num < 0)
			{
				return 0.0;
			}
			return buttons[num].timeUnpressed;
		}

		public bool GetModifierKey(ModifierKey key)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			if (!cbfclbvIBKLfWaRUdHELQdZGVkzd(out var button, out var button2, key))
			{
				return false;
			}
			if (button.value || button2.value)
			{
				return true;
			}
			return false;
		}

		public bool GetModifierKeyDown(ModifierKey key)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			if (!cbfclbvIBKLfWaRUdHELQdZGVkzd(out var button, out var button2, key))
			{
				return false;
			}
			if (!button.value && !button2.value)
			{
				return false;
			}
			if (button.valuePrev || button2.valuePrev)
			{
				return false;
			}
			return true;
		}

		public bool GetModifierKeyUp(ModifierKey key)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			if (!cbfclbvIBKLfWaRUdHELQdZGVkzd(out var button, out var button2, key))
			{
				return false;
			}
			if (button.value || button2.value)
			{
				return false;
			}
			if (!button.valuePrev && !button2.valuePrev)
			{
				return false;
			}
			return true;
		}

		public bool GetModifierKeyPrev(ModifierKey key)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			if (!cbfclbvIBKLfWaRUdHELQdZGVkzd(out var button, out var button2, key))
			{
				return false;
			}
			if (button.valuePrev || button2.valuePrev)
			{
				return true;
			}
			return false;
		}

		public double GetModifierKeyTimePressed(ModifierKey key)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			if (!cbfclbvIBKLfWaRUdHELQdZGVkzd(out var button, out var button2, key))
			{
				return 0.0;
			}
			return MathTools.Max(button.timePressed, button2.timePressed);
		}

		public double GetModifierKeyTimeUnpressed(ModifierKey key)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			if (!cbfclbvIBKLfWaRUdHELQdZGVkzd(out var button, out var button2, key))
			{
				return 0.0;
			}
			return MathTools.Min(button.timeUnpressed, button2.timeUnpressed);
		}

		public KeyCode GetKeyCodeByButtonIndex(int buttonIndex)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return KeyCode.None;
			}
			return hLCSNOjmzRRszVIigLVwNHstOdSE(GetKeyboardKeyCodeByButtonIndex(buttonIndex));
		}

		public KeyCode GetKeyCodeById(int elementIdentifierId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return KeyCode.None;
			}
			return GetKeyCodeByButtonIndex(GetButtonIndexById(elementIdentifierId));
		}

		public int GetButtonIndexByKeyCode(KeyCode keyCode)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return -1;
			}
			if ((uint)keyCode > (uint)OVuXxxrWhkZTPkIISbbBytPyESOj)
			{
				return -1;
			}
			return EILjPeSCmjzvfzZNxpyfRbFbplmf[(int)keyCode];
		}

		public ControllerElementIdentifier GetElementIdentifierByKeyCode(KeyCode keyCode)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			if ((uint)keyCode > (uint)OVuXxxrWhkZTPkIISbbBytPyESOj)
			{
				return null;
			}
			int num = EILjPeSCmjzvfzZNxpyfRbFbplmf[(int)keyCode];
			if (num < 0)
			{
				return null;
			}
			return AWCbIECppuLDtCThiwONsElGeIEub.buttonElementIdentifiers_cache[num];
		}

		public ControllerPollingInfo PollForFirstKey()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
			}
			int count = Consts.keyboardKeyValues.Count;
			for (int i = 0; i < count; i++)
			{
				KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[i];
				if (GetKey(keyCode))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, GetKeyName(keyCode), AWCbIECppuLDtCThiwONsElGeIEub.buttonElementIdentifierIds[i], keyCode);
				}
			}
			return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
		}

		public IEnumerable<ControllerPollingInfo> PollForAllKeys()
		{
			return new bwVQnvCwKtRMzGCCauvIOqIrpCcS(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this
			};
		}

		public IEnumerable<ControllerPollingInfo> PollForAllKeysDown()
		{
			return new UsaDkEHiCcJIIDoEISDWFhxtTjpk(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this
			};
		}

		public ControllerPollingInfo PollForFirstKeyDown()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
			}
			int count = Consts.keyboardKeyValues.Count;
			for (int i = 0; i < count; i++)
			{
				KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[i];
				if (GetKeyDown(keyCode))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, GetKeyName(keyCode), AWCbIECppuLDtCThiwONsElGeIEub.buttonElementIdentifierIds[i], keyCode);
				}
			}
			return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
		}

		public override ControllerPollingInfo PollForFirstButton()
		{
			return PollForFirstKey();
		}

		public override ControllerPollingInfo PollForFirstButtonDown()
		{
			return PollForFirstKeyDown();
		}

		public override IEnumerable<ControllerPollingInfo> PollForAllButtons()
		{
			return PollForAllKeys();
		}

		public override IEnumerable<ControllerPollingInfo> PollForAllButtonsDown()
		{
			return PollForAllKeysDown();
		}

		public static bool IsModifierKey(KeyCode key)
		{
			switch (key)
			{
			case KeyCode.None:
				return false;
			case KeyCode.RightShift:
			case KeyCode.LeftShift:
			case KeyCode.RightControl:
			case KeyCode.LeftControl:
			case KeyCode.RightAlt:
			case KeyCode.LeftAlt:
			case KeyCode.RightCommand:
			case KeyCode.LeftCommand:
				return true;
			default:
				return false;
			}
		}

		internal static bool JScIttmBkgMsHdfRTwQqHcXQGAnCA(KeyboardKeyCode P_0)
		{
			switch (P_0)
			{
			case KeyboardKeyCode.None:
				return false;
			case KeyboardKeyCode.RightShift:
			case KeyboardKeyCode.LeftShift:
			case KeyboardKeyCode.RightControl:
			case KeyboardKeyCode.LeftControl:
			case KeyboardKeyCode.RightAlt:
			case KeyboardKeyCode.LeftAlt:
			case KeyboardKeyCode.RightCommand:
			case KeyboardKeyCode.LeftCommand:
				return true;
			default:
				return false;
			}
		}

		public static ModifierKey KeyCodeToModifierKey(KeyCode key)
		{
			switch (key)
			{
			case KeyCode.None:
				return ModifierKey.None;
			case KeyCode.RightControl:
			case KeyCode.LeftControl:
				return ModifierKey.Control;
			case KeyCode.RightAlt:
			case KeyCode.LeftAlt:
				return ModifierKey.Alt;
			case KeyCode.RightCommand:
			case KeyCode.LeftCommand:
				return ModifierKey.Command;
			case KeyCode.RightShift:
			case KeyCode.LeftShift:
				return ModifierKey.Shift;
			default:
				return ModifierKey.None;
			}
		}

		public static ModifierKeyFlags KeyCodeToModifierKeyFlags(KeyCode key)
		{
			switch (key)
			{
			case KeyCode.LeftControl:
				return ModifierKeyFlags.LeftControl;
			case KeyCode.RightControl:
				return ModifierKeyFlags.RightControl;
			case KeyCode.LeftAlt:
				return ModifierKeyFlags.LeftAlt;
			case KeyCode.RightAlt:
				return ModifierKeyFlags.RightAlt;
			case KeyCode.LeftShift:
				return ModifierKeyFlags.LeftShift;
			case KeyCode.RightShift:
				return ModifierKeyFlags.RightShift;
			case KeyCode.LeftCommand:
				return ModifierKeyFlags.LeftCommand;
			case KeyCode.RightCommand:
				return ModifierKeyFlags.RightCommand;
			default:
				return ModifierKeyFlags.None;
			}
		}

		public static bool ModifierKeyFlagsContain(ModifierKeyFlags flags, ModifierKey key)
		{
			switch (key)
			{
			case ModifierKey.None:
				return false;
			case ModifierKey.Control:
				if ((flags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
				{
					return true;
				}
				if ((flags & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
				{
					return true;
				}
				return false;
			case ModifierKey.Alt:
				if ((flags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
				{
					return true;
				}
				if ((flags & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
				{
					return true;
				}
				return false;
			case ModifierKey.Shift:
				if ((flags & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
				{
					return true;
				}
				if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
				{
					return true;
				}
				return false;
			case ModifierKey.Command:
				if ((flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
				{
					return true;
				}
				if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
				{
					return true;
				}
				return false;
			default:
				return false;
			}
		}

		public static bool ModifierKeyFlagsContain(ModifierKeyFlags flags, KeyCode key)
		{
			switch (key)
			{
			case KeyCode.None:
				return false;
			case KeyCode.LeftControl:
				if ((flags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
				{
					return true;
				}
				return false;
			case KeyCode.RightControl:
				if ((flags & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
				{
					return true;
				}
				return false;
			case KeyCode.LeftAlt:
				if ((flags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
				{
					return true;
				}
				return false;
			case KeyCode.RightAlt:
				if ((flags & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
				{
					return true;
				}
				return false;
			case KeyCode.LeftShift:
				if ((flags & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
				{
					return true;
				}
				return false;
			case KeyCode.RightShift:
				if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
				{
					return true;
				}
				return false;
			case KeyCode.LeftCommand:
				if ((flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
				{
					return true;
				}
				return false;
			case KeyCode.RightCommand:
				if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
				{
					return true;
				}
				return false;
			default:
				return false;
			}
		}

		public static ModifierKey ModifierKeyFlagsToModifierKey(ModifierKeyFlags flags)
		{
			if ((flags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
			{
				return ModifierKey.Control;
			}
			if ((flags & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
			{
				return ModifierKey.Control;
			}
			if ((flags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
			{
				return ModifierKey.Alt;
			}
			if ((flags & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
			{
				return ModifierKey.Alt;
			}
			if ((flags & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
			{
				return ModifierKey.Shift;
			}
			if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
			{
				return ModifierKey.Shift;
			}
			if ((flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
			{
				return ModifierKey.Command;
			}
			if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
			{
				return ModifierKey.Command;
			}
			return ModifierKey.None;
		}

		public static KeyCode ModifierKeyFlagsToKeyCode(ModifierKeyFlags flags)
		{
			if ((flags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
			{
				return KeyCode.LeftControl;
			}
			if ((flags & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
			{
				return KeyCode.RightControl;
			}
			if ((flags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
			{
				return KeyCode.LeftAlt;
			}
			if ((flags & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
			{
				return KeyCode.RightAlt;
			}
			if ((flags & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
			{
				return KeyCode.LeftShift;
			}
			if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
			{
				return KeyCode.RightShift;
			}
			if ((flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
			{
				return KeyCode.LeftCommand;
			}
			if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
			{
				return KeyCode.RightCommand;
			}
			return KeyCode.None;
		}

		public static ModifierKeyFlags ModifierKeyToModifierKeyFlags(ModifierKey key)
		{
			switch (key)
			{
			case ModifierKey.None:
				return ModifierKeyFlags.None;
			case ModifierKey.Control:
				return ModifierKeyFlags.LeftControl | ModifierKeyFlags.RightControl;
			case ModifierKey.Alt:
				return ModifierKeyFlags.LeftAlt | ModifierKeyFlags.RightAlt;
			case ModifierKey.Shift:
				return ModifierKeyFlags.LeftShift | ModifierKeyFlags.RightShift;
			case ModifierKey.Command:
				return ModifierKeyFlags.LeftCommand | ModifierKeyFlags.RightCommand;
			default:
				return ModifierKeyFlags.None;
			}
		}

		public static string GetKeyName(KeyCode key)
		{
			if (daIVciQEvCtqbioIoJuNBqfDhIkJ == null)
			{
				return string.Empty;
			}
			int buttonIndex = daIVciQEvCtqbioIoJuNBqfDhIkJ.GetButtonIndex(XbboyWJyzBtZEWrUkIElMurDOyys(key));
			if (buttonIndex < 0)
			{
				return string.Empty;
			}
			return daIVciQEvCtqbioIoJuNBqfDhIkJ.ButtonElementIdentifiers[buttonIndex].name;
		}

		public static string GetKeyName(KeyCode key, ModifierKeyFlags flags)
		{
			string text = GetKeyName(key);
			if (flags != ModifierKeyFlags.None)
			{
				StringBuilder stringBuilder = new StringBuilder(text);
				stringBuilder.Append(" + ");
				stringBuilder.Append(ModifierKeyFlagsToString(flags));
				text = stringBuilder.ToString();
			}
			return text;
		}

		public static string GetModifierKeyName(ModifierKey modifierKey)
		{
			if (daIVciQEvCtqbioIoJuNBqfDhIkJ == null)
			{
				return string.Empty;
			}
			return daIVciQEvCtqbioIoJuNBqfDhIkJ.ufVAFIeJhcoXMNVXgQxvZoDqTBrV(modifierKey, false);
		}

		public static string GetModifierKeyName(ModifierKey modifierKey, bool getShortName)
		{
			if (daIVciQEvCtqbioIoJuNBqfDhIkJ == null)
			{
				return string.Empty;
			}
			return daIVciQEvCtqbioIoJuNBqfDhIkJ.ufVAFIeJhcoXMNVXgQxvZoDqTBrV(modifierKey, getShortName);
		}

		public static string ModifierKeyFlagsToString(ModifierKeyFlags flags, bool getShortName)
		{
			int num = 0;
			StringBuilder stringBuilder = new StringBuilder();
			if (ModifierKeyFlagsContain(flags, ModifierKey.Control))
			{
				stringBuilder.Append(GetModifierKeyName(ModifierKey.Control, getShortName));
				num++;
			}
			if (ModifierKeyFlagsContain(flags, ModifierKey.Command))
			{
				if (num > 0)
				{
					stringBuilder.Append(" + ");
				}
				stringBuilder.Append(GetModifierKeyName(ModifierKey.Command, getShortName));
				num++;
			}
			if (ModifierKeyFlagsContain(flags, ModifierKey.Alt))
			{
				if (num > 0)
				{
					stringBuilder.Append(" + ");
				}
				stringBuilder.Append(GetModifierKeyName(ModifierKey.Alt, getShortName));
				num++;
			}
			if (num >= 3)
			{
				return stringBuilder.ToString();
			}
			if (ModifierKeyFlagsContain(flags, ModifierKey.Shift))
			{
				if (num > 0)
				{
					stringBuilder.Append(" + ");
				}
				stringBuilder.Append(GetModifierKeyName(ModifierKey.Shift, getShortName));
				num++;
			}
			return stringBuilder.ToString();
		}

		public static string ModifierKeyFlagsToString(ModifierKeyFlags flags)
		{
			return ModifierKeyFlagsToString(flags, getShortName: false);
		}

		public static object GetModifierKeyGlyph(ModifierKey modifierKey)
		{
			if (daIVciQEvCtqbioIoJuNBqfDhIkJ == null)
			{
				return null;
			}
			return daIVciQEvCtqbioIoJuNBqfDhIkJ.YnjyYDNzuhQnRQpEQyWMfJSevvqE(modifierKey);
		}

		internal static string jymnBHidUmzuuKypeGgPOWzQNXDb(ModifierKey P_0)
		{
			if (daIVciQEvCtqbioIoJuNBqfDhIkJ == null)
			{
				return string.Empty;
			}
			return daIVciQEvCtqbioIoJuNBqfDhIkJ.NkZuBJNpYYeqCezdfkKzqWLcThnn(P_0);
		}

		internal static KeyboardKeyCode XbboyWJyzBtZEWrUkIElMurDOyys(KeyCode P_0)
		{
			return (KeyboardKeyCode)P_0;
		}

		internal static KeyCode hLCSNOjmzRRszVIigLVwNHstOdSE(KeyboardKeyCode P_0)
		{
			return (KeyCode)P_0;
		}

		internal static ModifierKeyFlags WpiPGdUCevALQlmVADrdROktvftm(ModifierKeyFlags P_0)
		{
			if ((P_0 & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
			{
				P_0 |= ModifierKeyFlags.RightControl;
			}
			if ((P_0 & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
			{
				P_0 |= ModifierKeyFlags.LeftControl;
			}
			if ((P_0 & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
			{
				P_0 |= ModifierKeyFlags.RightCommand;
			}
			if ((P_0 & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
			{
				P_0 |= ModifierKeyFlags.LeftCommand;
			}
			if ((P_0 & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
			{
				P_0 |= ModifierKeyFlags.RightAlt;
			}
			if ((P_0 & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
			{
				P_0 |= ModifierKeyFlags.LeftAlt;
			}
			if ((P_0 & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
			{
				P_0 |= ModifierKeyFlags.RightShift;
			}
			if ((P_0 & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
			{
				P_0 |= ModifierKeyFlags.LeftShift;
			}
			return P_0;
		}

		internal static int hGkZkBfOatFMqgMssMRWiDMvoUNdb(ModifierKeyFlags P_0)
		{
			if (P_0 == ModifierKeyFlags.None)
			{
				return 0;
			}
			int num = 0;
			if ((P_0 & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
			{
				num++;
			}
			else if ((P_0 & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
			{
				num++;
			}
			if ((P_0 & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
			{
				num++;
			}
			else if ((P_0 & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
			{
				num++;
			}
			if ((P_0 & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
			{
				num++;
			}
			else if ((P_0 & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
			{
				num++;
			}
			if ((P_0 & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
			{
				num++;
			}
			else if ((P_0 & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
			{
				num++;
			}
			return num;
		}

		[CustomObfuscation(rename = false)]
		internal static KeyboardKeyCode GetKeyboardKeyCodeByButtonIndex(int buttonIndex)
		{
			if ((uint)buttonIndex > 132u)
			{
				return KeyboardKeyCode.None;
			}
			return MDOCNgfDqGevDdmmteZQMMPbsmsL[buttonIndex];
		}

		internal static int SoZRTGcHjCoUcYlszSAEabCCdixn(KeyboardKeyCode P_0)
		{
			int buttonIndex = daIVciQEvCtqbioIoJuNBqfDhIkJ.GetButtonIndex(P_0);
			if (buttonIndex < 0)
			{
				return -1;
			}
			return daIVciQEvCtqbioIoJuNBqfDhIkJ.ButtonElementIdentifiers[buttonIndex].id;
		}

		internal static void cBfVBUZbWeWptZKZFvHhKPyjnheu(ref int P_0, ref KeyCode P_1)
		{
			if (P_1 != KeyCode.None)
			{
				P_0 = SoZRTGcHjCoUcYlszSAEabCCdixn(XbboyWJyzBtZEWrUkIElMurDOyys(P_1));
			}
			else
			{
				P_1 = ReInput.vnBcsWOiBrsweGQzTZwXEVWsKEyb.ksIrgmIMxbskrWvzAPRFSsoyIedU.GetKeyCodeById(P_0);
			}
		}

		internal override void tglbagDKhFNyJrooYNWfohsJFQmi(UpdateLoopType P_0)
		{
			CLFHWOuPSRLahPSSrSHZoiqMbYrk.UpdateInputData(fcpRkkeLOqieJylVwWSUEEJhOXpJ);
			base.tglbagDKhFNyJrooYNWfohsJFQmi(P_0);
			tnDVySByHhqgpvyoiiADqOboNYAI();
		}

		internal void fJNKoWgTsiTKBYlvYSrPTkQDMyXC(UpdateLoopType P_0)
		{
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape].ZCYeQXTQlBeczBTsRNSgmJnLWcxf(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape, fcpRkkeLOqieJylVwWSUEEJhOXpJ);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu].ZCYeQXTQlBeczBTsRNSgmJnLWcxf(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu, fcpRkkeLOqieJylVwWSUEEJhOXpJ);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_F2].ZCYeQXTQlBeczBTsRNSgmJnLWcxf(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_F2, fcpRkkeLOqieJylVwWSUEEJhOXpJ);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow].ZCYeQXTQlBeczBTsRNSgmJnLWcxf(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow, fcpRkkeLOqieJylVwWSUEEJhOXpJ);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow].ZCYeQXTQlBeczBTsRNSgmJnLWcxf(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow, fcpRkkeLOqieJylVwWSUEEJhOXpJ);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow].ZCYeQXTQlBeczBTsRNSgmJnLWcxf(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow, fcpRkkeLOqieJylVwWSUEEJhOXpJ);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow].ZCYeQXTQlBeczBTsRNSgmJnLWcxf(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow, fcpRkkeLOqieJylVwWSUEEJhOXpJ);
		}

		internal bool vtOmEEXVokrjXeqhtDXDMqrjDhwE(KeyboardKeyCode P_0)
		{
			if ((uint)P_0 > (uint)OVuXxxrWhkZTPkIISbbBytPyESOj)
			{
				return false;
			}
			int num = EILjPeSCmjzvfzZNxpyfRbFbplmf[(int)P_0];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].value;
		}

		internal bool ANTCcQvnEJhsTItCMjDSxqnmjVYPA(KeyboardKeyCode P_0)
		{
			if ((uint)P_0 > (uint)OVuXxxrWhkZTPkIISbbBytPyESOj)
			{
				return false;
			}
			int num = EILjPeSCmjzvfzZNxpyfRbFbplmf[(int)P_0];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].valuePrev;
		}

		internal bool JgbGnLHDygzucaRiXhLugJqAHZZv(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (!vtOmEEXVokrjXeqhtDXDMqrjDhwE(P_0))
			{
				return false;
			}
			if (P_1 == ModifierKeyFlags.None)
			{
				return true;
			}
			if ((P_1 & roTfpKeksRizKimpmXsHMpDCggGX) != P_1)
			{
				return false;
			}
			double keyTimePressed = GetKeyTimePressed((KeyCode)P_0);
			if ((P_1 & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl && keyTimePressed > GetModifierKeyTimePressed(ModifierKey.Control))
			{
				return false;
			}
			if ((P_1 & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand && keyTimePressed > GetModifierKeyTimePressed(ModifierKey.Command))
			{
				return false;
			}
			if ((P_1 & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt && keyTimePressed > GetModifierKeyTimePressed(ModifierKey.Alt))
			{
				return false;
			}
			if ((P_1 & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift && keyTimePressed > GetModifierKeyTimePressed(ModifierKey.Shift))
			{
				return false;
			}
			return true;
		}

		internal bool BQKBQuekgvUeiUvYaLDeJJOcjVAfb(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (vtOmEEXVokrjXeqhtDXDMqrjDhwE(P_0))
			{
				return true;
			}
			if (GetModifierKey(ModifierKeyFlagsToModifierKey(P_1)))
			{
				return true;
			}
			return false;
		}

		[CustomObfuscation(rename = false)]
		internal int GetButtonIndex(KeyboardKeyCode keyCode)
		{
			if ((uint)keyCode > (uint)OVuXxxrWhkZTPkIISbbBytPyESOj)
			{
				return -1;
			}
			return EILjPeSCmjzvfzZNxpyfRbFbplmf[(int)keyCode];
		}

		[CustomObfuscation(rename = false)]
		internal void BakeMap(ControllerMap controllerMap)
		{
			if (controllerMap != null)
			{
				IList<ActionElementMap> list = controllerMap.UetWStxkTEpvtiiHkgsRzKetHbwDA;
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					vnEKgLVSpFebRqVrxBMjTwuUqPef(controllerMap, list[i]);
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal void BakeActionElementMap(ControllerMap controllerMap, ActionElementMap map)
		{
			map?.XxnQtsdeMuILfHyfAVjirqwliWOgA(controllerMap);
		}

		internal override void wJjPIIRJfHhEbGedUconecGfiwzgB()
		{
			base.wJjPIIRJfHhEbGedUconecGfiwzgB();
			FmksErTAobCBAhJGyShibXWVBRnTA = ModifierKeyFlags.None;
			roTfpKeksRizKimpmXsHMpDCggGX = ModifierKeyFlags.None;
		}

		internal override bool vSypfONnKVpDpZlTyTmFsHtqFCqP(bool P_0)
		{
			if (!base.vSypfONnKVpDpZlTyTmFsHtqFCqP(P_0))
			{
				return false;
			}
			if (CLFHWOuPSRLahPSSrSHZoiqMbYrk is IGetSetEnabled)
			{
				(CLFHWOuPSRLahPSSrSHZoiqMbYrk as IGetSetEnabled).enabled = P_0;
			}
			return true;
		}

		private bool cbfclbvIBKLfWaRUdHELQdZGVkzd(out Button P_0, out Button P_1, ModifierKey P_2)
		{
			P_0 = null;
			P_1 = null;
			switch (P_2)
			{
			case ModifierKey.None:
				return false;
			case ModifierKey.Control:
				P_0 = buttons[EILjPeSCmjzvfzZNxpyfRbFbplmf[306]];
				P_1 = buttons[EILjPeSCmjzvfzZNxpyfRbFbplmf[305]];
				return true;
			case ModifierKey.Alt:
				P_0 = buttons[EILjPeSCmjzvfzZNxpyfRbFbplmf[308]];
				P_1 = buttons[EILjPeSCmjzvfzZNxpyfRbFbplmf[307]];
				return true;
			case ModifierKey.Command:
				P_0 = buttons[EILjPeSCmjzvfzZNxpyfRbFbplmf[310]];
				P_1 = buttons[EILjPeSCmjzvfzZNxpyfRbFbplmf[309]];
				return true;
			case ModifierKey.Shift:
				P_0 = buttons[EILjPeSCmjzvfzZNxpyfRbFbplmf[304]];
				P_1 = buttons[EILjPeSCmjzvfzZNxpyfRbFbplmf[303]];
				return true;
			default:
				return false;
			}
		}

		private void tnDVySByHhqgpvyoiiADqOboNYAI()
		{
			ModifierKeyFlags modifierKeyFlags = ModifierKeyFlags.None;
			if (buttons[EILjPeSCmjzvfzZNxpyfRbFbplmf[306]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftControl;
			}
			if (buttons[EILjPeSCmjzvfzZNxpyfRbFbplmf[305]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightControl;
			}
			if (buttons[EILjPeSCmjzvfzZNxpyfRbFbplmf[310]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftCommand;
			}
			if (buttons[EILjPeSCmjzvfzZNxpyfRbFbplmf[309]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightCommand;
			}
			if (buttons[EILjPeSCmjzvfzZNxpyfRbFbplmf[308]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftAlt;
			}
			if (buttons[EILjPeSCmjzvfzZNxpyfRbFbplmf[307]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightAlt;
			}
			if (buttons[EILjPeSCmjzvfzZNxpyfRbFbplmf[304]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftShift;
			}
			if (buttons[EILjPeSCmjzvfzZNxpyfRbFbplmf[303]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightShift;
			}
			FmksErTAobCBAhJGyShibXWVBRnTA = modifierKeyFlags;
			roTfpKeksRizKimpmXsHMpDCggGX = WpiPGdUCevALQlmVADrdROktvftm(modifierKeyFlags);
		}

		private string ufVAFIeJhcoXMNVXgQxvZoDqTBrV(ModifierKey P_0, bool P_1)
		{
			if (P_0 == ModifierKey.None)
			{
				return string.Empty;
			}
			ModifierKeyInfo modifierKeyInfo = Consts.modifierKeyInfo[(int)P_0];
			string result = modifierKeyInfo.GetName(P_1);
			if (!LocalizationManager.isEnabled)
			{
				return result;
			}
			if (!PwqSDuBEXumUoHiWpqrKpLxpWSGy.TryGetValue((int)P_0, out var value))
			{
				return result;
			}
			string result2;
			if (P_1)
			{
				if (value.sjIElpUxfRfRUqQAuNHkFWJKQfuJ != null && MezcNmXiZvudUqKQZkGMsoXCBrejA(value.sjIElpUxfRfRUqQAuNHkFWJKQfuJ, modifierKeyInfo.shortKey, modifierKeyInfo.shortName, AWCbIECppuLDtCThiwONsElGeIEub.deviceLocalizationInfo, out result2))
				{
					return result2;
				}
				if (value.EYaJuFRcsmFpdjOTJHpGDWpcNFARb != null && MezcNmXiZvudUqKQZkGMsoXCBrejA(value.EYaJuFRcsmFpdjOTJHpGDWpcNFARb, modifierKeyInfo.longKey, modifierKeyInfo.longName, AWCbIECppuLDtCThiwONsElGeIEub.deviceLocalizationInfo, out result2))
				{
					return result2;
				}
				return result;
			}
			if (value.EYaJuFRcsmFpdjOTJHpGDWpcNFARb == null)
			{
				return result;
			}
			MezcNmXiZvudUqKQZkGMsoXCBrejA(value.EYaJuFRcsmFpdjOTJHpGDWpcNFARb, modifierKeyInfo.longKey, modifierKeyInfo.longName, AWCbIECppuLDtCThiwONsElGeIEub.deviceLocalizationInfo, out result2);
			return result2;
		}

		private static bool MezcNmXiZvudUqKQZkGMsoXCBrejA(dnLmCQexgDwxKOANksXDzCTvVPik P_0, string P_1, string P_2, DeviceLocalizationInfo P_3, out string P_4)
		{
			LocalizationManager.GetAndUpdateLocalizedStringResultFlags getAndUpdateLocalizedStringResultFlags = bYUfoUKGpLnbYkcOYAkjmqgxLxsS.HMgzPeSwpkGvipoCujYWapPuEqPy(P_0.ANnyYrpgRHgHrBXsbJxMFrsUzupD, P_1, "controller", P_2, P_3, urAVZRefROHDbvendscKLBZHGrdo.Keyboard, -1, AxisRange.Full, -1, out P_4);
			if ((getAndUpdateLocalizedStringResultFlags & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
			{
				P_0.HXKhdHpexPYddGMtYPiGAoiZjeQX = (getAndUpdateLocalizedStringResultFlags & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.JustLocalized) != 0;
			}
			return P_0.HXKhdHpexPYddGMtYPiGAoiZjeQX;
		}

		private object YnjyYDNzuhQnRQpEQyWMfJSevvqE(ModifierKey P_0)
		{
			if (P_0 == ModifierKey.None)
			{
				return null;
			}
			ModifierKeyInfo modifierKeyInfo = Consts.modifierKeyInfo[(int)P_0];
			if (!GlyphManager.isEnabled)
			{
				return null;
			}
			if (!dTQNgGLlLMwkqYDJuIATEThzvrOt.TryGetValue((int)P_0, out var value))
			{
				return null;
			}
			if (qYPCoaheILhSYVEnKCUoPLrSMhDBA(value, modifierKeyInfo.longKey, AWCbIECppuLDtCThiwONsElGeIEub.deviceLocalizationInfo, out var result))
			{
				return result;
			}
			return null;
		}

		private string NkZuBJNpYYeqCezdfkKzqWLcThnn(ModifierKey P_0)
		{
			if (P_0 == ModifierKey.None)
			{
				return null;
			}
			ModifierKeyInfo modifierKeyInfo = Consts.modifierKeyInfo[(int)P_0];
			if (!GlyphManager.isEnabled)
			{
				return null;
			}
			if (!dTQNgGLlLMwkqYDJuIATEThzvrOt.TryGetValue((int)P_0, out var value))
			{
				return null;
			}
			if (CdglzgafrAveWJzmljbzLbmzDZGk(value, modifierKeyInfo.longKey, AWCbIECppuLDtCThiwONsElGeIEub.deviceLocalizationInfo, out var result))
			{
				return result;
			}
			return null;
		}

		private static bool qYPCoaheILhSYVEnKCUoPLrSMhDBA(OGJxJivAzTceTrClSrcSZPkuiElp P_0, string P_1, DeviceLocalizationInfo P_2, out object P_3)
		{
			GlyphManager.GetAndUpdateGlyphResultFlags getAndUpdateGlyphResultFlags = NfMEdmAZiwwhofFCWPXtSFCyPfwaA.GCmgPYLJvhRgYXNkhFCWSxUETVPr(P_0.ANnyYrpgRHgHrBXsbJxMFrsUzupD, P_1, "controller", P_2, urAVZRefROHDbvendscKLBZHGrdo.Keyboard, -1, AxisRange.Full, -1, out P_3);
			if ((getAndUpdateGlyphResultFlags & GlyphManager.GetAndUpdateGlyphResultFlags.Changed) != GlyphManager.GetAndUpdateGlyphResultFlags.None)
			{
				P_0.YNWrmmBdJeaMqGJqqClqkervvJbTA = (getAndUpdateGlyphResultFlags & GlyphManager.GetAndUpdateGlyphResultFlags.JustGot) != 0;
			}
			return P_0.YNWrmmBdJeaMqGJqqClqkervvJbTA;
		}

		private static bool CdglzgafrAveWJzmljbzLbmzDZGk(OGJxJivAzTceTrClSrcSZPkuiElp P_0, string P_1, DeviceLocalizationInfo P_2, out string P_3)
		{
			object obj;
			bool result = qYPCoaheILhSYVEnKCUoPLrSMhDBA(P_0, P_1, P_2, out obj);
			P_3 = P_0.ANnyYrpgRHgHrBXsbJxMFrsUzupD.cachedKey;
			return result;
		}

		[CompilerGenerated]
		private void yCjVfoxUGFmRTKsRLwfmVHWpHFNb()
		{
			IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
			for (int i = 0; i < values.Count; i++)
			{
				ufVAFIeJhcoXMNVXgQxvZoDqTBrV(values[i], true);
				ufVAFIeJhcoXMNVXgQxvZoDqTBrV(values[i], false);
			}
		}

		[CompilerGenerated]
		private void kgpWOwGoFTYrkeVLJRGGfSUdgrzw()
		{
			IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
			for (int i = 0; i < values.Count; i++)
			{
				YnjyYDNzuhQnRQpEQyWMfJSevvqE(values[i]);
			}
		}
	}
}
