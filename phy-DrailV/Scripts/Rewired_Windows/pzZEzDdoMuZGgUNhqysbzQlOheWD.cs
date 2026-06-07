using System;
using Rewired;
using Rewired.Platforms.Microsoft.WindowsGamingInput;

internal sealed class pzZEzDdoMuZGgUNhqysbzQlOheWD : LRjGDiyCmNXFwrfYWCQyGHCNrEOhA
{
	private const int alpbKwLALkCahrtZbQONzDYKzPjn = 14;

	private const int hPGYvOJyGRFAXlayNclRbQbgBrho = 6;

	private const int GlJwIjJIPZnHArhQuCAwcYBiCWFp = 0;

	private const int JRVaqxBKatYgbGYyeEJbKTzddNthb = 4;

	private const bool SFHEoLFtkmPWaGuXCKXjAhXIeZUVA = true;

	private KjCHeFcNkYjJzESIKPSiBBloOtLf agogorRzkzoPeYcrWEKmHeLmFiiK;

	private qYblfIKWTJCcUzwzMzhWLaymennH uReLQFCvKGfAEJqlGntBwnXfyEah;

	private qYblfIKWTJCcUzwzMzhWLaymennH VYmDPFhgopoeOwnumbrSgAGwixeD;

	private double afLJffDjplLKsByTZRpRWJCWDvWI;

	private bool gFKELBSWuhgpKzEENLfqJGUPqSWo;

	private double wWlcVWXEwQagNGuDKNxqbxbtieqUA;

	private Action<KjCHeFcNkYjJzESIKPSiBBloOtLf, qYblfIKWTJCcUzwzMzhWLaymennH> FsijgjEbKSsIHcRlWMGyvkWiDrWcA;

	public KjCHeFcNkYjJzESIKPSiBBloOtLf BCEJAizXSvucuShEhCivWcsNuuyl => agogorRzkzoPeYcrWEKmHeLmFiiK;

	bool LRjGDiyCmNXFwrfYWCQyGHCNrEOhA.SupportsVibration => true;

	int LRjGDiyCmNXFwrfYWCQyGHCNrEOhA.VibrationMotorCount => 4;

	public pzZEzDdoMuZGgUNhqysbzQlOheWD(KjCHeFcNkYjJzESIKPSiBBloOtLf P_0, int P_1, Action<KjCHeFcNkYjJzESIKPSiBBloOtLf, qYblfIKWTJCcUzwzMzhWLaymennH> P_2)
		: base(WGIDeviceType.Gamepad, P_0, P_1, 14, 6, 0)
	{
		if (KjCHeFcNkYjJzESIKPSiBBloOtLf.KnRQEmwHYQnLlhpqQiYLhcNhPfug(P_0, null))
		{
			throw new ArgumentNullException("gamepad");
		}
		if (P_2 == null)
		{
			throw new ArgumentNullException("commitVibrationDelegate");
		}
		agogorRzkzoPeYcrWEKmHeLmFiiK = P_0;
		FsijgjEbKSsIHcRlWMGyvkWiDrWcA = P_2;
	}

	public void biVimzifKYhPASSMiMszQGhHToFB(dpAQVaQJEhyBbqThhjtzRWIlvUBi P_0, double P_1)
	{
		NAMTrcvXYLWpIwbVCKZHcEYqDTzA.SetValue(0, (P_0.syxPbhBJItzVAVLveDKeKXtdjmVVA & GamepadButtons.A) != 0, P_1);
		NAMTrcvXYLWpIwbVCKZHcEYqDTzA.SetValue(1, (P_0.syxPbhBJItzVAVLveDKeKXtdjmVVA & GamepadButtons.B) != 0, P_1);
		NAMTrcvXYLWpIwbVCKZHcEYqDTzA.SetValue(2, (P_0.syxPbhBJItzVAVLveDKeKXtdjmVVA & GamepadButtons.X) != 0, P_1);
		NAMTrcvXYLWpIwbVCKZHcEYqDTzA.SetValue(3, (P_0.syxPbhBJItzVAVLveDKeKXtdjmVVA & GamepadButtons.Y) != 0, P_1);
		NAMTrcvXYLWpIwbVCKZHcEYqDTzA.SetValue(4, (P_0.syxPbhBJItzVAVLveDKeKXtdjmVVA & GamepadButtons.LeftShoulder) != 0, P_1);
		NAMTrcvXYLWpIwbVCKZHcEYqDTzA.SetValue(5, (P_0.syxPbhBJItzVAVLveDKeKXtdjmVVA & GamepadButtons.RightShoulder) != 0, P_1);
		NAMTrcvXYLWpIwbVCKZHcEYqDTzA.SetValue(6, (P_0.syxPbhBJItzVAVLveDKeKXtdjmVVA & GamepadButtons.View) != 0, P_1);
		NAMTrcvXYLWpIwbVCKZHcEYqDTzA.SetValue(7, (P_0.syxPbhBJItzVAVLveDKeKXtdjmVVA & GamepadButtons.Menu) != 0, P_1);
		NAMTrcvXYLWpIwbVCKZHcEYqDTzA.SetValue(8, (P_0.syxPbhBJItzVAVLveDKeKXtdjmVVA & GamepadButtons.LeftThumbstick) != 0, P_1);
		NAMTrcvXYLWpIwbVCKZHcEYqDTzA.SetValue(9, (P_0.syxPbhBJItzVAVLveDKeKXtdjmVVA & GamepadButtons.RightThumbstick) != 0, P_1);
		NAMTrcvXYLWpIwbVCKZHcEYqDTzA.SetValue(10, (P_0.syxPbhBJItzVAVLveDKeKXtdjmVVA & GamepadButtons.DPadUp) != 0, P_1);
		NAMTrcvXYLWpIwbVCKZHcEYqDTzA.SetValue(11, (P_0.syxPbhBJItzVAVLveDKeKXtdjmVVA & GamepadButtons.DPadRight) != 0, P_1);
		NAMTrcvXYLWpIwbVCKZHcEYqDTzA.SetValue(12, (P_0.syxPbhBJItzVAVLveDKeKXtdjmVVA & GamepadButtons.DPadDown) != 0, P_1);
		NAMTrcvXYLWpIwbVCKZHcEYqDTzA.SetValue(13, (P_0.syxPbhBJItzVAVLveDKeKXtdjmVVA & GamepadButtons.DPadLeft) != 0, P_1);
		jzqfmHHqqFqkeYQqsSKetsnjJTXX[0].pWRdAJigDslyLjNIYbVMMkTWOPgC = (float)P_0.DiBvvqUKabSUMcBpmDDtOGoauEXR;
		jzqfmHHqqFqkeYQqsSKetsnjJTXX[1].pWRdAJigDslyLjNIYbVMMkTWOPgC = (float)P_0.TDiYpSoBhnihceOPyFUhvMHFDFsy;
		jzqfmHHqqFqkeYQqsSKetsnjJTXX[2].pWRdAJigDslyLjNIYbVMMkTWOPgC = (float)P_0.jfmJYjQWgTWzPOHUxfCeVDlHdvxx;
		jzqfmHHqqFqkeYQqsSKetsnjJTXX[3].pWRdAJigDslyLjNIYbVMMkTWOPgC = (float)P_0.uQvysrSZxvNoKAbsVxoQxIGQbQygA;
		jzqfmHHqqFqkeYQqsSKetsnjJTXX[4].pWRdAJigDslyLjNIYbVMMkTWOPgC = (float)P_0.yWSFKFEZfcuyGsIrNIHGcVoNdiKpA;
		jzqfmHHqqFqkeYQqsSKetsnjJTXX[5].pWRdAJigDslyLjNIYbVMMkTWOPgC = (float)P_0.GzMrQBOyzotNMNIFqVCkpghEVknH;
	}

	public override void mefhGqvTkcrETnFSidhNngFjAYNV(UpdateLoopType P_0)
	{
		base.mefhGqvTkcrETnFSidhNngFjAYNV(P_0);
		PoUaIzcHzxHsIJLePvaBgCgcYKhrA();
	}

	public override void GakDHFgZtfHRkJQPyctqdjzIeosJc(NPcbXYOMZTPjQpCotxkrcLlyrqWf P_0)
	{
		base.GakDHFgZtfHRkJQPyctqdjzIeosJc(P_0);
		if (P_0 is pzZEzDdoMuZGgUNhqysbzQlOheWD pzZEzDdoMuZGgUNhqysbzQlOheWD2)
		{
			agogorRzkzoPeYcrWEKmHeLmFiiK = pzZEzDdoMuZGgUNhqysbzQlOheWD2.agogorRzkzoPeYcrWEKmHeLmFiiK;
		}
	}

	public float qRMuwtsAaYfoyquhBDmqGCuRvYkw(int P_0)
	{
		qYblfIKWTJCcUzwzMzhWLaymennH qYblfIKWTJCcUzwzMzhWLaymennH2 = agogorRzkzoPeYcrWEKmHeLmFiiK.neQxlYnEyEaZhAOllmdjXIpIwFLIA;
		switch (P_0)
		{
		case 0:
			return (float)qYblfIKWTJCcUzwzMzhWLaymennH2.MoUEVtYkNtJFCzWMQHZtqPhgPOaF;
		case 1:
			return (float)qYblfIKWTJCcUzwzMzhWLaymennH2.keMmfqFrFliYoJcTuogcSeEXwcvV;
		case 2:
			return (float)qYblfIKWTJCcUzwzMzhWLaymennH2.yWSFKFEZfcuyGsIrNIHGcVoNdiKpA;
		case 3:
			return (float)qYblfIKWTJCcUzwzMzhWLaymennH2.GzMrQBOyzotNMNIFqVCkpghEVknH;
		default:
			return 0f;
		}
	}

	public void SSYDhArzaqosllxWhbucIiAwdyFZ(int P_0, float P_1, bool P_2)
	{
		if (P_0 >= 0 && P_0 < 4)
		{
			if (P_1 < 0f)
			{
				P_1 = 0f;
			}
			else if (P_1 > 1f)
			{
				P_1 = 1f;
			}
			if (P_2)
			{
				KOvyjmcDrWkwysJDVuiHnigdXmNG(ref uReLQFCvKGfAEJqlGntBwnXfyEah);
			}
			switch (P_0)
			{
			case 0:
				uReLQFCvKGfAEJqlGntBwnXfyEah.MoUEVtYkNtJFCzWMQHZtqPhgPOaF = P_1;
				break;
			case 1:
				uReLQFCvKGfAEJqlGntBwnXfyEah.keMmfqFrFliYoJcTuogcSeEXwcvV = P_1;
				break;
			case 2:
				uReLQFCvKGfAEJqlGntBwnXfyEah.yWSFKFEZfcuyGsIrNIHGcVoNdiKpA = P_1;
				break;
			case 3:
				uReLQFCvKGfAEJqlGntBwnXfyEah.GzMrQBOyzotNMNIFqVCkpghEVknH = P_1;
				break;
			}
			EkndpcBQQwixiqpwBGwdDSVdhEMIc(false);
		}
	}

	public void TtqTMYGbIwcFrQNfdmWJpZTiqfPI()
	{
		KOvyjmcDrWkwysJDVuiHnigdXmNG(ref uReLQFCvKGfAEJqlGntBwnXfyEah);
		EkndpcBQQwixiqpwBGwdDSVdhEMIc(true);
	}

	private void PoUaIzcHzxHsIJLePvaBgCgcYKhrA()
	{
		if (gFKELBSWuhgpKzEENLfqJGUPqSWo)
		{
			upwMJZvNFgBGUEvNulPZfbuMfCCZA();
		}
		eGkpYzKeQCBRwHGZgrYgAyUzptsm();
	}

	private void eGkpYzKeQCBRwHGZgrYgAyUzptsm()
	{
		if (!(ReInput.unscaledTime < afLJffDjplLKsByTZRpRWJCWDvWI) && djNpjqajwQeghNvszAhAYnfOuxrf(ref uReLQFCvKGfAEJqlGntBwnXfyEah))
		{
			EkndpcBQQwixiqpwBGwdDSVdhEMIc(true);
		}
	}

	private void EkndpcBQQwixiqpwBGwdDSVdhEMIc(bool P_0)
	{
		gFKELBSWuhgpKzEENLfqJGUPqSWo = true;
		if (P_0)
		{
			sFepLEEAKUuQDGIxvsdqPhXqByeC();
		}
	}

	private void upwMJZvNFgBGUEvNulPZfbuMfCCZA()
	{
		if (gFKELBSWuhgpKzEENLfqJGUPqSWo && !(ReInput.unscaledTime < wWlcVWXEwQagNGuDKNxqbxbtieqUA + 0.009999999776482582))
		{
			sFepLEEAKUuQDGIxvsdqPhXqByeC();
		}
	}

	private void sFepLEEAKUuQDGIxvsdqPhXqByeC()
	{
		if (!djNpjqajwQeghNvszAhAYnfOuxrf(ref uReLQFCvKGfAEJqlGntBwnXfyEah) && !djNpjqajwQeghNvszAhAYnfOuxrf(ref VYmDPFhgopoeOwnumbrSgAGwixeD))
		{
			gFKELBSWuhgpKzEENLfqJGUPqSWo = false;
			return;
		}
		FsijgjEbKSsIHcRlWMGyvkWiDrWcA(agogorRzkzoPeYcrWEKmHeLmFiiK, uReLQFCvKGfAEJqlGntBwnXfyEah);
		double unscaledTime = ReInput.unscaledTime;
		afLJffDjplLKsByTZRpRWJCWDvWI = unscaledTime + 1.5;
		wWlcVWXEwQagNGuDKNxqbxbtieqUA = unscaledTime;
		AUYXDtKsdoTkjOgOfCafDtVTAjFz(ref uReLQFCvKGfAEJqlGntBwnXfyEah, ref VYmDPFhgopoeOwnumbrSgAGwixeD);
		gFKELBSWuhgpKzEENLfqJGUPqSWo = false;
	}

	private bool djNpjqajwQeghNvszAhAYnfOuxrf(ref qYblfIKWTJCcUzwzMzhWLaymennH P_0)
	{
		if (P_0.MoUEVtYkNtJFCzWMQHZtqPhgPOaF > 0.0 || P_0.keMmfqFrFliYoJcTuogcSeEXwcvV > 0.0 || P_0.yWSFKFEZfcuyGsIrNIHGcVoNdiKpA > 0.0 || P_0.GzMrQBOyzotNMNIFqVCkpghEVknH > 0.0)
		{
			return true;
		}
		return false;
	}

	private void KOvyjmcDrWkwysJDVuiHnigdXmNG(ref qYblfIKWTJCcUzwzMzhWLaymennH P_0)
	{
		P_0.MoUEVtYkNtJFCzWMQHZtqPhgPOaF = 0.0;
		P_0.keMmfqFrFliYoJcTuogcSeEXwcvV = 0.0;
		P_0.yWSFKFEZfcuyGsIrNIHGcVoNdiKpA = 0.0;
		P_0.GzMrQBOyzotNMNIFqVCkpghEVknH = 0.0;
	}

	private void AUYXDtKsdoTkjOgOfCafDtVTAjFz(ref qYblfIKWTJCcUzwzMzhWLaymennH P_0, ref qYblfIKWTJCcUzwzMzhWLaymennH P_1)
	{
		P_1.MoUEVtYkNtJFCzWMQHZtqPhgPOaF = P_0.MoUEVtYkNtJFCzWMQHZtqPhgPOaF;
		P_1.keMmfqFrFliYoJcTuogcSeEXwcvV = P_0.keMmfqFrFliYoJcTuogcSeEXwcvV;
		P_1.yWSFKFEZfcuyGsIrNIHGcVoNdiKpA = P_0.yWSFKFEZfcuyGsIrNIHGcVoNdiKpA;
		P_1.GzMrQBOyzotNMNIFqVCkpghEVknH = P_0.GzMrQBOyzotNMNIFqVCkpghEVknH;
	}

	protected override bool vCBFvIdHsbAnKBZkroQOsRrLIAyV(bool P_0)
	{
		if (base.vCBFvIdHsbAnKBZkroQOsRrLIAyV(P_0))
		{
			return true;
		}
		if (P_0 && KjCHeFcNkYjJzESIKPSiBBloOtLf.aVrCGbDxOYyGJCHKjqMUEaQwsGZeb(agogorRzkzoPeYcrWEKmHeLmFiiK, null))
		{
			try
			{
				agogorRzkzoPeYcrWEKmHeLmFiiK.neQxlYnEyEaZhAOllmdjXIpIwFLIA = default(qYblfIKWTJCcUzwzMzhWLaymennH);
			}
			catch
			{
			}
		}
		return false;
	}
}
