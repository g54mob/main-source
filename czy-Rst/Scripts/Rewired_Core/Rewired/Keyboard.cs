using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
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

		private class hbHKpbHlPHTrJgTaAGunhJSJiFUH
		{
			public readonly vaYdlqCIibKfFdpYixvQIHAgosGzb cJXxBDaJGFTRPTfAVmcaxPBnWqzR;

			public readonly vaYdlqCIibKfFdpYixvQIHAgosGzb qIbvTGdBwifRemEuRuQyidzQApNW;

			public hbHKpbHlPHTrJgTaAGunhJSJiFUH(string P_0, string P_1)
			{
				if (!string.IsNullOrEmpty(P_0))
				{
					cJXxBDaJGFTRPTfAVmcaxPBnWqzR = new vaYdlqCIibKfFdpYixvQIHAgosGzb(new LocalizedString());
				}
				if (!string.IsNullOrEmpty(P_1))
				{
					qIbvTGdBwifRemEuRuQyidzQApNW = new vaYdlqCIibKfFdpYixvQIHAgosGzb(new LocalizedString());
				}
			}
		}

		private sealed class vaYdlqCIibKfFdpYixvQIHAgosGzb
		{
			public readonly LocalizedString dTLJvTWzdmiebFWZPDhLyaKSDoVk;

			public bool ERQekbVDCbRovKpDXfWQBjevroSnA;

			public vaYdlqCIibKfFdpYixvQIHAgosGzb(LocalizedString P_0)
			{
				dTLJvTWzdmiebFWZPDhLyaKSDoVk = P_0;
			}
		}

		private sealed class YMUVaWRfzbXxSEfyDTzBjzbdonFs
		{
			public readonly KeyedGlyph aZMexCasesZGiTJADOwuAhjaUKvJB;

			public bool IRjcCHkEGYxhHwxiXHkwSjdDoWaA;

			public YMUVaWRfzbXxSEfyDTzBjzbdonFs(KeyedGlyph P_0)
			{
				aZMexCasesZGiTJADOwuAhjaUKvJB = P_0;
			}
		}

		private sealed class zOCeJieUTJVoaxNUhwDvwDMezAPB : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int qfCBvfoekJoYyTyCftbgYXRQAFRb;

			private ControllerPollingInfo cclkbnAmfbKKVzgiAaFQmqjSLjRv;

			private int zbfQFOHIruDcXZxeYraZMnbjjjfS;

			public Keyboard SjEKFWZwWEbUiWLXPJPRanWdnhCi;

			private int cbiCGFSLkleJwSXcjAgbaAHxRNFvA;

			private int HpdyyWSSawykOrlATLCMMjEJHOyd;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return cclkbnAmfbKKVzgiAaFQmqjSLjRv;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return cclkbnAmfbKKVzgiAaFQmqjSLjRv;
				}
			}

			[DebuggerHidden]
			public zOCeJieUTJVoaxNUhwDvwDMezAPB(int P_0)
			{
				qfCBvfoekJoYyTyCftbgYXRQAFRb = P_0;
				zbfQFOHIruDcXZxeYraZMnbjjjfS = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = qfCBvfoekJoYyTyCftbgYXRQAFRb;
				Keyboard sjEKFWZwWEbUiWLXPJPRanWdnhCi = SjEKFWZwWEbUiWLXPJPRanWdnhCi;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					qfCBvfoekJoYyTyCftbgYXRQAFRb = -1;
					goto IL_00bf;
				}
				qfCBvfoekJoYyTyCftbgYXRQAFRb = -1;
				if (ReInput._id != sjEKFWZwWEbUiWLXPJPRanWdnhCi.AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(sjEKFWZwWEbUiWLXPJPRanWdnhCi.AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return false;
				}
				cbiCGFSLkleJwSXcjAgbaAHxRNFvA = Consts.keyboardKeyValues.Count;
				HpdyyWSSawykOrlATLCMMjEJHOyd = 0;
				goto IL_00cf;
				IL_00cf:
				if (HpdyyWSSawykOrlATLCMMjEJHOyd < cbiCGFSLkleJwSXcjAgbaAHxRNFvA)
				{
					KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[HpdyyWSSawykOrlATLCMMjEJHOyd];
					if (sjEKFWZwWEbUiWLXPJPRanWdnhCi.GetKey(keyCode))
					{
						cclkbnAmfbKKVzgiAaFQmqjSLjRv = new ControllerPollingInfo(true, -1, sjEKFWZwWEbUiWLXPJPRanWdnhCi.id, sjEKFWZwWEbUiWLXPJPRanWdnhCi._name, sjEKFWZwWEbUiWLXPJPRanWdnhCi._type, ControllerElementType.Button, HpdyyWSSawykOrlATLCMMjEJHOyd, Pole.Positive, GetKeyName(keyCode), sjEKFWZwWEbUiWLXPJPRanWdnhCi.UzVdrXbKoYScsNhLYrSoTUeynXDBb.buttonElementIdentifierIds[HpdyyWSSawykOrlATLCMMjEJHOyd], keyCode);
						qfCBvfoekJoYyTyCftbgYXRQAFRb = 1;
						return true;
					}
					goto IL_00bf;
				}
				return false;
				IL_00bf:
				HpdyyWSSawykOrlATLCMMjEJHOyd++;
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
				zOCeJieUTJVoaxNUhwDvwDMezAPB zOCeJieUTJVoaxNUhwDvwDMezAPB2;
				if (qfCBvfoekJoYyTyCftbgYXRQAFRb == -2 && zbfQFOHIruDcXZxeYraZMnbjjjfS == Environment.CurrentManagedThreadId)
				{
					qfCBvfoekJoYyTyCftbgYXRQAFRb = 0;
					zOCeJieUTJVoaxNUhwDvwDMezAPB2 = this;
				}
				else
				{
					zOCeJieUTJVoaxNUhwDvwDMezAPB2 = new zOCeJieUTJVoaxNUhwDvwDMezAPB(0);
					zOCeJieUTJVoaxNUhwDvwDMezAPB2.SjEKFWZwWEbUiWLXPJPRanWdnhCi = SjEKFWZwWEbUiWLXPJPRanWdnhCi;
				}
				return zOCeJieUTJVoaxNUhwDvwDMezAPB2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class UExvUmdAIQjPRdcVFqULUfgsTqJtA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int gWcmMJuVwslYgeFlRDxXpOlVbNwiA;

			private ControllerPollingInfo zFuhbjsZNMdlAdjNkHwpqVWwtUcI;

			private int KCjnmLfUXujDpyBxJFneGtBacFTn;

			public Keyboard kqeYrYmjEuJUMCfgYfyfuWztjXfT;

			private int FxYffeDGQqchGECVTkpZIEldbtWfc;

			private int UroWEiFmSOcCBmtaSLfGsJUAdbLgA;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return zFuhbjsZNMdlAdjNkHwpqVWwtUcI;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return zFuhbjsZNMdlAdjNkHwpqVWwtUcI;
				}
			}

			[DebuggerHidden]
			public UExvUmdAIQjPRdcVFqULUfgsTqJtA(int P_0)
			{
				gWcmMJuVwslYgeFlRDxXpOlVbNwiA = P_0;
				KCjnmLfUXujDpyBxJFneGtBacFTn = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = gWcmMJuVwslYgeFlRDxXpOlVbNwiA;
				Keyboard keyboard = kqeYrYmjEuJUMCfgYfyfuWztjXfT;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					gWcmMJuVwslYgeFlRDxXpOlVbNwiA = -1;
					goto IL_00bf;
				}
				gWcmMJuVwslYgeFlRDxXpOlVbNwiA = -1;
				if (ReInput._id != keyboard.AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(keyboard.AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return false;
				}
				FxYffeDGQqchGECVTkpZIEldbtWfc = Consts.keyboardKeyValues.Count;
				UroWEiFmSOcCBmtaSLfGsJUAdbLgA = 0;
				goto IL_00cf;
				IL_00cf:
				if (UroWEiFmSOcCBmtaSLfGsJUAdbLgA < FxYffeDGQqchGECVTkpZIEldbtWfc)
				{
					KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[UroWEiFmSOcCBmtaSLfGsJUAdbLgA];
					if (keyboard.GetKeyDown(keyCode))
					{
						zFuhbjsZNMdlAdjNkHwpqVWwtUcI = new ControllerPollingInfo(true, -1, keyboard.id, keyboard._name, keyboard._type, ControllerElementType.Button, UroWEiFmSOcCBmtaSLfGsJUAdbLgA, Pole.Positive, GetKeyName(keyCode), keyboard.UzVdrXbKoYScsNhLYrSoTUeynXDBb.buttonElementIdentifierIds[UroWEiFmSOcCBmtaSLfGsJUAdbLgA], keyCode);
						gWcmMJuVwslYgeFlRDxXpOlVbNwiA = 1;
						return true;
					}
					goto IL_00bf;
				}
				return false;
				IL_00bf:
				UroWEiFmSOcCBmtaSLfGsJUAdbLgA++;
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
				UExvUmdAIQjPRdcVFqULUfgsTqJtA uExvUmdAIQjPRdcVFqULUfgsTqJtA;
				if (gWcmMJuVwslYgeFlRDxXpOlVbNwiA == -2 && KCjnmLfUXujDpyBxJFneGtBacFTn == Environment.CurrentManagedThreadId)
				{
					gWcmMJuVwslYgeFlRDxXpOlVbNwiA = 0;
					uExvUmdAIQjPRdcVFqULUfgsTqJtA = this;
				}
				else
				{
					uExvUmdAIQjPRdcVFqULUfgsTqJtA = new UExvUmdAIQjPRdcVFqULUfgsTqJtA(0);
					uExvUmdAIQjPRdcVFqULUfgsTqJtA.kqeYrYmjEuJUMCfgYfyfuWztjXfT = kqeYrYmjEuJUMCfgYfyfuWztjXfT;
				}
				return uExvUmdAIQjPRdcVFqULUfgsTqJtA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private const string kTdNnmxwUWkiFRKJTxklPBYHwHOp = " + ";

		private static Keyboard MGKkaNhGkMNpOQBxomTLvGUQUHhB;

		private static KeyboardKeyCode[] zAhiHuBhcfpXBUSxrmpsMKhmEIArA;

		private static Guid QViVawCopruquFKBwYSAGhuIuYFQ;

		private readonly IUnifiedKeyboardSource ZpvjquEjWpLAQrNFxuFWNlDEPgFC;

		private ModifierKeyFlags NNzviPyBtqbOPkijONJnfOEHKIgtb;

		private ModifierKeyFlags mPzkEtUknSBDZKdgKArzTxCDlPCk;

		private Func<KeyboardKeyCode, int> KJDWktubnRjwYbKILpwaEFLcEWxab;

		private readonly int[] JjpTsmigjEcasfMWpQoXoWVBUFeBA;

		private readonly int vpVQaWAGruDgwGMDsqbxGPACvyHGA;

		private readonly pdzTLPmqpuLIOpAzKgpvnBvFeTFbA CtZeKXdlXlhtAlGxcsLbEKatriKJ;

		private readonly pMGFPAMXITZSyRhwggrNACqjyAhT YJFHygoJQuNPUOiHiJZQPEuoVTsL;

		private Dictionary<int, hbHKpbHlPHTrJgTaAGunhJSJiFUH> ZYwcvJQQgcsLClTWjkvBTdWuJBoM;

		private Dictionary<int, YMUVaWRfzbXxSEfyDTzBjzbdonFs> NKSvojhgjaLlLwNkYmDALuWezLpb;

		private static KeyboardKeyCode[] oIqabFlLiyHHUiwHnDekLAiTFVRC
		{
			get
			{
				if (zAhiHuBhcfpXBUSxrmpsMKhmEIArA == null)
				{
					int[] keyboardKeyValues = Consts._keyboardKeyValues;
					int num = keyboardKeyValues.Length;
					zAhiHuBhcfpXBUSxrmpsMKhmEIArA = new KeyboardKeyCode[num];
					for (int i = 0; i < num; i++)
					{
						zAhiHuBhcfpXBUSxrmpsMKhmEIArA[i] = (KeyboardKeyCode)keyboardKeyValues[i];
					}
				}
				return zAhiHuBhcfpXBUSxrmpsMKhmEIArA;
			}
		}

		private Dictionary<int, hbHKpbHlPHTrJgTaAGunhJSJiFUH> OvjQLSRfkXFvKehubjKqlKXROcFaA
		{
			get
			{
				if (ZYwcvJQQgcsLClTWjkvBTdWuJBoM == null)
				{
					Rewired.Utils.Interfaces.IReadOnlyDictionary<int, ModifierKeyInfo> modifierKeyInfo = Consts.modifierKeyInfo;
					Dictionary<int, hbHKpbHlPHTrJgTaAGunhJSJiFUH> dictionary = new Dictionary<int, hbHKpbHlPHTrJgTaAGunhJSJiFUH>();
					foreach (KeyValuePair<int, ModifierKeyInfo> item in modifierKeyInfo)
					{
						if (item.Key != 0)
						{
							dictionary.Add(item.Key, new hbHKpbHlPHTrJgTaAGunhJSJiFUH(item.Value.shortKey, item.Value.longKey));
						}
					}
					ZYwcvJQQgcsLClTWjkvBTdWuJBoM = dictionary;
				}
				return ZYwcvJQQgcsLClTWjkvBTdWuJBoM;
			}
		}

		private Dictionary<int, YMUVaWRfzbXxSEfyDTzBjzbdonFs> KcjwDJMfavJddGyaiQzCNJQnnBsr
		{
			get
			{
				if (NKSvojhgjaLlLwNkYmDALuWezLpb == null)
				{
					Rewired.Utils.Interfaces.IReadOnlyDictionary<int, ModifierKeyInfo> modifierKeyInfo = Consts.modifierKeyInfo;
					Dictionary<int, YMUVaWRfzbXxSEfyDTzBjzbdonFs> dictionary = new Dictionary<int, YMUVaWRfzbXxSEfyDTzBjzbdonFs>();
					foreach (KeyValuePair<int, ModifierKeyInfo> item in modifierKeyInfo)
					{
						if (item.Key != 0)
						{
							YMUVaWRfzbXxSEfyDTzBjzbdonFs value = new YMUVaWRfzbXxSEfyDTzBjzbdonFs(new KeyedGlyph());
							dictionary.Add(item.Key, value);
						}
					}
					NKSvojhgjaLlLwNkYmDALuWezLpb = dictionary;
				}
				return NKSvojhgjaLlLwNkYmDALuWezLpb;
			}
		}

		Guid Controller.deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return Guid.Empty;
				}
				return QViVawCopruquFKBwYSAGhuIuYFQ;
			}
		}

		internal Keyboard(string P_0, IUnifiedKeyboardSource P_1)
			: this(0, P_1.inputSource, P_0, InputTools.FormatHardwareIdentifierString(P_0), P_1.hardwareMap, 132, P_1?.controllerExtension, new ControllerDataUpdater(P_1.inputSource, 0, 132, null))
		{
			QViVawCopruquFKBwYSAGhuIuYFQ = MiscTools.CreateGuidHashSHA1("[Universal Keyboard]");
			CtZeKXdlXlhtAlGxcsLbEKatriKJ = new pdzTLPmqpuLIOpAzKgpvnBvFeTFbA(delegate
			{
				IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
				for (int i = 0; i < values.Count; i++)
				{
					bwqFGHEbmbGjXBYvOLHAteywSidGA(values[i], true);
					bwqFGHEbmbGjXBYvOLHAteywSidGA(values[i], false);
				}
			});
			YJFHygoJQuNPUOiHiJZQPEuoVTsL = new pMGFPAMXITZSyRhwggrNACqjyAhT(delegate
			{
				IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
				for (int i = 0; i < values.Count; i++)
				{
					VejdVTDtNToIpnZaytkYBmBTUysEA(values[i]);
				}
			});
			int[] keyboardKeyValues = Consts._keyboardKeyValues;
			int num = keyboardKeyValues.Length;
			for (int num2 = 0; num2 < num; num2++)
			{
				if (keyboardKeyValues[num2] > vpVQaWAGruDgwGMDsqbxGPACvyHGA)
				{
					vpVQaWAGruDgwGMDsqbxGPACvyHGA = keyboardKeyValues[num2];
				}
			}
			JjpTsmigjEcasfMWpQoXoWVBUFeBA = new int[vpVQaWAGruDgwGMDsqbxGPACvyHGA + 1];
			ArrayTools.Fill(JjpTsmigjEcasfMWpQoXoWVBUFeBA, -1);
			for (int num3 = 0; num3 < num; num3++)
			{
				JjpTsmigjEcasfMWpQoXoWVBUFeBA[keyboardKeyValues[num3]] = num3;
			}
			ZpvjquEjWpLAQrNFxuFWNlDEPgFC = P_1;
			if (LocalizationManager.isEnabled && LocalizationManager.autoPrefetch)
			{
				((goyuORzVCSsvhefHsgPEBCMfboVoA)CtZeKXdlXlhtAlGxcsLbEKatriKJ).Localize();
			}
			if (GlyphManager.isEnabled && GlyphManager.autoPrefetch)
			{
				((IPrefetch)YJFHygoJQuNPUOiHiJZQPEuoVTsL).Prefetch();
			}
			yAFKgfmSqcdzYvwLywJEIeWPEynEA();
		}

		private Keyboard(int P_0, InputSource P_1, string P_2, string P_3, HardwareControllerMap_Game P_4, int P_5, Extension P_6, ControllerDataUpdater P_7)
			: base(P_0, P_1, P_2, P_2, P_3, ControllerType.Keyboard, Consts.hardwareTypeGuid_universalKeyboard, P_5, null, P_4, P_6, P_7)
		{
			MGKkaNhGkMNpOQBxomTLvGUQUHhB = this;
		}

		public bool GetKey(KeyCode keyCode)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			if ((uint)keyCode > (uint)vpVQaWAGruDgwGMDsqbxGPACvyHGA)
			{
				return false;
			}
			int num = JjpTsmigjEcasfMWpQoXoWVBUFeBA[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].value;
		}

		public bool GetKeyDown(KeyCode keyCode)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			if ((uint)keyCode > (uint)vpVQaWAGruDgwGMDsqbxGPACvyHGA)
			{
				return false;
			}
			int num = JjpTsmigjEcasfMWpQoXoWVBUFeBA[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].justPressed;
		}

		public bool GetKeyUp(KeyCode keyCode)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			if ((uint)keyCode > (uint)vpVQaWAGruDgwGMDsqbxGPACvyHGA)
			{
				return false;
			}
			int num = JjpTsmigjEcasfMWpQoXoWVBUFeBA[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].justReleased;
		}

		public bool GetKeyDoublePressHold(KeyCode keyCode, float speed)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			if ((uint)keyCode > (uint)vpVQaWAGruDgwGMDsqbxGPACvyHGA)
			{
				return false;
			}
			int num = JjpTsmigjEcasfMWpQoXoWVBUFeBA[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].DoublePressedAndHeld(speed);
		}

		public bool GetKeyDoublePressHold(KeyCode keyCode)
		{
			if ((uint)keyCode > (uint)vpVQaWAGruDgwGMDsqbxGPACvyHGA)
			{
				return false;
			}
			int num = JjpTsmigjEcasfMWpQoXoWVBUFeBA[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].DoublePressedAndHeld(0f);
		}

		public bool GetKeyDoublePressDown(KeyCode keyCode, float speed)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			if ((uint)keyCode > (uint)vpVQaWAGruDgwGMDsqbxGPACvyHGA)
			{
				return false;
			}
			int num = JjpTsmigjEcasfMWpQoXoWVBUFeBA[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].JustDoublePressed(speed);
		}

		public bool GetKeyDoublePressDown(KeyCode keyCode)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			if ((uint)keyCode > (uint)vpVQaWAGruDgwGMDsqbxGPACvyHGA)
			{
				return false;
			}
			int num = JjpTsmigjEcasfMWpQoXoWVBUFeBA[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].JustDoublePressed(0f);
		}

		public bool GetKeyPrev(KeyCode keyCode)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			if ((uint)keyCode > (uint)vpVQaWAGruDgwGMDsqbxGPACvyHGA)
			{
				return false;
			}
			int num = JjpTsmigjEcasfMWpQoXoWVBUFeBA[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].valuePrev;
		}

		public double GetKeyTimePressed(KeyCode keyCode)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0.0;
			}
			if ((uint)keyCode > (uint)vpVQaWAGruDgwGMDsqbxGPACvyHGA)
			{
				return 0.0;
			}
			int num = JjpTsmigjEcasfMWpQoXoWVBUFeBA[(int)keyCode];
			if (num < 0)
			{
				return 0.0;
			}
			return buttons[num].timePressed;
		}

		public double GetKeyTimeUnpressed(KeyCode keyCode)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0.0;
			}
			if ((uint)keyCode > (uint)vpVQaWAGruDgwGMDsqbxGPACvyHGA)
			{
				return 0.0;
			}
			int num = JjpTsmigjEcasfMWpQoXoWVBUFeBA[(int)keyCode];
			if (num < 0)
			{
				return 0.0;
			}
			return buttons[num].timeUnpressed;
		}

		public bool GetModifierKey(ModifierKey key)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			if (!yNhjiAycCeCEnjDXjhcfdSWCdqndB(out var button, out var button2, key))
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			if (!yNhjiAycCeCEnjDXjhcfdSWCdqndB(out var button, out var button2, key))
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			if (!yNhjiAycCeCEnjDXjhcfdSWCdqndB(out var button, out var button2, key))
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			if (!yNhjiAycCeCEnjDXjhcfdSWCdqndB(out var button, out var button2, key))
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0.0;
			}
			if (!yNhjiAycCeCEnjDXjhcfdSWCdqndB(out var button, out var button2, key))
			{
				return 0.0;
			}
			return MathTools.Max(button.timePressed, button2.timePressed);
		}

		public double GetModifierKeyTimeUnpressed(ModifierKey key)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0.0;
			}
			if (!yNhjiAycCeCEnjDXjhcfdSWCdqndB(out var button, out var button2, key))
			{
				return 0.0;
			}
			return MathTools.Min(button.timeUnpressed, button2.timeUnpressed);
		}

		public KeyCode GetKeyCodeByButtonIndex(int buttonIndex)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return KeyCode.None;
			}
			return LhkAfSLSnBssWNiYUltBQGrSsLMk(GetKeyboardKeyCodeByButtonIndex(buttonIndex));
		}

		public KeyCode GetKeyCodeById(int elementIdentifierId)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return KeyCode.None;
			}
			return GetKeyCodeByButtonIndex(GetButtonIndexById(elementIdentifierId));
		}

		public int GetButtonIndexByKeyCode(KeyCode keyCode)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return -1;
			}
			if ((uint)keyCode > (uint)vpVQaWAGruDgwGMDsqbxGPACvyHGA)
			{
				return -1;
			}
			return JjpTsmigjEcasfMWpQoXoWVBUFeBA[(int)keyCode];
		}

		public ControllerElementIdentifier GetElementIdentifierByKeyCode(KeyCode keyCode)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return null;
			}
			if ((uint)keyCode > (uint)vpVQaWAGruDgwGMDsqbxGPACvyHGA)
			{
				return null;
			}
			int num = JjpTsmigjEcasfMWpQoXoWVBUFeBA[(int)keyCode];
			if (num < 0)
			{
				return null;
			}
			return UzVdrXbKoYScsNhLYrSoTUeynXDBb.buttonElementIdentifiers_cache[num];
		}

		public ControllerPollingInfo PollForFirstKey()
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
			}
			int count = Consts.keyboardKeyValues.Count;
			for (int i = 0; i < count; i++)
			{
				KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[i];
				if (GetKey(keyCode))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, GetKeyName(keyCode), UzVdrXbKoYScsNhLYrSoTUeynXDBb.buttonElementIdentifierIds[i], keyCode);
				}
			}
			return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
		}

		[IteratorStateMachine(typeof(zOCeJieUTJVoaxNUhwDvwDMezAPB))]
		public IEnumerable<ControllerPollingInfo> PollForAllKeys()
		{
			return new zOCeJieUTJVoaxNUhwDvwDMezAPB(-2)
			{
				SjEKFWZwWEbUiWLXPJPRanWdnhCi = this
			};
		}

		[IteratorStateMachine(typeof(UExvUmdAIQjPRdcVFqULUfgsTqJtA))]
		public IEnumerable<ControllerPollingInfo> PollForAllKeysDown()
		{
			return new UExvUmdAIQjPRdcVFqULUfgsTqJtA(-2)
			{
				kqeYrYmjEuJUMCfgYfyfuWztjXfT = this
			};
		}

		public ControllerPollingInfo PollForFirstKeyDown()
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
			}
			int count = Consts.keyboardKeyValues.Count;
			for (int i = 0; i < count; i++)
			{
				KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[i];
				if (GetKeyDown(keyCode))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, GetKeyName(keyCode), UzVdrXbKoYScsNhLYrSoTUeynXDBb.buttonElementIdentifierIds[i], keyCode);
				}
			}
			return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
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
			case KeyCode.RightMeta:
			case KeyCode.LeftMeta:
				return true;
			default:
				return false;
			}
		}

		internal static bool BPHzoOBpYZkOIeTkKitxeOgKAqHjA(KeyboardKeyCode P_0)
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
			case KeyCode.RightMeta:
			case KeyCode.LeftMeta:
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
			return key switch
			{
				KeyCode.LeftControl => ModifierKeyFlags.LeftControl, 
				KeyCode.RightControl => ModifierKeyFlags.RightControl, 
				KeyCode.LeftAlt => ModifierKeyFlags.LeftAlt, 
				KeyCode.RightAlt => ModifierKeyFlags.RightAlt, 
				KeyCode.LeftShift => ModifierKeyFlags.LeftShift, 
				KeyCode.RightShift => ModifierKeyFlags.RightShift, 
				KeyCode.LeftMeta => ModifierKeyFlags.LeftCommand, 
				KeyCode.RightMeta => ModifierKeyFlags.RightCommand, 
				_ => ModifierKeyFlags.None, 
			};
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
			case KeyCode.LeftMeta:
				if ((flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
				{
					return true;
				}
				return false;
			case KeyCode.RightMeta:
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
				return KeyCode.LeftMeta;
			}
			if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
			{
				return KeyCode.RightMeta;
			}
			return KeyCode.None;
		}

		public static ModifierKeyFlags ModifierKeyToModifierKeyFlags(ModifierKey key)
		{
			return key switch
			{
				ModifierKey.None => ModifierKeyFlags.None, 
				ModifierKey.Control => ModifierKeyFlags.LeftControl | ModifierKeyFlags.RightControl, 
				ModifierKey.Alt => ModifierKeyFlags.LeftAlt | ModifierKeyFlags.RightAlt, 
				ModifierKey.Shift => ModifierKeyFlags.LeftShift | ModifierKeyFlags.RightShift, 
				ModifierKey.Command => ModifierKeyFlags.LeftCommand | ModifierKeyFlags.RightCommand, 
				_ => ModifierKeyFlags.None, 
			};
		}

		public static string GetKeyName(KeyCode key)
		{
			if (MGKkaNhGkMNpOQBxomTLvGUQUHhB == null)
			{
				return string.Empty;
			}
			int buttonIndex = MGKkaNhGkMNpOQBxomTLvGUQUHhB.GetButtonIndex(FolpKRVFiNrERNcjilyyzYEBpLKl(key));
			if (buttonIndex < 0)
			{
				return string.Empty;
			}
			return MGKkaNhGkMNpOQBxomTLvGUQUHhB.ButtonElementIdentifiers[buttonIndex].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
			if (MGKkaNhGkMNpOQBxomTLvGUQUHhB == null)
			{
				return string.Empty;
			}
			return MGKkaNhGkMNpOQBxomTLvGUQUHhB.bwqFGHEbmbGjXBYvOLHAteywSidGA(modifierKey, false);
		}

		public static string GetModifierKeyName(ModifierKey modifierKey, bool getShortName)
		{
			if (MGKkaNhGkMNpOQBxomTLvGUQUHhB == null)
			{
				return string.Empty;
			}
			return MGKkaNhGkMNpOQBxomTLvGUQUHhB.bwqFGHEbmbGjXBYvOLHAteywSidGA(modifierKey, getShortName);
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
			if (MGKkaNhGkMNpOQBxomTLvGUQUHhB == null)
			{
				return null;
			}
			return MGKkaNhGkMNpOQBxomTLvGUQUHhB.VejdVTDtNToIpnZaytkYBmBTUysEA(modifierKey);
		}

		internal static string NdAATAVzzVpvhgjRmtaFjImFmPAr(ModifierKey P_0)
		{
			if (MGKkaNhGkMNpOQBxomTLvGUQUHhB == null)
			{
				return string.Empty;
			}
			return MGKkaNhGkMNpOQBxomTLvGUQUHhB.DXghFdgLotNMpFleMCczVhVabcxV(P_0);
		}

		internal static KeyboardKeyCode FolpKRVFiNrERNcjilyyzYEBpLKl(KeyCode P_0)
		{
			return (KeyboardKeyCode)P_0;
		}

		internal static KeyCode LhkAfSLSnBssWNiYUltBQGrSsLMk(KeyboardKeyCode P_0)
		{
			return (KeyCode)P_0;
		}

		internal static ModifierKeyFlags AKOLpoAOCeBVrFtFxJdVFHIbleKcA(ModifierKeyFlags P_0)
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

		internal static int wYlrynKQMRqxFeRkuUJhciBnXVbf(ModifierKeyFlags P_0)
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
			return oIqabFlLiyHHUiwHnDekLAiTFVRC[buttonIndex];
		}

		internal static int UAQsBBzzhIgWFeszStLDbUQsAKfN(KeyboardKeyCode P_0)
		{
			int buttonIndex = MGKkaNhGkMNpOQBxomTLvGUQUHhB.GetButtonIndex(P_0);
			if (buttonIndex < 0)
			{
				return -1;
			}
			return MGKkaNhGkMNpOQBxomTLvGUQUHhB.ButtonElementIdentifiers[buttonIndex].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid;
		}

		internal static void NdOuanZOdKWfFCmxswwYgmFhjWAj(ref int P_0, ref KeyCode P_1)
		{
			if (P_1 != KeyCode.None)
			{
				P_0 = UAQsBBzzhIgWFeszStLDbUQsAKfN(FolpKRVFiNrERNcjilyyzYEBpLKl(P_1));
			}
			else
			{
				P_1 = ReInput.VeAmGFtEIHUuquEZXjxbJYdKKrEb.DgfFcsFEypGvKCatIhkeSdaWtzwHc.GetKeyCodeById(P_0);
			}
		}

		internal void rCqkJKSSnRfhlGsKADteKmItyKWJ(UpdateLoopType P_0)
		{
			ZpvjquEjWpLAQrNFxuFWNlDEPgFC.UpdateInputData(ucqtfsuOTseRsybfPGjEFawPmfNK);
			base.TphwDqkAytPBkZdmXYWPheGltdaf(P_0);
			tDYgrmajoZGcrRCwTAYTwwnAdVRo();
		}

		internal void KvoFcjqdgLeXYvFnGgyQadAHjIRjb(UpdateLoopType P_0)
		{
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape].wwiDNeLfkwfiCXIMYvGOWvdxgzbD(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape, ucqtfsuOTseRsybfPGjEFawPmfNK);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu].wwiDNeLfkwfiCXIMYvGOWvdxgzbD(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu, ucqtfsuOTseRsybfPGjEFawPmfNK);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_F2].wwiDNeLfkwfiCXIMYvGOWvdxgzbD(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_F2, ucqtfsuOTseRsybfPGjEFawPmfNK);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow].wwiDNeLfkwfiCXIMYvGOWvdxgzbD(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow, ucqtfsuOTseRsybfPGjEFawPmfNK);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow].wwiDNeLfkwfiCXIMYvGOWvdxgzbD(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow, ucqtfsuOTseRsybfPGjEFawPmfNK);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow].wwiDNeLfkwfiCXIMYvGOWvdxgzbD(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow, ucqtfsuOTseRsybfPGjEFawPmfNK);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow].wwiDNeLfkwfiCXIMYvGOWvdxgzbD(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow, ucqtfsuOTseRsybfPGjEFawPmfNK);
		}

		internal bool bNHmNhlnQOljIiQHdrQoCDkahsBG(KeyboardKeyCode P_0)
		{
			if ((uint)P_0 > (uint)vpVQaWAGruDgwGMDsqbxGPACvyHGA)
			{
				return false;
			}
			int num = JjpTsmigjEcasfMWpQoXoWVBUFeBA[(int)P_0];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].value;
		}

		internal bool AGopfLUOGxZuNhoaAhALeRjLLUfWA(KeyboardKeyCode P_0)
		{
			if ((uint)P_0 > (uint)vpVQaWAGruDgwGMDsqbxGPACvyHGA)
			{
				return false;
			}
			int num = JjpTsmigjEcasfMWpQoXoWVBUFeBA[(int)P_0];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].valuePrev;
		}

		internal bool nRIufaGBUegfLaPgCqzaLKRqdDMCA(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (!bNHmNhlnQOljIiQHdrQoCDkahsBG(P_0))
			{
				return false;
			}
			if (P_1 == ModifierKeyFlags.None)
			{
				return true;
			}
			if ((P_1 & mPzkEtUknSBDZKdgKArzTxCDlPCk) != P_1)
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

		internal bool PMSEmNiQmIqagjmAbAXQXTFXFlJM(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (bNHmNhlnQOljIiQHdrQoCDkahsBG(P_0))
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
			if ((uint)keyCode > (uint)vpVQaWAGruDgwGMDsqbxGPACvyHGA)
			{
				return -1;
			}
			return JjpTsmigjEcasfMWpQoXoWVBUFeBA[(int)keyCode];
		}

		[CustomObfuscation(rename = false)]
		internal void BakeMap(ControllerMap controllerMap)
		{
			if (controllerMap != null)
			{
				IList<ActionElementMap> list = controllerMap.XJOdguxXwMRhhVigJirOJaRIWSEt;
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					XxMvlVzqErvGSYjarMeZYpjHprtT(controllerMap, list[i]);
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal void BakeActionElementMap(ControllerMap controllerMap, ActionElementMap map)
		{
			map?.STLLClZycMGvQuJnbJckqZikooUE(controllerMap);
		}

		internal void OaMVudoFDnjwAariArqgiuYhZCFV()
		{
			base.xbzMqJvVogJAviEMRocpklZVZryW();
			NNzviPyBtqbOPkijONJnfOEHKIgtb = ModifierKeyFlags.None;
			mPzkEtUknSBDZKdgKArzTxCDlPCk = ModifierKeyFlags.None;
		}

		internal bool PAUPCpbYSeUHRSOKgNDRvrQYAYgf(bool P_0)
		{
			if (!base.SXQqxQnpROfgArPviygPWFsoFYZS(P_0))
			{
				return false;
			}
			if (ZpvjquEjWpLAQrNFxuFWNlDEPgFC is IGetSetEnabled)
			{
				(ZpvjquEjWpLAQrNFxuFWNlDEPgFC as IGetSetEnabled).enabled = P_0;
			}
			return true;
		}

		private bool yNhjiAycCeCEnjDXjhcfdSWCdqndB(out Button P_0, out Button P_1, ModifierKey P_2)
		{
			P_0 = null;
			P_1 = null;
			switch (P_2)
			{
			case ModifierKey.None:
				return false;
			case ModifierKey.Control:
				P_0 = buttons[JjpTsmigjEcasfMWpQoXoWVBUFeBA[306]];
				P_1 = buttons[JjpTsmigjEcasfMWpQoXoWVBUFeBA[305]];
				return true;
			case ModifierKey.Alt:
				P_0 = buttons[JjpTsmigjEcasfMWpQoXoWVBUFeBA[308]];
				P_1 = buttons[JjpTsmigjEcasfMWpQoXoWVBUFeBA[307]];
				return true;
			case ModifierKey.Command:
				P_0 = buttons[JjpTsmigjEcasfMWpQoXoWVBUFeBA[310]];
				P_1 = buttons[JjpTsmigjEcasfMWpQoXoWVBUFeBA[309]];
				return true;
			case ModifierKey.Shift:
				P_0 = buttons[JjpTsmigjEcasfMWpQoXoWVBUFeBA[304]];
				P_1 = buttons[JjpTsmigjEcasfMWpQoXoWVBUFeBA[303]];
				return true;
			default:
				return false;
			}
		}

		private void tDYgrmajoZGcrRCwTAYTwwnAdVRo()
		{
			ModifierKeyFlags modifierKeyFlags = ModifierKeyFlags.None;
			if (buttons[JjpTsmigjEcasfMWpQoXoWVBUFeBA[306]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftControl;
			}
			if (buttons[JjpTsmigjEcasfMWpQoXoWVBUFeBA[305]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightControl;
			}
			if (buttons[JjpTsmigjEcasfMWpQoXoWVBUFeBA[310]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftCommand;
			}
			if (buttons[JjpTsmigjEcasfMWpQoXoWVBUFeBA[309]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightCommand;
			}
			if (buttons[JjpTsmigjEcasfMWpQoXoWVBUFeBA[308]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftAlt;
			}
			if (buttons[JjpTsmigjEcasfMWpQoXoWVBUFeBA[307]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightAlt;
			}
			if (buttons[JjpTsmigjEcasfMWpQoXoWVBUFeBA[304]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftShift;
			}
			if (buttons[JjpTsmigjEcasfMWpQoXoWVBUFeBA[303]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightShift;
			}
			NNzviPyBtqbOPkijONJnfOEHKIgtb = modifierKeyFlags;
			mPzkEtUknSBDZKdgKArzTxCDlPCk = AKOLpoAOCeBVrFtFxJdVFHIbleKcA(modifierKeyFlags);
		}

		private string bwqFGHEbmbGjXBYvOLHAteywSidGA(ModifierKey P_0, bool P_1)
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
			if (!OvjQLSRfkXFvKehubjKqlKXROcFaA.TryGetValue((int)P_0, out var value))
			{
				return result;
			}
			string result2;
			if (P_1)
			{
				if (value.cJXxBDaJGFTRPTfAVmcaxPBnWqzR != null && CwHeZLXzMRhLrRsscRgafQLBeqfI(value.cJXxBDaJGFTRPTfAVmcaxPBnWqzR, modifierKeyInfo.shortKey, modifierKeyInfo.shortName, UzVdrXbKoYScsNhLYrSoTUeynXDBb.deviceLocalizationInfo, out result2))
				{
					return result2;
				}
				if (value.qIbvTGdBwifRemEuRuQyidzQApNW != null && CwHeZLXzMRhLrRsscRgafQLBeqfI(value.qIbvTGdBwifRemEuRuQyidzQApNW, modifierKeyInfo.longKey, modifierKeyInfo.longName, UzVdrXbKoYScsNhLYrSoTUeynXDBb.deviceLocalizationInfo, out result2))
				{
					return result2;
				}
				return result;
			}
			if (value.qIbvTGdBwifRemEuRuQyidzQApNW == null)
			{
				return result;
			}
			CwHeZLXzMRhLrRsscRgafQLBeqfI(value.qIbvTGdBwifRemEuRuQyidzQApNW, modifierKeyInfo.longKey, modifierKeyInfo.longName, UzVdrXbKoYScsNhLYrSoTUeynXDBb.deviceLocalizationInfo, out result2);
			return result2;
		}

		private static bool CwHeZLXzMRhLrRsscRgafQLBeqfI(vaYdlqCIibKfFdpYixvQIHAgosGzb P_0, string P_1, string P_2, DeviceLocalizationInfo P_3, out string P_4)
		{
			LocalizationManager.GetAndUpdateLocalizedStringResultFlags getAndUpdateLocalizedStringResultFlags = dXDhgciBpvPiLRoZXBpiBCxofOAPA.UyOlPLAOODeAkJjiqbFijsgMcfdkA(P_0.dTLJvTWzdmiebFWZPDhLyaKSDoVk, P_1, "controller", P_2, P_3, eXRjOdORfaNOqMSguWnRpnOIZGBy.Keyboard, -1, AxisRange.Full, -1, out P_4);
			if ((getAndUpdateLocalizedStringResultFlags & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
			{
				P_0.ERQekbVDCbRovKpDXfWQBjevroSnA = (getAndUpdateLocalizedStringResultFlags & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.JustLocalized) != 0;
			}
			return P_0.ERQekbVDCbRovKpDXfWQBjevroSnA;
		}

		private object VejdVTDtNToIpnZaytkYBmBTUysEA(ModifierKey P_0)
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
			if (!KcjwDJMfavJddGyaiQzCNJQnnBsr.TryGetValue((int)P_0, out var value))
			{
				return null;
			}
			if (ecbZBYzFFSEpSPVyvGiukKMuHaBZ(value, modifierKeyInfo.longKey, UzVdrXbKoYScsNhLYrSoTUeynXDBb.deviceLocalizationInfo, out var result))
			{
				return result;
			}
			return null;
		}

		private string DXghFdgLotNMpFleMCczVhVabcxV(ModifierKey P_0)
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
			if (!KcjwDJMfavJddGyaiQzCNJQnnBsr.TryGetValue((int)P_0, out var value))
			{
				return null;
			}
			if (kkZKlDlfTEVlfEbNZqNNazogBNkr(value, modifierKeyInfo.longKey, UzVdrXbKoYScsNhLYrSoTUeynXDBb.deviceLocalizationInfo, out var result))
			{
				return result;
			}
			return null;
		}

		private static bool ecbZBYzFFSEpSPVyvGiukKMuHaBZ(YMUVaWRfzbXxSEfyDTzBjzbdonFs P_0, string P_1, DeviceLocalizationInfo P_2, out object P_3)
		{
			GlyphManager.GetAndUpdateGlyphResultFlags getAndUpdateGlyphResultFlags = FLTutQdraUqptwGNJUGqpFFtDAEy.qyAZFylUpdGRHbgtLQIAfvzcAJtE(P_0.aZMexCasesZGiTJADOwuAhjaUKvJB, P_1, "controller", P_2, eXRjOdORfaNOqMSguWnRpnOIZGBy.Keyboard, -1, AxisRange.Full, -1, out P_3);
			if ((getAndUpdateGlyphResultFlags & GlyphManager.GetAndUpdateGlyphResultFlags.Changed) != GlyphManager.GetAndUpdateGlyphResultFlags.None)
			{
				P_0.IRjcCHkEGYxhHwxiXHkwSjdDoWaA = (getAndUpdateGlyphResultFlags & GlyphManager.GetAndUpdateGlyphResultFlags.JustGot) != 0;
			}
			return P_0.IRjcCHkEGYxhHwxiXHkwSjdDoWaA;
		}

		private static bool kkZKlDlfTEVlfEbNZqNNazogBNkr(YMUVaWRfzbXxSEfyDTzBjzbdonFs P_0, string P_1, DeviceLocalizationInfo P_2, out string P_3)
		{
			object obj;
			bool result = ecbZBYzFFSEpSPVyvGiukKMuHaBZ(P_0, P_1, P_2, out obj);
			P_3 = P_0.aZMexCasesZGiTJADOwuAhjaUKvJB.cachedKey;
			return result;
		}

		[CompilerGenerated]
		private void SZdFMGhyPvnPxDneFEaSCobJXBzCA()
		{
			IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
			for (int i = 0; i < values.Count; i++)
			{
				bwqFGHEbmbGjXBYvOLHAteywSidGA(values[i], true);
				bwqFGHEbmbGjXBYvOLHAteywSidGA(values[i], false);
			}
		}

		[CompilerGenerated]
		private void PfPPjrYWyRAhbVUFNLHYnocqjTYE()
		{
			IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
			for (int i = 0; i < values.Count; i++)
			{
				VejdVTDtNToIpnZaytkYBmBTUysEA(values[i]);
			}
		}
	}
}
