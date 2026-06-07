using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public class PlayerController : IPlayerController
	{
		public class Definition
		{
			public bool enabled;

			public int playerId;

			public ICollection<Element.Definition> elements;
		}

		public static class Factory
		{
			public static PlayerController Create(Definition definition)
			{
				return null;
			}
		}

		public class Axis : ElementWithSource
		{
			public new class Definition : ElementWithSource.Definition
			{
				public AxisCoordinateMode coordinateMode;

				public float absoluteToRelativeSensitivity;

				internal override Element AyzbqKXoiIAsmtBrFwHcroNIERsg(PlayerController P_0)
				{
					return null;
				}
			}

			internal const float qPCOvYDSlUjWBxYNrOOgLxzPbptD = 1f;

			[CustomObfuscation]
			internal const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Absolute;

			private float xUxCcWyVGFihlQamzXrgHckdUJcY;

			private AxisCoordinateMode BMcobjmjHTLggNNyfOMkSqmwWrQO;

			public float absoluteToRelativeSensitivity
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public AxisCoordinateMode coordinateMode => default(AxisCoordinateMode);

			public virtual float value => 0f;

			public virtual float valueRaw => 0f;

			internal Axis(PlayerController P_0, Definition P_1)
				: base(null, null)
			{
			}
		}

		public class MouseAxis : Axis
		{
			public new class Definition : Axis.Definition
			{
				internal override Element AyzbqKXoiIAsmtBrFwHcroNIERsg(PlayerController P_0)
				{
					return null;
				}
			}

			[CustomObfuscation]
			internal new const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Relative;

			[CustomObfuscation]
			internal const float defaultAbsoluteToRelativeSensitivity = 600f;

			public override float value => 0f;

			internal MouseAxis(PlayerController P_0, Definition P_1)
				: base(null, null)
			{
			}
		}

		public class Axis2D : CompoundElement
		{
			public new class Definition : CompoundElement.Definition
			{
				private Axis.Definition lMaImMvDFjePdKTitSLtLPPEvZJP;

				private Axis.Definition typAojquHuySEkCnukGlcsTlLXGh;

				public Axis.Definition xAxis
				{
					get
					{
						return null;
					}
					set
					{
					}
				}

				public Axis.Definition yAxis
				{
					get
					{
						return null;
					}
					set
					{
					}
				}

				internal override Element AyzbqKXoiIAsmtBrFwHcroNIERsg(PlayerController P_0)
				{
					return null;
				}
			}

			internal const int JKBReHOaFzWpyjqwhKkYsdYexEJi = 0;

			internal const int RsUEyOrIEAdgNdMsNlvgyfTYgRVT = 1;

			internal const int LldlRtxxxfHaDraqUBjJFnJlWYnK = 2;

			public Axis xAxis => null;

			public Axis yAxis => null;

			public virtual Vector2 value => default(Vector2);

			public virtual Vector2 valueRaw => default(Vector2);

			internal Axis2D(PlayerController P_0, Definition P_1, Element.Definition[] P_2)
				: base(null, null, null)
			{
			}

			internal Axis2D(PlayerController P_0, Definition P_1)
				: base(null, null, null)
			{
			}
		}

		public sealed class MouseAxis2D : Axis2D
		{
			public new class Definition : Axis2D.Definition
			{
				public new MouseAxis.Definition xAxis
				{
					get
					{
						return null;
					}
					set
					{
					}
				}

				public new MouseAxis.Definition yAxis
				{
					get
					{
						return null;
					}
					set
					{
					}
				}

				internal override Element AyzbqKXoiIAsmtBrFwHcroNIERsg(PlayerController P_0)
				{
					return null;
				}
			}

			public new MouseAxis xAxis => null;

			public new MouseAxis yAxis => null;

			internal MouseAxis2D(PlayerController P_0, Definition P_1)
				: base(null, null, null)
			{
			}
		}

		public sealed class Button : ElementWithSource
		{
			public new class Definition : ElementWithSource.Definition
			{
				internal override Element AyzbqKXoiIAsmtBrFwHcroNIERsg(PlayerController P_0)
				{
					return null;
				}
			}

			public bool value => false;

			public bool valuePrev => false;

			public bool justPressed => false;

			public bool justReleased => false;

			internal Button(PlayerController P_0, Definition P_1)
				: base(null, null)
			{
			}
		}

		public abstract class CompoundElement : Element
		{
			public new abstract class Definition : Element.Definition
			{
				public Definition()
				{
				}
			}

			private readonly List<Element> aUQWeyXieBvNOUAjqzTkUKmMbRkq;

			internal int WOdvMTZVCrCusSlqOUStwpOvfaKX => 0;

			internal CompoundElement(PlayerController P_0, Definition P_1, Element.Definition[] P_2)
				: base(null, null)
			{
			}

			internal _0001 eFnogOZmzyuQdEpygQflSqDcOeKp<_0001>(int P_0) where _0001 : Element
			{
				return null;
			}

			internal void bDWTTzTqiIaxwAXlRaWoxZRsySsJ(List<Element> P_0)
			{
			}

			internal void EXLSSjQnrrQtaZMvCcEDTNZBhhQt(Element P_0)
			{
			}
		}

		public abstract class Element
		{
			[CustomObfuscation]
			internal enum Type
			{
				[CustomObfuscation]
				Button = 0,
				[CustomObfuscation]
				Axis = 1,
				[CustomObfuscation]
				MouseAxis = 2,
				[CustomObfuscation]
				MouseWheelAxis = 3,
				[CustomObfuscation]
				Axis2D = 100,
				[CustomObfuscation]
				MouseAxis2D = 101,
				[CustomObfuscation]
				MouseWheel = 102
			}

			[CustomObfuscation]
			internal enum TypeWithSource
			{
				[CustomObfuscation]
				Button = 0,
				[CustomObfuscation]
				Axis = 1,
				[CustomObfuscation]
				MouseAxis = 2,
				[CustomObfuscation]
				MouseWheelAxis = 3
			}

			[CustomObfuscation]
			internal enum CompoundTypes
			{
				[CustomObfuscation]
				Axis2D = 100,
				[CustomObfuscation]
				MouseAxis2D = 101,
				[CustomObfuscation]
				MouseWheel = 102
			}

			public abstract class Definition
			{
				public bool enabled;

				public string name;

				public Definition()
				{
				}

				internal abstract Element AyzbqKXoiIAsmtBrFwHcroNIERsg(PlayerController P_0);
			}

			internal struct qFOqzvUldDgMWroubIhupUJWSdUC
			{
				public ControllerElementType HdUojRicHUlIpCmGkuawfkOvHDMt;

				public int OVaNqsFEyODDjJdeKwblTptrPuEz;

				public float pWbMhcBQKZEHHDwvEOhqpAUJhzfpA;

				public qFOqzvUldDgMWroubIhupUJWSdUC(ControllerElementType P_0, int P_1, float P_2)
				{
					HdUojRicHUlIpCmGkuawfkOvHDMt = default(ControllerElementType);
					OVaNqsFEyODDjJdeKwblTptrPuEz = 0;
					pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = 0f;
				}
			}

			[CustomObfuscation]
			internal const bool defaultEnabled = true;

			private readonly PlayerController rBdHDCfDobOjBUqyNbBnmEluxEvZ;

			private bool YQcaepgwdPMnDBoJhLEmSeLNpvTX;

			private bool llkLFSoLVtaASCstwdnHCsIDxnhYb;

			private string gbaFwplwRPDIuUufIuWmknaoIHDK;

			private static int[] xYSdIKKPJhRECdphArEgoKPfEPNe;

			private static int[] brKQlghhXgojExrMnbyrUXYTTgNB;

			protected Player player => null;

			protected bool selfAndParentEnabled => false;

			internal bool EmbhxShZpSdinJOCBRHmiAsqvDuRA
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

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
				set
				{
				}
			}

			internal Element(PlayerController P_0, Definition P_1)
			{
			}

			internal virtual void sOLNzBCCbZmFXkMugfndpShqgrUP()
			{
			}

			protected virtual void EnabledStateChanged(bool state)
			{
			}

			[CustomObfuscation]
			internal static bool IsTypeWithSource(Type type)
			{
				return false;
			}

			[CustomObfuscation]
			internal static bool IsCompoundType(Type type)
			{
				return false;
			}

			[CustomObfuscation]
			internal static int GetMaxElementCount(Type type)
			{
				return 0;
			}

			[CustomObfuscation]
			internal static string GetElementTitle(Type type, int index)
			{
				return null;
			}

			[CustomObfuscation]
			internal static Definition CreateDefinition(Type type)
			{
				return null;
			}
		}

		public abstract class ElementWithSource : Element
		{
			public new abstract class Definition : Element.Definition
			{
				private int WtxqRhyewFhRCZexgGgTPAkliDAd;

				public int actionId
				{
					get
					{
						return 0;
					}
					set
					{
					}
				}

				public string actionName
				{
					get
					{
						return null;
					}
					set
					{
					}
				}

				public Definition()
				{
				}
			}

			[CustomObfuscation]
			internal const int defaultActionId = -1;

			private int WtxqRhyewFhRCZexgGgTPAkliDAd;

			public int actionId
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public string actionName
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			internal ElementWithSource(PlayerController P_0, Definition P_1)
				: base(null, null)
			{
			}
		}

		public sealed class MouseWheel : Axis2D
		{
			public new class Definition : Axis2D.Definition
			{
				public new MouseWheelAxis.Definition xAxis
				{
					get
					{
						return null;
					}
					set
					{
					}
				}

				public new MouseWheelAxis.Definition yAxis
				{
					get
					{
						return null;
					}
					set
					{
					}
				}

				internal override Element AyzbqKXoiIAsmtBrFwHcroNIERsg(PlayerController P_0)
				{
					return null;
				}
			}

			public new MouseWheelAxis xAxis => null;

			public new MouseWheelAxis yAxis => null;

			internal MouseWheel(PlayerController P_0, Definition P_1)
				: base(null, null, null)
			{
			}
		}

		public sealed class MouseWheelAxis : Axis
		{
			public new class Definition : Axis.Definition
			{
				public float repeatRate;

				internal override Element AyzbqKXoiIAsmtBrFwHcroNIERsg(PlayerController P_0)
				{
					return null;
				}
			}

			[CustomObfuscation]
			internal const float defaultRepeatRate = 4f;

			[CustomObfuscation]
			internal new const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Relative;

			private const float pPMENrbaPfAiPpLAInSBmXmskYUK = 0.01f;

			private float RNxVHgjleVBMtFFWhbGeJSoMIgab;

			private double vIwvPMcATIHkMviHRVsUjaNizSjw;

			private float zqlmAmRAWxhuzRtcELHICvssAvpy;

			public float repeatRate
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public override float value => 0f;

			internal MouseWheelAxis(PlayerController P_0, Definition P_1)
				: base(null, null)
			{
			}

			internal override void sOLNzBCCbZmFXkMugfndpShqgrUP()
			{
			}

			protected override void EnabledStateChanged(bool state)
			{
			}

			private float pPeAIMkptsfutQLGOJrGoKfGJLad()
			{
				return 0f;
			}

			private void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
			{
			}
		}

		internal readonly int TcEXPUvjqSTMTFutCAtGRnMeNwub;

		private bool llkLFSoLVtaASCstwdnHCsIDxnhYb;

		private int KjrBBzjjJWMijsVwJGfzfVcgArYWb;

		private readonly AList<Element> aUQWeyXieBvNOUAjqzTkUKmMbRkq;

		private readonly AList<Button> ZvPFEBoODFIFAalgjPuHlidSttRw;

		private readonly AList<Axis> brSuYimOuyWJoTIlcMgUhFfimdIf;

		private readonly ReadOnlyCollection<Element> ABLlvSkeHalgmkxVjrUFAcOGcjTf;

		private readonly ReadOnlyCollection<Button> egRIWCsrRvLJBNoTeDGKlOMtsehu;

		private readonly ReadOnlyCollection<Axis> rEtiIIgRDKkgbtYvpdyAuMMnTsTo;

		private readonly List<Element.qFOqzvUldDgMWroubIhupUJWSdUC> YpTnyHbxmVEeJmsCbcHlhquMctqU;

		private Action<int, bool> oGZajKIGGQSTmaWfVTqiqcYCqDRv;

		private Action<int, float> HLGKyrdafUQHhqdCIWgbSLWXcXmr;

		private Action<bool> vPTVuMiQdGJnDqRyojAKUwFPnFYJ;

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

		public int playerId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public IList<Button> buttons => null;

		public IList<Axis> axes => null;

		public IList<Element> elements => null;

		public int buttonCount => 0;

		public int axisCount => 0;

		public int elementCount => 0;

		internal Player EVSYfBRoRmlZGWzbtVEKHpHdIHIm => null;

		public event Action<int, bool> ButtonStateChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<int, float> AxisValueChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<bool> EnabledStateChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		internal PlayerController(Definition P_0)
		{
		}

		~PlayerController()
		{
		}

		public bool GetButton(int index)
		{
			return false;
		}

		public bool GetButtonDown(int index)
		{
			return false;
		}

		public bool GetButtonUp(int index)
		{
			return false;
		}

		public float GetAxis(int index)
		{
			return 0f;
		}

		public float GetAxisRaw(int index)
		{
			return 0f;
		}

		public Element GetElement(int index)
		{
			return null;
		}

		public T GetElement<T>(int index) where T : Element
		{
			return null;
		}

		private void IghfPvNUXsucbZILFgzLRWwwGmUeA(UpdateLoopType P_0)
		{
		}

		protected virtual bool Update(UpdateLoopType updateLoop)
		{
			return false;
		}

		protected virtual void UpdateFinished()
		{
		}

		protected virtual void ClearVars()
		{
		}

		internal void EXLSSjQnrrQtaZMvCcEDTNZBhhQt(Element P_0)
		{
		}

		private void EXLSSjQnrrQtaZMvCcEDTNZBhhQt(Element P_0, List<Element> P_1, List<Element> P_2, List<Button> P_3, List<Axis> P_4)
		{
		}

		internal static int IuxFzWiQBqbOyePCizqDplvmnxcy<_0001>(IList<_0001> P_0, Predicate<_0001> P_1, int P_2) where _0001 : Element
		{
			return 0;
		}
	}
}
