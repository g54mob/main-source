using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal sealed class ChYhaBSijJnTpdXwQSqYJssvGND : IDisposable
{
	public enum ZyZRbCnIBTbNHvCqDENOiYHQYPDr
	{
		WbhPDGhsQhtuoeuemyINPoTnEvK = 0,
		dBmuEUmBrzqrPzCZlujyBJFlBlqD = 1
	}

	private class eLdjcNWnzlUUdzfBtBbgCpokXPDR
	{
		public ADictionary<int, InputBehavior> JIrXlwvAsrFbMRDIqaqVCXOEeRm;

		public List<InputBehavior> nwteNHcRpGsgfiGZzjfvOCLUadGv;

		public IList<InputBehavior> gbaOPDJUNrQFoVnHayGjnkPoiHu;

		public eLdjcNWnzlUUdzfBtBbgCpokXPDR(List<InputBehavior> behaviors)
		{
			nwteNHcRpGsgfiGZzjfvOCLUadGv = new List<InputBehavior>(behaviors.Count);
			JIrXlwvAsrFbMRDIqaqVCXOEeRm = new ADictionary<int, InputBehavior>();
			int num = 0;
			for (int i = 0; i < behaviors.Count; i++)
			{
				InputBehavior inputBehavior = behaviors[i].Clone();
				JIrXlwvAsrFbMRDIqaqVCXOEeRm.Add(behaviors[i].id, inputBehavior);
				nwteNHcRpGsgfiGZzjfvOCLUadGv.Add(inputBehavior);
				num++;
			}
			gbaOPDJUNrQFoVnHayGjnkPoiHu = new ReadOnlyCollection<InputBehavior>(nwteNHcRpGsgfiGZzjfvOCLUadGv);
		}

		public InputBehavior IrKXInWReiueMYDtLnljczPLpxC(int P_0)
		{
			if (nwteNHcRpGsgfiGZzjfvOCLUadGv.Count == 0)
			{
				return null;
			}
			JIrXlwvAsrFbMRDIqaqVCXOEeRm.TryGetValue(P_0, out var value);
			if (value == null)
			{
				return nwteNHcRpGsgfiGZzjfvOCLUadGv[0];
			}
			return value;
		}
	}

	private sealed class HmFcZIlVxjuvmkSQUqxrCPOCUnx : IDisposable, IEnumerator, IEnumerable, IEnumerable<CustomController>, IEnumerator<CustomController>
	{
		private CustomController ajbaQItphrIyqhowgmMTfPkCBvcN;

		private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

		private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

		public ChYhaBSijJnTpdXwQSqYJssvGND kdBZqupjvsCsVkwJiOeEQzkEDVO;

		public int XtaXNzORPRTxqoJxEClWcGibfrN;

		public int QXwgXVMZTbHAlLsSUQmthjCOfioj;

		public int sUxiSHKLpKzEJxADhxNiTOfGaFzA;

		public int MKtfUfOrPwqaxcTZkMuwxjFLVMS;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return ajbaQItphrIyqhowgmMTfPkCBvcN;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return ajbaQItphrIyqhowgmMTfPkCBvcN;
			}
		}

		[DebuggerHidden]
		IEnumerator<CustomController> IEnumerable<CustomController>.GetEnumerator()
		{
			HmFcZIlVxjuvmkSQUqxrCPOCUnx hmFcZIlVxjuvmkSQUqxrCPOCUnx;
			if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
				hmFcZIlVxjuvmkSQUqxrCPOCUnx = this;
			}
			else
			{
				hmFcZIlVxjuvmkSQUqxrCPOCUnx = new HmFcZIlVxjuvmkSQUqxrCPOCUnx(0);
				hmFcZIlVxjuvmkSQUqxrCPOCUnx.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
			}
			hmFcZIlVxjuvmkSQUqxrCPOCUnx.XtaXNzORPRTxqoJxEClWcGibfrN = QXwgXVMZTbHAlLsSUQmthjCOfioj;
			return hmFcZIlVxjuvmkSQUqxrCPOCUnx;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}

		private bool MoveNext()
		{
			switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
			{
			case 0:
				uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
				sUxiSHKLpKzEJxADhxNiTOfGaFzA = kdBZqupjvsCsVkwJiOeEQzkEDVO.YLsaCuedneTuoHaKQfuOqsFrGYI.Count;
				MKtfUfOrPwqaxcTZkMuwxjFLVMS = 0;
				goto IL_009d;
			case 1:
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
					goto IL_008f;
				}
				IL_009d:
				if (MKtfUfOrPwqaxcTZkMuwxjFLVMS >= sUxiSHKLpKzEJxADhxNiTOfGaFzA)
				{
					break;
				}
				if (kdBZqupjvsCsVkwJiOeEQzkEDVO.YLsaCuedneTuoHaKQfuOqsFrGYI[MKtfUfOrPwqaxcTZkMuwxjFLVMS].sourceControllerId == XtaXNzORPRTxqoJxEClWcGibfrN)
				{
					ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.YLsaCuedneTuoHaKQfuOqsFrGYI[MKtfUfOrPwqaxcTZkMuwxjFLVMS];
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
					return true;
				}
				goto IL_008f;
				IL_008f:
				MKtfUfOrPwqaxcTZkMuwxjFLVMS++;
				goto IL_009d;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		void IDisposable.Dispose()
		{
		}

		[DebuggerHidden]
		public HmFcZIlVxjuvmkSQUqxrCPOCUnx(int _003C_003E1__state)
		{
			uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
			LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
		}
	}

	private sealed class McnQohzIonFvDFDSqhGdjJlGcsqH : IDisposable, IEnumerator, IEnumerable, IEnumerable<CustomController>, IEnumerator<CustomController>
	{
		private CustomController ajbaQItphrIyqhowgmMTfPkCBvcN;

		private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

		private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

		public ChYhaBSijJnTpdXwQSqYJssvGND kdBZqupjvsCsVkwJiOeEQzkEDVO;

		public string TiGkGVqxuceQNvPSLIihRfkPdJqa;

		public string mufPbKpVOBEtofbeNAVPePuPBCK;

		public int SDIfiCFRjMnIYFqYpwJWwaSjGuH;

		public int xtAOPmDcqacZxCSjIyFHhsqWbTqW;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return ajbaQItphrIyqhowgmMTfPkCBvcN;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return ajbaQItphrIyqhowgmMTfPkCBvcN;
			}
		}

		[DebuggerHidden]
		IEnumerator<CustomController> IEnumerable<CustomController>.GetEnumerator()
		{
			McnQohzIonFvDFDSqhGdjJlGcsqH mcnQohzIonFvDFDSqhGdjJlGcsqH;
			if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
				mcnQohzIonFvDFDSqhGdjJlGcsqH = this;
			}
			else
			{
				mcnQohzIonFvDFDSqhGdjJlGcsqH = new McnQohzIonFvDFDSqhGdjJlGcsqH(0);
				mcnQohzIonFvDFDSqhGdjJlGcsqH.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
			}
			mcnQohzIonFvDFDSqhGdjJlGcsqH.TiGkGVqxuceQNvPSLIihRfkPdJqa = mufPbKpVOBEtofbeNAVPePuPBCK;
			return mcnQohzIonFvDFDSqhGdjJlGcsqH;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}

		private bool MoveNext()
		{
			switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
			{
			case 0:
				uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
				SDIfiCFRjMnIYFqYpwJWwaSjGuH = kdBZqupjvsCsVkwJiOeEQzkEDVO.YLsaCuedneTuoHaKQfuOqsFrGYI.Count;
				xtAOPmDcqacZxCSjIyFHhsqWbTqW = 0;
				goto IL_00a3;
			case 1:
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
					goto IL_0095;
				}
				IL_00a3:
				if (xtAOPmDcqacZxCSjIyFHhsqWbTqW >= SDIfiCFRjMnIYFqYpwJWwaSjGuH)
				{
					break;
				}
				if (kdBZqupjvsCsVkwJiOeEQzkEDVO.YLsaCuedneTuoHaKQfuOqsFrGYI[xtAOPmDcqacZxCSjIyFHhsqWbTqW].tag.Equals(TiGkGVqxuceQNvPSLIihRfkPdJqa, StringComparison.OrdinalIgnoreCase))
				{
					ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.YLsaCuedneTuoHaKQfuOqsFrGYI[xtAOPmDcqacZxCSjIyFHhsqWbTqW];
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
					return true;
				}
				goto IL_0095;
				IL_0095:
				xtAOPmDcqacZxCSjIyFHhsqWbTqW++;
				goto IL_00a3;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		void IDisposable.Dispose()
		{
		}

		[DebuggerHidden]
		public McnQohzIonFvDFDSqhGdjJlGcsqH(int _003C_003E1__state)
		{
			uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
			LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
		}
	}

	private List<Joystick> xjRsnHvlapakrytsrYIhPkNLNRp;

	private List<Joystick> SCfCzwjnjXDBqAQKAXdcIXDCmYc;

	private List<CustomController> YLsaCuedneTuoHaKQfuOqsFrGYI;

	private List<Controller> CHKlEkrUfKlWgiWDsEfgfOjSgWs;

	private ReadOnlyCollection<Controller> IEPjVPJBsZnoVcaEETEPzGYuGVd;

	private Keyboard jWRCsxanswSezNRwShQFLDsixnhV;

	private Mouse MiFwUrdVVdOrWSSAMcWZRrLShqF;

	private ConfigVars SRJmkvsqkiIalkRkItQQVjlCCTY;

	private dSBGNfhWmOBnJhxggXIGiXSpFLdE[] TSrxbVQejeAztUxGvxbSMoujSqS;

	private dSBGNfhWmOBnJhxggXIGiXSpFLdE[] YUaChOqWbFXMhmqFLMUnEdCoulm;

	private dSBGNfhWmOBnJhxggXIGiXSpFLdE[,] pGlGMThJXXyXoHHIshZCedYqWIlc;

	private hMnkyrwLnsUHICLHhatCKMLfBPe QobUucNKiJirDRNPebFhTZgRwit;

	private PVHhzgaKOpHvKspvDHsmQsKUzPh vRdLFtMLqmNBuvjIjgTaYneHDyD;

	private PVHhzgaKOpHvKspvDHsmQsKUzPh[] cKjpkowFHdILyMjtVAzICxgZemI;

	private global::dhyYkrDfPmnKIWJlTBAqTODKFpsG<ActiveControllerChangedDelegate> GNgFvzxbbvwUIwKwzpEmtKPvAou;

	private global::dhyYkrDfPmnKIWJlTBAqTODKFpsG<PlayerActiveControllerChangedDelegate> OgHWugKJErqeioVzrYOnRjVKEKO;

	private global::dhyYkrDfPmnKIWJlTBAqTODKFpsG<PlayerActiveControllerChangedDelegate>[] QOhFsEysugPfMjVlpIrKthsBAbCJ;

	private ADictionary<int, eLdjcNWnzlUUdzfBtBbgCpokXPDR> MAPYOCBxzAVdryWxrzLWRrrutBJ;

	private readonly UpJYtIyHkhXTxTerpbIGIMQMINV DKDPSzxAYGPHIdvhCTFjPnGPODE;

	private IList<Joystick> vHTqzMaMhxMcjfnMDWYDZYYBqRg;

	private IList<CustomController> zvRqIGakMdSBrtKymEBsnKZSxRU;

	private int CJjlciYakXNxrkHyvcLLzQcqDVD;

	private bool DBibHQQRifdUpWAxGQiYCmvSEMn;

	private bool CwWMDXJLnZyjgHkoEXvDlKGJKbr;

	private bool ALMCJmjXSjdHiZhMwzlPasRpIhSm;

	private IUnifiedKeyboardSource GNSjyBJEkiLwVbuRSlSZoEKBDyQg;

	private IUnifiedMouseSource lFpwQxUJRsCiNyogVelsiPafwny;

	private int rqTGMBiIZUdCiQgkavfAfOsTzvY;

	private SlfkunxWuMcSymhpycotdVbpUpl bmLEnbkKNrTNSFrbOCrmcDPSGZKL;

	private kfVJCyCDaGCuiDEEEMtqgVXykXX USfldASbLlPourbEtKfoowSEGgo;

	private int rljhPROQGamuMpXWYzbmAtgdSOJ;

	private int VWqacxenovIReLxkURhOECDvYfGs;

	private Action<int, ControllerDataUpdater> GwdNvASrVYFlqIQiQILORoItHLH;

	private Action<bool, int, int> IFpGeMedzJbtotzIWCUejfgMbxwU;

	private Action<ControllerStatusChangedEventArgs> DEmbVedpYPPKIIIyJpfdClnefDqL;

	private Action<ControllerType, int> OAOtkxlmyVvzmwnjZytgcPdEVMX;

	private bool jgbpvYJovPcfzmcAEJzdxdrBmcm;

	public IList<Joystick> Joysticks_readOnly => vHTqzMaMhxMcjfnMDWYDZYYBqRg;

	public List<Joystick> Joysticks_orig => xjRsnHvlapakrytsrYIhPkNLNRp;

	public int joystickCount => xjRsnHvlapakrytsrYIhPkNLNRp.Count;

	public Mouse Mouse => MiFwUrdVVdOrWSSAMcWZRrLShqF;

	public Keyboard Keyboard => jWRCsxanswSezNRwShQFLDsixnhV;

	public IList<CustomController> CustomControllers_readOnly => zvRqIGakMdSBrtKymEBsnKZSxRU;

	public List<CustomController> CustomControllers_orig => YLsaCuedneTuoHaKQfuOqsFrGYI;

	public int customControllerCount => YLsaCuedneTuoHaKQfuOqsFrGYI.Count;

	public IList<Controller> Controllers => IEPjVPJBsZnoVcaEETEPzGYuGVd;

	public int controllerCount => CHKlEkrUfKlWgiWDsEfgfOjSgWs.Count;

	private int nextCustomControllerId
	{
		get
		{
			int result = rqTGMBiIZUdCiQgkavfAfOsTzvY;
			rqTGMBiIZUdCiQgkavfAfOsTzvY++;
			if (rqTGMBiIZUdCiQgkavfAfOsTzvY >= int.MaxValue)
			{
				rqTGMBiIZUdCiQgkavfAfOsTzvY = 0;
			}
			return result;
		}
	}

	public event Action<ControllerStatusChangedEventArgs> ControllerDisconnectStartedEvent
	{
		add
		{
			DEmbVedpYPPKIIIyJpfdClnefDqL = (Action<ControllerStatusChangedEventArgs>)Delegate.Combine(DEmbVedpYPPKIIIyJpfdClnefDqL, value);
		}
		remove
		{
			DEmbVedpYPPKIIIyJpfdClnefDqL = (Action<ControllerStatusChangedEventArgs>)Delegate.Remove(DEmbVedpYPPKIIIyJpfdClnefDqL, value);
		}
	}

	public event Action<ControllerType, int> JustBeforeControllerFullyDisconnectedEvent
	{
		add
		{
			OAOtkxlmyVvzmwnjZytgcPdEVMX = (Action<ControllerType, int>)Delegate.Combine(OAOtkxlmyVvzmwnjZytgcPdEVMX, value);
		}
		remove
		{
			OAOtkxlmyVvzmwnjZytgcPdEVMX = (Action<ControllerType, int>)Delegate.Remove(OAOtkxlmyVvzmwnjZytgcPdEVMX, value);
		}
	}

	public ChYhaBSijJnTpdXwQSqYJssvGND(ConfigVars configVars, PlatformInputManager inputManager)
	{
		SRJmkvsqkiIalkRkItQQVjlCCTY = configVars;
		CJjlciYakXNxrkHyvcLLzQcqDVD = 0;
		DBibHQQRifdUpWAxGQiYCmvSEMn = UnityTools.isAndroidPlatform;
		CHKlEkrUfKlWgiWDsEfgfOjSgWs = new List<Controller>(10);
		IEPjVPJBsZnoVcaEETEPzGYuGVd = new ReadOnlyCollection<Controller>(CHKlEkrUfKlWgiWDsEfgfOjSgWs);
		IUnifiedKeyboardSource unifiedKeyboardSource = inputManager.GetUnifiedKeyboardSource();
		if (unifiedKeyboardSource == null)
		{
			unifiedKeyboardSource = (GNSjyBJEkiLwVbuRSlSZoEKBDyQg = new UnityUnifiedKeyboardSource());
		}
		jWRCsxanswSezNRwShQFLDsixnhV = new Keyboard("Keyboard", unifiedKeyboardSource);
		CHKlEkrUfKlWgiWDsEfgfOjSgWs.Add(jWRCsxanswSezNRwShQFLDsixnhV);
		IUnifiedMouseSource unifiedMouseSource = inputManager.GetUnifiedMouseSource();
		if (unifiedMouseSource == null)
		{
			unifiedMouseSource = (lFpwQxUJRsCiNyogVelsiPafwny = new UnityUnifiedMouseSource());
		}
		MiFwUrdVVdOrWSSAMcWZRrLShqF = new Mouse("Mouse", unifiedMouseSource);
		CHKlEkrUfKlWgiWDsEfgfOjSgWs.Add(MiFwUrdVVdOrWSSAMcWZRrLShqF);
		QobUucNKiJirDRNPebFhTZgRwit = new hMnkyrwLnsUHICLHhatCKMLfBPe(configVars.updateLoop, jWRCsxanswSezNRwShQFLDsixnhV);
		jWRCsxanswSezNRwShQFLDsixnhV.EnabledStateChangedEvent += himblVluqbrWTOIPWeZAcXEarRP;
		jWRCsxanswSezNRwShQFLDsixnhV.enabled = !configVars.GetPlatformVar_disableKeyboard();
		JtVEtBYJhQtFKDuamlFmfbgoJGw.QjNHfjHnCmaQyvCGKbwODraSxUWC();
		DKDPSzxAYGPHIdvhCTFjPnGPODE = new UpJYtIyHkhXTxTerpbIGIMQMINV(UnityTools.externalTools.GetControllerTemplateTypes(), UnityTools.externalTools.GetControllerTemplateInterfaceTypes());
		DKDPSzxAYGPHIdvhCTFjPnGPODE.HWIjIWHDiHmuObinjAMvEfORTYeM(jWRCsxanswSezNRwShQFLDsixnhV);
		DKDPSzxAYGPHIdvhCTFjPnGPODE.HWIjIWHDiHmuObinjAMvEfORTYeM(MiFwUrdVVdOrWSSAMcWZRrLShqF);
		ReInput.ApplicationFocusChangedEvent += WYmLDaFUlNQSFcnYqPRibopaGWP;
	}

	public void EJpmrTgGvrhKjJnkpXbomYBpQTQ(Action<int, ControllerDataUpdater> P_0, List<InputBehavior> P_1)
	{
		GwdNvASrVYFlqIQiQILORoItHLH = P_0;
		EJpmrTgGvrhKjJnkpXbomYBpQTQ(P_1);
	}

	public void QTPiZFmnRsxmyQYmMuIoBQkOtfg(UpdateLoopType P_0)
	{
		JtVEtBYJhQtFKDuamlFmfbgoJGw.SrVavscbLndTlLkAtZtPkpdghxJJ(P_0);
		if (jWRCsxanswSezNRwShQFLDsixnhV.enabled)
		{
			QobUucNKiJirDRNPebFhTZgRwit.QTPiZFmnRsxmyQYmMuIoBQkOtfg(P_0);
		}
		CKBLcZRRtsaeKlCrCqpMuVAsbOo(P_0);
		hMGDovNjfsTREnzqquxQRlFbqAq(P_0);
		JtVEtBYJhQtFKDuamlFmfbgoJGw.yBuuCvoSMWjNMRELDWTrhiPPkXs(P_0, ReInput.currentFrame);
		if (ALMCJmjXSjdHiZhMwzlPasRpIhSm)
		{
			lvNsaOnwLjNjBPewEMHNhTzZQZO();
		}
	}

	public dSBGNfhWmOBnJhxggXIGiXSpFLdE rOiHJUbkFlrKFFYgoEYHIeqSBPEh(int P_0, string P_1, bool P_2)
	{
		int num = bmLEnbkKNrTNSFrbOCrmcDPSGZKL.EZvGxHsqIFFuTapSiFVRnGzgbyW(P_1, P_2);
		if (num < 0)
		{
			return null;
		}
		if (P_0 == 9999999)
		{
			return YUaChOqWbFXMhmqFLMUnEdCoulm[num];
		}
		if (P_0 < 0 || P_0 >= rljhPROQGamuMpXWYzbmAtgdSOJ)
		{
			return null;
		}
		return pGlGMThJXXyXoHHIshZCedYqWIlc[P_0, num];
	}

	public dSBGNfhWmOBnJhxggXIGiXSpFLdE rOiHJUbkFlrKFFYgoEYHIeqSBPEh(int P_0, int P_1, bool P_2)
	{
		int num = bmLEnbkKNrTNSFrbOCrmcDPSGZKL.EZvGxHsqIFFuTapSiFVRnGzgbyW(P_1, P_2);
		if (num < 0)
		{
			return null;
		}
		if (P_0 == 9999999)
		{
			return YUaChOqWbFXMhmqFLMUnEdCoulm[num];
		}
		return pGlGMThJXXyXoHHIshZCedYqWIlc[P_0, num];
	}

	public void CwUUJciFYlAaprEDiknrgmfmGne(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 != null && P_0.sourceJoystick != null)
		{
			ZyZRbCnIBTbNHvCqDENOiYHQYPDr zyZRbCnIBTbNHvCqDENOiYHQYPDr = ZyZRbCnIBTbNHvCqDENOiYHQYPDr.WbhPDGhsQhtuoeuemyINPoTnEvK;
			int num = MWqbcrlIqLMKeJnknbcgCDjJTfQP(P_0.sourceJoystick.rewiredId, zyZRbCnIBTbNHvCqDENOiYHQYPDr);
			if (num < 0)
			{
				zyZRbCnIBTbNHvCqDENOiYHQYPDr = ZyZRbCnIBTbNHvCqDENOiYHQYPDr.dBmuEUmBrzqrPzCZlujyBJFlBlqD;
				num = MWqbcrlIqLMKeJnknbcgCDjJTfQP(P_0.sourceJoystick.rewiredId, zyZRbCnIBTbNHvCqDENOiYHQYPDr);
			}
			if (num >= 0)
			{
				Joystick joystick = ((zyZRbCnIBTbNHvCqDENOiYHQYPDr != ZyZRbCnIBTbNHvCqDENOiYHQYPDr.WbhPDGhsQhtuoeuemyINPoTnEvK) ? (joystick = SCfCzwjnjXDBqAQKAXdcIXDCmYc[num]) : (joystick = xjRsnHvlapakrytsrYIhPkNLNRp[num]));
				joystick.hzVtWbKoxBiVifQXnOxAGNpQbbY(P_0);
			}
		}
	}

	public bool zKYZSXSlrsVNCispexWvwVJBVtq(int P_0, ZyZRbCnIBTbNHvCqDENOiYHQYPDr P_1)
	{
		if (MWqbcrlIqLMKeJnknbcgCDjJTfQP(P_0, P_1) < 0)
		{
			return false;
		}
		return true;
	}

	public int MWqbcrlIqLMKeJnknbcgCDjJTfQP(int P_0, ZyZRbCnIBTbNHvCqDENOiYHQYPDr P_1)
	{
		switch (P_1)
		{
		case ZyZRbCnIBTbNHvCqDENOiYHQYPDr.WbhPDGhsQhtuoeuemyINPoTnEvK:
		{
			int count2 = xjRsnHvlapakrytsrYIhPkNLNRp.Count;
			for (int j = 0; j < count2; j++)
			{
				if (xjRsnHvlapakrytsrYIhPkNLNRp[j].id == P_0)
				{
					return j;
				}
			}
			break;
		}
		case ZyZRbCnIBTbNHvCqDENOiYHQYPDr.dBmuEUmBrzqrPzCZlujyBJFlBlqD:
		{
			int count = SCfCzwjnjXDBqAQKAXdcIXDCmYc.Count;
			for (int i = 0; i < count; i++)
			{
				if (SCfCzwjnjXDBqAQKAXdcIXDCmYc[i].id == P_0)
				{
					return i;
				}
			}
			break;
		}
		}
		return -1;
	}

	public int MWqbcrlIqLMKeJnknbcgCDjJTfQP(Guid P_0, ZyZRbCnIBTbNHvCqDENOiYHQYPDr P_1)
	{
		switch (P_1)
		{
		case ZyZRbCnIBTbNHvCqDENOiYHQYPDr.WbhPDGhsQhtuoeuemyINPoTnEvK:
		{
			int count2 = xjRsnHvlapakrytsrYIhPkNLNRp.Count;
			for (int j = 0; j < count2; j++)
			{
				if (xjRsnHvlapakrytsrYIhPkNLNRp[j].deviceInstanceGuid == P_0)
				{
					return j;
				}
			}
			break;
		}
		case ZyZRbCnIBTbNHvCqDENOiYHQYPDr.dBmuEUmBrzqrPzCZlujyBJFlBlqD:
		{
			int count = SCfCzwjnjXDBqAQKAXdcIXDCmYc.Count;
			for (int i = 0; i < count; i++)
			{
				if (SCfCzwjnjXDBqAQKAXdcIXDCmYc[i].deviceInstanceGuid == P_0)
				{
					return i;
				}
			}
			break;
		}
		}
		return -1;
	}

	public bool pocqnKdThRzirbjLXSOhyHcpxuY(int P_0)
	{
		if (mLHtePvuLRpoNtuIrcqOCquemOy(P_0) < 0)
		{
			return false;
		}
		return true;
	}

	public int mLHtePvuLRpoNtuIrcqOCquemOy(int P_0)
	{
		int count = YLsaCuedneTuoHaKQfuOqsFrGYI.Count;
		for (int i = 0; i < count; i++)
		{
			if (YLsaCuedneTuoHaKQfuOqsFrGYI[i].id == P_0)
			{
				return i;
			}
		}
		return -1;
	}

	public int mLHtePvuLRpoNtuIrcqOCquemOy(Guid P_0)
	{
		int count = YLsaCuedneTuoHaKQfuOqsFrGYI.Count;
		for (int i = 0; i < count; i++)
		{
			if (YLsaCuedneTuoHaKQfuOqsFrGYI[i].deviceInstanceGuid == P_0)
			{
				return i;
			}
		}
		return -1;
	}

	public void OcJiFTfYhVOxbPWzpBkiqlUfCqj(BridgedController P_0)
	{
		eVTXVPJbvyCHwEfwHsIQiOERmX(P_0);
	}

	public void aJmAFIJYAhoNsonZPnVCEQKSIgF(int P_0)
	{
		int num = MWqbcrlIqLMKeJnknbcgCDjJTfQP(P_0, ZyZRbCnIBTbNHvCqDENOiYHQYPDr.WbhPDGhsQhtuoeuemyINPoTnEvK);
		zXAeGDuhTVCbpGhoowuCQOvSOWmn(num);
	}

	public int OdgeliGexstdTqqKtmEBqLlngeAN()
	{
		return CJjlciYakXNxrkHyvcLLzQcqDVD++;
	}

	public IList<InputBehavior> ULwJdKkNlZyMLRMUSpEcyLnEHMVd(int P_0)
	{
		if (!MAPYOCBxzAVdryWxrzLWRrrutBJ.ContainsKey(P_0))
		{
			return new List<InputBehavior>();
		}
		return MAPYOCBxzAVdryWxrzLWRrrutBJ[P_0].gbaOPDJUNrQFoVnHayGjnkPoiHu;
	}

	public InputBehavior TGBTlzxMydGPzMLlNNpkWykXunu(int P_0, string P_1)
	{
		if (P_1 == null || P_1 == string.Empty)
		{
			return null;
		}
		int inputBehaviorId = ReInput.mapping.GetInputBehaviorId(P_1);
		return TGBTlzxMydGPzMLlNNpkWykXunu(P_0, inputBehaviorId);
	}

	public InputBehavior TGBTlzxMydGPzMLlNNpkWykXunu(int P_0, int P_1)
	{
		if (!MAPYOCBxzAVdryWxrzLWRrrutBJ.ContainsKey(P_0))
		{
			return null;
		}
		IList<InputBehavior> gbaOPDJUNrQFoVnHayGjnkPoiHu = MAPYOCBxzAVdryWxrzLWRrrutBJ[P_0].gbaOPDJUNrQFoVnHayGjnkPoiHu;
		for (int i = 0; i < gbaOPDJUNrQFoVnHayGjnkPoiHu.Count; i++)
		{
			if (gbaOPDJUNrQFoVnHayGjnkPoiHu[i].id == P_1)
			{
				return gbaOPDJUNrQFoVnHayGjnkPoiHu[i];
			}
		}
		return null;
	}

	public Joystick DjEdqahmwjneIiOCxudqBnmlLdFW(int P_0, bool P_1 = false)
	{
		int num = MWqbcrlIqLMKeJnknbcgCDjJTfQP(P_0, ZyZRbCnIBTbNHvCqDENOiYHQYPDr.WbhPDGhsQhtuoeuemyINPoTnEvK);
		if (num >= 0)
		{
			return xjRsnHvlapakrytsrYIhPkNLNRp[num];
		}
		if (P_1)
		{
			num = MWqbcrlIqLMKeJnknbcgCDjJTfQP(P_0, ZyZRbCnIBTbNHvCqDENOiYHQYPDr.dBmuEUmBrzqrPzCZlujyBJFlBlqD);
			if (num >= 0)
			{
				return SCfCzwjnjXDBqAQKAXdcIXDCmYc[num];
			}
		}
		return null;
	}

	public Joystick DjEdqahmwjneIiOCxudqBnmlLdFW(Guid P_0, bool P_1 = false)
	{
		int num = MWqbcrlIqLMKeJnknbcgCDjJTfQP(P_0, ZyZRbCnIBTbNHvCqDENOiYHQYPDr.WbhPDGhsQhtuoeuemyINPoTnEvK);
		if (num >= 0)
		{
			return xjRsnHvlapakrytsrYIhPkNLNRp[num];
		}
		if (P_1)
		{
			num = MWqbcrlIqLMKeJnknbcgCDjJTfQP(P_0, ZyZRbCnIBTbNHvCqDENOiYHQYPDr.dBmuEUmBrzqrPzCZlujyBJFlBlqD);
			if (num >= 0)
			{
				return SCfCzwjnjXDBqAQKAXdcIXDCmYc[num];
			}
		}
		return null;
	}

	public Joystick[] sFRhzwbwJENamFdozTvrBCQUxGC()
	{
		int count = xjRsnHvlapakrytsrYIhPkNLNRp.Count;
		if (count == 0)
		{
			return EmptyObjects<Joystick>.array;
		}
		Joystick[] array = new Joystick[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = xjRsnHvlapakrytsrYIhPkNLNRp[i];
		}
		return array;
	}

	public string[] TmuBgXKIzPBrnJUzRIdxdVobKNzN()
	{
		int count = xjRsnHvlapakrytsrYIhPkNLNRp.Count;
		if (count == 0)
		{
			return EmptyObjects<string>.array;
		}
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = xjRsnHvlapakrytsrYIhPkNLNRp[i].name;
		}
		return array;
	}

	public CustomController bsfTsyrwELqckGDTZplJtQXhLEf(int P_0)
	{
		int num = mLHtePvuLRpoNtuIrcqOCquemOy(P_0);
		if (num < 0)
		{
			return null;
		}
		return YLsaCuedneTuoHaKQfuOqsFrGYI[num];
	}

	public CustomController bsfTsyrwELqckGDTZplJtQXhLEf(Guid P_0)
	{
		int num = mLHtePvuLRpoNtuIrcqOCquemOy(P_0);
		if (num < 0)
		{
			return null;
		}
		return YLsaCuedneTuoHaKQfuOqsFrGYI[num];
	}

	public CustomController[] GNFsuerMGaIqAjZQCHWxdXBqZcXK()
	{
		int count = YLsaCuedneTuoHaKQfuOqsFrGYI.Count;
		if (count == 0)
		{
			return EmptyObjects<CustomController>.array;
		}
		CustomController[] array = new CustomController[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = YLsaCuedneTuoHaKQfuOqsFrGYI[i];
		}
		return array;
	}

	public string[] SpFatxALfUoRPNGNSAyUBzkhGqWC()
	{
		int count = YLsaCuedneTuoHaKQfuOqsFrGYI.Count;
		if (count == 0)
		{
			return EmptyObjects<string>.array;
		}
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = YLsaCuedneTuoHaKQfuOqsFrGYI[i].name;
		}
		return array;
	}

	public CustomController EEXCNqgVpUfeLKZrirmWsCPeGFli(int P_0)
	{
		CustomController_Editor customControllerById = ReInput.UserData.GetCustomControllerById(P_0);
		if (customControllerById == null)
		{
			return null;
		}
		int aVJCjGFlvmvUQprbQtbNLTqidXD = nextCustomControllerId;
		ygvylZNreBYIQhhVJVOfRApPZNs ygvylZNreBYIQhhVJVOfRApPZNs2 = new ygvylZNreBYIQhhVJVOfRApPZNs();
		ygvylZNreBYIQhhVJVOfRApPZNs2.UdjCSEOPIRsTIjnUgCiPBbbzKWS = InputSource.Custom;
		ygvylZNreBYIQhhVJVOfRApPZNs2.MLmLjcwSbKBkEhcbqGJFmLCQUrjT = customControllerById.descriptiveName;
		ygvylZNreBYIQhhVJVOfRApPZNs2.uayuHNVIEnEtqEVbNsJfjAqVsbm = customControllerById.name;
		ygvylZNreBYIQhhVJVOfRApPZNs2.JDyNNdOScJLywOHcbmcaJdgZeIE = customControllerById.axisCount;
		ygvylZNreBYIQhhVJVOfRApPZNs2.CtHmgLQvreiWMWnBZZLsTLZpuCY = customControllerById.buttonCount;
		ygvylZNreBYIQhhVJVOfRApPZNs2.AVJCjGFlvmvUQprbQtbNLTqidXD = aVJCjGFlvmvUQprbQtbNLTqidXD;
		ygvylZNreBYIQhhVJVOfRApPZNs2.zgKNDgvLPNgKlLScSDXNeXiBIqQM = customControllerById.id;
		ygvylZNreBYIQhhVJVOfRApPZNs2.brEBbktrLGXDVNcjjSmlHrEpLlf = customControllerById.typeGuid;
		ygvylZNreBYIQhhVJVOfRApPZNs2.ptRLmiXIjTICISXbyEHEtIvywjV = customControllerById.id.ToString();
		ygvylZNreBYIQhhVJVOfRApPZNs2.JZChcDKathrMbEPpYYUdEtVaKyqX = customControllerById.ODbFZfeokzbSMyFiHAkwhiknQgY();
		ygvylZNreBYIQhhVJVOfRApPZNs data = ygvylZNreBYIQhhVJVOfRApPZNs2;
		CustomController customController = new CustomController(data);
		ZeNcCgUkWoGJZAZOLSbHwfsXHTq(customController);
		return customController;
	}

	public bool IVeWpiSIKGIDRHGSqGuVGfhqHAL(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		return TPBQzKwhRwfWtmCNVYcejNFNlGQ(P_0);
	}

	public CustomController LlcDycQirIicJKrnomSRXMoVxmD(int P_0)
	{
		int count = YLsaCuedneTuoHaKQfuOqsFrGYI.Count;
		for (int i = 0; i < count; i++)
		{
			if (YLsaCuedneTuoHaKQfuOqsFrGYI[i].sourceControllerId == P_0)
			{
				return YLsaCuedneTuoHaKQfuOqsFrGYI[i];
			}
		}
		return null;
	}

	public CustomController GMitpWtyESwPjvwSHqzCjFCGvfR(string P_0)
	{
		int count = YLsaCuedneTuoHaKQfuOqsFrGYI.Count;
		for (int i = 0; i < count; i++)
		{
			if (YLsaCuedneTuoHaKQfuOqsFrGYI[i].tag.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return YLsaCuedneTuoHaKQfuOqsFrGYI[i];
			}
		}
		return null;
	}

	public IEnumerable<CustomController> NLscTSEJNtmCrMdGobsVmkcehci(int P_0)
	{
		HmFcZIlVxjuvmkSQUqxrCPOCUnx hmFcZIlVxjuvmkSQUqxrCPOCUnx = new HmFcZIlVxjuvmkSQUqxrCPOCUnx(-2);
		hmFcZIlVxjuvmkSQUqxrCPOCUnx.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
		hmFcZIlVxjuvmkSQUqxrCPOCUnx.QXwgXVMZTbHAlLsSUQmthjCOfioj = P_0;
		return hmFcZIlVxjuvmkSQUqxrCPOCUnx;
	}

	public IEnumerable<CustomController> tkZxDOlgYJVqYwoeJXjnqLyZBNU(string P_0)
	{
		McnQohzIonFvDFDSqhGdjJlGcsqH mcnQohzIonFvDFDSqhGdjJlGcsqH = new McnQohzIonFvDFDSqhGdjJlGcsqH(-2);
		mcnQohzIonFvDFDSqhGdjJlGcsqH.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
		mcnQohzIonFvDFDSqhGdjJlGcsqH.mufPbKpVOBEtofbeNAVPePuPBCK = P_0;
		return mcnQohzIonFvDFDSqhGdjJlGcsqH;
	}

	public Controller ZbGtisIkVmOkbLNUAlpAicawGu(ControllerType P_0, int P_1, bool P_2 = false)
	{
		return P_0 switch
		{
			ControllerType.Joystick => DjEdqahmwjneIiOCxudqBnmlLdFW(P_1, P_2), 
			ControllerType.Keyboard => jWRCsxanswSezNRwShQFLDsixnhV, 
			ControllerType.Mouse => MiFwUrdVVdOrWSSAMcWZRrLShqF, 
			ControllerType.Custom => bsfTsyrwELqckGDTZplJtQXhLEf(P_1), 
			_ => throw new NotImplementedException(), 
		};
	}

	public Controller ZbGtisIkVmOkbLNUAlpAicawGu(ControllerIdentifier P_0, bool P_1 = false)
	{
		if (P_0.deviceInstanceGuid != Guid.Empty)
		{
			return ZbGtisIkVmOkbLNUAlpAicawGu(P_0.deviceInstanceGuid);
		}
		if (P_0.controllerId >= 0)
		{
			return ZbGtisIkVmOkbLNUAlpAicawGu(P_0.controllerType, P_0.controllerId, P_1);
		}
		return null;
	}

	public Controller ZbGtisIkVmOkbLNUAlpAicawGu(Guid P_0, bool P_1 = false)
	{
		if (P_0 == Guid.Empty)
		{
			return null;
		}
		if (jWRCsxanswSezNRwShQFLDsixnhV.deviceInstanceGuid == P_0)
		{
			return jWRCsxanswSezNRwShQFLDsixnhV;
		}
		if (MiFwUrdVVdOrWSSAMcWZRrLShqF.deviceInstanceGuid == P_0)
		{
			return MiFwUrdVVdOrWSSAMcWZRrLShqF;
		}
		Controller result;
		if ((result = DjEdqahmwjneIiOCxudqBnmlLdFW(P_0, P_1)) != null)
		{
			return result;
		}
		if ((result = bsfTsyrwELqckGDTZplJtQXhLEf(P_0)) != null)
		{
			return result;
		}
		return null;
	}

	public Controller[] CDjnCrMZbGGAMUnUMTDGCdPpJkZ(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => sFRhzwbwJENamFdozTvrBCQUxGC(), 
			ControllerType.Keyboard => new Controller[1] { jWRCsxanswSezNRwShQFLDsixnhV }, 
			ControllerType.Mouse => new Controller[1] { MiFwUrdVVdOrWSSAMcWZRrLShqF }, 
			ControllerType.Custom => GNFsuerMGaIqAjZQCHWxdXBqZcXK(), 
			_ => throw new NotImplementedException(), 
		};
	}

	public string[] rsuIiBmxTdeVboabAJdwNPzTWqs(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => TmuBgXKIzPBrnJUzRIdxdVobKNzN(), 
			ControllerType.Keyboard => new string[1] { jWRCsxanswSezNRwShQFLDsixnhV.name }, 
			ControllerType.Mouse => new string[1] { MiFwUrdVVdOrWSSAMcWZRrLShqF.name }, 
			ControllerType.Custom => SpFatxALfUoRPNGNSAyUBzkhGqWC(), 
			_ => throw new NotImplementedException(), 
		};
	}

	public void ClYADwuGCcDzxlqMVqgVHGhbARy(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		if (!CwWMDXJLnZyjgHkoEXvDlKGJKbr)
		{
			CwWMDXJLnZyjgHkoEXvDlKGJKbr = true;
		}
		cujyGfzXYFQAPmpiGJVdNocOPvB(P_0)?.kXumKtfSBwewksMrxulEXBnmjdWG(P_1, P_2, InputActionEventType.Update, null);
	}

	public void ClYADwuGCcDzxlqMVqgVHGhbARy(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		if (!CwWMDXJLnZyjgHkoEXvDlKGJKbr)
		{
			CwWMDXJLnZyjgHkoEXvDlKGJKbr = true;
		}
		cujyGfzXYFQAPmpiGJVdNocOPvB(P_0)?.kXumKtfSBwewksMrxulEXBnmjdWG(P_1, P_2, InputActionEventType.Update, P_3, null);
	}

	public void ClYADwuGCcDzxlqMVqgVHGhbARy(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		if (!CwWMDXJLnZyjgHkoEXvDlKGJKbr)
		{
			CwWMDXJLnZyjgHkoEXvDlKGJKbr = true;
		}
		int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(P_3);
		if (num >= 0)
		{
			ClYADwuGCcDzxlqMVqgVHGhbARy(P_0, P_1, P_2, num);
		}
	}

	public void ClYADwuGCcDzxlqMVqgVHGhbARy(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, object[] P_4)
	{
		if (!CwWMDXJLnZyjgHkoEXvDlKGJKbr)
		{
			CwWMDXJLnZyjgHkoEXvDlKGJKbr = true;
		}
		cujyGfzXYFQAPmpiGJVdNocOPvB(P_0)?.kXumKtfSBwewksMrxulEXBnmjdWG(P_1, P_2, P_3, P_4);
	}

	public void ClYADwuGCcDzxlqMVqgVHGhbARy(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4, object[] P_5)
	{
		if (!CwWMDXJLnZyjgHkoEXvDlKGJKbr)
		{
			CwWMDXJLnZyjgHkoEXvDlKGJKbr = true;
		}
		cujyGfzXYFQAPmpiGJVdNocOPvB(P_0)?.kXumKtfSBwewksMrxulEXBnmjdWG(P_1, P_2, P_3, P_4, P_5);
	}

	public void ClYADwuGCcDzxlqMVqgVHGhbARy(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4, object[] P_5)
	{
		if (!CwWMDXJLnZyjgHkoEXvDlKGJKbr)
		{
			CwWMDXJLnZyjgHkoEXvDlKGJKbr = true;
		}
		int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(P_4);
		if (num >= 0)
		{
			ClYADwuGCcDzxlqMVqgVHGhbARy(P_0, P_1, P_2, P_3, num, P_5);
		}
	}

	public void PcvrLwJfQkATCIgvYbqASXVMKFCJ(int P_0, Action<InputActionEventData> P_1)
	{
		cujyGfzXYFQAPmpiGJVdNocOPvB(P_0)?.FCOtpjOvOZFuOGQPrGDxAJbQpGR(P_1);
	}

	public void PcvrLwJfQkATCIgvYbqASXVMKFCJ(int P_0, Action<InputActionEventData> P_1, int P_2)
	{
		cujyGfzXYFQAPmpiGJVdNocOPvB(P_0)?.FCOtpjOvOZFuOGQPrGDxAJbQpGR(P_1, P_2);
	}

	public void PcvrLwJfQkATCIgvYbqASXVMKFCJ(int P_0, Action<InputActionEventData> P_1, string P_2)
	{
		int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(P_2);
		if (num >= 0)
		{
			PcvrLwJfQkATCIgvYbqASXVMKFCJ(P_0, P_1, num);
		}
	}

	public void PcvrLwJfQkATCIgvYbqASXVMKFCJ(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		cujyGfzXYFQAPmpiGJVdNocOPvB(P_0)?.FCOtpjOvOZFuOGQPrGDxAJbQpGR(P_1, P_2);
	}

	public void PcvrLwJfQkATCIgvYbqASXVMKFCJ(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2)
	{
		cujyGfzXYFQAPmpiGJVdNocOPvB(P_0)?.FCOtpjOvOZFuOGQPrGDxAJbQpGR(P_1, P_2);
	}

	public void PcvrLwJfQkATCIgvYbqASXVMKFCJ(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		cujyGfzXYFQAPmpiGJVdNocOPvB(P_0)?.FCOtpjOvOZFuOGQPrGDxAJbQpGR(P_1, P_2, P_3);
	}

	public void PcvrLwJfQkATCIgvYbqASXVMKFCJ(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(P_3);
		if (num >= 0)
		{
			PcvrLwJfQkATCIgvYbqASXVMKFCJ(P_0, P_1, P_2, num);
		}
	}

	public void PcvrLwJfQkATCIgvYbqASXVMKFCJ(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, int P_3)
	{
		cujyGfzXYFQAPmpiGJVdNocOPvB(P_0)?.FCOtpjOvOZFuOGQPrGDxAJbQpGR(P_1, P_2, P_3);
	}

	public void PcvrLwJfQkATCIgvYbqASXVMKFCJ(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, string P_3)
	{
		int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(P_3);
		if (num >= 0)
		{
			PcvrLwJfQkATCIgvYbqASXVMKFCJ(P_0, P_1, P_2, num);
		}
	}

	public void PcvrLwJfQkATCIgvYbqASXVMKFCJ(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3)
	{
		cujyGfzXYFQAPmpiGJVdNocOPvB(P_0)?.FCOtpjOvOZFuOGQPrGDxAJbQpGR(P_1, P_2, P_3);
	}

	public void PcvrLwJfQkATCIgvYbqASXVMKFCJ(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4)
	{
		cujyGfzXYFQAPmpiGJVdNocOPvB(P_0)?.FCOtpjOvOZFuOGQPrGDxAJbQpGR(P_1, P_2, P_3, P_4);
	}

	public void PcvrLwJfQkATCIgvYbqASXVMKFCJ(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4)
	{
		int num = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.QCCcivdnkZkmiacpJDFREoDsGax(P_4);
		if (num >= 0)
		{
			PcvrLwJfQkATCIgvYbqASXVMKFCJ(P_0, P_1, P_2, P_3, num);
		}
	}

	public void GnynYeRDnILdbolUyKDXfomUmyG(int P_0)
	{
		cujyGfzXYFQAPmpiGJVdNocOPvB(P_0)?.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
	}

	public bool bBbXsYHFeBvAjkinoiIFFuBLCBWS(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < YUaChOqWbFXMhmqFLMUnEdCoulm.Length; i++)
			{
				if (YUaChOqWbFXMhmqFLMUnEdCoulm[i].tczGrLoSLQRKAWwrReBmbHatjKF())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= rljhPROQGamuMpXWYzbmAtgdSOJ)
		{
			return false;
		}
		int actionCount = bmLEnbkKNrTNSFrbOCrmcDPSGZKL.actionCount;
		for (int j = 0; j < actionCount; j++)
		{
			if (pGlGMThJXXyXoHHIshZCedYqWIlc[P_0, j].tczGrLoSLQRKAWwrReBmbHatjKF())
			{
				return true;
			}
		}
		return false;
	}

	public bool bFKUBVJsrjxGlwNxhyQsURGSIqj(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < YUaChOqWbFXMhmqFLMUnEdCoulm.Length; i++)
			{
				if (YUaChOqWbFXMhmqFLMUnEdCoulm[i].wyMTjzWuSYHxxwaQSHqUbLUGgKg())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= rljhPROQGamuMpXWYzbmAtgdSOJ)
		{
			return false;
		}
		int actionCount = bmLEnbkKNrTNSFrbOCrmcDPSGZKL.actionCount;
		for (int j = 0; j < actionCount; j++)
		{
			if (pGlGMThJXXyXoHHIshZCedYqWIlc[P_0, j].wyMTjzWuSYHxxwaQSHqUbLUGgKg())
			{
				return true;
			}
		}
		return false;
	}

	public bool kNRsZXBAYLbdwHbcUybDHytAORr(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < YUaChOqWbFXMhmqFLMUnEdCoulm.Length; i++)
			{
				if (YUaChOqWbFXMhmqFLMUnEdCoulm[i].KsQmhhakoIMsmFFssFWZgAtACAmj())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= rljhPROQGamuMpXWYzbmAtgdSOJ)
		{
			return false;
		}
		int actionCount = bmLEnbkKNrTNSFrbOCrmcDPSGZKL.actionCount;
		for (int j = 0; j < actionCount; j++)
		{
			if (pGlGMThJXXyXoHHIshZCedYqWIlc[P_0, j].KsQmhhakoIMsmFFssFWZgAtACAmj())
			{
				return true;
			}
		}
		return false;
	}

	public bool jQwfojcbbLwzJLtlhXQHizmIhCz(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < YUaChOqWbFXMhmqFLMUnEdCoulm.Length; i++)
			{
				if (YUaChOqWbFXMhmqFLMUnEdCoulm[i].hOuVCsfFccvyBzqOmUyNGejSnqg())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= rljhPROQGamuMpXWYzbmAtgdSOJ)
		{
			return false;
		}
		int actionCount = bmLEnbkKNrTNSFrbOCrmcDPSGZKL.actionCount;
		for (int j = 0; j < actionCount; j++)
		{
			if (pGlGMThJXXyXoHHIshZCedYqWIlc[P_0, j].hOuVCsfFccvyBzqOmUyNGejSnqg())
			{
				return true;
			}
		}
		return false;
	}

	public bool XMiSioRGzWKcpTLdUCWanpTXRyO(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < YUaChOqWbFXMhmqFLMUnEdCoulm.Length; i++)
			{
				if (YUaChOqWbFXMhmqFLMUnEdCoulm[i].KpRTXcEtyGlzHQYXMAstvlyskee())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= rljhPROQGamuMpXWYzbmAtgdSOJ)
		{
			return false;
		}
		int actionCount = bmLEnbkKNrTNSFrbOCrmcDPSGZKL.actionCount;
		for (int j = 0; j < actionCount; j++)
		{
			if (pGlGMThJXXyXoHHIshZCedYqWIlc[P_0, j].KpRTXcEtyGlzHQYXMAstvlyskee())
			{
				return true;
			}
		}
		return false;
	}

	public bool DFfOsSHSkVEaxLmynSHamJhfGyyh(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < YUaChOqWbFXMhmqFLMUnEdCoulm.Length; i++)
			{
				if (YUaChOqWbFXMhmqFLMUnEdCoulm[i].KyvdceKirMVFNQGItYflXrFbvzb())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= rljhPROQGamuMpXWYzbmAtgdSOJ)
		{
			return false;
		}
		int actionCount = bmLEnbkKNrTNSFrbOCrmcDPSGZKL.actionCount;
		for (int j = 0; j < actionCount; j++)
		{
			if (pGlGMThJXXyXoHHIshZCedYqWIlc[P_0, j].KyvdceKirMVFNQGItYflXrFbvzb())
			{
				return true;
			}
		}
		return false;
	}

	public bool mHmforKaWCqgzJraHcgcZvIRfQwf(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < YUaChOqWbFXMhmqFLMUnEdCoulm.Length; i++)
			{
				if (YUaChOqWbFXMhmqFLMUnEdCoulm[i].ZwUMSLHJcuYAbRcebDaGJalfcRoE())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= rljhPROQGamuMpXWYzbmAtgdSOJ)
		{
			return false;
		}
		int actionCount = bmLEnbkKNrTNSFrbOCrmcDPSGZKL.actionCount;
		for (int j = 0; j < actionCount; j++)
		{
			if (pGlGMThJXXyXoHHIshZCedYqWIlc[P_0, j].ZwUMSLHJcuYAbRcebDaGJalfcRoE())
			{
				return true;
			}
		}
		return false;
	}

	public bool ylkFjeYhAiHvOQiSlSTlKMHHfAa(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < YUaChOqWbFXMhmqFLMUnEdCoulm.Length; i++)
			{
				if (YUaChOqWbFXMhmqFLMUnEdCoulm[i].VdfXOJuqKRFlPuSWWCQbwWJCAGE())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= rljhPROQGamuMpXWYzbmAtgdSOJ)
		{
			return false;
		}
		int actionCount = bmLEnbkKNrTNSFrbOCrmcDPSGZKL.actionCount;
		for (int j = 0; j < actionCount; j++)
		{
			if (pGlGMThJXXyXoHHIshZCedYqWIlc[P_0, j].VdfXOJuqKRFlPuSWWCQbwWJCAGE())
			{
				return true;
			}
		}
		return false;
	}

	public bool uErIGsaCfVrhMzjnvTAimaVcBuDM()
	{
		if (!uErIGsaCfVrhMzjnvTAimaVcBuDM(MiFwUrdVVdOrWSSAMcWZRrLShqF) && !uErIGsaCfVrhMzjnvTAimaVcBuDM(xjRsnHvlapakrytsrYIhPkNLNRp) && !uErIGsaCfVrhMzjnvTAimaVcBuDM(jWRCsxanswSezNRwShQFLDsixnhV))
		{
			return uErIGsaCfVrhMzjnvTAimaVcBuDM(YLsaCuedneTuoHaKQfuOqsFrGYI);
		}
		return true;
	}

	public bool uErIGsaCfVrhMzjnvTAimaVcBuDM(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => uErIGsaCfVrhMzjnvTAimaVcBuDM(xjRsnHvlapakrytsrYIhPkNLNRp), 
			ControllerType.Keyboard => uErIGsaCfVrhMzjnvTAimaVcBuDM(jWRCsxanswSezNRwShQFLDsixnhV), 
			ControllerType.Mouse => uErIGsaCfVrhMzjnvTAimaVcBuDM(MiFwUrdVVdOrWSSAMcWZRrLShqF), 
			ControllerType.Custom => uErIGsaCfVrhMzjnvTAimaVcBuDM(YLsaCuedneTuoHaKQfuOqsFrGYI), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool uEcGaHgkKaQepEeRRYIyaETDGsiR()
	{
		if (!uEcGaHgkKaQepEeRRYIyaETDGsiR(MiFwUrdVVdOrWSSAMcWZRrLShqF) && !uEcGaHgkKaQepEeRRYIyaETDGsiR(xjRsnHvlapakrytsrYIhPkNLNRp) && !uEcGaHgkKaQepEeRRYIyaETDGsiR(jWRCsxanswSezNRwShQFLDsixnhV))
		{
			return uEcGaHgkKaQepEeRRYIyaETDGsiR(YLsaCuedneTuoHaKQfuOqsFrGYI);
		}
		return true;
	}

	public bool uEcGaHgkKaQepEeRRYIyaETDGsiR(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => uEcGaHgkKaQepEeRRYIyaETDGsiR(xjRsnHvlapakrytsrYIhPkNLNRp), 
			ControllerType.Keyboard => uEcGaHgkKaQepEeRRYIyaETDGsiR(jWRCsxanswSezNRwShQFLDsixnhV), 
			ControllerType.Mouse => uEcGaHgkKaQepEeRRYIyaETDGsiR(MiFwUrdVVdOrWSSAMcWZRrLShqF), 
			ControllerType.Custom => uEcGaHgkKaQepEeRRYIyaETDGsiR(YLsaCuedneTuoHaKQfuOqsFrGYI), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool UOlkBNWKtHFJwsNGRxGVpAsaAmeb()
	{
		if (!UOlkBNWKtHFJwsNGRxGVpAsaAmeb(MiFwUrdVVdOrWSSAMcWZRrLShqF) && !UOlkBNWKtHFJwsNGRxGVpAsaAmeb(xjRsnHvlapakrytsrYIhPkNLNRp) && !UOlkBNWKtHFJwsNGRxGVpAsaAmeb(jWRCsxanswSezNRwShQFLDsixnhV))
		{
			return UOlkBNWKtHFJwsNGRxGVpAsaAmeb(YLsaCuedneTuoHaKQfuOqsFrGYI);
		}
		return true;
	}

	public bool UOlkBNWKtHFJwsNGRxGVpAsaAmeb(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => UOlkBNWKtHFJwsNGRxGVpAsaAmeb(xjRsnHvlapakrytsrYIhPkNLNRp), 
			ControllerType.Keyboard => UOlkBNWKtHFJwsNGRxGVpAsaAmeb(jWRCsxanswSezNRwShQFLDsixnhV), 
			ControllerType.Mouse => UOlkBNWKtHFJwsNGRxGVpAsaAmeb(MiFwUrdVVdOrWSSAMcWZRrLShqF), 
			ControllerType.Custom => UOlkBNWKtHFJwsNGRxGVpAsaAmeb(YLsaCuedneTuoHaKQfuOqsFrGYI), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool PplchENCbauLcPKcNgQefbauMVmA()
	{
		if (!PplchENCbauLcPKcNgQefbauMVmA(MiFwUrdVVdOrWSSAMcWZRrLShqF) && !PplchENCbauLcPKcNgQefbauMVmA(xjRsnHvlapakrytsrYIhPkNLNRp) && !PplchENCbauLcPKcNgQefbauMVmA(jWRCsxanswSezNRwShQFLDsixnhV))
		{
			return PplchENCbauLcPKcNgQefbauMVmA(YLsaCuedneTuoHaKQfuOqsFrGYI);
		}
		return true;
	}

	public bool PplchENCbauLcPKcNgQefbauMVmA(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => PplchENCbauLcPKcNgQefbauMVmA(xjRsnHvlapakrytsrYIhPkNLNRp), 
			ControllerType.Keyboard => PplchENCbauLcPKcNgQefbauMVmA(jWRCsxanswSezNRwShQFLDsixnhV), 
			ControllerType.Mouse => PplchENCbauLcPKcNgQefbauMVmA(MiFwUrdVVdOrWSSAMcWZRrLShqF), 
			ControllerType.Custom => PplchENCbauLcPKcNgQefbauMVmA(YLsaCuedneTuoHaKQfuOqsFrGYI), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool MdzcSCEDfXUWKSyxQLUNeDIjnWta()
	{
		if (!MdzcSCEDfXUWKSyxQLUNeDIjnWta(MiFwUrdVVdOrWSSAMcWZRrLShqF) && !MdzcSCEDfXUWKSyxQLUNeDIjnWta(xjRsnHvlapakrytsrYIhPkNLNRp) && !MdzcSCEDfXUWKSyxQLUNeDIjnWta(jWRCsxanswSezNRwShQFLDsixnhV))
		{
			return MdzcSCEDfXUWKSyxQLUNeDIjnWta(YLsaCuedneTuoHaKQfuOqsFrGYI);
		}
		return true;
	}

	public bool MdzcSCEDfXUWKSyxQLUNeDIjnWta(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => MdzcSCEDfXUWKSyxQLUNeDIjnWta(xjRsnHvlapakrytsrYIhPkNLNRp), 
			ControllerType.Keyboard => MdzcSCEDfXUWKSyxQLUNeDIjnWta(jWRCsxanswSezNRwShQFLDsixnhV), 
			ControllerType.Mouse => MdzcSCEDfXUWKSyxQLUNeDIjnWta(MiFwUrdVVdOrWSSAMcWZRrLShqF), 
			ControllerType.Custom => MdzcSCEDfXUWKSyxQLUNeDIjnWta(YLsaCuedneTuoHaKQfuOqsFrGYI), 
			_ => throw new NotImplementedException(), 
		};
	}

	private bool uErIGsaCfVrhMzjnvTAimaVcBuDM<T>(IList<T> P_0) where T : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			T val = P_0[i];
			if (val != null && val.GetAnyButton())
			{
				return true;
			}
		}
		return false;
	}

	private bool uErIGsaCfVrhMzjnvTAimaVcBuDM(Controller P_0)
	{
		return P_0?.GetAnyButton() ?? false;
	}

	private bool uEcGaHgkKaQepEeRRYIyaETDGsiR<T>(IList<T> P_0) where T : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			T val = P_0[i];
			if (val != null && val.GetAnyButtonDown())
			{
				return true;
			}
		}
		return false;
	}

	private bool uEcGaHgkKaQepEeRRYIyaETDGsiR(Controller P_0)
	{
		return P_0?.GetAnyButtonDown() ?? false;
	}

	private bool UOlkBNWKtHFJwsNGRxGVpAsaAmeb<T>(IList<T> P_0) where T : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			T val = P_0[i];
			if (val != null && val.GetAnyButtonUp())
			{
				return true;
			}
		}
		return false;
	}

	private bool UOlkBNWKtHFJwsNGRxGVpAsaAmeb(Controller P_0)
	{
		return P_0?.GetAnyButtonUp() ?? false;
	}

	private bool PplchENCbauLcPKcNgQefbauMVmA<T>(IList<T> P_0) where T : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			T val = P_0[i];
			if (val != null && val.GetAnyButtonChanged())
			{
				return true;
			}
		}
		return false;
	}

	private bool PplchENCbauLcPKcNgQefbauMVmA(Controller P_0)
	{
		return P_0?.GetAnyButtonChanged() ?? false;
	}

	private bool MdzcSCEDfXUWKSyxQLUNeDIjnWta<T>(IList<T> P_0) where T : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			T val = P_0[i];
			if (val != null && val.GetAnyButtonPrev())
			{
				return true;
			}
		}
		return false;
	}

	private bool MdzcSCEDfXUWKSyxQLUNeDIjnWta(Controller P_0)
	{
		return P_0?.GetAnyButtonPrev() ?? false;
	}

	public Controller EgFZYQxVBCCUzptkFaEGSYRVBNb()
	{
		Controller lastController = null;
		double lastTime = 0.0;
		InputTools.CompareLastActiveController(MiFwUrdVVdOrWSSAMcWZRrLShqF, ref lastController, ref lastTime);
		InputTools.CompareLastActiveController(jWRCsxanswSezNRwShQFLDsixnhV, ref lastController, ref lastTime);
		IList<Joystick> list = xjRsnHvlapakrytsrYIhPkNLNRp;
		for (int i = 0; i < joystickCount; i++)
		{
			InputTools.CompareLastActiveController(list[i], ref lastController, ref lastTime);
		}
		IList<CustomController> yLsaCuedneTuoHaKQfuOqsFrGYI = YLsaCuedneTuoHaKQfuOqsFrGYI;
		for (int j = 0; j < customControllerCount; j++)
		{
			InputTools.CompareLastActiveController(yLsaCuedneTuoHaKQfuOqsFrGYI[j], ref lastController, ref lastTime);
		}
		if (lastController == null)
		{
			lastController = jWRCsxanswSezNRwShQFLDsixnhV;
		}
		return lastController;
	}

	public Controller EgFZYQxVBCCUzptkFaEGSYRVBNb(ControllerType P_0)
	{
		Controller lastController = null;
		double lastTime = 0.0;
		switch (P_0)
		{
		case ControllerType.Joystick:
		{
			int count = xjRsnHvlapakrytsrYIhPkNLNRp.Count;
			for (int j = 0; j < count; j++)
			{
				InputTools.CompareLastActiveController(xjRsnHvlapakrytsrYIhPkNLNRp[j], ref lastController, ref lastTime);
			}
			break;
		}
		case ControllerType.Keyboard:
			return Keyboard;
		case ControllerType.Mouse:
			return Mouse;
		case ControllerType.Custom:
		{
			int count = YLsaCuedneTuoHaKQfuOqsFrGYI.Count;
			for (int i = 0; i < count; i++)
			{
				InputTools.CompareLastActiveController(YLsaCuedneTuoHaKQfuOqsFrGYI[i], ref lastController, ref lastTime);
			}
			break;
		}
		default:
			throw new NotImplementedException();
		}
		return lastController;
	}

	public T EgFZYQxVBCCUzptkFaEGSYRVBNb<T>() where T : Controller
	{
		Type typeFromHandle = typeof(T);
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
		{
			return EgFZYQxVBCCUzptkFaEGSYRVBNb(ControllerType.Joystick) as T;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
		{
			return EgFZYQxVBCCUzptkFaEGSYRVBNb(ControllerType.Keyboard) as T;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
		{
			return EgFZYQxVBCCUzptkFaEGSYRVBNb(ControllerType.Custom) as T;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
		{
			return EgFZYQxVBCCUzptkFaEGSYRVBNb(ControllerType.Mouse) as T;
		}
		throw new NotImplementedException();
	}

	public ControllerType CjgErvTVJOUFVnarHAVzmHSrpBV()
	{
		return EgFZYQxVBCCUzptkFaEGSYRVBNb()?.type ?? ControllerType.Keyboard;
	}

	public void MvGborIExmOgobVmPUOPCDhRdZd(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 != null)
		{
			ALMCJmjXSjdHiZhMwzlPasRpIhSm = true;
			GNgFvzxbbvwUIwKwzpEmtKPvAou.AQeAdoXJFyqgYIAsEfWzTzTehBE(P_0);
		}
	}

	public void MvGborIExmOgobVmPUOPCDhRdZd(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 != null)
		{
			ALMCJmjXSjdHiZhMwzlPasRpIhSm = true;
			GNgFvzxbbvwUIwKwzpEmtKPvAou.AQeAdoXJFyqgYIAsEfWzTzTehBE(P_0, P_1);
		}
	}

	public void CjdNlmspnwRwPMzNTWWEMLksHWK(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 != null)
		{
			GNgFvzxbbvwUIwKwzpEmtKPvAou.vDkdKZRqfADRNJbbzNLIqsdVUyq(P_0);
		}
	}

	public void rODMHhGlRsmkAmXMAUOhEStVaYW(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 != null)
		{
			GNgFvzxbbvwUIwKwzpEmtKPvAou.vDkdKZRqfADRNJbbzNLIqsdVUyq(P_0, P_1);
		}
	}

	public void rBtCdQwOhFJaLVTaHeAeaGEBcRb()
	{
		GNgFvzxbbvwUIwKwzpEmtKPvAou.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
	}

	public void MvGborIExmOgobVmPUOPCDhRdZd(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		if (P_0 == 9999999)
		{
			OgHWugKJErqeioVzrYOnRjVKEKO.AQeAdoXJFyqgYIAsEfWzTzTehBE(P_1);
		}
		else
		{
			if ((uint)P_0 >= (uint)rljhPROQGamuMpXWYzbmAtgdSOJ)
			{
				return;
			}
			QOhFsEysugPfMjVlpIrKthsBAbCJ[P_0].AQeAdoXJFyqgYIAsEfWzTzTehBE(P_1);
		}
		ALMCJmjXSjdHiZhMwzlPasRpIhSm = true;
	}

	public void MvGborIExmOgobVmPUOPCDhRdZd(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
	{
		if (P_1 == null)
		{
			return;
		}
		if (P_0 == 9999999)
		{
			OgHWugKJErqeioVzrYOnRjVKEKO.AQeAdoXJFyqgYIAsEfWzTzTehBE(P_1, P_2);
		}
		else
		{
			if ((uint)P_0 >= (uint)rljhPROQGamuMpXWYzbmAtgdSOJ)
			{
				return;
			}
			QOhFsEysugPfMjVlpIrKthsBAbCJ[P_0].AQeAdoXJFyqgYIAsEfWzTzTehBE(P_1, P_2);
		}
		ALMCJmjXSjdHiZhMwzlPasRpIhSm = true;
	}

	public void CjdNlmspnwRwPMzNTWWEMLksHWK(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 != null)
		{
			if (P_0 == 9999999)
			{
				OgHWugKJErqeioVzrYOnRjVKEKO.vDkdKZRqfADRNJbbzNLIqsdVUyq(P_1);
			}
			else if ((uint)P_0 < (uint)rljhPROQGamuMpXWYzbmAtgdSOJ)
			{
				QOhFsEysugPfMjVlpIrKthsBAbCJ[P_0].vDkdKZRqfADRNJbbzNLIqsdVUyq(P_1);
			}
		}
	}

	public void CjdNlmspnwRwPMzNTWWEMLksHWK(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
	{
		if (P_1 != null)
		{
			if (P_0 == 9999999)
			{
				OgHWugKJErqeioVzrYOnRjVKEKO.vDkdKZRqfADRNJbbzNLIqsdVUyq(P_1, P_2);
			}
			else if ((uint)P_0 < (uint)rljhPROQGamuMpXWYzbmAtgdSOJ)
			{
				QOhFsEysugPfMjVlpIrKthsBAbCJ[P_0].vDkdKZRqfADRNJbbzNLIqsdVUyq(P_1, P_2);
			}
		}
	}

	public void rBtCdQwOhFJaLVTaHeAeaGEBcRb(int P_0)
	{
		if (P_0 == 9999999)
		{
			OgHWugKJErqeioVzrYOnRjVKEKO.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
		}
		else if ((uint)P_0 < (uint)rljhPROQGamuMpXWYzbmAtgdSOJ)
		{
			QOhFsEysugPfMjVlpIrKthsBAbCJ[P_0].dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
		}
	}

	private void lvNsaOnwLjNjBPewEMHNhTzZQZO()
	{
		if (GNgFvzxbbvwUIwKwzpEmtKPvAou.EsOGFOZGwjVjaCHcIWhFnbpPHFs > 0)
		{
			GNgFvzxbbvwUIwKwzpEmtKPvAou.XFnfCoBjwaPKUyFbQTzuBuzwuTkN(-1, EgFZYQxVBCCUzptkFaEGSYRVBNb(), EgFZYQxVBCCUzptkFaEGSYRVBNb(ControllerType.Joystick), EgFZYQxVBCCUzptkFaEGSYRVBNb(ControllerType.Custom));
		}
		if (OgHWugKJErqeioVzrYOnRjVKEKO.EsOGFOZGwjVjaCHcIWhFnbpPHFs > 0)
		{
			Player.ControllerHelper controllers = USfldASbLlPourbEtKfoowSEGgo.InehxVsbhjanyOASwkbyVFduGgO().controllers;
			OgHWugKJErqeioVzrYOnRjVKEKO.XFnfCoBjwaPKUyFbQTzuBuzwuTkN(9999999, controllers.GetLastActiveController(), controllers.GetLastActiveController(ControllerType.Joystick), controllers.GetLastActiveController(ControllerType.Custom));
		}
		for (int i = 0; i < rljhPROQGamuMpXWYzbmAtgdSOJ; i++)
		{
			if (QOhFsEysugPfMjVlpIrKthsBAbCJ[i].EsOGFOZGwjVjaCHcIWhFnbpPHFs != 0)
			{
				Player.ControllerHelper controllers2 = USfldASbLlPourbEtKfoowSEGgo.Players_orig[i].controllers;
				QOhFsEysugPfMjVlpIrKthsBAbCJ[i].XFnfCoBjwaPKUyFbQTzuBuzwuTkN(i, controllers2.GetLastActiveController(), controllers2.GetLastActiveController(ControllerType.Joystick), controllers2.GetLastActiveController(ControllerType.Custom));
			}
		}
	}

	public void GhZnlbNKooLhPxyEkNBqwGgpeKr(ThrottleCalibrationMode P_0)
	{
		for (int i = 0; i < xjRsnHvlapakrytsrYIhPkNLNRp.Count; i++)
		{
			if (xjRsnHvlapakrytsrYIhPkNLNRp[i] != null)
			{
				GhZnlbNKooLhPxyEkNBqwGgpeKr(xjRsnHvlapakrytsrYIhPkNLNRp[i], P_0);
			}
		}
		for (int j = 0; j < SCfCzwjnjXDBqAQKAXdcIXDCmYc.Count; j++)
		{
			if (SCfCzwjnjXDBqAQKAXdcIXDCmYc[j] != null)
			{
				GhZnlbNKooLhPxyEkNBqwGgpeKr(SCfCzwjnjXDBqAQKAXdcIXDCmYc[j], P_0);
			}
		}
		for (int k = 0; k < customControllerCount; k++)
		{
			if (YLsaCuedneTuoHaKQfuOqsFrGYI[k] != null)
			{
				GhZnlbNKooLhPxyEkNBqwGgpeKr(YLsaCuedneTuoHaKQfuOqsFrGYI[k], P_0);
			}
		}
		GhZnlbNKooLhPxyEkNBqwGgpeKr(MiFwUrdVVdOrWSSAMcWZRrLShqF, P_0);
	}

	private void GhZnlbNKooLhPxyEkNBqwGgpeKr(ControllerWithAxes P_0, ThrottleCalibrationMode P_1)
	{
		IList<Controller.Axis> axes = P_0.Axes;
		for (int i = 0; i < P_0.axisCount; i++)
		{
			if (axes[i].tfkhmJMDJkUYFJkJuabHOpbuotU._specialAxisType == SpecialAxisType.Throttle)
			{
				P_0.calibrationMap.Axes[i].calibrationMode = EnumConverter.ToAlternateAxisCalibrationType(P_1);
			}
		}
	}

	public IList<T> XSPVJndKfUtJgYwHcgLhaPazdky<T>() where T : IControllerTemplate
	{
		return DKDPSzxAYGPHIdvhCTFjPnGPODE.PoxNLyEKfLBqvaizvkvHcJnPXMDH<T>();
	}

	private void EJpmrTgGvrhKjJnkpXbomYBpQTQ(List<InputBehavior> P_0)
	{
		bmLEnbkKNrTNSFrbOCrmcDPSGZKL = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL;
		USfldASbLlPourbEtKfoowSEGgo = ReInput.USfldASbLlPourbEtKfoowSEGgo;
		xjRsnHvlapakrytsrYIhPkNLNRp = new List<Joystick>();
		SCfCzwjnjXDBqAQKAXdcIXDCmYc = new List<Joystick>();
		YLsaCuedneTuoHaKQfuOqsFrGYI = new List<CustomController>();
		VWqacxenovIReLxkURhOECDvYfGs = bmLEnbkKNrTNSFrbOCrmcDPSGZKL.actionCount;
		rljhPROQGamuMpXWYzbmAtgdSOJ = USfldASbLlPourbEtKfoowSEGgo.gamePlayerCount;
		IFpGeMedzJbtotzIWCUejfgMbxwU = ZxIIpnvdIfDfpDGNahjIbpZGMWG;
		rqTGMBiIZUdCiQgkavfAfOsTzvY = 0;
		MAPYOCBxzAVdryWxrzLWRrrutBJ = new ADictionary<int, eLdjcNWnzlUUdzfBtBbgCpokXPDR>();
		MAPYOCBxzAVdryWxrzLWRrrutBJ.Add(ReInput.players.GetSystemPlayer().id, new eLdjcNWnzlUUdzfBtBbgCpokXPDR(P_0));
		IList<Player> players = ReInput.players.Players;
		for (int i = 0; i < players.Count; i++)
		{
			MAPYOCBxzAVdryWxrzLWRrrutBJ.Add(players[i].id, new eLdjcNWnzlUUdzfBtBbgCpokXPDR(P_0));
		}
		vHTqzMaMhxMcjfnMDWYDZYYBqRg = new ReadOnlyCollection<Joystick>(xjRsnHvlapakrytsrYIhPkNLNRp);
		zvRqIGakMdSBrtKymEBsnKZSxRU = new ReadOnlyCollection<CustomController>(YLsaCuedneTuoHaKQfuOqsFrGYI);
		dSBGNfhWmOBnJhxggXIGiXSpFLdE.vmSPQzZKqmITEagAYqDGuSxIOIQ(SRJmkvsqkiIalkRkItQQVjlCCTY);
		TSrxbVQejeAztUxGvxbSMoujSqS = new dSBGNfhWmOBnJhxggXIGiXSpFLdE[(rljhPROQGamuMpXWYzbmAtgdSOJ + 1) * VWqacxenovIReLxkURhOECDvYfGs];
		int num = 0;
		YUaChOqWbFXMhmqFLMUnEdCoulm = new dSBGNfhWmOBnJhxggXIGiXSpFLdE[VWqacxenovIReLxkURhOECDvYfGs];
		for (int j = 0; j < VWqacxenovIReLxkURhOECDvYfGs; j++)
		{
			InputAction inputAction = bmLEnbkKNrTNSFrbOCrmcDPSGZKL.VXeLAnoWliGcHOyDxpnQUgYcpQB(j);
			InputBehavior inputBehavior = MAPYOCBxzAVdryWxrzLWRrrutBJ[9999999].IrKXInWReiueMYDtLnljczPLpxC(inputAction.behaviorId);
			dSBGNfhWmOBnJhxggXIGiXSpFLdE dSBGNfhWmOBnJhxggXIGiXSpFLdE2 = new dSBGNfhWmOBnJhxggXIGiXSpFLdE(9999999, inputAction, inputBehavior, SRJmkvsqkiIalkRkItQQVjlCCTY);
			YUaChOqWbFXMhmqFLMUnEdCoulm[j] = dSBGNfhWmOBnJhxggXIGiXSpFLdE2;
			TSrxbVQejeAztUxGvxbSMoujSqS[num] = dSBGNfhWmOBnJhxggXIGiXSpFLdE2;
			num++;
		}
		pGlGMThJXXyXoHHIshZCedYqWIlc = new dSBGNfhWmOBnJhxggXIGiXSpFLdE[rljhPROQGamuMpXWYzbmAtgdSOJ, VWqacxenovIReLxkURhOECDvYfGs];
		for (int k = 0; k < rljhPROQGamuMpXWYzbmAtgdSOJ; k++)
		{
			for (int l = 0; l < VWqacxenovIReLxkURhOECDvYfGs; l++)
			{
				InputAction inputAction2 = bmLEnbkKNrTNSFrbOCrmcDPSGZKL.VXeLAnoWliGcHOyDxpnQUgYcpQB(l);
				InputBehavior inputBehavior2 = MAPYOCBxzAVdryWxrzLWRrrutBJ[players[k].id].IrKXInWReiueMYDtLnljczPLpxC(inputAction2.behaviorId);
				dSBGNfhWmOBnJhxggXIGiXSpFLdE dSBGNfhWmOBnJhxggXIGiXSpFLdE3 = new dSBGNfhWmOBnJhxggXIGiXSpFLdE(k, inputAction2, inputBehavior2, SRJmkvsqkiIalkRkItQQVjlCCTY);
				pGlGMThJXXyXoHHIshZCedYqWIlc[k, l] = dSBGNfhWmOBnJhxggXIGiXSpFLdE3;
				TSrxbVQejeAztUxGvxbSMoujSqS[num] = dSBGNfhWmOBnJhxggXIGiXSpFLdE3;
				num++;
			}
		}
		IList<Player_Editor> players_readOnly = ReInput.UserData.Players_readOnly;
		if (players_readOnly == null)
		{
			throw new ArgumentNullException("Players cannot be null!");
		}
		for (int m = 0; m < players_readOnly.Count; m++)
		{
			List<Player_Editor.CreateControllerInfo> startingCustomControllers = players_readOnly[m].startingCustomControllers;
			if (startingCustomControllers == null)
			{
				continue;
			}
			for (int n = 0; n < startingCustomControllers.Count; n++)
			{
				CustomController customController = EEXCNqgVpUfeLKZrirmWsCPeGFli(startingCustomControllers[n].sourceId);
				if (customController != null)
				{
					customController.tag = startingCustomControllers[n].tag;
					int num2 = ((m == 0) ? 9999999 : (m - 1));
					USfldASbLlPourbEtKfoowSEGgo.FgvPueKchdieOiiAPcILDqNkmwJD(num2)?.controllers.ZeNcCgUkWoGJZAZOLSbHwfsXHTq(customController, false);
				}
			}
		}
		vRdLFtMLqmNBuvjIjgTaYneHDyD = new PVHhzgaKOpHvKspvDHsmQsKUzPh();
		cKjpkowFHdILyMjtVAzICxgZemI = new PVHhzgaKOpHvKspvDHsmQsKUzPh[rljhPROQGamuMpXWYzbmAtgdSOJ];
		for (int num3 = 0; num3 < rljhPROQGamuMpXWYzbmAtgdSOJ; num3++)
		{
			cKjpkowFHdILyMjtVAzICxgZemI[num3] = new PVHhzgaKOpHvKspvDHsmQsKUzPh();
		}
		GNgFvzxbbvwUIwKwzpEmtKPvAou = new global::dhyYkrDfPmnKIWJlTBAqTODKFpsG<ActiveControllerChangedDelegate>();
		OgHWugKJErqeioVzrYOnRjVKEKO = new global::dhyYkrDfPmnKIWJlTBAqTODKFpsG<PlayerActiveControllerChangedDelegate>();
		QOhFsEysugPfMjVlpIrKthsBAbCJ = new global::dhyYkrDfPmnKIWJlTBAqTODKFpsG<PlayerActiveControllerChangedDelegate>[USfldASbLlPourbEtKfoowSEGgo.gamePlayerCount];
		ArrayTools.Populate(QOhFsEysugPfMjVlpIrKthsBAbCJ);
	}

	private void CKBLcZRRtsaeKlCrCqpMuVAsbOo(UpdateLoopType P_0)
	{
		int count = xjRsnHvlapakrytsrYIhPkNLNRp.Count;
		for (int i = 0; i < count; i++)
		{
			Joystick joystick = xjRsnHvlapakrytsrYIhPkNLNRp[i];
			if (joystick.enabled)
			{
				GwdNvASrVYFlqIQiQILORoItHLH(joystick.inputManagerId, joystick.ebxBmtwxyRprAbJBnnRdvbVCKbL);
				joystick.qLvftnPJXcUYQsqiHkMAPRekFwO(P_0);
			}
		}
		if (jWRCsxanswSezNRwShQFLDsixnhV.enabled)
		{
			jWRCsxanswSezNRwShQFLDsixnhV.qLvftnPJXcUYQsqiHkMAPRekFwO(P_0);
		}
		else if (DBibHQQRifdUpWAxGQiYCmvSEMn)
		{
			jWRCsxanswSezNRwShQFLDsixnhV.gkZMTNuuOHGkOJFzBnsouHaoKMr(P_0);
		}
		if (MiFwUrdVVdOrWSSAMcWZRrLShqF.enabled)
		{
			MiFwUrdVVdOrWSSAMcWZRrLShqF.qLvftnPJXcUYQsqiHkMAPRekFwO(P_0);
		}
		int count2 = YLsaCuedneTuoHaKQfuOqsFrGYI.Count;
		for (int j = 0; j < count2; j++)
		{
			CustomController customController = YLsaCuedneTuoHaKQfuOqsFrGYI[j];
			if (customController.enabled)
			{
				customController.GVyzsgBcNtCKXvPCYEVnrvtmvVp();
				customController.qLvftnPJXcUYQsqiHkMAPRekFwO(P_0);
			}
		}
	}

	private void hMGDovNjfsTREnzqquxQRlFbqAq(UpdateLoopType P_0)
	{
		dSBGNfhWmOBnJhxggXIGiXSpFLdE.yYtCAhIquEbBOKtXcLzOaAnecRTE(P_0);
		Player[] allPlayers_orig = USfldASbLlPourbEtKfoowSEGgo.AllPlayers_orig;
		int num = allPlayers_orig.Length;
		bool enabled = jWRCsxanswSezNRwShQFLDsixnhV.enabled;
		if (enabled)
		{
			for (int i = 0; i < num; i++)
			{
				IList<KeyboardMap> maps = allPlayers_orig[i].controllers.maps.GetMaps<KeyboardMap>(0);
				int count = maps.Count;
				for (int j = 0; j < count; j++)
				{
					if (maps[j].enabled)
					{
						QobUucNKiJirDRNPebFhTZgRwit.mLBCyqzoqrEYNeyfbtuaqqyPECu(maps[j]);
					}
				}
			}
		}
		bool enabled2 = MiFwUrdVVdOrWSSAMcWZRrLShqF.enabled;
		for (int k = 0; k < num; k++)
		{
			Player.ControllerHelper controllers = allPlayers_orig[k].controllers;
			controllers.xAZfWMceZkUxrmChMHDWkCtOCNSs(IFpGeMedzJbtotzIWCUejfgMbxwU);
			if (enabled || DBibHQQRifdUpWAxGQiYCmvSEMn)
			{
				controllers.IYekLagvIXUzYjPByyngxUUfTmq(jWRCsxanswSezNRwShQFLDsixnhV, QobUucNKiJirDRNPebFhTZgRwit, IFpGeMedzJbtotzIWCUejfgMbxwU);
			}
			if (enabled2)
			{
				controllers.RrINqnuZWxMDgWXyTsAnckxvUBk(MiFwUrdVVdOrWSSAMcWZRrLShqF, IFpGeMedzJbtotzIWCUejfgMbxwU);
			}
			controllers.xaMDqwsWxRUBpkAPaAMYPpwCPVr(IFpGeMedzJbtotzIWCUejfgMbxwU);
		}
		for (int l = 0; l < TSrxbVQejeAztUxGvxbSMoujSqS.Length; l++)
		{
			if (TSrxbVQejeAztUxGvxbSMoujSqS[l].RiGXprroBUtILpwRLFsBXFflBhS != dSBGNfhWmOBnJhxggXIGiXSpFLdE.ZokPvEPpGPbZixpzdMyWwRVcNWx.cUhrPrhdTFLhvqHJHOLHrPrInNm)
			{
				TSrxbVQejeAztUxGvxbSMoujSqS[l].vvkCMKLUhZHDFkNfnGNwimTKnnwq();
			}
		}
		dSBGNfhWmOBnJhxggXIGiXSpFLdE.xOOMkwRyMBBVqDgOCtdZuEfvbDn();
		if (!CwWMDXJLnZyjgHkoEXvDlKGJKbr)
		{
			return;
		}
		if (vRdLFtMLqmNBuvjIjgTaYneHDyD.oTMfnUFSDYkBxxDhZXhMeSpBMuJB > 0)
		{
			for (int m = 0; m < VWqacxenovIReLxkURhOECDvYfGs; m++)
			{
				dSBGNfhWmOBnJhxggXIGiXSpFLdE dSBGNfhWmOBnJhxggXIGiXSpFLdE2 = YUaChOqWbFXMhmqFLMUnEdCoulm[m];
				if (dSBGNfhWmOBnJhxggXIGiXSpFLdE2.RiGXprroBUtILpwRLFsBXFflBhS != dSBGNfhWmOBnJhxggXIGiXSpFLdE.ZokPvEPpGPbZixpzdMyWwRVcNWx.cUhrPrhdTFLhvqHJHOLHrPrInNm)
				{
					vRdLFtMLqmNBuvjIjgTaYneHDyD.VUnKBfDOoQrNzLmkpdEWrOcmgOpa(dSBGNfhWmOBnJhxggXIGiXSpFLdE2, P_0);
				}
			}
		}
		for (int n = 0; n < rljhPROQGamuMpXWYzbmAtgdSOJ; n++)
		{
			PVHhzgaKOpHvKspvDHsmQsKUzPh pVHhzgaKOpHvKspvDHsmQsKUzPh = cKjpkowFHdILyMjtVAzICxgZemI[n];
			if (pVHhzgaKOpHvKspvDHsmQsKUzPh.oTMfnUFSDYkBxxDhZXhMeSpBMuJB == 0)
			{
				continue;
			}
			for (int num2 = 0; num2 < VWqacxenovIReLxkURhOECDvYfGs; num2++)
			{
				dSBGNfhWmOBnJhxggXIGiXSpFLdE dSBGNfhWmOBnJhxggXIGiXSpFLdE3 = pGlGMThJXXyXoHHIshZCedYqWIlc[n, num2];
				if (dSBGNfhWmOBnJhxggXIGiXSpFLdE3.RiGXprroBUtILpwRLFsBXFflBhS != dSBGNfhWmOBnJhxggXIGiXSpFLdE.ZokPvEPpGPbZixpzdMyWwRVcNWx.cUhrPrhdTFLhvqHJHOLHrPrInNm)
				{
					pVHhzgaKOpHvKspvDHsmQsKUzPh.VUnKBfDOoQrNzLmkpdEWrOcmgOpa(dSBGNfhWmOBnJhxggXIGiXSpFLdE3, P_0);
				}
			}
		}
	}

	private void ZxIIpnvdIfDfpDGNahjIbpZGMWG(bool P_0, int P_1, int P_2)
	{
		int num = bmLEnbkKNrTNSFrbOCrmcDPSGZKL.EZvGxHsqIFFuTapSiFVRnGzgbyW(P_2);
		if (num >= 0)
		{
			if (P_1 == 9999999)
			{
				YUaChOqWbFXMhmqFLMUnEdCoulm[num].clmETOaSnIMZqfuDWIbhRhvcRVgd(P_0);
			}
			else
			{
				pGlGMThJXXyXoHHIshZCedYqWIlc[P_1, num].clmETOaSnIMZqfuDWIbhRhvcRVgd(P_0);
			}
		}
	}

	private void eVTXVPJbvyCHwEfwHsIQiOERmX(BridgedController P_0)
	{
		int num = MWqbcrlIqLMKeJnknbcgCDjJTfQP(P_0.sourceJoystick.rewiredId, ZyZRbCnIBTbNHvCqDENOiYHQYPDr.WbhPDGhsQhtuoeuemyINPoTnEvK);
		if (num >= 0)
		{
			Logger.LogError("Controller was already in connected list!");
			return;
		}
		num = MWqbcrlIqLMKeJnknbcgCDjJTfQP(P_0.sourceJoystick.rewiredId, ZyZRbCnIBTbNHvCqDENOiYHQYPDr.dBmuEUmBrzqrPzCZlujyBJFlBlqD);
		Joystick joystick;
		if (num >= 0)
		{
			joystick = SCfCzwjnjXDBqAQKAXdcIXDCmYc[num];
			SCfCzwjnjXDBqAQKAXdcIXDCmYc.RemoveAt(num);
			joystick.hzVtWbKoxBiVifQXnOxAGNpQbbY(P_0);
			joystick.isConnected = true;
		}
		else
		{
			joystick = new Joystick(P_0);
		}
		xjRsnHvlapakrytsrYIhPkNLNRp.Add(joystick);
		CHKlEkrUfKlWgiWDsEfgfOjSgWs.Add(joystick);
		xjRsnHvlapakrytsrYIhPkNLNRp.Sort(Joystick.mcKQGHDmIrJRGdYIDEXqqnlmnBU);
		DKDPSzxAYGPHIdvhCTFjPnGPODE.HWIjIWHDiHmuObinjAMvEfORTYeM(joystick);
	}

	private void zXAeGDuhTVCbpGhoowuCQOvSOWmn(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (P_0 >= xjRsnHvlapakrytsrYIhPkNLNRp.Count)
		{
			Logger.LogError("Device was not in connected list! Cannot remove!");
			return;
		}
		Joystick joystick = xjRsnHvlapakrytsrYIhPkNLNRp[P_0];
		joystick.isConnected = false;
		if (DEmbVedpYPPKIIIyJpfdClnefDqL != null)
		{
			DEmbVedpYPPKIIIyJpfdClnefDqL(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
		}
		if (OAOtkxlmyVvzmwnjZytgcPdEVMX != null)
		{
			OAOtkxlmyVvzmwnjZytgcPdEVMX(joystick.type, joystick.id);
		}
		xjRsnHvlapakrytsrYIhPkNLNRp.RemoveAt(P_0);
		SCfCzwjnjXDBqAQKAXdcIXDCmYc.Add(joystick);
		CHKlEkrUfKlWgiWDsEfgfOjSgWs.Remove(joystick);
		DKDPSzxAYGPHIdvhCTFjPnGPODE.ugTjZrvDSxPdNxpwLjCweZdZmiz(joystick);
		joystick.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
	}

	private void AaOhUuRGAjXlLAVDBOYqFEXemzy()
	{
		int count = xjRsnHvlapakrytsrYIhPkNLNRp.Count;
		for (int num = count - 1; num >= 0; num--)
		{
			zXAeGDuhTVCbpGhoowuCQOvSOWmn(num);
		}
	}

	private bool ZeNcCgUkWoGJZAZOLSbHwfsXHTq(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		for (int i = 0; i < YLsaCuedneTuoHaKQfuOqsFrGYI.Count; i++)
		{
			if (YLsaCuedneTuoHaKQfuOqsFrGYI[i] == P_0)
			{
				return true;
			}
		}
		YLsaCuedneTuoHaKQfuOqsFrGYI.Add(P_0);
		CHKlEkrUfKlWgiWDsEfgfOjSgWs.Add(P_0);
		DKDPSzxAYGPHIdvhCTFjPnGPODE.HWIjIWHDiHmuObinjAMvEfORTYeM(P_0);
		return true;
	}

	private bool TPBQzKwhRwfWtmCNVYcejNFNlGQ(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		DKDPSzxAYGPHIdvhCTFjPnGPODE.ugTjZrvDSxPdNxpwLjCweZdZmiz(P_0);
		CHKlEkrUfKlWgiWDsEfgfOjSgWs.Remove(P_0);
		return YLsaCuedneTuoHaKQfuOqsFrGYI.Remove(P_0);
	}

	private PVHhzgaKOpHvKspvDHsmQsKUzPh cujyGfzXYFQAPmpiGJVdNocOPvB(int P_0)
	{
		if (P_0 == 9999999)
		{
			return vRdLFtMLqmNBuvjIjgTaYneHDyD;
		}
		if (P_0 < 0 || P_0 >= ReInput.USfldASbLlPourbEtKfoowSEGgo.gamePlayerCount)
		{
			return null;
		}
		return cKjpkowFHdILyMjtVAzICxgZemI[P_0];
	}

	private void himblVluqbrWTOIPWeZAcXEarRP(bool P_0)
	{
		if (!P_0)
		{
			QobUucNKiJirDRNPebFhTZgRwit.sQOZyACQNEauvjgVcNCmUCXMaLX();
		}
	}

	private void WYmLDaFUlNQSFcnYqPRibopaGWP(bool P_0)
	{
		if (!P_0 && !ReInput.applicationRunInBackground)
		{
			for (int i = 0; i < xjRsnHvlapakrytsrYIhPkNLNRp.Count; i++)
			{
				xjRsnHvlapakrytsrYIhPkNLNRp[i].StopVibration();
			}
		}
	}

	public void Dispose()
	{
		TKtGozqoOtxUzimyRPnpCnmqxwZ(true);
		GC.SuppressFinalize(this);
	}

	~ChYhaBSijJnTpdXwQSqYJssvGND()
	{
		TKtGozqoOtxUzimyRPnpCnmqxwZ(false);
	}

	private void TKtGozqoOtxUzimyRPnpCnmqxwZ(bool P_0)
	{
		if (jgbpvYJovPcfzmcAEJzdxdrBmcm)
		{
			return;
		}
		if (P_0)
		{
			if (GNSjyBJEkiLwVbuRSlSZoEKBDyQg is IDisposable)
			{
				(GNSjyBJEkiLwVbuRSlSZoEKBDyQg as IDisposable).Dispose();
			}
			if (lFpwQxUJRsCiNyogVelsiPafwny is IDisposable)
			{
				(lFpwQxUJRsCiNyogVelsiPafwny as IDisposable).Dispose();
			}
		}
		jgbpvYJovPcfzmcAEJzdxdrBmcm = true;
	}
}
