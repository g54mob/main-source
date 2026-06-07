using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Data.Mapping;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerTemplate : IControllerTemplate, IControllerTemplate_Internal, dmwPlHfCHErBELjQlGwCmsUXbNbq
	{
		internal abstract class VDOHtlyVpNuIyLqoCoEYCSQmofCn : IControllerTemplateElement, IControllerTemplateElement_Internal
		{
			private readonly IControllerTemplate ojooDGEaJECKhyOezwAwccuEhTqe;

			private readonly int hkWujhcfccpMXcbVXYmeAxsCmEJX;

			private readonly ControllerTemplateElementType tEbLhPwmcywWYhiXqbdSnfTcMuuR;

			protected readonly int erpCIERZGUnnWvxvbrjbcFJRzjrw;

			protected readonly RHrJzbmIXsdYvASDPWOTfZbswxFS typAtIygQrofJDdadDXjsDVdVheW;

			public int id => 0;

			public string descriptiveName => null;

			internal string rHDemMaWMMvJplwMdONlmLiDQwaB => null;

			public ControllerTemplateElementType type => default(ControllerTemplateElementType);

			public IControllerTemplate parent => null;

			public abstract int elementCount { get; }

			public abstract IControllerTemplateElementSource source { get; }

			public abstract bool exists { get; }

			protected VDOHtlyVpNuIyLqoCoEYCSQmofCn(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, RHrJzbmIXsdYvASDPWOTfZbswxFS P_3)
			{
			}

			public abstract IControllerTemplateElement GetElement(int index);

			public abstract int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list);

			protected static RHrJzbmIXsdYvASDPWOTfZbswxFS rszsrXntEkHTvALHTiWLSFhXhfTaA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3)
			{
				return null;
			}
		}

		internal abstract class ZcVWOasWOoDskytsZFsWyMbFvLTQ : VDOHtlyVpNuIyLqoCoEYCSQmofCn
		{
			protected readonly int igXAYhdhaolKLblGAhxfMGTiQGVnB;

			protected readonly kjCDHDVKEPdQkfgBqEtkakUwFxPUA[] HstOHrNWsnKueWPMYShdrREbNWKd;

			public override bool exists => false;

			protected ZcVWOasWOoDskytsZFsWyMbFvLTQ(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, IList<kjCDHDVKEPdQkfgBqEtkakUwFxPUA> P_3, RHrJzbmIXsdYvASDPWOTfZbswxFS P_4)
				: base(null, 0, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal abstract class RvVLyanCokdPajbnkRIRIkwKJqbKA : ZcVWOasWOoDskytsZFsWyMbFvLTQ, IControllerTemplateAxis, IControllerTemplateElement, IControllerTemplateButton
		{
			private vuooprXJHVvacQvysmZLVazcCbGcA NKLfUHdXIomBVdBUegxNeARBSvxsb;

			public float HqSNvMoKdYlEAGhouPOWsYBzPilx => 0f;

			public float PrAvYPgjgCeMJudmIFodcLmOelKGb => 0f;

			public bool nWDANndiYDbmOdZxsbXBCgViYwjJB => false;

			public bool EiuFfpsNiYqxWKHxhuKBXDAJCaXhA => false;

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

			protected ZNDpJwCUHDPjiknwGXiRUIYEVeDB nzSZeNQjMWceMUjcaoMWKHtHkVqk => null;

			protected RvVLyanCokdPajbnkRIRIkwKJqbKA(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, vuooprXJHVvacQvysmZLVazcCbGcA P_3, IList<kjCDHDVKEPdQkfgBqEtkakUwFxPUA> P_4, ZNDpJwCUHDPjiknwGXiRUIYEVeDB P_5)
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

			private static bool MBSQzSaqKCqLPHEcebYPzviMvWor(ControllerElementTarget P_0, IControllerElementTarget P_1)
			{
				return false;
			}
		}

		internal sealed class skVatTOCTOFNiHhfTcZAPyMNGraf : RvVLyanCokdPajbnkRIRIkwKJqbKA
		{
			public skVatTOCTOFNiHhfTcZAPyMNGraf(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, string P_4, string P_5, string P_6, string P_7, vuooprXJHVvacQvysmZLVazcCbGcA P_8, IList<kjCDHDVKEPdQkfgBqEtkakUwFxPUA> P_9)
				: base(null, 0, default(ControllerTemplateElementType), null, null, null)
			{
			}

			internal static skVatTOCTOFNiHhfTcZAPyMNGraf nWoZKMkfFmGUMfAOLFtECorGOxzf(IControllerTemplate_Internal P_0)
			{
				return null;
			}
		}

		internal sealed class TZzlDCZgsOeczGenITVagdQWelzaA : RvVLyanCokdPajbnkRIRIkwKJqbKA
		{
			public TZzlDCZgsOeczGenITVagdQWelzaA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, string P_4, string P_5, string P_6, string P_7, vuooprXJHVvacQvysmZLVazcCbGcA P_8, IList<kjCDHDVKEPdQkfgBqEtkakUwFxPUA> P_9)
				: base(null, 0, default(ControllerTemplateElementType), null, null, null)
			{
			}

			internal static TZzlDCZgsOeczGenITVagdQWelzaA SHGHNsWTJXoufzlRWEBlrNzoFTKo(IControllerTemplate_Internal P_0)
			{
				return null;
			}
		}

		internal abstract class bjdsVLzmlpRLyKjlAcmlEQQKglfS : VDOHtlyVpNuIyLqoCoEYCSQmofCn
		{
			protected readonly int QQLGrJICpyKFZQimxxFSAMJeBGriA;

			protected readonly VDOHtlyVpNuIyLqoCoEYCSQmofCn[] CTIDPxfmAQIlRWAoPiPQqgoiJFWlA;

			public override bool exists => false;

			public override IControllerTemplateElementSource source => null;

			public override int elementCount => 0;

			protected bjdsVLzmlpRLyKjlAcmlEQQKglfS(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, VDOHtlyVpNuIyLqoCoEYCSQmofCn[] P_3, RHrJzbmIXsdYvASDPWOTfZbswxFS P_4)
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

		internal abstract class LFANnfkbVSxOFagTqCazckCnOqBVA : bjdsVLzmlpRLyKjlAcmlEQQKglfS, IControllerTemplateAxis2D, IControllerTemplateElement
		{
			protected const int RiYRgqCWxtTXbkLNKMoYXzqLLEBr = 0;

			protected const int eHgymsbuFPVHswOYZFDOFghkIMnHA = 1;

			protected const int HFbdIkyDYLRGIvlTuzomrhINKJfT = 2;

			public Vector2 value => default(Vector2);

			public Vector2 valuePrev => default(Vector2);

			public IControllerTemplateAxis horizontal => null;

			public IControllerTemplateAxis vertical => null;

			protected LFANnfkbVSxOFagTqCazckCnOqBVA(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, VDOHtlyVpNuIyLqoCoEYCSQmofCn[] P_3, RHrJzbmIXsdYvASDPWOTfZbswxFS P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal abstract class JIUakCWoogJwkBYYmbmKuaFcLoiE : bjdsVLzmlpRLyKjlAcmlEQQKglfS, IControllerTemplateAxis3D, IControllerTemplateElement
		{
			protected const int KvDtNLRwnSbfRgXYUaLuXwHTCyFG = 0;

			protected const int wIrKYlGQkGnQhJZeiHBooQoVBSaP = 1;

			protected const int ABePgwKlpXGdIiNsjBRdiAIQoRlg = 2;

			protected const int VLxfVyEiIDqNQohiIJtOaPSbMxCob = 3;

			public Vector3 value => default(Vector3);

			public Vector3 valuePrev => default(Vector3);

			public IControllerTemplateAxis horizontal => null;

			public IControllerTemplateAxis vertical => null;

			public IControllerTemplateAxis depth => null;

			protected JIUakCWoogJwkBYYmbmKuaFcLoiE(IControllerTemplate_Internal P_0, int P_1, ControllerTemplateElementType P_2, VDOHtlyVpNuIyLqoCoEYCSQmofCn[] P_3, RHrJzbmIXsdYvASDPWOTfZbswxFS P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal abstract class dowibMxHfMjBcaWQBSIdSgnIhKwOA : bjdsVLzmlpRLyKjlAcmlEQQKglfS, IControllerTemplateAxis6D, IControllerTemplateElement
		{
			protected const int cBrUaghmpolIuwRmVVbVRGQWbRfz = 0;

			protected const int XevdaZHTkflCVNhVQclGmWezBKCjA = 1;

			protected const int bUwVUstoCbNxMBxCPzNRbQUxQlND = 2;

			protected const int UyoACekrWCMwOnJUZPgPvbhypaDH = 3;

			protected const int DkiunDBdEDItOhFYoxFzFlFgMnaVA = 4;

			protected const int YfDKPuYBLyktsIRJCqnvLABmNWjB = 5;

			protected const int oygXOePhAQCHmGnSEsDyZErMMYln = 6;

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

			protected dowibMxHfMjBcaWQBSIdSgnIhKwOA(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, VDOHtlyVpNuIyLqoCoEYCSQmofCn[] P_3, RHrJzbmIXsdYvASDPWOTfZbswxFS P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal sealed class xRsKOFnSiqEbapbdvxblBhKJvlbF : JIUakCWoogJwkBYYmbmKuaFcLoiE, IControllerTemplateStick, IControllerTemplateElement
		{
			private const int MbZlbtwUTmaxvmaedwNFCZGaHwq = 3;

			public IControllerTemplateAxis rotation => null;

			private xRsKOFnSiqEbapbdvxblBhKJvlbF(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, VDOHtlyVpNuIyLqoCoEYCSQmofCn[] P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}

			public xRsKOFnSiqEbapbdvxblBhKJvlbF(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, RvVLyanCokdPajbnkRIRIkwKJqbKA P_4, RvVLyanCokdPajbnkRIRIkwKJqbKA P_5, RvVLyanCokdPajbnkRIRIkwKJqbKA P_6)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal sealed class iQVJnkBUnVFmEQnUWWWwCThQPqOu : LFANnfkbVSxOFagTqCazckCnOqBVA, IControllerTemplateThumbStick, IControllerTemplateElement
		{
			private const int BwyjoOxhrAAznbWHCxUPcQjOMaS = 2;

			private const int VhGDijiSunkoRvDFALqpOCXQRzEk = 3;

			public IControllerTemplateButton press => null;

			private iQVJnkBUnVFmEQnUWWWwCThQPqOu(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, VDOHtlyVpNuIyLqoCoEYCSQmofCn[] P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}

			internal iQVJnkBUnVFmEQnUWWWwCThQPqOu(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, RvVLyanCokdPajbnkRIRIkwKJqbKA P_4, RvVLyanCokdPajbnkRIRIkwKJqbKA P_5, RvVLyanCokdPajbnkRIRIkwKJqbKA P_6)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal sealed class SGorldinAUsndEmxkppdHathEGGV : bjdsVLzmlpRLyKjlAcmlEQQKglfS, IControllerTemplateDPad, IControllerTemplateElement
		{
			private const int hoAcTbeLXMOuYYHRobelAlzfXZOw = 0;

			private const int bsfAoJHmmpUjWpsjgOvBaDEDgtfEc = 1;

			private const int XAlCxNhlndWyXetWDjwhCAQfKgLmb = 2;

			private const int KCQyIyTLIJhkPoGyqVKXCRBtperO = 3;

			private const int rODoutxrJkGUqqaTGZFrkjwteeFCA = 4;

			private const int uxTaQciHAWevXHgVITxtqHdVpruf = 5;

			public Vector2 value => default(Vector2);

			public Vector2 valuePrev => default(Vector2);

			public IControllerTemplateButton up => null;

			public IControllerTemplateButton right => null;

			public IControllerTemplateButton down => null;

			public IControllerTemplateButton left => null;

			public IControllerTemplateButton press => null;

			private SGorldinAUsndEmxkppdHathEGGV(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, VDOHtlyVpNuIyLqoCoEYCSQmofCn[] P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}

			internal SGorldinAUsndEmxkppdHathEGGV(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, RvVLyanCokdPajbnkRIRIkwKJqbKA P_4, RvVLyanCokdPajbnkRIRIkwKJqbKA P_5, RvVLyanCokdPajbnkRIRIkwKJqbKA P_6, RvVLyanCokdPajbnkRIRIkwKJqbKA P_7, RvVLyanCokdPajbnkRIRIkwKJqbKA P_8)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal sealed class ZJCeLPfsrIUrIeBzGNaWAobtbFmE : bjdsVLzmlpRLyKjlAcmlEQQKglfS, IControllerTemplateThrottle, IControllerTemplateElement
		{
			private const int ppNhmUnJqSEgQvMdDTSTJvOvDeOp = 0;

			private const int xtsVksSOMXhedDkfFBfiFWagUvTnB = 1;

			private const int nOuALJJcnkmMpkzNlgTIubiuQmXuA = 2;

			public float value => 0f;

			public float valuePrev => 0f;

			public IControllerTemplateAxis throttle => null;

			public IControllerTemplateButton minDetent => null;

			private ZJCeLPfsrIUrIeBzGNaWAobtbFmE(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, VDOHtlyVpNuIyLqoCoEYCSQmofCn[] P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}

			internal ZJCeLPfsrIUrIeBzGNaWAobtbFmE(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, RvVLyanCokdPajbnkRIRIkwKJqbKA P_4, RvVLyanCokdPajbnkRIRIkwKJqbKA P_5)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal sealed class yfyozDITuyZtXRhSRkBPgGkmFjEJ : bjdsVLzmlpRLyKjlAcmlEQQKglfS, IControllerTemplateHat, IControllerTemplateElement
		{
			private const int ozPAlRIfVUHVXueyMWtdpNXNSVyY = 0;

			private const int KVsBHCaUxtCRGdYcbyyUSvUhOsEy = 1;

			private const int UKmezUbyLJZBkcOUopUMFYXpvYNQA = 2;

			private const int FTCNMqUBffEQRfWkjxRNnhpQtbUWA = 3;

			private const int xsDiNVHaWuVfwsvkXRvSOLShbNiW = 4;

			private const int NkEzCjtnXVIoouCYrSMHLNqQpwQv = 5;

			private const int THlGXQbAJJgzfPfYRyBdMKvdHRNEb = 6;

			private const int aUNgyycRdTvUUwCjKZjRkDYmzojo = 7;

			private const int PTNCURHtSTzmkuGMvazoiJUtUIWG = 8;

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

			private yfyozDITuyZtXRhSRkBPgGkmFjEJ(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, VDOHtlyVpNuIyLqoCoEYCSQmofCn[] P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}

			internal yfyozDITuyZtXRhSRkBPgGkmFjEJ(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, RvVLyanCokdPajbnkRIRIkwKJqbKA P_4, RvVLyanCokdPajbnkRIRIkwKJqbKA P_5, RvVLyanCokdPajbnkRIRIkwKJqbKA P_6, RvVLyanCokdPajbnkRIRIkwKJqbKA P_7, RvVLyanCokdPajbnkRIRIkwKJqbKA P_8, RvVLyanCokdPajbnkRIRIkwKJqbKA P_9, RvVLyanCokdPajbnkRIRIkwKJqbKA P_10, RvVLyanCokdPajbnkRIRIkwKJqbKA P_11)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal sealed class mKpVpuCNJrnMEbmdkWRNYklkjRniA : LFANnfkbVSxOFagTqCazckCnOqBVA, IControllerTemplateYoke, IControllerTemplateElement
		{
			private const int pwsnQXCZdXPzdFyZFJpUSZVoJCbS = 2;

			public IControllerTemplateAxis rotation => null;

			public IControllerTemplateAxis pushPull => null;

			private mKpVpuCNJrnMEbmdkWRNYklkjRniA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, VDOHtlyVpNuIyLqoCoEYCSQmofCn[] P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}

			internal mKpVpuCNJrnMEbmdkWRNYklkjRniA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, RvVLyanCokdPajbnkRIRIkwKJqbKA P_4, RvVLyanCokdPajbnkRIRIkwKJqbKA P_5)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal sealed class KbmBLrcZECdfOqyEifYAADPAOosw : dowibMxHfMjBcaWQBSIdSgnIhKwOA, IControllerTemplateStick6D, IControllerTemplateElement
		{
			private const int NDWUjAzODWbhbhIKWNCZFNjQVgAG = 6;

			private KbmBLrcZECdfOqyEifYAADPAOosw(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, VDOHtlyVpNuIyLqoCoEYCSQmofCn[] P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}

			internal KbmBLrcZECdfOqyEifYAADPAOosw(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, RvVLyanCokdPajbnkRIRIkwKJqbKA P_4, RvVLyanCokdPajbnkRIRIkwKJqbKA P_5, RvVLyanCokdPajbnkRIRIkwKJqbKA P_6, RvVLyanCokdPajbnkRIRIkwKJqbKA P_7, RvVLyanCokdPajbnkRIRIkwKJqbKA P_8, RvVLyanCokdPajbnkRIRIkwKJqbKA P_9)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal class kjCDHDVKEPdQkfgBqEtkakUwFxPUA
		{
			public readonly Controller.Element pBVKCKjDyccdwFbQadgohKCVXJOW;

			public readonly IControllerElementTarget mvqAaAaiSElnMWAvqJWYgiDYlmDbb;

			public bool inhaZvSHbfWgVsdeuiyDwbrngaUgA => false;

			public bool oWWFvgFgrVFjxsDWUXqbckaJSlWoA => false;

			public bool DgjOTpuIgMapEBYwfqhKHmoqSgOF => false;

			public bool yqcFQrHQzpJpWRraajJvgyzmYAzJA => false;

			public float sWPTTcZNKyGHRjuuqjJxeuunaIuAb => 0f;

			public float KNBuJDvLOGulxLonfPMkyhJqAnOg => 0f;

			public kjCDHDVKEPdQkfgBqEtkakUwFxPUA(IControllerElementTarget P_0, Controller.Element P_1)
			{
			}

			public static kjCDHDVKEPdQkfgBqEtkakUwFxPUA TPbrqwigVHFNuipZVhicIYwhLsYOB()
			{
				return null;
			}
		}

		internal class YsWrcFqqSGghQvlmsmJmoUqYunTO
		{
			public readonly Controller IrailxBSRdQGFXroVoTZcguvjVhs;

			public readonly IHardwareControllerTemplateMap_Internal xlBvjxYERmFsIpOvHUYWpetSXvfN;

			public YsWrcFqqSGghQvlmsmJmoUqYunTO(Controller P_0, IHardwareControllerTemplateMap_Internal P_1)
			{
			}
		}

		private sealed class lLMGNZpBRqsVUGEESkaoDAoDipNR
		{
			[Serializable]
			private sealed class tlaoaoHxprYJNIDMdHYFadTKcYjv
			{
				public static readonly tlaoaoHxprYJNIDMdHYFadTKcYjv _003C_003E9;

				public static Func<RHrJzbmIXsdYvASDPWOTfZbswxFS, RHrJzbmIXsdYvASDPWOTfZbswxFS, bool> _003C_003E9__4_0;

				internal bool VLtlrLnmkHxgJnjdxwXnXrJOiQYv(RHrJzbmIXsdYvASDPWOTfZbswxFS P_0, RHrJzbmIXsdYvASDPWOTfZbswxFS P_1)
				{
					return false;
				}
			}

			private static lLMGNZpBRqsVUGEESkaoDAoDipNR jvnThuMVzXmJjmnHUeVWfAEUaxZk;

			private readonly global::FqjMmvizhiyunToVEnOzbPvoLDyB<RHrJzbmIXsdYvASDPWOTfZbswxFS> wyOpSNUCEACYtalSaJjdunvHFqMY;

			private static lLMGNZpBRqsVUGEESkaoDAoDipNR hblrFqDhMjeOgCtqtfKzJzateSGYA => null;

			private lLMGNZpBRqsVUGEESkaoDAoDipNR()
			{
			}

			private void WmLCDtmJPQukiOsCjDZeRLtYosqk()
			{
			}

			private void nBOIZDHewEqtQxXLJvHrDEoCzUMuA()
			{
			}

			public static RHrJzbmIXsdYvASDPWOTfZbswxFS VuicTeRukJGBxjMdvkUyfqZivuurA(RHrJzbmIXsdYvASDPWOTfZbswxFS P_0)
			{
				return null;
			}

			public static bool HHwLtyrBDrQFXZUYJZxhmizhrvNg(RHrJzbmIXsdYvASDPWOTfZbswxFS P_0, out RHrJzbmIXsdYvASDPWOTfZbswxFS P_1)
			{
				P_1 = null;
				return false;
			}

			public static void rvmgRpUXbOfdOPjDhDglCIDjKBkoA(RHrJzbmIXsdYvASDPWOTfZbswxFS P_0)
			{
			}
		}

		private const string sBKIhDPoPDuUlbKHmCxujkQqMuBP = "controller/template";

		private string EMCJFfUBEHGeTBhDKAxQEcPhqOSAA;

		private string UctAIDsxHHygInqdcYvwefHJrKtK;

		private int rlDiZrIWfsGJAtcMUdeZCbmWAfacA;

		private readonly Guid wSbhKVxuqCuhnPBXAdCgJtQtNRWHA;

		private readonly DeviceLocalizationInfo rqGDwvfJyWFUFYrakVTaqnJOGtTU;

		private readonly Controller khvizTtULLpIgsvmzhCBnHwjtUle;

		private readonly ADictionary<int, IControllerTemplateElement> QsOrjjwEVISOWSOItFjJMzNPvabS;

		private readonly ADictionary<string, IControllerTemplateElement> byhKRznMHwvuPqBoelrsszIKRAYj;

		private IControllerTemplateElement[] ivfJcJMcavuoUVuUuhYFNiyKQmtC;

		private ReadOnlyCollection<IControllerTemplateElement> ErpCrrzWeUIWUsBxIwCIdtlARycS;

		private readonly kHQCdvDFmtugtOEvKzWXyTgZIwTh GeTjmzTTXtsUpceJYPdAFxBtBEYP;

		private readonly int DWrOyPwpeIaRGZkiCNNUwaYsDpVfA;

		internal DeviceLocalizationInfo PzKxfqlhOjyJTfaGZBTPFtTrKzbo => null;

		DeviceLocalizationInfo IControllerTemplate_Internal.deviceLocalizationInfo => null;

		Controller IControllerTemplate.controller => null;

		string IControllerTemplate.name => null;

		Guid IControllerTemplate.typeGuid => default(Guid);

		IList<IControllerTemplateElement> IControllerTemplate.elements => null;

		int IControllerTemplate.elementCount => 0;

		string dmwPlHfCHErBELjQlGwCmsUXbNbq.keyCategory => null;

		string dmwPlHfCHErBELjQlGwCmsUXbNbq.scriptingName => null;

		string dmwPlHfCHErBELjQlGwCmsUXbNbq.nonLocalizedDescriptiveName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		string dmwPlHfCHErBELjQlGwCmsUXbNbq.key => null;

		int dmwPlHfCHErBELjQlGwCmsUXbNbq.autoGeneratedValueFlags
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

		private ControllerTemplate(YsWrcFqqSGghQvlmsmJmoUqYunTO P_0)
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

		private static IList<kjCDHDVKEPdQkfgBqEtkakUwFxPUA> SrUIXsypecPdBKYtRHwGLzvdLYoD(Controller P_0, IControllerTemplateAxisSource P_1)
		{
			return null;
		}

		private static IList<kjCDHDVKEPdQkfgBqEtkakUwFxPUA> HAKBhVCfhpnIOGuPyoJlGbSihqmg(Controller P_0, IControllerTemplateButtonSource P_1)
		{
			return null;
		}

		private static IList<kjCDHDVKEPdQkfgBqEtkakUwFxPUA> yZrGXaRIgPYoQKkJmrZWdbnytvTF(Controller P_0, IControllerElementTarget P_1)
		{
			return null;
		}

		private static IControllerTemplateElement XGUZyVLJLDaZDwDqchiKHusnOMszA(List<IControllerTemplateElement> P_0, int P_1)
		{
			return null;
		}

		private static RvVLyanCokdPajbnkRIRIkwKJqbKA jBsFloWSInnjDlmmgCcGBimLidGxA(IControllerTemplate_Internal P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			return null;
		}

		private static RvVLyanCokdPajbnkRIRIkwKJqbKA LDQscEsUcNqwDtXygPRteSLrqCfQ(IControllerTemplate_Internal P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			return null;
		}
	}
}
