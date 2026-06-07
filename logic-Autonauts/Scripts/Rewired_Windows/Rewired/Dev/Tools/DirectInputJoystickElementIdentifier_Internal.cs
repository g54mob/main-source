using System;
using System.Collections.Generic;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Libraries.SharpDX.DirectInput;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	internal sealed class DirectInputJoystickElementIdentifier_Internal : IElementIdentifierTool
	{
		private Rewired.Internal.GUIText text;

		private string textBuffer;

		private int currentDeviceId;

		private DirectInput pbsDzFwuvQvUwdnstjlbFubXWWZ;

		private jsQodzWnVXxJhIsULuSibIHUoCH FvpbthwqHsVfdlOKqyTxjSLrkXP;

		private Guid deviceInstanceGuid;

		private IList<vgUDhfmgAmAsRjRuQJnGENONMljC> PcJfKsiYBMNqZDjxgGYYAhvPaOoz;

		private IList<vgUDhfmgAmAsRjRuQJnGENONMljC> BHIwHwrUuZRMmUCAJWExIyRtFab;

		private bool showAllDevices;

		private bool refreshNow;

		private bool ready;

		private int rawDeviceCount;

		private TimerRealTime XruuVyWMVAVXdAhAsLNgGqHxHyp;

		public void Initialize(Rewired.Internal.GUIText text)
		{
			this.text = text;
		}

		public void Start()
		{
			if (ReInput.isEditor && ReInput.editorPlatform != EditorPlatform.Windows)
			{
				Logger.LogError("Direct Input cannot be run on this platform. You must be running the editor in Windows.");
				return;
			}
			if (ReInput.currentPlatform != Platform.Windows)
			{
				Logger.LogError("Direct Input cannot be run on this build target. Be sure Unity's build target is set to Windows Standalone.");
				return;
			}
			InputSourceWrapper<DirectInput> inputSourceWrapper = ReInput.primaryInputManager.inputSource as InputSourceWrapper<DirectInput>;
			if (inputSourceWrapper == null || inputSourceWrapper.source == null)
			{
				Logger.LogError("Unable to initialize Direct Input! You must add a Rewired Input Manager to the scene and set the input mode to Direct Input.");
				return;
			}
			pbsDzFwuvQvUwdnstjlbFubXWWZ = inputSourceWrapper.source;
			ReInput.primaryInputManager.SystemDeviceConnectedEvent += SystemDeviceConnected;
			ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += SystemDeviceDisconnected;
			XruuVyWMVAVXdAhAsLNgGqHxHyp = new TimerRealTime(1f);
			XruuVyWMVAVXdAhAsLNgGqHxHyp.Start();
			UpdateDeviceList();
			ready = true;
		}

		public void Update()
		{
			if (!ready)
			{
				return;
			}
			textBuffer = "Direct Input Joystick Element Identifier\n\n";
			this.text.text = textBuffer;
			if (Input.GetKeyDown(KeyCode.A))
			{
				showAllDevices = !showAllDevices;
			}
			if (showAllDevices)
			{
				this.text.text += "All Devices:\n";
				foreach (vgUDhfmgAmAsRjRuQJnGENONMljC item in BHIwHwrUuZRMmUCAJWExIyRtFab)
				{
					Rewired.Internal.GUIText gUIText = this.text;
					object obj = gUIText.text;
					gUIText.text = string.Concat(obj, item.OEnOUJCzzTIBDnorvtUHuLJCUSM, ", ", item.IsHumanInterfaceDevice, ", ", new PidVid(item.neegydbRJWFbtaeXBWBstaVupIYa), ", ", item.Subtype, ", ", item.CZzFxmqlmJjjVIdYppEAiCkwSwBD, ", ", item.WmtUGOFEZXlJDeownvmsmDErLwz, "\n");
				}
				this.text.text += "\n";
			}
			int num = currentDeviceId;
			Guid guid = deviceInstanceGuid;
			if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Equals) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Plus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadPlus))
			{
				currentDeviceId++;
			}
			if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadMinus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Minus))
			{
				currentDeviceId--;
			}
			if (XruuVyWMVAVXdAhAsLNgGqHxHyp.Update())
			{
				int deviceCount = pbsDzFwuvQvUwdnstjlbFubXWWZ.GetDeviceCount(RSViiCwWYViTGbHemxBsoBfasVd.vvyijmZOzRFtTdippDQZhtsZhGJC, zGfVlsImnYjabwVEyjlINqRCfqKj.sQJXOWUzmAyNONjbRXYAwNmJORI);
				if (deviceCount != rawDeviceCount)
				{
					rawDeviceCount = deviceCount;
					refreshNow = true;
				}
				XruuVyWMVAVXdAhAsLNgGqHxHyp.Start();
			}
			if (refreshNow)
			{
				UpdateDeviceList();
				refreshNow = false;
			}
			int num2 = ((PcJfKsiYBMNqZDjxgGYYAhvPaOoz != null) ? PcJfKsiYBMNqZDjxgGYYAhvPaOoz.Count : 0);
			if (num2 == 0)
			{
				return;
			}
			if (currentDeviceId < 0)
			{
				currentDeviceId = num2 - 1;
			}
			else if (currentDeviceId >= num2)
			{
				currentDeviceId = 0;
			}
			deviceInstanceGuid = PcJfKsiYBMNqZDjxgGYYAhvPaOoz[currentDeviceId].enAPtHYaqiBCfCxaGvASHsInALh;
			bool flag = false;
			if (num != currentDeviceId || guid != deviceInstanceGuid)
			{
				flag = true;
			}
			if (FvpbthwqHsVfdlOKqyTxjSLrkXP == null || flag)
			{
				if (FvpbthwqHsVfdlOKqyTxjSLrkXP != null)
				{
					FvpbthwqHsVfdlOKqyTxjSLrkXP.JxfIuiJgitwuNVhKepFyxnNnrFN();
				}
				FvpbthwqHsVfdlOKqyTxjSLrkXP = new jsQodzWnVXxJhIsULuSibIHUoCH(pbsDzFwuvQvUwdnstjlbFubXWWZ, PcJfKsiYBMNqZDjxgGYYAhvPaOoz[currentDeviceId].enAPtHYaqiBCfCxaGvASHsInALh);
				if (FvpbthwqHsVfdlOKqyTxjSLrkXP == null)
				{
					return;
				}
				IList<KuQxCBzznSLnNWYiaqXOToEkUKh> list = FvpbthwqHsVfdlOKqyTxjSLrkXP.DKqajuJWbQnTOheggZGXUloOluMu();
				if (list != null)
				{
					for (int i = 0; i < list.Count; i++)
					{
						if ((list[i].PAKwpRwHzcMrwnAbkFIFosdOHCzB.Flags & gxhgVrOliVamAhmjXjgnPKfDmZY.HHXbspJDVrOgmjeiSarUYYMpdPSa) != gxhgVrOliVamAhmjXjgnPKfDmZY.vvyijmZOzRFtTdippDQZhtsZhGJC)
						{
							FvpbthwqHsVfdlOKqyTxjSLrkXP.Properties.Range = new BeZFfShWDfxzerAOHfuPtekOGSBW(-65535, 65535);
						}
					}
				}
				FvpbthwqHsVfdlOKqyTxjSLrkXP.GFLPSeyIjIAqKSNFbdOLeOPmOvDX();
			}
			HEnqjDCbQatLClXKVNYOqMCtdXr hEnqjDCbQatLClXKVNYOqMCtdXr;
			try
			{
				hEnqjDCbQatLClXKVNYOqMCtdXr = FvpbthwqHsVfdlOKqyTxjSLrkXP.dBAjkoHBoFgyxqAazfpYYAufWOSd();
			}
			catch
			{
				hEnqjDCbQatLClXKVNYOqMCtdXr = null;
			}
			if (hEnqjDCbQatLClXKVNYOqMCtdXr == null)
			{
				return;
			}
			if (num2 > 0)
			{
				textBuffer = textBuffer + num2 + " connected devices:\n";
			}
			for (int j = 0; j < num2; j++)
			{
				textBuffer = textBuffer + PcJfKsiYBMNqZDjxgGYYAhvPaOoz[j].OEnOUJCzzTIBDnorvtUHuLJCUSM + "\n";
			}
			textBuffer += "\n";
			object obj3 = textBuffer;
			textBuffer = string.Concat(obj3, "Current DI device ", currentDeviceId, ": ", PcJfKsiYBMNqZDjxgGYYAhvPaOoz[currentDeviceId].OEnOUJCzzTIBDnorvtUHuLJCUSM, "\n");
			textBuffer += "(Press + or - to change monitored device id.)\n\n";
			Log("Identifier", new PidVid(FvpbthwqHsVfdlOKqyTxjSLrkXP.Information.neegydbRJWFbtaeXBWBstaVupIYa));
			Log("Instance GUID", FvpbthwqHsVfdlOKqyTxjSLrkXP.Information.enAPtHYaqiBCfCxaGvASHsInALh);
			Log("Product Id", FvpbthwqHsVfdlOKqyTxjSLrkXP.Properties.ProductId);
			Log("Device Type", FvpbthwqHsVfdlOKqyTxjSLrkXP.Capabilities.Type.ToString());
			textBuffer += "\n";
			Log("Axis Count", FvpbthwqHsVfdlOKqyTxjSLrkXP.Capabilities.dHTfRYjcEiBnhjZAXjEderVDyXok);
			Log("Button Count", FvpbthwqHsVfdlOKqyTxjSLrkXP.Capabilities.lwPieGbLEzAskWvJIoFcuwJwQsU);
			Log("Hat Count", FvpbthwqHsVfdlOKqyTxjSLrkXP.Capabilities.EKNLxnieCsJOkPzMWbNelRMrciQ);
			textBuffer += "\n";
			if (flag)
			{
				Logger.Log("Device Name: \"" + PcJfKsiYBMNqZDjxgGYYAhvPaOoz[currentDeviceId].OEnOUJCzzTIBDnorvtUHuLJCUSM + "\"");
				Logger.Log("Identifier: " + new PidVid(FvpbthwqHsVfdlOKqyTxjSLrkXP.Information.neegydbRJWFbtaeXBWBstaVupIYa));
			}
			for (int k = 0; k < 32; k++)
			{
				int value = MnqkSgUruMGpGEncQArrqhjEHzFC((DirectInputAxis)k, hEnqjDCbQatLClXKVNYOqMCtdXr);
				string key = ((DirectInputAxis)k).ToString();
				Log(key, value + " (" + NormalizeAxis(value) + ")");
			}
			int[] pointOfViewControllers = hEnqjDCbQatLClXKVNYOqMCtdXr.PointOfViewControllers;
			for (int l = 0; l < 4; l++)
			{
				int num3 = pointOfViewControllers[l];
				string key2 = "Hat " + l;
				Log(key2, num3);
			}
			bool[] buttons = hEnqjDCbQatLClXKVNYOqMCtdXr.Buttons;
			string text = "";
			for (int m = 0; m < 128; m++)
			{
				if (buttons[m])
				{
					if (text != "")
					{
						text += ", ";
					}
					text += m;
				}
			}
			Log("Buttons ", text);
			this.text.text = textBuffer;
		}

		private void UpdateDeviceList()
		{
			PcJfKsiYBMNqZDjxgGYYAhvPaOoz = pbsDzFwuvQvUwdnstjlbFubXWWZ.GetDevices(RSViiCwWYViTGbHemxBsoBfasVd.GbQpIWxEvYSkxUbfmBgPqSZfLDE, zGfVlsImnYjabwVEyjlINqRCfqKj.sQJXOWUzmAyNONjbRXYAwNmJORI);
			BHIwHwrUuZRMmUCAJWExIyRtFab = pbsDzFwuvQvUwdnstjlbFubXWWZ.GetDevices(RSViiCwWYViTGbHemxBsoBfasVd.vvyijmZOzRFtTdippDQZhtsZhGJC, zGfVlsImnYjabwVEyjlINqRCfqKj.sQJXOWUzmAyNONjbRXYAwNmJORI);
			rawDeviceCount = ((BHIwHwrUuZRMmUCAJWExIyRtFab != null) ? BHIwHwrUuZRMmUCAJWExIyRtFab.Count : 0);
		}

		private void SystemDeviceConnected()
		{
			Refresh();
		}

		private void SystemDeviceDisconnected()
		{
			Refresh();
		}

		private void Refresh()
		{
			Clear();
			refreshNow = true;
		}

		private void Clear()
		{
			currentDeviceId = 0;
			FvpbthwqHsVfdlOKqyTxjSLrkXP = null;
			deviceInstanceGuid = Guid.Empty;
			PcJfKsiYBMNqZDjxgGYYAhvPaOoz = null;
			BHIwHwrUuZRMmUCAJWExIyRtFab = null;
			showAllDevices = false;
			refreshNow = false;
			rawDeviceCount = 0;
		}

		private void Log(string key, object value)
		{
			string text = textBuffer;
			textBuffer = text + key + " = " + value.ToString() + "\n";
		}

		private int MnqkSgUruMGpGEncQArrqhjEHzFC(DirectInputAxis P_0, HEnqjDCbQatLClXKVNYOqMCtdXr P_1)
		{
			switch (P_0)
			{
			case DirectInputAxis.X:
				return P_1.X;
			case DirectInputAxis.Y:
				return P_1.Y;
			case DirectInputAxis.Z:
				return P_1.Z;
			case DirectInputAxis.RotationX:
				return P_1.RotationX;
			case DirectInputAxis.RotationY:
				return P_1.RotationY;
			case DirectInputAxis.RotationZ:
				return P_1.RotationZ;
			case DirectInputAxis.Slider0:
				return P_1.Sliders[0];
			case DirectInputAxis.Slider1:
				return P_1.Sliders[1];
			case DirectInputAxis.VelocityX:
				return P_1.VelocityX;
			case DirectInputAxis.VelocityY:
				return P_1.VelocityY;
			case DirectInputAxis.VelocityZ:
				return P_1.VelocityZ;
			case DirectInputAxis.AngularVelocityX:
				return P_1.AngularVelocityX;
			case DirectInputAxis.AngularVelocityY:
				return P_1.AngularVelocityY;
			case DirectInputAxis.AngularVelocityZ:
				return P_1.AngularVelocityZ;
			case DirectInputAxis.VelocitySlider0:
				return P_1.VelocitySliders[0];
			case DirectInputAxis.VelocitySlider1:
				return P_1.VelocitySliders[1];
			case DirectInputAxis.AccelerationX:
				return P_1.AccelerationX;
			case DirectInputAxis.AccelerationY:
				return P_1.AccelerationY;
			case DirectInputAxis.AccelerationZ:
				return P_1.AccelerationZ;
			case DirectInputAxis.AngularAccelerationX:
				return P_1.AngularAccelerationX;
			case DirectInputAxis.AngularAccelerationY:
				return P_1.AngularAccelerationY;
			case DirectInputAxis.AngularAccelerationZ:
				return P_1.AngularAccelerationZ;
			case DirectInputAxis.AccelerationSlider0:
				return P_1.AccelerationSliders[0];
			case DirectInputAxis.AccelerationSlider1:
				return P_1.AccelerationSliders[1];
			case DirectInputAxis.ForceX:
				return P_1.ForceX;
			case DirectInputAxis.ForceY:
				return P_1.ForceY;
			case DirectInputAxis.ForceZ:
				return P_1.ForceZ;
			case DirectInputAxis.TorqueX:
				return P_1.TorqueX;
			case DirectInputAxis.TorqueY:
				return P_1.TorqueY;
			case DirectInputAxis.TorqueZ:
				return P_1.TorqueZ;
			case DirectInputAxis.ForceSlider0:
				return P_1.ForceSliders[0];
			case DirectInputAxis.ForceSlider1:
				return P_1.ForceSliders[1];
			default:
				return 0;
			}
		}

		private float NormalizeAxis(int value)
		{
			if (value == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(value) / 65535f * (float)MathTools.Sign(value), -1f, 1f);
		}

		public void OnDestroy()
		{
			if (FvpbthwqHsVfdlOKqyTxjSLrkXP != null)
			{
				FvpbthwqHsVfdlOKqyTxjSLrkXP.JxfIuiJgitwuNVhKepFyxnNnrFN();
			}
		}
	}
}
