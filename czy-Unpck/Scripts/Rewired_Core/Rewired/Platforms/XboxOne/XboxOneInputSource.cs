using System;
using System.Collections.Generic;
using Rewired.Platforms.Custom;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Platforms.XboxOne
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class XboxOneInputSource : CustomInputSource, IXboxOneInputSource
	{
		[CustomObfuscation(rename = false)]
		private enum BadConnectionReason
		{
			[CustomObfuscation(rename = false)]
			None = 0,
			[CustomObfuscation(rename = false)]
			GamepadNotActive = 1,
			[CustomObfuscation(rename = false)]
			InvalidName = 2
		}

		private struct fQcfCUALoXnpfYRHfJYwPyYjjNK
		{
			public uint cgjCRKNqDroLAfWifBbDTIhaUko;

			public uint XfObLdJAuaijeiyZzmTWDDFKLRs;

			public fQcfCUALoXnpfYRHfJYwPyYjjNK(uint unityJoystickId, uint connectedFrame)
			{
				cgjCRKNqDroLAfWifBbDTIhaUko = unityJoystickId;
				XfObLdJAuaijeiyZzmTWDDFKLRs = connectedFrame;
			}
		}

		private class NvhEfsEcrGNiaPghFVAwOBmokAId : Joystick
		{
			private const int HdwDFHEjYnWvNocUPRQUFfWDpFW = 6;

			private const int bIVKqEWQlcsQuBjQNcfTnhQBcMzH = 14;

			private const string usWfiQgGqOGLApbcHauTSidCFnn = "Xbox One Controller";

			private const int PcIVwiPcWiSJcrvPbSlzeauocXQF = 0;

			private const int oLtGoKqeuOlUoAIDPbJMOpojNEn = 1;

			private const int RtdvwFGjqFSqEMvtZBMskJzPbOg = 2;

			private const int cAZSNqaldAvNQHDNMcMJKvJZNUyT = 3;

			private const int reRNtsvpERCUVifdILTwSRSRDNU = 4;

			private const int KVhFrSBPibAdycLXlKPvQFWWScxU = 5;

			private const int cAQiopHDDjvJbLdLRDrNMPImmmP = 6;

			private const int RPPexnvixLakiFfnjmIrhAeAxwUG = 7;

			private const int hstVVueczRJarlVAfjadSpEAVGC = 8;

			private const int DwGKKEHGQIeNmfqZZqEqEzBeqjqG = 9;

			private const int iKjvuiEXEFiGpRCmXfEPFMTiytiA = 12;

			private const int hpzYzPmpatasmLKGrSVwzFMaHdRb = 13;

			private const int ZvscijuKwEXAITpjlQMjAswZKpZ = 14;

			private const int RxFmoRHiZVYBcgVzmJVudupQSXE = 15;

			private const int RIjCMHjvqCbSmWVBKPzEPTUQexcX = 0;

			private const int eSYczniXIwqhiNlCAbccTUkEzquU = 1;

			private const int dzxFoaRiogkOmEYYpJRpHcbQipxC = 3;

			private const int whoiSwlEJjpOtrCWcRfTXEOTrzY = 4;

			private const int ThQmcZGEBMzjwZpNVZYfuRuFVFs = 8;

			private const int oNLaJOYGVjjlMAcSVxIIYthUjPw = 9;

			private readonly IXboxOneInputSource IRTGlhOkWOimkumhYFSkdpOYbETD;

			private int FeaeSsBIvGENCmfHDJxvHHDdpYR;

			private ulong WlQzwIUIYJEegKkaUSoOEmcgfFrf;

			private string[] tJObTdSEfBpLeNOAseAIpenbQpf;

			public ulong xboxControllerId => WlQzwIUIYJEegKkaUSoOEmcgfFrf;

			public NvhEfsEcrGNiaPghFVAwOBmokAId(IXboxOneInputSource inputSource, ulong xboxControllerId, int unityJoystickId, bool isConnected)
				: base(isConnected ? UnityTools.externalTools.XboxOneInput_GetControllerType(xboxControllerId) : "Xbox One Controller", (long)xboxControllerId, unityJoystickId, 6, 14)
			{
				while (true)
				{
					int num = -231100811;
					while (true)
					{
						switch (num ^ -231100812)
						{
						case 0:
							break;
						case 1:
							goto IL_0048;
						case 2:
							FeaeSsBIvGENCmfHDJxvHHDdpYR = unityJoystickId - 1;
							tJObTdSEfBpLeNOAseAIpenbQpf = new string[6];
							IARnSHmwaoiJBwdfKdLYgtmlFDLS();
							base.extension = new XboxOneGamepadExtension(supportsVibration: true, inputSource);
							_isConnected = isConnected;
							if (_isConnected)
							{
								SdmfoteCDVoXNaSlWEvRMBbwmDy(xboxControllerId);
								return;
							}
							goto default;
						default:
							WlQzwIUIYJEegKkaUSoOEmcgfFrf = xboxControllerId;
							return;
						}
						break;
						IL_0048:
						IRTGlhOkWOimkumhYFSkdpOYbETD = inputSource;
						num = -231100810;
					}
				}
			}

			public virtual void GzCliicOSMFLMvKajLgvnmGSSrh()
			{
				if (!_isConnected)
				{
					return;
				}
				IList<Axis> axes = default(IList<Axis>);
				while (true)
				{
					IList<Button> buttons = base.Buttons;
					buttons[0].value = jFcZHuafkqlzijBvuFElJkopdfY(0);
					int num = -1683237246;
					while (true)
					{
						switch (num ^ -1683237238)
						{
						case 3:
							num = -1683237233;
							continue;
						case 0:
							buttons[7].value = jFcZHuafkqlzijBvuFElJkopdfY(7);
							buttons[8].value = jFcZHuafkqlzijBvuFElJkopdfY(8);
							num = -1683237235;
							continue;
						case 8:
							buttons[1].value = jFcZHuafkqlzijBvuFElJkopdfY(1);
							num = -1683237240;
							continue;
						case 7:
							buttons[9].value = jFcZHuafkqlzijBvuFElJkopdfY(9);
							buttons[10].value = jFcZHuafkqlzijBvuFElJkopdfY(12);
							buttons[11].value = jFcZHuafkqlzijBvuFElJkopdfY(15);
							buttons[12].value = jFcZHuafkqlzijBvuFElJkopdfY(13);
							num = -1683237236;
							continue;
						case 2:
							buttons[2].value = jFcZHuafkqlzijBvuFElJkopdfY(2);
							buttons[3].value = jFcZHuafkqlzijBvuFElJkopdfY(3);
							buttons[4].value = jFcZHuafkqlzijBvuFElJkopdfY(4);
							num = -1683237245;
							continue;
						case 9:
							buttons[5].value = jFcZHuafkqlzijBvuFElJkopdfY(5);
							num = -1683237237;
							continue;
						case 6:
							buttons[13].value = jFcZHuafkqlzijBvuFElJkopdfY(14);
							axes = base.Axes;
							axes[0].value = Input.GetAxisRaw(tJObTdSEfBpLeNOAseAIpenbQpf[0]);
							num = -1683237234;
							continue;
						case 1:
							buttons[6].value = jFcZHuafkqlzijBvuFElJkopdfY(6);
							num = -1683237238;
							continue;
						case 5:
							break;
						default:
							axes[1].value = Input.GetAxisRaw(tJObTdSEfBpLeNOAseAIpenbQpf[1]);
							axes[2].value = Input.GetAxisRaw(tJObTdSEfBpLeNOAseAIpenbQpf[2]);
							axes[3].value = Input.GetAxisRaw(tJObTdSEfBpLeNOAseAIpenbQpf[3]);
							axes[4].value = Input.GetAxisRaw(tJObTdSEfBpLeNOAseAIpenbQpf[4]);
							axes[5].value = Input.GetAxisRaw(tJObTdSEfBpLeNOAseAIpenbQpf[5]);
							return;
						}
						break;
					}
				}
			}

			public void SdmfoteCDVoXNaSlWEvRMBbwmDy(ulong P_0)
			{
				if (_isConnected)
				{
					return;
				}
				while (true)
				{
					_isConnected = true;
					WlQzwIUIYJEegKkaUSoOEmcgfFrf = P_0;
					base.systemId = (long)P_0;
					int num = -275204632;
					while (true)
					{
						switch (num ^ -275204629)
						{
						case 0:
							goto IL_0009;
						case 1:
							break;
						case 3:
							if (UnityTools.externalTools.XboxOneInput_GetJoystickId(P_0) != (uint)base.unityId)
							{
								Logger.LogError("Unity joystick id does not match expected id!");
								_isConnected = false;
								return;
							}
							goto default;
						default:
							dHfFdAFdXwGmnUMjzIdYADgaGzoi();
							return;
						}
						break;
						IL_0009:
						num = -275204630;
					}
				}
			}

			private void dHfFdAFdXwGmnUMjzIdYADgaGzoi()
			{
				if (_isConnected)
				{
					_deviceName = UnityTools.externalTools.XboxOneInput_GetControllerType(WlQzwIUIYJEegKkaUSoOEmcgfFrf);
				}
				_customName = "Controller " + base.unityId;
			}

			private bool jFcZHuafkqlzijBvuFElJkopdfY(int P_0)
			{
				int key = 350 + P_0 + FeaeSsBIvGENCmfHDJxvHHDdpYR * 20;
				return Input.GetKey((KeyCode)key);
			}

			private void IARnSHmwaoiJBwdfKdLYgtmlFDLS()
			{
				tJObTdSEfBpLeNOAseAIpenbQpf[0] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 0);
				tJObTdSEfBpLeNOAseAIpenbQpf[1] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 1);
				tJObTdSEfBpLeNOAseAIpenbQpf[2] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 3);
				tJObTdSEfBpLeNOAseAIpenbQpf[3] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 4);
				tJObTdSEfBpLeNOAseAIpenbQpf[4] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 8);
				while (true)
				{
					int num = -1771419452;
					while (true)
					{
						switch (num ^ -1771419450)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_0082;
						case 1:
							return;
						}
						break;
						IL_0082:
						tJObTdSEfBpLeNOAseAIpenbQpf[5] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 9);
						num = -1771419449;
					}
				}
			}
		}

		private const int ORaFQrJVorgzyMXapbxVBuRYnOC = 8;

		private readonly bool UUnypIIfQihusKKsRGbhsEYxCLL;

		private bool vRNKYjJscLZsGKpOLDXFfYnjOV;

		private Queue<fQcfCUALoXnpfYRHfJYwPyYjjNK> MVRKUiFhwixcUhMyDnzoIEcHIrp;

		private bool xRygqjRmTtURDPiwlgMmFcdNBrr;

		public override bool isReady => UUnypIIfQihusKKsRGbhsEYxCLL;

		public XboxOneInputSource()
			: base(21)
		{
			try
			{
				MVRKUiFhwixcUhMyDnzoIEcHIrp = new Queue<fQcfCUALoXnpfYRHfJYwPyYjjNK>();
				base.useApproximateMatching = false;
				for (int i = 0; i < 8; i++)
				{
					int num = i + 1;
					BadConnectionReason badConnectionReason;
					bool flag = qrfgjpfIzoHgINsSVqpadzcrxYOy((uint)num, true, out badConnectionReason);
					ulong xboxControllerId = (flag ? UnityTools.externalTools.XboxOneInput_GetControllerId((uint)num) : 0);
					AddJoystick(new NvhEfsEcrGNiaPghFVAwOBmokAId(this, xboxControllerId, num, flag)
					{
						supportsVibration = true
					});
				}
				UnityTools.externalTools.XboxOneInput_OnGamepadStateChange += GwmWMpFTDNBxPPVKUbhaTSJZyIZ;
				UUnypIIfQihusKKsRGbhsEYxCLL = true;
			}
			catch
			{
			}
		}

		public override void Update()
		{
			if (!UUnypIIfQihusKKsRGbhsEYxCLL)
			{
				goto IL_0008;
			}
			goto IL_003e;
			IL_0008:
			int num = 1738233235;
			goto IL_000d;
			IL_000d:
			IList<Joystick> joysticks = default(IList<Joystick>);
			int num2 = default(int);
			int count = default(int);
			while (true)
			{
				switch (num ^ 0x679B5592)
				{
				case 3:
					break;
				default:
					return;
				case 1:
					return;
				case 4:
					goto IL_003e;
				case 6:
					goto IL_005c;
				case 0:
					joysticks[num2].Update();
					num2++;
					num = 1738233236;
					continue;
				case 5:
					count = joysticks.Count;
					num2 = 0;
					num = 1738233236;
					continue;
				case 2:
					return;
				}
				break;
				IL_005c:
				int num3;
				if (num2 < count)
				{
					num = 1738233234;
					num3 = num;
				}
				else
				{
					num = 1738233232;
					num3 = num;
				}
			}
			goto IL_0008;
			IL_003e:
			LbVjsxaWBIqFnnCKoCWJNdnWtlD();
			UnityTools.externalTools.XboxOne_Gamepad_UpdatePlugin();
			joysticks = GetJoysticks();
			num = 1738233239;
			goto IL_000d;
		}

		private void GwmWMpFTDNBxPPVKUbhaTSJZyIZ(uint P_0, bool P_1)
		{
			if (!UUnypIIfQihusKKsRGbhsEYxCLL)
			{
				return;
			}
			while (true)
			{
				if (P_0 == 0)
				{
					Logger.LogError("Invalid unity joystick id");
					break;
				}
				while (true)
				{
					IL_006e:
					if (P_1)
					{
						if (qrfgjpfIzoHgINsSVqpadzcrxYOy(P_0, true, out var _))
						{
							iumCFsgNEsRGxGlXEGEXGgjDfvi(P_0, true);
						}
						return;
					}
					while (true)
					{
						IL_008d:
						int index = (int)(P_0 - 1);
						int num = 704966904;
						while (true)
						{
							switch (num ^ 0x2A04F0FA)
							{
							case 5:
								num = 704966910;
								continue;
							default:
								return;
							case 4:
								break;
							case 2:
							{
								NvhEfsEcrGNiaPghFVAwOBmokAId nvhEfsEcrGNiaPghFVAwOBmokAId = GetJoysticks()[index] as NvhEfsEcrGNiaPghFVAwOBmokAId;
								nvhEfsEcrGNiaPghFVAwOBmokAId.Disconnect();
								OnJoystickDisconnected();
								num = 704966905;
								continue;
							}
							case 1:
								goto IL_006e;
							case 0:
								goto IL_008d;
							case 3:
								return;
							}
							break;
						}
						break;
					}
					break;
				}
			}
		}

		private void iumCFsgNEsRGxGlXEGEXGgjDfvi(uint P_0, bool P_1)
		{
			int index = (int)(P_0 - 1);
			NvhEfsEcrGNiaPghFVAwOBmokAId nvhEfsEcrGNiaPghFVAwOBmokAId = GetJoysticks()[index] as NvhEfsEcrGNiaPghFVAwOBmokAId;
			ulong num = UnityTools.externalTools.XboxOneInput_GetControllerId(P_0);
			nvhEfsEcrGNiaPghFVAwOBmokAId.SdmfoteCDVoXNaSlWEvRMBbwmDy(num);
			if (P_1)
			{
				OnJoystickConnected();
			}
		}

		private void LbVjsxaWBIqFnnCKoCWJNdnWtlD()
		{
			int num = MVRKUiFhwixcUhMyDnzoIEcHIrp.Count;
			fQcfCUALoXnpfYRHfJYwPyYjjNK item = default(fQcfCUALoXnpfYRHfJYwPyYjjNK);
			uint currentFrame = default(uint);
			bool flag = default(bool);
			while (true)
			{
				int num2 = -1735135979;
				while (true)
				{
					switch (num2 ^ -1735135977)
					{
					case 8:
						break;
					default:
						return;
					case 9:
						MVRKUiFhwixcUhMyDnzoIEcHIrp.Enqueue(item);
						num2 = -1735135982;
						continue;
					case 4:
						OnJoystickConnected();
						num2 = -1735135971;
						continue;
					case 5:
						num--;
						num2 = -1735135977;
						continue;
					case 1:
						num2 = -1735135982;
						continue;
					case 11:
					{
						item = MVRKUiFhwixcUhMyDnzoIEcHIrp.Dequeue();
						int num4;
						if (currentFrame < item.XfObLdJAuaijeiyZzmTWDDFKLRs + 1)
						{
							num2 = -1735135970;
							num4 = num2;
						}
						else
						{
							num2 = -1735135984;
							num4 = num2;
						}
						continue;
					}
					case 12:
						currentFrame = ReInput.time.currentFrame;
						num2 = -1735135980;
						continue;
					case 6:
						flag = false;
						num2 = -1735135973;
						continue;
					case 2:
						if (num == 0)
						{
							return;
						}
						goto case 6;
					case 3:
						num2 = -1735135977;
						continue;
					case 0:
						if (num <= 0)
						{
							int num3;
							if (!flag)
							{
								num2 = -1735135971;
								num3 = num2;
							}
							else
							{
								num2 = -1735135981;
								num3 = num2;
							}
							continue;
						}
						goto case 11;
					case 7:
					{
						if (qrfgjpfIzoHgINsSVqpadzcrxYOy(item.cgjCRKNqDroLAfWifBbDTIhaUko, true, out var _))
						{
							iumCFsgNEsRGxGlXEGEXGgjDfvi(item.cgjCRKNqDroLAfWifBbDTIhaUko, false);
							flag = true;
							num2 = -1735135978;
							continue;
						}
						goto case 5;
					}
					case 10:
						return;
					}
					break;
				}
			}
		}

		private bool qrfgjpfIzoHgINsSVqpadzcrxYOy(uint P_0, bool P_1, out BadConnectionReason P_2)
		{
			if (!UnityTools.externalTools.XboxOneInput_IsGamepadActive(P_0))
			{
				P_2 = BadConnectionReason.GamepadNotActive;
				goto IL_0010;
			}
			string text = UnityTools.externalTools.XboxOneInput_GetControllerType(UnityTools.externalTools.XboxOneInput_GetControllerId(P_0));
			int num = -843639020;
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num ^ -843639017)
				{
				case 0:
					break;
				case 5:
					if (text == " ")
					{
						num = -843639021;
						continue;
					}
					P_2 = BadConnectionReason.None;
					return true;
				case 4:
					if (P_1)
					{
						MVRKUiFhwixcUhMyDnzoIEcHIrp.Enqueue(new fQcfCUALoXnpfYRHfJYwPyYjjNK(P_0, ReInput.time.currentFrame));
						num = -843639019;
						continue;
					}
					goto default;
				case 1:
					return false;
				case 3:
				{
					int num2;
					if (!string.IsNullOrEmpty(text))
					{
						num = -843639022;
						num2 = num;
					}
					else
					{
						num = -843639021;
						num2 = num;
					}
					continue;
				}
				default:
					P_2 = BadConnectionReason.InvalidName;
					return false;
				}
				break;
			}
			goto IL_0010;
			IL_0010:
			num = -843639018;
			goto IL_0015;
		}

		private void wkwPYIRGgSgqGKWsyzpfTMPIYll()
		{
			if (vRNKYjJscLZsGKpOLDXFfYnjOV)
			{
				while (true)
				{
					switch (0x5805C655 ^ 0x5805C654)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			vRNKYjJscLZsGKpOLDXFfYnjOV = true;
			Logger.LogError("A required native library is missing! See documentation for Xbox One installation instructions.");
		}

		public int GetXboxOneUserIdFromUnityJoystick(int unityJoystickId)
		{
			if (!UUnypIIfQihusKKsRGbhsEYxCLL)
			{
				return -1;
			}
			return UnityTools.externalTools.XboxOneInput_GetUserIdForGamepad((uint)unityJoystickId);
		}

		public void PulseVibrateMotor(ulong xboxOneJoystickId, XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
			if (UUnypIIfQihusKKsRGbhsEYxCLL)
			{
				ulong durationMS = (ulong)(duration * 1000f);
				UnityTools.externalTools.XboxOne_Gamepad_PulseVibrateMotor(xboxOneJoystickId, (int)motor, startLevel, endLevel, durationMS);
			}
		}

		public bool SetXboxOneVibration(ulong xboxOneJoystickId, fuZrdLLYfsbiIDndZbyZiLEjiMX vibration)
		{
			if (!UUnypIIfQihusKKsRGbhsEYxCLL)
			{
				return false;
			}
			return UnityTools.externalTools.XboxOne_Gamepad_SetGamepadVibration(xboxOneJoystickId, vibration.ZTRwmqcDYuawIFdUyiEvDZOHpXgi, vibration.VxZgBTvLcLhDLpcLzUhWPMfElMe, vibration.HYwUfjBbbOpvGLyiZFSajsPZAQS, vibration.WGbNQbRcuRIWFXqkkqqBXtxACGu);
		}

		public override void Dispose()
		{
			base.Dispose();
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~XboxOneInputSource()
		{
			Dispose(disposing: false);
		}

		protected override void Dispose(bool disposing)
		{
			if (xRygqjRmTtURDPiwlgMmFcdNBrr)
			{
				return;
			}
			while (disposing)
			{
				UnityTools.externalTools.XboxOneInput_OnGamepadStateChange -= GwmWMpFTDNBxPPVKUbhaTSJZyIZ;
				int num = 917861152;
				while (true)
				{
					switch (num ^ 0x36B57321)
					{
					case 0:
						num = 917861155;
						continue;
					case 2:
						break;
					default:
						goto end_IL_0027;
					}
					break;
				}
				continue;
				end_IL_0027:
				break;
			}
			xRygqjRmTtURDPiwlgMmFcdNBrr = true;
		}
	}
}
