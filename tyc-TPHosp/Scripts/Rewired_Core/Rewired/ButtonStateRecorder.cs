using Rewired.Utils;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	internal class ButtonStateRecorder
	{
		private class UrntrtUfZkzJwtxaQEzlXRDIoyT
		{
			public bool hldjmLLhRFbldypJyNprJPlbZSg;

			public double YaNikuiCGBjKtibFhmHuzxkYrtMU;

			public void JYyEPkmZztzXfbEgKghAFieAytO(UrntrtUfZkzJwtxaQEzlXRDIoyT P_0)
			{
				hldjmLLhRFbldypJyNprJPlbZSg = P_0.hldjmLLhRFbldypJyNprJPlbZSg;
				YaNikuiCGBjKtibFhmHuzxkYrtMU = P_0.YaNikuiCGBjKtibFhmHuzxkYrtMU;
			}

			public void QjNHfjHnCmaQyvCGKbwODraSxUWC()
			{
				hldjmLLhRFbldypJyNprJPlbZSg = false;
				YaNikuiCGBjKtibFhmHuzxkYrtMU = 0.0;
			}
		}

		private const int LYjEKzbapaiTQbDcHKjzMQazyFNW = 3;

		private UrntrtUfZkzJwtxaQEzlXRDIoyT[] fopcRAyqeBjmZPOELjthAdVYQiB;

		private UrntrtUfZkzJwtxaQEzlXRDIoyT[] sjUdYVuJvIlOBLbHJuomjXrqOX;

		private int UQZzLZapifMOUcZmRZfvIQOEUX;

		private int xocQNZcjVBqvRBkqckdxXdlguyh;

		private uint emtREvNRkbLQtddbdGleQNpmZLQ;

		public double timePressed
		{
			get
			{
				if (!fopcRAyqeBjmZPOELjthAdVYQiB[UQZzLZapifMOUcZmRZfvIQOEUX].hldjmLLhRFbldypJyNprJPlbZSg)
				{
					return 0.0;
				}
				return ReInput.unscaledTime - fopcRAyqeBjmZPOELjthAdVYQiB[UQZzLZapifMOUcZmRZfvIQOEUX].YaNikuiCGBjKtibFhmHuzxkYrtMU;
			}
		}

		public double timeUnpressed
		{
			get
			{
				if (fopcRAyqeBjmZPOELjthAdVYQiB[UQZzLZapifMOUcZmRZfvIQOEUX].hldjmLLhRFbldypJyNprJPlbZSg)
				{
					return 0.0;
				}
				return ReInput.unscaledTime - fopcRAyqeBjmZPOELjthAdVYQiB[UQZzLZapifMOUcZmRZfvIQOEUX].YaNikuiCGBjKtibFhmHuzxkYrtMU;
			}
		}

		public double lastTimePressed
		{
			get
			{
				if (fopcRAyqeBjmZPOELjthAdVYQiB[UQZzLZapifMOUcZmRZfvIQOEUX].hldjmLLhRFbldypJyNprJPlbZSg)
				{
					return ReInput.unscaledTime;
				}
				return fopcRAyqeBjmZPOELjthAdVYQiB[UQZzLZapifMOUcZmRZfvIQOEUX].YaNikuiCGBjKtibFhmHuzxkYrtMU;
			}
		}

		public double lastTimeUnpressed
		{
			get
			{
				if (!fopcRAyqeBjmZPOELjthAdVYQiB[UQZzLZapifMOUcZmRZfvIQOEUX].hldjmLLhRFbldypJyNprJPlbZSg)
				{
					return ReInput.unscaledTime;
				}
				return fopcRAyqeBjmZPOELjthAdVYQiB[UQZzLZapifMOUcZmRZfvIQOEUX].YaNikuiCGBjKtibFhmHuzxkYrtMU;
			}
		}

		public double lastTimeStateChangedToPressed
		{
			get
			{
				if (fopcRAyqeBjmZPOELjthAdVYQiB[UQZzLZapifMOUcZmRZfvIQOEUX].hldjmLLhRFbldypJyNprJPlbZSg)
				{
					return fopcRAyqeBjmZPOELjthAdVYQiB[UQZzLZapifMOUcZmRZfvIQOEUX].YaNikuiCGBjKtibFhmHuzxkYrtMU;
				}
				return fopcRAyqeBjmZPOELjthAdVYQiB[ZcNEnETDQujGHkYahBIcpCmuPMI(UQZzLZapifMOUcZmRZfvIQOEUX, 1)].YaNikuiCGBjKtibFhmHuzxkYrtMU;
			}
		}

		public double lastTimeStateChangedToUnpressed
		{
			get
			{
				if (!fopcRAyqeBjmZPOELjthAdVYQiB[UQZzLZapifMOUcZmRZfvIQOEUX].hldjmLLhRFbldypJyNprJPlbZSg)
				{
					return fopcRAyqeBjmZPOELjthAdVYQiB[UQZzLZapifMOUcZmRZfvIQOEUX].YaNikuiCGBjKtibFhmHuzxkYrtMU;
				}
				return fopcRAyqeBjmZPOELjthAdVYQiB[ZcNEnETDQujGHkYahBIcpCmuPMI(UQZzLZapifMOUcZmRZfvIQOEUX, 1)].YaNikuiCGBjKtibFhmHuzxkYrtMU;
			}
		}

		public double lastTimeStateChanged => fopcRAyqeBjmZPOELjthAdVYQiB[UQZzLZapifMOUcZmRZfvIQOEUX].YaNikuiCGBjKtibFhmHuzxkYrtMU;

		public ButtonStateRecorder()
		{
			fopcRAyqeBjmZPOELjthAdVYQiB = new UrntrtUfZkzJwtxaQEzlXRDIoyT[3];
			sjUdYVuJvIlOBLbHJuomjXrqOX = new UrntrtUfZkzJwtxaQEzlXRDIoyT[3];
			for (int i = 0; i < 3; i++)
			{
				fopcRAyqeBjmZPOELjthAdVYQiB[i] = new UrntrtUfZkzJwtxaQEzlXRDIoyT();
				sjUdYVuJvIlOBLbHJuomjXrqOX[i] = new UrntrtUfZkzJwtxaQEzlXRDIoyT();
			}
			UQZzLZapifMOUcZmRZfvIQOEUX = 0;
			xocQNZcjVBqvRBkqckdxXdlguyh = 0;
		}

		public void QTPiZFmnRsxmyQYmMuIoBQkOtfg(bool P_0, bool P_1, double P_2)
		{
			bool flag = ((!fopcRAyqeBjmZPOELjthAdVYQiB[UQZzLZapifMOUcZmRZfvIQOEUX].hldjmLLhRFbldypJyNprJPlbZSg) ? P_0 : P_1);
			if (fopcRAyqeBjmZPOELjthAdVYQiB[UQZzLZapifMOUcZmRZfvIQOEUX].hldjmLLhRFbldypJyNprJPlbZSg == flag)
			{
				if (ReInput.currentFrame == MiscTools.Tick(emtREvNRkbLQtddbdGleQNpmZLQ))
				{
					oRuBeQrLPSdhWruDFeWRfotAlisi();
				}
			}
			else
			{
				oRuBeQrLPSdhWruDFeWRfotAlisi();
				emtREvNRkbLQtddbdGleQNpmZLQ = ReInput.currentFrame;
				UQZzLZapifMOUcZmRZfvIQOEUX = iCgdwQgJsBAxtoVBcwtmqQKfNIL(UQZzLZapifMOUcZmRZfvIQOEUX, 1);
				fopcRAyqeBjmZPOELjthAdVYQiB[UQZzLZapifMOUcZmRZfvIQOEUX].hldjmLLhRFbldypJyNprJPlbZSg = flag;
				fopcRAyqeBjmZPOELjthAdVYQiB[UQZzLZapifMOUcZmRZfvIQOEUX].YaNikuiCGBjKtibFhmHuzxkYrtMU = P_2;
			}
		}

		public bool EeMlJALivDnMblIcfunCQenlWlE(float P_0)
		{
			return EeMlJALivDnMblIcfunCQenlWlE(fopcRAyqeBjmZPOELjthAdVYQiB, UQZzLZapifMOUcZmRZfvIQOEUX, P_0);
		}

		public bool YKlOXJOWzwbhmdZaioDGEKIEsqz(float P_0)
		{
			return EeMlJALivDnMblIcfunCQenlWlE(sjUdYVuJvIlOBLbHJuomjXrqOX, xocQNZcjVBqvRBkqckdxXdlguyh, P_0);
		}

		private static bool EeMlJALivDnMblIcfunCQenlWlE(UrntrtUfZkzJwtxaQEzlXRDIoyT[] P_0, int P_1, float P_2)
		{
			if (P_2 <= 0f)
			{
				return false;
			}
			if (!P_0[P_1].hldjmLLhRFbldypJyNprJPlbZSg)
			{
				return false;
			}
			int num = ZcNEnETDQujGHkYahBIcpCmuPMI(P_1, 2);
			if (!P_0[num].hldjmLLhRFbldypJyNprJPlbZSg)
			{
				return false;
			}
			if (P_0[P_1].YaNikuiCGBjKtibFhmHuzxkYrtMU - P_0[num].YaNikuiCGBjKtibFhmHuzxkYrtMU <= (double)P_2)
			{
				return true;
			}
			return false;
		}

		private void oRuBeQrLPSdhWruDFeWRfotAlisi()
		{
			if (xocQNZcjVBqvRBkqckdxXdlguyh != UQZzLZapifMOUcZmRZfvIQOEUX)
			{
				xocQNZcjVBqvRBkqckdxXdlguyh = UQZzLZapifMOUcZmRZfvIQOEUX;
			}
			for (int i = 0; i < 3; i++)
			{
				sjUdYVuJvIlOBLbHJuomjXrqOX[i].JYyEPkmZztzXfbEgKghAFieAytO(fopcRAyqeBjmZPOELjthAdVYQiB[i]);
			}
		}

		public void QjNHfjHnCmaQyvCGKbwODraSxUWC()
		{
			UQZzLZapifMOUcZmRZfvIQOEUX = 0;
			xocQNZcjVBqvRBkqckdxXdlguyh = 0;
			for (int i = 0; i < 3; i++)
			{
				fopcRAyqeBjmZPOELjthAdVYQiB[i].QjNHfjHnCmaQyvCGKbwODraSxUWC();
				sjUdYVuJvIlOBLbHJuomjXrqOX[i].QjNHfjHnCmaQyvCGKbwODraSxUWC();
			}
			emtREvNRkbLQtddbdGleQNpmZLQ = 0u;
		}

		public void CZmZbtMncLTjhIRiLRHSACUbiJg(double P_0)
		{
			QTPiZFmnRsxmyQYmMuIoBQkOtfg(false, false, P_0);
		}

		private static int iCgdwQgJsBAxtoVBcwtmqQKfNIL(int P_0, int P_1)
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

		private static int ZcNEnETDQujGHkYahBIcpCmuPMI(int P_0, int P_1)
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
