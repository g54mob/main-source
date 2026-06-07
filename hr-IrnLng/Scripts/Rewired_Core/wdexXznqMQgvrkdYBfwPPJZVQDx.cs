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

internal sealed class wdexXznqMQgvrkdYBfwPPJZVQDx : IDisposable
{
	public enum hbPDZOCSuXiheOvMjbSBMPtfSCE
	{
		qHVcGhKvPuKymhkYhwLQLNBDMPo = 0,
		TOIglsDSYqeGLcutualzaXwPStSU = 1
	}

	private class SgJxHfuWnKMjzGaItUgkhpeycFMH
	{
		public ADictionary<int, InputBehavior> lzZBwAKNPsUaSIywjNiGInbihBW;

		public List<InputBehavior> NjLrcxmsMFKBjPvxolrqYGyaxxm;

		public IList<InputBehavior> CrWcevJmuobqmfWdEvQgopsbCVKA;

		public SgJxHfuWnKMjzGaItUgkhpeycFMH(List<InputBehavior> behaviors)
		{
			NjLrcxmsMFKBjPvxolrqYGyaxxm = new List<InputBehavior>(behaviors.Count);
			lzZBwAKNPsUaSIywjNiGInbihBW = new ADictionary<int, InputBehavior>();
			int num = 0;
			for (int i = 0; i < behaviors.Count; i++)
			{
				InputBehavior inputBehavior = behaviors[i].Clone();
				lzZBwAKNPsUaSIywjNiGInbihBW.Add(behaviors[i].id, inputBehavior);
				NjLrcxmsMFKBjPvxolrqYGyaxxm.Add(inputBehavior);
				num++;
			}
			CrWcevJmuobqmfWdEvQgopsbCVKA = new ReadOnlyCollection<InputBehavior>(NjLrcxmsMFKBjPvxolrqYGyaxxm);
		}

		public InputBehavior auqjpNrMPzeNGPWFKBdgotuznwq(int P_0)
		{
			if (NjLrcxmsMFKBjPvxolrqYGyaxxm.Count == 0)
			{
				return null;
			}
			lzZBwAKNPsUaSIywjNiGInbihBW.TryGetValue(P_0, out var value);
			if (value == null)
			{
				return NjLrcxmsMFKBjPvxolrqYGyaxxm[0];
			}
			return value;
		}
	}

	private sealed class oYAUpFHjWpbAJdrNbMeOdDNkVIL : IDisposable, IEnumerator, IEnumerable, IEnumerable<CustomController>, IEnumerator<CustomController>
	{
		private CustomController WCNlIsEdYuVTqbNYvICUPcTebLU;

		private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

		private int dFCUHNznYmJZjnnffQJUVAprSDy;

		public wdexXznqMQgvrkdYBfwPPJZVQDx GxphHAMqMhNBLjnlhXuBQmXaALiE;

		public int bZIiRblPqGwwhturBCTgerjFbxN;

		public int mDUXajpDmsvjxUcgXIkycfpopuQa;

		public int CLJYdfhwCZLnXuYtueNtRuMuDsB;

		public int mHNUnJhfGxhBdbwddNEdzrObqJc;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return WCNlIsEdYuVTqbNYvICUPcTebLU;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return WCNlIsEdYuVTqbNYvICUPcTebLU;
			}
		}

		[DebuggerHidden]
		IEnumerator<CustomController> IEnumerable<CustomController>.GetEnumerator()
		{
			oYAUpFHjWpbAJdrNbMeOdDNkVIL oYAUpFHjWpbAJdrNbMeOdDNkVIL2;
			if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
				oYAUpFHjWpbAJdrNbMeOdDNkVIL2 = this;
			}
			else
			{
				oYAUpFHjWpbAJdrNbMeOdDNkVIL2 = new oYAUpFHjWpbAJdrNbMeOdDNkVIL(0);
				oYAUpFHjWpbAJdrNbMeOdDNkVIL2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
			}
			oYAUpFHjWpbAJdrNbMeOdDNkVIL2.bZIiRblPqGwwhturBCTgerjFbxN = mDUXajpDmsvjxUcgXIkycfpopuQa;
			return oYAUpFHjWpbAJdrNbMeOdDNkVIL2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}

		private bool MoveNext()
		{
			switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
			{
			case 0:
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
				CLJYdfhwCZLnXuYtueNtRuMuDsB = GxphHAMqMhNBLjnlhXuBQmXaALiE.ozMPDGPKrryEoMaiFqmJeoSVQba.Count;
				mHNUnJhfGxhBdbwddNEdzrObqJc = 0;
				goto IL_009d;
			case 1:
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
					goto IL_008f;
				}
				IL_009d:
				if (mHNUnJhfGxhBdbwddNEdzrObqJc >= CLJYdfhwCZLnXuYtueNtRuMuDsB)
				{
					break;
				}
				if (GxphHAMqMhNBLjnlhXuBQmXaALiE.ozMPDGPKrryEoMaiFqmJeoSVQba[mHNUnJhfGxhBdbwddNEdzrObqJc].sourceControllerId == bZIiRblPqGwwhturBCTgerjFbxN)
				{
					WCNlIsEdYuVTqbNYvICUPcTebLU = GxphHAMqMhNBLjnlhXuBQmXaALiE.ozMPDGPKrryEoMaiFqmJeoSVQba[mHNUnJhfGxhBdbwddNEdzrObqJc];
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
					return true;
				}
				goto IL_008f;
				IL_008f:
				mHNUnJhfGxhBdbwddNEdzrObqJc++;
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
		public oYAUpFHjWpbAJdrNbMeOdDNkVIL(int _003C_003E1__state)
		{
			SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
			dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
		}
	}

	private sealed class mZyvrXfzpYWQJSXfsuouitvEfZe : IDisposable, IEnumerator, IEnumerable, IEnumerable<CustomController>, IEnumerator<CustomController>
	{
		private CustomController WCNlIsEdYuVTqbNYvICUPcTebLU;

		private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

		private int dFCUHNznYmJZjnnffQJUVAprSDy;

		public wdexXznqMQgvrkdYBfwPPJZVQDx GxphHAMqMhNBLjnlhXuBQmXaALiE;

		public string jViWlhVTBxhzBmqmOfeiJkFhjZQ;

		public string WQHivsClkQrgkkTRIQoQskwrJmc;

		public int kgEYoRkWZKSSETymYuBwtrNWQl;

		public int JJuEeWjmDlXenqDHBLDEMmDsqHAe;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return WCNlIsEdYuVTqbNYvICUPcTebLU;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return WCNlIsEdYuVTqbNYvICUPcTebLU;
			}
		}

		[DebuggerHidden]
		IEnumerator<CustomController> IEnumerable<CustomController>.GetEnumerator()
		{
			mZyvrXfzpYWQJSXfsuouitvEfZe mZyvrXfzpYWQJSXfsuouitvEfZe2;
			if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
				mZyvrXfzpYWQJSXfsuouitvEfZe2 = this;
			}
			else
			{
				mZyvrXfzpYWQJSXfsuouitvEfZe2 = new mZyvrXfzpYWQJSXfsuouitvEfZe(0);
				mZyvrXfzpYWQJSXfsuouitvEfZe2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
			}
			mZyvrXfzpYWQJSXfsuouitvEfZe2.jViWlhVTBxhzBmqmOfeiJkFhjZQ = WQHivsClkQrgkkTRIQoQskwrJmc;
			return mZyvrXfzpYWQJSXfsuouitvEfZe2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}

		private bool MoveNext()
		{
			switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
			{
			case 0:
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
				kgEYoRkWZKSSETymYuBwtrNWQl = GxphHAMqMhNBLjnlhXuBQmXaALiE.ozMPDGPKrryEoMaiFqmJeoSVQba.Count;
				JJuEeWjmDlXenqDHBLDEMmDsqHAe = 0;
				goto IL_00a3;
			case 1:
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
					goto IL_0095;
				}
				IL_00a3:
				if (JJuEeWjmDlXenqDHBLDEMmDsqHAe >= kgEYoRkWZKSSETymYuBwtrNWQl)
				{
					break;
				}
				if (GxphHAMqMhNBLjnlhXuBQmXaALiE.ozMPDGPKrryEoMaiFqmJeoSVQba[JJuEeWjmDlXenqDHBLDEMmDsqHAe].tag.Equals(jViWlhVTBxhzBmqmOfeiJkFhjZQ, StringComparison.OrdinalIgnoreCase))
				{
					WCNlIsEdYuVTqbNYvICUPcTebLU = GxphHAMqMhNBLjnlhXuBQmXaALiE.ozMPDGPKrryEoMaiFqmJeoSVQba[JJuEeWjmDlXenqDHBLDEMmDsqHAe];
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
					return true;
				}
				goto IL_0095;
				IL_0095:
				JJuEeWjmDlXenqDHBLDEMmDsqHAe++;
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
		public mZyvrXfzpYWQJSXfsuouitvEfZe(int _003C_003E1__state)
		{
			SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
			dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
		}
	}

	private List<Joystick> PwdEInECBiDDjabWgJCuiXatYNFJ;

	private List<Joystick> ywLEiQCiOAobwTWmZbbhQQiuYIC;

	private List<CustomController> ozMPDGPKrryEoMaiFqmJeoSVQba;

	private List<Controller> mjbCXiYvUoMzOxiBvCouhdEikme;

	private ReadOnlyCollection<Controller> whLEdUsXOHOTWnqJCHQcdnkAXLq;

	private Keyboard HkpqDTUFRpMRrOEQVnSMXoFQldZ;

	private Mouse asfRDzSekmvCpHiAVkQLFwtshxJ;

	private ConfigVars kEfTcVPDPtzkvdMGLfLPBGnaUJq;

	private VvbRiPIRRDOGFeaGvZCVmBjRfXT[] jmPQhhdSmzMbfNmhujxPORzPOWc;

	private VvbRiPIRRDOGFeaGvZCVmBjRfXT[] aRIrccLhfOfqfrZCAqEeQcWCSkS;

	private VvbRiPIRRDOGFeaGvZCVmBjRfXT[,] XZFphnyIaSbooGWqtVFLlrzISCP;

	private ZdLBPTHRMdSwGFQpiatZEUsVVDOA qrVEDSepLYqYVSPtpaJcNmLxEsZ;

	private rclcWIXPrkQyKbnNIANjIzDkfpB HoFaqBAdDbKcuzeayPPdDGLgbeza;

	private rclcWIXPrkQyKbnNIANjIzDkfpB[] AoVWIGFmkaussHBpYpzPYXGhmBw;

	private global::RQGiHPimgvjtQJEPCbYrPWcejhA<ActiveControllerChangedDelegate> iuCCmPYpUwwJAvFqqyhfzwePwIY;

	private global::RQGiHPimgvjtQJEPCbYrPWcejhA<PlayerActiveControllerChangedDelegate> gjhHVIbZboONefLBoeKyJgkoHYad;

	private global::RQGiHPimgvjtQJEPCbYrPWcejhA<PlayerActiveControllerChangedDelegate>[] yLBuXsZVLfoMAulVuEjXxdXxjtm;

	private ADictionary<int, SgJxHfuWnKMjzGaItUgkhpeycFMH> yMltWmasIPwCpdMeapCHJxGEtaz;

	private readonly azjbOeFBgqcQlKHDiWTROdmqZMv dHzdxJGgfVamEigJTrTmGDfvxRqc;

	private IList<Joystick> LvddOeiZGwWTpcucIOYQcVfzoXYv;

	private IList<CustomController> JsfDAuTeDkFfzwAgnsObzjhapta;

	private int uaBIhWveDCamhbrrsgxUvXnYROl;

	private bool rMxEqIvJeWWddFXXpARGQYckQDR;

	private bool mIybkdemYKTOqJCEXLpKRnfrChDv;

	private bool wfkokSoCzafcqgRarzbQkYiZozy;

	private IUnifiedKeyboardSource kDkaXjirHbZFFctlXAEYdkznSkeB;

	private IUnifiedMouseSource LMDDrFpdadEtNxxESOgzcywBrkG;

	private int VwhbnrPNaFbAiXyYtbRRzCVjzTk;

	private uXNRyMOantFPUprJgkJntGqFAgR XVroGTnTmiTwGITDVAhlDMsuaLiG;

	private YOrqWFzXKZXgaAwGZbhDkecGRxO yIRdWijqyghmemPssevxkoxocsUE;

	private int LHXUijdjpnmZGwdcLlrvMfDTDEhg;

	private int jGQlTFOTZwmOauEGXHrDOyuTntc;

	private Action<int, ControllerDataUpdater> gpJkbsjewLmliVKKBOWNXriDJPv;

	private Action<bool, int, int> iYLORkOUOSEEasmcRHMzhlHqunUP;

	private Action<ControllerStatusChangedEventArgs> boUkaKIZrWDvEDSGCebudhCNWFIl;

	private Action<ControllerType, int> kEmCDEOBLWCcttXnEgdrosQqBfn;

	private bool JtZAxieDBYjDdfBgPPJgrNSxYmS;

	public IList<Joystick> Joysticks_readOnly => LvddOeiZGwWTpcucIOYQcVfzoXYv;

	public List<Joystick> Joysticks_orig => PwdEInECBiDDjabWgJCuiXatYNFJ;

	public int joystickCount => PwdEInECBiDDjabWgJCuiXatYNFJ.Count;

	public Mouse Mouse => asfRDzSekmvCpHiAVkQLFwtshxJ;

	public Keyboard Keyboard => HkpqDTUFRpMRrOEQVnSMXoFQldZ;

	public IList<CustomController> CustomControllers_readOnly => JsfDAuTeDkFfzwAgnsObzjhapta;

	public List<CustomController> CustomControllers_orig => ozMPDGPKrryEoMaiFqmJeoSVQba;

	public int customControllerCount => ozMPDGPKrryEoMaiFqmJeoSVQba.Count;

	public IList<Controller> Controllers => whLEdUsXOHOTWnqJCHQcdnkAXLq;

	public int controllerCount => mjbCXiYvUoMzOxiBvCouhdEikme.Count;

	private int nextCustomControllerId
	{
		get
		{
			int vwhbnrPNaFbAiXyYtbRRzCVjzTk = VwhbnrPNaFbAiXyYtbRRzCVjzTk;
			VwhbnrPNaFbAiXyYtbRRzCVjzTk++;
			if (VwhbnrPNaFbAiXyYtbRRzCVjzTk >= int.MaxValue)
			{
				VwhbnrPNaFbAiXyYtbRRzCVjzTk = 0;
			}
			return vwhbnrPNaFbAiXyYtbRRzCVjzTk;
		}
	}

	public event Action<ControllerStatusChangedEventArgs> ControllerDisconnectStartedEvent
	{
		add
		{
			boUkaKIZrWDvEDSGCebudhCNWFIl = (Action<ControllerStatusChangedEventArgs>)Delegate.Combine(boUkaKIZrWDvEDSGCebudhCNWFIl, value);
		}
		remove
		{
			boUkaKIZrWDvEDSGCebudhCNWFIl = (Action<ControllerStatusChangedEventArgs>)Delegate.Remove(boUkaKIZrWDvEDSGCebudhCNWFIl, value);
		}
	}

	public event Action<ControllerType, int> JustBeforeControllerFullyDisconnectedEvent
	{
		add
		{
			kEmCDEOBLWCcttXnEgdrosQqBfn = (Action<ControllerType, int>)Delegate.Combine(kEmCDEOBLWCcttXnEgdrosQqBfn, value);
		}
		remove
		{
			kEmCDEOBLWCcttXnEgdrosQqBfn = (Action<ControllerType, int>)Delegate.Remove(kEmCDEOBLWCcttXnEgdrosQqBfn, value);
		}
	}

	public wdexXznqMQgvrkdYBfwPPJZVQDx(ConfigVars configVars, PlatformInputManager inputManager)
	{
		kEfTcVPDPtzkvdMGLfLPBGnaUJq = configVars;
		uaBIhWveDCamhbrrsgxUvXnYROl = 0;
		rMxEqIvJeWWddFXXpARGQYckQDR = UnityTools.isAndroidPlatform;
		mjbCXiYvUoMzOxiBvCouhdEikme = new List<Controller>(10);
		whLEdUsXOHOTWnqJCHQcdnkAXLq = new ReadOnlyCollection<Controller>(mjbCXiYvUoMzOxiBvCouhdEikme);
		IUnifiedKeyboardSource unifiedKeyboardSource = inputManager.GetUnifiedKeyboardSource();
		if (unifiedKeyboardSource == null)
		{
			unifiedKeyboardSource = (kDkaXjirHbZFFctlXAEYdkznSkeB = new UnityUnifiedKeyboardSource());
		}
		HkpqDTUFRpMRrOEQVnSMXoFQldZ = new Keyboard("Keyboard", unifiedKeyboardSource);
		mjbCXiYvUoMzOxiBvCouhdEikme.Add(HkpqDTUFRpMRrOEQVnSMXoFQldZ);
		IUnifiedMouseSource unifiedMouseSource = inputManager.GetUnifiedMouseSource();
		if (unifiedMouseSource == null)
		{
			unifiedMouseSource = (LMDDrFpdadEtNxxESOgzcywBrkG = new UnityUnifiedMouseSource());
		}
		asfRDzSekmvCpHiAVkQLFwtshxJ = new Mouse("Mouse", unifiedMouseSource);
		mjbCXiYvUoMzOxiBvCouhdEikme.Add(asfRDzSekmvCpHiAVkQLFwtshxJ);
		qrVEDSepLYqYVSPtpaJcNmLxEsZ = new ZdLBPTHRMdSwGFQpiatZEUsVVDOA(configVars.updateLoop, HkpqDTUFRpMRrOEQVnSMXoFQldZ);
		HkpqDTUFRpMRrOEQVnSMXoFQldZ.EnabledStateChangedEvent += DoUEHlIyXyKaDNnkDumByicGjjv;
		HkpqDTUFRpMRrOEQVnSMXoFQldZ.enabled = !configVars.GetPlatformVar_disableKeyboard();
		tPpCplvxCBpYIIbYhfvfnqNQfUM.agvWMBoHtblzmgSmVloJbsDkfGk();
		dHzdxJGgfVamEigJTrTmGDfvxRqc = new azjbOeFBgqcQlKHDiWTROdmqZMv(UnityTools.externalTools.GetControllerTemplateTypes(), UnityTools.externalTools.GetControllerTemplateInterfaceTypes());
		dHzdxJGgfVamEigJTrTmGDfvxRqc.ztcXjeonNMANOsnNizYgnnvxcMY(HkpqDTUFRpMRrOEQVnSMXoFQldZ);
		dHzdxJGgfVamEigJTrTmGDfvxRqc.ztcXjeonNMANOsnNizYgnnvxcMY(asfRDzSekmvCpHiAVkQLFwtshxJ);
		ReInput.ApplicationFocusChangedEvent += mmSeCYyGzAcrXjKTdGFrnOLGsGp;
	}

	public void iDBXctPcOcjjzWbKaCnxuPiVNUc(Action<int, ControllerDataUpdater> P_0, List<InputBehavior> P_1)
	{
		gpJkbsjewLmliVKKBOWNXriDJPv = P_0;
		iDBXctPcOcjjzWbKaCnxuPiVNUc(P_1);
	}

	public void iAnBBfDdWbgOiFHwNWqxFDtiXzYA(UpdateLoopType P_0)
	{
		tPpCplvxCBpYIIbYhfvfnqNQfUM.yKnlAOOxoakoftRymnrQvAIGfln(P_0);
		if (HkpqDTUFRpMRrOEQVnSMXoFQldZ.enabled)
		{
			qrVEDSepLYqYVSPtpaJcNmLxEsZ.iAnBBfDdWbgOiFHwNWqxFDtiXzYA(P_0);
		}
		yqbANtBoQbEHUAgHKNxFeobyUQMs(P_0);
		ZjaahTcFObjqKqWJtrgHBvQVVoW(P_0);
		tPpCplvxCBpYIIbYhfvfnqNQfUM.AOQgnFcBlXraMNObOnRwRhydWuOc(P_0, ReInput.currentFrame);
		if (wfkokSoCzafcqgRarzbQkYiZozy)
		{
			PrvLWaYnReqoVYeGLAnIjaAvYju();
		}
	}

	public VvbRiPIRRDOGFeaGvZCVmBjRfXT RBIWoiWucaBtFKDYvIAUOHZykHm(int P_0, string P_1, bool P_2)
	{
		int num = XVroGTnTmiTwGITDVAhlDMsuaLiG.iFNXApJjlWtDZdwedJFKpfGAMok(P_1, P_2);
		if (num < 0)
		{
			return null;
		}
		if (P_0 == 9999999)
		{
			return aRIrccLhfOfqfrZCAqEeQcWCSkS[num];
		}
		if (P_0 < 0 || P_0 >= LHXUijdjpnmZGwdcLlrvMfDTDEhg)
		{
			return null;
		}
		return XZFphnyIaSbooGWqtVFLlrzISCP[P_0, num];
	}

	public VvbRiPIRRDOGFeaGvZCVmBjRfXT RBIWoiWucaBtFKDYvIAUOHZykHm(int P_0, int P_1, bool P_2)
	{
		int num = XVroGTnTmiTwGITDVAhlDMsuaLiG.iFNXApJjlWtDZdwedJFKpfGAMok(P_1, P_2);
		if (num < 0)
		{
			return null;
		}
		if (P_0 == 9999999)
		{
			return aRIrccLhfOfqfrZCAqEeQcWCSkS[num];
		}
		return XZFphnyIaSbooGWqtVFLlrzISCP[P_0, num];
	}

	public void ktuBhGHQjsvnfuwdpgbumZMATxQ(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 != null && P_0.sourceJoystick != null)
		{
			hbPDZOCSuXiheOvMjbSBMPtfSCE hbPDZOCSuXiheOvMjbSBMPtfSCE2 = hbPDZOCSuXiheOvMjbSBMPtfSCE.qHVcGhKvPuKymhkYhwLQLNBDMPo;
			int num = cqUXmPYEHCxLgOfUwaJfVeSndpg(P_0.sourceJoystick.rewiredId, hbPDZOCSuXiheOvMjbSBMPtfSCE2);
			if (num < 0)
			{
				hbPDZOCSuXiheOvMjbSBMPtfSCE2 = hbPDZOCSuXiheOvMjbSBMPtfSCE.TOIglsDSYqeGLcutualzaXwPStSU;
				num = cqUXmPYEHCxLgOfUwaJfVeSndpg(P_0.sourceJoystick.rewiredId, hbPDZOCSuXiheOvMjbSBMPtfSCE2);
			}
			if (num >= 0)
			{
				Joystick joystick = ((hbPDZOCSuXiheOvMjbSBMPtfSCE2 != hbPDZOCSuXiheOvMjbSBMPtfSCE.qHVcGhKvPuKymhkYhwLQLNBDMPo) ? (joystick = ywLEiQCiOAobwTWmZbbhQQiuYIC[num]) : (joystick = PwdEInECBiDDjabWgJCuiXatYNFJ[num]));
				joystick.FMngbHlSISVmcoIhmlrHQoUqlno(P_0);
			}
		}
	}

	public bool VOcmxjbeKhGsODdHjBYoOiwhydKu(int P_0, hbPDZOCSuXiheOvMjbSBMPtfSCE P_1)
	{
		if (cqUXmPYEHCxLgOfUwaJfVeSndpg(P_0, P_1) < 0)
		{
			return false;
		}
		return true;
	}

	public int cqUXmPYEHCxLgOfUwaJfVeSndpg(int P_0, hbPDZOCSuXiheOvMjbSBMPtfSCE P_1)
	{
		switch (P_1)
		{
		case hbPDZOCSuXiheOvMjbSBMPtfSCE.qHVcGhKvPuKymhkYhwLQLNBDMPo:
		{
			int count2 = PwdEInECBiDDjabWgJCuiXatYNFJ.Count;
			for (int j = 0; j < count2; j++)
			{
				if (PwdEInECBiDDjabWgJCuiXatYNFJ[j].id == P_0)
				{
					return j;
				}
			}
			break;
		}
		case hbPDZOCSuXiheOvMjbSBMPtfSCE.TOIglsDSYqeGLcutualzaXwPStSU:
		{
			int count = ywLEiQCiOAobwTWmZbbhQQiuYIC.Count;
			for (int i = 0; i < count; i++)
			{
				if (ywLEiQCiOAobwTWmZbbhQQiuYIC[i].id == P_0)
				{
					return i;
				}
			}
			break;
		}
		}
		return -1;
	}

	public int cqUXmPYEHCxLgOfUwaJfVeSndpg(Guid P_0, hbPDZOCSuXiheOvMjbSBMPtfSCE P_1)
	{
		switch (P_1)
		{
		case hbPDZOCSuXiheOvMjbSBMPtfSCE.qHVcGhKvPuKymhkYhwLQLNBDMPo:
		{
			int count2 = PwdEInECBiDDjabWgJCuiXatYNFJ.Count;
			for (int j = 0; j < count2; j++)
			{
				if (PwdEInECBiDDjabWgJCuiXatYNFJ[j].deviceInstanceGuid == P_0)
				{
					return j;
				}
			}
			break;
		}
		case hbPDZOCSuXiheOvMjbSBMPtfSCE.TOIglsDSYqeGLcutualzaXwPStSU:
		{
			int count = ywLEiQCiOAobwTWmZbbhQQiuYIC.Count;
			for (int i = 0; i < count; i++)
			{
				if (ywLEiQCiOAobwTWmZbbhQQiuYIC[i].deviceInstanceGuid == P_0)
				{
					return i;
				}
			}
			break;
		}
		}
		return -1;
	}

	public bool XUlBqZUMElIlDirEpOyIeJNLzkI(int P_0)
	{
		if (KnaSxGnmCgAHcKyeJoXMIPEWsO(P_0) < 0)
		{
			return false;
		}
		return true;
	}

	public int KnaSxGnmCgAHcKyeJoXMIPEWsO(int P_0)
	{
		int count = ozMPDGPKrryEoMaiFqmJeoSVQba.Count;
		for (int i = 0; i < count; i++)
		{
			if (ozMPDGPKrryEoMaiFqmJeoSVQba[i].id == P_0)
			{
				return i;
			}
		}
		return -1;
	}

	public int KnaSxGnmCgAHcKyeJoXMIPEWsO(Guid P_0)
	{
		int count = ozMPDGPKrryEoMaiFqmJeoSVQba.Count;
		for (int i = 0; i < count; i++)
		{
			if (ozMPDGPKrryEoMaiFqmJeoSVQba[i].deviceInstanceGuid == P_0)
			{
				return i;
			}
		}
		return -1;
	}

	public void kifwqfIoWOaCtFKBcyaxisrThaZv(BridgedController P_0)
	{
		YsdeYfgDmmTgRjRHrZmXYpzqZOt(P_0);
	}

	public void ACEyGymgjawtaxNjGLZPWdlygix(int P_0)
	{
		int num = cqUXmPYEHCxLgOfUwaJfVeSndpg(P_0, hbPDZOCSuXiheOvMjbSBMPtfSCE.qHVcGhKvPuKymhkYhwLQLNBDMPo);
		NNgVpjJBuWeIpHkWrikRmACidIQG(num);
	}

	public int gqYOIAJQKjXYVpEcilQGRCMNcumg()
	{
		return uaBIhWveDCamhbrrsgxUvXnYROl++;
	}

	public IList<InputBehavior> qBAcKkDJYAgrLrUyXSQfoyMaOWli(int P_0)
	{
		if (!yMltWmasIPwCpdMeapCHJxGEtaz.ContainsKey(P_0))
		{
			return new List<InputBehavior>();
		}
		return yMltWmasIPwCpdMeapCHJxGEtaz[P_0].CrWcevJmuobqmfWdEvQgopsbCVKA;
	}

	public InputBehavior tTnDGLKfHmwwnZlLMmzdSgXpidO(int P_0, string P_1)
	{
		if (P_1 == null || P_1 == string.Empty)
		{
			return null;
		}
		int inputBehaviorId = ReInput.mapping.GetInputBehaviorId(P_1);
		return tTnDGLKfHmwwnZlLMmzdSgXpidO(P_0, inputBehaviorId);
	}

	public InputBehavior tTnDGLKfHmwwnZlLMmzdSgXpidO(int P_0, int P_1)
	{
		if (!yMltWmasIPwCpdMeapCHJxGEtaz.ContainsKey(P_0))
		{
			return null;
		}
		IList<InputBehavior> crWcevJmuobqmfWdEvQgopsbCVKA = yMltWmasIPwCpdMeapCHJxGEtaz[P_0].CrWcevJmuobqmfWdEvQgopsbCVKA;
		for (int i = 0; i < crWcevJmuobqmfWdEvQgopsbCVKA.Count; i++)
		{
			if (crWcevJmuobqmfWdEvQgopsbCVKA[i].id == P_1)
			{
				return crWcevJmuobqmfWdEvQgopsbCVKA[i];
			}
		}
		return null;
	}

	public Joystick zCynXQNrFypPOHsukRvftnVVvxv(int P_0, bool P_1 = false)
	{
		int num = cqUXmPYEHCxLgOfUwaJfVeSndpg(P_0, hbPDZOCSuXiheOvMjbSBMPtfSCE.qHVcGhKvPuKymhkYhwLQLNBDMPo);
		if (num >= 0)
		{
			return PwdEInECBiDDjabWgJCuiXatYNFJ[num];
		}
		if (P_1)
		{
			num = cqUXmPYEHCxLgOfUwaJfVeSndpg(P_0, hbPDZOCSuXiheOvMjbSBMPtfSCE.TOIglsDSYqeGLcutualzaXwPStSU);
			if (num >= 0)
			{
				return ywLEiQCiOAobwTWmZbbhQQiuYIC[num];
			}
		}
		return null;
	}

	public Joystick zCynXQNrFypPOHsukRvftnVVvxv(Guid P_0, bool P_1 = false)
	{
		int num = cqUXmPYEHCxLgOfUwaJfVeSndpg(P_0, hbPDZOCSuXiheOvMjbSBMPtfSCE.qHVcGhKvPuKymhkYhwLQLNBDMPo);
		if (num >= 0)
		{
			return PwdEInECBiDDjabWgJCuiXatYNFJ[num];
		}
		if (P_1)
		{
			num = cqUXmPYEHCxLgOfUwaJfVeSndpg(P_0, hbPDZOCSuXiheOvMjbSBMPtfSCE.TOIglsDSYqeGLcutualzaXwPStSU);
			if (num >= 0)
			{
				return ywLEiQCiOAobwTWmZbbhQQiuYIC[num];
			}
		}
		return null;
	}

	public Joystick[] WLxWQIGswHpTuGoGagfoNGpkNUi()
	{
		int count = PwdEInECBiDDjabWgJCuiXatYNFJ.Count;
		if (count == 0)
		{
			return EmptyObjects<Joystick>.array;
		}
		Joystick[] array = new Joystick[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = PwdEInECBiDDjabWgJCuiXatYNFJ[i];
		}
		return array;
	}

	public string[] lzUTlfxjIWCAxVpPYtNqRBHwRnF()
	{
		int count = PwdEInECBiDDjabWgJCuiXatYNFJ.Count;
		if (count == 0)
		{
			return EmptyObjects<string>.array;
		}
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = PwdEInECBiDDjabWgJCuiXatYNFJ[i].name;
		}
		return array;
	}

	public CustomController XLOkGOGTJTTMgVorWpHofbbxLFg(int P_0)
	{
		int num = KnaSxGnmCgAHcKyeJoXMIPEWsO(P_0);
		if (num < 0)
		{
			return null;
		}
		return ozMPDGPKrryEoMaiFqmJeoSVQba[num];
	}

	public CustomController XLOkGOGTJTTMgVorWpHofbbxLFg(Guid P_0)
	{
		int num = KnaSxGnmCgAHcKyeJoXMIPEWsO(P_0);
		if (num < 0)
		{
			return null;
		}
		return ozMPDGPKrryEoMaiFqmJeoSVQba[num];
	}

	public CustomController[] aeriZUDCjjOFEjImDxUcfHiKMmjO()
	{
		int count = ozMPDGPKrryEoMaiFqmJeoSVQba.Count;
		if (count == 0)
		{
			return EmptyObjects<CustomController>.array;
		}
		CustomController[] array = new CustomController[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = ozMPDGPKrryEoMaiFqmJeoSVQba[i];
		}
		return array;
	}

	public string[] ojdLCTeIELScFPQxRSuPvWDcmqi()
	{
		int count = ozMPDGPKrryEoMaiFqmJeoSVQba.Count;
		if (count == 0)
		{
			return EmptyObjects<string>.array;
		}
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = ozMPDGPKrryEoMaiFqmJeoSVQba[i].name;
		}
		return array;
	}

	public CustomController whxNiKHrMFxPJAgBjEgFFOeSlVHA(int P_0)
	{
		CustomController_Editor customControllerById = ReInput.UserData.GetCustomControllerById(P_0);
		if (customControllerById == null)
		{
			return null;
		}
		int sjbjANsWQaKxKgfHgxDuZgoAatr = nextCustomControllerId;
		SSXBUfkgAKBbEgHlAaRyfXKtATAa sSXBUfkgAKBbEgHlAaRyfXKtATAa = new SSXBUfkgAKBbEgHlAaRyfXKtATAa();
		sSXBUfkgAKBbEgHlAaRyfXKtATAa.ahVlanlbOCBOWeBnfSIFVGtHSeq = InputSource.Custom;
		sSXBUfkgAKBbEgHlAaRyfXKtATAa.qROaKKGTWVzDYhhRdQZEfZxsihTO = customControllerById.descriptiveName;
		sSXBUfkgAKBbEgHlAaRyfXKtATAa.CJAZbjwducAKeDXWKNPqtHrxjmK = customControllerById.name;
		sSXBUfkgAKBbEgHlAaRyfXKtATAa.rGEuFEtJcMmFaLOCcsmbRHUjSpy = customControllerById.axisCount;
		sSXBUfkgAKBbEgHlAaRyfXKtATAa.qrXpdbCUzFLCBfjCDTfPHyJCus = customControllerById.buttonCount;
		sSXBUfkgAKBbEgHlAaRyfXKtATAa.sjbjANsWQaKxKgfHgxDuZgoAatr = sjbjANsWQaKxKgfHgxDuZgoAatr;
		sSXBUfkgAKBbEgHlAaRyfXKtATAa.TMsCkWDMcUezxWQMFEJGYJRjUaqu = customControllerById.id;
		sSXBUfkgAKBbEgHlAaRyfXKtATAa.BosaYMINWJilPSeDoArkNCjTJvR = customControllerById.typeGuid;
		sSXBUfkgAKBbEgHlAaRyfXKtATAa.VCpqtEqSaKpqQHTevHyRzIpEfdp = customControllerById.id.ToString();
		sSXBUfkgAKBbEgHlAaRyfXKtATAa.ptorLnNmGaWxfMoJJnQaxSkKksE = customControllerById.yuVTyXTeLkmAEriUUAaddbTLpoaJ();
		SSXBUfkgAKBbEgHlAaRyfXKtATAa data = sSXBUfkgAKBbEgHlAaRyfXKtATAa;
		CustomController customController = new CustomController(data);
		lObdySffSxtSFDoDQQyUyVZrHkI(customController);
		return customController;
	}

	public bool ssSdbGfZnDEhDUWmfPYQOsAGwMx(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		return tWdfQmBPudobtUdhGKshtjyjmUgb(P_0);
	}

	public CustomController dsQtTEnYQFjVFFxLvbGUXZDvbar(int P_0)
	{
		int count = ozMPDGPKrryEoMaiFqmJeoSVQba.Count;
		for (int i = 0; i < count; i++)
		{
			if (ozMPDGPKrryEoMaiFqmJeoSVQba[i].sourceControllerId == P_0)
			{
				return ozMPDGPKrryEoMaiFqmJeoSVQba[i];
			}
		}
		return null;
	}

	public CustomController cQAeGgQhxJEefiiwSPvDFzthihtv(string P_0)
	{
		int count = ozMPDGPKrryEoMaiFqmJeoSVQba.Count;
		for (int i = 0; i < count; i++)
		{
			if (ozMPDGPKrryEoMaiFqmJeoSVQba[i].tag.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return ozMPDGPKrryEoMaiFqmJeoSVQba[i];
			}
		}
		return null;
	}

	public IEnumerable<CustomController> lCPwepBkieLtLzatCuWyqPWSqO(int P_0)
	{
		oYAUpFHjWpbAJdrNbMeOdDNkVIL oYAUpFHjWpbAJdrNbMeOdDNkVIL2 = new oYAUpFHjWpbAJdrNbMeOdDNkVIL(-2);
		oYAUpFHjWpbAJdrNbMeOdDNkVIL2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
		oYAUpFHjWpbAJdrNbMeOdDNkVIL2.mDUXajpDmsvjxUcgXIkycfpopuQa = P_0;
		return oYAUpFHjWpbAJdrNbMeOdDNkVIL2;
	}

	public IEnumerable<CustomController> JTfhmcCQtSnJUpEUWApocqDjLBeg(string P_0)
	{
		mZyvrXfzpYWQJSXfsuouitvEfZe mZyvrXfzpYWQJSXfsuouitvEfZe2 = new mZyvrXfzpYWQJSXfsuouitvEfZe(-2);
		mZyvrXfzpYWQJSXfsuouitvEfZe2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
		mZyvrXfzpYWQJSXfsuouitvEfZe2.WQHivsClkQrgkkTRIQoQskwrJmc = P_0;
		return mZyvrXfzpYWQJSXfsuouitvEfZe2;
	}

	public Controller ZqzzcVLLrMBIUyLpDAZiOGBIopG(ControllerType P_0, int P_1, bool P_2 = false)
	{
		return P_0 switch
		{
			ControllerType.Joystick => zCynXQNrFypPOHsukRvftnVVvxv(P_1, P_2), 
			ControllerType.Keyboard => HkpqDTUFRpMRrOEQVnSMXoFQldZ, 
			ControllerType.Mouse => asfRDzSekmvCpHiAVkQLFwtshxJ, 
			ControllerType.Custom => XLOkGOGTJTTMgVorWpHofbbxLFg(P_1), 
			_ => throw new NotImplementedException(), 
		};
	}

	public Controller ZqzzcVLLrMBIUyLpDAZiOGBIopG(ControllerIdentifier P_0, bool P_1 = false)
	{
		if (P_0.deviceInstanceGuid != Guid.Empty)
		{
			return ZqzzcVLLrMBIUyLpDAZiOGBIopG(P_0.deviceInstanceGuid);
		}
		if (P_0.controllerId >= 0)
		{
			return ZqzzcVLLrMBIUyLpDAZiOGBIopG(P_0.controllerType, P_0.controllerId, P_1);
		}
		return null;
	}

	public Controller ZqzzcVLLrMBIUyLpDAZiOGBIopG(Guid P_0, bool P_1 = false)
	{
		if (P_0 == Guid.Empty)
		{
			return null;
		}
		if (HkpqDTUFRpMRrOEQVnSMXoFQldZ.deviceInstanceGuid == P_0)
		{
			return HkpqDTUFRpMRrOEQVnSMXoFQldZ;
		}
		if (asfRDzSekmvCpHiAVkQLFwtshxJ.deviceInstanceGuid == P_0)
		{
			return asfRDzSekmvCpHiAVkQLFwtshxJ;
		}
		Controller result;
		if ((result = zCynXQNrFypPOHsukRvftnVVvxv(P_0, P_1)) != null)
		{
			return result;
		}
		if ((result = XLOkGOGTJTTMgVorWpHofbbxLFg(P_0)) != null)
		{
			return result;
		}
		return null;
	}

	public Controller[] kWDKDubSsTrSPPczHPBLAqrNgtB(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => WLxWQIGswHpTuGoGagfoNGpkNUi(), 
			ControllerType.Keyboard => new Controller[1] { HkpqDTUFRpMRrOEQVnSMXoFQldZ }, 
			ControllerType.Mouse => new Controller[1] { asfRDzSekmvCpHiAVkQLFwtshxJ }, 
			ControllerType.Custom => aeriZUDCjjOFEjImDxUcfHiKMmjO(), 
			_ => throw new NotImplementedException(), 
		};
	}

	public string[] BzUXJxDpeyaJzhOFTHxpLxSrdcM(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => lzUTlfxjIWCAxVpPYtNqRBHwRnF(), 
			ControllerType.Keyboard => new string[1] { HkpqDTUFRpMRrOEQVnSMXoFQldZ.name }, 
			ControllerType.Mouse => new string[1] { asfRDzSekmvCpHiAVkQLFwtshxJ.name }, 
			ControllerType.Custom => ojdLCTeIELScFPQxRSuPvWDcmqi(), 
			_ => throw new NotImplementedException(), 
		};
	}

	public void oxajqOBcvxFwvcUsERaSFiCLsDM(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		if (!mIybkdemYKTOqJCEXLpKRnfrChDv)
		{
			mIybkdemYKTOqJCEXLpKRnfrChDv = true;
		}
		SxDIpXAqrWehLnWSLeRuTTNizfp(P_0)?.MoYefDcYehcNuEtBwCxDvPMYqtm(P_1, P_2, InputActionEventType.Update, null);
	}

	public void oxajqOBcvxFwvcUsERaSFiCLsDM(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		if (!mIybkdemYKTOqJCEXLpKRnfrChDv)
		{
			mIybkdemYKTOqJCEXLpKRnfrChDv = true;
		}
		SxDIpXAqrWehLnWSLeRuTTNizfp(P_0)?.MoYefDcYehcNuEtBwCxDvPMYqtm(P_1, P_2, InputActionEventType.Update, P_3, null);
	}

	public void oxajqOBcvxFwvcUsERaSFiCLsDM(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		if (!mIybkdemYKTOqJCEXLpKRnfrChDv)
		{
			mIybkdemYKTOqJCEXLpKRnfrChDv = true;
		}
		int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(P_3);
		if (num >= 0)
		{
			oxajqOBcvxFwvcUsERaSFiCLsDM(P_0, P_1, P_2, num);
		}
	}

	public void oxajqOBcvxFwvcUsERaSFiCLsDM(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, object[] P_4)
	{
		if (!mIybkdemYKTOqJCEXLpKRnfrChDv)
		{
			mIybkdemYKTOqJCEXLpKRnfrChDv = true;
		}
		SxDIpXAqrWehLnWSLeRuTTNizfp(P_0)?.MoYefDcYehcNuEtBwCxDvPMYqtm(P_1, P_2, P_3, P_4);
	}

	public void oxajqOBcvxFwvcUsERaSFiCLsDM(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4, object[] P_5)
	{
		if (!mIybkdemYKTOqJCEXLpKRnfrChDv)
		{
			mIybkdemYKTOqJCEXLpKRnfrChDv = true;
		}
		SxDIpXAqrWehLnWSLeRuTTNizfp(P_0)?.MoYefDcYehcNuEtBwCxDvPMYqtm(P_1, P_2, P_3, P_4, P_5);
	}

	public void oxajqOBcvxFwvcUsERaSFiCLsDM(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4, object[] P_5)
	{
		if (!mIybkdemYKTOqJCEXLpKRnfrChDv)
		{
			mIybkdemYKTOqJCEXLpKRnfrChDv = true;
		}
		int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(P_4);
		if (num >= 0)
		{
			oxajqOBcvxFwvcUsERaSFiCLsDM(P_0, P_1, P_2, P_3, num, P_5);
		}
	}

	public void tyFeiIHqbjlgMjxLdJoLlFaykNoz(int P_0, Action<InputActionEventData> P_1)
	{
		SxDIpXAqrWehLnWSLeRuTTNizfp(P_0)?.tsiIiRnEIKEeGXdmsiYIGAemsrcr(P_1);
	}

	public void tyFeiIHqbjlgMjxLdJoLlFaykNoz(int P_0, Action<InputActionEventData> P_1, int P_2)
	{
		SxDIpXAqrWehLnWSLeRuTTNizfp(P_0)?.tsiIiRnEIKEeGXdmsiYIGAemsrcr(P_1, P_2);
	}

	public void tyFeiIHqbjlgMjxLdJoLlFaykNoz(int P_0, Action<InputActionEventData> P_1, string P_2)
	{
		int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(P_2);
		if (num >= 0)
		{
			tyFeiIHqbjlgMjxLdJoLlFaykNoz(P_0, P_1, num);
		}
	}

	public void tyFeiIHqbjlgMjxLdJoLlFaykNoz(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		SxDIpXAqrWehLnWSLeRuTTNizfp(P_0)?.tsiIiRnEIKEeGXdmsiYIGAemsrcr(P_1, P_2);
	}

	public void tyFeiIHqbjlgMjxLdJoLlFaykNoz(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2)
	{
		SxDIpXAqrWehLnWSLeRuTTNizfp(P_0)?.tsiIiRnEIKEeGXdmsiYIGAemsrcr(P_1, P_2);
	}

	public void tyFeiIHqbjlgMjxLdJoLlFaykNoz(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		SxDIpXAqrWehLnWSLeRuTTNizfp(P_0)?.tsiIiRnEIKEeGXdmsiYIGAemsrcr(P_1, P_2, P_3);
	}

	public void tyFeiIHqbjlgMjxLdJoLlFaykNoz(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(P_3);
		if (num >= 0)
		{
			tyFeiIHqbjlgMjxLdJoLlFaykNoz(P_0, P_1, P_2, num);
		}
	}

	public void tyFeiIHqbjlgMjxLdJoLlFaykNoz(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, int P_3)
	{
		SxDIpXAqrWehLnWSLeRuTTNizfp(P_0)?.tsiIiRnEIKEeGXdmsiYIGAemsrcr(P_1, P_2, P_3);
	}

	public void tyFeiIHqbjlgMjxLdJoLlFaykNoz(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, string P_3)
	{
		int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(P_3);
		if (num >= 0)
		{
			tyFeiIHqbjlgMjxLdJoLlFaykNoz(P_0, P_1, P_2, num);
		}
	}

	public void tyFeiIHqbjlgMjxLdJoLlFaykNoz(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3)
	{
		SxDIpXAqrWehLnWSLeRuTTNizfp(P_0)?.tsiIiRnEIKEeGXdmsiYIGAemsrcr(P_1, P_2, P_3);
	}

	public void tyFeiIHqbjlgMjxLdJoLlFaykNoz(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4)
	{
		SxDIpXAqrWehLnWSLeRuTTNizfp(P_0)?.tsiIiRnEIKEeGXdmsiYIGAemsrcr(P_1, P_2, P_3, P_4);
	}

	public void tyFeiIHqbjlgMjxLdJoLlFaykNoz(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4)
	{
		int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(P_4);
		if (num >= 0)
		{
			tyFeiIHqbjlgMjxLdJoLlFaykNoz(P_0, P_1, P_2, P_3, num);
		}
	}

	public void oMDCImrWTNmtnocxXQYboXctem(int P_0)
	{
		SxDIpXAqrWehLnWSLeRuTTNizfp(P_0)?.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
	}

	public bool ZEFJZiaABMktrhDLjeAKbicfiRmL(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < aRIrccLhfOfqfrZCAqEeQcWCSkS.Length; i++)
			{
				if (aRIrccLhfOfqfrZCAqEeQcWCSkS[i].JFLhhsViRZmASHFRAirmzVNMOhf())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= LHXUijdjpnmZGwdcLlrvMfDTDEhg)
		{
			return false;
		}
		int actionCount = XVroGTnTmiTwGITDVAhlDMsuaLiG.actionCount;
		for (int j = 0; j < actionCount; j++)
		{
			if (XZFphnyIaSbooGWqtVFLlrzISCP[P_0, j].JFLhhsViRZmASHFRAirmzVNMOhf())
			{
				return true;
			}
		}
		return false;
	}

	public bool RSwEunaNKyfnjjtVoWSzPKfabcNN(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < aRIrccLhfOfqfrZCAqEeQcWCSkS.Length; i++)
			{
				if (aRIrccLhfOfqfrZCAqEeQcWCSkS[i].CmwiIVrqfDqUrfdgDhwXnRxwqAE())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= LHXUijdjpnmZGwdcLlrvMfDTDEhg)
		{
			return false;
		}
		int actionCount = XVroGTnTmiTwGITDVAhlDMsuaLiG.actionCount;
		for (int j = 0; j < actionCount; j++)
		{
			if (XZFphnyIaSbooGWqtVFLlrzISCP[P_0, j].CmwiIVrqfDqUrfdgDhwXnRxwqAE())
			{
				return true;
			}
		}
		return false;
	}

	public bool SdgVxmkxIXIaIbUFSwMTeQmRUN(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < aRIrccLhfOfqfrZCAqEeQcWCSkS.Length; i++)
			{
				if (aRIrccLhfOfqfrZCAqEeQcWCSkS[i].cpecOFaBXVFHwWEOrZWGPOEkoSMP())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= LHXUijdjpnmZGwdcLlrvMfDTDEhg)
		{
			return false;
		}
		int actionCount = XVroGTnTmiTwGITDVAhlDMsuaLiG.actionCount;
		for (int j = 0; j < actionCount; j++)
		{
			if (XZFphnyIaSbooGWqtVFLlrzISCP[P_0, j].cpecOFaBXVFHwWEOrZWGPOEkoSMP())
			{
				return true;
			}
		}
		return false;
	}

	public bool BDUSBJSsOUWVTWELscIUqkTqfQLB(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < aRIrccLhfOfqfrZCAqEeQcWCSkS.Length; i++)
			{
				if (aRIrccLhfOfqfrZCAqEeQcWCSkS[i].NyQDvOIzDpkRBsleftaSWfWiBaUD())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= LHXUijdjpnmZGwdcLlrvMfDTDEhg)
		{
			return false;
		}
		int actionCount = XVroGTnTmiTwGITDVAhlDMsuaLiG.actionCount;
		for (int j = 0; j < actionCount; j++)
		{
			if (XZFphnyIaSbooGWqtVFLlrzISCP[P_0, j].NyQDvOIzDpkRBsleftaSWfWiBaUD())
			{
				return true;
			}
		}
		return false;
	}

	public bool nqOePCatWLXLxMGXPYQnhBolKic(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < aRIrccLhfOfqfrZCAqEeQcWCSkS.Length; i++)
			{
				if (aRIrccLhfOfqfrZCAqEeQcWCSkS[i].gjvFsQfWVLkGJLUlHHOwfcVAxgI())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= LHXUijdjpnmZGwdcLlrvMfDTDEhg)
		{
			return false;
		}
		int actionCount = XVroGTnTmiTwGITDVAhlDMsuaLiG.actionCount;
		for (int j = 0; j < actionCount; j++)
		{
			if (XZFphnyIaSbooGWqtVFLlrzISCP[P_0, j].gjvFsQfWVLkGJLUlHHOwfcVAxgI())
			{
				return true;
			}
		}
		return false;
	}

	public bool dMTcDaEmFSrHzEOUqoPhOmSTtkWc(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < aRIrccLhfOfqfrZCAqEeQcWCSkS.Length; i++)
			{
				if (aRIrccLhfOfqfrZCAqEeQcWCSkS[i].wiPVOSjfQFqDVBfmgbvuPukNqlZ())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= LHXUijdjpnmZGwdcLlrvMfDTDEhg)
		{
			return false;
		}
		int actionCount = XVroGTnTmiTwGITDVAhlDMsuaLiG.actionCount;
		for (int j = 0; j < actionCount; j++)
		{
			if (XZFphnyIaSbooGWqtVFLlrzISCP[P_0, j].wiPVOSjfQFqDVBfmgbvuPukNqlZ())
			{
				return true;
			}
		}
		return false;
	}

	public bool IRONFTFwrVPBpGrUUkUlFjxjhIQ(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < aRIrccLhfOfqfrZCAqEeQcWCSkS.Length; i++)
			{
				if (aRIrccLhfOfqfrZCAqEeQcWCSkS[i].lSoChdolRrcjvhCMgWkTNuSJzJM())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= LHXUijdjpnmZGwdcLlrvMfDTDEhg)
		{
			return false;
		}
		int actionCount = XVroGTnTmiTwGITDVAhlDMsuaLiG.actionCount;
		for (int j = 0; j < actionCount; j++)
		{
			if (XZFphnyIaSbooGWqtVFLlrzISCP[P_0, j].lSoChdolRrcjvhCMgWkTNuSJzJM())
			{
				return true;
			}
		}
		return false;
	}

	public bool QoIcpQdncbKmYPmwiPrmIoKrKqY(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < aRIrccLhfOfqfrZCAqEeQcWCSkS.Length; i++)
			{
				if (aRIrccLhfOfqfrZCAqEeQcWCSkS[i].tWNGjrHjjCtCJlLkJMXkyfcwFWa())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= LHXUijdjpnmZGwdcLlrvMfDTDEhg)
		{
			return false;
		}
		int actionCount = XVroGTnTmiTwGITDVAhlDMsuaLiG.actionCount;
		for (int j = 0; j < actionCount; j++)
		{
			if (XZFphnyIaSbooGWqtVFLlrzISCP[P_0, j].tWNGjrHjjCtCJlLkJMXkyfcwFWa())
			{
				return true;
			}
		}
		return false;
	}

	public bool CoZRjQbUOQiESclBcEIdexoMtib()
	{
		if (!CoZRjQbUOQiESclBcEIdexoMtib(asfRDzSekmvCpHiAVkQLFwtshxJ) && !CoZRjQbUOQiESclBcEIdexoMtib(PwdEInECBiDDjabWgJCuiXatYNFJ) && !CoZRjQbUOQiESclBcEIdexoMtib(HkpqDTUFRpMRrOEQVnSMXoFQldZ))
		{
			return CoZRjQbUOQiESclBcEIdexoMtib(ozMPDGPKrryEoMaiFqmJeoSVQba);
		}
		return true;
	}

	public bool CoZRjQbUOQiESclBcEIdexoMtib(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => CoZRjQbUOQiESclBcEIdexoMtib(PwdEInECBiDDjabWgJCuiXatYNFJ), 
			ControllerType.Keyboard => CoZRjQbUOQiESclBcEIdexoMtib(HkpqDTUFRpMRrOEQVnSMXoFQldZ), 
			ControllerType.Mouse => CoZRjQbUOQiESclBcEIdexoMtib(asfRDzSekmvCpHiAVkQLFwtshxJ), 
			ControllerType.Custom => CoZRjQbUOQiESclBcEIdexoMtib(ozMPDGPKrryEoMaiFqmJeoSVQba), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool KyWOTzXnbnFXfcbzIhYfqSkrzkMa()
	{
		if (!KyWOTzXnbnFXfcbzIhYfqSkrzkMa(asfRDzSekmvCpHiAVkQLFwtshxJ) && !KyWOTzXnbnFXfcbzIhYfqSkrzkMa(PwdEInECBiDDjabWgJCuiXatYNFJ) && !KyWOTzXnbnFXfcbzIhYfqSkrzkMa(HkpqDTUFRpMRrOEQVnSMXoFQldZ))
		{
			return KyWOTzXnbnFXfcbzIhYfqSkrzkMa(ozMPDGPKrryEoMaiFqmJeoSVQba);
		}
		return true;
	}

	public bool KyWOTzXnbnFXfcbzIhYfqSkrzkMa(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => KyWOTzXnbnFXfcbzIhYfqSkrzkMa(PwdEInECBiDDjabWgJCuiXatYNFJ), 
			ControllerType.Keyboard => KyWOTzXnbnFXfcbzIhYfqSkrzkMa(HkpqDTUFRpMRrOEQVnSMXoFQldZ), 
			ControllerType.Mouse => KyWOTzXnbnFXfcbzIhYfqSkrzkMa(asfRDzSekmvCpHiAVkQLFwtshxJ), 
			ControllerType.Custom => KyWOTzXnbnFXfcbzIhYfqSkrzkMa(ozMPDGPKrryEoMaiFqmJeoSVQba), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool yERBofCdUWBmcVxkAYCWLnNYSuAS()
	{
		if (!yERBofCdUWBmcVxkAYCWLnNYSuAS(asfRDzSekmvCpHiAVkQLFwtshxJ) && !yERBofCdUWBmcVxkAYCWLnNYSuAS(PwdEInECBiDDjabWgJCuiXatYNFJ) && !yERBofCdUWBmcVxkAYCWLnNYSuAS(HkpqDTUFRpMRrOEQVnSMXoFQldZ))
		{
			return yERBofCdUWBmcVxkAYCWLnNYSuAS(ozMPDGPKrryEoMaiFqmJeoSVQba);
		}
		return true;
	}

	public bool yERBofCdUWBmcVxkAYCWLnNYSuAS(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => yERBofCdUWBmcVxkAYCWLnNYSuAS(PwdEInECBiDDjabWgJCuiXatYNFJ), 
			ControllerType.Keyboard => yERBofCdUWBmcVxkAYCWLnNYSuAS(HkpqDTUFRpMRrOEQVnSMXoFQldZ), 
			ControllerType.Mouse => yERBofCdUWBmcVxkAYCWLnNYSuAS(asfRDzSekmvCpHiAVkQLFwtshxJ), 
			ControllerType.Custom => yERBofCdUWBmcVxkAYCWLnNYSuAS(ozMPDGPKrryEoMaiFqmJeoSVQba), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool fSFOJycYWbgZkCObUKvhjBIWHpU()
	{
		if (!fSFOJycYWbgZkCObUKvhjBIWHpU(asfRDzSekmvCpHiAVkQLFwtshxJ) && !fSFOJycYWbgZkCObUKvhjBIWHpU(PwdEInECBiDDjabWgJCuiXatYNFJ) && !fSFOJycYWbgZkCObUKvhjBIWHpU(HkpqDTUFRpMRrOEQVnSMXoFQldZ))
		{
			return fSFOJycYWbgZkCObUKvhjBIWHpU(ozMPDGPKrryEoMaiFqmJeoSVQba);
		}
		return true;
	}

	public bool fSFOJycYWbgZkCObUKvhjBIWHpU(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => fSFOJycYWbgZkCObUKvhjBIWHpU(PwdEInECBiDDjabWgJCuiXatYNFJ), 
			ControllerType.Keyboard => fSFOJycYWbgZkCObUKvhjBIWHpU(HkpqDTUFRpMRrOEQVnSMXoFQldZ), 
			ControllerType.Mouse => fSFOJycYWbgZkCObUKvhjBIWHpU(asfRDzSekmvCpHiAVkQLFwtshxJ), 
			ControllerType.Custom => fSFOJycYWbgZkCObUKvhjBIWHpU(ozMPDGPKrryEoMaiFqmJeoSVQba), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool eqFovowBCGYtCfcTTXQKPQnFkQX()
	{
		if (!eqFovowBCGYtCfcTTXQKPQnFkQX(asfRDzSekmvCpHiAVkQLFwtshxJ) && !eqFovowBCGYtCfcTTXQKPQnFkQX(PwdEInECBiDDjabWgJCuiXatYNFJ) && !eqFovowBCGYtCfcTTXQKPQnFkQX(HkpqDTUFRpMRrOEQVnSMXoFQldZ))
		{
			return eqFovowBCGYtCfcTTXQKPQnFkQX(ozMPDGPKrryEoMaiFqmJeoSVQba);
		}
		return true;
	}

	public bool eqFovowBCGYtCfcTTXQKPQnFkQX(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => eqFovowBCGYtCfcTTXQKPQnFkQX(PwdEInECBiDDjabWgJCuiXatYNFJ), 
			ControllerType.Keyboard => eqFovowBCGYtCfcTTXQKPQnFkQX(HkpqDTUFRpMRrOEQVnSMXoFQldZ), 
			ControllerType.Mouse => eqFovowBCGYtCfcTTXQKPQnFkQX(asfRDzSekmvCpHiAVkQLFwtshxJ), 
			ControllerType.Custom => eqFovowBCGYtCfcTTXQKPQnFkQX(ozMPDGPKrryEoMaiFqmJeoSVQba), 
			_ => throw new NotImplementedException(), 
		};
	}

	private bool CoZRjQbUOQiESclBcEIdexoMtib<T>(IList<T> P_0) where T : Controller
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

	private bool CoZRjQbUOQiESclBcEIdexoMtib(Controller P_0)
	{
		return P_0?.GetAnyButton() ?? false;
	}

	private bool KyWOTzXnbnFXfcbzIhYfqSkrzkMa<T>(IList<T> P_0) where T : Controller
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

	private bool KyWOTzXnbnFXfcbzIhYfqSkrzkMa(Controller P_0)
	{
		return P_0?.GetAnyButtonDown() ?? false;
	}

	private bool yERBofCdUWBmcVxkAYCWLnNYSuAS<T>(IList<T> P_0) where T : Controller
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

	private bool yERBofCdUWBmcVxkAYCWLnNYSuAS(Controller P_0)
	{
		return P_0?.GetAnyButtonUp() ?? false;
	}

	private bool fSFOJycYWbgZkCObUKvhjBIWHpU<T>(IList<T> P_0) where T : Controller
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

	private bool fSFOJycYWbgZkCObUKvhjBIWHpU(Controller P_0)
	{
		return P_0?.GetAnyButtonChanged() ?? false;
	}

	private bool eqFovowBCGYtCfcTTXQKPQnFkQX<T>(IList<T> P_0) where T : Controller
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

	private bool eqFovowBCGYtCfcTTXQKPQnFkQX(Controller P_0)
	{
		return P_0?.GetAnyButtonPrev() ?? false;
	}

	public Controller ezbHzgCqwLthxsWYOOyJKDwpFMX()
	{
		Controller lastController = null;
		double lastTime = 0.0;
		InputTools.CompareLastActiveController(asfRDzSekmvCpHiAVkQLFwtshxJ, ref lastController, ref lastTime);
		InputTools.CompareLastActiveController(HkpqDTUFRpMRrOEQVnSMXoFQldZ, ref lastController, ref lastTime);
		IList<Joystick> pwdEInECBiDDjabWgJCuiXatYNFJ = PwdEInECBiDDjabWgJCuiXatYNFJ;
		for (int i = 0; i < joystickCount; i++)
		{
			InputTools.CompareLastActiveController(pwdEInECBiDDjabWgJCuiXatYNFJ[i], ref lastController, ref lastTime);
		}
		IList<CustomController> list = ozMPDGPKrryEoMaiFqmJeoSVQba;
		for (int j = 0; j < customControllerCount; j++)
		{
			InputTools.CompareLastActiveController(list[j], ref lastController, ref lastTime);
		}
		if (lastController == null)
		{
			lastController = HkpqDTUFRpMRrOEQVnSMXoFQldZ;
		}
		return lastController;
	}

	public Controller ezbHzgCqwLthxsWYOOyJKDwpFMX(ControllerType P_0)
	{
		Controller lastController = null;
		double lastTime = 0.0;
		switch (P_0)
		{
		case ControllerType.Joystick:
		{
			int count = PwdEInECBiDDjabWgJCuiXatYNFJ.Count;
			for (int j = 0; j < count; j++)
			{
				InputTools.CompareLastActiveController(PwdEInECBiDDjabWgJCuiXatYNFJ[j], ref lastController, ref lastTime);
			}
			break;
		}
		case ControllerType.Keyboard:
			return Keyboard;
		case ControllerType.Mouse:
			return Mouse;
		case ControllerType.Custom:
		{
			int count = ozMPDGPKrryEoMaiFqmJeoSVQba.Count;
			for (int i = 0; i < count; i++)
			{
				InputTools.CompareLastActiveController(ozMPDGPKrryEoMaiFqmJeoSVQba[i], ref lastController, ref lastTime);
			}
			break;
		}
		default:
			throw new NotImplementedException();
		}
		return lastController;
	}

	public T ezbHzgCqwLthxsWYOOyJKDwpFMX<T>() where T : Controller
	{
		Type typeFromHandle = typeof(T);
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
		{
			return ezbHzgCqwLthxsWYOOyJKDwpFMX(ControllerType.Joystick) as T;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
		{
			return ezbHzgCqwLthxsWYOOyJKDwpFMX(ControllerType.Keyboard) as T;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
		{
			return ezbHzgCqwLthxsWYOOyJKDwpFMX(ControllerType.Custom) as T;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
		{
			return ezbHzgCqwLthxsWYOOyJKDwpFMX(ControllerType.Mouse) as T;
		}
		throw new NotImplementedException();
	}

	public ControllerType yCSnAJgicRxnHscROcTistbBbLl()
	{
		return ezbHzgCqwLthxsWYOOyJKDwpFMX()?.type ?? ControllerType.Keyboard;
	}

	public void yriBQDnkYvrvyaiUGEOUCIKrzPN(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 != null)
		{
			wfkokSoCzafcqgRarzbQkYiZozy = true;
			iuCCmPYpUwwJAvFqqyhfzwePwIY.shIhxTsNglBmaJDkzEdPZwGvNzb(P_0);
		}
	}

	public void yriBQDnkYvrvyaiUGEOUCIKrzPN(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 != null)
		{
			wfkokSoCzafcqgRarzbQkYiZozy = true;
			iuCCmPYpUwwJAvFqqyhfzwePwIY.shIhxTsNglBmaJDkzEdPZwGvNzb(P_0, P_1);
		}
	}

	public void ePRwkMZZWtoOHNmXUYNXQjcOLks(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 != null)
		{
			iuCCmPYpUwwJAvFqqyhfzwePwIY.PqASozytJLkPHWgZycLJeLJjhSKj(P_0);
		}
	}

	public void PjOpTtOqxuHGnsuVpSkOPzznyw(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 != null)
		{
			iuCCmPYpUwwJAvFqqyhfzwePwIY.PqASozytJLkPHWgZycLJeLJjhSKj(P_0, P_1);
		}
	}

	public void JITpkVFOnUeywEjxEasvcfvrohL()
	{
		iuCCmPYpUwwJAvFqqyhfzwePwIY.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
	}

	public void yriBQDnkYvrvyaiUGEOUCIKrzPN(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		if (P_0 == 9999999)
		{
			gjhHVIbZboONefLBoeKyJgkoHYad.shIhxTsNglBmaJDkzEdPZwGvNzb(P_1);
		}
		else
		{
			if ((uint)P_0 >= (uint)LHXUijdjpnmZGwdcLlrvMfDTDEhg)
			{
				return;
			}
			yLBuXsZVLfoMAulVuEjXxdXxjtm[P_0].shIhxTsNglBmaJDkzEdPZwGvNzb(P_1);
		}
		wfkokSoCzafcqgRarzbQkYiZozy = true;
	}

	public void yriBQDnkYvrvyaiUGEOUCIKrzPN(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
	{
		if (P_1 == null)
		{
			return;
		}
		if (P_0 == 9999999)
		{
			gjhHVIbZboONefLBoeKyJgkoHYad.shIhxTsNglBmaJDkzEdPZwGvNzb(P_1, P_2);
		}
		else
		{
			if ((uint)P_0 >= (uint)LHXUijdjpnmZGwdcLlrvMfDTDEhg)
			{
				return;
			}
			yLBuXsZVLfoMAulVuEjXxdXxjtm[P_0].shIhxTsNglBmaJDkzEdPZwGvNzb(P_1, P_2);
		}
		wfkokSoCzafcqgRarzbQkYiZozy = true;
	}

	public void ePRwkMZZWtoOHNmXUYNXQjcOLks(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 != null)
		{
			if (P_0 == 9999999)
			{
				gjhHVIbZboONefLBoeKyJgkoHYad.PqASozytJLkPHWgZycLJeLJjhSKj(P_1);
			}
			else if ((uint)P_0 < (uint)LHXUijdjpnmZGwdcLlrvMfDTDEhg)
			{
				yLBuXsZVLfoMAulVuEjXxdXxjtm[P_0].PqASozytJLkPHWgZycLJeLJjhSKj(P_1);
			}
		}
	}

	public void ePRwkMZZWtoOHNmXUYNXQjcOLks(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
	{
		if (P_1 != null)
		{
			if (P_0 == 9999999)
			{
				gjhHVIbZboONefLBoeKyJgkoHYad.PqASozytJLkPHWgZycLJeLJjhSKj(P_1, P_2);
			}
			else if ((uint)P_0 < (uint)LHXUijdjpnmZGwdcLlrvMfDTDEhg)
			{
				yLBuXsZVLfoMAulVuEjXxdXxjtm[P_0].PqASozytJLkPHWgZycLJeLJjhSKj(P_1, P_2);
			}
		}
	}

	public void JITpkVFOnUeywEjxEasvcfvrohL(int P_0)
	{
		if (P_0 == 9999999)
		{
			gjhHVIbZboONefLBoeKyJgkoHYad.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
		}
		else if ((uint)P_0 < (uint)LHXUijdjpnmZGwdcLlrvMfDTDEhg)
		{
			yLBuXsZVLfoMAulVuEjXxdXxjtm[P_0].VcHhfbFqwxAmqhwBHKVJpDjlfufe();
		}
	}

	private void PrvLWaYnReqoVYeGLAnIjaAvYju()
	{
		if (iuCCmPYpUwwJAvFqqyhfzwePwIY.iouhdcojnqiucZBxZBWMhNWfnJQ > 0)
		{
			iuCCmPYpUwwJAvFqqyhfzwePwIY.dZPNnKEuXxgzKOORPEzdcBWIBFYI(-1, ezbHzgCqwLthxsWYOOyJKDwpFMX(), ezbHzgCqwLthxsWYOOyJKDwpFMX(ControllerType.Joystick), ezbHzgCqwLthxsWYOOyJKDwpFMX(ControllerType.Custom));
		}
		if (gjhHVIbZboONefLBoeKyJgkoHYad.iouhdcojnqiucZBxZBWMhNWfnJQ > 0)
		{
			Player.ControllerHelper controllers = yIRdWijqyghmemPssevxkoxocsUE.ikAQnlPYKaPDyPGwvHipJdyKxOw().controllers;
			gjhHVIbZboONefLBoeKyJgkoHYad.dZPNnKEuXxgzKOORPEzdcBWIBFYI(9999999, controllers.GetLastActiveController(), controllers.GetLastActiveController(ControllerType.Joystick), controllers.GetLastActiveController(ControllerType.Custom));
		}
		for (int i = 0; i < LHXUijdjpnmZGwdcLlrvMfDTDEhg; i++)
		{
			if (yLBuXsZVLfoMAulVuEjXxdXxjtm[i].iouhdcojnqiucZBxZBWMhNWfnJQ != 0)
			{
				Player.ControllerHelper controllers2 = yIRdWijqyghmemPssevxkoxocsUE.Players_orig[i].controllers;
				yLBuXsZVLfoMAulVuEjXxdXxjtm[i].dZPNnKEuXxgzKOORPEzdcBWIBFYI(i, controllers2.GetLastActiveController(), controllers2.GetLastActiveController(ControllerType.Joystick), controllers2.GetLastActiveController(ControllerType.Custom));
			}
		}
	}

	public void sdnEHVkszbacpcRGvFmAcEtNbcs(ThrottleCalibrationMode P_0)
	{
		for (int i = 0; i < PwdEInECBiDDjabWgJCuiXatYNFJ.Count; i++)
		{
			if (PwdEInECBiDDjabWgJCuiXatYNFJ[i] != null)
			{
				sdnEHVkszbacpcRGvFmAcEtNbcs(PwdEInECBiDDjabWgJCuiXatYNFJ[i], P_0);
			}
		}
		for (int j = 0; j < ywLEiQCiOAobwTWmZbbhQQiuYIC.Count; j++)
		{
			if (ywLEiQCiOAobwTWmZbbhQQiuYIC[j] != null)
			{
				sdnEHVkszbacpcRGvFmAcEtNbcs(ywLEiQCiOAobwTWmZbbhQQiuYIC[j], P_0);
			}
		}
		for (int k = 0; k < customControllerCount; k++)
		{
			if (ozMPDGPKrryEoMaiFqmJeoSVQba[k] != null)
			{
				sdnEHVkszbacpcRGvFmAcEtNbcs(ozMPDGPKrryEoMaiFqmJeoSVQba[k], P_0);
			}
		}
		sdnEHVkszbacpcRGvFmAcEtNbcs(asfRDzSekmvCpHiAVkQLFwtshxJ, P_0);
	}

	private void sdnEHVkszbacpcRGvFmAcEtNbcs(ControllerWithAxes P_0, ThrottleCalibrationMode P_1)
	{
		IList<Controller.Axis> axes = P_0.Axes;
		for (int i = 0; i < P_0.axisCount; i++)
		{
			if (axes[i].PlYUFxznkverJWuzpbzUWwQOLjs._specialAxisType == SpecialAxisType.Throttle)
			{
				P_0.calibrationMap.Axes[i].calibrationMode = EnumConverter.ToAlternateAxisCalibrationType(P_1);
			}
		}
	}

	public IList<T> fgzioFOpODFqmPepxTDygvJRpyO<T>() where T : IControllerTemplate
	{
		return dHzdxJGgfVamEigJTrTmGDfvxRqc.xbXCiCGpUEnZvbvPgjxSgXChLGvD<T>();
	}

	private void iDBXctPcOcjjzWbKaCnxuPiVNUc(List<InputBehavior> P_0)
	{
		XVroGTnTmiTwGITDVAhlDMsuaLiG = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG;
		yIRdWijqyghmemPssevxkoxocsUE = ReInput.yIRdWijqyghmemPssevxkoxocsUE;
		PwdEInECBiDDjabWgJCuiXatYNFJ = new List<Joystick>();
		ywLEiQCiOAobwTWmZbbhQQiuYIC = new List<Joystick>();
		ozMPDGPKrryEoMaiFqmJeoSVQba = new List<CustomController>();
		jGQlTFOTZwmOauEGXHrDOyuTntc = XVroGTnTmiTwGITDVAhlDMsuaLiG.actionCount;
		LHXUijdjpnmZGwdcLlrvMfDTDEhg = yIRdWijqyghmemPssevxkoxocsUE.gamePlayerCount;
		iYLORkOUOSEEasmcRHMzhlHqunUP = nnipvNSBKmDcjCwnjkdZzkiuEWaD;
		VwhbnrPNaFbAiXyYtbRRzCVjzTk = 0;
		yMltWmasIPwCpdMeapCHJxGEtaz = new ADictionary<int, SgJxHfuWnKMjzGaItUgkhpeycFMH>();
		yMltWmasIPwCpdMeapCHJxGEtaz.Add(ReInput.players.GetSystemPlayer().id, new SgJxHfuWnKMjzGaItUgkhpeycFMH(P_0));
		IList<Player> players = ReInput.players.Players;
		for (int i = 0; i < players.Count; i++)
		{
			yMltWmasIPwCpdMeapCHJxGEtaz.Add(players[i].id, new SgJxHfuWnKMjzGaItUgkhpeycFMH(P_0));
		}
		LvddOeiZGwWTpcucIOYQcVfzoXYv = new ReadOnlyCollection<Joystick>(PwdEInECBiDDjabWgJCuiXatYNFJ);
		JsfDAuTeDkFfzwAgnsObzjhapta = new ReadOnlyCollection<CustomController>(ozMPDGPKrryEoMaiFqmJeoSVQba);
		VvbRiPIRRDOGFeaGvZCVmBjRfXT.ZiymOPuXhjhmAzOQLyeRogxsHYa(kEfTcVPDPtzkvdMGLfLPBGnaUJq);
		jmPQhhdSmzMbfNmhujxPORzPOWc = new VvbRiPIRRDOGFeaGvZCVmBjRfXT[(LHXUijdjpnmZGwdcLlrvMfDTDEhg + 1) * jGQlTFOTZwmOauEGXHrDOyuTntc];
		int num = 0;
		aRIrccLhfOfqfrZCAqEeQcWCSkS = new VvbRiPIRRDOGFeaGvZCVmBjRfXT[jGQlTFOTZwmOauEGXHrDOyuTntc];
		for (int j = 0; j < jGQlTFOTZwmOauEGXHrDOyuTntc; j++)
		{
			InputAction inputAction = XVroGTnTmiTwGITDVAhlDMsuaLiG.tlCsXbFIrbtDiBdpidNJQdEUhja(j);
			InputBehavior inputBehavior = yMltWmasIPwCpdMeapCHJxGEtaz[9999999].auqjpNrMPzeNGPWFKBdgotuznwq(inputAction.behaviorId);
			VvbRiPIRRDOGFeaGvZCVmBjRfXT vvbRiPIRRDOGFeaGvZCVmBjRfXT = new VvbRiPIRRDOGFeaGvZCVmBjRfXT(9999999, inputAction, inputBehavior, kEfTcVPDPtzkvdMGLfLPBGnaUJq);
			aRIrccLhfOfqfrZCAqEeQcWCSkS[j] = vvbRiPIRRDOGFeaGvZCVmBjRfXT;
			jmPQhhdSmzMbfNmhujxPORzPOWc[num] = vvbRiPIRRDOGFeaGvZCVmBjRfXT;
			num++;
		}
		XZFphnyIaSbooGWqtVFLlrzISCP = new VvbRiPIRRDOGFeaGvZCVmBjRfXT[LHXUijdjpnmZGwdcLlrvMfDTDEhg, jGQlTFOTZwmOauEGXHrDOyuTntc];
		for (int k = 0; k < LHXUijdjpnmZGwdcLlrvMfDTDEhg; k++)
		{
			for (int l = 0; l < jGQlTFOTZwmOauEGXHrDOyuTntc; l++)
			{
				InputAction inputAction2 = XVroGTnTmiTwGITDVAhlDMsuaLiG.tlCsXbFIrbtDiBdpidNJQdEUhja(l);
				InputBehavior inputBehavior2 = yMltWmasIPwCpdMeapCHJxGEtaz[players[k].id].auqjpNrMPzeNGPWFKBdgotuznwq(inputAction2.behaviorId);
				VvbRiPIRRDOGFeaGvZCVmBjRfXT vvbRiPIRRDOGFeaGvZCVmBjRfXT2 = new VvbRiPIRRDOGFeaGvZCVmBjRfXT(k, inputAction2, inputBehavior2, kEfTcVPDPtzkvdMGLfLPBGnaUJq);
				XZFphnyIaSbooGWqtVFLlrzISCP[k, l] = vvbRiPIRRDOGFeaGvZCVmBjRfXT2;
				jmPQhhdSmzMbfNmhujxPORzPOWc[num] = vvbRiPIRRDOGFeaGvZCVmBjRfXT2;
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
				CustomController customController = whxNiKHrMFxPJAgBjEgFFOeSlVHA(startingCustomControllers[n].sourceId);
				if (customController != null)
				{
					customController.tag = startingCustomControllers[n].tag;
					int num2 = ((m == 0) ? 9999999 : (m - 1));
					yIRdWijqyghmemPssevxkoxocsUE.lZXmlWxQPcBFEbyBUMCSggeIoJj(num2)?.controllers.lObdySffSxtSFDoDQQyUyVZrHkI(customController, false);
				}
			}
		}
		HoFaqBAdDbKcuzeayPPdDGLgbeza = new rclcWIXPrkQyKbnNIANjIzDkfpB();
		AoVWIGFmkaussHBpYpzPYXGhmBw = new rclcWIXPrkQyKbnNIANjIzDkfpB[LHXUijdjpnmZGwdcLlrvMfDTDEhg];
		for (int num3 = 0; num3 < LHXUijdjpnmZGwdcLlrvMfDTDEhg; num3++)
		{
			AoVWIGFmkaussHBpYpzPYXGhmBw[num3] = new rclcWIXPrkQyKbnNIANjIzDkfpB();
		}
		iuCCmPYpUwwJAvFqqyhfzwePwIY = new global::RQGiHPimgvjtQJEPCbYrPWcejhA<ActiveControllerChangedDelegate>();
		gjhHVIbZboONefLBoeKyJgkoHYad = new global::RQGiHPimgvjtQJEPCbYrPWcejhA<PlayerActiveControllerChangedDelegate>();
		yLBuXsZVLfoMAulVuEjXxdXxjtm = new global::RQGiHPimgvjtQJEPCbYrPWcejhA<PlayerActiveControllerChangedDelegate>[yIRdWijqyghmemPssevxkoxocsUE.gamePlayerCount];
		ArrayTools.Populate(yLBuXsZVLfoMAulVuEjXxdXxjtm);
	}

	private void yqbANtBoQbEHUAgHKNxFeobyUQMs(UpdateLoopType P_0)
	{
		int count = PwdEInECBiDDjabWgJCuiXatYNFJ.Count;
		for (int i = 0; i < count; i++)
		{
			Joystick joystick = PwdEInECBiDDjabWgJCuiXatYNFJ[i];
			if (joystick.enabled)
			{
				gpJkbsjewLmliVKKBOWNXriDJPv(joystick.inputManagerId, joystick.QlXkhNBHPYUNWwhKurdwrqFgWTf);
				joystick.KcNfORqUkjxfSzjWExwXXCRKlZu(P_0);
			}
		}
		if (HkpqDTUFRpMRrOEQVnSMXoFQldZ.enabled)
		{
			HkpqDTUFRpMRrOEQVnSMXoFQldZ.KcNfORqUkjxfSzjWExwXXCRKlZu(P_0);
		}
		else if (rMxEqIvJeWWddFXXpARGQYckQDR)
		{
			HkpqDTUFRpMRrOEQVnSMXoFQldZ.WxdpFdTfMOdtOWHKOpbraLqOYhP(P_0);
		}
		if (asfRDzSekmvCpHiAVkQLFwtshxJ.enabled)
		{
			asfRDzSekmvCpHiAVkQLFwtshxJ.KcNfORqUkjxfSzjWExwXXCRKlZu(P_0);
		}
		int count2 = ozMPDGPKrryEoMaiFqmJeoSVQba.Count;
		for (int j = 0; j < count2; j++)
		{
			CustomController customController = ozMPDGPKrryEoMaiFqmJeoSVQba[j];
			if (customController.enabled)
			{
				customController.oYEKbEsjyanyZgeNJBDuvfAMTFD();
				customController.KcNfORqUkjxfSzjWExwXXCRKlZu(P_0);
			}
		}
	}

	private void ZjaahTcFObjqKqWJtrgHBvQVVoW(UpdateLoopType P_0)
	{
		VvbRiPIRRDOGFeaGvZCVmBjRfXT.UIRnsHnENNoXIiApdjlDWHOSAVj(P_0);
		Player[] allPlayers_orig = yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_orig;
		int num = allPlayers_orig.Length;
		bool enabled = HkpqDTUFRpMRrOEQVnSMXoFQldZ.enabled;
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
						qrVEDSepLYqYVSPtpaJcNmLxEsZ.EYnVuSOaHchUNxtZyxXhwRThKWG(maps[j]);
					}
				}
			}
		}
		bool enabled2 = asfRDzSekmvCpHiAVkQLFwtshxJ.enabled;
		for (int k = 0; k < num; k++)
		{
			Player.ControllerHelper controllers = allPlayers_orig[k].controllers;
			controllers.DKtbpgXFibSltryXZZqFGlUsBCa(iYLORkOUOSEEasmcRHMzhlHqunUP);
			if (enabled || rMxEqIvJeWWddFXXpARGQYckQDR)
			{
				controllers.eOQJVQLbEYJpUqpbngwkDpnPoTCd(HkpqDTUFRpMRrOEQVnSMXoFQldZ, qrVEDSepLYqYVSPtpaJcNmLxEsZ, iYLORkOUOSEEasmcRHMzhlHqunUP);
			}
			if (enabled2)
			{
				controllers.dDwopBTjgiBbyPpfOEoeobDFVYM(asfRDzSekmvCpHiAVkQLFwtshxJ, iYLORkOUOSEEasmcRHMzhlHqunUP);
			}
			controllers.PnucCUBgvYFhldakvrKVPhWaiNR(iYLORkOUOSEEasmcRHMzhlHqunUP);
		}
		for (int l = 0; l < jmPQhhdSmzMbfNmhujxPORzPOWc.Length; l++)
		{
			if (jmPQhhdSmzMbfNmhujxPORzPOWc[l].zeUqVPIDVWYcAggYWXLnNfyRBHX != VvbRiPIRRDOGFeaGvZCVmBjRfXT.CIxBuEeASTjOkXSChHkrvFPOWiW.WQNdYJSAYYvmjxKbWASGxbAiIpYg)
			{
				jmPQhhdSmzMbfNmhujxPORzPOWc[l].TIGQjegnUMUwRUVNgQHfuaqPqhU();
			}
		}
		VvbRiPIRRDOGFeaGvZCVmBjRfXT.FmqbFCAglOyiasCaFtvYdiGPKNPD();
		if (!mIybkdemYKTOqJCEXLpKRnfrChDv)
		{
			return;
		}
		if (HoFaqBAdDbKcuzeayPPdDGLgbeza.GWmqAqfHoBawfOQHOApVhYErCejj > 0)
		{
			for (int m = 0; m < jGQlTFOTZwmOauEGXHrDOyuTntc; m++)
			{
				VvbRiPIRRDOGFeaGvZCVmBjRfXT vvbRiPIRRDOGFeaGvZCVmBjRfXT = aRIrccLhfOfqfrZCAqEeQcWCSkS[m];
				if (vvbRiPIRRDOGFeaGvZCVmBjRfXT.zeUqVPIDVWYcAggYWXLnNfyRBHX != VvbRiPIRRDOGFeaGvZCVmBjRfXT.CIxBuEeASTjOkXSChHkrvFPOWiW.WQNdYJSAYYvmjxKbWASGxbAiIpYg)
				{
					HoFaqBAdDbKcuzeayPPdDGLgbeza.fRBYwVckFDGelApOqAuTpyFGMnH(vvbRiPIRRDOGFeaGvZCVmBjRfXT, P_0);
				}
			}
		}
		for (int n = 0; n < LHXUijdjpnmZGwdcLlrvMfDTDEhg; n++)
		{
			rclcWIXPrkQyKbnNIANjIzDkfpB rclcWIXPrkQyKbnNIANjIzDkfpB2 = AoVWIGFmkaussHBpYpzPYXGhmBw[n];
			if (rclcWIXPrkQyKbnNIANjIzDkfpB2.GWmqAqfHoBawfOQHOApVhYErCejj == 0)
			{
				continue;
			}
			for (int num2 = 0; num2 < jGQlTFOTZwmOauEGXHrDOyuTntc; num2++)
			{
				VvbRiPIRRDOGFeaGvZCVmBjRfXT vvbRiPIRRDOGFeaGvZCVmBjRfXT2 = XZFphnyIaSbooGWqtVFLlrzISCP[n, num2];
				if (vvbRiPIRRDOGFeaGvZCVmBjRfXT2.zeUqVPIDVWYcAggYWXLnNfyRBHX != VvbRiPIRRDOGFeaGvZCVmBjRfXT.CIxBuEeASTjOkXSChHkrvFPOWiW.WQNdYJSAYYvmjxKbWASGxbAiIpYg)
				{
					rclcWIXPrkQyKbnNIANjIzDkfpB2.fRBYwVckFDGelApOqAuTpyFGMnH(vvbRiPIRRDOGFeaGvZCVmBjRfXT2, P_0);
				}
			}
		}
	}

	private void nnipvNSBKmDcjCwnjkdZzkiuEWaD(bool P_0, int P_1, int P_2)
	{
		int num = XVroGTnTmiTwGITDVAhlDMsuaLiG.iFNXApJjlWtDZdwedJFKpfGAMok(P_2);
		if (num >= 0)
		{
			if (P_1 == 9999999)
			{
				aRIrccLhfOfqfrZCAqEeQcWCSkS[num].AUSocaxjOFPiynwlRPvgzxGUtHA(P_0);
			}
			else
			{
				XZFphnyIaSbooGWqtVFLlrzISCP[P_1, num].AUSocaxjOFPiynwlRPvgzxGUtHA(P_0);
			}
		}
	}

	private void YsdeYfgDmmTgRjRHrZmXYpzqZOt(BridgedController P_0)
	{
		int num = cqUXmPYEHCxLgOfUwaJfVeSndpg(P_0.sourceJoystick.rewiredId, hbPDZOCSuXiheOvMjbSBMPtfSCE.qHVcGhKvPuKymhkYhwLQLNBDMPo);
		if (num >= 0)
		{
			Logger.LogError("Controller was already in connected list!");
			return;
		}
		num = cqUXmPYEHCxLgOfUwaJfVeSndpg(P_0.sourceJoystick.rewiredId, hbPDZOCSuXiheOvMjbSBMPtfSCE.TOIglsDSYqeGLcutualzaXwPStSU);
		Joystick joystick;
		if (num >= 0)
		{
			joystick = ywLEiQCiOAobwTWmZbbhQQiuYIC[num];
			ywLEiQCiOAobwTWmZbbhQQiuYIC.RemoveAt(num);
			joystick.FMngbHlSISVmcoIhmlrHQoUqlno(P_0);
			joystick.isConnected = true;
		}
		else
		{
			joystick = new Joystick(P_0);
		}
		PwdEInECBiDDjabWgJCuiXatYNFJ.Add(joystick);
		mjbCXiYvUoMzOxiBvCouhdEikme.Add(joystick);
		PwdEInECBiDDjabWgJCuiXatYNFJ.Sort(Joystick.GjOtUikaRXonJoEqPEQUwdULwhf);
		dHzdxJGgfVamEigJTrTmGDfvxRqc.ztcXjeonNMANOsnNizYgnnvxcMY(joystick);
	}

	private void NNgVpjJBuWeIpHkWrikRmACidIQG(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (P_0 >= PwdEInECBiDDjabWgJCuiXatYNFJ.Count)
		{
			Logger.LogError("Device was not in connected list! Cannot remove!");
			return;
		}
		Joystick joystick = PwdEInECBiDDjabWgJCuiXatYNFJ[P_0];
		joystick.isConnected = false;
		if (boUkaKIZrWDvEDSGCebudhCNWFIl != null)
		{
			boUkaKIZrWDvEDSGCebudhCNWFIl(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
		}
		if (kEmCDEOBLWCcttXnEgdrosQqBfn != null)
		{
			kEmCDEOBLWCcttXnEgdrosQqBfn(joystick.type, joystick.id);
		}
		PwdEInECBiDDjabWgJCuiXatYNFJ.RemoveAt(P_0);
		ywLEiQCiOAobwTWmZbbhQQiuYIC.Add(joystick);
		mjbCXiYvUoMzOxiBvCouhdEikme.Remove(joystick);
		dHzdxJGgfVamEigJTrTmGDfvxRqc.EpPUHSOjmleHMsWUMfpjcKkxcPX(joystick);
		joystick.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
	}

	private void kMecESgLhcBeRbVzAyOneHqQBaGq()
	{
		int count = PwdEInECBiDDjabWgJCuiXatYNFJ.Count;
		for (int num = count - 1; num >= 0; num--)
		{
			NNgVpjJBuWeIpHkWrikRmACidIQG(num);
		}
	}

	private bool lObdySffSxtSFDoDQQyUyVZrHkI(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		for (int i = 0; i < ozMPDGPKrryEoMaiFqmJeoSVQba.Count; i++)
		{
			if (ozMPDGPKrryEoMaiFqmJeoSVQba[i] == P_0)
			{
				return true;
			}
		}
		ozMPDGPKrryEoMaiFqmJeoSVQba.Add(P_0);
		mjbCXiYvUoMzOxiBvCouhdEikme.Add(P_0);
		dHzdxJGgfVamEigJTrTmGDfvxRqc.ztcXjeonNMANOsnNizYgnnvxcMY(P_0);
		return true;
	}

	private bool tWdfQmBPudobtUdhGKshtjyjmUgb(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		dHzdxJGgfVamEigJTrTmGDfvxRqc.EpPUHSOjmleHMsWUMfpjcKkxcPX(P_0);
		mjbCXiYvUoMzOxiBvCouhdEikme.Remove(P_0);
		return ozMPDGPKrryEoMaiFqmJeoSVQba.Remove(P_0);
	}

	private rclcWIXPrkQyKbnNIANjIzDkfpB SxDIpXAqrWehLnWSLeRuTTNizfp(int P_0)
	{
		if (P_0 == 9999999)
		{
			return HoFaqBAdDbKcuzeayPPdDGLgbeza;
		}
		if (P_0 < 0 || P_0 >= ReInput.yIRdWijqyghmemPssevxkoxocsUE.gamePlayerCount)
		{
			return null;
		}
		return AoVWIGFmkaussHBpYpzPYXGhmBw[P_0];
	}

	private void DoUEHlIyXyKaDNnkDumByicGjjv(bool P_0)
	{
		if (!P_0)
		{
			qrVEDSepLYqYVSPtpaJcNmLxEsZ.WGomWYfshVDHmufUxNmTGIleoCd();
		}
	}

	private void mmSeCYyGzAcrXjKTdGFrnOLGsGp(bool P_0)
	{
		if (!P_0 && !ReInput.applicationRunInBackground)
		{
			for (int i = 0; i < PwdEInECBiDDjabWgJCuiXatYNFJ.Count; i++)
			{
				PwdEInECBiDDjabWgJCuiXatYNFJ[i].StopVibration();
			}
		}
	}

	public void Dispose()
	{
		hPYtPMXxgzKzMhWWBZyeOBKCxhk(true);
		GC.SuppressFinalize(this);
	}

	~wdexXznqMQgvrkdYBfwPPJZVQDx()
	{
		hPYtPMXxgzKzMhWWBZyeOBKCxhk(false);
	}

	private void hPYtPMXxgzKzMhWWBZyeOBKCxhk(bool P_0)
	{
		if (JtZAxieDBYjDdfBgPPJgrNSxYmS)
		{
			return;
		}
		if (P_0)
		{
			if (kDkaXjirHbZFFctlXAEYdkznSkeB is IDisposable)
			{
				(kDkaXjirHbZFFctlXAEYdkznSkeB as IDisposable).Dispose();
			}
			if (LMDDrFpdadEtNxxESOgzcywBrkG is IDisposable)
			{
				(LMDDrFpdadEtNxxESOgzcywBrkG as IDisposable).Dispose();
			}
		}
		JtZAxieDBYjDdfBgPPJgrNSxYmS = true;
	}
}
