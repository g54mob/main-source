using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired
{
	public abstract class Controller
	{
		public abstract class Element
		{
			internal abstract class WNpyGCuliccFefQyNUuRdlpoHGKc
			{
				public abstract class xybeihjQdvpGQPxQuRdfCNRFFDX
				{
					public abstract void wcDfhuvvIloonVFErZkAXwihlbn();
				}

				protected readonly int mqNgTSOrdRFPKlUcIGsSYaxTOTC;

				protected readonly int[] wibilwWVuOgfHtKmZoOXnJPdCsZ;

				protected xybeihjQdvpGQPxQuRdfCNRFFDX[] GrZfYEkTEvFfsrQqENXvXJLTbTq;

				public xybeihjQdvpGQPxQuRdfCNRFFDX DNsUOSgZQrgrzaoVIbqmnEQQRth;

				private int bjflEjOceXoNSbWyZHEtmnfxUuN;

				public int jjQGkKiJZUcpHvqNiAQVtjTfEtI;

				protected ReadOnlyCollection<xybeihjQdvpGQPxQuRdfCNRFFDX> ktSRtaKCpXaNcJjtxGlyrpuNVEbD;

				public IList<xybeihjQdvpGQPxQuRdfCNRFFDX> Data => null;

				public UpdateLoopType updateLoop
				{
					set
					{
					}
				}

				public WNpyGCuliccFefQyNUuRdlpoHGKc(UpdateLoopSetting updateLoopSetting)
				{
				}

				public void wcDfhuvvIloonVFErZkAXwihlbn()
				{
				}
			}

			public readonly int id;

			public readonly string name;

			public readonly ControllerElementType type;

			internal WNpyGCuliccFefQyNUuRdlpoHGKc fxHPSDjbozROTmUBdFTfSrZDrXC;

			internal int AWCKrHCMdCEBXeWwIViWkNRNugNV;

			internal Controller tpqKoykKcOLYkAdTxfptCxwOTbTu;

			internal readonly int RSGBQYfltigFuhDMRviugFIbvohH;

			public ControllerElementIdentifier elementIdentifier => null;

			public bool isMemberElement => false;

			internal Element(Controller controller, int elementIdentifierId, string name, ControllerElementType type)
			{
			}

			public void Reset()
			{
			}

			internal void tfzshhGmbsBEXoKrjcRoLYHhVsJ()
			{
			}

			internal void YRjWudAECUhKHpsoSppYuOLMjKM()
			{
			}
		}

		public sealed class Axis : Element
		{
			internal class VgjTNRwNfajhsfSXlaGaivPIuch : WNpyGCuliccFefQyNUuRdlpoHGKc
			{
				public class oOwOdAuUcUvDMnzOrsdSGkZFoSy : xybeihjQdvpGQPxQuRdfCNRFFDX
				{
					private const float uXsVGAKfwJbXCGSJnVjuUlfVuxf = 0.001f;

					public float vlnXqrXZUnXUpcXPRJmvOerSEWc;

					public float tyxafAGCkVKyPXByslIlEbtRWKX;

					public float xrTbFpBNZEkOQumQWmedatXjsED;

					public float ChIejnZCCpHhAJurlDBAWkpApoW;

					public float CSoBVdRhEtvIauNckZFyNfqoBgGb;

					public float pcDSpXhdGiOltLXMeITwsiInJIJ;

					public double SPhbeWYvvZbnwGZfaYMRQRlvrDq;

					public double ekFFsUgLhUhnxKeyemkdqvUESUA;

					public double rNlauNMhVZCZUcWzuzjYKZFOMFb;

					public double zNeplFrcTnPorifKPmWPoVMOvEt;

					public double ORqABusQgRCYMDTVNKFyjzKPPhrf;

					public double WBgZuLBLKMGolgSdtfyiYAbpfZv;

					public double timeActive => 0.0;

					public double timeActiveRaw => 0.0;

					public double timeInactive => 0.0;

					public double timeInactiveRaw => 0.0;

					public void oDVbwUgIfbSDvfmIInVcyfSKnKRm(bool P_0)
					{
					}

					public void WIhaGwBSWsLCNvXclCaIdDudIKXu(float P_0)
					{
					}

					public override void wcDfhuvvIloonVFErZkAXwihlbn()
					{
					}
				}

				public VgjTNRwNfajhsfSXlaGaivPIuch(UpdateLoopSetting updateCycle)
					: base(default(UpdateLoopSetting))
				{
				}
			}

			internal readonly AxisRange queamqdKWoGuwQECUDRNOVdBiPv;

			internal readonly HardwareAxisInfo FsqspQicZjDkYfoBRbYJsZlFWJz;

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

			internal float selfValue => 0f;

			internal float selfValuePrev => 0f;

			internal float effectivePollingDeadZone => 0f;

			internal void ouBMOLbhcWsNpRrEcGTrwwvJCes(float P_0)
			{
			}

			internal Axis(Controller controller, int elementIdentifierId, string name, AxisRange axisRange, HardwareAxisInfo axisInfo)
				: base(null, 0, null, default(ControllerElementType))
			{
			}

			internal void DgSZHGVFwxcaPEHwtzqraflJYGXe(UpdateLoopType P_0)
			{
			}

			internal void aXffaoLGyYtQrtylZrIJjAjMbrU(AxisCalibration P_0)
			{
			}

			internal void aXffaoLGyYtQrtylZrIJjAjMbrU()
			{
			}

			internal void JmagWNFmhGVzrvuiGxQRuhVmYDp()
			{
			}

			internal void PbQBcafrkyCnfBlgHUbQPjiDQxuf()
			{
			}

			internal void pGkpdfgfYnZMAYvhgnlGsImYVwg(float P_0)
			{
			}

			internal float aICGAuWtdGyesiMhqqCCYMEjvSW(UpdateLoopType P_0, AxisCalibration P_1)
			{
				return 0f;
			}
		}

		public sealed class Button : Element
		{
			internal class YduMFVQDbqKvVJnXLwKWsjERbArD : WNpyGCuliccFefQyNUuRdlpoHGKc
			{
				public class wkLNuYdBwNDnDxCFDLLizPIqdAwC : xybeihjQdvpGQPxQuRdfCNRFFDX
				{
					public bool vlnXqrXZUnXUpcXPRJmvOerSEWc;

					public bool tyxafAGCkVKyPXByslIlEbtRWKX;

					public ButtonStateRecorder tbdYKBLwlHeKcSKnsVmXfplyQpw;

					public FnUdPKcxvNLvmuhVHaSrZIWEmTD aCnMAZDDdQDOBtJwAWUMTSKebJk;

					public void ynAzaTrXmpuZxcXTbTqTnIHFxKo(bool P_0)
					{
					}

					public override void wcDfhuvvIloonVFErZkAXwihlbn()
					{
					}
				}

				public class LBSErJPmvDvLcXirwfaKGSMGoLF : wkLNuYdBwNDnDxCFDLLizPIqdAwC
				{
					public float GePDhGCajVOQnyOvbEHyoBVnXjB;

					public float vYKoRrhifhWOVLssahfAdZNwkyj;

					public void ynAzaTrXmpuZxcXTbTqTnIHFxKo(float P_0)
					{
					}

					public override void wcDfhuvvIloonVFErZkAXwihlbn()
					{
					}
				}

				public YduMFVQDbqKvVJnXLwKWsjERbArD(UpdateLoopSetting updateCycle, bool isPressureSensitive)
					: base(default(UpdateLoopSetting))
				{
				}

				public void IdBYcFtMLqHFOkvqOkkmCEkBIXqS(float P_0)
				{
				}

				public void qEGlsjHjdRIkKgrWBGKyPFQOeTj()
				{
				}
			}

			internal readonly bool cPHLLhiGjGPjhiMfNXocNilcbqQ;

			internal readonly HardwareButtonInfo hGNQDotFEDfjeTiUNCIuAQINGxjj;

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

			internal ButtonStateFlags state => default(ButtonStateFlags);

			internal Button(Controller controller, int elementIdentifierId, string name, HardwareButtonInfo buttonInfo)
				: base(null, 0, null, default(ControllerElementType))
			{
			}

			internal Button(Controller controller, int elementIdentifierId, string name, bool isPressureSensitive, HardwareButtonInfo buttonInfo)
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

			internal void ynAzaTrXmpuZxcXTbTqTnIHFxKo(UpdateLoopType P_0, int P_1, ControllerDataUpdater P_2)
			{
			}

			internal void xXghybVadEanthGHIggkVCgbxIat(UpdateLoopType P_0)
			{
			}

			internal void pGkpdfgfYnZMAYvhgnlGsImYVwg()
			{
			}
		}

		public abstract class CompoundElement
		{
			private class HeBClNZjaDgEWbqopJAVGbRqGNxn
			{
				public readonly Element XrwfZuHOqgohwdZSTthJIzdewzjI;

				public readonly int odulvcqauCVSLnEOyEezKGePTLZ;

				public HeBClNZjaDgEWbqopJAVGbRqGNxn(Element element, int elementIndex)
				{
				}
			}

			private int YcDcbHqQMwtgQxoISZasthfuQlm;

			private string kmeYsmlXepROQEFJNIgdaFZxzqM;

			private CompoundControllerElementType WwGNBcAzyQKiegnejLCVExHzkIt;

			private int iYAFqnIdyjAzlclAedBLsssujGGB;

			private HeBClNZjaDgEWbqopJAVGbRqGNxn[] dUqaGcCfoWKXVGjiiebOuLeBmxHO;

			private Controller tpqKoykKcOLYkAdTxfptCxwOTbTu;

			internal readonly int RSGBQYfltigFuhDMRviugFIbvohH;

			public int id => 0;

			public string name => null;

			public CompoundControllerElementType type => default(CompoundControllerElementType);

			public bool hasElements => false;

			public int elementCount => 0;

			public abstract int elementCapacity { get; }

			public ControllerElementIdentifier elementIdentifier => null;

			internal CompoundElement(Controller controller, int elementIdentifierId, string name, CompoundControllerElementType type)
			{
			}

			internal Element otjzrFTdnAYWZYpQlaTqEPcnAJZ(int P_0)
			{
				return null;
			}

			internal T otjzrFTdnAYWZYpQlaTqEPcnAJZ<T>(int P_0) where T : Element
			{
				return null;
			}

			internal T aQdnVyAzZYDxHDzIiJmVnbceISE<T>(int P_0, out int P_1) where T : Element
			{
				P_1 = default(int);
				return null;
			}

			internal bool IKHRTuKkvFbvONMHJwmCBywAFGD(Element P_0, int P_1)
			{
				return false;
			}

			internal bool kjNXhEvtWAEFPHhnuphJqIEQmSk(Element P_0)
			{
				return false;
			}

			internal void wEUhMXcIauFpazSUmJzldeilhGCc()
			{
			}

			private int jOTZYhaRTkESqoRklsmyQGfNdZg(Element P_0)
			{
				return 0;
			}

			private bool hEqvcoFyNXjqSAlIlZFIWFVEDuO(Element P_0, int P_1, int P_2)
			{
				return false;
			}

			private bool EyEvwvuPfhWnnjOWVjyoWAlrnvq(int P_0)
			{
				return false;
			}

			private int VaBVWjQZQFjyzTCYBNJoYffGNEB()
			{
				return 0;
			}
		}

		public sealed class Axis2D : CompoundElement
		{
			private const int qIhfmmrMwOdhcIHDEqSqZXLPpYf = 2;

			private CalibrationMap HjVaukVOLUCxShDIBuALFcmsNBEf;

			public override int elementCapacity => 0;

			public Axis xAxis => null;

			public Axis yAxis => null;

			public Vector2 value => default(Vector2);

			public Vector2 valuePrev => default(Vector2);

			public Vector2 valueRaw => default(Vector2);

			public Vector2 valueRawPrev => default(Vector2);

			internal Axis2D(Controller controller, int elementIdentifierId, string name, Axis xAxis, Axis yAxis, int xAxisIndex, int yAxisIndex, CalibrationMap calibratonMap)
				: base(null, 0, null, default(CompoundControllerElementType))
			{
			}

			internal void ZucfMCUUpiUcGbSvbgTRvluOeUhc()
			{
			}

			private Vector2 WqsmIXysDsYDRSaXJHEdoUhMTQI()
			{
				return default(Vector2);
			}

			private Vector2 GyBcCvqPwbAUjyRsYFaeHrbKfqh()
			{
				return default(Vector2);
			}
		}

		public sealed class Hat : CompoundElement
		{
			private const int qIhfmmrMwOdhcIHDEqSqZXLPpYf = 8;

			private const int FathsRhVwHMoPaopfLdlLlHdUHEI = 0;

			private const int gZzLMycfubObUwDBdBzkEpYcRcb = 1;

			private const int PHqilVAQZaWoNKLxHvStjXOnntt = 2;

			private const int iqkZWuYoISeJLDAARgfFVwANwsT = 3;

			private const int RJMbZaDoxxuYwpruDWTNpRQQTGru = 4;

			private const int RIUjJBEKmGSeAFyayVmAbawNEOd = 5;

			private const int DusNYiAAiGAIaxjtbPyMuacfxpP = 6;

			private const int iYYdSMNMMyQPyDonMHmlvjrcAGjb = 7;

			private readonly int RrYxBmqUSBCLFEwCTngUveIoIMP;

			private readonly Button[] VkPFJCiiJjjRwtsEoPQYtrARvQCi;

			private readonly ReadOnlyCollection<Button> urFlYQladstPzzGSBlcHKLGOHtm;

			private readonly int[] djevUuuGrrhGllaNgCzXAGWiCQED;

			private bool LopJMfuquvqJIlergDOEEqFtLWzc;

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

			internal Hat(Controller controller, int elementIdentifierId, string name, Button[] buttons, int[] buttonIndices)
				: base(null, 0, null, default(CompoundControllerElementType))
			{
			}

			internal void ZucfMCUUpiUcGbSvbgTRvluOeUhc(UpdateLoopType P_0, ControllerDataUpdater P_1)
			{
			}

			private void aPrcblKMSjurTLVmtXWxTPiHbMXA(Button P_0, int P_1, int P_2, int P_3, UpdateLoopType P_4, ControllerDataUpdater P_5)
			{
			}

			private void jAdtkxKRCQmcEzOORRCTZkyphqk(Button P_0, int P_1, UpdateLoopType P_2, ControllerDataUpdater P_3)
			{
			}
		}

		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public abstract class Extension
		{
			private Controller tpqKoykKcOLYkAdTxfptCxwOTbTu;

			private IControllerExtensionSource tfTCEMKNedpBjaNONhTolgkIZhi;

			internal readonly int _reInputId;

			internal bool isJoystickConnected => false;

			internal bool enabled => false;

			internal Controller controller => null;

			internal Extension(IControllerExtensionSource source)
			{
			}

			internal Extension(Extension source)
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

			private void PZlPbSTKDSKmMKEdqqkYFPXpCCV(IControllerExtensionSource P_0)
			{
			}

			internal virtual void Clear()
			{
			}

			internal abstract void SourceUpdated(IControllerExtensionSource source);

			internal abstract void UpdateData(UpdateLoopType updateLoop);

			internal abstract Extension Clone();
		}

		private sealed class KiIkLwYlormhhMtlHwOouGevtIp : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo YDjDCBVmlkHQnKMyHwfXVborvEXS;

			private int KjzQtaNmLSFADNQocZpcbdUSqwW;

			private int heukQwubtgAAwETRDLwZfpUeIur;

			public Controller OLVemnFdjzUkQSlFFFIOsrknazt;

			public int hkjZwEtRcbNEZzlBIpvzpzhYPxY;

			public int idrQNnHCTHqhQmpngeLbtSGJaAH;

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
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
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

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public KiIkLwYlormhhMtlHwOouGevtIp(int _003C_003E1__state)
			{
			}
		}

		private sealed class DnYDYGGcmLDeyYdmgdASWOGhDDvA : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo YDjDCBVmlkHQnKMyHwfXVborvEXS;

			private int KjzQtaNmLSFADNQocZpcbdUSqwW;

			private int heukQwubtgAAwETRDLwZfpUeIur;

			public Controller OLVemnFdjzUkQSlFFFIOsrknazt;

			public int remgSeRMjbSxsGWEnoztHXPWGOn;

			public int FwBnZCQqSApOhdRFcwPtATSCKuT;

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
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
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

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public DnYDYGGcmLDeyYdmgdASWOGhDDvA(int _003C_003E1__state)
			{
			}
		}

		public readonly int id;

		protected string _tag;

		protected string _name;

		protected string _hardwareName;

		protected readonly ControllerType _type;

		internal readonly Guid kYGaYQCKfZFlKEWRAlzuFvTSafyH;

		protected string _hardwareIdentifier;

		protected bool _isConnected;

		private Extension nLirTpmApUFQKRfjXAdrcqyOjsEQ;

		private bool fYgWWBiWXTDKmooXjoXGiYdmpQy;

		private ControllerIdentifier OItdHJtsJCozneRsokzpbafiHoY;

		internal int RSGBQYfltigFuhDMRviugFIbvohH;

		protected readonly int _buttonCount;

		protected readonly Button[] buttons;

		protected readonly ReadOnlyCollection<Button> buttons_readOnly;

		private readonly IList<Element> ghELxvZccxyBcQOFxgfvOmJJMwd;

		private readonly ReadOnlyCollection<Element> UQBunaqbqSHfKmADyxRGWCRFoPU;

		internal readonly InputSource yoSyHRopdxoJZbHbOQnQvYEjUel;

		internal readonly ControllerDataUpdater EXnNFqQmsYLQJZGNGEwhLeTthrk;

		internal readonly HardwareControllerMap_Game zxQEfAFLNCohjaIzYOxqDqxypRJ;

		internal uint vKWoaAzYEAoawlhlkcpGVpIOZLH;

		private uint bwMIvZfwSDUTmemoNADzySBoNRK;

		private uint ylSgSvXaYdwdkoypcXbrBmhppxL;

		private Action<bool> zAFOCPktRkRIrkcIjRnVYdsIfEH;

		private IControllerTemplate[] UecFPhuBIuARjPJkkcaQjvtjqdM;

		private ReadOnlyCollection<IControllerTemplate> EdodvgFcGAMGbBtFdnLCgrYNpGxw;

		private static Func<Controller, Guid, bool> xiNlGiayTRisvJMMBwICCdBeEwUg;

		private static Func<Controller, Type, bool> ikhrDXjlMggKDxxInpwCLIzeGib;

		[CompilerGenerated]
		private static Func<Controller, Guid, bool> awpkufMDcpprqtGkXvItnJTqqFy;

		[CompilerGenerated]
		private static Func<Controller, Type, bool> doGELBXViVaXchtFTeIwBzQPojtT;

		internal bool wasPollingPrev => false;

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

		public IList<Button> Buttons => null;

		public Extension extension => null;

		public IList<ControllerElementIdentifier> ElementIdentifiers => null;

		public IList<ControllerElementIdentifier> ButtonElementIdentifiers => null;

		public IList<IControllerTemplate> Templates => null;

		public int templateCount => 0;

		internal static Func<Controller, Guid, bool> implementsTemplateDelegate_Guid => null;

		internal static Func<Controller, Type, bool> implementsTemplateDelegate_Type => null;

		internal event Action<bool> EnabledStateChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		internal Controller(int controllerId, InputSource inputSource, string name, string hardwareName, string hardwareIdentifier, ControllerType type, Guid hardwareTypeGuid, int buttonCount, bool[] isButtonPressureSensitive, HardwareButtonInfo[] hwButtonInfo, HardwareControllerMap_Game hardwareMap, Extension extension, ControllerDataUpdater dataUpdater)
		{
		}

		internal virtual void GSedYgCKRFxIwfwCFlpVIFrarDLC()
		{
		}

		public virtual Element GetElementById(int elementIdentifierId)
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

		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtons()
		{
			return null;
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtonsDown()
		{
			return null;
		}

		private bool doSBZEHCATPkNfDRbJxGjQhANKza(int P_0, out int P_1)
		{
			P_1 = default(int);
			return false;
		}

		private bool bOLAikJJnUEOQkEArbjZkHOWfmDC(int P_0, out int P_1)
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

		internal void RxYerZeLQmwxsOHZuXuVjkibMza(IControllerTemplate[] P_0)
		{
		}

		internal virtual void IdvXxslbVpgePKGcszHAudaDgmvT(UpdateLoopType P_0)
		{
		}

		internal virtual ButtonStateFlags CoJBRLIUZxiRSJOEmyhVodYitGkh(int P_0)
		{
			return default(ButtonStateFlags);
		}

		internal void EtZOwCLStwdylVOgcIZbiZhtlvB(Extension P_0)
		{
		}

		internal void SgYbMrtGoPAJnDGIUADIMGWbmlTb(Extension P_0)
		{
		}

		internal virtual void DcbUeIfyTfvTrRQxceAMfGCsJNs()
		{
		}

		internal virtual bool WCkUbKnZwdSTjaEPCIHcdGhehrxE(bool P_0)
		{
			return false;
		}

		internal virtual void waxdHdNHlDhxzkjqsWWmSQZfsNN(ControllerMap P_0)
		{
		}

		internal virtual void GwGsCBzrPvyJJTZjZfVGITmOBPf(ControllerMap P_0, ActionElementMap P_1)
		{
		}

		internal bool XeavhUxsbKQmsvcmVbbNECdrTQk(ActionElementMap P_0, int P_1, out float P_2, out bool P_3)
		{
			P_2 = default(float);
			P_3 = default(bool);
			return false;
		}

		internal bool XeavhUxsbKQmsvcmVbbNECdrTQk(ActionElementMap P_0, int P_1, bool P_2, out float P_3)
		{
			P_3 = default(float);
			return false;
		}

		internal void IKHRTuKkvFbvONMHJwmCBywAFGD(Element P_0)
		{
		}

		internal virtual Guid idkZxHGEbEFcRkaHmFvmSkvhZTv()
		{
			return default(Guid);
		}

		internal virtual void aYscBdBbWIIgUMQjVZygRDyLkhan(bool P_0)
		{
		}

		protected virtual void Connected()
		{
		}

		protected virtual void Disconnected()
		{
		}

		[CompilerGenerated]
		private static bool DOTFTBDoFEBYoNGDrnQyaSoGvHm(Controller P_0, Guid P_1)
		{
			return false;
		}

		[CompilerGenerated]
		private static bool lpfWCwzLvapuKEtXsBwyXgKOncW(Controller P_0, Type P_1)
		{
			return false;
		}
	}
}
