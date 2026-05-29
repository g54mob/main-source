using System;
using System.Collections.Generic;
using Rewired.Config;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Data;

namespace Rewired.InputSources.SDL2
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal class SDL2InputSource : IDisposable, IInputSource
	{
		public delegate void VULDneOsuWDCbgCFLMgVsLatWCJb(int joystickId, byte rewiredElementType, byte elementIndex, short value);

		public delegate void agidOXEMtStTMiIrrZWDyRBTlGq(int joystickIndex);

		public delegate void wKhIzuKwnUBTSdKLbNSpelOZUPR(int joystickId);

		public delegate void YEIvDcIXlfXhrQGWyuSgoiygXTX(int gameControllerId, byte rewiredElementType, byte sdlElementType, short value);

		private const int UCdfazQPuafuwLiayeEnamaFtH = 32;

		private bool QUchpVanBlxNCZBQmOQpHHAotkN;

		private bool RPekqPaxgtgakAGiDVjneCfBRjS;

		private bool uVeiynACHwcuryGcEbVFZQtesoQ;

		private bool BANdYlThwJqHilRYnCIzTxUYuln;

		private bool aLzbAjHdyinuPAkYilYZkIGyBOc;

		private ADictionary<int, VnzKtXrttPTnSAOeJckfbkRFQchv> lvnwmFJpksIrMbnCgHpzlXRbJYf;

		private ADictionary<int, hobZtlBFOaHZYiPpucPVjGtJDENx> FVPgYVaRUNDrXwldgKoGlSLpKGmR;

		private sCxBXOpgyRXqNIHOTIzoipLtiRcc.hJNAwCFCIvainhhXlfPtBcCAiav iuGggmGgSCdIBnNGlVQYBlffAMx;

		private NativeBuffer LWMSUPSUwkIgwDwJZjDubHZDGaDi;

		private Action XUhsVNVqkOUxAyVmqHRcPnUfwzh;

		private bool CGIHxiLUHgNfmOBOdViTruIZZWF;

		public bool initialized => false;

		private event Action _DeviceChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action DeviceChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public SDL2InputSource(UpdateLoopSetting updateLoop, bool handleJoysticks, bool handleGamepads, bool handleUnifiedMouse, bool handleUnifiedKeyboard)
		{
		}

		public void SystemDeviceConnected()
		{
		}

		public void SystemDeviceDisconnected()
		{
		}

		public void Update()
		{
		}

		public void UpdateDevices(UpdateLoopType updateLoop)
		{
		}

		public void UpdateFinished()
		{
		}

		public IList<T> GetJoysticks<T>() where T : class
		{
			return null;
		}

		private int PKgGImCNTXYVbPLOMTUlVFeIymT()
		{
			return 0;
		}

		private int JJFcRItauJXlYSBUTdjEKZQyDKKp()
		{
			return 0;
		}

		private VnzKtXrttPTnSAOeJckfbkRFQchv emihmleJLKWugNeYlZxeiehhbDZ(int P_0)
		{
			return null;
		}

		private hobZtlBFOaHZYiPpucPVjGtJDENx ISBfmFurPZbNrFZOeOCGQGmdMvG(int P_0)
		{
			return null;
		}

		private cRWvgmOoylMLZSViVCdYvdXKuSj lNgaeSsfOGzaKrQyTSDfyMolbeuh(int P_0, EFojXEJzjuCAVZCCracFHuNNPxUg P_1)
		{
			return null;
		}

		private cRWvgmOoylMLZSViVCdYvdXKuSj nJRTdqgylgBtxIOiyerkjVLLQRQ(int P_0, DMBqafNSZuiqzyxCWLQzlENzeQF P_1)
		{
			return null;
		}

		private void bEKKCubomuuaKVIxArrSoqjXYuY()
		{
		}

		private void DsRPLXnVAOokaVPLcFhDLwXUxUt()
		{
		}

		private bool uysMeaKOElexgGkiBmdTJAOXRALk(int P_0)
		{
			return false;
		}

		private void UbZncdaKBSwGhHnisUMEXsvGttN(int P_0)
		{
		}

		private bool wasiheHKmFUekANhnoKOJWitRdY(int P_0)
		{
			return false;
		}

		private void SvGEcGGPZyrPiiuxOsCsnXBysWB(int P_0)
		{
		}

		private VnzKtXrttPTnSAOeJckfbkRFQchv dvZEXiKdEBTyUHvnLjKYOZhPjvf(int P_0)
		{
			return null;
		}

		private hobZtlBFOaHZYiPpucPVjGtJDENx dBkYcNTjopuWdxQBAiAHlUlsASl(int P_0)
		{
			return null;
		}

		private void mzlkOfWlWdsBbKlfEjhmfgUakeGC()
		{
		}

		private void SOFuIdjRcdCPPfzNciPmjzKLImLA(ref sCxBXOpgyRXqNIHOTIzoipLtiRcc.JFOlJhoFIoTCvEZINgAeFmVpTAT P_0, double P_1)
		{
		}

		private void UbyiCLaSPHDEzlobrhMVUZHfSRy(ref sCxBXOpgyRXqNIHOTIzoipLtiRcc.SogLjMHLpNwdOLJvTRpHbfmWbuLb P_0, double P_1)
		{
		}

		private void hNgGDQIWuXWWjjSOdZKwCgWHgxGX(ref sCxBXOpgyRXqNIHOTIzoipLtiRcc.ibYDGDeHcwYmJWnqnnkcxNYXySei P_0, double P_1)
		{
		}

		private void tGvUhgJecGQShcfazShRgZbIUKn(ref sCxBXOpgyRXqNIHOTIzoipLtiRcc.tGjkNGQdZcfhHHFcqKDBMkNXlEp P_0, double P_1)
		{
		}

		private void fqfkYQPOomERoAxHxbQDUevOdEy(ref sCxBXOpgyRXqNIHOTIzoipLtiRcc.UdoFChkvvIyAdeQgmjterDdcmaBR P_0)
		{
		}

		private void tpjMOgHnaMpVTTMvuUedhuzPkIg(ref sCxBXOpgyRXqNIHOTIzoipLtiRcc.UdoFChkvvIyAdeQgmjterDdcmaBR P_0)
		{
		}

		private void SdWwSyYjzXPYxWnjJkUduESZLqV(ref sCxBXOpgyRXqNIHOTIzoipLtiRcc.ZOOsftwpTVbESMGrKBFgKBlweKs P_0, double P_1)
		{
		}

		private void jCvKJxPgWjgDzCjFoncICdShdFuF(ref sCxBXOpgyRXqNIHOTIzoipLtiRcc.nqpHpWncNPHuREuxzMXDzKfuIYpE P_0, double P_1)
		{
		}

		private void YoEaihCgkKlrpDjUiiGnvRHEBKDz(ref sCxBXOpgyRXqNIHOTIzoipLtiRcc.zFPHZVRJatgFxrRGWVFMZMUwXyw P_0)
		{
		}

		private void ildxUmvhlyhqlxcVreEAbxKRUDF(ref sCxBXOpgyRXqNIHOTIzoipLtiRcc.zFPHZVRJatgFxrRGWVFMZMUwXyw P_0)
		{
		}

		private void LxCIOHEfwzKnGAyRKxhBbOOFuui(ref sCxBXOpgyRXqNIHOTIzoipLtiRcc.zFPHZVRJatgFxrRGWVFMZMUwXyw P_0)
		{
		}

		private void GgzBdCKHeFkiiNRdAiaNYfLiKPrB(int P_0, CWdIVsKjqOcvuTmmTDPEMYherbo P_1, byte P_2, short P_3, double P_4)
		{
		}

		private void PAXivZEiwgIGIHAzznUKPoEiBzSe(int P_0, CWdIVsKjqOcvuTmmTDPEMYherbo P_1, byte P_2, short P_3, double P_4)
		{
		}

		private void hChveuLRLEBfkFEvVNDqKCJUuox()
		{
		}

		public void Dispose()
		{
		}

		~SDL2InputSource()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}
	}
}
