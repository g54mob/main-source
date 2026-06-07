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

				internal abstract Element MYVETqWFLwGNVKSdsAtynZHYNMgl(PlayerController P_0);
			}

			internal struct imqfEZJRMdXxpAriWeReLlYAEOKf
			{
				public ControllerElementType LSmTRdvHuagVChPSPaniDTWrvDKL;

				public int ACGGwGOBHafSQSEmbVqxDttpurC;

				public float lvXCTCWOhrCtuFDbbEqyqyUVPhp;

				public imqfEZJRMdXxpAriWeReLlYAEOKf(ControllerElementType elementType, int index, float value)
				{
					LSmTRdvHuagVChPSPaniDTWrvDKL = elementType;
					ACGGwGOBHafSQSEmbVqxDttpurC = index;
					lvXCTCWOhrCtuFDbbEqyqyUVPhp = value;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const bool defaultEnabled = true;

			private readonly PlayerController lNLlpcURMXkCiVBaiOQpguboCVx;

			private bool QhKPUXrzQriageKPKHXwmyZLtzL;

			private bool fnEBjitvkHhPtXTzRLmBYpIxFbt = true;

			private string qpIGvFaemznETzYbpRdmOKmaPCL;

			private static int[] bRaVZiTUoVOSzYfrhTcqWJWfFMP;

			private static int[] pdgwcVqlOKilIBYdMJemDsPFUReu;

			protected Player player
			{
				get
				{
					if (!ReInput.isReady)
					{
						return null;
					}
					return ReInput.players.GetPlayer(lNLlpcURMXkCiVBaiOQpguboCVx.EpFfrTuakcvBKacoggaztTmGfrG);
				}
			}

			protected bool selfAndParentEnabled
			{
				get
				{
					if (fnEBjitvkHhPtXTzRLmBYpIxFbt)
					{
						return lNLlpcURMXkCiVBaiOQpguboCVx.fnEBjitvkHhPtXTzRLmBYpIxFbt;
					}
					return false;
				}
			}

			internal bool isMemberElement
			{
				get
				{
					return QhKPUXrzQriageKPKHXwmyZLtzL;
				}
				set
				{
					QhKPUXrzQriageKPKHXwmyZLtzL = true;
				}
			}

			public bool enabled
			{
				get
				{
					return fnEBjitvkHhPtXTzRLmBYpIxFbt;
				}
				set
				{
					if (fnEBjitvkHhPtXTzRLmBYpIxFbt != value)
					{
						fnEBjitvkHhPtXTzRLmBYpIxFbt = value;
						EnabledStateChanged(value);
					}
				}
			}

			public string name
			{
				get
				{
					return qpIGvFaemznETzYbpRdmOKmaPCL;
				}
				set
				{
					qpIGvFaemznETzYbpRdmOKmaPCL = value;
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
				lNLlpcURMXkCiVBaiOQpguboCVx = parent;
				fnEBjitvkHhPtXTzRLmBYpIxFbt = definition.enabled;
			}

			internal virtual void iAnBBfDdWbgOiFHwNWqxFDtiXzYA()
			{
			}

			protected virtual void EnabledStateChanged(bool state)
			{
			}

			[CustomObfuscation(rename = false)]
			internal static bool IsTypeWithSource(Type type)
			{
				if (bRaVZiTUoVOSzYfrhTcqWJWfFMP == null)
				{
					bRaVZiTUoVOSzYfrhTcqWJWfFMP = (int[])Enum.GetValues(typeof(TypeWithSource));
				}
				return ArrayTools.Contains(bRaVZiTUoVOSzYfrhTcqWJWfFMP, (int)type);
			}

			[CustomObfuscation(rename = false)]
			internal static bool IsCompoundType(Type type)
			{
				if (pdgwcVqlOKilIBYdMJemDsPFUReu == null)
				{
					pdgwcVqlOKilIBYdMJemDsPFUReu = (int[])Enum.GetValues(typeof(CompoundTypes));
				}
				return ArrayTools.Contains(pdgwcVqlOKilIBYdMJemDsPFUReu, (int)type);
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
				private int CYBGYVfPDvCydagiBzJBExAfcuYb;

				public int actionId
				{
					get
					{
						return CYBGYVfPDvCydagiBzJBExAfcuYb;
					}
					set
					{
						CYBGYVfPDvCydagiBzJBExAfcuYb = value;
					}
				}

				public string actionName
				{
					get
					{
						if (!ReInput.isReady || CYBGYVfPDvCydagiBzJBExAfcuYb < 0)
						{
							return null;
						}
						return ReInput.mapping.GetAction(CYBGYVfPDvCydagiBzJBExAfcuYb)?.name;
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
							CYBGYVfPDvCydagiBzJBExAfcuYb = -1;
						}
						else
						{
							CYBGYVfPDvCydagiBzJBExAfcuYb = action.id;
						}
					}
				}

				public Definition()
				{
					CYBGYVfPDvCydagiBzJBExAfcuYb = -1;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const int defaultActionId = -1;

			private int CYBGYVfPDvCydagiBzJBExAfcuYb = -1;

			public int actionId
			{
				get
				{
					return CYBGYVfPDvCydagiBzJBExAfcuYb;
				}
				set
				{
					CYBGYVfPDvCydagiBzJBExAfcuYb = value;
				}
			}

			public string actionName
			{
				get
				{
					if (!ReInput.isReady || CYBGYVfPDvCydagiBzJBExAfcuYb < 0)
					{
						return null;
					}
					return ReInput.mapping.GetAction(CYBGYVfPDvCydagiBzJBExAfcuYb)?.name;
				}
				set
				{
					if (ReInput.isReady)
					{
						InputAction action = ReInput.mapping.GetAction(value);
						if (action == null)
						{
							CYBGYVfPDvCydagiBzJBExAfcuYb = -1;
						}
						else
						{
							CYBGYVfPDvCydagiBzJBExAfcuYb = action.id;
						}
					}
				}
			}

			internal ElementWithSource(PlayerController parent, Definition definition)
				: base(parent, definition)
			{
				CYBGYVfPDvCydagiBzJBExAfcuYb = definition.actionId;
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

				internal override Element MYVETqWFLwGNVKSdsAtynZHYNMgl(PlayerController P_0)
				{
					return new Axis(P_0, this);
				}
			}

			internal const float agcbcmCUxovgiCfGQrNytRnVfvt = 1f;

			[CustomObfuscation(rename = false)]
			internal const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Absolute;

			private float dxBMQingrxBsGhukQIysHdkpjJar = 1f;

			private AxisCoordinateMode BdUbDLjYsfttLyhaUFBsixasdzU;

			public float absoluteToRelativeSensitivity
			{
				get
				{
					return dxBMQingrxBsGhukQIysHdkpjJar;
				}
				set
				{
					if (value < 0f)
					{
						value = 0f;
					}
					dxBMQingrxBsGhukQIysHdkpjJar = value;
				}
			}

			public AxisCoordinateMode coordinateMode => BdUbDLjYsfttLyhaUFBsixasdzU;

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
						if (BdUbDLjYsfttLyhaUFBsixasdzU == AxisCoordinateMode.Absolute)
						{
							return 0f;
						}
						break;
					case AxisCoordinateMode.Absolute:
						if (BdUbDLjYsfttLyhaUFBsixasdzU == AxisCoordinateMode.Relative)
						{
							num *= (float)ReInput.unscaledDeltaTime * dxBMQingrxBsGhukQIysHdkpjJar;
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
				dxBMQingrxBsGhukQIysHdkpjJar = definition.absoluteToRelativeSensitivity;
				BdUbDLjYsfttLyhaUFBsixasdzU = definition.coordinateMode;
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

				internal override Element MYVETqWFLwGNVKSdsAtynZHYNMgl(PlayerController P_0)
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

			private readonly List<Element> omxIKEAXItSjJrzFPUwpagFQPsi;

			internal int elementCount => omxIKEAXItSjJrzFPUwpagFQPsi.Count;

			internal CompoundElement(PlayerController parent, Definition definition, Element.Definition[] elementDefinitions)
				: base(parent, definition)
			{
				omxIKEAXItSjJrzFPUwpagFQPsi = new List<Element>();
				if (elementDefinitions == null)
				{
					return;
				}
				for (int i = 0; i < elementDefinitions.Length; i++)
				{
					if (elementDefinitions[i] != null)
					{
						SSjwBZRYcJqbFyjnlHATtvRHxFM(elementDefinitions[i].MYVETqWFLwGNVKSdsAtynZHYNMgl(parent));
					}
				}
			}

			internal T mqLOUmOxEQDrMnAgTyphyrVuicA<T>(int P_0) where T : Element
			{
				if ((uint)P_0 >= (uint)omxIKEAXItSjJrzFPUwpagFQPsi.Count)
				{
					return null;
				}
				return omxIKEAXItSjJrzFPUwpagFQPsi[P_0] as T;
			}

			internal void zogrqFEhVuhiXlPlqfJqIPTccqer(List<Element> P_0)
			{
				for (int i = 0; i < omxIKEAXItSjJrzFPUwpagFQPsi.Count; i++)
				{
					if (omxIKEAXItSjJrzFPUwpagFQPsi[i] is CompoundElement)
					{
						(omxIKEAXItSjJrzFPUwpagFQPsi[i] as CompoundElement).zogrqFEhVuhiXlPlqfJqIPTccqer(P_0);
					}
					else
					{
						P_0.Add(omxIKEAXItSjJrzFPUwpagFQPsi[i]);
					}
				}
			}

			internal void SSjwBZRYcJqbFyjnlHATtvRHxFM(Element P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("element");
				}
				omxIKEAXItSjJrzFPUwpagFQPsi.Add(P_0);
				P_0.isMemberElement = true;
			}
		}

		public class Axis2D : CompoundElement
		{
			public new class Definition : CompoundElement.Definition
			{
				private Axis.Definition rCCUskmpaLFAYvUqCBCbanPClXVW;

				private Axis.Definition vyXfeHbEmSGntdDdJzfjWKRhSZAE;

				public Axis.Definition xAxis
				{
					get
					{
						return rCCUskmpaLFAYvUqCBCbanPClXVW;
					}
					set
					{
						rCCUskmpaLFAYvUqCBCbanPClXVW = value;
					}
				}

				public Axis.Definition yAxis
				{
					get
					{
						return vyXfeHbEmSGntdDdJzfjWKRhSZAE;
					}
					set
					{
						vyXfeHbEmSGntdDdJzfjWKRhSZAE = value;
					}
				}

				internal override Element MYVETqWFLwGNVKSdsAtynZHYNMgl(PlayerController P_0)
				{
					return new Axis2D(P_0, this);
				}
			}

			internal const int RhvErvFuuXdDJDUeYvTQgGAkTxBi = 0;

			internal const int JVwODgkFrwFtiCqkcWmgOhDCpBH = 1;

			internal const int FnTrNPwYGZmWsECerDmDKvFdkOrB = 2;

			public Axis xAxis => mqLOUmOxEQDrMnAgTyphyrVuicA<Axis>(0);

			public Axis yAxis => mqLOUmOxEQDrMnAgTyphyrVuicA<Axis>(1);

			public virtual Vector2 value => new Vector2(mqLOUmOxEQDrMnAgTyphyrVuicA<Axis>(0).value, mqLOUmOxEQDrMnAgTyphyrVuicA<Axis>(1).value);

			public virtual Vector2 valueRaw => new Vector2(mqLOUmOxEQDrMnAgTyphyrVuicA<Axis>(0).valueRaw, mqLOUmOxEQDrMnAgTyphyrVuicA<Axis>(1).valueRaw);

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

				internal override Element MYVETqWFLwGNVKSdsAtynZHYNMgl(PlayerController P_0)
				{
					return new MouseAxis2D(P_0, this);
				}
			}

			public new MouseAxis xAxis => mqLOUmOxEQDrMnAgTyphyrVuicA<MouseAxis>(0);

			public new MouseAxis yAxis => mqLOUmOxEQDrMnAgTyphyrVuicA<MouseAxis>(1);

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
				internal override Element MYVETqWFLwGNVKSdsAtynZHYNMgl(PlayerController P_0)
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

				internal override Element MYVETqWFLwGNVKSdsAtynZHYNMgl(PlayerController P_0)
				{
					return new MouseWheel(P_0, this);
				}
			}

			public new MouseWheelAxis xAxis => mqLOUmOxEQDrMnAgTyphyrVuicA<MouseWheelAxis>(0);

			public new MouseWheelAxis yAxis => mqLOUmOxEQDrMnAgTyphyrVuicA<MouseWheelAxis>(1);

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

				internal override Element MYVETqWFLwGNVKSdsAtynZHYNMgl(PlayerController P_0)
				{
					return new MouseWheelAxis(P_0, this);
				}
			}

			[CustomObfuscation(rename = false)]
			internal const float defaultRepeatRate = 4f;

			[CustomObfuscation(rename = false)]
			internal new const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Relative;

			private const float nZkReHmLmVKvcOpSpEXRGAyizSSd = 0.01f;

			private float JDjArhcbCWvKxOGLfWqSVlUqLWoa = 0.25f;

			private double vpIrJylhiwmztScXcajKThZiQWz;

			private float rDXFGACXzNvmEuFurHYAqqwyQzh;

			public float repeatRate
			{
				get
				{
					if (JDjArhcbCWvKxOGLfWqSVlUqLWoa == 0f)
					{
						return 0f;
					}
					return 1f / JDjArhcbCWvKxOGLfWqSVlUqLWoa;
				}
				set
				{
					if (value < 0f)
					{
						value = 0f;
					}
					if (value == 0f)
					{
						JDjArhcbCWvKxOGLfWqSVlUqLWoa = 0f;
					}
					else
					{
						JDjArhcbCWvKxOGLfWqSVlUqLWoa = 1f / value;
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
					return rDXFGACXzNvmEuFurHYAqqwyQzh;
				}
			}

			internal MouseWheelAxis(PlayerController parent, Definition definition)
				: base(parent, definition)
			{
				repeatRate = definition.repeatRate;
			}

			internal override void iAnBBfDdWbgOiFHwNWqxFDtiXzYA()
			{
				base.iAnBBfDdWbgOiFHwNWqxFDtiXzYA();
				if (base.selfAndParentEnabled)
				{
					rDXFGACXzNvmEuFurHYAqqwyQzh = zGETwglgGGcyIhtFhFYMMEYAYVe();
				}
			}

			protected override void EnabledStateChanged(bool state)
			{
				base.EnabledStateChanged(state);
				if (!state)
				{
					VcHhfbFqwxAmqhwBHKVJpDjlfufe();
				}
			}

			private float zGETwglgGGcyIhtFhFYMMEYAYVe()
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
					if (!flag && ReInput.unscaledTime < vpIrJylhiwmztScXcajKThZiQWz + (double)JDjArhcbCWvKxOGLfWqSVlUqLWoa)
					{
						return 0f;
					}
					if (Mathf.Abs(num) <= 0.01f)
					{
						return 0f;
					}
					num = Mathf.Sign(num);
					num *= base.absoluteToRelativeSensitivity;
					vpIrJylhiwmztScXcajKThZiQWz = ReInput.unscaledTime;
					break;
				}
				}
				return num;
			}

			private void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
			{
				rDXFGACXzNvmEuFurHYAqqwyQzh = 0f;
				vpIrJylhiwmztScXcajKThZiQWz = 0.0;
			}
		}

		internal readonly int VumWnlylMgxSbyJcluXptXvaaZa;

		private bool fnEBjitvkHhPtXTzRLmBYpIxFbt;

		private int EpFfrTuakcvBKacoggaztTmGfrG;

		private readonly AList<Element> omxIKEAXItSjJrzFPUwpagFQPsi;

		private readonly AList<Button> BSdobvxzcvULrRIsWxFTPPpGtUR;

		private readonly AList<Axis> rEwCUWdrnAvHNmyWPMTQEZZqEeEa;

		private readonly ReadOnlyCollection<Element> WOxVRRtZDKwuVNgdENoHiNyWQgT;

		private readonly ReadOnlyCollection<Button> uHtwIoxVsZKiaojHBDRKZOEjbsjH;

		private readonly ReadOnlyCollection<Axis> zpHkpilrcetqGYInYjsIElKteuN;

		private readonly List<Element.imqfEZJRMdXxpAriWeReLlYAEOKf> ACbfAhmYPlprmVLUQrYtRqgYWdc;

		private Action<int, bool> mIxrLaFrrwnGJTCxooboCpMCYTF;

		private Action<int, float> HlcQcPamEeQYUXnCttxpkbIRLGe;

		private Action<bool> tGjExmrsAcHOmVrgLTgCsqJPOrA;

		public bool enabled
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return false;
				}
				return fnEBjitvkHhPtXTzRLmBYpIxFbt;
			}
			set
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				}
				else
				{
					if (fnEBjitvkHhPtXTzRLmBYpIxFbt == value)
					{
						return;
					}
					if (!value)
					{
						ClearVars();
					}
					fnEBjitvkHhPtXTzRLmBYpIxFbt = value;
					for (int i = 0; i < omxIKEAXItSjJrzFPUwpagFQPsi._count; i++)
					{
						omxIKEAXItSjJrzFPUwpagFQPsi[i].enabled = value;
					}
					if (tGjExmrsAcHOmVrgLTgCsqJPOrA != null)
					{
						try
						{
							tGjExmrsAcHOmVrgLTgCsqJPOrA(value);
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
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return -1;
				}
				return EpFfrTuakcvBKacoggaztTmGfrG;
			}
			set
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				}
				else if (EpFfrTuakcvBKacoggaztTmGfrG != value)
				{
					EpFfrTuakcvBKacoggaztTmGfrG = value;
					ClearVars();
				}
			}
		}

		public IList<Button> buttons
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return null;
				}
				return uHtwIoxVsZKiaojHBDRKZOEjbsjH;
			}
		}

		public IList<Axis> axes
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return null;
				}
				return zpHkpilrcetqGYInYjsIElKteuN;
			}
		}

		public IList<Element> elements
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return null;
				}
				return WOxVRRtZDKwuVNgdENoHiNyWQgT;
			}
		}

		public int buttonCount
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return 0;
				}
				if (BSdobvxzcvULrRIsWxFTPPpGtUR == null)
				{
					return 0;
				}
				return BSdobvxzcvULrRIsWxFTPPpGtUR._count;
			}
		}

		public int axisCount
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return 0;
				}
				if (rEwCUWdrnAvHNmyWPMTQEZZqEeEa == null)
				{
					return 0;
				}
				return rEwCUWdrnAvHNmyWPMTQEZZqEeEa._count;
			}
		}

		public int elementCount
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return 0;
				}
				if (omxIKEAXItSjJrzFPUwpagFQPsi == null)
				{
					return 0;
				}
				return omxIKEAXItSjJrzFPUwpagFQPsi._count;
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
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				}
				else
				{
					mIxrLaFrrwnGJTCxooboCpMCYTF = (Action<int, bool>)Delegate.Combine(mIxrLaFrrwnGJTCxooboCpMCYTF, value);
				}
			}
			remove
			{
				mIxrLaFrrwnGJTCxooboCpMCYTF = (Action<int, bool>)Delegate.Remove(mIxrLaFrrwnGJTCxooboCpMCYTF, value);
			}
		}

		public event Action<int, float> AxisValueChangedEvent
		{
			add
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				}
				else
				{
					HlcQcPamEeQYUXnCttxpkbIRLGe = (Action<int, float>)Delegate.Combine(HlcQcPamEeQYUXnCttxpkbIRLGe, value);
				}
			}
			remove
			{
				HlcQcPamEeQYUXnCttxpkbIRLGe = (Action<int, float>)Delegate.Remove(HlcQcPamEeQYUXnCttxpkbIRLGe, value);
			}
		}

		public event Action<bool> EnabledStateChangedEvent
		{
			add
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				}
				else
				{
					tGjExmrsAcHOmVrgLTgCsqJPOrA = (Action<bool>)Delegate.Combine(tGjExmrsAcHOmVrgLTgCsqJPOrA, value);
				}
			}
			remove
			{
				tGjExmrsAcHOmVrgLTgCsqJPOrA = (Action<bool>)Delegate.Remove(tGjExmrsAcHOmVrgLTgCsqJPOrA, value);
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
			VumWnlylMgxSbyJcluXptXvaaZa = ReInput._id;
			EpFfrTuakcvBKacoggaztTmGfrG = definition.playerId;
			fnEBjitvkHhPtXTzRLmBYpIxFbt = definition.enabled;
			List<Element> list = new List<Element>();
			List<Element> list2 = new List<Element>();
			List<Button> list3 = new List<Button>();
			List<Axis> list4 = new List<Axis>();
			foreach (Element.Definition element in definition.elements)
			{
				SSjwBZRYcJqbFyjnlHATtvRHxFM(element.MYVETqWFLwGNVKSdsAtynZHYNMgl(this), list, list2, list3, list4);
			}
			list.AddRange(list2);
			omxIKEAXItSjJrzFPUwpagFQPsi = new AList<Element>(list);
			BSdobvxzcvULrRIsWxFTPPpGtUR = new AList<Button>(list3);
			rEwCUWdrnAvHNmyWPMTQEZZqEeEa = new AList<Axis>(list4);
			WOxVRRtZDKwuVNgdENoHiNyWQgT = new ReadOnlyCollection<Element>(omxIKEAXItSjJrzFPUwpagFQPsi);
			uHtwIoxVsZKiaojHBDRKZOEjbsjH = new ReadOnlyCollection<Button>(BSdobvxzcvULrRIsWxFTPPpGtUR);
			zpHkpilrcetqGYInYjsIElKteuN = new ReadOnlyCollection<Axis>(rEwCUWdrnAvHNmyWPMTQEZZqEeEa);
			ACbfAhmYPlprmVLUQrYtRqgYWdc = new List<Element.imqfEZJRMdXxpAriWeReLlYAEOKf>();
			ReInput.UpdateEndedEvent += GoDzCZSWyCxHOoFNmmNBncoqcAY;
		}

		~PlayerController()
		{
			ReInput.UpdateEndedEvent -= GoDzCZSWyCxHOoFNmmNBncoqcAY;
		}

		public bool GetButton(int index)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if ((uint)index >= (uint)BSdobvxzcvULrRIsWxFTPPpGtUR._count)
			{
				return false;
			}
			return BSdobvxzcvULrRIsWxFTPPpGtUR[index].value;
		}

		public bool GetButtonDown(int index)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if ((uint)index >= (uint)BSdobvxzcvULrRIsWxFTPPpGtUR._count)
			{
				return false;
			}
			return BSdobvxzcvULrRIsWxFTPPpGtUR[index].justPressed;
		}

		public bool GetButtonUp(int index)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if ((uint)index >= (uint)BSdobvxzcvULrRIsWxFTPPpGtUR._count)
			{
				return false;
			}
			return BSdobvxzcvULrRIsWxFTPPpGtUR[index].justReleased;
		}

		public float GetAxis(int index)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0f;
			}
			if ((uint)index >= (uint)rEwCUWdrnAvHNmyWPMTQEZZqEeEa._count)
			{
				return 0f;
			}
			return rEwCUWdrnAvHNmyWPMTQEZZqEeEa[index].value;
		}

		public float GetAxisRaw(int index)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0f;
			}
			if ((uint)index >= (uint)rEwCUWdrnAvHNmyWPMTQEZZqEeEa._count)
			{
				return 0f;
			}
			return rEwCUWdrnAvHNmyWPMTQEZZqEeEa[index].valueRaw;
		}

		public Element GetElement(int index)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			if ((uint)index >= (uint)rEwCUWdrnAvHNmyWPMTQEZZqEeEa._count)
			{
				return null;
			}
			return omxIKEAXItSjJrzFPUwpagFQPsi[index];
		}

		public T GetElement<T>(int index) where T : Element
		{
			return GetElement(index) as T;
		}

		private void GoDzCZSWyCxHOoFNmmNBncoqcAY(UpdateLoopType P_0)
		{
			Update(P_0);
			UpdateFinished();
		}

		protected virtual bool Update(UpdateLoopType updateLoop)
		{
			if (!fnEBjitvkHhPtXTzRLmBYpIxFbt)
			{
				return false;
			}
			bool flag = HlcQcPamEeQYUXnCttxpkbIRLGe != null;
			bool flag2 = mIxrLaFrrwnGJTCxooboCpMCYTF != null;
			for (int i = 0; i < omxIKEAXItSjJrzFPUwpagFQPsi._count; i++)
			{
				float num = 0f;
				if (flag && omxIKEAXItSjJrzFPUwpagFQPsi[i] is Axis)
				{
					Axis axis = omxIKEAXItSjJrzFPUwpagFQPsi[i] as Axis;
					num = ((axis.coordinateMode != AxisCoordinateMode.Absolute) ? 0f : axis.value);
				}
				omxIKEAXItSjJrzFPUwpagFQPsi[i].iAnBBfDdWbgOiFHwNWqxFDtiXzYA();
				if (flag2 && omxIKEAXItSjJrzFPUwpagFQPsi[i] is Button)
				{
					Button button = omxIKEAXItSjJrzFPUwpagFQPsi[i] as Button;
					if (button.justPressed && button.value)
					{
						ACbfAhmYPlprmVLUQrYtRqgYWdc.Add(new Element.imqfEZJRMdXxpAriWeReLlYAEOKf(ControllerElementType.Button, i, 1f));
					}
					else if (button.justReleased && !button.value)
					{
						ACbfAhmYPlprmVLUQrYtRqgYWdc.Add(new Element.imqfEZJRMdXxpAriWeReLlYAEOKf(ControllerElementType.Button, i, 0f));
					}
				}
				else if (flag && omxIKEAXItSjJrzFPUwpagFQPsi[i] is Axis)
				{
					ACbfAhmYPlprmVLUQrYtRqgYWdc.Add(new Element.imqfEZJRMdXxpAriWeReLlYAEOKf(ControllerElementType.Axis, i, (omxIKEAXItSjJrzFPUwpagFQPsi[i] as Axis).value - num));
				}
			}
			return true;
		}

		protected virtual void UpdateFinished()
		{
			int count = ACbfAhmYPlprmVLUQrYtRqgYWdc.Count;
			if (count <= 0)
			{
				return;
			}
			for (int i = 0; i < count; i++)
			{
				Element.imqfEZJRMdXxpAriWeReLlYAEOKf imqfEZJRMdXxpAriWeReLlYAEOKf = ACbfAhmYPlprmVLUQrYtRqgYWdc[i];
				if (imqfEZJRMdXxpAriWeReLlYAEOKf.LSmTRdvHuagVChPSPaniDTWrvDKL == ControllerElementType.Button)
				{
					try
					{
						mIxrLaFrrwnGJTCxooboCpMCYTF(imqfEZJRMdXxpAriWeReLlYAEOKf.ACGGwGOBHafSQSEmbVqxDttpurC, (imqfEZJRMdXxpAriWeReLlYAEOKf.lvXCTCWOhrCtuFDbbEqyqyUVPhp > 0f) ? true : false);
					}
					catch (Exception ex)
					{
						Logger.LogError("An exception occurred in a listener of ButtonStateChangedEvent. This means an exception was thrown by your code.\n" + ex);
					}
				}
				else if (imqfEZJRMdXxpAriWeReLlYAEOKf.LSmTRdvHuagVChPSPaniDTWrvDKL == ControllerElementType.Axis)
				{
					try
					{
						HlcQcPamEeQYUXnCttxpkbIRLGe(imqfEZJRMdXxpAriWeReLlYAEOKf.ACGGwGOBHafSQSEmbVqxDttpurC, imqfEZJRMdXxpAriWeReLlYAEOKf.lvXCTCWOhrCtuFDbbEqyqyUVPhp);
					}
					catch (Exception ex2)
					{
						Logger.LogError("An exception occurred in a listener of AxisValueChangedEvent. This means an exception was thrown by your code.\n" + ex2);
					}
				}
			}
			ACbfAhmYPlprmVLUQrYtRqgYWdc.Clear();
		}

		protected virtual void ClearVars()
		{
			ACbfAhmYPlprmVLUQrYtRqgYWdc.Clear();
		}

		internal void SSjwBZRYcJqbFyjnlHATtvRHxFM(Element P_0)
		{
			if (P_0 != null)
			{
				if (P_0 is Axis)
				{
					rEwCUWdrnAvHNmyWPMTQEZZqEeEa.Add(P_0 as Axis);
				}
				else if (P_0 is Button)
				{
					BSdobvxzcvULrRIsWxFTPPpGtUR.Add(P_0 as Button);
				}
				omxIKEAXItSjJrzFPUwpagFQPsi.Add(P_0);
			}
		}

		private void SSjwBZRYcJqbFyjnlHATtvRHxFM(Element P_0, List<Element> P_1, List<Element> P_2, List<Button> P_3, List<Axis> P_4)
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
					(P_0 as CompoundElement).zogrqFEhVuhiXlPlqfJqIPTccqer(list);
					for (int i = 0; i < list.Count; i++)
					{
						SSjwBZRYcJqbFyjnlHATtvRHxFM(list[i], P_1, P_2, P_3, P_4);
					}
				}
				P_2.Add(P_0);
			}
			else
			{
				Logger.LogWarning("Unknown Element type encountered: " + P_0.GetType());
			}
		}

		internal static int IBJFxwhgESZPVuIABbZHTfQgjyg<T>(IList<T> P_0, Predicate<T> P_1, int P_2) where T : Element
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
