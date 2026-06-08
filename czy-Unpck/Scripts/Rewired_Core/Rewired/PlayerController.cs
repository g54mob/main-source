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

				internal abstract Element czintdxcTJLElcenMIOuHtsaRzTe(PlayerController P_0);
			}

			internal struct WKJXkUuaWGgwNdigkGgsbfrFurzH
			{
				public ControllerElementType vsNzKyIocFQEgFvIpUOofhdTyKf;

				public int aCtihPxuRFLiowUoZPQdxLYTTal;

				public float ZTonADnXjOPnKfCdZaXyKwbxjUQ;

				public WKJXkUuaWGgwNdigkGgsbfrFurzH(ControllerElementType elementType, int index, float value)
				{
					vsNzKyIocFQEgFvIpUOofhdTyKf = elementType;
					aCtihPxuRFLiowUoZPQdxLYTTal = index;
					ZTonADnXjOPnKfCdZaXyKwbxjUQ = value;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const bool defaultEnabled = true;

			private readonly PlayerController ZcHJtpUHuctAcnqSflrxCAOupGj;

			private bool oFxhsYUCSYXtUWvNkgyaUYwheKu;

			private bool FnzJwrQpikWfZbmfjZhFwutJGAA = true;

			private string SQlNTEPvaCuPzRHxRVAmonHCzna;

			private static int[] RRDCdhfuyoOZFwOfDfFuiyrPrvgJ;

			private static int[] REVeGMDFOngwwUqlqmBsWCujLgPP;

			protected Player player
			{
				get
				{
					if (!ReInput.isReady)
					{
						return null;
					}
					return ReInput.players.GetPlayer(ZcHJtpUHuctAcnqSflrxCAOupGj.cNcLkMBaCDcdcMeoQVAxVFVuHEv);
				}
			}

			protected bool selfAndParentEnabled
			{
				get
				{
					if (FnzJwrQpikWfZbmfjZhFwutJGAA)
					{
						return ZcHJtpUHuctAcnqSflrxCAOupGj.FnzJwrQpikWfZbmfjZhFwutJGAA;
					}
					return false;
				}
			}

			internal bool isMemberElement
			{
				get
				{
					return oFxhsYUCSYXtUWvNkgyaUYwheKu;
				}
				set
				{
					oFxhsYUCSYXtUWvNkgyaUYwheKu = true;
				}
			}

			public bool enabled
			{
				get
				{
					return FnzJwrQpikWfZbmfjZhFwutJGAA;
				}
				set
				{
					if (FnzJwrQpikWfZbmfjZhFwutJGAA == value)
					{
						goto IL_0009;
					}
					goto IL_0033;
					IL_0009:
					int num = -315176807;
					goto IL_000e;
					IL_000e:
					switch (num ^ -315176808)
					{
					case 3:
						break;
					default:
						return;
					case 1:
						return;
					case 2:
						goto IL_0033;
					case 0:
						return;
					}
					goto IL_0009;
					IL_0033:
					FnzJwrQpikWfZbmfjZhFwutJGAA = value;
					EnabledStateChanged(value);
					num = -315176808;
					goto IL_000e;
				}
			}

			public string name
			{
				get
				{
					return SQlNTEPvaCuPzRHxRVAmonHCzna;
				}
				set
				{
					SQlNTEPvaCuPzRHxRVAmonHCzna = value;
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
				ZcHJtpUHuctAcnqSflrxCAOupGj = parent;
				FnzJwrQpikWfZbmfjZhFwutJGAA = definition.enabled;
			}

			internal virtual void GzCliicOSMFLMvKajLgvnmGSSrh()
			{
			}

			protected virtual void EnabledStateChanged(bool state)
			{
			}

			[CustomObfuscation(rename = false)]
			internal static bool IsTypeWithSource(Type type)
			{
				if (RRDCdhfuyoOZFwOfDfFuiyrPrvgJ == null)
				{
					RRDCdhfuyoOZFwOfDfFuiyrPrvgJ = (int[])Enum.GetValues(typeof(TypeWithSource));
				}
				return ArrayTools.Contains(RRDCdhfuyoOZFwOfDfFuiyrPrvgJ, (int)type);
			}

			[CustomObfuscation(rename = false)]
			internal static bool IsCompoundType(Type type)
			{
				if (REVeGMDFOngwwUqlqmBsWCujLgPP == null)
				{
					REVeGMDFOngwwUqlqmBsWCujLgPP = (int[])Enum.GetValues(typeof(CompoundTypes));
				}
				return ArrayTools.Contains(REVeGMDFOngwwUqlqmBsWCujLgPP, (int)type);
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
						switch (0x42A4A44B ^ 0x42A4A44A)
						{
						case 3:
							continue;
						case 1:
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
							goto case 0;
						case 0:
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
					goto IL_0037;
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
					num = 85198349;
					goto IL_0012;
				}
				goto IL_0098;
				IL_0012:
				while (true)
				{
					switch (num ^ 0x5140608)
					{
					case 0:
						break;
					case 2:
						goto IL_0037;
					case 4:
						return "Y Axis";
					case 1:
						goto IL_006d;
					case 5:
						switch (type2)
						{
						default:
							throw new NotImplementedException();
						case Type.Axis2D:
						case Type.MouseAxis2D:
						case Type.MouseWheel:
							break;
						}
						goto IL_006d;
					default:
						goto IL_0098;
					}
					break;
					IL_006d:
					if (index == 0)
					{
						return "X Axis";
					}
					num = 85198348;
				}
				goto IL_000d;
				IL_000d:
				num = 85198346;
				goto IL_0012;
				IL_0037:
				return null;
				IL_0098:
				throw new NotImplementedException();
			}

			[CustomObfuscation(rename = false)]
			internal static Definition CreateDefinition(Type type)
			{
				while (true)
				{
					switch (0x1D8869B ^ 0x1D8869A)
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
				private int qxoYaUQyNIsvDIFklnqXHPrHJLd;

				public int actionId
				{
					get
					{
						return qxoYaUQyNIsvDIFklnqXHPrHJLd;
					}
					set
					{
						qxoYaUQyNIsvDIFklnqXHPrHJLd = value;
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
							if (qxoYaUQyNIsvDIFklnqXHPrHJLd < 0)
							{
								goto IL_0010;
							}
							action = ReInput.mapping.GetAction(qxoYaUQyNIsvDIFklnqXHPrHJLd);
							num = -1503223561;
							goto IL_0015;
						}
						goto IL_002e;
						IL_002e:
						return null;
						IL_0048:
						return action?.name;
						IL_0010:
						num = -1503223564;
						goto IL_0015;
						IL_0015:
						switch (num ^ -1503223563)
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
							Logger.LogError("You cannot set an Action Name because Rewired has not been intialized.");
							return;
						}
						InputAction action = ReInput.mapping.GetAction(value);
						if (action == null)
						{
							qxoYaUQyNIsvDIFklnqXHPrHJLd = -1;
						}
						else
						{
							qxoYaUQyNIsvDIFklnqXHPrHJLd = action.id;
						}
					}
				}

				public Definition()
				{
					qxoYaUQyNIsvDIFklnqXHPrHJLd = -1;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const int defaultActionId = -1;

			private int qxoYaUQyNIsvDIFklnqXHPrHJLd = -1;

			public int actionId
			{
				get
				{
					return qxoYaUQyNIsvDIFklnqXHPrHJLd;
				}
				set
				{
					qxoYaUQyNIsvDIFklnqXHPrHJLd = value;
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
						if (qxoYaUQyNIsvDIFklnqXHPrHJLd < 0)
						{
							goto IL_0010;
						}
						action = ReInput.mapping.GetAction(qxoYaUQyNIsvDIFklnqXHPrHJLd);
						num = 1179160181;
						goto IL_0015;
					}
					goto IL_002e;
					IL_002e:
					return null;
					IL_0048:
					return action?.name;
					IL_0010:
					num = 1179160182;
					goto IL_0015;
					IL_0015:
					switch (num ^ 0x46488E77)
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
						if (action == null)
						{
							break;
						}
						while (true)
						{
							IL_0048:
							qxoYaUQyNIsvDIFklnqXHPrHJLd = action.id;
							int num = -1829560365;
							while (true)
							{
								switch (num ^ -1829560365)
								{
								case 2:
									num = -1829560366;
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
					qxoYaUQyNIsvDIFklnqXHPrHJLd = -1;
				}
			}

			internal ElementWithSource(PlayerController parent, Definition definition)
				: base(parent, definition)
			{
				qxoYaUQyNIsvDIFklnqXHPrHJLd = definition.actionId;
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

				internal override Element czintdxcTJLElcenMIOuHtsaRzTe(PlayerController P_0)
				{
					return new Axis(P_0, this);
				}
			}

			internal const float OEDUEntdnVilSAaMyTkwgBGlPEYa = 1f;

			[CustomObfuscation(rename = false)]
			internal const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Absolute;

			private float RVufmlMCrIQfyNHkaqDsFHBDqyV = 1f;

			private AxisCoordinateMode pBtzuQYwcCmhfMnyagwgINDCIXr;

			public float absoluteToRelativeSensitivity
			{
				get
				{
					return RVufmlMCrIQfyNHkaqDsFHBDqyV;
				}
				set
				{
					if (value < 0f)
					{
						while (true)
						{
							int num = 1104782814;
							while (true)
							{
								switch (num ^ 0x41D9A5DF)
								{
								case 0:
									break;
								case 1:
									value = 0f;
									num = 1104782813;
									continue;
								default:
									goto end_IL_0008;
								}
								break;
							}
							continue;
							end_IL_0008:
							break;
						}
					}
					RVufmlMCrIQfyNHkaqDsFHBDqyV = value;
				}
			}

			public AxisCoordinateMode coordinateMode => pBtzuQYwcCmhfMnyagwgINDCIXr;

			public virtual float value
			{
				get
				{
					float num = default(float);
					AxisCoordinateMode axisCoordinateMode = default(AxisCoordinateMode);
					int num2;
					if (base.selfAndParentEnabled)
					{
						if (base.player == null)
						{
							goto IL_0010;
						}
						num = base.player.GetAxis(base.actionId);
						axisCoordinateMode = base.player.GetAxisCoordinateMode(base.actionId);
						num2 = 1890600400;
						goto IL_0015;
					}
					goto IL_007b;
					IL_0015:
					while (true)
					{
						switch (num2 ^ 0x70B045D1)
						{
						case 0:
							break;
						case 3:
							goto IL_0036;
						case 1:
							goto IL_0064;
						case 4:
							goto IL_007b;
						default:
							goto IL_00af;
						}
						break;
						IL_0064:
						switch (axisCoordinateMode)
						{
						case AxisCoordinateMode.Relative:
							break;
						case AxisCoordinateMode.Absolute:
							goto IL_0044;
						default:
							goto IL_0074;
						}
						goto IL_0036;
						IL_0074:
						num2 = 1890600403;
						continue;
						IL_0044:
						if (pBtzuQYwcCmhfMnyagwgINDCIXr == AxisCoordinateMode.Relative)
						{
							num *= (float)ReInput.unscaledDeltaTime * RVufmlMCrIQfyNHkaqDsFHBDqyV;
							num2 = 1890600403;
							continue;
						}
						goto IL_00af;
						IL_00af:
						return num;
						IL_0036:
						if (pBtzuQYwcCmhfMnyagwgINDCIXr == AxisCoordinateMode.Absolute)
						{
							return 0f;
						}
						goto IL_00af;
					}
					goto IL_0010;
					IL_007b:
					return 0f;
					IL_0010:
					num2 = 1890600405;
					goto IL_0015;
				}
			}

			public virtual float valueRaw
			{
				get
				{
					if (base.selfAndParentEnabled)
					{
						while (true)
						{
							int num = -1045831889;
							while (true)
							{
								switch (num ^ -1045831890)
								{
								case 2:
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
									num = -1045831890;
									continue;
								}
								return base.player.GetAxisRaw(base.actionId);
							}
							continue;
							end_IL_0008:
							break;
						}
					}
					return 0f;
				}
			}

			internal Axis(PlayerController parent, Definition definition)
				: base(parent, definition)
			{
				RVufmlMCrIQfyNHkaqDsFHBDqyV = definition.absoluteToRelativeSensitivity;
				pBtzuQYwcCmhfMnyagwgINDCIXr = definition.coordinateMode;
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

				internal override Element czintdxcTJLElcenMIOuHtsaRzTe(PlayerController P_0)
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

			private readonly List<Element> OZXcSZtVrQPQPLpKldDeETdguIN;

			internal int elementCount => OZXcSZtVrQPQPLpKldDeETdguIN.Count;

			internal CompoundElement(PlayerController parent, Definition definition, Element.Definition[] elementDefinitions)
				: base(parent, definition)
			{
				OZXcSZtVrQPQPLpKldDeETdguIN = new List<Element>();
				if (elementDefinitions == null)
				{
					return;
				}
				for (int i = 0; i < elementDefinitions.Length; i++)
				{
					if (elementDefinitions[i] != null)
					{
						itKYLEidIwjerGGrDGqPNskdaYz(elementDefinitions[i].czintdxcTJLElcenMIOuHtsaRzTe(parent));
					}
				}
			}

			internal T WPeqKlrsUlCkyNVaxZHjSbqAJOj<T>(int P_0) where T : Element
			{
				T result = default(T);
				if ((uint)P_0 >= (uint)OZXcSZtVrQPQPLpKldDeETdguIN.Count)
				{
					while (true)
					{
						int num = -391124589;
						while (true)
						{
							switch (num ^ -391124590)
							{
							case 0:
								break;
							case 1:
								goto IL_002c;
							default:
								return result;
							}
							break;
							IL_002c:
							result = null;
							num = -391124592;
						}
					}
				}
				return OZXcSZtVrQPQPLpKldDeETdguIN[P_0] as T;
			}

			internal void XMVXbEvPDLjXpNgpYeCenjeIKHJ(List<Element> P_0)
			{
				int num = 0;
				while (num < OZXcSZtVrQPQPLpKldDeETdguIN.Count)
				{
					while (true)
					{
						int num2;
						int num3;
						if (!(OZXcSZtVrQPQPLpKldDeETdguIN[num] is CompoundElement))
						{
							num2 = 610786442;
							num3 = num2;
						}
						else
						{
							num2 = 610786443;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x2467DC89)
							{
							case 5:
								num2 = 610786445;
								continue;
							case 4:
								break;
							case 1:
								num++;
								num2 = 610786441;
								continue;
							case 3:
								P_0.Add(OZXcSZtVrQPQPLpKldDeETdguIN[num]);
								num2 = 610786440;
								continue;
							case 2:
								(OZXcSZtVrQPQPLpKldDeETdguIN[num] as CompoundElement).XMVXbEvPDLjXpNgpYeCenjeIKHJ(P_0);
								num2 = 610786440;
								continue;
							default:
								goto end_IL_0031;
							}
							break;
						}
						continue;
						end_IL_0031:
						break;
					}
				}
			}

			internal void itKYLEidIwjerGGrDGqPNskdaYz(Element P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("element");
				}
				while (true)
				{
					OZXcSZtVrQPQPLpKldDeETdguIN.Add(P_0);
					int num = 552435838;
					while (true)
					{
						switch (num ^ 0x20ED807C)
						{
						case 0:
							goto IL_000e;
						case 1:
							break;
						default:
							P_0.isMemberElement = true;
							return;
						}
						break;
						IL_000e:
						num = 552435837;
					}
				}
			}
		}

		public class Axis2D : CompoundElement
		{
			public new class Definition : CompoundElement.Definition
			{
				private Axis.Definition FBpmSvZWqcdNuTyiejxnDAumAqm;

				private Axis.Definition XZymEQImwxktLvEptKTxwwuNuPn;

				public Axis.Definition xAxis
				{
					get
					{
						return FBpmSvZWqcdNuTyiejxnDAumAqm;
					}
					set
					{
						FBpmSvZWqcdNuTyiejxnDAumAqm = value;
					}
				}

				public Axis.Definition yAxis
				{
					get
					{
						return XZymEQImwxktLvEptKTxwwuNuPn;
					}
					set
					{
						XZymEQImwxktLvEptKTxwwuNuPn = value;
					}
				}

				internal override Element czintdxcTJLElcenMIOuHtsaRzTe(PlayerController P_0)
				{
					return new Axis2D(P_0, this);
				}
			}

			internal const int fgUyRgeQiwNUhyKqmEaAeTxYqOi = 0;

			internal const int zVXcajPjrDouUkdkWcPajgqcjoiA = 1;

			internal const int tLsKnAXvImIVKuRqTUPZFuoHpvS = 2;

			public Axis xAxis => WPeqKlrsUlCkyNVaxZHjSbqAJOj<Axis>(0);

			public Axis yAxis => WPeqKlrsUlCkyNVaxZHjSbqAJOj<Axis>(1);

			public virtual Vector2 value => new Vector2(WPeqKlrsUlCkyNVaxZHjSbqAJOj<Axis>(0).value, WPeqKlrsUlCkyNVaxZHjSbqAJOj<Axis>(1).value);

			public virtual Vector2 valueRaw => new Vector2(WPeqKlrsUlCkyNVaxZHjSbqAJOj<Axis>(0).valueRaw, WPeqKlrsUlCkyNVaxZHjSbqAJOj<Axis>(1).valueRaw);

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

				internal override Element czintdxcTJLElcenMIOuHtsaRzTe(PlayerController P_0)
				{
					return new MouseAxis2D(P_0, this);
				}
			}

			public new MouseAxis xAxis => WPeqKlrsUlCkyNVaxZHjSbqAJOj<MouseAxis>(0);

			public new MouseAxis yAxis => WPeqKlrsUlCkyNVaxZHjSbqAJOj<MouseAxis>(1);

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
				internal override Element czintdxcTJLElcenMIOuHtsaRzTe(PlayerController P_0)
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
					if (base.selfAndParentEnabled)
					{
						while (true)
						{
							int num = 454756798;
							while (true)
							{
								switch (num ^ 0x1B1B09BF)
								{
								case 2:
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
									num = 454756799;
									continue;
								}
								return base.player.GetButtonPrev(base.actionId);
							}
							continue;
							end_IL_0008:
							break;
						}
					}
					return false;
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
							int num = 1382301231;
							while (true)
							{
								switch (num ^ 0x52643E2E)
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
									num = 1382301228;
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

				internal override Element czintdxcTJLElcenMIOuHtsaRzTe(PlayerController P_0)
				{
					return new MouseWheel(P_0, this);
				}
			}

			public new MouseWheelAxis xAxis => WPeqKlrsUlCkyNVaxZHjSbqAJOj<MouseWheelAxis>(0);

			public new MouseWheelAxis yAxis => WPeqKlrsUlCkyNVaxZHjSbqAJOj<MouseWheelAxis>(1);

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

				internal override Element czintdxcTJLElcenMIOuHtsaRzTe(PlayerController P_0)
				{
					return new MouseWheelAxis(P_0, this);
				}
			}

			[CustomObfuscation(rename = false)]
			internal const float defaultRepeatRate = 4f;

			[CustomObfuscation(rename = false)]
			internal new const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Relative;

			private const float NZDkEWDBsuvcWqDATgcBfqPKIfxw = 0.01f;

			private float zDEhRsKCMxDZHwiBJnPUCHtOyfFU = 0.25f;

			private double TNnKdbIngVhoPCgVWUIMvlyWrlYa;

			private float HewmgBxnlqheeaCyBbxCmITSoEAX;

			public float repeatRate
			{
				get
				{
					if (zDEhRsKCMxDZHwiBJnPUCHtOyfFU == 0f)
					{
						return 0f;
					}
					return 1f / zDEhRsKCMxDZHwiBJnPUCHtOyfFU;
				}
				set
				{
					if (value < 0f)
					{
						value = 0f;
						goto IL_000f;
					}
					goto IL_0031;
					IL_004c:
					zDEhRsKCMxDZHwiBJnPUCHtOyfFU = 1f / value;
					int num = -719800725;
					goto IL_0014;
					IL_000f:
					num = -719800727;
					goto IL_0014;
					IL_0014:
					switch (num ^ -719800728)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_0031;
					case 2:
						goto IL_004c;
					case 3:
						return;
					}
					goto IL_000f;
					IL_0031:
					if (value == 0f)
					{
						zDEhRsKCMxDZHwiBJnPUCHtOyfFU = 0f;
						return;
					}
					goto IL_004c;
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
					return HewmgBxnlqheeaCyBbxCmITSoEAX;
				}
			}

			internal MouseWheelAxis(PlayerController parent, Definition definition)
				: base(parent, definition)
			{
				repeatRate = definition.repeatRate;
			}

			internal override void GzCliicOSMFLMvKajLgvnmGSSrh()
			{
				base.GzCliicOSMFLMvKajLgvnmGSSrh();
				if (!base.selfAndParentEnabled)
				{
					while (true)
					{
						switch (0x4019522E ^ 0x4019522F)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				HewmgBxnlqheeaCyBbxCmITSoEAX = ZGtBWfcQMbapuZPHRDvCeufDioFo();
			}

			protected override void EnabledStateChanged(bool state)
			{
				base.EnabledStateChanged(state);
				if (!state)
				{
					tAgADqjTsMUxSqYXeDyJIdETYRAp();
				}
			}

			private float ZGtBWfcQMbapuZPHRDvCeufDioFo()
			{
				if (base.player == null)
				{
					goto IL_000b;
				}
				float num = base.player.GetAxis(base.actionId);
				int num2 = -80061256;
				goto IL_0010;
				IL_0010:
				bool flag = default(bool);
				AxisCoordinateMode axisCoordinateMode = default(AxisCoordinateMode);
				while (true)
				{
					switch (num2 ^ -80061262)
					{
					case 4:
						break;
					case 6:
						if (!flag && ReInput.unscaledTime < TNnKdbIngVhoPCgVWUIMvlyWrlYa + (double)zDEhRsKCMxDZHwiBJnPUCHtOyfFU)
						{
							return 0f;
						}
						if (Mathf.Abs(num) <= 0.01f)
						{
							num2 = -80061261;
							continue;
						}
						num = Mathf.Sign(num);
						num *= base.absoluteToRelativeSensitivity;
						num2 = -80061254;
						continue;
					case 10:
						axisCoordinateMode = base.player.GetAxisCoordinateMode(base.actionId);
						num2 = -80061263;
						continue;
					case 2:
						flag = false;
						if (base.player.GetButtonDown(base.actionId))
						{
							flag = true;
							num = 1f;
							num2 = -80061260;
							continue;
						}
						goto case 0;
					case 3:
						switch (axisCoordinateMode)
						{
						case AxisCoordinateMode.Absolute:
							break;
						default:
							goto IL_00d1;
						case AxisCoordinateMode.Relative:
							goto IL_0164;
						}
						goto case 2;
					case 1:
						return 0f;
					case 5:
						num = -1f;
						num2 = -80061260;
						continue;
					case 0:
						if (base.player.GetNegativeButtonDown(base.actionId))
						{
							flag = true;
							num2 = -80061257;
							continue;
						}
						goto case 6;
					case 9:
						return 0f;
					case 8:
						TNnKdbIngVhoPCgVWUIMvlyWrlYa = ReInput.unscaledTime;
						num2 = -80061259;
						continue;
					default:
						goto IL_0164;
						IL_0164:
						return num;
						IL_00d1:
						num2 = -80061259;
						continue;
					}
					break;
				}
				goto IL_000b;
				IL_000b:
				num2 = -80061253;
				goto IL_0010;
			}

			private void tAgADqjTsMUxSqYXeDyJIdETYRAp()
			{
				HewmgBxnlqheeaCyBbxCmITSoEAX = 0f;
				TNnKdbIngVhoPCgVWUIMvlyWrlYa = 0.0;
			}
		}

		internal readonly int vuPDNwATQFuTZgAqTRoviXUGAgFM;

		private bool FnzJwrQpikWfZbmfjZhFwutJGAA;

		private int cNcLkMBaCDcdcMeoQVAxVFVuHEv;

		private readonly AList<Element> OZXcSZtVrQPQPLpKldDeETdguIN;

		private readonly AList<Button> duQdUwWCoAwHNtdgoIMHHlMkZKgA;

		private readonly AList<Axis> PdPvqHQYrfTEtGcYrKwAnNuIEVr;

		private readonly ReadOnlyCollection<Element> mpWcvIBYZzhvfGlpsJRRLOVkPPkn;

		private readonly ReadOnlyCollection<Button> WjYYSvUAasAXIMCTfymAbybBbLC;

		private readonly ReadOnlyCollection<Axis> LQyAGvAhoRvyiuQpeuKKwdxPVXu;

		private readonly List<Element.WKJXkUuaWGgwNdigkGgsbfrFurzH> obEiQkTIFAgaQthAiHzprSBuFMTa;

		private Action<int, bool> WiQkrnglrRfNhtRfAbCuwHxgPeo;

		private Action<int, float> xlRkoINFONdZuzJATOAlCCxxQiF;

		private Action<bool> ViElVhCmKJNZGzfohfDCJGshGWjB;

		public bool enabled
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return false;
				}
				return FnzJwrQpikWfZbmfjZhFwutJGAA;
			}
			set
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					goto IL_0019;
				}
				goto IL_0078;
				IL_0078:
				int num;
				int num2;
				if (FnzJwrQpikWfZbmfjZhFwutJGAA != value)
				{
					num = 1101822917;
					num2 = num;
				}
				else
				{
					num = 1101822918;
					num2 = num;
				}
				goto IL_001e;
				IL_0019:
				num = 1101822921;
				goto IL_001e;
				IL_001e:
				int num3 = default(int);
				while (true)
				{
					switch (num ^ 0x41AC7BC1)
					{
					case 2:
						break;
					case 8:
						return;
					case 3:
						OZXcSZtVrQPQPLpKldDeETdguIN[num3].enabled = value;
						num = 1101822919;
						continue;
					case 7:
						return;
					case 0:
						goto IL_0078;
					case 6:
						num3++;
						num = 1101822912;
						continue;
					case 4:
						if (!value)
						{
							ClearVars();
							num = 1101822916;
							continue;
						}
						goto case 5;
					case 5:
						FnzJwrQpikWfZbmfjZhFwutJGAA = value;
						num3 = 0;
						num = 1101822912;
						continue;
					default:
						if (num3 >= OZXcSZtVrQPQPLpKldDeETdguIN._count)
						{
							if (ViElVhCmKJNZGzfohfDCJGshGWjB != null)
							{
								try
								{
									ViElVhCmKJNZGzfohfDCJGshGWjB(value);
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
						goto case 3;
					}
					break;
				}
				goto IL_0019;
			}
		}

		public int playerId
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return -1;
				}
				return cNcLkMBaCDcdcMeoQVAxVFVuHEv;
			}
			set
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					while (true)
					{
						switch (0xC465A81 ^ 0xC465A83)
						{
						case 0:
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
				if (cNcLkMBaCDcdcMeoQVAxVFVuHEv == value)
				{
					return;
				}
				goto IL_0054;
				IL_0054:
				cNcLkMBaCDcdcMeoQVAxVFVuHEv = value;
				ClearVars();
			}
		}

		public IList<Button> buttons
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return null;
				}
				return WjYYSvUAasAXIMCTfymAbybBbLC;
			}
		}

		public IList<Axis> axes
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return null;
				}
				return LQyAGvAhoRvyiuQpeuKKwdxPVXu;
			}
		}

		public IList<Element> elements
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return null;
				}
				return mpWcvIBYZzhvfGlpsJRRLOVkPPkn;
			}
		}

		public int buttonCount
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return 0;
				}
				if (duQdUwWCoAwHNtdgoIMHHlMkZKgA == null)
				{
					return 0;
				}
				return duQdUwWCoAwHNtdgoIMHHlMkZKgA._count;
			}
		}

		public int axisCount
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return 0;
				}
				if (PdPvqHQYrfTEtGcYrKwAnNuIEVr == null)
				{
					return 0;
				}
				return PdPvqHQYrfTEtGcYrKwAnNuIEVr._count;
			}
		}

		public int elementCount
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return 0;
				}
				if (OZXcSZtVrQPQPLpKldDeETdguIN == null)
				{
					return 0;
				}
				return OZXcSZtVrQPQPLpKldDeETdguIN._count;
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
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					goto IL_000d;
				}
				goto IL_0043;
				IL_000d:
				int num = -1242274531;
				goto IL_0012;
				IL_0012:
				switch (num ^ -1242274532)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return;
				case 3:
					goto IL_0043;
				case 2:
					return;
				}
				goto IL_000d;
				IL_0043:
				WiQkrnglrRfNhtRfAbCuwHxgPeo = (Action<int, bool>)Delegate.Combine(WiQkrnglrRfNhtRfAbCuwHxgPeo, value);
				num = -1242274530;
				goto IL_0012;
			}
			remove
			{
				WiQkrnglrRfNhtRfAbCuwHxgPeo = (Action<int, bool>)Delegate.Remove(WiQkrnglrRfNhtRfAbCuwHxgPeo, value);
			}
		}

		public event Action<int, float> AxisValueChangedEvent
		{
			add
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					goto IL_000d;
				}
				goto IL_0046;
				IL_000d:
				int num = 368353826;
				goto IL_0012;
				IL_0012:
				while (true)
				{
					switch (num ^ 0x15F4A226)
					{
					case 0:
						break;
					default:
						return;
					case 4:
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						num = 368353828;
						continue;
					case 3:
						goto IL_0046;
					case 2:
						return;
					case 1:
						return;
					}
					break;
				}
				goto IL_000d;
				IL_0046:
				xlRkoINFONdZuzJATOAlCCxxQiF = (Action<int, float>)Delegate.Combine(xlRkoINFONdZuzJATOAlCCxxQiF, value);
				num = 368353831;
				goto IL_0012;
			}
			remove
			{
				xlRkoINFONdZuzJATOAlCCxxQiF = (Action<int, float>)Delegate.Remove(xlRkoINFONdZuzJATOAlCCxxQiF, value);
			}
		}

		public event Action<bool> EnabledStateChangedEvent
		{
			add
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				}
				else
				{
					ViElVhCmKJNZGzfohfDCJGshGWjB = (Action<bool>)Delegate.Combine(ViElVhCmKJNZGzfohfDCJGshGWjB, value);
				}
			}
			remove
			{
				ViElVhCmKJNZGzfohfDCJGshGWjB = (Action<bool>)Delegate.Remove(ViElVhCmKJNZGzfohfDCJGshGWjB, value);
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
			vuPDNwATQFuTZgAqTRoviXUGAgFM = ReInput._id;
			cNcLkMBaCDcdcMeoQVAxVFVuHEv = definition.playerId;
			FnzJwrQpikWfZbmfjZhFwutJGAA = definition.enabled;
			List<Element> list = new List<Element>();
			List<Element> list2 = new List<Element>();
			List<Button> list3 = new List<Button>();
			List<Axis> list4 = new List<Axis>();
			foreach (Element.Definition element in definition.elements)
			{
				itKYLEidIwjerGGrDGqPNskdaYz(element.czintdxcTJLElcenMIOuHtsaRzTe(this), list, list2, list3, list4);
			}
			list.AddRange(list2);
			OZXcSZtVrQPQPLpKldDeETdguIN = new AList<Element>(list);
			duQdUwWCoAwHNtdgoIMHHlMkZKgA = new AList<Button>(list3);
			PdPvqHQYrfTEtGcYrKwAnNuIEVr = new AList<Axis>(list4);
			mpWcvIBYZzhvfGlpsJRRLOVkPPkn = new ReadOnlyCollection<Element>(OZXcSZtVrQPQPLpKldDeETdguIN);
			WjYYSvUAasAXIMCTfymAbybBbLC = new ReadOnlyCollection<Button>(duQdUwWCoAwHNtdgoIMHHlMkZKgA);
			LQyAGvAhoRvyiuQpeuKKwdxPVXu = new ReadOnlyCollection<Axis>(PdPvqHQYrfTEtGcYrKwAnNuIEVr);
			obEiQkTIFAgaQthAiHzprSBuFMTa = new List<Element.WKJXkUuaWGgwNdigkGgsbfrFurzH>();
			ReInput.UpdateEndedEvent += spiCZIbBixHwkYmPEBFXAXTGsXtO;
		}

		~PlayerController()
		{
			ReInput.UpdateEndedEvent -= spiCZIbBixHwkYmPEBFXAXTGsXtO;
		}

		public bool GetButton(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			if ((uint)index >= (uint)duQdUwWCoAwHNtdgoIMHHlMkZKgA._count)
			{
				return false;
			}
			return duQdUwWCoAwHNtdgoIMHHlMkZKgA[index].value;
		}

		public bool GetButtonDown(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			if ((uint)index >= (uint)duQdUwWCoAwHNtdgoIMHHlMkZKgA._count)
			{
				return false;
			}
			return duQdUwWCoAwHNtdgoIMHHlMkZKgA[index].justPressed;
		}

		public bool GetButtonUp(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			if ((uint)index >= (uint)duQdUwWCoAwHNtdgoIMHHlMkZKgA._count)
			{
				return false;
			}
			return duQdUwWCoAwHNtdgoIMHHlMkZKgA[index].justReleased;
		}

		public float GetAxis(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0f;
			}
			if ((uint)index >= (uint)PdPvqHQYrfTEtGcYrKwAnNuIEVr._count)
			{
				return 0f;
			}
			return PdPvqHQYrfTEtGcYrKwAnNuIEVr[index].value;
		}

		public float GetAxisRaw(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0f;
			}
			if ((uint)index >= (uint)PdPvqHQYrfTEtGcYrKwAnNuIEVr._count)
			{
				return 0f;
			}
			return PdPvqHQYrfTEtGcYrKwAnNuIEVr[index].valueRaw;
		}

		public Element GetElement(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return null;
			}
			if ((uint)index >= (uint)PdPvqHQYrfTEtGcYrKwAnNuIEVr._count)
			{
				return null;
			}
			return OZXcSZtVrQPQPLpKldDeETdguIN[index];
		}

		public T GetElement<T>(int index) where T : Element
		{
			return GetElement(index) as T;
		}

		private void spiCZIbBixHwkYmPEBFXAXTGsXtO(UpdateLoopType P_0)
		{
			Update(P_0);
			UpdateFinished();
		}

		protected virtual bool Update(UpdateLoopType updateLoop)
		{
			if (!FnzJwrQpikWfZbmfjZhFwutJGAA)
			{
				return false;
			}
			bool flag = xlRkoINFONdZuzJATOAlCCxxQiF != null;
			Button button = default(Button);
			int num2 = default(int);
			float num5 = default(float);
			bool flag2 = default(bool);
			while (true)
			{
				int num = -1847561936;
				while (true)
				{
					switch (num ^ -1847561922)
					{
					case 13:
						break;
					case 8:
					{
						int num7;
						if (button.justReleased)
						{
							num = -1847561923;
							num7 = num;
						}
						else
						{
							num = -1847561922;
							num7 = num;
						}
						continue;
					}
					case 7:
						if (flag && OZXcSZtVrQPQPLpKldDeETdguIN[num2] is Axis)
						{
							obEiQkTIFAgaQthAiHzprSBuFMTa.Add(new Element.WKJXkUuaWGgwNdigkGgsbfrFurzH(ControllerElementType.Axis, num2, (OZXcSZtVrQPQPLpKldDeETdguIN[num2] as Axis).value - num5));
							num = -1847561922;
							continue;
						}
						goto case 0;
					case 14:
						flag2 = WiQkrnglrRfNhtRfAbCuwHxgPeo != null;
						num2 = 0;
						num = -1847561924;
						continue;
					case 3:
						if (!button.value)
						{
							obEiQkTIFAgaQthAiHzprSBuFMTa.Add(new Element.WKJXkUuaWGgwNdigkGgsbfrFurzH(ControllerElementType.Button, num2, 0f));
							num = -1847561921;
							continue;
						}
						goto case 0;
					case 5:
						num5 = 0f;
						num = -1847561928;
						continue;
					case 10:
						num5 = 0f;
						num = -1847561926;
						continue;
					case 6:
						if (flag && OZXcSZtVrQPQPLpKldDeETdguIN[num2] is Axis)
						{
							Axis axis = OZXcSZtVrQPQPLpKldDeETdguIN[num2] as Axis;
							if (axis.coordinateMode == AxisCoordinateMode.Absolute)
							{
								num5 = axis.value;
								num = -1847561926;
								continue;
							}
							goto case 10;
						}
						goto case 4;
					case 1:
						num = -1847561922;
						continue;
					case 0:
						num2++;
						num = -1847561924;
						continue;
					case 4:
					{
						OZXcSZtVrQPQPLpKldDeETdguIN[num2].GzCliicOSMFLMvKajLgvnmGSSrh();
						int num4;
						if (flag2)
						{
							num = -1847561931;
							num4 = num;
						}
						else
						{
							num = -1847561927;
							num4 = num;
						}
						continue;
					}
					case 9:
						if (button.value)
						{
							obEiQkTIFAgaQthAiHzprSBuFMTa.Add(new Element.WKJXkUuaWGgwNdigkGgsbfrFurzH(ControllerElementType.Button, num2, 1f));
							num = -1847561922;
							continue;
						}
						goto case 8;
					case 11:
					{
						int num6;
						if (OZXcSZtVrQPQPLpKldDeETdguIN[num2] is Button)
						{
							num = -1847561934;
							num6 = num;
						}
						else
						{
							num = -1847561927;
							num6 = num;
						}
						continue;
					}
					case 12:
					{
						button = OZXcSZtVrQPQPLpKldDeETdguIN[num2] as Button;
						int num3;
						if (button.justPressed)
						{
							num = -1847561929;
							num3 = num;
						}
						else
						{
							num = -1847561930;
							num3 = num;
						}
						continue;
					}
					default:
						if (num2 >= OZXcSZtVrQPQPLpKldDeETdguIN._count)
						{
							return true;
						}
						goto case 5;
					}
					break;
				}
			}
		}

		protected virtual void UpdateFinished()
		{
			int count = obEiQkTIFAgaQthAiHzprSBuFMTa.Count;
			if (count <= 0)
			{
				return;
			}
			int num2 = default(int);
			Element.WKJXkUuaWGgwNdigkGgsbfrFurzH wKJXkUuaWGgwNdigkGgsbfrFurzH = default(Element.WKJXkUuaWGgwNdigkGgsbfrFurzH);
			while (true)
			{
				int num = 1615370679;
				while (true)
				{
					int num3;
					switch (num ^ 0x604899B6)
					{
					case 4:
						break;
					case 1:
						num2 = 0;
						num = 1615370676;
						continue;
					case 3:
						wKJXkUuaWGgwNdigkGgsbfrFurzH = obEiQkTIFAgaQthAiHzprSBuFMTa[num2];
						num = 1615370678;
						continue;
					default:
						if (wKJXkUuaWGgwNdigkGgsbfrFurzH.vsNzKyIocFQEgFvIpUOofhdTyKf == ControllerElementType.Button)
						{
							try
							{
								WiQkrnglrRfNhtRfAbCuwHxgPeo(wKJXkUuaWGgwNdigkGgsbfrFurzH.aCtihPxuRFLiowUoZPQdxLYTTal, (wKJXkUuaWGgwNdigkGgsbfrFurzH.ZTonADnXjOPnKfCdZaXyKwbxjUQ > 0f) ? true : false);
							}
							catch (Exception ex)
							{
								Logger.LogError("An exception occurred in a listener of ButtonStateChangedEvent. This means an exception was thrown by your code.\n" + ex);
							}
						}
						else if (wKJXkUuaWGgwNdigkGgsbfrFurzH.vsNzKyIocFQEgFvIpUOofhdTyKf == ControllerElementType.Axis)
						{
							try
							{
								xlRkoINFONdZuzJATOAlCCxxQiF(wKJXkUuaWGgwNdigkGgsbfrFurzH.aCtihPxuRFLiowUoZPQdxLYTTal, wKJXkUuaWGgwNdigkGgsbfrFurzH.ZTonADnXjOPnKfCdZaXyKwbxjUQ);
							}
							catch (Exception ex2)
							{
								Logger.LogError("An exception occurred in a listener of AxisValueChangedEvent. This means an exception was thrown by your code.\n" + ex2);
							}
						}
						num2++;
						goto IL_00e2;
					case 2:
						goto IL_0100;
						IL_0100:
						if (num2 < count)
						{
							goto case 3;
						}
						obEiQkTIFAgaQthAiHzprSBuFMTa.Clear();
						num3 = 1615370678;
						goto IL_00e7;
						IL_00e7:
						switch (num3 ^ 0x604899B6)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							goto IL_0100;
						case 0:
							return;
						}
						goto IL_00e2;
						IL_00e2:
						num3 = 1615370679;
						goto IL_00e7;
					}
					break;
				}
			}
		}

		protected virtual void ClearVars()
		{
			obEiQkTIFAgaQthAiHzprSBuFMTa.Clear();
		}

		internal void itKYLEidIwjerGGrDGqPNskdaYz(Element P_0)
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
					PdPvqHQYrfTEtGcYrKwAnNuIEVr.Add(P_0 as Axis);
					num = -154667884;
					goto IL_0009;
				}
				goto IL_0047;
				IL_0009:
				while (true)
				{
					switch (num ^ -154667883)
					{
					case 0:
						num = -154667882;
						continue;
					case 3:
						break;
					case 2:
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
				duQdUwWCoAwHNtdgoIMHHlMkZKgA.Add(P_0 as Button);
				num = -154667884;
				goto IL_0009;
				continue;
				end_IL_0026:
				break;
			}
			OZXcSZtVrQPQPLpKldDeETdguIN.Add(P_0);
		}

		private void itKYLEidIwjerGGrDGqPNskdaYz(Element P_0, List<Element> P_1, List<Element> P_2, List<Button> P_3, List<Axis> P_4)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			goto IL_0058;
			IL_0003:
			int num = -389753641;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num ^ -389753642)
				{
				case 0:
					break;
				case 8:
					return;
				case 3:
					return;
				case 4:
					goto IL_0058;
				case 10:
					Logger.LogWarning("Unknown Element type encountered: " + P_0.GetType());
					num = -389753634;
					continue;
				case 2:
					goto IL_0097;
				case 11:
					if (P_0 is Button)
					{
						P_3.Add((Button)P_0);
						num = -389753633;
						continue;
					}
					goto IL_0097;
				case 1:
					return;
				case 9:
					P_1.Add(P_0);
					num = -389753643;
					continue;
				case 5:
					P_4.Add((Axis)P_0);
					num = -389753647;
					continue;
				case 7:
					num = -389753633;
					continue;
				default:
					goto IL_010f;
				}
				break;
				IL_0097:
				int num2;
				if (!(P_0 is Axis))
				{
					num = -389753636;
					num2 = num;
				}
				else
				{
					num = -389753645;
					num2 = num;
				}
			}
			goto IL_0003;
			IL_0058:
			P_0.GetType();
			int num3;
			if (P_0 is ElementWithSource)
			{
				num = -389753635;
				num3 = num;
			}
			else
			{
				num = -389753648;
				num3 = num;
			}
			goto IL_0008;
			IL_010f:
			if (P_0 is CompoundElement)
			{
				TempListPool.TList<Element> tList = TempListPool.GetTList<Element>();
				try
				{
					List<Element> list = tList.list;
					(P_0 as CompoundElement).XMVXbEvPDLjXpNgpYeCenjeIKHJ(list);
					int num4 = 0;
					while (num4 < list.Count)
					{
						while (true)
						{
							itKYLEidIwjerGGrDGqPNskdaYz(list[num4], P_1, P_2, P_3, P_4);
							num4++;
							int num5 = -389753642;
							while (true)
							{
								switch (num5 ^ -389753642)
								{
								case 2:
									num5 = -389753641;
									continue;
								case 1:
									break;
								default:
									goto end_IL_0155;
								}
								break;
							}
							continue;
							end_IL_0155:
							break;
						}
					}
				}
				finally
				{
					if (tList != null)
					{
						while (true)
						{
							IL_0181:
							int num6 = -389753644;
							while (true)
							{
								switch (num6 ^ -389753642)
								{
								case 0:
									break;
								default:
									goto end_IL_0186;
								case 2:
									goto IL_019f;
								case 1:
									goto end_IL_0186;
								}
								goto IL_0181;
								IL_019f:
								((IDisposable)tList).Dispose();
								num6 = -389753641;
								continue;
								end_IL_0186:
								break;
							}
							break;
						}
					}
				}
				P_2.Add(P_0);
			}
			else
			{
				Logger.LogWarning("Unknown Element type encountered: " + P_0.GetType());
			}
		}

		internal static int sEpfEHqnNOzQdObWILhWKKhIL<T>(IList<T> P_0, Predicate<T> P_1, int P_2) where T : Element
		{
			int num = 0;
			int num2 = 0;
			while (num2 < P_0.Count)
			{
				while (true)
				{
					int num3;
					if (P_1(P_0[num2]))
					{
						num++;
						num3 = 1955031364;
						goto IL_000b;
					}
					goto IL_0042;
					IL_000b:
					while (true)
					{
						switch (num3 ^ 0x74876944)
						{
						case 2:
							num3 = 1955031365;
							continue;
						case 1:
							break;
						case 0:
							goto IL_0042;
						default:
							goto end_IL_0028;
						}
						break;
					}
					continue;
					IL_0042:
					if (num == P_2)
					{
						return num2;
					}
					num2++;
					num3 = 1955031367;
					goto IL_000b;
					continue;
					end_IL_0028:
					break;
				}
			}
			return -1;
		}
	}
}
