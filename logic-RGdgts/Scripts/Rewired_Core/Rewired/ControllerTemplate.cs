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
		internal abstract class gwBXOpXdcaPCdFtopfeMjzVrGimI : IControllerTemplateElement, IControllerTemplateElement_Internal
		{
			private readonly IControllerTemplate rBdHDCfDobOjBUqyNbBnmEluxEvZ;

			private readonly int HZrDwOTOuvYGJkZRWDMDnUPlFNTs;

			private readonly string gbaFwplwRPDIuUufIuWmknaoIHDK;

			private readonly ControllerTemplateElementType OkGTKhIUqsJqQkbQwDsMbAsaAzwbb;

			protected readonly int TcEXPUvjqSTMTFutCAtGRnMeNwub;

			public int id => 0;

			public string descriptiveName => null;

			public ControllerTemplateElementType type => default(ControllerTemplateElementType);

			public IControllerTemplate parent => null;

			public abstract int elementCount { get; }

			public abstract IControllerTemplateElementSource source { get; }

			public abstract bool exists { get; }

			protected gwBXOpXdcaPCdFtopfeMjzVrGimI(IControllerTemplate P_0, int P_1, string P_2, ControllerTemplateElementType P_3)
			{
			}

			public abstract IControllerTemplateElement GetElement(int index);

			public abstract int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list);
		}

		internal abstract class gZQbaqXWBHQndqPaoQZUBUoAmoxT : gwBXOpXdcaPCdFtopfeMjzVrGimI
		{
			protected readonly int taSVMYSBmrCPVFcLRxCMvdtobAfp;

			protected readonly PbLhtDmFPsNazvYLFQBoFqNdAtlL[] pKVjEFfzRXWJtssGHjQAMvVcQJso;

			public override bool exists => false;

			protected gZQbaqXWBHQndqPaoQZUBUoAmoxT(IControllerTemplate P_0, int P_1, string P_2, ControllerTemplateElementType P_3, IList<PbLhtDmFPsNazvYLFQBoFqNdAtlL> P_4)
				: base(null, 0, null, default(ControllerTemplateElementType))
			{
			}
		}

		internal abstract class sNACywUzLRIlnfbDvzRcJlkFTFTb : gZQbaqXWBHQndqPaoQZUBUoAmoxT, IControllerTemplateElement, IControllerTemplateButton, IControllerTemplateAxis
		{
			private KpZHreySesbtLKuRdoZrwgpLSyTA BzUaLEMAzIdLahimlKbygLBhWDUxA;

			private string rEqjlYclMBTuGfiSdYagSTFLfkRH;

			private string fhiGKycLeSGfBCPbjipFXJOZQGAXA;

			public float esvdQDSeoVapiVBnSLWqsHImVLWA => 0f;

			public float sLALWRKTLxJotpSszSIhCrXmtbUF => 0f;

			public bool oWEdkgpANxjhVOIcAcKXObeBlSuU => false;

			public bool mjwdDosldubIUAhRxvRGpnamBQgm => false;

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

			protected sNACywUzLRIlnfbDvzRcJlkFTFTb(IControllerTemplate P_0, int P_1, string P_2, string P_3, string P_4, ControllerTemplateElementType P_5, KpZHreySesbtLKuRdoZrwgpLSyTA P_6, IList<PbLhtDmFPsNazvYLFQBoFqNdAtlL> P_7)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
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

			private static bool UcxGIJfLBVbsDJsSkLTzUiQTJiEVA(ControllerElementTarget P_0, IControllerElementTarget P_1)
			{
				return false;
			}
		}

		internal sealed class ZLOgUXjjWrIpfPEbmgeGsxJWJjEy : sNACywUzLRIlnfbDvzRcJlkFTFTb
		{
			public ZLOgUXjjWrIpfPEbmgeGsxJWJjEy(IControllerTemplate P_0, int P_1, string P_2, string P_3, string P_4, KpZHreySesbtLKuRdoZrwgpLSyTA P_5, IList<PbLhtDmFPsNazvYLFQBoFqNdAtlL> P_6)
				: base(null, 0, null, null, null, default(ControllerTemplateElementType), null, null)
			{
			}

			internal static ZLOgUXjjWrIpfPEbmgeGsxJWJjEy ckrUQVcMUnHdCWgDQIywBRRTSKOn(IControllerTemplate P_0)
			{
				return null;
			}
		}

		internal sealed class yzeaXMAenzWpurIfbwmsEFPXmIPUA : sNACywUzLRIlnfbDvzRcJlkFTFTb
		{
			public yzeaXMAenzWpurIfbwmsEFPXmIPUA(IControllerTemplate P_0, int P_1, string P_2, string P_3, string P_4, KpZHreySesbtLKuRdoZrwgpLSyTA P_5, IList<PbLhtDmFPsNazvYLFQBoFqNdAtlL> P_6)
				: base(null, 0, null, null, null, default(ControllerTemplateElementType), null, null)
			{
			}

			internal static yzeaXMAenzWpurIfbwmsEFPXmIPUA ckrUQVcMUnHdCWgDQIywBRRTSKOn(IControllerTemplate P_0)
			{
				return null;
			}
		}

		internal abstract class iqvTAvaOEKbSYfnUTtlbTFLCZR : gwBXOpXdcaPCdFtopfeMjzVrGimI
		{
			protected readonly int kiYHfahFeDPjHhkmohjSmWVgsjLv;

			protected readonly gwBXOpXdcaPCdFtopfeMjzVrGimI[] aUQWeyXieBvNOUAjqzTkUKmMbRkq;

			public override bool exists => false;

			public override IControllerTemplateElementSource source => null;

			public override int elementCount => 0;

			protected iqvTAvaOEKbSYfnUTtlbTFLCZR(IControllerTemplate P_0, int P_1, string P_2, ControllerTemplateElementType P_3, gwBXOpXdcaPCdFtopfeMjzVrGimI[] P_4)
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

		internal abstract class esTNGvLAqbTZOoFAXRFbFhJiHsnI : iqvTAvaOEKbSYfnUTtlbTFLCZR, IControllerTemplateElement, IControllerTemplateAxis2D
		{
			protected const int KvzFBvQNWpBwtfGBziXAIZsXdPqpA = 0;

			protected const int beoJeCBfCSvBoiqEuUIgxEmrofGJ = 1;

			protected const int YWRtWKbIgqRwyNetoDlDhiZglSfoA = 2;

			public Vector2 value => default(Vector2);

			public Vector2 valuePrev => default(Vector2);

			public IControllerTemplateAxis horizontal => null;

			public IControllerTemplateAxis vertical => null;

			protected esTNGvLAqbTZOoFAXRFbFhJiHsnI(IControllerTemplate P_0, int P_1, string P_2, ControllerTemplateElementType P_3, gwBXOpXdcaPCdFtopfeMjzVrGimI[] P_4)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal abstract class eATkOCxXlFfCfRgULMWYXmjrksKk : iqvTAvaOEKbSYfnUTtlbTFLCZR, IControllerTemplateElement, IControllerTemplateAxis3D
		{
			protected const int KvzFBvQNWpBwtfGBziXAIZsXdPqpA = 0;

			protected const int beoJeCBfCSvBoiqEuUIgxEmrofGJ = 1;

			protected const int tjNXwmbOqxVbNpOFzkVhvDJofaUfA = 2;

			protected const int YWRtWKbIgqRwyNetoDlDhiZglSfoA = 3;

			public Vector3 value => default(Vector3);

			public Vector3 valuePrev => default(Vector3);

			public IControllerTemplateAxis horizontal => null;

			public IControllerTemplateAxis vertical => null;

			public IControllerTemplateAxis depth => null;

			protected eATkOCxXlFfCfRgULMWYXmjrksKk(IControllerTemplate P_0, int P_1, string P_2, ControllerTemplateElementType P_3, gwBXOpXdcaPCdFtopfeMjzVrGimI[] P_4)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal abstract class OitTJKMbgxCqxEiMofopDYqFnPOK : iqvTAvaOEKbSYfnUTtlbTFLCZR, IControllerTemplateElement, IControllerTemplateAxis6D
		{
			protected const int yvXbqGKCSGLKdyEsScwEgEquZFUrA = 0;

			protected const int nzKcfYrDpmfCUHKocQixVxLLNpOG = 1;

			protected const int SdaeRGvFwlbvUabvyJCNTJmYCcoY = 2;

			protected const int nWeatfAXyAuBsPsShlpAAHVeCCCMb = 3;

			protected const int ILPWrOCcbcIBeYSAhuocterTQVtb = 4;

			protected const int UnoERIzJrPfETHzxfAuFBdQGUCUic = 5;

			protected const int YWRtWKbIgqRwyNetoDlDhiZglSfoA = 6;

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

			protected OitTJKMbgxCqxEiMofopDYqFnPOK(IControllerTemplate P_0, int P_1, string P_2, ControllerTemplateElementType P_3, gwBXOpXdcaPCdFtopfeMjzVrGimI[] P_4)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal sealed class WUbLoAAsDTcFlixjKBKxiuRFEKFKB : eATkOCxXlFfCfRgULMWYXmjrksKk, IControllerTemplateElement, IControllerTemplateStick
		{
			private new const int YWRtWKbIgqRwyNetoDlDhiZglSfoA = 3;

			public IControllerTemplateAxis rotation => null;

			private WUbLoAAsDTcFlixjKBKxiuRFEKFKB(IControllerTemplate P_0, int P_1, string P_2, gwBXOpXdcaPCdFtopfeMjzVrGimI[] P_3)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}

			public WUbLoAAsDTcFlixjKBKxiuRFEKFKB(IControllerTemplate P_0, int P_1, string P_2, sNACywUzLRIlnfbDvzRcJlkFTFTb P_3, sNACywUzLRIlnfbDvzRcJlkFTFTb P_4, sNACywUzLRIlnfbDvzRcJlkFTFTb P_5)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal sealed class HiGXBsqDccjqVGuItfKobymTTZqJ : esTNGvLAqbTZOoFAXRFbFhJiHsnI, IControllerTemplateElement, IControllerTemplateThumbStick
		{
			private const int IKmfvOBITGILPenJBKoBxYDRBmLc = 2;

			private new const int YWRtWKbIgqRwyNetoDlDhiZglSfoA = 3;

			public IControllerTemplateButton press => null;

			private HiGXBsqDccjqVGuItfKobymTTZqJ(IControllerTemplate P_0, int P_1, string P_2, gwBXOpXdcaPCdFtopfeMjzVrGimI[] P_3)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}

			internal HiGXBsqDccjqVGuItfKobymTTZqJ(IControllerTemplate P_0, int P_1, string P_2, sNACywUzLRIlnfbDvzRcJlkFTFTb P_3, sNACywUzLRIlnfbDvzRcJlkFTFTb P_4, sNACywUzLRIlnfbDvzRcJlkFTFTb P_5)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal sealed class dbNLfLVNvcXaUpSDKahiFuenWaf : iqvTAvaOEKbSYfnUTtlbTFLCZR, IControllerTemplateElement, IControllerTemplateDPad
		{
			private const int ORYfOycqcJWkBthpFFuEOJrZziIh = 0;

			private const int PGUaUqHMOmajPApKidHCJNhDfwpac = 1;

			private const int hbWwcKoFZfzdEpQbhTkKYJSWmmCH = 2;

			private const int VYmonlrhYpdcMdJxrWruqlZUaXgr = 3;

			private const int lLFdQstqcvCZIpCGqiSNVTBOyZgu = 4;

			private const int YWRtWKbIgqRwyNetoDlDhiZglSfoA = 5;

			public Vector2 value => default(Vector2);

			public Vector2 valuePrev => default(Vector2);

			public IControllerTemplateButton up => null;

			public IControllerTemplateButton right => null;

			public IControllerTemplateButton down => null;

			public IControllerTemplateButton left => null;

			public IControllerTemplateButton press => null;

			private dbNLfLVNvcXaUpSDKahiFuenWaf(IControllerTemplate P_0, int P_1, string P_2, gwBXOpXdcaPCdFtopfeMjzVrGimI[] P_3)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}

			internal dbNLfLVNvcXaUpSDKahiFuenWaf(IControllerTemplate P_0, int P_1, string P_2, sNACywUzLRIlnfbDvzRcJlkFTFTb P_3, sNACywUzLRIlnfbDvzRcJlkFTFTb P_4, sNACywUzLRIlnfbDvzRcJlkFTFTb P_5, sNACywUzLRIlnfbDvzRcJlkFTFTb P_6, sNACywUzLRIlnfbDvzRcJlkFTFTb P_7)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal sealed class mBBKIVYdbjBDNmrZzdwurUheBAABA : iqvTAvaOEKbSYfnUTtlbTFLCZR, IControllerTemplateElement, IControllerTemplateThrottle
		{
			private const int tPycErcAGxMDCuYgNSYetEEfgmmEb = 0;

			private const int qHzpcWedrHyeEkwxUHjaKZmDVeAb = 1;

			private const int YWRtWKbIgqRwyNetoDlDhiZglSfoA = 2;

			public float value => 0f;

			public float valuePrev => 0f;

			public IControllerTemplateAxis throttle => null;

			public IControllerTemplateButton minDetent => null;

			private mBBKIVYdbjBDNmrZzdwurUheBAABA(IControllerTemplate P_0, int P_1, string P_2, gwBXOpXdcaPCdFtopfeMjzVrGimI[] P_3)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}

			internal mBBKIVYdbjBDNmrZzdwurUheBAABA(IControllerTemplate P_0, int P_1, string P_2, sNACywUzLRIlnfbDvzRcJlkFTFTb P_3, sNACywUzLRIlnfbDvzRcJlkFTFTb P_4)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal sealed class NjraWBtqrDdAEhZrgZTFLTbrQseR : iqvTAvaOEKbSYfnUTtlbTFLCZR, IControllerTemplateElement, IControllerTemplateHat
		{
			private const int ORYfOycqcJWkBthpFFuEOJrZziIh = 0;

			private const int uDyODBymzzhyopbbBFuCCcLNrrNOA = 1;

			private const int PGUaUqHMOmajPApKidHCJNhDfwpac = 2;

			private const int PTgvpyfwKvqIbWyzeNzjCVyxTAAJ = 3;

			private const int hbWwcKoFZfzdEpQbhTkKYJSWmmCH = 4;

			private const int LWwOearHbPQhpuBmdIYnbSXsjnQEb = 5;

			private const int VYmonlrhYpdcMdJxrWruqlZUaXgr = 6;

			private const int kaHSlCtWVQHJeFyFpToJDBQUKeSK = 7;

			private const int YWRtWKbIgqRwyNetoDlDhiZglSfoA = 8;

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

			private NjraWBtqrDdAEhZrgZTFLTbrQseR(IControllerTemplate P_0, int P_1, string P_2, gwBXOpXdcaPCdFtopfeMjzVrGimI[] P_3)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}

			internal NjraWBtqrDdAEhZrgZTFLTbrQseR(IControllerTemplate P_0, int P_1, string P_2, sNACywUzLRIlnfbDvzRcJlkFTFTb P_3, sNACywUzLRIlnfbDvzRcJlkFTFTb P_4, sNACywUzLRIlnfbDvzRcJlkFTFTb P_5, sNACywUzLRIlnfbDvzRcJlkFTFTb P_6, sNACywUzLRIlnfbDvzRcJlkFTFTb P_7, sNACywUzLRIlnfbDvzRcJlkFTFTb P_8, sNACywUzLRIlnfbDvzRcJlkFTFTb P_9, sNACywUzLRIlnfbDvzRcJlkFTFTb P_10)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal sealed class JOmCJevqEYwTFrKxZaIBpAwbkmNk : esTNGvLAqbTZOoFAXRFbFhJiHsnI, IControllerTemplateElement, IControllerTemplateYoke
		{
			private new const int YWRtWKbIgqRwyNetoDlDhiZglSfoA = 2;

			public IControllerTemplateAxis rotation => null;

			public IControllerTemplateAxis pushPull => null;

			private JOmCJevqEYwTFrKxZaIBpAwbkmNk(IControllerTemplate P_0, int P_1, string P_2, gwBXOpXdcaPCdFtopfeMjzVrGimI[] P_3)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}

			internal JOmCJevqEYwTFrKxZaIBpAwbkmNk(IControllerTemplate P_0, int P_1, string P_2, sNACywUzLRIlnfbDvzRcJlkFTFTb P_3, sNACywUzLRIlnfbDvzRcJlkFTFTb P_4)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal sealed class pndTnlNuLfTmFyGQJCrSrXYBCXKy : OitTJKMbgxCqxEiMofopDYqFnPOK, IControllerTemplateElement, IControllerTemplateStick6D
		{
			private new const int YWRtWKbIgqRwyNetoDlDhiZglSfoA = 6;

			private pndTnlNuLfTmFyGQJCrSrXYBCXKy(IControllerTemplate P_0, int P_1, string P_2, gwBXOpXdcaPCdFtopfeMjzVrGimI[] P_3)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}

			internal pndTnlNuLfTmFyGQJCrSrXYBCXKy(IControllerTemplate P_0, int P_1, string P_2, sNACywUzLRIlnfbDvzRcJlkFTFTb P_3, sNACywUzLRIlnfbDvzRcJlkFTFTb P_4, sNACywUzLRIlnfbDvzRcJlkFTFTb P_5, sNACywUzLRIlnfbDvzRcJlkFTFTb P_6, sNACywUzLRIlnfbDvzRcJlkFTFTb P_7, sNACywUzLRIlnfbDvzRcJlkFTFTb P_8)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal class PbLhtDmFPsNazvYLFQBoFqNdAtlL
		{
			public readonly Controller.Element BCuHApOmoSObQBcmCUJCdFCnCAsFA;

			public readonly IControllerElementTarget LNFmGxqdskDZYydfYKbBBRoonLzv;

			public bool oWEdkgpANxjhVOIcAcKXObeBlSuU => false;

			public bool mjwdDosldubIUAhRxvRGpnamBQgm => false;

			public bool yjBXVGcweMRmHAeJWtlsivXQHOYK => false;

			public bool pmvZevAaExDOXoNPFOwXhCJOdDQl => false;

			public float esvdQDSeoVapiVBnSLWqsHImVLWA => 0f;

			public float sLALWRKTLxJotpSszSIhCrXmtbUF => 0f;

			public PbLhtDmFPsNazvYLFQBoFqNdAtlL(IControllerElementTarget P_0, Controller.Element P_1)
			{
			}

			public static PbLhtDmFPsNazvYLFQBoFqNdAtlL ckrUQVcMUnHdCWgDQIywBRRTSKOn()
			{
				return null;
			}
		}

		internal class feVKXHBPShqNDdopDgaTXfGJMrbc
		{
			public readonly Controller NlFnBAIUQPMwtvacPcDKoOszCbeW;

			public readonly IHardwareControllerTemplateMap_Internal OGphAamvxmKlIbmrRdwRIFGnAPCkA;

			public feVKXHBPShqNDdopDgaTXfGJMrbc(Controller P_0, IHardwareControllerTemplateMap_Internal P_1)
			{
			}
		}

		private readonly string gbaFwplwRPDIuUufIuWmknaoIHDK;

		private readonly Guid JPtXFrKJjRdQNJgDXtEmYtxqxYhM;

		private readonly Controller nEgdvbuTaiHYWdQfyyXkKnXDhOQcb;

		private readonly ADictionary<int, IControllerTemplateElement> KxaTofjYlqbwmMmKZdhwovhZxdzA;

		private readonly ADictionary<string, IControllerTemplateElement> uPRcmVWopBMlISMMaNrxnCcSgfSs;

		private IControllerTemplateElement[] aUQWeyXieBvNOUAjqzTkUKmMbRkq;

		private ReadOnlyCollection<IControllerTemplateElement> ABLlvSkeHalgmkxVjrUFAcOGcjTf;

		private readonly int TcEXPUvjqSTMTFutCAtGRnMeNwub;

		Controller IControllerTemplate.controller => null;

		string IControllerTemplate.name => null;

		Guid IControllerTemplate.typeGuid => default(Guid);

		IList<IControllerTemplateElement> IControllerTemplate.elements => null;

		int IControllerTemplate.elementCount => 0;

		protected ControllerTemplate(object P_0)
		{
		}

		private ControllerTemplate(feVKXHBPShqNDdopDgaTXfGJMrbc P_0)
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

		[CustomObfuscation]
		internal static Type GetInterfaceType(ControllerTemplateElementType elementType)
		{
			return null;
		}

		private static IList<PbLhtDmFPsNazvYLFQBoFqNdAtlL> LnItojlMnxazbiMQNlegHahpuXhxA(Controller P_0, IControllerTemplateAxisSource P_1)
		{
			return null;
		}

		private static IList<PbLhtDmFPsNazvYLFQBoFqNdAtlL> LnItojlMnxazbiMQNlegHahpuXhxA(Controller P_0, IControllerTemplateButtonSource P_1)
		{
			return null;
		}

		private static IList<PbLhtDmFPsNazvYLFQBoFqNdAtlL> LnItojlMnxazbiMQNlegHahpuXhxA(Controller P_0, IControllerElementTarget P_1)
		{
			return null;
		}

		private static IControllerTemplateElement nZHQVsgVTUQcIoUXkGNrGIPCwOzc(List<IControllerTemplateElement> P_0, int P_1)
		{
			return null;
		}

		private static sNACywUzLRIlnfbDvzRcJlkFTFTb IdaaQBJQnEYKOoXGgCRtlIWpoEQAA(IControllerTemplate P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			return null;
		}

		private static sNACywUzLRIlnfbDvzRcJlkFTFTb jodeWACReFvZpoQyUvqnhZRwyafZ(IControllerTemplate P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			return null;
		}
	}
}
