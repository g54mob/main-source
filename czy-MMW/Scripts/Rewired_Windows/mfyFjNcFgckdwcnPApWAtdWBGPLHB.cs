using System;
using System.Collections.Generic;
using Rewired;
using Rewired.HID;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

internal sealed class mfyFjNcFgckdwcnPApWAtdWBGPLHB : IElementIdentifierTool
{
	private GUIText gIbbxZGVZkMkKhjpHhPytRatjCxkB;

	private string fUKBsrBtgKGATuOMVMFKZRWwWnhGA;

	private int guDBETttaatZtmHpZQwMJEMYtpGp;

	private lkHkoAuBtkzhXzuFmLvNvBuSoSoG AcrlPVMOXXzrRhxppuGwNyAfQyhd;

	private qMLHUgANpXxKCmRpGepdcfgprHTj KTcIssEfoJvldVQYufZEsSthCRbp;

	private Guid OYqSEvMOFYAwZJgwThoTiIttCxYP;

	private IList<qMLHUgANpXxKCmRpGepdcfgprHTj> PMApWhcKcYeNvSLOZhTVcYzFzNQdA;

	private bool NsyBPIhFjnyzqiNlbUFBUgiHODaBA;

	private bool DOiRdZkbPzGcgLcWsfIHByBLceWp;

	private bool JebVFrwBgAobMyFpJpXjyCHCAeIh;

	private string[] JeutpIlApnAoWIasdprvkNSpFeFk;

	private int[] yHHnCBuZURvMeoZAMgqOgIEZTbih;

	public void Initialize(GUIText text)
	{
		gIbbxZGVZkMkKhjpHhPytRatjCxkB = text;
		JeutpIlApnAoWIasdprvkNSpFeFk = Enum.GetNames(typeof(RawInputAxis));
		yHHnCBuZURvMeoZAMgqOgIEZTbih = (int[])Enum.GetValues(typeof(RawInputAxis));
	}

	void IElementIdentifierTool.Initialize(GUIText text)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Initialize
		this.Initialize(text);
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
		AcrlPVMOXXzrRhxppuGwNyAfQyhd = ReInput.primaryInputManager.inputSource as lkHkoAuBtkzhXzuFmLvNvBuSoSoG;
		if (AcrlPVMOXXzrRhxppuGwNyAfQyhd == null)
		{
			Rewired.Logger.LogError("Unable to initialize Raw Input! You must add a Rewired Input Manager to the scene and set the input mode to Raw Input.");
			return;
		}
		ReInput.primaryInputManager.SystemDeviceConnectedEvent += TsjfZfoGRiLfKtQzAKCRmbnXvgdh;
		ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += MDtdrXXKmGajnkakGXfEVqhPuiEs;
		cQgHqAJSvKOboIhHeKPBbinwxfAh();
		JebVFrwBgAobMyFpJpXjyCHCAeIh = true;
	}

	void IElementIdentifierTool.Start()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Start
		this.Start();
	}

	public void Update()
	{
		if (!JebVFrwBgAobMyFpJpXjyCHCAeIh)
		{
			return;
		}
		fUKBsrBtgKGATuOMVMFKZRWwWnhGA = "Raw Input Joystick Element Identifier\n\n";
		gIbbxZGVZkMkKhjpHhPytRatjCxkB.text = fUKBsrBtgKGATuOMVMFKZRWwWnhGA;
		int num = guDBETttaatZtmHpZQwMJEMYtpGp;
		Guid oYqSEvMOFYAwZJgwThoTiIttCxYP = OYqSEvMOFYAwZJgwThoTiIttCxYP;
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Equals) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Plus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadPlus))
		{
			guDBETttaatZtmHpZQwMJEMYtpGp++;
		}
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadMinus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Minus))
		{
			guDBETttaatZtmHpZQwMJEMYtpGp--;
		}
		if (DOiRdZkbPzGcgLcWsfIHByBLceWp)
		{
			cQgHqAJSvKOboIhHeKPBbinwxfAh();
			DOiRdZkbPzGcgLcWsfIHByBLceWp = false;
		}
		int num2 = ((PMApWhcKcYeNvSLOZhTVcYzFzNQdA != null) ? PMApWhcKcYeNvSLOZhTVcYzFzNQdA.Count : 0);
		if (num2 == 0)
		{
			return;
		}
		if (guDBETttaatZtmHpZQwMJEMYtpGp < 0)
		{
			guDBETttaatZtmHpZQwMJEMYtpGp = num2 - 1;
		}
		else if (guDBETttaatZtmHpZQwMJEMYtpGp >= num2)
		{
			guDBETttaatZtmHpZQwMJEMYtpGp = 0;
		}
		OYqSEvMOFYAwZJgwThoTiIttCxYP = PMApWhcKcYeNvSLOZhTVcYzFzNQdA[guDBETttaatZtmHpZQwMJEMYtpGp].LfcjkMbWzXGcVUAKMEjaTydvCJTgb;
		bool flag = false;
		if (num != guDBETttaatZtmHpZQwMJEMYtpGp || oYqSEvMOFYAwZJgwThoTiIttCxYP != OYqSEvMOFYAwZJgwThoTiIttCxYP)
		{
			flag = true;
		}
		if (KTcIssEfoJvldVQYufZEsSthCRbp == null || flag)
		{
			if (KTcIssEfoJvldVQYufZEsSthCRbp != null)
			{
				KTcIssEfoJvldVQYufZEsSthCRbp.yGdDLHAwGvGPIqTacoLVHuIKsVwr();
			}
			KTcIssEfoJvldVQYufZEsSthCRbp = PMApWhcKcYeNvSLOZhTVcYzFzNQdA[guDBETttaatZtmHpZQwMJEMYtpGp];
			if (KTcIssEfoJvldVQYufZEsSthCRbp == null)
			{
				return;
			}
			KTcIssEfoJvldVQYufZEsSthCRbp.qxUytPzZYzrmzQlCnbDbwUORftCkA();
		}
		bool flag2 = false;
		if (KTcIssEfoJvldVQYufZEsSthCRbp.CjCfHpwnzRdYwiLuQwvFRwNaBodm is IZfUpNDHUGPBHVHVKyBnPBHhUASO)
		{
			flag2 = true;
		}
		else if (!(KTcIssEfoJvldVQYufZEsSthCRbp.CjCfHpwnzRdYwiLuQwvFRwNaBodm is MSnnYaHlzXooFhgMKAHsgeYdqLSj))
		{
			return;
		}
		if (num2 > 0)
		{
			fUKBsrBtgKGATuOMVMFKZRWwWnhGA = fUKBsrBtgKGATuOMVMFKZRWwWnhGA + num2 + " connected devices:\n";
		}
		for (int i = 0; i < num2; i++)
		{
			fUKBsrBtgKGATuOMVMFKZRWwWnhGA = fUKBsrBtgKGATuOMVMFKZRWwWnhGA + PMApWhcKcYeNvSLOZhTVcYzFzNQdA[i].ajaWryTIgdfKkRrvDEwFxFJEHKLZ + "\n";
		}
		fUKBsrBtgKGATuOMVMFKZRWwWnhGA += "\n";
		fUKBsrBtgKGATuOMVMFKZRWwWnhGA = fUKBsrBtgKGATuOMVMFKZRWwWnhGA + "Current RI device " + guDBETttaatZtmHpZQwMJEMYtpGp + ": \"" + KTcIssEfoJvldVQYufZEsSthCRbp.ajaWryTIgdfKkRrvDEwFxFJEHKLZ + "\"\n";
		fUKBsrBtgKGATuOMVMFKZRWwWnhGA += "(Press + or - to change monitored device id.)\n\n";
		JOAXRVgSNeDWRHPXyIjCzGvqYzlN("Product Name", "\"" + KTcIssEfoJvldVQYufZEsSthCRbp.ajaWryTIgdfKkRrvDEwFxFJEHKLZ + "\"");
		JOAXRVgSNeDWRHPXyIjCzGvqYzlN("Is Bluetooth Device", KTcIssEfoJvldVQYufZEsSthCRbp.DtwkGESqlVDhvJugqakYuJSBFgwTA);
		if (KTcIssEfoJvldVQYufZEsSthCRbp.DtwkGESqlVDhvJugqakYuJSBFgwTA)
		{
			JOAXRVgSNeDWRHPXyIjCzGvqYzlN("Bluetooth Device Name", "\"" + KTcIssEfoJvldVQYufZEsSthCRbp.DIUfWpmTmGRhLqarOTeDeoDlvpl + "\"");
		}
		if (flag2)
		{
			JOAXRVgSNeDWRHPXyIjCzGvqYzlN("Using Custom Driver", "TRUE");
		}
		JOAXRVgSNeDWRHPXyIjCzGvqYzlN("Device Type", KTcIssEfoJvldVQYufZEsSthCRbp.JHDapwgQDowqlIdYwLHzZLvuFsoOA.ToString());
		JOAXRVgSNeDWRHPXyIjCzGvqYzlN("Identifier", new PidVid(KTcIssEfoJvldVQYufZEsSthCRbp.jvbBEhRaZCBkAGnoVBTJRPrgfYtEb));
		JOAXRVgSNeDWRHPXyIjCzGvqYzlN("Product Id", KTcIssEfoJvldVQYufZEsSthCRbp.CFAKFhaosubYGrJUcTccwLmVjJMc);
		JOAXRVgSNeDWRHPXyIjCzGvqYzlN("Vendor Id", KTcIssEfoJvldVQYufZEsSthCRbp.pluFMScFqLGHySMBXtdKsxZRwQDM);
		fUKBsrBtgKGATuOMVMFKZRWwWnhGA += "\n";
		JOAXRVgSNeDWRHPXyIjCzGvqYzlN("Axis Count", KTcIssEfoJvldVQYufZEsSthCRbp.RYRAYjBiooKCDvoiWJEENuzRBFDcA);
		JOAXRVgSNeDWRHPXyIjCzGvqYzlN("Button Count", KTcIssEfoJvldVQYufZEsSthCRbp.zzOwiFLMbXudAdkmdERlQynpMsGV);
		JOAXRVgSNeDWRHPXyIjCzGvqYzlN("Hat Count", KTcIssEfoJvldVQYufZEsSthCRbp.twjmkNysChPYuiMxGhsrECeNPZ);
		fUKBsrBtgKGATuOMVMFKZRWwWnhGA += "\n";
		if (flag)
		{
			string text = "";
			text = text + "Device Name: \"" + PMApWhcKcYeNvSLOZhTVcYzFzNQdA[guDBETttaatZtmHpZQwMJEMYtpGp].ajaWryTIgdfKkRrvDEwFxFJEHKLZ + "\"\n";
			if (KTcIssEfoJvldVQYufZEsSthCRbp.DtwkGESqlVDhvJugqakYuJSBFgwTA)
			{
				text = text + "Bluetooth Device Name: \"" + KTcIssEfoJvldVQYufZEsSthCRbp.DIUfWpmTmGRhLqarOTeDeoDlvpl + "\"\n";
			}
			text = text + "Identifier: " + new PidVid(KTcIssEfoJvldVQYufZEsSthCRbp.jvbBEhRaZCBkAGnoVBTJRPrgfYtEb).ToString() + "\n";
			Rewired.Logger.Log(text);
		}
		if (!flag2)
		{
			MSnnYaHlzXooFhgMKAHsgeYdqLSj mSnnYaHlzXooFhgMKAHsgeYdqLSj = KTcIssEfoJvldVQYufZEsSthCRbp.CjCfHpwnzRdYwiLuQwvFRwNaBodm as MSnnYaHlzXooFhgMKAHsgeYdqLSj;
			for (int j = 1; j < JeutpIlApnAoWIasdprvkNSpFeFk.Length - 1; j++)
			{
				int num3 = OvUhKxJEQPktUSNjDnNUtinLJlxQ((RawInputAxis)yHHnCBuZURvMeoZAMgqOgIEZTbih[j], 0, mSnnYaHlzXooFhgMKAHsgeYdqLSj);
				string text2 = JeutpIlApnAoWIasdprvkNSpFeFk[j];
				try
				{
					JOAXRVgSNeDWRHPXyIjCzGvqYzlN(text2, num3 + " (" + buaRrVigeCEdaPqPZXMBzTLhwfoe(num3) + ")");
				}
				catch
				{
					JOAXRVgSNeDWRHPXyIjCzGvqYzlN(text2, "FAILED! Axis value = " + num3);
				}
			}
			if (mSnnYaHlzXooFhgMKAHsgeYdqLSj.hkHfOcHVYwjBujISxhdwzWtDorgTA > 0)
			{
				for (int k = 0; k < mSnnYaHlzXooFhgMKAHsgeYdqLSj.hkHfOcHVYwjBujISxhdwzWtDorgTA; k++)
				{
					int num4 = OvUhKxJEQPktUSNjDnNUtinLJlxQ(RawInputAxis.Other, k, mSnnYaHlzXooFhgMKAHsgeYdqLSj);
					string text3 = "Other Axis " + k;
					try
					{
						JOAXRVgSNeDWRHPXyIjCzGvqYzlN(text3, num4 + " (" + buaRrVigeCEdaPqPZXMBzTLhwfoe(num4) + ")");
					}
					catch
					{
						JOAXRVgSNeDWRHPXyIjCzGvqYzlN(text3, "FAILED! Axis value = " + num4);
					}
				}
			}
			int[] array = KTcIssEfoJvldVQYufZEsSthCRbp.WPtSGfUgpWRMiszKwsvgtRZBBtNh;
			for (int l = 0; l < array.Length; l++)
			{
				int num5 = array[l];
				string text4 = "Hat " + l;
				JOAXRVgSNeDWRHPXyIjCzGvqYzlN(text4, num5);
			}
			bool[] array2 = KTcIssEfoJvldVQYufZEsSthCRbp.XPBAEEmRYSySyiigVJUQqmZPfAXBA;
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
			JOAXRVgSNeDWRHPXyIjCzGvqYzlN("Buttons ", text5);
		}
		else
		{
			IZfUpNDHUGPBHVHVKyBnPBHhUASO zfUpNDHUGPBHVHVKyBnPBHhUASO = KTcIssEfoJvldVQYufZEsSthCRbp.CjCfHpwnzRdYwiLuQwvFRwNaBodm as IZfUpNDHUGPBHVHVKyBnPBHhUASO;
			for (int n = 0; n < KTcIssEfoJvldVQYufZEsSthCRbp.RYRAYjBiooKCDvoiWJEENuzRBFDcA; n++)
			{
				float num6 = zfUpNDHUGPBHVHVKyBnPBHhUASO.kKmkfKwfgeIfRACyulEZdmLhqveXb(n);
				string text6 = n.ToString();
				try
				{
					JOAXRVgSNeDWRHPXyIjCzGvqYzlN(text6, num6 + " (" + zfUpNDHUGPBHVHVKyBnPBHhUASO.FLbHrGSdLcltVBrKSDPsaRByGLLe(n) + ")");
				}
				catch
				{
					JOAXRVgSNeDWRHPXyIjCzGvqYzlN(text6, "FAILED! Axis value = " + num6);
				}
			}
			int[] array3 = KTcIssEfoJvldVQYufZEsSthCRbp.WPtSGfUgpWRMiszKwsvgtRZBBtNh;
			for (int num7 = 0; num7 < KTcIssEfoJvldVQYufZEsSthCRbp.twjmkNysChPYuiMxGhsrECeNPZ; num7++)
			{
				int num8 = array3[num7];
				string text7 = "Hat " + num7;
				JOAXRVgSNeDWRHPXyIjCzGvqYzlN(text7, num8);
			}
			for (int num9 = 0; num9 < KTcIssEfoJvldVQYufZEsSthCRbp.WPgdGbKJmaHtiVcfmcjseAeNVejh.GyroscopeCount; num9++)
			{
				int valueLength = KTcIssEfoJvldVQYufZEsSthCRbp.WPgdGbKJmaHtiVcfmcjseAeNVejh.gyroscopes[num9].valueLength;
				string text8 = "";
				for (int num10 = 0; num10 < valueLength; num10++)
				{
					float num11 = KTcIssEfoJvldVQYufZEsSthCRbp.WPgdGbKJmaHtiVcfmcjseAeNVejh.gyroscopes[num9].rawValue[num10];
					text8 = text8 + "[" + num10 + "]: " + num11.ToString("f3");
					if (num10 < valueLength - 1)
					{
						text8 += " ";
					}
				}
				JOAXRVgSNeDWRHPXyIjCzGvqYzlN("Gyro " + num9, text8);
			}
			for (int num12 = 0; num12 < KTcIssEfoJvldVQYufZEsSthCRbp.WPgdGbKJmaHtiVcfmcjseAeNVejh.AccelerometerCount; num12++)
			{
				int valueLength2 = KTcIssEfoJvldVQYufZEsSthCRbp.WPgdGbKJmaHtiVcfmcjseAeNVejh.accelerometers[num12].valueLength;
				string text9 = "";
				for (int num13 = 0; num13 < valueLength2; num13++)
				{
					float num14 = KTcIssEfoJvldVQYufZEsSthCRbp.WPgdGbKJmaHtiVcfmcjseAeNVejh.accelerometers[num12].rawValue[num13];
					text9 = text9 + "[" + num13 + "]: " + num14.ToString("f3");
					if (num13 < valueLength2 - 1)
					{
						text9 += " ";
					}
				}
				JOAXRVgSNeDWRHPXyIjCzGvqYzlN("Accelerometer " + num12, text9);
			}
			for (int num15 = 0; num15 < KTcIssEfoJvldVQYufZEsSthCRbp.WPgdGbKJmaHtiVcfmcjseAeNVejh.TouchpadCount; num15++)
			{
				HIDTouchpad hIDTouchpad = KTcIssEfoJvldVQYufZEsSthCRbp.WPgdGbKJmaHtiVcfmcjseAeNVejh.touchpads[num15];
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
				xOkgBrfymjGIcvKotpyChMhwohfKA("Touchpad " + num15, text10);
			}
			bool[] array4 = KTcIssEfoJvldVQYufZEsSthCRbp.XPBAEEmRYSySyiigVJUQqmZPfAXBA;
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
			JOAXRVgSNeDWRHPXyIjCzGvqYzlN("Buttons ", text11);
		}
		gIbbxZGVZkMkKhjpHhPytRatjCxkB.text = fUKBsrBtgKGATuOMVMFKZRWwWnhGA;
	}

	void IElementIdentifierTool.Update()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Update
		this.Update();
	}

	public void OnDestroy()
	{
		if (KTcIssEfoJvldVQYufZEsSthCRbp != null)
		{
			KTcIssEfoJvldVQYufZEsSthCRbp.yGdDLHAwGvGPIqTacoLVHuIKsVwr();
		}
	}

	void IElementIdentifierTool.OnDestroy()
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnDestroy
		this.OnDestroy();
	}

	private void cQgHqAJSvKOboIhHeKPBbinwxfAh()
	{
		PMApWhcKcYeNvSLOZhTVcYzFzNQdA = AcrlPVMOXXzrRhxppuGwNyAfQyhd.GetJoysticks<qMLHUgANpXxKCmRpGepdcfgprHTj>();
	}

	private void TsjfZfoGRiLfKtQzAKCRmbnXvgdh()
	{
		nUChNYGGdIiAQDjRbdKKfLygMAWf();
	}

	private void MDtdrXXKmGajnkakGXfEVqhPuiEs()
	{
		nUChNYGGdIiAQDjRbdKKfLygMAWf();
	}

	private void nUChNYGGdIiAQDjRbdKKfLygMAWf()
	{
		vntvRdxfMYPSluzgBncsqQKbgBdN();
		DOiRdZkbPzGcgLcWsfIHByBLceWp = true;
	}

	private void vntvRdxfMYPSluzgBncsqQKbgBdN()
	{
		guDBETttaatZtmHpZQwMJEMYtpGp = 0;
		KTcIssEfoJvldVQYufZEsSthCRbp = null;
		OYqSEvMOFYAwZJgwThoTiIttCxYP = Guid.Empty;
		PMApWhcKcYeNvSLOZhTVcYzFzNQdA = null;
		NsyBPIhFjnyzqiNlbUFBUgiHODaBA = false;
		DOiRdZkbPzGcgLcWsfIHByBLceWp = false;
	}

	private void JOAXRVgSNeDWRHPXyIjCzGvqYzlN(string P_0, object P_1)
	{
		fUKBsrBtgKGATuOMVMFKZRWwWnhGA = fUKBsrBtgKGATuOMVMFKZRWwWnhGA + P_0 + " = " + P_1.ToString() + "\n";
	}

	private void xOkgBrfymjGIcvKotpyChMhwohfKA(string P_0, object P_1)
	{
		fUKBsrBtgKGATuOMVMFKZRWwWnhGA = fUKBsrBtgKGATuOMVMFKZRWwWnhGA + P_0 + ":\n" + P_1.ToString() + "\n";
	}

	private int OvUhKxJEQPktUSNjDnNUtinLJlxQ(RawInputAxis P_0, int P_1, MSnnYaHlzXooFhgMKAHsgeYdqLSj P_2)
	{
		return P_2.phycLHHgVoPEsIuXFPiFNHHIldNMA(P_0, P_1);
	}

	private float buaRrVigeCEdaPqPZXMBzTLhwfoe(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}
}
