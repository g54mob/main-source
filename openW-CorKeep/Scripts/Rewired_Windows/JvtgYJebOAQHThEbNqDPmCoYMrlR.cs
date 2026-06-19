using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

internal sealed class JvtgYJebOAQHThEbNqDPmCoYMrlR : IElementIdentifierTool
{
	private Rewired.Internal.GUIText BrsDQBkLdSAUxHbNHlIfKGQtXcHgA;

	private string CkLEHtQcUgJsuQgsdmGTAWucnZTN;

	private int JIUvETMGkKpbSyGBbnPNODiMZDmL;

	private aVNwfEKFFkuytdgRDywStztpwdQi dMkOfLrmgvPAahHNVkpbQZWdusNX;

	private zvOGxcHsUJhuDsNyEaqXAYZbfPfCB xDhIFaedUxTNORTsIzAFprBtxzFw;

	private Guid rjvOtdjohyJccLJEtcrQtUDhlNiX;

	private IList<zvOGxcHsUJhuDsNyEaqXAYZbfPfCB> ifPUjnTsIgEbMOKsbaIAFJPNGzkEb;

	private bool uhleiCaNZTGLZIDTFOKGCzIRTrOuA;

	private bool oAbsvJJsjLcgBHpcCDSSGclTIfyI;

	private bool aviaaTFDtqNUlikptIckpNiMzisO;

	private string[] avtSGKGvBNyljMhYVaMovYkrtXpJ;

	private int[] RUMdOXVJnvSRXiJfwdtTKdcLMnAlA;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		BrsDQBkLdSAUxHbNHlIfKGQtXcHgA = text;
		avtSGKGvBNyljMhYVaMovYkrtXpJ = Enum.GetNames(typeof(RawInputAxis));
		RUMdOXVJnvSRXiJfwdtTKdcLMnAlA = (int[])Enum.GetValues(typeof(RawInputAxis));
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
		dMkOfLrmgvPAahHNVkpbQZWdusNX = ReInput.primaryInputManager.inputSource as aVNwfEKFFkuytdgRDywStztpwdQi;
		if (dMkOfLrmgvPAahHNVkpbQZWdusNX == null)
		{
			Rewired.Logger.LogError("Unable to initialize Raw Input! You must add a Rewired Input Manager to the scene and set the input mode to Raw Input.");
			return;
		}
		ReInput.primaryInputManager.SystemDeviceConnectedEvent += yBaUbdDHmUhvdxOqovJYjbPVVXVM;
		ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += fQgOBvyGdqDCoeYwomNPYVHVGyhB;
		THjuwKcIauowRMeTUBwQcDKoTluk();
		aviaaTFDtqNUlikptIckpNiMzisO = true;
	}

	void IElementIdentifierTool.Start()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Start
		this.Start();
	}

	public void Update()
	{
		if (!aviaaTFDtqNUlikptIckpNiMzisO)
		{
			return;
		}
		CkLEHtQcUgJsuQgsdmGTAWucnZTN = "Raw Input Joystick Element Identifier\n\n";
		BrsDQBkLdSAUxHbNHlIfKGQtXcHgA.text = CkLEHtQcUgJsuQgsdmGTAWucnZTN;
		int jIUvETMGkKpbSyGBbnPNODiMZDmL = JIUvETMGkKpbSyGBbnPNODiMZDmL;
		Guid guid = rjvOtdjohyJccLJEtcrQtUDhlNiX;
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Equals) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Plus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadPlus))
		{
			JIUvETMGkKpbSyGBbnPNODiMZDmL++;
		}
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadMinus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Minus))
		{
			JIUvETMGkKpbSyGBbnPNODiMZDmL--;
		}
		if (oAbsvJJsjLcgBHpcCDSSGclTIfyI)
		{
			THjuwKcIauowRMeTUBwQcDKoTluk();
			oAbsvJJsjLcgBHpcCDSSGclTIfyI = false;
		}
		int num = ((ifPUjnTsIgEbMOKsbaIAFJPNGzkEb != null) ? ifPUjnTsIgEbMOKsbaIAFJPNGzkEb.Count : 0);
		if (num == 0)
		{
			return;
		}
		if (JIUvETMGkKpbSyGBbnPNODiMZDmL < 0)
		{
			JIUvETMGkKpbSyGBbnPNODiMZDmL = num - 1;
		}
		else if (JIUvETMGkKpbSyGBbnPNODiMZDmL >= num)
		{
			JIUvETMGkKpbSyGBbnPNODiMZDmL = 0;
		}
		rjvOtdjohyJccLJEtcrQtUDhlNiX = ifPUjnTsIgEbMOKsbaIAFJPNGzkEb[JIUvETMGkKpbSyGBbnPNODiMZDmL].EHQHtNNrxlMzreeTogiAPPIWcpqC;
		bool flag = false;
		if (jIUvETMGkKpbSyGBbnPNODiMZDmL != JIUvETMGkKpbSyGBbnPNODiMZDmL || guid != rjvOtdjohyJccLJEtcrQtUDhlNiX)
		{
			flag = true;
		}
		if (xDhIFaedUxTNORTsIzAFprBtxzFw == null || flag)
		{
			if (xDhIFaedUxTNORTsIzAFprBtxzFw != null)
			{
				xDhIFaedUxTNORTsIzAFprBtxzFw.ufLYtYEvPEeXlpFsKnARimVPwPjd();
			}
			xDhIFaedUxTNORTsIzAFprBtxzFw = ifPUjnTsIgEbMOKsbaIAFJPNGzkEb[JIUvETMGkKpbSyGBbnPNODiMZDmL];
			if (xDhIFaedUxTNORTsIzAFprBtxzFw == null)
			{
				return;
			}
			xDhIFaedUxTNORTsIzAFprBtxzFw.MdtMfAVmBZYZlclZRBuTFVbXsHRs();
		}
		bool flag2 = false;
		if (xDhIFaedUxTNORTsIzAFprBtxzFw.EjzGwBuvIZFSaCPTHznZvNtTeSvWA is DwhHUsgGvbTPWRSgIAUsyncIEAXEA)
		{
			flag2 = true;
		}
		else if (!(xDhIFaedUxTNORTsIzAFprBtxzFw.EjzGwBuvIZFSaCPTHznZvNtTeSvWA is SPDdCAYahBBjGiXtqyHRCWjATVyT))
		{
			return;
		}
		if (num > 0)
		{
			CkLEHtQcUgJsuQgsdmGTAWucnZTN = CkLEHtQcUgJsuQgsdmGTAWucnZTN + num + " connected devices:\n";
		}
		for (int i = 0; i < num; i++)
		{
			CkLEHtQcUgJsuQgsdmGTAWucnZTN = CkLEHtQcUgJsuQgsdmGTAWucnZTN + ifPUjnTsIgEbMOKsbaIAFJPNGzkEb[i].kHVLroZdzgYbmtCjUQBkmLNvwIAh + "\n";
		}
		CkLEHtQcUgJsuQgsdmGTAWucnZTN += "\n";
		CkLEHtQcUgJsuQgsdmGTAWucnZTN = CkLEHtQcUgJsuQgsdmGTAWucnZTN + "Current RI device " + JIUvETMGkKpbSyGBbnPNODiMZDmL + ": \"" + xDhIFaedUxTNORTsIzAFprBtxzFw.kHVLroZdzgYbmtCjUQBkmLNvwIAh + "\"\n";
		CkLEHtQcUgJsuQgsdmGTAWucnZTN += "(Press + or - to change monitored device id.)\n\n";
		kzFRyRZXjWmhiLMtQkiXsOJsLvBg("Product Name", "\"" + xDhIFaedUxTNORTsIzAFprBtxzFw.kHVLroZdzgYbmtCjUQBkmLNvwIAh + "\"");
		kzFRyRZXjWmhiLMtQkiXsOJsLvBg("Is Bluetooth Device", xDhIFaedUxTNORTsIzAFprBtxzFw.cmRjyxmQtZdaHTctAEloLaRHsWhh);
		if (xDhIFaedUxTNORTsIzAFprBtxzFw.cmRjyxmQtZdaHTctAEloLaRHsWhh)
		{
			kzFRyRZXjWmhiLMtQkiXsOJsLvBg("Bluetooth Device Name", "\"" + xDhIFaedUxTNORTsIzAFprBtxzFw.xXjjzJOGKVAUsURDmlmlbuXJFSkP + "\"");
		}
		if (flag2)
		{
			kzFRyRZXjWmhiLMtQkiXsOJsLvBg("Using Custom Driver", "TRUE");
		}
		kzFRyRZXjWmhiLMtQkiXsOJsLvBg("Device Type", xDhIFaedUxTNORTsIzAFprBtxzFw.ZErDWEsMYMTvJzWzFPYRZaJSUfdL.ToString());
		kzFRyRZXjWmhiLMtQkiXsOJsLvBg("Identifier", new PidVid(xDhIFaedUxTNORTsIzAFprBtxzFw.GwyBEvfTEZeyGrFtYNdeBRCHzPAOb));
		kzFRyRZXjWmhiLMtQkiXsOJsLvBg("Product Id", xDhIFaedUxTNORTsIzAFprBtxzFw.yJPKDzzdTMFNGOBOQDLASYBxbecU);
		kzFRyRZXjWmhiLMtQkiXsOJsLvBg("Vendor Id", xDhIFaedUxTNORTsIzAFprBtxzFw.izTxynPZFQvOiNEtBAmqobeGLRIL);
		CkLEHtQcUgJsuQgsdmGTAWucnZTN += "\n";
		kzFRyRZXjWmhiLMtQkiXsOJsLvBg("Axis Count", xDhIFaedUxTNORTsIzAFprBtxzFw.BZnryvGngwgOtAHOQzzKQkauNMZy);
		kzFRyRZXjWmhiLMtQkiXsOJsLvBg("Button Count", xDhIFaedUxTNORTsIzAFprBtxzFw.xAeBNkejlxbvIhTFSrCiHanTeVsi);
		kzFRyRZXjWmhiLMtQkiXsOJsLvBg("Hat Count", xDhIFaedUxTNORTsIzAFprBtxzFw.NbZTHRzpPMpqKQApSzjgrKijqTZM);
		CkLEHtQcUgJsuQgsdmGTAWucnZTN += "\n";
		if (flag)
		{
			string text = "";
			text = text + "Device Name: \"" + ifPUjnTsIgEbMOKsbaIAFJPNGzkEb[JIUvETMGkKpbSyGBbnPNODiMZDmL].kHVLroZdzgYbmtCjUQBkmLNvwIAh + "\"\n";
			if (xDhIFaedUxTNORTsIzAFprBtxzFw.cmRjyxmQtZdaHTctAEloLaRHsWhh)
			{
				text = text + "Bluetooth Device Name: \"" + xDhIFaedUxTNORTsIzAFprBtxzFw.xXjjzJOGKVAUsURDmlmlbuXJFSkP + "\"\n";
			}
			text = text + "Identifier: " + new PidVid(xDhIFaedUxTNORTsIzAFprBtxzFw.GwyBEvfTEZeyGrFtYNdeBRCHzPAOb).ToString() + "\n";
			Rewired.Logger.Log(text);
		}
		if (!flag2)
		{
			SPDdCAYahBBjGiXtqyHRCWjATVyT sPDdCAYahBBjGiXtqyHRCWjATVyT = xDhIFaedUxTNORTsIzAFprBtxzFw.EjzGwBuvIZFSaCPTHznZvNtTeSvWA as SPDdCAYahBBjGiXtqyHRCWjATVyT;
			for (int j = 1; j < avtSGKGvBNyljMhYVaMovYkrtXpJ.Length - 1; j++)
			{
				int num2 = aCEnYUOOfsLpxhuvQCDFhgAgPqxg((RawInputAxis)RUMdOXVJnvSRXiJfwdtTKdcLMnAlA[j], 0, sPDdCAYahBBjGiXtqyHRCWjATVyT);
				string text2 = avtSGKGvBNyljMhYVaMovYkrtXpJ[j];
				try
				{
					kzFRyRZXjWmhiLMtQkiXsOJsLvBg(text2, num2 + " (" + GNhCqhRGWkLkPJMIjCUMavfjeIYBA(num2) + ")");
				}
				catch
				{
					kzFRyRZXjWmhiLMtQkiXsOJsLvBg(text2, "FAILED! Axis value = " + num2);
				}
			}
			if (sPDdCAYahBBjGiXtqyHRCWjATVyT.wJjapDSvohbGeIdysfAhYtEnPeIL > 0)
			{
				for (int k = 0; k < sPDdCAYahBBjGiXtqyHRCWjATVyT.wJjapDSvohbGeIdysfAhYtEnPeIL; k++)
				{
					int num3 = aCEnYUOOfsLpxhuvQCDFhgAgPqxg(RawInputAxis.Other, k, sPDdCAYahBBjGiXtqyHRCWjATVyT);
					string text3 = "Other Axis " + k;
					try
					{
						kzFRyRZXjWmhiLMtQkiXsOJsLvBg(text3, num3 + " (" + GNhCqhRGWkLkPJMIjCUMavfjeIYBA(num3) + ")");
					}
					catch
					{
						kzFRyRZXjWmhiLMtQkiXsOJsLvBg(text3, "FAILED! Axis value = " + num3);
					}
				}
			}
			int[] array = xDhIFaedUxTNORTsIzAFprBtxzFw.DliRiQDHRpzekMwehUWjqGaLvtRR;
			for (int l = 0; l < array.Length; l++)
			{
				int num4 = array[l];
				string text4 = "Hat " + l;
				kzFRyRZXjWmhiLMtQkiXsOJsLvBg(text4, num4);
			}
			bool[] array2 = xDhIFaedUxTNORTsIzAFprBtxzFw.MYWhtZzmOOCIFEKYdEvnERWcPLnqb;
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
			kzFRyRZXjWmhiLMtQkiXsOJsLvBg("Buttons ", text5);
		}
		else
		{
			DwhHUsgGvbTPWRSgIAUsyncIEAXEA dwhHUsgGvbTPWRSgIAUsyncIEAXEA = xDhIFaedUxTNORTsIzAFprBtxzFw.EjzGwBuvIZFSaCPTHznZvNtTeSvWA as DwhHUsgGvbTPWRSgIAUsyncIEAXEA;
			for (int n = 0; n < xDhIFaedUxTNORTsIzAFprBtxzFw.BZnryvGngwgOtAHOQzzKQkauNMZy; n++)
			{
				float num5 = dwhHUsgGvbTPWRSgIAUsyncIEAXEA.aFJKkYSyCZCopbUtfJsAJpDKyGTt(n);
				string text6 = n.ToString();
				try
				{
					kzFRyRZXjWmhiLMtQkiXsOJsLvBg(text6, num5 + " (" + dwhHUsgGvbTPWRSgIAUsyncIEAXEA.PgrdIPEUWJuhshMYudwmBlnASwpMA(n) + ")");
				}
				catch
				{
					kzFRyRZXjWmhiLMtQkiXsOJsLvBg(text6, "FAILED! Axis value = " + num5);
				}
			}
			int[] array3 = xDhIFaedUxTNORTsIzAFprBtxzFw.DliRiQDHRpzekMwehUWjqGaLvtRR;
			for (int num6 = 0; num6 < xDhIFaedUxTNORTsIzAFprBtxzFw.NbZTHRzpPMpqKQApSzjgrKijqTZM; num6++)
			{
				int num7 = array3[num6];
				string text7 = "Hat " + num6;
				kzFRyRZXjWmhiLMtQkiXsOJsLvBg(text7, num7);
			}
			for (int num8 = 0; num8 < xDhIFaedUxTNORTsIzAFprBtxzFw.hFjmewFMcmejcJNNTRBVEXNSoZqA.Rewired_002EHID_002EDrivers_002EIControllerDriver_002EGyroscopeCount; num8++)
			{
				int mvshQTlclAFvPZiAcxePYmwJVxbk = xDhIFaedUxTNORTsIzAFprBtxzFw.hFjmewFMcmejcJNNTRBVEXNSoZqA.gyroscopes[num8].MvshQTlclAFvPZiAcxePYmwJVxbk;
				string text8 = "";
				for (int num9 = 0; num9 < mvshQTlclAFvPZiAcxePYmwJVxbk; num9++)
				{
					float num10 = xDhIFaedUxTNORTsIzAFprBtxzFw.hFjmewFMcmejcJNNTRBVEXNSoZqA.gyroscopes[num8].wXaANDSmoAgGvfdyOuMHrJOabbtz[num9];
					text8 = text8 + "[" + num9 + "]: " + num10.ToString("f3");
					if (num9 < mvshQTlclAFvPZiAcxePYmwJVxbk - 1)
					{
						text8 += " ";
					}
				}
				kzFRyRZXjWmhiLMtQkiXsOJsLvBg("Gyro " + num8, text8);
			}
			for (int num11 = 0; num11 < xDhIFaedUxTNORTsIzAFprBtxzFw.hFjmewFMcmejcJNNTRBVEXNSoZqA.Rewired_002EHID_002EDrivers_002EIControllerDriver_002EAccelerometerCount; num11++)
			{
				int jLRWgflYJupJFAzqRgETQAptariw = xDhIFaedUxTNORTsIzAFprBtxzFw.hFjmewFMcmejcJNNTRBVEXNSoZqA.accelerometers[num11].jLRWgflYJupJFAzqRgETQAptariw;
				string text9 = "";
				for (int num12 = 0; num12 < jLRWgflYJupJFAzqRgETQAptariw; num12++)
				{
					float num13 = xDhIFaedUxTNORTsIzAFprBtxzFw.hFjmewFMcmejcJNNTRBVEXNSoZqA.accelerometers[num11].idaOHKBnMGIFbSErnXWBOkCLqsFq[num12];
					text9 = text9 + "[" + num12 + "]: " + num13.ToString("f3");
					if (num12 < jLRWgflYJupJFAzqRgETQAptariw - 1)
					{
						text9 += " ";
					}
				}
				kzFRyRZXjWmhiLMtQkiXsOJsLvBg("Accelerometer " + num11, text9);
			}
			for (int num14 = 0; num14 < xDhIFaedUxTNORTsIzAFprBtxzFw.hFjmewFMcmejcJNNTRBVEXNSoZqA.Rewired_002EHID_002EDrivers_002EIControllerDriver_002ETouchpadCount; num14++)
			{
				hwDBnDzZlOwqwaLOCXGWdEQuXFFf hwDBnDzZlOwqwaLOCXGWdEQuXFFf2 = xDhIFaedUxTNORTsIzAFprBtxzFw.hFjmewFMcmejcJNNTRBVEXNSoZqA.touchpads[num14];
				int num15 = hwDBnDzZlOwqwaLOCXGWdEQuXFFf2.iVNpVhZhCmFMvyxmNYTLNjsnDNML.Length;
				string text10 = "";
				for (int num16 = 0; num16 < num15; num16++)
				{
					hwDBnDzZlOwqwaLOCXGWdEQuXFFf.TouchData touchData = hwDBnDzZlOwqwaLOCXGWdEQuXFFf2.iVNpVhZhCmFMvyxmNYTLNjsnDNML[num16];
					text10 = text10 + "Touch " + num16 + ": Is Touching = " + touchData.isTouching + "\n";
					text10 = text10 + "Touch " + num16 + ": Touch Id = " + touchData.touchId + "\n";
					text10 = text10 + "Touch " + num16 + ": Position = " + touchData.positionX + ", " + touchData.positionY + "\n";
					text10 = text10 + "Touch " + num16 + ": Abs Position = " + touchData.positionAbsX + ", " + touchData.positionAbsY + " (" + touchData.positionRawX + ", " + touchData.positionRawY + ")\n";
				}
				SYfIodNzOFJaNOPYFVzLXKPuHuXk("Touchpad " + num14, text10);
			}
			bool[] array4 = xDhIFaedUxTNORTsIzAFprBtxzFw.MYWhtZzmOOCIFEKYdEvnERWcPLnqb;
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
			kzFRyRZXjWmhiLMtQkiXsOJsLvBg("Buttons ", text11);
		}
		BrsDQBkLdSAUxHbNHlIfKGQtXcHgA.text = CkLEHtQcUgJsuQgsdmGTAWucnZTN;
	}

	void IElementIdentifierTool.Update()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Update
		this.Update();
	}

	public void OnDestroy()
	{
		if (xDhIFaedUxTNORTsIzAFprBtxzFw != null)
		{
			xDhIFaedUxTNORTsIzAFprBtxzFw.ufLYtYEvPEeXlpFsKnARimVPwPjd();
		}
	}

	void IElementIdentifierTool.OnDestroy()
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnDestroy
		this.OnDestroy();
	}

	private void THjuwKcIauowRMeTUBwQcDKoTluk()
	{
		ifPUjnTsIgEbMOKsbaIAFJPNGzkEb = dMkOfLrmgvPAahHNVkpbQZWdusNX.GetJoysticks<zvOGxcHsUJhuDsNyEaqXAYZbfPfCB>();
	}

	private void yBaUbdDHmUhvdxOqovJYjbPVVXVM()
	{
		OhBESWxlcuCjzPmlBoJVadCikuwj();
	}

	private void fQgOBvyGdqDCoeYwomNPYVHVGyhB()
	{
		OhBESWxlcuCjzPmlBoJVadCikuwj();
	}

	private void OhBESWxlcuCjzPmlBoJVadCikuwj()
	{
		CEqOibSKcgquAwKKjejjKhilrnPQA();
		oAbsvJJsjLcgBHpcCDSSGclTIfyI = true;
	}

	private void CEqOibSKcgquAwKKjejjKhilrnPQA()
	{
		JIUvETMGkKpbSyGBbnPNODiMZDmL = 0;
		xDhIFaedUxTNORTsIzAFprBtxzFw = null;
		rjvOtdjohyJccLJEtcrQtUDhlNiX = Guid.Empty;
		ifPUjnTsIgEbMOKsbaIAFJPNGzkEb = null;
		uhleiCaNZTGLZIDTFOKGCzIRTrOuA = false;
		oAbsvJJsjLcgBHpcCDSSGclTIfyI = false;
	}

	private void kzFRyRZXjWmhiLMtQkiXsOJsLvBg(string P_0, object P_1)
	{
		CkLEHtQcUgJsuQgsdmGTAWucnZTN = CkLEHtQcUgJsuQgsdmGTAWucnZTN + P_0 + " = " + P_1.ToString() + "\n";
	}

	private void SYfIodNzOFJaNOPYFVzLXKPuHuXk(string P_0, object P_1)
	{
		CkLEHtQcUgJsuQgsdmGTAWucnZTN = CkLEHtQcUgJsuQgsdmGTAWucnZTN + P_0 + ":\n" + P_1.ToString() + "\n";
	}

	private int aCEnYUOOfsLpxhuvQCDFhgAgPqxg(RawInputAxis P_0, int P_1, SPDdCAYahBBjGiXtqyHRCWjATVyT P_2)
	{
		return P_2.EDPFwIqlCnrHKdeMuKucNFoMapRiA(P_0, P_1);
	}

	private float GNhCqhRGWkLkPJMIjCUMavfjeIYBA(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}
}
