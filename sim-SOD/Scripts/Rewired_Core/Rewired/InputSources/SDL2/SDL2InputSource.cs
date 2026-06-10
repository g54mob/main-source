using System;
using System.Collections.Generic;
using Rewired.Config;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Data;

namespace Rewired.InputSources.SDL2
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class SDL2InputSource : IDisposable, IInputSource
	{
		public delegate void WAqEPTkKMqXLdQlRNEVjezFELWJJ(int joystickId, byte rewiredElementType, byte elementIndex, short value);

		public delegate void tnNGuiuuDgPMGyXltWldMEeaaAgg(int joystickIndex);

		public delegate void ddWTkLoEDykYYpSNvupDGWjcSHT(int joystickId);

		public delegate void TQtcZZyTvNAUdCUMkmBYjALdRBNn(int gameControllerId, byte rewiredElementType, byte sdlElementType, short value);

		private const int HqdfZVFFvEepoVqcqUZyKLFBqvBa = 32;

		private bool HDJNVwIBlNemQDRSqmzXFfleDxRV;

		private bool AiNWheSfYJahoAPcHrWPOeYymbO;

		private bool fsHpMKkPrCgzhiNqIZEpxxKVHmC;

		private bool OHgheWfmObMMojdOxVzLzRphstr;

		private bool fjUzJMvfKUtkXCOEoCUtEkxLMZg;

		private ADictionary<int, WsEZbqZDFtbgYMAcPzJXWIsoQcz> kXAWKabWpEyGChQDeArZBazUSzE;

		private ADictionary<int, wCCDsMxojAYSGkzusuutaAqgUGF> AsSqsfKmpCoBlEliGZcsJkAXSu;

		private nREhqrHWTjduVGKGXONUAorKFqg.KkZqtgyqFgbUiQuKMjetFRMTdRmY pelvKRkIgaMyDlxKlIaqbzGOoCt;

		private NativeBuffer MZfySmogQMhngNMJDuRWZJygkRX;

		private Action ALWhZkhcGawnCyOsqeoAfJhCtBr;

		private bool PrvylHtjoIHWmYgGfZyfZonoJFJ;

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

		private int IDHdsBgjjhfYhgZYEvvDtfFjLaVs()
		{
			return 0;
		}

		private int EdyFfvFfCngoIkEKFwOmTnhBaAIz()
		{
			return 0;
		}

		private WsEZbqZDFtbgYMAcPzJXWIsoQcz jIPuHSGMrmEVgLLStKmKCJIIWlJ(int P_0)
		{
			return null;
		}

		private wCCDsMxojAYSGkzusuutaAqgUGF ZbopNiWtdvqulHkMuxlekgRKNCK(int P_0)
		{
			return null;
		}

		private hahOPTmeKZTDDEzZDmdeZiyrpop giDIQhMawoCtAavcPooFKOFMxiiK(int P_0, RlZahpfQPSSHXRNYdgLrFUoeqxAF P_1)
		{
			return null;
		}

		private hahOPTmeKZTDDEzZDmdeZiyrpop sEgLlXEoZIJSpYJicjRAVQmiuES(int P_0, OdcAbWnmrObmjgMYWaMHVwsUmcX P_1)
		{
			return null;
		}

		private void wJreWPDyIInYYPdzYCQeGgUemeS()
		{
		}

		private void WVoxZuLHuolCiRXHsEinxdehvLb()
		{
		}

		private bool fPHYmBaNcFunkqawNIexiGpaEYF(int P_0)
		{
			return false;
		}

		private void NAofTXiCesllplLnopdwWzBxJpNn(int P_0)
		{
		}

		private bool ftDBWXhfGfczkKsbrJxshlPWuzQ(int P_0)
		{
			return false;
		}

		private void VrhNuliRfYLsymenANHYBAcBQuB(int P_0)
		{
		}

		private WsEZbqZDFtbgYMAcPzJXWIsoQcz ubcDhVgHwrntEPmvDCvocWAsGzx(int P_0)
		{
			return null;
		}

		private wCCDsMxojAYSGkzusuutaAqgUGF oeZQVkvKvFZolpJmUjvnDQXFQVt(int P_0)
		{
			return null;
		}

		private void jRYmFWcFqDYWvMVjOYgOMvrFqYC()
		{
		}

		private void LsmwLEVeQRINFlIZoCcURgfkguNC(ref nREhqrHWTjduVGKGXONUAorKFqg.BGjgUzdcwWbNIkMCJjrkxfiDhOOZ P_0, double P_1)
		{
		}

		private void VGDaiyWKzbXmlzXxlxnriKqQFEo(ref nREhqrHWTjduVGKGXONUAorKFqg.TrqTFFqOTQZnbOTqwrRNWIrwCBn P_0, double P_1)
		{
		}

		private void yHhrEoGxnVtiMKxpzGZUbmxbCd(ref nREhqrHWTjduVGKGXONUAorKFqg.nluaXjCoSwezAEdpnmjnHJbZdXh P_0, double P_1)
		{
		}

		private void qQOwcLrGGuqNdiIahOhzUmSjUwn(ref nREhqrHWTjduVGKGXONUAorKFqg.GfvISkWHDnfrQEkiwZjCscTJPmP P_0, double P_1)
		{
		}

		private void wlSMCtxdSEVVqKNBvqCjqhKzzIk(ref nREhqrHWTjduVGKGXONUAorKFqg.PIMPETmqSRqGBDvgegEuuPfoFFY P_0)
		{
		}

		private void iuAuVDvlUsOwJPWtqVqJXsIyUAq(ref nREhqrHWTjduVGKGXONUAorKFqg.PIMPETmqSRqGBDvgegEuuPfoFFY P_0)
		{
		}

		private void LLnOIDyNNxnKlQJhJqDPSvvwOPX(ref nREhqrHWTjduVGKGXONUAorKFqg.xtLteHjxDCPCUOrMudqMnzgpCsM P_0, double P_1)
		{
		}

		private void eiGxXSdEkXbYrvCXmBkcRdvYgLg(ref nREhqrHWTjduVGKGXONUAorKFqg.slkQdfrSCwhNYBIfgOhVqdGLwQyi P_0, double P_1)
		{
		}

		private void HqnOGOSGtgidrxSfknGNjewqUJZ(ref nREhqrHWTjduVGKGXONUAorKFqg.lxFeTJgiBoBQtFLbHfkyhQDGkjuh P_0)
		{
		}

		private void vVSyFTRHNQgsxjvcleFoFcKkwOH(ref nREhqrHWTjduVGKGXONUAorKFqg.lxFeTJgiBoBQtFLbHfkyhQDGkjuh P_0)
		{
		}

		private void UpjumyeZIXqzYAnZIWwxJAxsqXs(ref nREhqrHWTjduVGKGXONUAorKFqg.lxFeTJgiBoBQtFLbHfkyhQDGkjuh P_0)
		{
		}

		private void THEVfrbYZjnbeJhaKZNbPipBXcz(int P_0, HtAToTukCybhcEDwPYmoGkQJUhmF P_1, byte P_2, short P_3, double P_4)
		{
		}

		private void YTgTWqgeOYEBQXHhfKzkbBzHWjY(int P_0, HtAToTukCybhcEDwPYmoGkQJUhmF P_1, byte P_2, short P_3, double P_4)
		{
		}

		private void mSCOEPdcdskLoBCtHKgCgTqbKgn()
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
