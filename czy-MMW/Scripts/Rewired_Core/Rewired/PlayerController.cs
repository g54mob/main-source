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

				internal virtual Element bjZQOwccTlMQoAGjukckxOXRbXqv(PlayerController P_0)
				{
					return new Axis(P_0, this);
				}
			}

			internal const float nosFwrBWHqkcJSXHsGuTiptfwlGU = 1f;

			[CustomObfuscation(rename = false)]
			internal const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Absolute;

			private float PJuIddwHJOMtQfmjsFrReMwmgyAe = 1f;

			private AxisCoordinateMode yiEELSOOmSXPwJCuOHoHLhvebPOh;

			public float absoluteToRelativeSensitivity
			{
				get
				{
					return PJuIddwHJOMtQfmjsFrReMwmgyAe;
				}
				set
				{
					if (value < 0f)
					{
						value = 0f;
					}
					PJuIddwHJOMtQfmjsFrReMwmgyAe = value;
				}
			}

			public AxisCoordinateMode coordinateMode => yiEELSOOmSXPwJCuOHoHLhvebPOh;

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
						if (yiEELSOOmSXPwJCuOHoHLhvebPOh == AxisCoordinateMode.Absolute)
						{
							return 0f;
						}
						break;
					case AxisCoordinateMode.Absolute:
						if (yiEELSOOmSXPwJCuOHoHLhvebPOh == AxisCoordinateMode.Relative)
						{
							num *= (float)ReInput.unscaledDeltaTime * PJuIddwHJOMtQfmjsFrReMwmgyAe;
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
				PJuIddwHJOMtQfmjsFrReMwmgyAe = P_1.absoluteToRelativeSensitivity;
				yiEELSOOmSXPwJCuOHoHLhvebPOh = P_1.coordinateMode;
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

				internal virtual Element rriSAmgeVxoEkwGjiQDYcVIUVgXs(PlayerController P_0)
				{
					return new MouseAxis(P_0, this);
				}
			}

			[CustomObfuscation(rename = false)]
			internal new const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Relative;

			[CustomObfuscation(rename = false)]
			internal const float defaultAbsoluteToRelativeSensitivity = 600f;

			float Axis.value
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
				private Axis.Definition PlSDGyRhazpMvIxQWGdAUligFdyq;

				private Axis.Definition oHBSHIbjjSvXyohBHllzUQyajyPe;

				public Axis.Definition xAxis
				{
					get
					{
						return PlSDGyRhazpMvIxQWGdAUligFdyq;
					}
					set
					{
						PlSDGyRhazpMvIxQWGdAUligFdyq = value;
					}
				}

				public Axis.Definition yAxis
				{
					get
					{
						return oHBSHIbjjSvXyohBHllzUQyajyPe;
					}
					set
					{
						oHBSHIbjjSvXyohBHllzUQyajyPe = value;
					}
				}

				internal virtual Element foIBkIdXBiRXZbIUNHFUJdAWdJUm(PlayerController P_0)
				{
					return new Axis2D(P_0, this);
				}
			}

			internal const int gcbmmCUMRqfwkiVltzZteaooHyEx = 0;

			internal const int dPrCsvDdBEEsSGpwUzHaVUaYeIQR = 1;

			internal const int sLEJubMGJicvmcDPWbSdJNUCAonNA = 2;

			public Axis xAxis => ZQOSSeClMFsaBkKDOcYJRuEEJSwT<Axis>(0);

			public Axis yAxis => ZQOSSeClMFsaBkKDOcYJRuEEJSwT<Axis>(1);

			public virtual Vector2 value => new Vector2(ZQOSSeClMFsaBkKDOcYJRuEEJSwT<Axis>(0).value, ZQOSSeClMFsaBkKDOcYJRuEEJSwT<Axis>(1).value);

			public virtual Vector2 valueRaw => new Vector2(ZQOSSeClMFsaBkKDOcYJRuEEJSwT<Axis>(0).valueRaw, ZQOSSeClMFsaBkKDOcYJRuEEJSwT<Axis>(1).valueRaw);

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

				internal virtual Element bROLHBEqFwAZNSHcnAqbJZNRfULx(PlayerController P_0)
				{
					return new MouseAxis2D(P_0, this);
				}
			}

			public new MouseAxis xAxis => ZQOSSeClMFsaBkKDOcYJRuEEJSwT<MouseAxis>(0);

			public new MouseAxis yAxis => ZQOSSeClMFsaBkKDOcYJRuEEJSwT<MouseAxis>(1);

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
				internal virtual Element UDDofOKLZwsabOVUoriWUkTbYNuG(PlayerController P_0)
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

			private readonly List<Element> NRSWqLITUvVRQpQIKrYAOMgcaOGl;

			internal int ZphiXBHEQsvKORxclmPPrtUjbjjN => NRSWqLITUvVRQpQIKrYAOMgcaOGl.Count;

			internal CompoundElement(PlayerController P_0, Definition P_1, Element.Definition[] P_2)
				: base(P_0, P_1)
			{
				NRSWqLITUvVRQpQIKrYAOMgcaOGl = new List<Element>();
				if (P_2 == null)
				{
					return;
				}
				for (int i = 0; i < P_2.Length; i++)
				{
					if (P_2[i] != null)
					{
						dkfjsbgYGxUEJxKMvFxwHbDnlskY(P_2[i].nAqVywOcCRERHbAEqQAackSXtzAM(P_0));
					}
				}
			}

			internal _0001 ZQOSSeClMFsaBkKDOcYJRuEEJSwT<_0001>(int P_0) where _0001 : Element
			{
				if ((uint)P_0 >= (uint)NRSWqLITUvVRQpQIKrYAOMgcaOGl.Count)
				{
					return null;
				}
				return NRSWqLITUvVRQpQIKrYAOMgcaOGl[P_0] as _0001;
			}

			internal void EXxtCmRnbwFfxYFwmBHADOWBRKAb(List<Element> P_0)
			{
				for (int i = 0; i < NRSWqLITUvVRQpQIKrYAOMgcaOGl.Count; i++)
				{
					if (NRSWqLITUvVRQpQIKrYAOMgcaOGl[i] is CompoundElement)
					{
						(NRSWqLITUvVRQpQIKrYAOMgcaOGl[i] as CompoundElement).EXxtCmRnbwFfxYFwmBHADOWBRKAb(P_0);
					}
					else
					{
						P_0.Add(NRSWqLITUvVRQpQIKrYAOMgcaOGl[i]);
					}
				}
			}

			internal void dkfjsbgYGxUEJxKMvFxwHbDnlskY(Element P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("element");
				}
				NRSWqLITUvVRQpQIKrYAOMgcaOGl.Add(P_0);
				P_0.RlYkHLUTywqWzOeZDjmVjgzZNxit = true;
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

				internal abstract Element nAqVywOcCRERHbAEqQAackSXtzAM(PlayerController P_0);
			}

			internal struct SthchbSSHqgApFtODpjtqWAlNXwfA
			{
				public ControllerElementType WzGkrVHbIxzEwZyNPkmrLeSUDnaq;

				public int feXSNvtCACzeTJnuXIwzgsfyRCWy;

				public float vHxfQimFsOcGTgALYnVwVJnADGyKA;

				public SthchbSSHqgApFtODpjtqWAlNXwfA(ControllerElementType P_0, int P_1, float P_2)
				{
					WzGkrVHbIxzEwZyNPkmrLeSUDnaq = P_0;
					feXSNvtCACzeTJnuXIwzgsfyRCWy = P_1;
					vHxfQimFsOcGTgALYnVwVJnADGyKA = P_2;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const bool defaultEnabled = true;

			private readonly PlayerController zJoNiPAhvVblBClwKZHiWkQtgiqD;

			private bool CQMgfJSPvOAZbOlXYJjFCEVQIBPF;

			private bool LQgVuhnXACdZxXaWGnxrtDMvocVo = true;

			private string EidIcklEkbpxVvmfDttcZbclAboEA;

			private static int[] NFabJMcHiRfIuuNlZJktUMUqLjBrA;

			private static int[] LcbthBurUoAANkpCYHDvjlGAvmDu;

			protected Player player
			{
				get
				{
					if (!ReInput.isReady)
					{
						return null;
					}
					return ReInput.players.GetPlayer(zJoNiPAhvVblBClwKZHiWkQtgiqD.IAJTbCcWhXlZkIJnVLpEkJlxRpzk);
				}
			}

			protected bool selfAndParentEnabled
			{
				get
				{
					if (LQgVuhnXACdZxXaWGnxrtDMvocVo)
					{
						return zJoNiPAhvVblBClwKZHiWkQtgiqD.ikpfoolsWNeSJgzlqkUjpLJVebBib;
					}
					return false;
				}
			}

			internal bool RlYkHLUTywqWzOeZDjmVjgzZNxit
			{
				get
				{
					return CQMgfJSPvOAZbOlXYJjFCEVQIBPF;
				}
				set
				{
					CQMgfJSPvOAZbOlXYJjFCEVQIBPF = true;
				}
			}

			public bool enabled
			{
				get
				{
					return LQgVuhnXACdZxXaWGnxrtDMvocVo;
				}
				set
				{
					if (LQgVuhnXACdZxXaWGnxrtDMvocVo != value)
					{
						LQgVuhnXACdZxXaWGnxrtDMvocVo = value;
						EnabledStateChanged(value);
					}
				}
			}

			public string name
			{
				get
				{
					return EidIcklEkbpxVvmfDttcZbclAboEA;
				}
				set
				{
					EidIcklEkbpxVvmfDttcZbclAboEA = value;
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
				zJoNiPAhvVblBClwKZHiWkQtgiqD = P_0;
				LQgVuhnXACdZxXaWGnxrtDMvocVo = P_1.enabled;
			}

			internal virtual void FhmguMVRiyRNQSlfwxvzMBzJhvsi()
			{
			}

			protected virtual void EnabledStateChanged(bool state)
			{
			}

			[CustomObfuscation(rename = false)]
			internal static bool IsTypeWithSource(Type type)
			{
				if (NFabJMcHiRfIuuNlZJktUMUqLjBrA == null)
				{
					NFabJMcHiRfIuuNlZJktUMUqLjBrA = (int[])Enum.GetValues(typeof(TypeWithSource));
				}
				return ArrayTools.Contains(NFabJMcHiRfIuuNlZJktUMUqLjBrA, (int)type);
			}

			[CustomObfuscation(rename = false)]
			internal static bool IsCompoundType(Type type)
			{
				if (LcbthBurUoAANkpCYHDvjlGAvmDu == null)
				{
					LcbthBurUoAANkpCYHDvjlGAvmDu = (int[])Enum.GetValues(typeof(CompoundTypes));
				}
				return ArrayTools.Contains(LcbthBurUoAANkpCYHDvjlGAvmDu, (int)type);
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
				private int cIwvdqeKufSftZFGfbWMyamkjAhC;

				public int actionId
				{
					get
					{
						return cIwvdqeKufSftZFGfbWMyamkjAhC;
					}
					set
					{
						cIwvdqeKufSftZFGfbWMyamkjAhC = value;
					}
				}

				public string actionName
				{
					get
					{
						if (!ReInput.isReady || cIwvdqeKufSftZFGfbWMyamkjAhC < 0)
						{
							return null;
						}
						return ReInput.mapping.GetAction(cIwvdqeKufSftZFGfbWMyamkjAhC)?.name;
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
							cIwvdqeKufSftZFGfbWMyamkjAhC = -1;
						}
						else
						{
							cIwvdqeKufSftZFGfbWMyamkjAhC = action.id;
						}
					}
				}

				public Definition()
				{
					cIwvdqeKufSftZFGfbWMyamkjAhC = -1;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const int defaultActionId = -1;

			private int BhbtEBxDkfSLYdPQEtfjLNYpFBRw = -1;

			public int actionId
			{
				get
				{
					return BhbtEBxDkfSLYdPQEtfjLNYpFBRw;
				}
				set
				{
					BhbtEBxDkfSLYdPQEtfjLNYpFBRw = value;
				}
			}

			public string actionName
			{
				get
				{
					if (!ReInput.isReady || BhbtEBxDkfSLYdPQEtfjLNYpFBRw < 0)
					{
						return null;
					}
					return ReInput.mapping.GetAction(BhbtEBxDkfSLYdPQEtfjLNYpFBRw)?.name;
				}
				set
				{
					if (ReInput.isReady)
					{
						InputAction action = ReInput.mapping.GetAction(value);
						if (action == null)
						{
							BhbtEBxDkfSLYdPQEtfjLNYpFBRw = -1;
						}
						else
						{
							BhbtEBxDkfSLYdPQEtfjLNYpFBRw = action.id;
						}
					}
				}
			}

			internal ElementWithSource(PlayerController P_0, Definition P_1)
				: base(P_0, P_1)
			{
				BhbtEBxDkfSLYdPQEtfjLNYpFBRw = P_1.actionId;
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

				internal virtual Element nSQNprvhAdyJAgWcKuNvkhoNHazEA(PlayerController P_0)
				{
					return new MouseWheel(P_0, this);
				}
			}

			public new MouseWheelAxis xAxis => ZQOSSeClMFsaBkKDOcYJRuEEJSwT<MouseWheelAxis>(0);

			public new MouseWheelAxis yAxis => ZQOSSeClMFsaBkKDOcYJRuEEJSwT<MouseWheelAxis>(1);

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

				internal virtual Element TFOhBNRTSdpCmxlAngbjITxWcJaoA(PlayerController P_0)
				{
					return new MouseWheelAxis(P_0, this);
				}
			}

			[CustomObfuscation(rename = false)]
			internal const float defaultRepeatRate = 4f;

			[CustomObfuscation(rename = false)]
			internal new const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Relative;

			private const float cSdHbCoDMnmWLYaDsTRcrkLccTXGA = 0.01f;

			private float fYMOHanFipcbdJWncBgusABlhmhFb = 0.25f;

			private double GISFtwgJfoaVySUvxJwNtMydfqLt;

			private float VIwCXyUwMlfmOYKPbjxCfMTEgYYo;

			public float repeatRate
			{
				get
				{
					if (fYMOHanFipcbdJWncBgusABlhmhFb == 0f)
					{
						return 0f;
					}
					return 1f / fYMOHanFipcbdJWncBgusABlhmhFb;
				}
				set
				{
					if (value < 0f)
					{
						value = 0f;
					}
					if (value == 0f)
					{
						fYMOHanFipcbdJWncBgusABlhmhFb = 0f;
					}
					else
					{
						fYMOHanFipcbdJWncBgusABlhmhFb = 1f / value;
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
					return VIwCXyUwMlfmOYKPbjxCfMTEgYYo;
				}
			}

			internal MouseWheelAxis(PlayerController P_0, Definition P_1)
				: base(P_0, P_1)
			{
				repeatRate = P_1.repeatRate;
			}

			internal void HSWqekxAmRzlNkDReMsWJFkaVeNL()
			{
				base.FhmguMVRiyRNQSlfwxvzMBzJhvsi();
				if (base.selfAndParentEnabled)
				{
					VIwCXyUwMlfmOYKPbjxCfMTEgYYo = BTDgCwjrQcXJcIBFElbhZVySurAp();
				}
			}

			protected override void EnabledStateChanged(bool state)
			{
				base.EnabledStateChanged(state);
				if (!state)
				{
					aCpzCrRgSqEuAgTDFnOGyNGMbTybb();
				}
			}

			private float BTDgCwjrQcXJcIBFElbhZVySurAp()
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
					if (!flag && ReInput.unscaledTime < GISFtwgJfoaVySUvxJwNtMydfqLt + (double)fYMOHanFipcbdJWncBgusABlhmhFb)
					{
						return 0f;
					}
					if (Mathf.Abs(num) <= 0.01f)
					{
						return 0f;
					}
					num = Mathf.Sign(num);
					num *= base.absoluteToRelativeSensitivity;
					GISFtwgJfoaVySUvxJwNtMydfqLt = ReInput.unscaledTime;
					break;
				}
				}
				return num;
			}

			private void aCpzCrRgSqEuAgTDFnOGyNGMbTybb()
			{
				VIwCXyUwMlfmOYKPbjxCfMTEgYYo = 0f;
				GISFtwgJfoaVySUvxJwNtMydfqLt = 0.0;
			}
		}

		internal readonly int DGnEkWBJwKSeEfmWAgVsYGPpHltFA;

		private bool ikpfoolsWNeSJgzlqkUjpLJVebBib;

		private int IAJTbCcWhXlZkIJnVLpEkJlxRpzk;

		private readonly AList<Element> hcumyDKqnEdXvKWcMzOEDwnckWFh;

		private readonly AList<Button> tRcUdmrClKUQLqNydcmoAsMGuQkR;

		private readonly AList<Axis> OAIOibSBbHBHMaJaLxCIttxIyLaNA;

		private readonly ReadOnlyCollection<Element> rhvcqzVShdwhCEWkaqpmELpYnxss;

		private readonly ReadOnlyCollection<Button> rExfAFrDkiRyzUKqxAwvBhTeAVqe;

		private readonly ReadOnlyCollection<Axis> VJBvBGQQdYoNjaFDfydjqtyIaWxN;

		private readonly List<Element.SthchbSSHqgApFtODpjtqWAlNXwfA> eAWebIjMHwmxbhsKDydZYfIDcbgHA;

		private Action<int, bool> ZsHFBXkNFdwwdThljWECbwxfftkGA;

		private Action<int, float> cJkvDaRAyzHJOYqkZfsRZWWdgBVc;

		private Action<bool> fdbZmSaQkucZCfogfYaEuLFkmevC;

		bool IPlayerController.enabled
		{
			get
			{
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
					return false;
				}
				return ikpfoolsWNeSJgzlqkUjpLJVebBib;
			}
			set
			{
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
				}
				else
				{
					if (ikpfoolsWNeSJgzlqkUjpLJVebBib == value)
					{
						return;
					}
					if (!value)
					{
						ClearVars();
					}
					ikpfoolsWNeSJgzlqkUjpLJVebBib = value;
					for (int i = 0; i < hcumyDKqnEdXvKWcMzOEDwnckWFh._count; i++)
					{
						hcumyDKqnEdXvKWcMzOEDwnckWFh[i].enabled = value;
					}
					if (fdbZmSaQkucZCfogfYaEuLFkmevC != null)
					{
						try
						{
							fdbZmSaQkucZCfogfYaEuLFkmevC(value);
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
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
					return -1;
				}
				return IAJTbCcWhXlZkIJnVLpEkJlxRpzk;
			}
			set
			{
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
				}
				else if (IAJTbCcWhXlZkIJnVLpEkJlxRpzk != value)
				{
					IAJTbCcWhXlZkIJnVLpEkJlxRpzk = value;
					ClearVars();
				}
			}
		}

		IList<Button> IPlayerController.buttons
		{
			get
			{
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
					return null;
				}
				return rExfAFrDkiRyzUKqxAwvBhTeAVqe;
			}
		}

		IList<Axis> IPlayerController.axes
		{
			get
			{
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
					return null;
				}
				return VJBvBGQQdYoNjaFDfydjqtyIaWxN;
			}
		}

		IList<Element> IPlayerController.elements
		{
			get
			{
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
					return null;
				}
				return rhvcqzVShdwhCEWkaqpmELpYnxss;
			}
		}

		int IPlayerController.buttonCount
		{
			get
			{
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
					return 0;
				}
				if (tRcUdmrClKUQLqNydcmoAsMGuQkR == null)
				{
					return 0;
				}
				return tRcUdmrClKUQLqNydcmoAsMGuQkR._count;
			}
		}

		int IPlayerController.axisCount
		{
			get
			{
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
					return 0;
				}
				if (OAIOibSBbHBHMaJaLxCIttxIyLaNA == null)
				{
					return 0;
				}
				return OAIOibSBbHBHMaJaLxCIttxIyLaNA._count;
			}
		}

		int IPlayerController.elementCount
		{
			get
			{
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
					return 0;
				}
				if (hcumyDKqnEdXvKWcMzOEDwnckWFh == null)
				{
					return 0;
				}
				return hcumyDKqnEdXvKWcMzOEDwnckWFh._count;
			}
		}

		internal Player DbfpgXxKeDTUSktfwyjEKpeOvbCI
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

		event Action<int, bool> IPlayerController.ButtonStateChangedEvent
		{
			add
			{
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
				}
				else
				{
					ZsHFBXkNFdwwdThljWECbwxfftkGA = (Action<int, bool>)Delegate.Combine(ZsHFBXkNFdwwdThljWECbwxfftkGA, value);
				}
			}
			remove
			{
				ZsHFBXkNFdwwdThljWECbwxfftkGA = (Action<int, bool>)Delegate.Remove(ZsHFBXkNFdwwdThljWECbwxfftkGA, value);
			}
		}

		event Action<int, float> IPlayerController.AxisValueChangedEvent
		{
			add
			{
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
				}
				else
				{
					cJkvDaRAyzHJOYqkZfsRZWWdgBVc = (Action<int, float>)Delegate.Combine(cJkvDaRAyzHJOYqkZfsRZWWdgBVc, value);
				}
			}
			remove
			{
				cJkvDaRAyzHJOYqkZfsRZWWdgBVc = (Action<int, float>)Delegate.Remove(cJkvDaRAyzHJOYqkZfsRZWWdgBVc, value);
			}
		}

		event Action<bool> IPlayerController.EnabledStateChangedEvent
		{
			add
			{
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
				}
				else
				{
					fdbZmSaQkucZCfogfYaEuLFkmevC = (Action<bool>)Delegate.Combine(fdbZmSaQkucZCfogfYaEuLFkmevC, value);
				}
			}
			remove
			{
				fdbZmSaQkucZCfogfYaEuLFkmevC = (Action<bool>)Delegate.Remove(fdbZmSaQkucZCfogfYaEuLFkmevC, value);
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
			DGnEkWBJwKSeEfmWAgVsYGPpHltFA = ReInput._id;
			IAJTbCcWhXlZkIJnVLpEkJlxRpzk = P_0.playerId;
			ikpfoolsWNeSJgzlqkUjpLJVebBib = P_0.enabled;
			List<Element> list = new List<Element>();
			List<Element> list2 = new List<Element>();
			List<Button> list3 = new List<Button>();
			List<Axis> list4 = new List<Axis>();
			foreach (Element.Definition element in P_0.elements)
			{
				BRPYbeuDvdHgrZyuONYAElXPYCWL(element.nAqVywOcCRERHbAEqQAackSXtzAM(this), list, list2, list3, list4);
			}
			list.AddRange(list2);
			hcumyDKqnEdXvKWcMzOEDwnckWFh = new AList<Element>(list);
			tRcUdmrClKUQLqNydcmoAsMGuQkR = new AList<Button>(list3);
			OAIOibSBbHBHMaJaLxCIttxIyLaNA = new AList<Axis>(list4);
			rhvcqzVShdwhCEWkaqpmELpYnxss = new ReadOnlyCollection<Element>(hcumyDKqnEdXvKWcMzOEDwnckWFh);
			rExfAFrDkiRyzUKqxAwvBhTeAVqe = new ReadOnlyCollection<Button>(tRcUdmrClKUQLqNydcmoAsMGuQkR);
			VJBvBGQQdYoNjaFDfydjqtyIaWxN = new ReadOnlyCollection<Axis>(OAIOibSBbHBHMaJaLxCIttxIyLaNA);
			eAWebIjMHwmxbhsKDydZYfIDcbgHA = new List<Element.SthchbSSHqgApFtODpjtqWAlNXwfA>();
			ReInput.UpdateEndedEvent += vNdJwvhesSiCvwTxzsnyeVIKRCWB;
		}

		~PlayerController()
		{
			ReInput.UpdateEndedEvent -= vNdJwvhesSiCvwTxzsnyeVIKRCWB;
		}

		public bool GetButton(int index)
		{
			if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
			{
				ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
				return false;
			}
			if ((uint)index >= (uint)tRcUdmrClKUQLqNydcmoAsMGuQkR._count)
			{
				return false;
			}
			return tRcUdmrClKUQLqNydcmoAsMGuQkR[index].value;
		}

		bool IPlayerController.GetButton(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetButton
			return this.GetButton(index);
		}

		public bool GetButtonDown(int index)
		{
			if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
			{
				ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
				return false;
			}
			if ((uint)index >= (uint)tRcUdmrClKUQLqNydcmoAsMGuQkR._count)
			{
				return false;
			}
			return tRcUdmrClKUQLqNydcmoAsMGuQkR[index].justPressed;
		}

		bool IPlayerController.GetButtonDown(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetButtonDown
			return this.GetButtonDown(index);
		}

		public bool GetButtonUp(int index)
		{
			if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
			{
				ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
				return false;
			}
			if ((uint)index >= (uint)tRcUdmrClKUQLqNydcmoAsMGuQkR._count)
			{
				return false;
			}
			return tRcUdmrClKUQLqNydcmoAsMGuQkR[index].justReleased;
		}

		bool IPlayerController.GetButtonUp(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetButtonUp
			return this.GetButtonUp(index);
		}

		public float GetAxis(int index)
		{
			if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
			{
				ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
				return 0f;
			}
			if ((uint)index >= (uint)OAIOibSBbHBHMaJaLxCIttxIyLaNA._count)
			{
				return 0f;
			}
			return OAIOibSBbHBHMaJaLxCIttxIyLaNA[index].value;
		}

		float IPlayerController.GetAxis(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetAxis
			return this.GetAxis(index);
		}

		public float GetAxisRaw(int index)
		{
			if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
			{
				ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
				return 0f;
			}
			if ((uint)index >= (uint)OAIOibSBbHBHMaJaLxCIttxIyLaNA._count)
			{
				return 0f;
			}
			return OAIOibSBbHBHMaJaLxCIttxIyLaNA[index].valueRaw;
		}

		float IPlayerController.GetAxisRaw(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetAxisRaw
			return this.GetAxisRaw(index);
		}

		public Element GetElement(int index)
		{
			if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
			{
				ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
				return null;
			}
			if ((uint)index >= (uint)OAIOibSBbHBHMaJaLxCIttxIyLaNA._count)
			{
				return null;
			}
			return hcumyDKqnEdXvKWcMzOEDwnckWFh[index];
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

		private void vNdJwvhesSiCvwTxzsnyeVIKRCWB(UpdateLoopType P_0)
		{
			Update(P_0);
			UpdateFinished();
		}

		protected virtual bool Update(UpdateLoopType updateLoop)
		{
			if (!ikpfoolsWNeSJgzlqkUjpLJVebBib)
			{
				return false;
			}
			bool flag = cJkvDaRAyzHJOYqkZfsRZWWdgBVc != null;
			bool flag2 = ZsHFBXkNFdwwdThljWECbwxfftkGA != null;
			for (int i = 0; i < hcumyDKqnEdXvKWcMzOEDwnckWFh._count; i++)
			{
				float num = 0f;
				if (flag && hcumyDKqnEdXvKWcMzOEDwnckWFh[i] is Axis)
				{
					Axis axis = hcumyDKqnEdXvKWcMzOEDwnckWFh[i] as Axis;
					num = ((axis.coordinateMode != AxisCoordinateMode.Absolute) ? 0f : axis.value);
				}
				hcumyDKqnEdXvKWcMzOEDwnckWFh[i].FhmguMVRiyRNQSlfwxvzMBzJhvsi();
				if (flag2 && hcumyDKqnEdXvKWcMzOEDwnckWFh[i] is Button)
				{
					Button button = hcumyDKqnEdXvKWcMzOEDwnckWFh[i] as Button;
					if (button.justPressed && button.value)
					{
						eAWebIjMHwmxbhsKDydZYfIDcbgHA.Add(new Element.SthchbSSHqgApFtODpjtqWAlNXwfA(ControllerElementType.Button, i, 1f));
					}
					else if (button.justReleased && !button.value)
					{
						eAWebIjMHwmxbhsKDydZYfIDcbgHA.Add(new Element.SthchbSSHqgApFtODpjtqWAlNXwfA(ControllerElementType.Button, i, 0f));
					}
				}
				else if (flag && hcumyDKqnEdXvKWcMzOEDwnckWFh[i] is Axis)
				{
					eAWebIjMHwmxbhsKDydZYfIDcbgHA.Add(new Element.SthchbSSHqgApFtODpjtqWAlNXwfA(ControllerElementType.Axis, i, (hcumyDKqnEdXvKWcMzOEDwnckWFh[i] as Axis).value - num));
				}
			}
			return true;
		}

		protected virtual void UpdateFinished()
		{
			int count = eAWebIjMHwmxbhsKDydZYfIDcbgHA.Count;
			if (count <= 0)
			{
				return;
			}
			for (int i = 0; i < count; i++)
			{
				Element.SthchbSSHqgApFtODpjtqWAlNXwfA sthchbSSHqgApFtODpjtqWAlNXwfA = eAWebIjMHwmxbhsKDydZYfIDcbgHA[i];
				if (sthchbSSHqgApFtODpjtqWAlNXwfA.WzGkrVHbIxzEwZyNPkmrLeSUDnaq == ControllerElementType.Button)
				{
					try
					{
						ZsHFBXkNFdwwdThljWECbwxfftkGA(sthchbSSHqgApFtODpjtqWAlNXwfA.feXSNvtCACzeTJnuXIwzgsfyRCWy, sthchbSSHqgApFtODpjtqWAlNXwfA.vHxfQimFsOcGTgALYnVwVJnADGyKA > 0f);
					}
					catch (Exception ex)
					{
						Logger.LogError("An exception occurred in a listener of ButtonStateChangedEvent. This means an exception was thrown by your code.\n" + ex);
					}
				}
				else if (sthchbSSHqgApFtODpjtqWAlNXwfA.WzGkrVHbIxzEwZyNPkmrLeSUDnaq == ControllerElementType.Axis)
				{
					try
					{
						cJkvDaRAyzHJOYqkZfsRZWWdgBVc(sthchbSSHqgApFtODpjtqWAlNXwfA.feXSNvtCACzeTJnuXIwzgsfyRCWy, sthchbSSHqgApFtODpjtqWAlNXwfA.vHxfQimFsOcGTgALYnVwVJnADGyKA);
					}
					catch (Exception ex2)
					{
						Logger.LogError("An exception occurred in a listener of AxisValueChangedEvent. This means an exception was thrown by your code.\n" + ex2);
					}
				}
			}
			eAWebIjMHwmxbhsKDydZYfIDcbgHA.Clear();
		}

		protected virtual void ClearVars()
		{
			eAWebIjMHwmxbhsKDydZYfIDcbgHA.Clear();
		}

		internal void vonHLgKTlCsLPcSfCsMMHrTyRObI(Element P_0)
		{
			if (P_0 != null)
			{
				if (P_0 is Axis)
				{
					OAIOibSBbHBHMaJaLxCIttxIyLaNA.Add(P_0 as Axis);
				}
				else if (P_0 is Button)
				{
					tRcUdmrClKUQLqNydcmoAsMGuQkR.Add(P_0 as Button);
				}
				hcumyDKqnEdXvKWcMzOEDwnckWFh.Add(P_0);
			}
		}

		private void BRPYbeuDvdHgrZyuONYAElXPYCWL(Element P_0, List<Element> P_1, List<Element> P_2, List<Button> P_3, List<Axis> P_4)
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
					(P_0 as CompoundElement).EXxtCmRnbwFfxYFwmBHADOWBRKAb(list);
					for (int i = 0; i < list.Count; i++)
					{
						BRPYbeuDvdHgrZyuONYAElXPYCWL(list[i], P_1, P_2, P_3, P_4);
					}
				}
				P_2.Add(P_0);
			}
			else
			{
				Logger.LogWarning("Unknown Element type encountered: " + P_0.GetType());
			}
		}

		internal static int lKhRPqnykfpsRxjOCzoGAJgPJdrc<_0001>(IList<_0001> P_0, Predicate<_0001> P_1, int P_2) where _0001 : Element
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
