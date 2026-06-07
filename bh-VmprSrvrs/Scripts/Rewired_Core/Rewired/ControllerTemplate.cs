using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Data.Mapping;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerTemplate : IControllerTemplate, IControllerTemplate_Internal, cfLjOhjLYeBVSqIGSwIBARCebRsBb
	{
		internal abstract class KhfwjXILcpeEsMzonkVXzoOLfqRH : IControllerTemplateElement, IControllerTemplateElement_Internal
		{
			private readonly IControllerTemplate nROwphaqzgNiEpgYELCvXPwfXpnv;

			private readonly int uvvcPYRpEccJpJXeGQzDfsvfGKxA;

			private readonly ControllerTemplateElementType sRKmmpMAtEJmMgFLRQJXWPBDjadu;

			protected readonly int zxOqPihoHeBBSjcvYWTerVHeCtkFb;

			protected readonly URUqgJYVEGsJrTTZacgCSjzPllKh qNUfVqfGVLqUFVUeEAduIVRFSnfCc;

			public int id => 0;

			public string descriptiveName => null;

			internal string yGcxlQCtVgGXNmTsCmkIPtDmaQfQ => null;

			public ControllerTemplateElementType type => default(ControllerTemplateElementType);

			public IControllerTemplate parent => null;

			public abstract int elementCount { get; }

			public abstract IControllerTemplateElementSource source { get; }

			public abstract bool exists { get; }

			protected KhfwjXILcpeEsMzonkVXzoOLfqRH(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, URUqgJYVEGsJrTTZacgCSjzPllKh P_3)
			{
			}

			public abstract IControllerTemplateElement GetElement(int index);

			public abstract int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list);

			protected static URUqgJYVEGsJrTTZacgCSjzPllKh aITwpDDFWtxhPLBqnsWnozsdmUL(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3)
			{
				return null;
			}
		}

		internal abstract class MmeZETKVhESghtodiQfFHxriJhMe : KhfwjXILcpeEsMzonkVXzoOLfqRH
		{
			protected readonly int dQiTlDHxhAoXFeMbWPokjZFhAMEd;

			protected readonly dmpCBfrLRfoxauILPTyzDHONthOK[] OrCyTHlqRPxckBeDngamGYZSIPLvA;

			public override bool exists => false;

			protected MmeZETKVhESghtodiQfFHxriJhMe(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, IList<dmpCBfrLRfoxauILPTyzDHONthOK> P_3, URUqgJYVEGsJrTTZacgCSjzPllKh P_4)
				: base(null, 0, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal abstract class EfcbsCZFnIfvwwQpTlqALXafTwwv : MmeZETKVhESghtodiQfFHxriJhMe, IControllerTemplateAxis, IControllerTemplateElement, IControllerTemplateButton
		{
			private aiXCuJzvMdwQePgyTGrMKoxTlbNY MRuBCbhKHSheRCLSDBPYpdBrHneY;

			public float KapaagElykxoQDJaLEuDNtVQryqT => 0f;

			public float AzMZdZAnqoaHIzilJAmDumpHlTIb => 0f;

			public bool odiQGJPvVfoYSKknPCrCBnDbliiT => false;

			public bool TLPqYFMhxaZpQZSzIwsUuhSoyoMJ => false;

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

			protected UXgYabqYHrbzmnqtbhdfhKGfFLrW oPlOMhmgFeoICFTaFGyBdOrwiqfn => null;

			protected EfcbsCZFnIfvwwQpTlqALXafTwwv(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, aiXCuJzvMdwQePgyTGrMKoxTlbNY P_3, IList<dmpCBfrLRfoxauILPTyzDHONthOK> P_4, UXgYabqYHrbzmnqtbhdfhKGfFLrW P_5)
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

			private static bool ZXliNgMbLuHYPbUoPooAVOsjIEzGA(ControllerElementTarget P_0, IControllerElementTarget P_1)
			{
				return false;
			}
		}

		internal sealed class pemHvfEuYoezoqSryppTLqIouMhZ : EfcbsCZFnIfvwwQpTlqALXafTwwv
		{
			public pemHvfEuYoezoqSryppTLqIouMhZ(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, string P_4, string P_5, string P_6, string P_7, aiXCuJzvMdwQePgyTGrMKoxTlbNY P_8, IList<dmpCBfrLRfoxauILPTyzDHONthOK> P_9)
				: base(null, 0, default(ControllerTemplateElementType), null, null, null)
			{
			}

			internal static pemHvfEuYoezoqSryppTLqIouMhZ yMPgYohIUMgcKxqIaZpHBfbhSYueA(IControllerTemplate_Internal P_0)
			{
				return null;
			}
		}

		internal sealed class InCJkclPlirSrPXnxAhhHqWtAriaA : EfcbsCZFnIfvwwQpTlqALXafTwwv
		{
			public InCJkclPlirSrPXnxAhhHqWtAriaA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, string P_4, string P_5, string P_6, string P_7, aiXCuJzvMdwQePgyTGrMKoxTlbNY P_8, IList<dmpCBfrLRfoxauILPTyzDHONthOK> P_9)
				: base(null, 0, default(ControllerTemplateElementType), null, null, null)
			{
			}

			internal static InCJkclPlirSrPXnxAhhHqWtAriaA XBnCKIilKvABnktDbxsqOnjZFYBG(IControllerTemplate_Internal P_0)
			{
				return null;
			}
		}

		internal abstract class isOEXtTZuTtGsBtjzASclwUdlqkh : KhfwjXILcpeEsMzonkVXzoOLfqRH
		{
			protected readonly int ZDmectscwYapBVZqQtrBxoJVfKwEA;

			protected readonly KhfwjXILcpeEsMzonkVXzoOLfqRH[] XDrCjTQGZeDDBBbcmblZLXyPRsLi;

			public override bool exists => false;

			public override IControllerTemplateElementSource source => null;

			public override int elementCount => 0;

			protected isOEXtTZuTtGsBtjzASclwUdlqkh(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, KhfwjXILcpeEsMzonkVXzoOLfqRH[] P_3, URUqgJYVEGsJrTTZacgCSjzPllKh P_4)
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

		internal abstract class QjbasJMMKizeBhhDLCGoAVGYxqMSA : isOEXtTZuTtGsBtjzASclwUdlqkh, IControllerTemplateAxis2D, IControllerTemplateElement
		{
			protected const int GRntvEoZuJrzndsTfOdPsfquHECS = 0;

			protected const int xoRfEETIxhpgyzYqkdLtkrUDEqCB = 1;

			protected const int KFSdaOJUPpJdEzcXXtZpJMOcUHaCA = 2;

			public Vector2 value => default(Vector2);

			public Vector2 valuePrev => default(Vector2);

			public IControllerTemplateAxis horizontal => null;

			public IControllerTemplateAxis vertical => null;

			protected QjbasJMMKizeBhhDLCGoAVGYxqMSA(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, KhfwjXILcpeEsMzonkVXzoOLfqRH[] P_3, URUqgJYVEGsJrTTZacgCSjzPllKh P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal abstract class QRlbfiJulMYnyjQKRvNZNVoLHRjOA : isOEXtTZuTtGsBtjzASclwUdlqkh, IControllerTemplateAxis3D, IControllerTemplateElement
		{
			protected const int PwIgpzgRaPIJfYIpYIdmFHqUbQL = 0;

			protected const int jtMNMNsTdeuwlODkPjDhDWicSCpk = 1;

			protected const int RQJFGCewuzvqKrpiSrfgmZIjSwePA = 2;

			protected const int CtOKGUKfBzlOImFmreFByyOpJfBQ = 3;

			public Vector3 value => default(Vector3);

			public Vector3 valuePrev => default(Vector3);

			public IControllerTemplateAxis horizontal => null;

			public IControllerTemplateAxis vertical => null;

			public IControllerTemplateAxis depth => null;

			protected QRlbfiJulMYnyjQKRvNZNVoLHRjOA(IControllerTemplate_Internal P_0, int P_1, ControllerTemplateElementType P_2, KhfwjXILcpeEsMzonkVXzoOLfqRH[] P_3, URUqgJYVEGsJrTTZacgCSjzPllKh P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal abstract class oyLmZuNaqapHcDAKijsmFlhvUUhQ : isOEXtTZuTtGsBtjzASclwUdlqkh, IControllerTemplateAxis6D, IControllerTemplateElement
		{
			protected const int xLWjWIHuNGwuEvuZcNYTiWcpFqkb = 0;

			protected const int AAUQhrzfxPzmFYAZpyZDDkaIhCDx = 1;

			protected const int oeDgIAdXbBQtWcIruhHQaYMUEIGnA = 2;

			protected const int FpBgRMGkBmegYdaRqihCCWnCLdKRc = 3;

			protected const int YJVshpPLzHDSGAOXNhcbSLHHhjDB = 4;

			protected const int DFqvFxaFKMnCvJVXboUairQJgZDm = 5;

			protected const int toJoGApvNkpVyHYGjpnrostfYuyH = 6;

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

			protected oyLmZuNaqapHcDAKijsmFlhvUUhQ(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, KhfwjXILcpeEsMzonkVXzoOLfqRH[] P_3, URUqgJYVEGsJrTTZacgCSjzPllKh P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal sealed class ulLyHkJbTQruyczvKDZisPKywrcx : QRlbfiJulMYnyjQKRvNZNVoLHRjOA, IControllerTemplateStick, IControllerTemplateElement
		{
			private const int LJUtqFZGNbyWveCgBvNYuRXfgDlt = 3;

			public IControllerTemplateAxis rotation => null;

			private ulLyHkJbTQruyczvKDZisPKywrcx(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, KhfwjXILcpeEsMzonkVXzoOLfqRH[] P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}

			public ulLyHkJbTQruyczvKDZisPKywrcx(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, EfcbsCZFnIfvwwQpTlqALXafTwwv P_4, EfcbsCZFnIfvwwQpTlqALXafTwwv P_5, EfcbsCZFnIfvwwQpTlqALXafTwwv P_6)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal sealed class zTouSMtwulAJEZNIjuNtxBbbhqDx : QjbasJMMKizeBhhDLCGoAVGYxqMSA, IControllerTemplateThumbStick, IControllerTemplateElement
		{
			private const int GyDSrEuXgDhixyOMiFLTofKAqIvV = 2;

			private const int IvltbLKwnBYOBgARpSHgdIHxBzZn = 3;

			public IControllerTemplateButton press => null;

			private zTouSMtwulAJEZNIjuNtxBbbhqDx(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, KhfwjXILcpeEsMzonkVXzoOLfqRH[] P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}

			internal zTouSMtwulAJEZNIjuNtxBbbhqDx(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, EfcbsCZFnIfvwwQpTlqALXafTwwv P_4, EfcbsCZFnIfvwwQpTlqALXafTwwv P_5, EfcbsCZFnIfvwwQpTlqALXafTwwv P_6)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal sealed class HQLysHMeJyHJhFOdVwTqqWhMFWTS : isOEXtTZuTtGsBtjzASclwUdlqkh, IControllerTemplateDPad, IControllerTemplateElement
		{
			private const int kenUYFIYYeoYCRpJXRAuQAxIqXTn = 0;

			private const int uiMdTbKpxFNvCtzmJNBMsGyDtDiD = 1;

			private const int GLWcDpDfuJQqJeEIeMAypXMhkBAI = 2;

			private const int NtnZYhjTYpAVApweFmaUlLOMaOwd = 3;

			private const int czmlpXRGCSheqpzXfTriBIeOAaYFA = 4;

			private const int znkftGfIFkkUXsWZxlheuRruObbyA = 5;

			public Vector2 value => default(Vector2);

			public Vector2 valuePrev => default(Vector2);

			public IControllerTemplateButton up => null;

			public IControllerTemplateButton right => null;

			public IControllerTemplateButton down => null;

			public IControllerTemplateButton left => null;

			public IControllerTemplateButton press => null;

			private HQLysHMeJyHJhFOdVwTqqWhMFWTS(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, KhfwjXILcpeEsMzonkVXzoOLfqRH[] P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}

			internal HQLysHMeJyHJhFOdVwTqqWhMFWTS(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, EfcbsCZFnIfvwwQpTlqALXafTwwv P_4, EfcbsCZFnIfvwwQpTlqALXafTwwv P_5, EfcbsCZFnIfvwwQpTlqALXafTwwv P_6, EfcbsCZFnIfvwwQpTlqALXafTwwv P_7, EfcbsCZFnIfvwwQpTlqALXafTwwv P_8)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal sealed class YSdbzxVjvoCoWhrRvanvZfcAmrrJA : isOEXtTZuTtGsBtjzASclwUdlqkh, IControllerTemplateThrottle, IControllerTemplateElement
		{
			private const int aZcnWuBAryUiCytlkqGCisWYuBLi = 0;

			private const int qDLfkKgVNbQhdpIdkFOjvmkjpFCl = 1;

			private const int wpDWwdQmQUkTvsDVGpdJCoUHonOe = 2;

			public float value => 0f;

			public float valuePrev => 0f;

			public IControllerTemplateAxis throttle => null;

			public IControllerTemplateButton minDetent => null;

			private YSdbzxVjvoCoWhrRvanvZfcAmrrJA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, KhfwjXILcpeEsMzonkVXzoOLfqRH[] P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}

			internal YSdbzxVjvoCoWhrRvanvZfcAmrrJA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, EfcbsCZFnIfvwwQpTlqALXafTwwv P_4, EfcbsCZFnIfvwwQpTlqALXafTwwv P_5)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal sealed class lRNglnoadIexRdKluiOYwDqDNNTcA : isOEXtTZuTtGsBtjzASclwUdlqkh, IControllerTemplateHat, IControllerTemplateElement
		{
			private const int jJgmIrLaEgnlXnyinVCcojZkFJfF = 0;

			private const int NcFIQoYqlPheCNqQSAbBzGUGeAFe = 1;

			private const int NBBgasUaIxdjaDuGJcXTbfDCMdWk = 2;

			private const int WgxcTIkqsLCmXjReMBxKJIrxofVIb = 3;

			private const int cguSWlrTJATSqzfysRAFxOOGJpli = 4;

			private const int GQtNRxVMglIuhdMaGmCGmgFnecTG = 5;

			private const int UoAEagsAIbPQvqXWcdgytTdENeUK = 6;

			private const int jHydzEOUudmsUxzlvVyCHTETiUwI = 7;

			private const int OQckJjbEVdMNmnaEUsUdPbOKTOXS = 8;

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

			private lRNglnoadIexRdKluiOYwDqDNNTcA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, KhfwjXILcpeEsMzonkVXzoOLfqRH[] P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}

			internal lRNglnoadIexRdKluiOYwDqDNNTcA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, EfcbsCZFnIfvwwQpTlqALXafTwwv P_4, EfcbsCZFnIfvwwQpTlqALXafTwwv P_5, EfcbsCZFnIfvwwQpTlqALXafTwwv P_6, EfcbsCZFnIfvwwQpTlqALXafTwwv P_7, EfcbsCZFnIfvwwQpTlqALXafTwwv P_8, EfcbsCZFnIfvwwQpTlqALXafTwwv P_9, EfcbsCZFnIfvwwQpTlqALXafTwwv P_10, EfcbsCZFnIfvwwQpTlqALXafTwwv P_11)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal sealed class fBQeKPaEhBodMolFHxuYpvEHVdoD : QjbasJMMKizeBhhDLCGoAVGYxqMSA, IControllerTemplateYoke, IControllerTemplateElement
		{
			private const int wfFZkhyguddJzKzHsUVFlQHDvGyQ = 2;

			public IControllerTemplateAxis rotation => null;

			public IControllerTemplateAxis pushPull => null;

			private fBQeKPaEhBodMolFHxuYpvEHVdoD(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, KhfwjXILcpeEsMzonkVXzoOLfqRH[] P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}

			internal fBQeKPaEhBodMolFHxuYpvEHVdoD(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, EfcbsCZFnIfvwwQpTlqALXafTwwv P_4, EfcbsCZFnIfvwwQpTlqALXafTwwv P_5)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal sealed class FXZpENOMPibPCtsUFFeJdeHzusrU : oyLmZuNaqapHcDAKijsmFlhvUUhQ, IControllerTemplateStick6D, IControllerTemplateElement
		{
			private const int IDdVPZVkFqEBlwSYpBhMwVFxHPXfA = 6;

			private FXZpENOMPibPCtsUFFeJdeHzusrU(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, KhfwjXILcpeEsMzonkVXzoOLfqRH[] P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}

			internal FXZpENOMPibPCtsUFFeJdeHzusrU(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, EfcbsCZFnIfvwwQpTlqALXafTwwv P_4, EfcbsCZFnIfvwwQpTlqALXafTwwv P_5, EfcbsCZFnIfvwwQpTlqALXafTwwv P_6, EfcbsCZFnIfvwwQpTlqALXafTwwv P_7, EfcbsCZFnIfvwwQpTlqALXafTwwv P_8, EfcbsCZFnIfvwwQpTlqALXafTwwv P_9)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal class dmpCBfrLRfoxauILPTyzDHONthOK
		{
			public readonly Controller.Element oKmCFsEFhKoGuYAGJSSdgCEgSTXEb;

			public readonly IControllerElementTarget zbHzvyUFomLwGLfQTydFXBCfsQME;

			public bool njWfdHudkVSoVjzgJOSEHslQXsXR => false;

			public bool tMbgLYGHirBtxGHCrAAaJzaqtRDf => false;

			public bool APCaBNJQHyVQQTQOEpWRrmuVqGVqA => false;

			public bool dALZGFiUqVVDQUWyFhgoVbvBQRqJ => false;

			public float nqIvWheFGdiHxDiVJfgLVmSpUdp => 0f;

			public float BbmhrxDgPgDUraQhMEbfeXXiVCBLc => 0f;

			public dmpCBfrLRfoxauILPTyzDHONthOK(IControllerElementTarget P_0, Controller.Element P_1)
			{
			}

			public static dmpCBfrLRfoxauILPTyzDHONthOK OTOdlSIsQzTfamHFkfAlKzwqKuXrA()
			{
				return null;
			}
		}

		internal class FwhBjfWAXmuLYsqqNixxJjkdmxOP
		{
			public readonly Controller PEXqWFhnOFqnJKLoupTUXokAJswk;

			public readonly IHardwareControllerTemplateMap_Internal aRqMmReFMIqOSghreYsHWnzjGjqAA;

			public FwhBjfWAXmuLYsqqNixxJjkdmxOP(Controller P_0, IHardwareControllerTemplateMap_Internal P_1)
			{
			}
		}

		private sealed class qfbJJvjXUEKQCoJSpICrceakTjWfb
		{
			[Serializable]
			private sealed class orDFrEtsiFWuDFmQKdsGDTNlFIcY
			{
				public static readonly orDFrEtsiFWuDFmQKdsGDTNlFIcY _003C_003E9;

				public static Func<URUqgJYVEGsJrTTZacgCSjzPllKh, URUqgJYVEGsJrTTZacgCSjzPllKh, bool> _003C_003E9__4_0;

				internal bool QPSiNtTAlxIKHeVxIvogqFRncQNy(URUqgJYVEGsJrTTZacgCSjzPllKh P_0, URUqgJYVEGsJrTTZacgCSjzPllKh P_1)
				{
					return false;
				}
			}

			private static qfbJJvjXUEKQCoJSpICrceakTjWfb mAuAGegYplcnxDipKvZCGZhyOOb;

			private readonly global::CJCYPIQCgYcCaJUchpDJOUTXPPENA<URUqgJYVEGsJrTTZacgCSjzPllKh> pflraluALyampdfELJViiTnkjgPyA;

			private static qfbJJvjXUEKQCoJSpICrceakTjWfb kvOGsCjBPNDguNeqUlsyQdeGYYJm => null;

			private qfbJJvjXUEKQCoJSpICrceakTjWfb()
			{
			}

			private void LcqSWDGnAiIGaViQWQnteNrlHwbs()
			{
			}

			private void yHnYKfGgpoHfUKgJaApqzasdQIPX()
			{
			}

			public static URUqgJYVEGsJrTTZacgCSjzPllKh QeRAPAtBfrfghXFrQIizLAHNGctHA(URUqgJYVEGsJrTTZacgCSjzPllKh P_0)
			{
				return null;
			}

			public static bool MxPCEWGZGFRqRWKCuNhkRBrQCpQjb(URUqgJYVEGsJrTTZacgCSjzPllKh P_0, out URUqgJYVEGsJrTTZacgCSjzPllKh P_1)
			{
				P_1 = null;
				return false;
			}

			public static void aiZIxXyKaqVmAKTZWYqyrSPEBAtk(URUqgJYVEGsJrTTZacgCSjzPllKh P_0)
			{
			}
		}

		private const string rvbgNjbRCnyJlujDBiJlWVOFtoKp = "controller/template";

		private string ZCxLWRyUFfTOHMAZtcJTiFTSYEXZ;

		private string FtYMRvWgKjaUYuUfBImnKLNmGnmcb;

		private int kBeltFuFmEuiSacGjTKInRgbSdnr;

		private readonly Guid lGCJGfJXbmLldKdFxbqnMfEYCNFkA;

		private readonly DeviceLocalizationInfo oJltBTZMpoqWJRLcDtVzZaTjdFGH;

		private readonly Controller jGMDnvDLVdOZkztfQoJIeALeGrkkB;

		private readonly ADictionary<int, IControllerTemplateElement> NwjbcNSRUiieUHaQMOXWzhJymqyQ;

		private readonly ADictionary<string, IControllerTemplateElement> eeQjBJBVMWpDFdQeTNVbHbYdDXFo;

		private IControllerTemplateElement[] pEUEClBexNTSGsSeFXJUuqqnNAkGA;

		private ReadOnlyCollection<IControllerTemplateElement> ZxOqkRHltkKgMvVhdxqHGbrxNexV;

		private readonly hBdBPTFfODwAjjJlnJTKaJqqNCMYA DyexRDflUDsBzhWXtBYXadBCOpHk;

		private readonly int KZKnRpUDderXKCigdhtFVPANNnMv;

		internal DeviceLocalizationInfo AZddgCAHZBDOZYoQkZvOkeVWSvykA => null;

		DeviceLocalizationInfo IControllerTemplate_Internal.deviceLocalizationInfo => null;

		Controller IControllerTemplate.controller => null;

		string IControllerTemplate.name => null;

		Guid IControllerTemplate.typeGuid => default(Guid);

		IList<IControllerTemplateElement> IControllerTemplate.elements => null;

		int IControllerTemplate.elementCount => 0;

		string cfLjOhjLYeBVSqIGSwIBARCebRsBb.keyCategory => null;

		string cfLjOhjLYeBVSqIGSwIBARCebRsBb.scriptingName => null;

		string cfLjOhjLYeBVSqIGSwIBARCebRsBb.nonLocalizedDescriptiveName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		string cfLjOhjLYeBVSqIGSwIBARCebRsBb.key => null;

		int cfLjOhjLYeBVSqIGSwIBARCebRsBb.autoGeneratedValueFlags
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

		private ControllerTemplate(FwhBjfWAXmuLYsqqNixxJjkdmxOP P_0)
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

		private static IList<dmpCBfrLRfoxauILPTyzDHONthOK> LyhKFQEmjCgrHPojofxFiWbYyHxV(Controller P_0, IControllerTemplateAxisSource P_1)
		{
			return null;
		}

		private static IList<dmpCBfrLRfoxauILPTyzDHONthOK> KKddKxhkmNAPGNTJZrUwtrKTEvpFA(Controller P_0, IControllerTemplateButtonSource P_1)
		{
			return null;
		}

		private static IList<dmpCBfrLRfoxauILPTyzDHONthOK> dqEHTKbQzjVuGJwDNgLTKwjDTtIw(Controller P_0, IControllerElementTarget P_1)
		{
			return null;
		}

		private static IControllerTemplateElement ArlzQxjWQlpCNdwmJCfRXaZAESpe(List<IControllerTemplateElement> P_0, int P_1)
		{
			return null;
		}

		private static EfcbsCZFnIfvwwQpTlqALXafTwwv koVQqKagTPvNZkJyHoYZTwcsJbFX(IControllerTemplate_Internal P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			return null;
		}

		private static EfcbsCZFnIfvwwQpTlqALXafTwwv QnfCjaIjrzBEPhqcHnfaiDZeCOguB(IControllerTemplate_Internal P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			return null;
		}
	}
}
