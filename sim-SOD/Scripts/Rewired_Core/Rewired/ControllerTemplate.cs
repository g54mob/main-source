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
		internal abstract class cjBQtkVwwUVCJVeUcRUBvecgkrv : IControllerTemplateElement, IControllerTemplateElement_Internal
		{
			private readonly IControllerTemplate fMdHWLVUiLPbjetAYCnsIeSxnvw;

			private readonly int ZjhenRHxqNuSrgJhTzeCvEoySmU;

			private readonly string kmeYsmlXepROQEFJNIgdaFZxzqM;

			private readonly ControllerTemplateElementType WwGNBcAzyQKiegnejLCVExHzkIt;

			protected readonly int RSGBQYfltigFuhDMRviugFIbvohH;

			public int id => 0;

			public string descriptiveName => null;

			public ControllerTemplateElementType type => default(ControllerTemplateElementType);

			public IControllerTemplate parent => null;

			public abstract int elementCount { get; }

			public abstract IControllerTemplateElementSource source { get; }

			public abstract bool exists { get; }

			protected cjBQtkVwwUVCJVeUcRUBvecgkrv(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType)
			{
			}

			public abstract IControllerTemplateElement GetElement(int index);

			public abstract int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list);
		}

		internal abstract class ukOzrHPJOztBlaUivfRnNTLBVsl : cjBQtkVwwUVCJVeUcRUBvecgkrv
		{
			protected readonly int zMKUHPWsmDESzNzbIPwPdHSbzQg;

			protected readonly VNFkzCmkLKXfTfNrUuxnTScerYw[] nzBcFYApRptBHUuqKNwHECorRofl;

			public override bool exists => false;

			protected ukOzrHPJOztBlaUivfRnNTLBVsl(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, IList<VNFkzCmkLKXfTfNrUuxnTScerYw> sourceElements)
				: base(null, 0, null, default(ControllerTemplateElementType))
			{
			}
		}

		internal abstract class mdGPibIdxjeIBtKXKCPEjVGAGsMz : ukOzrHPJOztBlaUivfRnNTLBVsl, IControllerTemplateElement, IControllerTemplateAxis, IControllerTemplateButton
		{
			private WEjbSeiFAGihJGQWKjQAhkLgezjp TMqETCLpkbBCuMSaJPdPmcozsT;

			private string zQyisTqeMvRlofdweHovEdwIYQU;

			private string hQkeLlBIyiFbfbLBdfVEPBhCZnLA;

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

			protected mdGPibIdxjeIBtKXKCPEjVGAGsMz(IControllerTemplate parent, int id, string name, string positiveName, string negativeName, ControllerTemplateElementType elementType, WEjbSeiFAGihJGQWKjQAhkLgezjp target, IList<VNFkzCmkLKXfTfNrUuxnTScerYw> sourceElements)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}

			private string YhDZTGiVJKKNBBfmiaEBqSswSer(AxisRange P_0)
			{
				return null;
			}

			string IControllerTemplateAxis.GetDescriptiveName(AxisRange P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in YhDZTGiVJKKNBBfmiaEBqSswSer
				return this.YhDZTGiVJKKNBBfmiaEBqSswSer(P_0);
			}

			public override IControllerTemplateElement GetElement(int index)
			{
				return null;
			}

			public override int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list)
			{
				return 0;
			}

			private static bool GRxGRWCfXxbydyeslyrmBsvAYXVh(ControllerElementTarget P_0, IControllerElementTarget P_1)
			{
				return false;
			}
		}

		internal sealed class XcWiTGfnCPtWLTFFnWIDmomZZYXs : mdGPibIdxjeIBtKXKCPEjVGAGsMz
		{
			public XcWiTGfnCPtWLTFFnWIDmomZZYXs(IControllerTemplate parent, int id, string name, string positiveName, string negativeName, WEjbSeiFAGihJGQWKjQAhkLgezjp target, IList<VNFkzCmkLKXfTfNrUuxnTScerYw> sourceElements)
				: base(null, 0, null, null, null, default(ControllerTemplateElementType), null, null)
			{
			}

			internal static XcWiTGfnCPtWLTFFnWIDmomZZYXs wxbBMWuFAZRbqUPnPEfhFUkMxnX(IControllerTemplate P_0)
			{
				return null;
			}
		}

		internal sealed class qlmkQTyMvPQvEOQFkiAnZOkYxzE : mdGPibIdxjeIBtKXKCPEjVGAGsMz
		{
			public qlmkQTyMvPQvEOQFkiAnZOkYxzE(IControllerTemplate parent, int id, string name, string positiveName, string negativeName, WEjbSeiFAGihJGQWKjQAhkLgezjp target, IList<VNFkzCmkLKXfTfNrUuxnTScerYw> sourceElements)
				: base(null, 0, null, null, null, default(ControllerTemplateElementType), null, null)
			{
			}

			internal static qlmkQTyMvPQvEOQFkiAnZOkYxzE wxbBMWuFAZRbqUPnPEfhFUkMxnX(IControllerTemplate P_0)
			{
				return null;
			}
		}

		internal abstract class QqqacKCoeseALGWXqxzklheKFlE : cjBQtkVwwUVCJVeUcRUBvecgkrv
		{
			protected readonly int iYAFqnIdyjAzlclAedBLsssujGGB;

			protected readonly cjBQtkVwwUVCJVeUcRUBvecgkrv[] ghELxvZccxyBcQOFxgfvOmJJMwd;

			public override bool exists => false;

			public override IControllerTemplateElementSource source => null;

			public override int elementCount => 0;

			protected QqqacKCoeseALGWXqxzklheKFlE(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, cjBQtkVwwUVCJVeUcRUBvecgkrv[] elements)
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

		internal abstract class mgZWviBbUXPsqwcnUIpiJuwzcTc : QqqacKCoeseALGWXqxzklheKFlE, IControllerTemplateElement, IControllerTemplateAxis2D
		{
			protected const int GkjFYsbKYXmkVmQfwblBAHZcIgdx = 0;

			protected const int lRmAtBJWWcpDEegizFgfziFqyLF = 1;

			protected const int QINsPPhPaIfcIJqDrLJMiHobgpwc = 2;

			public Vector2 value => default(Vector2);

			public Vector2 valuePrev => default(Vector2);

			public IControllerTemplateAxis horizontal => null;

			public IControllerTemplateAxis vertical => null;

			protected mgZWviBbUXPsqwcnUIpiJuwzcTc(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, cjBQtkVwwUVCJVeUcRUBvecgkrv[] elements)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal abstract class yPBALLkntbMGVRTwWmuFaDUoURRe : QqqacKCoeseALGWXqxzklheKFlE, IControllerTemplateElement, IControllerTemplateAxis3D
		{
			protected const int GkjFYsbKYXmkVmQfwblBAHZcIgdx = 0;

			protected const int lRmAtBJWWcpDEegizFgfziFqyLF = 1;

			protected const int zVBMprzlcVvsdfgzwbvkxpmxWLR = 2;

			protected const int QINsPPhPaIfcIJqDrLJMiHobgpwc = 3;

			public Vector3 value => default(Vector3);

			public Vector3 valuePrev => default(Vector3);

			public IControllerTemplateAxis horizontal => null;

			public IControllerTemplateAxis vertical => null;

			public IControllerTemplateAxis depth => null;

			protected yPBALLkntbMGVRTwWmuFaDUoURRe(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, cjBQtkVwwUVCJVeUcRUBvecgkrv[] elements)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal abstract class WwvMcPAVgHUoLAiszBDuDYLStWR : QqqacKCoeseALGWXqxzklheKFlE, IControllerTemplateElement, IControllerTemplateAxis6D
		{
			protected const int qfLtLcOAesKHSoMhFQJREXCpyqX = 0;

			protected const int vnCnZBnjUOfhoZOuzchyDBmOuWZ = 1;

			protected const int YNwvVdzoTZveEwLrzcEbRZpPHrI = 2;

			protected const int fImkukBmiaWVCevkmvDRPuePadJ = 3;

			protected const int UiRcBmIjqTyYbGUuoCQhxPPAhzAA = 4;

			protected const int CDoEIXChvtJErAzRixUCapbBjfZL = 5;

			protected const int QINsPPhPaIfcIJqDrLJMiHobgpwc = 6;

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

			protected WwvMcPAVgHUoLAiszBDuDYLStWR(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, cjBQtkVwwUVCJVeUcRUBvecgkrv[] elements)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal sealed class QivYjJOaNxQHJdsHJmsyugaBifS : yPBALLkntbMGVRTwWmuFaDUoURRe, IControllerTemplateElement, IControllerTemplateStick
		{
			private new const int QINsPPhPaIfcIJqDrLJMiHobgpwc = 3;

			public IControllerTemplateAxis rotation => null;

			private QivYjJOaNxQHJdsHJmsyugaBifS(IControllerTemplate parent, int id, string name, cjBQtkVwwUVCJVeUcRUBvecgkrv[] elements)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}

			public QivYjJOaNxQHJdsHJmsyugaBifS(IControllerTemplate parent, int id, string name, mdGPibIdxjeIBtKXKCPEjVGAGsMz xAxis, mdGPibIdxjeIBtKXKCPEjVGAGsMz yAxis, mdGPibIdxjeIBtKXKCPEjVGAGsMz zAxis)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal sealed class DxCGCxsXkQzRnQUyePCfxQPMwev : mgZWviBbUXPsqwcnUIpiJuwzcTc, IControllerTemplateElement, IControllerTemplateThumbStick
		{
			private const int UhEBoiNHWdvMlqoPYxahpqvSBid = 2;

			private new const int QINsPPhPaIfcIJqDrLJMiHobgpwc = 3;

			public IControllerTemplateButton press => null;

			private DxCGCxsXkQzRnQUyePCfxQPMwev(IControllerTemplate parent, int id, string name, cjBQtkVwwUVCJVeUcRUBvecgkrv[] elements)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}

			internal DxCGCxsXkQzRnQUyePCfxQPMwev(IControllerTemplate parent, int id, string name, mdGPibIdxjeIBtKXKCPEjVGAGsMz xAxis, mdGPibIdxjeIBtKXKCPEjVGAGsMz yAxis, mdGPibIdxjeIBtKXKCPEjVGAGsMz button)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal sealed class zszaWwDvXLqeMGlZUCykoyRvYwr : QqqacKCoeseALGWXqxzklheKFlE, IControllerTemplateElement, IControllerTemplateDPad
		{
			private const int UeMolfauodMdlnRJGhlJQWaEOgT = 0;

			private const int RsEiFxUHKYNlzxHsgchReFQeULqr = 1;

			private const int nPKdwRiMXRhrmzpPohPLGudNFPV = 2;

			private const int NKwvaRbKbJaEonDckFmbkioJoLx = 3;

			private const int nBaTncvmfDLylxcFdgEGXsMToil = 4;

			private const int QINsPPhPaIfcIJqDrLJMiHobgpwc = 5;

			public Vector2 value => default(Vector2);

			public Vector2 valuePrev => default(Vector2);

			public IControllerTemplateButton up => null;

			public IControllerTemplateButton right => null;

			public IControllerTemplateButton down => null;

			public IControllerTemplateButton left => null;

			public IControllerTemplateButton press => null;

			private zszaWwDvXLqeMGlZUCykoyRvYwr(IControllerTemplate parent, int id, string name, cjBQtkVwwUVCJVeUcRUBvecgkrv[] elements)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}

			internal zszaWwDvXLqeMGlZUCykoyRvYwr(IControllerTemplate parent, int id, string name, mdGPibIdxjeIBtKXKCPEjVGAGsMz up, mdGPibIdxjeIBtKXKCPEjVGAGsMz right, mdGPibIdxjeIBtKXKCPEjVGAGsMz down, mdGPibIdxjeIBtKXKCPEjVGAGsMz left, mdGPibIdxjeIBtKXKCPEjVGAGsMz press)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal sealed class grTaBSWvfNgHvgsbyHSlZvYhGvLK : QqqacKCoeseALGWXqxzklheKFlE, IControllerTemplateElement, IControllerTemplateThrottle
		{
			private const int jagMVcMhADgFaaQWONkdDOxsnPlW = 0;

			private const int yaVBalOMhBstCccWsejeGhypQmn = 1;

			private const int QINsPPhPaIfcIJqDrLJMiHobgpwc = 2;

			public float value => 0f;

			public float valuePrev => 0f;

			public IControllerTemplateAxis throttle => null;

			public IControllerTemplateButton minDetent => null;

			private grTaBSWvfNgHvgsbyHSlZvYhGvLK(IControllerTemplate parent, int id, string name, cjBQtkVwwUVCJVeUcRUBvecgkrv[] elements)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}

			internal grTaBSWvfNgHvgsbyHSlZvYhGvLK(IControllerTemplate parent, int id, string name, mdGPibIdxjeIBtKXKCPEjVGAGsMz axis, mdGPibIdxjeIBtKXKCPEjVGAGsMz zeroDetentButton)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal sealed class PUbiNKlYvxNKgPNNhgxOPAWezHt : QqqacKCoeseALGWXqxzklheKFlE, IControllerTemplateElement, IControllerTemplateHat
		{
			private const int UeMolfauodMdlnRJGhlJQWaEOgT = 0;

			private const int aSmXISuClJZaYrLLCMALaeiCqSY = 1;

			private const int RsEiFxUHKYNlzxHsgchReFQeULqr = 2;

			private const int RfqgBdnEcNmyZKRRdjHoONxyyIL = 3;

			private const int nPKdwRiMXRhrmzpPohPLGudNFPV = 4;

			private const int DKoStpbihlcfDboQyXscLCgpPMFj = 5;

			private const int NKwvaRbKbJaEonDckFmbkioJoLx = 6;

			private const int eNPPtHtcFeZKANdlglOIFlpTfkD = 7;

			private const int QINsPPhPaIfcIJqDrLJMiHobgpwc = 8;

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

			private PUbiNKlYvxNKgPNNhgxOPAWezHt(IControllerTemplate parent, int id, string name, cjBQtkVwwUVCJVeUcRUBvecgkrv[] elements)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}

			internal PUbiNKlYvxNKgPNNhgxOPAWezHt(IControllerTemplate parent, int id, string name, mdGPibIdxjeIBtKXKCPEjVGAGsMz up, mdGPibIdxjeIBtKXKCPEjVGAGsMz upRight, mdGPibIdxjeIBtKXKCPEjVGAGsMz right, mdGPibIdxjeIBtKXKCPEjVGAGsMz downRight, mdGPibIdxjeIBtKXKCPEjVGAGsMz down, mdGPibIdxjeIBtKXKCPEjVGAGsMz downLeft, mdGPibIdxjeIBtKXKCPEjVGAGsMz left, mdGPibIdxjeIBtKXKCPEjVGAGsMz upLeft)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal sealed class NgwMhFzSsgPlCbXcAWCchVaqLUS : mgZWviBbUXPsqwcnUIpiJuwzcTc, IControllerTemplateElement, IControllerTemplateYoke
		{
			private new const int QINsPPhPaIfcIJqDrLJMiHobgpwc = 2;

			public IControllerTemplateAxis rotation => null;

			public IControllerTemplateAxis pushPull => null;

			private NgwMhFzSsgPlCbXcAWCchVaqLUS(IControllerTemplate parent, int id, string name, cjBQtkVwwUVCJVeUcRUBvecgkrv[] elements)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}

			internal NgwMhFzSsgPlCbXcAWCchVaqLUS(IControllerTemplate parent, int id, string name, mdGPibIdxjeIBtKXKCPEjVGAGsMz rollAxis, mdGPibIdxjeIBtKXKCPEjVGAGsMz pitchAxis)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal sealed class jAbqyyVDJNdmtcvgYaFNbRdAwcX : WwvMcPAVgHUoLAiszBDuDYLStWR, IControllerTemplateElement, IControllerTemplateStick6D
		{
			private new const int QINsPPhPaIfcIJqDrLJMiHobgpwc = 6;

			private jAbqyyVDJNdmtcvgYaFNbRdAwcX(IControllerTemplate parent, int id, string name, cjBQtkVwwUVCJVeUcRUBvecgkrv[] elements)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}

			internal jAbqyyVDJNdmtcvgYaFNbRdAwcX(IControllerTemplate parent, int id, string name, mdGPibIdxjeIBtKXKCPEjVGAGsMz positionX, mdGPibIdxjeIBtKXKCPEjVGAGsMz positionY, mdGPibIdxjeIBtKXKCPEjVGAGsMz positionZ, mdGPibIdxjeIBtKXKCPEjVGAGsMz rotationX, mdGPibIdxjeIBtKXKCPEjVGAGsMz rotationY, mdGPibIdxjeIBtKXKCPEjVGAGsMz rotationZ)
				: base(null, 0, null, default(ControllerTemplateElementType), null)
			{
			}
		}

		internal class VNFkzCmkLKXfTfNrUuxnTScerYw
		{
			public readonly Controller.Element XrwfZuHOqgohwdZSTthJIzdewzjI;

			public readonly IControllerElementTarget BaTtacyeRYNBocHXDZsGDxVdgZg;

			public bool boolValue => false;

			public bool boolValuePrev => false;

			public bool justPressed => false;

			public bool justReleased => false;

			public float floatValue => 0f;

			public float floatValuePrev => 0f;

			public VNFkzCmkLKXfTfNrUuxnTScerYw(IControllerElementTarget target, Controller.Element element)
			{
			}

			public static VNFkzCmkLKXfTfNrUuxnTScerYw wxbBMWuFAZRbqUPnPEfhFUkMxnX()
			{
				return null;
			}
		}

		internal class nuVdHULyPRgyxrVGADGfNzACqzs
		{
			public readonly Controller JaRyOXCWYfSQVfjQWFnXCyNiyKv;

			public readonly IHardwareControllerTemplateMap_Internal WWrEJxiVlUinsCxXChOAoGxwTqNt;

			public nuVdHULyPRgyxrVGADGfNzACqzs(Controller controller, IHardwareControllerTemplateMap_Internal templateMap)
			{
			}
		}

		private readonly string kmeYsmlXepROQEFJNIgdaFZxzqM;

		private readonly Guid ZBvpWoOedhqGructKPkxYtClfda;

		private readonly Controller tpqKoykKcOLYkAdTxfptCxwOTbTu;

		private readonly ADictionary<int, IControllerTemplateElement> SloGMdpCSGGrMAfOKbDqBgMMPSwV;

		private readonly ADictionary<string, IControllerTemplateElement> obDlvQIhVvSnaSmzxxiGhVzLWTJ;

		private IControllerTemplateElement[] ghELxvZccxyBcQOFxgfvOmJJMwd;

		private ReadOnlyCollection<IControllerTemplateElement> UQBunaqbqSHfKmADyxRGWCRFoPU;

		private readonly int RSGBQYfltigFuhDMRviugFIbvohH;

		Controller IControllerTemplate.controller => null;

		string IControllerTemplate.name => null;

		Guid IControllerTemplate.typeGuid => default(Guid);

		IList<IControllerTemplateElement> IControllerTemplate.elements => null;

		int IControllerTemplate.elementCount => 0;

		protected ControllerTemplate(object payload)
		{
		}

		private ControllerTemplate(nuVdHULyPRgyxrVGADGfNzACqzs initializer)
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

		private IControllerTemplateElement nLHZVzIGuhbzhvcEvfMXlfeBpKl(int P_0)
		{
			return null;
		}

		IControllerTemplateElement IControllerTemplate.GetElement(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in nLHZVzIGuhbzhvcEvfMXlfeBpKl
			return this.nLHZVzIGuhbzhvcEvfMXlfeBpKl(P_0);
		}

		private T nLHZVzIGuhbzhvcEvfMXlfeBpKl<T>(int P_0) where T : class, IControllerTemplateElement
		{
			return null;
		}

		T IControllerTemplate.GetElement<T>(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in nLHZVzIGuhbzhvcEvfMXlfeBpKl
			return this.nLHZVzIGuhbzhvcEvfMXlfeBpKl<T>(P_0);
		}

		private int wulALrWMrXcNAHZMWpvEQHujVVra(ControllerElementTarget P_0, IList<ControllerTemplateElementTarget> P_1)
		{
			return 0;
		}

		int IControllerTemplate.GetElementTargets(ControllerElementTarget P_0, IList<ControllerTemplateElementTarget> P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in wulALrWMrXcNAHZMWpvEQHujVVra
			return this.wulALrWMrXcNAHZMWpvEQHujVVra(P_0, P_1);
		}

		private int yuxYLOJuSULZuYunPdxEznxndbG(ControllerElementTarget P_0, ref IList<ControllerTemplateElementTarget> P_1)
		{
			return 0;
		}

		[CustomObfuscation(rename = false)]
		internal static Type GetInterfaceType(ControllerTemplateElementType elementType)
		{
			return null;
		}

		private static IList<VNFkzCmkLKXfTfNrUuxnTScerYw> DzQpjotwfVgzHAGmGvKlqxEwRyo(Controller P_0, IControllerTemplateAxisSource P_1)
		{
			return null;
		}

		private static IList<VNFkzCmkLKXfTfNrUuxnTScerYw> DzQpjotwfVgzHAGmGvKlqxEwRyo(Controller P_0, IControllerTemplateButtonSource P_1)
		{
			return null;
		}

		private static IList<VNFkzCmkLKXfTfNrUuxnTScerYw> DzQpjotwfVgzHAGmGvKlqxEwRyo(Controller P_0, IControllerElementTarget P_1)
		{
			return null;
		}

		private static IControllerTemplateElement jOTZYhaRTkESqoRklsmyQGfNdZg(List<IControllerTemplateElement> P_0, int P_1)
		{
			return null;
		}

		private static mdGPibIdxjeIBtKXKCPEjVGAGsMz YpepFIMEvoRKqTlspvdwGlzgLvH(IControllerTemplate P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			return null;
		}

		private static mdGPibIdxjeIBtKXKCPEjVGAGsMz banLZPZVyjSXTEzSLqWmNqmdMZs(IControllerTemplate P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			return null;
		}
	}
}
