using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public class PlayerController : IPlayerController
	{
		public class Definition
		{
			public bool enabled = true;

			public int playerId = -1;

			public ICollection<Element.Definition> elements;
		}

		public static class Factory
		{
			public static PlayerController Create(Definition definition)
			{
				return new PlayerController(definition);
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
					enabled = true;
					name = null;
				}

				internal abstract Element wpzWcMxzqdVgTVfJjIbzkLgsfUIc(PlayerController P_0);
			}

			internal struct OVKNllgCfimOjVJOPKJdXfpkuCe
			{
				public ControllerElementType vfOgoNYdPlyNOyYmKzOzPipRXne;

				public int qFslVgpsJvzXCDAccmwaJAuNiAc;

				public float HpxePuhaScltgSCBmgsrsCpjliL;

				public OVKNllgCfimOjVJOPKJdXfpkuCe(ControllerElementType elementType, int index, float value)
				{
					vfOgoNYdPlyNOyYmKzOzPipRXne = elementType;
					qFslVgpsJvzXCDAccmwaJAuNiAc = index;
					HpxePuhaScltgSCBmgsrsCpjliL = value;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const bool defaultEnabled = true;

			private readonly PlayerController TKnWISxZiQPTaIhKpEMkcaWQSuD;

			private bool mngDbbdSfefDizfbBDZnoawxaffX;

			private bool TAiAzEAcNOkrpYWJEmhYYqnFvpF = true;

			private string YckvCvRVVkCnFoBTmVxvWZVKnMr;

			private static int[] FBSgqYuLRYNlvPvNsgkzSBjPjWf;

			private static int[] LhKiNlPjnTuEQZdXJpsjgegpaJMC;

			protected Player player
			{
				get
				{
					if (!ReInput.isReady)
					{
						return null;
					}
					return ReInput.players.GetPlayer(TKnWISxZiQPTaIhKpEMkcaWQSuD.ivfdKpZALpQIAdtIdHmkpPFkwfq);
				}
			}

			protected bool selfAndParentEnabled
			{
				get
				{
					if (TAiAzEAcNOkrpYWJEmhYYqnFvpF)
					{
						return TKnWISxZiQPTaIhKpEMkcaWQSuD.TAiAzEAcNOkrpYWJEmhYYqnFvpF;
					}
					return false;
				}
			}

			internal bool isMemberElement
			{
				get
				{
					return mngDbbdSfefDizfbBDZnoawxaffX;
				}
				set
				{
					mngDbbdSfefDizfbBDZnoawxaffX = true;
				}
			}

			public bool enabled
			{
				get
				{
					return TAiAzEAcNOkrpYWJEmhYYqnFvpF;
				}
				set
				{
					if (TAiAzEAcNOkrpYWJEmhYYqnFvpF != value)
					{
						TAiAzEAcNOkrpYWJEmhYYqnFvpF = value;
						EnabledStateChanged(value);
					}
				}
			}

			public string name
			{
				get
				{
					return YckvCvRVVkCnFoBTmVxvWZVKnMr;
				}
				set
				{
					YckvCvRVVkCnFoBTmVxvWZVKnMr = value;
				}
			}

			internal Element(PlayerController parent, Definition definition)
			{
				if (parent == null)
				{
					throw new ArgumentNullException("parent");
				}
				if (definition == null)
				{
					throw new ArgumentNullException("definition");
				}
				TKnWISxZiQPTaIhKpEMkcaWQSuD = parent;
				TAiAzEAcNOkrpYWJEmhYYqnFvpF = definition.enabled;
			}

			internal virtual void QTPiZFmnRsxmyQYmMuIoBQkOtfg()
			{
			}

			protected virtual void EnabledStateChanged(bool state)
			{
			}

			[CustomObfuscation(rename = false)]
			internal static bool IsTypeWithSource(Type type)
			{
				if (FBSgqYuLRYNlvPvNsgkzSBjPjWf == null)
				{
					FBSgqYuLRYNlvPvNsgkzSBjPjWf = (int[])Enum.GetValues(typeof(TypeWithSource));
				}
				return ArrayTools.Contains(FBSgqYuLRYNlvPvNsgkzSBjPjWf, (int)type);
			}

			[CustomObfuscation(rename = false)]
			internal static bool IsCompoundType(Type type)
			{
				if (LhKiNlPjnTuEQZdXJpsjgegpaJMC == null)
				{
					LhKiNlPjnTuEQZdXJpsjgegpaJMC = (int[])Enum.GetValues(typeof(CompoundTypes));
				}
				return ArrayTools.Contains(LhKiNlPjnTuEQZdXJpsjgegpaJMC, (int)type);
			}

			[CustomObfuscation(rename = false)]
			internal static int GetMaxElementCount(Type type)
			{
				if (IsTypeWithSource(type))
				{
					return 1;
				}
				if (IsCompoundType(type))
				{
					return type switch
					{
						Type.Axis2D => 2, 
						Type.MouseAxis2D => 2, 
						Type.MouseWheel => 2, 
						_ => throw new NotImplementedException(), 
					};
				}
				throw new NotImplementedException();
			}

			[CustomObfuscation(rename = false)]
			internal static string GetElementTitle(Type type, int index)
			{
				if (index < 0 || index > GetMaxElementCount(type))
				{
					return null;
				}
				if (IsTypeWithSource(type))
				{
					return null;
				}
				if (IsCompoundType(type))
				{
					switch (type)
					{
					case Type.Axis2D:
					case Type.MouseAxis2D:
					case Type.MouseWheel:
						if (index != 0)
						{
							return "Y Axis";
						}
						return "X Axis";
					default:
						throw new NotImplementedException();
					}
				}
				throw new NotImplementedException();
			}

			[CustomObfuscation(rename = false)]
			internal static Definition CreateDefinition(Type type)
			{
				return type switch
				{
					Type.Axis => new Axis.Definition(), 
					Type.Button => new Button.Definition(), 
					Type.MouseAxis => new MouseAxis.Definition(), 
					Type.MouseWheelAxis => new MouseWheelAxis.Definition(), 
					Type.Axis2D => new Axis2D.Definition(), 
					Type.MouseAxis2D => new MouseAxis2D.Definition(), 
					Type.MouseWheel => new MouseWheel.Definition(), 
					_ => throw new NotImplementedException(), 
				};
			}
		}

		public abstract class ElementWithSource : Element
		{
			public new abstract class Definition : Element.Definition
			{
				private int sRbRrhSYcsdTbzpQQADExfvLSkq;

				public int actionId
				{
					get
					{
						return sRbRrhSYcsdTbzpQQADExfvLSkq;
					}
					set
					{
						sRbRrhSYcsdTbzpQQADExfvLSkq = value;
					}
				}

				public string actionName
				{
					get
					{
						if (!ReInput.isReady || sRbRrhSYcsdTbzpQQADExfvLSkq < 0)
						{
							return null;
						}
						return ReInput.mapping.GetAction(sRbRrhSYcsdTbzpQQADExfvLSkq)?.name;
					}
					set
					{
						if (!ReInput.isReady)
						{
							Logger.LogError("You cannot set an Action Name because Rewired has not been intialized.");
							return;
						}
						InputAction action = ReInput.mapping.GetAction(value);
						if (action == null)
						{
							sRbRrhSYcsdTbzpQQADExfvLSkq = -1;
						}
						else
						{
							sRbRrhSYcsdTbzpQQADExfvLSkq = action.id;
						}
					}
				}

				public Definition()
				{
					sRbRrhSYcsdTbzpQQADExfvLSkq = -1;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const int defaultActionId = -1;

			private int sRbRrhSYcsdTbzpQQADExfvLSkq = -1;

			public int actionId
			{
				get
				{
					return sRbRrhSYcsdTbzpQQADExfvLSkq;
				}
				set
				{
					sRbRrhSYcsdTbzpQQADExfvLSkq = value;
				}
			}

			public string actionName
			{
				get
				{
					if (!ReInput.isReady || sRbRrhSYcsdTbzpQQADExfvLSkq < 0)
					{
						return null;
					}
					return ReInput.mapping.GetAction(sRbRrhSYcsdTbzpQQADExfvLSkq)?.name;
				}
				set
				{
					if (ReInput.isReady)
					{
						InputAction action = ReInput.mapping.GetAction(value);
						if (action == null)
						{
							sRbRrhSYcsdTbzpQQADExfvLSkq = -1;
						}
						else
						{
							sRbRrhSYcsdTbzpQQADExfvLSkq = action.id;
						}
					}
				}
			}

			internal ElementWithSource(PlayerController parent, Definition definition)
				: base(parent, definition)
			{
				sRbRrhSYcsdTbzpQQADExfvLSkq = definition.actionId;
			}
		}

		public class Axis : ElementWithSource
		{
			public new class Definition : ElementWithSource.Definition
			{
				public AxisCoordinateMode coordinateMode;

				public float absoluteToRelativeSensitivity;

				public Definition()
				{
					coordinateMode = AxisCoordinateMode.Absolute;
					absoluteToRelativeSensitivity = 1f;
				}

				internal override Element wpzWcMxzqdVgTVfJjIbzkLgsfUIc(PlayerController P_0)
				{
					return new Axis(P_0, this);
				}
			}

			internal const float OTGnNElgUtmPkNxoZIBnjvEfxlR = 1f;

			[CustomObfuscation(rename = false)]
			internal const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Absolute;

			private float LkjBdKHWGazBKdeABbuhNrJZYXK = 1f;

			private AxisCoordinateMode rwcecbKIPyUqTfFATILdiyFILpe;

			public float absoluteToRelativeSensitivity
			{
				get
				{
					return LkjBdKHWGazBKdeABbuhNrJZYXK;
				}
				set
				{
					if (value < 0f)
					{
						value = 0f;
					}
					LkjBdKHWGazBKdeABbuhNrJZYXK = value;
				}
			}

			public AxisCoordinateMode coordinateMode => rwcecbKIPyUqTfFATILdiyFILpe;

			public virtual float value
			{
				get
				{
					if (!base.selfAndParentEnabled || base.player == null)
					{
						return 0f;
					}
					float num = base.player.GetAxis(base.actionId);
					switch (base.player.GetAxisCoordinateMode(base.actionId))
					{
					case AxisCoordinateMode.Relative:
						if (rwcecbKIPyUqTfFATILdiyFILpe == AxisCoordinateMode.Absolute)
						{
							return 0f;
						}
						break;
					case AxisCoordinateMode.Absolute:
						if (rwcecbKIPyUqTfFATILdiyFILpe == AxisCoordinateMode.Relative)
						{
							num *= (float)ReInput.unscaledDeltaTime * LkjBdKHWGazBKdeABbuhNrJZYXK;
						}
						break;
					}
					return num;
				}
			}

			public virtual float valueRaw
			{
				get
				{
					if (!base.selfAndParentEnabled || base.player == null)
					{
						return 0f;
					}
					return base.player.GetAxisRaw(base.actionId);
				}
			}

			internal Axis(PlayerController parent, Definition definition)
				: base(parent, definition)
			{
				LkjBdKHWGazBKdeABbuhNrJZYXK = definition.absoluteToRelativeSensitivity;
				rwcecbKIPyUqTfFATILdiyFILpe = definition.coordinateMode;
			}
		}

		public class MouseAxis : Axis
		{
			public new class Definition : Axis.Definition
			{
				public Definition()
				{
					coordinateMode = AxisCoordinateMode.Relative;
					absoluteToRelativeSensitivity = 600f;
				}

				internal override Element wpzWcMxzqdVgTVfJjIbzkLgsfUIc(PlayerController P_0)
				{
					return new MouseAxis(P_0, this);
				}
			}

			[CustomObfuscation(rename = false)]
			internal new const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Relative;

			[CustomObfuscation(rename = false)]
			internal const float defaultAbsoluteToRelativeSensitivity = 600f;

			public override float value
			{
				get
				{
					float num = base.value;
					if (num == 0f)
					{
						return 0f;
					}
					if (base.coordinateMode == AxisCoordinateMode.Relative && base.player.GetAxisCoordinateMode(base.actionId) == AxisCoordinateMode.Absolute)
					{
						num *= (float)Screen.currentResolution.width / 1920f;
					}
					return num;
				}
			}

			internal MouseAxis(PlayerController parent, Definition definition)
				: base(parent, definition)
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

			private readonly List<Element> KFQlRixtegtOhokPEQnlitLaJDS;

			internal int elementCount => KFQlRixtegtOhokPEQnlitLaJDS.Count;

			internal CompoundElement(PlayerController parent, Definition definition, Element.Definition[] elementDefinitions)
				: base(parent, definition)
			{
				KFQlRixtegtOhokPEQnlitLaJDS = new List<Element>();
				if (elementDefinitions == null)
				{
					return;
				}
				for (int i = 0; i < elementDefinitions.Length; i++)
				{
					if (elementDefinitions[i] != null)
					{
						sPDBUryojEPTZhjXiDvYbSylxsi(elementDefinitions[i].wpzWcMxzqdVgTVfJjIbzkLgsfUIc(parent));
					}
				}
			}

			internal T WChpoUjfxVomSqiESmHoqccMwdg<T>(int P_0) where T : Element
			{
				if ((uint)P_0 >= (uint)KFQlRixtegtOhokPEQnlitLaJDS.Count)
				{
					return null;
				}
				return KFQlRixtegtOhokPEQnlitLaJDS[P_0] as T;
			}

			internal void HHYIRrxedtPnBiLqhPjvTilEoES(List<Element> P_0)
			{
				for (int i = 0; i < KFQlRixtegtOhokPEQnlitLaJDS.Count; i++)
				{
					if (KFQlRixtegtOhokPEQnlitLaJDS[i] is CompoundElement)
					{
						(KFQlRixtegtOhokPEQnlitLaJDS[i] as CompoundElement).HHYIRrxedtPnBiLqhPjvTilEoES(P_0);
					}
					else
					{
						P_0.Add(KFQlRixtegtOhokPEQnlitLaJDS[i]);
					}
				}
			}

			internal void sPDBUryojEPTZhjXiDvYbSylxsi(Element P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("element");
				}
				KFQlRixtegtOhokPEQnlitLaJDS.Add(P_0);
				P_0.isMemberElement = true;
			}
		}

		public class Axis2D : CompoundElement
		{
			public new class Definition : CompoundElement.Definition
			{
				private Axis.Definition HqsFBYGFDKNfWYsUNGEattwstNpR;

				private Axis.Definition ZoxwRvCINPHEhbOJQIniNWgJsPk;

				public Axis.Definition xAxis
				{
					get
					{
						return HqsFBYGFDKNfWYsUNGEattwstNpR;
					}
					set
					{
						HqsFBYGFDKNfWYsUNGEattwstNpR = value;
					}
				}

				public Axis.Definition yAxis
				{
					get
					{
						return ZoxwRvCINPHEhbOJQIniNWgJsPk;
					}
					set
					{
						ZoxwRvCINPHEhbOJQIniNWgJsPk = value;
					}
				}

				internal override Element wpzWcMxzqdVgTVfJjIbzkLgsfUIc(PlayerController P_0)
				{
					return new Axis2D(P_0, this);
				}
			}

			internal const int hAZQEVwrVKqwZNdSZQFHCSlAqpj = 0;

			internal const int fPIzECXESpQcoDQKhuAvIsOwVDl = 1;

			internal const int rdxjgrkJfIibsUVGkFgUnboPfCBj = 2;

			public Axis xAxis => WChpoUjfxVomSqiESmHoqccMwdg<Axis>(0);

			public Axis yAxis => WChpoUjfxVomSqiESmHoqccMwdg<Axis>(1);

			public virtual Vector2 value => new Vector2(WChpoUjfxVomSqiESmHoqccMwdg<Axis>(0).value, WChpoUjfxVomSqiESmHoqccMwdg<Axis>(1).value);

			public virtual Vector2 valueRaw => new Vector2(WChpoUjfxVomSqiESmHoqccMwdg<Axis>(0).valueRaw, WChpoUjfxVomSqiESmHoqccMwdg<Axis>(1).valueRaw);

			internal Axis2D(PlayerController parent, Definition definition, Element.Definition[] definitions)
				: base(parent, definition, definitions)
			{
			}

			internal Axis2D(PlayerController parent, Definition definition)
				: base(parent, definition, (definition != null) ? new Element.Definition[2]
				{
					(definition.xAxis != null) ? definition.xAxis : new Axis.Definition(),
					(definition.yAxis != null) ? definition.yAxis : new Axis.Definition()
				} : null)
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
						return base.xAxis as MouseAxis.Definition;
					}
					set
					{
						base.xAxis = value;
					}
				}

				public new MouseAxis.Definition yAxis
				{
					get
					{
						return base.yAxis as MouseAxis.Definition;
					}
					set
					{
						base.yAxis = value;
					}
				}

				internal override Element wpzWcMxzqdVgTVfJjIbzkLgsfUIc(PlayerController P_0)
				{
					return new MouseAxis2D(P_0, this);
				}
			}

			public new MouseAxis xAxis => WChpoUjfxVomSqiESmHoqccMwdg<MouseAxis>(0);

			public new MouseAxis yAxis => WChpoUjfxVomSqiESmHoqccMwdg<MouseAxis>(1);

			internal MouseAxis2D(PlayerController parent, Definition definition)
				: base(parent, definition, (definition != null) ? new Element.Definition[2]
				{
					(definition.xAxis != null) ? definition.xAxis : new MouseAxis.Definition(),
					(definition.yAxis != null) ? definition.yAxis : new MouseAxis.Definition()
				} : null)
			{
			}
		}

		public sealed class Button : ElementWithSource
		{
			public new class Definition : ElementWithSource.Definition
			{
				internal override Element wpzWcMxzqdVgTVfJjIbzkLgsfUIc(PlayerController P_0)
				{
					return new Button(P_0, this);
				}
			}

			public bool value
			{
				get
				{
					if (!base.selfAndParentEnabled || base.player == null)
					{
						return false;
					}
					return base.player.GetButton(base.actionId);
				}
			}

			public bool valuePrev
			{
				get
				{
					if (!base.selfAndParentEnabled || base.player == null)
					{
						return false;
					}
					return base.player.GetButtonPrev(base.actionId);
				}
			}

			public bool justPressed
			{
				get
				{
					if (!base.selfAndParentEnabled || base.player == null)
					{
						return false;
					}
					return base.player.GetButtonDown(base.actionId);
				}
			}

			public bool justReleased
			{
				get
				{
					if (!base.selfAndParentEnabled || base.player == null)
					{
						return false;
					}
					return base.player.GetButtonUp(base.actionId);
				}
			}

			internal Button(PlayerController parent, Definition definition)
				: base(parent, definition)
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
						return base.xAxis as MouseWheelAxis.Definition;
					}
					set
					{
						base.xAxis = value;
					}
				}

				public new MouseWheelAxis.Definition yAxis
				{
					get
					{
						return base.yAxis as MouseWheelAxis.Definition;
					}
					set
					{
						base.yAxis = value;
					}
				}

				internal override Element wpzWcMxzqdVgTVfJjIbzkLgsfUIc(PlayerController P_0)
				{
					return new MouseWheel(P_0, this);
				}
			}

			public new MouseWheelAxis xAxis => WChpoUjfxVomSqiESmHoqccMwdg<MouseWheelAxis>(0);

			public new MouseWheelAxis yAxis => WChpoUjfxVomSqiESmHoqccMwdg<MouseWheelAxis>(1);

			internal MouseWheel(PlayerController parent, Definition definition)
				: base(parent, definition, (definition != null) ? new Element.Definition[2]
				{
					(definition.xAxis != null) ? definition.xAxis : new MouseWheelAxis.Definition(),
					(definition.yAxis != null) ? definition.yAxis : new MouseWheelAxis.Definition()
				} : null)
			{
			}
		}

		public sealed class MouseWheelAxis : Axis
		{
			public new class Definition : Axis.Definition
			{
				public float repeatRate;

				public Definition()
				{
					coordinateMode = AxisCoordinateMode.Relative;
					repeatRate = 4f;
				}

				internal override Element wpzWcMxzqdVgTVfJjIbzkLgsfUIc(PlayerController P_0)
				{
					return new MouseWheelAxis(P_0, this);
				}
			}

			[CustomObfuscation(rename = false)]
			internal const float defaultRepeatRate = 4f;

			[CustomObfuscation(rename = false)]
			internal new const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Relative;

			private const float DnMgLzcJNGeIkvRseCXMOGZEiGsK = 0.01f;

			private float nNFIYZMEjBAhzFxdiceVnbjAPIY = 0.25f;

			private double XFmjmMaWHhkEnFwzpXrBDioEFKDa;

			private float BUlTlwnOYIYrMrbKigONinVIGlB;

			public float repeatRate
			{
				get
				{
					if (nNFIYZMEjBAhzFxdiceVnbjAPIY == 0f)
					{
						return 0f;
					}
					return 1f / nNFIYZMEjBAhzFxdiceVnbjAPIY;
				}
				set
				{
					if (value < 0f)
					{
						value = 0f;
					}
					if (value == 0f)
					{
						nNFIYZMEjBAhzFxdiceVnbjAPIY = 0f;
					}
					else
					{
						nNFIYZMEjBAhzFxdiceVnbjAPIY = 1f / value;
					}
				}
			}

			public override float value
			{
				get
				{
					if (!base.selfAndParentEnabled)
					{
						return 0f;
					}
					return BUlTlwnOYIYrMrbKigONinVIGlB;
				}
			}

			internal MouseWheelAxis(PlayerController parent, Definition definition)
				: base(parent, definition)
			{
				repeatRate = definition.repeatRate;
			}

			internal override void QTPiZFmnRsxmyQYmMuIoBQkOtfg()
			{
				base.QTPiZFmnRsxmyQYmMuIoBQkOtfg();
				if (base.selfAndParentEnabled)
				{
					BUlTlwnOYIYrMrbKigONinVIGlB = RTqFTYIjxPoTQqrpuHMLUBpyYFS();
				}
			}

			protected override void EnabledStateChanged(bool state)
			{
				base.EnabledStateChanged(state);
				if (!state)
				{
					dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
				}
			}

			private float RTqFTYIjxPoTQqrpuHMLUBpyYFS()
			{
				if (base.player == null)
				{
					return 0f;
				}
				float num = base.player.GetAxis(base.actionId);
				switch (base.player.GetAxisCoordinateMode(base.actionId))
				{
				case AxisCoordinateMode.Absolute:
				{
					bool flag = false;
					if (base.player.GetButtonDown(base.actionId))
					{
						flag = true;
						num = 1f;
					}
					else if (base.player.GetNegativeButtonDown(base.actionId))
					{
						flag = true;
						num = -1f;
					}
					if (!flag && ReInput.unscaledTime < XFmjmMaWHhkEnFwzpXrBDioEFKDa + (double)nNFIYZMEjBAhzFxdiceVnbjAPIY)
					{
						return 0f;
					}
					if (Mathf.Abs(num) <= 0.01f)
					{
						return 0f;
					}
					num = Mathf.Sign(num);
					num *= base.absoluteToRelativeSensitivity;
					XFmjmMaWHhkEnFwzpXrBDioEFKDa = ReInput.unscaledTime;
					break;
				}
				}
				return num;
			}

			private void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
			{
				BUlTlwnOYIYrMrbKigONinVIGlB = 0f;
				XFmjmMaWHhkEnFwzpXrBDioEFKDa = 0.0;
			}
		}

		internal readonly int fhCkCLBQpxfjvFtQcQZeUtCOKFGZ;

		private bool TAiAzEAcNOkrpYWJEmhYYqnFvpF;

		private int ivfdKpZALpQIAdtIdHmkpPFkwfq;

		private readonly AList<Element> KFQlRixtegtOhokPEQnlitLaJDS;

		private readonly AList<Button> fMHXJPWJIudshUOjLfHOLECkvEl;

		private readonly AList<Axis> XiWNbwUWYHoLPxZyOZhRZbiCuVm;

		private readonly ReadOnlyCollection<Element> izLDyzKhaPvNHKsTLMyAkmTgGsf;

		private readonly ReadOnlyCollection<Button> SbTXOHYVHQxqjplfKPBFBpODmGN;

		private readonly ReadOnlyCollection<Axis> JcrLJYGDkpIAEDBLHjHTMpUXuMf;

		private readonly List<Element.OVKNllgCfimOjVJOPKJdXfpkuCe> mMHrVXJgucSxiIfkJEhuXVNotPC;

		private Action<int, bool> EVHecCIeKfNnNcQVhGtnZEvwJBzN;

		private Action<int, float> xKttxJFfhovSFQqyujyyqhpOHYE;

		private Action<bool> DXFSAUKlttPxoWkMUSsJgyyzmdk;

		public bool enabled
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return false;
				}
				return TAiAzEAcNOkrpYWJEmhYYqnFvpF;
			}
			set
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				}
				else
				{
					if (TAiAzEAcNOkrpYWJEmhYYqnFvpF == value)
					{
						return;
					}
					if (!value)
					{
						ClearVars();
					}
					TAiAzEAcNOkrpYWJEmhYYqnFvpF = value;
					for (int i = 0; i < KFQlRixtegtOhokPEQnlitLaJDS._count; i++)
					{
						KFQlRixtegtOhokPEQnlitLaJDS[i].enabled = value;
					}
					if (DXFSAUKlttPxoWkMUSsJgyyzmdk != null)
					{
						try
						{
							DXFSAUKlttPxoWkMUSsJgyyzmdk(value);
						}
						catch (Exception ex)
						{
							Logger.LogError("An exception occurred in a listener of EnabledStateChangedEvent. This means an exception was thrown by your code.\n" + ex);
						}
					}
				}
			}
		}

		public int playerId
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return -1;
				}
				return ivfdKpZALpQIAdtIdHmkpPFkwfq;
			}
			set
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				}
				else if (ivfdKpZALpQIAdtIdHmkpPFkwfq != value)
				{
					ivfdKpZALpQIAdtIdHmkpPFkwfq = value;
					ClearVars();
				}
			}
		}

		public IList<Button> buttons
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return null;
				}
				return SbTXOHYVHQxqjplfKPBFBpODmGN;
			}
		}

		public IList<Axis> axes
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return null;
				}
				return JcrLJYGDkpIAEDBLHjHTMpUXuMf;
			}
		}

		public IList<Element> elements
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return null;
				}
				return izLDyzKhaPvNHKsTLMyAkmTgGsf;
			}
		}

		public int buttonCount
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return 0;
				}
				if (fMHXJPWJIudshUOjLfHOLECkvEl == null)
				{
					return 0;
				}
				return fMHXJPWJIudshUOjLfHOLECkvEl._count;
			}
		}

		public int axisCount
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return 0;
				}
				if (XiWNbwUWYHoLPxZyOZhRZbiCuVm == null)
				{
					return 0;
				}
				return XiWNbwUWYHoLPxZyOZhRZbiCuVm._count;
			}
		}

		public int elementCount
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return 0;
				}
				if (KFQlRixtegtOhokPEQnlitLaJDS == null)
				{
					return 0;
				}
				return KFQlRixtegtOhokPEQnlitLaJDS._count;
			}
		}

		internal Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.players.GetPlayer(playerId);
			}
		}

		public event Action<int, bool> ButtonStateChangedEvent
		{
			add
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				}
				else
				{
					EVHecCIeKfNnNcQVhGtnZEvwJBzN = (Action<int, bool>)Delegate.Combine(EVHecCIeKfNnNcQVhGtnZEvwJBzN, value);
				}
			}
			remove
			{
				EVHecCIeKfNnNcQVhGtnZEvwJBzN = (Action<int, bool>)Delegate.Remove(EVHecCIeKfNnNcQVhGtnZEvwJBzN, value);
			}
		}

		public event Action<int, float> AxisValueChangedEvent
		{
			add
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				}
				else
				{
					xKttxJFfhovSFQqyujyyqhpOHYE = (Action<int, float>)Delegate.Combine(xKttxJFfhovSFQqyujyyqhpOHYE, value);
				}
			}
			remove
			{
				xKttxJFfhovSFQqyujyyqhpOHYE = (Action<int, float>)Delegate.Remove(xKttxJFfhovSFQqyujyyqhpOHYE, value);
			}
		}

		public event Action<bool> EnabledStateChangedEvent
		{
			add
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				}
				else
				{
					DXFSAUKlttPxoWkMUSsJgyyzmdk = (Action<bool>)Delegate.Combine(DXFSAUKlttPxoWkMUSsJgyyzmdk, value);
				}
			}
			remove
			{
				DXFSAUKlttPxoWkMUSsJgyyzmdk = (Action<bool>)Delegate.Remove(DXFSAUKlttPxoWkMUSsJgyyzmdk, value);
			}
		}

		internal PlayerController(Definition definition)
		{
			if (definition == null)
			{
				throw new ArgumentNullException("definition");
			}
			if (definition.elements == null)
			{
				throw new ArgumentNullException("definition.elements");
			}
			fhCkCLBQpxfjvFtQcQZeUtCOKFGZ = ReInput._id;
			ivfdKpZALpQIAdtIdHmkpPFkwfq = definition.playerId;
			TAiAzEAcNOkrpYWJEmhYYqnFvpF = definition.enabled;
			List<Element> list = new List<Element>();
			List<Element> list2 = new List<Element>();
			List<Button> list3 = new List<Button>();
			List<Axis> list4 = new List<Axis>();
			foreach (Element.Definition element in definition.elements)
			{
				sPDBUryojEPTZhjXiDvYbSylxsi(element.wpzWcMxzqdVgTVfJjIbzkLgsfUIc(this), list, list2, list3, list4);
			}
			list.AddRange(list2);
			KFQlRixtegtOhokPEQnlitLaJDS = new AList<Element>(list);
			fMHXJPWJIudshUOjLfHOLECkvEl = new AList<Button>(list3);
			XiWNbwUWYHoLPxZyOZhRZbiCuVm = new AList<Axis>(list4);
			izLDyzKhaPvNHKsTLMyAkmTgGsf = new ReadOnlyCollection<Element>(KFQlRixtegtOhokPEQnlitLaJDS);
			SbTXOHYVHQxqjplfKPBFBpODmGN = new ReadOnlyCollection<Button>(fMHXJPWJIudshUOjLfHOLECkvEl);
			JcrLJYGDkpIAEDBLHjHTMpUXuMf = new ReadOnlyCollection<Axis>(XiWNbwUWYHoLPxZyOZhRZbiCuVm);
			mMHrVXJgucSxiIfkJEhuXVNotPC = new List<Element.OVKNllgCfimOjVJOPKJdXfpkuCe>();
			ReInput.UpdateEndedEvent += yQdUgprBXDEoWjnetusIxRhMmAu;
		}

		~PlayerController()
		{
			ReInput.UpdateEndedEvent -= yQdUgprBXDEoWjnetusIxRhMmAu;
		}

		public bool GetButton(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if ((uint)index >= (uint)fMHXJPWJIudshUOjLfHOLECkvEl._count)
			{
				return false;
			}
			return fMHXJPWJIudshUOjLfHOLECkvEl[index].value;
		}

		public bool GetButtonDown(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if ((uint)index >= (uint)fMHXJPWJIudshUOjLfHOLECkvEl._count)
			{
				return false;
			}
			return fMHXJPWJIudshUOjLfHOLECkvEl[index].justPressed;
		}

		public bool GetButtonUp(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if ((uint)index >= (uint)fMHXJPWJIudshUOjLfHOLECkvEl._count)
			{
				return false;
			}
			return fMHXJPWJIudshUOjLfHOLECkvEl[index].justReleased;
		}

		public float GetAxis(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0f;
			}
			if ((uint)index >= (uint)XiWNbwUWYHoLPxZyOZhRZbiCuVm._count)
			{
				return 0f;
			}
			return XiWNbwUWYHoLPxZyOZhRZbiCuVm[index].value;
		}

		public float GetAxisRaw(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0f;
			}
			if ((uint)index >= (uint)XiWNbwUWYHoLPxZyOZhRZbiCuVm._count)
			{
				return 0f;
			}
			return XiWNbwUWYHoLPxZyOZhRZbiCuVm[index].valueRaw;
		}

		public Element GetElement(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			if ((uint)index >= (uint)XiWNbwUWYHoLPxZyOZhRZbiCuVm._count)
			{
				return null;
			}
			return KFQlRixtegtOhokPEQnlitLaJDS[index];
		}

		public T GetElement<T>(int index) where T : Element
		{
			return GetElement(index) as T;
		}

		private void yQdUgprBXDEoWjnetusIxRhMmAu(UpdateLoopType P_0)
		{
			Update(P_0);
			UpdateFinished();
		}

		protected virtual bool Update(UpdateLoopType updateLoop)
		{
			if (!TAiAzEAcNOkrpYWJEmhYYqnFvpF)
			{
				return false;
			}
			bool flag = xKttxJFfhovSFQqyujyyqhpOHYE != null;
			bool flag2 = EVHecCIeKfNnNcQVhGtnZEvwJBzN != null;
			for (int i = 0; i < KFQlRixtegtOhokPEQnlitLaJDS._count; i++)
			{
				float num = 0f;
				if (flag && KFQlRixtegtOhokPEQnlitLaJDS[i] is Axis)
				{
					Axis axis = KFQlRixtegtOhokPEQnlitLaJDS[i] as Axis;
					num = ((axis.coordinateMode != AxisCoordinateMode.Absolute) ? 0f : axis.value);
				}
				KFQlRixtegtOhokPEQnlitLaJDS[i].QTPiZFmnRsxmyQYmMuIoBQkOtfg();
				if (flag2 && KFQlRixtegtOhokPEQnlitLaJDS[i] is Button)
				{
					Button button = KFQlRixtegtOhokPEQnlitLaJDS[i] as Button;
					if (button.justPressed && button.value)
					{
						mMHrVXJgucSxiIfkJEhuXVNotPC.Add(new Element.OVKNllgCfimOjVJOPKJdXfpkuCe(ControllerElementType.Button, i, 1f));
					}
					else if (button.justReleased && !button.value)
					{
						mMHrVXJgucSxiIfkJEhuXVNotPC.Add(new Element.OVKNllgCfimOjVJOPKJdXfpkuCe(ControllerElementType.Button, i, 0f));
					}
				}
				else if (flag && KFQlRixtegtOhokPEQnlitLaJDS[i] is Axis)
				{
					mMHrVXJgucSxiIfkJEhuXVNotPC.Add(new Element.OVKNllgCfimOjVJOPKJdXfpkuCe(ControllerElementType.Axis, i, (KFQlRixtegtOhokPEQnlitLaJDS[i] as Axis).value - num));
				}
			}
			return true;
		}

		protected virtual void UpdateFinished()
		{
			int count = mMHrVXJgucSxiIfkJEhuXVNotPC.Count;
			if (count <= 0)
			{
				return;
			}
			for (int i = 0; i < count; i++)
			{
				Element.OVKNllgCfimOjVJOPKJdXfpkuCe oVKNllgCfimOjVJOPKJdXfpkuCe = mMHrVXJgucSxiIfkJEhuXVNotPC[i];
				if (oVKNllgCfimOjVJOPKJdXfpkuCe.vfOgoNYdPlyNOyYmKzOzPipRXne == ControllerElementType.Button)
				{
					try
					{
						EVHecCIeKfNnNcQVhGtnZEvwJBzN(oVKNllgCfimOjVJOPKJdXfpkuCe.qFslVgpsJvzXCDAccmwaJAuNiAc, (oVKNllgCfimOjVJOPKJdXfpkuCe.HpxePuhaScltgSCBmgsrsCpjliL > 0f) ? true : false);
					}
					catch (Exception ex)
					{
						Logger.LogError("An exception occurred in a listener of ButtonStateChangedEvent. This means an exception was thrown by your code.\n" + ex);
					}
				}
				else if (oVKNllgCfimOjVJOPKJdXfpkuCe.vfOgoNYdPlyNOyYmKzOzPipRXne == ControllerElementType.Axis)
				{
					try
					{
						xKttxJFfhovSFQqyujyyqhpOHYE(oVKNllgCfimOjVJOPKJdXfpkuCe.qFslVgpsJvzXCDAccmwaJAuNiAc, oVKNllgCfimOjVJOPKJdXfpkuCe.HpxePuhaScltgSCBmgsrsCpjliL);
					}
					catch (Exception ex2)
					{
						Logger.LogError("An exception occurred in a listener of AxisValueChangedEvent. This means an exception was thrown by your code.\n" + ex2);
					}
				}
			}
			mMHrVXJgucSxiIfkJEhuXVNotPC.Clear();
		}

		protected virtual void ClearVars()
		{
			mMHrVXJgucSxiIfkJEhuXVNotPC.Clear();
		}

		internal void sPDBUryojEPTZhjXiDvYbSylxsi(Element P_0)
		{
			if (P_0 != null)
			{
				if (P_0 is Axis)
				{
					XiWNbwUWYHoLPxZyOZhRZbiCuVm.Add(P_0 as Axis);
				}
				else if (P_0 is Button)
				{
					fMHXJPWJIudshUOjLfHOLECkvEl.Add(P_0 as Button);
				}
				KFQlRixtegtOhokPEQnlitLaJDS.Add(P_0);
			}
		}

		private void sPDBUryojEPTZhjXiDvYbSylxsi(Element P_0, List<Element> P_1, List<Element> P_2, List<Button> P_3, List<Axis> P_4)
		{
			if (P_0 == null)
			{
				return;
			}
			P_0.GetType();
			if (P_0 is ElementWithSource)
			{
				if (P_0 is Button)
				{
					P_3.Add((Button)P_0);
				}
				else
				{
					if (!(P_0 is Axis))
					{
						Logger.LogWarning("Unknown Element type encountered: " + P_0.GetType());
						return;
					}
					P_4.Add((Axis)P_0);
				}
				P_1.Add(P_0);
			}
			else if (P_0 is CompoundElement)
			{
				using (TempListPool.TList<Element> tList = TempListPool.GetTList<Element>())
				{
					List<Element> list = tList.list;
					(P_0 as CompoundElement).HHYIRrxedtPnBiLqhPjvTilEoES(list);
					for (int i = 0; i < list.Count; i++)
					{
						sPDBUryojEPTZhjXiDvYbSylxsi(list[i], P_1, P_2, P_3, P_4);
					}
				}
				P_2.Add(P_0);
			}
			else
			{
				Logger.LogWarning("Unknown Element type encountered: " + P_0.GetType());
			}
		}

		internal static int csxuKUIFFDGmHdlmOknQRXQYDjW<T>(IList<T> P_0, Predicate<T> P_1, int P_2) where T : Element
		{
			int num = 0;
			for (int i = 0; i < P_0.Count; i++)
			{
				if (P_1(P_0[i]))
				{
					num++;
				}
				if (num == P_2)
				{
					return i;
				}
			}
			return -1;
		}
	}
}
