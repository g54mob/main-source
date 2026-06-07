using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal sealed class EoqcPwHFroBDvYipUYkUEMhWICGOA : IElementIdentifierTool
{
	private Rewired.Internal.GUIText FRaZKhaTILmrjuSxKHaBodjQxfVM;

	private string nCudswbgCdZfxrCtJbdPIrEFdYybb;

	private int sQaQMUbTVPmOeMTfmmdhnnoQRbRM;

	private YbMgkjmXpWdzgUKMqsjYZeXnSVzq VAyGDGfoHBoDUCWNaIhGjglCTLfid;

	private TGMNVgEkzYRUJhRlmEORKKDOgVur dUxVIgaadrfqJWSzRpXGORZlkMqp;

	private Guid HIYNDJWBxLXpBcJBIaulbrLiEbMDb;

	private IList<VrUjHkyKwlgfxGiNlmxxLiWLUcYKA> lmXcQhajdNKdniYMTQObQulPNJVV;

	private IList<VrUjHkyKwlgfxGiNlmxxLiWLUcYKA> lsQWhnbpSYUZUxdnmEOCvKZzAbCcA;

	private bool dQyChmifADJvJQhpuocMoiegCNMd;

	private bool vjJRFMubUzwLBZlOVKUMMvJtVVRN;

	private bool YlNIbKOzBiExQEAIlepDGOSGGonS;

	private int xKSrvMOHrAEbkidXlRfGsHMLnObDb;

	private TimerRealTime zBkbhvgUhZMSPzzdBzDLTpZfIlWHb;

	public void Initialize(Rewired.Internal.GUIText text)
	{
		FRaZKhaTILmrjuSxKHaBodjQxfVM = text;
	}

	public void Start()
	{
		if (ReInput.isEditor && ReInput.editorPlatform != EditorPlatform.Windows)
		{
			Rewired.Logger.LogError("Direct Input cannot be run on this platform. You must be running the editor in Windows.");
			return;
		}
		if (ReInput.currentPlatform != Platform.Windows)
		{
			Rewired.Logger.LogError("Direct Input cannot be run on this build target. Be sure Unity's build target is set to Windows Standalone.");
			return;
		}
		if (!(ReInput.primaryInputManager.inputSource is InputSourceWrapper<YbMgkjmXpWdzgUKMqsjYZeXnSVzq> inputSourceWrapper) || inputSourceWrapper.source == null)
		{
			Rewired.Logger.LogError("Unable to initialize Direct Input! You must add a Rewired Input Manager to the scene and set the input mode to Direct Input.");
			return;
		}
		VAyGDGfoHBoDUCWNaIhGjglCTLfid = inputSourceWrapper.source;
		ReInput.primaryInputManager.SystemDeviceConnectedEvent += resmJsazZhbpJqFxSjGbWtjWKDDg;
		ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += dpTjWWikrkoIbAUfsiUXFoMqXhEk;
		zBkbhvgUhZMSPzzdBzDLTpZfIlWHb = new TimerRealTime(1.0);
		zBkbhvgUhZMSPzzdBzDLTpZfIlWHb.Start();
		XfxgwnHacNVnUdMeTealuvJLOsxd();
		YlNIbKOzBiExQEAIlepDGOSGGonS = true;
	}

	public void Update()
	{
		if (!YlNIbKOzBiExQEAIlepDGOSGGonS)
		{
			return;
		}
		nCudswbgCdZfxrCtJbdPIrEFdYybb = "Direct Input Joystick Element Identifier\n\n";
		FRaZKhaTILmrjuSxKHaBodjQxfVM.text = nCudswbgCdZfxrCtJbdPIrEFdYybb;
		if (Input.GetKeyDown(KeyCode.A))
		{
			dQyChmifADJvJQhpuocMoiegCNMd = !dQyChmifADJvJQhpuocMoiegCNMd;
		}
		if (dQyChmifADJvJQhpuocMoiegCNMd)
		{
			FRaZKhaTILmrjuSxKHaBodjQxfVM.text += "All Devices:\n";
			foreach (VrUjHkyKwlgfxGiNlmxxLiWLUcYKA item in lsQWhnbpSYUZUxdnmEOCvKZzAbCcA)
			{
				Rewired.Internal.GUIText fRaZKhaTILmrjuSxKHaBodjQxfVM = FRaZKhaTILmrjuSxKHaBodjQxfVM;
				fRaZKhaTILmrjuSxKHaBodjQxfVM.text = fRaZKhaTILmrjuSxKHaBodjQxfVM.text + item.mqjctEYgXEfZnYIDMMngJxDYpBhU + ", " + item.gKjYCDHpPPLRttviHQXHXyGrCneo + ", " + new PidVid(item.RqoeGgcphJkoXcPusfFTyPTciRntA).ToString() + ", " + item.ebFCTPkOlEnQbCtJKheCoOJZNVFj + ", " + item.cWhBJpdcIExibSMjYHItMpewxpwkA + ", " + item.mfmnPLnoKcRvXQLIfmBFbZvcCOM + "\n";
			}
			FRaZKhaTILmrjuSxKHaBodjQxfVM.text += "\n";
		}
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
		if (zBkbhvgUhZMSPzzdBzDLTpZfIlWHb.Update())
		{
			int num2 = VAyGDGfoHBoDUCWNaIhGjglCTLfid.MAMHkSqdTslvpHFZqrSKDkgwpZrh(pXLCPSuuAhzcgGmkJbVkDzXovEub.All, XsxUPjMGXXOzFHWjBirlaEPOLxzP.AttachedOnly);
			if (num2 != xKSrvMOHrAEbkidXlRfGsHMLnObDb)
			{
				xKSrvMOHrAEbkidXlRfGsHMLnObDb = num2;
				vjJRFMubUzwLBZlOVKUMMvJtVVRN = true;
			}
			zBkbhvgUhZMSPzzdBzDLTpZfIlWHb.Start();
		}
		if (vjJRFMubUzwLBZlOVKUMMvJtVVRN)
		{
			XfxgwnHacNVnUdMeTealuvJLOsxd();
			vjJRFMubUzwLBZlOVKUMMvJtVVRN = false;
		}
		int num3 = ((lmXcQhajdNKdniYMTQObQulPNJVV != null) ? lmXcQhajdNKdniYMTQObQulPNJVV.Count : 0);
		if (num3 == 0)
		{
			return;
		}
		if (sQaQMUbTVPmOeMTfmmdhnnoQRbRM < 0)
		{
			sQaQMUbTVPmOeMTfmmdhnnoQRbRM = num3 - 1;
		}
		else if (sQaQMUbTVPmOeMTfmmdhnnoQRbRM >= num3)
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
				dUxVIgaadrfqJWSzRpXGORZlkMqp.zobeSpTCoofGnipPFjpZGNzdwEoE();
			}
			dUxVIgaadrfqJWSzRpXGORZlkMqp = new TGMNVgEkzYRUJhRlmEORKKDOgVur(VAyGDGfoHBoDUCWNaIhGjglCTLfid, lmXcQhajdNKdniYMTQObQulPNJVV[sQaQMUbTVPmOeMTfmmdhnnoQRbRM].SCGcrIIDMjURHdkJjDIzHoMbvWQHA);
			if (dUxVIgaadrfqJWSzRpXGORZlkMqp == null)
			{
				return;
			}
			IList<mGCtkWxfHNgipjpNJrPlMcYgiHAeb> list = dUxVIgaadrfqJWSzRpXGORZlkMqp.hQiEBbgKRTDSiRPBLPKoZEyKJffcb();
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if ((list[i].dYOWBIwnTrqHAAMOZUTcVjxMVIUK.PRRpOkhGRpmYTaxqZbRqgXTDKOHx & AZnevqKCIWQlsGzMgiuOiXlPUErU.Axis) != AZnevqKCIWQlsGzMgiuOiXlPUErU.All)
					{
						dUxVIgaadrfqJWSzRpXGORZlkMqp.MRgfRfyrShjIzBYFIfiuqlDRKHEK.WfXVhhnLaBVsKHneEGAORYsOycyh = new tQFeFLIIfwDkSIttciiqLHyRENsoB(-65535, 65535);
					}
				}
			}
			dUxVIgaadrfqJWSzRpXGORZlkMqp.qqTnUdwDLRDdijbuOGAyBhNivyaqA();
		}
		voxoBYAimrcIeQjtgwMxLKYrrGIu voxoBYAimrcIeQjtgwMxLKYrrGIu2;
		try
		{
			voxoBYAimrcIeQjtgwMxLKYrrGIu2 = dUxVIgaadrfqJWSzRpXGORZlkMqp.BtCbOvIHOGQpBItNCNtrDviCbJtfB();
		}
		catch
		{
			voxoBYAimrcIeQjtgwMxLKYrrGIu2 = null;
		}
		if (voxoBYAimrcIeQjtgwMxLKYrrGIu2 == null)
		{
			return;
		}
		if (num3 > 0)
		{
			nCudswbgCdZfxrCtJbdPIrEFdYybb = nCudswbgCdZfxrCtJbdPIrEFdYybb + num3 + " connected devices:\n";
		}
		for (int j = 0; j < num3; j++)
		{
			nCudswbgCdZfxrCtJbdPIrEFdYybb = nCudswbgCdZfxrCtJbdPIrEFdYybb + lmXcQhajdNKdniYMTQObQulPNJVV[j].mqjctEYgXEfZnYIDMMngJxDYpBhU + "\n";
		}
		nCudswbgCdZfxrCtJbdPIrEFdYybb += "\n";
		nCudswbgCdZfxrCtJbdPIrEFdYybb = nCudswbgCdZfxrCtJbdPIrEFdYybb + "Current DI device " + sQaQMUbTVPmOeMTfmmdhnnoQRbRM + ": " + lmXcQhajdNKdniYMTQObQulPNJVV[sQaQMUbTVPmOeMTfmmdhnnoQRbRM].mqjctEYgXEfZnYIDMMngJxDYpBhU + "\n";
		nCudswbgCdZfxrCtJbdPIrEFdYybb += "(Press + or - to change monitored device id.)\n\n";
		oSrzFJGZfUCPHuNPLENPheEyWsoK("Identifier", new PidVid(dUxVIgaadrfqJWSzRpXGORZlkMqp.kpMbQJBjMApYRdZNhFkteyPYvUwtb.RqoeGgcphJkoXcPusfFTyPTciRntA));
		oSrzFJGZfUCPHuNPLENPheEyWsoK("Instance GUID", dUxVIgaadrfqJWSzRpXGORZlkMqp.kpMbQJBjMApYRdZNhFkteyPYvUwtb.SCGcrIIDMjURHdkJjDIzHoMbvWQHA);
		oSrzFJGZfUCPHuNPLENPheEyWsoK("Product Id", dUxVIgaadrfqJWSzRpXGORZlkMqp.MRgfRfyrShjIzBYFIfiuqlDRKHEK.nKaqOeNeXtRFQyIiPrSeMOBlIXKe);
		oSrzFJGZfUCPHuNPLENPheEyWsoK("Device Type", dUxVIgaadrfqJWSzRpXGORZlkMqp.gSKbQhPhCcxFkHCLeYWmJrvPjhbK.dTqvRoWTYLcyxOCegaoAeiVZAPTAb.ToString());
		nCudswbgCdZfxrCtJbdPIrEFdYybb += "\n";
		oSrzFJGZfUCPHuNPLENPheEyWsoK("Axis Count", dUxVIgaadrfqJWSzRpXGORZlkMqp.gSKbQhPhCcxFkHCLeYWmJrvPjhbK.NqTKrVbLutsaVoXhctUGYVTTPWFS);
		oSrzFJGZfUCPHuNPLENPheEyWsoK("Button Count", dUxVIgaadrfqJWSzRpXGORZlkMqp.gSKbQhPhCcxFkHCLeYWmJrvPjhbK.JVqCHAvnctFGSlUdMoFcLkcNXrDA);
		oSrzFJGZfUCPHuNPLENPheEyWsoK("Hat Count", dUxVIgaadrfqJWSzRpXGORZlkMqp.gSKbQhPhCcxFkHCLeYWmJrvPjhbK.gfDBhkyFyfyBIeMxjTnVOcGtibdX);
		nCudswbgCdZfxrCtJbdPIrEFdYybb += "\n";
		if (flag)
		{
			Rewired.Logger.Log("Device Name: \"" + lmXcQhajdNKdniYMTQObQulPNJVV[sQaQMUbTVPmOeMTfmmdhnnoQRbRM].mqjctEYgXEfZnYIDMMngJxDYpBhU + "\"");
			Rewired.Logger.Log("Identifier: " + new PidVid(dUxVIgaadrfqJWSzRpXGORZlkMqp.kpMbQJBjMApYRdZNhFkteyPYvUwtb.RqoeGgcphJkoXcPusfFTyPTciRntA).ToString());
		}
		for (int k = 0; k < 32; k++)
		{
			int num4 = mkqEwjEWKTccoblNpohIPzhMuvaL((DirectInputAxis)k, voxoBYAimrcIeQjtgwMxLKYrrGIu2);
			DirectInputAxis directInputAxis = (DirectInputAxis)k;
			string text = directInputAxis.ToString();
			oSrzFJGZfUCPHuNPLENPheEyWsoK(text, num4 + " (" + XkqINHLcERmXREsNUNSKIBnJXSoW(num4) + ")");
		}
		int[] array = voxoBYAimrcIeQjtgwMxLKYrrGIu2.YwGnMOKwAHDLEyCOXcOpCjBCXpNK;
		for (int l = 0; l < 4; l++)
		{
			int num5 = array[l];
			string text2 = "Hat " + l;
			oSrzFJGZfUCPHuNPLENPheEyWsoK(text2, num5);
		}
		bool[] array2 = voxoBYAimrcIeQjtgwMxLKYrrGIu2.syxPbhBJItzVAVLveDKeKXtdjmVVA;
		string text3 = "";
		for (int m = 0; m < 128; m++)
		{
			if (array2[m])
			{
				if (text3 != "")
				{
					text3 += ", ";
				}
				text3 += m;
			}
		}
		oSrzFJGZfUCPHuNPLENPheEyWsoK("Buttons ", text3);
		FRaZKhaTILmrjuSxKHaBodjQxfVM.text = nCudswbgCdZfxrCtJbdPIrEFdYybb;
	}

	private void XfxgwnHacNVnUdMeTealuvJLOsxd()
	{
		lmXcQhajdNKdniYMTQObQulPNJVV = VAyGDGfoHBoDUCWNaIhGjglCTLfid.LRVtwyTWSgrntlaZRBVqrFfsbLRz(pXLCPSuuAhzcgGmkJbVkDzXovEub.GameControl, XsxUPjMGXXOzFHWjBirlaEPOLxzP.AttachedOnly);
		lsQWhnbpSYUZUxdnmEOCvKZzAbCcA = VAyGDGfoHBoDUCWNaIhGjglCTLfid.LRVtwyTWSgrntlaZRBVqrFfsbLRz(pXLCPSuuAhzcgGmkJbVkDzXovEub.All, XsxUPjMGXXOzFHWjBirlaEPOLxzP.AttachedOnly);
		xKSrvMOHrAEbkidXlRfGsHMLnObDb = ((lsQWhnbpSYUZUxdnmEOCvKZzAbCcA != null) ? lsQWhnbpSYUZUxdnmEOCvKZzAbCcA.Count : 0);
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
		lsQWhnbpSYUZUxdnmEOCvKZzAbCcA = null;
		dQyChmifADJvJQhpuocMoiegCNMd = false;
		vjJRFMubUzwLBZlOVKUMMvJtVVRN = false;
		xKSrvMOHrAEbkidXlRfGsHMLnObDb = 0;
	}

	private void oSrzFJGZfUCPHuNPLENPheEyWsoK(string P_0, object P_1)
	{
		nCudswbgCdZfxrCtJbdPIrEFdYybb = nCudswbgCdZfxrCtJbdPIrEFdYybb + P_0 + " = " + P_1.ToString() + "\n";
	}

	private int mkqEwjEWKTccoblNpohIPzhMuvaL(DirectInputAxis P_0, voxoBYAimrcIeQjtgwMxLKYrrGIu P_1)
	{
		switch (P_0)
		{
		case DirectInputAxis.X:
			return P_1.XHAcjfYHxobupnkeqiFjdRtqsftl;
		case DirectInputAxis.Y:
			return P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ;
		case DirectInputAxis.Z:
			return P_1.nXGdfezugKPnijHxPqSGMXNvieeu;
		case DirectInputAxis.RotationX:
			return P_1.iVZXAatNNkoQhakyOcSvPZuywmil;
		case DirectInputAxis.RotationY:
			return P_1.fRKWXdIcjzUVKxBCLBAxjgTDzHXfA;
		case DirectInputAxis.RotationZ:
			return P_1.uXFvVgVvAswDejLdlJrCamssAhoj;
		case DirectInputAxis.Slider0:
			return P_1.YrVRqCBdYnMvpzdpuevFnfRkNtEB[0];
		case DirectInputAxis.Slider1:
			return P_1.YrVRqCBdYnMvpzdpuevFnfRkNtEB[1];
		case DirectInputAxis.VelocityX:
			return P_1.IVGASYlUTQmRAdogTdHGGGSkarzB;
		case DirectInputAxis.VelocityY:
			return P_1.BokrrSjVfAhYkIQmhzfHRbuAwaHg;
		case DirectInputAxis.VelocityZ:
			return P_1.irfbjzGcGIOFNuSIcxqNAnObMqwfA;
		case DirectInputAxis.AngularVelocityX:
			return P_1.MIprVMIPkzUhwQMRTGRBJUKDOEHG;
		case DirectInputAxis.AngularVelocityY:
			return P_1.gHFfmwgurBviMwjylTPNtvFERkueA;
		case DirectInputAxis.AngularVelocityZ:
			return P_1.ZJzfzzVoBQcjSbQzJDLBesKHhgrd;
		case DirectInputAxis.VelocitySlider0:
			return P_1.bcTvrKOzACMlcKbeYtQASNtoRYNF[0];
		case DirectInputAxis.VelocitySlider1:
			return P_1.bcTvrKOzACMlcKbeYtQASNtoRYNF[1];
		case DirectInputAxis.AccelerationX:
			return P_1.mLaQWAdMKFPMBUGNBffgLOgiOfei;
		case DirectInputAxis.AccelerationY:
			return P_1.SwbkYdbTEUHqQhNPkvGRnQfJjnBM;
		case DirectInputAxis.AccelerationZ:
			return P_1.jZdAQOYvoJwkNAKHfQVbsbezVfmW;
		case DirectInputAxis.AngularAccelerationX:
			return P_1.ispeatToHywvYYMSuZWhkGwDnwYp;
		case DirectInputAxis.AngularAccelerationY:
			return P_1.IpSfimgoprwpPbvvZHasGFLoyFpU;
		case DirectInputAxis.AngularAccelerationZ:
			return P_1.vTBwIFSNkxHsobDCWeicqTmmUnIH;
		case DirectInputAxis.AccelerationSlider0:
			return P_1.tkaAtqiNIrFwnbfhpfDKyViuRMGV[0];
		case DirectInputAxis.AccelerationSlider1:
			return P_1.tkaAtqiNIrFwnbfhpfDKyViuRMGV[1];
		case DirectInputAxis.ForceX:
			return P_1.taoHjuPyxajupaEHhgrYbSBkwtZo;
		case DirectInputAxis.ForceY:
			return P_1.lsBdvuIbCnbembzorkupUPfpqrMG;
		case DirectInputAxis.ForceZ:
			return P_1.qdgKtiruueifuNJqTMRtZTgjWvmn;
		case DirectInputAxis.TorqueX:
			return P_1.jRBPLEpruUgsqCpLoBAvnjcDbnwlA;
		case DirectInputAxis.TorqueY:
			return P_1.fMiDgiXVKZbDOKqlvGclhoBcUCoDB;
		case DirectInputAxis.TorqueZ:
			return P_1.KdwAVnhDDPrFtJAllRAkceDPAadz;
		case DirectInputAxis.ForceSlider0:
			return P_1.bbzjSUmzCpvKeztqjjpYuJViWzaP[0];
		case DirectInputAxis.ForceSlider1:
			return P_1.bbzjSUmzCpvKeztqjjpYuJViWzaP[1];
		default:
			return 0;
		}
	}

	private float XkqINHLcERmXREsNUNSKIBnJXSoW(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}

	public void OnDestroy()
	{
		if (dUxVIgaadrfqJWSzRpXGORZlkMqp != null)
		{
			dUxVIgaadrfqJWSzRpXGORZlkMqp.zobeSpTCoofGnipPFjpZGNzdwEoE();
		}
	}
}
