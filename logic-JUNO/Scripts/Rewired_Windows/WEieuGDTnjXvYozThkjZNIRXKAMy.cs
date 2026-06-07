using System;
using System.Collections.Generic;
using Rewired;
using Rewired.HID;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

internal sealed class WEieuGDTnjXvYozThkjZNIRXKAMy : IElementIdentifierTool
{
	private Rewired.Internal.GUIText CBhjeUgHGdTiaJonbmypcjfGaHeVb;

	private string RPYFlgrshPEInHLYLBgBIpFjtuuab;

	private int GkLPlMhAhxILPbmnNsTDjzHRsmJR;

	private PtZxJDakPjxrloDZyiNQFrvDzsve ubtkxKOEJUjSfcdhzFKnbPzgZygi;

	private KsPSzxQcqUtvkddpYRqqAlhgiDSe qosepnUOjOGbZKSMmGuJUJeanOur;

	private Guid sJmyDySRONPUhGtuBgLGIpeoMkRU;

	private IList<KsPSzxQcqUtvkddpYRqqAlhgiDSe> ruMPLqeZzTXSVXfEDkqYksySIMVt;

	private bool fsqgMBGHiiyrKTUdfiaQyAhAtOlqA;

	private bool dMuIEMoAOeKLCKHIaelSlnCQZtZR;

	private bool lbMOUAwMAHsmUjLhHIyaMFXBZNjb;

	private string[] nzoevPpuWiEAoZeEtGluCXKuKCEf;

	private int[] ITiuEUcSMXvGSdNQeJBfIReEAhQb;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		CBhjeUgHGdTiaJonbmypcjfGaHeVb = text;
		nzoevPpuWiEAoZeEtGluCXKuKCEf = Enum.GetNames(typeof(RawInputAxis));
		ITiuEUcSMXvGSdNQeJBfIReEAhQb = (int[])Enum.GetValues(typeof(RawInputAxis));
	}

	void IElementIdentifierTool.Initialize(Rewired.Internal.GUIText text)
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
		ubtkxKOEJUjSfcdhzFKnbPzgZygi = ReInput.primaryInputManager.inputSource as PtZxJDakPjxrloDZyiNQFrvDzsve;
		if (ubtkxKOEJUjSfcdhzFKnbPzgZygi == null)
		{
			Rewired.Logger.LogError("Unable to initialize Raw Input! You must add a Rewired Input Manager to the scene and set the input mode to Raw Input.");
			return;
		}
		ReInput.primaryInputManager.SystemDeviceConnectedEvent += hldydcubBlFvsgKuClESIduKkMuL;
		ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += qCraqUFUzPdhDbcuQYAZhhkSgfPGA;
		CKwSRHRbLHMiUNMbcxOYDZnlyMTL();
		lbMOUAwMAHsmUjLhHIyaMFXBZNjb = true;
	}

	void IElementIdentifierTool.Start()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Start
		this.Start();
	}

	public void Update()
	{
		if (!lbMOUAwMAHsmUjLhHIyaMFXBZNjb)
		{
			return;
		}
		RPYFlgrshPEInHLYLBgBIpFjtuuab = "Raw Input Joystick Element Identifier\n\n";
		CBhjeUgHGdTiaJonbmypcjfGaHeVb.text = RPYFlgrshPEInHLYLBgBIpFjtuuab;
		int gkLPlMhAhxILPbmnNsTDjzHRsmJR = GkLPlMhAhxILPbmnNsTDjzHRsmJR;
		Guid guid = sJmyDySRONPUhGtuBgLGIpeoMkRU;
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Equals) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Plus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadPlus))
		{
			GkLPlMhAhxILPbmnNsTDjzHRsmJR++;
		}
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadMinus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Minus))
		{
			GkLPlMhAhxILPbmnNsTDjzHRsmJR--;
		}
		if (dMuIEMoAOeKLCKHIaelSlnCQZtZR)
		{
			CKwSRHRbLHMiUNMbcxOYDZnlyMTL();
			dMuIEMoAOeKLCKHIaelSlnCQZtZR = false;
		}
		int num = ((ruMPLqeZzTXSVXfEDkqYksySIMVt != null) ? ruMPLqeZzTXSVXfEDkqYksySIMVt.Count : 0);
		if (num == 0)
		{
			return;
		}
		if (GkLPlMhAhxILPbmnNsTDjzHRsmJR < 0)
		{
			GkLPlMhAhxILPbmnNsTDjzHRsmJR = num - 1;
		}
		else if (GkLPlMhAhxILPbmnNsTDjzHRsmJR >= num)
		{
			GkLPlMhAhxILPbmnNsTDjzHRsmJR = 0;
		}
		sJmyDySRONPUhGtuBgLGIpeoMkRU = ruMPLqeZzTXSVXfEDkqYksySIMVt[GkLPlMhAhxILPbmnNsTDjzHRsmJR].jHebtBIWiEcsbJJOKPGjnGweZWKpA;
		bool flag = false;
		if (gkLPlMhAhxILPbmnNsTDjzHRsmJR != GkLPlMhAhxILPbmnNsTDjzHRsmJR || guid != sJmyDySRONPUhGtuBgLGIpeoMkRU)
		{
			flag = true;
		}
		if (qosepnUOjOGbZKSMmGuJUJeanOur == null || flag)
		{
			if (qosepnUOjOGbZKSMmGuJUJeanOur != null)
			{
				qosepnUOjOGbZKSMmGuJUJeanOur.GbrLWQWoTqIVmzpoqpiCbqNRJGdp();
			}
			qosepnUOjOGbZKSMmGuJUJeanOur = ruMPLqeZzTXSVXfEDkqYksySIMVt[GkLPlMhAhxILPbmnNsTDjzHRsmJR];
			if (qosepnUOjOGbZKSMmGuJUJeanOur == null)
			{
				return;
			}
			qosepnUOjOGbZKSMmGuJUJeanOur.WNISmWtDFejmLKZCdlcguOBQcoVYA();
		}
		bool flag2 = false;
		if (qosepnUOjOGbZKSMmGuJUJeanOur.iTUibayzySxhMznaGDqWrBUvFOeO is iLxYqULhLHYVzWUNInwsvFMgTLJw)
		{
			flag2 = true;
		}
		else if (!(qosepnUOjOGbZKSMmGuJUJeanOur.iTUibayzySxhMznaGDqWrBUvFOeO is uKzsBlRJaUgSlwuiUzLvEjLexiNL))
		{
			return;
		}
		if (num > 0)
		{
			RPYFlgrshPEInHLYLBgBIpFjtuuab = RPYFlgrshPEInHLYLBgBIpFjtuuab + num + " connected devices:\n";
		}
		for (int i = 0; i < num; i++)
		{
			RPYFlgrshPEInHLYLBgBIpFjtuuab = RPYFlgrshPEInHLYLBgBIpFjtuuab + ruMPLqeZzTXSVXfEDkqYksySIMVt[i].OZaxqjHzvqAAUAPlNFBOJMIFQXSU + "\n";
		}
		RPYFlgrshPEInHLYLBgBIpFjtuuab += "\n";
		RPYFlgrshPEInHLYLBgBIpFjtuuab = RPYFlgrshPEInHLYLBgBIpFjtuuab + "Current RI device " + GkLPlMhAhxILPbmnNsTDjzHRsmJR + ": \"" + qosepnUOjOGbZKSMmGuJUJeanOur.OZaxqjHzvqAAUAPlNFBOJMIFQXSU + "\"\n";
		RPYFlgrshPEInHLYLBgBIpFjtuuab += "(Press + or - to change monitored device id.)\n\n";
		duWSQKiBObTMbOqHkMGFNegbPigX("Product Name", "\"" + qosepnUOjOGbZKSMmGuJUJeanOur.OZaxqjHzvqAAUAPlNFBOJMIFQXSU + "\"");
		duWSQKiBObTMbOqHkMGFNegbPigX("Is Bluetooth Device", qosepnUOjOGbZKSMmGuJUJeanOur.lpwEZBInmOutBzQaeALNdwBCgvhCA);
		if (qosepnUOjOGbZKSMmGuJUJeanOur.lpwEZBInmOutBzQaeALNdwBCgvhCA)
		{
			duWSQKiBObTMbOqHkMGFNegbPigX("Bluetooth Device Name", "\"" + qosepnUOjOGbZKSMmGuJUJeanOur.dtCehBfYGvZlLYsontGhvanEwywg + "\"");
		}
		if (flag2)
		{
			duWSQKiBObTMbOqHkMGFNegbPigX("Using Custom Driver", "TRUE");
		}
		duWSQKiBObTMbOqHkMGFNegbPigX("Device Type", qosepnUOjOGbZKSMmGuJUJeanOur.lfNimxGKYpveXVyOaOkewvgpkffgb.ToString());
		duWSQKiBObTMbOqHkMGFNegbPigX("Identifier", new PidVid(qosepnUOjOGbZKSMmGuJUJeanOur.ZlnPlwZFYVacagxgNsaIlxubBFym));
		duWSQKiBObTMbOqHkMGFNegbPigX("Product Id", qosepnUOjOGbZKSMmGuJUJeanOur.qwWBUCsdRljeVoPFimjsCKPMyKjB);
		duWSQKiBObTMbOqHkMGFNegbPigX("Vendor Id", qosepnUOjOGbZKSMmGuJUJeanOur.XbmeRDAXvQiBISRJBhCBUQSAzNWUA);
		RPYFlgrshPEInHLYLBgBIpFjtuuab += "\n";
		duWSQKiBObTMbOqHkMGFNegbPigX("Axis Count", qosepnUOjOGbZKSMmGuJUJeanOur.vNBfFkwWjnyUtlkuQYjPxzuCkUOs);
		duWSQKiBObTMbOqHkMGFNegbPigX("Button Count", qosepnUOjOGbZKSMmGuJUJeanOur.RjGWzCNXiMvLyoAsnFukyHiipjJo);
		duWSQKiBObTMbOqHkMGFNegbPigX("Hat Count", qosepnUOjOGbZKSMmGuJUJeanOur.TzxaCrZribnxrdyUIjMuKBKLGUCD);
		RPYFlgrshPEInHLYLBgBIpFjtuuab += "\n";
		if (flag)
		{
			string text = "";
			text = text + "Device Name: \"" + ruMPLqeZzTXSVXfEDkqYksySIMVt[GkLPlMhAhxILPbmnNsTDjzHRsmJR].OZaxqjHzvqAAUAPlNFBOJMIFQXSU + "\"\n";
			if (qosepnUOjOGbZKSMmGuJUJeanOur.lpwEZBInmOutBzQaeALNdwBCgvhCA)
			{
				text = text + "Bluetooth Device Name: \"" + qosepnUOjOGbZKSMmGuJUJeanOur.dtCehBfYGvZlLYsontGhvanEwywg + "\"\n";
			}
			text = text + "Identifier: " + new PidVid(qosepnUOjOGbZKSMmGuJUJeanOur.ZlnPlwZFYVacagxgNsaIlxubBFym).ToString() + "\n";
			Rewired.Logger.Log(text);
		}
		if (!flag2)
		{
			uKzsBlRJaUgSlwuiUzLvEjLexiNL uKzsBlRJaUgSlwuiUzLvEjLexiNL2 = qosepnUOjOGbZKSMmGuJUJeanOur.iTUibayzySxhMznaGDqWrBUvFOeO as uKzsBlRJaUgSlwuiUzLvEjLexiNL;
			for (int j = 1; j < nzoevPpuWiEAoZeEtGluCXKuKCEf.Length - 1; j++)
			{
				int num2 = olKdmeXNFAGpaFJrTHmBHTwGLsueb((RawInputAxis)ITiuEUcSMXvGSdNQeJBfIReEAhQb[j], 0, uKzsBlRJaUgSlwuiUzLvEjLexiNL2);
				string text2 = nzoevPpuWiEAoZeEtGluCXKuKCEf[j];
				try
				{
					duWSQKiBObTMbOqHkMGFNegbPigX(text2, num2 + " (" + VwEtgiAjFeWQUtuJkcGHNIuPjdo(num2) + ")");
				}
				catch
				{
					duWSQKiBObTMbOqHkMGFNegbPigX(text2, "FAILED! Axis value = " + num2);
				}
			}
			if (uKzsBlRJaUgSlwuiUzLvEjLexiNL2.PaJdNpiRFpyPQsBAtYGvtioWoezyA > 0)
			{
				for (int k = 0; k < uKzsBlRJaUgSlwuiUzLvEjLexiNL2.PaJdNpiRFpyPQsBAtYGvtioWoezyA; k++)
				{
					int num3 = olKdmeXNFAGpaFJrTHmBHTwGLsueb(RawInputAxis.Other, k, uKzsBlRJaUgSlwuiUzLvEjLexiNL2);
					string text3 = "Other Axis " + k;
					try
					{
						duWSQKiBObTMbOqHkMGFNegbPigX(text3, num3 + " (" + VwEtgiAjFeWQUtuJkcGHNIuPjdo(num3) + ")");
					}
					catch
					{
						duWSQKiBObTMbOqHkMGFNegbPigX(text3, "FAILED! Axis value = " + num3);
					}
				}
			}
			int[] array = qosepnUOjOGbZKSMmGuJUJeanOur.gNlFDeSkoDTCYlYEcPedVYEKQdOJ;
			for (int l = 0; l < array.Length; l++)
			{
				int num4 = array[l];
				string text4 = "Hat " + l;
				duWSQKiBObTMbOqHkMGFNegbPigX(text4, num4);
			}
			bool[] array2 = qosepnUOjOGbZKSMmGuJUJeanOur.noFaBVsAZVUYUbMqLItRWwCEGNWW;
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
			duWSQKiBObTMbOqHkMGFNegbPigX("Buttons ", text5);
		}
		else
		{
			iLxYqULhLHYVzWUNInwsvFMgTLJw iLxYqULhLHYVzWUNInwsvFMgTLJw2 = qosepnUOjOGbZKSMmGuJUJeanOur.iTUibayzySxhMznaGDqWrBUvFOeO as iLxYqULhLHYVzWUNInwsvFMgTLJw;
			for (int n = 0; n < qosepnUOjOGbZKSMmGuJUJeanOur.vNBfFkwWjnyUtlkuQYjPxzuCkUOs; n++)
			{
				float num5 = iLxYqULhLHYVzWUNInwsvFMgTLJw2.AvmFaVwVxdsffZPseEpEUlAxasjL(n);
				string text6 = n.ToString();
				try
				{
					duWSQKiBObTMbOqHkMGFNegbPigX(text6, num5 + " (" + iLxYqULhLHYVzWUNInwsvFMgTLJw2.xplWLXEautdRpIIdCautWiKzBlMG(n) + ")");
				}
				catch
				{
					duWSQKiBObTMbOqHkMGFNegbPigX(text6, "FAILED! Axis value = " + num5);
				}
			}
			int[] array3 = qosepnUOjOGbZKSMmGuJUJeanOur.gNlFDeSkoDTCYlYEcPedVYEKQdOJ;
			for (int num6 = 0; num6 < qosepnUOjOGbZKSMmGuJUJeanOur.TzxaCrZribnxrdyUIjMuKBKLGUCD; num6++)
			{
				int num7 = array3[num6];
				string text7 = "Hat " + num6;
				duWSQKiBObTMbOqHkMGFNegbPigX(text7, num7);
			}
			for (int num8 = 0; num8 < qosepnUOjOGbZKSMmGuJUJeanOur.gJkkVuUYHhHTwOqqiNtNINTKKwIc.GyroscopeCount; num8++)
			{
				int valueLength = qosepnUOjOGbZKSMmGuJUJeanOur.gJkkVuUYHhHTwOqqiNtNINTKKwIc.gyroscopes[num8].valueLength;
				string text8 = "";
				for (int num9 = 0; num9 < valueLength; num9++)
				{
					float num10 = qosepnUOjOGbZKSMmGuJUJeanOur.gJkkVuUYHhHTwOqqiNtNINTKKwIc.gyroscopes[num8].rawValue[num9];
					text8 = text8 + "[" + num9 + "]: " + num10.ToString("f3");
					if (num9 < valueLength - 1)
					{
						text8 += " ";
					}
				}
				duWSQKiBObTMbOqHkMGFNegbPigX("Gyro " + num8, text8);
			}
			for (int num11 = 0; num11 < qosepnUOjOGbZKSMmGuJUJeanOur.gJkkVuUYHhHTwOqqiNtNINTKKwIc.AccelerometerCount; num11++)
			{
				int valueLength2 = qosepnUOjOGbZKSMmGuJUJeanOur.gJkkVuUYHhHTwOqqiNtNINTKKwIc.accelerometers[num11].valueLength;
				string text9 = "";
				for (int num12 = 0; num12 < valueLength2; num12++)
				{
					float num13 = qosepnUOjOGbZKSMmGuJUJeanOur.gJkkVuUYHhHTwOqqiNtNINTKKwIc.accelerometers[num11].rawValue[num12];
					text9 = text9 + "[" + num12 + "]: " + num13.ToString("f3");
					if (num12 < valueLength2 - 1)
					{
						text9 += " ";
					}
				}
				duWSQKiBObTMbOqHkMGFNegbPigX("Accelerometer " + num11, text9);
			}
			for (int num14 = 0; num14 < qosepnUOjOGbZKSMmGuJUJeanOur.gJkkVuUYHhHTwOqqiNtNINTKKwIc.TouchpadCount; num14++)
			{
				HIDTouchpad hIDTouchpad = qosepnUOjOGbZKSMmGuJUJeanOur.gJkkVuUYHhHTwOqqiNtNINTKKwIc.touchpads[num14];
				int num15 = hIDTouchpad.values.Length;
				string text10 = "";
				for (int num16 = 0; num16 < num15; num16++)
				{
					HIDTouchpad.TouchData touchData = hIDTouchpad.values[num16];
					text10 = text10 + "Touch " + num16 + ": Is Touching = " + touchData.isTouching + "\n";
					text10 = text10 + "Touch " + num16 + ": Touch Id = " + touchData.touchId + "\n";
					text10 = text10 + "Touch " + num16 + ": Position = " + touchData.positionX + ", " + touchData.positionY + "\n";
					text10 = text10 + "Touch " + num16 + ": Abs Position = " + touchData.positionAbsX + ", " + touchData.positionAbsY + " (" + touchData.positionRawX + ", " + touchData.positionRawY + ")\n";
				}
				NvecCyAczwiKYVTcpCBNsuehxwiAA("Touchpad " + num14, text10);
			}
			bool[] array4 = qosepnUOjOGbZKSMmGuJUJeanOur.noFaBVsAZVUYUbMqLItRWwCEGNWW;
			string text11 = "";
			for (int num17 = 0; num17 < array4.Length; num17++)
			{
				if (array4[num17])
				{
					if (text11 != "")
					{
						text11 += ", ";
					}
					text11 += num17;
				}
			}
			duWSQKiBObTMbOqHkMGFNegbPigX("Buttons ", text11);
		}
		CBhjeUgHGdTiaJonbmypcjfGaHeVb.text = RPYFlgrshPEInHLYLBgBIpFjtuuab;
	}

	void IElementIdentifierTool.Update()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Update
		this.Update();
	}

	public void OnDestroy()
	{
		if (qosepnUOjOGbZKSMmGuJUJeanOur != null)
		{
			qosepnUOjOGbZKSMmGuJUJeanOur.GbrLWQWoTqIVmzpoqpiCbqNRJGdp();
		}
	}

	void IElementIdentifierTool.OnDestroy()
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnDestroy
		this.OnDestroy();
	}

	private void CKwSRHRbLHMiUNMbcxOYDZnlyMTL()
	{
		ruMPLqeZzTXSVXfEDkqYksySIMVt = ubtkxKOEJUjSfcdhzFKnbPzgZygi.GetJoysticks<KsPSzxQcqUtvkddpYRqqAlhgiDSe>();
	}

	private void hldydcubBlFvsgKuClESIduKkMuL()
	{
		XgCaKXUDVHgVsArThWNHTSfhZJZH();
	}

	private void qCraqUFUzPdhDbcuQYAZhhkSgfPGA()
	{
		XgCaKXUDVHgVsArThWNHTSfhZJZH();
	}

	private void XgCaKXUDVHgVsArThWNHTSfhZJZH()
	{
		NvlVQiztPHhCFpruFVFlOVTytAyx();
		dMuIEMoAOeKLCKHIaelSlnCQZtZR = true;
	}

	private void NvlVQiztPHhCFpruFVFlOVTytAyx()
	{
		GkLPlMhAhxILPbmnNsTDjzHRsmJR = 0;
		qosepnUOjOGbZKSMmGuJUJeanOur = null;
		sJmyDySRONPUhGtuBgLGIpeoMkRU = Guid.Empty;
		ruMPLqeZzTXSVXfEDkqYksySIMVt = null;
		fsqgMBGHiiyrKTUdfiaQyAhAtOlqA = false;
		dMuIEMoAOeKLCKHIaelSlnCQZtZR = false;
	}

	private void duWSQKiBObTMbOqHkMGFNegbPigX(string P_0, object P_1)
	{
		RPYFlgrshPEInHLYLBgBIpFjtuuab = RPYFlgrshPEInHLYLBgBIpFjtuuab + P_0 + " = " + P_1.ToString() + "\n";
	}

	private void NvecCyAczwiKYVTcpCBNsuehxwiAA(string P_0, object P_1)
	{
		RPYFlgrshPEInHLYLBgBIpFjtuuab = RPYFlgrshPEInHLYLBgBIpFjtuuab + P_0 + ":\n" + P_1.ToString() + "\n";
	}

	private int olKdmeXNFAGpaFJrTHmBHTwGLsueb(RawInputAxis P_0, int P_1, uKzsBlRJaUgSlwuiUzLvEjLexiNL P_2)
	{
		return P_2.ZCqFQKiuUzqOOHxViPDMtxSIFgYEB(P_0, P_1);
	}

	private float VwEtgiAjFeWQUtuJkcGHNIuPjdo(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}
}
