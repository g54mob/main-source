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

		private class ZLMgjSObVFlidzMfXdFOCTgGJOky
		{
			public readonly JgTIWNLySlYbvyRgkyKhsafhYVke OVYgqtdUsNedgSJLOxRlAtocYPmB;

			public readonly JgTIWNLySlYbvyRgkyKhsafhYVke KbwOQfygiieUGGhnOjbFyZFBdTfKA;

			public ZLMgjSObVFlidzMfXdFOCTgGJOky(string P_0, string P_1)
			{
				if (!string.IsNullOrEmpty(P_0))
				{
					OVYgqtdUsNedgSJLOxRlAtocYPmB = new JgTIWNLySlYbvyRgkyKhsafhYVke(new LocalizedString());
				}
				if (!string.IsNullOrEmpty(P_1))
				{
					KbwOQfygiieUGGhnOjbFyZFBdTfKA = new JgTIWNLySlYbvyRgkyKhsafhYVke(new LocalizedString());
				}
			}
		}

		private sealed class JgTIWNLySlYbvyRgkyKhsafhYVke
		{
			public readonly LocalizedString HFERkoJCheqVFMvAYpOwPPgRZtny;

			public bool iFTRfIULStPXJJmOQNHjQEEmEQeM;

			public JgTIWNLySlYbvyRgkyKhsafhYVke(LocalizedString P_0)
			{
				HFERkoJCheqVFMvAYpOwPPgRZtny = P_0;
			}
		}

		private sealed class yHoZzYIlhHSmSVpSPcckKHuuLhRA
		{
			public readonly KeyedGlyph OfFCNbpduajTEGDLOtjNCrLLgkNF;

			public bool ugMtDtxuIQKGHxLwhkKLTUVcYtmK;

			public yHoZzYIlhHSmSVpSPcckKHuuLhRA(KeyedGlyph P_0)
			{
				OfFCNbpduajTEGDLOtjNCrLLgkNF = P_0;
			}
		}

		private sealed class HeHZJqpAENYeKqhIwgdcdNxrvLogA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int EJiWaInHeXmRuKdhgdwIhqpJbmfHA;

			private ControllerPollingInfo GoqDNCJapdbvxcrlXAExDPVFQNlGA;

			private int LTehdhMntwAFxCobTCdglQTwdDPs;

			public Keyboard cuDJbtSPAYFGWHdWAGWoTPyufFeHA;

			private int OtrNfqHIsxKiULxzeJlMdmhketby;

			private int ddyAJLPTMgjPCdogMjYvrdHMWnIrA;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return GoqDNCJapdbvxcrlXAExDPVFQNlGA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return GoqDNCJapdbvxcrlXAExDPVFQNlGA;
				}
			}

			[DebuggerHidden]
			public HeHZJqpAENYeKqhIwgdcdNxrvLogA(int P_0)
			{
				EJiWaInHeXmRuKdhgdwIhqpJbmfHA = P_0;
				LTehdhMntwAFxCobTCdglQTwdDPs = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int eJiWaInHeXmRuKdhgdwIhqpJbmfHA = EJiWaInHeXmRuKdhgdwIhqpJbmfHA;
				Keyboard keyboard = cuDJbtSPAYFGWHdWAGWoTPyufFeHA;
				if (eJiWaInHeXmRuKdhgdwIhqpJbmfHA != 0)
				{
					if (eJiWaInHeXmRuKdhgdwIhqpJbmfHA != 1)
					{
						return false;
					}
					EJiWaInHeXmRuKdhgdwIhqpJbmfHA = -1;
					goto IL_00bf;
				}
				EJiWaInHeXmRuKdhgdwIhqpJbmfHA = -1;
				if (ReInput._id != keyboard.amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(keyboard.amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return false;
				}
				OtrNfqHIsxKiULxzeJlMdmhketby = Consts.keyboardKeyValues.Count;
				ddyAJLPTMgjPCdogMjYvrdHMWnIrA = 0;
				goto IL_00cf;
				IL_00cf:
				if (ddyAJLPTMgjPCdogMjYvrdHMWnIrA < OtrNfqHIsxKiULxzeJlMdmhketby)
				{
					KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[ddyAJLPTMgjPCdogMjYvrdHMWnIrA];
					if (keyboard.GetKey(keyCode))
					{
						GoqDNCJapdbvxcrlXAExDPVFQNlGA = new ControllerPollingInfo(true, -1, keyboard.id, keyboard._name, keyboard._type, ControllerElementType.Button, ddyAJLPTMgjPCdogMjYvrdHMWnIrA, Pole.Positive, GetKeyName(keyCode), keyboard.qfUAjoZEkUJBMcgOHFRLtyQzKjdR.buttonElementIdentifierIds[ddyAJLPTMgjPCdogMjYvrdHMWnIrA], keyCode);
						EJiWaInHeXmRuKdhgdwIhqpJbmfHA = 1;
						return true;
					}
					goto IL_00bf;
				}
				return false;
				IL_00bf:
				ddyAJLPTMgjPCdogMjYvrdHMWnIrA++;
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
				HeHZJqpAENYeKqhIwgdcdNxrvLogA heHZJqpAENYeKqhIwgdcdNxrvLogA;
				if (EJiWaInHeXmRuKdhgdwIhqpJbmfHA == -2 && LTehdhMntwAFxCobTCdglQTwdDPs == Environment.CurrentManagedThreadId)
				{
					EJiWaInHeXmRuKdhgdwIhqpJbmfHA = 0;
					heHZJqpAENYeKqhIwgdcdNxrvLogA = this;
				}
				else
				{
					heHZJqpAENYeKqhIwgdcdNxrvLogA = new HeHZJqpAENYeKqhIwgdcdNxrvLogA(0);
					heHZJqpAENYeKqhIwgdcdNxrvLogA.cuDJbtSPAYFGWHdWAGWoTPyufFeHA = cuDJbtSPAYFGWHdWAGWoTPyufFeHA;
				}
				return heHZJqpAENYeKqhIwgdcdNxrvLogA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class iKwfBxmGoCezFvUrSXarKMpuMvgb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int WLfdrqvDkwFhQlGsGueeWJFEIjYT;

			private ControllerPollingInfo ZWdGOMtTZWFYmcLQrIAODsajsRON;

			private int gOmiCysvBaeINzocWkgBtnljFzll;

			public Keyboard UUzSznlOgkiDwJbRBfKCFVnabIHf;

			private int fgTMIJQpQkYSkDeQImzutlXoDYsg;

			private int ucrnFdOCnEpfcvxaBcFvHuiFVwrE;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return ZWdGOMtTZWFYmcLQrIAODsajsRON;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ZWdGOMtTZWFYmcLQrIAODsajsRON;
				}
			}

			[DebuggerHidden]
			public iKwfBxmGoCezFvUrSXarKMpuMvgb(int P_0)
			{
				WLfdrqvDkwFhQlGsGueeWJFEIjYT = P_0;
				gOmiCysvBaeINzocWkgBtnljFzll = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int wLfdrqvDkwFhQlGsGueeWJFEIjYT = WLfdrqvDkwFhQlGsGueeWJFEIjYT;
				Keyboard uUzSznlOgkiDwJbRBfKCFVnabIHf = UUzSznlOgkiDwJbRBfKCFVnabIHf;
				if (wLfdrqvDkwFhQlGsGueeWJFEIjYT != 0)
				{
					if (wLfdrqvDkwFhQlGsGueeWJFEIjYT != 1)
					{
						return false;
					}
					WLfdrqvDkwFhQlGsGueeWJFEIjYT = -1;
					goto IL_00bf;
				}
				WLfdrqvDkwFhQlGsGueeWJFEIjYT = -1;
				if (ReInput._id != uUzSznlOgkiDwJbRBfKCFVnabIHf.amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(uUzSznlOgkiDwJbRBfKCFVnabIHf.amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return false;
				}
				fgTMIJQpQkYSkDeQImzutlXoDYsg = Consts.keyboardKeyValues.Count;
				ucrnFdOCnEpfcvxaBcFvHuiFVwrE = 0;
				goto IL_00cf;
				IL_00cf:
				if (ucrnFdOCnEpfcvxaBcFvHuiFVwrE < fgTMIJQpQkYSkDeQImzutlXoDYsg)
				{
					KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[ucrnFdOCnEpfcvxaBcFvHuiFVwrE];
					if (uUzSznlOgkiDwJbRBfKCFVnabIHf.GetKeyDown(keyCode))
					{
						ZWdGOMtTZWFYmcLQrIAODsajsRON = new ControllerPollingInfo(true, -1, uUzSznlOgkiDwJbRBfKCFVnabIHf.id, uUzSznlOgkiDwJbRBfKCFVnabIHf._name, uUzSznlOgkiDwJbRBfKCFVnabIHf._type, ControllerElementType.Button, ucrnFdOCnEpfcvxaBcFvHuiFVwrE, Pole.Positive, GetKeyName(keyCode), uUzSznlOgkiDwJbRBfKCFVnabIHf.qfUAjoZEkUJBMcgOHFRLtyQzKjdR.buttonElementIdentifierIds[ucrnFdOCnEpfcvxaBcFvHuiFVwrE], keyCode);
						WLfdrqvDkwFhQlGsGueeWJFEIjYT = 1;
						return true;
					}
					goto IL_00bf;
				}
				return false;
				IL_00bf:
				ucrnFdOCnEpfcvxaBcFvHuiFVwrE++;
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
				iKwfBxmGoCezFvUrSXarKMpuMvgb iKwfBxmGoCezFvUrSXarKMpuMvgb2;
				if (WLfdrqvDkwFhQlGsGueeWJFEIjYT == -2 && gOmiCysvBaeINzocWkgBtnljFzll == Environment.CurrentManagedThreadId)
				{
					WLfdrqvDkwFhQlGsGueeWJFEIjYT = 0;
					iKwfBxmGoCezFvUrSXarKMpuMvgb2 = this;
				}
				else
				{
					iKwfBxmGoCezFvUrSXarKMpuMvgb2 = new iKwfBxmGoCezFvUrSXarKMpuMvgb(0);
					iKwfBxmGoCezFvUrSXarKMpuMvgb2.UUzSznlOgkiDwJbRBfKCFVnabIHf = UUzSznlOgkiDwJbRBfKCFVnabIHf;
				}
				return iKwfBxmGoCezFvUrSXarKMpuMvgb2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private const string KCcCULmQMMgLlYbQINnMqygOSjqQ = " + ";

		private static Keyboard qAJwVLswCKLyZLJCzhxsEaeTNmxn;

		private static KeyboardKeyCode[] ZLaaVTqjytoifRgwuaCZzPRjcYwD;

		private static Guid eBzViLZlKzDSkOYazRelnUuHaEtd;

		private readonly IUnifiedKeyboardSource ndaXYHLadlqimagUolpmypHFlhfO;

		private ModifierKeyFlags nysLqyvtgsrpBdwTSGKHfyFTsSsA;

		private ModifierKeyFlags UEwfXSeLlQEujVLdTKNGMwkYzFsiA;

		private Func<KeyboardKeyCode, int> wQcJOxprThLmGPXkSjLcghuduFYB;

		private readonly int[] lgOZHChvEOXQfXJCsbgmbjMUvAWB;

		private readonly int JxOdFbHfnsLLMPQOdieEeamTZClX;

		private readonly HoegishJjcCukocqVPiQYVHCmbvt yESkZikbNbqKcuZahDvCbIUchLoY;

		private readonly LSZgSpTkKDvpCWjrrDwcvUKyRuBp uXKXVJtEEqypoZiAdhEvkKMxFrMp;

		private Dictionary<int, ZLMgjSObVFlidzMfXdFOCTgGJOky> hqvPYoPbacBssyHFgCaugjklSdQo;

		private Dictionary<int, yHoZzYIlhHSmSVpSPcckKHuuLhRA> rERwYZckocWwZjzOXVzaqxUpCBtv;

		private static KeyboardKeyCode[] MezvXQofReUydvKhumABgWyWarjQ
		{
			get
			{
				if (ZLaaVTqjytoifRgwuaCZzPRjcYwD == null)
				{
					int[] keyboardKeyValues = Consts._keyboardKeyValues;
					int num = keyboardKeyValues.Length;
					ZLaaVTqjytoifRgwuaCZzPRjcYwD = new KeyboardKeyCode[num];
					for (int i = 0; i < num; i++)
					{
						ZLaaVTqjytoifRgwuaCZzPRjcYwD[i] = (KeyboardKeyCode)keyboardKeyValues[i];
					}
				}
				return ZLaaVTqjytoifRgwuaCZzPRjcYwD;
			}
		}

		private Dictionary<int, ZLMgjSObVFlidzMfXdFOCTgGJOky> eKkdidMqeNQWasszsLhXlFfEaYbl
		{
			get
			{
				if (hqvPYoPbacBssyHFgCaugjklSdQo == null)
				{
					Rewired.Utils.Interfaces.IReadOnlyDictionary<int, ModifierKeyInfo> modifierKeyInfo = Consts.modifierKeyInfo;
					Dictionary<int, ZLMgjSObVFlidzMfXdFOCTgGJOky> dictionary = new Dictionary<int, ZLMgjSObVFlidzMfXdFOCTgGJOky>();
					foreach (KeyValuePair<int, ModifierKeyInfo> item in modifierKeyInfo)
					{
						if (item.Key != 0)
						{
							dictionary.Add(item.Key, new ZLMgjSObVFlidzMfXdFOCTgGJOky(item.Value.shortKey, item.Value.longKey));
						}
					}
					hqvPYoPbacBssyHFgCaugjklSdQo = dictionary;
				}
				return hqvPYoPbacBssyHFgCaugjklSdQo;
			}
		}

		private Dictionary<int, yHoZzYIlhHSmSVpSPcckKHuuLhRA> stiGLyRuulBEZTPxpyuteGsoevCr
		{
			get
			{
				if (rERwYZckocWwZjzOXVzaqxUpCBtv == null)
				{
					Rewired.Utils.Interfaces.IReadOnlyDictionary<int, ModifierKeyInfo> modifierKeyInfo = Consts.modifierKeyInfo;
					Dictionary<int, yHoZzYIlhHSmSVpSPcckKHuuLhRA> dictionary = new Dictionary<int, yHoZzYIlhHSmSVpSPcckKHuuLhRA>();
					foreach (KeyValuePair<int, ModifierKeyInfo> item in modifierKeyInfo)
					{
						if (item.Key != 0)
						{
							yHoZzYIlhHSmSVpSPcckKHuuLhRA value = new yHoZzYIlhHSmSVpSPcckKHuuLhRA(new KeyedGlyph());
							dictionary.Add(item.Key, value);
						}
					}
					rERwYZckocWwZjzOXVzaqxUpCBtv = dictionary;
				}
				return rERwYZckocWwZjzOXVzaqxUpCBtv;
			}
		}

		Guid Controller.deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return Guid.Empty;
				}
				return eBzViLZlKzDSkOYazRelnUuHaEtd;
			}
		}

		internal Keyboard(string P_0, IUnifiedKeyboardSource P_1)
			: this(0, P_1.inputSource, P_0, InputTools.FormatHardwareIdentifierString(P_0), P_1.hardwareMap, 132, P_1?.controllerExtension, new ControllerDataUpdater(P_1.inputSource, 0, 132, null))
		{
			eBzViLZlKzDSkOYazRelnUuHaEtd = MiscTools.CreateGuidHashSHA1("[Universal Keyboard]");
			yESkZikbNbqKcuZahDvCbIUchLoY = new HoegishJjcCukocqVPiQYVHCmbvt(delegate
			{
				IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
				for (int i = 0; i < values.Count; i++)
				{
					RlntYaZcgvUHdVtaPEajPtQrEaZj(values[i], true);
					RlntYaZcgvUHdVtaPEajPtQrEaZj(values[i], false);
				}
			});
			uXKXVJtEEqypoZiAdhEvkKMxFrMp = new LSZgSpTkKDvpCWjrrDwcvUKyRuBp(delegate
			{
				IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
				for (int i = 0; i < values.Count; i++)
				{
					jkakhmmfPFnNXMnPfhyhRrXMEMYd(values[i]);
				}
			});
			int[] keyboardKeyValues = Consts._keyboardKeyValues;
			int num = keyboardKeyValues.Length;
			for (int num2 = 0; num2 < num; num2++)
			{
				if (keyboardKeyValues[num2] > JxOdFbHfnsLLMPQOdieEeamTZClX)
				{
					JxOdFbHfnsLLMPQOdieEeamTZClX = keyboardKeyValues[num2];
				}
			}
			lgOZHChvEOXQfXJCsbgmbjMUvAWB = new int[JxOdFbHfnsLLMPQOdieEeamTZClX + 1];
			ArrayTools.Fill(lgOZHChvEOXQfXJCsbgmbjMUvAWB, -1);
			for (int num3 = 0; num3 < num; num3++)
			{
				lgOZHChvEOXQfXJCsbgmbjMUvAWB[keyboardKeyValues[num3]] = num3;
			}
			ndaXYHLadlqimagUolpmypHFlhfO = P_1;
			if (LocalizationManager.isEnabled && LocalizationManager.autoPrefetch)
			{
				((IfopinoSAuQZnpEvFIfBnubyAxLB)yESkZikbNbqKcuZahDvCbIUchLoY).Localize();
			}
			if (GlyphManager.isEnabled && GlyphManager.autoPrefetch)
			{
				((IPrefetch)uXKXVJtEEqypoZiAdhEvkKMxFrMp).Prefetch();
			}
			CpCVLCxmguYfwaCGdHOlxVqCpGLv();
		}

		private Keyboard(int P_0, InputSource P_1, string P_2, string P_3, HardwareControllerMap_Game P_4, int P_5, Extension P_6, ControllerDataUpdater P_7)
			: base(P_0, P_1, P_2, P_2, P_3, ControllerType.Keyboard, Consts.hardwareTypeGuid_universalKeyboard, P_5, null, P_4, P_6, P_7)
		{
			qAJwVLswCKLyZLJCzhxsEaeTNmxn = this;
		}

		public bool GetKey(KeyCode keyCode)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return false;
			}
			if ((uint)keyCode > (uint)JxOdFbHfnsLLMPQOdieEeamTZClX)
			{
				return false;
			}
			int num = lgOZHChvEOXQfXJCsbgmbjMUvAWB[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].value;
		}

		public bool GetKeyDown(KeyCode keyCode)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return false;
			}
			if ((uint)keyCode > (uint)JxOdFbHfnsLLMPQOdieEeamTZClX)
			{
				return false;
			}
			int num = lgOZHChvEOXQfXJCsbgmbjMUvAWB[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].justPressed;
		}

		public bool GetKeyUp(KeyCode keyCode)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return false;
			}
			if ((uint)keyCode > (uint)JxOdFbHfnsLLMPQOdieEeamTZClX)
			{
				return false;
			}
			int num = lgOZHChvEOXQfXJCsbgmbjMUvAWB[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].justReleased;
		}

		public bool GetKeyDoublePressHold(KeyCode keyCode, float speed)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return false;
			}
			if ((uint)keyCode > (uint)JxOdFbHfnsLLMPQOdieEeamTZClX)
			{
				return false;
			}
			int num = lgOZHChvEOXQfXJCsbgmbjMUvAWB[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].DoublePressedAndHeld(speed);
		}

		public bool GetKeyDoublePressHold(KeyCode keyCode)
		{
			if ((uint)keyCode > (uint)JxOdFbHfnsLLMPQOdieEeamTZClX)
			{
				return false;
			}
			int num = lgOZHChvEOXQfXJCsbgmbjMUvAWB[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].DoublePressedAndHeld(0f);
		}

		public bool GetKeyDoublePressDown(KeyCode keyCode, float speed)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return false;
			}
			if ((uint)keyCode > (uint)JxOdFbHfnsLLMPQOdieEeamTZClX)
			{
				return false;
			}
			int num = lgOZHChvEOXQfXJCsbgmbjMUvAWB[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].JustDoublePressed(speed);
		}

		public bool GetKeyDoublePressDown(KeyCode keyCode)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return false;
			}
			if ((uint)keyCode > (uint)JxOdFbHfnsLLMPQOdieEeamTZClX)
			{
				return false;
			}
			int num = lgOZHChvEOXQfXJCsbgmbjMUvAWB[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].JustDoublePressed(0f);
		}

		public bool GetKeyPrev(KeyCode keyCode)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return false;
			}
			if ((uint)keyCode > (uint)JxOdFbHfnsLLMPQOdieEeamTZClX)
			{
				return false;
			}
			int num = lgOZHChvEOXQfXJCsbgmbjMUvAWB[(int)keyCode];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].valuePrev;
		}

		public double GetKeyTimePressed(KeyCode keyCode)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return 0.0;
			}
			if ((uint)keyCode > (uint)JxOdFbHfnsLLMPQOdieEeamTZClX)
			{
				return 0.0;
			}
			int num = lgOZHChvEOXQfXJCsbgmbjMUvAWB[(int)keyCode];
			if (num < 0)
			{
				return 0.0;
			}
			return buttons[num].timePressed;
		}

		public double GetKeyTimeUnpressed(KeyCode keyCode)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return 0.0;
			}
			if ((uint)keyCode > (uint)JxOdFbHfnsLLMPQOdieEeamTZClX)
			{
				return 0.0;
			}
			int num = lgOZHChvEOXQfXJCsbgmbjMUvAWB[(int)keyCode];
			if (num < 0)
			{
				return 0.0;
			}
			return buttons[num].timeUnpressed;
		}

		public bool GetModifierKey(ModifierKey key)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return false;
			}
			if (!QWiLcdjyQebfXICEijuMnceoECRy(out var button, out var button2, key))
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return false;
			}
			if (!QWiLcdjyQebfXICEijuMnceoECRy(out var button, out var button2, key))
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return false;
			}
			if (!QWiLcdjyQebfXICEijuMnceoECRy(out var button, out var button2, key))
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return false;
			}
			if (!QWiLcdjyQebfXICEijuMnceoECRy(out var button, out var button2, key))
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return 0.0;
			}
			if (!QWiLcdjyQebfXICEijuMnceoECRy(out var button, out var button2, key))
			{
				return 0.0;
			}
			return MathTools.Max(button.timePressed, button2.timePressed);
		}

		public double GetModifierKeyTimeUnpressed(ModifierKey key)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return 0.0;
			}
			if (!QWiLcdjyQebfXICEijuMnceoECRy(out var button, out var button2, key))
			{
				return 0.0;
			}
			return MathTools.Min(button.timeUnpressed, button2.timeUnpressed);
		}

		public KeyCode GetKeyCodeByButtonIndex(int buttonIndex)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return KeyCode.None;
			}
			return vRjevpEmzBEDgUVDZfgythFRZMmo(GetKeyboardKeyCodeByButtonIndex(buttonIndex));
		}

		public KeyCode GetKeyCodeById(int elementIdentifierId)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return KeyCode.None;
			}
			return GetKeyCodeByButtonIndex(GetButtonIndexById(elementIdentifierId));
		}

		public int GetButtonIndexByKeyCode(KeyCode keyCode)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return -1;
			}
			if ((uint)keyCode > (uint)JxOdFbHfnsLLMPQOdieEeamTZClX)
			{
				return -1;
			}
			return lgOZHChvEOXQfXJCsbgmbjMUvAWB[(int)keyCode];
		}

		public ControllerElementIdentifier GetElementIdentifierByKeyCode(KeyCode keyCode)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return null;
			}
			if ((uint)keyCode > (uint)JxOdFbHfnsLLMPQOdieEeamTZClX)
			{
				return null;
			}
			int num = lgOZHChvEOXQfXJCsbgmbjMUvAWB[(int)keyCode];
			if (num < 0)
			{
				return null;
			}
			return qfUAjoZEkUJBMcgOHFRLtyQzKjdR.buttonElementIdentifiers_cache[num];
		}

		public ControllerPollingInfo PollForFirstKey()
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
			}
			int count = Consts.keyboardKeyValues.Count;
			for (int i = 0; i < count; i++)
			{
				KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[i];
				if (GetKey(keyCode))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, GetKeyName(keyCode), qfUAjoZEkUJBMcgOHFRLtyQzKjdR.buttonElementIdentifierIds[i], keyCode);
				}
			}
			return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
		}

		[IteratorStateMachine(typeof(HeHZJqpAENYeKqhIwgdcdNxrvLogA))]
		public IEnumerable<ControllerPollingInfo> PollForAllKeys()
		{
			return new HeHZJqpAENYeKqhIwgdcdNxrvLogA(-2)
			{
				cuDJbtSPAYFGWHdWAGWoTPyufFeHA = this
			};
		}

		[IteratorStateMachine(typeof(iKwfBxmGoCezFvUrSXarKMpuMvgb))]
		public IEnumerable<ControllerPollingInfo> PollForAllKeysDown()
		{
			return new iKwfBxmGoCezFvUrSXarKMpuMvgb(-2)
			{
				UUzSznlOgkiDwJbRBfKCFVnabIHf = this
			};
		}

		public ControllerPollingInfo PollForFirstKeyDown()
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
			}
			int count = Consts.keyboardKeyValues.Count;
			for (int i = 0; i < count; i++)
			{
				KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[i];
				if (GetKeyDown(keyCode))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, GetKeyName(keyCode), qfUAjoZEkUJBMcgOHFRLtyQzKjdR.buttonElementIdentifierIds[i], keyCode);
				}
			}
			return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
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

		internal static bool pvITbdCGvZzmjnzjPqKMZOLZSide(KeyboardKeyCode P_0)
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
			if (qAJwVLswCKLyZLJCzhxsEaeTNmxn == null)
			{
				return string.Empty;
			}
			int buttonIndex = qAJwVLswCKLyZLJCzhxsEaeTNmxn.GetButtonIndex(ndgptuICyPrvjQAqjbfBCtuCBBsn(key));
			if (buttonIndex < 0)
			{
				return string.Empty;
			}
			return qAJwVLswCKLyZLJCzhxsEaeTNmxn.ButtonElementIdentifiers[buttonIndex].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
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
			if (qAJwVLswCKLyZLJCzhxsEaeTNmxn == null)
			{
				return string.Empty;
			}
			return qAJwVLswCKLyZLJCzhxsEaeTNmxn.RlntYaZcgvUHdVtaPEajPtQrEaZj(modifierKey, false);
		}

		public static string GetModifierKeyName(ModifierKey modifierKey, bool getShortName)
		{
			if (qAJwVLswCKLyZLJCzhxsEaeTNmxn == null)
			{
				return string.Empty;
			}
			return qAJwVLswCKLyZLJCzhxsEaeTNmxn.RlntYaZcgvUHdVtaPEajPtQrEaZj(modifierKey, getShortName);
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
			if (qAJwVLswCKLyZLJCzhxsEaeTNmxn == null)
			{
				return null;
			}
			return qAJwVLswCKLyZLJCzhxsEaeTNmxn.jkakhmmfPFnNXMnPfhyhRrXMEMYd(modifierKey);
		}

		internal static string foHomfIwvDgCVdEKxQvqGeUMRrsO(ModifierKey P_0)
		{
			if (qAJwVLswCKLyZLJCzhxsEaeTNmxn == null)
			{
				return string.Empty;
			}
			return qAJwVLswCKLyZLJCzhxsEaeTNmxn.rfhygOpHejKlFECvFWbYgRnleEPT(P_0);
		}

		internal static KeyboardKeyCode ndgptuICyPrvjQAqjbfBCtuCBBsn(KeyCode P_0)
		{
			return (KeyboardKeyCode)P_0;
		}

		internal static KeyCode vRjevpEmzBEDgUVDZfgythFRZMmo(KeyboardKeyCode P_0)
		{
			return (KeyCode)P_0;
		}

		internal static ModifierKeyFlags aTJGpZNZQqoEFgzSqaxyqmKkWXuD(ModifierKeyFlags P_0)
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

		internal static int QrgKAILKYLXMjbdpbBTWTljuEbDO(ModifierKeyFlags P_0)
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
			return MezvXQofReUydvKhumABgWyWarjQ[buttonIndex];
		}

		internal static int qOVcgukCzIWxrpjuNEIcQJqteiPn(KeyboardKeyCode P_0)
		{
			int buttonIndex = qAJwVLswCKLyZLJCzhxsEaeTNmxn.GetButtonIndex(P_0);
			if (buttonIndex < 0)
			{
				return -1;
			}
			return qAJwVLswCKLyZLJCzhxsEaeTNmxn.ButtonElementIdentifiers[buttonIndex].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid;
		}

		internal static void rpLFLEYGhGqlxLEmjQrjDcbgYLsW(ref int P_0, ref KeyCode P_1)
		{
			if (P_1 != KeyCode.None)
			{
				P_0 = qOVcgukCzIWxrpjuNEIcQJqteiPn(ndgptuICyPrvjQAqjbfBCtuCBBsn(P_1));
			}
			else
			{
				P_1 = ReInput.zEtuNvknIQbzOpsTCdeQeEswlwDw.drgNjPBDklMoqhfwuCfPMsCoXTQl.GetKeyCodeById(P_0);
			}
		}

		internal void VOnHZbPJzNAAZRyPXiUZbFompMwV(UpdateLoopType P_0)
		{
			ndaXYHLadlqimagUolpmypHFlhfO.UpdateInputData(EnxeINdfRsPNEfNsWCRpkeCWEWlpA);
			base.hdccNRifKnNeMIMmCYJkjUCelZGPA(P_0);
			FyJdJVelqHHjDhErQzTspPDRGlvlA();
		}

		internal void gjlPYUtCaPavykGmFfNbEpyWeKzh(UpdateLoopType P_0)
		{
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape].KknekHfCfaOAyFWPFHiholZwGQJTA(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape, EnxeINdfRsPNEfNsWCRpkeCWEWlpA);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu].KknekHfCfaOAyFWPFHiholZwGQJTA(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu, EnxeINdfRsPNEfNsWCRpkeCWEWlpA);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_F2].KknekHfCfaOAyFWPFHiholZwGQJTA(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_F2, EnxeINdfRsPNEfNsWCRpkeCWEWlpA);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow].KknekHfCfaOAyFWPFHiholZwGQJTA(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow, EnxeINdfRsPNEfNsWCRpkeCWEWlpA);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow].KknekHfCfaOAyFWPFHiholZwGQJTA(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow, EnxeINdfRsPNEfNsWCRpkeCWEWlpA);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow].KknekHfCfaOAyFWPFHiholZwGQJTA(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow, EnxeINdfRsPNEfNsWCRpkeCWEWlpA);
			buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow].KknekHfCfaOAyFWPFHiholZwGQJTA(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow, EnxeINdfRsPNEfNsWCRpkeCWEWlpA);
		}

		internal bool BEMgZUsbQAZSolYIoOsTnkUpcBleA(KeyboardKeyCode P_0)
		{
			if ((uint)P_0 > (uint)JxOdFbHfnsLLMPQOdieEeamTZClX)
			{
				return false;
			}
			int num = lgOZHChvEOXQfXJCsbgmbjMUvAWB[(int)P_0];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].value;
		}

		internal bool aPtOTcLdKxkPdyylLKJyeONMMcLn(KeyboardKeyCode P_0)
		{
			if ((uint)P_0 > (uint)JxOdFbHfnsLLMPQOdieEeamTZClX)
			{
				return false;
			}
			int num = lgOZHChvEOXQfXJCsbgmbjMUvAWB[(int)P_0];
			if (num < 0)
			{
				return false;
			}
			return buttons[num].valuePrev;
		}

		internal bool NBEMNDAYaEajSpvXyzBgUpljRiF(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (!BEMgZUsbQAZSolYIoOsTnkUpcBleA(P_0))
			{
				return false;
			}
			if (P_1 == ModifierKeyFlags.None)
			{
				return true;
			}
			if ((P_1 & UEwfXSeLlQEujVLdTKNGMwkYzFsiA) != P_1)
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

		internal bool dUPDTetewIDvYyFJqMencVrSJUpj(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (BEMgZUsbQAZSolYIoOsTnkUpcBleA(P_0))
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
			if ((uint)keyCode > (uint)JxOdFbHfnsLLMPQOdieEeamTZClX)
			{
				return -1;
			}
			return lgOZHChvEOXQfXJCsbgmbjMUvAWB[(int)keyCode];
		}

		[CustomObfuscation(rename = false)]
		internal void BakeMap(ControllerMap controllerMap)
		{
			if (controllerMap != null)
			{
				IList<ActionElementMap> list = controllerMap.tVVQZXmeiSGqPDWfAiktOetHVuiqA;
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					tdLKgiuKWlzkkJjXwztgjBdYXkPE(controllerMap, list[i]);
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal void BakeActionElementMap(ControllerMap controllerMap, ActionElementMap map)
		{
			map?.qpQzcYGEaMlrmdrWslIRXltfsMcp(controllerMap);
		}

		internal void qENDGkhZfxHawkzeHplTXuucaprC()
		{
			base.NQeVYgkqiwjcPfmLUdoKHfxQPBEL();
			nysLqyvtgsrpBdwTSGKHfyFTsSsA = ModifierKeyFlags.None;
			UEwfXSeLlQEujVLdTKNGMwkYzFsiA = ModifierKeyFlags.None;
		}

		internal bool xRDhqWqKAwhjbCFTlHWuLUsLDeEZA(bool P_0)
		{
			if (!base.mqVKPhaeRMzKymnkzsnkxIOdysds(P_0))
			{
				return false;
			}
			if (ndaXYHLadlqimagUolpmypHFlhfO is IGetSetEnabled)
			{
				(ndaXYHLadlqimagUolpmypHFlhfO as IGetSetEnabled).enabled = P_0;
			}
			return true;
		}

		private bool QWiLcdjyQebfXICEijuMnceoECRy(out Button P_0, out Button P_1, ModifierKey P_2)
		{
			P_0 = null;
			P_1 = null;
			switch (P_2)
			{
			case ModifierKey.None:
				return false;
			case ModifierKey.Control:
				P_0 = buttons[lgOZHChvEOXQfXJCsbgmbjMUvAWB[306]];
				P_1 = buttons[lgOZHChvEOXQfXJCsbgmbjMUvAWB[305]];
				return true;
			case ModifierKey.Alt:
				P_0 = buttons[lgOZHChvEOXQfXJCsbgmbjMUvAWB[308]];
				P_1 = buttons[lgOZHChvEOXQfXJCsbgmbjMUvAWB[307]];
				return true;
			case ModifierKey.Command:
				P_0 = buttons[lgOZHChvEOXQfXJCsbgmbjMUvAWB[310]];
				P_1 = buttons[lgOZHChvEOXQfXJCsbgmbjMUvAWB[309]];
				return true;
			case ModifierKey.Shift:
				P_0 = buttons[lgOZHChvEOXQfXJCsbgmbjMUvAWB[304]];
				P_1 = buttons[lgOZHChvEOXQfXJCsbgmbjMUvAWB[303]];
				return true;
			default:
				return false;
			}
		}

		private void FyJdJVelqHHjDhErQzTspPDRGlvlA()
		{
			ModifierKeyFlags modifierKeyFlags = ModifierKeyFlags.None;
			if (buttons[lgOZHChvEOXQfXJCsbgmbjMUvAWB[306]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftControl;
			}
			if (buttons[lgOZHChvEOXQfXJCsbgmbjMUvAWB[305]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightControl;
			}
			if (buttons[lgOZHChvEOXQfXJCsbgmbjMUvAWB[310]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftCommand;
			}
			if (buttons[lgOZHChvEOXQfXJCsbgmbjMUvAWB[309]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightCommand;
			}
			if (buttons[lgOZHChvEOXQfXJCsbgmbjMUvAWB[308]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftAlt;
			}
			if (buttons[lgOZHChvEOXQfXJCsbgmbjMUvAWB[307]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightAlt;
			}
			if (buttons[lgOZHChvEOXQfXJCsbgmbjMUvAWB[304]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.LeftShift;
			}
			if (buttons[lgOZHChvEOXQfXJCsbgmbjMUvAWB[303]].value)
			{
				modifierKeyFlags |= ModifierKeyFlags.RightShift;
			}
			nysLqyvtgsrpBdwTSGKHfyFTsSsA = modifierKeyFlags;
			UEwfXSeLlQEujVLdTKNGMwkYzFsiA = aTJGpZNZQqoEFgzSqaxyqmKkWXuD(modifierKeyFlags);
		}

		private string RlntYaZcgvUHdVtaPEajPtQrEaZj(ModifierKey P_0, bool P_1)
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
			if (!eKkdidMqeNQWasszsLhXlFfEaYbl.TryGetValue((int)P_0, out var value))
			{
				return result;
			}
			string result2;
			if (P_1)
			{
				if (value.OVYgqtdUsNedgSJLOxRlAtocYPmB != null && slAiEmMRATGCZKnnnGuLUDbQUTXg(value.OVYgqtdUsNedgSJLOxRlAtocYPmB, modifierKeyInfo.shortKey, modifierKeyInfo.shortName, qfUAjoZEkUJBMcgOHFRLtyQzKjdR.deviceLocalizationInfo, out result2))
				{
					return result2;
				}
				if (value.KbwOQfygiieUGGhnOjbFyZFBdTfKA != null && slAiEmMRATGCZKnnnGuLUDbQUTXg(value.KbwOQfygiieUGGhnOjbFyZFBdTfKA, modifierKeyInfo.longKey, modifierKeyInfo.longName, qfUAjoZEkUJBMcgOHFRLtyQzKjdR.deviceLocalizationInfo, out result2))
				{
					return result2;
				}
				return result;
			}
			if (value.KbwOQfygiieUGGhnOjbFyZFBdTfKA == null)
			{
				return result;
			}
			slAiEmMRATGCZKnnnGuLUDbQUTXg(value.KbwOQfygiieUGGhnOjbFyZFBdTfKA, modifierKeyInfo.longKey, modifierKeyInfo.longName, qfUAjoZEkUJBMcgOHFRLtyQzKjdR.deviceLocalizationInfo, out result2);
			return result2;
		}

		private static bool slAiEmMRATGCZKnnnGuLUDbQUTXg(JgTIWNLySlYbvyRgkyKhsafhYVke P_0, string P_1, string P_2, DeviceLocalizationInfo P_3, out string P_4)
		{
			LocalizationManager.GetAndUpdateLocalizedStringResultFlags getAndUpdateLocalizedStringResultFlags = RfUTDPxyvrJRnCbYKkuVrGRpezaF.agPakmRUSFnjKMPflMMJQvARCNRW(P_0.HFERkoJCheqVFMvAYpOwPPgRZtny, P_1, "controller", P_2, P_3, ILKhcCJzrmtoMHIdzHgcKloPCkpIA.Keyboard, -1, AxisRange.Full, -1, out P_4);
			if ((getAndUpdateLocalizedStringResultFlags & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
			{
				P_0.iFTRfIULStPXJJmOQNHjQEEmEQeM = (getAndUpdateLocalizedStringResultFlags & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.JustLocalized) != 0;
			}
			return P_0.iFTRfIULStPXJJmOQNHjQEEmEQeM;
		}

		private object jkakhmmfPFnNXMnPfhyhRrXMEMYd(ModifierKey P_0)
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
			if (!stiGLyRuulBEZTPxpyuteGsoevCr.TryGetValue((int)P_0, out var value))
			{
				return null;
			}
			if (EtaGwtomPKtUeQQpuCjDJPobjUfWA(value, modifierKeyInfo.longKey, qfUAjoZEkUJBMcgOHFRLtyQzKjdR.deviceLocalizationInfo, out var result))
			{
				return result;
			}
			return null;
		}

		private string rfhygOpHejKlFECvFWbYgRnleEPT(ModifierKey P_0)
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
			if (!stiGLyRuulBEZTPxpyuteGsoevCr.TryGetValue((int)P_0, out var value))
			{
				return null;
			}
			if (KtAAmmuANMhITLlQUfQaCPYlsrSbA(value, modifierKeyInfo.longKey, qfUAjoZEkUJBMcgOHFRLtyQzKjdR.deviceLocalizationInfo, out var result))
			{
				return result;
			}
			return null;
		}

		private static bool EtaGwtomPKtUeQQpuCjDJPobjUfWA(yHoZzYIlhHSmSVpSPcckKHuuLhRA P_0, string P_1, DeviceLocalizationInfo P_2, out object P_3)
		{
			GlyphManager.GetAndUpdateGlyphResultFlags getAndUpdateGlyphResultFlags = jXWJBvwkkEhPNhiAYEXNWGlggasIA.OTHZyPgXInChboubWiTnARTxGuBp(P_0.OfFCNbpduajTEGDLOtjNCrLLgkNF, P_1, "controller", P_2, ILKhcCJzrmtoMHIdzHgcKloPCkpIA.Keyboard, -1, AxisRange.Full, -1, out P_3);
			if ((getAndUpdateGlyphResultFlags & GlyphManager.GetAndUpdateGlyphResultFlags.Changed) != GlyphManager.GetAndUpdateGlyphResultFlags.None)
			{
				P_0.ugMtDtxuIQKGHxLwhkKLTUVcYtmK = (getAndUpdateGlyphResultFlags & GlyphManager.GetAndUpdateGlyphResultFlags.JustGot) != 0;
			}
			return P_0.ugMtDtxuIQKGHxLwhkKLTUVcYtmK;
		}

		private static bool KtAAmmuANMhITLlQUfQaCPYlsrSbA(yHoZzYIlhHSmSVpSPcckKHuuLhRA P_0, string P_1, DeviceLocalizationInfo P_2, out string P_3)
		{
			object obj;
			bool result = EtaGwtomPKtUeQQpuCjDJPobjUfWA(P_0, P_1, P_2, out obj);
			P_3 = P_0.OfFCNbpduajTEGDLOtjNCrLLgkNF.cachedKey;
			return result;
		}

		[CompilerGenerated]
		private void gHedlrktHlapFGApOixbFMZCDxJM()
		{
			IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
			for (int i = 0; i < values.Count; i++)
			{
				RlntYaZcgvUHdVtaPEajPtQrEaZj(values[i], true);
				RlntYaZcgvUHdVtaPEajPtQrEaZj(values[i], false);
			}
		}

		[CompilerGenerated]
		private void jXMfgYJIiTzpLKLWOMSfGCKrfHaO()
		{
			IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
			for (int i = 0; i < values.Count; i++)
			{
				jkakhmmfPFnNXMnPfhyhRrXMEMYd(values[i]);
			}
		}
	}
}
