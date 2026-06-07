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
		public delegate void AyEHIuXPbwUphVNhwhGhUAcUGNOiA(int joystickId, byte rewiredElementType, byte elementIndex, short value);

		public delegate void fIlzjPVaguHcMlLNYqkdfIZyrNrN(int joystickIndex);

		public delegate void rHeHScPKmiZkAoknGGoDjuIoOEIu(int joystickId);

		public delegate void ZZIKeHeQPCevhHmRPUCfbeBJMGIB(int gameControllerId, byte rewiredElementType, byte sdlElementType, short value);

		private const int nftiXYgeASdOKRBGWQzdIAQkWzUL = 32;

		private bool CtMEZkphXiNOkCzBTklJyuCgSbyq;

		private bool LQcaLZhaHvSSXBSShusnYnNsFpxc;

		private bool TFmVQyNrWswmiafLaSnoezFbNgpf;

		private bool YqeezKzcNkFsFGFQFIxGpUWFngxx;

		private bool JXHmFdnLhcxuesiroPjEHpRFQNpw;

		private ADictionary<int, WkcRORaTgzgWYJcUgoIPdBZgPnio> CsRrvyMdtjbHKArLlHnTbSUAmcZlB;

		private ADictionary<int, ikgVYbMyJQEqQznFJQnfRRdmaHIKA> yAYBFkFgnMmbPFrMMmWOWgOCSEro;

		private pfiVsUugztmJNTMeonNWrlREbAxU.oqgBTrCjjOrPfRdSUXrGgRIUPRXU vjvYRapYvMRDXZSDXWFRxRLoanoh;

		private NativeBuffer UbCVIIOKGbZZIDAKuvrfBQQoJCGl;

		[CompilerGenerated]
		private Action CffkkgAQMBQcSkTPjEJlEwrLQcNL;

		private bool yKrknazNPeOxAycVkbZmcRsosrUH;

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

		private int vJlQfSDpgmmwdzGazcFLKEKOszmO()
		{
			return 0;
		}

		private int LfpPzwsThZNPBPmluIzKHcviCmUgb()
		{
			return 0;
		}

		private WkcRORaTgzgWYJcUgoIPdBZgPnio drOtLNxumxaaAizGYZfFGjPfESaI(int P_0)
		{
			return null;
		}

		private ikgVYbMyJQEqQznFJQnfRRdmaHIKA VzVIKCmjeOSEFYxJqUoWZKKQyabU(int P_0)
		{
			return null;
		}

		private xoRSCcZpjBrBJRPfcsgkevXthIaj aCuvWRDDXXDfhKqNqPNXgTsHqYNz(int P_0, FilFqSUIqWxtBOSyIDInvUZkNqLn P_1)
		{
			return null;
		}

		private xoRSCcZpjBrBJRPfcsgkevXthIaj JxZBMjwcqSsFAPruErKipKIrzAiw(int P_0, IIYOVrGNCYqRzdvejKpNuiPOytUS P_1)
		{
			return null;
		}

		private void VksahDAPcstyIooeXTEiHHoYbnxQA()
		{
		}

		private void IkeoBEcaeeCLMedcIfYynCSKFwUP()
		{
		}

		private bool tuAgDrmynAVqpgknaOSfwdJeGIpj(int P_0)
		{
			return false;
		}

		private void GabYGGAiczQdWvoPaicOWWfdphPR(int P_0)
		{
		}

		private bool WaxhkvjdgxNcRElRhmoNMWevwuGKb(int P_0)
		{
			return false;
		}

		private void iGxEqsxTgovnaOIBjuHSDBJwDMWK(int P_0)
		{
		}

		private WkcRORaTgzgWYJcUgoIPdBZgPnio mISGombQtkvzFtXsgTOJuMXpWPYm(int P_0)
		{
			return null;
		}

		private ikgVYbMyJQEqQznFJQnfRRdmaHIKA hShHVydEFfIqXdGSEGVJUyoTCbQPA(int P_0)
		{
			return null;
		}

		private void ukkRPrKbrXAWnaYoLudMuNSlhvHcb()
		{
		}

		private void omgQgSBDlrzmRePkyAgQBgsxyptq(ref pfiVsUugztmJNTMeonNWrlREbAxU.WquskBrUIIVulMGxqRGzpibkyGkp P_0, double P_1)
		{
		}

		private void MxUUBlxhFUyrEmmmCDkMhOsSRqKuA(ref pfiVsUugztmJNTMeonNWrlREbAxU.gulYHbeHhteGZuMOicIeYKruVTmS P_0, double P_1)
		{
		}

		private void wgzczbnLUxStqkFiqSDuLdKUJlHK(ref pfiVsUugztmJNTMeonNWrlREbAxU.pRiyeJyeipfTsMYRwTwaoOAIfTEq P_0, double P_1)
		{
		}

		private void gxBoZPfOYnlrLaonLnsIpFdkEkOj(ref pfiVsUugztmJNTMeonNWrlREbAxU.IdUzDZxiBmeXzbAObYPQWviCDAFP P_0, double P_1)
		{
		}

		private void yXTEFEHeKKVNMDTnIhmBHdWZxTBJA(ref pfiVsUugztmJNTMeonNWrlREbAxU.wekkZzloRgfGhEsQakclflohDrqi P_0)
		{
		}

		private void XEIYqAtASedXPczuUQDpvzYswYdpA(ref pfiVsUugztmJNTMeonNWrlREbAxU.wekkZzloRgfGhEsQakclflohDrqi P_0)
		{
		}

		private void jyWEpWIfwznXmXdeRUbbqmNiNFfGb(ref pfiVsUugztmJNTMeonNWrlREbAxU.WEPqMIgabnMqZUrzuanCtRzPzDJh P_0, double P_1)
		{
		}

		private void SVBjMkcKZdABqGMbPkBSSnOWigMW(ref pfiVsUugztmJNTMeonNWrlREbAxU.dviGnFJvRCCTuhciLFWRHVGxUaqkA P_0, double P_1)
		{
		}

		private void KlJSdbewfPMxUjsbHCvPoZpmaXpt(ref pfiVsUugztmJNTMeonNWrlREbAxU.FymWujodGwaWzSoCIyojMWHFsJQk P_0)
		{
		}

		private void fSTBmqiGtKzotClMivimqmIrvsllA(ref pfiVsUugztmJNTMeonNWrlREbAxU.FymWujodGwaWzSoCIyojMWHFsJQk P_0)
		{
		}

		private void mjWjrjifuoqwknMfAgGGRNwNGpcn(ref pfiVsUugztmJNTMeonNWrlREbAxU.FymWujodGwaWzSoCIyojMWHFsJQk P_0)
		{
		}

		private void kyaBOJDgWjCHlEPAPaNrjUBUMnYBb(int P_0, ZYofOgFzPoVDsUbAwpPkPenPkgzK P_1, byte P_2, short P_3, double P_4)
		{
		}

		private void dGHodKFWfnduLKjaXJsQiONpnfLS(int P_0, ZYofOgFzPoVDsUbAwpPkPenPkgzK P_1, byte P_2, short P_3, double P_4)
		{
		}

		private void VVJIhTyrFGjSVqWQARhiaMDOAmrBA()
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
