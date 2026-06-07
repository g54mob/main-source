using System;
using Rewired.Utils;

namespace Rewired
{
	public sealed class CustomController : ControllerWithAxes
	{
		private int _sourceControllerId;

		private Func<int, float> axisUpdateCallback;

		private Func<int, bool> buttonUpdateCallback;

		private bool useUpdateCallbacks;

		private Guid _deviceInstanceGuid;

		public int sourceControllerId
		{
			get
			{
				return _sourceControllerId;
			}
		}

		public override Guid deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return Guid.Empty;
				}
				return _deviceInstanceGuid;
			}
		}

		internal CustomController(kSarBqLUpbjSYJYRRnTdWDHCPuD data)
			: this(data.YZYerWLyrZezITIzzsjvGpplKQw, data.vuToNXjJNzINjbcxQPiHIIiUPZb, data.nrRGcDtTrsjNDnwfdqSbSUqyNkC, data.WVeuvvGVKxuwIVofyhIJOpLcDjb, data.MMbWxTmxKwcWWMhVwLNlEkYBAMS, data.qavxNgFSMXrtkmTbLrBlcGAYqOV, data.rFUeqRiFdjyAEcgvioRQEeBxRMiT, data.TwhUkSEboxGPsJgqbpmupSCMcvva, data.SgYwVaEgtCZiUkgVDcTwJWbyDTtb, data.LsVaVuksnFAOffJvSNKbyOxlzXL, null, new ControllerDataUpdater(data.WVeuvvGVKxuwIVofyhIJOpLcDjb, data.TwhUkSEboxGPsJgqbpmupSCMcvva, data.SgYwVaEgtCZiUkgVDcTwJWbyDTtb, null))
		{
		}

		private CustomController(int controllerId, int sourceControllerId, Guid hardwareTypeGuid, InputSource inputSource, string name, string hardwareName, string hardwareIdentifier, int axisCount, int buttonCount, HardwareControllerMap_Game hardwareMap, Extension extension, ControllerDataUpdater dataUpdater)
			: base(controllerId, inputSource, name, hardwareName, hardwareIdentifier, ControllerType.Custom, hardwareTypeGuid, axisCount, buttonCount, null, hardwareMap, extension, dataUpdater)
		{
			_sourceControllerId = sourceControllerId;
			_deviceInstanceGuid = MiscTools.CreateGuidHashSHA1("CustomController device instance GUID: sourceId = " + _sourceControllerId + ", controllerId = " + controllerId);
			snpHjGkGVogejiySyWIFjoJWDLTS();
		}

		internal void FillData()
		{
			if (!useUpdateCallbacks)
			{
				return;
			}
			int num = default(int);
			int num3 = default(int);
			while (true)
			{
				int num2;
				if (axisUpdateCallback != null)
				{
					num = 0;
					num2 = 2021246379;
					goto IL_000e;
				}
				goto IL_0095;
				IL_000e:
				while (true)
				{
					switch (num2 ^ 0x7879C5AE)
					{
					case 0:
						num2 = 2021246377;
						continue;
					default:
						return;
					case 2:
						num3++;
						num2 = 2021246376;
						continue;
					case 6:
						break;
					case 7:
						goto end_IL_000e;
					case 5:
						goto IL_0078;
					case 3:
						goto IL_0095;
					case 8:
						ybiZyKuVmvsrOHqZzdmfwidXkdm.buttonValues[num3] = buttonUpdateCallback(num3);
						num2 = 2021246380;
						continue;
					case 1:
						ybiZyKuVmvsrOHqZzdmfwidXkdm.axisValues[num] = axisUpdateCallback(num);
						num++;
						num2 = 2021246379;
						continue;
					case 4:
						return;
					}
					int num4;
					if (num3 < _buttonCount)
					{
						num2 = 2021246374;
						num4 = num2;
					}
					else
					{
						num2 = 2021246378;
						num4 = num2;
					}
					continue;
					IL_0078:
					int num5;
					if (num < _axisCount)
					{
						num2 = 2021246383;
						num5 = num2;
					}
					else
					{
						num2 = 2021246381;
						num5 = num2;
					}
					continue;
					end_IL_000e:
					break;
				}
				continue;
				IL_0095:
				if (buttonUpdateCallback != null)
				{
					num3 = 0;
					num2 = 2021246376;
					goto IL_000e;
				}
				break;
			}
		}

		public void SetAxisValue(int index, float value)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return;
			}
			while (base.enabled)
			{
				while (true)
				{
					IL_0050:
					if (index >= 0)
					{
						int num;
						int num2;
						if (index >= _axisCount)
						{
							num = -1448002387;
							num2 = num;
						}
						else
						{
							num = -1448002390;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -1448002391)
							{
							case 0:
								num = -1448002389;
								continue;
							case 2:
								break;
							case 1:
								goto IL_0050;
							case 4:
								goto IL_006e;
							default:
								ybiZyKuVmvsrOHqZzdmfwidXkdm.axisValues[index] = value;
								return;
							}
							break;
						}
						break;
					}
					goto IL_006e;
					IL_006e:
					Logger.LogWarning(index + " is not a valid Axis index.");
					return;
				}
			}
		}

		public void SetAxisValue(string elementName, float value)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			goto IL_0069;
			IL_0093:
			int axisIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetAxisIndex(elementName);
			int num;
			int num2;
			if (axisIndex < 0)
			{
				num = 341152933;
				num2 = num;
			}
			else
			{
				num = 341152929;
				num2 = num;
			}
			goto IL_001e;
			IL_0019:
			num = 341152932;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ 0x145594A7)
				{
				case 4:
					break;
				case 2:
					Logger.LogWarning("\"" + axisIndex + "\" is not a valid Axis name.");
					return;
				case 0:
					goto IL_0069;
				case 6:
					goto IL_0079;
				case 1:
					goto IL_0093;
				case 3:
					return;
				default:
					ybiZyKuVmvsrOHqZzdmfwidXkdm.axisValues[axisIndex] = value;
					return;
				}
				break;
				IL_0079:
				int num3;
				if (axisIndex < _axisCount)
				{
					num = 341152930;
					num3 = num;
				}
				else
				{
					num = 341152933;
					num3 = num;
				}
			}
			goto IL_0019;
			IL_0069:
			if (!base.enabled)
			{
				return;
			}
			goto IL_0093;
		}

		public void SetAxisValueById(int elementId, float value)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_001c;
			}
			goto IL_00b3;
			IL_0072:
			int axisIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetAxisIndex(elementId);
			int num = 2087565986;
			goto IL_0021;
			IL_001c:
			num = 2087565985;
			goto IL_0021;
			IL_0021:
			while (true)
			{
				switch (num ^ 0x7C6DBAA6)
				{
				case 5:
					break;
				default:
					return;
				case 8:
					Logger.LogWarning(elementId + " is not a valid Axis id.");
					return;
				case 0:
					goto IL_0072;
				case 4:
					goto IL_0086;
				case 6:
					ybiZyKuVmvsrOHqZzdmfwidXkdm.axisValues[axisIndex] = value;
					num = 2087565988;
					continue;
				case 1:
					goto IL_00b3;
				case 7:
					return;
				case 3:
					goto IL_00d1;
				case 2:
					return;
				}
				break;
				IL_00d1:
				int num2;
				if (axisIndex >= _axisCount)
				{
					num = 2087565998;
					num2 = num;
				}
				else
				{
					num = 2087565984;
					num2 = num;
				}
				continue;
				IL_0086:
				int num3;
				if (axisIndex < 0)
				{
					num = 2087565998;
					num3 = num;
				}
				else
				{
					num = 2087565989;
					num3 = num;
				}
			}
			goto IL_001c;
			IL_00b3:
			if (!base.enabled)
			{
				return;
			}
			goto IL_0072;
		}

		public void SetButtonValue(int index, bool value)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			goto IL_0073;
			IL_000d:
			int num = 979066232;
			goto IL_0012;
			IL_0012:
			switch (num ^ 0x3A5B5D79)
			{
			case 4:
				break;
			case 1:
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return;
			case 0:
				goto IL_004f;
			case 5:
				return;
			case 3:
				goto IL_0073;
			case 6:
				goto IL_0083;
			default:
				ybiZyKuVmvsrOHqZzdmfwidXkdm.buttonValues[index] = value;
				return;
			}
			goto IL_000d;
			IL_004f:
			Logger.LogWarning(index + " is not a valid Button index.");
			num = 979066236;
			goto IL_0012;
			IL_0073:
			if (!base.enabled)
			{
				return;
			}
			goto IL_0083;
			IL_0083:
			if (index >= 0)
			{
				int num2;
				if (index >= _buttonCount)
				{
					num = 979066233;
					num2 = num;
				}
				else
				{
					num = 979066235;
					num2 = num;
				}
				goto IL_0012;
			}
			goto IL_004f;
		}

		public void SetButtonValue(string elementName, bool value)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			goto IL_0068;
			IL_000d:
			int num = 719686223;
			goto IL_0012;
			IL_0012:
			int buttonIndex = default(int);
			while (true)
			{
				switch (num ^ 0x2AE58A4C)
				{
				case 6:
					break;
				case 4:
					Logger.LogWarning("\"" + buttonIndex + "\" is not a valid Button name.");
					return;
				case 1:
					return;
				case 0:
					goto IL_0068;
				case 3:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return;
				case 2:
					buttonIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetButtonIndex(elementName);
					if (buttonIndex < 0)
					{
						goto case 4;
					}
					goto IL_00a9;
				default:
					ybiZyKuVmvsrOHqZzdmfwidXkdm.buttonValues[buttonIndex] = value;
					return;
				}
				break;
				IL_00a9:
				int num2;
				if (buttonIndex >= _buttonCount)
				{
					num = 719686216;
					num2 = num;
				}
				else
				{
					num = 719686217;
					num2 = num;
				}
			}
			goto IL_000d;
			IL_0068:
			int num3;
			if (base.enabled)
			{
				num = 719686222;
				num3 = num;
			}
			else
			{
				num = 719686221;
				num3 = num;
			}
			goto IL_0012;
		}

		public void SetButtonValueById(int elementId, bool value)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			goto IL_007c;
			IL_000d:
			int num = 589382618;
			goto IL_0012;
			IL_0012:
			int buttonIndex = default(int);
			while (true)
			{
				switch (num ^ 0x232143D9)
				{
				case 5:
					break;
				default:
					return;
				case 6:
					goto IL_004a;
				case 2:
					ybiZyKuVmvsrOHqZzdmfwidXkdm.buttonValues[buttonIndex] = value;
					num = 589382608;
					continue;
				case 8:
					return;
				case 4:
					goto IL_007c;
				case 3:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return;
				case 0:
					Logger.LogWarning(elementId + " is not a valid Button id.");
					return;
				case 1:
					buttonIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetButtonIndex(elementId);
					num = 589382623;
					continue;
				case 7:
					goto IL_00e6;
				case 9:
					return;
				}
				break;
				IL_00e6:
				int num2;
				if (buttonIndex >= _buttonCount)
				{
					num = 589382617;
					num2 = num;
				}
				else
				{
					num = 589382619;
					num2 = num;
				}
				continue;
				IL_004a:
				int num3;
				if (buttonIndex < 0)
				{
					num = 589382617;
					num3 = num;
				}
				else
				{
					num = 589382622;
					num3 = num;
				}
			}
			goto IL_000d;
			IL_007c:
			int num4;
			if (base.enabled)
			{
				num = 589382616;
				num4 = num;
			}
			else
			{
				num = 589382609;
				num4 = num;
			}
			goto IL_0012;
		}

		public void SetAxisUpdateCallback(Func<int, float> callback)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return;
			}
			while (true)
			{
				axisUpdateCallback = callback;
				if (useUpdateCallbacks)
				{
					break;
				}
				useUpdateCallbacks = true;
				int num = -1140446844;
				while (true)
				{
					switch (num ^ -1140446844)
					{
					case 2:
						goto IL_001a;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_001a:
					num = -1140446843;
				}
			}
		}

		public void SetButtonUpdateCallback(Func<int, bool> callback)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return;
			}
			while (true)
			{
				buttonUpdateCallback = callback;
				if (useUpdateCallbacks)
				{
					break;
				}
				useUpdateCallbacks = true;
				int num = -1951533392;
				while (true)
				{
					switch (num ^ -1951533390)
					{
					case 0:
						goto IL_001a;
					default:
						return;
					case 1:
						break;
					case 2:
						return;
					}
					break;
					IL_001a:
					num = -1951533389;
				}
			}
		}

		public void ClearAxisValue(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return;
			}
			while (base.enabled)
			{
				while (true)
				{
					IL_005d:
					if (index >= 0)
					{
						int num;
						int num2;
						if (index >= _axisCount)
						{
							num = 2031727995;
							num2 = num;
						}
						else
						{
							num = 2031727999;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x7919B57F)
							{
							case 3:
								num = 2031727998;
								continue;
							case 4:
								break;
							case 2:
								goto IL_005d;
							case 1:
								goto end_IL_005d;
							default:
							{
								float num3 = ((_calibrationMap != null) ? _calibrationMap.GetAxis(index).calibratedZero : 0f);
								ybiZyKuVmvsrOHqZzdmfwidXkdm.axisValues[index] = num3;
								return;
							}
							}
							break;
						}
					}
					Logger.LogWarning(index + " is not a valid Axis index.");
					return;
					continue;
					end_IL_005d:
					break;
				}
			}
		}

		public void ClearAxisValue(string elementName)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			goto IL_0084;
			IL_000d:
			int num = 687916349;
			goto IL_0012;
			IL_0012:
			int axisIndex = default(int);
			while (true)
			{
				switch (num ^ 0x2900C53F)
				{
				case 4:
					break;
				case 1:
					Logger.LogWarning("\"" + axisIndex + "\" is not a valid Axis name.");
					return;
				case 7:
					return;
				case 5:
					axisIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetAxisIndex(elementName);
					num = 687916351;
					continue;
				case 3:
					goto IL_0084;
				case 2:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					num = 687916344;
					continue;
				case 0:
					if (axisIndex < 0)
					{
						goto case 1;
					}
					goto IL_00ba;
				case 8:
					return;
				default:
					ClearAxisValue(axisIndex);
					return;
				}
				break;
				IL_00ba:
				int num2;
				if (axisIndex < _axisCount)
				{
					num = 687916345;
					num2 = num;
				}
				else
				{
					num = 687916350;
					num2 = num;
				}
			}
			goto IL_000d;
			IL_0084:
			int num3;
			if (base.enabled)
			{
				num = 687916346;
				num3 = num;
			}
			else
			{
				num = 687916343;
				num3 = num;
			}
			goto IL_0012;
		}

		public void ClearAxisValueById(int elementId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_001c;
			}
			goto IL_00a1;
			IL_0052:
			int axisIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetAxisIndex(elementId);
			int num = 780987254;
			goto IL_0021;
			IL_001c:
			num = 780987252;
			goto IL_0021;
			IL_0021:
			while (true)
			{
				switch (num ^ 0x2E8CEB75)
				{
				case 4:
					break;
				case 1:
					return;
				case 6:
					goto IL_0052;
				case 5:
					Logger.LogWarning(elementId + " is not a valid Axis id.");
					return;
				case 3:
					if (axisIndex < 0)
					{
						goto case 5;
					}
					goto IL_0087;
				case 2:
					goto IL_00a1;
				default:
					ClearAxisValue(axisIndex);
					return;
				}
				break;
				IL_0087:
				int num2;
				if (axisIndex >= _axisCount)
				{
					num = 780987248;
					num2 = num;
				}
				else
				{
					num = 780987253;
					num2 = num;
				}
			}
			goto IL_001c;
			IL_00a1:
			if (!base.enabled)
			{
				return;
			}
			goto IL_0052;
		}

		public void ClearButtonValue(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_001c;
			}
			goto IL_0095;
			IL_0095:
			int num;
			int num2;
			if (!base.enabled)
			{
				num = 1384822503;
				num2 = num;
			}
			else
			{
				num = 1384822499;
				num2 = num;
			}
			goto IL_0021;
			IL_001c:
			num = 1384822496;
			goto IL_0021;
			IL_0021:
			while (true)
			{
				switch (num ^ 0x528AB6E6)
				{
				case 0:
					break;
				case 1:
					return;
				case 3:
					Logger.LogWarning(index + " is not a valid Button index.");
					return;
				case 5:
					if (index < 0)
					{
						goto case 3;
					}
					goto IL_0073;
				case 6:
					return;
				case 4:
					goto IL_0095;
				default:
					ybiZyKuVmvsrOHqZzdmfwidXkdm.buttonValues[index] = false;
					ybiZyKuVmvsrOHqZzdmfwidXkdm.buttonPressureValues[index] = 0f;
					return;
				}
				break;
				IL_0073:
				int num3;
				if (index >= _buttonCount)
				{
					num = 1384822501;
					num3 = num;
				}
				else
				{
					num = 1384822500;
					num3 = num;
				}
			}
			goto IL_001c;
		}

		public void ClearButtonValue(string elementName)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			goto IL_005a;
			IL_000d:
			int num = 2126861912;
			goto IL_0012;
			IL_0012:
			int buttonIndex = default(int);
			while (true)
			{
				switch (num ^ 0x7EC5565C)
				{
				case 0:
					break;
				case 1:
					goto IL_0046;
				case 5:
					goto IL_005a;
				case 3:
					goto IL_006a;
				case 4:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					num = 2126861908;
					continue;
				case 8:
					return;
				case 7:
					goto IL_00a5;
				case 6:
					Logger.LogWarning("\"" + buttonIndex + "\" is not a valid Button name.");
					return;
				default:
					ClearButtonValue(buttonIndex);
					return;
				}
				break;
				IL_00a5:
				int num2;
				if (buttonIndex >= 0)
				{
					num = 2126861919;
					num2 = num;
				}
				else
				{
					num = 2126861914;
					num2 = num;
				}
				continue;
				IL_006a:
				int num3;
				if (buttonIndex >= _buttonCount)
				{
					num = 2126861914;
					num3 = num;
				}
				else
				{
					num = 2126861918;
					num3 = num;
				}
			}
			goto IL_000d;
			IL_005a:
			if (!base.enabled)
			{
				return;
			}
			goto IL_0046;
			IL_0046:
			buttonIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetButtonIndex(elementName);
			num = 2126861915;
			goto IL_0012;
		}

		public void ClearButtonValueById(int elementId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			goto IL_0070;
			IL_000d:
			int num = 576963415;
			goto IL_0012;
			IL_0012:
			int buttonIndex = default(int);
			while (true)
			{
				switch (num ^ 0x2263C353)
				{
				case 7:
					break;
				case 2:
					goto IL_0042;
				case 3:
					goto IL_005c;
				case 0:
					goto IL_0070;
				case 1:
					goto IL_0080;
				case 4:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return;
				case 6:
					Logger.LogWarning(elementId + " is not a valid Button id.");
					return;
				default:
					ClearButtonValue(buttonIndex);
					return;
				}
				break;
				IL_0080:
				int num2;
				if (buttonIndex >= 0)
				{
					num = 576963409;
					num2 = num;
				}
				else
				{
					num = 576963413;
					num2 = num;
				}
				continue;
				IL_0042:
				int num3;
				if (buttonIndex < _buttonCount)
				{
					num = 576963414;
					num3 = num;
				}
				else
				{
					num = 576963413;
					num3 = num;
				}
			}
			goto IL_000d;
			IL_0070:
			if (!base.enabled)
			{
				return;
			}
			goto IL_005c;
			IL_005c:
			buttonIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetButtonIndex(elementId);
			num = 576963410;
			goto IL_0012;
		}
	}
}
