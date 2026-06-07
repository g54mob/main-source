using System;
using System.Collections.Generic;
using Rewired;
using Rewired.HID;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

internal sealed class mRshZYvRPZEOqsKKDOIjEclUqAru : IElementIdentifierTool
{
	private Rewired.Internal.GUIText JzAfbtKxCwASVKtjZrSXugCJMlLP;

	private string buIZqcLMLGSCBHddADdLhqrMOhcm;

	private int wbGCxIBPLgZzEuVdzcFrrXZHEhPP;

	private tVBWyZGsKPKvJuuMOPZiWmVEjMGK EXdAjdeIMCUCpAYTcjQKiDTfoUGY;

	private asRdKzmHUeOfEtnumeRYNLFtgVpi rCJaKsAexMPepwMrQdSYEBasCTuF;

	private Guid BBoHkLsQpuXGjSPFBUTxdCwfabIr;

	private IList<asRdKzmHUeOfEtnumeRYNLFtgVpi> vepFprKAxiCaHIEACJmtUUSQOPXX;

	private bool tyQrCqEQvegNlcffrOwMkhLvdMUO;

	private bool huhBeEUxCGzsbrpUSeqSJQsaRXNpA;

	private bool WdpVKQkoHJlfycdWktHLALrVKudV;

	private string[] iMwKudUzdDtrGdbtJcLnHSlsugyD;

	private int[] BIIAZxqUVqNmHKBeorSAuhyYYkaV;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		JzAfbtKxCwASVKtjZrSXugCJMlLP = text;
		iMwKudUzdDtrGdbtJcLnHSlsugyD = Enum.GetNames(typeof(RawInputAxis));
		BIIAZxqUVqNmHKBeorSAuhyYYkaV = (int[])Enum.GetValues(typeof(RawInputAxis));
	}

	public void Start()
	{
		if (ReInput.isEditor && ReInput.editorPlatform != EditorPlatform.Windows)
		{
			Rewired.Logger.LogError("Raw Input cannot be run on this platform. You must be running the editor in Windows.");
			return;
		}
		if (ReInput.currentPlatform != Platform.Windows)
		{
			Rewired.Logger.LogError("Raw Input cannot be run on this build target. Be sure Unity's build target is set to Windows Standalone.");
			return;
		}
		EXdAjdeIMCUCpAYTcjQKiDTfoUGY = ReInput.primaryInputManager.inputSource as tVBWyZGsKPKvJuuMOPZiWmVEjMGK;
		if (EXdAjdeIMCUCpAYTcjQKiDTfoUGY == null)
		{
			Rewired.Logger.LogError("Unable to initialize Raw Input! You must add a Rewired Input Manager to the scene and set the input mode to Raw Input.");
			return;
		}
		ReInput.primaryInputManager.SystemDeviceConnectedEvent += fMETbuWJvSMkxSEBJPpdAdARbGDW;
		ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += lzsOMpAlDaVTdmbDtGNXTjFtLYEc;
		PPVHYajegyyiBHeOCeEfwVISqOnu();
		WdpVKQkoHJlfycdWktHLALrVKudV = true;
	}

	public void Update()
	{
		if (!WdpVKQkoHJlfycdWktHLALrVKudV)
		{
			return;
		}
		buIZqcLMLGSCBHddADdLhqrMOhcm = "Raw Input Joystick Element Identifier\n\n";
		JzAfbtKxCwASVKtjZrSXugCJMlLP.text = buIZqcLMLGSCBHddADdLhqrMOhcm;
		int num = wbGCxIBPLgZzEuVdzcFrrXZHEhPP;
		Guid bBoHkLsQpuXGjSPFBUTxdCwfabIr = BBoHkLsQpuXGjSPFBUTxdCwfabIr;
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Equals) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Plus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadPlus))
		{
			wbGCxIBPLgZzEuVdzcFrrXZHEhPP++;
		}
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadMinus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Minus))
		{
			wbGCxIBPLgZzEuVdzcFrrXZHEhPP--;
		}
		if (huhBeEUxCGzsbrpUSeqSJQsaRXNpA)
		{
			PPVHYajegyyiBHeOCeEfwVISqOnu();
			huhBeEUxCGzsbrpUSeqSJQsaRXNpA = false;
		}
		int num2 = ((vepFprKAxiCaHIEACJmtUUSQOPXX != null) ? vepFprKAxiCaHIEACJmtUUSQOPXX.Count : 0);
		if (num2 == 0)
		{
			return;
		}
		if (wbGCxIBPLgZzEuVdzcFrrXZHEhPP < 0)
		{
			wbGCxIBPLgZzEuVdzcFrrXZHEhPP = num2 - 1;
		}
		else if (wbGCxIBPLgZzEuVdzcFrrXZHEhPP >= num2)
		{
			wbGCxIBPLgZzEuVdzcFrrXZHEhPP = 0;
		}
		BBoHkLsQpuXGjSPFBUTxdCwfabIr = vepFprKAxiCaHIEACJmtUUSQOPXX[wbGCxIBPLgZzEuVdzcFrrXZHEhPP].UTgEnYwMzKwvhFVWmadoqnWiKGQb;
		bool flag = false;
		if (num != wbGCxIBPLgZzEuVdzcFrrXZHEhPP || bBoHkLsQpuXGjSPFBUTxdCwfabIr != BBoHkLsQpuXGjSPFBUTxdCwfabIr)
		{
			flag = true;
		}
		if (rCJaKsAexMPepwMrQdSYEBasCTuF == null || flag)
		{
			if (rCJaKsAexMPepwMrQdSYEBasCTuF != null)
			{
				rCJaKsAexMPepwMrQdSYEBasCTuF.Unacquire();
			}
			rCJaKsAexMPepwMrQdSYEBasCTuF = vepFprKAxiCaHIEACJmtUUSQOPXX[wbGCxIBPLgZzEuVdzcFrrXZHEhPP];
			if (rCJaKsAexMPepwMrQdSYEBasCTuF == null)
			{
				return;
			}
			rCJaKsAexMPepwMrQdSYEBasCTuF.Acquire();
		}
		bool flag2 = false;
		if (rCJaKsAexMPepwMrQdSYEBasCTuF.MTZhVIKBKRLScmMzBpiVZUsSQZVd is EkjPPGtMfdCmBOwKmCFAiaihYVqrA)
		{
			flag2 = true;
		}
		else if (!(rCJaKsAexMPepwMrQdSYEBasCTuF.MTZhVIKBKRLScmMzBpiVZUsSQZVd is YzhTkxbnAyFqHcHbqYnZZGjpbdcx))
		{
			return;
		}
		if (num2 > 0)
		{
			buIZqcLMLGSCBHddADdLhqrMOhcm = buIZqcLMLGSCBHddADdLhqrMOhcm + num2 + " connected devices:\n";
		}
		for (int i = 0; i < num2; i++)
		{
			buIZqcLMLGSCBHddADdLhqrMOhcm = buIZqcLMLGSCBHddADdLhqrMOhcm + vepFprKAxiCaHIEACJmtUUSQOPXX[i].ohZDoCmVQxaTHsROXZdsVHeLPMzH + "\n";
		}
		buIZqcLMLGSCBHddADdLhqrMOhcm += "\n";
		buIZqcLMLGSCBHddADdLhqrMOhcm = buIZqcLMLGSCBHddADdLhqrMOhcm + "Current RI device " + wbGCxIBPLgZzEuVdzcFrrXZHEhPP + ": \"" + rCJaKsAexMPepwMrQdSYEBasCTuF.ohZDoCmVQxaTHsROXZdsVHeLPMzH + "\"\n";
		buIZqcLMLGSCBHddADdLhqrMOhcm += "(Press + or - to change monitored device id.)\n\n";
		wyRUZJuhpprevQEDYmBXvxppUQaF("Product Name", "\"" + rCJaKsAexMPepwMrQdSYEBasCTuF.ohZDoCmVQxaTHsROXZdsVHeLPMzH + "\"");
		wyRUZJuhpprevQEDYmBXvxppUQaF("Is Bluetooth Device", rCJaKsAexMPepwMrQdSYEBasCTuF.MECbKJLKFUIoOBQeEkOXNtXmlPEC);
		if (rCJaKsAexMPepwMrQdSYEBasCTuF.MECbKJLKFUIoOBQeEkOXNtXmlPEC)
		{
			wyRUZJuhpprevQEDYmBXvxppUQaF("Bluetooth Device Name", "\"" + rCJaKsAexMPepwMrQdSYEBasCTuF.sIXmVbVDtaBkdtQMVHYeWQdqUKYs + "\"");
		}
		if (flag2)
		{
			wyRUZJuhpprevQEDYmBXvxppUQaF("Using Custom Driver", "TRUE");
		}
		wyRUZJuhpprevQEDYmBXvxppUQaF("Device Type", rCJaKsAexMPepwMrQdSYEBasCTuF.IahAEyAbGcjkThbPHvPGbvOCgtjYD.ToString());
		wyRUZJuhpprevQEDYmBXvxppUQaF("Identifier", new PidVid(rCJaKsAexMPepwMrQdSYEBasCTuF.NYYrpoJmrmXNddXgbOtXNRapBPrR));
		wyRUZJuhpprevQEDYmBXvxppUQaF("Product Id", rCJaKsAexMPepwMrQdSYEBasCTuF.tFEBVepOaIieiWoMKdBqOityhAYt);
		wyRUZJuhpprevQEDYmBXvxppUQaF("Vendor Id", rCJaKsAexMPepwMrQdSYEBasCTuF.lYkgFObpJbehzEgFocikXKvHajvX);
		buIZqcLMLGSCBHddADdLhqrMOhcm += "\n";
		wyRUZJuhpprevQEDYmBXvxppUQaF("Axis Count", rCJaKsAexMPepwMrQdSYEBasCTuF.QvqKvOEgWZFuaadBGEQbfeQgKqAic);
		wyRUZJuhpprevQEDYmBXvxppUQaF("Button Count", rCJaKsAexMPepwMrQdSYEBasCTuF.RgbfDDRzjDqkoFkQgCKPVHBbPkbi);
		wyRUZJuhpprevQEDYmBXvxppUQaF("Hat Count", rCJaKsAexMPepwMrQdSYEBasCTuF.jxpPyoeDgFhsnWYCemYCOPmWcJgn);
		buIZqcLMLGSCBHddADdLhqrMOhcm += "\n";
		if (flag)
		{
			string text = "";
			text = text + "Device Name: \"" + vepFprKAxiCaHIEACJmtUUSQOPXX[wbGCxIBPLgZzEuVdzcFrrXZHEhPP].ohZDoCmVQxaTHsROXZdsVHeLPMzH + "\"\n";
			if (rCJaKsAexMPepwMrQdSYEBasCTuF.MECbKJLKFUIoOBQeEkOXNtXmlPEC)
			{
				text = text + "Bluetooth Device Name: \"" + rCJaKsAexMPepwMrQdSYEBasCTuF.sIXmVbVDtaBkdtQMVHYeWQdqUKYs + "\"\n";
			}
			text = text + "Identifier: " + new PidVid(rCJaKsAexMPepwMrQdSYEBasCTuF.NYYrpoJmrmXNddXgbOtXNRapBPrR).ToString() + "\n";
			Rewired.Logger.Log(text);
		}
		if (!flag2)
		{
			YzhTkxbnAyFqHcHbqYnZZGjpbdcx yzhTkxbnAyFqHcHbqYnZZGjpbdcx = rCJaKsAexMPepwMrQdSYEBasCTuF.MTZhVIKBKRLScmMzBpiVZUsSQZVd as YzhTkxbnAyFqHcHbqYnZZGjpbdcx;
			for (int j = 1; j < iMwKudUzdDtrGdbtJcLnHSlsugyD.Length - 1; j++)
			{
				int num3 = gtExFxcpYcZTABrBeLFEPTMTniaw((RawInputAxis)BIIAZxqUVqNmHKBeorSAuhyYYkaV[j], 0, yzhTkxbnAyFqHcHbqYnZZGjpbdcx);
				string text2 = iMwKudUzdDtrGdbtJcLnHSlsugyD[j];
				try
				{
					wyRUZJuhpprevQEDYmBXvxppUQaF(text2, num3 + " (" + ZeCVkTdiUyWuvkSDDwvSKXKKMqkf(num3) + ")");
				}
				catch
				{
					wyRUZJuhpprevQEDYmBXvxppUQaF(text2, "FAILED! Axis value = " + num3);
				}
			}
			if (yzhTkxbnAyFqHcHbqYnZZGjpbdcx.VsCRihyVbJrxHGglfbHklRZlXOWw > 0)
			{
				for (int k = 0; k < yzhTkxbnAyFqHcHbqYnZZGjpbdcx.VsCRihyVbJrxHGglfbHklRZlXOWw; k++)
				{
					int num4 = gtExFxcpYcZTABrBeLFEPTMTniaw(RawInputAxis.Other, k, yzhTkxbnAyFqHcHbqYnZZGjpbdcx);
					string text3 = "Other Axis " + k;
					try
					{
						wyRUZJuhpprevQEDYmBXvxppUQaF(text3, num4 + " (" + ZeCVkTdiUyWuvkSDDwvSKXKKMqkf(num4) + ")");
					}
					catch
					{
						wyRUZJuhpprevQEDYmBXvxppUQaF(text3, "FAILED! Axis value = " + num4);
					}
				}
			}
			int[] array = rCJaKsAexMPepwMrQdSYEBasCTuF.IMSgnydiJRMbFOJZiuTORfgUwFavA;
			for (int l = 0; l < array.Length; l++)
			{
				int num5 = array[l];
				string text4 = "Hat " + l;
				wyRUZJuhpprevQEDYmBXvxppUQaF(text4, num5);
			}
			bool[] array2 = rCJaKsAexMPepwMrQdSYEBasCTuF.cSTdYhCfOIlkyjUlxiceJHSyagLSA;
			string text5 = "";
			for (int m = 0; m < array2.Length; m++)
			{
				if (array2[m])
				{
					if (text5 != "")
					{
						text5 += ", ";
					}
					text5 += m;
				}
			}
			wyRUZJuhpprevQEDYmBXvxppUQaF("Buttons ", text5);
		}
		else
		{
			EkjPPGtMfdCmBOwKmCFAiaihYVqrA ekjPPGtMfdCmBOwKmCFAiaihYVqrA = rCJaKsAexMPepwMrQdSYEBasCTuF.MTZhVIKBKRLScmMzBpiVZUsSQZVd as EkjPPGtMfdCmBOwKmCFAiaihYVqrA;
			for (int n = 0; n < rCJaKsAexMPepwMrQdSYEBasCTuF.QvqKvOEgWZFuaadBGEQbfeQgKqAic; n++)
			{
				float num6 = ekjPPGtMfdCmBOwKmCFAiaihYVqrA.gtExFxcpYcZTABrBeLFEPTMTniaw(n);
				string text6 = n.ToString();
				try
				{
					wyRUZJuhpprevQEDYmBXvxppUQaF(text6, num6 + " (" + ekjPPGtMfdCmBOwKmCFAiaihYVqrA.ABlNUnzdvpBOUkUNIiXYyXkXjYbK(n) + ")");
				}
				catch
				{
					wyRUZJuhpprevQEDYmBXvxppUQaF(text6, "FAILED! Axis value = " + num6);
				}
			}
			int[] array3 = rCJaKsAexMPepwMrQdSYEBasCTuF.IMSgnydiJRMbFOJZiuTORfgUwFavA;
			for (int num7 = 0; num7 < rCJaKsAexMPepwMrQdSYEBasCTuF.jxpPyoeDgFhsnWYCemYCOPmWcJgn; num7++)
			{
				int num8 = array3[num7];
				string text7 = "Hat " + num7;
				wyRUZJuhpprevQEDYmBXvxppUQaF(text7, num8);
			}
			for (int num9 = 0; num9 < rCJaKsAexMPepwMrQdSYEBasCTuF.pOSToWoKPbQypFYQiUpDCTXdBGHb.GyroscopeCount; num9++)
			{
				int valueLength = rCJaKsAexMPepwMrQdSYEBasCTuF.pOSToWoKPbQypFYQiUpDCTXdBGHb.gyroscopes[num9].valueLength;
				string text8 = "";
				for (int num10 = 0; num10 < valueLength; num10++)
				{
					float num11 = rCJaKsAexMPepwMrQdSYEBasCTuF.pOSToWoKPbQypFYQiUpDCTXdBGHb.gyroscopes[num9].rawValue[num10];
					text8 = text8 + "[" + num10 + "]: " + num11.ToString("f3");
					if (num10 < valueLength - 1)
					{
						text8 += " ";
					}
				}
				wyRUZJuhpprevQEDYmBXvxppUQaF("Gyro " + num9, text8);
			}
			for (int num12 = 0; num12 < rCJaKsAexMPepwMrQdSYEBasCTuF.pOSToWoKPbQypFYQiUpDCTXdBGHb.AccelerometerCount; num12++)
			{
				int valueLength2 = rCJaKsAexMPepwMrQdSYEBasCTuF.pOSToWoKPbQypFYQiUpDCTXdBGHb.accelerometers[num12].valueLength;
				string text9 = "";
				for (int num13 = 0; num13 < valueLength2; num13++)
				{
					float num14 = rCJaKsAexMPepwMrQdSYEBasCTuF.pOSToWoKPbQypFYQiUpDCTXdBGHb.accelerometers[num12].rawValue[num13];
					text9 = text9 + "[" + num13 + "]: " + num14.ToString("f3");
					if (num13 < valueLength2 - 1)
					{
						text9 += " ";
					}
				}
				wyRUZJuhpprevQEDYmBXvxppUQaF("Accelerometer " + num12, text9);
			}
			for (int num15 = 0; num15 < rCJaKsAexMPepwMrQdSYEBasCTuF.pOSToWoKPbQypFYQiUpDCTXdBGHb.TouchpadCount; num15++)
			{
				HIDTouchpad hIDTouchpad = rCJaKsAexMPepwMrQdSYEBasCTuF.pOSToWoKPbQypFYQiUpDCTXdBGHb.touchpads[num15];
				int num16 = hIDTouchpad.values.Length;
				string text10 = "";
				for (int num17 = 0; num17 < num16; num17++)
				{
					HIDTouchpad.TouchData touchData = hIDTouchpad.values[num17];
					text10 = text10 + "Touch " + num17 + ": Is Touching = " + touchData.isTouching + "\n";
					text10 = text10 + "Touch " + num17 + ": Touch Id = " + touchData.touchId + "\n";
					text10 = text10 + "Touch " + num17 + ": Position = " + touchData.positionX + ", " + touchData.positionY + "\n";
					text10 = text10 + "Touch " + num17 + ": Abs Position = " + touchData.positionAbsX + ", " + touchData.positionAbsY + " (" + touchData.positionRawX + ", " + touchData.positionRawY + ")\n";
				}
				atwGIqaKFUUFqMXEXeHvAdqTaLDEA("Touchpad " + num15, text10);
			}
			bool[] array4 = rCJaKsAexMPepwMrQdSYEBasCTuF.cSTdYhCfOIlkyjUlxiceJHSyagLSA;
			string text11 = "";
			for (int num18 = 0; num18 < array4.Length; num18++)
			{
				if (array4[num18])
				{
					if (text11 != "")
					{
						text11 += ", ";
					}
					text11 += num18;
				}
			}
			wyRUZJuhpprevQEDYmBXvxppUQaF("Buttons ", text11);
		}
		JzAfbtKxCwASVKtjZrSXugCJMlLP.text = buIZqcLMLGSCBHddADdLhqrMOhcm;
	}

	public void OnDestroy()
	{
		if (rCJaKsAexMPepwMrQdSYEBasCTuF != null)
		{
			rCJaKsAexMPepwMrQdSYEBasCTuF.Unacquire();
		}
	}

	private void PPVHYajegyyiBHeOCeEfwVISqOnu()
	{
		vepFprKAxiCaHIEACJmtUUSQOPXX = EXdAjdeIMCUCpAYTcjQKiDTfoUGY.GetJoysticks<asRdKzmHUeOfEtnumeRYNLFtgVpi>();
	}

	private void fMETbuWJvSMkxSEBJPpdAdARbGDW()
	{
		dcVdxJdzxMZSZROeXTVCUmflVKQLA();
	}

	private void lzsOMpAlDaVTdmbDtGNXTjFtLYEc()
	{
		dcVdxJdzxMZSZROeXTVCUmflVKQLA();
	}

	private void dcVdxJdzxMZSZROeXTVCUmflVKQLA()
	{
		PNnwosyJbZAkbwObisgdtMytZJol();
		huhBeEUxCGzsbrpUSeqSJQsaRXNpA = true;
	}

	private void PNnwosyJbZAkbwObisgdtMytZJol()
	{
		wbGCxIBPLgZzEuVdzcFrrXZHEhPP = 0;
		rCJaKsAexMPepwMrQdSYEBasCTuF = null;
		BBoHkLsQpuXGjSPFBUTxdCwfabIr = Guid.Empty;
		vepFprKAxiCaHIEACJmtUUSQOPXX = null;
		tyQrCqEQvegNlcffrOwMkhLvdMUO = false;
		huhBeEUxCGzsbrpUSeqSJQsaRXNpA = false;
	}

	private void wyRUZJuhpprevQEDYmBXvxppUQaF(string P_0, object P_1)
	{
		buIZqcLMLGSCBHddADdLhqrMOhcm = buIZqcLMLGSCBHddADdLhqrMOhcm + P_0 + " = " + P_1.ToString() + "\n";
	}

	private void atwGIqaKFUUFqMXEXeHvAdqTaLDEA(string P_0, object P_1)
	{
		buIZqcLMLGSCBHddADdLhqrMOhcm = buIZqcLMLGSCBHddADdLhqrMOhcm + P_0 + ":\n" + P_1.ToString() + "\n";
	}

	private int gtExFxcpYcZTABrBeLFEPTMTniaw(RawInputAxis P_0, int P_1, YzhTkxbnAyFqHcHbqYnZZGjpbdcx P_2)
	{
		return P_2.gtExFxcpYcZTABrBeLFEPTMTniaw(P_0, P_1);
	}

	private float ZeCVkTdiUyWuvkSDDwvSKXKKMqkf(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}
}
