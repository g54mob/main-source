using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Data.Mapping;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerTemplate : IControllerTemplate
	{
		internal abstract class pEaruRhmCqoUTDRAuiwlLIVVrnr : IControllerTemplateElement, IControllerTemplateElement_Internal
		{
			private readonly IControllerTemplate cFEBywhZYxtgpybAYsIGoOnAlzo;

			private readonly int EPKCDchEYzXNdkVlXPBcLtJDQuC;

			private readonly string rxFXeRTtpDKAOGNDPEpHeMwItpAb;

			private readonly ControllerTemplateElementType JafvOZeUKqlluyTklnnzmjcQYBv;

			protected readonly int UmlfknJGLCaKwkBKLxTOQfvOngpe;

			public int id => 0;

			public string descriptiveName => null;

			public ControllerTemplateElementType type => default(ControllerTemplateElementType);

			public IControllerTemplate parent => null;

			public abstract int elementCount { get; }

			public abstract IControllerTemplateElementSource source { get; }

			public abstract bool exists { get; }

			protected pEaruRhmCqoUTDRAuiwlLIVVrnr(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType)
			{
			}

			public abstract IControllerTemplateElement GetElement(int index);

			public abstract int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list);
		}

		internal abstract class fJvEZCnkzZwgHiPWboAzrWkanTq : pEaruRhmCqoUTDRAuiwlLIVVrnr
		{
			protected readonly int cWtQsqqhQvAPrDHvAPupJDnWmboO;

			protected readonly YxkREjIZrmGCNpwlApNHlQHNjlq[] aNwvbUNrEZENIkyFWZrbwPrGklk;

			public override bool exists => false;

			protected fJvEZCnkzZwgHiPWboAzrWkanTq(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, IList<YxkREjIZrmGCNpwlApNHlQHNjlq> sourceElements)
				: base(null, 0, null, default(ControllerTemplateElementType))
			{
			}
		}

		internal abstract class tldklGuSFRMDNbsTKncmdEjtGaGf : fJvEZCnkzZwgHiPWboAzrWkanTq, IControllerTemplateElement, IControllerTemplateAxis, IControllerTemplateButton
		{
			private ZLAHcRAlswBmLISIGDdywYeRahfS GvxgeuaiJYpASZqIalyLGlPjDkPK;

			private string gNXtYwIGsXnWizrcyoTVsNFrrIK;

			private string kxFdrWxMIWBgxeJZrfasbjKIrlPm;

			public float floatValue => 0f;

			public float floatValuePrev => 0f;

			public bool boolValue => false;

			public bool boolValuePrev => false;

			string IControllerTemplateAxis.positiveDescriptiveName => null;

			string IControllerTemplateAxis.negativeDescriptiveName => null;

			float IControllerTemplateAxis.value => 0f;

			float IControllerTemplateAxis.valuePrev => 0f;

			IControllerTemplateAxisSource IControllerTemplateAxis.source => null;

			bool IControllerTemplateButton.value => false;

			bool IControllerTemplateButton.valuePrev => false;

			bool IControllerTemplateButton.justPressed => false;

			bool IControllerTemplateButton.justReleased => false;

			bool IControllerTemplateButton.justChangedState => false;

			float IControllerTemplateButton.pressure => 0f;

			float IControllerTemplateButton.pressurePrev => 0f;

			IControllerTemplateButtonSource IControllerTemplateButton.source => null;

			public override IControllerTemplateElementSource source => null;

			public override int elementCount => 0;

			public IControllerTemplateAxis AsAxis => null;

			public IControllerTemplateButton AsButton => null;

			protected tldklGuSFRMDNbsTKncmdEjtGaGf(IControllerTemplate parent, int id, string name, string positiveName, string negativeName, ControllerTemplateElementType elementType, ZLAHcRAlswBmLISIGDdywYeRahfS target, IList<YxkREjIZrmGCNpwlApNHlQHNjlq> sourceElements)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}

			private string PdqQzlWXxmNTDNtgwtrtCcNFQmj(AxisRange P_0)
			{
				return null;
			}

			string IControllerTemplateAxis.GetDescriptiveName(AxisRange P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in PdqQzlWXxmNTDNtgwtrtCcNFQmj
				return this.PdqQzlWXxmNTDNtgwtrtCcNFQmj(P_0);
			}

			public override IControllerTemplateElement GetElement(int index)
			{
				return null;
			}

			public override int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list)
			{
				return 0;
			}

			private static bool ZGtJzNYdDrybsAebCVAOmYdZKH(ControllerElementTarget P_0, IControllerElementTarget P_1)
			{
				return false;
			}
		}

		internal sealed class KdYnvDJsxWRRRZJjfvlGuBcHWLE : tldklGuSFRMDNbsTKncmdEjtGaGf
		{
			public KdYnvDJsxWRRRZJjfvlGuBcHWLE(IControllerTemplate parent, int id, string name, string positiveName, string negativeName, ZLAHcRAlswBmLISIGDdywYeRahfS target, IList<YxkREjIZrmGCNpwlApNHlQHNjlq> sourceElements)
				: base(null, 0, null, null, null, default(ControllerTemplateElementType), null, null)
			{
			}

			internal static KdYnvDJsxWRRRZJjfvlGuBcHWLE fuWutfUlgbGGiKrpTsnFlrLbgtHd(IControllerTemplate P_0)
			{
				return null;
			}
		}

		internal sealed class pdFiikWIHrAaQUqXultDzMRvZvW : tldklGuSFRMDNbsTKncmdEjtGaGf
		{
			public pdFiikWIHrAaQUqXultDzMRvZvW(IControllerTemplate parent, int id, string name, string positiveName, string negativeName, ZLAHcRAlswBmLISIGDdywYeRahfS target, IList<YxkREjIZrmGCNpwlApNHlQHNjlq> sourceElements)
				: base(null, 0, null, null, null, default(ControllerTemplateElementType), null, null)
			{
			}

			internal static pdFiikWIHrAaQUqXultDzMRvZvW fuWutfUlgbGGiKrpTsnFlrLbgtHd(IControllerTemplate P_0)
			{
				return null;
			}
		}

		internal abstract class JXVDSbqwYUjJLWXDgiUGDtZvAdM : pEaruRhmCqoUTDRAuiwlLIVVrnr
		{
			protected readonly int fbjGYJTKJighVvUdqovGMNGpSWg;

			protected readonly pEaruRhmCqoUTDRAuiwlLIVVrnr[] pLlTDQrAWXFGuEEXrnQNcxqsCoj;

			public override bool exists => false;

			public override IControllerTemplateElementSource source => null;

			public override int elementCount => 0;

			protected JXVDSbqwYUjJLWXDgiUGDtZvAdM(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, pEaruRhmCqoUTDRAuiwlLIVVrnr[] elements)
				: base(null, 0, null, default(ControllerTemplateElementType))
			{
			}

			public override IControllerTemplateElement GetElement(int P_0)
			{
				return null;
			}

			public override int GetElementTargets(ControllerElementTarget P_0, ref IList<ControllerTemplateElementTarget> P_1)
			{
				return 0;
			}
		}

		internal abstract class rAwkkLzPglgKskkjQzAMMlTWlawq : JXVDSbqwYUjJLWXDgiUGDtZvAdM, IControllerTemplateElement, IControllerTemplateAxis2D
		{
			protected const int FlSmNKekEzdXxSnZyYzZxmtrmfm = 0;

			protected const int uMRmegxMcCooYaqerlXJTXmFOHD = 1;

			protected const int BnollgJLSenhOVeLtEuqOyLSrnk = 2;

			public Vector2 value => default(Vector2);

			public Vector2 valuePrev => default(Vector2);

			public IControllerTemplateAxis horizontal => null;

			public IControllerTemplateAxis vertical => null;

			protected rAwkkLzPglgKskkjQzAMMlTWlawq(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, pEaruRhmCqoUTDRAuiwlLIVVrnr[] elements)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal abstract class lRoriyBTtDXCPBclSZqvvvdLXuV : JXVDSbqwYUjJLWXDgiUGDtZvAdM, IControllerTemplateElement, IControllerTemplateAxis3D
		{
			protected const int FlSmNKekEzdXxSnZyYzZxmtrmfm = 0;

			protected const int uMRmegxMcCooYaqerlXJTXmFOHD = 1;

			protected const int yagThEDhKbfsxhOnujKAiRDKtBL = 2;

			protected const int BnollgJLSenhOVeLtEuqOyLSrnk = 3;

			public Vector3 value => default(Vector3);

			public Vector3 valuePrev => default(Vector3);

			public IControllerTemplateAxis horizontal => null;

			public IControllerTemplateAxis vertical => null;

			public IControllerTemplateAxis depth => null;

			protected lRoriyBTtDXCPBclSZqvvvdLXuV(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, pEaruRhmCqoUTDRAuiwlLIVVrnr[] elements)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal abstract class JsYNmuoLUfoRVKCmfwoMrjqlVEJ : JXVDSbqwYUjJLWXDgiUGDtZvAdM, IControllerTemplateElement, IControllerTemplateAxis6D
		{
			protected const int lewETckauEwFNOoCPbxbqqqOcwHI = 0;

			protected const int mWnRPcLoRemewHAGtUZChWDzlsV = 1;

			protected const int VzBcPuhNQfGsieaTxsZidhyhuPpK = 2;

			protected const int sNDUuDjIUCBOUsMsePgdtnLgCzH = 3;

			protected const int PpkgvBqDGxGDrfSgsubNJZehdfCR = 4;

			protected const int NENamlNJMDZnwnZTsdyXPYBodDY = 5;

			protected const int BnollgJLSenhOVeLtEuqOyLSrnk = 6;

			public Vector3 position => default(Vector3);

			public Vector3 positionPrev => default(Vector3);

			public Vector3 rotation => default(Vector3);

			public Vector3 rotationPrev => default(Vector3);

			public IControllerTemplateAxis positionX => null;

			public IControllerTemplateAxis positionY => null;

			public IControllerTemplateAxis positionZ => null;

			public IControllerTemplateAxis rotationX => null;

			public IControllerTemplateAxis rotationY => null;

			public IControllerTemplateAxis rotationZ => null;

			protected JsYNmuoLUfoRVKCmfwoMrjqlVEJ(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, pEaruRhmCqoUTDRAuiwlLIVVrnr[] elements)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal sealed class DlUDyecjQLSHXjFLNRQQSQJotOE : lRoriyBTtDXCPBclSZqvvvdLXuV, IControllerTemplateElement, IControllerTemplateStick
		{
			private new const int BnollgJLSenhOVeLtEuqOyLSrnk = 3;

			public IControllerTemplateAxis rotation => null;

			private DlUDyecjQLSHXjFLNRQQSQJotOE(IControllerTemplate parent, int id, string name, pEaruRhmCqoUTDRAuiwlLIVVrnr[] elements)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}

			public DlUDyecjQLSHXjFLNRQQSQJotOE(IControllerTemplate parent, int id, string name, tldklGuSFRMDNbsTKncmdEjtGaGf xAxis, tldklGuSFRMDNbsTKncmdEjtGaGf yAxis, tldklGuSFRMDNbsTKncmdEjtGaGf zAxis)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal sealed class AsnLkESeYsjorCboyHsZIBuxzeho : rAwkkLzPglgKskkjQzAMMlTWlawq, IControllerTemplateElement, IControllerTemplateThumbStick
		{
			private const int XodHMVzmeHDFrhmZSbNFzBEdjmbW = 2;

			private new const int BnollgJLSenhOVeLtEuqOyLSrnk = 3;

			public IControllerTemplateButton press => null;

			private AsnLkESeYsjorCboyHsZIBuxzeho(IControllerTemplate parent, int id, string name, pEaruRhmCqoUTDRAuiwlLIVVrnr[] elements)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}

			internal AsnLkESeYsjorCboyHsZIBuxzeho(IControllerTemplate parent, int id, string name, tldklGuSFRMDNbsTKncmdEjtGaGf xAxis, tldklGuSFRMDNbsTKncmdEjtGaGf yAxis, tldklGuSFRMDNbsTKncmdEjtGaGf button)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal sealed class qZSeyJxBnpYlSWyRYjHMMYwUcQf : JXVDSbqwYUjJLWXDgiUGDtZvAdM, IControllerTemplateElement, IControllerTemplateDPad
		{
			private const int HpxYAGYBYPpBrtdVKzAjsGrlMKB = 0;

			private const int GyvpHOiecmkepbuqivMbbxxJPgg = 1;

			private const int ilzmNsGAbhyikvfHmxQjwuUeFZN = 2;

			private const int OINbXPNpcpxrudHFyAoHCWVouQb = 3;

			private const int eUkejSEHMtvQiMdedTPmodXuTarT = 4;

			private const int BnollgJLSenhOVeLtEuqOyLSrnk = 5;

			public Vector2 value => default(Vector2);

			public Vector2 valuePrev => default(Vector2);

			public IControllerTemplateButton up => null;

			public IControllerTemplateButton right => null;

			public IControllerTemplateButton down => null;

			public IControllerTemplateButton left => null;

			public IControllerTemplateButton press => null;

			private qZSeyJxBnpYlSWyRYjHMMYwUcQf(IControllerTemplate parent, int id, string name, pEaruRhmCqoUTDRAuiwlLIVVrnr[] elements)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}

			internal qZSeyJxBnpYlSWyRYjHMMYwUcQf(IControllerTemplate parent, int id, string name, tldklGuSFRMDNbsTKncmdEjtGaGf up, tldklGuSFRMDNbsTKncmdEjtGaGf right, tldklGuSFRMDNbsTKncmdEjtGaGf down, tldklGuSFRMDNbsTKncmdEjtGaGf left, tldklGuSFRMDNbsTKncmdEjtGaGf press)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal sealed class btwlgxcXcpCZfarmazSJXlWYnBZ : JXVDSbqwYUjJLWXDgiUGDtZvAdM, IControllerTemplateElement, IControllerTemplateThrottle
		{
			private const int eSBxIZkcopUrqYFEAJFVqvKXUPb = 0;

			private const int rHsHKWuRXlftYouAsAWGofHAJif = 1;

			private const int BnollgJLSenhOVeLtEuqOyLSrnk = 2;

			public float value => 0f;

			public float valuePrev => 0f;

			public IControllerTemplateAxis throttle => null;

			public IControllerTemplateButton minDetent => null;

			private btwlgxcXcpCZfarmazSJXlWYnBZ(IControllerTemplate parent, int id, string name, pEaruRhmCqoUTDRAuiwlLIVVrnr[] elements)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}

			internal btwlgxcXcpCZfarmazSJXlWYnBZ(IControllerTemplate parent, int id, string name, tldklGuSFRMDNbsTKncmdEjtGaGf axis, tldklGuSFRMDNbsTKncmdEjtGaGf zeroDetentButton)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal sealed class EAOjUfXiFPkRsDTRlAGwpOdHeJvJ : JXVDSbqwYUjJLWXDgiUGDtZvAdM, IControllerTemplateElement, IControllerTemplateHat
		{
			private const int HpxYAGYBYPpBrtdVKzAjsGrlMKB = 0;

			private const int pHXaRvGZZfzDElVPCtcjOETxMsY = 1;

			private const int GyvpHOiecmkepbuqivMbbxxJPgg = 2;

			private const int GrFeOYPSmrDrHEWPrFIUFagZWyXo = 3;

			private const int ilzmNsGAbhyikvfHmxQjwuUeFZN = 4;

			private const int UNVJQONHFDmpZmDGwZLWsURQUOZ = 5;

			private const int OINbXPNpcpxrudHFyAoHCWVouQb = 6;

			private const int nkitleTPhGDYWGJzcuKserGeClNe = 7;

			private const int BnollgJLSenhOVeLtEuqOyLSrnk = 8;

			public Vector2 value => default(Vector2);

			public Vector2 valuePrev => default(Vector2);

			public IControllerTemplateButton up => null;

			public IControllerTemplateButton upRight => null;

			public IControllerTemplateButton right => null;

			public IControllerTemplateButton downRight => null;

			public IControllerTemplateButton down => null;

			public IControllerTemplateButton downLeft => null;

			public IControllerTemplateButton left => null;

			public IControllerTemplateButton upLeft => null;

			private EAOjUfXiFPkRsDTRlAGwpOdHeJvJ(IControllerTemplate parent, int id, string name, pEaruRhmCqoUTDRAuiwlLIVVrnr[] elements)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}

			internal EAOjUfXiFPkRsDTRlAGwpOdHeJvJ(IControllerTemplate parent, int id, string name, tldklGuSFRMDNbsTKncmdEjtGaGf up, tldklGuSFRMDNbsTKncmdEjtGaGf upRight, tldklGuSFRMDNbsTKncmdEjtGaGf right, tldklGuSFRMDNbsTKncmdEjtGaGf downRight, tldklGuSFRMDNbsTKncmdEjtGaGf down, tldklGuSFRMDNbsTKncmdEjtGaGf downLeft, tldklGuSFRMDNbsTKncmdEjtGaGf left, tldklGuSFRMDNbsTKncmdEjtGaGf upLeft)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal sealed class KYPDaKKXqMpYzGvZQGpktLqDgHSO : rAwkkLzPglgKskkjQzAMMlTWlawq, IControllerTemplateElement, IControllerTemplateYoke
		{
			private new const int BnollgJLSenhOVeLtEuqOyLSrnk = 2;

			public IControllerTemplateAxis rotation => null;

			public IControllerTemplateAxis pushPull => null;

			private KYPDaKKXqMpYzGvZQGpktLqDgHSO(IControllerTemplate parent, int id, string name, pEaruRhmCqoUTDRAuiwlLIVVrnr[] elements)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}

			internal KYPDaKKXqMpYzGvZQGpktLqDgHSO(IControllerTemplate parent, int id, string name, tldklGuSFRMDNbsTKncmdEjtGaGf rollAxis, tldklGuSFRMDNbsTKncmdEjtGaGf pitchAxis)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal sealed class cEASnPjmtjfxlwnkWcGtHqAdcAR : JsYNmuoLUfoRVKCmfwoMrjqlVEJ, IControllerTemplateElement, IControllerTemplateStick6D
		{
			private new const int BnollgJLSenhOVeLtEuqOyLSrnk = 6;

			private cEASnPjmtjfxlwnkWcGtHqAdcAR(IControllerTemplate parent, int id, string name, pEaruRhmCqoUTDRAuiwlLIVVrnr[] elements)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}

			internal cEASnPjmtjfxlwnkWcGtHqAdcAR(IControllerTemplate parent, int id, string name, tldklGuSFRMDNbsTKncmdEjtGaGf positionX, tldklGuSFRMDNbsTKncmdEjtGaGf positionY, tldklGuSFRMDNbsTKncmdEjtGaGf positionZ, tldklGuSFRMDNbsTKncmdEjtGaGf rotationX, tldklGuSFRMDNbsTKncmdEjtGaGf rotationY, tldklGuSFRMDNbsTKncmdEjtGaGf rotationZ)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal class YxkREjIZrmGCNpwlApNHlQHNjlq
		{
			public readonly Controller.Element IZavTswMEmsoNdWDGOpiDSDmzfj;

			public readonly IControllerElementTarget QXkxRHWAIexUminBPlmsdpmAaXw;

			public bool boolValue => false;

			public bool boolValuePrev => false;

			public bool justPressed => false;

			public bool justReleased => false;

			public float floatValue => 0f;

			public float floatValuePrev => 0f;

			public YxkREjIZrmGCNpwlApNHlQHNjlq(IControllerElementTarget target, Controller.Element element)
			{
			}

			public static YxkREjIZrmGCNpwlApNHlQHNjlq fuWutfUlgbGGiKrpTsnFlrLbgtHd()
			{
				return null;
			}
		}

		internal class coaErhfffzOtdrMCSIlXbgvjldq
		{
			public readonly Controller ECcgIuoimNBCDpLQIYznCFyRYZx;

			public readonly IHardwareControllerTemplateMap_Internal NWAzMSEDocgqAxDQpbgDiEBMmDq;

			public coaErhfffzOtdrMCSIlXbgvjldq(Controller controller, IHardwareControllerTemplateMap_Internal templateMap)
			{
			}
		}

		private readonly string rxFXeRTtpDKAOGNDPEpHeMwItpAb;

		private readonly Guid UtUqjJmoPHNLpehnQIVHuavYmli;

		private readonly Controller mhFIKTSvWsXQmSRHbUBLDvRbbFX;

		private readonly ADictionary<int, IControllerTemplateElement> NtDjiIHtaopkAEzMYvaOIgtzrGu;

		private readonly ADictionary<string, IControllerTemplateElement> fmsyXxeJNJkPiAzmrWWGVSyuEEL;

		private IControllerTemplateElement[] pLlTDQrAWXFGuEEXrnQNcxqsCoj;

		private ReadOnlyCollection<IControllerTemplateElement> PYkIGFSdEsaiQkqDwqcwfwgkkJAH;

		private readonly int UmlfknJGLCaKwkBKLxTOQfvOngpe;

		Controller IControllerTemplate.controller => null;

		string IControllerTemplate.name => null;

		Guid IControllerTemplate.typeGuid => default(Guid);

		IList<IControllerTemplateElement> IControllerTemplate.elements => null;

		int IControllerTemplate.elementCount => 0;

		protected ControllerTemplate(object payload)
		{
		}

		private ControllerTemplate(coaErhfffzOtdrMCSIlXbgvjldq initializer)
		{
		}

		protected IControllerTemplateElement GetElement(int id)
		{
			return null;
		}

		protected T GetElement<T>(int id) where T : class, IControllerTemplateElement
		{
			return null;
		}

		private IControllerTemplateElement uguKxKioKLJetxEIzUjtTnZckCh(int P_0)
		{
			return null;
		}

		IControllerTemplateElement IControllerTemplate.GetElement(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in uguKxKioKLJetxEIzUjtTnZckCh
			return this.uguKxKioKLJetxEIzUjtTnZckCh(P_0);
		}

		private T uguKxKioKLJetxEIzUjtTnZckCh<T>(int P_0) where T : class, IControllerTemplateElement
		{
			return null;
		}

		T IControllerTemplate.GetElement<T>(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in uguKxKioKLJetxEIzUjtTnZckCh
			return this.uguKxKioKLJetxEIzUjtTnZckCh<T>(P_0);
		}

		private int dBMGrEaIBlYUAJOWEvImxtHCPFh(ControllerElementTarget P_0, IList<ControllerTemplateElementTarget> P_1)
		{
			return 0;
		}

		int IControllerTemplate.GetElementTargets(ControllerElementTarget P_0, IList<ControllerTemplateElementTarget> P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in dBMGrEaIBlYUAJOWEvImxtHCPFh
			return this.dBMGrEaIBlYUAJOWEvImxtHCPFh(P_0, P_1);
		}

		private int bJMdMppqrcIvmSffTKlkBUmKjJK(ControllerElementTarget P_0, ref IList<ControllerTemplateElementTarget> P_1)
		{
			return 0;
		}

		[CustomObfuscation]
		internal static Type GetInterfaceType(ControllerTemplateElementType elementType)
		{
			return null;
		}

		private static IList<YxkREjIZrmGCNpwlApNHlQHNjlq> EdhXlHRsRzsODWiuEjhLQndRqec(Controller P_0, IControllerTemplateAxisSource P_1)
		{
			return null;
		}

		private static IList<YxkREjIZrmGCNpwlApNHlQHNjlq> EdhXlHRsRzsODWiuEjhLQndRqec(Controller P_0, IControllerTemplateButtonSource P_1)
		{
			return null;
		}

		private static IList<YxkREjIZrmGCNpwlApNHlQHNjlq> EdhXlHRsRzsODWiuEjhLQndRqec(Controller P_0, IControllerElementTarget P_1)
		{
			return null;
		}

		private static IControllerTemplateElement oJknvKYthIOJiyqezQZKobWmKDs(List<IControllerTemplateElement> P_0, int P_1)
		{
			return null;
		}

		private static tldklGuSFRMDNbsTKncmdEjtGaGf ZGDtvdapJCHNoNyWbYHWqAIVjjL(IControllerTemplate P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			return null;
		}

		private static tldklGuSFRMDNbsTKncmdEjtGaGf gsAhqingKHCQFSIANnlItARObBeF(IControllerTemplate P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			return null;
		}
	}
}
