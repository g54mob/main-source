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

		public enum AbsoluteToRelativeScalingMode
		{
			None = 0,
			ScreenWidth = 1,
			ScreenHeight = 2,
			MaxScreenDimension = 3,
			MinScreenDimension = 4,
			ViewportWidth = 5,
			ViewportHeight = 6,
			MaxViewportDimension = 7,
			MinViewportDimension = 8
		}

		public class Axis : ElementWithSource
		{
			public new class Definition : ElementWithSource.Definition
			{
				public AxisCoordinateMode coordinateMode;

				public float absoluteToRelativeSensitivity;

				public AbsoluteToRelativeScalingMode absoluteToRelativeScalingMode;

				internal override Element xdjxkDjtSSdBMsvOUqGtSDbsuJlH(PlayerController P_0)
				{
					return null;
				}
			}

			internal const float tPrdYQirqhIWWDFkYIQWMOAAscjK = 1f;

			internal const AbsoluteToRelativeScalingMode stHGOCBPjAacDrFWudmgSZiaSlZw = AbsoluteToRelativeScalingMode.None;

			[CustomObfuscation(rename = false)]
			internal const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Absolute;

			private float VtbCBCgBwTjiXJgEGjtUrKzRPblwA;

			private AxisCoordinateMode eyHiFhnCVRCnfKCZculWNxEPOihWA;

			private AbsoluteToRelativeScalingMode HOqARMCigopNiGejBHTemBduPYcA;

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

			public AbsoluteToRelativeScalingMode absoluteToRelativeScalingMode
			{
				get
				{
					return default(AbsoluteToRelativeScalingMode);
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
				internal override Element xdjxkDjtSSdBMsvOUqGtSDbsuJlH(PlayerController P_0)
				{
					return null;
				}
			}

			[CustomObfuscation(rename = false)]
			internal new const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Relative;

			[CustomObfuscation(rename = false)]
			internal const float defaultAbsoluteToRelativeSensitivity = 600f;

			[CustomObfuscation(rename = false)]
			internal const AbsoluteToRelativeScalingMode defaultAbsoluteToRelativeScalingMode = AbsoluteToRelativeScalingMode.ScreenWidth;

			internal MouseAxis(PlayerController P_0, Definition P_1)
				: base(null, null)
			{
			}
		}

		public class Axis2D : CompoundElement
		{
			public new class Definition : CompoundElement.Definition
			{
				private Axis.Definition TvPHbFeFTcjagBhnoWLNwnLLnoZU;

				private Axis.Definition qaEFXleQALSJdFlwenVgmiLDPoAoD;

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

				internal override Element xdjxkDjtSSdBMsvOUqGtSDbsuJlH(PlayerController P_0)
				{
					return null;
				}
			}

			internal const int aEgbgzhMcvYNpxsITtMoOaTZfZnF = 0;

			internal const int bvoORUoUuRhSBFLBkLxppLVhtVnw = 1;

			internal const int qrHpOKjsklwBhhYiwnegnTxxufQw = 2;

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

				internal override Element xdjxkDjtSSdBMsvOUqGtSDbsuJlH(PlayerController P_0)
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
				internal override Element xdjxkDjtSSdBMsvOUqGtSDbsuJlH(PlayerController P_0)
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

			private readonly List<Element> VOTGTurgpyKzDejhwRLDgbBLPdvv;

			internal int DTeMmgqLftsfPKSPRjlETbtOuVIj => 0;

			internal CompoundElement(PlayerController P_0, Definition P_1, Element.Definition[] P_2)
				: base(null, null)
			{
			}

			internal _0001 JPJVGRrhOYQVAtaysguIblNbDoVC<_0001>(int P_0) where _0001 : Element
			{
				return null;
			}

			internal void GhWYunooGqCpkeZmANjUefxvYGtjA(List<Element> P_0)
			{
			}

			internal void dzirdOZVpgwhAywrJHHzVzmYfYZH(Element P_0)
			{
			}
		}

		public abstract class Element
		{
			[CustomObfuscation(rename = false)]
			internal enum Type
			{
				[CustomObfuscation(rename = false)]
				Button = 0,
				[CustomObfuscation(rename = false)]
				Axis = 1,
				[CustomObfuscation(rename = false)]
				MouseAxis = 2,
				[CustomObfuscation(rename = false)]
				MouseWheelAxis = 3,
				[CustomObfuscation(rename = false)]
				Axis2D = 100,
				[CustomObfuscation(rename = false)]
				MouseAxis2D = 101,
				[CustomObfuscation(rename = false)]
				MouseWheel = 102
			}

			[CustomObfuscation(rename = false)]
			internal enum TypeWithSource
			{
				[CustomObfuscation(rename = false)]
				Button = 0,
				[CustomObfuscation(rename = false)]
				Axis = 1,
				[CustomObfuscation(rename = false)]
				MouseAxis = 2,
				[CustomObfuscation(rename = false)]
				MouseWheelAxis = 3
			}

			[CustomObfuscation(rename = false)]
			internal enum CompoundTypes
			{
				[CustomObfuscation(rename = false)]
				Axis2D = 100,
				[CustomObfuscation(rename = false)]
				MouseAxis2D = 101,
				[CustomObfuscation(rename = false)]
				MouseWheel = 102
			}

			public abstract class Definition
			{
				public bool enabled;

				public string name;

				public Definition()
				{
				}

				internal abstract Element xdjxkDjtSSdBMsvOUqGtSDbsuJlH(PlayerController P_0);
			}

			internal struct UJinuItmyzahmebrnEFgySjMJMHO
			{
				public ControllerElementType MINaxwHudqzRnmKspPKysxrlJwNHA;

				public int zgCOpCObfTGMEGJVtKwoUeCLKRtQ;

				public float lboRhBZfNTAcCNNmmcptFhMrxTRqA;

				public UJinuItmyzahmebrnEFgySjMJMHO(ControllerElementType P_0, int P_1, float P_2)
				{
					MINaxwHudqzRnmKspPKysxrlJwNHA = default(ControllerElementType);
					zgCOpCObfTGMEGJVtKwoUeCLKRtQ = 0;
					lboRhBZfNTAcCNNmmcptFhMrxTRqA = 0f;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const bool defaultEnabled = true;

			private readonly PlayerController jWzSQytjQYkVGDbEalhpaBFQPtDQ;

			private bool ElJjdkbLCJewcFDuaknMcczhQLqP;

			private bool TPfrAnWbwTrcjCdIoDeGZnsSfcdB;

			private string YygfdTKoLuFjQugIzFLrzTJSjoVX;

			private static int[] BXxQizqhHQikxIOYzWVkilMFwnkd;

			private static int[] ZFgoqgJZrpmGKjLxwbnkVWjlvwef;

			protected Player player => null;

			protected bool selfAndParentEnabled => false;

			internal bool RqFMzefgLvcrkHcahUASVRYomsRJ
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

			internal virtual void ZzpEhhoJPpGrPVOAEfTyoEYwnsZu()
			{
			}

			protected virtual void EnabledStateChanged(bool state)
			{
			}

			[CustomObfuscation(rename = false)]
			internal static bool IsTypeWithSource(Type type)
			{
				return false;
			}

			[CustomObfuscation(rename = false)]
			internal static bool IsCompoundType(Type type)
			{
				return false;
			}

			[CustomObfuscation(rename = false)]
			internal static int GetMaxElementCount(Type type)
			{
				return 0;
			}

			[CustomObfuscation(rename = false)]
			internal static string GetElementTitle(Type type, int index)
			{
				return null;
			}

			[CustomObfuscation(rename = false)]
			internal static Definition CreateDefinition(Type type)
			{
				return null;
			}
		}

		public abstract class ElementWithSource : Element
		{
			public new abstract class Definition : Element.Definition
			{
				private int cVfUcFFbhowaaAhuBABBCYPZnkMNA;

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

			[CustomObfuscation(rename = false)]
			internal const int defaultActionId = -1;

			private int FxuThkEZoqlKTopVeNJybxWAEVqC;

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

				internal override Element xdjxkDjtSSdBMsvOUqGtSDbsuJlH(PlayerController P_0)
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

				internal override Element xdjxkDjtSSdBMsvOUqGtSDbsuJlH(PlayerController P_0)
				{
					return null;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const float defaultRepeatRate = 4f;

			[CustomObfuscation(rename = false)]
			internal new const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Relative;

			private const float cLeaKfPnxomKWZuyUvGxNTsBSOiK = 0.01f;

			private float hhLCRNCAXsAJeRCYQeArcweKOfYBA;

			private double AtRgzJJWGvbwfJvWLQlIPkZYpcqh;

			private float NBdoEVletwXEBBOoHTNFXDspaJdiA;

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

			internal override void ZzpEhhoJPpGrPVOAEfTyoEYwnsZu()
			{
			}

			protected override void EnabledStateChanged(bool state)
			{
			}

			private float LmCPMREttphSxLsmyXDctFydsWvC()
			{
				return 0f;
			}

			private void ksTDCzmtroANHSkbmwLerfBrUBPc()
			{
			}
		}

		internal readonly int BactrdkHXDdWZqddywffsRoEOaKo;

		private bool wXmdUPKjxYymCkUzIcPwxgIaacod;

		private int YJUZOvVHMEIRrjJItipRtWYWXQEJA;

		private readonly AList<Element> bEdnyspCxFXDgXHFkFWZbcODtIuL;

		private readonly AList<Button> lOzudZCCJLsQvjBFZYglwzqlZPBC;

		private readonly AList<Axis> QhFbjUjHOKvjBSJTdpqRNrMtaALW;

		private readonly ReadOnlyCollection<Element> pAaNfAqsMacTFBBHIgXrupOjHiNz;

		private readonly ReadOnlyCollection<Button> xyaEqeFYBfgtubJjKNooszCIZJLec;

		private readonly ReadOnlyCollection<Axis> PuYOfofOPVbqOfkqLVwJGLYvXEOB;

		private readonly List<Element.UJinuItmyzahmebrnEFgySjMJMHO> gfRkmhzkkfJpymYjbJuCaHraaOTl;

		private Action<int, bool> LKIYUuumZcUCyyQJHwJLLQpUyvJD;

		private Action<int, float> axrskPegruGfLRTTrETEdhlUcfcGb;

		private Action<bool> xFyyUZZIptJIYeSTJixtGCwLHvWT;

		private static Vector2 vMZvTcNCmcvYTADFySwEkhBEjUpr;

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

		internal Player FJqAmuJWVSTbDOtWMyWBapBlIonGA => null;

		public static Vector2 absoluteToRelativeScalingReferenceResolution
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

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

		private void pueFQQcCHZrIDOdsXXIehAilPOpiA(UpdateLoopType P_0)
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

		internal void hUoiCXvSYHMKMzjAuBSHbvmFxWMz(Element P_0)
		{
		}

		private void JQSeDFFLOujvuFIXFqlNVmqVmBvSc(Element P_0, List<Element> P_1, List<Element> P_2, List<Button> P_3, List<Axis> P_4)
		{
		}

		internal static int vtkwMwYTZycPtaVGqtFzwJswUMYr<_0001>(IList<_0001> P_0, Predicate<_0001> P_1, int P_2) where _0001 : Element
		{
			return 0;
		}
	}
}
