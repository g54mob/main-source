using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Data.Mapping;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerTemplate : IControllerTemplate, IControllerTemplate_Internal, gDrCmzJNXwFvGTMAYKGQspUqeYD
	{
		internal abstract class YYjpTGeypKuHJYOzvnyAyPmfPEfn : IControllerTemplateElement, IControllerTemplateElement_Internal
		{
			private readonly IControllerTemplate xoSKWyOmGVNSnjJyGWfcYAFBMmFE;

			private readonly int ownGHACqwvxNwHvAuLOwFmUBjdkJA;

			private readonly ControllerTemplateElementType moCjHoajcfWZtooEZBDATqbrDsLK;

			protected readonly int hIYycpNuKVkvtikiONVlQOlOKoCf;

			protected readonly OoMOZEqfXndBIZKQcgmHDZDrhUwEA sEMyzuaAuQpccCtjGjlGOvSmQHOc;

			public int id => 0;

			public string descriptiveName => null;

			internal string kzwCANoFYBabwkDtKjaBIldKJbFt => null;

			public ControllerTemplateElementType type => default(ControllerTemplateElementType);

			public IControllerTemplate parent => null;

			public abstract int elementCount { get; }

			public abstract IControllerTemplateElementSource source { get; }

			public abstract bool exists { get; }

			protected YYjpTGeypKuHJYOzvnyAyPmfPEfn(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, OoMOZEqfXndBIZKQcgmHDZDrhUwEA P_3)
			{
			}

			public abstract IControllerTemplateElement GetElement(int index);

			public abstract int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list);

			protected static OoMOZEqfXndBIZKQcgmHDZDrhUwEA exOEPwnVAxgSUKBEuruZmkNQdAsYA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3)
			{
				return null;
			}
		}

		internal abstract class SToemRBqEpnrLmpbqrYWRGTIPeeBb : YYjpTGeypKuHJYOzvnyAyPmfPEfn
		{
			protected readonly int dPyyaYjKmzpTwmEREVFnsctPStqR;

			protected readonly hutPhcBnEQdPRoJEXCJgCtixxCeM[] UOQeuUVYPsJuDFKtpgRxFdrqspnd;

			public override bool exists => false;

			protected SToemRBqEpnrLmpbqrYWRGTIPeeBb(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, IList<hutPhcBnEQdPRoJEXCJgCtixxCeM> P_3, OoMOZEqfXndBIZKQcgmHDZDrhUwEA P_4)
				: base(null, 0, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal abstract class AbuLYXhDofdMHjmwNPaBwEYJNRUkA : SToemRBqEpnrLmpbqrYWRGTIPeeBb, IControllerTemplateAxis, IControllerTemplateElement, IControllerTemplateButton
		{
			private eyXePMBLHAVdDBzdXMjLzHNfDAjcA WosvwaRCMdNAgEBVTnTXalbPrCUx;

			public float YFxIVraKdXlHlZAlXSoEOkhepJMx => 0f;

			public float IItEwoimcLCNkHpdpTYxCbYZcKbGb => 0f;

			public bool uCirRUroEYvltGQwDzoHWrrBJvGI => false;

			public bool NuLsFEmTiFQynVloIxkZjHaKODav => false;

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

			protected OiaFmiQUHWOGZzaOlpbuggwRuWBd qqxtFcWsOBtBfVnzRoTCqGJSFrTf => null;

			protected AbuLYXhDofdMHjmwNPaBwEYJNRUkA(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, eyXePMBLHAVdDBzdXMjLzHNfDAjcA P_3, IList<hutPhcBnEQdPRoJEXCJgCtixxCeM> P_4, OiaFmiQUHWOGZzaOlpbuggwRuWBd P_5)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}

			string IControllerTemplateAxis.GetDescriptiveName(AxisRange axisRange)
			{
				return null;
			}

			public override IControllerTemplateElement GetElement(int index)
			{
				return null;
			}

			public override int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list)
			{
				return 0;
			}

			private static bool LipwXryGIZJdcIszNBiHVMUZFvPDA(ControllerElementTarget P_0, IControllerElementTarget P_1)
			{
				return false;
			}
		}

		internal sealed class vyUuyGVoBSHRAeomrSKtoxAdqJC : AbuLYXhDofdMHjmwNPaBwEYJNRUkA
		{
			public vyUuyGVoBSHRAeomrSKtoxAdqJC(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, string P_4, string P_5, string P_6, string P_7, eyXePMBLHAVdDBzdXMjLzHNfDAjcA P_8, IList<hutPhcBnEQdPRoJEXCJgCtixxCeM> P_9)
				: base(null, 0, default(ControllerTemplateElementType), null, null, null)
			{
			}

			internal static vyUuyGVoBSHRAeomrSKtoxAdqJC kBqrzRiVlVLxekJwbdIPmLPZtUDA(IControllerTemplate_Internal P_0)
			{
				return null;
			}
		}

		internal sealed class WSWBqdXhsJebMVCilWvuKFuXCKMAA : AbuLYXhDofdMHjmwNPaBwEYJNRUkA
		{
			public WSWBqdXhsJebMVCilWvuKFuXCKMAA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, string P_4, string P_5, string P_6, string P_7, eyXePMBLHAVdDBzdXMjLzHNfDAjcA P_8, IList<hutPhcBnEQdPRoJEXCJgCtixxCeM> P_9)
				: base(null, 0, default(ControllerTemplateElementType), null, null, null)
			{
			}

			internal static WSWBqdXhsJebMVCilWvuKFuXCKMAA JezrnTUUJQotMkMMdixlBvVtesvo(IControllerTemplate_Internal P_0)
			{
				return null;
			}
		}

		internal abstract class wNKivkbIlmRMTVMgvDSrylsFkKGS : YYjpTGeypKuHJYOzvnyAyPmfPEfn
		{
			protected readonly int LceoRiCDpblCcFhvCVlSwEvtAhOiA;

			protected readonly YYjpTGeypKuHJYOzvnyAyPmfPEfn[] JcpwrGaoIHLqoZNdwXdGWaSfvilM;

			public override bool exists => false;

			public override IControllerTemplateElementSource source => null;

			public override int elementCount => 0;

			protected wNKivkbIlmRMTVMgvDSrylsFkKGS(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, YYjpTGeypKuHJYOzvnyAyPmfPEfn[] P_3, OoMOZEqfXndBIZKQcgmHDZDrhUwEA P_4)
				: base(null, 0, default(ControllerTemplateElementType), null)
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

		internal abstract class OWhgNEkCVNxNyvxERsCrYKgigVwW : wNKivkbIlmRMTVMgvDSrylsFkKGS, IControllerTemplateAxis2D, IControllerTemplateElement
		{
			protected const int YohiGVESxyTYIzkYvKOAriEKnfgr = 0;

			protected const int nRDdKJGzBSuGNAjDibhKIfDijhCSb = 1;

			protected const int UaEXJZgSCIIitoCARVLmRZyYiVGJ = 2;

			public Vector2 value => default(Vector2);

			public Vector2 valuePrev => default(Vector2);

			public IControllerTemplateAxis horizontal => null;

			public IControllerTemplateAxis vertical => null;

			protected OWhgNEkCVNxNyvxERsCrYKgigVwW(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, YYjpTGeypKuHJYOzvnyAyPmfPEfn[] P_3, OoMOZEqfXndBIZKQcgmHDZDrhUwEA P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal abstract class SoxKdmIuAhUJVMNePTaIUkAdwrNm : wNKivkbIlmRMTVMgvDSrylsFkKGS, IControllerTemplateAxis3D, IControllerTemplateElement
		{
			protected const int VEqHlmcBzXGasazBzUWigllhKxmrB = 0;

			protected const int xMMPyKAOkJnTGYVjPFxuMLSQdtDP = 1;

			protected const int TJybHcSzQiJbHxfDMrrhMmSBFEmB = 2;

			protected const int GnEVxFarQSSSdoWffcTMbBmZmEjt = 3;

			public Vector3 value => default(Vector3);

			public Vector3 valuePrev => default(Vector3);

			public IControllerTemplateAxis horizontal => null;

			public IControllerTemplateAxis vertical => null;

			public IControllerTemplateAxis depth => null;

			protected SoxKdmIuAhUJVMNePTaIUkAdwrNm(IControllerTemplate_Internal P_0, int P_1, ControllerTemplateElementType P_2, YYjpTGeypKuHJYOzvnyAyPmfPEfn[] P_3, OoMOZEqfXndBIZKQcgmHDZDrhUwEA P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal abstract class uHPsBjnKfTjCTALFwWotfAPBIlLpA : wNKivkbIlmRMTVMgvDSrylsFkKGS, IControllerTemplateAxis6D, IControllerTemplateElement
		{
			protected const int juKcYJbhhdIDTrhraqDBxhkFmqCz = 0;

			protected const int IFCCTeHooeJLuQaQdBlSQtEavMlH = 1;

			protected const int uBDxZizeaJUlvYqsEBFDwgaYtoN = 2;

			protected const int BrHakFyvSDNVjsNMafxJBSFlRWqT = 3;

			protected const int KwZgLwhZYYQslUQJXYhnoVjjLMDVA = 4;

			protected const int DAuyokEiDrlXIZjAtUxtdoitckvg = 5;

			protected const int rRLrqLHUCDWeDDwLtzzaxOJRfHCF = 6;

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

			protected uHPsBjnKfTjCTALFwWotfAPBIlLpA(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, YYjpTGeypKuHJYOzvnyAyPmfPEfn[] P_3, OoMOZEqfXndBIZKQcgmHDZDrhUwEA P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal sealed class kUPqUxzOtjXnFackMZynboOUUfOC : SoxKdmIuAhUJVMNePTaIUkAdwrNm, IControllerTemplateStick, IControllerTemplateElement
		{
			private const int VwEHvCtDYOzoAmarHDJXjftJuXJe = 3;

			public IControllerTemplateAxis rotation => null;

			private kUPqUxzOtjXnFackMZynboOUUfOC(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, YYjpTGeypKuHJYOzvnyAyPmfPEfn[] P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}

			public kUPqUxzOtjXnFackMZynboOUUfOC(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_4, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_5, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_6)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal sealed class lmsmNZTPnWFlvDONrYsywnZRaPrgA : OWhgNEkCVNxNyvxERsCrYKgigVwW, IControllerTemplateThumbStick, IControllerTemplateElement
		{
			private const int CiFKOFKFhoZaWevHyBeAnmqqhxVg = 2;

			private const int WKxPISgOukknuiCWfmApcktXQYvJ = 3;

			public IControllerTemplateButton press => null;

			private lmsmNZTPnWFlvDONrYsywnZRaPrgA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, YYjpTGeypKuHJYOzvnyAyPmfPEfn[] P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}

			internal lmsmNZTPnWFlvDONrYsywnZRaPrgA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_4, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_5, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_6)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal sealed class ZpXhLSqRATskOTKsBaFdngDouhnV : wNKivkbIlmRMTVMgvDSrylsFkKGS, IControllerTemplateDPad, IControllerTemplateElement
		{
			private const int yBllZYuPkFdErDbIXEDfLQDqmFdH = 0;

			private const int kXGyQekfuiXovxBqVVRDlByrLIQm = 1;

			private const int YuQvZmzdruXdagVFyrSjcogXrPsO = 2;

			private const int TMndgPRQEMFlcjldDIgXSstayBGNA = 3;

			private const int ghgjUCzqJjGXNbeEdzlrUqSadFqcA = 4;

			private const int hgOWNUiQHwjiHQYljbttEJWvMTlA = 5;

			public Vector2 value => default(Vector2);

			public Vector2 valuePrev => default(Vector2);

			public IControllerTemplateButton up => null;

			public IControllerTemplateButton right => null;

			public IControllerTemplateButton down => null;

			public IControllerTemplateButton left => null;

			public IControllerTemplateButton press => null;

			private ZpXhLSqRATskOTKsBaFdngDouhnV(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, YYjpTGeypKuHJYOzvnyAyPmfPEfn[] P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}

			internal ZpXhLSqRATskOTKsBaFdngDouhnV(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_4, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_5, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_6, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_7, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_8)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal sealed class KnfOkvlczPRfNxOtnvkXkECsONtb : wNKivkbIlmRMTVMgvDSrylsFkKGS, IControllerTemplateThrottle, IControllerTemplateElement
		{
			private const int iGerMrroqREjtmGgmRyXxcgoTFjp = 0;

			private const int scNdIJkGEKEdSdxwaaXsYoSSTYyob = 1;

			private const int mQXynccjpxZRAwoOQytGVkIdHPsHA = 2;

			public float value => 0f;

			public float valuePrev => 0f;

			public IControllerTemplateAxis throttle => null;

			public IControllerTemplateButton minDetent => null;

			private KnfOkvlczPRfNxOtnvkXkECsONtb(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, YYjpTGeypKuHJYOzvnyAyPmfPEfn[] P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}

			internal KnfOkvlczPRfNxOtnvkXkECsONtb(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_4, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_5)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal sealed class voVUXmEisrbEaWnsoIIHCkGxFszdA : wNKivkbIlmRMTVMgvDSrylsFkKGS, IControllerTemplateHat, IControllerTemplateElement
		{
			private const int bWsVNmhKBZzAkfmdpDLjbdbUtuJz = 0;

			private const int TDTBhpgWxqCOlCLpSiECxicuYRbKA = 1;

			private const int XeRzBtyLRGOATXUNLDgQswbesdqu = 2;

			private const int MZlDmBCBfyeTwfLxMWjXTURNXEby = 3;

			private const int gawpnuZdWxVgJfWzsrLQuQosCmDW = 4;

			private const int YpbeaUftLGEhTBrXdCwFNlMoFLprB = 5;

			private const int KRSWzbWaPSveKynBsubvqVDqFwsT = 6;

			private const int bYilYDcqdMvXjlBarCLLEAqpkJSzA = 7;

			private const int QpksGsTDQCcwNnGHAeIaGLekMpjV = 8;

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

			private voVUXmEisrbEaWnsoIIHCkGxFszdA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, YYjpTGeypKuHJYOzvnyAyPmfPEfn[] P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}

			internal voVUXmEisrbEaWnsoIIHCkGxFszdA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_4, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_5, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_6, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_7, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_8, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_9, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_10, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_11)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal sealed class fEGFNXFAXiGFbCeeARfFRqRRviEFB : OWhgNEkCVNxNyvxERsCrYKgigVwW, IControllerTemplateYoke, IControllerTemplateElement
		{
			private const int mATnqsKebKcySgSAmhJScojfTxIbb = 2;

			public IControllerTemplateAxis rotation => null;

			public IControllerTemplateAxis pushPull => null;

			private fEGFNXFAXiGFbCeeARfFRqRRviEFB(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, YYjpTGeypKuHJYOzvnyAyPmfPEfn[] P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}

			internal fEGFNXFAXiGFbCeeARfFRqRRviEFB(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_4, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_5)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal sealed class FIVvIWuLGHuDfjmPDeGCalxLDFZh : uHPsBjnKfTjCTALFwWotfAPBIlLpA, IControllerTemplateStick6D, IControllerTemplateElement
		{
			private const int ACpgSWnGERuCYseLjidTfPzLqxhL = 6;

			private FIVvIWuLGHuDfjmPDeGCalxLDFZh(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, YYjpTGeypKuHJYOzvnyAyPmfPEfn[] P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}

			internal FIVvIWuLGHuDfjmPDeGCalxLDFZh(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_4, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_5, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_6, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_7, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_8, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_9)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal class hutPhcBnEQdPRoJEXCJgCtixxCeM
		{
			public readonly Controller.Element qvamzwhoWxtDxCBmROcRJoqSsdpc;

			public readonly IControllerElementTarget hERAAbAwSLlkzwNuDGeKwOhDkNebb;

			public bool tWWBIKWnxksDofQfZDGTIQDaEXjCb => false;

			public bool nthTXFeOzKIoOMYVpOYjIEWKUOtP => false;

			public bool IQKyhEaErJtbbCCBYSrGzpWvnNfF => false;

			public bool dFNtsWKDbuZolWNvThlfOoDpOdUx => false;

			public float tCcIrTkDIrtEqIhdHwhlUEYwljHAb => 0f;

			public float FfsbKslVKHQpWWvuQfRgEYvtxRrg => 0f;

			public hutPhcBnEQdPRoJEXCJgCtixxCeM(IControllerElementTarget P_0, Controller.Element P_1)
			{
			}

			public static hutPhcBnEQdPRoJEXCJgCtixxCeM QmKEQTghVEFKPhcUiKOuSqSYZBvuA()
			{
				return null;
			}
		}

		internal class BkhfCqorSBgitkHzZknmENKJVMyO
		{
			public readonly Controller RbVpLWZwRaQJcKqzqNdBQcUszuSR;

			public readonly IHardwareControllerTemplateMap_Internal iOcFxMKRTzzQhmvuuuNEXBDDbUON;

			public BkhfCqorSBgitkHzZknmENKJVMyO(Controller P_0, IHardwareControllerTemplateMap_Internal P_1)
			{
			}
		}

		private sealed class ovuqbdJtztpjNNJlEglfEcWUcsC
		{
			[Serializable]
			private sealed class uORBWTDZluVJcZFPCsyJOkpBdzYU
			{
				public static readonly uORBWTDZluVJcZFPCsyJOkpBdzYU _003C_003E9;

				public static Func<OoMOZEqfXndBIZKQcgmHDZDrhUwEA, OoMOZEqfXndBIZKQcgmHDZDrhUwEA, bool> _003C_003E9__4_0;

				internal bool SqUIRkvIkIxjawMsCUbtrmpRerpv(OoMOZEqfXndBIZKQcgmHDZDrhUwEA P_0, OoMOZEqfXndBIZKQcgmHDZDrhUwEA P_1)
				{
					return false;
				}
			}

			private static ovuqbdJtztpjNNJlEglfEcWUcsC sEAIFPgUtMxEYhQUfzWSHRqJDUmK;

			private readonly global::CWEsnVafmhdWXWfXjHVMLtdvyjyd<OoMOZEqfXndBIZKQcgmHDZDrhUwEA> vAvTHoWTGNNbChNZFZwvAMNKDObk;

			private static ovuqbdJtztpjNNJlEglfEcWUcsC yKShfRLGMoeNRNWbIhabjTGgDtfYA => null;

			private ovuqbdJtztpjNNJlEglfEcWUcsC()
			{
			}

			private void ZDutBEcLTRhcJNEPOBzgbhHFaHHu()
			{
			}

			private void kybubairgZIunMxUchhtCoUVvvtuA()
			{
			}

			public static OoMOZEqfXndBIZKQcgmHDZDrhUwEA OBPUvPZMoEiEURFsAXgmYYvnPZDt(OoMOZEqfXndBIZKQcgmHDZDrhUwEA P_0)
			{
				return null;
			}

			public static bool SIFxLOzNekFaeINNwvOjMBTiAduD(OoMOZEqfXndBIZKQcgmHDZDrhUwEA P_0, out OoMOZEqfXndBIZKQcgmHDZDrhUwEA P_1)
			{
				P_1 = null;
				return false;
			}

			public static void eyJlrKOYbRfenEFGQBGjDyreaaFoA(OoMOZEqfXndBIZKQcgmHDZDrhUwEA P_0)
			{
			}
		}

		private const string pKhNHsBrPEuTGkoURdHsNDcvyVcP = "controller/template";

		private string LdbzREMxGWdWuUmWlZxMUjsafXrE;

		private string BnUkwagPHIbGpuwqZmQySadKMPYK;

		private int ueaYLYYcddJVtaIFpfYBwJSZNGZP;

		private readonly Guid vzWLkqlUqFueQAdIxcieKDcaZqdiA;

		private readonly DeviceLocalizationInfo qwxPWQjoyVFTcNqlHvneUUpRFSiU;

		private readonly Controller bZAKwebGxGaRHhghQDaBNzKkIbEe;

		private readonly ADictionary<int, IControllerTemplateElement> TJzEJIeBVLSRtDSFMHNFmRtGTBKS;

		private readonly ADictionary<string, IControllerTemplateElement> acAAgIfkBzZaehkbDWDkUqaXDalo;

		private IControllerTemplateElement[] rbKnwFUuPijnSUlTJRLndGRZhENB;

		private ReadOnlyCollection<IControllerTemplateElement> HIYHBWpOgZNgrvdojAgGZzHJgZJS;

		private readonly zepspERRxafWKJaGpLXDAMQMfvgE HiooMURUXusXWrCAbtDGtszwpOpK;

		private readonly int UgWhYoisePaOdKLfjQrWSGozPQst;

		internal DeviceLocalizationInfo IGrBRytIswzcwcZGkfDKptkiOAXb => null;

		DeviceLocalizationInfo IControllerTemplate_Internal.deviceLocalizationInfo => null;

		Controller IControllerTemplate.controller => null;

		string IControllerTemplate.name => null;

		Guid IControllerTemplate.typeGuid => default(Guid);

		IList<IControllerTemplateElement> IControllerTemplate.elements => null;

		int IControllerTemplate.elementCount => 0;

		string gDrCmzJNXwFvGTMAYKGQspUqeYD.keyCategory => null;

		string gDrCmzJNXwFvGTMAYKGQspUqeYD.scriptingName => null;

		string gDrCmzJNXwFvGTMAYKGQspUqeYD.nonLocalizedDescriptiveName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		string gDrCmzJNXwFvGTMAYKGQspUqeYD.key => null;

		int gDrCmzJNXwFvGTMAYKGQspUqeYD.autoGeneratedValueFlags
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected ControllerTemplate(object P_0)
		{
		}

		private ControllerTemplate(BkhfCqorSBgitkHzZknmENKJVMyO P_0)
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

		IControllerTemplateElement IControllerTemplate.GetElement(int id)
		{
			return null;
		}

		T IControllerTemplate.GetElement<T>(int id)
		{
			return null;
		}

		int IControllerTemplate.GetElementTargets(ControllerElementTarget find, IList<ControllerTemplateElementTarget> results)
		{
			return 0;
		}

		private int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> results)
		{
			return 0;
		}

		[CustomObfuscation(rename = false)]
		internal static Type GetInterfaceType(ControllerTemplateElementType elementType)
		{
			return null;
		}

		private static IList<hutPhcBnEQdPRoJEXCJgCtixxCeM> ZHtyJRqXejMduXZcwblElSRqsAPl(Controller P_0, IControllerTemplateAxisSource P_1)
		{
			return null;
		}

		private static IList<hutPhcBnEQdPRoJEXCJgCtixxCeM> UvrfogArdwitUXSxZOfZgydHEXhA(Controller P_0, IControllerTemplateButtonSource P_1)
		{
			return null;
		}

		private static IList<hutPhcBnEQdPRoJEXCJgCtixxCeM> hqIsULBeeCaBfZOUVbFEHBTrbUkhA(Controller P_0, IControllerElementTarget P_1)
		{
			return null;
		}

		private static IControllerTemplateElement EpxxYqToLEaAydMbTIIMDKOupnFzA(List<IControllerTemplateElement> P_0, int P_1)
		{
			return null;
		}

		private static AbuLYXhDofdMHjmwNPaBwEYJNRUkA yRFXhPIOMmcVkkkpRCyUSQEEEtjh(IControllerTemplate_Internal P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			return null;
		}

		private static AbuLYXhDofdMHjmwNPaBwEYJNRUkA OSdDCvuYcKqvcgWpDprvEmdyFbGCA(IControllerTemplate_Internal P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			return null;
		}
	}
}
