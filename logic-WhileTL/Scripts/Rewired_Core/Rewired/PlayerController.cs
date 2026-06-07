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

				internal override Element AyzbqKXoiIAsmtBrFwHcroNIERsg(PlayerController P_0)
				{
					return new Axis(P_0, this);
				}
			}

			internal const float qPCOvYDSlUjWBxYNrOOgLxzPbptD = 1f;

			[CustomObfuscation(rename = false)]
			internal const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Absolute;

			private float xUxCcWyVGFihlQamzXrgHckdUJcY = 1f;

			private AxisCoordinateMode BMcobjmjHTLggNNyfOMkSqmwWrQO;

			public float absoluteToRelativeSensitivity
			{
				get
				{
					return xUxCcWyVGFihlQamzXrgHckdUJcY;
				}
				set
				{
					if (value < 0f)
					{
						value = 0f;
					}
					xUxCcWyVGFihlQamzXrgHckdUJcY = value;
				}
			}

			public AxisCoordinateMode coordinateMode => BMcobjmjHTLggNNyfOMkSqmwWrQO;

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
						if (BMcobjmjHTLggNNyfOMkSqmwWrQO == AxisCoordinateMode.Absolute)
						{
							return 0f;
						}
						break;
					case AxisCoordinateMode.Absolute:
						if (BMcobjmjHTLggNNyfOMkSqmwWrQO == AxisCoordinateMode.Relative)
						{
							num *= (float)ReInput.unscaledDeltaTime * xUxCcWyVGFihlQamzXrgHckdUJcY;
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
				xUxCcWyVGFihlQamzXrgHckdUJcY = P_1.absoluteToRelativeSensitivity;
				BMcobjmjHTLggNNyfOMkSqmwWrQO = P_1.coordinateMode;
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

				internal override Element AyzbqKXoiIAsmtBrFwHcroNIERsg(PlayerController P_0)
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

			internal MouseAxis(PlayerController P_0, Definition P_1)
				: base(P_0, P_1)
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
						return lMaImMvDFjePdKTitSLtLPPEvZJP;
					}
					set
					{
						lMaImMvDFjePdKTitSLtLPPEvZJP = value;
					}
				}

				public Axis.Definition yAxis
				{
					get
					{
						return typAojquHuySEkCnukGlcsTlLXGh;
					}
					set
					{
						typAojquHuySEkCnukGlcsTlLXGh = value;
					}
				}

				internal override Element AyzbqKXoiIAsmtBrFwHcroNIERsg(PlayerController P_0)
				{
					return new Axis2D(P_0, this);
				}
			}

			internal const int JKBReHOaFzWpyjqwhKkYsdYexEJi = 0;

			internal const int RsUEyOrIEAdgNdMsNlvgyfTYgRVT = 1;

			internal const int LldlRtxxxfHaDraqUBjJFnJlWYnK = 2;

			public Axis xAxis => eFnogOZmzyuQdEpygQflSqDcOeKp<Axis>(0);

			public Axis yAxis => eFnogOZmzyuQdEpygQflSqDcOeKp<Axis>(1);

			public virtual Vector2 value => new Vector2(eFnogOZmzyuQdEpygQflSqDcOeKp<Axis>(0).value, eFnogOZmzyuQdEpygQflSqDcOeKp<Axis>(1).value);

			public virtual Vector2 valueRaw => new Vector2(eFnogOZmzyuQdEpygQflSqDcOeKp<Axis>(0).valueRaw, eFnogOZmzyuQdEpygQflSqDcOeKp<Axis>(1).valueRaw);

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

				internal override Element AyzbqKXoiIAsmtBrFwHcroNIERsg(PlayerController P_0)
				{
					return new MouseAxis2D(P_0, this);
				}
			}

			public new MouseAxis xAxis => eFnogOZmzyuQdEpygQflSqDcOeKp<MouseAxis>(0);

			public new MouseAxis yAxis => eFnogOZmzyuQdEpygQflSqDcOeKp<MouseAxis>(1);

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
				internal override Element AyzbqKXoiIAsmtBrFwHcroNIERsg(PlayerController P_0)
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

			private readonly List<Element> aUQWeyXieBvNOUAjqzTkUKmMbRkq;

			internal int WOdvMTZVCrCusSlqOUStwpOvfaKX => aUQWeyXieBvNOUAjqzTkUKmMbRkq.Count;

			internal CompoundElement(PlayerController P_0, Definition P_1, Element.Definition[] P_2)
				: base(P_0, P_1)
			{
				aUQWeyXieBvNOUAjqzTkUKmMbRkq = new List<Element>();
				if (P_2 == null)
				{
					return;
				}
				for (int i = 0; i < P_2.Length; i++)
				{
					if (P_2[i] != null)
					{
						EXLSSjQnrrQtaZMvCcEDTNZBhhQt(P_2[i].AyzbqKXoiIAsmtBrFwHcroNIERsg(P_0));
					}
				}
			}

			internal _0001 eFnogOZmzyuQdEpygQflSqDcOeKp<_0001>(int P_0) where _0001 : Element
			{
				if ((uint)P_0 >= (uint)aUQWeyXieBvNOUAjqzTkUKmMbRkq.Count)
				{
					return null;
				}
				return aUQWeyXieBvNOUAjqzTkUKmMbRkq[P_0] as _0001;
			}

			internal void bDWTTzTqiIaxwAXlRaWoxZRsySsJ(List<Element> P_0)
			{
				for (int i = 0; i < aUQWeyXieBvNOUAjqzTkUKmMbRkq.Count; i++)
				{
					if (aUQWeyXieBvNOUAjqzTkUKmMbRkq[i] is CompoundElement)
					{
						(aUQWeyXieBvNOUAjqzTkUKmMbRkq[i] as CompoundElement).bDWTTzTqiIaxwAXlRaWoxZRsySsJ(P_0);
					}
					else
					{
						P_0.Add(aUQWeyXieBvNOUAjqzTkUKmMbRkq[i]);
					}
				}
			}

			internal void EXLSSjQnrrQtaZMvCcEDTNZBhhQt(Element P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("element");
				}
				aUQWeyXieBvNOUAjqzTkUKmMbRkq.Add(P_0);
				P_0.EmbhxShZpSdinJOCBRHmiAsqvDuRA = true;
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

				internal abstract Element AyzbqKXoiIAsmtBrFwHcroNIERsg(PlayerController P_0);
			}

			internal struct qFOqzvUldDgMWroubIhupUJWSdUC
			{
				public ControllerElementType HdUojRicHUlIpCmGkuawfkOvHDMt;

				public int OVaNqsFEyODDjJdeKwblTptrPuEz;

				public float pWbMhcBQKZEHHDwvEOhqpAUJhzfpA;

				public qFOqzvUldDgMWroubIhupUJWSdUC(ControllerElementType P_0, int P_1, float P_2)
				{
					HdUojRicHUlIpCmGkuawfkOvHDMt = P_0;
					OVaNqsFEyODDjJdeKwblTptrPuEz = P_1;
					pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = P_2;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const bool defaultEnabled = true;

			private readonly PlayerController rBdHDCfDobOjBUqyNbBnmEluxEvZ;

			private bool YQcaepgwdPMnDBoJhLEmSeLNpvTX;

			private bool llkLFSoLVtaASCstwdnHCsIDxnhYb = true;

			private string gbaFwplwRPDIuUufIuWmknaoIHDK;

			private static int[] xYSdIKKPJhRECdphArEgoKPfEPNe;

			private static int[] brKQlghhXgojExrMnbyrUXYTTgNB;

			protected Player player
			{
				get
				{
					if (!ReInput.isReady)
					{
						return null;
					}
					return ReInput.players.GetPlayer(rBdHDCfDobOjBUqyNbBnmEluxEvZ.KjrBBzjjJWMijsVwJGfzfVcgArYWb);
				}
			}

			protected bool selfAndParentEnabled
			{
				get
				{
					if (llkLFSoLVtaASCstwdnHCsIDxnhYb)
					{
						return rBdHDCfDobOjBUqyNbBnmEluxEvZ.llkLFSoLVtaASCstwdnHCsIDxnhYb;
					}
					return false;
				}
			}

			internal bool EmbhxShZpSdinJOCBRHmiAsqvDuRA
			{
				get
				{
					return YQcaepgwdPMnDBoJhLEmSeLNpvTX;
				}
				set
				{
					YQcaepgwdPMnDBoJhLEmSeLNpvTX = true;
				}
			}

			public bool enabled
			{
				get
				{
					return llkLFSoLVtaASCstwdnHCsIDxnhYb;
				}
				set
				{
					if (llkLFSoLVtaASCstwdnHCsIDxnhYb != value)
					{
						llkLFSoLVtaASCstwdnHCsIDxnhYb = value;
						EnabledStateChanged(value);
					}
				}
			}

			public string name
			{
				get
				{
					return gbaFwplwRPDIuUufIuWmknaoIHDK;
				}
				set
				{
					gbaFwplwRPDIuUufIuWmknaoIHDK = value;
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
				rBdHDCfDobOjBUqyNbBnmEluxEvZ = P_0;
				llkLFSoLVtaASCstwdnHCsIDxnhYb = P_1.enabled;
			}

			internal virtual void sOLNzBCCbZmFXkMugfndpShqgrUP()
			{
			}

			protected virtual void EnabledStateChanged(bool state)
			{
			}

			[CustomObfuscation(rename = false)]
			internal static bool IsTypeWithSource(Type type)
			{
				if (xYSdIKKPJhRECdphArEgoKPfEPNe == null)
				{
					xYSdIKKPJhRECdphArEgoKPfEPNe = (int[])Enum.GetValues(typeof(TypeWithSource));
				}
				return ArrayTools.Contains(xYSdIKKPJhRECdphArEgoKPfEPNe, (int)type);
			}

			[CustomObfuscation(rename = false)]
			internal static bool IsCompoundType(Type type)
			{
				if (brKQlghhXgojExrMnbyrUXYTTgNB == null)
				{
					brKQlghhXgojExrMnbyrUXYTTgNB = (int[])Enum.GetValues(typeof(CompoundTypes));
				}
				return ArrayTools.Contains(brKQlghhXgojExrMnbyrUXYTTgNB, (int)type);
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
				private int WtxqRhyewFhRCZexgGgTPAkliDAd;

				public int actionId
				{
					get
					{
						return WtxqRhyewFhRCZexgGgTPAkliDAd;
					}
					set
					{
						WtxqRhyewFhRCZexgGgTPAkliDAd = value;
					}
				}

				public string actionName
				{
					get
					{
						if (!ReInput.isReady || WtxqRhyewFhRCZexgGgTPAkliDAd < 0)
						{
							return null;
						}
						return ReInput.mapping.GetAction(WtxqRhyewFhRCZexgGgTPAkliDAd)?.name;
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
							WtxqRhyewFhRCZexgGgTPAkliDAd = -1;
						}
						else
						{
							WtxqRhyewFhRCZexgGgTPAkliDAd = action.id;
						}
					}
				}

				public Definition()
				{
					WtxqRhyewFhRCZexgGgTPAkliDAd = -1;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const int defaultActionId = -1;

			private int WtxqRhyewFhRCZexgGgTPAkliDAd = -1;

			public int actionId
			{
				get
				{
					return WtxqRhyewFhRCZexgGgTPAkliDAd;
				}
				set
				{
					WtxqRhyewFhRCZexgGgTPAkliDAd = value;
				}
			}

			public string actionName
			{
				get
				{
					if (!ReInput.isReady || WtxqRhyewFhRCZexgGgTPAkliDAd < 0)
					{
						return null;
					}
					return ReInput.mapping.GetAction(WtxqRhyewFhRCZexgGgTPAkliDAd)?.name;
				}
				set
				{
					if (ReInput.isReady)
					{
						InputAction action = ReInput.mapping.GetAction(value);
						if (action == null)
						{
							WtxqRhyewFhRCZexgGgTPAkliDAd = -1;
						}
						else
						{
							WtxqRhyewFhRCZexgGgTPAkliDAd = action.id;
						}
					}
				}
			}

			internal ElementWithSource(PlayerController P_0, Definition P_1)
				: base(P_0, P_1)
			{
				WtxqRhyewFhRCZexgGgTPAkliDAd = P_1.actionId;
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

				internal override Element AyzbqKXoiIAsmtBrFwHcroNIERsg(PlayerController P_0)
				{
					return new MouseWheel(P_0, this);
				}
			}

			public new MouseWheelAxis xAxis => eFnogOZmzyuQdEpygQflSqDcOeKp<MouseWheelAxis>(0);

			public new MouseWheelAxis yAxis => eFnogOZmzyuQdEpygQflSqDcOeKp<MouseWheelAxis>(1);

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

				internal override Element AyzbqKXoiIAsmtBrFwHcroNIERsg(PlayerController P_0)
				{
					return new MouseWheelAxis(P_0, this);
				}
			}

			[CustomObfuscation(rename = false)]
			internal const float defaultRepeatRate = 4f;

			[CustomObfuscation(rename = false)]
			internal new const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Relative;

			private const float pPMENrbaPfAiPpLAInSBmXmskYUK = 0.01f;

			private float RNxVHgjleVBMtFFWhbGeJSoMIgab = 0.25f;

			private double vIwvPMcATIHkMviHRVsUjaNizSjw;

			private float zqlmAmRAWxhuzRtcELHICvssAvpy;

			public float repeatRate
			{
				get
				{
					if (RNxVHgjleVBMtFFWhbGeJSoMIgab == 0f)
					{
						return 0f;
					}
					return 1f / RNxVHgjleVBMtFFWhbGeJSoMIgab;
				}
				set
				{
					if (value < 0f)
					{
						value = 0f;
					}
					if (value == 0f)
					{
						RNxVHgjleVBMtFFWhbGeJSoMIgab = 0f;
					}
					else
					{
						RNxVHgjleVBMtFFWhbGeJSoMIgab = 1f / value;
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
					return zqlmAmRAWxhuzRtcELHICvssAvpy;
				}
			}

			internal MouseWheelAxis(PlayerController P_0, Definition P_1)
				: base(P_0, P_1)
			{
				repeatRate = P_1.repeatRate;
			}

			internal override void sOLNzBCCbZmFXkMugfndpShqgrUP()
			{
				base.sOLNzBCCbZmFXkMugfndpShqgrUP();
				if (base.selfAndParentEnabled)
				{
					zqlmAmRAWxhuzRtcELHICvssAvpy = pPeAIMkptsfutQLGOJrGoKfGJLad();
				}
			}

			protected override void EnabledStateChanged(bool state)
			{
				base.EnabledStateChanged(state);
				if (!state)
				{
					HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
				}
			}

			private float pPeAIMkptsfutQLGOJrGoKfGJLad()
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
					if (!flag && ReInput.unscaledTime < vIwvPMcATIHkMviHRVsUjaNizSjw + (double)RNxVHgjleVBMtFFWhbGeJSoMIgab)
					{
						return 0f;
					}
					if (Mathf.Abs(num) <= 0.01f)
					{
						return 0f;
					}
					num = Mathf.Sign(num);
					num *= base.absoluteToRelativeSensitivity;
					vIwvPMcATIHkMviHRVsUjaNizSjw = ReInput.unscaledTime;
					break;
				}
				}
				return num;
			}

			private void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
			{
				zqlmAmRAWxhuzRtcELHICvssAvpy = 0f;
				vIwvPMcATIHkMviHRVsUjaNizSjw = 0.0;
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
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return false;
				}
				return llkLFSoLVtaASCstwdnHCsIDxnhYb;
			}
			set
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				}
				else
				{
					if (llkLFSoLVtaASCstwdnHCsIDxnhYb == value)
					{
						return;
					}
					if (!value)
					{
						ClearVars();
					}
					llkLFSoLVtaASCstwdnHCsIDxnhYb = value;
					for (int i = 0; i < aUQWeyXieBvNOUAjqzTkUKmMbRkq._count; i++)
					{
						aUQWeyXieBvNOUAjqzTkUKmMbRkq[i].enabled = value;
					}
					if (vPTVuMiQdGJnDqRyojAKUwFPnFYJ != null)
					{
						try
						{
							vPTVuMiQdGJnDqRyojAKUwFPnFYJ(value);
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
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return -1;
				}
				return KjrBBzjjJWMijsVwJGfzfVcgArYWb;
			}
			set
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				}
				else if (KjrBBzjjJWMijsVwJGfzfVcgArYWb != value)
				{
					KjrBBzjjJWMijsVwJGfzfVcgArYWb = value;
					ClearVars();
				}
			}
		}

		public IList<Button> buttons
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return null;
				}
				return egRIWCsrRvLJBNoTeDGKlOMtsehu;
			}
		}

		public IList<Axis> axes
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return null;
				}
				return rEtiIIgRDKkgbtYvpdyAuMMnTsTo;
			}
		}

		public IList<Element> elements
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return null;
				}
				return ABLlvSkeHalgmkxVjrUFAcOGcjTf;
			}
		}

		public int buttonCount
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return 0;
				}
				if (ZvPFEBoODFIFAalgjPuHlidSttRw == null)
				{
					return 0;
				}
				return ZvPFEBoODFIFAalgjPuHlidSttRw._count;
			}
		}

		public int axisCount
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return 0;
				}
				if (brSuYimOuyWJoTIlcMgUhFfimdIf == null)
				{
					return 0;
				}
				return brSuYimOuyWJoTIlcMgUhFfimdIf._count;
			}
		}

		public int elementCount
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return 0;
				}
				if (aUQWeyXieBvNOUAjqzTkUKmMbRkq == null)
				{
					return 0;
				}
				return aUQWeyXieBvNOUAjqzTkUKmMbRkq._count;
			}
		}

		internal Player EVSYfBRoRmlZGWzbtVEKHpHdIHIm
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
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				}
				else
				{
					oGZajKIGGQSTmaWfVTqiqcYCqDRv = (Action<int, bool>)Delegate.Combine(oGZajKIGGQSTmaWfVTqiqcYCqDRv, value);
				}
			}
			remove
			{
				oGZajKIGGQSTmaWfVTqiqcYCqDRv = (Action<int, bool>)Delegate.Remove(oGZajKIGGQSTmaWfVTqiqcYCqDRv, value);
			}
		}

		public event Action<int, float> AxisValueChangedEvent
		{
			add
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				}
				else
				{
					HLGKyrdafUQHhqdCIWgbSLWXcXmr = (Action<int, float>)Delegate.Combine(HLGKyrdafUQHhqdCIWgbSLWXcXmr, value);
				}
			}
			remove
			{
				HLGKyrdafUQHhqdCIWgbSLWXcXmr = (Action<int, float>)Delegate.Remove(HLGKyrdafUQHhqdCIWgbSLWXcXmr, value);
			}
		}

		public event Action<bool> EnabledStateChangedEvent
		{
			add
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				}
				else
				{
					vPTVuMiQdGJnDqRyojAKUwFPnFYJ = (Action<bool>)Delegate.Combine(vPTVuMiQdGJnDqRyojAKUwFPnFYJ, value);
				}
			}
			remove
			{
				vPTVuMiQdGJnDqRyojAKUwFPnFYJ = (Action<bool>)Delegate.Remove(vPTVuMiQdGJnDqRyojAKUwFPnFYJ, value);
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
			TcEXPUvjqSTMTFutCAtGRnMeNwub = ReInput._id;
			KjrBBzjjJWMijsVwJGfzfVcgArYWb = P_0.playerId;
			llkLFSoLVtaASCstwdnHCsIDxnhYb = P_0.enabled;
			List<Element> list = new List<Element>();
			List<Element> list2 = new List<Element>();
			List<Button> list3 = new List<Button>();
			List<Axis> list4 = new List<Axis>();
			foreach (Element.Definition element in P_0.elements)
			{
				EXLSSjQnrrQtaZMvCcEDTNZBhhQt(element.AyzbqKXoiIAsmtBrFwHcroNIERsg(this), list, list2, list3, list4);
			}
			list.AddRange(list2);
			aUQWeyXieBvNOUAjqzTkUKmMbRkq = new AList<Element>(list);
			ZvPFEBoODFIFAalgjPuHlidSttRw = new AList<Button>(list3);
			brSuYimOuyWJoTIlcMgUhFfimdIf = new AList<Axis>(list4);
			ABLlvSkeHalgmkxVjrUFAcOGcjTf = new ReadOnlyCollection<Element>(aUQWeyXieBvNOUAjqzTkUKmMbRkq);
			egRIWCsrRvLJBNoTeDGKlOMtsehu = new ReadOnlyCollection<Button>(ZvPFEBoODFIFAalgjPuHlidSttRw);
			rEtiIIgRDKkgbtYvpdyAuMMnTsTo = new ReadOnlyCollection<Axis>(brSuYimOuyWJoTIlcMgUhFfimdIf);
			YpTnyHbxmVEeJmsCbcHlhquMctqU = new List<Element.qFOqzvUldDgMWroubIhupUJWSdUC>();
			ReInput.UpdateEndedEvent += IghfPvNUXsucbZILFgzLRWwwGmUeA;
		}

		~PlayerController()
		{
			ReInput.UpdateEndedEvent -= IghfPvNUXsucbZILFgzLRWwwGmUeA;
		}

		public bool GetButton(int index)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			if ((uint)index >= (uint)ZvPFEBoODFIFAalgjPuHlidSttRw._count)
			{
				return false;
			}
			return ZvPFEBoODFIFAalgjPuHlidSttRw[index].value;
		}

		public bool GetButtonDown(int index)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			if ((uint)index >= (uint)ZvPFEBoODFIFAalgjPuHlidSttRw._count)
			{
				return false;
			}
			return ZvPFEBoODFIFAalgjPuHlidSttRw[index].justPressed;
		}

		public bool GetButtonUp(int index)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			if ((uint)index >= (uint)ZvPFEBoODFIFAalgjPuHlidSttRw._count)
			{
				return false;
			}
			return ZvPFEBoODFIFAalgjPuHlidSttRw[index].justReleased;
		}

		public float GetAxis(int index)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0f;
			}
			if ((uint)index >= (uint)brSuYimOuyWJoTIlcMgUhFfimdIf._count)
			{
				return 0f;
			}
			return brSuYimOuyWJoTIlcMgUhFfimdIf[index].value;
		}

		public float GetAxisRaw(int index)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0f;
			}
			if ((uint)index >= (uint)brSuYimOuyWJoTIlcMgUhFfimdIf._count)
			{
				return 0f;
			}
			return brSuYimOuyWJoTIlcMgUhFfimdIf[index].valueRaw;
		}

		public Element GetElement(int index)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			if ((uint)index >= (uint)brSuYimOuyWJoTIlcMgUhFfimdIf._count)
			{
				return null;
			}
			return aUQWeyXieBvNOUAjqzTkUKmMbRkq[index];
		}

		public T GetElement<T>(int index) where T : Element
		{
			return GetElement(index) as T;
		}

		private void IghfPvNUXsucbZILFgzLRWwwGmUeA(UpdateLoopType P_0)
		{
			Update(P_0);
			UpdateFinished();
		}

		protected virtual bool Update(UpdateLoopType updateLoop)
		{
			if (!llkLFSoLVtaASCstwdnHCsIDxnhYb)
			{
				return false;
			}
			bool flag = HLGKyrdafUQHhqdCIWgbSLWXcXmr != null;
			bool flag2 = oGZajKIGGQSTmaWfVTqiqcYCqDRv != null;
			for (int i = 0; i < aUQWeyXieBvNOUAjqzTkUKmMbRkq._count; i++)
			{
				float num = 0f;
				if (flag && aUQWeyXieBvNOUAjqzTkUKmMbRkq[i] is Axis)
				{
					Axis axis = aUQWeyXieBvNOUAjqzTkUKmMbRkq[i] as Axis;
					num = ((axis.coordinateMode != AxisCoordinateMode.Absolute) ? 0f : axis.value);
				}
				aUQWeyXieBvNOUAjqzTkUKmMbRkq[i].sOLNzBCCbZmFXkMugfndpShqgrUP();
				if (flag2 && aUQWeyXieBvNOUAjqzTkUKmMbRkq[i] is Button)
				{
					Button button = aUQWeyXieBvNOUAjqzTkUKmMbRkq[i] as Button;
					if (button.justPressed && button.value)
					{
						YpTnyHbxmVEeJmsCbcHlhquMctqU.Add(new Element.qFOqzvUldDgMWroubIhupUJWSdUC(ControllerElementType.Button, i, 1f));
					}
					else if (button.justReleased && !button.value)
					{
						YpTnyHbxmVEeJmsCbcHlhquMctqU.Add(new Element.qFOqzvUldDgMWroubIhupUJWSdUC(ControllerElementType.Button, i, 0f));
					}
				}
				else if (flag && aUQWeyXieBvNOUAjqzTkUKmMbRkq[i] is Axis)
				{
					YpTnyHbxmVEeJmsCbcHlhquMctqU.Add(new Element.qFOqzvUldDgMWroubIhupUJWSdUC(ControllerElementType.Axis, i, (aUQWeyXieBvNOUAjqzTkUKmMbRkq[i] as Axis).value - num));
				}
			}
			return true;
		}

		protected virtual void UpdateFinished()
		{
			int count = YpTnyHbxmVEeJmsCbcHlhquMctqU.Count;
			if (count <= 0)
			{
				return;
			}
			for (int i = 0; i < count; i++)
			{
				Element.qFOqzvUldDgMWroubIhupUJWSdUC qFOqzvUldDgMWroubIhupUJWSdUC = YpTnyHbxmVEeJmsCbcHlhquMctqU[i];
				if (qFOqzvUldDgMWroubIhupUJWSdUC.HdUojRicHUlIpCmGkuawfkOvHDMt == ControllerElementType.Button)
				{
					try
					{
						oGZajKIGGQSTmaWfVTqiqcYCqDRv(qFOqzvUldDgMWroubIhupUJWSdUC.OVaNqsFEyODDjJdeKwblTptrPuEz, qFOqzvUldDgMWroubIhupUJWSdUC.pWbMhcBQKZEHHDwvEOhqpAUJhzfpA > 0f);
					}
					catch (Exception ex)
					{
						Logger.LogError("An exception occurred in a listener of ButtonStateChangedEvent. This means an exception was thrown by your code.\n" + ex);
					}
				}
				else if (qFOqzvUldDgMWroubIhupUJWSdUC.HdUojRicHUlIpCmGkuawfkOvHDMt == ControllerElementType.Axis)
				{
					try
					{
						HLGKyrdafUQHhqdCIWgbSLWXcXmr(qFOqzvUldDgMWroubIhupUJWSdUC.OVaNqsFEyODDjJdeKwblTptrPuEz, qFOqzvUldDgMWroubIhupUJWSdUC.pWbMhcBQKZEHHDwvEOhqpAUJhzfpA);
					}
					catch (Exception ex2)
					{
						Logger.LogError("An exception occurred in a listener of AxisValueChangedEvent. This means an exception was thrown by your code.\n" + ex2);
					}
				}
			}
			YpTnyHbxmVEeJmsCbcHlhquMctqU.Clear();
		}

		protected virtual void ClearVars()
		{
			YpTnyHbxmVEeJmsCbcHlhquMctqU.Clear();
		}

		internal void EXLSSjQnrrQtaZMvCcEDTNZBhhQt(Element P_0)
		{
			if (P_0 != null)
			{
				if (P_0 is Axis)
				{
					brSuYimOuyWJoTIlcMgUhFfimdIf.Add(P_0 as Axis);
				}
				else if (P_0 is Button)
				{
					ZvPFEBoODFIFAalgjPuHlidSttRw.Add(P_0 as Button);
				}
				aUQWeyXieBvNOUAjqzTkUKmMbRkq.Add(P_0);
			}
		}

		private void EXLSSjQnrrQtaZMvCcEDTNZBhhQt(Element P_0, List<Element> P_1, List<Element> P_2, List<Button> P_3, List<Axis> P_4)
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
					(P_0 as CompoundElement).bDWTTzTqiIaxwAXlRaWoxZRsySsJ(list);
					for (int i = 0; i < list.Count; i++)
					{
						EXLSSjQnrrQtaZMvCcEDTNZBhhQt(list[i], P_1, P_2, P_3, P_4);
					}
				}
				P_2.Add(P_0);
			}
			else
			{
				Logger.LogWarning("Unknown Element type encountered: " + P_0.GetType());
			}
		}

		internal static int IuxFzWiQBqbOyePCizqDplvmnxcy<_0001>(IList<_0001> P_0, Predicate<_0001> P_1, int P_2) where _0001 : Element
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
