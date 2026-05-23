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

				internal abstract Element CreateElement(PlayerController P_0);
			}

			internal struct UvPQNSiehACJrvBONJBxEuFvEvZ
			{
				public ControllerElementType jtJqVgInZRaLUQAkQAhzWYXSDiZ;

				public int mFfLSVvRgZulYzYIyEkqCMoEiNXj;

				public float JHgsNLxiAQVnmyfVeWejfTJocIu;

				public UvPQNSiehACJrvBONJBxEuFvEvZ(ControllerElementType elementType, int index, float value)
				{
					jtJqVgInZRaLUQAkQAhzWYXSDiZ = elementType;
					mFfLSVvRgZulYzYIyEkqCMoEiNXj = index;
					JHgsNLxiAQVnmyfVeWejfTJocIu = value;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const bool defaultEnabled = true;

			private readonly PlayerController HQqdfhbximGRqAmWjsGgpbsZYxai;

			private bool mgpGqOOfdWNViVdjBhZjlhAyKrC;

			private bool PAfqntGWZaNgzmZFIOyQPuJGOCq = true;

			private string EqppaAHmTQvmVSSZadzlNpPBbHM;

			private static int[] ZVpHpEaNiQjrBbHkRqjGHXGwnKn;

			private static int[] ZBqUxNpvfWYKbBJXwtazAZemjL;

			protected Player player
			{
				get
				{
					if (!ReInput.isReady)
					{
						return null;
					}
					return ReInput.players.GetPlayer(HQqdfhbximGRqAmWjsGgpbsZYxai.iueDnAHVXVmEMnNCzSowjkddzOFv);
				}
			}

			protected bool selfAndParentEnabled
			{
				get
				{
					if (PAfqntGWZaNgzmZFIOyQPuJGOCq)
					{
						return HQqdfhbximGRqAmWjsGgpbsZYxai.PAfqntGWZaNgzmZFIOyQPuJGOCq;
					}
					return false;
				}
			}

			internal bool isMemberElement
			{
				get
				{
					return mgpGqOOfdWNViVdjBhZjlhAyKrC;
				}
				set
				{
					mgpGqOOfdWNViVdjBhZjlhAyKrC = true;
				}
			}

			public bool enabled
			{
				get
				{
					return PAfqntGWZaNgzmZFIOyQPuJGOCq;
				}
				set
				{
					if (PAfqntGWZaNgzmZFIOyQPuJGOCq == value)
					{
						return;
					}
					while (true)
					{
						PAfqntGWZaNgzmZFIOyQPuJGOCq = value;
						int num = -1121774739;
						while (true)
						{
							switch (num ^ -1121774739)
							{
							case 2:
								goto IL_000a;
							case 1:
								break;
							default:
								EnabledStateChanged(value);
								return;
							}
							break;
							IL_000a:
							num = -1121774740;
						}
					}
				}
			}

			public string name
			{
				get
				{
					return EqppaAHmTQvmVSSZadzlNpPBbHM;
				}
				set
				{
					EqppaAHmTQvmVSSZadzlNpPBbHM = value;
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
				HQqdfhbximGRqAmWjsGgpbsZYxai = parent;
				PAfqntGWZaNgzmZFIOyQPuJGOCq = definition.enabled;
			}

			internal virtual void Update()
			{
			}

			protected virtual void EnabledStateChanged(bool state)
			{
			}

			[CustomObfuscation(rename = false)]
			internal static bool IsTypeWithSource(Type type)
			{
				if (ZVpHpEaNiQjrBbHkRqjGHXGwnKn == null)
				{
					while (true)
					{
						int num = 198445620;
						while (true)
						{
							switch (num ^ 0xBD40A35)
							{
							case 0:
								break;
							case 1:
								ZVpHpEaNiQjrBbHkRqjGHXGwnKn = (int[])Enum.GetValues(typeof(TypeWithSource));
								num = 198445623;
								continue;
							default:
								goto end_IL_0007;
							}
							break;
						}
						continue;
						end_IL_0007:
						break;
					}
				}
				return ArrayTools.Contains(ZVpHpEaNiQjrBbHkRqjGHXGwnKn, (int)type);
			}

			[CustomObfuscation(rename = false)]
			internal static bool IsCompoundType(Type type)
			{
				if (ZBqUxNpvfWYKbBJXwtazAZemjL == null)
				{
					while (true)
					{
						int num = 2052548518;
						while (true)
						{
							switch (num ^ 0x7A5767A4)
							{
							case 0:
								break;
							case 2:
								ZBqUxNpvfWYKbBJXwtazAZemjL = (int[])Enum.GetValues(typeof(CompoundTypes));
								num = 2052548517;
								continue;
							default:
								goto end_IL_0007;
							}
							break;
						}
						continue;
						end_IL_0007:
						break;
					}
				}
				return ArrayTools.Contains(ZBqUxNpvfWYKbBJXwtazAZemjL, (int)type);
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
					while (true)
					{
						switch (-1170966228 ^ -1170966226)
						{
						case 0:
							continue;
						case 2:
							switch (type)
							{
							case Type.Axis2D:
								break;
							case Type.MouseAxis2D:
								return 2;
							case Type.MouseWheel:
								return 2;
							default:
								throw new NotImplementedException();
							}
							goto case 1;
						case 1:
							return 2;
						}
						break;
					}
				}
				throw new NotImplementedException();
			}

			[CustomObfuscation(rename = false)]
			internal static string GetElementTitle(Type type, int index)
			{
				if (index < 0)
				{
					goto IL_0079;
				}
				if (index > GetMaxElementCount(type))
				{
					goto IL_000d;
				}
				if (IsTypeWithSource(type))
				{
					return null;
				}
				Type type2 = default(Type);
				int num;
				if (IsCompoundType(type))
				{
					type2 = type;
					num = -89607673;
					goto IL_0012;
				}
				goto IL_00a6;
				IL_0012:
				while (true)
				{
					switch (num ^ -89607673)
					{
					case 2:
						break;
					case 0:
						switch (type2)
						{
						default:
							num = -89607676;
							continue;
						case Type.Axis2D:
						case Type.MouseAxis2D:
						case Type.MouseWheel:
							break;
						}
						goto IL_0099;
					case 5:
						return "Y Axis";
					case 3:
						throw new NotImplementedException();
					case 6:
						goto IL_0079;
					case 1:
						goto IL_0099;
					default:
						goto IL_00a6;
					}
					break;
					IL_0099:
					if (index == 0)
					{
						return "X Axis";
					}
					num = -89607678;
				}
				goto IL_000d;
				IL_000d:
				num = -89607679;
				goto IL_0012;
				IL_0079:
				return null;
				IL_00a6:
				throw new NotImplementedException();
			}

			[CustomObfuscation(rename = false)]
			internal static Definition CreateDefinition(Type type)
			{
				switch (type)
				{
				case Type.Axis:
					return new Axis.Definition();
				case Type.Button:
					return new Button.Definition();
				case Type.MouseAxis:
					return new MouseAxis.Definition();
				case Type.MouseWheelAxis:
					return new MouseWheelAxis.Definition();
				case Type.Axis2D:
					return new Axis2D.Definition();
				case Type.MouseAxis2D:
					return new MouseAxis2D.Definition();
				case Type.MouseWheel:
					return new MouseWheel.Definition();
				default:
					throw new NotImplementedException();
				}
			}
		}

		public abstract class ElementWithSource : Element
		{
			public new abstract class Definition : Element.Definition
			{
				private int mecAvOSCkKTUzDMSKLpGqHuOJBZ;

				public int actionId
				{
					get
					{
						return mecAvOSCkKTUzDMSKLpGqHuOJBZ;
					}
					set
					{
						mecAvOSCkKTUzDMSKLpGqHuOJBZ = value;
					}
				}

				public string actionName
				{
					get
					{
						if (!ReInput.isReady || mecAvOSCkKTUzDMSKLpGqHuOJBZ < 0)
						{
							return null;
						}
						InputAction action = ReInput.mapping.GetAction(mecAvOSCkKTUzDMSKLpGqHuOJBZ);
						if (action == null)
						{
							return null;
						}
						return action.name;
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
							mecAvOSCkKTUzDMSKLpGqHuOJBZ = -1;
						}
						else
						{
							mecAvOSCkKTUzDMSKLpGqHuOJBZ = action.id;
						}
					}
				}

				public Definition()
				{
					mecAvOSCkKTUzDMSKLpGqHuOJBZ = -1;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const int defaultActionId = -1;

			private int mecAvOSCkKTUzDMSKLpGqHuOJBZ = -1;

			public int actionId
			{
				get
				{
					return mecAvOSCkKTUzDMSKLpGqHuOJBZ;
				}
				set
				{
					mecAvOSCkKTUzDMSKLpGqHuOJBZ = value;
				}
			}

			public string actionName
			{
				get
				{
					if (!ReInput.isReady || mecAvOSCkKTUzDMSKLpGqHuOJBZ < 0)
					{
						return null;
					}
					InputAction action = ReInput.mapping.GetAction(mecAvOSCkKTUzDMSKLpGqHuOJBZ);
					if (action == null)
					{
						return null;
					}
					return action.name;
				}
				set
				{
					if (!ReInput.isReady)
					{
						return;
					}
					while (true)
					{
						InputAction action = ReInput.mapping.GetAction(value);
						if (action == null)
						{
							break;
						}
						while (true)
						{
							IL_0048:
							mecAvOSCkKTUzDMSKLpGqHuOJBZ = action.id;
							int num = 2010369282;
							while (true)
							{
								switch (num ^ 0x77D3CD02)
								{
								case 2:
									num = 2010369283;
									continue;
								default:
									return;
								case 1:
									break;
								case 3:
									goto IL_0048;
								case 0:
									return;
								}
								break;
							}
							break;
						}
					}
					mecAvOSCkKTUzDMSKLpGqHuOJBZ = -1;
				}
			}

			internal ElementWithSource(PlayerController parent, Definition definition)
				: base(parent, definition)
			{
				mecAvOSCkKTUzDMSKLpGqHuOJBZ = definition.actionId;
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
					while (true)
					{
						int num = -868019182;
						while (true)
						{
							switch (num ^ -868019184)
							{
							case 0:
								break;
							case 2:
								goto IL_0024;
							default:
								absoluteToRelativeSensitivity = 1f;
								return;
							}
							break;
							IL_0024:
							coordinateMode = AxisCoordinateMode.Absolute;
							num = -868019183;
						}
					}
				}

				internal override Element CreateElement(PlayerController P_0)
				{
					return new Axis(P_0, this);
				}
			}

			internal const float KZXurpvCNFBAytBqPPInseosCYi = 1f;

			[CustomObfuscation(rename = false)]
			internal const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Absolute;

			private float dnrncekBhbHUliJJmyTwATuSfTs = 1f;

			private AxisCoordinateMode ncxsDUUsZCAjNNDATjTbnEzLcURe;

			private bool NBOhEYGbeXsuTmrsRwBkMpKlbtk;

			public float absoluteToRelativeSensitivity
			{
				get
				{
					return dnrncekBhbHUliJJmyTwATuSfTs;
				}
				set
				{
					if (value < 0f)
					{
						value = 0f;
					}
					dnrncekBhbHUliJJmyTwATuSfTs = value;
				}
			}

			public AxisCoordinateMode coordinateMode
			{
				get
				{
					return ncxsDUUsZCAjNNDATjTbnEzLcURe;
				}
			}

			public virtual float value
			{
				get
				{
					if (base.selfAndParentEnabled)
					{
						AxisCoordinateMode axisCoordinateMode = default(AxisCoordinateMode);
						float num2 = default(float);
						while (true)
						{
							int num = -1897476097;
							while (true)
							{
								switch (num ^ -1897476102)
								{
								case 3:
									break;
								case 5:
									goto IL_0039;
								case 6:
									goto end_IL_0008;
								case 1:
									goto IL_0079;
								case 4:
									goto IL_0089;
								case 0:
									goto IL_00b2;
								default:
									goto IL_00cc;
								}
								break;
								IL_00b2:
								switch (axisCoordinateMode)
								{
								case AxisCoordinateMode.Relative:
									break;
								case AxisCoordinateMode.Absolute:
									goto IL_0097;
								default:
									goto IL_00c2;
								}
								goto IL_0089;
								IL_00c2:
								num = -1897476104;
								continue;
								IL_0097:
								if (ncxsDUUsZCAjNNDATjTbnEzLcURe == AxisCoordinateMode.Relative)
								{
									num2 *= ReInput.unscaledDeltaTime;
									num = -1897476101;
									continue;
								}
								goto IL_0079;
								IL_0079:
								num2 *= dnrncekBhbHUliJJmyTwATuSfTs;
								num = -1897476104;
								continue;
								IL_0089:
								if (ncxsDUUsZCAjNNDATjTbnEzLcURe == AxisCoordinateMode.Absolute)
								{
									return 0f;
								}
								goto IL_00cc;
								IL_0039:
								if (base.player == null)
								{
									num = -1897476100;
									continue;
								}
								num2 = base.player.GetAxis(base.actionId);
								axisCoordinateMode = base.player.GetAxisCoordinateMode(base.actionId);
								num = -1897476102;
								continue;
								IL_00cc:
								return num2;
							}
							continue;
							end_IL_0008:
							break;
						}
					}
					return 0f;
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
				while (true)
				{
					int num = -1379261167;
					while (true)
					{
						switch (num ^ -1379261165)
						{
						case 0:
							break;
						case 2:
							goto IL_0031;
						default:
							ncxsDUUsZCAjNNDATjTbnEzLcURe = definition.coordinateMode;
							return;
						}
						break;
						IL_0031:
						dnrncekBhbHUliJJmyTwATuSfTs = definition.absoluteToRelativeSensitivity;
						num = -1379261166;
					}
				}
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

				internal override Element CreateElement(PlayerController P_0)
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
					while (true)
					{
						int num2 = 213052169;
						while (true)
						{
							switch (num2 ^ 0xCB2EB08)
							{
							case 2:
								break;
							case 1:
								if (num == 0f)
								{
									return 0f;
								}
								if (base.player.GetAxisCoordinateMode(base.actionId) == AxisCoordinateMode.Absolute)
								{
									goto IL_0046;
								}
								goto default;
							default:
								return num;
							}
							break;
							IL_0046:
							num *= (float)Screen.currentResolution.width / 1920f;
							num2 = 213052168;
						}
					}
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

			private readonly List<Element> SERTGFptqMjtvIPNWFYznVbzAwf;

			internal int elementCount
			{
				get
				{
					return SERTGFptqMjtvIPNWFYznVbzAwf.Count;
				}
			}

			internal CompoundElement(PlayerController parent, Definition definition, Element.Definition[] elementDefinitions)
				: base(parent, definition)
			{
				SERTGFptqMjtvIPNWFYznVbzAwf = new List<Element>();
				if (elementDefinitions == null)
				{
					return;
				}
				for (int i = 0; i < elementDefinitions.Length; i++)
				{
					if (elementDefinitions[i] != null)
					{
						uiIyqEcLjeCLLGNLkqHYomAmAGZF(elementDefinitions[i].CreateElement(parent));
					}
				}
			}

			internal T KQaqMptOrhHmGWOCKcwibHIHaLV<T>(int P_0) where T : Element
			{
				if ((uint)P_0 >= (uint)SERTGFptqMjtvIPNWFYznVbzAwf.Count)
				{
					return null;
				}
				return SERTGFptqMjtvIPNWFYznVbzAwf[P_0] as T;
			}

			internal void LNDPlGnYyVBQBWaJvhRhAoCZFZh(List<Element> P_0)
			{
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num < SERTGFptqMjtvIPNWFYznVbzAwf.Count)
					{
						num2 = -85371476;
						num3 = num2;
					}
					else
					{
						num2 = -85371480;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -85371478)
						{
						case 3:
							num2 = -85371476;
							continue;
						default:
							return;
						case 6:
						{
							int num4;
							if (SERTGFptqMjtvIPNWFYznVbzAwf[num] is CompoundElement)
							{
								num2 = -85371477;
								num4 = num2;
							}
							else
							{
								num2 = -85371478;
								num4 = num2;
							}
							continue;
						}
						case 5:
							break;
						case 0:
							P_0.Add(SERTGFptqMjtvIPNWFYznVbzAwf[num]);
							num2 = -85371474;
							continue;
						case 1:
							(SERTGFptqMjtvIPNWFYznVbzAwf[num] as CompoundElement).LNDPlGnYyVBQBWaJvhRhAoCZFZh(P_0);
							num2 = -85371474;
							continue;
						case 4:
							num++;
							num2 = -85371473;
							continue;
						case 2:
							return;
						}
						break;
					}
				}
			}

			internal void uiIyqEcLjeCLLGNLkqHYomAmAGZF(Element P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("element");
				}
				SERTGFptqMjtvIPNWFYznVbzAwf.Add(P_0);
				P_0.isMemberElement = true;
			}
		}

		public class Axis2D : CompoundElement
		{
			public new class Definition : CompoundElement.Definition
			{
				private Axis.Definition TczConLzViblGIuETYsaeiAvHeO;

				private Axis.Definition ViamFGWNFlGpfoBVOxJiBHYOgEH;

				public Axis.Definition xAxis
				{
					get
					{
						return TczConLzViblGIuETYsaeiAvHeO;
					}
					set
					{
						TczConLzViblGIuETYsaeiAvHeO = value;
					}
				}

				public Axis.Definition yAxis
				{
					get
					{
						return ViamFGWNFlGpfoBVOxJiBHYOgEH;
					}
					set
					{
						ViamFGWNFlGpfoBVOxJiBHYOgEH = value;
					}
				}

				internal override Element CreateElement(PlayerController P_0)
				{
					return new Axis2D(P_0, this);
				}
			}

			internal const int vaMhxegjZkiGZlRWNNFJROZJEnY = 0;

			internal const int hiTkWtPuORcKilMIpQybVnQvRyY = 1;

			internal const int tVqaJITtxeifsriKkiaKCgWANnus = 2;

			public Axis xAxis
			{
				get
				{
					return KQaqMptOrhHmGWOCKcwibHIHaLV<Axis>(0);
				}
			}

			public Axis yAxis
			{
				get
				{
					return KQaqMptOrhHmGWOCKcwibHIHaLV<Axis>(1);
				}
			}

			public virtual Vector2 value
			{
				get
				{
					return new Vector2(KQaqMptOrhHmGWOCKcwibHIHaLV<Axis>(0).value, KQaqMptOrhHmGWOCKcwibHIHaLV<Axis>(1).value);
				}
			}

			public virtual Vector2 valueRaw
			{
				get
				{
					return new Vector2(KQaqMptOrhHmGWOCKcwibHIHaLV<Axis>(0).valueRaw, KQaqMptOrhHmGWOCKcwibHIHaLV<Axis>(1).valueRaw);
				}
			}

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

				internal override Element CreateElement(PlayerController P_0)
				{
					return new MouseAxis2D(P_0, this);
				}
			}

			public new MouseAxis xAxis
			{
				get
				{
					return KQaqMptOrhHmGWOCKcwibHIHaLV<MouseAxis>(0);
				}
			}

			public new MouseAxis yAxis
			{
				get
				{
					return KQaqMptOrhHmGWOCKcwibHIHaLV<MouseAxis>(1);
				}
			}

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
				internal override Element CreateElement(PlayerController P_0)
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
					if (base.selfAndParentEnabled)
					{
						while (true)
						{
							int num = -666869158;
							while (true)
							{
								switch (num ^ -666869157)
								{
								case 0:
									break;
								case 1:
									goto IL_0026;
								default:
									goto end_IL_0008;
								}
								break;
								IL_0026:
								if (base.player == null)
								{
									num = -666869159;
									continue;
								}
								return base.player.GetButtonUp(base.actionId);
							}
							continue;
							end_IL_0008:
							break;
						}
					}
					return false;
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

				internal override Element CreateElement(PlayerController P_0)
				{
					return new MouseWheel(P_0, this);
				}
			}

			public new MouseWheelAxis xAxis
			{
				get
				{
					return KQaqMptOrhHmGWOCKcwibHIHaLV<MouseWheelAxis>(0);
				}
			}

			public new MouseWheelAxis yAxis
			{
				get
				{
					return KQaqMptOrhHmGWOCKcwibHIHaLV<MouseWheelAxis>(1);
				}
			}

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

				internal override Element CreateElement(PlayerController P_0)
				{
					return new MouseWheelAxis(P_0, this);
				}
			}

			[CustomObfuscation(rename = false)]
			internal const float defaultRepeatRate = 4f;

			[CustomObfuscation(rename = false)]
			internal new const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Relative;

			private const float BATdaERbVaYMklKweeLYXsbXEpDG = 0.01f;

			private float haGvdeAzNhvXdxjkygPGsXeTzEh = 0.25f;

			private float PYlaZrEbVRGEhzvzzXnFYnAPqbe;

			private float FAoORBrTWqKCGNyMiKXRtudTOgk;

			public float repeatRate
			{
				get
				{
					if (haGvdeAzNhvXdxjkygPGsXeTzEh == 0f)
					{
						return 0f;
					}
					return 1f / haGvdeAzNhvXdxjkygPGsXeTzEh;
				}
				set
				{
					if (value < 0f)
					{
						value = 0f;
						goto IL_000f;
					}
					goto IL_0035;
					IL_0035:
					int num;
					int num2;
					if (value == 0f)
					{
						num = 1392380244;
						num2 = num;
					}
					else
					{
						num = 1392380245;
						num2 = num;
					}
					goto IL_0014;
					IL_000f:
					num = 1392380247;
					goto IL_0014;
					IL_0014:
					while (true)
					{
						switch (num ^ 0x52FE0956)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_0035;
						case 2:
							haGvdeAzNhvXdxjkygPGsXeTzEh = 0f;
							return;
						case 3:
							haGvdeAzNhvXdxjkygPGsXeTzEh = 1f / value;
							num = 1392380242;
							continue;
						case 4:
							return;
						}
						break;
					}
					goto IL_000f;
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
					return FAoORBrTWqKCGNyMiKXRtudTOgk;
				}
			}

			internal MouseWheelAxis(PlayerController parent, Definition definition)
				: base(parent, definition)
			{
				while (true)
				{
					int num = 1566022401;
					while (true)
					{
						switch (num ^ 0x5D579B00)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							goto IL_0031;
						case 0:
							return;
						}
						break;
						IL_0031:
						repeatRate = definition.repeatRate;
						num = 1566022400;
					}
				}
			}

			internal override void Update()
			{
				base.Update();
				if (!base.selfAndParentEnabled)
				{
					while (true)
					{
						switch (-281872822 ^ -281872821)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				FAoORBrTWqKCGNyMiKXRtudTOgk = DafgjXGnwnHCJGhWiGBdZDDtqJb();
			}

			protected override void EnabledStateChanged(bool state)
			{
				base.EnabledStateChanged(state);
				while (true)
				{
					int num = -1580338657;
					while (true)
					{
						switch (num ^ -1580338658)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							if (!state)
							{
								goto IL_0028;
							}
							return;
						case 0:
							return;
						}
						break;
						IL_0028:
						nympziBLtYDUiPlWNRoEGqbSPfa();
						num = -1580338658;
					}
				}
			}

			private float DafgjXGnwnHCJGhWiGBdZDDtqJb()
			{
				if (base.player == null)
				{
					return 0f;
				}
				float num = base.player.GetAxis(base.actionId);
				AxisCoordinateMode axisCoordinateMode = base.player.GetAxisCoordinateMode(base.actionId);
				AxisCoordinateMode axisCoordinateMode2 = axisCoordinateMode;
				bool flag = default(bool);
				while (true)
				{
					int num2 = 2018159540;
					while (true)
					{
						switch (num2 ^ 0x784AABB0)
						{
						case 6:
							break;
						case 2:
							num = 1f;
							num2 = 2018159539;
							continue;
						case 0:
							PYlaZrEbVRGEhzvzzXnFYnAPqbe = ReInput.unscaledTime;
							num2 = 2018159543;
							continue;
						case 3:
							if (!flag && ReInput.unscaledTime < PYlaZrEbVRGEhzvzzXnFYnAPqbe + haGvdeAzNhvXdxjkygPGsXeTzEh)
							{
								return 0f;
							}
							if (Mathf.Abs(num) <= 0.01f)
							{
								return 0f;
							}
							num = Mathf.Sign(num);
							num *= base.absoluteToRelativeSensitivity;
							num2 = 2018159536;
							continue;
						case 4:
							switch (axisCoordinateMode2)
							{
							case AxisCoordinateMode.Absolute:
								goto IL_00ee;
							case AxisCoordinateMode.Relative:
								goto IL_0141;
							}
							num2 = 2018159543;
							continue;
						case 1:
							goto IL_00ee;
						case 8:
							if (base.player.GetButtonDown(base.actionId))
							{
								flag = true;
								num2 = 2018159538;
								continue;
							}
							goto case 5;
						case 5:
							if (base.player.GetNegativeButtonDown(base.actionId))
							{
								flag = true;
								num = -1f;
								num2 = 2018159539;
								continue;
							}
							goto case 3;
						default:
							goto IL_0141;
							IL_0141:
							return num;
							IL_00ee:
							flag = false;
							num2 = 2018159544;
							continue;
						}
						break;
					}
				}
			}

			private void nympziBLtYDUiPlWNRoEGqbSPfa()
			{
				FAoORBrTWqKCGNyMiKXRtudTOgk = 0f;
				PYlaZrEbVRGEhzvzzXnFYnAPqbe = 0f;
			}
		}

		internal readonly int znFtIaPrJLvdjPGCwXFaaAeLKcr;

		private bool PAfqntGWZaNgzmZFIOyQPuJGOCq;

		private int iueDnAHVXVmEMnNCzSowjkddzOFv;

		private readonly AList<Element> SERTGFptqMjtvIPNWFYznVbzAwf;

		private readonly AList<Button> lgAkyeKCNYSjxkICDjzKgIcrtWEL;

		private readonly AList<Axis> PbFORHCAibynPVwQMVeRWSjVVbJ;

		private readonly ReadOnlyCollection<Element> uYCZQbMkrLLRfaHNIaSBlhhdXMi;

		private readonly ReadOnlyCollection<Button> YUEEutEHRiXnwNizOlBTOCVAsZw;

		private readonly ReadOnlyCollection<Axis> XPokcnKJNNUAUtIRBGdBJVNIoHAw;

		private readonly List<Element.UvPQNSiehACJrvBONJBxEuFvEvZ> gfEREqRssWfYecQgVvMwQCxxmAh;

		private Action<int, bool> UWUcVvwiCLhpRswJvpVbLGRpKwK;

		private Action<int, float> bAHHEOTptXbbAuqcuBlybpNijmlo;

		private Action<bool> TEEhmdIRbRbrcoqQUkwTruKySqN;

		public bool enabled
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return false;
				}
				return PAfqntGWZaNgzmZFIOyQPuJGOCq;
			}
			set
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					goto IL_001c;
				}
				goto IL_00b8;
				IL_00a5:
				int num;
				if (!value)
				{
					ClearVars();
					num = -1571736678;
					goto IL_0021;
				}
				goto IL_008a;
				IL_001c:
				num = -1571736680;
				goto IL_0021;
				IL_0021:
				int num2 = default(int);
				while (true)
				{
					switch (num ^ -1571736676)
					{
					case 0:
						break;
					case 3:
						SERTGFptqMjtvIPNWFYznVbzAwf[num2].enabled = value;
						num2++;
						num = -1571736677;
						continue;
					case 7:
						goto IL_006b;
					case 6:
						goto IL_008a;
					case 4:
						return;
					case 5:
						goto IL_00a5;
					case 1:
						goto IL_00b8;
					default:
						if (TEEhmdIRbRbrcoqQUkwTruKySqN != null)
						{
							try
							{
								TEEhmdIRbRbrcoqQUkwTruKySqN(value);
								return;
							}
							catch (Exception ex)
							{
								Logger.LogError("An exception occurred in a listener of EnabledStateChangedEvent. This means an exception was thrown by your code.\n" + ex);
								return;
							}
						}
						return;
					}
					break;
					IL_006b:
					int num3;
					if (num2 < SERTGFptqMjtvIPNWFYznVbzAwf._count)
					{
						num = -1571736673;
						num3 = num;
					}
					else
					{
						num = -1571736674;
						num3 = num;
					}
				}
				goto IL_001c;
				IL_00b8:
				if (PAfqntGWZaNgzmZFIOyQPuJGOCq == value)
				{
					return;
				}
				goto IL_00a5;
				IL_008a:
				PAfqntGWZaNgzmZFIOyQPuJGOCq = value;
				num2 = 0;
				num = -1571736677;
				goto IL_0021;
			}
		}

		public int playerId
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return -1;
				}
				return iueDnAHVXVmEMnNCzSowjkddzOFv;
			}
			set
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				}
				else if (iueDnAHVXVmEMnNCzSowjkddzOFv != value)
				{
					iueDnAHVXVmEMnNCzSowjkddzOFv = value;
					ClearVars();
				}
			}
		}

		public IList<Button> buttons
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return null;
				}
				return YUEEutEHRiXnwNizOlBTOCVAsZw;
			}
		}

		public IList<Axis> axes
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return null;
				}
				return XPokcnKJNNUAUtIRBGdBJVNIoHAw;
			}
		}

		public IList<Element> elements
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return null;
				}
				return uYCZQbMkrLLRfaHNIaSBlhhdXMi;
			}
		}

		public int buttonCount
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return 0;
				}
				if (lgAkyeKCNYSjxkICDjzKgIcrtWEL == null)
				{
					return 0;
				}
				return lgAkyeKCNYSjxkICDjzKgIcrtWEL._count;
			}
		}

		public int axisCount
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					while (true)
					{
						int num = 583400519;
						while (true)
						{
							switch (num ^ 0x22C5FC46)
							{
							case 2:
								break;
							case 1:
								goto IL_002b;
							default:
								return 0;
							}
							break;
							IL_002b:
							ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
							num = 583400518;
						}
					}
				}
				if (PbFORHCAibynPVwQMVeRWSjVVbJ == null)
				{
					return 0;
				}
				return PbFORHCAibynPVwQMVeRWSjVVbJ._count;
			}
		}

		public int elementCount
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return 0;
				}
				if (SERTGFptqMjtvIPNWFYznVbzAwf == null)
				{
					return 0;
				}
				return SERTGFptqMjtvIPNWFYznVbzAwf._count;
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
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					while (true)
					{
						switch (0x1A17B01A ^ 0x1A17B01B)
						{
						case 2:
							continue;
						case 1:
							ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
							return;
						}
						break;
					}
				}
				UWUcVvwiCLhpRswJvpVbLGRpKwK = (Action<int, bool>)Delegate.Combine(UWUcVvwiCLhpRswJvpVbLGRpKwK, value);
			}
			remove
			{
				UWUcVvwiCLhpRswJvpVbLGRpKwK = (Action<int, bool>)Delegate.Remove(UWUcVvwiCLhpRswJvpVbLGRpKwK, value);
			}
		}

		public event Action<int, float> AxisValueChangedEvent
		{
			add
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				}
				else
				{
					bAHHEOTptXbbAuqcuBlybpNijmlo = (Action<int, float>)Delegate.Combine(bAHHEOTptXbbAuqcuBlybpNijmlo, value);
				}
			}
			remove
			{
				bAHHEOTptXbbAuqcuBlybpNijmlo = (Action<int, float>)Delegate.Remove(bAHHEOTptXbbAuqcuBlybpNijmlo, value);
			}
		}

		public event Action<bool> EnabledStateChangedEvent
		{
			add
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					goto IL_000d;
				}
				goto IL_0043;
				IL_000d:
				int num = 875131107;
				goto IL_0012;
				IL_0012:
				switch (num ^ 0x342970E2)
				{
				case 3:
					break;
				default:
					return;
				case 1:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return;
				case 0:
					goto IL_0043;
				case 2:
					return;
				}
				goto IL_000d;
				IL_0043:
				TEEhmdIRbRbrcoqQUkwTruKySqN = (Action<bool>)Delegate.Combine(TEEhmdIRbRbrcoqQUkwTruKySqN, value);
				num = 875131104;
				goto IL_0012;
			}
			remove
			{
				TEEhmdIRbRbrcoqQUkwTruKySqN = (Action<bool>)Delegate.Remove(TEEhmdIRbRbrcoqQUkwTruKySqN, value);
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
			znFtIaPrJLvdjPGCwXFaaAeLKcr = ReInput._id;
			iueDnAHVXVmEMnNCzSowjkddzOFv = definition.playerId;
			PAfqntGWZaNgzmZFIOyQPuJGOCq = definition.enabled;
			List<Element> list = new List<Element>();
			List<Element> list2 = new List<Element>();
			List<Button> list3 = new List<Button>();
			List<Axis> list4 = new List<Axis>();
			foreach (Element.Definition element in definition.elements)
			{
				uiIyqEcLjeCLLGNLkqHYomAmAGZF(element.CreateElement(this), list, list2, list3, list4);
			}
			list.AddRange(list2);
			SERTGFptqMjtvIPNWFYznVbzAwf = new AList<Element>(list);
			lgAkyeKCNYSjxkICDjzKgIcrtWEL = new AList<Button>(list3);
			PbFORHCAibynPVwQMVeRWSjVVbJ = new AList<Axis>(list4);
			uYCZQbMkrLLRfaHNIaSBlhhdXMi = new ReadOnlyCollection<Element>(SERTGFptqMjtvIPNWFYznVbzAwf);
			YUEEutEHRiXnwNizOlBTOCVAsZw = new ReadOnlyCollection<Button>(lgAkyeKCNYSjxkICDjzKgIcrtWEL);
			XPokcnKJNNUAUtIRBGdBJVNIoHAw = new ReadOnlyCollection<Axis>(PbFORHCAibynPVwQMVeRWSjVVbJ);
			gfEREqRssWfYecQgVvMwQCxxmAh = new List<Element.UvPQNSiehACJrvBONJBxEuFvEvZ>();
			ReInput.UpdateEndedEvent += sroidYdoPhgGWbBrpNeOeuxXjDRZ;
		}

		~PlayerController()
		{
			ReInput.UpdateEndedEvent -= sroidYdoPhgGWbBrpNeOeuxXjDRZ;
		}

		public bool GetButton(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			if ((uint)index >= (uint)lgAkyeKCNYSjxkICDjzKgIcrtWEL._count)
			{
				return false;
			}
			return lgAkyeKCNYSjxkICDjzKgIcrtWEL[index].value;
		}

		public bool GetButtonDown(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			if ((uint)index >= (uint)lgAkyeKCNYSjxkICDjzKgIcrtWEL._count)
			{
				return false;
			}
			return lgAkyeKCNYSjxkICDjzKgIcrtWEL[index].justPressed;
		}

		public bool GetButtonUp(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			int num;
			if ((uint)index >= (uint)lgAkyeKCNYSjxkICDjzKgIcrtWEL._count)
			{
				num = -1943507643;
				goto IL_001e;
			}
			return lgAkyeKCNYSjxkICDjzKgIcrtWEL[index].justReleased;
			IL_0019:
			num = -1943507644;
			goto IL_001e;
			IL_001e:
			switch (num ^ -1943507643)
			{
			case 2:
				break;
			case 1:
				return false;
			default:
				return false;
			}
			goto IL_0019;
		}

		public float GetAxis(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			}
			if ((uint)index >= (uint)PbFORHCAibynPVwQMVeRWSjVVbJ._count)
			{
				return 0f;
			}
			return PbFORHCAibynPVwQMVeRWSjVVbJ[index].value;
		}

		public float GetAxisRaw(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			}
			if ((uint)index >= (uint)PbFORHCAibynPVwQMVeRWSjVVbJ._count)
			{
				return 0f;
			}
			return PbFORHCAibynPVwQMVeRWSjVVbJ[index].valueRaw;
		}

		public Element GetElement(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			int num;
			if ((uint)index >= (uint)PbFORHCAibynPVwQMVeRWSjVVbJ._count)
			{
				num = 974906505;
				goto IL_001e;
			}
			return SERTGFptqMjtvIPNWFYznVbzAwf[index];
			IL_0019:
			num = 974906506;
			goto IL_001e;
			IL_001e:
			switch (num ^ 0x3A1BE488)
			{
			case 0:
				break;
			case 2:
				return null;
			default:
				return null;
			}
			goto IL_0019;
		}

		public T GetElement<T>(int index) where T : Element
		{
			return GetElement(index) as T;
		}

		private void sroidYdoPhgGWbBrpNeOeuxXjDRZ(UpdateLoopType P_0)
		{
			Update(P_0);
			UpdateFinished();
		}

		protected virtual bool Update(UpdateLoopType updateLoop)
		{
			if (!PAfqntGWZaNgzmZFIOyQPuJGOCq)
			{
				goto IL_0008;
			}
			bool flag = bAHHEOTptXbbAuqcuBlybpNijmlo != null;
			bool flag2 = UWUcVvwiCLhpRswJvpVbLGRpKwK != null;
			int num = 0;
			int num2 = -1124236034;
			goto IL_000d;
			IL_000d:
			Button button = default(Button);
			float num4 = default(float);
			while (true)
			{
				switch (num2 ^ -1124236043)
				{
				case 6:
					break;
				case 2:
					num++;
					num2 = -1124236034;
					continue;
				case 1:
				{
					int num5;
					if (!button.justReleased)
					{
						num2 = -1124236041;
						num5 = num2;
					}
					else
					{
						num2 = -1124236048;
						num5 = num2;
					}
					continue;
				}
				case 10:
					return false;
				case 5:
					if (!button.value)
					{
						gfEREqRssWfYecQgVvMwQCxxmAh.Add(new Element.UvPQNSiehACJrvBONJBxEuFvEvZ(ControllerElementType.Button, num, 0f));
						num2 = -1124236041;
						continue;
					}
					goto case 2;
				case 0:
					num4 = 0f;
					num2 = -1124236042;
					continue;
				case 9:
					button = SERTGFptqMjtvIPNWFYznVbzAwf[num] as Button;
					if (button.justPressed)
					{
						int num7;
						if (button.value)
						{
							num2 = -1124236047;
							num7 = num2;
						}
						else
						{
							num2 = -1124236044;
							num7 = num2;
						}
						continue;
					}
					goto case 1;
				case 7:
					num4 = 0f;
					if (flag && SERTGFptqMjtvIPNWFYznVbzAwf[num] is Axis)
					{
						Axis axis = SERTGFptqMjtvIPNWFYznVbzAwf[num] as Axis;
						if (axis.coordinateMode == AxisCoordinateMode.Absolute)
						{
							num4 = axis.value;
							num2 = -1124236042;
							continue;
						}
						goto case 0;
					}
					goto case 3;
				case 4:
					gfEREqRssWfYecQgVvMwQCxxmAh.Add(new Element.UvPQNSiehACJrvBONJBxEuFvEvZ(ControllerElementType.Button, num, 1f));
					num2 = -1124236041;
					continue;
				case 3:
					SERTGFptqMjtvIPNWFYznVbzAwf[num].Update();
					if (flag2)
					{
						int num6;
						if (!(SERTGFptqMjtvIPNWFYznVbzAwf[num] is Button))
						{
							num2 = -1124236039;
							num6 = num2;
						}
						else
						{
							num2 = -1124236036;
							num6 = num2;
						}
						continue;
					}
					goto case 12;
				case 8:
					gfEREqRssWfYecQgVvMwQCxxmAh.Add(new Element.UvPQNSiehACJrvBONJBxEuFvEvZ(ControllerElementType.Axis, num, (SERTGFptqMjtvIPNWFYznVbzAwf[num] as Axis).value - num4));
					num2 = -1124236041;
					continue;
				case 12:
					if (flag)
					{
						int num3;
						if (!(SERTGFptqMjtvIPNWFYznVbzAwf[num] is Axis))
						{
							num2 = -1124236041;
							num3 = num2;
						}
						else
						{
							num2 = -1124236035;
							num3 = num2;
						}
						continue;
					}
					goto case 2;
				default:
					if (num >= SERTGFptqMjtvIPNWFYznVbzAwf._count)
					{
						return true;
					}
					goto case 7;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -1124236033;
			goto IL_000d;
		}

		protected virtual void UpdateFinished()
		{
			int count = gfEREqRssWfYecQgVvMwQCxxmAh.Count;
			if (count <= 0)
			{
				return;
			}
			Element.UvPQNSiehACJrvBONJBxEuFvEvZ uvPQNSiehACJrvBONJBxEuFvEvZ = default(Element.UvPQNSiehACJrvBONJBxEuFvEvZ);
			int num3 = default(int);
			while (true)
			{
				int num = -1666188706;
				while (true)
				{
					int num4;
					switch (num ^ -1666188710)
					{
					case 0:
						break;
					case 3:
						uvPQNSiehACJrvBONJBxEuFvEvZ = gfEREqRssWfYecQgVvMwQCxxmAh[num3];
						num = -1666188712;
						continue;
					case 4:
						num3 = 0;
						num = -1666188709;
						continue;
					default:
						if (uvPQNSiehACJrvBONJBxEuFvEvZ.jtJqVgInZRaLUQAkQAhzWYXSDiZ == ControllerElementType.Button)
						{
							try
							{
								UWUcVvwiCLhpRswJvpVbLGRpKwK(uvPQNSiehACJrvBONJBxEuFvEvZ.mFfLSVvRgZulYzYIyEkqCMoEiNXj, (uvPQNSiehACJrvBONJBxEuFvEvZ.JHgsNLxiAQVnmyfVeWejfTJocIu > 0f) ? true : false);
							}
							catch (Exception ex)
							{
								Logger.LogError("An exception occurred in a listener of ButtonStateChangedEvent. This means an exception was thrown by your code.\n" + ex);
							}
						}
						else if (uvPQNSiehACJrvBONJBxEuFvEvZ.jtJqVgInZRaLUQAkQAhzWYXSDiZ == ControllerElementType.Axis)
						{
							try
							{
								bAHHEOTptXbbAuqcuBlybpNijmlo(uvPQNSiehACJrvBONJBxEuFvEvZ.mFfLSVvRgZulYzYIyEkqCMoEiNXj, uvPQNSiehACJrvBONJBxEuFvEvZ.JHgsNLxiAQVnmyfVeWejfTJocIu);
							}
							catch (Exception ex2)
							{
								while (true)
								{
									IL_00cb:
									int num2 = -1666188709;
									while (true)
									{
										switch (num2 ^ -1666188710)
										{
										case 2:
											break;
										default:
											goto end_IL_00d0;
										case 1:
											goto IL_00e9;
										case 0:
											goto end_IL_00d0;
										}
										goto IL_00cb;
										IL_00e9:
										Logger.LogError("An exception occurred in a listener of AxisValueChangedEvent. This means an exception was thrown by your code.\n" + ex2);
										num2 = -1666188710;
										continue;
										end_IL_00d0:
										break;
									}
									break;
								}
							}
						}
						num3++;
						goto IL_0107;
					case 1:
						goto IL_0129;
						IL_0129:
						if (num3 < count)
						{
							goto case 3;
						}
						num4 = -1666188711;
						goto IL_010c;
						IL_010c:
						while (true)
						{
							switch (num4 ^ -1666188710)
							{
							case 0:
								break;
							default:
								return;
							case 1:
								goto IL_0129;
							case 3:
								gfEREqRssWfYecQgVvMwQCxxmAh.Clear();
								num4 = -1666188712;
								continue;
							case 2:
								return;
							}
							break;
						}
						goto IL_0107;
						IL_0107:
						num4 = -1666188709;
						goto IL_010c;
					}
					break;
				}
			}
		}

		protected virtual void ClearVars()
		{
			gfEREqRssWfYecQgVvMwQCxxmAh.Clear();
		}

		internal void uiIyqEcLjeCLLGNLkqHYomAmAGZF(Element P_0)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			goto IL_0031;
			IL_0003:
			int num = 199689037;
			goto IL_0008;
			IL_0008:
			switch (num ^ 0xBE7034F)
			{
			case 3:
				break;
			case 2:
				return;
			case 4:
				goto IL_0031;
			case 0:
				goto IL_0052;
			default:
				goto IL_0073;
			}
			goto IL_0003;
			IL_0031:
			if (P_0 is Axis)
			{
				PbFORHCAibynPVwQMVeRWSjVVbJ.Add(P_0 as Axis);
				num = 199689038;
				goto IL_0008;
			}
			goto IL_0052;
			IL_0052:
			if (P_0 is Button)
			{
				lgAkyeKCNYSjxkICDjzKgIcrtWEL.Add(P_0 as Button);
				num = 199689038;
				goto IL_0008;
			}
			goto IL_0073;
			IL_0073:
			SERTGFptqMjtvIPNWFYznVbzAwf.Add(P_0);
		}

		private void uiIyqEcLjeCLLGNLkqHYomAmAGZF(Element P_0, List<Element> P_1, List<Element> P_2, List<Button> P_3, List<Axis> P_4)
		{
			if (P_0 == null)
			{
				goto IL_0006;
			}
			goto IL_00c9;
			IL_0006:
			int num = 1339508489;
			goto IL_000b;
			IL_000b:
			while (true)
			{
				switch (num ^ 0x4FD7470B)
				{
				case 4:
					break;
				case 5:
					if (P_0 is Button)
					{
						P_3.Add((Button)P_0);
						num = 1339508492;
						continue;
					}
					goto case 3;
				case 7:
					num = 1339508490;
					continue;
				case 3:
					if (P_0 is Axis)
					{
						P_4.Add((Axis)P_0);
						num = 1339508490;
						continue;
					}
					goto case 9;
				case 9:
					Logger.LogWarning("Unknown Element type encountered: " + P_0.GetType());
					num = 1339508491;
					continue;
				case 2:
					return;
				case 1:
					P_1.Add(P_0);
					return;
				case 0:
					return;
				case 6:
					goto IL_00c9;
				default:
					goto IL_00ec;
				}
				break;
			}
			goto IL_0006;
			IL_00ec:
			if (P_0 is CompoundElement)
			{
				using (TempListPool.TList<Element> tList = TempListPool.GetTList<Element>())
				{
					List<Element> list = tList.list;
					(P_0 as CompoundElement).LNDPlGnYyVBQBWaJvhRhAoCZFZh(list);
					int num3 = default(int);
					while (true)
					{
						IL_0110:
						int num2 = 1339508489;
						while (true)
						{
							switch (num2 ^ 0x4FD7470B)
							{
							case 3:
								break;
							case 0:
								num3++;
								num2 = 1339508490;
								continue;
							case 4:
								uiIyqEcLjeCLLGNLkqHYomAmAGZF(list[num3], P_1, P_2, P_3, P_4);
								num2 = 1339508491;
								continue;
							case 2:
								num3 = 0;
								num2 = 1339508490;
								continue;
							default:
								if (num3 >= list.Count)
								{
									goto end_IL_0115;
								}
								goto case 4;
							}
							goto IL_0110;
							continue;
							end_IL_0115:
							break;
						}
						break;
					}
				}
				P_2.Add(P_0);
				return;
			}
			while (true)
			{
				Logger.LogWarning("Unknown Element type encountered: " + P_0.GetType());
				int num4 = 1339508491;
				while (true)
				{
					switch (num4 ^ 0x4FD7470B)
					{
					case 2:
						goto IL_0181;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_0181:
					num4 = 1339508490;
				}
			}
			IL_00c9:
			P_0.GetType();
			int num5;
			if (!(P_0 is ElementWithSource))
			{
				num = 1339508483;
				num5 = num;
			}
			else
			{
				num = 1339508494;
				num5 = num;
			}
			goto IL_000b;
		}

		internal static int eEaeRhdMBvlgJyTeGHlQmUkRWOvh<T>(IList<T> P_0, Predicate<T> P_1, int P_2) where T : Element
		{
			int num = 0;
			int num3 = default(int);
			while (true)
			{
				int num2 = -1116754537;
				while (true)
				{
					switch (num2 ^ -1116754539)
					{
					case 4:
						break;
					case 2:
						num3 = 0;
						num2 = -1116754539;
						continue;
					case 1:
						if (P_1(P_0[num3]))
						{
							num++;
							num2 = -1116754538;
							continue;
						}
						goto case 3;
					case 3:
						if (num == P_2)
						{
							return num3;
						}
						num3++;
						num2 = -1116754539;
						continue;
					default:
						if (num3 >= P_0.Count)
						{
							return -1;
						}
						goto case 1;
					}
					break;
				}
			}
		}
	}
}
