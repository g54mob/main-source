using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using UnityEngine;

namespace Rewired
{
	public abstract class Controller
	{
		public abstract class Element
		{
			internal abstract class lZybJXLnHhCcBdEDpreKIJwiUFbg
			{
				public abstract class yGvAcjBgGOmqAgSTAdgGmmdWUMudb
				{
					public abstract void CkVAOykdYxkeFJQKYfxohLyqXoog();
				}

				protected readonly int EoehKdBObwZWKMwzJgCazIUEuigo;

				protected readonly int[] VjfeiXIKTjgNFwzXWXlfOyGkBppHb;

				protected yGvAcjBgGOmqAgSTAdgGmmdWUMudb[] GrMBZdMocODVMwkuVqDusLZlBiOIA;

				public yGvAcjBgGOmqAgSTAdgGmmdWUMudb YBQMNYyHvqpYZDkEQrnjYcQFBWpHA;

				private int aSZETZBhPSfjaIXKhtOKRqefaMZK;

				public int lcJKMEgrCJUiDRqxskIPtDLeuojN;

				protected ReadOnlyCollection<yGvAcjBgGOmqAgSTAdgGmmdWUMudb> zFKWEquPLGLKmlxcfElkMeKEWLXq;

				public IList<yGvAcjBgGOmqAgSTAdgGmmdWUMudb> cmqIQDoKUspEoDCGnFQLXYwhZXIH => null;

				public UpdateLoopType ruqXBtdwgIJgUuTmzNuAqeGEzJtQ
				{
					set
					{
					}
				}

				public lZybJXLnHhCcBdEDpreKIJwiUFbg(UpdateLoopSetting P_0)
				{
				}

				public void AcSQAdVLcZppFghwfERXctyGnhCyA()
				{
				}

				public yGvAcjBgGOmqAgSTAdgGmmdWUMudb JMRCGlPARMgFdyyAinFGdBiBuOoc(UpdateLoopType P_0)
				{
					return null;
				}
			}

			public readonly int id;

			public readonly string name;

			public readonly ControllerElementType type;

			internal lZybJXLnHhCcBdEDpreKIJwiUFbg fXJTKleYylrDyjWtPwPDMiiwkayJ;

			internal int zwJOCuPcLueCEDApGJpfOhvQgUeO;

			internal Controller HDncYvfSNkadiALYJeTKEDIIEiUFA;

			internal readonly int eglHKWiUWuKZwdjyCQdtIBVkeyldA;

			private CompoundElement LmUepmWzMeGkcCDyfCMqfgFRAwXl;

			private bool xCxotdSoSCSTObMZXLpwOLLSRRsM;

			public ControllerElementIdentifier elementIdentifier => null;

			public virtual bool excludeFromPolling
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool isMemberElement => false;

			public CompoundElement compoundElement => null;

			internal Element(Controller P_0, int P_1, string P_2, ControllerElementType P_3)
			{
			}

			public void Reset()
			{
			}

			internal void mmttFXHmedzWTWxNYuyCcbfcjsve(CompoundElement P_0)
			{
			}

			internal void tcCKdzFmbdkICpAtcTmndNYtIvan(CompoundElement P_0)
			{
			}
		}

		public sealed class Axis : Element
		{
			internal class egRiCpVutosBWzlJBHjGXvGloISA : lZybJXLnHhCcBdEDpreKIJwiUFbg
			{
				public class pNknKyWHkJsDGkPxYCuCfnBmnSIG : yGvAcjBgGOmqAgSTAdgGmmdWUMudb
				{
					private const float jhdKZOrsdAJLxWIZeTLpemvrZPIX = 0.001f;

					public float pIBkBGocFujoFriijoOBDIaEDnPc;

					public float DImYvdeJMgadABcnRYCFHbqyepCD;

					public float agHmMaFbTpPfCqqHmnpkjOSppsRi;

					public float PSvMCJTZPpgphSHBbsWxDijmAobT;

					public float OxYJpxxRCFWhAzoSGbQwcCcnGGFXA;

					public float rNBFggJvoRcxNBIcpUtpSoWtpJFmA;

					public double ZvgbLOFmpkeSoRRdOhCyJwnqzwIX;

					public double hNFBZfrPebctrfBYabOeOiSSPZoD;

					public double cLvBkuvlNoArwyPsSlquvEsmgpIQ;

					public double EqzRyjeqeMKUCrLagFERAlgxqiqJ;

					public double QqckjRTSZszzduchEOVLDalYRkWE;

					public double pjxJCYemrosqaQjKBVXyqjYSbSTf;

					public double MojVSUWMVcNyzYsVYuDhRPrcwoEI => 0.0;

					public double JvzuMssMQPAbLvHQVSwDKzxyCcJX => 0.0;

					public double soiOEOnhIsyiXwWzPItcVQBqTLBi => 0.0;

					public double ONwkZuVXZiMJnRRUzQXOZBFDuZZH => 0.0;

					public void SGhcSODHoZFXplZxAbsfbuHFwDgw(bool P_0)
					{
					}

					public void kPjacDSUisxOAZpdvkJXjNXrgfphA(float P_0)
					{
					}

					public override void CkVAOykdYxkeFJQKYfxohLyqXoog()
					{
					}
				}

				public egRiCpVutosBWzlJBHjGXvGloISA(UpdateLoopSetting P_0)
					: base(default(UpdateLoopSetting))
				{
				}
			}

			internal readonly AxisRange oimGovBRfBmECaHFDVHeXKwVLWrRb;

			internal readonly HardwareAxisInfo ryFTpRRwfNUpckOcIPGYQDQZBAJs;

			public float value => 0f;

			public float valuePrev => 0f;

			public float valueRaw
			{
				get
				{
					return 0f;
				}
				internal set
				{
				}
			}

			public float valueRawPrev => 0f;

			public float valueDelta => 0f;

			public float valueDeltaRaw => 0f;

			public double lastTimeActive => 0.0;

			public double lastTimeActiveRaw => 0.0;

			public double lastTimeInactive => 0.0;

			public double lastTimeInactiveRaw => 0.0;

			public double lastTimeValueChanged => 0.0;

			public double lastTimeValueChangedRaw => 0.0;

			public double timeActive => 0.0;

			public double timeActiveRaw => 0.0;

			public double timeInactive => 0.0;

			public double timeInactiveRaw => 0.0;

			public float pollingDeadZone
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public AxisCoordinateMode axisCoordinateMode => default(AxisCoordinateMode);

			public override bool excludeFromPolling
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			internal float VNsEAazSOsZtMiaYqGFxFbECkjvi => 0f;

			internal float QveyrtkJZNVIRXLJwBIaxouEPTrH => 0f;

			internal float HhYnVahwuyhWrHmNZHyTBiIefqPm => 0f;

			internal void KcGaCyClaYPayUfwuGCqXJtfCIREA(float P_0)
			{
			}

			internal Axis(Controller P_0, int P_1, string P_2, AxisRange P_3, HardwareAxisInfo P_4)
				: base(null, 0, null, default(ControllerElementType))
			{
			}

			internal void xJDNeeDSHTPEDSQNfoJnSEUrchkT(UpdateLoopType P_0)
			{
			}

			internal void HoXsfcIqJgwXUhnbStYNOpbvnctg(AxisCalibration P_0)
			{
			}

			internal void WyvexsGMLLyXWkEfvMAIegeKPGMyb()
			{
			}

			internal void OKbKuHgUghROqZSxplHxPkKRYNjF()
			{
			}

			internal void bcNeQZvXYonWPLEYLngjRxPNEJaS()
			{
			}

			internal void CjIbYfhrPxwnJLpawVilJdcMNppf(float P_0)
			{
			}

			internal float EJQtjRUhzaAYhzwtGVciBlQfEOqW(UpdateLoopType P_0, AxisCalibration P_1)
			{
				return 0f;
			}
		}

		public sealed class Button : Element
		{
			internal class fvjLdGlKslGkaKZpxoPHKFyDpISEb : lZybJXLnHhCcBdEDpreKIJwiUFbg
			{
				public class PSPdkpCAcJdLQrkEYGvaWtRYQVISA : yGvAcjBgGOmqAgSTAdgGmmdWUMudb
				{
					public bool cjnIcRjyIxOvJAFlFinYyehiqssR;

					public bool rGthJKXGLkDioKVIjNdUimlOZFyM;

					public ButtonStateRecorder KypfQRCDGarjXikwSPvvusGTOCBg;

					public qxPfKPXXoGAGRwczpznkeBkUcigjA bYleBzgufaBlpTdfbgyRfvVqNcEaA;

					public void NdMhgsgKHkWqxAohakoGjZljoPoX(bool P_0)
					{
					}

					public override void CkVAOykdYxkeFJQKYfxohLyqXoog()
					{
					}
				}

				public class QRUtdXAPlvHpNuKzhmnHsXrDiOzM : PSPdkpCAcJdLQrkEYGvaWtRYQVISA
				{
					public float KtTFFIcPzKlrZjCddstAyjjTnzKOA;

					public float sZwetIPMkDggDWgnUMJhWGKUNwee;

					public void WKgQSgQwPAjLyRzCwHVLjkSyndkI(float P_0)
					{
					}

					public override void CkVAOykdYxkeFJQKYfxohLyqXoog()
					{
					}
				}

				public fvjLdGlKslGkaKZpxoPHKFyDpISEb(UpdateLoopSetting P_0, bool P_1)
					: base(default(UpdateLoopSetting))
				{
				}

				public void ZQAFEZYwufSsahtWBAJKElVcvhem(float P_0)
				{
				}

				public void oRuAfqkKoBmemMcVDOWKaGGGkBEt()
				{
				}
			}

			internal readonly bool udGOZVYTWxZgmcjOPFxmgYxbzrrI;

			internal readonly HardwareButtonInfo dYjmqcSawoKxCjWLBmbegPeVbVig;

			public bool valuePrev => false;

			public bool value => false;

			public float pressure => 0f;

			public float pressurePrev => 0f;

			public bool isPressureSensitive => false;

			public bool justPressed => false;

			public bool justReleased => false;

			public bool justChangedState => false;

			public bool doublePressedAndHeld => false;

			public bool justDoublePressed => false;

			public double timePressed => 0.0;

			public double timeUnpressed => 0.0;

			public double lastTimePressed => 0.0;

			public double lastTimeUnpressed => 0.0;

			public double lastTimeStateChanged => 0.0;

			internal ButtonStateFlags TSMufmgufRclkRKuuckvauIZNzFQA => default(ButtonStateFlags);

			internal Button(Controller P_0, int P_1, string P_2, HardwareButtonInfo P_3)
				: base(null, 0, null, default(ControllerElementType))
			{
			}

			internal Button(Controller P_0, int P_1, string P_2, bool P_3, HardwareButtonInfo P_4)
				: base(null, 0, null, default(ControllerElementType))
			{
			}

			public bool DoublePressedAndHeld(float speed)
			{
				return false;
			}

			public bool JustDoublePressed(float speed)
			{
				return false;
			}

			internal void ouuPvNyRUbCMyFnbDqdlAKUqruxQ(UpdateLoopType P_0, int P_1, ControllerDataUpdater P_2)
			{
			}

			internal void AxwdTteaqddMXztEgGgMAYifeHOuA(UpdateLoopType P_0)
			{
			}

			internal void IgzgSqodOPavxgbqYFIteVjpvfan()
			{
			}
		}

		public abstract class CompoundElement
		{
			private class mXMpCWqZzGRPxixQJcNMOwhcTVMr
			{
				public readonly Element oWjAFKEFiPCMFIbugSILBftTMJUiA;

				public readonly int FuTAAbIogauHSEjJzvCpqbBjEXLsA;

				public mXMpCWqZzGRPxixQJcNMOwhcTVMr(Element P_0, int P_1)
				{
				}
			}

			private int yjhWtvxagZNCUxEsXmEAltDNdmSl;

			private string uqqoymhbtOsHCKKDvzLneahvBaOiA;

			private CompoundControllerElementType ocRGrLAkdXWKatZzzcwqsQYtrEbn;

			private int diHgqvgInqaFaMzZNlOZXOHcBvdK;

			private mXMpCWqZzGRPxixQJcNMOwhcTVMr[] NLzZiNefFSANwGOBfIloRkNkTYOLA;

			private Controller NDrxuvokSTQVDISKswStwAiutQuL;

			internal readonly int pCnmyGvAaUbtQFUxMNzpAMkpkeUo;

			public int id => 0;

			public string name => null;

			public CompoundControllerElementType type => default(CompoundControllerElementType);

			public bool hasElements => false;

			public int elementCount => 0;

			public abstract int elementCapacity { get; }

			public ControllerElementIdentifier elementIdentifier => null;

			internal CompoundElement(Controller P_0, int P_1, string P_2, CompoundControllerElementType P_3)
			{
			}

			internal Element liiwEmLUDSskrnCJikzdWXahIALr(int P_0)
			{
				return null;
			}

			internal _0001 liiwEmLUDSskrnCJikzdWXahIALr<_0001>(int P_0) where _0001 : Element
			{
				return null;
			}

			internal _0001 aPPeYCnsFlIrSpwZpManBwBNLAFW<_0001>(int P_0, out int P_1) where _0001 : Element
			{
				P_1 = default(int);
				return null;
			}

			internal bool CqfRZGMjKHnRqAggjGkcDqzSALYA(Element P_0, int P_1)
			{
				return false;
			}

			internal bool StFJihcouqBDuIISThVKJTywmvsD(Element P_0)
			{
				return false;
			}

			internal void jdcYNoQdwSlPvwMMnaUbhtHhGxFiA()
			{
			}

			private int eASWFmPMBJuMGnUgAJFNWslWrAUD(Element P_0)
			{
				return 0;
			}

			private bool xUMWOuQcoppiMHOTvCyVHmSUfUSab(Element P_0, int P_1, int P_2)
			{
				return false;
			}

			private bool PXQkkGLGMSocrufttmkFombgzrrk(int P_0)
			{
				return false;
			}

			private int MlvrSOkMkjTHCcxnrhbiUltQQkyN()
			{
				return 0;
			}
		}

		public sealed class Axis2D : CompoundElement
		{
			private const int fsFwszSgeTkzOfSjuQdzLNVHaGtZ = 2;

			private CalibrationMap mNRdlfWhfSCUVEibWBbQuDNwGZKvA;

			public override int elementCapacity => 0;

			public Axis xAxis => null;

			public Axis yAxis => null;

			public Vector2 value => default(Vector2);

			public Vector2 valuePrev => default(Vector2);

			public Vector2 valueRaw => default(Vector2);

			public Vector2 valueRawPrev => default(Vector2);

			internal Axis2D(Controller P_0, int P_1, string P_2, Axis P_3, Axis P_4, int P_5, int P_6, CalibrationMap P_7)
				: base(null, 0, null, default(CompoundControllerElementType))
			{
			}

			internal void xmbEqmiNwLvTGRWKdVUeLMnHEmEd()
			{
			}

			private Vector2 sxqzaNOlrmgxViHwOdLZoaSyxkMKA()
			{
				return default(Vector2);
			}

			private Vector2 PtKBqvwBbiuSZirqKfDyRkIcnXqe()
			{
				return default(Vector2);
			}
		}

		public sealed class Hat : CompoundElement
		{
			private const int QfEXEaDIJCsvlTMqLnyGEHTKAmfY = 8;

			private const int RdJepLCVdaOaVpkPucnGdtzIILWmc = 0;

			private const int sVskxshxinlhYBJDTxmjeOvSOJTW = 1;

			private const int ANeARvcBONaLDELQsljGycFxoEKvA = 2;

			private const int gbcuFUoIxQiVNMrhnTiOgLzJYxfD = 3;

			private const int ZOQiusunlwIvoHDqaoyvNQZrDAYQA = 4;

			private const int BGWpGLgfzwpohjTFxrtIqvhiAGdg = 5;

			private const int CtvkvTgFNSHMlKAcTpMrgbwLnTCz = 6;

			private const int akZGyOrrFtDsEARSJeTagaOVJBeYA = 7;

			private readonly int LMhDoaWOVPMOUVjpbillbgHdhiKXA;

			private readonly Button[] lKFfFxBQJpyeXcbbHMxBKKmiFJyOA;

			private readonly ReadOnlyCollection<Button> CwsQPNRQAcpacYADnQJWwfPrZjMI;

			private readonly int[] SZlrqGFOJUYCrHMhYAwVgleDWemaA;

			private bool MXnGlFRJpFepagcHqOxTAjUiGyCO;

			public override int elementCapacity => 0;

			public bool force4Way
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public int directionCount => 0;

			public IList<Button> Buttons => null;

			public Button buttonUp => null;

			public Button buttonRight => null;

			public Button buttonDown => null;

			public Button buttonLeft => null;

			public Button buttonUpRight => null;

			public Button buttonDownRight => null;

			public Button buttonDownLeft => null;

			public Button buttonUpLeft => null;

			internal Hat(Controller P_0, int P_1, string P_2, Button[] P_3, int[] P_4)
				: base(null, 0, null, default(CompoundControllerElementType))
			{
			}

			internal void XZIVnpScGXTaLtdiFtZATTQiqnTX(UpdateLoopType P_0, ControllerDataUpdater P_1)
			{
			}

			private void PiCAxICbmRFiQxaJYLRNerbJbAdoB(Button P_0, int P_1, int P_2, int P_3, UpdateLoopType P_4, ControllerDataUpdater P_5)
			{
			}

			private void oFWrIDsgEzaNcEWyIDmiKAaxVKLc(Button P_0, int P_1, UpdateLoopType P_2, ControllerDataUpdater P_3)
			{
			}
		}

		public sealed class DirectionalPad : CompoundElement
		{
			private const int rTlKsRRSjDSoiKlwEpLlmNfDSfKF = 4;

			private const int VWuuRPxSexQSjIepWhciHycMwmUC = 0;

			private const int KvyBrpCoLHRELRTumLKpQcRnLDpu = 1;

			private const int uYTHKxAkiJPCzacDBGRjWFGGJwXA = 2;

			private const int VszjWUPvNJRBXqqnPiNwTnTYCnEIA = 3;

			private readonly int zLucfmbOjLcXjCkCaPYRwywPhUpT;

			private readonly Button[] NmNbCpfljlskaWoRwbkDunTNqyPs;

			private readonly ReadOnlyCollection<Button> bUOXnEGxrdSsLyXfwibcNMrjfFvG;

			private readonly int[] MkIiTLhPAdmHwQwQnrWqYyHKgAQd;

			public override int elementCapacity => 0;

			public IList<Button> Buttons => null;

			public Button buttonUp => null;

			public Button buttonRight => null;

			public Button buttonDown => null;

			public Button buttonLeft => null;

			internal DirectionalPad(Controller P_0, int P_1, string P_2, Button[] P_3, int[] P_4)
				: base(null, 0, null, default(CompoundControllerElementType))
			{
			}

			internal void vfwhdAaAjdEygOBCyfJOFvQbswhvb(UpdateLoopType P_0, ControllerDataUpdater P_1)
			{
			}
		}

		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public abstract class Extension
		{
			private Controller uGeJGwBnerIHMwBBQAaFHdUMzbSu;

			private IControllerExtensionSource qLFVYOLLcpeMNGwhxgVMmFGuPcv;

			internal readonly int _reInputId;

			internal bool isJoystickConnected => false;

			internal bool enabled => false;

			public Controller controller => null;

			internal Extension(IControllerExtensionSource P_0)
			{
			}

			internal Extension(Extension P_0)
			{
			}

			internal T GetController<T>() where T : Controller
			{
				return null;
			}

			internal void SetController(Controller controller)
			{
			}

			[CustomObfuscation(rename = false)]
			internal IControllerExtensionSource GetSource()
			{
				return null;
			}

			internal void SetSource(Extension extension)
			{
			}

			private void UWODeqiPCmpjuMtBReslLLDmjeciA(IControllerExtensionSource P_0)
			{
			}

			internal virtual void Clear()
			{
			}

			internal abstract void SourceUpdated(IControllerExtensionSource source);

			internal abstract void UpdateData(UpdateLoopType updateLoop);

			internal abstract Extension Clone();
		}

		[Serializable]
		private sealed class TiVJDxcSHHRrPDfcNsVeGickOmcY
		{
			public static readonly TiVJDxcSHHRrPDfcNsVeGickOmcY _003C_003E9;

			public static Func<Controller, Guid, bool> _003C_003E9__166_0;

			public static Func<Controller, Type, bool> _003C_003E9__169_0;

			internal bool YblRRkDYnItgyTYArRrhIAJREhGd(Controller P_0, Guid P_1)
			{
				return false;
			}

			internal bool jyGqyFZdhNmySROCCVrERnzCZSyh(Controller P_0, Type P_1)
			{
				return false;
			}
		}

		private sealed class UkiZSmKCYrVlAuEbMDQeEKtiKseP : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int NnRVkrMOwtoygCiOVmHxMlDKtPsM;

			private ControllerPollingInfo FqVtRmYTjoKfhkbFrrBRdDmFJmpW;

			private int JYkISyCSeqZGoeEMcVabhdEnALGW;

			public Controller TDyPmljhTQwgsERVGPByIGIaEPEQ;

			private int dOXmjeejOhIGxeSjhVeBmUbOMOioA;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(ControllerPollingInfo);
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public UkiZSmKCYrVlAuEbMDQeEKtiKseP(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
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
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private sealed class WyVDHNUPVCrwqHquOipBszoIShNr : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int LKpEFaEqNyLgfuReCPMkGkGGPppk;

			private ControllerPollingInfo ShEKtrdiEDmUeCSWHBiEakMaMiyoA;

			private int WDBPqSShPUcWWjBQcDnnkCGdCgvfA;

			public Controller YsWdBTqCVstDCSjawaGzGNOXjpjcb;

			private int soZuSDwaaydpylGyvdnbhuIuyTlqA;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(ControllerPollingInfo);
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public WyVDHNUPVCrwqHquOipBszoIShNr(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
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
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public readonly int id;

		protected string _tag;

		protected string _name;

		private readonly DeviceLocalizationInfo ktjfKAkXSgEWtcoYvESsrEStHfXqA;

		protected string _hardwareName;

		protected readonly ControllerType _type;

		internal readonly Guid htGdydDAehGzXKOjwvJrpfYYBoFN;

		protected string _hardwareIdentifier;

		protected bool _isConnected;

		private Extension mXyhTrJiPocfooPtAbtrFUUoZfVQA;

		private bool WZnwJFsgrFufeGLwcawLfxcertDpA;

		private ControllerIdentifier oTTDACSTacXivteChZwMofyljqVj;

		internal int QfoMlUwoZvbDNduOcBCPbqzLkAzv;

		protected readonly int _buttonCount;

		protected readonly Button[] buttons;

		protected readonly ReadOnlyCollection<Button> buttons_readOnly;

		private readonly IList<Element> kOMFLyVHwCgTNBZeCTreLijZfQsFA;

		private readonly ReadOnlyCollection<Element> yBRftUKxGuMYhFbsFwhGqioibowt;

		private readonly IList<CompoundElement> XxOUIvqgKqeKuiEtmctGgQJJLbghB;

		private readonly ReadOnlyCollection<CompoundElement> xijdTwCVYLlxfdRqtMCYWxYtXCxW;

		[CustomObfuscation(rename = false)]
		internal readonly InputSource inputSource;

		internal readonly ControllerDataUpdater mayyHLPNyfbJMAsCWGYjuZVIlqBiA;

		internal readonly HardwareControllerMap_Game YgLFpavjNVbLIfOsDIGTYgZxcZNGA;

		internal uint YLqFtssdtUyhXDdfndGyLhzwfixEA;

		private uint fHuJEDgVYkqOzAoYSvDHUIFVORUK;

		private uint XMjqrIsAFleJEEtXbbbpEQYZcFhGb;

		private ITryGetLocalizedName ERfsfJXzYgxEPrWWcYspfwCNSeob;

		private readonly LocalizedString sqhkOfIBPiNECSsUCyDZMDfwHZkt;

		private readonly tmpzpaZXCvsusfPERWtQvkUUQTDv YsFTKkFzzDauoADFsCcXlxUNByxh;

		private Action<bool> AdBonhKDXEcbJiraBMzkaKtHnYqvb;

		private IControllerTemplate[] LbGiaijFqfdmkxyDQbqFXqtTxzNp;

		private ReadOnlyCollection<IControllerTemplate> bZczXLzRChgVIAtaXtQvhyLxADnH;

		private static Func<Controller, Guid, bool> EAWhCuAlLavjLUqfKnJFjLPpqFUwA;

		private static Func<Controller, Type, bool> aGLEooQIApkDLOJsNcvwyVrSinvf;

		internal bool FTtJwTdFneoivxdrzzjlJnaRVZrm => false;

		public bool enabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public string name
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public string tag
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string hardwareName => null;

		public ControllerType type => default(ControllerType);

		public Guid hardwareTypeGuid => default(Guid);

		public abstract Guid deviceInstanceGuid { get; }

		public ControllerIdentifier identifier => default(ControllerIdentifier);

		public bool isConnected
		{
			get
			{
				return false;
			}
			internal set
			{
			}
		}

		public string hardwareIdentifier => null;

		public string mapTypeString => null;

		public int elementCount => 0;

		public int buttonCount => 0;

		public IList<Element> Elements => null;

		public IList<CompoundElement> CompoundElements => null;

		public IList<Button> Buttons => null;

		public Extension extension => null;

		public IList<ControllerElementIdentifier> ElementIdentifiers => null;

		public IList<ControllerElementIdentifier> ButtonElementIdentifiers => null;

		internal ITryGetLocalizedName OXxiuXsyOqbRHnVEHGAokXPXcsTE
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public IList<IControllerTemplate> Templates => null;

		public int templateCount => 0;

		internal static Func<Controller, Guid, bool> NOKxMiqhpFtwrmFsIQHvLDEbomRt => null;

		internal static Func<Controller, Type, bool> yuITUvnUXlCglxExnvwJIzKaPWyj => null;

		internal event Action<bool> EBQbVjaHljfxSRmxsoutvkgPftwBb
		{
			add
			{
			}
			remove
			{
			}
		}

		internal Controller(int P_0, InputSource P_1, string P_2, string P_3, string P_4, ControllerType P_5, Guid P_6, int P_7, bool[] P_8, HardwareButtonInfo[] P_9, HardwareControllerMap_Game P_10, Extension P_11, ControllerDataUpdater P_12)
		{
		}

		internal virtual void uZjQGmTJhFKwensHdNpNIzWKmruB()
		{
		}

		public virtual Element GetElementById(int elementIdentifierId)
		{
			return null;
		}

		public virtual CompoundElement GetCompoundElementById(int elementIdentifierId)
		{
			return null;
		}

		[Obsolete("This method is deprecated. Use GetCompoundElementById instead.", false)]
		public virtual CompoundElement GetCompundElementById(int elementIdentifierId)
		{
			return null;
		}

		public int GetButtonIndexById(int elementIdentifierId)
		{
			return 0;
		}

		public ControllerElementIdentifier GetElementIdentifierById(int elementIdentifierId)
		{
			return null;
		}

		public virtual bool GetButton(int index)
		{
			return false;
		}

		public virtual bool GetButtonDown(int index)
		{
			return false;
		}

		public virtual bool GetButtonUp(int index)
		{
			return false;
		}

		public virtual bool GetButtonChanged(int index)
		{
			return false;
		}

		public virtual bool GetButtonPrev(int index)
		{
			return false;
		}

		public virtual bool GetButtonDoublePressHold(int index)
		{
			return false;
		}

		public virtual bool GetButtonDoublePressHold(int index, float speed)
		{
			return false;
		}

		public virtual bool GetButtonDoublePressDown(int index)
		{
			return false;
		}

		public virtual bool GetButtonDoublePressDown(int index, float speed)
		{
			return false;
		}

		public virtual double GetButtonTimePressed(int index)
		{
			return 0.0;
		}

		public virtual double GetButtonTimeUnpressed(int index)
		{
			return 0.0;
		}

		public virtual double GetButtonLastTimePressed(int index)
		{
			return 0.0;
		}

		public virtual double GetButtonLastTimeUnpressed(int index)
		{
			return 0.0;
		}

		public virtual bool GetAnyButton()
		{
			return false;
		}

		public virtual bool GetAnyButtonDown()
		{
			return false;
		}

		public virtual bool GetAnyButtonUp()
		{
			return false;
		}

		public virtual bool GetAnyButtonPrev()
		{
			return false;
		}

		public virtual bool GetAnyButtonChanged()
		{
			return false;
		}

		public virtual bool GetButtonById(int elementIdentifierId)
		{
			return false;
		}

		public virtual bool GetButtonDownById(int elementIdentifierId)
		{
			return false;
		}

		public virtual bool GetButtonUpById(int elementIdentifierId)
		{
			return false;
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId, float speed)
		{
			return false;
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId, float speed)
		{
			return false;
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId)
		{
			return false;
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId)
		{
			return false;
		}

		public virtual bool GetButtonPrevById(int elementIdentifierId)
		{
			return false;
		}

		public virtual double GetButtonTimePressedById(int elementIdentifierId)
		{
			return 0.0;
		}

		public virtual double GetButtonTimeUnpressedById(int elementIdentifierId)
		{
			return 0.0;
		}

		public virtual double GetButtonLastTimePressedById(int elementIdentifierId)
		{
			return 0.0;
		}

		public virtual double GetButtonLastTimeUnpressedById(int elementIdentifierId)
		{
			return 0.0;
		}

		public virtual ControllerPollingInfo PollForFirstElement()
		{
			return default(ControllerPollingInfo);
		}

		public virtual ControllerPollingInfo PollForFirstElementDown()
		{
			return default(ControllerPollingInfo);
		}

		public virtual ControllerPollingInfo PollForFirstButton()
		{
			return default(ControllerPollingInfo);
		}

		public virtual ControllerPollingInfo PollForFirstButtonDown()
		{
			return default(ControllerPollingInfo);
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllElements()
		{
			return null;
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
		{
			return null;
		}

		[IteratorStateMachine(typeof(UkiZSmKCYrVlAuEbMDQeEKtiKseP))]
		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtons()
		{
			return null;
		}

		[IteratorStateMachine(typeof(WyVDHNUPVCrwqHquOipBszoIShNr))]
		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtonsDown()
		{
			return null;
		}

		private bool fYAPCdOQhnCiDgwIsTdARFpuqBOV(int P_0, out int P_1)
		{
			P_1 = default(int);
			return false;
		}

		private bool FffcURYUkBAEMKXsJaAGatDFwdhmA(int P_0, out int P_1)
		{
			P_1 = default(int);
			return false;
		}

		protected void UpdatePollingFrameTracking()
		{
		}

		public virtual double GetLastTimeActive()
		{
			return 0.0;
		}

		public virtual double GetLastTimeActive(bool useRawValues)
		{
			return 0.0;
		}

		public virtual double GetLastTimeAnyElementChanged()
		{
			return 0.0;
		}

		public virtual double GetLastTimeAnyElementChanged(bool useRawValues)
		{
			return 0.0;
		}

		public double GetLastTimeAnyButtonPressed()
		{
			return 0.0;
		}

		public double GetLastTimeAnyButtonChanged()
		{
			return 0.0;
		}

		public T GetExtension<T>() where T : class
		{
			return null;
		}

		public IControllerTemplate GetTemplate(Guid typeGuid)
		{
			return null;
		}

		public IControllerTemplate GetTemplate(Type type)
		{
			return null;
		}

		public T GetTemplate<T>() where T : class
		{
			return null;
		}

		public bool ImplementsTemplate(Guid typeGuid)
		{
			return false;
		}

		public bool ImplementsTemplate(Type type)
		{
			return false;
		}

		public bool ImplementsTemplate<T>() where T : class
		{
			return false;
		}

		internal void QxemHteCHgaRWDFZhbXXDOeXXWOzA(IControllerTemplate[] P_0)
		{
		}

		internal virtual void JXxDIRZpnsgiGXNGCAUihWVkSdwx(UpdateLoopType P_0)
		{
		}

		internal virtual ButtonStateFlags dbWXilhpsuaozfsrLNKPdReTVsTz(int P_0)
		{
			return default(ButtonStateFlags);
		}

		internal void SPXuKnPjyjbxzfWDiqFDuSePMoeyA(Extension P_0)
		{
		}

		internal void QRTRQBWkxyvvePOVredTwUDEzpzf(Extension P_0)
		{
		}

		internal virtual void fDlKuMABpdnNzezjAcKGsqfGpGcE()
		{
		}

		internal virtual bool ElEvIvMPwHGEirtSjuwsUVBdtARp(bool P_0)
		{
			return false;
		}

		internal virtual void NgSVRXtzGmXahkQxjWThqqmlVJXH(ControllerMap P_0)
		{
		}

		internal virtual void BEMHamOlnupxqKxDqmuyQAAUjGvI(ControllerMap P_0, ActionElementMap P_1)
		{
		}

		internal bool BhzdfiHmvjPaSSQWVEBDFmbjimpGA(ActionElementMap P_0, int P_1, out float P_2, out bool P_3)
		{
			P_2 = default(float);
			P_3 = default(bool);
			return false;
		}

		internal bool vnFaGDYjXsKhIsXTfBghxGrFaRBU(ActionElementMap P_0, int P_1, bool P_2, out float P_3)
		{
			P_3 = default(float);
			return false;
		}

		internal void HDTybFzIBBMQxccCIHrbcPWPQJSwA(Element P_0)
		{
		}

		internal void sHiwsqKNZVpsDoPyHvVjwyOsEbIq(CompoundElement P_0)
		{
		}

		internal virtual Guid yVyNmGlVHDfMrWvbxQEMBlvOGLSCA()
		{
			return default(Guid);
		}

		internal virtual void pmKeldfEgYcUHdSZgCOYBoCGnvRfc(bool P_0)
		{
		}

		protected virtual void Connected()
		{
		}

		protected virtual void Disconnected()
		{
		}

		[CompilerGenerated]
		private void FNJwgtObXlUDXpqfYIEPAYbPxfIGA()
		{
		}
	}
}
