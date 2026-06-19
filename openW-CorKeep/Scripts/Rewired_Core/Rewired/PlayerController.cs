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

				public Definition()
				{
					coordinateMode = AxisCoordinateMode.Absolute;
					absoluteToRelativeSensitivity = 1f;
					absoluteToRelativeScalingMode = AbsoluteToRelativeScalingMode.None;
				}

				internal virtual Element hWYQPTFqogswzLaYYtKzNHqmSKPq(PlayerController P_0)
				{
					return new Axis(P_0, this);
				}
			}

			internal const float tPrdYQirqhIWWDFkYIQWMOAAscjK = 1f;

			internal const AbsoluteToRelativeScalingMode stHGOCBPjAacDrFWudmgSZiaSlZw = AbsoluteToRelativeScalingMode.None;

			[CustomObfuscation(rename = false)]
			internal const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Absolute;

			private float VtbCBCgBwTjiXJgEGjtUrKzRPblwA = 1f;

			private AxisCoordinateMode eyHiFhnCVRCnfKCZculWNxEPOihWA;

			private AbsoluteToRelativeScalingMode HOqARMCigopNiGejBHTemBduPYcA;

			public float absoluteToRelativeSensitivity
			{
				get
				{
					return VtbCBCgBwTjiXJgEGjtUrKzRPblwA;
				}
				set
				{
					if (value < 0f)
					{
						value = 0f;
					}
					VtbCBCgBwTjiXJgEGjtUrKzRPblwA = value;
				}
			}

			public AbsoluteToRelativeScalingMode absoluteToRelativeScalingMode
			{
				get
				{
					return HOqARMCigopNiGejBHTemBduPYcA;
				}
				set
				{
					HOqARMCigopNiGejBHTemBduPYcA = value;
				}
			}

			public AxisCoordinateMode coordinateMode => eyHiFhnCVRCnfKCZculWNxEPOihWA;

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
						if (eyHiFhnCVRCnfKCZculWNxEPOihWA == AxisCoordinateMode.Absolute)
						{
							return 0f;
						}
						break;
					case AxisCoordinateMode.Absolute:
						if (eyHiFhnCVRCnfKCZculWNxEPOihWA == AxisCoordinateMode.Relative)
						{
							switch (HOqARMCigopNiGejBHTemBduPYcA)
							{
							case AbsoluteToRelativeScalingMode.ScreenHeight:
								num *= (float)Screen.currentResolution.height / absoluteToRelativeScalingReferenceResolution.y;
								break;
							case AbsoluteToRelativeScalingMode.ScreenWidth:
								num *= (float)Screen.currentResolution.width / absoluteToRelativeScalingReferenceResolution.x;
								break;
							case AbsoluteToRelativeScalingMode.ViewportHeight:
								num *= (float)Screen.height / absoluteToRelativeScalingReferenceResolution.y;
								break;
							case AbsoluteToRelativeScalingMode.ViewportWidth:
								num *= (float)Screen.width / absoluteToRelativeScalingReferenceResolution.x;
								break;
							case AbsoluteToRelativeScalingMode.MaxScreenDimension:
								num = ((Screen.currentResolution.width < Screen.currentResolution.height) ? (num * ((float)Screen.currentResolution.height / absoluteToRelativeScalingReferenceResolution.y)) : (num * ((float)Screen.currentResolution.width / absoluteToRelativeScalingReferenceResolution.x)));
								break;
							case AbsoluteToRelativeScalingMode.MinScreenDimension:
								num = ((Screen.currentResolution.width > Screen.currentResolution.height) ? (num * ((float)Screen.currentResolution.height / absoluteToRelativeScalingReferenceResolution.y)) : (num * ((float)Screen.currentResolution.width / absoluteToRelativeScalingReferenceResolution.x)));
								break;
							case AbsoluteToRelativeScalingMode.MaxViewportDimension:
								num = ((Screen.width < Screen.height) ? (num * ((float)Screen.height / absoluteToRelativeScalingReferenceResolution.y)) : (num * ((float)Screen.width / absoluteToRelativeScalingReferenceResolution.x)));
								break;
							case AbsoluteToRelativeScalingMode.MinViewportDimension:
								num = ((Screen.width > Screen.height) ? (num * ((float)Screen.height / absoluteToRelativeScalingReferenceResolution.y)) : (num * ((float)Screen.width / absoluteToRelativeScalingReferenceResolution.x)));
								break;
							}
							num *= (float)ReInput.unscaledDeltaTime * VtbCBCgBwTjiXJgEGjtUrKzRPblwA;
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

			internal Axis(PlayerController P_0, Definition P_1)
				: base(P_0, P_1)
			{
				VtbCBCgBwTjiXJgEGjtUrKzRPblwA = P_1.absoluteToRelativeSensitivity;
				eyHiFhnCVRCnfKCZculWNxEPOihWA = P_1.coordinateMode;
				HOqARMCigopNiGejBHTemBduPYcA = P_1.absoluteToRelativeScalingMode;
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
					absoluteToRelativeScalingMode = AbsoluteToRelativeScalingMode.ScreenWidth;
				}

				internal virtual Element npzVFVJqCkmqjbACElvDExmzhZid(PlayerController P_0)
				{
					return new MouseAxis(P_0, this);
				}
			}

			[CustomObfuscation(rename = false)]
			internal new const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Relative;

			[CustomObfuscation(rename = false)]
			internal const float defaultAbsoluteToRelativeSensitivity = 600f;

			[CustomObfuscation(rename = false)]
			internal const AbsoluteToRelativeScalingMode defaultAbsoluteToRelativeScalingMode = AbsoluteToRelativeScalingMode.ScreenWidth;

			internal MouseAxis(PlayerController P_0, Definition P_1)
				: base(P_0, P_1)
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
						return TvPHbFeFTcjagBhnoWLNwnLLnoZU;
					}
					set
					{
						TvPHbFeFTcjagBhnoWLNwnLLnoZU = value;
					}
				}

				public Axis.Definition yAxis
				{
					get
					{
						return qaEFXleQALSJdFlwenVgmiLDPoAoD;
					}
					set
					{
						qaEFXleQALSJdFlwenVgmiLDPoAoD = value;
					}
				}

				internal virtual Element dRHsYfSpijmzGyQvpHzNfYzfYQzH(PlayerController P_0)
				{
					return new Axis2D(P_0, this);
				}
			}

			internal const int aEgbgzhMcvYNpxsITtMoOaTZfZnF = 0;

			internal const int bvoORUoUuRhSBFLBkLxppLVhtVnw = 1;

			internal const int qrHpOKjsklwBhhYiwnegnTxxufQw = 2;

			public Axis xAxis => JPJVGRrhOYQVAtaysguIblNbDoVC<Axis>(0);

			public Axis yAxis => JPJVGRrhOYQVAtaysguIblNbDoVC<Axis>(1);

			public virtual Vector2 value => new Vector2(JPJVGRrhOYQVAtaysguIblNbDoVC<Axis>(0).value, JPJVGRrhOYQVAtaysguIblNbDoVC<Axis>(1).value);

			public virtual Vector2 valueRaw => new Vector2(JPJVGRrhOYQVAtaysguIblNbDoVC<Axis>(0).valueRaw, JPJVGRrhOYQVAtaysguIblNbDoVC<Axis>(1).valueRaw);

			internal Axis2D(PlayerController P_0, Definition P_1, Element.Definition[] P_2)
				: base(P_0, P_1, P_2)
			{
			}

			internal Axis2D(PlayerController P_0, Definition P_1)
				: base(P_0, P_1, (P_1 == null) ? null : new Element.Definition[2]
				{
					(P_1.xAxis != null) ? P_1.xAxis : new Axis.Definition(),
					(P_1.yAxis != null) ? P_1.yAxis : new Axis.Definition()
				})
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

				internal virtual Element htLdEihparExQBNTVWWuHzikxHueA(PlayerController P_0)
				{
					return new MouseAxis2D(P_0, this);
				}
			}

			public new MouseAxis xAxis => JPJVGRrhOYQVAtaysguIblNbDoVC<MouseAxis>(0);

			public new MouseAxis yAxis => JPJVGRrhOYQVAtaysguIblNbDoVC<MouseAxis>(1);

			internal MouseAxis2D(PlayerController P_0, Definition P_1)
				: base(P_0, P_1, (P_1 == null) ? null : new Element.Definition[2]
				{
					(P_1.xAxis != null) ? P_1.xAxis : new MouseAxis.Definition(),
					(P_1.yAxis != null) ? P_1.yAxis : new MouseAxis.Definition()
				})
			{
			}
		}

		public sealed class Button : ElementWithSource
		{
			public new class Definition : ElementWithSource.Definition
			{
				internal virtual Element OaALlfzPybHOkXXzIrXFaNkCrLJr(PlayerController P_0)
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

			internal Button(PlayerController P_0, Definition P_1)
				: base(P_0, P_1)
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

			internal int DTeMmgqLftsfPKSPRjlETbtOuVIj => VOTGTurgpyKzDejhwRLDgbBLPdvv.Count;

			internal CompoundElement(PlayerController P_0, Definition P_1, Element.Definition[] P_2)
				: base(P_0, P_1)
			{
				VOTGTurgpyKzDejhwRLDgbBLPdvv = new List<Element>();
				if (P_2 == null)
				{
					return;
				}
				for (int i = 0; i < P_2.Length; i++)
				{
					if (P_2[i] != null)
					{
						dzirdOZVpgwhAywrJHHzVzmYfYZH(P_2[i].xdjxkDjtSSdBMsvOUqGtSDbsuJlH(P_0));
					}
				}
			}

			internal _0001 JPJVGRrhOYQVAtaysguIblNbDoVC<_0001>(int P_0) where _0001 : Element
			{
				if ((uint)P_0 >= (uint)VOTGTurgpyKzDejhwRLDgbBLPdvv.Count)
				{
					return null;
				}
				return VOTGTurgpyKzDejhwRLDgbBLPdvv[P_0] as _0001;
			}

			internal void GhWYunooGqCpkeZmANjUefxvYGtjA(List<Element> P_0)
			{
				for (int i = 0; i < VOTGTurgpyKzDejhwRLDgbBLPdvv.Count; i++)
				{
					if (VOTGTurgpyKzDejhwRLDgbBLPdvv[i] is CompoundElement)
					{
						(VOTGTurgpyKzDejhwRLDgbBLPdvv[i] as CompoundElement).GhWYunooGqCpkeZmANjUefxvYGtjA(P_0);
					}
					else
					{
						P_0.Add(VOTGTurgpyKzDejhwRLDgbBLPdvv[i]);
					}
				}
			}

			internal void dzirdOZVpgwhAywrJHHzVzmYfYZH(Element P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("element");
				}
				VOTGTurgpyKzDejhwRLDgbBLPdvv.Add(P_0);
				P_0.RqFMzefgLvcrkHcahUASVRYomsRJ = true;
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

				internal abstract Element xdjxkDjtSSdBMsvOUqGtSDbsuJlH(PlayerController P_0);
			}

			internal struct UJinuItmyzahmebrnEFgySjMJMHO
			{
				public ControllerElementType MINaxwHudqzRnmKspPKysxrlJwNHA;

				public int zgCOpCObfTGMEGJVtKwoUeCLKRtQ;

				public float lboRhBZfNTAcCNNmmcptFhMrxTRqA;

				public UJinuItmyzahmebrnEFgySjMJMHO(ControllerElementType P_0, int P_1, float P_2)
				{
					MINaxwHudqzRnmKspPKysxrlJwNHA = P_0;
					zgCOpCObfTGMEGJVtKwoUeCLKRtQ = P_1;
					lboRhBZfNTAcCNNmmcptFhMrxTRqA = P_2;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const bool defaultEnabled = true;

			private readonly PlayerController jWzSQytjQYkVGDbEalhpaBFQPtDQ;

			private bool ElJjdkbLCJewcFDuaknMcczhQLqP;

			private bool TPfrAnWbwTrcjCdIoDeGZnsSfcdB = true;

			private string YygfdTKoLuFjQugIzFLrzTJSjoVX;

			private static int[] BXxQizqhHQikxIOYzWVkilMFwnkd;

			private static int[] ZFgoqgJZrpmGKjLxwbnkVWjlvwef;

			protected Player player
			{
				get
				{
					if (!ReInput.isReady)
					{
						return null;
					}
					return ReInput.players.GetPlayer(jWzSQytjQYkVGDbEalhpaBFQPtDQ.YJUZOvVHMEIRrjJItipRtWYWXQEJA);
				}
			}

			protected bool selfAndParentEnabled
			{
				get
				{
					if (TPfrAnWbwTrcjCdIoDeGZnsSfcdB)
					{
						return jWzSQytjQYkVGDbEalhpaBFQPtDQ.wXmdUPKjxYymCkUzIcPwxgIaacod;
					}
					return false;
				}
			}

			internal bool RqFMzefgLvcrkHcahUASVRYomsRJ
			{
				get
				{
					return ElJjdkbLCJewcFDuaknMcczhQLqP;
				}
				set
				{
					ElJjdkbLCJewcFDuaknMcczhQLqP = true;
				}
			}

			public bool enabled
			{
				get
				{
					return TPfrAnWbwTrcjCdIoDeGZnsSfcdB;
				}
				set
				{
					if (TPfrAnWbwTrcjCdIoDeGZnsSfcdB != value)
					{
						TPfrAnWbwTrcjCdIoDeGZnsSfcdB = value;
						EnabledStateChanged(value);
					}
				}
			}

			public string name
			{
				get
				{
					return YygfdTKoLuFjQugIzFLrzTJSjoVX;
				}
				set
				{
					YygfdTKoLuFjQugIzFLrzTJSjoVX = value;
				}
			}

			internal Element(PlayerController P_0, Definition P_1)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("parent");
				}
				if (P_1 == null)
				{
					throw new ArgumentNullException("definition");
				}
				jWzSQytjQYkVGDbEalhpaBFQPtDQ = P_0;
				TPfrAnWbwTrcjCdIoDeGZnsSfcdB = P_1.enabled;
				YygfdTKoLuFjQugIzFLrzTJSjoVX = P_1.name;
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
				if (BXxQizqhHQikxIOYzWVkilMFwnkd == null)
				{
					BXxQizqhHQikxIOYzWVkilMFwnkd = (int[])Enum.GetValues(typeof(TypeWithSource));
				}
				return ArrayTools.Contains(BXxQizqhHQikxIOYzWVkilMFwnkd, (int)type);
			}

			[CustomObfuscation(rename = false)]
			internal static bool IsCompoundType(Type type)
			{
				if (ZFgoqgJZrpmGKjLxwbnkVWjlvwef == null)
				{
					ZFgoqgJZrpmGKjLxwbnkVWjlvwef = (int[])Enum.GetValues(typeof(CompoundTypes));
				}
				return ArrayTools.Contains(ZFgoqgJZrpmGKjLxwbnkVWjlvwef, (int)type);
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
					if ((uint)(type - 100) <= 2u)
					{
						if (index != 0)
						{
							return "Y Axis";
						}
						return "X Axis";
					}
					throw new NotImplementedException();
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
				private int cVfUcFFbhowaaAhuBABBCYPZnkMNA;

				public int actionId
				{
					get
					{
						return cVfUcFFbhowaaAhuBABBCYPZnkMNA;
					}
					set
					{
						cVfUcFFbhowaaAhuBABBCYPZnkMNA = value;
					}
				}

				public string actionName
				{
					get
					{
						if (!ReInput.isReady || cVfUcFFbhowaaAhuBABBCYPZnkMNA < 0)
						{
							return null;
						}
						return ReInput.mapping.GetAction(cVfUcFFbhowaaAhuBABBCYPZnkMNA)?.name;
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
							cVfUcFFbhowaaAhuBABBCYPZnkMNA = -1;
						}
						else
						{
							cVfUcFFbhowaaAhuBABBCYPZnkMNA = action.id;
						}
					}
				}

				public Definition()
				{
					cVfUcFFbhowaaAhuBABBCYPZnkMNA = -1;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const int defaultActionId = -1;

			private int FxuThkEZoqlKTopVeNJybxWAEVqC = -1;

			public int actionId
			{
				get
				{
					return FxuThkEZoqlKTopVeNJybxWAEVqC;
				}
				set
				{
					FxuThkEZoqlKTopVeNJybxWAEVqC = value;
				}
			}

			public string actionName
			{
				get
				{
					if (!ReInput.isReady || FxuThkEZoqlKTopVeNJybxWAEVqC < 0)
					{
						return null;
					}
					return ReInput.mapping.GetAction(FxuThkEZoqlKTopVeNJybxWAEVqC)?.name;
				}
				set
				{
					if (ReInput.isReady)
					{
						InputAction action = ReInput.mapping.GetAction(value);
						if (action == null)
						{
							FxuThkEZoqlKTopVeNJybxWAEVqC = -1;
						}
						else
						{
							FxuThkEZoqlKTopVeNJybxWAEVqC = action.id;
						}
					}
				}
			}

			internal ElementWithSource(PlayerController P_0, Definition P_1)
				: base(P_0, P_1)
			{
				FxuThkEZoqlKTopVeNJybxWAEVqC = P_1.actionId;
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

				internal virtual Element zMNacAChdaudFtNTodvyCUFaylQwA(PlayerController P_0)
				{
					return new MouseWheel(P_0, this);
				}
			}

			public new MouseWheelAxis xAxis => JPJVGRrhOYQVAtaysguIblNbDoVC<MouseWheelAxis>(0);

			public new MouseWheelAxis yAxis => JPJVGRrhOYQVAtaysguIblNbDoVC<MouseWheelAxis>(1);

			internal MouseWheel(PlayerController P_0, Definition P_1)
				: base(P_0, P_1, (P_1 == null) ? null : new Element.Definition[2]
				{
					(P_1.xAxis != null) ? P_1.xAxis : new MouseWheelAxis.Definition(),
					(P_1.yAxis != null) ? P_1.yAxis : new MouseWheelAxis.Definition()
				})
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

				internal virtual Element JdLCtautdsyinqGxPDNodCAvmYRU(PlayerController P_0)
				{
					return new MouseWheelAxis(P_0, this);
				}
			}

			[CustomObfuscation(rename = false)]
			internal const float defaultRepeatRate = 4f;

			[CustomObfuscation(rename = false)]
			internal new const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Relative;

			private const float cLeaKfPnxomKWZuyUvGxNTsBSOiK = 0.01f;

			private float hhLCRNCAXsAJeRCYQeArcweKOfYBA = 0.25f;

			private double AtRgzJJWGvbwfJvWLQlIPkZYpcqh;

			private float NBdoEVletwXEBBOoHTNFXDspaJdiA;

			public float repeatRate
			{
				get
				{
					if (hhLCRNCAXsAJeRCYQeArcweKOfYBA == 0f)
					{
						return 0f;
					}
					return 1f / hhLCRNCAXsAJeRCYQeArcweKOfYBA;
				}
				set
				{
					if (value < 0f)
					{
						value = 0f;
					}
					if (value == 0f)
					{
						hhLCRNCAXsAJeRCYQeArcweKOfYBA = 0f;
					}
					else
					{
						hhLCRNCAXsAJeRCYQeArcweKOfYBA = 1f / value;
					}
				}
			}

			float Axis.value
			{
				get
				{
					if (!base.selfAndParentEnabled)
					{
						return 0f;
					}
					return NBdoEVletwXEBBOoHTNFXDspaJdiA;
				}
			}

			internal MouseWheelAxis(PlayerController P_0, Definition P_1)
				: base(P_0, P_1)
			{
				repeatRate = P_1.repeatRate;
			}

			internal void XRZctRaCROCXWqhaGJwTtEDHzOcT()
			{
				base.ZzpEhhoJPpGrPVOAEfTyoEYwnsZu();
				if (base.selfAndParentEnabled)
				{
					NBdoEVletwXEBBOoHTNFXDspaJdiA = LmCPMREttphSxLsmyXDctFydsWvC();
				}
			}

			protected override void EnabledStateChanged(bool state)
			{
				base.EnabledStateChanged(state);
				if (!state)
				{
					ksTDCzmtroANHSkbmwLerfBrUBPc();
				}
			}

			private float LmCPMREttphSxLsmyXDctFydsWvC()
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
					if (base.player.GetNegativeButtonDown(base.actionId))
					{
						flag = true;
						num = -1f;
					}
					if (!flag && ReInput.unscaledTime < AtRgzJJWGvbwfJvWLQlIPkZYpcqh + (double)hhLCRNCAXsAJeRCYQeArcweKOfYBA)
					{
						return 0f;
					}
					if (Mathf.Abs(num) <= 0.01f)
					{
						return 0f;
					}
					num = Mathf.Sign(num);
					num *= base.absoluteToRelativeSensitivity;
					AtRgzJJWGvbwfJvWLQlIPkZYpcqh = ReInput.unscaledTime;
					break;
				}
				}
				return num;
			}

			private void ksTDCzmtroANHSkbmwLerfBrUBPc()
			{
				NBdoEVletwXEBBOoHTNFXDspaJdiA = 0f;
				AtRgzJJWGvbwfJvWLQlIPkZYpcqh = 0.0;
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

		private static Vector2 vMZvTcNCmcvYTADFySwEkhBEjUpr = new Vector2(1920f, 1080f);

		bool IPlayerController.enabled
		{
			get
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
					return false;
				}
				return wXmdUPKjxYymCkUzIcPwxgIaacod;
			}
			set
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
				}
				else
				{
					if (wXmdUPKjxYymCkUzIcPwxgIaacod == value)
					{
						return;
					}
					if (!value)
					{
						ClearVars();
					}
					wXmdUPKjxYymCkUzIcPwxgIaacod = value;
					for (int i = 0; i < bEdnyspCxFXDgXHFkFWZbcODtIuL._count; i++)
					{
						bEdnyspCxFXDgXHFkFWZbcODtIuL[i].enabled = value;
					}
					if (xFyyUZZIptJIYeSTJixtGCwLHvWT != null)
					{
						try
						{
							xFyyUZZIptJIYeSTJixtGCwLHvWT(value);
						}
						catch (Exception ex)
						{
							Logger.LogError("An exception occurred in a listener of EnabledStateChangedEvent. This means an exception was thrown by your code.\n" + ex);
						}
					}
				}
			}
		}

		int IPlayerController.playerId
		{
			get
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
					return -1;
				}
				return YJUZOvVHMEIRrjJItipRtWYWXQEJA;
			}
			set
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
				}
				else if (YJUZOvVHMEIRrjJItipRtWYWXQEJA != value)
				{
					YJUZOvVHMEIRrjJItipRtWYWXQEJA = value;
					ClearVars();
				}
			}
		}

		IList<Button> IPlayerController.buttons
		{
			get
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
					return null;
				}
				return xyaEqeFYBfgtubJjKNooszCIZJLec;
			}
		}

		IList<Axis> IPlayerController.axes
		{
			get
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
					return null;
				}
				return PuYOfofOPVbqOfkqLVwJGLYvXEOB;
			}
		}

		IList<Element> IPlayerController.elements
		{
			get
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
					return null;
				}
				return pAaNfAqsMacTFBBHIgXrupOjHiNz;
			}
		}

		int IPlayerController.buttonCount
		{
			get
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
					return 0;
				}
				if (lOzudZCCJLsQvjBFZYglwzqlZPBC == null)
				{
					return 0;
				}
				return lOzudZCCJLsQvjBFZYglwzqlZPBC._count;
			}
		}

		int IPlayerController.axisCount
		{
			get
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
					return 0;
				}
				if (QhFbjUjHOKvjBSJTdpqRNrMtaALW == null)
				{
					return 0;
				}
				return QhFbjUjHOKvjBSJTdpqRNrMtaALW._count;
			}
		}

		int IPlayerController.elementCount
		{
			get
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
					return 0;
				}
				if (bEdnyspCxFXDgXHFkFWZbcODtIuL == null)
				{
					return 0;
				}
				return bEdnyspCxFXDgXHFkFWZbcODtIuL._count;
			}
		}

		internal Player FJqAmuJWVSTbDOtWMyWBapBlIonGA
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.players.GetPlayer(Rewired_002EIPlayerController_002EplayerId);
			}
		}

		public static Vector2 absoluteToRelativeScalingReferenceResolution
		{
			get
			{
				return vMZvTcNCmcvYTADFySwEkhBEjUpr;
			}
			set
			{
				if (value.x < 1f)
				{
					value.x = 1f;
				}
				if (value.y < 1f)
				{
					value.y = 1f;
				}
				vMZvTcNCmcvYTADFySwEkhBEjUpr = value;
			}
		}

		event Action<int, bool> IPlayerController.ButtonStateChangedEvent
		{
			add
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
				}
				else
				{
					LKIYUuumZcUCyyQJHwJLLQpUyvJD = (Action<int, bool>)Delegate.Combine(LKIYUuumZcUCyyQJHwJLLQpUyvJD, value);
				}
			}
			remove
			{
				LKIYUuumZcUCyyQJHwJLLQpUyvJD = (Action<int, bool>)Delegate.Remove(LKIYUuumZcUCyyQJHwJLLQpUyvJD, value);
			}
		}

		event Action<int, float> IPlayerController.AxisValueChangedEvent
		{
			add
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
				}
				else
				{
					axrskPegruGfLRTTrETEdhlUcfcGb = (Action<int, float>)Delegate.Combine(axrskPegruGfLRTTrETEdhlUcfcGb, value);
				}
			}
			remove
			{
				axrskPegruGfLRTTrETEdhlUcfcGb = (Action<int, float>)Delegate.Remove(axrskPegruGfLRTTrETEdhlUcfcGb, value);
			}
		}

		event Action<bool> IPlayerController.EnabledStateChangedEvent
		{
			add
			{
				if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
				{
					ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
				}
				else
				{
					xFyyUZZIptJIYeSTJixtGCwLHvWT = (Action<bool>)Delegate.Combine(xFyyUZZIptJIYeSTJixtGCwLHvWT, value);
				}
			}
			remove
			{
				xFyyUZZIptJIYeSTJixtGCwLHvWT = (Action<bool>)Delegate.Remove(xFyyUZZIptJIYeSTJixtGCwLHvWT, value);
			}
		}

		internal PlayerController(Definition P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("definition");
			}
			if (P_0.elements == null)
			{
				throw new ArgumentNullException("definition.elements");
			}
			BactrdkHXDdWZqddywffsRoEOaKo = ReInput._id;
			YJUZOvVHMEIRrjJItipRtWYWXQEJA = P_0.playerId;
			wXmdUPKjxYymCkUzIcPwxgIaacod = P_0.enabled;
			List<Element> list = new List<Element>();
			List<Element> list2 = new List<Element>();
			List<Button> list3 = new List<Button>();
			List<Axis> list4 = new List<Axis>();
			foreach (Element.Definition element in P_0.elements)
			{
				JQSeDFFLOujvuFIXFqlNVmqVmBvSc(element.xdjxkDjtSSdBMsvOUqGtSDbsuJlH(this), list, list2, list3, list4);
			}
			list.AddRange(list2);
			bEdnyspCxFXDgXHFkFWZbcODtIuL = new AList<Element>(list);
			lOzudZCCJLsQvjBFZYglwzqlZPBC = new AList<Button>(list3);
			QhFbjUjHOKvjBSJTdpqRNrMtaALW = new AList<Axis>(list4);
			pAaNfAqsMacTFBBHIgXrupOjHiNz = new ReadOnlyCollection<Element>(bEdnyspCxFXDgXHFkFWZbcODtIuL);
			xyaEqeFYBfgtubJjKNooszCIZJLec = new ReadOnlyCollection<Button>(lOzudZCCJLsQvjBFZYglwzqlZPBC);
			PuYOfofOPVbqOfkqLVwJGLYvXEOB = new ReadOnlyCollection<Axis>(QhFbjUjHOKvjBSJTdpqRNrMtaALW);
			gfRkmhzkkfJpymYjbJuCaHraaOTl = new List<Element.UJinuItmyzahmebrnEFgySjMJMHO>();
			ReInput.UpdateEndedEvent += pueFQQcCHZrIDOdsXXIehAilPOpiA;
		}

		~PlayerController()
		{
			ReInput.UpdateEndedEvent -= pueFQQcCHZrIDOdsXXIehAilPOpiA;
		}

		public bool GetButton(int index)
		{
			if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
			{
				ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
				return false;
			}
			if ((uint)index >= (uint)lOzudZCCJLsQvjBFZYglwzqlZPBC._count)
			{
				return false;
			}
			return lOzudZCCJLsQvjBFZYglwzqlZPBC[index].value;
		}

		bool IPlayerController.GetButton(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetButton
			return this.GetButton(index);
		}

		public bool GetButtonDown(int index)
		{
			if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
			{
				ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
				return false;
			}
			if ((uint)index >= (uint)lOzudZCCJLsQvjBFZYglwzqlZPBC._count)
			{
				return false;
			}
			return lOzudZCCJLsQvjBFZYglwzqlZPBC[index].justPressed;
		}

		bool IPlayerController.GetButtonDown(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetButtonDown
			return this.GetButtonDown(index);
		}

		public bool GetButtonUp(int index)
		{
			if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
			{
				ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
				return false;
			}
			if ((uint)index >= (uint)lOzudZCCJLsQvjBFZYglwzqlZPBC._count)
			{
				return false;
			}
			return lOzudZCCJLsQvjBFZYglwzqlZPBC[index].justReleased;
		}

		bool IPlayerController.GetButtonUp(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetButtonUp
			return this.GetButtonUp(index);
		}

		public float GetAxis(int index)
		{
			if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
			{
				ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
				return 0f;
			}
			if ((uint)index >= (uint)QhFbjUjHOKvjBSJTdpqRNrMtaALW._count)
			{
				return 0f;
			}
			return QhFbjUjHOKvjBSJTdpqRNrMtaALW[index].value;
		}

		float IPlayerController.GetAxis(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetAxis
			return this.GetAxis(index);
		}

		public float GetAxisRaw(int index)
		{
			if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
			{
				ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
				return 0f;
			}
			if ((uint)index >= (uint)QhFbjUjHOKvjBSJTdpqRNrMtaALW._count)
			{
				return 0f;
			}
			return QhFbjUjHOKvjBSJTdpqRNrMtaALW[index].valueRaw;
		}

		float IPlayerController.GetAxisRaw(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetAxisRaw
			return this.GetAxisRaw(index);
		}

		public Element GetElement(int index)
		{
			if (ReInput._id != BactrdkHXDdWZqddywffsRoEOaKo)
			{
				ReInput.CheckInitialized(BactrdkHXDdWZqddywffsRoEOaKo);
				return null;
			}
			if ((uint)index >= (uint)bEdnyspCxFXDgXHFkFWZbcODtIuL._count)
			{
				return null;
			}
			return bEdnyspCxFXDgXHFkFWZbcODtIuL[index];
		}

		Element IPlayerController.GetElement(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetElement
			return this.GetElement(index);
		}

		public T GetElement<T>(int index) where T : Element
		{
			return GetElement(index) as T;
		}

		T IPlayerController.GetElement<T>(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetElement
			return this.GetElement<T>(index);
		}

		private void pueFQQcCHZrIDOdsXXIehAilPOpiA(UpdateLoopType P_0)
		{
			Update(P_0);
			UpdateFinished();
		}

		protected virtual bool Update(UpdateLoopType updateLoop)
		{
			if (!wXmdUPKjxYymCkUzIcPwxgIaacod)
			{
				return false;
			}
			bool flag = axrskPegruGfLRTTrETEdhlUcfcGb != null;
			bool flag2 = LKIYUuumZcUCyyQJHwJLLQpUyvJD != null;
			for (int i = 0; i < bEdnyspCxFXDgXHFkFWZbcODtIuL._count; i++)
			{
				float num = 0f;
				if (flag && bEdnyspCxFXDgXHFkFWZbcODtIuL[i] is Axis)
				{
					Axis axis = bEdnyspCxFXDgXHFkFWZbcODtIuL[i] as Axis;
					num = ((axis.coordinateMode != AxisCoordinateMode.Absolute) ? 0f : axis.value);
				}
				bEdnyspCxFXDgXHFkFWZbcODtIuL[i].ZzpEhhoJPpGrPVOAEfTyoEYwnsZu();
				if (flag2 && bEdnyspCxFXDgXHFkFWZbcODtIuL[i] is Button)
				{
					Button button = bEdnyspCxFXDgXHFkFWZbcODtIuL[i] as Button;
					if (button.justPressed && button.value)
					{
						gfRkmhzkkfJpymYjbJuCaHraaOTl.Add(new Element.UJinuItmyzahmebrnEFgySjMJMHO(ControllerElementType.Button, i, 1f));
					}
					else if (button.justReleased && !button.value)
					{
						gfRkmhzkkfJpymYjbJuCaHraaOTl.Add(new Element.UJinuItmyzahmebrnEFgySjMJMHO(ControllerElementType.Button, i, 0f));
					}
				}
				else if (flag && bEdnyspCxFXDgXHFkFWZbcODtIuL[i] is Axis)
				{
					gfRkmhzkkfJpymYjbJuCaHraaOTl.Add(new Element.UJinuItmyzahmebrnEFgySjMJMHO(ControllerElementType.Axis, i, (bEdnyspCxFXDgXHFkFWZbcODtIuL[i] as Axis).value - num));
				}
			}
			return true;
		}

		protected virtual void UpdateFinished()
		{
			int count = gfRkmhzkkfJpymYjbJuCaHraaOTl.Count;
			if (count <= 0)
			{
				return;
			}
			for (int i = 0; i < count; i++)
			{
				Element.UJinuItmyzahmebrnEFgySjMJMHO uJinuItmyzahmebrnEFgySjMJMHO = gfRkmhzkkfJpymYjbJuCaHraaOTl[i];
				if (uJinuItmyzahmebrnEFgySjMJMHO.MINaxwHudqzRnmKspPKysxrlJwNHA == ControllerElementType.Button)
				{
					try
					{
						LKIYUuumZcUCyyQJHwJLLQpUyvJD(uJinuItmyzahmebrnEFgySjMJMHO.zgCOpCObfTGMEGJVtKwoUeCLKRtQ, uJinuItmyzahmebrnEFgySjMJMHO.lboRhBZfNTAcCNNmmcptFhMrxTRqA > 0f);
					}
					catch (Exception ex)
					{
						Logger.LogError("An exception occurred in a listener of ButtonStateChangedEvent. This means an exception was thrown by your code.\n" + ex);
					}
				}
				else if (uJinuItmyzahmebrnEFgySjMJMHO.MINaxwHudqzRnmKspPKysxrlJwNHA == ControllerElementType.Axis)
				{
					try
					{
						axrskPegruGfLRTTrETEdhlUcfcGb(uJinuItmyzahmebrnEFgySjMJMHO.zgCOpCObfTGMEGJVtKwoUeCLKRtQ, uJinuItmyzahmebrnEFgySjMJMHO.lboRhBZfNTAcCNNmmcptFhMrxTRqA);
					}
					catch (Exception ex2)
					{
						Logger.LogError("An exception occurred in a listener of AxisValueChangedEvent. This means an exception was thrown by your code.\n" + ex2);
					}
				}
			}
			gfRkmhzkkfJpymYjbJuCaHraaOTl.Clear();
		}

		protected virtual void ClearVars()
		{
			gfRkmhzkkfJpymYjbJuCaHraaOTl.Clear();
		}

		internal void hUoiCXvSYHMKMzjAuBSHbvmFxWMz(Element P_0)
		{
			if (P_0 != null)
			{
				if (P_0 is Axis)
				{
					QhFbjUjHOKvjBSJTdpqRNrMtaALW.Add(P_0 as Axis);
				}
				else if (P_0 is Button)
				{
					lOzudZCCJLsQvjBFZYglwzqlZPBC.Add(P_0 as Button);
				}
				bEdnyspCxFXDgXHFkFWZbcODtIuL.Add(P_0);
			}
		}

		private void JQSeDFFLOujvuFIXFqlNVmqVmBvSc(Element P_0, List<Element> P_1, List<Element> P_2, List<Button> P_3, List<Axis> P_4)
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
					(P_0 as CompoundElement).GhWYunooGqCpkeZmANjUefxvYGtjA(list);
					for (int i = 0; i < list.Count; i++)
					{
						JQSeDFFLOujvuFIXFqlNVmqVmBvSc(list[i], P_1, P_2, P_3, P_4);
					}
				}
				P_2.Add(P_0);
			}
			else
			{
				Logger.LogWarning("Unknown Element type encountered: " + P_0.GetType());
			}
		}

		internal static int vtkwMwYTZycPtaVGqtFzwJswUMYr<_0001>(IList<_0001> P_0, Predicate<_0001> P_1, int P_2) where _0001 : Element
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
