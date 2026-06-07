using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

internal sealed class msQNZbobIYYXLUApZmkTmfWFdCkH : IElementIdentifierTool
{
	private Rewired.Internal.GUIText ivNLKlwltSXlbEmHJdrxSSeeeOIH;

	private string fDiMwZUJCorjulfurbdVUiAvdXSX;

	private int qQpWcdOlIIQcUHTLnbOVKkOViJbKA;

	private BqakktYRwNvnDKTTjDQXbTstkBmA KYNhTjdqctfCiKkBFHUxKXseswWv;

	private GFzeCCkaUHxzLqMmAXGJQcvsbFsv AvGCwYrMHvKMKkejYvrRljHgvBIh;

	private Guid AtGdaRlqxgYtseQCjnKUpvpeoDbX;

	private IList<GFzeCCkaUHxzLqMmAXGJQcvsbFsv> HVgqdXRGBeeQKrwcfdcQZhfQbdhH;

	private bool TFQnsymmBBAUNeJRFfJYregIivPy;

	private bool PMCEbfTwpJspZsYoYpeIUjTCwUvX;

	private bool NqJntrFxlgSLzXcvrCFgHdMPyefqA;

	private string[] NqKeNgOKBHmdnljIZpPidLQsIpar;

	private int[] kgbpFxPQhvlATXIxcUODhsGKmhDM;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		ivNLKlwltSXlbEmHJdrxSSeeeOIH = text;
		NqKeNgOKBHmdnljIZpPidLQsIpar = Enum.GetNames(typeof(RawInputAxis));
		kgbpFxPQhvlATXIxcUODhsGKmhDM = (int[])Enum.GetValues(typeof(RawInputAxis));
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
		KYNhTjdqctfCiKkBFHUxKXseswWv = ReInput.primaryInputManager.inputSource as BqakktYRwNvnDKTTjDQXbTstkBmA;
		if (KYNhTjdqctfCiKkBFHUxKXseswWv == null)
		{
			Rewired.Logger.LogError("Unable to initialize Raw Input! You must add a Rewired Input Manager to the scene and set the input mode to Raw Input.");
			return;
		}
		ReInput.primaryInputManager.SystemDeviceConnectedEvent += DjVfVBDmuECedQNcsGcCdehKSBMM;
		ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += WuXsVlifYawGSXPGkjHBQnjMCOhHA;
		yeUjtqcvcaVlBxxZUIwMyBynqLdW();
		NqJntrFxlgSLzXcvrCFgHdMPyefqA = true;
	}

	void IElementIdentifierTool.Start()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Start
		this.Start();
	}

	public void Update()
	{
		if (!NqJntrFxlgSLzXcvrCFgHdMPyefqA)
		{
			return;
		}
		fDiMwZUJCorjulfurbdVUiAvdXSX = "Raw Input Joystick Element Identifier\n\n";
		ivNLKlwltSXlbEmHJdrxSSeeeOIH.text = fDiMwZUJCorjulfurbdVUiAvdXSX;
		int num = qQpWcdOlIIQcUHTLnbOVKkOViJbKA;
		Guid atGdaRlqxgYtseQCjnKUpvpeoDbX = AtGdaRlqxgYtseQCjnKUpvpeoDbX;
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Equals) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Plus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadPlus))
		{
			qQpWcdOlIIQcUHTLnbOVKkOViJbKA++;
		}
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadMinus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Minus))
		{
			qQpWcdOlIIQcUHTLnbOVKkOViJbKA--;
		}
		if (PMCEbfTwpJspZsYoYpeIUjTCwUvX)
		{
			yeUjtqcvcaVlBxxZUIwMyBynqLdW();
			PMCEbfTwpJspZsYoYpeIUjTCwUvX = false;
		}
		int num2 = ((HVgqdXRGBeeQKrwcfdcQZhfQbdhH != null) ? HVgqdXRGBeeQKrwcfdcQZhfQbdhH.Count : 0);
		if (num2 == 0)
		{
			return;
		}
		if (qQpWcdOlIIQcUHTLnbOVKkOViJbKA < 0)
		{
			qQpWcdOlIIQcUHTLnbOVKkOViJbKA = num2 - 1;
		}
		else if (qQpWcdOlIIQcUHTLnbOVKkOViJbKA >= num2)
		{
			qQpWcdOlIIQcUHTLnbOVKkOViJbKA = 0;
		}
		AtGdaRlqxgYtseQCjnKUpvpeoDbX = HVgqdXRGBeeQKrwcfdcQZhfQbdhH[qQpWcdOlIIQcUHTLnbOVKkOViJbKA].phjbIzJwpfaHndTsqJBOtHvTTudeA;
		bool flag = false;
		if (num != qQpWcdOlIIQcUHTLnbOVKkOViJbKA || atGdaRlqxgYtseQCjnKUpvpeoDbX != AtGdaRlqxgYtseQCjnKUpvpeoDbX)
		{
			flag = true;
		}
		if (AvGCwYrMHvKMKkejYvrRljHgvBIh == null || flag)
		{
			if (AvGCwYrMHvKMKkejYvrRljHgvBIh != null)
			{
				AvGCwYrMHvKMKkejYvrRljHgvBIh.LFubPekUlWjjnGGXgCSBpgQpWoqvB();
			}
			AvGCwYrMHvKMKkejYvrRljHgvBIh = HVgqdXRGBeeQKrwcfdcQZhfQbdhH[qQpWcdOlIIQcUHTLnbOVKkOViJbKA];
			if (AvGCwYrMHvKMKkejYvrRljHgvBIh == null)
			{
				return;
			}
			AvGCwYrMHvKMKkejYvrRljHgvBIh.vxAebkHmVZCbhNjZXXsFPZJWBHOK();
		}
		bool flag2 = false;
		if (AvGCwYrMHvKMKkejYvrRljHgvBIh.zeKnungAQHNsmgJDLErFJHBMUNwe is qOWNeWiQdvONIuaeCdEikuUBUJEl)
		{
			flag2 = true;
		}
		else if (!(AvGCwYrMHvKMKkejYvrRljHgvBIh.zeKnungAQHNsmgJDLErFJHBMUNwe is fliORgAWnNfkUHOriNcTSiLVhTfIA))
		{
			return;
		}
		if (num2 > 0)
		{
			fDiMwZUJCorjulfurbdVUiAvdXSX = fDiMwZUJCorjulfurbdVUiAvdXSX + num2 + " connected devices:\n";
		}
		for (int i = 0; i < num2; i++)
		{
			fDiMwZUJCorjulfurbdVUiAvdXSX = fDiMwZUJCorjulfurbdVUiAvdXSX + HVgqdXRGBeeQKrwcfdcQZhfQbdhH[i].VhebEQKXpmCJgYSzUThqlsfqMoVkA + "\n";
		}
		fDiMwZUJCorjulfurbdVUiAvdXSX += "\n";
		fDiMwZUJCorjulfurbdVUiAvdXSX = fDiMwZUJCorjulfurbdVUiAvdXSX + "Current RI device " + qQpWcdOlIIQcUHTLnbOVKkOViJbKA + ": \"" + AvGCwYrMHvKMKkejYvrRljHgvBIh.VhebEQKXpmCJgYSzUThqlsfqMoVkA + "\"\n";
		fDiMwZUJCorjulfurbdVUiAvdXSX += "(Press + or - to change monitored device id.)\n\n";
		LdcbvjTMxUczkAsfGCXJAgbIpFKBB("Product Name", "\"" + AvGCwYrMHvKMKkejYvrRljHgvBIh.VhebEQKXpmCJgYSzUThqlsfqMoVkA + "\"");
		LdcbvjTMxUczkAsfGCXJAgbIpFKBB("Is Bluetooth Device", AvGCwYrMHvKMKkejYvrRljHgvBIh.RYehePePOJhoDoBdQdzwgDtYfmccb);
		if (AvGCwYrMHvKMKkejYvrRljHgvBIh.RYehePePOJhoDoBdQdzwgDtYfmccb)
		{
			LdcbvjTMxUczkAsfGCXJAgbIpFKBB("Bluetooth Device Name", "\"" + AvGCwYrMHvKMKkejYvrRljHgvBIh.WBMgidYMSTZBedYHaRzndjzWWXzi + "\"");
		}
		if (flag2)
		{
			LdcbvjTMxUczkAsfGCXJAgbIpFKBB("Using Custom Driver", "TRUE");
		}
		LdcbvjTMxUczkAsfGCXJAgbIpFKBB("Device Type", AvGCwYrMHvKMKkejYvrRljHgvBIh.ghGDQestAGYUNKYdRaWNXafVGvwI.ToString());
		LdcbvjTMxUczkAsfGCXJAgbIpFKBB("Identifier", new PidVid(AvGCwYrMHvKMKkejYvrRljHgvBIh.vSXXdZFcWHtbAwOjUQJqVgkyjHVT));
		LdcbvjTMxUczkAsfGCXJAgbIpFKBB("Product Id", AvGCwYrMHvKMKkejYvrRljHgvBIh.ZPmGRXCxBEwOQOdOWCuUXGtyzwneA);
		LdcbvjTMxUczkAsfGCXJAgbIpFKBB("Vendor Id", AvGCwYrMHvKMKkejYvrRljHgvBIh.ZmTpVjBHdSymNuhkHzqHwAFRNBHe);
		fDiMwZUJCorjulfurbdVUiAvdXSX += "\n";
		LdcbvjTMxUczkAsfGCXJAgbIpFKBB("Axis Count", AvGCwYrMHvKMKkejYvrRljHgvBIh.uCKAvRYcsaaXxcxYMNIAjYSlGYYuA);
		LdcbvjTMxUczkAsfGCXJAgbIpFKBB("Button Count", AvGCwYrMHvKMKkejYvrRljHgvBIh.YkHEMGjoxxtiIEKFQuSelHBSQytyA);
		LdcbvjTMxUczkAsfGCXJAgbIpFKBB("Hat Count", AvGCwYrMHvKMKkejYvrRljHgvBIh.kZsWpxnWNKvqMhPhWInkvoUuLxKi);
		fDiMwZUJCorjulfurbdVUiAvdXSX += "\n";
		if (flag)
		{
			string text = "";
			text = text + "Device Name: \"" + HVgqdXRGBeeQKrwcfdcQZhfQbdhH[qQpWcdOlIIQcUHTLnbOVKkOViJbKA].VhebEQKXpmCJgYSzUThqlsfqMoVkA + "\"\n";
			if (AvGCwYrMHvKMKkejYvrRljHgvBIh.RYehePePOJhoDoBdQdzwgDtYfmccb)
			{
				text = text + "Bluetooth Device Name: \"" + AvGCwYrMHvKMKkejYvrRljHgvBIh.WBMgidYMSTZBedYHaRzndjzWWXzi + "\"\n";
			}
			text = text + "Identifier: " + new PidVid(AvGCwYrMHvKMKkejYvrRljHgvBIh.vSXXdZFcWHtbAwOjUQJqVgkyjHVT).ToString() + "\n";
			Rewired.Logger.Log(text);
		}
		if (!flag2)
		{
			fliORgAWnNfkUHOriNcTSiLVhTfIA fliORgAWnNfkUHOriNcTSiLVhTfIA2 = AvGCwYrMHvKMKkejYvrRljHgvBIh.zeKnungAQHNsmgJDLErFJHBMUNwe as fliORgAWnNfkUHOriNcTSiLVhTfIA;
			for (int j = 1; j < NqKeNgOKBHmdnljIZpPidLQsIpar.Length - 1; j++)
			{
				int num3 = FJnDeiQExyTAzSOwAEhDkdwlkLkrA((RawInputAxis)kgbpFxPQhvlATXIxcUODhsGKmhDM[j], 0, fliORgAWnNfkUHOriNcTSiLVhTfIA2);
				string text2 = NqKeNgOKBHmdnljIZpPidLQsIpar[j];
				try
				{
					LdcbvjTMxUczkAsfGCXJAgbIpFKBB(text2, num3 + " (" + pNGPdDDXCiVdPsKAhVhYeXVshGZR(num3) + ")");
				}
				catch
				{
					LdcbvjTMxUczkAsfGCXJAgbIpFKBB(text2, "FAILED! Axis value = " + num3);
				}
			}
			if (fliORgAWnNfkUHOriNcTSiLVhTfIA2.FeSEnlcYdfDmwAbeGmOpqYsypPPgb > 0)
			{
				for (int k = 0; k < fliORgAWnNfkUHOriNcTSiLVhTfIA2.FeSEnlcYdfDmwAbeGmOpqYsypPPgb; k++)
				{
					int num4 = FJnDeiQExyTAzSOwAEhDkdwlkLkrA(RawInputAxis.Other, k, fliORgAWnNfkUHOriNcTSiLVhTfIA2);
					string text3 = "Other Axis " + k;
					try
					{
						LdcbvjTMxUczkAsfGCXJAgbIpFKBB(text3, num4 + " (" + pNGPdDDXCiVdPsKAhVhYeXVshGZR(num4) + ")");
					}
					catch
					{
						LdcbvjTMxUczkAsfGCXJAgbIpFKBB(text3, "FAILED! Axis value = " + num4);
					}
				}
			}
			int[] array = AvGCwYrMHvKMKkejYvrRljHgvBIh.iNZAlcTuJdKxgpvgzJhhytQGEdGu;
			for (int l = 0; l < array.Length; l++)
			{
				int num5 = array[l];
				string text4 = "Hat " + l;
				LdcbvjTMxUczkAsfGCXJAgbIpFKBB(text4, num5);
			}
			bool[] array2 = AvGCwYrMHvKMKkejYvrRljHgvBIh.fMvoddvLKADYDxhEtImxPIqUBYaj;
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
			LdcbvjTMxUczkAsfGCXJAgbIpFKBB("Buttons ", text5);
		}
		else
		{
			qOWNeWiQdvONIuaeCdEikuUBUJEl qOWNeWiQdvONIuaeCdEikuUBUJEl2 = AvGCwYrMHvKMKkejYvrRljHgvBIh.zeKnungAQHNsmgJDLErFJHBMUNwe as qOWNeWiQdvONIuaeCdEikuUBUJEl;
			for (int n = 0; n < AvGCwYrMHvKMKkejYvrRljHgvBIh.uCKAvRYcsaaXxcxYMNIAjYSlGYYuA; n++)
			{
				float num6 = qOWNeWiQdvONIuaeCdEikuUBUJEl2.FEwzcuOSWJbRpUsfxTtQBSrREWUG(n);
				string text6 = n.ToString();
				try
				{
					LdcbvjTMxUczkAsfGCXJAgbIpFKBB(text6, num6 + " (" + qOWNeWiQdvONIuaeCdEikuUBUJEl2.qHYmLjQbAVMgsUKQcxNcxNHFceqo(n) + ")");
				}
				catch
				{
					LdcbvjTMxUczkAsfGCXJAgbIpFKBB(text6, "FAILED! Axis value = " + num6);
				}
			}
			int[] array3 = AvGCwYrMHvKMKkejYvrRljHgvBIh.iNZAlcTuJdKxgpvgzJhhytQGEdGu;
			for (int num7 = 0; num7 < AvGCwYrMHvKMKkejYvrRljHgvBIh.kZsWpxnWNKvqMhPhWInkvoUuLxKi; num7++)
			{
				int num8 = array3[num7];
				string text7 = "Hat " + num7;
				LdcbvjTMxUczkAsfGCXJAgbIpFKBB(text7, num8);
			}
			for (int num9 = 0; num9 < AvGCwYrMHvKMKkejYvrRljHgvBIh.EsivdIFkKegfviNHPBmLeAzWGwWCb.Rewired_002EHID_002EDrivers_002EIControllerDriver_002EGyroscopeCount; num9++)
			{
				int frLLuhnhnCBcDbsEacDVQKWOYPyiA = AvGCwYrMHvKMKkejYvrRljHgvBIh.EsivdIFkKegfviNHPBmLeAzWGwWCb.gyroscopes[num9].frLLuhnhnCBcDbsEacDVQKWOYPyiA;
				string text8 = "";
				for (int num10 = 0; num10 < frLLuhnhnCBcDbsEacDVQKWOYPyiA; num10++)
				{
					float num11 = AvGCwYrMHvKMKkejYvrRljHgvBIh.EsivdIFkKegfviNHPBmLeAzWGwWCb.gyroscopes[num9].TOPmGrQoeSxFlEKkKDvFEfkvXbyBA[num10];
					text8 = text8 + "[" + num10 + "]: " + num11.ToString("f3");
					if (num10 < frLLuhnhnCBcDbsEacDVQKWOYPyiA - 1)
					{
						text8 += " ";
					}
				}
				LdcbvjTMxUczkAsfGCXJAgbIpFKBB("Gyro " + num9, text8);
			}
			for (int num12 = 0; num12 < AvGCwYrMHvKMKkejYvrRljHgvBIh.EsivdIFkKegfviNHPBmLeAzWGwWCb.Rewired_002EHID_002EDrivers_002EIControllerDriver_002EAccelerometerCount; num12++)
			{
				int sdkQPDfSBwcaRnDuTdNBcCRmopjgA = AvGCwYrMHvKMKkejYvrRljHgvBIh.EsivdIFkKegfviNHPBmLeAzWGwWCb.accelerometers[num12].SdkQPDfSBwcaRnDuTdNBcCRmopjgA;
				string text9 = "";
				for (int num13 = 0; num13 < sdkQPDfSBwcaRnDuTdNBcCRmopjgA; num13++)
				{
					float num14 = AvGCwYrMHvKMKkejYvrRljHgvBIh.EsivdIFkKegfviNHPBmLeAzWGwWCb.accelerometers[num12].LWJBMyDpMAXWrlkvxBnTSFsUyyMq[num13];
					text9 = text9 + "[" + num13 + "]: " + num14.ToString("f3");
					if (num13 < sdkQPDfSBwcaRnDuTdNBcCRmopjgA - 1)
					{
						text9 += " ";
					}
				}
				LdcbvjTMxUczkAsfGCXJAgbIpFKBB("Accelerometer " + num12, text9);
			}
			for (int num15 = 0; num15 < AvGCwYrMHvKMKkejYvrRljHgvBIh.EsivdIFkKegfviNHPBmLeAzWGwWCb.Rewired_002EHID_002EDrivers_002EIControllerDriver_002ETouchpadCount; num15++)
			{
				ECuuExxPnMTpiDfXAPmQzhehTPKT eCuuExxPnMTpiDfXAPmQzhehTPKT = AvGCwYrMHvKMKkejYvrRljHgvBIh.EsivdIFkKegfviNHPBmLeAzWGwWCb.touchpads[num15];
				int num16 = eCuuExxPnMTpiDfXAPmQzhehTPKT.RFuDyXZFSuwShPfcFbhPdVCqtPBKA.Length;
				string text10 = "";
				for (int num17 = 0; num17 < num16; num17++)
				{
					ECuuExxPnMTpiDfXAPmQzhehTPKT.TouchData touchData = eCuuExxPnMTpiDfXAPmQzhehTPKT.RFuDyXZFSuwShPfcFbhPdVCqtPBKA[num17];
					text10 = text10 + "Touch " + num17 + ": Is Touching = " + touchData.isTouching + "\n";
					text10 = text10 + "Touch " + num17 + ": Touch Id = " + touchData.touchId + "\n";
					text10 = text10 + "Touch " + num17 + ": Position = " + touchData.positionX + ", " + touchData.positionY + "\n";
					text10 = text10 + "Touch " + num17 + ": Abs Position = " + touchData.positionAbsX + ", " + touchData.positionAbsY + " (" + touchData.positionRawX + ", " + touchData.positionRawY + ")\n";
				}
				ncUpJRFVUZnMLjAQRYwNVAzvNuSf("Touchpad " + num15, text10);
			}
			bool[] array4 = AvGCwYrMHvKMKkejYvrRljHgvBIh.fMvoddvLKADYDxhEtImxPIqUBYaj;
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
			LdcbvjTMxUczkAsfGCXJAgbIpFKBB("Buttons ", text11);
		}
		ivNLKlwltSXlbEmHJdrxSSeeeOIH.text = fDiMwZUJCorjulfurbdVUiAvdXSX;
	}

	void IElementIdentifierTool.Update()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Update
		this.Update();
	}

	public void OnDestroy()
	{
		if (AvGCwYrMHvKMKkejYvrRljHgvBIh != null)
		{
			AvGCwYrMHvKMKkejYvrRljHgvBIh.LFubPekUlWjjnGGXgCSBpgQpWoqvB();
		}
	}

	void IElementIdentifierTool.OnDestroy()
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnDestroy
		this.OnDestroy();
	}

	private void yeUjtqcvcaVlBxxZUIwMyBynqLdW()
	{
		HVgqdXRGBeeQKrwcfdcQZhfQbdhH = KYNhTjdqctfCiKkBFHUxKXseswWv.GetJoysticks<GFzeCCkaUHxzLqMmAXGJQcvsbFsv>();
	}

	private void DjVfVBDmuECedQNcsGcCdehKSBMM()
	{
		xtckRgvzaatTfgGfTAZHckobwuluA();
	}

	private void WuXsVlifYawGSXPGkjHBQnjMCOhHA()
	{
		xtckRgvzaatTfgGfTAZHckobwuluA();
	}

	private void xtckRgvzaatTfgGfTAZHckobwuluA()
	{
		fyLdlJWswaqxONCYhuYbdsIisnOU();
		PMCEbfTwpJspZsYoYpeIUjTCwUvX = true;
	}

	private void fyLdlJWswaqxONCYhuYbdsIisnOU()
	{
		qQpWcdOlIIQcUHTLnbOVKkOViJbKA = 0;
		AvGCwYrMHvKMKkejYvrRljHgvBIh = null;
		AtGdaRlqxgYtseQCjnKUpvpeoDbX = Guid.Empty;
		HVgqdXRGBeeQKrwcfdcQZhfQbdhH = null;
		TFQnsymmBBAUNeJRFfJYregIivPy = false;
		PMCEbfTwpJspZsYoYpeIUjTCwUvX = false;
	}

	private void LdcbvjTMxUczkAsfGCXJAgbIpFKBB(string P_0, object P_1)
	{
		fDiMwZUJCorjulfurbdVUiAvdXSX = fDiMwZUJCorjulfurbdVUiAvdXSX + P_0 + " = " + P_1.ToString() + "\n";
	}

	private void ncUpJRFVUZnMLjAQRYwNVAzvNuSf(string P_0, object P_1)
	{
		fDiMwZUJCorjulfurbdVUiAvdXSX = fDiMwZUJCorjulfurbdVUiAvdXSX + P_0 + ":\n" + P_1.ToString() + "\n";
	}

	private int FJnDeiQExyTAzSOwAEhDkdwlkLkrA(RawInputAxis P_0, int P_1, fliORgAWnNfkUHOriNcTSiLVhTfIA P_2)
	{
		return P_2.dkiEOycbUxIqSCIWcDNwiLENHlMjb(P_0, P_1);
	}

	private float pNGPdDDXCiVdPsKAhVhYeXVshGZR(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}
}
