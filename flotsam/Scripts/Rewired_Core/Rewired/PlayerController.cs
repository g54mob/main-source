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

				internal virtual Element nZEUPKbOUaeiBakuPdBKWQiHsFXNA(PlayerController P_0)
				{
					return new Axis(P_0, this);
				}
			}

			internal const float rKhfjXYEYtOTaueMJZnlTuUndNlJ = 1f;

			internal const AbsoluteToRelativeScalingMode cOZCKLhZeOuQtGmGndsHPiZXuAND = AbsoluteToRelativeScalingMode.None;

			[CustomObfuscation(rename = false)]
			internal const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Absolute;

			private float HntfFPdEWFzutXMkJlspBzbsvchW = 1f;

			private AxisCoordinateMode sxTaXsHFjPBnRqvdjlatAqYoAfdib;

			private AbsoluteToRelativeScalingMode ZIQCEUoCQqorxNQEepOehpXYGSOp;

			public float absoluteToRelativeSensitivity
			{
				get
				{
					return HntfFPdEWFzutXMkJlspBzbsvchW;
				}
				set
				{
					if (value < 0f)
					{
						value = 0f;
					}
					HntfFPdEWFzutXMkJlspBzbsvchW = value;
				}
			}

			public AbsoluteToRelativeScalingMode absoluteToRelativeScalingMode
			{
				get
				{
					return ZIQCEUoCQqorxNQEepOehpXYGSOp;
				}
				set
				{
					ZIQCEUoCQqorxNQEepOehpXYGSOp = value;
				}
			}

			public AxisCoordinateMode coordinateMode => sxTaXsHFjPBnRqvdjlatAqYoAfdib;

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
						if (sxTaXsHFjPBnRqvdjlatAqYoAfdib == AxisCoordinateMode.Absolute)
						{
							return 0f;
						}
						break;
					case AxisCoordinateMode.Absolute:
						if (sxTaXsHFjPBnRqvdjlatAqYoAfdib == AxisCoordinateMode.Relative)
						{
							switch (ZIQCEUoCQqorxNQEepOehpXYGSOp)
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
							num *= (float)ReInput.unscaledDeltaTime * HntfFPdEWFzutXMkJlspBzbsvchW;
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
				HntfFPdEWFzutXMkJlspBzbsvchW = P_1.absoluteToRelativeSensitivity;
				sxTaXsHFjPBnRqvdjlatAqYoAfdib = P_1.coordinateMode;
				ZIQCEUoCQqorxNQEepOehpXYGSOp = P_1.absoluteToRelativeScalingMode;
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

				internal virtual Element pnjXuSdbGckoTSAePTcqJHdOQuwy(PlayerController P_0)
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
				private Axis.Definition FyZVMOSvYceLKqVjfGikzBYupHPC;

				private Axis.Definition yUYFJuajmZGPThEIunIVKzHwzfkvA;

				public Axis.Definition xAxis
				{
					get
					{
						return FyZVMOSvYceLKqVjfGikzBYupHPC;
					}
					set
					{
						FyZVMOSvYceLKqVjfGikzBYupHPC = value;
					}
				}

				public Axis.Definition yAxis
				{
					get
					{
						return yUYFJuajmZGPThEIunIVKzHwzfkvA;
					}
					set
					{
						yUYFJuajmZGPThEIunIVKzHwzfkvA = value;
					}
				}

				internal virtual Element ppVVIwcLOvYjcJZTuHsimHbYuTlS(PlayerController P_0)
				{
					return new Axis2D(P_0, this);
				}
			}

			internal const int ubstMwPaEbEbPKmgYghPRKZicZnh = 0;

			internal const int dtusPTWiSDkMzyNxlvsAicDKiQhkA = 1;

			internal const int spNSSPHsMfuFBMmItArBsvbAJaKkA = 2;

			public Axis xAxis => HNDXtOBJXYYeeAcCnfhrqNzGACVcA<Axis>(0);

			public Axis yAxis => HNDXtOBJXYYeeAcCnfhrqNzGACVcA<Axis>(1);

			public virtual Vector2 value => new Vector2(HNDXtOBJXYYeeAcCnfhrqNzGACVcA<Axis>(0).value, HNDXtOBJXYYeeAcCnfhrqNzGACVcA<Axis>(1).value);

			public virtual Vector2 valueRaw => new Vector2(HNDXtOBJXYYeeAcCnfhrqNzGACVcA<Axis>(0).valueRaw, HNDXtOBJXYYeeAcCnfhrqNzGACVcA<Axis>(1).valueRaw);

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

				internal virtual Element zmHStCDSrbzwUabjGJJOuuPsAeEb(PlayerController P_0)
				{
					return new MouseAxis2D(P_0, this);
				}
			}

			public new MouseAxis xAxis => HNDXtOBJXYYeeAcCnfhrqNzGACVcA<MouseAxis>(0);

			public new MouseAxis yAxis => HNDXtOBJXYYeeAcCnfhrqNzGACVcA<MouseAxis>(1);

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
				internal virtual Element EgMDtwcLWnrMETgLDoMaFdsftYNWb(PlayerController P_0)
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

			private readonly List<Element> XTZgJlITBmwfxkLXrKAcyjTgMwdqA;

			internal int ROmQuhWHKpakttrOGwdvUzkjrmMC => XTZgJlITBmwfxkLXrKAcyjTgMwdqA.Count;

			internal CompoundElement(PlayerController P_0, Definition P_1, Element.Definition[] P_2)
				: base(P_0, P_1)
			{
				XTZgJlITBmwfxkLXrKAcyjTgMwdqA = new List<Element>();
				if (P_2 == null)
				{
					return;
				}
				for (int i = 0; i < P_2.Length; i++)
				{
					if (P_2[i] != null)
					{
						nwkfnNvjXsifsZlPSQGMWDohfeJv(P_2[i].njnzKSVWTUbHsRVJVdCCDOrLbajI(P_0));
					}
				}
			}

			internal _0001 HNDXtOBJXYYeeAcCnfhrqNzGACVcA<_0001>(int P_0) where _0001 : Element
			{
				if ((uint)P_0 >= (uint)XTZgJlITBmwfxkLXrKAcyjTgMwdqA.Count)
				{
					return null;
				}
				return XTZgJlITBmwfxkLXrKAcyjTgMwdqA[P_0] as _0001;
			}

			internal void SJQlmmKPgqtpOaNQTBcpJkdOmFtKA(List<Element> P_0)
			{
				for (int i = 0; i < XTZgJlITBmwfxkLXrKAcyjTgMwdqA.Count; i++)
				{
					if (XTZgJlITBmwfxkLXrKAcyjTgMwdqA[i] is CompoundElement)
					{
						(XTZgJlITBmwfxkLXrKAcyjTgMwdqA[i] as CompoundElement).SJQlmmKPgqtpOaNQTBcpJkdOmFtKA(P_0);
					}
					else
					{
						P_0.Add(XTZgJlITBmwfxkLXrKAcyjTgMwdqA[i]);
					}
				}
			}

			internal void nwkfnNvjXsifsZlPSQGMWDohfeJv(Element P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("element");
				}
				XTZgJlITBmwfxkLXrKAcyjTgMwdqA.Add(P_0);
				P_0.VTRSEbLgtjyuMkiCeZgfMOIDdhLK = true;
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

				internal abstract Element njnzKSVWTUbHsRVJVdCCDOrLbajI(PlayerController P_0);
			}

			internal struct EhqyoDTYWpaWCTETcDMRjZddkLHn
			{
				public ControllerElementType SCBkfdUDTmBLDcdUuRFRkypSTzJgA;

				public int vBQKbFcNEBOQovnJoRhFPCKeCpdl;

				public float xDwNfAjGhLaSgweUtgMKonQSUUTg;

				public EhqyoDTYWpaWCTETcDMRjZddkLHn(ControllerElementType P_0, int P_1, float P_2)
				{
					SCBkfdUDTmBLDcdUuRFRkypSTzJgA = P_0;
					vBQKbFcNEBOQovnJoRhFPCKeCpdl = P_1;
					xDwNfAjGhLaSgweUtgMKonQSUUTg = P_2;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const bool defaultEnabled = true;

			private readonly PlayerController hYbPSbJysWiNmwnenoVEvZJtuqJH;

			private bool WjJebtDZsBVgMLgMhuahLfdOMCgBb;

			private bool XprrIFscHDgjCzIBrlIDQBrrFomeA = true;

			private string KuatKYoBdeFKiLXmyOKWotFtfLBk;

			private static int[] NajYpaKwjWcvJjDauTmLhBninjem;

			private static int[] FamiCjzNSroeSMHgxmBmGtdCkqUc;

			protected Player player
			{
				get
				{
					if (!ReInput.isReady)
					{
						return null;
					}
					return ReInput.players.GetPlayer(hYbPSbJysWiNmwnenoVEvZJtuqJH.EeQJOujjqAuNZwpowLwaHqEnsVIy);
				}
			}

			protected bool selfAndParentEnabled
			{
				get
				{
					if (XprrIFscHDgjCzIBrlIDQBrrFomeA)
					{
						return hYbPSbJysWiNmwnenoVEvZJtuqJH.aVcryGwtTYkjgPbaNtlFojuBhjkJ;
					}
					return false;
				}
			}

			internal bool VTRSEbLgtjyuMkiCeZgfMOIDdhLK
			{
				get
				{
					return WjJebtDZsBVgMLgMhuahLfdOMCgBb;
				}
				set
				{
					WjJebtDZsBVgMLgMhuahLfdOMCgBb = true;
				}
			}

			public bool enabled
			{
				get
				{
					return XprrIFscHDgjCzIBrlIDQBrrFomeA;
				}
				set
				{
					if (XprrIFscHDgjCzIBrlIDQBrrFomeA != value)
					{
						XprrIFscHDgjCzIBrlIDQBrrFomeA = value;
						EnabledStateChanged(value);
					}
				}
			}

			public string name
			{
				get
				{
					return KuatKYoBdeFKiLXmyOKWotFtfLBk;
				}
				set
				{
					KuatKYoBdeFKiLXmyOKWotFtfLBk = value;
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
				hYbPSbJysWiNmwnenoVEvZJtuqJH = P_0;
				XprrIFscHDgjCzIBrlIDQBrrFomeA = P_1.enabled;
				KuatKYoBdeFKiLXmyOKWotFtfLBk = P_1.name;
			}

			internal virtual void BZtExybAhfUplccqDzUZItQHhlZGb()
			{
			}

			protected virtual void EnabledStateChanged(bool state)
			{
			}

			[CustomObfuscation(rename = false)]
			internal static bool IsTypeWithSource(Type type)
			{
				if (NajYpaKwjWcvJjDauTmLhBninjem == null)
				{
					NajYpaKwjWcvJjDauTmLhBninjem = (int[])Enum.GetValues(typeof(TypeWithSource));
				}
				return ArrayTools.Contains(NajYpaKwjWcvJjDauTmLhBninjem, (int)type);
			}

			[CustomObfuscation(rename = false)]
			internal static bool IsCompoundType(Type type)
			{
				if (FamiCjzNSroeSMHgxmBmGtdCkqUc == null)
				{
					FamiCjzNSroeSMHgxmBmGtdCkqUc = (int[])Enum.GetValues(typeof(CompoundTypes));
				}
				return ArrayTools.Contains(FamiCjzNSroeSMHgxmBmGtdCkqUc, (int)type);
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
				private int uXbOgAtbZaueGndSEaSmBTHyzjGOA;

				public int actionId
				{
					get
					{
						return uXbOgAtbZaueGndSEaSmBTHyzjGOA;
					}
					set
					{
						uXbOgAtbZaueGndSEaSmBTHyzjGOA = value;
					}
				}

				public string actionName
				{
					get
					{
						if (!ReInput.isReady || uXbOgAtbZaueGndSEaSmBTHyzjGOA < 0)
						{
							return null;
						}
						return ReInput.mapping.GetAction(uXbOgAtbZaueGndSEaSmBTHyzjGOA)?.name;
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
							uXbOgAtbZaueGndSEaSmBTHyzjGOA = -1;
						}
						else
						{
							uXbOgAtbZaueGndSEaSmBTHyzjGOA = action.id;
						}
					}
				}

				public Definition()
				{
					uXbOgAtbZaueGndSEaSmBTHyzjGOA = -1;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const int defaultActionId = -1;

			private int ZCwXvbkYxstshRhVjONTuUznJuig = -1;

			public int actionId
			{
				get
				{
					return ZCwXvbkYxstshRhVjONTuUznJuig;
				}
				set
				{
					ZCwXvbkYxstshRhVjONTuUznJuig = value;
				}
			}

			public string actionName
			{
				get
				{
					if (!ReInput.isReady || ZCwXvbkYxstshRhVjONTuUznJuig < 0)
					{
						return null;
					}
					return ReInput.mapping.GetAction(ZCwXvbkYxstshRhVjONTuUznJuig)?.name;
				}
				set
				{
					if (ReInput.isReady)
					{
						InputAction action = ReInput.mapping.GetAction(value);
						if (action == null)
						{
							ZCwXvbkYxstshRhVjONTuUznJuig = -1;
						}
						else
						{
							ZCwXvbkYxstshRhVjONTuUznJuig = action.id;
						}
					}
				}
			}

			internal ElementWithSource(PlayerController P_0, Definition P_1)
				: base(P_0, P_1)
			{
				ZCwXvbkYxstshRhVjONTuUznJuig = P_1.actionId;
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

				internal virtual Element lNVoNvmJDwhfhMfmzajJLZpLwdAC(PlayerController P_0)
				{
					return new MouseWheel(P_0, this);
				}
			}

			public new MouseWheelAxis xAxis => HNDXtOBJXYYeeAcCnfhrqNzGACVcA<MouseWheelAxis>(0);

			public new MouseWheelAxis yAxis => HNDXtOBJXYYeeAcCnfhrqNzGACVcA<MouseWheelAxis>(1);

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

				internal virtual Element NETCqbMJzsspTTZnUKbLwODITuZe(PlayerController P_0)
				{
					return new MouseWheelAxis(P_0, this);
				}
			}

			[CustomObfuscation(rename = false)]
			internal const float defaultRepeatRate = 4f;

			[CustomObfuscation(rename = false)]
			internal new const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Relative;

			private const float gpgosktAFqcVwwLWPwKWWkwsFCim = 0.01f;

			private float fjRODOwvVqZHSecvXZeMpaaxcLSE = 0.25f;

			private double AVJowIniPrrBBiayGLozQAZhcOqF;

			private float JarBWOiLLofWpVmIOtGiIKgUKEvtA;

			public float repeatRate
			{
				get
				{
					if (fjRODOwvVqZHSecvXZeMpaaxcLSE == 0f)
					{
						return 0f;
					}
					return 1f / fjRODOwvVqZHSecvXZeMpaaxcLSE;
				}
				set
				{
					if (value < 0f)
					{
						value = 0f;
					}
					if (value == 0f)
					{
						fjRODOwvVqZHSecvXZeMpaaxcLSE = 0f;
					}
					else
					{
						fjRODOwvVqZHSecvXZeMpaaxcLSE = 1f / value;
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
					return JarBWOiLLofWpVmIOtGiIKgUKEvtA;
				}
			}

			internal MouseWheelAxis(PlayerController P_0, Definition P_1)
				: base(P_0, P_1)
			{
				repeatRate = P_1.repeatRate;
			}

			internal void ZTNkpCcDpOsFiGPATytiieLgnRcs()
			{
				base.BZtExybAhfUplccqDzUZItQHhlZGb();
				if (base.selfAndParentEnabled)
				{
					JarBWOiLLofWpVmIOtGiIKgUKEvtA = NrCTOIesPxnCZiGMnAETwKHMpfzx();
				}
			}

			protected override void EnabledStateChanged(bool state)
			{
				base.EnabledStateChanged(state);
				if (!state)
				{
					izadBZEnPbPCbrkWcdraIarGjLTIA();
				}
			}

			private float NrCTOIesPxnCZiGMnAETwKHMpfzx()
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
					if (!flag && ReInput.unscaledTime < AVJowIniPrrBBiayGLozQAZhcOqF + (double)fjRODOwvVqZHSecvXZeMpaaxcLSE)
					{
						return 0f;
					}
					if (Mathf.Abs(num) <= 0.01f)
					{
						return 0f;
					}
					num = Mathf.Sign(num);
					num *= base.absoluteToRelativeSensitivity;
					AVJowIniPrrBBiayGLozQAZhcOqF = ReInput.unscaledTime;
					break;
				}
				}
				return num;
			}

			private void izadBZEnPbPCbrkWcdraIarGjLTIA()
			{
				JarBWOiLLofWpVmIOtGiIKgUKEvtA = 0f;
				AVJowIniPrrBBiayGLozQAZhcOqF = 0.0;
			}
		}

		internal readonly int BColakSjrXYdzLJJhcOAtYyjrySF;

		private bool aVcryGwtTYkjgPbaNtlFojuBhjkJ;

		private int EeQJOujjqAuNZwpowLwaHqEnsVIy;

		private readonly AList<Element> vbflPpFkxBBGQkBhdYymcGSoguyi;

		private readonly AList<Button> zNzAoQkisVlwsEHpKCBAxmlApCTN;

		private readonly AList<Axis> ERrbDDLsAgzjhHtedhmSGESmZLv;

		private readonly ReadOnlyCollection<Element> dyiYfBUQsgoNvmXlXuSMxXSOgnBO;

		private readonly ReadOnlyCollection<Button> fseEkpgqldghAywBYInDdmSiySPGA;

		private readonly ReadOnlyCollection<Axis> DSKUgoBAsPHtAELIIYEHTmBSgICGA;

		private readonly List<Element.EhqyoDTYWpaWCTETcDMRjZddkLHn> iiFmGiNWCtToAREFeaEzvNpJipTM;

		private Action<int, bool> RPSILvUoCmOYYPukOtqyYOwlzXDE;

		private Action<int, float> cztOsOOhRgWbnwrxqtCpmVhlIimU;

		private Action<bool> nIilOAxXRrHYuNTrOzSELAgsJwAV;

		private static Vector2 jpTRRjzqQygIrjKfnnDttkLvjTpS = new Vector2(1920f, 1080f);

		bool IPlayerController.enabled
		{
			get
			{
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
					return false;
				}
				return aVcryGwtTYkjgPbaNtlFojuBhjkJ;
			}
			set
			{
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
				}
				else
				{
					if (aVcryGwtTYkjgPbaNtlFojuBhjkJ == value)
					{
						return;
					}
					if (!value)
					{
						ClearVars();
					}
					aVcryGwtTYkjgPbaNtlFojuBhjkJ = value;
					for (int i = 0; i < vbflPpFkxBBGQkBhdYymcGSoguyi._count; i++)
					{
						vbflPpFkxBBGQkBhdYymcGSoguyi[i].enabled = value;
					}
					if (nIilOAxXRrHYuNTrOzSELAgsJwAV != null)
					{
						try
						{
							nIilOAxXRrHYuNTrOzSELAgsJwAV(value);
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
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
					return -1;
				}
				return EeQJOujjqAuNZwpowLwaHqEnsVIy;
			}
			set
			{
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
				}
				else if (EeQJOujjqAuNZwpowLwaHqEnsVIy != value)
				{
					EeQJOujjqAuNZwpowLwaHqEnsVIy = value;
					ClearVars();
				}
			}
		}

		IList<Button> IPlayerController.buttons
		{
			get
			{
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
					return null;
				}
				return fseEkpgqldghAywBYInDdmSiySPGA;
			}
		}

		IList<Axis> IPlayerController.axes
		{
			get
			{
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
					return null;
				}
				return DSKUgoBAsPHtAELIIYEHTmBSgICGA;
			}
		}

		IList<Element> IPlayerController.elements
		{
			get
			{
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
					return null;
				}
				return dyiYfBUQsgoNvmXlXuSMxXSOgnBO;
			}
		}

		int IPlayerController.buttonCount
		{
			get
			{
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
					return 0;
				}
				if (zNzAoQkisVlwsEHpKCBAxmlApCTN == null)
				{
					return 0;
				}
				return zNzAoQkisVlwsEHpKCBAxmlApCTN._count;
			}
		}

		int IPlayerController.axisCount
		{
			get
			{
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
					return 0;
				}
				if (ERrbDDLsAgzjhHtedhmSGESmZLv == null)
				{
					return 0;
				}
				return ERrbDDLsAgzjhHtedhmSGESmZLv._count;
			}
		}

		int IPlayerController.elementCount
		{
			get
			{
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
					return 0;
				}
				if (vbflPpFkxBBGQkBhdYymcGSoguyi == null)
				{
					return 0;
				}
				return vbflPpFkxBBGQkBhdYymcGSoguyi._count;
			}
		}

		internal Player XEmKonepnKndlQCaJOTwvtZQhtxV
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
				return jpTRRjzqQygIrjKfnnDttkLvjTpS;
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
				jpTRRjzqQygIrjKfnnDttkLvjTpS = value;
			}
		}

		event Action<int, bool> IPlayerController.ButtonStateChangedEvent
		{
			add
			{
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
				}
				else
				{
					RPSILvUoCmOYYPukOtqyYOwlzXDE = (Action<int, bool>)Delegate.Combine(RPSILvUoCmOYYPukOtqyYOwlzXDE, value);
				}
			}
			remove
			{
				RPSILvUoCmOYYPukOtqyYOwlzXDE = (Action<int, bool>)Delegate.Remove(RPSILvUoCmOYYPukOtqyYOwlzXDE, value);
			}
		}

		event Action<int, float> IPlayerController.AxisValueChangedEvent
		{
			add
			{
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
				}
				else
				{
					cztOsOOhRgWbnwrxqtCpmVhlIimU = (Action<int, float>)Delegate.Combine(cztOsOOhRgWbnwrxqtCpmVhlIimU, value);
				}
			}
			remove
			{
				cztOsOOhRgWbnwrxqtCpmVhlIimU = (Action<int, float>)Delegate.Remove(cztOsOOhRgWbnwrxqtCpmVhlIimU, value);
			}
		}

		event Action<bool> IPlayerController.EnabledStateChangedEvent
		{
			add
			{
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
				}
				else
				{
					nIilOAxXRrHYuNTrOzSELAgsJwAV = (Action<bool>)Delegate.Combine(nIilOAxXRrHYuNTrOzSELAgsJwAV, value);
				}
			}
			remove
			{
				nIilOAxXRrHYuNTrOzSELAgsJwAV = (Action<bool>)Delegate.Remove(nIilOAxXRrHYuNTrOzSELAgsJwAV, value);
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
			BColakSjrXYdzLJJhcOAtYyjrySF = ReInput._id;
			EeQJOujjqAuNZwpowLwaHqEnsVIy = P_0.playerId;
			aVcryGwtTYkjgPbaNtlFojuBhjkJ = P_0.enabled;
			List<Element> list = new List<Element>();
			List<Element> list2 = new List<Element>();
			List<Button> list3 = new List<Button>();
			List<Axis> list4 = new List<Axis>();
			foreach (Element.Definition element in P_0.elements)
			{
				HSIJFWpteiBfKbxrfWyezZoDdOtW(element.njnzKSVWTUbHsRVJVdCCDOrLbajI(this), list, list2, list3, list4);
			}
			list.AddRange(list2);
			vbflPpFkxBBGQkBhdYymcGSoguyi = new AList<Element>(list);
			zNzAoQkisVlwsEHpKCBAxmlApCTN = new AList<Button>(list3);
			ERrbDDLsAgzjhHtedhmSGESmZLv = new AList<Axis>(list4);
			dyiYfBUQsgoNvmXlXuSMxXSOgnBO = new ReadOnlyCollection<Element>(vbflPpFkxBBGQkBhdYymcGSoguyi);
			fseEkpgqldghAywBYInDdmSiySPGA = new ReadOnlyCollection<Button>(zNzAoQkisVlwsEHpKCBAxmlApCTN);
			DSKUgoBAsPHtAELIIYEHTmBSgICGA = new ReadOnlyCollection<Axis>(ERrbDDLsAgzjhHtedhmSGESmZLv);
			iiFmGiNWCtToAREFeaEzvNpJipTM = new List<Element.EhqyoDTYWpaWCTETcDMRjZddkLHn>();
			ReInput.UpdateEndedEvent += jpwiQHaPpJKUnKqYKaLLFMgIgRlGA;
		}

		~PlayerController()
		{
			ReInput.UpdateEndedEvent -= jpwiQHaPpJKUnKqYKaLLFMgIgRlGA;
		}

		public bool GetButton(int index)
		{
			if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
			{
				ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
				return false;
			}
			if ((uint)index >= (uint)zNzAoQkisVlwsEHpKCBAxmlApCTN._count)
			{
				return false;
			}
			return zNzAoQkisVlwsEHpKCBAxmlApCTN[index].value;
		}

		bool IPlayerController.GetButton(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetButton
			return this.GetButton(index);
		}

		public bool GetButtonDown(int index)
		{
			if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
			{
				ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
				return false;
			}
			if ((uint)index >= (uint)zNzAoQkisVlwsEHpKCBAxmlApCTN._count)
			{
				return false;
			}
			return zNzAoQkisVlwsEHpKCBAxmlApCTN[index].justPressed;
		}

		bool IPlayerController.GetButtonDown(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetButtonDown
			return this.GetButtonDown(index);
		}

		public bool GetButtonUp(int index)
		{
			if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
			{
				ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
				return false;
			}
			if ((uint)index >= (uint)zNzAoQkisVlwsEHpKCBAxmlApCTN._count)
			{
				return false;
			}
			return zNzAoQkisVlwsEHpKCBAxmlApCTN[index].justReleased;
		}

		bool IPlayerController.GetButtonUp(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetButtonUp
			return this.GetButtonUp(index);
		}

		public float GetAxis(int index)
		{
			if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
			{
				ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
				return 0f;
			}
			if ((uint)index >= (uint)ERrbDDLsAgzjhHtedhmSGESmZLv._count)
			{
				return 0f;
			}
			return ERrbDDLsAgzjhHtedhmSGESmZLv[index].value;
		}

		float IPlayerController.GetAxis(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetAxis
			return this.GetAxis(index);
		}

		public float GetAxisRaw(int index)
		{
			if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
			{
				ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
				return 0f;
			}
			if ((uint)index >= (uint)ERrbDDLsAgzjhHtedhmSGESmZLv._count)
			{
				return 0f;
			}
			return ERrbDDLsAgzjhHtedhmSGESmZLv[index].valueRaw;
		}

		float IPlayerController.GetAxisRaw(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetAxisRaw
			return this.GetAxisRaw(index);
		}

		public Element GetElement(int index)
		{
			if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
			{
				ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
				return null;
			}
			if ((uint)index >= (uint)vbflPpFkxBBGQkBhdYymcGSoguyi._count)
			{
				return null;
			}
			return vbflPpFkxBBGQkBhdYymcGSoguyi[index];
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

		private void jpwiQHaPpJKUnKqYKaLLFMgIgRlGA(UpdateLoopType P_0)
		{
			Update(P_0);
			UpdateFinished();
		}

		protected virtual bool Update(UpdateLoopType updateLoop)
		{
			if (!aVcryGwtTYkjgPbaNtlFojuBhjkJ)
			{
				return false;
			}
			bool flag = cztOsOOhRgWbnwrxqtCpmVhlIimU != null;
			bool flag2 = RPSILvUoCmOYYPukOtqyYOwlzXDE != null;
			for (int i = 0; i < vbflPpFkxBBGQkBhdYymcGSoguyi._count; i++)
			{
				float num = 0f;
				if (flag && vbflPpFkxBBGQkBhdYymcGSoguyi[i] is Axis)
				{
					Axis axis = vbflPpFkxBBGQkBhdYymcGSoguyi[i] as Axis;
					num = ((axis.coordinateMode != AxisCoordinateMode.Absolute) ? 0f : axis.value);
				}
				vbflPpFkxBBGQkBhdYymcGSoguyi[i].BZtExybAhfUplccqDzUZItQHhlZGb();
				if (flag2 && vbflPpFkxBBGQkBhdYymcGSoguyi[i] is Button)
				{
					Button button = vbflPpFkxBBGQkBhdYymcGSoguyi[i] as Button;
					if (button.justPressed && button.value)
					{
						iiFmGiNWCtToAREFeaEzvNpJipTM.Add(new Element.EhqyoDTYWpaWCTETcDMRjZddkLHn(ControllerElementType.Button, i, 1f));
					}
					else if (button.justReleased && !button.value)
					{
						iiFmGiNWCtToAREFeaEzvNpJipTM.Add(new Element.EhqyoDTYWpaWCTETcDMRjZddkLHn(ControllerElementType.Button, i, 0f));
					}
				}
				else if (flag && vbflPpFkxBBGQkBhdYymcGSoguyi[i] is Axis)
				{
					iiFmGiNWCtToAREFeaEzvNpJipTM.Add(new Element.EhqyoDTYWpaWCTETcDMRjZddkLHn(ControllerElementType.Axis, i, (vbflPpFkxBBGQkBhdYymcGSoguyi[i] as Axis).value - num));
				}
			}
			return true;
		}

		protected virtual void UpdateFinished()
		{
			int count = iiFmGiNWCtToAREFeaEzvNpJipTM.Count;
			if (count <= 0)
			{
				return;
			}
			for (int i = 0; i < count; i++)
			{
				Element.EhqyoDTYWpaWCTETcDMRjZddkLHn ehqyoDTYWpaWCTETcDMRjZddkLHn = iiFmGiNWCtToAREFeaEzvNpJipTM[i];
				if (ehqyoDTYWpaWCTETcDMRjZddkLHn.SCBkfdUDTmBLDcdUuRFRkypSTzJgA == ControllerElementType.Button)
				{
					try
					{
						RPSILvUoCmOYYPukOtqyYOwlzXDE(ehqyoDTYWpaWCTETcDMRjZddkLHn.vBQKbFcNEBOQovnJoRhFPCKeCpdl, ehqyoDTYWpaWCTETcDMRjZddkLHn.xDwNfAjGhLaSgweUtgMKonQSUUTg > 0f);
					}
					catch (Exception ex)
					{
						Logger.LogError("An exception occurred in a listener of ButtonStateChangedEvent. This means an exception was thrown by your code.\n" + ex);
					}
				}
				else if (ehqyoDTYWpaWCTETcDMRjZddkLHn.SCBkfdUDTmBLDcdUuRFRkypSTzJgA == ControllerElementType.Axis)
				{
					try
					{
						cztOsOOhRgWbnwrxqtCpmVhlIimU(ehqyoDTYWpaWCTETcDMRjZddkLHn.vBQKbFcNEBOQovnJoRhFPCKeCpdl, ehqyoDTYWpaWCTETcDMRjZddkLHn.xDwNfAjGhLaSgweUtgMKonQSUUTg);
					}
					catch (Exception ex2)
					{
						Logger.LogError("An exception occurred in a listener of AxisValueChangedEvent. This means an exception was thrown by your code.\n" + ex2);
					}
				}
			}
			iiFmGiNWCtToAREFeaEzvNpJipTM.Clear();
		}

		protected virtual void ClearVars()
		{
			iiFmGiNWCtToAREFeaEzvNpJipTM.Clear();
		}

		internal void vTqACGIFuVUScfSshJZyMaqwUVQAA(Element P_0)
		{
			if (P_0 != null)
			{
				if (P_0 is Axis)
				{
					ERrbDDLsAgzjhHtedhmSGESmZLv.Add(P_0 as Axis);
				}
				else if (P_0 is Button)
				{
					zNzAoQkisVlwsEHpKCBAxmlApCTN.Add(P_0 as Button);
				}
				vbflPpFkxBBGQkBhdYymcGSoguyi.Add(P_0);
			}
		}

		private void HSIJFWpteiBfKbxrfWyezZoDdOtW(Element P_0, List<Element> P_1, List<Element> P_2, List<Button> P_3, List<Axis> P_4)
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
					(P_0 as CompoundElement).SJQlmmKPgqtpOaNQTBcpJkdOmFtKA(list);
					for (int i = 0; i < list.Count; i++)
					{
						HSIJFWpteiBfKbxrfWyezZoDdOtW(list[i], P_1, P_2, P_3, P_4);
					}
				}
				P_2.Add(P_0);
			}
			else
			{
				Logger.LogWarning("Unknown Element type encountered: " + P_0.GetType());
			}
		}

		internal static int fPclSdsJruCRRFBcrEIUehqBkJSfA<_0001>(IList<_0001> P_0, Predicate<_0001> P_1, int P_2) where _0001 : Element
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
