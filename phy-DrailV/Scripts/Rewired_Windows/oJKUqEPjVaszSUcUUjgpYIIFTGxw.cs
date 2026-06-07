using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

internal sealed class oJKUqEPjVaszSUcUUjgpYIIFTGxw : IElementIdentifierTool
{
	private Rewired.Internal.GUIText FRaZKhaTILmrjuSxKHaBodjQxfVM;

	private string nCudswbgCdZfxrCtJbdPIrEFdYybb;

	private int sQaQMUbTVPmOeMTfmmdhnnoQRbRM;

	private BJkeDTpvKMtUyGqqYbRkHpVmhHYR WFPqAfmFIvUnJciHnBoKjBckkWEAb;

	private UybLZbXlLlOUQudVBgPjuLligodX dUxVIgaadrfqJWSzRpXGORZlkMqp;

	private Guid HIYNDJWBxLXpBcJBIaulbrLiEbMDb;

	private IList<UybLZbXlLlOUQudVBgPjuLligodX> lmXcQhajdNKdniYMTQObQulPNJVV;

	private bool dQyChmifADJvJQhpuocMoiegCNMd;

	private bool vjJRFMubUzwLBZlOVKUMMvJtVVRN;

	private bool YlNIbKOzBiExQEAIlepDGOSGGonS;

	private string[] ifGCjhyTzeIIuLNzYKCzBPnzQygQ;

	private int[] VaqoBlSqHFRmnupsjuqOcfDRcicJ;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		FRaZKhaTILmrjuSxKHaBodjQxfVM = text;
		ifGCjhyTzeIIuLNzYKCzBPnzQygQ = Enum.GetNames(typeof(RawInputAxis));
		VaqoBlSqHFRmnupsjuqOcfDRcicJ = (int[])Enum.GetValues(typeof(RawInputAxis));
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
		WFPqAfmFIvUnJciHnBoKjBckkWEAb = ReInput.primaryInputManager.inputSource as BJkeDTpvKMtUyGqqYbRkHpVmhHYR;
		if (WFPqAfmFIvUnJciHnBoKjBckkWEAb == null)
		{
			Rewired.Logger.LogError("Unable to initialize Raw Input! You must add a Rewired Input Manager to the scene and set the input mode to Raw Input.");
			return;
		}
		ReInput.primaryInputManager.SystemDeviceConnectedEvent += resmJsazZhbpJqFxSjGbWtjWKDDg;
		ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += dpTjWWikrkoIbAUfsiUXFoMqXhEk;
		XfxgwnHacNVnUdMeTealuvJLOsxd();
		YlNIbKOzBiExQEAIlepDGOSGGonS = true;
	}

	public void Update()
	{
		if (!YlNIbKOzBiExQEAIlepDGOSGGonS)
		{
			return;
		}
		nCudswbgCdZfxrCtJbdPIrEFdYybb = "Raw Input Joystick Element Identifier\n\n";
		FRaZKhaTILmrjuSxKHaBodjQxfVM.text = nCudswbgCdZfxrCtJbdPIrEFdYybb;
		int num = sQaQMUbTVPmOeMTfmmdhnnoQRbRM;
		Guid hIYNDJWBxLXpBcJBIaulbrLiEbMDb = HIYNDJWBxLXpBcJBIaulbrLiEbMDb;
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Equals) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Plus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadPlus))
		{
			sQaQMUbTVPmOeMTfmmdhnnoQRbRM++;
		}
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadMinus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Minus))
		{
			sQaQMUbTVPmOeMTfmmdhnnoQRbRM--;
		}
		if (vjJRFMubUzwLBZlOVKUMMvJtVVRN)
		{
			XfxgwnHacNVnUdMeTealuvJLOsxd();
			vjJRFMubUzwLBZlOVKUMMvJtVVRN = false;
		}
		int num2 = ((lmXcQhajdNKdniYMTQObQulPNJVV != null) ? lmXcQhajdNKdniYMTQObQulPNJVV.Count : 0);
		if (num2 == 0)
		{
			return;
		}
		if (sQaQMUbTVPmOeMTfmmdhnnoQRbRM < 0)
		{
			sQaQMUbTVPmOeMTfmmdhnnoQRbRM = num2 - 1;
		}
		else if (sQaQMUbTVPmOeMTfmmdhnnoQRbRM >= num2)
		{
			sQaQMUbTVPmOeMTfmmdhnnoQRbRM = 0;
		}
		HIYNDJWBxLXpBcJBIaulbrLiEbMDb = lmXcQhajdNKdniYMTQObQulPNJVV[sQaQMUbTVPmOeMTfmmdhnnoQRbRM].SCGcrIIDMjURHdkJjDIzHoMbvWQHA;
		bool flag = false;
		if (num != sQaQMUbTVPmOeMTfmmdhnnoQRbRM || hIYNDJWBxLXpBcJBIaulbrLiEbMDb != HIYNDJWBxLXpBcJBIaulbrLiEbMDb)
		{
			flag = true;
		}
		if (dUxVIgaadrfqJWSzRpXGORZlkMqp == null || flag)
		{
			if (dUxVIgaadrfqJWSzRpXGORZlkMqp != null)
			{
				dUxVIgaadrfqJWSzRpXGORZlkMqp.Unacquire();
			}
			dUxVIgaadrfqJWSzRpXGORZlkMqp = lmXcQhajdNKdniYMTQObQulPNJVV[sQaQMUbTVPmOeMTfmmdhnnoQRbRM];
			if (dUxVIgaadrfqJWSzRpXGORZlkMqp == null)
			{
				return;
			}
			dUxVIgaadrfqJWSzRpXGORZlkMqp.Acquire();
		}
		bool flag2 = false;
		if (dUxVIgaadrfqJWSzRpXGORZlkMqp.EctSBOaKmcyrSQrSOBVXHrtXCtDd is qIWtcbDqaTWfTuQTFCnUQsKNLnHo)
		{
			flag2 = true;
		}
		else if (!(dUxVIgaadrfqJWSzRpXGORZlkMqp.EctSBOaKmcyrSQrSOBVXHrtXCtDd is lXccLDhmWjHPtDKHzsAjoJhPqYwC))
		{
			return;
		}
		if (num2 > 0)
		{
			nCudswbgCdZfxrCtJbdPIrEFdYybb = nCudswbgCdZfxrCtJbdPIrEFdYybb + num2 + " connected devices:\n";
		}
		for (int i = 0; i < num2; i++)
		{
			nCudswbgCdZfxrCtJbdPIrEFdYybb = nCudswbgCdZfxrCtJbdPIrEFdYybb + lmXcQhajdNKdniYMTQObQulPNJVV[i].mqjctEYgXEfZnYIDMMngJxDYpBhU + "\n";
		}
		nCudswbgCdZfxrCtJbdPIrEFdYybb += "\n";
		nCudswbgCdZfxrCtJbdPIrEFdYybb = nCudswbgCdZfxrCtJbdPIrEFdYybb + "Current RI device " + sQaQMUbTVPmOeMTfmmdhnnoQRbRM + ": \"" + dUxVIgaadrfqJWSzRpXGORZlkMqp.mqjctEYgXEfZnYIDMMngJxDYpBhU + "\"\n";
		nCudswbgCdZfxrCtJbdPIrEFdYybb += "(Press + or - to change monitored device id.)\n\n";
		oSrzFJGZfUCPHuNPLENPheEyWsoK("Product Name", "\"" + dUxVIgaadrfqJWSzRpXGORZlkMqp.mqjctEYgXEfZnYIDMMngJxDYpBhU + "\"");
		oSrzFJGZfUCPHuNPLENPheEyWsoK("Is Bluetooth Device", dUxVIgaadrfqJWSzRpXGORZlkMqp.MpuQBNhsGfnlifDQFONVPCMzxEIi);
		if (dUxVIgaadrfqJWSzRpXGORZlkMqp.MpuQBNhsGfnlifDQFONVPCMzxEIi)
		{
			oSrzFJGZfUCPHuNPLENPheEyWsoK("Bluetooth Device Name", "\"" + dUxVIgaadrfqJWSzRpXGORZlkMqp.iAlThlvTdFBnLFoKOqPsWaWpHQQV + "\"");
		}
		if (flag2)
		{
			oSrzFJGZfUCPHuNPLENPheEyWsoK("Using Custom Driver", "TRUE");
		}
		oSrzFJGZfUCPHuNPLENPheEyWsoK("Device Type", dUxVIgaadrfqJWSzRpXGORZlkMqp.KpLgfiTwKVmJnHrLykvAtjznonIo.ToString());
		oSrzFJGZfUCPHuNPLENPheEyWsoK("Identifier", new PidVid(dUxVIgaadrfqJWSzRpXGORZlkMqp.RqoeGgcphJkoXcPusfFTyPTciRntA));
		oSrzFJGZfUCPHuNPLENPheEyWsoK("Product Id", dUxVIgaadrfqJWSzRpXGORZlkMqp.nKaqOeNeXtRFQyIiPrSeMOBlIXKe);
		oSrzFJGZfUCPHuNPLENPheEyWsoK("Vendor Id", dUxVIgaadrfqJWSzRpXGORZlkMqp.rQMHGWBVRINpDkLJvWbkZIiKbMlE);
		nCudswbgCdZfxrCtJbdPIrEFdYybb += "\n";
		oSrzFJGZfUCPHuNPLENPheEyWsoK("Axis Count", dUxVIgaadrfqJWSzRpXGORZlkMqp.OnAwGKsEQkUZSJUZVquvqkbDyaWo);
		oSrzFJGZfUCPHuNPLENPheEyWsoK("Button Count", dUxVIgaadrfqJWSzRpXGORZlkMqp.JVqCHAvnctFGSlUdMoFcLkcNXrDA);
		oSrzFJGZfUCPHuNPLENPheEyWsoK("Hat Count", dUxVIgaadrfqJWSzRpXGORZlkMqp.nHDbLoGMognNLMuWpWyCEHRJaNibA);
		nCudswbgCdZfxrCtJbdPIrEFdYybb += "\n";
		if (flag)
		{
			string text = "";
			text = text + "Device Name: \"" + lmXcQhajdNKdniYMTQObQulPNJVV[sQaQMUbTVPmOeMTfmmdhnnoQRbRM].mqjctEYgXEfZnYIDMMngJxDYpBhU + "\"\n";
			if (dUxVIgaadrfqJWSzRpXGORZlkMqp.MpuQBNhsGfnlifDQFONVPCMzxEIi)
			{
				text = text + "Bluetooth Device Name: \"" + dUxVIgaadrfqJWSzRpXGORZlkMqp.iAlThlvTdFBnLFoKOqPsWaWpHQQV + "\"\n";
			}
			text = text + "Identifier: " + new PidVid(dUxVIgaadrfqJWSzRpXGORZlkMqp.RqoeGgcphJkoXcPusfFTyPTciRntA).ToString() + "\n";
			Rewired.Logger.Log(text);
		}
		if (!flag2)
		{
			lXccLDhmWjHPtDKHzsAjoJhPqYwC lXccLDhmWjHPtDKHzsAjoJhPqYwC2 = dUxVIgaadrfqJWSzRpXGORZlkMqp.EctSBOaKmcyrSQrSOBVXHrtXCtDd as lXccLDhmWjHPtDKHzsAjoJhPqYwC;
			for (int j = 1; j < ifGCjhyTzeIIuLNzYKCzBPnzQygQ.Length - 1; j++)
			{
				int num3 = mkqEwjEWKTccoblNpohIPzhMuvaL((RawInputAxis)VaqoBlSqHFRmnupsjuqOcfDRcicJ[j], 0, lXccLDhmWjHPtDKHzsAjoJhPqYwC2);
				string text2 = ifGCjhyTzeIIuLNzYKCzBPnzQygQ[j];
				try
				{
					oSrzFJGZfUCPHuNPLENPheEyWsoK(text2, num3 + " (" + XkqINHLcERmXREsNUNSKIBnJXSoW(num3) + ")");
				}
				catch
				{
					oSrzFJGZfUCPHuNPLENPheEyWsoK(text2, "FAILED! Axis value = " + num3);
				}
			}
			if (lXccLDhmWjHPtDKHzsAjoJhPqYwC2.ZCceBtAQlcnQrlexuipiahooyEWSA > 0)
			{
				for (int k = 0; k < lXccLDhmWjHPtDKHzsAjoJhPqYwC2.ZCceBtAQlcnQrlexuipiahooyEWSA; k++)
				{
					int num4 = mkqEwjEWKTccoblNpohIPzhMuvaL(RawInputAxis.Other, k, lXccLDhmWjHPtDKHzsAjoJhPqYwC2);
					string text3 = "Other Axis " + k;
					try
					{
						oSrzFJGZfUCPHuNPLENPheEyWsoK(text3, num4 + " (" + XkqINHLcERmXREsNUNSKIBnJXSoW(num4) + ")");
					}
					catch
					{
						oSrzFJGZfUCPHuNPLENPheEyWsoK(text3, "FAILED! Axis value = " + num4);
					}
				}
			}
			int[] array = dUxVIgaadrfqJWSzRpXGORZlkMqp.ODmpMmQHXebYjfzDfcdWGfBPjZaQA;
			for (int l = 0; l < array.Length; l++)
			{
				int num5 = array[l];
				string text4 = "Hat " + l;
				oSrzFJGZfUCPHuNPLENPheEyWsoK(text4, num5);
			}
			bool[] array2 = dUxVIgaadrfqJWSzRpXGORZlkMqp.syxPbhBJItzVAVLveDKeKXtdjmVVA;
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
			oSrzFJGZfUCPHuNPLENPheEyWsoK("Buttons ", text5);
		}
		else
		{
			qIWtcbDqaTWfTuQTFCnUQsKNLnHo qIWtcbDqaTWfTuQTFCnUQsKNLnHo2 = dUxVIgaadrfqJWSzRpXGORZlkMqp.EctSBOaKmcyrSQrSOBVXHrtXCtDd as qIWtcbDqaTWfTuQTFCnUQsKNLnHo;
			for (int n = 0; n < dUxVIgaadrfqJWSzRpXGORZlkMqp.OnAwGKsEQkUZSJUZVquvqkbDyaWo; n++)
			{
				float num6 = qIWtcbDqaTWfTuQTFCnUQsKNLnHo2.mkqEwjEWKTccoblNpohIPzhMuvaL(n);
				string text6 = n.ToString();
				try
				{
					oSrzFJGZfUCPHuNPLENPheEyWsoK(text6, num6 + " (" + qIWtcbDqaTWfTuQTFCnUQsKNLnHo2.UjBkmnDCfQvJySSLDxrAehDCKEbp(n) + ")");
				}
				catch
				{
					oSrzFJGZfUCPHuNPLENPheEyWsoK(text6, "FAILED! Axis value = " + num6);
				}
			}
			int[] array3 = dUxVIgaadrfqJWSzRpXGORZlkMqp.ODmpMmQHXebYjfzDfcdWGfBPjZaQA;
			for (int num7 = 0; num7 < dUxVIgaadrfqJWSzRpXGORZlkMqp.nHDbLoGMognNLMuWpWyCEHRJaNibA; num7++)
			{
				int num8 = array3[num7];
				string text7 = "Hat " + num7;
				oSrzFJGZfUCPHuNPLENPheEyWsoK(text7, num8);
			}
			for (int num9 = 0; num9 < dUxVIgaadrfqJWSzRpXGORZlkMqp.zJgibcUXMsvjAnMGNucfYtyWDTSi.GyroscopeCount; num9++)
			{
				int qCOFsGxIkxDEmAbTaixfrCMMvZhd = dUxVIgaadrfqJWSzRpXGORZlkMqp.zJgibcUXMsvjAnMGNucfYtyWDTSi.gyroscopes[num9].QCOFsGxIkxDEmAbTaixfrCMMvZhd;
				string text8 = "";
				for (int num10 = 0; num10 < qCOFsGxIkxDEmAbTaixfrCMMvZhd; num10++)
				{
					float num11 = dUxVIgaadrfqJWSzRpXGORZlkMqp.zJgibcUXMsvjAnMGNucfYtyWDTSi.gyroscopes[num9].QGEPzKgIedvthGPliWOduwXNjWui[num10];
					text8 = text8 + "[" + num10 + "]: " + num11.ToString("f3");
					if (num10 < qCOFsGxIkxDEmAbTaixfrCMMvZhd - 1)
					{
						text8 += " ";
					}
				}
				oSrzFJGZfUCPHuNPLENPheEyWsoK("Gyro " + num9, text8);
			}
			for (int num12 = 0; num12 < dUxVIgaadrfqJWSzRpXGORZlkMqp.zJgibcUXMsvjAnMGNucfYtyWDTSi.AccelerometerCount; num12++)
			{
				int qCOFsGxIkxDEmAbTaixfrCMMvZhd2 = dUxVIgaadrfqJWSzRpXGORZlkMqp.zJgibcUXMsvjAnMGNucfYtyWDTSi.accelerometers[num12].QCOFsGxIkxDEmAbTaixfrCMMvZhd;
				string text9 = "";
				for (int num13 = 0; num13 < qCOFsGxIkxDEmAbTaixfrCMMvZhd2; num13++)
				{
					float num14 = dUxVIgaadrfqJWSzRpXGORZlkMqp.zJgibcUXMsvjAnMGNucfYtyWDTSi.accelerometers[num12].QGEPzKgIedvthGPliWOduwXNjWui[num13];
					text9 = text9 + "[" + num13 + "]: " + num14.ToString("f3");
					if (num13 < qCOFsGxIkxDEmAbTaixfrCMMvZhd2 - 1)
					{
						text9 += " ";
					}
				}
				oSrzFJGZfUCPHuNPLENPheEyWsoK("Accelerometer " + num12, text9);
			}
			for (int num15 = 0; num15 < dUxVIgaadrfqJWSzRpXGORZlkMqp.zJgibcUXMsvjAnMGNucfYtyWDTSi.TouchpadCount; num15++)
			{
				IRcdnSIjiuKLhXFkJwhyNQabopZH rcdnSIjiuKLhXFkJwhyNQabopZH = dUxVIgaadrfqJWSzRpXGORZlkMqp.zJgibcUXMsvjAnMGNucfYtyWDTSi.touchpads[num15];
				int num16 = rcdnSIjiuKLhXFkJwhyNQabopZH.vdoCmmimVgkttAEVHxTdgHVkQBPMb.Length;
				string text10 = "";
				for (int num17 = 0; num17 < num16; num17++)
				{
					IRcdnSIjiuKLhXFkJwhyNQabopZH.TouchData touchData = rcdnSIjiuKLhXFkJwhyNQabopZH.vdoCmmimVgkttAEVHxTdgHVkQBPMb[num17];
					text10 = text10 + "Touch " + num17 + ": Is Touching = " + touchData.isTouching + "\n";
					text10 = text10 + "Touch " + num17 + ": Touch Id = " + touchData.touchId + "\n";
					text10 = text10 + "Touch " + num17 + ": Position = " + touchData.positionX + ", " + touchData.positionY + "\n";
					text10 = text10 + "Touch " + num17 + ": Abs Position = " + touchData.positionAbsX + ", " + touchData.positionAbsY + " (" + touchData.positionRawX + ", " + touchData.positionRawY + ")\n";
				}
				wnASteAGLniyQFeIQIvfQCBQzPRSA("Touchpad " + num15, text10);
			}
			bool[] array4 = dUxVIgaadrfqJWSzRpXGORZlkMqp.syxPbhBJItzVAVLveDKeKXtdjmVVA;
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
			oSrzFJGZfUCPHuNPLENPheEyWsoK("Buttons ", text11);
		}
		FRaZKhaTILmrjuSxKHaBodjQxfVM.text = nCudswbgCdZfxrCtJbdPIrEFdYybb;
	}

	public void OnDestroy()
	{
		if (dUxVIgaadrfqJWSzRpXGORZlkMqp != null)
		{
			dUxVIgaadrfqJWSzRpXGORZlkMqp.Unacquire();
		}
	}

	private void XfxgwnHacNVnUdMeTealuvJLOsxd()
	{
		lmXcQhajdNKdniYMTQObQulPNJVV = WFPqAfmFIvUnJciHnBoKjBckkWEAb.GetJoysticks<UybLZbXlLlOUQudVBgPjuLligodX>();
	}

	private void resmJsazZhbpJqFxSjGbWtjWKDDg()
	{
		xTlsYZTTzhQhrmgwSRhOmHEqXUOO();
	}

	private void dpTjWWikrkoIbAUfsiUXFoMqXhEk()
	{
		xTlsYZTTzhQhrmgwSRhOmHEqXUOO();
	}

	private void xTlsYZTTzhQhrmgwSRhOmHEqXUOO()
	{
		DwNKXiEShimVDUzntAObjUXyaFmo();
		vjJRFMubUzwLBZlOVKUMMvJtVVRN = true;
	}

	private void DwNKXiEShimVDUzntAObjUXyaFmo()
	{
		sQaQMUbTVPmOeMTfmmdhnnoQRbRM = 0;
		dUxVIgaadrfqJWSzRpXGORZlkMqp = null;
		HIYNDJWBxLXpBcJBIaulbrLiEbMDb = Guid.Empty;
		lmXcQhajdNKdniYMTQObQulPNJVV = null;
		dQyChmifADJvJQhpuocMoiegCNMd = false;
		vjJRFMubUzwLBZlOVKUMMvJtVVRN = false;
	}

	private void oSrzFJGZfUCPHuNPLENPheEyWsoK(string P_0, object P_1)
	{
		nCudswbgCdZfxrCtJbdPIrEFdYybb = nCudswbgCdZfxrCtJbdPIrEFdYybb + P_0 + " = " + P_1.ToString() + "\n";
	}

	private void wnASteAGLniyQFeIQIvfQCBQzPRSA(string P_0, object P_1)
	{
		nCudswbgCdZfxrCtJbdPIrEFdYybb = nCudswbgCdZfxrCtJbdPIrEFdYybb + P_0 + ":\n" + P_1.ToString() + "\n";
	}

	private int mkqEwjEWKTccoblNpohIPzhMuvaL(RawInputAxis P_0, int P_1, lXccLDhmWjHPtDKHzsAjoJhPqYwC P_2)
	{
		return P_2.mkqEwjEWKTccoblNpohIPzhMuvaL(P_0, P_1);
	}

	private float XkqINHLcERmXREsNUNSKIBnJXSoW(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}
}
