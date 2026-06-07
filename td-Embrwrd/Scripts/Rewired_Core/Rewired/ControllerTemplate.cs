using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Data.Mapping;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerTemplate : IControllerTemplate, IControllerTemplate_Internal, ygnuJPyjhZTGYdIDYqMweKSjbBks
	{
		internal abstract class YyFltbbbDQKtuzibrHkoFEGSkrTYA : IControllerTemplateElement, IControllerTemplateElement_Internal
		{
			private readonly IControllerTemplate vuydwXDoYTBfQhSLOYCAJiqwsjtgA;

			private readonly int wPHnnhhHSjtbDOLMaYQAEUyiIoEg;

			private readonly ControllerTemplateElementType slwfbHtYSbxnEFgYJgHmdkXUixvl;

			protected readonly int rIeeGUEqkZNCGNXmKDxVmVRjzvoh;

			protected readonly WLidSnxDbdFpzgCOypsfxMzGTdKU kXySGKprkuIHFvirKEfBjyRPidvkA;

			public int id => 0;

			public string descriptiveName => null;

			internal string cEAhqkflmLSQRFXvKZmzukFhIMrp => null;

			public ControllerTemplateElementType type => default(ControllerTemplateElementType);

			public IControllerTemplate parent => null;

			public abstract int elementCount { get; }

			public abstract IControllerTemplateElementSource source { get; }

			public abstract bool exists { get; }

			protected YyFltbbbDQKtuzibrHkoFEGSkrTYA(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, WLidSnxDbdFpzgCOypsfxMzGTdKU P_3)
			{
			}

			public abstract IControllerTemplateElement GetElement(int index);

			public abstract int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list);

			protected static WLidSnxDbdFpzgCOypsfxMzGTdKU uTonQFkikdeAlyxMgkblWvlnnEGK(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3)
			{
				return null;
			}
		}

		internal abstract class CqIKbwpcufRJoQPtiKvmkDdpVfWk : YyFltbbbDQKtuzibrHkoFEGSkrTYA
		{
			protected readonly int vJAKadcWEfljZTABYDGRGtPkSnML;

			protected readonly tQVcDJKKmOBbefLWJTXWuGGAYzAO[] ORqaAnfGqyLdkCkAhuwPRxTPQNFkA;

			public override bool exists => false;

			protected CqIKbwpcufRJoQPtiKvmkDdpVfWk(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, IList<tQVcDJKKmOBbefLWJTXWuGGAYzAO> P_3, WLidSnxDbdFpzgCOypsfxMzGTdKU P_4)
				: base(null, 0, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal abstract class WyYecqqfOrecmVpaLQsloeaoaqygA : CqIKbwpcufRJoQPtiKvmkDdpVfWk, IControllerTemplateAxis, IControllerTemplateElement, IControllerTemplateButton
		{
			private qVrtDhCppSFJeqDjDfvjFKbIExZx AjKSZAKsXpeNRnLaJBrZYBtabcUb;

			public float EgZpaEpxDTzIIacvXyicyDDDmkkI => 0f;

			public float OELUqPvfWTzTXUBhlMLPHQykpeXk => 0f;

			public bool oFGGRdunyOCZQrUyTkpnsqRyweus => false;

			public bool ZRpcplbCSTdKQaqqMNuneDYdYuGEA => false;

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

			protected COYAhZgPuWIsuGAuJnxCICSJaVvrB qQBHDZJLeVbNSJehLSsqnCfhvqzMA => null;

			protected WyYecqqfOrecmVpaLQsloeaoaqygA(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, qVrtDhCppSFJeqDjDfvjFKbIExZx P_3, IList<tQVcDJKKmOBbefLWJTXWuGGAYzAO> P_4, COYAhZgPuWIsuGAuJnxCICSJaVvrB P_5)
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

			private static bool BiLPWCxtmHkPPzMrTUufbPeshAjiA(ControllerElementTarget P_0, IControllerElementTarget P_1)
			{
				return false;
			}
		}

		internal sealed class lFEtgZJIfVJeehAogwvaLUIrASfO : WyYecqqfOrecmVpaLQsloeaoaqygA
		{
			public lFEtgZJIfVJeehAogwvaLUIrASfO(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, string P_4, string P_5, string P_6, string P_7, qVrtDhCppSFJeqDjDfvjFKbIExZx P_8, IList<tQVcDJKKmOBbefLWJTXWuGGAYzAO> P_9)
				: base(null, 0, default(ControllerTemplateElementType), null, null, null)
			{
			}

			internal static lFEtgZJIfVJeehAogwvaLUIrASfO axfuTIzhfpMbEBpXmlfiIgribEqV(IControllerTemplate_Internal P_0)
			{
				return null;
			}
		}

		internal sealed class MTuLdIYSOHENrewehrjSkHSaenyY : WyYecqqfOrecmVpaLQsloeaoaqygA
		{
			public MTuLdIYSOHENrewehrjSkHSaenyY(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, string P_4, string P_5, string P_6, string P_7, qVrtDhCppSFJeqDjDfvjFKbIExZx P_8, IList<tQVcDJKKmOBbefLWJTXWuGGAYzAO> P_9)
				: base(null, 0, default(ControllerTemplateElementType), null, null, null)
			{
			}

			internal static MTuLdIYSOHENrewehrjSkHSaenyY TeVbDiNMfIoFzZZQvmtXrpbUHJHM(IControllerTemplate_Internal P_0)
			{
				return null;
			}
		}

		internal abstract class mKoBLFyMTeaTgkSmjKJRMaOcGpkU : YyFltbbbDQKtuzibrHkoFEGSkrTYA
		{
			protected readonly int NzAdPBFjVjwTJuHtQDpqYiHWBOmDA;

			protected readonly YyFltbbbDQKtuzibrHkoFEGSkrTYA[] BZGBxbreDHSLLshrahqSwgeIFZwB;

			public override bool exists => false;

			public override IControllerTemplateElementSource source => null;

			public override int elementCount => 0;

			protected mKoBLFyMTeaTgkSmjKJRMaOcGpkU(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, YyFltbbbDQKtuzibrHkoFEGSkrTYA[] P_3, WLidSnxDbdFpzgCOypsfxMzGTdKU P_4)
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

		internal abstract class KuBjodvwpPfkRMBODImVccQZymAj : mKoBLFyMTeaTgkSmjKJRMaOcGpkU, IControllerTemplateAxis2D, IControllerTemplateElement
		{
			protected const int MNDeLsVMXkiZnCwWxYogDPsbIPCf = 0;

			protected const int bmvkFsyCvYkiuIWNinVqTjlWYkgK = 1;

			protected const int MGmyngngyMpoWFNATBDMdtGxIDmbA = 2;

			public Vector2 value => default(Vector2);

			public Vector2 valuePrev => default(Vector2);

			public IControllerTemplateAxis horizontal => null;

			public IControllerTemplateAxis vertical => null;

			protected KuBjodvwpPfkRMBODImVccQZymAj(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, YyFltbbbDQKtuzibrHkoFEGSkrTYA[] P_3, WLidSnxDbdFpzgCOypsfxMzGTdKU P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal abstract class MrDYyOZUUhdiyhIXBBTcoDgOVZpO : mKoBLFyMTeaTgkSmjKJRMaOcGpkU, IControllerTemplateAxis3D, IControllerTemplateElement
		{
			protected const int BbILEPMNLFMXXOeNbMbIPHDnbCSW = 0;

			protected const int hnqSwjFFYLAffpRbRYtSkmqncUvq = 1;

			protected const int LUztRsTGFEbbUFKfGNbHZwYaJuacA = 2;

			protected const int IkeXyItkBAmASVdunFLuBEcqxXXC = 3;

			public Vector3 value => default(Vector3);

			public Vector3 valuePrev => default(Vector3);

			public IControllerTemplateAxis horizontal => null;

			public IControllerTemplateAxis vertical => null;

			public IControllerTemplateAxis depth => null;

			protected MrDYyOZUUhdiyhIXBBTcoDgOVZpO(IControllerTemplate_Internal P_0, int P_1, ControllerTemplateElementType P_2, YyFltbbbDQKtuzibrHkoFEGSkrTYA[] P_3, WLidSnxDbdFpzgCOypsfxMzGTdKU P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal abstract class cFlcnCcnNFKqkkIFuSuBaTxkkYxp : mKoBLFyMTeaTgkSmjKJRMaOcGpkU, IControllerTemplateAxis6D, IControllerTemplateElement
		{
			protected const int bOkmDswBwfhZgUfugXFnTOCqTcyG = 0;

			protected const int WHihyRGaWsltBfHIjlXqwPgXCYPV = 1;

			protected const int sHbwTwmBAeCkUFfgwlDxltAJUESLA = 2;

			protected const int RRfNIsjheJqhWJYGyMlvzObIopAY = 3;

			protected const int SPbfnHChoMWmIzYRJbMXnVTKhHbj = 4;

			protected const int VGCfSBHTjhJDdBmOdkQHRUMSYDNn = 5;

			protected const int vujGXkEnmNmukejLvzhYTHraaCeo = 6;

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

			protected cFlcnCcnNFKqkkIFuSuBaTxkkYxp(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, YyFltbbbDQKtuzibrHkoFEGSkrTYA[] P_3, WLidSnxDbdFpzgCOypsfxMzGTdKU P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal sealed class mAndUMimihMhkcTaAWNBBNGqdnyvb : MrDYyOZUUhdiyhIXBBTcoDgOVZpO, IControllerTemplateStick, IControllerTemplateElement
		{
			private const int JZeFhreygEwHtRFvNMFlyVPiwDdQA = 3;

			public IControllerTemplateAxis rotation => null;

			private mAndUMimihMhkcTaAWNBBNGqdnyvb(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, YyFltbbbDQKtuzibrHkoFEGSkrTYA[] P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}

			public mAndUMimihMhkcTaAWNBBNGqdnyvb(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, WyYecqqfOrecmVpaLQsloeaoaqygA P_4, WyYecqqfOrecmVpaLQsloeaoaqygA P_5, WyYecqqfOrecmVpaLQsloeaoaqygA P_6)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal sealed class lLWtgiEdRYfZMmWLnigWQOdkBsDKA : KuBjodvwpPfkRMBODImVccQZymAj, IControllerTemplateThumbStick, IControllerTemplateElement
		{
			private const int AonEwuGHDssnzkPRsEFooHKNmIntA = 2;

			private const int GlRckdjaEaYZPHYArSENGlZasdLr = 3;

			public IControllerTemplateButton press => null;

			private lLWtgiEdRYfZMmWLnigWQOdkBsDKA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, YyFltbbbDQKtuzibrHkoFEGSkrTYA[] P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}

			internal lLWtgiEdRYfZMmWLnigWQOdkBsDKA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, WyYecqqfOrecmVpaLQsloeaoaqygA P_4, WyYecqqfOrecmVpaLQsloeaoaqygA P_5, WyYecqqfOrecmVpaLQsloeaoaqygA P_6)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal sealed class VMbtIpdviLWVhkxoRLCJDGrXeSJR : mKoBLFyMTeaTgkSmjKJRMaOcGpkU, IControllerTemplateDPad, IControllerTemplateElement
		{
			private const int cEPFRfxWdNfHCqtYZTCLzxjDCBBr = 0;

			private const int mRyegFrAmgOzCSmGXDLbDKLQbfqh = 1;

			private const int ERixRumPNeFDKBLniYHlOYDwgSXc = 2;

			private const int LhNKjwQAgSBVFGxjJeYdWlHXwecJ = 3;

			private const int oEIcexycfhhluQUMtFpTwLuFeeKEA = 4;

			private const int lwKSmulSmDFTZfcCpIjPqvbpnlto = 5;

			public Vector2 value => default(Vector2);

			public Vector2 valuePrev => default(Vector2);

			public IControllerTemplateButton up => null;

			public IControllerTemplateButton right => null;

			public IControllerTemplateButton down => null;

			public IControllerTemplateButton left => null;

			public IControllerTemplateButton press => null;

			private VMbtIpdviLWVhkxoRLCJDGrXeSJR(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, YyFltbbbDQKtuzibrHkoFEGSkrTYA[] P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}

			internal VMbtIpdviLWVhkxoRLCJDGrXeSJR(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, WyYecqqfOrecmVpaLQsloeaoaqygA P_4, WyYecqqfOrecmVpaLQsloeaoaqygA P_5, WyYecqqfOrecmVpaLQsloeaoaqygA P_6, WyYecqqfOrecmVpaLQsloeaoaqygA P_7, WyYecqqfOrecmVpaLQsloeaoaqygA P_8)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal sealed class CSLYqHcuYHRrEWUOnIrIQcwHRpnw : mKoBLFyMTeaTgkSmjKJRMaOcGpkU, IControllerTemplateThrottle, IControllerTemplateElement
		{
			private const int oGIbaUoGIVDTAKLyuiazFTETAeTRA = 0;

			private const int ezpevuHoMGTndQuUiNwWMkiilTSE = 1;

			private const int oNpRIFfLKrnpVTABAndyhwqYyFAd = 2;

			public float value => 0f;

			public float valuePrev => 0f;

			public IControllerTemplateAxis throttle => null;

			public IControllerTemplateButton minDetent => null;

			private CSLYqHcuYHRrEWUOnIrIQcwHRpnw(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, YyFltbbbDQKtuzibrHkoFEGSkrTYA[] P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}

			internal CSLYqHcuYHRrEWUOnIrIQcwHRpnw(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, WyYecqqfOrecmVpaLQsloeaoaqygA P_4, WyYecqqfOrecmVpaLQsloeaoaqygA P_5)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal sealed class nQbNcVLECnqqHnpwwoUjsigUcRFbA : mKoBLFyMTeaTgkSmjKJRMaOcGpkU, IControllerTemplateHat, IControllerTemplateElement
		{
			private const int pQSbFHopZDyXHMzBhJjRJPHpZPre = 0;

			private const int TavBPSbFCawRCehTMQPoYWaBaGTf = 1;

			private const int ZbljCMzzzGoHymFcNwbeGPTBGDKG = 2;

			private const int WYNSBcZsXenPJylbQrevzvfuhQZf = 3;

			private const int maAHWLYferATeKIxgAZqMEUZbZlV = 4;

			private const int AJDYbhcInYFjyADuWsYxTmBeexLd = 5;

			private const int MLmROBRfnEIbuRHBwdDjAhLJDMuB = 6;

			private const int byCaMqdeRYilUGxidIZhaICQPmiM = 7;

			private const int ESGMQZAaqAyKyGTJYVWOsUQBQuTk = 8;

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

			private nQbNcVLECnqqHnpwwoUjsigUcRFbA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, YyFltbbbDQKtuzibrHkoFEGSkrTYA[] P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}

			internal nQbNcVLECnqqHnpwwoUjsigUcRFbA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, WyYecqqfOrecmVpaLQsloeaoaqygA P_4, WyYecqqfOrecmVpaLQsloeaoaqygA P_5, WyYecqqfOrecmVpaLQsloeaoaqygA P_6, WyYecqqfOrecmVpaLQsloeaoaqygA P_7, WyYecqqfOrecmVpaLQsloeaoaqygA P_8, WyYecqqfOrecmVpaLQsloeaoaqygA P_9, WyYecqqfOrecmVpaLQsloeaoaqygA P_10, WyYecqqfOrecmVpaLQsloeaoaqygA P_11)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal sealed class jzalHcRIbkxQSXjsHrfjQQpYDQyJ : KuBjodvwpPfkRMBODImVccQZymAj, IControllerTemplateYoke, IControllerTemplateElement
		{
			private const int yxrAxPTsVOIWtrJKuRycWpBUKpsF = 2;

			public IControllerTemplateAxis rotation => null;

			public IControllerTemplateAxis pushPull => null;

			private jzalHcRIbkxQSXjsHrfjQQpYDQyJ(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, YyFltbbbDQKtuzibrHkoFEGSkrTYA[] P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}

			internal jzalHcRIbkxQSXjsHrfjQQpYDQyJ(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, WyYecqqfOrecmVpaLQsloeaoaqygA P_4, WyYecqqfOrecmVpaLQsloeaoaqygA P_5)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal sealed class JlzHNbfJoLPSIKeNJgekBSBekqxGb : cFlcnCcnNFKqkkIFuSuBaTxkkYxp, IControllerTemplateStick6D, IControllerTemplateElement
		{
			private const int AgPfEvFouJBGjiRXDhtruJVPgXTJc = 6;

			private JlzHNbfJoLPSIKeNJgekBSBekqxGb(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, YyFltbbbDQKtuzibrHkoFEGSkrTYA[] P_4)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}

			internal JlzHNbfJoLPSIKeNJgekBSBekqxGb(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, WyYecqqfOrecmVpaLQsloeaoaqygA P_4, WyYecqqfOrecmVpaLQsloeaoaqygA P_5, WyYecqqfOrecmVpaLQsloeaoaqygA P_6, WyYecqqfOrecmVpaLQsloeaoaqygA P_7, WyYecqqfOrecmVpaLQsloeaoaqygA P_8, WyYecqqfOrecmVpaLQsloeaoaqygA P_9)
				: base(null, 0, default(ControllerTemplateElementType), null, null)
			{
			}
		}

		internal class tQVcDJKKmOBbefLWJTXWuGGAYzAO
		{
			public readonly Controller.Element mAGXOAsQOdhRaKxXFfSCTfUlGZVTA;

			public readonly IControllerElementTarget tytqkGjokZSVYewGFsnskTSomtYd;

			public bool lzsRkbVDHaGpHbOvBiQxVwnLsuBFA => false;

			public bool zDJlkCbVEgYdMvFxgWHbuqdzpHZb => false;

			public bool STkXMjnFoVLVAjVTCkCyVsaEnODt => false;

			public bool dfKhvZgTgUxKtftHlEBgwhMUHcI => false;

			public float vWYDHeSKcfepPIjjJihRqZgXtYnq => 0f;

			public float TiOriJkLoPQBflPuAdhOeiVSgKVoA => 0f;

			public tQVcDJKKmOBbefLWJTXWuGGAYzAO(IControllerElementTarget P_0, Controller.Element P_1)
			{
			}

			public static tQVcDJKKmOBbefLWJTXWuGGAYzAO CkeogwxpxAyxoXnKsUIUIaqlfuDR()
			{
				return null;
			}
		}

		internal class XhLkXPbKyJUWWVTxNfOSkuwivCGm
		{
			public readonly Controller DzbxktAapiEvHlJbainpiqmNSBeuA;

			public readonly IHardwareControllerTemplateMap_Internal wQYkdpJmjneHENTuecsmIlpeKfcZ;

			public XhLkXPbKyJUWWVTxNfOSkuwivCGm(Controller P_0, IHardwareControllerTemplateMap_Internal P_1)
			{
			}
		}

		private sealed class qGDUUDmWdhbNQwjFbMGIVOolUlKV
		{
			[Serializable]
			private sealed class irnRagGQJgjvLyvVEkuxqNVwBMsx
			{
				public static readonly irnRagGQJgjvLyvVEkuxqNVwBMsx _003C_003E9;

				public static Func<WLidSnxDbdFpzgCOypsfxMzGTdKU, WLidSnxDbdFpzgCOypsfxMzGTdKU, bool> _003C_003E9__4_0;

				internal bool AoodaDczKEFQJXdqICnVDLHsHUDx(WLidSnxDbdFpzgCOypsfxMzGTdKU P_0, WLidSnxDbdFpzgCOypsfxMzGTdKU P_1)
				{
					return false;
				}
			}

			private static qGDUUDmWdhbNQwjFbMGIVOolUlKV cbcrWyBaRSsPtEJEdOZihRIwcqAG;

			private readonly global::GaiDWqabXbzXglrllPZmxbNMxNYcA<WLidSnxDbdFpzgCOypsfxMzGTdKU> feZhtZPRqLCjlWaZLyVJmXvzSiDO;

			private static qGDUUDmWdhbNQwjFbMGIVOolUlKV gIoVFuAloadTywPdUakVvNqDSGZK => null;

			private qGDUUDmWdhbNQwjFbMGIVOolUlKV()
			{
			}

			private void PDSDNjjwbDxZkoLRSslCZtrkasvL()
			{
			}

			private void sLIJXMvCJGCOgrIGizLWGaOoWFOc()
			{
			}

			public static WLidSnxDbdFpzgCOypsfxMzGTdKU OzpDkHSGFKcfleiIKqCCgJWUgChd(WLidSnxDbdFpzgCOypsfxMzGTdKU P_0)
			{
				return null;
			}

			public static bool EOfVReukpwglZhQZqgnVoitDnrKx(WLidSnxDbdFpzgCOypsfxMzGTdKU P_0, out WLidSnxDbdFpzgCOypsfxMzGTdKU P_1)
			{
				P_1 = null;
				return false;
			}

			public static void sxdFnbDBXVcSOdFMKTWJOZLZbJxS(WLidSnxDbdFpzgCOypsfxMzGTdKU P_0)
			{
			}
		}

		private const string tkBajFQfzWFdthTEFTHAuzKOLqKCA = "controller/template";

		private string FgHmHtJyiKhRDzHMlVJokzVFrKXm;

		private string RNqkILtKpQpBYXgePGoYjgZvDtkrA;

		private int uEYKabLNNnffGiHVdQGvCGwBgtlyB;

		private readonly Guid hxqSpRwBWRhStlhIvuvKheYTdTFW;

		private readonly DeviceLocalizationInfo wtRcsvwGGBGfFgwpLAzYmMDqFrYJA;

		private readonly Controller lCwYyLgakYkCwSAoGdPtefPDNtayA;

		private readonly ADictionary<int, IControllerTemplateElement> FHDfxjfHvXfTAcnDILhpCqPvefoK;

		private readonly ADictionary<string, IControllerTemplateElement> segoSdgNrbBMFUsfDcFYaaAeaXBLA;

		private IControllerTemplateElement[] thsUVPBVIiLJIjOvXIPfNyiyPGiV;

		private ReadOnlyCollection<IControllerTemplateElement> RIeetxejOXUjUKyizhsslUpoEanU;

		private readonly tiNBYbYMraZDnyWczeThmkcdcMCM NiIAcpIMtsSjpOKUpxHeTuZRMWRl;

		private readonly int ADaeKHtVCRcOOfDnvnFaabEAHjCu;

		internal DeviceLocalizationInfo WMZvzyeogeVVJZDLuHzlRGNJjbwz => null;

		DeviceLocalizationInfo IControllerTemplate_Internal.deviceLocalizationInfo => null;

		Controller IControllerTemplate.controller => null;

		string IControllerTemplate.name => null;

		Guid IControllerTemplate.typeGuid => default(Guid);

		IList<IControllerTemplateElement> IControllerTemplate.elements => null;

		int IControllerTemplate.elementCount => 0;

		string ygnuJPyjhZTGYdIDYqMweKSjbBks.keyCategory => null;

		string ygnuJPyjhZTGYdIDYqMweKSjbBks.scriptingName => null;

		string ygnuJPyjhZTGYdIDYqMweKSjbBks.nonLocalizedDescriptiveName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		string ygnuJPyjhZTGYdIDYqMweKSjbBks.key => null;

		int ygnuJPyjhZTGYdIDYqMweKSjbBks.autoGeneratedValueFlags
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

		private ControllerTemplate(XhLkXPbKyJUWWVTxNfOSkuwivCGm P_0)
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

		private static IList<tQVcDJKKmOBbefLWJTXWuGGAYzAO> JlPnMwjHEnUgDyRewIxyBttBjDnU(Controller P_0, IControllerTemplateAxisSource P_1)
		{
			return null;
		}

		private static IList<tQVcDJKKmOBbefLWJTXWuGGAYzAO> MBXXXDLUTgbMGgXUFQYVGQSIatps(Controller P_0, IControllerTemplateButtonSource P_1)
		{
			return null;
		}

		private static IList<tQVcDJKKmOBbefLWJTXWuGGAYzAO> lSepCsCNYCknGmlMRVJcfcjManMJA(Controller P_0, IControllerElementTarget P_1)
		{
			return null;
		}

		private static IControllerTemplateElement ELXyFLQxtCqGXKxWPWJgaayFQjrc(List<IControllerTemplateElement> P_0, int P_1)
		{
			return null;
		}

		private static WyYecqqfOrecmVpaLQsloeaoaqygA eslEjuNLwwkUPLXtJGuqegublvBk(IControllerTemplate_Internal P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			return null;
		}

		private static WyYecqqfOrecmVpaLQsloeaoaqygA SsFqBMzNUYFuTVJxTheDijPRDYkK(IControllerTemplate_Internal P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			return null;
		}
	}
}
