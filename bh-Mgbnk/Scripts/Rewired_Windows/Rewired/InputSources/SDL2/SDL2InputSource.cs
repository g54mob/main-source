using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Config;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Data;

namespace Rewired.InputSources.SDL2
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class SDL2InputSource : IInputSource, IDisposable
	{
		public delegate void CWoXUaaXMGhDzIoezeFTMIfPLbmi(int joystickId, byte rewiredElementType, byte elementIndex, short value);

		public delegate void rOLXeBynACMqCsGMVsIZbXMjdRHR(int joystickIndex);

		public delegate void hhKRUksHUGcNObQoNWErfdZlFAcq(int joystickId);

		public delegate void PMtQDyiFkjXmxWHrCsmytlrGgCyU(int gameControllerId, byte rewiredElementType, byte sdlElementType, short value);

		private const int fsVWjWHwgerIUIGTTSBNEVBlMtis = 32;

		private bool UVgEJiAAzOGyeXvUEPongOTdxZYE;

		private bool JyKjnHKcUPkGFMLHcbQRQzcpoRJw;

		private bool LOYkYseyJIcaohVszckYihsuPDPI;

		private bool UyOcnWKBzKRmTTLLSBUcxOVEyaRk;

		private bool JWpCnlGXQuiiglcpUFqGNCcCZFaB;

		private ADictionary<int, EDMLXIVQZTAQYUVDbcrQxMhxfKoB> UlaSaxABBLrMgcCwDVhKrJpnszV;

		private ADictionary<int, ihGbBntUbqdcAoUSKlRNVQklGFas> wqoUUcmkVmFhDWZXXCmqOaVXLYLs;

		private xsGdtKZhJXFPDSHnlpbcrhALFUHz.ghOtUnnOVgZVtCJDZPHwgBBZQNpp dITXHaYsZigHVQTWGyyhjfEphqEjA;

		private NativeBuffer ItoHYQvtoFvNMWOTxTDBXlVnaTiu;

		[CompilerGenerated]
		private Action OtRdlyGrejVMMexGaQoTOCoElYhEA;

		private bool mGBhtiCSbWgKEuxAhpPAUwnfNssZ;

		public bool initialized => false;

		private event Action _DeviceChangedEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
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

		public SDL2InputSource(UpdateLoopSetting P_0, bool P_1, bool P_2, bool P_3, bool P_4)
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

		private int xeBmIMqKCKmbMsdJczpKEVyRrONB()
		{
			return 0;
		}

		private int XpDaoeVZelJdDQqlpNIcayGlcyeC()
		{
			return 0;
		}

		private EDMLXIVQZTAQYUVDbcrQxMhxfKoB pxeJeLETSVemYdvmROtdYOCgrGCV(int P_0)
		{
			return null;
		}

		private ihGbBntUbqdcAoUSKlRNVQklGFas ZpzJPSTGsoGODHQifMakZIBJoEBm(int P_0)
		{
			return null;
		}

		private fDbJJcHmDfGbNBOeIdCSAuIdujaMC qVUJsVmzlttSvbBCdppbRblKdEdw(int P_0, JmHvsErHQuhKVTMnRwHHtbIrekxV P_1)
		{
			return null;
		}

		private fDbJJcHmDfGbNBOeIdCSAuIdujaMC JursDvPaAsQTSIXxXHoQvhXgHGAQ(int P_0, SfqSKfhkaqBmtqnOcTSpiYXLhsQc P_1)
		{
			return null;
		}

		private void XMWitRinKWeeWlSbOuXOLubPxiPj()
		{
		}

		private void UeGIlCJGOQZCSrfvVzuCjDRFboqkA()
		{
		}

		private bool nWsBzdiDTgOFdJdytWyVIeEvNWXQA(int P_0)
		{
			return false;
		}

		private void OxNDOAhYSXrsKexQlGogImmqfell(int P_0)
		{
		}

		private bool OrXdZlQfQFwPRmfSpQavEwzrgwoj(int P_0)
		{
			return false;
		}

		private void ooVKFsMLpMvtiLlZqfYqVhEtMVeV(int P_0)
		{
		}

		private EDMLXIVQZTAQYUVDbcrQxMhxfKoB eFsfIaACPQtWZqtlfeqnkxSkVnwl(int P_0)
		{
			return null;
		}

		private ihGbBntUbqdcAoUSKlRNVQklGFas ncLYiqIhpFqGZZoFZhTxoFbSfpei(int P_0)
		{
			return null;
		}

		private void cDYMpqbTWnWnEXpfEZGaNLYorPjd()
		{
		}

		private void cANrMyTTFRyDnKlvCSyZmrggtTT(ref xsGdtKZhJXFPDSHnlpbcrhALFUHz.IASedDQOgiagncXczGoBLnyhrYYhA P_0, double P_1)
		{
		}

		private void KAuSUzYEbkgfQpEzLGAoFCnPKoicA(ref xsGdtKZhJXFPDSHnlpbcrhALFUHz.uXLyHtVHPDGALbGFzlkICwazKZMk P_0, double P_1)
		{
		}

		private void uHNIztQvzHRGspYQbigSFGHNnRzQ(ref xsGdtKZhJXFPDSHnlpbcrhALFUHz.nzGyjPBmYBnNeTsGreQIIaXBzTuSA P_0, double P_1)
		{
		}

		private void eUnBfTCMgTllDFjcIZDqdzavbMyoA(ref xsGdtKZhJXFPDSHnlpbcrhALFUHz.SNwaWHYHtISJnyHPiBxeEOtVzCjiA P_0, double P_1)
		{
		}

		private void mTxKXCHcgoTAOSSkREVnfWLOVCxL(ref xsGdtKZhJXFPDSHnlpbcrhALFUHz.iMAejbCYbSUdfDHTngMVarlEkRCuB P_0)
		{
		}

		private void FmcAhMQzkClFJghdLutLpMZpfGVw(ref xsGdtKZhJXFPDSHnlpbcrhALFUHz.iMAejbCYbSUdfDHTngMVarlEkRCuB P_0)
		{
		}

		private void tSyoZYQHATHrgiHxQHaDuQOfFDDI(ref xsGdtKZhJXFPDSHnlpbcrhALFUHz.QjdGbKHiVHuUFZxwzgWytHmIKvln P_0, double P_1)
		{
		}

		private void EstZowPptZPqmTkiKdjyOPELmdmg(ref xsGdtKZhJXFPDSHnlpbcrhALFUHz.fZGamDuftoNKuylVYsjSBHEwkGED P_0, double P_1)
		{
		}

		private void QMncufPDZrDjAsWwWBDbgksbtBDZ(ref xsGdtKZhJXFPDSHnlpbcrhALFUHz.JqEfZzXdeWctlHiBLdQDABCElyyU P_0)
		{
		}

		private void rYbtDcfXXicVzmMFnWgAwNReawBj(ref xsGdtKZhJXFPDSHnlpbcrhALFUHz.JqEfZzXdeWctlHiBLdQDABCElyyU P_0)
		{
		}

		private void qfumXpXOOCqbcqwIDoBaJBpUnlQh(ref xsGdtKZhJXFPDSHnlpbcrhALFUHz.JqEfZzXdeWctlHiBLdQDABCElyyU P_0)
		{
		}

		private void qZOwIHiAwNuVzZVZEJbNCxGJDxcU(int P_0, JVAggskIXCHscZhHndFCJHiGmoHQ P_1, byte P_2, short P_3, double P_4)
		{
		}

		private void roheWNsPaVdFnZxhYCuYmYMmxzPB(int P_0, JVAggskIXCHscZhHndFCJHiGmoHQ P_1, byte P_2, short P_3, double P_4)
		{
		}

		private void HsfeOXJvMqUAXhVgDZhOaKMLuTPJ()
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
