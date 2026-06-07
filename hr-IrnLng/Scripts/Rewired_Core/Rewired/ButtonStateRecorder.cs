using Rewired.Utils;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	internal class ButtonStateRecorder
	{
		private class cKHDEPbBcldomCiMVslglZeuvedu
		{
			public bool NOPQVhqkBWMrvrfDpfQaBWDBYUI;

			public double qrbwLYJjtGFdpgsrupVlChDHstaj;

			public void tlMbXbDwaaKJTudkJIuTPdZmwuo(cKHDEPbBcldomCiMVslglZeuvedu P_0)
			{
				NOPQVhqkBWMrvrfDpfQaBWDBYUI = P_0.NOPQVhqkBWMrvrfDpfQaBWDBYUI;
				qrbwLYJjtGFdpgsrupVlChDHstaj = P_0.qrbwLYJjtGFdpgsrupVlChDHstaj;
			}

			public void agvWMBoHtblzmgSmVloJbsDkfGk()
			{
				NOPQVhqkBWMrvrfDpfQaBWDBYUI = false;
				qrbwLYJjtGFdpgsrupVlChDHstaj = 0.0;
			}
		}

		private const int lRVQfPHPGtDgSWjWZSpkMmZSGDv = 3;

		private cKHDEPbBcldomCiMVslglZeuvedu[] DBNLceLJjOSJnIoFWvBsUwReOrv;

		private cKHDEPbBcldomCiMVslglZeuvedu[] KqPKBymRaaOLWOGFCiszoRuBgEr;

		private int ohmKzjuKIphSAHrzlNYstmvsSMn;

		private int BEIlepVCSCdVzSSIznakRoOAaoGe;

		private uint ANfsFoHVwfingWTcgnrBQOQEVmA;

		public double timePressed
		{
			get
			{
				if (!DBNLceLJjOSJnIoFWvBsUwReOrv[ohmKzjuKIphSAHrzlNYstmvsSMn].NOPQVhqkBWMrvrfDpfQaBWDBYUI)
				{
					return 0.0;
				}
				return ReInput.unscaledTime - DBNLceLJjOSJnIoFWvBsUwReOrv[ohmKzjuKIphSAHrzlNYstmvsSMn].qrbwLYJjtGFdpgsrupVlChDHstaj;
			}
		}

		public double timeUnpressed
		{
			get
			{
				if (DBNLceLJjOSJnIoFWvBsUwReOrv[ohmKzjuKIphSAHrzlNYstmvsSMn].NOPQVhqkBWMrvrfDpfQaBWDBYUI)
				{
					return 0.0;
				}
				return ReInput.unscaledTime - DBNLceLJjOSJnIoFWvBsUwReOrv[ohmKzjuKIphSAHrzlNYstmvsSMn].qrbwLYJjtGFdpgsrupVlChDHstaj;
			}
		}

		public double lastTimePressed
		{
			get
			{
				if (DBNLceLJjOSJnIoFWvBsUwReOrv[ohmKzjuKIphSAHrzlNYstmvsSMn].NOPQVhqkBWMrvrfDpfQaBWDBYUI)
				{
					return ReInput.unscaledTime;
				}
				return DBNLceLJjOSJnIoFWvBsUwReOrv[ohmKzjuKIphSAHrzlNYstmvsSMn].qrbwLYJjtGFdpgsrupVlChDHstaj;
			}
		}

		public double lastTimeUnpressed
		{
			get
			{
				if (!DBNLceLJjOSJnIoFWvBsUwReOrv[ohmKzjuKIphSAHrzlNYstmvsSMn].NOPQVhqkBWMrvrfDpfQaBWDBYUI)
				{
					return ReInput.unscaledTime;
				}
				return DBNLceLJjOSJnIoFWvBsUwReOrv[ohmKzjuKIphSAHrzlNYstmvsSMn].qrbwLYJjtGFdpgsrupVlChDHstaj;
			}
		}

		public double lastTimeStateChangedToPressed
		{
			get
			{
				if (DBNLceLJjOSJnIoFWvBsUwReOrv[ohmKzjuKIphSAHrzlNYstmvsSMn].NOPQVhqkBWMrvrfDpfQaBWDBYUI)
				{
					return DBNLceLJjOSJnIoFWvBsUwReOrv[ohmKzjuKIphSAHrzlNYstmvsSMn].qrbwLYJjtGFdpgsrupVlChDHstaj;
				}
				return DBNLceLJjOSJnIoFWvBsUwReOrv[vsvfIimEgbJOXdXyoJhrhDJQERo(ohmKzjuKIphSAHrzlNYstmvsSMn, 1)].qrbwLYJjtGFdpgsrupVlChDHstaj;
			}
		}

		public double lastTimeStateChangedToUnpressed
		{
			get
			{
				if (!DBNLceLJjOSJnIoFWvBsUwReOrv[ohmKzjuKIphSAHrzlNYstmvsSMn].NOPQVhqkBWMrvrfDpfQaBWDBYUI)
				{
					return DBNLceLJjOSJnIoFWvBsUwReOrv[ohmKzjuKIphSAHrzlNYstmvsSMn].qrbwLYJjtGFdpgsrupVlChDHstaj;
				}
				return DBNLceLJjOSJnIoFWvBsUwReOrv[vsvfIimEgbJOXdXyoJhrhDJQERo(ohmKzjuKIphSAHrzlNYstmvsSMn, 1)].qrbwLYJjtGFdpgsrupVlChDHstaj;
			}
		}

		public double lastTimeStateChanged => DBNLceLJjOSJnIoFWvBsUwReOrv[ohmKzjuKIphSAHrzlNYstmvsSMn].qrbwLYJjtGFdpgsrupVlChDHstaj;

		public ButtonStateRecorder()
		{
			DBNLceLJjOSJnIoFWvBsUwReOrv = new cKHDEPbBcldomCiMVslglZeuvedu[3];
			KqPKBymRaaOLWOGFCiszoRuBgEr = new cKHDEPbBcldomCiMVslglZeuvedu[3];
			for (int i = 0; i < 3; i++)
			{
				DBNLceLJjOSJnIoFWvBsUwReOrv[i] = new cKHDEPbBcldomCiMVslglZeuvedu();
				KqPKBymRaaOLWOGFCiszoRuBgEr[i] = new cKHDEPbBcldomCiMVslglZeuvedu();
			}
			ohmKzjuKIphSAHrzlNYstmvsSMn = 0;
			BEIlepVCSCdVzSSIznakRoOAaoGe = 0;
		}

		public void iAnBBfDdWbgOiFHwNWqxFDtiXzYA(bool P_0, bool P_1, double P_2)
		{
			bool flag = ((!DBNLceLJjOSJnIoFWvBsUwReOrv[ohmKzjuKIphSAHrzlNYstmvsSMn].NOPQVhqkBWMrvrfDpfQaBWDBYUI) ? P_0 : P_1);
			if (DBNLceLJjOSJnIoFWvBsUwReOrv[ohmKzjuKIphSAHrzlNYstmvsSMn].NOPQVhqkBWMrvrfDpfQaBWDBYUI == flag)
			{
				if (ReInput.currentFrame == MiscTools.Tick(ANfsFoHVwfingWTcgnrBQOQEVmA))
				{
					WUUPKkIaeRUBIogbESVOoBEwiWM();
				}
			}
			else
			{
				WUUPKkIaeRUBIogbESVOoBEwiWM();
				ANfsFoHVwfingWTcgnrBQOQEVmA = ReInput.currentFrame;
				ohmKzjuKIphSAHrzlNYstmvsSMn = MWIJFkHfHOGoffHffvUzgkbHSwn(ohmKzjuKIphSAHrzlNYstmvsSMn, 1);
				DBNLceLJjOSJnIoFWvBsUwReOrv[ohmKzjuKIphSAHrzlNYstmvsSMn].NOPQVhqkBWMrvrfDpfQaBWDBYUI = flag;
				DBNLceLJjOSJnIoFWvBsUwReOrv[ohmKzjuKIphSAHrzlNYstmvsSMn].qrbwLYJjtGFdpgsrupVlChDHstaj = P_2;
			}
		}

		public bool qqoQTcwXGEOuvgOuoaHFIhKZOIw(float P_0)
		{
			return qqoQTcwXGEOuvgOuoaHFIhKZOIw(DBNLceLJjOSJnIoFWvBsUwReOrv, ohmKzjuKIphSAHrzlNYstmvsSMn, P_0);
		}

		public bool khReyfaxYnVKatcOpyVRiAvmqwLx(float P_0)
		{
			return qqoQTcwXGEOuvgOuoaHFIhKZOIw(KqPKBymRaaOLWOGFCiszoRuBgEr, BEIlepVCSCdVzSSIznakRoOAaoGe, P_0);
		}

		private static bool qqoQTcwXGEOuvgOuoaHFIhKZOIw(cKHDEPbBcldomCiMVslglZeuvedu[] P_0, int P_1, float P_2)
		{
			if (P_2 <= 0f)
			{
				return false;
			}
			if (!P_0[P_1].NOPQVhqkBWMrvrfDpfQaBWDBYUI)
			{
				return false;
			}
			int num = vsvfIimEgbJOXdXyoJhrhDJQERo(P_1, 2);
			if (!P_0[num].NOPQVhqkBWMrvrfDpfQaBWDBYUI)
			{
				return false;
			}
			if (P_0[P_1].qrbwLYJjtGFdpgsrupVlChDHstaj - P_0[num].qrbwLYJjtGFdpgsrupVlChDHstaj <= (double)P_2)
			{
				return true;
			}
			return false;
		}

		private void WUUPKkIaeRUBIogbESVOoBEwiWM()
		{
			if (BEIlepVCSCdVzSSIznakRoOAaoGe != ohmKzjuKIphSAHrzlNYstmvsSMn)
			{
				BEIlepVCSCdVzSSIznakRoOAaoGe = ohmKzjuKIphSAHrzlNYstmvsSMn;
			}
			for (int i = 0; i < 3; i++)
			{
				KqPKBymRaaOLWOGFCiszoRuBgEr[i].tlMbXbDwaaKJTudkJIuTPdZmwuo(DBNLceLJjOSJnIoFWvBsUwReOrv[i]);
			}
		}

		public void agvWMBoHtblzmgSmVloJbsDkfGk()
		{
			ohmKzjuKIphSAHrzlNYstmvsSMn = 0;
			BEIlepVCSCdVzSSIznakRoOAaoGe = 0;
			for (int i = 0; i < 3; i++)
			{
				DBNLceLJjOSJnIoFWvBsUwReOrv[i].agvWMBoHtblzmgSmVloJbsDkfGk();
				KqPKBymRaaOLWOGFCiszoRuBgEr[i].agvWMBoHtblzmgSmVloJbsDkfGk();
			}
			ANfsFoHVwfingWTcgnrBQOQEVmA = 0u;
		}

		public void sMUgVFzNYCmMbTjSKBcLQHtNmmC(double P_0)
		{
			iAnBBfDdWbgOiFHwNWqxFDtiXzYA(false, false, P_0);
		}

		private static int MWIJFkHfHOGoffHffvUzgkbHSwn(int P_0, int P_1)
		{
			if (P_1 < 0)
			{
				P_1 = 0;
			}
			else if (P_1 > 3)
			{
				P_1 = 3;
			}
			int num = P_0 + P_1;
			if (num >= 3)
			{
				num -= 3;
			}
			return num;
		}

		private static int vsvfIimEgbJOXdXyoJhrhDJQERo(int P_0, int P_1)
		{
			if (P_1 < 0)
			{
				P_1 = 0;
			}
			else if (P_1 > 3)
			{
				P_1 = 3;
			}
			int num = P_0 - P_1;
			if (num < 0)
			{
				num += 3;
			}
			return num;
		}
	}
}
