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
			internal abstract class oPRYmrproXcaBopMQdVNpxBLSIsT
			{
				public abstract class drCpUXORKqGkKDRdACrJNbMlYOhE
				{
					public abstract void TdgHFAcEXTmYLCNIfcZzEtyDhTpiA();
				}

				protected readonly int JyDRhRjUqUodKFWzssMzSbAliwdh;

				protected readonly int[] YzKbpdcYyPvJPwPWhRiVRSdVbdsC;

				protected drCpUXORKqGkKDRdACrJNbMlYOhE[] BXxRETkIvaPrUrpcqCntkRPWbaVvA;

				public drCpUXORKqGkKDRdACrJNbMlYOhE HldQYeALeSgiPGQYxXQkvsQaQMyj;

				private int lfsEPtbfIgwTkRrQIPTHituWKuYO;

				public int owuBMsWtJjMUROpjXgMUMcNBBieO;

				protected ReadOnlyCollection<drCpUXORKqGkKDRdACrJNbMlYOhE> sgpPUXOCjqiwkgsmGPpNnSbrBGeb;

				public IList<drCpUXORKqGkKDRdACrJNbMlYOhE> dfFhBbgUZOnZiOEQIIzQGsaGjLVAb => null;

				public UpdateLoopType ivZKEXLrtkYHUzmwACPLXAKlFOme
				{
					set
					{
					}
				}

				public oPRYmrproXcaBopMQdVNpxBLSIsT(UpdateLoopSetting P_0)
				{
				}

				public void ZvzAVJrMptbTDlTcGOfIKTkvntRM()
				{
				}

				public drCpUXORKqGkKDRdACrJNbMlYOhE UjztNajwRnfIZfnedhLOkGLuhyJFb(UpdateLoopType P_0)
				{
					return null;
				}
			}

			public readonly int id;

			public readonly string name;

			public readonly ControllerElementType type;

			internal oPRYmrproXcaBopMQdVNpxBLSIsT qNmPKDIHrREFaimlwfEUubcNxqxoA;

			internal int sMmzPYnPhCiICdSxfvdcCthfXIzZ;

			internal Controller AaCsFPNQYSLZiDGAyNnLhoIfbiXhA;

			internal readonly int tJIBKaOpLSzLsyfgpLxcdkJVkWmG;

			private CompoundElement SjdmpIckNCkcqRAeAxcdCRPaxAKo;

			public ControllerElementIdentifier elementIdentifier => null;

			public bool isMemberElement => false;

			public CompoundElement compoundElement => null;

			internal Element(Controller P_0, int P_1, string P_2, ControllerElementType P_3)
			{
			}

			public void Reset()
			{
			}

			internal void tVQxilfxbLqNFFIzdjMBHAjJPtqv(CompoundElement P_0)
			{
			}

			internal void gwvsIBxRsHqxMqOvNCvkGJGYxLnk(CompoundElement P_0)
			{
			}
		}

		public sealed class Axis : Element
		{
			internal class zjZShsvOpZkUPmZlkHxmikpvroRW : oPRYmrproXcaBopMQdVNpxBLSIsT
			{
				public class exTgaIdkfbmMAaxlpWsVjEZNCjLeb : drCpUXORKqGkKDRdACrJNbMlYOhE
				{
					private const float mrUOjmXSqqdBpDeZBbroPChGDRXiA = 0.001f;

					public float ukfttlEjlxiFyIuqBEEBpgYdWNskA;

					public float SRLABJSRKCbCEiEaamgGhohFJwVjc;

					public float vweedEfvYXxlOzARReTtgWGYVpWKA;

					public float KCWZHhpACDKZlJKTCfkauOnJjocv;

					public float DrlwTHJvVrZkGyYOziQrdxmQUmEF;

					public float syinRYlxRvLEVVDsEHzaNpQWLYIf;

					public double SRRrEopBiQcicdKlrfktjTzZXsJZA;

					public double yueIKXPwfNSxfkDYBgVntMabDDbr;

					public double nyGFKORkSAqsslKelYVnAMiFYvTq;

					public double XWKIYBQbfcheAFuoJDxCddycEapic;

					public double TGPkvljtCOfLrnOntJyMczlpWXLP;

					public double iPAeMkOJwQLCmZTKoNlxZyCfjtYR;

					public double ZaWGMscJYAHllFFFhDYiBkjLxiFSA => 0.0;

					public double MGXeUEPbnPLPuUmcQBObpKLsdUE => 0.0;

					public double zHXELcdNJChUTuflojiznqFJQJQgA => 0.0;

					public double ZaXUhSjYKYwrjMoKMskPglFasVQF => 0.0;

					public void NdUOpcjupvqbdyQzphMyUyVmITnS(bool P_0)
					{
					}

					public void pFCdtpqfMSgGAGvEEfGSOhXIblgh(float P_0)
					{
					}

					public override void TdgHFAcEXTmYLCNIfcZzEtyDhTpiA()
					{
					}
				}

				public zjZShsvOpZkUPmZlkHxmikpvroRW(UpdateLoopSetting P_0)
					: base(default(UpdateLoopSetting))
				{
				}
			}

			internal readonly AxisRange ppZzxRhixhuISUTqerfxvaseQpyH;

			internal readonly HardwareAxisInfo afgIGbvfsdAqafnsnkrLAjUgNKKZA;

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

			internal float ClRFHORADIBxADzYHScqbiObCmynA => 0f;

			internal float ZuZEfTFMAfdrNnUJLmznvQavpPoeA => 0f;

			internal float QTzHsKNCvCgJtFKTkmnUguIDTlKhB => 0f;

			internal void DtlDrGuIjqFbebTiPUktUyzYbIKiA(float P_0)
			{
			}

			internal Axis(Controller P_0, int P_1, string P_2, AxisRange P_3, HardwareAxisInfo P_4)
				: base(null, 0, null, default(ControllerElementType))
			{
			}

			internal void iquDSGtSOtbrPRBZCvGclROMDxjs(UpdateLoopType P_0)
			{
			}

			internal void MXmxvKwPjQzSAcJnrRuOvGtGjTkm(AxisCalibration P_0)
			{
			}

			internal void HzYebMecEthjCHLfMygXBRyiErVg()
			{
			}

			internal void PXGEDzKZtLobsQgbQdReJqYeQMaHb()
			{
			}

			internal void apuRLdROLUlaXKhCsJAegMTgPJzQ()
			{
			}

			internal void HztKiNDkOPdEXcSaZuzsDsudPTcoA(float P_0)
			{
			}

			internal float XfZcvsVuOOqbeFdhvOhaoEWFSdu(UpdateLoopType P_0, AxisCalibration P_1)
			{
				return 0f;
			}
		}

		public sealed class Button : Element
		{
			internal class qfIgPsVavPgQqMhjErfCgneizOVs : oPRYmrproXcaBopMQdVNpxBLSIsT
			{
				public class YdcdTNmixrvkCfOWlTxpUuXrPjFF : drCpUXORKqGkKDRdACrJNbMlYOhE
				{
					public bool htYrLvNlBLmPTBdrsXBRPRzBqElH;

					public bool sxEnymdDSURYsDcCCFNTkHxfOXplA;

					public ButtonStateRecorder HsOccfAqIMTNPFtmvMheYByarCKDA;

					public bkgPixblbysvXpnnYDDlHkwhuCnH slQKQHWmqANHxCIpCAhQOtXHkIPJ;

					public void CGblICSRQOYEzRCzPEPDUHnUHThV(bool P_0)
					{
					}

					public override void TdgHFAcEXTmYLCNIfcZzEtyDhTpiA()
					{
					}
				}

				public class TjPiteCyTPLVbnzGEFSeXjoIEolA : YdcdTNmixrvkCfOWlTxpUuXrPjFF
				{
					public float ZSeEJgtFqoPZJNGlCJTNGpuirCJh;

					public float bjTCfspSJnAYNCRafUeuhxSryDnuA;

					public void HXBEJAyuKyJZmQNARVrKOBELFxtAA(float P_0)
					{
					}

					public override void TdgHFAcEXTmYLCNIfcZzEtyDhTpiA()
					{
					}
				}

				public qfIgPsVavPgQqMhjErfCgneizOVs(UpdateLoopSetting P_0, bool P_1)
					: base(default(UpdateLoopSetting))
				{
				}

				public void SxbJSpqunBeguiaCoQcZrvFNMfdS(float P_0)
				{
				}

				public void hKRfXWdArxBSeQZNqPaBuRSngNXOA()
				{
				}
			}

			internal readonly bool lGvArtcxNVjsozYUufwrTreQtnqE;

			internal readonly HardwareButtonInfo oOOErYiwpYEeWqmXkdGzlBqsAfnjb;

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

			internal ButtonStateFlags KfVkEKhmdoPwCNaToYmDtGyftIR => default(ButtonStateFlags);

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

			internal void dyDCahSrDHQiiIKpidPkBpQDxkgOA(UpdateLoopType P_0, int P_1, ControllerDataUpdater P_2)
			{
			}

			internal void BuTQMPCOjRreFeCKDpCXfbqUMLVS(UpdateLoopType P_0)
			{
			}

			internal void LCIptIIOXjmEtvzyhOwmNIxAkbjp()
			{
			}
		}

		public abstract class CompoundElement
		{
			private class dbzBJwGogqFxfanGcrrNerdXjVFdb
			{
				public readonly Element jdCQYqaGrhrsNwQwVMwMAWlaFLLS;

				public readonly int AkeNwDGjVKrDOgTXGuyTWFAWFGnc;

				public dbzBJwGogqFxfanGcrrNerdXjVFdb(Element P_0, int P_1)
				{
				}
			}

			private int vtEaXXAXtxanSayyknELGGFcTbJZA;

			private string tZFbrOBEkeelYNKNOwzmDPjUtsFS;

			private CompoundControllerElementType hfiaRzelubkhmiCpQFIrNbEOZAip;

			private int qBgdoXCJcUnakRQFcqjYoFTNkVcW;

			private dbzBJwGogqFxfanGcrrNerdXjVFdb[] OmGxrbCMpmhioZXuIXOnHFGLQxBd;

			private Controller MUUpNqALmhxZvLSnXSydRgUPjvJB;

			internal readonly int kMUhSoDppaZUWAfrfVKehmaKekLG;

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

			internal Element ooVepGdOMugGpkUXNWFqlZuUIVSl(int P_0)
			{
				return null;
			}

			internal _0001 ooVepGdOMugGpkUXNWFqlZuUIVSl<_0001>(int P_0) where _0001 : Element
			{
				return null;
			}

			internal _0001 xjoTeiJtUPLPQcCDOkOwukFgWGUW<_0001>(int P_0, out int P_1) where _0001 : Element
			{
				P_1 = default(int);
				return null;
			}

			internal bool TKTuMnsLeyUNXPOsXFehhgkGGMQnA(Element P_0, int P_1)
			{
				return false;
			}

			internal bool DkmkEVOxhKDjsPQMylNNgfgPwahO(Element P_0)
			{
				return false;
			}

			internal void auJYKjarIkdlMdCzGakWITBGzAfB()
			{
			}

			private int bKbWZtviPvbGCwIMbNrKrjinbxTiA(Element P_0)
			{
				return 0;
			}

			private bool kElPbCodXVMJAUJPUCbKPQBdWHPf(Element P_0, int P_1, int P_2)
			{
				return false;
			}

			private bool KRfdxodWHqIBzfJzWQcIDyhFnMgK(int P_0)
			{
				return false;
			}

			private int VyIBZgAxxDQrIjtrWdHxhTbtFupo()
			{
				return 0;
			}
		}

		public sealed class Axis2D : CompoundElement
		{
			private const int gEsLvJgppfhHCiejFxLmWwBsOKenA = 2;

			private CalibrationMap fEwteBuVukrsXvIpnZLPyoXFTBBP;

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

			internal void eLWBPQCGMtMNKgGQkYfliuKUqYZiB()
			{
			}

			private Vector2 pnFbCjokHWFpRQwQfnEYXMBBidRD()
			{
				return default(Vector2);
			}

			private Vector2 USnEEZjOyMFCVuhplVNhhegPKxlX()
			{
				return default(Vector2);
			}
		}

		public sealed class Hat : CompoundElement
		{
			private const int DVnLGUpMwoJjvGaFsGJJfNRlsmEB = 8;

			private const int WMewZdtuVIKNFhFkFTCJCdtbZEVC = 0;

			private const int xPDoyANRzDRiMUcRmUKcHjjjDZEu = 1;

			private const int TaJoKDAqFpsjVUMQLDBDHTRWZYXu = 2;

			private const int lrLFnkbOiwpGByBpIpbXBZfqISqY = 3;

			private const int EYrhaKMtkKZFqUBeTbQwbwDMaEZO = 4;

			private const int UWbVgfGSsEkDnqBLUwFLVAbLSOsw = 5;

			private const int BWAmYhOLIeentHYueoxkQByyPPHi = 6;

			private const int zdghtmLUWZKEKTMIunpzVOYmVPjJ = 7;

			private readonly int SPKlCKaqStyiQScnELKgJfDYwjHK;

			private readonly Button[] kRaIENucYTUJLydjsRZYvPqRZMrG;

			private readonly ReadOnlyCollection<Button> TpDENnHhDWoPupVBYguLnRJMmLFUA;

			private readonly int[] PJMblcpeWmympOzflUSAOjomGodAA;

			private bool NAKkCblzsjBSohNHXFcYxAOHAyJl;

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

			internal void KZrsVtaZrbERKskQudXsmMELpSDc(UpdateLoopType P_0, ControllerDataUpdater P_1)
			{
			}

			private void KspkSeNlsnAoApZHpvbCKHnGKTwh(Button P_0, int P_1, int P_2, int P_3, UpdateLoopType P_4, ControllerDataUpdater P_5)
			{
			}

			private void pIexccSmvVZEBZRShDxvroOCgJZeA(Button P_0, int P_1, UpdateLoopType P_2, ControllerDataUpdater P_3)
			{
			}
		}

		public sealed class DirectionalPad : CompoundElement
		{
			private const int gjUZLxlzRhOasDNnfcDkLNLkqGLR = 4;

			private const int MPJctveXRJmmbdLsjOFhBschYaDtA = 0;

			private const int LsLRwTgbOtdsHiSsRrusdlDAqNcdb = 1;

			private const int nXnuWgPMnMkfWyIyyDuUgnVjGFrlA = 2;

			private const int SVCJFazAQlExVhzrycthceZdBrDhA = 3;

			private readonly int iCBSkMRCifptzXOWLDcSbHqawSyjA;

			private readonly Button[] QciTXNJouBeGiFoLJtEERfXaBcGgA;

			private readonly ReadOnlyCollection<Button> wobeEmciuXRuFBlHBZEbTgUIbjcpA;

			private readonly int[] DZztfxDFUNAYiGLsGZTpjradEeRvA;

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

			internal void gLFiRwoFcVWGmKaGJdsXKvOFaOuL(UpdateLoopType P_0, ControllerDataUpdater P_1)
			{
			}
		}

		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public abstract class Extension
		{
			private Controller hnFEQQhJpNhcAzBHnwOYcpUzSvFR;

			private IControllerExtensionSource fqaTAaqnCKAMCiYaAhIYnhBhJJxeb;

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

			private void BKbfNWWuRQBUyHHKoMzyuFUBqrle(IControllerExtensionSource P_0)
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
		private sealed class ESqUHFInYxJlBQlwapNhfRgZeutI
		{
			public static readonly ESqUHFInYxJlBQlwapNhfRgZeutI _003C_003E9;

			public static Func<Controller, Guid, bool> _003C_003E9__166_0;

			public static Func<Controller, Type, bool> _003C_003E9__169_0;

			internal bool PKCvIbxtFomTmGXGWfWczbGuMTLk(Controller P_0, Guid P_1)
			{
				return false;
			}

			internal bool eovHfznwghHKWKLMbejXjirvXJvoA(Controller P_0, Type P_1)
			{
				return false;
			}
		}

		private sealed class FhTOKKgBFDzlQxLptQettmhLcWtk : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int EoWnXTirJmYsIVKwfjaNdZzlHzz;

			private ControllerPollingInfo UfkZsUuqCClslncFWpBUMqeuzcyw;

			private int IRZcVKdqDGJtqetADLzqxUKEuDNjA;

			public Controller GTTeQRCFCsbOuXPLpLxjHzMXMRBPA;

			private int iiiuFICXHHaJfXCxCgCObVlhhYnp;

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
			public FhTOKKgBFDzlQxLptQettmhLcWtk(int P_0)
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

		private sealed class XlaEqbgxKaQqaWNulVPOTaubjRSF : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int GQOeLSsYSYRprvbinvhnppYrjFaP;

			private ControllerPollingInfo HrtikXRIDbwsmBWWeEfJVkKBeLdH;

			private int VhmduwmWAuWVEsGCXBmyBqACmqwI;

			public Controller DYtQGtGnSWTnWVyyRqwwohUerbgU;

			private int nAiphtYVlALTicteQPVyXGMZPHsu;

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
			public XlaEqbgxKaQqaWNulVPOTaubjRSF(int P_0)
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

		private readonly DeviceLocalizationInfo zSUTpkCBXEwBldBYIsPhjHGEJjIP;

		protected string _hardwareName;

		protected readonly ControllerType _type;

		internal readonly Guid qFrfcLnshVTmXTnxTKBcIPIpRiAO;

		protected string _hardwareIdentifier;

		protected bool _isConnected;

		private Extension nANAtBzmGCDfudjpfRTufrQFxDAH;

		private bool LZAUbJSeFjDsrXoORASfUgtZfYNb;

		private ControllerIdentifier ntwYOsooCIqnrgIYYfxZdVoEkzUbb;

		internal int HSDekcECANFzFsXKNGqSWBdevUqt;

		protected readonly int _buttonCount;

		protected readonly Button[] buttons;

		protected readonly ReadOnlyCollection<Button> buttons_readOnly;

		private readonly IList<Element> lHxIzKvbXklgHAfmlRHpaPpmQEpI;

		private readonly ReadOnlyCollection<Element> liwpesqTPOCklKcgkLANBpeRTozU;

		private readonly IList<CompoundElement> SxzRPnUTJQuorBfbPJZHfNTcpbQc;

		private readonly ReadOnlyCollection<CompoundElement> gjKUhUxiRpVydQaoEaIRhwEMGeqk;

		[CustomObfuscation(rename = false)]
		internal readonly InputSource inputSource;

		internal readonly ControllerDataUpdater hALIahpbtLdOYpMEtoKiuZYzmnIe;

		internal readonly HardwareControllerMap_Game VwgLOELTGpdhAemicmuIdYBKOHEW;

		internal uint HfRHYEECycEOFmUpUAozEufBRwkBc;

		private uint iNJeAxYpFCdYjHBGpiPEIpTKoYPiB;

		private uint UaSfkiONUBqhAXtPKsRebhWaKLwS;

		private ITryGetLocalizedName FKSXdJhycQHNQcQUFJmjOiommQdQ;

		private readonly LocalizedString bZQEpPBmSOGpIiRWDpCUghnHRLChe;

		private readonly cxGaDQfXETIUymKccPHLQUBpFxME ZfsnKCxGmjXOeZpHFCcWCaKqnHmP;

		private Action<bool> TFmAsDqoUoaRFGuqkYRnBpdIIItYA;

		private IControllerTemplate[] OxfghANSdPbWgusZbEEWonzegrSBA;

		private ReadOnlyCollection<IControllerTemplate> cqNKzxJTgTnGMDmoqDBiYZUCWDgd;

		private static Func<Controller, Guid, bool> BQfJREXjSMZvPrajltTSsMDSNfRj;

		private static Func<Controller, Type, bool> xwaLNAofNPFxXdRkgqExVZprtisBA;

		internal bool KxQtsxHSgGOCxulzGLaekHwabZoK => false;

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

		internal ITryGetLocalizedName XWCVrQMNlYgHZcBRoVsdVRLgfwYhA
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

		internal static Func<Controller, Guid, bool> GraBEZGqzQOrWtublxcpgOGpeEuA => null;

		internal static Func<Controller, Type, bool> lhHDJRSbRmhcejGALQwfCdJVHne => null;

		internal event Action<bool> RHxKLxpkeDZaEzhmXABkLuFkjVpD
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

		internal virtual void piaSBqblIJLmgihiSxlmdwbnlwkN()
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

		[IteratorStateMachine(typeof(FhTOKKgBFDzlQxLptQettmhLcWtk))]
		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtons()
		{
			return null;
		}

		[IteratorStateMachine(typeof(XlaEqbgxKaQqaWNulVPOTaubjRSF))]
		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtonsDown()
		{
			return null;
		}

		private bool wblBJHebkVoYFtEKRBHFagxZZTRfA(int P_0, out int P_1)
		{
			P_1 = default(int);
			return false;
		}

		private bool GLUJchydurgEERmygkNNAJNwfXmC(int P_0, out int P_1)
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

		internal void PGTWqHEIIQdpAKrLGBpYfbegoYLkA(IControllerTemplate[] P_0)
		{
		}

		internal virtual void YKYVNphRaSYCICdOlkgpUiVDznty(UpdateLoopType P_0)
		{
		}

		internal virtual ButtonStateFlags gbzfHDVrMKWehxapkkQQaquggZQH(int P_0)
		{
			return default(ButtonStateFlags);
		}

		internal void DgGFVzYvPoVtXeNPavWfjugzgzlA(Extension P_0)
		{
		}

		internal void VRkfIdimqSsXeMLNOYEOPXDxUtgP(Extension P_0)
		{
		}

		internal virtual void qDCvRYqsIViBHdsnjFEZLKubCvtCA()
		{
		}

		internal virtual bool JbpBDYktpnwagiSlOUtczNfAEIQd(bool P_0)
		{
			return false;
		}

		internal virtual void GCjOSjFUNWOpfvYdErgyRpuObJUeA(ControllerMap P_0)
		{
		}

		internal virtual void WuxFUCgjwWDFubZVVeYfohYlyjqPA(ControllerMap P_0, ActionElementMap P_1)
		{
		}

		internal bool IuSoySnMcXDWYTzGsFvQepxYWokR(ActionElementMap P_0, int P_1, out float P_2, out bool P_3)
		{
			P_2 = default(float);
			P_3 = default(bool);
			return false;
		}

		internal bool qduLdxmcGEYkKnHNKmxiQrnwsRIW(ActionElementMap P_0, int P_1, bool P_2, out float P_3)
		{
			P_3 = default(float);
			return false;
		}

		internal void CTkejhHQctgCzdAOdLcgiCrgLATe(Element P_0)
		{
		}

		internal void fiFrCSqEEjOLObsdqzowFCcNxVjb(CompoundElement P_0)
		{
		}

		internal virtual Guid zIHCtkBgQnocjBopOcoZionvHRPBb()
		{
			return default(Guid);
		}

		internal virtual void gpteFPNWxwePZNjFNmkXTEYStxYh(bool P_0)
		{
		}

		protected virtual void Connected()
		{
		}

		protected virtual void Disconnected()
		{
		}

		[CompilerGenerated]
		private void QgsxFkiENOhFfgjbnmSVlnnyrBCb()
		{
		}
	}
}
