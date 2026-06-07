using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal sealed class rvADANidBCTaBLMwFOZPaxTGMMzTB : IDisposable
{
	public enum eulYAqGqwcEPtrECQAsMrySUqYij
	{
		Connected = 0,
		Disconnected = 1
	}

	private class zDpKVWgTMWLqzLrKVDFkGgpqEJoF
	{
		public ADictionary<int, InputBehavior> chjwRUNZTJUDgxaBLAoftdbQlqjc;

		public List<InputBehavior> EqITHDzghdasdRRNwEnElUbUWsUE;

		public IList<InputBehavior> JdTVAiLfzhehzbGrWleHuQtDtsAOA;

		public zDpKVWgTMWLqzLrKVDFkGgpqEJoF(List<InputBehavior> P_0)
		{
			EqITHDzghdasdRRNwEnElUbUWsUE = new List<InputBehavior>(P_0.Count);
			chjwRUNZTJUDgxaBLAoftdbQlqjc = new ADictionary<int, InputBehavior>();
			int num = 0;
			for (int i = 0; i < P_0.Count; i++)
			{
				InputBehavior inputBehavior = P_0[i].Clone();
				chjwRUNZTJUDgxaBLAoftdbQlqjc.Add(P_0[i].id, inputBehavior);
				EqITHDzghdasdRRNwEnElUbUWsUE.Add(inputBehavior);
				num++;
			}
			JdTVAiLfzhehzbGrWleHuQtDtsAOA = new ReadOnlyCollection<InputBehavior>(EqITHDzghdasdRRNwEnElUbUWsUE);
		}

		public InputBehavior KjhAiQejGFyjZDtXpqazRKCbYBHMA(int P_0)
		{
			if (EqITHDzghdasdRRNwEnElUbUWsUE.Count == 0)
			{
				return null;
			}
			chjwRUNZTJUDgxaBLAoftdbQlqjc.TryGetValue(P_0, out var value);
			if (value == null)
			{
				return EqITHDzghdasdRRNwEnElUbUWsUE[0];
			}
			return value;
		}
	}

	private sealed class nSbQyBaHpWdPYsXnQfmwnKmVKiku : IEnumerable<CustomController>, IEnumerable, IEnumerator<CustomController>, IEnumerator, IDisposable
	{
		private int bZPPAGJLRERZhEESrJMyqTEuUdWW;

		private CustomController LoQpDImfOhldArqRHfRxwXFTFLAq;

		private int hzYlUxDKqDEwvWMUJPotgwTyOvUt;

		public rvADANidBCTaBLMwFOZPaxTGMMzTB odlWjeqEiWDOqCnQrvErmnAkudME;

		private int BqIsSYWGDkZHfPISRPzJhdRVCLEp;

		public int kDQRZiCZdqBTjKmwDcrwcaiWdyGl;

		private int JMlUAOghfTTEmyCpoyHcLrimWRaE;

		private int pDgZouvbufgoHGAQJEScRloIsXDL;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return LoQpDImfOhldArqRHfRxwXFTFLAq;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return LoQpDImfOhldArqRHfRxwXFTFLAq;
			}
		}

		[DebuggerHidden]
		public nSbQyBaHpWdPYsXnQfmwnKmVKiku(int P_0)
		{
			bZPPAGJLRERZhEESrJMyqTEuUdWW = P_0;
			hzYlUxDKqDEwvWMUJPotgwTyOvUt = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = bZPPAGJLRERZhEESrJMyqTEuUdWW;
			rvADANidBCTaBLMwFOZPaxTGMMzTB rvADANidBCTaBLMwFOZPaxTGMMzTB2 = odlWjeqEiWDOqCnQrvErmnAkudME;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				bZPPAGJLRERZhEESrJMyqTEuUdWW = -1;
				goto IL_007d;
			}
			bZPPAGJLRERZhEESrJMyqTEuUdWW = -1;
			JMlUAOghfTTEmyCpoyHcLrimWRaE = rvADANidBCTaBLMwFOZPaxTGMMzTB2.qmWDwbGpKFUNQOjgMMfuTLJkWVmSA.Count;
			pDgZouvbufgoHGAQJEScRloIsXDL = 0;
			goto IL_008d;
			IL_007d:
			pDgZouvbufgoHGAQJEScRloIsXDL++;
			goto IL_008d;
			IL_008d:
			if (pDgZouvbufgoHGAQJEScRloIsXDL < JMlUAOghfTTEmyCpoyHcLrimWRaE)
			{
				if (rvADANidBCTaBLMwFOZPaxTGMMzTB2.qmWDwbGpKFUNQOjgMMfuTLJkWVmSA[pDgZouvbufgoHGAQJEScRloIsXDL].sourceControllerId == BqIsSYWGDkZHfPISRPzJhdRVCLEp)
				{
					LoQpDImfOhldArqRHfRxwXFTFLAq = rvADANidBCTaBLMwFOZPaxTGMMzTB2.qmWDwbGpKFUNQOjgMMfuTLJkWVmSA[pDgZouvbufgoHGAQJEScRloIsXDL];
					bZPPAGJLRERZhEESrJMyqTEuUdWW = 1;
					return true;
				}
				goto IL_007d;
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

		[DebuggerHidden]
		IEnumerator<CustomController> IEnumerable<CustomController>.GetEnumerator()
		{
			nSbQyBaHpWdPYsXnQfmwnKmVKiku nSbQyBaHpWdPYsXnQfmwnKmVKiku2;
			if (bZPPAGJLRERZhEESrJMyqTEuUdWW == -2 && hzYlUxDKqDEwvWMUJPotgwTyOvUt == Environment.CurrentManagedThreadId)
			{
				bZPPAGJLRERZhEESrJMyqTEuUdWW = 0;
				nSbQyBaHpWdPYsXnQfmwnKmVKiku2 = this;
			}
			else
			{
				nSbQyBaHpWdPYsXnQfmwnKmVKiku2 = new nSbQyBaHpWdPYsXnQfmwnKmVKiku(0);
				nSbQyBaHpWdPYsXnQfmwnKmVKiku2.odlWjeqEiWDOqCnQrvErmnAkudME = odlWjeqEiWDOqCnQrvErmnAkudME;
			}
			nSbQyBaHpWdPYsXnQfmwnKmVKiku2.BqIsSYWGDkZHfPISRPzJhdRVCLEp = kDQRZiCZdqBTjKmwDcrwcaiWdyGl;
			return nSbQyBaHpWdPYsXnQfmwnKmVKiku2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}
	}

	private sealed class xfbvyGidsxLUiyQPyGUuYEIrgcLw : IEnumerable<CustomController>, IEnumerable, IEnumerator<CustomController>, IEnumerator, IDisposable
	{
		private int YAiDdyMbqkBTCcaNuKwfBlPQtmjVA;

		private CustomController aSjwXFtoGvGtqDbrFQySqcpkEnuQ;

		private int rsfELxguboAazszGdSibTtOIeJSwA;

		public rvADANidBCTaBLMwFOZPaxTGMMzTB STojrNtrLHFrPRndKzwbBbZZqAqP;

		private string bAahfLckVmhmLQWuSBneuRTHYexMA;

		public string CyMfNGhsXctIbkOjZrtJeKsQVjjwA;

		private int PzauDTXqDngFGdvdlYTgrRlBJdwTA;

		private int VYCzNiszSathBxuFoNCXtnyjGLmi;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return aSjwXFtoGvGtqDbrFQySqcpkEnuQ;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return aSjwXFtoGvGtqDbrFQySqcpkEnuQ;
			}
		}

		[DebuggerHidden]
		public xfbvyGidsxLUiyQPyGUuYEIrgcLw(int P_0)
		{
			YAiDdyMbqkBTCcaNuKwfBlPQtmjVA = P_0;
			rsfELxguboAazszGdSibTtOIeJSwA = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int yAiDdyMbqkBTCcaNuKwfBlPQtmjVA = YAiDdyMbqkBTCcaNuKwfBlPQtmjVA;
			rvADANidBCTaBLMwFOZPaxTGMMzTB sTojrNtrLHFrPRndKzwbBbZZqAqP = STojrNtrLHFrPRndKzwbBbZZqAqP;
			if (yAiDdyMbqkBTCcaNuKwfBlPQtmjVA != 0)
			{
				if (yAiDdyMbqkBTCcaNuKwfBlPQtmjVA != 1)
				{
					return false;
				}
				YAiDdyMbqkBTCcaNuKwfBlPQtmjVA = -1;
				goto IL_0083;
			}
			YAiDdyMbqkBTCcaNuKwfBlPQtmjVA = -1;
			PzauDTXqDngFGdvdlYTgrRlBJdwTA = sTojrNtrLHFrPRndKzwbBbZZqAqP.qmWDwbGpKFUNQOjgMMfuTLJkWVmSA.Count;
			VYCzNiszSathBxuFoNCXtnyjGLmi = 0;
			goto IL_0093;
			IL_0083:
			VYCzNiszSathBxuFoNCXtnyjGLmi++;
			goto IL_0093;
			IL_0093:
			if (VYCzNiszSathBxuFoNCXtnyjGLmi < PzauDTXqDngFGdvdlYTgrRlBJdwTA)
			{
				if (sTojrNtrLHFrPRndKzwbBbZZqAqP.qmWDwbGpKFUNQOjgMMfuTLJkWVmSA[VYCzNiszSathBxuFoNCXtnyjGLmi].tag.Equals(bAahfLckVmhmLQWuSBneuRTHYexMA, StringComparison.OrdinalIgnoreCase))
				{
					aSjwXFtoGvGtqDbrFQySqcpkEnuQ = sTojrNtrLHFrPRndKzwbBbZZqAqP.qmWDwbGpKFUNQOjgMMfuTLJkWVmSA[VYCzNiszSathBxuFoNCXtnyjGLmi];
					YAiDdyMbqkBTCcaNuKwfBlPQtmjVA = 1;
					return true;
				}
				goto IL_0083;
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

		[DebuggerHidden]
		IEnumerator<CustomController> IEnumerable<CustomController>.GetEnumerator()
		{
			xfbvyGidsxLUiyQPyGUuYEIrgcLw xfbvyGidsxLUiyQPyGUuYEIrgcLw2;
			if (YAiDdyMbqkBTCcaNuKwfBlPQtmjVA == -2 && rsfELxguboAazszGdSibTtOIeJSwA == Environment.CurrentManagedThreadId)
			{
				YAiDdyMbqkBTCcaNuKwfBlPQtmjVA = 0;
				xfbvyGidsxLUiyQPyGUuYEIrgcLw2 = this;
			}
			else
			{
				xfbvyGidsxLUiyQPyGUuYEIrgcLw2 = new xfbvyGidsxLUiyQPyGUuYEIrgcLw(0);
				xfbvyGidsxLUiyQPyGUuYEIrgcLw2.STojrNtrLHFrPRndKzwbBbZZqAqP = STojrNtrLHFrPRndKzwbBbZZqAqP;
			}
			xfbvyGidsxLUiyQPyGUuYEIrgcLw2.bAahfLckVmhmLQWuSBneuRTHYexMA = CyMfNGhsXctIbkOjZrtJeKsQVjjwA;
			return xfbvyGidsxLUiyQPyGUuYEIrgcLw2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}
	}

	private List<Joystick> oPZHKvbwBXlVdXrIkuOmnPnEZpYu;

	private List<Joystick> ReHKQvWaInURsUAsObnZyNXUBVFn;

	private List<CustomController> qmWDwbGpKFUNQOjgMMfuTLJkWVmSA;

	private List<Controller> EZSHPBhcVEWhKQvgUxDGHXHwcPSf;

	private ReadOnlyCollection<Controller> IQoAhwhaSVlhmoHLGcJXrFRWiZPGb;

	private Keyboard gpdihnsVBKFcdhAFqfitGQcowLwUA;

	private Mouse BYYngOgctOZoskZpkkAryjfPANHf;

	private ConfigVars bAwkesiCxVagVGvymaRlxMmnRFcvA;

	private KvDFldULABgCdeUydTfHpQtIJWLLA[] DOsSTFxBHHyMAeVNelJMIulMPBoE;

	private KvDFldULABgCdeUydTfHpQtIJWLLA[] mBlQPBqoPitZgepPLPGOwhXPXnwg;

	private KvDFldULABgCdeUydTfHpQtIJWLLA[,] xrqQFKFsIwvLMsZmYWSstJGNcWGU;

	private EPtbMtcNLxEwgFhZDmUBmgoMYKWwB vNCUHWeFYtdAIwwqxKkieKdGPtdP;

	private eKRRFmBsqycdoBxbIwmnkNPvqmFI QchkgBFeKlKbusGFeRjvHmFmhimD;

	private eKRRFmBsqycdoBxbIwmnkNPvqmFI[] KqDwUXpGiRpYgpxkHvMKtOSoJoMk;

	private global::YfwOMdmkzfuzklyvEonrviktmiIs<ActiveControllerChangedDelegate> lLGUhhDxIWQHJSDNQxsUWvCnlsvh;

	private global::YfwOMdmkzfuzklyvEonrviktmiIs<PlayerActiveControllerChangedDelegate> UNGiVuuBBalMLCcPBGOfjLvhKeEcb;

	private global::YfwOMdmkzfuzklyvEonrviktmiIs<PlayerActiveControllerChangedDelegate>[] YfUAdvWcAcNNJAyddwBiNiSrdNsx;

	private ADictionary<int, zDpKVWgTMWLqzLrKVDFkGgpqEJoF> tgMpIiYXwaGkXteRwtewizRIoiWK;

	private readonly luVyYQZUAigRpetoezTKghxXGpjb YywCqGhxSZVJJfKGrblzxgHtNCRuA;

	private IList<Joystick> RWBZoWnKkcDquvXzYhMKHZFxONxS;

	private IList<CustomController> JFdCgRkHCzHFkxAjhCJKDpBgtdpPc;

	private int QXRdTjwoDVzchbKvCrRtojiQBwes;

	private bool agVqhbOhoogMXpPmdTHxqAbtitOc;

	private bool zegBerCUBfDlcINYPgEMBHfuhXUc;

	private bool pBTTIIoLNzzuJNUHdPaFFlvanaIx;

	private IUnifiedKeyboardSource RmojKglJqaAZCivaHnoOgIWildFsA;

	private IUnifiedMouseSource HcyWCwaxkqteamzJQJVJbKJNpTNc;

	private int pQLebspKYjQicBQleRDRCBTMNLWd;

	private lUtCsqIAgfBFkZGlgbTnkPuYJNRDA ZFnuRthTgNtMQoSjnOTMTGpwfSedA;

	private HDJfIqxdWXZdIaCSTaUnYnqTqCtx IjLLOwtSjbeLJilzMmzOYhrLwAXh;

	private int ErKvoOUjBfJePGKjSrbzWogeiRvfA;

	private int vAJEywimdjvkATAjUAMVALeyUkmxA;

	private Action<int, ControllerDataUpdater> KYMradzwsMOEiwrMgHNhqDnFYOYD;

	private Action<bool, int, int> rcZNAkUblCpyIvpzLhcqufymhPhG;

	private Action<ControllerStatusChangedEventArgs> VxHBHrYzuMeUqSaFnBXtfnhjaMhWA;

	private Action<ControllerType, int> dOLtxKGtaNcfvTcJAALvttZYuyPQ;

	private bool HJVMciaotjpkmnljUHJDWQceBDHT;

	public IList<Joystick> PWbnnHEjRpDetJqMBgOLbJodoqfE => RWBZoWnKkcDquvXzYhMKHZFxONxS;

	public List<Joystick> JehfsOJZsoDYYqbqqBiGtrPiJzwpA => oPZHKvbwBXlVdXrIkuOmnPnEZpYu;

	public int LkbCNXDBSBeJusZHNRPbRWQxbsRl => oPZHKvbwBXlVdXrIkuOmnPnEZpYu.Count;

	public Mouse vdLMjGufKFZFbdHWwGFoTfIgNRfT => BYYngOgctOZoskZpkkAryjfPANHf;

	public Keyboard drgNjPBDklMoqhfwuCfPMsCoXTQl => gpdihnsVBKFcdhAFqfitGQcowLwUA;

	public IList<CustomController> rofnZiogmyQlxMWTOPOraCjgRvVT => JFdCgRkHCzHFkxAjhCJKDpBgtdpPc;

	public List<CustomController> JnkieMhCTdPctgXDdUoryStWsRkT => qmWDwbGpKFUNQOjgMMfuTLJkWVmSA;

	public int efRWqpQqHUtuuAjtPTclDqttaDJfA => qmWDwbGpKFUNQOjgMMfuTLJkWVmSA.Count;

	public IList<Controller> CcJUbpcfyeOqdwnSTYsToekkEJiKA => IQoAhwhaSVlhmoHLGcJXrFRWiZPGb;

	public int KTiqjXjbzvvrOFfZTCqwCsiLFRVbb => EZSHPBhcVEWhKQvgUxDGHXHwcPSf.Count;

	private int uDZwFhXAyXYrgnspmfaxdQAgLSRI
	{
		get
		{
			int result = pQLebspKYjQicBQleRDRCBTMNLWd;
			pQLebspKYjQicBQleRDRCBTMNLWd++;
			if (pQLebspKYjQicBQleRDRCBTMNLWd >= int.MaxValue)
			{
				pQLebspKYjQicBQleRDRCBTMNLWd = 0;
			}
			return result;
		}
	}

	public event Action<ControllerStatusChangedEventArgs> TRTBvOLkgojePeyYLPZtPxyOWXvTA
	{
		add
		{
			VxHBHrYzuMeUqSaFnBXtfnhjaMhWA = (Action<ControllerStatusChangedEventArgs>)Delegate.Combine(VxHBHrYzuMeUqSaFnBXtfnhjaMhWA, b);
		}
		remove
		{
			VxHBHrYzuMeUqSaFnBXtfnhjaMhWA = (Action<ControllerStatusChangedEventArgs>)Delegate.Remove(VxHBHrYzuMeUqSaFnBXtfnhjaMhWA, value2);
		}
	}

	public event Action<ControllerType, int> nDoOzSNQExaMLQhpCopXHmvtBcSJA
	{
		add
		{
			dOLtxKGtaNcfvTcJAALvttZYuyPQ = (Action<ControllerType, int>)Delegate.Combine(dOLtxKGtaNcfvTcJAALvttZYuyPQ, b);
		}
		remove
		{
			dOLtxKGtaNcfvTcJAALvttZYuyPQ = (Action<ControllerType, int>)Delegate.Remove(dOLtxKGtaNcfvTcJAALvttZYuyPQ, value2);
		}
	}

	public rvADANidBCTaBLMwFOZPaxTGMMzTB(ConfigVars P_0, PlatformInputManager P_1)
	{
		bAwkesiCxVagVGvymaRlxMmnRFcvA = P_0;
		QXRdTjwoDVzchbKvCrRtojiQBwes = 0;
		agVqhbOhoogMXpPmdTHxqAbtitOc = UnityTools.isAndroidPlatform;
		EZSHPBhcVEWhKQvgUxDGHXHwcPSf = new List<Controller>(10);
		IQoAhwhaSVlhmoHLGcJXrFRWiZPGb = new ReadOnlyCollection<Controller>(EZSHPBhcVEWhKQvgUxDGHXHwcPSf);
		IUnifiedKeyboardSource unifiedKeyboardSource = P_1.GetUnifiedKeyboardSource();
		if (unifiedKeyboardSource == null)
		{
			unifiedKeyboardSource = (RmojKglJqaAZCivaHnoOgIWildFsA = new UnityUnifiedKeyboardSource());
		}
		gpdihnsVBKFcdhAFqfitGQcowLwUA = new Keyboard("Keyboard", unifiedKeyboardSource);
		EZSHPBhcVEWhKQvgUxDGHXHwcPSf.Add(gpdihnsVBKFcdhAFqfitGQcowLwUA);
		IUnifiedMouseSource unifiedMouseSource = P_1.GetUnifiedMouseSource();
		if (unifiedMouseSource == null)
		{
			unifiedMouseSource = (HcyWCwaxkqteamzJQJVJbKJNpTNc = new UnityUnifiedMouseSource());
		}
		BYYngOgctOZoskZpkkAryjfPANHf = new Mouse("Mouse", unifiedMouseSource);
		EZSHPBhcVEWhKQvgUxDGHXHwcPSf.Add(BYYngOgctOZoskZpkkAryjfPANHf);
		vNCUHWeFYtdAIwwqxKkieKdGPtdP = new EPtbMtcNLxEwgFhZDmUBmgoMYKWwB(P_0.updateLoop, gpdihnsVBKFcdhAFqfitGQcowLwUA);
		gpdihnsVBKFcdhAFqfitGQcowLwUA.qZJEWltPOoLpMvBVmRrxVlfNERYU += uNSZUYqgeoTNEFBXWTFfdvCYdjqb;
		gpdihnsVBKFcdhAFqfitGQcowLwUA.enabled = !P_0.GetPlatformVar_disableKeyboard();
		BYYngOgctOZoskZpkkAryjfPANHf.enabled = !P_0.GetPlatformVar_disableMouse();
		qFNgDRrnPTMkkavmrIgfBeDFETAv.cJgFKmUqixrPxDvxevQaYldWsjtD();
		YywCqGhxSZVJJfKGrblzxgHtNCRuA = new luVyYQZUAigRpetoezTKghxXGpjb(UnityTools.externalTools.GetControllerTemplateTypes(), UnityTools.externalTools.GetControllerTemplateInterfaceTypes());
		YywCqGhxSZVJJfKGrblzxgHtNCRuA.JtDcHaHpJBOhVcxCDTnbPglAlCNdc(gpdihnsVBKFcdhAFqfitGQcowLwUA);
		YywCqGhxSZVJJfKGrblzxgHtNCRuA.JtDcHaHpJBOhVcxCDTnbPglAlCNdc(BYYngOgctOZoskZpkkAryjfPANHf);
		ReInput.ApplicationFocusChangedEvent += ySccSQFWOHgiiFLBcehatAykmTYH;
	}

	public void WjuvJAnKsiKatPxSDLkAvcmdzEMU(Action<int, ControllerDataUpdater> P_0, List<InputBehavior> P_1)
	{
		KYMradzwsMOEiwrMgHNhqDnFYOYD = P_0;
		uqdmOWseeZbmckrCkSYZAvvfLdUrA(P_1);
	}

	public void cATzubNdIyFPDPSctiuQhaiENxvm(UpdateLoopType P_0)
	{
		qFNgDRrnPTMkkavmrIgfBeDFETAv.bJxLFzLpNIidRtiKQjxKpCWjlQod(P_0);
		if (gpdihnsVBKFcdhAFqfitGQcowLwUA.enabled)
		{
			vNCUHWeFYtdAIwwqxKkieKdGPtdP.aOmojAuIpjUtsFgwhYOIrlewHidg(P_0);
		}
		QkmuudMmGCBkLJxNvtFhjqfHGNqIb(P_0);
		wSrJOJBkSTaneFwYFgdjpLwTXANKA(P_0);
		qFNgDRrnPTMkkavmrIgfBeDFETAv.jpAsTVmMfDpHvDpJDuqDQyBqFFvr(P_0, ReInput.currentFrame);
		if (pBTTIIoLNzzuJNUHdPaFFlvanaIx)
		{
			lxyEssEjBqQFZdTpcWCyMJIlCIXlB();
		}
	}

	public KvDFldULABgCdeUydTfHpQtIJWLLA ZimQjDSkGlLRmehJHaubWQGDxxKl(int P_0, string P_1, bool P_2)
	{
		int num = ZFnuRthTgNtMQoSjnOTMTGpwfSedA.nGtOoNcuCYgrmozQJioimkJEvJsL(P_1, P_2);
		if (num < 0)
		{
			return null;
		}
		if (P_0 == 9999999)
		{
			return mBlQPBqoPitZgepPLPGOwhXPXnwg[num];
		}
		if (P_0 < 0 || P_0 >= ErKvoOUjBfJePGKjSrbzWogeiRvfA)
		{
			return null;
		}
		return xrqQFKFsIwvLMsZmYWSstJGNcWGU[P_0, num];
	}

	public KvDFldULABgCdeUydTfHpQtIJWLLA rHxPDwYVNrsGvqoRZhPDldvonnvd(int P_0, int P_1, bool P_2)
	{
		int num = ZFnuRthTgNtMQoSjnOTMTGpwfSedA.iSPjDaBlidVkgDFbcWGdrWlErgNn(P_1, P_2);
		if (num < 0)
		{
			return null;
		}
		if (P_0 == 9999999)
		{
			return mBlQPBqoPitZgepPLPGOwhXPXnwg[num];
		}
		return xrqQFKFsIwvLMsZmYWSstJGNcWGU[P_0, num];
	}

	public void olUGwnkOpYtjBzBtxvmTuLEhXbeK(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 != null && P_0.sourceJoystick != null)
		{
			eulYAqGqwcEPtrECQAsMrySUqYij eulYAqGqwcEPtrECQAsMrySUqYij2 = eulYAqGqwcEPtrECQAsMrySUqYij.Connected;
			int num = rkxXlODNDEatsELfZvQnBinqmWWcA(P_0.sourceJoystick.rewiredId, eulYAqGqwcEPtrECQAsMrySUqYij2);
			if (num < 0)
			{
				eulYAqGqwcEPtrECQAsMrySUqYij2 = eulYAqGqwcEPtrECQAsMrySUqYij.Disconnected;
				num = rkxXlODNDEatsELfZvQnBinqmWWcA(P_0.sourceJoystick.rewiredId, eulYAqGqwcEPtrECQAsMrySUqYij2);
			}
			if (num >= 0)
			{
				((eulYAqGqwcEPtrECQAsMrySUqYij2 == eulYAqGqwcEPtrECQAsMrySUqYij.Connected) ? oPZHKvbwBXlVdXrIkuOmnPnEZpYu[num] : ReHKQvWaInURsUAsObnZyNXUBVFn[num]).cmhXjjVebxbKSEQPNNYgtRYAADvs(P_0);
			}
		}
	}

	public bool cvVGayNpBsvQUjVrGSCDPhfFHiHz(int P_0, eulYAqGqwcEPtrECQAsMrySUqYij P_1)
	{
		if (rkxXlODNDEatsELfZvQnBinqmWWcA(P_0, P_1) < 0)
		{
			return false;
		}
		return true;
	}

	public int rkxXlODNDEatsELfZvQnBinqmWWcA(int P_0, eulYAqGqwcEPtrECQAsMrySUqYij P_1)
	{
		switch (P_1)
		{
		case eulYAqGqwcEPtrECQAsMrySUqYij.Connected:
		{
			int count2 = oPZHKvbwBXlVdXrIkuOmnPnEZpYu.Count;
			for (int j = 0; j < count2; j++)
			{
				if (oPZHKvbwBXlVdXrIkuOmnPnEZpYu[j].id == P_0)
				{
					return j;
				}
			}
			break;
		}
		case eulYAqGqwcEPtrECQAsMrySUqYij.Disconnected:
		{
			int count = ReHKQvWaInURsUAsObnZyNXUBVFn.Count;
			for (int i = 0; i < count; i++)
			{
				if (ReHKQvWaInURsUAsObnZyNXUBVFn[i].id == P_0)
				{
					return i;
				}
			}
			break;
		}
		}
		return -1;
	}

	public int gZCWOBrjJnANBQBETZiAqIUXnSrM(Guid P_0, eulYAqGqwcEPtrECQAsMrySUqYij P_1)
	{
		switch (P_1)
		{
		case eulYAqGqwcEPtrECQAsMrySUqYij.Connected:
		{
			int count2 = oPZHKvbwBXlVdXrIkuOmnPnEZpYu.Count;
			for (int j = 0; j < count2; j++)
			{
				if (oPZHKvbwBXlVdXrIkuOmnPnEZpYu[j].deviceInstanceGuid == P_0)
				{
					return j;
				}
			}
			break;
		}
		case eulYAqGqwcEPtrECQAsMrySUqYij.Disconnected:
		{
			int count = ReHKQvWaInURsUAsObnZyNXUBVFn.Count;
			for (int i = 0; i < count; i++)
			{
				if (ReHKQvWaInURsUAsObnZyNXUBVFn[i].deviceInstanceGuid == P_0)
				{
					return i;
				}
			}
			break;
		}
		}
		return -1;
	}

	public bool ndayFNAaTGkMOWpUQOhXzPFgEAsm(int P_0)
	{
		if (pOqPmEJMCRdpJhxjfchvfWWiRoerb(P_0) < 0)
		{
			return false;
		}
		return true;
	}

	public int pOqPmEJMCRdpJhxjfchvfWWiRoerb(int P_0)
	{
		int count = qmWDwbGpKFUNQOjgMMfuTLJkWVmSA.Count;
		for (int i = 0; i < count; i++)
		{
			if (qmWDwbGpKFUNQOjgMMfuTLJkWVmSA[i].id == P_0)
			{
				return i;
			}
		}
		return -1;
	}

	public int kstaVDFsuchPTyPUrMWfkQorfsCZA(Guid P_0)
	{
		int count = qmWDwbGpKFUNQOjgMMfuTLJkWVmSA.Count;
		for (int i = 0; i < count; i++)
		{
			if (qmWDwbGpKFUNQOjgMMfuTLJkWVmSA[i].deviceInstanceGuid == P_0)
			{
				return i;
			}
		}
		return -1;
	}

	public void CcJGgTPbioYNwYtiFfhhBcRQwAzM(BridgedController P_0)
	{
		FwgctfBHJRDfZaWZOaNaIsxnDpyP(P_0);
	}

	public void PtjHyheWFBGtQuReuvBvkOJSzNEh(int P_0)
	{
		int num = rkxXlODNDEatsELfZvQnBinqmWWcA(P_0, eulYAqGqwcEPtrECQAsMrySUqYij.Connected);
		GKQFEVltQMCKITjBlnDSCjxWNTJf(num);
	}

	public int gEDdzpLkBWiuJgkOGISNpNPMikp()
	{
		return QXRdTjwoDVzchbKvCrRtojiQBwes++;
	}

	public IList<InputBehavior> yxlcXWJyivSECaVXCcPaGrFzeWGN(int P_0)
	{
		if (!tgMpIiYXwaGkXteRwtewizRIoiWK.ContainsKey(P_0))
		{
			return new List<InputBehavior>();
		}
		return tgMpIiYXwaGkXteRwtewizRIoiWK[P_0].JdTVAiLfzhehzbGrWleHuQtDtsAOA;
	}

	public InputBehavior nuatKlntTuiBBKKYpVnEkwckMurb(int P_0, string P_1)
	{
		if (P_1 == null || P_1 == string.Empty)
		{
			return null;
		}
		int inputBehaviorId = ReInput.mapping.GetInputBehaviorId(P_1);
		return mcSowgfWkICbLviMcwKVuFBXwNmK(P_0, inputBehaviorId);
	}

	public InputBehavior mcSowgfWkICbLviMcwKVuFBXwNmK(int P_0, int P_1)
	{
		if (!tgMpIiYXwaGkXteRwtewizRIoiWK.ContainsKey(P_0))
		{
			return null;
		}
		IList<InputBehavior> jdTVAiLfzhehzbGrWleHuQtDtsAOA = tgMpIiYXwaGkXteRwtewizRIoiWK[P_0].JdTVAiLfzhehzbGrWleHuQtDtsAOA;
		for (int i = 0; i < jdTVAiLfzhehzbGrWleHuQtDtsAOA.Count; i++)
		{
			if (jdTVAiLfzhehzbGrWleHuQtDtsAOA[i].id == P_1)
			{
				return jdTVAiLfzhehzbGrWleHuQtDtsAOA[i];
			}
		}
		return null;
	}

	public Joystick OxrgsiKBGdmiKjOdZinhwnxwTyjnA(int P_0, bool P_1 = false)
	{
		int num = rkxXlODNDEatsELfZvQnBinqmWWcA(P_0, eulYAqGqwcEPtrECQAsMrySUqYij.Connected);
		if (num >= 0)
		{
			return oPZHKvbwBXlVdXrIkuOmnPnEZpYu[num];
		}
		if (P_1)
		{
			num = rkxXlODNDEatsELfZvQnBinqmWWcA(P_0, eulYAqGqwcEPtrECQAsMrySUqYij.Disconnected);
			if (num >= 0)
			{
				return ReHKQvWaInURsUAsObnZyNXUBVFn[num];
			}
		}
		return null;
	}

	public Joystick RQJOESuaZQjCCSJkSkdFIdViPsyX(Guid P_0, bool P_1 = false)
	{
		int num = gZCWOBrjJnANBQBETZiAqIUXnSrM(P_0, eulYAqGqwcEPtrECQAsMrySUqYij.Connected);
		if (num >= 0)
		{
			return oPZHKvbwBXlVdXrIkuOmnPnEZpYu[num];
		}
		if (P_1)
		{
			num = gZCWOBrjJnANBQBETZiAqIUXnSrM(P_0, eulYAqGqwcEPtrECQAsMrySUqYij.Disconnected);
			if (num >= 0)
			{
				return ReHKQvWaInURsUAsObnZyNXUBVFn[num];
			}
		}
		return null;
	}

	public Joystick[] UPGEeOdRDNSgZRhYrklrsIWcepCVA()
	{
		int count = oPZHKvbwBXlVdXrIkuOmnPnEZpYu.Count;
		if (count == 0)
		{
			return EmptyObjects<Joystick>.array;
		}
		Joystick[] array = new Joystick[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = oPZHKvbwBXlVdXrIkuOmnPnEZpYu[i];
		}
		return array;
	}

	public string[] TVmcEHtBdCnDFIrCARaoDkhhWQfi()
	{
		int count = oPZHKvbwBXlVdXrIkuOmnPnEZpYu.Count;
		if (count == 0)
		{
			return EmptyObjects<string>.array;
		}
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = oPZHKvbwBXlVdXrIkuOmnPnEZpYu[i].name;
		}
		return array;
	}

	public CustomController isoqtKYJECuhecyRiMjBXSMSGjSO(int P_0)
	{
		int num = pOqPmEJMCRdpJhxjfchvfWWiRoerb(P_0);
		if (num < 0)
		{
			return null;
		}
		return qmWDwbGpKFUNQOjgMMfuTLJkWVmSA[num];
	}

	public CustomController bUqSVwXqznPrYvPQPHEwsAVrTgfd(Guid P_0)
	{
		int num = kstaVDFsuchPTyPUrMWfkQorfsCZA(P_0);
		if (num < 0)
		{
			return null;
		}
		return qmWDwbGpKFUNQOjgMMfuTLJkWVmSA[num];
	}

	public CustomController[] zLcCpYjSOohkyznYQcVVtXyloMhE()
	{
		int count = qmWDwbGpKFUNQOjgMMfuTLJkWVmSA.Count;
		if (count == 0)
		{
			return EmptyObjects<CustomController>.array;
		}
		CustomController[] array = new CustomController[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = qmWDwbGpKFUNQOjgMMfuTLJkWVmSA[i];
		}
		return array;
	}

	public string[] EwpbOsgZAtbiSaObABCqbusVkRDnc()
	{
		int count = qmWDwbGpKFUNQOjgMMfuTLJkWVmSA.Count;
		if (count == 0)
		{
			return EmptyObjects<string>.array;
		}
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = qmWDwbGpKFUNQOjgMMfuTLJkWVmSA[i].name;
		}
		return array;
	}

	public CustomController eCVKPANUKkNwYdDVztQrzDjKaPIm(int P_0)
	{
		CustomController_Editor customControllerById = ReInput.UserData.GetCustomControllerById(P_0);
		if (customControllerById == null)
		{
			return null;
		}
		int zcEBhdemvwOCgqjJBpVKxyqbtteP = uDZwFhXAyXYrgnspmfaxdQAgLSRI;
		CustomController customController = new CustomController(new ZAhIiLqVPOrLiMeHCaikprQgoMUO
		{
			IMMSYPqanXNmgGIWEzfqZNUFzqKR = InputSource.Custom,
			daVSXIGJerjTyUbuxeeTvxmxZLOy = customControllerById.descriptiveName,
			ZhGQJQcUijwpsIDbVBWymaPvbbsY = customControllerById.name,
			LBJpICysyvATKaHrVySYjkFcjgzEb = customControllerById.axisCount,
			aoKZHSPHWeAfqeoNrVCTcwtnCpRpA = customControllerById.buttonCount,
			ZcEBhdemvwOCgqjJBpVKxyqbtteP = zcEBhdemvwOCgqjJBpVKxyqbtteP,
			JwjLLuDBXcEDqqxmzootgfIjacFGA = customControllerById.id,
			qTBrYjzzAkUmEklvtRhaUQcwhOSg = customControllerById.typeGuid,
			BTDTuJYzrAhVtSPVqSuXasocaefd = customControllerById.id.ToString(),
			imIiOAjGTUBdRVMcuhyaKlyGFzws = customControllerById.CreateGameHardwareMap()
		});
		cOlhCDWazrElelMoYhaVfiSnIGEcA(customController);
		return customController;
	}

	public bool JDtcOknBrwYabvehllYYUtlakYyP(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		return oiZOFxMtxUnLDZBsAJGxjQpYDVmN(P_0);
	}

	public CustomController TnvKWGIBTrKENppmGptWClkBKQjj(int P_0)
	{
		int count = qmWDwbGpKFUNQOjgMMfuTLJkWVmSA.Count;
		for (int i = 0; i < count; i++)
		{
			if (qmWDwbGpKFUNQOjgMMfuTLJkWVmSA[i].sourceControllerId == P_0)
			{
				return qmWDwbGpKFUNQOjgMMfuTLJkWVmSA[i];
			}
		}
		return null;
	}

	public CustomController yKdeepKkoYPwBDUeiFgTmcRgagsmB(string P_0)
	{
		int count = qmWDwbGpKFUNQOjgMMfuTLJkWVmSA.Count;
		for (int i = 0; i < count; i++)
		{
			if (qmWDwbGpKFUNQOjgMMfuTLJkWVmSA[i].tag.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return qmWDwbGpKFUNQOjgMMfuTLJkWVmSA[i];
			}
		}
		return null;
	}

	[IteratorStateMachine(typeof(nSbQyBaHpWdPYsXnQfmwnKmVKiku))]
	public IEnumerable<CustomController> UewXmASMtKWuOjDSarewXUOagbVm(int P_0)
	{
		return new nSbQyBaHpWdPYsXnQfmwnKmVKiku(-2)
		{
			odlWjeqEiWDOqCnQrvErmnAkudME = this,
			kDQRZiCZdqBTjKmwDcrwcaiWdyGl = P_0
		};
	}

	[IteratorStateMachine(typeof(xfbvyGidsxLUiyQPyGUuYEIrgcLw))]
	public IEnumerable<CustomController> LNXWnfJxELSAbdselugnHVeAHofD(string P_0)
	{
		return new xfbvyGidsxLUiyQPyGUuYEIrgcLw(-2)
		{
			STojrNtrLHFrPRndKzwbBbZZqAqP = this,
			CyMfNGhsXctIbkOjZrtJeKsQVjjwA = P_0
		};
	}

	public Controller mIEmXinDLSYEQVEphxqMuRdgYjDG(ControllerType P_0, int P_1, bool P_2 = false)
	{
		return P_0 switch
		{
			ControllerType.Joystick => OxrgsiKBGdmiKjOdZinhwnxwTyjnA(P_1, P_2), 
			ControllerType.Keyboard => gpdihnsVBKFcdhAFqfitGQcowLwUA, 
			ControllerType.Mouse => BYYngOgctOZoskZpkkAryjfPANHf, 
			ControllerType.Custom => isoqtKYJECuhecyRiMjBXSMSGjSO(P_1), 
			_ => throw new NotImplementedException(), 
		};
	}

	public Controller iWKDuUmuGfUgHbDyxkQQwLEfoSAA(ControllerIdentifier P_0, bool P_1 = false)
	{
		if (P_0.deviceInstanceGuid != Guid.Empty)
		{
			return LEtlBiwHFWfiwcbArPrYSEnmWhpf(P_0.deviceInstanceGuid);
		}
		if (P_0.controllerId >= 0)
		{
			return mIEmXinDLSYEQVEphxqMuRdgYjDG(P_0.controllerType, P_0.controllerId, P_1);
		}
		return null;
	}

	public Controller LEtlBiwHFWfiwcbArPrYSEnmWhpf(Guid P_0, bool P_1 = false)
	{
		if (P_0 == Guid.Empty)
		{
			return null;
		}
		if (gpdihnsVBKFcdhAFqfitGQcowLwUA.deviceInstanceGuid == P_0)
		{
			return gpdihnsVBKFcdhAFqfitGQcowLwUA;
		}
		if (BYYngOgctOZoskZpkkAryjfPANHf.deviceInstanceGuid == P_0)
		{
			return BYYngOgctOZoskZpkkAryjfPANHf;
		}
		Controller result;
		if ((result = RQJOESuaZQjCCSJkSkdFIdViPsyX(P_0, P_1)) != null)
		{
			return result;
		}
		if ((result = bUqSVwXqznPrYvPQPHEwsAVrTgfd(P_0)) != null)
		{
			return result;
		}
		return null;
	}

	public Controller[] VQdsidmgyvDLqJgWZglylOukVfLy(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => UPGEeOdRDNSgZRhYrklrsIWcepCVA(), 
			ControllerType.Keyboard => new Controller[1] { gpdihnsVBKFcdhAFqfitGQcowLwUA }, 
			ControllerType.Mouse => new Controller[1] { BYYngOgctOZoskZpkkAryjfPANHf }, 
			ControllerType.Custom => zLcCpYjSOohkyznYQcVVtXyloMhE(), 
			_ => throw new NotImplementedException(), 
		};
	}

	public string[] VApgfmbMndFcfTpCLoICQqJDJpQj(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => TVmcEHtBdCnDFIrCARaoDkhhWQfi(), 
			ControllerType.Keyboard => new string[1] { gpdihnsVBKFcdhAFqfitGQcowLwUA.name }, 
			ControllerType.Mouse => new string[1] { BYYngOgctOZoskZpkkAryjfPANHf.name }, 
			ControllerType.Custom => EwpbOsgZAtbiSaObABCqbusVkRDnc(), 
			_ => throw new NotImplementedException(), 
		};
	}

	public void JBWbAibIbBpkjtyMlajopEyeLIvib(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		if (!zegBerCUBfDlcINYPgEMBHfuhXUc)
		{
			zegBerCUBfDlcINYPgEMBHfuhXUc = true;
		}
		LfCxDGnEKrHlMdAsDkLgvTdxrQKtA(P_0)?.VGWHTLvlubTIkSczclwfdrKcLqwh(P_1, P_2, InputActionEventType.Update, null);
	}

	public void xlOepvKqaKjguaqjDpGPfVfnSOSH(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		if (!zegBerCUBfDlcINYPgEMBHfuhXUc)
		{
			zegBerCUBfDlcINYPgEMBHfuhXUc = true;
		}
		LfCxDGnEKrHlMdAsDkLgvTdxrQKtA(P_0)?.bRibQrgNavKeHjaJKaaHhMRRghMT(P_1, P_2, InputActionEventType.Update, P_3, null);
	}

	public void zccjvoYbVboTEBAHSItGjHOzzPxq(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		if (!zegBerCUBfDlcINYPgEMBHfuhXUc)
		{
			zegBerCUBfDlcINYPgEMBHfuhXUc = true;
		}
		int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(P_3);
		if (num >= 0)
		{
			xlOepvKqaKjguaqjDpGPfVfnSOSH(P_0, P_1, P_2, num);
		}
	}

	public void hniBgTsVlhuVUTtbxEOUWgMSaihbA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, object[] P_4)
	{
		if (!zegBerCUBfDlcINYPgEMBHfuhXUc)
		{
			zegBerCUBfDlcINYPgEMBHfuhXUc = true;
		}
		LfCxDGnEKrHlMdAsDkLgvTdxrQKtA(P_0)?.VGWHTLvlubTIkSczclwfdrKcLqwh(P_1, P_2, P_3, P_4);
	}

	public void oFtxMXUeOKljBJNrnjLMiXURHpAl(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4, object[] P_5)
	{
		if (!zegBerCUBfDlcINYPgEMBHfuhXUc)
		{
			zegBerCUBfDlcINYPgEMBHfuhXUc = true;
		}
		LfCxDGnEKrHlMdAsDkLgvTdxrQKtA(P_0)?.bRibQrgNavKeHjaJKaaHhMRRghMT(P_1, P_2, P_3, P_4, P_5);
	}

	public void jdUNIejylHQWGrcyquXzKdyKJTxA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4, object[] P_5)
	{
		if (!zegBerCUBfDlcINYPgEMBHfuhXUc)
		{
			zegBerCUBfDlcINYPgEMBHfuhXUc = true;
		}
		int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(P_4);
		if (num >= 0)
		{
			oFtxMXUeOKljBJNrnjLMiXURHpAl(P_0, P_1, P_2, P_3, num, P_5);
		}
	}

	public void rivoBbpbcwiqPIOAgGXrGiWCpSoVA(int P_0, Action<InputActionEventData> P_1)
	{
		LfCxDGnEKrHlMdAsDkLgvTdxrQKtA(P_0)?.GiWbeRAgDipaLrUWIYIpPCoUCAzI(P_1);
	}

	public void rZTLhotjktHgpBGUrmGDfLHDSvZQB(int P_0, Action<InputActionEventData> P_1, int P_2)
	{
		LfCxDGnEKrHlMdAsDkLgvTdxrQKtA(P_0)?.UwxTiQONVJqVgFuOgVSrkfGocWXhA(P_1, P_2);
	}

	public void MslGLKvmmdlcSvSBohZbtZWZjELe(int P_0, Action<InputActionEventData> P_1, string P_2)
	{
		int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(P_2);
		if (num >= 0)
		{
			rZTLhotjktHgpBGUrmGDfLHDSvZQB(P_0, P_1, num);
		}
	}

	public void NtNKIkvoVIqycKFAZbGztCQVNCWF(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		LfCxDGnEKrHlMdAsDkLgvTdxrQKtA(P_0)?.YDjwhBzPqLFIhsjQakBkXVetLYxF(P_1, P_2);
	}

	public void SAyhDnUCrVQojQDDqlruUqBpfhDx(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2)
	{
		LfCxDGnEKrHlMdAsDkLgvTdxrQKtA(P_0)?.RdDfDdcxQOMcKOtVwbGELGrNpPEiA(P_1, P_2);
	}

	public void qTHhKfxISbMsIFKHHWTACCeriCME(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		LfCxDGnEKrHlMdAsDkLgvTdxrQKtA(P_0)?.XvPtXYnFKYGHBjUbbHmxuBBQgFjc(P_1, P_2, P_3);
	}

	public void JRRdiNBRnUxcfvFtvGNNDbeiXIYoA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(P_3);
		if (num >= 0)
		{
			qTHhKfxISbMsIFKHHWTACCeriCME(P_0, P_1, P_2, num);
		}
	}

	public void UyeLcWqonGduVHMaxYLvEMJhYOGrA(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, int P_3)
	{
		LfCxDGnEKrHlMdAsDkLgvTdxrQKtA(P_0)?.xTcyvtWyFlKikmmCxzbPNAmUGQOFA(P_1, P_2, P_3);
	}

	public void LRrSHvEgNDEbaChywforNkjcnpkP(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, string P_3)
	{
		int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(P_3);
		if (num >= 0)
		{
			UyeLcWqonGduVHMaxYLvEMJhYOGrA(P_0, P_1, P_2, num);
		}
	}

	public void AHDkxfgFjlgdLbqoRhYbGKCheLyXB(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3)
	{
		LfCxDGnEKrHlMdAsDkLgvTdxrQKtA(P_0)?.htLxiMKEctWkErqQfQAdIoUkSCPg(P_1, P_2, P_3);
	}

	public void ABGsOfDCuqSJuimXxbsFktfhvbQz(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4)
	{
		LfCxDGnEKrHlMdAsDkLgvTdxrQKtA(P_0)?.HddKxCnNCYKsGKOyMAHOKPUMFZwfA(P_1, P_2, P_3, P_4);
	}

	public void mOfqJwGdDnqNYpUrdKYKHqfMqMWq(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4)
	{
		int num = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.QxyvowDDpotMoPiXIJWolBJvCxOV(P_4);
		if (num >= 0)
		{
			ABGsOfDCuqSJuimXxbsFktfhvbQz(P_0, P_1, P_2, P_3, num);
		}
	}

	public void kVLGEfyuodSITNBdcAYYbKXYaMTo(int P_0)
	{
		LfCxDGnEKrHlMdAsDkLgvTdxrQKtA(P_0)?.scScQNlpGWHleZvpbWFmSIqTjsIK();
	}

	public bool JEFotBfKuCFGvwYyxpZnsLteLmQH(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < mBlQPBqoPitZgepPLPGOwhXPXnwg.Length; i++)
			{
				if (mBlQPBqoPitZgepPLPGOwhXPXnwg[i].jonBMeBgjqmpKxavKozLAPygznlzb())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= ErKvoOUjBfJePGKjSrbzWogeiRvfA)
		{
			return false;
		}
		int num = ZFnuRthTgNtMQoSjnOTMTGpwfSedA.GoIOqdlPCzCvEFwUfldukyRwTcoY;
		for (int j = 0; j < num; j++)
		{
			if (xrqQFKFsIwvLMsZmYWSstJGNcWGU[P_0, j].jonBMeBgjqmpKxavKozLAPygznlzb())
			{
				return true;
			}
		}
		return false;
	}

	public bool TXtRpXqPUSQzmCzvIxwIgfDABDRg(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < mBlQPBqoPitZgepPLPGOwhXPXnwg.Length; i++)
			{
				if (mBlQPBqoPitZgepPLPGOwhXPXnwg[i].AHAfXYajBSoiRkPUeJcdIbrWdSzT())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= ErKvoOUjBfJePGKjSrbzWogeiRvfA)
		{
			return false;
		}
		int num = ZFnuRthTgNtMQoSjnOTMTGpwfSedA.GoIOqdlPCzCvEFwUfldukyRwTcoY;
		for (int j = 0; j < num; j++)
		{
			if (xrqQFKFsIwvLMsZmYWSstJGNcWGU[P_0, j].AHAfXYajBSoiRkPUeJcdIbrWdSzT())
			{
				return true;
			}
		}
		return false;
	}

	public bool GhNWHSHMvWqeTQRWiSfThsuptNnI(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < mBlQPBqoPitZgepPLPGOwhXPXnwg.Length; i++)
			{
				if (mBlQPBqoPitZgepPLPGOwhXPXnwg[i].QhIFFGmODJeZADKlMzrwrvViMkFFA())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= ErKvoOUjBfJePGKjSrbzWogeiRvfA)
		{
			return false;
		}
		int num = ZFnuRthTgNtMQoSjnOTMTGpwfSedA.GoIOqdlPCzCvEFwUfldukyRwTcoY;
		for (int j = 0; j < num; j++)
		{
			if (xrqQFKFsIwvLMsZmYWSstJGNcWGU[P_0, j].QhIFFGmODJeZADKlMzrwrvViMkFFA())
			{
				return true;
			}
		}
		return false;
	}

	public bool WtTJvoPdusNImqFjvWaFUmyqosAF(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < mBlQPBqoPitZgepPLPGOwhXPXnwg.Length; i++)
			{
				if (mBlQPBqoPitZgepPLPGOwhXPXnwg[i].ErHrVSCsDYUYvOhOGtaLWvLzkRUv())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= ErKvoOUjBfJePGKjSrbzWogeiRvfA)
		{
			return false;
		}
		int num = ZFnuRthTgNtMQoSjnOTMTGpwfSedA.GoIOqdlPCzCvEFwUfldukyRwTcoY;
		for (int j = 0; j < num; j++)
		{
			if (xrqQFKFsIwvLMsZmYWSstJGNcWGU[P_0, j].ErHrVSCsDYUYvOhOGtaLWvLzkRUv())
			{
				return true;
			}
		}
		return false;
	}

	public bool WCPUExUBFBLAdpPEksHneVoQLNwB(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < mBlQPBqoPitZgepPLPGOwhXPXnwg.Length; i++)
			{
				if (mBlQPBqoPitZgepPLPGOwhXPXnwg[i].pXjVqdAzojvTbKvxXpykfDkEPpQj())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= ErKvoOUjBfJePGKjSrbzWogeiRvfA)
		{
			return false;
		}
		int num = ZFnuRthTgNtMQoSjnOTMTGpwfSedA.GoIOqdlPCzCvEFwUfldukyRwTcoY;
		for (int j = 0; j < num; j++)
		{
			if (xrqQFKFsIwvLMsZmYWSstJGNcWGU[P_0, j].pXjVqdAzojvTbKvxXpykfDkEPpQj())
			{
				return true;
			}
		}
		return false;
	}

	public bool HgzxcTpkYNIHJWrFZmhAcdKviFFW(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < mBlQPBqoPitZgepPLPGOwhXPXnwg.Length; i++)
			{
				if (mBlQPBqoPitZgepPLPGOwhXPXnwg[i].lHHuINDJBTdpehTarhalhiDIerGx())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= ErKvoOUjBfJePGKjSrbzWogeiRvfA)
		{
			return false;
		}
		int num = ZFnuRthTgNtMQoSjnOTMTGpwfSedA.GoIOqdlPCzCvEFwUfldukyRwTcoY;
		for (int j = 0; j < num; j++)
		{
			if (xrqQFKFsIwvLMsZmYWSstJGNcWGU[P_0, j].lHHuINDJBTdpehTarhalhiDIerGx())
			{
				return true;
			}
		}
		return false;
	}

	public bool LHJXSRkJSZXhLHBsTtPHWCOewreo(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < mBlQPBqoPitZgepPLPGOwhXPXnwg.Length; i++)
			{
				if (mBlQPBqoPitZgepPLPGOwhXPXnwg[i].cZnPzBTkHgebnurRTrMvxFZoHRQ())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= ErKvoOUjBfJePGKjSrbzWogeiRvfA)
		{
			return false;
		}
		int num = ZFnuRthTgNtMQoSjnOTMTGpwfSedA.GoIOqdlPCzCvEFwUfldukyRwTcoY;
		for (int j = 0; j < num; j++)
		{
			if (xrqQFKFsIwvLMsZmYWSstJGNcWGU[P_0, j].cZnPzBTkHgebnurRTrMvxFZoHRQ())
			{
				return true;
			}
		}
		return false;
	}

	public bool sHEScTEugnAJDsDHUqOjHVLpNQzC(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < mBlQPBqoPitZgepPLPGOwhXPXnwg.Length; i++)
			{
				if (mBlQPBqoPitZgepPLPGOwhXPXnwg[i].TLGzmXXWqWqdMxqYeLawjKRLjOHj())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= ErKvoOUjBfJePGKjSrbzWogeiRvfA)
		{
			return false;
		}
		int num = ZFnuRthTgNtMQoSjnOTMTGpwfSedA.GoIOqdlPCzCvEFwUfldukyRwTcoY;
		for (int j = 0; j < num; j++)
		{
			if (xrqQFKFsIwvLMsZmYWSstJGNcWGU[P_0, j].TLGzmXXWqWqdMxqYeLawjKRLjOHj())
			{
				return true;
			}
		}
		return false;
	}

	public bool daBiopFQwPbWEeRwYaTDhGdfikM()
	{
		if (!YKwoVDlCGCBsnadHfZOoJSVBAmxVA(BYYngOgctOZoskZpkkAryjfPANHf) && !qcLhghrLsEQalJroVJrgTmbZcLJY(oPZHKvbwBXlVdXrIkuOmnPnEZpYu) && !YKwoVDlCGCBsnadHfZOoJSVBAmxVA(gpdihnsVBKFcdhAFqfitGQcowLwUA))
		{
			return qcLhghrLsEQalJroVJrgTmbZcLJY(qmWDwbGpKFUNQOjgMMfuTLJkWVmSA);
		}
		return true;
	}

	public bool YZJmXVcjDoMOSmRzwhhEGPPoOETn(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => qcLhghrLsEQalJroVJrgTmbZcLJY(oPZHKvbwBXlVdXrIkuOmnPnEZpYu), 
			ControllerType.Keyboard => YKwoVDlCGCBsnadHfZOoJSVBAmxVA(gpdihnsVBKFcdhAFqfitGQcowLwUA), 
			ControllerType.Mouse => YKwoVDlCGCBsnadHfZOoJSVBAmxVA(BYYngOgctOZoskZpkkAryjfPANHf), 
			ControllerType.Custom => qcLhghrLsEQalJroVJrgTmbZcLJY(qmWDwbGpKFUNQOjgMMfuTLJkWVmSA), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool ERlLtRNOXKlAttLgeCJOaSJRpuDab()
	{
		if (!KOaMLeJaMZFXZBvZranndjYUmUJAb(BYYngOgctOZoskZpkkAryjfPANHf) && !GJUKKhYrWEafPAZDXcsaWBJbaGyy(oPZHKvbwBXlVdXrIkuOmnPnEZpYu) && !KOaMLeJaMZFXZBvZranndjYUmUJAb(gpdihnsVBKFcdhAFqfitGQcowLwUA))
		{
			return GJUKKhYrWEafPAZDXcsaWBJbaGyy(qmWDwbGpKFUNQOjgMMfuTLJkWVmSA);
		}
		return true;
	}

	public bool DsYGQsSJFScUXHIGsDsvvPsbEJZD(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => GJUKKhYrWEafPAZDXcsaWBJbaGyy(oPZHKvbwBXlVdXrIkuOmnPnEZpYu), 
			ControllerType.Keyboard => KOaMLeJaMZFXZBvZranndjYUmUJAb(gpdihnsVBKFcdhAFqfitGQcowLwUA), 
			ControllerType.Mouse => KOaMLeJaMZFXZBvZranndjYUmUJAb(BYYngOgctOZoskZpkkAryjfPANHf), 
			ControllerType.Custom => GJUKKhYrWEafPAZDXcsaWBJbaGyy(qmWDwbGpKFUNQOjgMMfuTLJkWVmSA), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool tENzToUPiywsIGkKyDToKmKPmmQs()
	{
		if (!EAnGtLuNSlzMFnChkjmmRlgpAFCB(BYYngOgctOZoskZpkkAryjfPANHf) && !xMKfSDhPyGiFaDDuVdOpqhCPTcgj(oPZHKvbwBXlVdXrIkuOmnPnEZpYu) && !EAnGtLuNSlzMFnChkjmmRlgpAFCB(gpdihnsVBKFcdhAFqfitGQcowLwUA))
		{
			return xMKfSDhPyGiFaDDuVdOpqhCPTcgj(qmWDwbGpKFUNQOjgMMfuTLJkWVmSA);
		}
		return true;
	}

	public bool HpkaTDQcZYmGprMRWYJuZhQNDAsV(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => xMKfSDhPyGiFaDDuVdOpqhCPTcgj(oPZHKvbwBXlVdXrIkuOmnPnEZpYu), 
			ControllerType.Keyboard => EAnGtLuNSlzMFnChkjmmRlgpAFCB(gpdihnsVBKFcdhAFqfitGQcowLwUA), 
			ControllerType.Mouse => EAnGtLuNSlzMFnChkjmmRlgpAFCB(BYYngOgctOZoskZpkkAryjfPANHf), 
			ControllerType.Custom => xMKfSDhPyGiFaDDuVdOpqhCPTcgj(qmWDwbGpKFUNQOjgMMfuTLJkWVmSA), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool mjvHXnUNiDIJsjNGEhuQUuSzHFwt()
	{
		if (!suNnKMcGaPGfjNClxRxAMgYitSTH(BYYngOgctOZoskZpkkAryjfPANHf) && !AYqExaxpkndpyKUecIbeSQBmusSo(oPZHKvbwBXlVdXrIkuOmnPnEZpYu) && !suNnKMcGaPGfjNClxRxAMgYitSTH(gpdihnsVBKFcdhAFqfitGQcowLwUA))
		{
			return AYqExaxpkndpyKUecIbeSQBmusSo(qmWDwbGpKFUNQOjgMMfuTLJkWVmSA);
		}
		return true;
	}

	public bool xtPgtlKHBSJNzjWTiGsPyhkABbsRB(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => AYqExaxpkndpyKUecIbeSQBmusSo(oPZHKvbwBXlVdXrIkuOmnPnEZpYu), 
			ControllerType.Keyboard => suNnKMcGaPGfjNClxRxAMgYitSTH(gpdihnsVBKFcdhAFqfitGQcowLwUA), 
			ControllerType.Mouse => suNnKMcGaPGfjNClxRxAMgYitSTH(BYYngOgctOZoskZpkkAryjfPANHf), 
			ControllerType.Custom => AYqExaxpkndpyKUecIbeSQBmusSo(qmWDwbGpKFUNQOjgMMfuTLJkWVmSA), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool BTVKjFYXGBNMlcWzNLlgvVsFcBNu()
	{
		if (!LxGaDThfFDUitNHVvcvlTRPaAtBIA(BYYngOgctOZoskZpkkAryjfPANHf) && !vHcxzFeFQTnSFSwzIHiyKymZrcuA(oPZHKvbwBXlVdXrIkuOmnPnEZpYu) && !LxGaDThfFDUitNHVvcvlTRPaAtBIA(gpdihnsVBKFcdhAFqfitGQcowLwUA))
		{
			return vHcxzFeFQTnSFSwzIHiyKymZrcuA(qmWDwbGpKFUNQOjgMMfuTLJkWVmSA);
		}
		return true;
	}

	public bool SPhHvGJXANUguWDmWqhyasoHimJH(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => vHcxzFeFQTnSFSwzIHiyKymZrcuA(oPZHKvbwBXlVdXrIkuOmnPnEZpYu), 
			ControllerType.Keyboard => LxGaDThfFDUitNHVvcvlTRPaAtBIA(gpdihnsVBKFcdhAFqfitGQcowLwUA), 
			ControllerType.Mouse => LxGaDThfFDUitNHVvcvlTRPaAtBIA(BYYngOgctOZoskZpkkAryjfPANHf), 
			ControllerType.Custom => vHcxzFeFQTnSFSwzIHiyKymZrcuA(qmWDwbGpKFUNQOjgMMfuTLJkWVmSA), 
			_ => throw new NotImplementedException(), 
		};
	}

	private bool qcLhghrLsEQalJroVJrgTmbZcLJY<_0001>(IList<_0001> P_0) where _0001 : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			_0001 val = P_0[i];
			if (val != null && val.GetAnyButton())
			{
				return true;
			}
		}
		return false;
	}

	private bool YKwoVDlCGCBsnadHfZOoJSVBAmxVA(Controller P_0)
	{
		return P_0?.GetAnyButton() ?? false;
	}

	private bool GJUKKhYrWEafPAZDXcsaWBJbaGyy<_0001>(IList<_0001> P_0) where _0001 : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			_0001 val = P_0[i];
			if (val != null && val.GetAnyButtonDown())
			{
				return true;
			}
		}
		return false;
	}

	private bool KOaMLeJaMZFXZBvZranndjYUmUJAb(Controller P_0)
	{
		return P_0?.GetAnyButtonDown() ?? false;
	}

	private bool xMKfSDhPyGiFaDDuVdOpqhCPTcgj<_0001>(IList<_0001> P_0) where _0001 : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			_0001 val = P_0[i];
			if (val != null && val.GetAnyButtonUp())
			{
				return true;
			}
		}
		return false;
	}

	private bool EAnGtLuNSlzMFnChkjmmRlgpAFCB(Controller P_0)
	{
		return P_0?.GetAnyButtonUp() ?? false;
	}

	private bool AYqExaxpkndpyKUecIbeSQBmusSo<_0001>(IList<_0001> P_0) where _0001 : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			_0001 val = P_0[i];
			if (val != null && val.GetAnyButtonChanged())
			{
				return true;
			}
		}
		return false;
	}

	private bool suNnKMcGaPGfjNClxRxAMgYitSTH(Controller P_0)
	{
		return P_0?.GetAnyButtonChanged() ?? false;
	}

	private bool vHcxzFeFQTnSFSwzIHiyKymZrcuA<_0001>(IList<_0001> P_0) where _0001 : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			_0001 val = P_0[i];
			if (val != null && val.GetAnyButtonPrev())
			{
				return true;
			}
		}
		return false;
	}

	private bool LxGaDThfFDUitNHVvcvlTRPaAtBIA(Controller P_0)
	{
		return P_0?.GetAnyButtonPrev() ?? false;
	}

	public Controller eghgYIIfxlmMwsWwLQdbJveNtrDn()
	{
		Controller lastController = null;
		double lastTime = 0.0;
		InputTools.CompareLastActiveController(BYYngOgctOZoskZpkkAryjfPANHf, ref lastController, ref lastTime);
		InputTools.CompareLastActiveController(gpdihnsVBKFcdhAFqfitGQcowLwUA, ref lastController, ref lastTime);
		IList<Joystick> list = oPZHKvbwBXlVdXrIkuOmnPnEZpYu;
		for (int i = 0; i < LkbCNXDBSBeJusZHNRPbRWQxbsRl; i++)
		{
			InputTools.CompareLastActiveController(list[i], ref lastController, ref lastTime);
		}
		IList<CustomController> list2 = qmWDwbGpKFUNQOjgMMfuTLJkWVmSA;
		for (int j = 0; j < efRWqpQqHUtuuAjtPTclDqttaDJfA; j++)
		{
			InputTools.CompareLastActiveController(list2[j], ref lastController, ref lastTime);
		}
		if (lastController == null)
		{
			lastController = gpdihnsVBKFcdhAFqfitGQcowLwUA;
		}
		return lastController;
	}

	public Controller QTRaFFAypvqLfdEbnpEKAgiDBIEtB(ControllerType P_0)
	{
		Controller lastController = null;
		double lastTime = 0.0;
		switch (P_0)
		{
		case ControllerType.Joystick:
		{
			int count = oPZHKvbwBXlVdXrIkuOmnPnEZpYu.Count;
			for (int j = 0; j < count; j++)
			{
				InputTools.CompareLastActiveController(oPZHKvbwBXlVdXrIkuOmnPnEZpYu[j], ref lastController, ref lastTime);
			}
			break;
		}
		case ControllerType.Keyboard:
			return drgNjPBDklMoqhfwuCfPMsCoXTQl;
		case ControllerType.Mouse:
			return vdLMjGufKFZFbdHWwGFoTfIgNRfT;
		case ControllerType.Custom:
		{
			int count = qmWDwbGpKFUNQOjgMMfuTLJkWVmSA.Count;
			for (int i = 0; i < count; i++)
			{
				InputTools.CompareLastActiveController(qmWDwbGpKFUNQOjgMMfuTLJkWVmSA[i], ref lastController, ref lastTime);
			}
			break;
		}
		default:
			throw new NotImplementedException();
		}
		return lastController;
	}

	public _0001 eghgYIIfxlmMwsWwLQdbJveNtrDn<_0001>() where _0001 : Controller
	{
		Type typeFromHandle = typeof(_0001);
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
		{
			return QTRaFFAypvqLfdEbnpEKAgiDBIEtB(ControllerType.Joystick) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
		{
			return QTRaFFAypvqLfdEbnpEKAgiDBIEtB(ControllerType.Keyboard) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
		{
			return QTRaFFAypvqLfdEbnpEKAgiDBIEtB(ControllerType.Custom) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
		{
			return QTRaFFAypvqLfdEbnpEKAgiDBIEtB(ControllerType.Mouse) as _0001;
		}
		throw new NotImplementedException();
	}

	public ControllerType GxjQHufSWpHiwukpxvFKjOItykSy()
	{
		return eghgYIIfxlmMwsWwLQdbJveNtrDn()?.type ?? ControllerType.Keyboard;
	}

	public void UBxOapVNUgZqGnoUobzTsQcbmcts(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 != null)
		{
			pBTTIIoLNzzuJNUHdPaFFlvanaIx = true;
			lLGUhhDxIWQHJSDNQxsUWvCnlsvh.hoJbvTofrWFaejGQPsQBuqNxRwqhA(P_0);
		}
	}

	public void kQSETnNMgcFBLYgnahPJNtTqWunJ(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 != null)
		{
			pBTTIIoLNzzuJNUHdPaFFlvanaIx = true;
			lLGUhhDxIWQHJSDNQxsUWvCnlsvh.crKINjQXkIUdBzXBqJNjNeyfbszC(P_0, P_1);
		}
	}

	public void rhGHaOTESuBEmeyDyMIsIgMvSXqm(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 != null)
		{
			lLGUhhDxIWQHJSDNQxsUWvCnlsvh.YBFbdoOhVEnozlFfSioBfSuwPFHT(P_0);
		}
	}

	public void mNehsUJnFHstxmfPLgPEbcJyGMOO(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 != null)
		{
			lLGUhhDxIWQHJSDNQxsUWvCnlsvh.TBGoGafchGyKAuleQVPqyOJrftXBA(P_0, P_1);
		}
	}

	public void OKdXFgjbBEHwAQxHuaNdxzNINvuk()
	{
		lLGUhhDxIWQHJSDNQxsUWvCnlsvh.GTjNZpbBdxDDQAGBlKcFulPpMGpB();
	}

	public void sVabTNUrlETeQUUwZknIHXVWfPKt(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		if (P_0 == 9999999)
		{
			UNGiVuuBBalMLCcPBGOfjLvhKeEcb.hoJbvTofrWFaejGQPsQBuqNxRwqhA(P_1);
		}
		else
		{
			if ((uint)P_0 >= (uint)ErKvoOUjBfJePGKjSrbzWogeiRvfA)
			{
				return;
			}
			YfUAdvWcAcNNJAyddwBiNiSrdNsx[P_0].hoJbvTofrWFaejGQPsQBuqNxRwqhA(P_1);
		}
		pBTTIIoLNzzuJNUHdPaFFlvanaIx = true;
	}

	public void PBBtsPxOhCcMJVWEjxkWdunddSSf(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
	{
		if (P_1 == null)
		{
			return;
		}
		if (P_0 == 9999999)
		{
			UNGiVuuBBalMLCcPBGOfjLvhKeEcb.crKINjQXkIUdBzXBqJNjNeyfbszC(P_1, P_2);
		}
		else
		{
			if ((uint)P_0 >= (uint)ErKvoOUjBfJePGKjSrbzWogeiRvfA)
			{
				return;
			}
			YfUAdvWcAcNNJAyddwBiNiSrdNsx[P_0].crKINjQXkIUdBzXBqJNjNeyfbszC(P_1, P_2);
		}
		pBTTIIoLNzzuJNUHdPaFFlvanaIx = true;
	}

	public void pobhFHImmgUdNtKdVLUhgRxuYRdOA(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 != null)
		{
			if (P_0 == 9999999)
			{
				UNGiVuuBBalMLCcPBGOfjLvhKeEcb.YBFbdoOhVEnozlFfSioBfSuwPFHT(P_1);
			}
			else if ((uint)P_0 < (uint)ErKvoOUjBfJePGKjSrbzWogeiRvfA)
			{
				YfUAdvWcAcNNJAyddwBiNiSrdNsx[P_0].YBFbdoOhVEnozlFfSioBfSuwPFHT(P_1);
			}
		}
	}

	public void xYqSQzBeNJGPJZGhmiugtwvZFAFu(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
	{
		if (P_1 != null)
		{
			if (P_0 == 9999999)
			{
				UNGiVuuBBalMLCcPBGOfjLvhKeEcb.TBGoGafchGyKAuleQVPqyOJrftXBA(P_1, P_2);
			}
			else if ((uint)P_0 < (uint)ErKvoOUjBfJePGKjSrbzWogeiRvfA)
			{
				YfUAdvWcAcNNJAyddwBiNiSrdNsx[P_0].TBGoGafchGyKAuleQVPqyOJrftXBA(P_1, P_2);
			}
		}
	}

	public void wMbbfulHXSejTabwlCgVgpFTjjKk(int P_0)
	{
		if (P_0 == 9999999)
		{
			UNGiVuuBBalMLCcPBGOfjLvhKeEcb.GTjNZpbBdxDDQAGBlKcFulPpMGpB();
		}
		else if ((uint)P_0 < (uint)ErKvoOUjBfJePGKjSrbzWogeiRvfA)
		{
			YfUAdvWcAcNNJAyddwBiNiSrdNsx[P_0].GTjNZpbBdxDDQAGBlKcFulPpMGpB();
		}
	}

	private void lxyEssEjBqQFZdTpcWCyMJIlCIXlB()
	{
		if (lLGUhhDxIWQHJSDNQxsUWvCnlsvh.zaHPsVQymiqTxQdMfCCFyNNQFqfQ > 0)
		{
			lLGUhhDxIWQHJSDNQxsUWvCnlsvh.hkxHoBTDevvcDJxFItRfcWMkTNqK(-1, eghgYIIfxlmMwsWwLQdbJveNtrDn(), QTRaFFAypvqLfdEbnpEKAgiDBIEtB(ControllerType.Joystick), QTRaFFAypvqLfdEbnpEKAgiDBIEtB(ControllerType.Custom));
		}
		if (UNGiVuuBBalMLCcPBGOfjLvhKeEcb.zaHPsVQymiqTxQdMfCCFyNNQFqfQ > 0)
		{
			Player.ControllerHelper controllers = IjLLOwtSjbeLJilzMmzOYhrLwAXh.kkFtAnKzLXLJZjMeUjNJMYwsjPoy().controllers;
			UNGiVuuBBalMLCcPBGOfjLvhKeEcb.hkxHoBTDevvcDJxFItRfcWMkTNqK(9999999, controllers.GetLastActiveController(), controllers.GetLastActiveController(ControllerType.Joystick), controllers.GetLastActiveController(ControllerType.Custom));
		}
		for (int i = 0; i < ErKvoOUjBfJePGKjSrbzWogeiRvfA; i++)
		{
			if (YfUAdvWcAcNNJAyddwBiNiSrdNsx[i].zaHPsVQymiqTxQdMfCCFyNNQFqfQ != 0)
			{
				Player.ControllerHelper controllers2 = IjLLOwtSjbeLJilzMmzOYhrLwAXh.lBeJVPUjmJjiebpWxLfJBeaeqDbNb[i].controllers;
				YfUAdvWcAcNNJAyddwBiNiSrdNsx[i].hkxHoBTDevvcDJxFItRfcWMkTNqK(i, controllers2.GetLastActiveController(), controllers2.GetLastActiveController(ControllerType.Joystick), controllers2.GetLastActiveController(ControllerType.Custom));
			}
		}
	}

	public void NaVlNYHFiohEAIeTAvHsQMkEwmZUA(ThrottleCalibrationMode P_0)
	{
		for (int i = 0; i < oPZHKvbwBXlVdXrIkuOmnPnEZpYu.Count; i++)
		{
			if (oPZHKvbwBXlVdXrIkuOmnPnEZpYu[i] != null)
			{
				sWMufnLcdHyOnxgWeDMSsfHndxmn(oPZHKvbwBXlVdXrIkuOmnPnEZpYu[i], P_0);
			}
		}
		for (int j = 0; j < ReHKQvWaInURsUAsObnZyNXUBVFn.Count; j++)
		{
			if (ReHKQvWaInURsUAsObnZyNXUBVFn[j] != null)
			{
				sWMufnLcdHyOnxgWeDMSsfHndxmn(ReHKQvWaInURsUAsObnZyNXUBVFn[j], P_0);
			}
		}
		for (int k = 0; k < efRWqpQqHUtuuAjtPTclDqttaDJfA; k++)
		{
			if (qmWDwbGpKFUNQOjgMMfuTLJkWVmSA[k] != null)
			{
				sWMufnLcdHyOnxgWeDMSsfHndxmn(qmWDwbGpKFUNQOjgMMfuTLJkWVmSA[k], P_0);
			}
		}
		sWMufnLcdHyOnxgWeDMSsfHndxmn(BYYngOgctOZoskZpkkAryjfPANHf, P_0);
	}

	private void sWMufnLcdHyOnxgWeDMSsfHndxmn(ControllerWithAxes P_0, ThrottleCalibrationMode P_1)
	{
		IList<Controller.Axis> axes = P_0.Axes;
		for (int i = 0; i < P_0.axisCount; i++)
		{
			if (axes[i].RWCEZctGAZWeIhWIQMIAdNROmnEb._specialAxisType == SpecialAxisType.Throttle)
			{
				P_0.calibrationMap.Axes[i].calibrationMode = EnumConverter.ToAlternateAxisCalibrationType(P_1);
			}
		}
	}

	public IList<_0001> guJgbpBeTuCjxLCAMgAEMsCSjNUC<_0001>() where _0001 : IControllerTemplate
	{
		return YywCqGhxSZVJJfKGrblzxgHtNCRuA.btiRIkziHJeHEgVVxcNtCxMgrcSvb<_0001>();
	}

	private void uqdmOWseeZbmckrCkSYZAvvfLdUrA(List<InputBehavior> P_0)
	{
		ZFnuRthTgNtMQoSjnOTMTGpwfSedA = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe;
		IjLLOwtSjbeLJilzMmzOYhrLwAXh = ReInput.yLMToaDqIzfOcDAFApituELqzLeNA;
		oPZHKvbwBXlVdXrIkuOmnPnEZpYu = new List<Joystick>();
		ReHKQvWaInURsUAsObnZyNXUBVFn = new List<Joystick>();
		qmWDwbGpKFUNQOjgMMfuTLJkWVmSA = new List<CustomController>();
		vAJEywimdjvkATAjUAMVALeyUkmxA = ZFnuRthTgNtMQoSjnOTMTGpwfSedA.GoIOqdlPCzCvEFwUfldukyRwTcoY;
		ErKvoOUjBfJePGKjSrbzWogeiRvfA = IjLLOwtSjbeLJilzMmzOYhrLwAXh.bYsHspPdAWKVmRlbOyRDnMcSXMgu;
		rcZNAkUblCpyIvpzLhcqufymhPhG = uykUXrFaqSSSgjZAceLUCHrVyfWf;
		pQLebspKYjQicBQleRDRCBTMNLWd = 0;
		tgMpIiYXwaGkXteRwtewizRIoiWK = new ADictionary<int, zDpKVWgTMWLqzLrKVDFkGgpqEJoF>();
		tgMpIiYXwaGkXteRwtewizRIoiWK.Add(ReInput.players.GetSystemPlayer().id, new zDpKVWgTMWLqzLrKVDFkGgpqEJoF(P_0));
		IList<Player> players = ReInput.players.Players;
		for (int i = 0; i < players.Count; i++)
		{
			tgMpIiYXwaGkXteRwtewizRIoiWK.Add(players[i].id, new zDpKVWgTMWLqzLrKVDFkGgpqEJoF(P_0));
		}
		RWBZoWnKkcDquvXzYhMKHZFxONxS = new ReadOnlyCollection<Joystick>(oPZHKvbwBXlVdXrIkuOmnPnEZpYu);
		JFdCgRkHCzHFkxAjhCJKDpBgtdpPc = new ReadOnlyCollection<CustomController>(qmWDwbGpKFUNQOjgMMfuTLJkWVmSA);
		KvDFldULABgCdeUydTfHpQtIJWLLA.icFBqtMgtwEeOTBMqdgFYPiGAKFw(bAwkesiCxVagVGvymaRlxMmnRFcvA);
		DOsSTFxBHHyMAeVNelJMIulMPBoE = new KvDFldULABgCdeUydTfHpQtIJWLLA[(ErKvoOUjBfJePGKjSrbzWogeiRvfA + 1) * vAJEywimdjvkATAjUAMVALeyUkmxA];
		int num = 0;
		mBlQPBqoPitZgepPLPGOwhXPXnwg = new KvDFldULABgCdeUydTfHpQtIJWLLA[vAJEywimdjvkATAjUAMVALeyUkmxA];
		for (int j = 0; j < vAJEywimdjvkATAjUAMVALeyUkmxA; j++)
		{
			InputAction inputAction = ZFnuRthTgNtMQoSjnOTMTGpwfSedA.BUydWMGMgACRxwrLofLjLHAboWlF(j);
			InputBehavior inputBehavior = tgMpIiYXwaGkXteRwtewizRIoiWK[9999999].KjhAiQejGFyjZDtXpqazRKCbYBHMA(inputAction.behaviorId);
			KvDFldULABgCdeUydTfHpQtIJWLLA kvDFldULABgCdeUydTfHpQtIJWLLA = new KvDFldULABgCdeUydTfHpQtIJWLLA(9999999, inputAction, inputBehavior, bAwkesiCxVagVGvymaRlxMmnRFcvA);
			mBlQPBqoPitZgepPLPGOwhXPXnwg[j] = kvDFldULABgCdeUydTfHpQtIJWLLA;
			DOsSTFxBHHyMAeVNelJMIulMPBoE[num] = kvDFldULABgCdeUydTfHpQtIJWLLA;
			num++;
		}
		xrqQFKFsIwvLMsZmYWSstJGNcWGU = new KvDFldULABgCdeUydTfHpQtIJWLLA[ErKvoOUjBfJePGKjSrbzWogeiRvfA, vAJEywimdjvkATAjUAMVALeyUkmxA];
		for (int k = 0; k < ErKvoOUjBfJePGKjSrbzWogeiRvfA; k++)
		{
			for (int l = 0; l < vAJEywimdjvkATAjUAMVALeyUkmxA; l++)
			{
				InputAction inputAction2 = ZFnuRthTgNtMQoSjnOTMTGpwfSedA.BUydWMGMgACRxwrLofLjLHAboWlF(l);
				InputBehavior inputBehavior2 = tgMpIiYXwaGkXteRwtewizRIoiWK[players[k].id].KjhAiQejGFyjZDtXpqazRKCbYBHMA(inputAction2.behaviorId);
				KvDFldULABgCdeUydTfHpQtIJWLLA kvDFldULABgCdeUydTfHpQtIJWLLA2 = new KvDFldULABgCdeUydTfHpQtIJWLLA(k, inputAction2, inputBehavior2, bAwkesiCxVagVGvymaRlxMmnRFcvA);
				xrqQFKFsIwvLMsZmYWSstJGNcWGU[k, l] = kvDFldULABgCdeUydTfHpQtIJWLLA2;
				DOsSTFxBHHyMAeVNelJMIulMPBoE[num] = kvDFldULABgCdeUydTfHpQtIJWLLA2;
				num++;
			}
		}
		IList<Player_Editor> list = ReInput.UserData.veCQUcbOHBPDdzjQJpMsjmKQamdw;
		if (list == null)
		{
			throw new ArgumentNullException("Players cannot be null!");
		}
		for (int m = 0; m < list.Count; m++)
		{
			List<Player_Editor.CreateControllerInfo> startingCustomControllers = list[m].startingCustomControllers;
			if (startingCustomControllers == null)
			{
				continue;
			}
			for (int n = 0; n < startingCustomControllers.Count; n++)
			{
				CustomController customController = eCVKPANUKkNwYdDVztQrzDjKaPIm(startingCustomControllers[n].sourceId);
				if (customController != null)
				{
					customController.tag = startingCustomControllers[n].tag;
					int num2 = ((m == 0) ? 9999999 : (m - 1));
					IjLLOwtSjbeLJilzMmzOYhrLwAXh.brhNoQGyqbXIjYOSldNMHSkKJjCd(num2)?.controllers.IUPlYNsSLxOsntNkkdjuBmtCQenBb(customController, false);
				}
			}
		}
		QchkgBFeKlKbusGFeRjvHmFmhimD = new eKRRFmBsqycdoBxbIwmnkNPvqmFI();
		KqDwUXpGiRpYgpxkHvMKtOSoJoMk = new eKRRFmBsqycdoBxbIwmnkNPvqmFI[ErKvoOUjBfJePGKjSrbzWogeiRvfA];
		for (int num3 = 0; num3 < ErKvoOUjBfJePGKjSrbzWogeiRvfA; num3++)
		{
			KqDwUXpGiRpYgpxkHvMKtOSoJoMk[num3] = new eKRRFmBsqycdoBxbIwmnkNPvqmFI();
		}
		lLGUhhDxIWQHJSDNQxsUWvCnlsvh = new global::YfwOMdmkzfuzklyvEonrviktmiIs<ActiveControllerChangedDelegate>();
		UNGiVuuBBalMLCcPBGOfjLvhKeEcb = new global::YfwOMdmkzfuzklyvEonrviktmiIs<PlayerActiveControllerChangedDelegate>();
		YfUAdvWcAcNNJAyddwBiNiSrdNsx = new global::YfwOMdmkzfuzklyvEonrviktmiIs<PlayerActiveControllerChangedDelegate>[IjLLOwtSjbeLJilzMmzOYhrLwAXh.bYsHspPdAWKVmRlbOyRDnMcSXMgu];
		ArrayTools.Populate(YfUAdvWcAcNNJAyddwBiNiSrdNsx);
	}

	private void QkmuudMmGCBkLJxNvtFhjqfHGNqIb(UpdateLoopType P_0)
	{
		int count = oPZHKvbwBXlVdXrIkuOmnPnEZpYu.Count;
		for (int i = 0; i < count; i++)
		{
			Joystick joystick = oPZHKvbwBXlVdXrIkuOmnPnEZpYu[i];
			if (joystick.enabled)
			{
				KYMradzwsMOEiwrMgHNhqDnFYOYD(joystick.dHkNCKpctgNGcHxUJklopMPghHBX, joystick.EnxeINdfRsPNEfNsWCRpkeCWEWlpA);
				joystick.hdccNRifKnNeMIMmCYJkjUCelZGPA(P_0);
			}
		}
		if (gpdihnsVBKFcdhAFqfitGQcowLwUA.enabled)
		{
			gpdihnsVBKFcdhAFqfitGQcowLwUA.hdccNRifKnNeMIMmCYJkjUCelZGPA(P_0);
		}
		else if (agVqhbOhoogMXpPmdTHxqAbtitOc)
		{
			gpdihnsVBKFcdhAFqfitGQcowLwUA.gjlPYUtCaPavykGmFfNbEpyWeKzh(P_0);
		}
		if (BYYngOgctOZoskZpkkAryjfPANHf.enabled)
		{
			BYYngOgctOZoskZpkkAryjfPANHf.hdccNRifKnNeMIMmCYJkjUCelZGPA(P_0);
		}
		int count2 = qmWDwbGpKFUNQOjgMMfuTLJkWVmSA.Count;
		for (int j = 0; j < count2; j++)
		{
			CustomController customController = qmWDwbGpKFUNQOjgMMfuTLJkWVmSA[j];
			if (customController.enabled)
			{
				customController.QjpUuIOUxpAXXfQDeFektwVlkJRV();
				customController.hdccNRifKnNeMIMmCYJkjUCelZGPA(P_0);
			}
		}
	}

	private void wSrJOJBkSTaneFwYFgdjpLwTXANKA(UpdateLoopType P_0)
	{
		KvDFldULABgCdeUydTfHpQtIJWLLA.EHZZpmHkEvhSMtfZqRDzzIbhjnmL(P_0);
		Player[] array = IjLLOwtSjbeLJilzMmzOYhrLwAXh.ipFcHyhMbZwkElirYYZBptJsVutG;
		int num = array.Length;
		bool enabled = gpdihnsVBKFcdhAFqfitGQcowLwUA.enabled;
		if (enabled)
		{
			for (int i = 0; i < num; i++)
			{
				IList<KeyboardMap> maps = array[i].controllers.maps.GetMaps<KeyboardMap>(0);
				int count = maps.Count;
				for (int j = 0; j < count; j++)
				{
					if (maps[j].enabled)
					{
						vNCUHWeFYtdAIwwqxKkieKdGPtdP.vVfJPlpqRQeeFRtyJnVpRhGHPGvR(maps[j]);
					}
				}
			}
		}
		bool enabled2 = BYYngOgctOZoskZpkkAryjfPANHf.enabled;
		for (int k = 0; k < num; k++)
		{
			Player.ControllerHelper controllers = array[k].controllers;
			controllers.ZwLqbBSaVPuGqqcMpiiiqfTwmkyt(rcZNAkUblCpyIvpzLhcqufymhPhG);
			if (enabled || agVqhbOhoogMXpPmdTHxqAbtitOc)
			{
				controllers.qqnYDDzmuSpodLwvwjWZEPDqMZRN(gpdihnsVBKFcdhAFqfitGQcowLwUA, vNCUHWeFYtdAIwwqxKkieKdGPtdP, rcZNAkUblCpyIvpzLhcqufymhPhG);
			}
			if (enabled2)
			{
				controllers.gAbkZnLgotbUoLaTjqHNIjpRUqAf(BYYngOgctOZoskZpkkAryjfPANHf, rcZNAkUblCpyIvpzLhcqufymhPhG);
			}
			controllers.eqlZktjnOqQBlMofrGOadMeUiUGv(rcZNAkUblCpyIvpzLhcqufymhPhG);
		}
		for (int l = 0; l < DOsSTFxBHHyMAeVNelJMIulMPBoE.Length; l++)
		{
			if (DOsSTFxBHHyMAeVNelJMIulMPBoE[l].aALbCbeNFwEwIAPDdXIQvgrgIQOcB != KvDFldULABgCdeUydTfHpQtIJWLLA.zBYFVTOQWtucjtuTpoxSrsJwfOdF.Disabled)
			{
				DOsSTFxBHHyMAeVNelJMIulMPBoE[l].mTRvMEijhIkrKoqJttfcAAkyySME();
			}
		}
		KvDFldULABgCdeUydTfHpQtIJWLLA.GlXCDQOkSyyavHiHtKTHigzjrwVP();
		if (!zegBerCUBfDlcINYPgEMBHfuhXUc)
		{
			return;
		}
		if (QchkgBFeKlKbusGFeRjvHmFmhimD.VBCGNLzqPUvJpBcZqJWEjsyHmNlT > 0)
		{
			for (int m = 0; m < vAJEywimdjvkATAjUAMVALeyUkmxA; m++)
			{
				KvDFldULABgCdeUydTfHpQtIJWLLA kvDFldULABgCdeUydTfHpQtIJWLLA = mBlQPBqoPitZgepPLPGOwhXPXnwg[m];
				if (kvDFldULABgCdeUydTfHpQtIJWLLA.aALbCbeNFwEwIAPDdXIQvgrgIQOcB != KvDFldULABgCdeUydTfHpQtIJWLLA.zBYFVTOQWtucjtuTpoxSrsJwfOdF.Disabled)
				{
					QchkgBFeKlKbusGFeRjvHmFmhimD.YVUdcmFPuhgrUtPvvxgathnNMrugb(kvDFldULABgCdeUydTfHpQtIJWLLA, P_0);
				}
			}
		}
		for (int n = 0; n < ErKvoOUjBfJePGKjSrbzWogeiRvfA; n++)
		{
			eKRRFmBsqycdoBxbIwmnkNPvqmFI eKRRFmBsqycdoBxbIwmnkNPvqmFI2 = KqDwUXpGiRpYgpxkHvMKtOSoJoMk[n];
			if (eKRRFmBsqycdoBxbIwmnkNPvqmFI2.VBCGNLzqPUvJpBcZqJWEjsyHmNlT == 0)
			{
				continue;
			}
			for (int num2 = 0; num2 < vAJEywimdjvkATAjUAMVALeyUkmxA; num2++)
			{
				KvDFldULABgCdeUydTfHpQtIJWLLA kvDFldULABgCdeUydTfHpQtIJWLLA2 = xrqQFKFsIwvLMsZmYWSstJGNcWGU[n, num2];
				if (kvDFldULABgCdeUydTfHpQtIJWLLA2.aALbCbeNFwEwIAPDdXIQvgrgIQOcB != KvDFldULABgCdeUydTfHpQtIJWLLA.zBYFVTOQWtucjtuTpoxSrsJwfOdF.Disabled)
				{
					eKRRFmBsqycdoBxbIwmnkNPvqmFI2.YVUdcmFPuhgrUtPvvxgathnNMrugb(kvDFldULABgCdeUydTfHpQtIJWLLA2, P_0);
				}
			}
		}
	}

	private void uykUXrFaqSSSgjZAceLUCHrVyfWf(bool P_0, int P_1, int P_2)
	{
		int num = ZFnuRthTgNtMQoSjnOTMTGpwfSedA.iSPjDaBlidVkgDFbcWGdrWlErgNn(P_2);
		if (num >= 0)
		{
			if (P_1 == 9999999)
			{
				mBlQPBqoPitZgepPLPGOwhXPXnwg[num].HJXCajbwJrCxTlmNrNaHsSkDwkXgA(P_0);
			}
			else
			{
				xrqQFKFsIwvLMsZmYWSstJGNcWGU[P_1, num].HJXCajbwJrCxTlmNrNaHsSkDwkXgA(P_0);
			}
		}
	}

	private void FwgctfBHJRDfZaWZOaNaIsxnDpyP(BridgedController P_0)
	{
		int num = rkxXlODNDEatsELfZvQnBinqmWWcA(P_0.sourceJoystick.rewiredId, eulYAqGqwcEPtrECQAsMrySUqYij.Connected);
		if (num >= 0)
		{
			Logger.LogError("Controller was already in connected list!");
			return;
		}
		num = rkxXlODNDEatsELfZvQnBinqmWWcA(P_0.sourceJoystick.rewiredId, eulYAqGqwcEPtrECQAsMrySUqYij.Disconnected);
		Joystick joystick;
		if (num >= 0)
		{
			joystick = ReHKQvWaInURsUAsObnZyNXUBVFn[num];
			ReHKQvWaInURsUAsObnZyNXUBVFn.RemoveAt(num);
			joystick.pNUSRvhBkrTRvdFypEUlwmSFWRDy(P_0);
			joystick.isConnected = true;
		}
		else
		{
			joystick = new Joystick(P_0);
		}
		oPZHKvbwBXlVdXrIkuOmnPnEZpYu.Add(joystick);
		EZSHPBhcVEWhKQvgUxDGHXHwcPSf.Add(joystick);
		oPZHKvbwBXlVdXrIkuOmnPnEZpYu.Sort(Joystick.GKwervGZyDvcatXJmzVFKsgIaTOeA);
		YywCqGhxSZVJJfKGrblzxgHtNCRuA.JtDcHaHpJBOhVcxCDTnbPglAlCNdc(joystick);
	}

	private void GKQFEVltQMCKITjBlnDSCjxWNTJf(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (P_0 >= oPZHKvbwBXlVdXrIkuOmnPnEZpYu.Count)
		{
			Logger.LogError("Device was not in connected list! Cannot remove!");
			return;
		}
		Joystick joystick = oPZHKvbwBXlVdXrIkuOmnPnEZpYu[P_0];
		joystick.isConnected = false;
		if (VxHBHrYzuMeUqSaFnBXtfnhjaMhWA != null)
		{
			VxHBHrYzuMeUqSaFnBXtfnhjaMhWA(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
		}
		if (dOLtxKGtaNcfvTcJAALvttZYuyPQ != null)
		{
			dOLtxKGtaNcfvTcJAALvttZYuyPQ(joystick.type, joystick.id);
		}
		oPZHKvbwBXlVdXrIkuOmnPnEZpYu.RemoveAt(P_0);
		ReHKQvWaInURsUAsObnZyNXUBVFn.Add(joystick);
		EZSHPBhcVEWhKQvgUxDGHXHwcPSf.Remove(joystick);
		YywCqGhxSZVJJfKGrblzxgHtNCRuA.mcLDGeazCzmWxNKScdthBzTSViJc(joystick);
		joystick.NQeVYgkqiwjcPfmLUdoKHfxQPBEL();
	}

	private void ZiqAUDrqBknYDRyNhnpXqdNLFjzi()
	{
		for (int num = oPZHKvbwBXlVdXrIkuOmnPnEZpYu.Count - 1; num >= 0; num--)
		{
			GKQFEVltQMCKITjBlnDSCjxWNTJf(num);
		}
	}

	private bool cOlhCDWazrElelMoYhaVfiSnIGEcA(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		for (int i = 0; i < qmWDwbGpKFUNQOjgMMfuTLJkWVmSA.Count; i++)
		{
			if (qmWDwbGpKFUNQOjgMMfuTLJkWVmSA[i] == P_0)
			{
				return true;
			}
		}
		qmWDwbGpKFUNQOjgMMfuTLJkWVmSA.Add(P_0);
		EZSHPBhcVEWhKQvgUxDGHXHwcPSf.Add(P_0);
		YywCqGhxSZVJJfKGrblzxgHtNCRuA.JtDcHaHpJBOhVcxCDTnbPglAlCNdc(P_0);
		return true;
	}

	private bool oiZOFxMtxUnLDZBsAJGxjQpYDVmN(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		YywCqGhxSZVJJfKGrblzxgHtNCRuA.mcLDGeazCzmWxNKScdthBzTSViJc(P_0);
		EZSHPBhcVEWhKQvgUxDGHXHwcPSf.Remove(P_0);
		return qmWDwbGpKFUNQOjgMMfuTLJkWVmSA.Remove(P_0);
	}

	private eKRRFmBsqycdoBxbIwmnkNPvqmFI LfCxDGnEKrHlMdAsDkLgvTdxrQKtA(int P_0)
	{
		if (P_0 == 9999999)
		{
			return QchkgBFeKlKbusGFeRjvHmFmhimD;
		}
		if (P_0 < 0 || P_0 >= ReInput.yLMToaDqIzfOcDAFApituELqzLeNA.bYsHspPdAWKVmRlbOyRDnMcSXMgu)
		{
			return null;
		}
		return KqDwUXpGiRpYgpxkHvMKtOSoJoMk[P_0];
	}

	private void uNSZUYqgeoTNEFBXWTFfdvCYdjqb(bool P_0)
	{
		if (!P_0)
		{
			vNCUHWeFYtdAIwwqxKkieKdGPtdP.NYcuJbMJbzpIdAAagUSndgHZbskQ();
		}
	}

	private void ySccSQFWOHgiiFLBcehatAykmTYH(bool P_0)
	{
		gpdihnsVBKFcdhAFqfitGQcowLwUA.LeLYmpHPVPCSNZNverFIBCLjUJnT(P_0);
		BYYngOgctOZoskZpkkAryjfPANHf.LeLYmpHPVPCSNZNverFIBCLjUJnT(P_0);
		for (int i = 0; i < oPZHKvbwBXlVdXrIkuOmnPnEZpYu.Count; i++)
		{
			oPZHKvbwBXlVdXrIkuOmnPnEZpYu[i].LeLYmpHPVPCSNZNverFIBCLjUJnT(P_0);
		}
		for (int j = 0; j < qmWDwbGpKFUNQOjgMMfuTLJkWVmSA.Count; j++)
		{
			qmWDwbGpKFUNQOjgMMfuTLJkWVmSA[j].LeLYmpHPVPCSNZNverFIBCLjUJnT(P_0);
		}
	}

	public void Dispose()
	{
		GBGncDRdcrwvTshSbMJnmVWOqPzT(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected void yERFszWyOlKFrdLgMXXInZsGINNE()
	{
		try
		{
			GBGncDRdcrwvTshSbMJnmVWOqPzT(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void GBGncDRdcrwvTshSbMJnmVWOqPzT(bool P_0)
	{
		if (HJVMciaotjpkmnljUHJDWQceBDHT)
		{
			return;
		}
		if (P_0)
		{
			if (RmojKglJqaAZCivaHnoOgIWildFsA is IDisposable)
			{
				(RmojKglJqaAZCivaHnoOgIWildFsA as IDisposable).Dispose();
			}
			if (HcyWCwaxkqteamzJQJVJbKJNpTNc is IDisposable)
			{
				(HcyWCwaxkqteamzJQJVJbKJNpTNc as IDisposable).Dispose();
			}
		}
		HJVMciaotjpkmnljUHJDWQceBDHT = true;
	}
}
