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

				internal abstract Element BVAZUwjKWKNRIpIBUpxHBmFwLdh(PlayerController P_0);
			}

			internal struct lPrlJXakJJslcdwEscDRVlSyavN
			{
				public ControllerElementType OFxIPpGxSUDTJEgqhfJRLIfXynV;

				public int NLVTHAlcYUOUXlkWNcQMDFfDJvH;

				public float goUQCKzJmFEdxabJRHcPmEGvlCq;

				public lPrlJXakJJslcdwEscDRVlSyavN(ControllerElementType elementType, int index, float value)
				{
					OFxIPpGxSUDTJEgqhfJRLIfXynV = default(ControllerElementType);
					NLVTHAlcYUOUXlkWNcQMDFfDJvH = 0;
					goUQCKzJmFEdxabJRHcPmEGvlCq = 0f;
				}
			}

			[CustomObfuscation]
			internal const bool defaultEnabled = true;

			private readonly PlayerController cFEBywhZYxtgpybAYsIGoOnAlzo;

			private bool VoBgDRASTBaetFDpkGTZMmHhLISP;

			private bool ebJsAuYejvRqociTxulmKyAPKrq;

			private string rxFXeRTtpDKAOGNDPEpHeMwItpAb;

			private static int[] wwvIOekylbVOqvLDVwvPCaIPAzQ;

			private static int[] gnnKlZZCHobtVAtXuSkJeuZxZuhT;

			protected Player player => null;

			protected bool selfAndParentEnabled => false;

			internal bool isMemberElement
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

			internal Element(PlayerController parent, Definition definition)
			{
			}

			internal virtual void jSmUMfkZCZCZfiMnleEGJnwKIqT()
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
				private int TQYOZDQbURTgwLWUxEJkbkWTlFD;

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

			private int TQYOZDQbURTgwLWUxEJkbkWTlFD;

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

			internal ElementWithSource(PlayerController parent, Definition definition)
				: base(null, null)
			{
			}
		}

		public class Axis : ElementWithSource
		{
			public new class Definition : ElementWithSource.Definition
			{
				public AxisCoordinateMode coordinateMode;

				public float absoluteToRelativeSensitivity;

				internal override Element BVAZUwjKWKNRIpIBUpxHBmFwLdh(PlayerController P_0)
				{
					return null;
				}
			}

			internal const float lZjPvktwaKiazxUekBHVnMzhxYa = 1f;

			[CustomObfuscation]
			internal const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Absolute;

			private float cfAGVeEWkPDiFPCKkjoTmjyLNudQ;

			private AxisCoordinateMode UqBQpBCzkJrEKZOHmDcZeHuSEhF;

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

			internal Axis(PlayerController parent, Definition definition)
				: base(null, null)
			{
			}
		}

		public class MouseAxis : Axis
		{
			public new class Definition : Axis.Definition
			{
				internal override Element BVAZUwjKWKNRIpIBUpxHBmFwLdh(PlayerController P_0)
				{
					return null;
				}
			}

			[CustomObfuscation]
			internal new const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Relative;

			[CustomObfuscation]
			internal const float defaultAbsoluteToRelativeSensitivity = 600f;

			public override float value => 0f;

			internal MouseAxis(PlayerController parent, Definition definition)
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

			private readonly List<Element> pLlTDQrAWXFGuEEXrnQNcxqsCoj;

			internal int elementCount => 0;

			internal CompoundElement(PlayerController parent, Definition definition, Element.Definition[] elementDefinitions)
				: base(null, null)
			{
			}

			internal T niOBPgvRcuDJPAYPxmZAmXmSJfX<T>(int P_0) where T : Element
			{
				return null;
			}

			internal void mhzqPLlfUUqxAUCBKJOBVePAPsh(List<Element> P_0)
			{
			}

			internal void TOijILutNxolQTyJVTjktNFbIoT(Element P_0)
			{
			}
		}

		public class Axis2D : CompoundElement
		{
			public new class Definition : CompoundElement.Definition
			{
				private Axis.Definition ckZdtqfFjtFYBbYEfkGOvfPKouYH;

				private Axis.Definition cUQYtFIbtmarksUThCjAaIHPnkRG;

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

				internal override Element BVAZUwjKWKNRIpIBUpxHBmFwLdh(PlayerController P_0)
				{
					return null;
				}
			}

			internal const int KUgmgtmXdxJtYffQgHrzYZUYQvE = 0;

			internal const int IJpRgpBsvSfhTrGAuaJgCTHwaGr = 1;

			internal const int YiEEYPgJZjoEpSnWZWcytXDBifqF = 2;

			public Axis xAxis => null;

			public Axis yAxis => null;

			public virtual Vector2 value => default(Vector2);

			public virtual Vector2 valueRaw => default(Vector2);

			internal Axis2D(PlayerController parent, Definition definition, Element.Definition[] definitions)
				: base(null, null, null)
			{
			}

			internal Axis2D(PlayerController parent, Definition definition)
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

				internal override Element BVAZUwjKWKNRIpIBUpxHBmFwLdh(PlayerController P_0)
				{
					return null;
				}
			}

			public new MouseAxis xAxis => null;

			public new MouseAxis yAxis => null;

			internal MouseAxis2D(PlayerController parent, Definition definition)
				: base(null, null, null)
			{
			}
		}

		public sealed class Button : ElementWithSource
		{
			public new class Definition : ElementWithSource.Definition
			{
				internal override Element BVAZUwjKWKNRIpIBUpxHBmFwLdh(PlayerController P_0)
				{
					return null;
				}
			}

			public bool value => false;

			public bool valuePrev => false;

			public bool justPressed => false;

			public bool justReleased => false;

			internal Button(PlayerController parent, Definition definition)
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

				internal override Element BVAZUwjKWKNRIpIBUpxHBmFwLdh(PlayerController P_0)
				{
					return null;
				}
			}

			public new MouseWheelAxis xAxis => null;

			public new MouseWheelAxis yAxis => null;

			internal MouseWheel(PlayerController parent, Definition definition)
				: base(null, null, null)
			{
			}
		}

		public sealed class MouseWheelAxis : Axis
		{
			public new class Definition : Axis.Definition
			{
				public float repeatRate;

				internal override Element BVAZUwjKWKNRIpIBUpxHBmFwLdh(PlayerController P_0)
				{
					return null;
				}
			}

			[CustomObfuscation]
			internal const float defaultRepeatRate = 4f;

			[CustomObfuscation]
			internal new const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Relative;

			private const float uLlDtRBJjnYjnDzyRvTgGrmGifJF = 0.01f;

			private float QHcgwrKhNofSulNnBIylxxMOpct;

			private double igVeEmAwdSfhoedhGujhHBBUvhcR;

			private float eAKYTWpmchhzPZnAFYwhyHoMSuu;

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

			internal MouseWheelAxis(PlayerController parent, Definition definition)
				: base(null, null)
			{
			}

			internal override void jSmUMfkZCZCZfiMnleEGJnwKIqT()
			{
			}

			protected override void EnabledStateChanged(bool state)
			{
			}

			private float mZLibeUaPaHeRdKvLNQtjOKgSwx()
			{
				return 0f;
			}

			private void CKSoitBPjLqWpFGpwBNgDbvTrVm()
			{
			}
		}

		internal readonly int UmlfknJGLCaKwkBKLxTOQfvOngpe;

		private bool ebJsAuYejvRqociTxulmKyAPKrq;

		private int RaKAiTTihElhDTpWAKsQdvaqmEJ;

		private readonly AList<Element> pLlTDQrAWXFGuEEXrnQNcxqsCoj;

		private readonly AList<Button> WlmpbMCpbLOJssSkuliwJzUqMhA;

		private readonly AList<Axis> sorqDOAPsoFXGLYgrhZpTdNKNDX;

		private readonly ReadOnlyCollection<Element> PYkIGFSdEsaiQkqDwqcwfwgkkJAH;

		private readonly ReadOnlyCollection<Button> dwmlaUUxflOFxLnUpLtRLGBFBiy;

		private readonly ReadOnlyCollection<Axis> yOKjwIcxYClBGtBsqljjMMBRLCc;

		private readonly List<Element.lPrlJXakJJslcdwEscDRVlSyavN> JGmDjdPWSVbclyhquOWMXeamSrp;

		private Action<int, bool> jPeBKaKeoYSYMyUZWdrXQwAwgcKI;

		private Action<int, float> WpjHROZJEOQfNwuuFlVEqAipoAj;

		private Action<bool> kYyUssSbZCJQjwgWvakpFqRrEIFW;

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

		internal Player player => null;

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

		internal PlayerController(Definition definition)
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

		private void PSFeJyfveNnRLRnWPckAdcFQFXH(UpdateLoopType P_0)
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

		internal void TOijILutNxolQTyJVTjktNFbIoT(Element P_0)
		{
		}

		private void TOijILutNxolQTyJVTjktNFbIoT(Element P_0, List<Element> P_1, List<Element> P_2, List<Button> P_3, List<Axis> P_4)
		{
		}

		internal static int HyYCxwQVdyXWIPaelvdgDUhGQjb<T>(IList<T> P_0, Predicate<T> P_1, int P_2) where T : Element
		{
			return 0;
		}
	}
}
