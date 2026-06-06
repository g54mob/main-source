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

		private class gCsjWiKOERwxiWpilldvYhZaDSpO
		{
			public readonly kdznJtZhtbJIiVcKMIRImdXTAotF voNNAzxVFthyFbUwSVcLGASuQEmA;

			public readonly kdznJtZhtbJIiVcKMIRImdXTAotF jaCshNgspacFNSBoknRcTYanANsO;

			public gCsjWiKOERwxiWpilldvYhZaDSpO(string P_0, string P_1)
			{
				if (!string.IsNullOrEmpty(P_0))
				{
					voNNAzxVFthyFbUwSVcLGASuQEmA = new kdznJtZhtbJIiVcKMIRImdXTAotF(new LocalizedString());
				}
				if (!string.IsNullOrEmpty(P_1))
				{
					jaCshNgspacFNSBoknRcTYanANsO = new kdznJtZhtbJIiVcKMIRImdXTAotF(new LocalizedString());
				}
			}
		}

		private sealed class kdznJtZhtbJIiVcKMIRImdXTAotF
		{
			public readonly LocalizedString qOkPZUXNiapGEdHHulmVNdXxFnkbA;

			public bool FrlyzqQnJnYSQigFsrZGMSpCWRpL;

			public kdznJtZhtbJIiVcKMIRImdXTAotF(LocalizedString P_0)
			{
				qOkPZUXNiapGEdHHulmVNdXxFnkbA = P_0;
			}
		}

		private sealed class LVneJAUcffJerycNaEDFOHcWZKwi
		{
			public readonly KeyedGlyph lEdryFzxomycBjYbsHfkKesvyoGI;

			public bool FReXmLfjVUXRWYjnTakudByAbGzdb;

			public LVneJAUcffJerycNaEDFOHcWZKwi(KeyedGlyph P_0)
			{
				lEdryFzxomycBjYbsHfkKesvyoGI = P_0;
			}
		}

		private sealed class cNfWuMvARNSnXTEFEVDLXRUPeJno : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int zhYyLetOnDfIjBnwOsGjdrUxoaqyA;

			private ControllerPollingInfo zaOLyeLfevSoeHgspVwGPJszNtsl;

			private int aFAGCHAJokHIkfhmfzDRczwWCZUgb;

			public Keyboard XTdeADQLVUCNFotFeCgHdPDIMVdJA;

			private int dCVoCQJTdzwdTgciUONpvYOQkpyO;

			private int WSIuurDuPuLATDExibkEkzqeolRLA;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return zaOLyeLfevSoeHgspVwGPJszNtsl;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return zaOLyeLfevSoeHgspVwGPJszNtsl;
				}
			}

			[DebuggerHidden]
			public cNfWuMvARNSnXTEFEVDLXRUPeJno(int P_0)
			{
				zhYyLetOnDfIjBnwOsGjdrUxoaqyA = P_0;
				aFAGCHAJokHIkfhmfzDRczwWCZUgb = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				zhYyLetOnDfIjBnwOsGjdrUxoaqyA = -2;
			}

			private bool MoveNext()
			{
				int num = zhYyLetOnDfIjBnwOsGjdrUxoaqyA;
				Keyboard xTdeADQLVUCNFotFeCgHdPDIMVdJA = XTdeADQLVUCNFotFeCgHdPDIMVdJA;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					zhYyLetOnDfIjBnwOsGjdrUxoaqyA = -1;
					goto IL_00bf;
				}
				zhYyLetOnDfIjBnwOsGjdrUxoaqyA = -1;
				if (ReInput._id != xTdeADQLVUCNFotFeCgHdPDIMVdJA.BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(xTdeADQLVUCNFotFeCgHdPDIMVdJA.BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return false;
				}
				dCVoCQJTdzwdTgciUONpvYOQkpyO = Consts.keyboardKeyValues.Count;
				WSIuurDuPuLATDExibkEkzqeolRLA = 0;
				goto IL_00cf;
				IL_00cf:
				if (WSIuurDuPuLATDExibkEkzqeolRLA < dCVoCQJTdzwdTgciUONpvYOQkpyO)
				{
					KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[WSIuurDuPuLATDExibkEkzqeolRLA];
					if (xTdeADQLVUCNFotFeCgHdPDIMVdJA.GetKey(keyCode))
					{
						zaOLyeLfevSoeHgspVwGPJszNtsl = new ControllerPollingInfo(true, -1, xTdeADQLVUCNFotFeCgHdPDIMVdJA.id, xTdeADQLVUCNFotFeCgHdPDIMVdJA._name, xTdeADQLVUCNFotFeCgHdPDIMVdJA._type, ControllerElementType.Button, WSIuurDuPuLATDExibkEkzqeolRLA, Pole.Positive, GetKeyName(keyCode), xTdeADQLVUCNFotFeCgHdPDIMVdJA.JEexZOPzSUUjNTHjvxywblgJdFqE.buttonElementIdentifierIds[WSIuurDuPuLATDExibkEkzqeolRLA], keyCode);
						zhYyLetOnDfIjBnwOsGjdrUxoaqyA = 1;
						return true;
					}
					goto IL_00bf;
				}
				return false;
				IL_00bf:
				WSIuurDuPuLATDExibkEkzqeolRLA++;
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
				cNfWuMvARNSnXTEFEVDLXRUPeJno cNfWuMvARNSnXTEFEVDLXRUPeJno2;
				if (zhYyLetOnDfIjBnwOsGjdrUxoaqyA == -2 && aFAGCHAJokHIkfhmfzDRczwWCZUgb == Environment.CurrentManagedThreadId)
				{
					zhYyLetOnDfIjBnwOsGjdrUxoaqyA = 0;
					cNfWuMvARNSnXTEFEVDLXRUPeJno2 = this;
				}
				else
				{
					cNfWuMvARNSnXTEFEVDLXRUPeJno2 = new cNfWuMvARNSnXTEFEVDLXRUPeJno(0);
					cNfWuMvARNSnXTEFEVDLXRUPeJno2.XTdeADQLVUCNFotFeCgHdPDIMVdJA = XTdeADQLVUCNFotFeCgHdPDIMVdJA;
				}
				return cNfWuMvARNSnXTEFEVDLXRUPeJno2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class PXOEhNoRTQxaMARnqhVzMtMTIokc : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int tmTCUOfmjuaoZkSfaMAVZGqqnlDAA;

			private ControllerPollingInfo wXNEpgrPWUaLtiFRNCgpUDLRGLFQA;

			private int PeGknAcHUudVOeSbwnMaolQTSditA;

			public Keyboard tPIrLOtZqYjpFmmpYTdFHmWvxOMA;

			private int WfnpurKoRoFknobVuEMPjUiCxLru;

			private int JQNAtNIHgKgsNSiIxKEODRmvRkTb;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return wXNEpgrPWUaLtiFRNCgpUDLRGLFQA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return wXNEpgrPWUaLtiFRNCgpUDLRGLFQA;
				}
			}

			[DebuggerHidden]
			public PXOEhNoRTQxaMARnqhVzMtMTIokc(int P_0)
			{
				tmTCUOfmjuaoZkSfaMAVZGqqnlDAA = P_0;
				PeGknAcHUudVOeSbwnMaolQTSditA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				tmTCUOfmjuaoZkSfaMAVZGqqnlDAA = -2;
			}

			private bool MoveNext()
			{
				int num = tmTCUOfmjuaoZkSfaMAVZGqqnlDAA;
				Keyboard keyboard = tPIrLOtZqYjpFmmpYTdFHmWvxOMA;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					tmTCUOfmjuaoZkSfaMAVZGqqnlDAA = -1;
					goto IL_00bf;
				}
				tmTCUOfmjuaoZkSfaMAVZGqqnlDAA = -1;
				if (ReInput._id != keyboard.BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(keyboard.BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return false;
				}
				WfnpurKoRoFknobVuEMPjUiCxLru = Consts.keyboardKeyValues.Count;
				JQNAtNIHgKgsNSiIxKEODRmvRkTb = 0;
				goto IL_00cf;
				IL_00cf:
				if (JQNAtNIHgKgsNSiIxKEODRmvRkTb < WfnpurKoRoFknobVuEMPjUiCxLru)
				{
					KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[JQNAtNIHgKgsNSiIxKEODRmvRkTb];
					if (keyboard.GetKeyDown(keyCode))
					{
						wXNEpgrPWUaLtiFRNCgpUDLRGLFQA = new ControllerPollingInfo(true, -1, keyboard.id, keyboard._name, keyboard._type, ControllerElementType.Button, JQNAtNIHgKgsNSiIxKEODRmvRkTb, Pole.Positive, GetKeyName(keyCode), keyboard.JEexZOPzSUUjNTHjvxywblgJdFqE.buttonElementIdentifierIds[JQNAtNIHgKgsNSiIxKEODRmvRkTb], keyCode);
						tmTCUOfmjuaoZkSfaMAVZGqqnlDAA = 1;
						return true;
					}
					goto IL_00bf;
				}
				return false;
				IL_00bf:
				JQNAtNIHgKgsNSiIxKEODRmvRkTb++;
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
				PXOEhNoRTQxaMARnqhVzMtMTIokc pXOEhNoRTQxaMARnqhVzMtMTIokc;
				if (tmTCUOfmjuaoZkSfaMAVZGqqnlDAA == -2 && PeGknAcHUudVOeSbwnMaolQTSditA == Environment.CurrentManagedThreadId)
				{
					tmTCUOfmjuaoZkSfaMAVZGqqnlDAA = 0;
					pXOEhNoRTQxaMARnqhVzMtMTIokc = this;
				}
				else
				{
					pXOEhNoRTQxaMARnqhVzMtMTIokc = new PXOEhNoRTQxaMARnqhVzMtMTIokc(0);
					pXOEhNoRTQxaMARnqhVzMtMTIokc.tPIrLOtZqYjpFmmpYTdFHmWvxOMA = tPIrLOtZqYjpFmmpYTdFHmWvxOMA;
				}
				return pXOEhNoRTQxaMARnqhVzMtMTIokc;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private const string jOMAvloMVQbOmGdLgjJdicFGkvtBc = " + ";

		private static Keyboard ZbpzktwHPIinKgAJJiTPOWLtggcHA;

		private static KeyboardKeyCode[] mjWZPxedefxGsoixYUWuvwSXaCjF;

		private static Guid JlTgdIZwTlKBDjJhHrbGlftrukoD;

		private readonly IUnifiedKeyboardSource QNGVnlPXanTpnTPVIBPXhqerAjifb;

		private ModifierKeyFlags UpMeGSfsswkmdQxdnabnfRAjiyZe;

		private ModifierKeyFlags roQciccFoQQlgrgwvjztCsBgiVpIA;

		private Func<KeyboardKeyCode, int> RSecaSxqORYlisQOkPsdkICNgAGD;

		private readonly int[] CzMuCtxilUIQTgWuCFqVnMIgfPZc;

		private readonly int kukenHBdoykUZejTXqGhoMVdgCiEA;

		private readonly oEKjTOxtumqnvVGrvGQjjCekBlgfb DOmhmMebMnbPrhZlLLJrgrhOLFluA;

		private readonly orzPQTDZxByPDnmaNCwVbdJOcdWe NymkMfbSFedmpgDtHqCWmftDbEHh;

		private Dictionary<int, gCsjWiKOERwxiWpilldvYhZaDSpO> KFDLzYBvjawdrRDGWXQDuMXPadNT;

		private Dictionary<int, LVneJAUcffJerycNaEDFOHcWZKwi> ItzWlzizrknrMSAZxEPZgIlZIFyn;

		private static KeyboardKeyCode[] nTVUkucCEgyhiQPcIccukGFsSrqw
		{
			get
			{
				if (mjWZPxedefxGsoixYUWuvwSXaCjF == null)
				{
					int[] keyboardKeyValues = Consts._keyboardKeyValues;
					int num = keyboardKeyValues.Length;
					mjWZPxedefxGsoixYUWuvwSXaCjF = new KeyboardKeyCode[num];
					for (int i = 0; i < num; i++)
					{
						mjWZPxedefxGsoixYUWuvwSXaCjF[i] = (KeyboardKeyCode)keyboardKeyValues[i];
					}
				}
				return mjWZPxedefxGsoixYUWuvwSXaCjF;
			}
		}

		private Dictionary<int, gCsjWiKOERwxiWpilldvYhZaDSpO> PIGTnLKefPiPlZWoWOxoxDSgqGsv
		{
			get
			{
				if (KFDLzYBvjawdrRDGWXQDuMXPadNT == null)
				{
					Rewired.Utils.Interfaces.IReadOnlyDictionary<int, ModifierKeyInfo> modifierKeyInfo = Consts.modifierKeyInfo;
					Dictionary<int, gCsjWiKOERwxiWpilldvYhZaDSpO> dictionary = new Dictionary<int, gCsjWiKOERwxiWpilldvYhZaDSpO>();
					foreach (KeyValuePair<int, ModifierKeyInfo> item in modifierKeyInfo)
					{
						if (item.Key != 0)
						{
							dictionary.Add(item.Key, new gCsjWiKOERwxiWpilldvYhZaDSpO(item.Value.shortKey, item.Value.longKey));
						}
					}
					KFDLzYBvjawdrRDGWXQDuMXPadNT = dictionary;
				}
				return KFDLzYBvjawdrRDGWXQDuMXPadNT;
			}
		}

		private Dictionary<int, LVneJAUcffJerycNaEDFOHcWZKwi> ZgAgyEFKhhULSgKwDpCMaQHIzxNu
		{
			get
			{
				if (ItzWlzizrknrMSAZxEPZgIlZIFyn == null)
				{
					Rewired.Utils.Interfaces.IReadOnlyDictionary<int, ModifierKeyInfo> modifierKeyInfo = Consts.modifierKeyInfo;
					Dictionary<int, LVneJAUcffJerycNaEDFOHcWZKwi> dictionary = new Dictionary<int, LVneJAUcffJerycNaEDFOHcWZKwi>();
					foreach (KeyValuePair<int, ModifierKeyInfo> item in modifierKeyInfo)
					{
						if (item.Key != 0)
						{
							LVneJAUcffJerycNaEDFOHcWZKwi value = new LVneJAUcffJerycNaEDFOHcWZKwi(new KeyedGlyph());
							dictionary.Add(item.Key, value);
						}
					}
					ItzWlzizrknrMSAZxEPZgIlZIFyn = dictionary;
				}
				return ItzWlzizrknrMSAZxEPZgIlZIFyn;
			}
		}

		Guid Controller.deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return Guid.Empty;
				}
				return JlTgdIZwTlKBDjJhHrbGlftrukoD;
			}
		}

		internal Keyboard(string P_0, IUnifiedKeyboardSource P_1)
			: this(0, P_1.inputSource, P_0, InputTools.FormatHardwareIdentifierString(P_0), P_1.hardwareMap, 132, P_1?.controllerExtension, new ControllerDataUpdater(P_1.inputSource, 0, 132, null))
		{
			JlTgdIZwTlKBDjJhHrbGlftrukoD = MiscTools.CreateGuidHashSHA1("[Universal Keyboard]");
			DOmhmMebMnbPrhZlLLJrgrhOLFluA = new oEKjTOxtumqnvVGrvGQjjCekBlgfb(delegate
			{
				IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
				for (int i = 0; i < values.Count; i++)
				{
					wlBKWADlfnVaysBtrcoSFMtTGGMY(values[i], true);
					wlBKWADlfnVaysBtrcoSFMtTGGMY(values[i], false);
				}
			});
			NymkMfbSFedmpgDtHqCWmftDbEHh = new orzPQTDZxByPDnmaNCwVbdJOcdWe(delegate
			{
				IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
				for (int i = 0; i < values.Count; i++)
				{
					QZWPeKwgORkOWrfsPKJULpYcHYJL(values[i]);
				}
			});
			int[] keyboardKeyValues = Consts._keyboardKeyValues;
			int num = keyboardKeyValues.Length;
			for (int num2 = 0; num2 < num; num2++)
			{
				if (keyboardKeyValues[num2] > kukenHBdoykUZejTXqGhoMVdgCiEA)
				{
					kukenHBdoykUZejTXqGhoMVdgCiEA = keyboardKeyValues[num2];
				}
			}
			CzMuCtxilUIQTgWuCFqVnMIgfPZc = new int[kukenHBdoykUZejTXqGhoMVdgCiEA + 1];
			ArrayTools.Fill(CzMuCtxilUIQTgWuCFqVnMIgfPZc, -1);
			for (int num3 = 0; num3 < num; num3++)
			{
				CzMuCtxilUIQTgWuCFqVnMIgfPZc[keyboardKeyValues[num3]] = num3;
			}
			QNGVnlPXanTpnTPVIBPXhqerAjifb = P_1;
			if (LocalizationManager.isEnabled && LocalizationManager.autoPrefetch)
			{
				((fuTAbCyJgOZBWWgBXmUSttFWWuoi)DOmhmMebMnbPrhZlLLJrgrhOLFluA).Localize();
			}
			if (GlyphManager.isEnabled && GlyphManager.autoPrefetch)
			{
				((IPrefetch)NymkMfbSFedmpgDtHqCWmftDbEHh).Prefetch();
			}
			jcuaGkxKxwRQhPfLTgjWpYLcOGCK();
		}

		private Keyboard(int P_0, InputSource P_1, string P_2, string P_3, HardwareControllerMap_Game P_4, int P_5, Extension P_6, ControllerDataUpdater P_7)
			: base(P_0, P_1, P_2, P_2, P_3, ControllerType.Keyboard, Consts.hardwareTypeGuid_universalKeyboard, P_5, null, P_4, P_6, P_7)
		{
			ZbpzktwHPIinKgAJJiTPOWLtggcHA = this;
		}

		public bool GetKey(KeyCode keyCode)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return false;
			}
			if ((uint)keyCode > (uint)kukenHBdoykUZejTXqGhoMVdgCiEA)
			{
				return false;
			}
			int num = CzMuCtxilUIQTgWuCFqVnMIgfPZc[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].value;
		}

		public bool GetKeyDown(KeyCode keyCode)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return false;
			}
			if ((uint)keyCode > (uint)kukenHBdoykUZejTXqGhoMVdgCiEA)
			{
				return false;
			}
			int num = CzMuCtxilUIQTgWuCFqVnMIgfPZc[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].justPressed;
		}

		public bool GetKeyUp(KeyCode keyCode)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return false;
			}
			if ((uint)keyCode > (uint)kukenHBdoykUZejTXqGhoMVdgCiEA)
			{
				return false;
			}
			int num = CzMuCtxilUIQTgWuCFqVnMIgfPZc[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].justReleased;
		}

		public bool GetKeyDoublePressHold(KeyCode keyCode, float speed)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return false;
			}
			if ((uint)keyCode > (uint)kukenHBdoykUZejTXqGhoMVdgCiEA)
			{
				return false;
			}
			int num = CzMuCtxilUIQTgWuCFqVnMIgfPZc[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].DoublePressedAndHeld(speed);
		}

		public bool GetKeyDoublePressHold(KeyCode keyCode)
		{
			if ((uint)keyCode > (uint)kukenHBdoykUZejTXqGhoMVdgCiEA)
			{
				return false;
			}
			int num = CzMuCtxilUIQTgWuCFqVnMIgfPZc[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].DoublePressedAndHeld(0f);
		}

		public bool GetKeyDoublePressDown(KeyCode keyCode, float speed)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return false;
			}
			if ((uint)keyCode > (uint)kukenHBdoykUZejTXqGhoMVdgCiEA)
			{
				return false;
			}
			int num = CzMuCtxilUIQTgWuCFqVnMIgfPZc[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].JustDoublePressed(speed);
		}

		public bool GetKeyDoublePressDown(KeyCode keyCode)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return false;
			}
			if ((uint)keyCode > (uint)kukenHBdoykUZejTXqGhoMVdgCiEA)
			{
				return false;
			}
			int num = CzMuCtxilUIQTgWuCFqVnMIgfPZc[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].JustDoublePressed(0f);
		}

		public bool GetKeyPrev(KeyCode keyCode)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return false;
			}
			if ((uint)keyCode > (uint)kukenHBdoykUZejTXqGhoMVdgCiEA)
			{
				return false;
			}
			int num = CzMuCtxilUIQTgWuCFqVnMIgfPZc[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].valuePrev;
		}

		public double GetKeyTimePressed(KeyCode keyCode)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return 0.0;
			}
			if ((uint)keyCode > (uint)kukenHBdoykUZejTXqGhoMVdgCiEA)
			{
				return 0.0;
			}
			int num = CzMuCtxilUIQTgWuCFqVnMIgfPZc[(int)keyCode];
			if (num < 0)
			{
				return 0.0;
			}
			return buttons[num].timePressed;
		}

		public double GetKeyTimeUnpressed(KeyCode keyCode)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return 0.0;
			}
			if ((uint)keyCode > (uint)kukenHBdoykUZejTXqGhoMVdgCiEA)
			{
				return 0.0;
			}
			int num = CzMuCtxilUIQTgWuCFqVnMIgfPZc[(int)keyCode];
			if (num < 0)
			{
				return 0.0;
			}
			return buttons[num].timeUnpressed;
		}

		public bool GetModifierKey(ModifierKey key)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return false;
			}
			if (!btEgdNtnHauNGhfJOPDtrqPKWfSk(out var button, out var button2, key))
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return false;
			}
			if (!btEgdNtnHauNGhfJOPDtrqPKWfSk(out var button, out var button2, key))
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return false;
			}
			if (!btEgdNtnHauNGhfJOPDtrqPKWfSk(out var button, out var button2, key))
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return false;
			}
			if (!btEgdNtnHauNGhfJOPDtrqPKWfSk(out var button, out var button2, key))
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return 0.0;
			}
			if (!btEgdNtnHauNGhfJOPDtrqPKWfSk(out var button, out var button2, key))
			{
				return 0.0;
			}
			return MathTools.Max(button.timePressed, button2.timePressed);
		}

		public double GetModifierKeyTimeUnpressed(ModifierKey key)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return 0.0;
			}
			if (!btEgdNtnHauNGhfJOPDtrqPKWfSk(out var button, out var button2, key))
			{
				return 0.0;
			}
			return MathTools.Min(button.timeUnpressed, button2.timeUnpressed);
		}

		public KeyCode GetKeyCodeByButtonIndex(int buttonIndex)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return KeyCode.None;
			}
			return EwBIUZKiwNBGxivIziALtbknsGpgA(GetKeyboardKeyCodeByButtonIndex(buttonIndex));
		}

		public KeyCode GetKeyCodeById(int elementIdentifierId)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return KeyCode.None;
			}
			return GetKeyCodeByButtonIndex(GetButtonIndexById(elementIdentifierId));
		}

		public int GetButtonIndexByKeyCode(KeyCode keyCode)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return -1;
			}
			if ((uint)keyCode > (uint)kukenHBdoykUZejTXqGhoMVdgCiEA)
			{
				return -1;
			}
			return CzMuCtxilUIQTgWuCFqVnMIgfPZc[(int)keyCode];
		}

		public ControllerElementIdentifier GetElementIdentifierByKeyCode(KeyCode keyCode)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return null;
			}
			if ((uint)keyCode > (uint)kukenHBdoykUZejTXqGhoMVdgCiEA)
			{
				return null;
			}
			int num = CzMuCtxilUIQTgWuCFqVnMIgfPZc[(int)keyCode];
			if (num < 0)
			{
				return null;
			}
			return JEexZOPzSUUjNTHjvxywblgJdFqE.buttonElementIdentifiers_cache[num];
		}

		public ControllerPollingInfo PollForFirstKey()
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
			}
			int count = Consts.keyboardKeyValues.Count;
			for (int i = 0; i < count; i++)
			{
				KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[i];
				if (GetKey(keyCode))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, GetKeyName(keyCode), JEexZOPzSUUjNTHjvxywblgJdFqE.buttonElementIdentifierIds[i], keyCode);
				}
			}
			return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
		}

		[IteratorStateMachine(typeof(cNfWuMvARNSnXTEFEVDLXRUPeJno))]
		public IEnumerable<ControllerPollingInfo> PollForAllKeys()
		{
			return new cNfWuMvARNSnXTEFEVDLXRUPeJno(-2)
			{
				XTdeADQLVUCNFotFeCgHdPDIMVdJA = this
			};
		}

		[IteratorStateMachine(typeof(PXOEhNoRTQxaMARnqhVzMtMTIokc))]
		public IEnumerable<ControllerPollingInfo> PollForAllKeysDown()
		{
			return new PXOEhNoRTQxaMARnqhVzMtMTIokc(-2)
			{
				tPIrLOtZqYjpFmmpYTdFHmWvxOMA = this
			};
		}

		public ControllerPollingInfo PollForFirstKeyDown()
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
			}
			int count = Consts.keyboardKeyValues.Count;
			for (int i = 0; i < count; i++)
			{
				KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[i];
				if (GetKeyDown(keyCode))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, GetKeyName(keyCode), JEexZOPzSUUjNTHjvxywblgJdFqE.buttonElementIdentifierIds[i], keyCode);
				}
			}
			return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
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

		internal static bool YoFsTSELTmwdKYqdbKbSJjvlMyoA(KeyboardKeyCode P_0)
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
			if (ZbpzktwHPIinKgAJJiTPOWLtggcHA == null)
			{
				return string.Empty;
			}
			int buttonIndex = ZbpzktwHPIinKgAJJiTPOWLtggcHA.GetButtonIndex(GqKWxMODjRKwgzCxHKHcWfJaWFzv(key));
			if (buttonIndex < 0)
			{
				return string.Empty;
			}
			return ZbpzktwHPIinKgAJJiTPOWLtggcHA.ButtonElementIdentifiers[buttonIndex].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
			if (ZbpzktwHPIinKgAJJiTPOWLtggcHA == null)
			{
				return string.Empty;
			}
			return ZbpzktwHPIinKgAJJiTPOWLtggcHA.wlBKWADlfnVaysBtrcoSFMtTGGMY(modifierKey, false);
		}

		public static string GetModifierKeyName(ModifierKey modifierKey, bool getShortName)
		{
			if (ZbpzktwHPIinKgAJJiTPOWLtggcHA == null)
			{
				return string.Empty;
			}
			return ZbpzktwHPIinKgAJJiTPOWLtggcHA.wlBKWADlfnVaysBtrcoSFMtTGGMY(modifierKey, getShortName);
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
			if (ZbpzktwHPIinKgAJJiTPOWLtggcHA == null)
			{
				return null;
			}
			return ZbpzktwHPIinKgAJJiTPOWLtggcHA.QZWPeKwgORkOWrfsPKJULpYcHYJL(modifierKey);
		}

		internal static string CcxPLVAHiJMJMMsVPTTXURhmxvzL(ModifierKey P_0)
		{
			if (ZbpzktwHPIinKgAJJiTPOWLtggcHA == null)
			{
				return string.Empty;
			}
			return ZbpzktwHPIinKgAJJiTPOWLtggcHA.KgBBqstuxhcMKnAsfDzjcJYLIECh(P_0);
		}

		internal static KeyboardKeyCode GqKWxMODjRKwgzCxHKHcWfJaWFzv(KeyCode P_0)
		{
			return (KeyboardKeyCode)P_0;
		}

		internal static KeyCode EwBIUZKiwNBGxivIziALtbknsGpgA(KeyboardKeyCode P_0)
		{
			return (KeyCode)P_0;
		}

		internal static ModifierKeyFlags DTbCltXVNympCJCVOWWXkHHIaIpW(ModifierKeyFlags P_0)
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

		internal static int fDGfbsBGVPECuAvsJWvzHxAKnsWk(ModifierKeyFlags P_0)
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
			return nTVUkucCEgyhiQPcIccukGFsSrqw[buttonIndex];
		}

		internal static int DEhTpUaGcEJooYCldgqNbQDDLkKHA(KeyboardKeyCode P_0)
		{
			int buttonIndex = ZbpzktwHPIinKgAJJiTPOWLtggcHA.GetButtonIndex(P_0);
			if (buttonIndex < 0)
			{
				return -1;
			}
			return ZbpzktwHPIinKgAJJiTPOWLtggcHA.ButtonElementIdentifiers[buttonIndex].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid;
		}

		internal static void OzdkyeOPiCpqmcUxHuPGZPSCqHpq(ref int P_0, ref KeyCode P_1)
		{
			if (P_1 != KeyCode.None)
			{
				P_0 = DEhTpUaGcEJooYCldgqNbQDDLkKHA(GqKWxMODjRKwgzCxHKHcWfJaWFzv(P_1));
			}
			else
			{
				P_1 = ReInput.AtHYwRgWVYrmVOsWolCxiSLKHuEp.IeYgCxBcbnFZhKaxGJMqKHnEVRHi.GetKeyCodeById(P_0);
			}
		}

		internal void aePKiBDieHiJEHsKpnoknbLQOCrXA(UpdateLoopType P_0)
		{
			QNGVnlPXanTpnTPVIBPXhqerAjifb.UpdateInputData(vAJlxjrsCepUBGzroHjWcArmXQkU);
			base.SSAuafxQNvPbHvrzmnbTGwbAWFNW(P_0);
			wbfCkfcnnTQwIMbkawtBABkxMncsA();
		}

		internal void BnDgWknNlTdmzTWfhXkCAbHeAmuQ(UpdateLoopType P_0)
		{
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape].viHgNbCUcsmRhvdKxmIOtUmKcUWBA(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape, vAJlxjrsCepUBGzroHjWcArmXQkU);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu].viHgNbCUcsmRhvdKxmIOtUmKcUWBA(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu, vAJlxjrsCepUBGzroHjWcArmXQkU);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_F2].viHgNbCUcsmRhvdKxmIOtUmKcUWBA(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_F2, vAJlxjrsCepUBGzroHjWcArmXQkU);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow].viHgNbCUcsmRhvdKxmIOtUmKcUWBA(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow, vAJlxjrsCepUBGzroHjWcArmXQkU);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow].viHgNbCUcsmRhvdKxmIOtUmKcUWBA(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow, vAJlxjrsCepUBGzroHjWcArmXQkU);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow].viHgNbCUcsmRhvdKxmIOtUmKcUWBA(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow, vAJlxjrsCepUBGzroHjWcArmXQkU);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow].viHgNbCUcsmRhvdKxmIOtUmKcUWBA(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow, vAJlxjrsCepUBGzroHjWcArmXQkU);
		}

		internal bool qvuGyewCFSjJvIbZGJIqlXpNmFcX(KeyboardKeyCode P_0)
		{
			if ((uint)P_0 > (uint)kukenHBdoykUZejTXqGhoMVdgCiEA)
			{
				return false;
			}
			int num = CzMuCtxilUIQTgWuCFqVnMIgfPZc[(int)P_0];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].value;
		}

		internal bool ZcJbxYZkZhmCyZkehExXacswZyIrA(KeyboardKeyCode P_0)
		{
			if ((uint)P_0 > (uint)kukenHBdoykUZejTXqGhoMVdgCiEA)
			{
				return false;
			}
			int num = CzMuCtxilUIQTgWuCFqVnMIgfPZc[(int)P_0];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].valuePrev;
		}

		internal bool qqdvAhHPNsZIohampAoagYdZvzxD(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (!qvuGyewCFSjJvIbZGJIqlXpNmFcX(P_0))
			{
				return false;
			}
			if (P_1 == ModifierKeyFlags.None)
			{
				return true;
			}
			if ((P_1 & roQciccFoQQlgrgwvjztCsBgiVpIA) != P_1)
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

		internal bool UVtqwErphQEhBLdEKutOeiGwCNsT(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (qvuGyewCFSjJvIbZGJIqlXpNmFcX(P_0))
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
			if ((uint)keyCode > (uint)kukenHBdoykUZejTXqGhoMVdgCiEA)
			{
				return -1;
			}
			return CzMuCtxilUIQTgWuCFqVnMIgfPZc[(int)keyCode];
		}

		[CustomObfuscation(rename = false)]
		internal void BakeMap(ControllerMap controllerMap)
		{
			if (controllerMap != null)
			{
				IList<ActionElementMap> list = controllerMap.OurlyxeFzWBnIptcmgMKsPUxiwjO;
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					EfvdQpyXFryBbeksYVlLvkBmPQQC(controllerMap, list[i]);
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal void BakeActionElementMap(ControllerMap controllerMap, ActionElementMap map)
		{
			map?.FNqTNkOozAgwnWePEBwoFWAPyUfy(controllerMap);
		}

		internal void BddshafYjjAqpDazlRVwBDVMssoE()
		{
			base.ufAgwGoHxawiKAxEmPcnTrGkJWTF();
			UpMeGSfsswkmdQxdnabnfRAjiyZe = ModifierKeyFlags.None;
			roQciccFoQQlgrgwvjztCsBgiVpIA = ModifierKeyFlags.None;
		}

		internal bool ScvgRcyrVcaqwiWKXNcPWMVdokBu(bool P_0)
		{
			if (!base.JErfaHktCKVFtNnhTKDJdWzTRcaq(P_0))
			{
				return false;
			}
			if (QNGVnlPXanTpnTPVIBPXhqerAjifb is IGetSetEnabled)
			{
				(QNGVnlPXanTpnTPVIBPXhqerAjifb as IGetSetEnabled).enabled = P_0;
			}
			return true;
		}

		private bool btEgdNtnHauNGhfJOPDtrqPKWfSk(out Button P_0, out Button P_1, ModifierKey P_2)
		{
			P_0 = null;
			P_1 = null;
			switch (P_2)
			{
			case ModifierKey.None:
				return false;
			case ModifierKey.Control:
				P_0 = buttons[CzMuCtxilUIQTgWuCFqVnMIgfPZc[306]];
				P_1 = buttons[CzMuCtxilUIQTgWuCFqVnMIgfPZc[305]];
				return true;
			case ModifierKey.Alt:
				P_0 = buttons[CzMuCtxilUIQTgWuCFqVnMIgfPZc[308]];
				P_1 = buttons[CzMuCtxilUIQTgWuCFqVnMIgfPZc[307]];
				return true;
			case ModifierKey.Command:
				P_0 = buttons[CzMuCtxilUIQTgWuCFqVnMIgfPZc[310]];
				P_1 = buttons[CzMuCtxilUIQTgWuCFqVnMIgfPZc[309]];
				return true;
			case ModifierKey.Shift:
				P_0 = buttons[CzMuCtxilUIQTgWuCFqVnMIgfPZc[304]];
				P_1 = buttons[CzMuCtxilUIQTgWuCFqVnMIgfPZc[303]];
				return true;
			default:
				return false;
			}
		}

		private void wbfCkfcnnTQwIMbkawtBABkxMncsA()
		{
			ModifierKeyFlags modifierKeyFlags = ModifierKeyFlags.None;
			if (buttons[CzMuCtxilUIQTgWuCFqVnMIgfPZc[306]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftControl;
			}
			if (buttons[CzMuCtxilUIQTgWuCFqVnMIgfPZc[305]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightControl;
			}
			if (buttons[CzMuCtxilUIQTgWuCFqVnMIgfPZc[310]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftCommand;
			}
			if (buttons[CzMuCtxilUIQTgWuCFqVnMIgfPZc[309]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightCommand;
			}
			if (buttons[CzMuCtxilUIQTgWuCFqVnMIgfPZc[308]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftAlt;
			}
			if (buttons[CzMuCtxilUIQTgWuCFqVnMIgfPZc[307]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightAlt;
			}
			if (buttons[CzMuCtxilUIQTgWuCFqVnMIgfPZc[304]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftShift;
			}
			if (buttons[CzMuCtxilUIQTgWuCFqVnMIgfPZc[303]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightShift;
			}
			UpMeGSfsswkmdQxdnabnfRAjiyZe = modifierKeyFlags;
			roQciccFoQQlgrgwvjztCsBgiVpIA = DTbCltXVNympCJCVOWWXkHHIaIpW(modifierKeyFlags);
		}

		private string wlBKWADlfnVaysBtrcoSFMtTGGMY(ModifierKey P_0, bool P_1)
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
			if (!PIGTnLKefPiPlZWoWOxoxDSgqGsv.TryGetValue((int)P_0, out var value))
			{
				return result;
			}
			string result2;
			if (P_1)
			{
				if (value.voNNAzxVFthyFbUwSVcLGASuQEmA != null && VlaZEIYfJJILYxecFNaiMOGmhWWR(value.voNNAzxVFthyFbUwSVcLGASuQEmA, modifierKeyInfo.shortKey, modifierKeyInfo.shortName, JEexZOPzSUUjNTHjvxywblgJdFqE.deviceLocalizationInfo, out result2))
				{
					return result2;
				}
				if (value.jaCshNgspacFNSBoknRcTYanANsO != null && VlaZEIYfJJILYxecFNaiMOGmhWWR(value.jaCshNgspacFNSBoknRcTYanANsO, modifierKeyInfo.longKey, modifierKeyInfo.longName, JEexZOPzSUUjNTHjvxywblgJdFqE.deviceLocalizationInfo, out result2))
				{
					return result2;
				}
				return result;
			}
			if (value.jaCshNgspacFNSBoknRcTYanANsO == null)
			{
				return result;
			}
			VlaZEIYfJJILYxecFNaiMOGmhWWR(value.jaCshNgspacFNSBoknRcTYanANsO, modifierKeyInfo.longKey, modifierKeyInfo.longName, JEexZOPzSUUjNTHjvxywblgJdFqE.deviceLocalizationInfo, out result2);
			return result2;
		}

		private static bool VlaZEIYfJJILYxecFNaiMOGmhWWR(kdznJtZhtbJIiVcKMIRImdXTAotF P_0, string P_1, string P_2, DeviceLocalizationInfo P_3, out string P_4)
		{
			LocalizationManager.GetAndUpdateLocalizedStringResultFlags getAndUpdateLocalizedStringResultFlags = kgoenjfnufElmhiZmbMkzRwPiuvy.XgrdXSJvFNjoTfFeZamaDOvjmZGYA(P_0.qOkPZUXNiapGEdHHulmVNdXxFnkbA, P_1, "controller", P_2, P_3, flkMCmNLqqynNeuvLSYPGZFpwSqE.Keyboard, -1, AxisRange.Full, -1, out P_4);
			if ((getAndUpdateLocalizedStringResultFlags & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
			{
				P_0.FrlyzqQnJnYSQigFsrZGMSpCWRpL = (getAndUpdateLocalizedStringResultFlags & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.JustLocalized) != 0;
			}
			return P_0.FrlyzqQnJnYSQigFsrZGMSpCWRpL;
		}

		private object QZWPeKwgORkOWrfsPKJULpYcHYJL(ModifierKey P_0)
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
			if (!ZgAgyEFKhhULSgKwDpCMaQHIzxNu.TryGetValue((int)P_0, out var value))
			{
				return null;
			}
			if (hgEhJXqwGUADfxjsUTBsTYRTtEkU(value, modifierKeyInfo.longKey, JEexZOPzSUUjNTHjvxywblgJdFqE.deviceLocalizationInfo, out var result))
			{
				return result;
			}
			return null;
		}

		private string KgBBqstuxhcMKnAsfDzjcJYLIECh(ModifierKey P_0)
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
			if (!ZgAgyEFKhhULSgKwDpCMaQHIzxNu.TryGetValue((int)P_0, out var value))
			{
				return null;
			}
			if (ntadpKulUIaXICsLcCeXmLrBmnVkA(value, modifierKeyInfo.longKey, JEexZOPzSUUjNTHjvxywblgJdFqE.deviceLocalizationInfo, out var result))
			{
				return result;
			}
			return null;
		}

		private static bool hgEhJXqwGUADfxjsUTBsTYRTtEkU(LVneJAUcffJerycNaEDFOHcWZKwi P_0, string P_1, DeviceLocalizationInfo P_2, out object P_3)
		{
			GlyphManager.GetAndUpdateGlyphResultFlags getAndUpdateGlyphResultFlags = SViFaPigtCBGMFMJsvheBSAMmczFA.bIhuNnssVhqyqHkqyUvGOdaFPwIV(P_0.lEdryFzxomycBjYbsHfkKesvyoGI, P_1, "controller", P_2, flkMCmNLqqynNeuvLSYPGZFpwSqE.Keyboard, -1, AxisRange.Full, -1, out P_3);
			if ((getAndUpdateGlyphResultFlags & GlyphManager.GetAndUpdateGlyphResultFlags.Changed) != GlyphManager.GetAndUpdateGlyphResultFlags.None)
			{
				P_0.FReXmLfjVUXRWYjnTakudByAbGzdb = (getAndUpdateGlyphResultFlags & GlyphManager.GetAndUpdateGlyphResultFlags.JustGot) != 0;
			}
			return P_0.FReXmLfjVUXRWYjnTakudByAbGzdb;
		}

		private static bool ntadpKulUIaXICsLcCeXmLrBmnVkA(LVneJAUcffJerycNaEDFOHcWZKwi P_0, string P_1, DeviceLocalizationInfo P_2, out string P_3)
		{
			object obj;
			bool result = hgEhJXqwGUADfxjsUTBsTYRTtEkU(P_0, P_1, P_2, out obj);
			P_3 = P_0.lEdryFzxomycBjYbsHfkKesvyoGI.cachedKey;
			return result;
		}

		[CompilerGenerated]
		private void LiYWuPgWWpdoStFwoTGAXnsezPMh()
		{
			IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
			for (int i = 0; i < values.Count; i++)
			{
				wlBKWADlfnVaysBtrcoSFMtTGGMY(values[i], true);
				wlBKWADlfnVaysBtrcoSFMtTGGMY(values[i], false);
			}
		}

		[CompilerGenerated]
		private void GWsiXoTMnBJgAvfVecsSECxJHNzgA()
		{
			IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
			for (int i = 0; i < values.Count; i++)
			{
				QZWPeKwgORkOWrfsPKJULpYcHYJL(values[i]);
			}
		}
	}
}
