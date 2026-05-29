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

			internal struct rDFNfJQfqUvcOHJstNvfxVmjoeO
			{
				public ControllerElementType ERFGOjgLTTFXpgYjkdzhlHHCfvY;

				public int VgtGZGVNuFqErLJXYsgetKqIFWC;

				public float kXoKOSZJMKwATOiGMaylYIDqdDnb;

				public rDFNfJQfqUvcOHJstNvfxVmjoeO(ControllerElementType elementType, int index, float value)
				{
					ERFGOjgLTTFXpgYjkdzhlHHCfvY = elementType;
					VgtGZGVNuFqErLJXYsgetKqIFWC = index;
					kXoKOSZJMKwATOiGMaylYIDqdDnb = value;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const bool defaultEnabled = true;

			private readonly PlayerController eOotmcFksuDgVSpJBCGwMaaBooj;

			private bool VBfVrJaUrUwmTzGgxNoxIZAeRXF;

			private bool gmbIkkevNmPVGSTIwKcAwoPYANrc = true;

			private string jMnuxDpeLQhKgkpKQOlnqChJgyRd;

			private static int[] ykDMdmCkPyGtAFnKKgqjcdHIfaV;

			private static int[] cCJpFDvBnjdUzFGAziXdKHEmlKq;

			protected Player player
			{
				get
				{
					if (!ReInput.isReady)
					{
						return null;
					}
					return ReInput.players.GetPlayer(eOotmcFksuDgVSpJBCGwMaaBooj.VUcYiZtcJRatratRXOokIFfcdNSg);
				}
			}

			protected bool selfAndParentEnabled
			{
				get
				{
					if (gmbIkkevNmPVGSTIwKcAwoPYANrc)
					{
						return eOotmcFksuDgVSpJBCGwMaaBooj.gmbIkkevNmPVGSTIwKcAwoPYANrc;
					}
					return false;
				}
			}

			internal bool isMemberElement
			{
				get
				{
					return VBfVrJaUrUwmTzGgxNoxIZAeRXF;
				}
				set
				{
					VBfVrJaUrUwmTzGgxNoxIZAeRXF = true;
				}
			}

			public bool enabled
			{
				get
				{
					return gmbIkkevNmPVGSTIwKcAwoPYANrc;
				}
				set
				{
					if (gmbIkkevNmPVGSTIwKcAwoPYANrc == value)
					{
						goto IL_0009;
					}
					goto IL_0033;
					IL_0009:
					int num = -381447394;
					goto IL_000e;
					IL_000e:
					switch (num ^ -381447396)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						return;
					case 1:
						goto IL_0033;
					case 3:
						return;
					}
					goto IL_0009;
					IL_0033:
					gmbIkkevNmPVGSTIwKcAwoPYANrc = value;
					EnabledStateChanged(value);
					num = -381447393;
					goto IL_000e;
				}
			}

			public string name
			{
				get
				{
					return jMnuxDpeLQhKgkpKQOlnqChJgyRd;
				}
				set
				{
					jMnuxDpeLQhKgkpKQOlnqChJgyRd = value;
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
				eOotmcFksuDgVSpJBCGwMaaBooj = parent;
				gmbIkkevNmPVGSTIwKcAwoPYANrc = definition.enabled;
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
				if (ykDMdmCkPyGtAFnKKgqjcdHIfaV == null)
				{
					ykDMdmCkPyGtAFnKKgqjcdHIfaV = (int[])Enum.GetValues(typeof(TypeWithSource));
				}
				return ArrayTools.Contains(ykDMdmCkPyGtAFnKKgqjcdHIfaV, (int)type);
			}

			[CustomObfuscation(rename = false)]
			internal static bool IsCompoundType(Type type)
			{
				if (cCJpFDvBnjdUzFGAziXdKHEmlKq == null)
				{
					cCJpFDvBnjdUzFGAziXdKHEmlKq = (int[])Enum.GetValues(typeof(CompoundTypes));
				}
				return ArrayTools.Contains(cCJpFDvBnjdUzFGAziXdKHEmlKq, (int)type);
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
					switch (type)
					{
					case Type.Axis2D:
						return 2;
					case Type.MouseAxis2D:
						return 2;
					case Type.MouseWheel:
						return 2;
					default:
						throw new NotImplementedException();
					}
				}
				throw new NotImplementedException();
			}

			[CustomObfuscation(rename = false)]
			internal static string GetElementTitle(Type type, int index)
			{
				int num;
				if (index >= 0)
				{
					if (index > GetMaxElementCount(type))
					{
						goto IL_000d;
					}
					int num2;
					if (IsTypeWithSource(type))
					{
						num = -1927367794;
					}
					else if (!IsCompoundType(type))
					{
						num = -1927367795;
						num2 = num;
					}
					else
					{
						num = -1927367800;
						num2 = num;
					}
					goto IL_0012;
				}
				goto IL_007e;
				IL_007e:
				return null;
				IL_0012:
				while (true)
				{
					switch (num ^ -1927367797)
					{
					case 2:
						break;
					case 0:
						goto IL_003b;
					case 4:
						return "Y Axis";
					case 3:
						switch (type)
						{
						case Type.Axis2D:
						case Type.MouseAxis2D:
						case Type.MouseWheel:
							break;
						default:
							throw new NotImplementedException();
						}
						goto IL_003b;
					case 1:
						goto IL_007e;
					case 5:
						return null;
					default:
						throw new NotImplementedException();
					}
					break;
					IL_003b:
					if (index != 0)
					{
						num = -1927367793;
						continue;
					}
					return "X Axis";
				}
				goto IL_000d;
				IL_000d:
				num = -1927367798;
				goto IL_0012;
			}

			[CustomObfuscation(rename = false)]
			internal static Definition CreateDefinition(Type type)
			{
				while (true)
				{
					switch (-1050383131 ^ -1050383132)
					{
					case 2:
						continue;
					case 1:
						switch (type)
						{
						case Type.Axis:
							break;
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
						break;
					}
					break;
				}
				return new Axis.Definition();
			}
		}

		public abstract class ElementWithSource : Element
		{
			public new abstract class Definition : Element.Definition
			{
				private int ZUoDkTcclUigIzTjeFLCXFMQOaU;

				public int actionId
				{
					get
					{
						return ZUoDkTcclUigIzTjeFLCXFMQOaU;
					}
					set
					{
						ZUoDkTcclUigIzTjeFLCXFMQOaU = value;
					}
				}

				public string actionName
				{
					get
					{
						InputAction action = default(InputAction);
						int num;
						if (ReInput.isReady)
						{
							if (ZUoDkTcclUigIzTjeFLCXFMQOaU < 0)
							{
								goto IL_0010;
							}
							action = ReInput.mapping.GetAction(ZUoDkTcclUigIzTjeFLCXFMQOaU);
							num = -783269913;
							goto IL_0015;
						}
						goto IL_0032;
						IL_0015:
						while (true)
						{
							switch (num ^ -783269914)
							{
							case 0:
								break;
							case 3:
								goto IL_0032;
							case 1:
								goto IL_004c;
							default:
								return null;
							}
							break;
							IL_004c:
							if (action == null)
							{
								num = -783269916;
								continue;
							}
							return action.name;
						}
						goto IL_0010;
						IL_0032:
						return null;
						IL_0010:
						num = -783269915;
						goto IL_0015;
					}
					set
					{
						if (!ReInput.isReady)
						{
							while (true)
							{
								int num = 1557676175;
								while (true)
								{
									switch (num ^ 0x5CD8408C)
									{
									case 2:
										break;
									case 1:
										goto end_IL_0007;
									case 4:
										return;
									case 3:
										Logger.LogError("You cannot set an Action Name because Rewired has not been intialized.");
										num = 1557676168;
										continue;
									default:
										goto IL_0064;
									}
									break;
								}
								continue;
								end_IL_0007:
								break;
							}
						}
						InputAction action = ReInput.mapping.GetAction(value);
						if (action == null)
						{
							ZUoDkTcclUigIzTjeFLCXFMQOaU = -1;
							return;
						}
						goto IL_0064;
						IL_0064:
						ZUoDkTcclUigIzTjeFLCXFMQOaU = action.id;
					}
				}

				public Definition()
				{
					ZUoDkTcclUigIzTjeFLCXFMQOaU = -1;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const int defaultActionId = -1;

			private int ZUoDkTcclUigIzTjeFLCXFMQOaU = -1;

			public int actionId
			{
				get
				{
					return ZUoDkTcclUigIzTjeFLCXFMQOaU;
				}
				set
				{
					ZUoDkTcclUigIzTjeFLCXFMQOaU = value;
				}
			}

			public string actionName
			{
				get
				{
					InputAction action = default(InputAction);
					int num;
					if (ReInput.isReady)
					{
						if (ZUoDkTcclUigIzTjeFLCXFMQOaU < 0)
						{
							goto IL_0010;
						}
						action = ReInput.mapping.GetAction(ZUoDkTcclUigIzTjeFLCXFMQOaU);
						num = -587911809;
						goto IL_0015;
					}
					goto IL_002e;
					IL_002e:
					return null;
					IL_0048:
					if (action == null)
					{
						return null;
					}
					return action.name;
					IL_0010:
					num = -587911812;
					goto IL_0015;
					IL_0015:
					switch (num ^ -587911811)
					{
					case 0:
						break;
					case 1:
						goto IL_002e;
					default:
						goto IL_0048;
					}
					goto IL_0010;
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
						int num = -1065769952;
						while (true)
						{
							switch (num ^ -1065769951)
							{
							case 0:
								goto IL_0008;
							case 2:
								break;
							case 1:
								if (action == null)
								{
									ZUoDkTcclUigIzTjeFLCXFMQOaU = -1;
									return;
								}
								goto default;
							default:
								ZUoDkTcclUigIzTjeFLCXFMQOaU = action.id;
								return;
							}
							break;
							IL_0008:
							num = -1065769949;
						}
					}
				}
			}

			internal ElementWithSource(PlayerController parent, Definition definition)
				: base(parent, definition)
			{
				ZUoDkTcclUigIzTjeFLCXFMQOaU = definition.actionId;
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

				internal override Element CreateElement(PlayerController P_0)
				{
					return new Axis(P_0, this);
				}
			}

			internal const float fHfSiNDKVmMPZYbfXDnVZyeLEt = 1f;

			[CustomObfuscation(rename = false)]
			internal const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Absolute;

			private float OWzaqvGKvbEtGUwAGsPujFuIjsl = 1f;

			private AxisCoordinateMode IAhIAXapTGAzkzcLneVfGEhLLTOb;

			private bool azKiPJclWPBZyKmXbmjknfbjeuf;

			public float absoluteToRelativeSensitivity
			{
				get
				{
					return OWzaqvGKvbEtGUwAGsPujFuIjsl;
				}
				set
				{
					if (value < 0f)
					{
						value = 0f;
						goto IL_000f;
					}
					goto IL_002d;
					IL_002d:
					OWzaqvGKvbEtGUwAGsPujFuIjsl = value;
					int num = -1038135379;
					goto IL_0014;
					IL_000f:
					num = -1038135378;
					goto IL_0014;
					IL_0014:
					switch (num ^ -1038135377)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_002d;
					case 2:
						return;
					}
					goto IL_000f;
				}
			}

			public AxisCoordinateMode coordinateMode
			{
				get
				{
					return IAhIAXapTGAzkzcLneVfGEhLLTOb;
				}
			}

			public virtual float value
			{
				get
				{
					float num = default(float);
					int num2;
					if (base.selfAndParentEnabled)
					{
						if (base.player == null)
						{
							goto IL_0010;
						}
						num = base.player.GetAxis(base.actionId);
						switch (base.player.GetAxisCoordinateMode(base.actionId))
						{
						case AxisCoordinateMode.Relative:
							goto IL_00a0;
						case AxisCoordinateMode.Absolute:
							goto IL_00ae;
						}
						num2 = 153373316;
						goto IL_0015;
					}
					goto IL_003d;
					IL_0010:
					num2 = 153373315;
					goto IL_0015;
					IL_0015:
					while (true)
					{
						switch (num2 ^ 0x9244A86)
						{
						case 3:
							break;
						case 5:
							goto IL_003d;
						case 0:
							num *= OWzaqvGKvbEtGUwAGsPujFuIjsl;
							num2 = 153373316;
							continue;
						case 4:
							num *= ReInput.unscaledDeltaTime;
							num2 = 153373318;
							continue;
						case 1:
							goto IL_00a0;
						default:
							goto IL_00cb;
						}
						break;
					}
					goto IL_0010;
					IL_00ae:
					int num3;
					if (IAhIAXapTGAzkzcLneVfGEhLLTOb != AxisCoordinateMode.Relative)
					{
						num2 = 153373318;
						num3 = num2;
					}
					else
					{
						num2 = 153373314;
						num3 = num2;
					}
					goto IL_0015;
					IL_00cb:
					return num;
					IL_00a0:
					if (IAhIAXapTGAzkzcLneVfGEhLLTOb == AxisCoordinateMode.Absolute)
					{
						return 0f;
					}
					goto IL_00cb;
					IL_003d:
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
					int num = -1051496446;
					while (true)
					{
						switch (num ^ -1051496445)
						{
						case 3:
							break;
						default:
							return;
						case 1:
							OWzaqvGKvbEtGUwAGsPujFuIjsl = definition.absoluteToRelativeSensitivity;
							num = -1051496445;
							continue;
						case 0:
							IAhIAXapTGAzkzcLneVfGEhLLTOb = definition.coordinateMode;
							num = -1051496447;
							continue;
						case 2:
							return;
						}
						break;
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
					while (true)
					{
						int num = -2143656033;
						while (true)
						{
							switch (num ^ -2143656036)
							{
							case 0:
								break;
							default:
								return;
							case 3:
								coordinateMode = AxisCoordinateMode.Relative;
								num = -2143656035;
								continue;
							case 1:
								absoluteToRelativeSensitivity = 600f;
								num = -2143656034;
								continue;
							case 2:
								return;
							}
							break;
						}
					}
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
					if (num == 0f)
					{
						return 0f;
					}
					if (base.player.GetAxisCoordinateMode(base.actionId) == AxisCoordinateMode.Absolute)
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

			private readonly List<Element> zGVdLCAPoSECGnwSmQQzpAttLxeB;

			internal int elementCount
			{
				get
				{
					return zGVdLCAPoSECGnwSmQQzpAttLxeB.Count;
				}
			}

			internal CompoundElement(PlayerController parent, Definition definition, Element.Definition[] elementDefinitions)
				: base(parent, definition)
			{
				zGVdLCAPoSECGnwSmQQzpAttLxeB = new List<Element>();
				if (elementDefinitions == null)
				{
					return;
				}
				for (int i = 0; i < elementDefinitions.Length; i++)
				{
					if (elementDefinitions[i] != null)
					{
						DaOirHIMrqCgwPvMGCDKpJCcEFCO(elementDefinitions[i].CreateElement(parent));
					}
				}
			}

			internal T duggHcLUlnjRnySPwdcsYXQFaCE<T>(int P_0) where T : Element
			{
				if ((uint)P_0 >= (uint)zGVdLCAPoSECGnwSmQQzpAttLxeB.Count)
				{
					return null;
				}
				return zGVdLCAPoSECGnwSmQQzpAttLxeB[P_0] as T;
			}

			internal void krZFeJLxsPeSuuwGTNErzcEZdSm(List<Element> P_0)
			{
				int num = 0;
				while (num < zGVdLCAPoSECGnwSmQQzpAttLxeB.Count)
				{
					while (true)
					{
						IL_005c:
						int num2;
						if (zGVdLCAPoSECGnwSmQQzpAttLxeB[num] is CompoundElement)
						{
							(zGVdLCAPoSECGnwSmQQzpAttLxeB[num] as CompoundElement).krZFeJLxsPeSuuwGTNErzcEZdSm(P_0);
							num2 = -1540357140;
							goto IL_000c;
						}
						goto IL_0043;
						IL_000c:
						while (true)
						{
							switch (num2 ^ -1540357137)
							{
							case 4:
								num2 = -1540357139;
								continue;
							case 0:
								num++;
								num2 = -1540357142;
								continue;
							case 3:
								num2 = -1540357137;
								continue;
							case 1:
								break;
							case 2:
								goto IL_005c;
							default:
								goto end_IL_005c;
							}
							break;
						}
						goto IL_0043;
						IL_0043:
						P_0.Add(zGVdLCAPoSECGnwSmQQzpAttLxeB[num]);
						num2 = -1540357137;
						goto IL_000c;
						continue;
						end_IL_005c:
						break;
					}
				}
			}

			internal void DaOirHIMrqCgwPvMGCDKpJCcEFCO(Element P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("element");
				}
				while (true)
				{
					zGVdLCAPoSECGnwSmQQzpAttLxeB.Add(P_0);
					P_0.isMemberElement = true;
					int num = 528565632;
					while (true)
					{
						switch (num ^ 0x1F814580)
						{
						case 2:
							goto IL_000e;
						default:
							return;
						case 1:
							break;
						case 0:
							return;
						}
						break;
						IL_000e:
						num = 528565633;
					}
				}
			}
		}

		public class Axis2D : CompoundElement
		{
			public new class Definition : CompoundElement.Definition
			{
				private Axis.Definition yxplCcjZLeAgfcuHpKCqVmUfvqR;

				private Axis.Definition iAyAdValPhnWUWwGyvncuQWOntE;

				public Axis.Definition xAxis
				{
					get
					{
						return yxplCcjZLeAgfcuHpKCqVmUfvqR;
					}
					set
					{
						yxplCcjZLeAgfcuHpKCqVmUfvqR = value;
					}
				}

				public Axis.Definition yAxis
				{
					get
					{
						return iAyAdValPhnWUWwGyvncuQWOntE;
					}
					set
					{
						iAyAdValPhnWUWwGyvncuQWOntE = value;
					}
				}

				internal override Element CreateElement(PlayerController P_0)
				{
					return new Axis2D(P_0, this);
				}
			}

			internal const int QYUgtPGFjaLkoPFAnTLhsXnTBFd = 0;

			internal const int OUXRZwnAYDOnBDvVBUuxikYtRpV = 1;

			internal const int MMsGZFlttyAGXXvBAqEQBbIWDwn = 2;

			public Axis xAxis
			{
				get
				{
					return duggHcLUlnjRnySPwdcsYXQFaCE<Axis>(0);
				}
			}

			public Axis yAxis
			{
				get
				{
					return duggHcLUlnjRnySPwdcsYXQFaCE<Axis>(1);
				}
			}

			public virtual Vector2 value
			{
				get
				{
					return new Vector2(duggHcLUlnjRnySPwdcsYXQFaCE<Axis>(0).value, duggHcLUlnjRnySPwdcsYXQFaCE<Axis>(1).value);
				}
			}

			public virtual Vector2 valueRaw
			{
				get
				{
					return new Vector2(duggHcLUlnjRnySPwdcsYXQFaCE<Axis>(0).valueRaw, duggHcLUlnjRnySPwdcsYXQFaCE<Axis>(1).valueRaw);
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
					return duggHcLUlnjRnySPwdcsYXQFaCE<MouseAxis>(0);
				}
			}

			public new MouseAxis yAxis
			{
				get
				{
					return duggHcLUlnjRnySPwdcsYXQFaCE<MouseAxis>(1);
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
					if (base.selfAndParentEnabled)
					{
						while (true)
						{
							int num = 1261229320;
							while (true)
							{
								switch (num ^ 0x4B2CD50A)
								{
								case 0:
									break;
								case 2:
									goto IL_0026;
								default:
									goto end_IL_0008;
								}
								break;
								IL_0026:
								if (base.player == null)
								{
									num = 1261229323;
									continue;
								}
								return base.player.GetButtonDown(base.actionId);
							}
							continue;
							end_IL_0008:
							break;
						}
					}
					return false;
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
							int num = 481982172;
							while (true)
							{
								switch (num ^ 0x1CBA76DD)
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
									num = 481982175;
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
					return duggHcLUlnjRnySPwdcsYXQFaCE<MouseWheelAxis>(0);
				}
			}

			public new MouseWheelAxis yAxis
			{
				get
				{
					return duggHcLUlnjRnySPwdcsYXQFaCE<MouseWheelAxis>(1);
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

			private const float cAZrPBfiFqfXPXypUZGEqHxVDwO = 0.01f;

			private float GWGwofwgtvCdCPbgSewRJFDTJwg = 0.25f;

			private float gkzABwoETNItWPmgDArTnkCPNun;

			private float oEeTqWLfGqIvjjZLGKQRMTdJbXv;

			public float repeatRate
			{
				get
				{
					if (GWGwofwgtvCdCPbgSewRJFDTJwg == 0f)
					{
						return 0f;
					}
					return 1f / GWGwofwgtvCdCPbgSewRJFDTJwg;
				}
				set
				{
					if (value < 0f)
					{
						value = 0f;
						goto IL_000f;
					}
					goto IL_004f;
					IL_004f:
					int num;
					int num2;
					if (value != 0f)
					{
						num = -1469694276;
						num2 = num;
					}
					else
					{
						num = -1469694275;
						num2 = num;
					}
					goto IL_0014;
					IL_000f:
					num = -1469694274;
					goto IL_0014;
					IL_0014:
					while (true)
					{
						switch (num ^ -1469694276)
						{
						case 3:
							break;
						case 4:
							return;
						case 1:
							GWGwofwgtvCdCPbgSewRJFDTJwg = 0f;
							num = -1469694280;
							continue;
						case 2:
							goto IL_004f;
						default:
							GWGwofwgtvCdCPbgSewRJFDTJwg = 1f / value;
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
					return oEeTqWLfGqIvjjZLGKQRMTdJbXv;
				}
			}

			internal MouseWheelAxis(PlayerController parent, Definition definition)
				: base(parent, definition)
			{
				repeatRate = definition.repeatRate;
			}

			internal override void Update()
			{
				base.Update();
				if (base.selfAndParentEnabled)
				{
					oEeTqWLfGqIvjjZLGKQRMTdJbXv = afhttcydXhkDzqwtUOMLcZypzVw();
				}
			}

			protected override void EnabledStateChanged(bool state)
			{
				base.EnabledStateChanged(state);
				if (!state)
				{
					QYwkAfdRMMgAPnyPzHFUdcsKUPp();
				}
			}

			private float afhttcydXhkDzqwtUOMLcZypzVw()
			{
				if (base.player == null)
				{
					return 0f;
				}
				float num = base.player.GetAxis(base.actionId);
				int num2;
				bool flag = default(bool);
				int num4;
				switch (base.player.GetAxisCoordinateMode(base.actionId))
				{
				default:
					num2 = 20136335;
					goto IL_0047;
				case AxisCoordinateMode.Absolute:
					goto IL_0091;
				case AxisCoordinateMode.Relative:
					break;
					IL_0047:
					while (true)
					{
						switch (num2 ^ 0x1334188)
						{
						case 2:
							break;
						case 8:
							gkzABwoETNItWPmgDArTnkCPNun = ReInput.unscaledTime;
							num2 = 20136334;
							continue;
						case 0:
							goto IL_0091;
						case 1:
							flag = true;
							num = 1f;
							num2 = 20136331;
							continue;
						case 4:
							goto IL_00c6;
						case 9:
							goto IL_010d;
						case 3:
							goto IL_0134;
						case 5:
							flag = true;
							num = -1f;
							num2 = 20136331;
							continue;
						case 7:
							num2 = 20136334;
							continue;
						default:
							goto end_IL_0035;
						}
						break;
						IL_0134:
						if (!flag)
						{
							num2 = 20136332;
							continue;
						}
						goto IL_00e0;
						IL_00e0:
						if (Mathf.Abs(num) <= 0.01f)
						{
							return 0f;
						}
						num = Mathf.Sign(num);
						num *= base.absoluteToRelativeSensitivity;
						num2 = 20136320;
						continue;
						IL_010d:
						int num3;
						if (!base.player.GetNegativeButtonDown(base.actionId))
						{
							num2 = 20136331;
							num3 = num2;
						}
						else
						{
							num2 = 20136333;
							num3 = num2;
						}
						continue;
						IL_00c6:
						if (ReInput.unscaledTime < gkzABwoETNItWPmgDArTnkCPNun + GWGwofwgtvCdCPbgSewRJFDTJwg)
						{
							return 0f;
						}
						goto IL_00e0;
					}
					goto default;
					IL_0091:
					flag = false;
					if (base.player.GetButtonDown(base.actionId))
					{
						num2 = 20136329;
						num4 = num2;
					}
					else
					{
						num2 = 20136321;
						num4 = num2;
					}
					goto IL_0047;
					end_IL_0035:
					break;
				}
				return num;
			}

			private void QYwkAfdRMMgAPnyPzHFUdcsKUPp()
			{
				oEeTqWLfGqIvjjZLGKQRMTdJbXv = 0f;
				gkzABwoETNItWPmgDArTnkCPNun = 0f;
			}
		}

		internal readonly int SsPwhbdijXONOlkRKHOkXryZrDq;

		private bool gmbIkkevNmPVGSTIwKcAwoPYANrc;

		private int VUcYiZtcJRatratRXOokIFfcdNSg;

		private readonly AList<Element> zGVdLCAPoSECGnwSmQQzpAttLxeB;

		private readonly AList<Button> WXIRxjkGHEWEQMEDrfdCKrevQRBu;

		private readonly AList<Axis> qbVJMDgYpnJuvznLeFDMdGeZUGX;

		private readonly ReadOnlyCollection<Element> DnCGAXuCydczsGMHdwaSQnTzKxR;

		private readonly ReadOnlyCollection<Button> viYopkgjFozOPpuuwOXRrmFKiWf;

		private readonly ReadOnlyCollection<Axis> qUwOjuiiHRUnpVEQpCzDHwXUBGDm;

		private readonly List<Element.rDFNfJQfqUvcOHJstNvfxVmjoeO> NaCMZvhCmEGdXOylluQkjYbfaRk;

		private Action<int, bool> zeGKZcOqKBGocSRKPdTtybVdnFX;

		private Action<int, float> UkJMZFbJhLdMvSjhIyryUeXaJfm;

		private Action<bool> keQiiwcvhFUxZCAVksrVOIIyXdA;

		public bool enabled
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return false;
				}
				return gmbIkkevNmPVGSTIwKcAwoPYANrc;
			}
			set
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					goto IL_001c;
				}
				goto IL_00b5;
				IL_00b5:
				if (gmbIkkevNmPVGSTIwKcAwoPYANrc == value)
				{
					return;
				}
				goto IL_0075;
				IL_001c:
				int num = 791005442;
				goto IL_0021;
				IL_0021:
				int num2 = default(int);
				while (true)
				{
					switch (num ^ 0x2F25C905)
					{
					case 0:
						break;
					case 7:
						return;
					case 3:
						num2 = 0;
						num = 791005453;
						continue;
					case 4:
						num2++;
						num = 791005453;
						continue;
					case 9:
						goto IL_0075;
					case 5:
						zGVdLCAPoSECGnwSmQQzpAttLxeB[num2].enabled = value;
						num = 791005441;
						continue;
					case 6:
						ClearVars();
						num = 791005444;
						continue;
					case 2:
						goto IL_00b5;
					case 1:
						gmbIkkevNmPVGSTIwKcAwoPYANrc = value;
						num = 791005446;
						continue;
					default:
						if (num2 >= zGVdLCAPoSECGnwSmQQzpAttLxeB._count)
						{
							if (keQiiwcvhFUxZCAVksrVOIIyXdA != null)
							{
								try
								{
									keQiiwcvhFUxZCAVksrVOIIyXdA(value);
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
						goto case 5;
					}
					break;
				}
				goto IL_001c;
				IL_0075:
				int num3;
				if (value)
				{
					num = 791005444;
					num3 = num;
				}
				else
				{
					num = 791005443;
					num3 = num;
				}
				goto IL_0021;
			}
		}

		public int playerId
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return -1;
				}
				return VUcYiZtcJRatratRXOokIFfcdNSg;
			}
			set
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					while (true)
					{
						switch (0x1EB84F8B ^ 0x1EB84F89)
						{
						case 3:
							break;
						case 2:
							return;
						case 1:
							goto end_IL_0019;
						default:
							goto IL_0054;
						}
						continue;
						end_IL_0019:
						break;
					}
				}
				if (VUcYiZtcJRatratRXOokIFfcdNSg == value)
				{
					return;
				}
				goto IL_0054;
				IL_0054:
				VUcYiZtcJRatratRXOokIFfcdNSg = value;
				ClearVars();
			}
		}

		public IList<Button> buttons
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return null;
				}
				return viYopkgjFozOPpuuwOXRrmFKiWf;
			}
		}

		public IList<Axis> axes
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return null;
				}
				return qUwOjuiiHRUnpVEQpCzDHwXUBGDm;
			}
		}

		public IList<Element> elements
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return null;
				}
				return DnCGAXuCydczsGMHdwaSQnTzKxR;
			}
		}

		public int buttonCount
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return 0;
				}
				if (WXIRxjkGHEWEQMEDrfdCKrevQRBu == null)
				{
					return 0;
				}
				return WXIRxjkGHEWEQMEDrfdCKrevQRBu._count;
			}
		}

		public int axisCount
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					goto IL_0019;
				}
				int num;
				if (qbVJMDgYpnJuvznLeFDMdGeZUGX == null)
				{
					num = 1897458351;
					goto IL_001e;
				}
				return qbVJMDgYpnJuvznLeFDMdGeZUGX._count;
				IL_0019:
				num = 1897458348;
				goto IL_001e;
				IL_001e:
				switch (num ^ 0x7118EAAE)
				{
				case 0:
					break;
				case 2:
					return 0;
				default:
					return 0;
				}
				goto IL_0019;
			}
		}

		public int elementCount
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return 0;
				}
				if (zGVdLCAPoSECGnwSmQQzpAttLxeB == null)
				{
					return 0;
				}
				return zGVdLCAPoSECGnwSmQQzpAttLxeB._count;
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
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					while (true)
					{
						switch (0x496A5945 ^ 0x496A5947)
						{
						case 0:
							continue;
						case 2:
							ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
							return;
						}
						break;
					}
				}
				zeGKZcOqKBGocSRKPdTtybVdnFX = (Action<int, bool>)Delegate.Combine(zeGKZcOqKBGocSRKPdTtybVdnFX, value);
			}
			remove
			{
				zeGKZcOqKBGocSRKPdTtybVdnFX = (Action<int, bool>)Delegate.Remove(zeGKZcOqKBGocSRKPdTtybVdnFX, value);
			}
		}

		public event Action<int, float> AxisValueChangedEvent
		{
			add
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					while (true)
					{
						switch (-2005936232 ^ -2005936230)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				UkJMZFbJhLdMvSjhIyryUeXaJfm = (Action<int, float>)Delegate.Combine(UkJMZFbJhLdMvSjhIyryUeXaJfm, value);
			}
			remove
			{
				UkJMZFbJhLdMvSjhIyryUeXaJfm = (Action<int, float>)Delegate.Remove(UkJMZFbJhLdMvSjhIyryUeXaJfm, value);
			}
		}

		public event Action<bool> EnabledStateChangedEvent
		{
			add
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				}
				else
				{
					keQiiwcvhFUxZCAVksrVOIIyXdA = (Action<bool>)Delegate.Combine(keQiiwcvhFUxZCAVksrVOIIyXdA, value);
				}
			}
			remove
			{
				keQiiwcvhFUxZCAVksrVOIIyXdA = (Action<bool>)Delegate.Remove(keQiiwcvhFUxZCAVksrVOIIyXdA, value);
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
			SsPwhbdijXONOlkRKHOkXryZrDq = ReInput._id;
			VUcYiZtcJRatratRXOokIFfcdNSg = definition.playerId;
			gmbIkkevNmPVGSTIwKcAwoPYANrc = definition.enabled;
			List<Element> list = new List<Element>();
			List<Element> list2 = new List<Element>();
			List<Button> list3 = new List<Button>();
			List<Axis> list4 = new List<Axis>();
			foreach (Element.Definition element in definition.elements)
			{
				DaOirHIMrqCgwPvMGCDKpJCcEFCO(element.CreateElement(this), list, list2, list3, list4);
			}
			list.AddRange(list2);
			zGVdLCAPoSECGnwSmQQzpAttLxeB = new AList<Element>(list);
			WXIRxjkGHEWEQMEDrfdCKrevQRBu = new AList<Button>(list3);
			qbVJMDgYpnJuvznLeFDMdGeZUGX = new AList<Axis>(list4);
			DnCGAXuCydczsGMHdwaSQnTzKxR = new ReadOnlyCollection<Element>(zGVdLCAPoSECGnwSmQQzpAttLxeB);
			viYopkgjFozOPpuuwOXRrmFKiWf = new ReadOnlyCollection<Button>(WXIRxjkGHEWEQMEDrfdCKrevQRBu);
			qUwOjuiiHRUnpVEQpCzDHwXUBGDm = new ReadOnlyCollection<Axis>(qbVJMDgYpnJuvznLeFDMdGeZUGX);
			NaCMZvhCmEGdXOylluQkjYbfaRk = new List<Element.rDFNfJQfqUvcOHJstNvfxVmjoeO>();
			ReInput.UpdateEndedEvent += VtisaHZOBdibbEhmThwWADtaHEQt;
		}

		~PlayerController()
		{
			ReInput.UpdateEndedEvent -= VtisaHZOBdibbEhmThwWADtaHEQt;
		}

		public bool GetButton(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			if ((uint)index >= (uint)WXIRxjkGHEWEQMEDrfdCKrevQRBu._count)
			{
				return false;
			}
			return WXIRxjkGHEWEQMEDrfdCKrevQRBu[index].value;
		}

		public bool GetButtonDown(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			if ((uint)index >= (uint)WXIRxjkGHEWEQMEDrfdCKrevQRBu._count)
			{
				return false;
			}
			return WXIRxjkGHEWEQMEDrfdCKrevQRBu[index].justPressed;
		}

		public bool GetButtonUp(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			if ((uint)index >= (uint)WXIRxjkGHEWEQMEDrfdCKrevQRBu._count)
			{
				return false;
			}
			return WXIRxjkGHEWEQMEDrfdCKrevQRBu[index].justReleased;
		}

		public float GetAxis(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			}
			if ((uint)index >= (uint)qbVJMDgYpnJuvznLeFDMdGeZUGX._count)
			{
				return 0f;
			}
			return qbVJMDgYpnJuvznLeFDMdGeZUGX[index].value;
		}

		public float GetAxisRaw(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			}
			if ((uint)index >= (uint)qbVJMDgYpnJuvznLeFDMdGeZUGX._count)
			{
				return 0f;
			}
			return qbVJMDgYpnJuvznLeFDMdGeZUGX[index].valueRaw;
		}

		public Element GetElement(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			int num;
			if ((uint)index >= (uint)qbVJMDgYpnJuvznLeFDMdGeZUGX._count)
			{
				num = 2050539680;
				goto IL_0012;
			}
			return zGVdLCAPoSECGnwSmQQzpAttLxeB[index];
			IL_000d:
			num = 2050539683;
			goto IL_0012;
			IL_0012:
			switch (num ^ 0x7A38C0A1)
			{
			case 0:
				break;
			case 2:
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return null;
			default:
				return null;
			}
			goto IL_000d;
		}

		public T GetElement<T>(int index) where T : Element
		{
			return GetElement(index) as T;
		}

		private void VtisaHZOBdibbEhmThwWADtaHEQt(UpdateLoopType P_0)
		{
			Update(P_0);
			UpdateFinished();
		}

		protected virtual bool Update(UpdateLoopType updateLoop)
		{
			if (!gmbIkkevNmPVGSTIwKcAwoPYANrc)
			{
				goto IL_000b;
			}
			bool flag = UkJMZFbJhLdMvSjhIyryUeXaJfm != null;
			bool flag2 = zeGKZcOqKBGocSRKPdTtybVdnFX != null;
			int num = 0;
			int num2 = 2033562906;
			goto IL_0010;
			IL_0010:
			Button button = default(Button);
			Axis axis = default(Axis);
			float num3 = default(float);
			while (true)
			{
				switch (num2 ^ 0x7935B519)
				{
				case 12:
					break;
				case 4:
					zGVdLCAPoSECGnwSmQQzpAttLxeB[num].Update();
					if (flag2 && zGVdLCAPoSECGnwSmQQzpAttLxeB[num] is Button)
					{
						button = zGVdLCAPoSECGnwSmQQzpAttLxeB[num] as Button;
						num2 = 2033562904;
						continue;
					}
					goto case 7;
				case 0:
					if (flag)
					{
						int num7;
						if (!(zGVdLCAPoSECGnwSmQQzpAttLxeB[num] is Axis))
						{
							num2 = 2033562909;
							num7 = num2;
						}
						else
						{
							num2 = 2033562896;
							num7 = num2;
						}
						continue;
					}
					goto case 4;
				case 14:
					num2 = 2033562897;
					continue;
				case 8:
					num++;
					num2 = 2033562906;
					continue;
				case 15:
					if (button.justReleased && !button.value)
					{
						NaCMZvhCmEGdXOylluQkjYbfaRk.Add(new Element.rDFNfJQfqUvcOHJstNvfxVmjoeO(ControllerElementType.Button, num, 0f));
						num2 = 2033562903;
						continue;
					}
					goto case 8;
				case 11:
					return false;
				case 1:
					if (button.justPressed)
					{
						int num6;
						if (!button.value)
						{
							num2 = 2033562902;
							num6 = num2;
						}
						else
						{
							num2 = 2033562907;
							num6 = num2;
						}
						continue;
					}
					goto case 15;
				case 13:
					if (axis.coordinateMode == AxisCoordinateMode.Absolute)
					{
						num3 = axis.value;
						num2 = 2033562909;
						continue;
					}
					goto case 6;
				case 2:
					NaCMZvhCmEGdXOylluQkjYbfaRk.Add(new Element.rDFNfJQfqUvcOHJstNvfxVmjoeO(ControllerElementType.Button, num, 1f));
					num2 = 2033562897;
					continue;
				case 3:
				{
					int num4;
					if (num >= zGVdLCAPoSECGnwSmQQzpAttLxeB._count)
					{
						num2 = 2033562889;
						num4 = num2;
					}
					else
					{
						num2 = 2033562908;
						num4 = num2;
					}
					continue;
				}
				case 9:
					axis = zGVdLCAPoSECGnwSmQQzpAttLxeB[num] as Axis;
					num2 = 2033562900;
					continue;
				case 5:
					num3 = 0f;
					num2 = 2033562905;
					continue;
				case 7:
					if (flag)
					{
						int num5;
						if (!(zGVdLCAPoSECGnwSmQQzpAttLxeB[num] is Axis))
						{
							num2 = 2033562897;
							num5 = num2;
						}
						else
						{
							num2 = 2033562899;
							num5 = num2;
						}
						continue;
					}
					goto case 8;
				case 10:
					NaCMZvhCmEGdXOylluQkjYbfaRk.Add(new Element.rDFNfJQfqUvcOHJstNvfxVmjoeO(ControllerElementType.Axis, num, (zGVdLCAPoSECGnwSmQQzpAttLxeB[num] as Axis).value - num3));
					num2 = 2033562897;
					continue;
				case 6:
					num3 = 0f;
					num2 = 2033562909;
					continue;
				default:
					return true;
				}
				break;
			}
			goto IL_000b;
			IL_000b:
			num2 = 2033562898;
			goto IL_0010;
		}

		protected virtual void UpdateFinished()
		{
			int count = NaCMZvhCmEGdXOylluQkjYbfaRk.Count;
			if (count <= 0)
			{
				return;
			}
			int num = 0;
			while (true)
			{
				IL_00ee:
				if (num < count)
				{
					Element.rDFNfJQfqUvcOHJstNvfxVmjoeO rDFNfJQfqUvcOHJstNvfxVmjoeO;
					while (true)
					{
						rDFNfJQfqUvcOHJstNvfxVmjoeO = NaCMZvhCmEGdXOylluQkjYbfaRk[num];
						int num2 = -428425317;
						while (true)
						{
							switch (num2 ^ -428425319)
							{
							case 0:
								num2 = -428425320;
								continue;
							case 1:
								break;
							default:
								goto end_IL_0038;
							}
							break;
						}
						continue;
						end_IL_0038:
						break;
					}
					if (rDFNfJQfqUvcOHJstNvfxVmjoeO.ERFGOjgLTTFXpgYjkdzhlHHCfvY == ControllerElementType.Button)
					{
						try
						{
							zeGKZcOqKBGocSRKPdTtybVdnFX(rDFNfJQfqUvcOHJstNvfxVmjoeO.VgtGZGVNuFqErLJXYsgetKqIFWC, (rDFNfJQfqUvcOHJstNvfxVmjoeO.kXoKOSZJMKwATOiGMaylYIDqdDnb > 0f) ? true : false);
						}
						catch (Exception ex)
						{
							Logger.LogError("An exception occurred in a listener of ButtonStateChangedEvent. This means an exception was thrown by your code.\n" + ex);
						}
					}
					else if (rDFNfJQfqUvcOHJstNvfxVmjoeO.ERFGOjgLTTFXpgYjkdzhlHHCfvY == ControllerElementType.Axis)
					{
						try
						{
							UkJMZFbJhLdMvSjhIyryUeXaJfm(rDFNfJQfqUvcOHJstNvfxVmjoeO.VgtGZGVNuFqErLJXYsgetKqIFWC, rDFNfJQfqUvcOHJstNvfxVmjoeO.kXoKOSZJMKwATOiGMaylYIDqdDnb);
						}
						catch (Exception ex2)
						{
							Logger.LogError("An exception occurred in a listener of AxisValueChangedEvent. This means an exception was thrown by your code.\n" + ex2);
						}
					}
					num++;
					goto IL_00cc;
				}
				int num3 = -428425318;
				goto IL_00d1;
				IL_00cc:
				num3 = -428425320;
				goto IL_00d1;
				IL_00d1:
				while (true)
				{
					switch (num3 ^ -428425319)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_00ee;
					case 3:
						NaCMZvhCmEGdXOylluQkjYbfaRk.Clear();
						num3 = -428425317;
						continue;
					case 2:
						return;
					}
					break;
				}
				goto IL_00cc;
			}
		}

		protected virtual void ClearVars()
		{
			NaCMZvhCmEGdXOylluQkjYbfaRk.Clear();
		}

		internal void DaOirHIMrqCgwPvMGCDKpJCcEFCO(Element P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				int num;
				if (P_0 is Axis)
				{
					qbVJMDgYpnJuvznLeFDMdGeZUGX.Add(P_0 as Axis);
					num = -1533569667;
					goto IL_0009;
				}
				goto IL_0047;
				IL_0009:
				while (true)
				{
					switch (num ^ -1533569666)
					{
					case 0:
						num = -1533569668;
						continue;
					case 2:
						break;
					case 1:
						goto IL_0047;
					default:
						goto end_IL_0026;
					}
					break;
				}
				continue;
				IL_0047:
				if (!(P_0 is Button))
				{
					break;
				}
				WXIRxjkGHEWEQMEDrfdCKrevQRBu.Add(P_0 as Button);
				num = -1533569667;
				goto IL_0009;
				continue;
				end_IL_0026:
				break;
			}
			zGVdLCAPoSECGnwSmQQzpAttLxeB.Add(P_0);
		}

		private void DaOirHIMrqCgwPvMGCDKpJCcEFCO(Element P_0, List<Element> P_1, List<Element> P_2, List<Button> P_3, List<Axis> P_4)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			goto IL_0059;
			IL_0003:
			int num = 935484086;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num ^ 0x37C25AB4)
				{
				case 6:
					break;
				case 4:
					Logger.LogWarning("Unknown Element type encountered: " + P_0.GetType());
					return;
				case 7:
					goto IL_0059;
				case 8:
					goto IL_0081;
				case 3:
					P_3.Add((Button)P_0);
					num = 935484084;
					continue;
				case 2:
					return;
				case 5:
					if (P_0 is Axis)
					{
						P_4.Add((Axis)P_0);
						num = 935484084;
						continue;
					}
					goto case 4;
				case 0:
					P_1.Add(P_0);
					return;
				default:
				{
					using (TempListPool.TList<Element> tList = TempListPool.GetTList<Element>())
					{
						List<Element> list = tList.list;
						(P_0 as CompoundElement).krZFeJLxsPeSuuwGTNErzcEZdSm(list);
						int num2 = 0;
						while (true)
						{
							IL_0107:
							int num3 = 935484085;
							while (true)
							{
								switch (num3 ^ 0x37C25AB4)
								{
								case 0:
									break;
								default:
									goto end_IL_010c;
								case 1:
									num3 = 935484087;
									continue;
								case 2:
									DaOirHIMrqCgwPvMGCDKpJCcEFCO(list[num2], P_1, P_2, P_3, P_4);
									num2++;
									num3 = 935484087;
									continue;
								case 3:
								{
									int num4;
									if (num2 >= list.Count)
									{
										num3 = 935484080;
										num4 = num3;
									}
									else
									{
										num3 = 935484086;
										num4 = num3;
									}
									continue;
								}
								case 4:
									goto end_IL_010c;
								}
								goto IL_0107;
								continue;
								end_IL_010c:
								break;
							}
							break;
						}
					}
					P_2.Add(P_0);
					return;
				}
				}
				break;
			}
			goto IL_0003;
			IL_0059:
			P_0.GetType();
			if (P_0 is ElementWithSource)
			{
				int num5;
				if (!(P_0 is Button))
				{
					num = 935484081;
					num5 = num;
				}
				else
				{
					num = 935484087;
					num5 = num;
				}
				goto IL_0008;
			}
			goto IL_0081;
			IL_0081:
			if (P_0 is CompoundElement)
			{
				num = 935484085;
				goto IL_0008;
			}
			Logger.LogWarning("Unknown Element type encountered: " + P_0.GetType());
		}

		internal static int NhwuMsaBZhNRgrlbmGtKvnkDBwq<T>(IList<T> P_0, Predicate<T> P_1, int P_2) where T : Element
		{
			int num = 0;
			int num2 = 0;
			while (true)
			{
				int num3 = 887914463;
				while (true)
				{
					switch (num3 ^ 0x34EC7FDD)
					{
					case 0:
						break;
					case 2:
						num3 = 887914460;
						continue;
					case 3:
						if (P_1(P_0[num2]))
						{
							num++;
							num3 = 887914457;
							continue;
						}
						goto case 4;
					case 4:
						if (num == P_2)
						{
							return num2;
						}
						num2++;
						num3 = 887914460;
						continue;
					default:
						if (num2 >= P_0.Count)
						{
							return -1;
						}
						goto case 3;
					}
					break;
				}
			}
		}
	}
}
