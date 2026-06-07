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
		public delegate void HiELdtRJevQqQMInnDogACbawdtw(int joystickId, byte rewiredElementType, byte elementIndex, short value);

		public delegate void mpfOnMPuhfdsbqbLDAdupxUEbdQK(int joystickIndex);

		public delegate void kBySrfZQjvdlnxthBeAOFvPUWsnuA(int joystickId);

		public delegate void KsVvgvFcBSzxQQhgEkhTxxrxiutG(int gameControllerId, byte rewiredElementType, byte sdlElementType, short value);

		private const int gmhXYZijZHTNnSsMBLFcQBRGfXlp = 32;

		private bool FdSrwjhYUxGNPLwFGjLImwPMGTZp;

		private bool OzoHKIxzZgPwwIOQyGwtKidEpGub;

		private bool KpailLLgtlnJbxrLrophuiuRjYDc;

		private bool FKwRENhlIjEYuDPMITZRhJNxcMWs;

		private bool GQZJgeruepOtRrLndONJBPOfvpET;

		private ADictionary<int, RqqerSecdiLVzGFItpiYfyIKmHPR> ZxLESxIUqaUGjyPXqNPEIEJOFWsN;

		private ADictionary<int, xcsIvsCICDKljseXUXHqAPgIWjrDA> tQEyDpDpmFatgORMVaiLEJxykAQf;

		private gNwgXNfwkgBAmCIyDfxVqpQqagKQB.jwsmEuWRqDIvQSFELDsDoKLirKal yBftRdzEoLHAaKbFQOgAboYOZEXm;

		private NativeBuffer PiYsVmYVBuMalQCCrXNwRZZIzgjD;

		[CompilerGenerated]
		private Action HMzCDzIgJAJBzhtTsnuwBYkfpaaXB;

		private bool jvnBZbtIOtjTnbnLdvRfinpSIAxkA;

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

		private int wPrfYTDWlpnSEowaytIWKHJcZmVJ()
		{
			return 0;
		}

		private int QolIExsmgKHOcKOnrDRDMqcGNWzqA()
		{
			return 0;
		}

		private RqqerSecdiLVzGFItpiYfyIKmHPR kXUMMYlfwilbcprNTrIdWEPXeZLB(int P_0)
		{
			return null;
		}

		private xcsIvsCICDKljseXUXHqAPgIWjrDA UITprZyMdJLHoPSXfTCRZPHsbSSv(int P_0)
		{
			return null;
		}

		private qiLBbtDpeAJwgbUvjLKdUcIRTNTBA fuigpKhZSYIgKklXvAdUNZrzgqsCA(int P_0, QSvnTVApnJdsqAFiNAcaazWCfYqYA P_1)
		{
			return null;
		}

		private qiLBbtDpeAJwgbUvjLKdUcIRTNTBA YMDxqsqlzXUzlEKcLiszlOLBwEPJ(int P_0, RzGjwoAHZVSSUmXawjDIoKCebRzW P_1)
		{
			return null;
		}

		private void ETswKQHmlvdfpvgwEuobPelgvLYx()
		{
		}

		private void VSeDiJsltjPntpmSPqnjvVumSPrD()
		{
		}

		private bool oLAPxmwemBgWMpbllXaiwaCGLoSp(int P_0)
		{
			return false;
		}

		private void BkjAhVBErgPanlsHpSOVoSiVlLyaA(int P_0)
		{
		}

		private bool DPjWHadpviYlqywFttMUGYjYBQfq(int P_0)
		{
			return false;
		}

		private void rpfztTrMFpsXjVCicUNoHMmAnfic(int P_0)
		{
		}

		private RqqerSecdiLVzGFItpiYfyIKmHPR pAEuVrrkuxCyegciztaUswQBBfrdA(int P_0)
		{
			return null;
		}

		private xcsIvsCICDKljseXUXHqAPgIWjrDA aJhLovnKCsBpgCHQJLrUAefxhNzKA(int P_0)
		{
			return null;
		}

		private void tqsDioCSoMUXMJvuETwTBGPNJtuJ()
		{
		}

		private void bckHBRTUiwrlmlronOVXNwrXTTQF(ref gNwgXNfwkgBAmCIyDfxVqpQqagKQB.ZisGLMhbXPUtApBplpisrUcMcmJAA P_0, double P_1)
		{
		}

		private void NGYBawJrYXzkhWnuXAATOAvuAAlfb(ref gNwgXNfwkgBAmCIyDfxVqpQqagKQB.hCpxCywYecZGonXUfyGbANsYdiTi P_0, double P_1)
		{
		}

		private void xWzNfyjUgcBhBzJwhgLjFPtixwee(ref gNwgXNfwkgBAmCIyDfxVqpQqagKQB.yAsHcMsypmOSTJAPdKIroZNkzrbg P_0, double P_1)
		{
		}

		private void xNHVVOzjBmCekvsnELDLxOiQLgpu(ref gNwgXNfwkgBAmCIyDfxVqpQqagKQB.BUKZaAbrWbGUYgcCoxhZWujqVswq P_0, double P_1)
		{
		}

		private void fnJxaNqtNNOQbUkpRhGCzAPrMxiS(ref gNwgXNfwkgBAmCIyDfxVqpQqagKQB.rosJJshGQpJqQZeQvnAolIfVwtHX P_0)
		{
		}

		private void UYQAVVgnVrJYybqmPofiXtNUicCyA(ref gNwgXNfwkgBAmCIyDfxVqpQqagKQB.rosJJshGQpJqQZeQvnAolIfVwtHX P_0)
		{
		}

		private void goGWSDdMfgzALoacAMRqeHQSTzKu(ref gNwgXNfwkgBAmCIyDfxVqpQqagKQB.DXdPTCkoeSJudVppBSLVtkhLXoEb P_0, double P_1)
		{
		}

		private void TnZphhmQUofYXHXhMljZObFuhMht(ref gNwgXNfwkgBAmCIyDfxVqpQqagKQB.qmaMGCFMSJKQVaAgYeqKaBRXqMDGA P_0, double P_1)
		{
		}

		private void PSDeCmhucMSwzoXvEvXQqmeOpvEW(ref gNwgXNfwkgBAmCIyDfxVqpQqagKQB.CemnoosLbxrOrDQPtSccGQJfIzlb P_0)
		{
		}

		private void cLNxJzQwuHStCqHUvkIlcJPVNOYQ(ref gNwgXNfwkgBAmCIyDfxVqpQqagKQB.CemnoosLbxrOrDQPtSccGQJfIzlb P_0)
		{
		}

		private void pqKmOmczbtBzVwhtPEkVLijxEFRCA(ref gNwgXNfwkgBAmCIyDfxVqpQqagKQB.CemnoosLbxrOrDQPtSccGQJfIzlb P_0)
		{
		}

		private void noasUIFlVoCeEFEGSfdwELEgIBzO(int P_0, GPmEhfBeYjIkZBEMrLdxRwAtGCQD P_1, byte P_2, short P_3, double P_4)
		{
		}

		private void iMHkWJVqgeGuqBCcAvYFeEETOHmn(int P_0, GPmEhfBeYjIkZBEMrLdxRwAtGCQD P_1, byte P_2, short P_3, double P_4)
		{
		}

		private void QnNPMWqNCHBRybTCNSLfiPOuErEL()
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
