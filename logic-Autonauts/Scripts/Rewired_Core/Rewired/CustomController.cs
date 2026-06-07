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
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return Guid.Empty;
				}
				return _deviceInstanceGuid;
			}
		}

		internal CustomController(BQyGYxvmdrkvdxOAtdNlcnVGzxWK data)
			: this(data.lJGmoPjWlZhCnfYmPrnrnNrpiFd, data.EFHfUkVHlpfMiRjveZJDpSTYIai, data.ATDQbOTPxeHkkBLoRmWzxDgmajNA, data.pjmDqcGcEdmXbvnkITKNjUFiEooD, data.ztxLGYqvsFLrsKkETXDfycBhNF, data.LnnEMtEzQZNQVvMexVVfLUASaXWH, data.YiIUvWfzvblblULoEBxCZANzFXz, data.ijxelHigybruBiYdNSiiNzGQTwsf, data.vgSbQnhkfGJDrjOShKPojdhsCSkQ, data.wNPKZbISdRnlUJccaUfbBMfnSsA, null, new ControllerDataUpdater(data.pjmDqcGcEdmXbvnkITKNjUFiEooD, data.ijxelHigybruBiYdNSiiNzGQTwsf, data.vgSbQnhkfGJDrjOShKPojdhsCSkQ, null))
		{
		}

		private CustomController(int controllerId, int sourceControllerId, Guid hardwareTypeGuid, InputSource inputSource, string name, string hardwareName, string hardwareIdentifier, int axisCount, int buttonCount, HardwareControllerMap_Game hardwareMap, Extension extension, ControllerDataUpdater dataUpdater)
			: base(controllerId, inputSource, name, hardwareName, hardwareIdentifier, ControllerType.Custom, hardwareTypeGuid, axisCount, buttonCount, null, hardwareMap, extension, dataUpdater)
		{
			_sourceControllerId = sourceControllerId;
			_deviceInstanceGuid = MiscTools.CreateGuidHashSHA1("CustomController device instance GUID: sourceId = " + _sourceControllerId + ", controllerId = " + controllerId);
			DRbMoDMaPuHTEfQNWMCHwDDCfEIB();
		}

		internal void FillData()
		{
			if (!useUpdateCallbacks)
			{
				goto IL_0008;
			}
			goto IL_0069;
			IL_0008:
			int num = 139531154;
			goto IL_000d;
			IL_000d:
			int num3 = default(int);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x851139A)
				{
				case 6:
					break;
				default:
					return;
				case 1:
					ROoGdHjYclVKlAjCTYtzRRhBjqvj.buttonValues[num3] = buttonUpdateCallback(num3);
					num3++;
					num = 139531166;
					continue;
				case 7:
					goto IL_0069;
				case 5:
					goto IL_007a;
				case 4:
					goto IL_0097;
				case 0:
					goto IL_00b4;
				case 8:
					return;
				case 2:
					ROoGdHjYclVKlAjCTYtzRRhBjqvj.axisValues[num2] = axisUpdateCallback(num2);
					num2++;
					num = 139531167;
					continue;
				case 9:
					num = 139531167;
					continue;
				case 3:
					return;
				}
				break;
				IL_0097:
				int num4;
				if (num3 >= _buttonCount)
				{
					num = 139531161;
					num4 = num;
				}
				else
				{
					num = 139531163;
					num4 = num;
				}
				continue;
				IL_007a:
				int num5;
				if (num2 < _axisCount)
				{
					num = 139531160;
					num5 = num;
				}
				else
				{
					num = 139531162;
					num5 = num;
				}
			}
			goto IL_0008;
			IL_0069:
			if (axisUpdateCallback != null)
			{
				num2 = 0;
				num = 139531155;
				goto IL_000d;
			}
			goto IL_00b4;
			IL_00b4:
			if (buttonUpdateCallback != null)
			{
				num3 = 0;
				num = 139531166;
				goto IL_000d;
			}
		}

		public void SetAxisValue(int index, float value)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			goto IL_0086;
			IL_000d:
			int num = 1749375237;
			goto IL_0012;
			IL_0012:
			switch (num ^ 0x68455901)
			{
			case 0:
				break;
			case 2:
				goto IL_0037;
			case 5:
				goto IL_0055;
			case 4:
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return;
			case 3:
				goto IL_0086;
			default:
				ROoGdHjYclVKlAjCTYtzRRhBjqvj.axisValues[index] = value;
				return;
			}
			goto IL_000d;
			IL_0086:
			if (!base.enabled)
			{
				return;
			}
			goto IL_0037;
			IL_0037:
			if (index >= 0)
			{
				int num2;
				if (index >= _axisCount)
				{
					num = 1749375236;
					num2 = num;
				}
				else
				{
					num = 1749375232;
					num2 = num;
				}
				goto IL_0012;
			}
			goto IL_0055;
			IL_0055:
			Logger.LogWarning(index + " is not a valid Axis index.");
		}

		public void SetAxisValue(string elementName, float value)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return;
			}
			int axisIndex = default(int);
			while (true)
			{
				int num;
				int num2;
				if (base.enabled)
				{
					num = 1850629158;
					num2 = num;
				}
				else
				{
					num = 1850629152;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x6E4E5C23)
					{
					case 0:
						num = 1850629159;
						continue;
					case 5:
						axisIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetAxisIndex(elementName);
						if (axisIndex >= 0)
						{
							int num3;
							if (axisIndex < _axisCount)
							{
								num = 1850629153;
								num3 = num;
							}
							else
							{
								num = 1850629154;
								num3 = num;
							}
							continue;
						}
						goto case 1;
					case 1:
						Logger.LogWarning("\"" + axisIndex + "\" is not a valid Axis name.");
						return;
					case 4:
						break;
					case 3:
						return;
					default:
						ROoGdHjYclVKlAjCTYtzRRhBjqvj.axisValues[axisIndex] = value;
						return;
					}
					break;
				}
			}
		}

		public void SetAxisValueById(int elementId, float value)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_001c;
			}
			goto IL_0096;
			IL_0071:
			Logger.LogWarning(elementId + " is not a valid Axis id.");
			return;
			IL_001c:
			int num = -929154232;
			goto IL_0021;
			IL_0021:
			int axisIndex = default(int);
			switch (num ^ -929154227)
			{
			case 3:
				break;
			case 4:
				goto IL_0046;
			case 2:
				goto IL_0071;
			case 5:
				return;
			case 0:
				goto IL_0096;
			default:
				ROoGdHjYclVKlAjCTYtzRRhBjqvj.axisValues[axisIndex] = value;
				return;
			}
			goto IL_001c;
			IL_0096:
			if (!base.enabled)
			{
				return;
			}
			goto IL_0046;
			IL_0046:
			axisIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetAxisIndex(elementId);
			if (axisIndex >= 0)
			{
				int num2;
				if (axisIndex >= _axisCount)
				{
					num = -929154225;
					num2 = num;
				}
				else
				{
					num = -929154228;
					num2 = num;
				}
				goto IL_0021;
			}
			goto IL_0071;
		}

		public void SetButtonValue(int index, bool value)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return;
			}
			while (base.enabled)
			{
				while (true)
				{
					IL_006d:
					if (index >= 0)
					{
						int num;
						int num2;
						if (index >= _buttonCount)
						{
							num = -219004575;
							num2 = num;
						}
						else
						{
							num = -219004573;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -219004575)
							{
							case 4:
								num = -219004576;
								continue;
							case 1:
								break;
							case 0:
								goto IL_0050;
							case 3:
								goto IL_006d;
							default:
								ROoGdHjYclVKlAjCTYtzRRhBjqvj.buttonValues[index] = value;
								return;
							}
							break;
						}
						break;
					}
					goto IL_0050;
					IL_0050:
					Logger.LogWarning(index + " is not a valid Button index.");
					return;
				}
			}
		}

		public void SetButtonValue(string elementName, bool value)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			goto IL_0046;
			IL_000d:
			int num = -1180308404;
			goto IL_0012;
			IL_0012:
			int buttonIndex = default(int);
			while (true)
			{
				switch (num ^ -1180308403)
				{
				case 5:
					break;
				default:
					return;
				case 3:
					goto IL_0046;
				case 7:
					Logger.LogWarning("\"" + buttonIndex + "\" is not a valid Button name.");
					return;
				case 4:
					ROoGdHjYclVKlAjCTYtzRRhBjqvj.buttonValues[buttonIndex] = value;
					num = -1180308401;
					continue;
				case 1:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					num = -1180308405;
					continue;
				case 6:
					return;
				case 8:
					if (buttonIndex < 0)
					{
						goto case 7;
					}
					goto IL_00b5;
				case 0:
					goto IL_00d2;
				case 2:
					return;
				}
				break;
				IL_00b5:
				int num2;
				if (buttonIndex >= _buttonCount)
				{
					num = -1180308406;
					num2 = num;
				}
				else
				{
					num = -1180308407;
					num2 = num;
				}
			}
			goto IL_000d;
			IL_00d2:
			buttonIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetButtonIndex(elementName);
			num = -1180308411;
			goto IL_0012;
			IL_0046:
			if (!base.enabled)
			{
				return;
			}
			goto IL_00d2;
		}

		public void SetButtonValueById(int elementId, bool value)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			goto IL_003b;
			IL_000d:
			int num = -1021863758;
			goto IL_0012;
			IL_0012:
			int buttonIndex = default(int);
			while (true)
			{
				switch (num ^ -1021863757)
				{
				case 0:
					break;
				case 2:
					goto IL_003b;
				case 4:
					return;
				case 1:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					num = -1021863753;
					continue;
				case 5:
					goto IL_0066;
				case 6:
					goto IL_0083;
				default:
					ROoGdHjYclVKlAjCTYtzRRhBjqvj.buttonValues[buttonIndex] = value;
					return;
				}
				break;
			}
			goto IL_000d;
			IL_0066:
			Logger.LogWarning(elementId + " is not a valid Button id.");
			return;
			IL_003b:
			if (!base.enabled)
			{
				return;
			}
			goto IL_0083;
			IL_0083:
			buttonIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetButtonIndex(elementId);
			if (buttonIndex >= 0)
			{
				int num2;
				if (buttonIndex < _buttonCount)
				{
					num = -1021863760;
					num2 = num;
				}
				else
				{
					num = -1021863754;
					num2 = num;
				}
				goto IL_0012;
			}
			goto IL_0066;
		}

		public void SetAxisUpdateCallback(Func<int, float> callback)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return;
			}
			while (true)
			{
				axisUpdateCallback = callback;
				int num;
				int num2;
				if (!useUpdateCallbacks)
				{
					num = -917627088;
					num2 = num;
				}
				else
				{
					num = -917627085;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -917627088)
					{
					case 2:
						num = -917627087;
						continue;
					default:
						return;
					case 1:
						break;
					case 0:
						useUpdateCallbacks = true;
						num = -917627085;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		public void SetButtonUpdateCallback(Func<int, bool> callback)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			goto IL_0043;
			IL_0043:
			buttonUpdateCallback = callback;
			int num;
			if (!useUpdateCallbacks)
			{
				useUpdateCallbacks = true;
				num = 1935130006;
				goto IL_001e;
			}
			return;
			IL_0019:
			num = 1935130005;
			goto IL_001e;
			IL_001e:
			switch (num ^ 0x7357BD94)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				return;
			case 3:
				goto IL_0043;
			case 2:
				return;
			}
			goto IL_0019;
		}

		public void ClearAxisValue(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return;
			}
			float num3 = default(float);
			while (base.enabled)
			{
				while (true)
				{
					IL_00aa:
					int num;
					if (index >= 0)
					{
						int num2;
						if (index >= _axisCount)
						{
							num = -911931510;
							num2 = num;
						}
						else
						{
							num = -911931511;
							num2 = num;
						}
						goto IL_001f;
					}
					goto IL_0063;
					IL_001f:
					while (true)
					{
						switch (num ^ -911931511)
						{
						case 5:
							num = -911931505;
							continue;
						case 6:
							break;
						case 1:
							return;
						case 3:
							goto IL_0063;
						case 0:
							num3 = ((_calibrationMap != null) ? _calibrationMap.GetAxis(index).calibratedZero : 0f);
							num = -911931507;
							continue;
						case 2:
							goto IL_00aa;
						default:
							ROoGdHjYclVKlAjCTYtzRRhBjqvj.axisValues[index] = num3;
							return;
						}
						break;
					}
					break;
					IL_0063:
					Logger.LogWarning(index + " is not a valid Axis index.");
					num = -911931512;
					goto IL_001f;
				}
			}
		}

		public void ClearAxisValue(string elementName)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			goto IL_007b;
			IL_000d:
			int num = -1053658238;
			goto IL_0012;
			IL_0012:
			int axisIndex = default(int);
			while (true)
			{
				switch (num ^ -1053658239)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					ClearAxisValue(axisIndex);
					num = -1053658236;
					continue;
				case 6:
					goto IL_0050;
				case 4:
					goto IL_007b;
				case 7:
					return;
				case 3:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					num = -1053658234;
					continue;
				case 1:
					goto IL_00ac;
				case 5:
					return;
				}
				break;
			}
			goto IL_000d;
			IL_0050:
			axisIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetAxisIndex(elementName);
			if (axisIndex >= 0)
			{
				int num2;
				if (axisIndex >= _axisCount)
				{
					num = -1053658240;
					num2 = num;
				}
				else
				{
					num = -1053658237;
					num2 = num;
				}
				goto IL_0012;
			}
			goto IL_00ac;
			IL_00ac:
			Logger.LogWarning("\"" + axisIndex + "\" is not a valid Axis name.");
			return;
			IL_007b:
			if (!base.enabled)
			{
				return;
			}
			goto IL_0050;
		}

		public void ClearAxisValueById(int elementId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			goto IL_006b;
			IL_004f:
			Logger.LogWarning(elementId + " is not a valid Axis id.");
			int num = 760450155;
			goto IL_001e;
			IL_0019:
			num = 760450154;
			goto IL_001e;
			IL_001e:
			int axisIndex = default(int);
			switch (num ^ 0x2D538C6B)
			{
			case 4:
				break;
			case 1:
				return;
			case 6:
				goto IL_004f;
			case 2:
				goto IL_006b;
			case 0:
				return;
			case 5:
				goto IL_0083;
			default:
				ClearAxisValue(axisIndex);
				return;
			}
			goto IL_0019;
			IL_006b:
			if (!base.enabled)
			{
				return;
			}
			goto IL_0083;
			IL_0083:
			axisIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetAxisIndex(elementId);
			if (axisIndex >= 0)
			{
				int num2;
				if (axisIndex >= _axisCount)
				{
					num = 760450157;
					num2 = num;
				}
				else
				{
					num = 760450152;
					num2 = num;
				}
				goto IL_001e;
			}
			goto IL_004f;
		}

		public void ClearButtonValue(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!base.enabled)
				{
					num = -1365196497;
					num2 = num;
				}
				else
				{
					num = -1365196499;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1365196500)
					{
					case 0:
						num = -1365196503;
						continue;
					case 4:
						Logger.LogWarning(index + " is not a valid Button index.");
						return;
					case 1:
						if (index >= 0)
						{
							int num3;
							if (index < _buttonCount)
							{
								num = -1365196498;
								num3 = num;
							}
							else
							{
								num = -1365196504;
								num3 = num;
							}
							continue;
						}
						goto case 4;
					case 2:
						ROoGdHjYclVKlAjCTYtzRRhBjqvj.buttonValues[index] = false;
						num = -1365196502;
						continue;
					case 5:
						break;
					case 3:
						return;
					default:
						ROoGdHjYclVKlAjCTYtzRRhBjqvj.buttonPressureValues[index] = 0f;
						return;
					}
					break;
				}
			}
		}

		public void ClearButtonValue(string elementName)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return;
			}
			int buttonIndex = default(int);
			while (true)
			{
				int num;
				int num2;
				if (!base.enabled)
				{
					num = -1259657427;
					num2 = num;
				}
				else
				{
					num = -1259657430;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1259657428)
					{
					case 7:
						num = -1259657432;
						continue;
					default:
						return;
					case 3:
						if (buttonIndex >= 0)
						{
							int num3;
							if (buttonIndex >= _buttonCount)
							{
								num = -1259657431;
								num3 = num;
							}
							else
							{
								num = -1259657426;
								num3 = num;
							}
							continue;
						}
						goto case 5;
					case 2:
						ClearButtonValue(buttonIndex);
						num = -1259657428;
						continue;
					case 4:
						break;
					case 6:
						buttonIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetButtonIndex(elementName);
						num = -1259657425;
						continue;
					case 1:
						return;
					case 5:
						Logger.LogWarning("\"" + buttonIndex + "\" is not a valid Button name.");
						return;
					case 0:
						return;
					}
					break;
				}
			}
		}

		public void ClearButtonValueById(int elementId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return;
			}
			while (base.enabled)
			{
				while (true)
				{
					IL_006d:
					int buttonIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetButtonIndex(elementId);
					if (buttonIndex >= 0)
					{
						int num;
						int num2;
						if (buttonIndex < _buttonCount)
						{
							num = -1839143495;
							num2 = num;
						}
						else
						{
							num = -1839143494;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -1839143493)
							{
							case 4:
								num = -1839143496;
								continue;
							case 3:
								break;
							case 1:
								goto IL_0050;
							case 0:
								goto IL_006d;
							default:
								ClearButtonValue(buttonIndex);
								return;
							}
							break;
						}
						break;
					}
					goto IL_0050;
					IL_0050:
					Logger.LogWarning(elementId + " is not a valid Button id.");
					return;
				}
			}
		}
	}
}
