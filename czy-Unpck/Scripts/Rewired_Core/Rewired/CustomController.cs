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

		public int sourceControllerId => _sourceControllerId;

		public override Guid deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return Guid.Empty;
				}
				return _deviceInstanceGuid;
			}
		}

		internal CustomController(gRkhIkZmWhiFsWWreyOyrrlNsjt data)
			: this(data.UKCDHORBCFHBoYLTIFGoDfJwMEGs, data.dMLvOHnSyvaMRsfCrfmGjKwFJVL, data.npTbYRtEOyhplyNZKAfaHlInTuqH, data.QhiXIzSBnzSGaWwDVddQlyhdvkF, data.QRjtmXoRMaFOuRnBPiyKhJYUVUo, data.eljtncJIlHPyIbsJcoSaVogBOjz, data.tYAFBJEJtsymrXHTcEZPbTaOjI, data.RGhWgMAfPjfICjXGWTZxnPoNdWD, data.SeOhWaCQLSUYyhdokorrnPTrNGB, data.DsPKrmcvILysVaeTrBlwFLBsuFp, null, new ControllerDataUpdater(data.QhiXIzSBnzSGaWwDVddQlyhdvkF, data.RGhWgMAfPjfICjXGWTZxnPoNdWD, data.SeOhWaCQLSUYyhdokorrnPTrNGB, null))
		{
		}

		private CustomController(int controllerId, int sourceControllerId, Guid hardwareTypeGuid, InputSource inputSource, string name, string hardwareName, string hardwareIdentifier, int axisCount, int buttonCount, HardwareControllerMap_Game hardwareMap, Extension extension, ControllerDataUpdater dataUpdater)
			: base(controllerId, inputSource, name, hardwareName, hardwareIdentifier, ControllerType.Custom, hardwareTypeGuid, axisCount, buttonCount, null, hardwareMap, extension, dataUpdater)
		{
			_sourceControllerId = sourceControllerId;
			_deviceInstanceGuid = MiscTools.CreateGuidHashSHA1("CustomController device instance GUID: sourceId = " + _sourceControllerId + ", controllerId = " + controllerId);
			aNzXPWgGkyjIHrJsRxlIZSjJoXv();
		}

		internal void FillData()
		{
			if (!useUpdateCallbacks)
			{
				goto IL_000b;
			}
			goto IL_00e5;
			IL_000b:
			int num = -322126476;
			goto IL_0010;
			IL_0010:
			int num3 = default(int);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -322126478)
				{
				case 7:
					break;
				default:
					return;
				case 6:
					return;
				case 0:
					goto IL_004c;
				case 5:
					goto IL_0066;
				case 2:
					cMcAtEwaThLpgGZfIIRmVCJQjDU.buttonValues[num3] = buttonUpdateCallback(num3);
					num3++;
					num = -322126478;
					continue;
				case 4:
					goto IL_00a1;
				case 3:
					cMcAtEwaThLpgGZfIIRmVCJQjDU.axisValues[num2] = axisUpdateCallback(num2);
					num2++;
					num = -322126474;
					continue;
				case 8:
					goto IL_00e5;
				case 1:
					return;
				}
				break;
				IL_00a1:
				int num4;
				if (num2 < _axisCount)
				{
					num = -322126479;
					num4 = num;
				}
				else
				{
					num = -322126473;
					num4 = num;
				}
				continue;
				IL_004c:
				int num5;
				if (num3 < _buttonCount)
				{
					num = -322126480;
					num5 = num;
				}
				else
				{
					num = -322126477;
					num5 = num;
				}
			}
			goto IL_000b;
			IL_00e5:
			if (axisUpdateCallback != null)
			{
				num2 = 0;
				num = -322126474;
				goto IL_0010;
			}
			goto IL_0066;
			IL_0066:
			if (buttonUpdateCallback != null)
			{
				num3 = 0;
				num = -322126478;
				goto IL_0010;
			}
		}

		public void SetAxisValue(int index, float value)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_0019;
			}
			goto IL_0061;
			IL_0079:
			Logger.LogWarning(index + " is not a valid Axis index.");
			return;
			IL_0019:
			int num = 1783655581;
			goto IL_001e;
			IL_001e:
			switch (num ^ 0x6A506C9F)
			{
			case 0:
				break;
			case 4:
				goto IL_0043;
			case 1:
				goto IL_0061;
			case 2:
				return;
			case 5:
				goto IL_0079;
			default:
				cMcAtEwaThLpgGZfIIRmVCJQjDU.axisValues[index] = value;
				return;
			}
			goto IL_0019;
			IL_0061:
			if (!base.enabled)
			{
				return;
			}
			goto IL_0043;
			IL_0043:
			if (index >= 0)
			{
				int num2;
				if (index < _axisCount)
				{
					num = 1783655580;
					num2 = num;
				}
				else
				{
					num = 1783655578;
					num2 = num;
				}
				goto IL_001e;
			}
			goto IL_0079;
		}

		public void SetAxisValue(string elementName, float value)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return;
			}
			while (base.enabled)
			{
				while (true)
				{
					IL_00ac:
					int axisIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetAxisIndex(elementName);
					int num = -1761557744;
					while (true)
					{
						switch (num ^ -1761557739)
						{
						case 6:
							num = -1761557743;
							continue;
						case 4:
							break;
						case 3:
							goto IL_0058;
						case 2:
							Logger.LogWarning("\"" + axisIndex + "\" is not a valid Axis name.");
							return;
						case 5:
							goto IL_0094;
						case 1:
							goto IL_00ac;
						default:
							cMcAtEwaThLpgGZfIIRmVCJQjDU.axisValues[axisIndex] = value;
							return;
						}
						break;
						IL_0094:
						int num2;
						if (axisIndex < 0)
						{
							num = -1761557737;
							num2 = num;
						}
						else
						{
							num = -1761557738;
							num2 = num;
						}
						continue;
						IL_0058:
						int num3;
						if (axisIndex < _axisCount)
						{
							num = -1761557739;
							num3 = num;
						}
						else
						{
							num = -1761557737;
							num3 = num;
						}
					}
					break;
				}
			}
		}

		public void SetAxisValueById(int elementId, float value)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			goto IL_005b;
			IL_000d:
			int num = 423825645;
			goto IL_0012;
			IL_0012:
			int axisIndex = default(int);
			while (true)
			{
				switch (num ^ 0x194310EF)
				{
				case 6:
					break;
				default:
					return;
				case 1:
					goto IL_003e;
				case 3:
					goto IL_005b;
				case 5:
					goto IL_006b;
				case 4:
					cMcAtEwaThLpgGZfIIRmVCJQjDU.axisValues[axisIndex] = value;
					num = 423825647;
					continue;
				case 2:
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return;
				case 0:
					return;
				}
				break;
			}
			goto IL_000d;
			IL_003e:
			Logger.LogWarning(elementId + " is not a valid Axis id.");
			return;
			IL_005b:
			if (!base.enabled)
			{
				return;
			}
			goto IL_006b;
			IL_006b:
			axisIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetAxisIndex(elementId);
			if (axisIndex >= 0)
			{
				int num2;
				if (axisIndex < _axisCount)
				{
					num = 423825643;
					num2 = num;
				}
				else
				{
					num = 423825646;
					num2 = num;
				}
				goto IL_0012;
			}
			goto IL_003e;
		}

		public void SetButtonValue(int index, bool value)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
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
						if (index < _buttonCount)
						{
							num = -388326144;
							num2 = num;
						}
						else
						{
							num = -388326141;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -388326142)
							{
							case 4:
								num = -388326143;
								continue;
							case 1:
								break;
							case 0:
								goto IL_005d;
							case 3:
								goto end_IL_005d;
							default:
								cMcAtEwaThLpgGZfIIRmVCJQjDU.buttonValues[index] = value;
								return;
							}
							break;
						}
					}
					Logger.LogWarning(index + " is not a valid Button index.");
					return;
					continue;
					end_IL_005d:
					break;
				}
			}
		}

		public void SetButtonValue(string elementName, bool value)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return;
			}
			while (base.enabled)
			{
				while (true)
				{
					IL_00ce:
					int buttonIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetButtonIndex(elementName);
					int num = 1304928009;
					while (true)
					{
						switch (num ^ 0x4DC79F08)
						{
						case 2:
							num = 1304928011;
							continue;
						default:
							return;
						case 3:
							break;
						case 0:
							cMcAtEwaThLpgGZfIIRmVCJQjDU.buttonValues[buttonIndex] = value;
							num = 1304928000;
							continue;
						case 1:
							goto IL_0078;
						case 5:
							goto IL_008d;
						case 4:
							Logger.LogWarning("\"" + buttonIndex + "\" is not a valid Button name.");
							num = 1304928015;
							continue;
						case 6:
							goto IL_00ce;
						case 7:
							return;
						case 8:
							return;
						}
						break;
						IL_008d:
						int num2;
						if (buttonIndex < _buttonCount)
						{
							num = 1304928008;
							num2 = num;
						}
						else
						{
							num = 1304928012;
							num2 = num;
						}
						continue;
						IL_0078:
						int num3;
						if (buttonIndex < 0)
						{
							num = 1304928012;
							num3 = num;
						}
						else
						{
							num = 1304928013;
							num3 = num;
						}
					}
					break;
				}
			}
		}

		public void SetButtonValueById(int elementId, bool value)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return;
			}
			while (base.enabled)
			{
				while (true)
				{
					IL_008a:
					int buttonIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetButtonIndex(elementId);
					int num;
					int num2;
					if (buttonIndex < 0)
					{
						num = 1987322672;
						num2 = num;
					}
					else
					{
						num = 1987322679;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x76742333)
						{
						case 5:
							num = 1987322674;
							continue;
						default:
							return;
						case 4:
							break;
						case 0:
							cMcAtEwaThLpgGZfIIRmVCJQjDU.buttonValues[buttonIndex] = value;
							num = 1987322677;
							continue;
						case 1:
							goto end_IL_001f;
						case 2:
							goto IL_008a;
						case 3:
							Logger.LogWarning(elementId + " is not a valid Button id.");
							return;
						case 6:
							return;
						}
						int num3;
						if (buttonIndex < _buttonCount)
						{
							num = 1987322675;
							num3 = num;
						}
						else
						{
							num = 1987322672;
							num3 = num;
						}
						continue;
						end_IL_001f:
						break;
					}
					break;
				}
			}
		}

		public void SetAxisUpdateCallback(Func<int, float> callback)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			goto IL_0058;
			IL_000d:
			int num = 893523579;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x3542167F)
				{
				case 2:
					break;
				default:
					return;
				case 4:
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					num = 893523578;
					continue;
				case 1:
					useUpdateCallbacks = true;
					num = 893523580;
					continue;
				case 0:
					goto IL_0058;
				case 5:
					return;
				case 3:
					return;
				}
				break;
			}
			goto IL_000d;
			IL_0058:
			axisUpdateCallback = callback;
			int num2;
			if (useUpdateCallbacks)
			{
				num = 893523580;
				num2 = num;
			}
			else
			{
				num = 893523582;
				num2 = num;
			}
			goto IL_0012;
		}

		public void SetButtonUpdateCallback(Func<int, bool> callback)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
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
				int num = -773980207;
				while (true)
				{
					switch (num ^ -773980208)
					{
					case 0:
						goto IL_001a;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_001a:
					num = -773980206;
				}
			}
		}

		public void ClearAxisValue(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return;
			}
			while (base.enabled)
			{
				while (true)
				{
					int num;
					int num2;
					if (index >= 0)
					{
						num = 1825172145;
						num2 = num;
					}
					else
					{
						num = 1825172147;
						num2 = num;
					}
					while (true)
					{
						float num3;
						float num4;
						switch (num ^ 0x6CC9EAB1)
						{
						case 3:
							num = 1825172151;
							continue;
						case 5:
							if (_calibrationMap == null)
							{
								num = 1825172149;
								continue;
							}
							num3 = _calibrationMap.GetAxis(index).calibratedZero;
							goto IL_00ce;
						case 1:
							break;
						case 0:
							goto IL_006c;
						case 6:
							goto end_IL_0057;
						case 2:
							Logger.LogWarning(index + " is not a valid Axis index.");
							return;
						default:
							{
								num3 = 0f;
								goto IL_00ce;
							}
							IL_00ce:
							num4 = num3;
							cMcAtEwaThLpgGZfIIRmVCJQjDU.axisValues[index] = num4;
							return;
						}
						break;
						IL_006c:
						int num5;
						if (index >= _axisCount)
						{
							num = 1825172147;
							num5 = num;
						}
						else
						{
							num = 1825172148;
							num5 = num;
						}
					}
					continue;
					end_IL_0057:
					break;
				}
			}
		}

		public void ClearAxisValue(string elementName)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_001c;
			}
			goto IL_009f;
			IL_009f:
			int num;
			int num2;
			if (base.enabled)
			{
				num = 2080951369;
				num2 = num;
			}
			else
			{
				num = 2080951374;
				num2 = num;
			}
			goto IL_0021;
			IL_001c:
			num = 2080951370;
			goto IL_0021;
			IL_0021:
			int axisIndex = default(int);
			while (true)
			{
				switch (num ^ 0x7C08CC48)
				{
				case 5:
					break;
				case 3:
					Logger.LogWarning("\"" + axisIndex + "\" is not a valid Axis name.");
					return;
				case 6:
					return;
				case 1:
					axisIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetAxisIndex(elementName);
					if (axisIndex < 0)
					{
						goto case 3;
					}
					goto IL_0085;
				case 4:
					goto IL_009f;
				case 2:
					return;
				default:
					ClearAxisValue(axisIndex);
					return;
				}
				break;
				IL_0085:
				int num3;
				if (axisIndex >= _axisCount)
				{
					num = 2080951371;
					num3 = num;
				}
				else
				{
					num = 2080951368;
					num3 = num;
				}
			}
			goto IL_001c;
		}

		public void ClearAxisValueById(int elementId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return;
			}
			while (base.enabled)
			{
				while (true)
				{
					int axisIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetAxisIndex(elementId);
					int num;
					int num2;
					if (axisIndex >= 0)
					{
						num = -114064547;
						num2 = num;
					}
					else
					{
						num = -114064552;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -114064552)
						{
						case 3:
							num = -114064546;
							continue;
						default:
							return;
						case 0:
							Logger.LogWarning(elementId + " is not a valid Axis id.");
							return;
						case 5:
							break;
						case 2:
							goto end_IL_0022;
						case 4:
							ClearAxisValue(axisIndex);
							num = -114064551;
							continue;
						case 6:
							goto end_IL_0085;
						case 1:
							return;
						}
						int num3;
						if (axisIndex >= _axisCount)
						{
							num = -114064552;
							num3 = num;
						}
						else
						{
							num = -114064548;
							num3 = num;
						}
						continue;
						end_IL_0022:
						break;
					}
					continue;
					end_IL_0085:
					break;
				}
			}
		}

		public void ClearButtonValue(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return;
			}
			while (base.enabled)
			{
				while (true)
				{
					IL_005b:
					int num;
					int num2;
					if (index < 0)
					{
						num = -1365784418;
						num2 = num;
					}
					else
					{
						num = -1365784417;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -1365784419)
						{
						case 0:
							num = -1365784423;
							continue;
						default:
							return;
						case 4:
							break;
						case 5:
							goto IL_005b;
						case 2:
							goto IL_0070;
						case 6:
							cMcAtEwaThLpgGZfIIRmVCJQjDU.buttonValues[index] = false;
							cMcAtEwaThLpgGZfIIRmVCJQjDU.buttonPressureValues[index] = 0f;
							num = -1365784420;
							continue;
						case 3:
							Logger.LogWarning(index + " is not a valid Button index.");
							return;
						case 1:
							return;
						}
						break;
						IL_0070:
						int num3;
						if (index >= _buttonCount)
						{
							num = -1365784418;
							num3 = num;
						}
						else
						{
							num = -1365784421;
							num3 = num;
						}
					}
					break;
				}
			}
		}

		public void ClearButtonValue(string elementName)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return;
			}
			while (base.enabled)
			{
				while (true)
				{
					IL_0090:
					int buttonIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetButtonIndex(elementName);
					int num;
					int num2;
					if (buttonIndex >= 0)
					{
						num = -1519183638;
						num2 = num;
					}
					else
					{
						num = -1519183633;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -1519183633)
						{
						case 4:
							num = -1519183635;
							continue;
						case 5:
							break;
						case 0:
							Logger.LogWarning("\"" + buttonIndex + "\" is not a valid Button name.");
							return;
						case 2:
							goto end_IL_001f;
						case 3:
							goto IL_0090;
						default:
							ClearButtonValue(buttonIndex);
							return;
						}
						int num3;
						if (buttonIndex >= _buttonCount)
						{
							num = -1519183633;
							num3 = num;
						}
						else
						{
							num = -1519183634;
							num3 = num;
						}
						continue;
						end_IL_001f:
						break;
					}
					break;
				}
			}
		}

		public void ClearButtonValueById(int elementId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return;
			}
			while (base.enabled)
			{
				while (true)
				{
					IL_006e:
					int buttonIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetButtonIndex(elementId);
					int num;
					int num2;
					if (buttonIndex < 0)
					{
						num = 872352508;
						num2 = num;
					}
					else
					{
						num = 872352504;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x33FF0AF8)
						{
						case 3:
							num = 872352509;
							continue;
						case 5:
							break;
						case 0:
							goto IL_0054;
						case 2:
							goto IL_006e;
						case 4:
							Logger.LogWarning(elementId + " is not a valid Button id.");
							return;
						default:
							ClearButtonValue(buttonIndex);
							return;
						}
						break;
						IL_0054:
						int num3;
						if (buttonIndex < _buttonCount)
						{
							num = 872352505;
							num3 = num;
						}
						else
						{
							num = 872352508;
							num3 = num;
						}
					}
					break;
				}
			}
		}
	}
}
