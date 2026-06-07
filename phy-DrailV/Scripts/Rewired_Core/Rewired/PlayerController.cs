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

				internal override Element vUlywBdeUIQdKKcXqgQIbseFiUogb(PlayerController P_0)
				{
					return new Axis(P_0, this);
				}
			}

			internal const float FzSoTXbQkOOGdOvcOIqYYQWQjrzl = 1f;

			[CustomObfuscation(rename = false)]
			internal const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Absolute;

			private float WetfxJCYsPkEPDjWEOLQkIJaqDufA = 1f;

			private AxisCoordinateMode oPqsSwUtVNXwIoSLAcBKLXrbnuCd;

			public float absoluteToRelativeSensitivity
			{
				get
				{
					return WetfxJCYsPkEPDjWEOLQkIJaqDufA;
				}
				set
				{
					if (value < 0f)
					{
						value = 0f;
					}
					WetfxJCYsPkEPDjWEOLQkIJaqDufA = value;
				}
			}

			public AxisCoordinateMode coordinateMode => oPqsSwUtVNXwIoSLAcBKLXrbnuCd;

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
						if (oPqsSwUtVNXwIoSLAcBKLXrbnuCd == AxisCoordinateMode.Absolute)
						{
							return 0f;
						}
						break;
					case AxisCoordinateMode.Absolute:
						if (oPqsSwUtVNXwIoSLAcBKLXrbnuCd == AxisCoordinateMode.Relative)
						{
							num *= (float)ReInput.unscaledDeltaTime * WetfxJCYsPkEPDjWEOLQkIJaqDufA;
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
				WetfxJCYsPkEPDjWEOLQkIJaqDufA = P_1.absoluteToRelativeSensitivity;
				oPqsSwUtVNXwIoSLAcBKLXrbnuCd = P_1.coordinateMode;
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

				internal override Element vUlywBdeUIQdKKcXqgQIbseFiUogb(PlayerController P_0)
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
				private Axis.Definition WjicVJcRdduoBOtMGVvRmOiDQPNVA;

				private Axis.Definition IvjXZiMovoeZkNGZXUINrFyccNUQ;

				public Axis.Definition xAxis
				{
					get
					{
						return WjicVJcRdduoBOtMGVvRmOiDQPNVA;
					}
					set
					{
						WjicVJcRdduoBOtMGVvRmOiDQPNVA = value;
					}
				}

				public Axis.Definition yAxis
				{
					get
					{
						return IvjXZiMovoeZkNGZXUINrFyccNUQ;
					}
					set
					{
						IvjXZiMovoeZkNGZXUINrFyccNUQ = value;
					}
				}

				internal override Element vUlywBdeUIQdKKcXqgQIbseFiUogb(PlayerController P_0)
				{
					return new Axis2D(P_0, this);
				}
			}

			internal const int euPnKCmFpvhnWWrCCFmoIffzMlXLA = 0;

			internal const int cjYjZZRkWqPbUKWoAVMPreZfHHab = 1;

			internal const int sHpdoiAVZfJubFYWhrTfiWsoQOrQA = 2;

			public Axis xAxis => TIxnSRhPSalQFvQOFZaLLiQtwMIC<Axis>(0);

			public Axis yAxis => TIxnSRhPSalQFvQOFZaLLiQtwMIC<Axis>(1);

			public virtual Vector2 value => new Vector2(TIxnSRhPSalQFvQOFZaLLiQtwMIC<Axis>(0).value, TIxnSRhPSalQFvQOFZaLLiQtwMIC<Axis>(1).value);

			public virtual Vector2 valueRaw => new Vector2(TIxnSRhPSalQFvQOFZaLLiQtwMIC<Axis>(0).valueRaw, TIxnSRhPSalQFvQOFZaLLiQtwMIC<Axis>(1).valueRaw);

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

				internal override Element vUlywBdeUIQdKKcXqgQIbseFiUogb(PlayerController P_0)
				{
					return new MouseAxis2D(P_0, this);
				}
			}

			public new MouseAxis xAxis => TIxnSRhPSalQFvQOFZaLLiQtwMIC<MouseAxis>(0);

			public new MouseAxis yAxis => TIxnSRhPSalQFvQOFZaLLiQtwMIC<MouseAxis>(1);

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
				internal override Element vUlywBdeUIQdKKcXqgQIbseFiUogb(PlayerController P_0)
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

			private readonly List<Element> JlCnxdjSAFgokjnBJvAQVZXHNacj;

			internal int psjRAApvubFvKrvItiJJlxpacaQl => JlCnxdjSAFgokjnBJvAQVZXHNacj.Count;

			internal CompoundElement(PlayerController P_0, Definition P_1, Element.Definition[] P_2)
				: base(P_0, P_1)
			{
				JlCnxdjSAFgokjnBJvAQVZXHNacj = new List<Element>();
				if (P_2 == null)
				{
					return;
				}
				for (int i = 0; i < P_2.Length; i++)
				{
					if (P_2[i] != null)
					{
						noRZOaiqNhQVUigJbcItGViYdGAm(P_2[i].vUlywBdeUIQdKKcXqgQIbseFiUogb(P_0));
					}
				}
			}

			internal _0001 TIxnSRhPSalQFvQOFZaLLiQtwMIC<_0001>(int P_0) where _0001 : Element
			{
				if ((uint)P_0 >= (uint)JlCnxdjSAFgokjnBJvAQVZXHNacj.Count)
				{
					return null;
				}
				return JlCnxdjSAFgokjnBJvAQVZXHNacj[P_0] as _0001;
			}

			internal void GGIMKibDSMSJMvuZcauMulkfyMyf(List<Element> P_0)
			{
				for (int i = 0; i < JlCnxdjSAFgokjnBJvAQVZXHNacj.Count; i++)
				{
					if (JlCnxdjSAFgokjnBJvAQVZXHNacj[i] is CompoundElement)
					{
						(JlCnxdjSAFgokjnBJvAQVZXHNacj[i] as CompoundElement).GGIMKibDSMSJMvuZcauMulkfyMyf(P_0);
					}
					else
					{
						P_0.Add(JlCnxdjSAFgokjnBJvAQVZXHNacj[i]);
					}
				}
			}

			internal void noRZOaiqNhQVUigJbcItGViYdGAm(Element P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("element");
				}
				JlCnxdjSAFgokjnBJvAQVZXHNacj.Add(P_0);
				P_0.jCjEmPjlJInDPluwqfVWLCDlDLwy = true;
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

				internal abstract Element vUlywBdeUIQdKKcXqgQIbseFiUogb(PlayerController P_0);
			}

			internal struct FpYmryamBHrXwQeAYWwGcYfNlIWr
			{
				public ControllerElementType ugEcvEUjcYzrLriOHSDCiapaTNEm;

				public int tmcbqprIOUgJRYkEdFEZugQwfaOT;

				public float ANnyYrpgRHgHrBXsbJxMFrsUzupD;

				public FpYmryamBHrXwQeAYWwGcYfNlIWr(ControllerElementType P_0, int P_1, float P_2)
				{
					ugEcvEUjcYzrLriOHSDCiapaTNEm = P_0;
					tmcbqprIOUgJRYkEdFEZugQwfaOT = P_1;
					ANnyYrpgRHgHrBXsbJxMFrsUzupD = P_2;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const bool defaultEnabled = true;

			private readonly PlayerController WEvCOBjpQhIRpHaUkrxNLGKtAKdt;

			private bool pNsEteKULVNIbNirCOoKJNgCKvBbb;

			private bool KByWFLCBjjvqwXYVZFDfzPdklyjf = true;

			private string XXuYUuZFvXwuYxiNryIOxzHdIWPU;

			private static int[] QVCkkLqCvbjcmQsTbeXQpkngMRFl;

			private static int[] MNWjHgLwZcFBZQHFMCFYXUiGFBoO;

			protected Player player
			{
				get
				{
					if (!ReInput.isReady)
					{
						return null;
					}
					return ReInput.players.GetPlayer(WEvCOBjpQhIRpHaUkrxNLGKtAKdt.lZxGiiRCjWjNVgZWofZDCyZVhNIF);
				}
			}

			protected bool selfAndParentEnabled
			{
				get
				{
					if (KByWFLCBjjvqwXYVZFDfzPdklyjf)
					{
						return WEvCOBjpQhIRpHaUkrxNLGKtAKdt.KByWFLCBjjvqwXYVZFDfzPdklyjf;
					}
					return false;
				}
			}

			internal bool jCjEmPjlJInDPluwqfVWLCDlDLwy
			{
				get
				{
					return pNsEteKULVNIbNirCOoKJNgCKvBbb;
				}
				set
				{
					pNsEteKULVNIbNirCOoKJNgCKvBbb = true;
				}
			}

			public bool enabled
			{
				get
				{
					return KByWFLCBjjvqwXYVZFDfzPdklyjf;
				}
				set
				{
					if (KByWFLCBjjvqwXYVZFDfzPdklyjf != value)
					{
						KByWFLCBjjvqwXYVZFDfzPdklyjf = value;
						EnabledStateChanged(value);
					}
				}
			}

			public string name
			{
				get
				{
					return XXuYUuZFvXwuYxiNryIOxzHdIWPU;
				}
				set
				{
					XXuYUuZFvXwuYxiNryIOxzHdIWPU = value;
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
				WEvCOBjpQhIRpHaUkrxNLGKtAKdt = P_0;
				KByWFLCBjjvqwXYVZFDfzPdklyjf = P_1.enabled;
				XXuYUuZFvXwuYxiNryIOxzHdIWPU = P_1.name;
			}

			internal virtual void DsDuSUaDcVanpNAhDLIRqjKndMGi()
			{
			}

			protected virtual void EnabledStateChanged(bool state)
			{
			}

			[CustomObfuscation(rename = false)]
			internal static bool IsTypeWithSource(Type type)
			{
				if (QVCkkLqCvbjcmQsTbeXQpkngMRFl == null)
				{
					QVCkkLqCvbjcmQsTbeXQpkngMRFl = (int[])Enum.GetValues(typeof(TypeWithSource));
				}
				return ArrayTools.Contains(QVCkkLqCvbjcmQsTbeXQpkngMRFl, (int)type);
			}

			[CustomObfuscation(rename = false)]
			internal static bool IsCompoundType(Type type)
			{
				if (MNWjHgLwZcFBZQHFMCFYXUiGFBoO == null)
				{
					MNWjHgLwZcFBZQHFMCFYXUiGFBoO = (int[])Enum.GetValues(typeof(CompoundTypes));
				}
				return ArrayTools.Contains(MNWjHgLwZcFBZQHFMCFYXUiGFBoO, (int)type);
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
				private int nqrNxyIjKJnAagqUPKmjCYvwkyMr;

				public int actionId
				{
					get
					{
						return nqrNxyIjKJnAagqUPKmjCYvwkyMr;
					}
					set
					{
						nqrNxyIjKJnAagqUPKmjCYvwkyMr = value;
					}
				}

				public string actionName
				{
					get
					{
						if (!ReInput.isReady || nqrNxyIjKJnAagqUPKmjCYvwkyMr < 0)
						{
							return null;
						}
						return ReInput.mapping.GetAction(nqrNxyIjKJnAagqUPKmjCYvwkyMr)?.name;
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
							nqrNxyIjKJnAagqUPKmjCYvwkyMr = -1;
						}
						else
						{
							nqrNxyIjKJnAagqUPKmjCYvwkyMr = action.id;
						}
					}
				}

				public Definition()
				{
					nqrNxyIjKJnAagqUPKmjCYvwkyMr = -1;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const int defaultActionId = -1;

			private int nqrNxyIjKJnAagqUPKmjCYvwkyMr = -1;

			public int actionId
			{
				get
				{
					return nqrNxyIjKJnAagqUPKmjCYvwkyMr;
				}
				set
				{
					nqrNxyIjKJnAagqUPKmjCYvwkyMr = value;
				}
			}

			public string actionName
			{
				get
				{
					if (!ReInput.isReady || nqrNxyIjKJnAagqUPKmjCYvwkyMr < 0)
					{
						return null;
					}
					return ReInput.mapping.GetAction(nqrNxyIjKJnAagqUPKmjCYvwkyMr)?.name;
				}
				set
				{
					if (ReInput.isReady)
					{
						InputAction action = ReInput.mapping.GetAction(value);
						if (action == null)
						{
							nqrNxyIjKJnAagqUPKmjCYvwkyMr = -1;
						}
						else
						{
							nqrNxyIjKJnAagqUPKmjCYvwkyMr = action.id;
						}
					}
				}
			}

			internal ElementWithSource(PlayerController P_0, Definition P_1)
				: base(P_0, P_1)
			{
				nqrNxyIjKJnAagqUPKmjCYvwkyMr = P_1.actionId;
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

				internal override Element vUlywBdeUIQdKKcXqgQIbseFiUogb(PlayerController P_0)
				{
					return new MouseWheel(P_0, this);
				}
			}

			public new MouseWheelAxis xAxis => TIxnSRhPSalQFvQOFZaLLiQtwMIC<MouseWheelAxis>(0);

			public new MouseWheelAxis yAxis => TIxnSRhPSalQFvQOFZaLLiQtwMIC<MouseWheelAxis>(1);

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

				internal override Element vUlywBdeUIQdKKcXqgQIbseFiUogb(PlayerController P_0)
				{
					return new MouseWheelAxis(P_0, this);
				}
			}

			[CustomObfuscation(rename = false)]
			internal const float defaultRepeatRate = 4f;

			[CustomObfuscation(rename = false)]
			internal new const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Relative;

			private const float AMCCRqELzrpDniEifqipjtHfEOIQA = 0.01f;

			private float khThQGMCBaewaMNtjARehIzjlOaSA = 0.25f;

			private double CFedePkUvUwNoCAnclYqPuwntUxNA;

			private float YZxUdzxmklZNPuQQfDdyVZJzmbxt;

			public float repeatRate
			{
				get
				{
					if (khThQGMCBaewaMNtjARehIzjlOaSA == 0f)
					{
						return 0f;
					}
					return 1f / khThQGMCBaewaMNtjARehIzjlOaSA;
				}
				set
				{
					if (value < 0f)
					{
						value = 0f;
					}
					if (value == 0f)
					{
						khThQGMCBaewaMNtjARehIzjlOaSA = 0f;
					}
					else
					{
						khThQGMCBaewaMNtjARehIzjlOaSA = 1f / value;
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
					return YZxUdzxmklZNPuQQfDdyVZJzmbxt;
				}
			}

			internal MouseWheelAxis(PlayerController P_0, Definition P_1)
				: base(P_0, P_1)
			{
				repeatRate = P_1.repeatRate;
			}

			internal override void DsDuSUaDcVanpNAhDLIRqjKndMGi()
			{
				base.DsDuSUaDcVanpNAhDLIRqjKndMGi();
				if (base.selfAndParentEnabled)
				{
					YZxUdzxmklZNPuQQfDdyVZJzmbxt = GzchNHSYDyGuDxyljnOwzvvXVIsJ();
				}
			}

			protected override void EnabledStateChanged(bool state)
			{
				base.EnabledStateChanged(state);
				if (!state)
				{
					wJjPIIRJfHhEbGedUconecGfiwzgB();
				}
			}

			private float GzchNHSYDyGuDxyljnOwzvvXVIsJ()
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
					if (!flag && ReInput.unscaledTime < CFedePkUvUwNoCAnclYqPuwntUxNA + (double)khThQGMCBaewaMNtjARehIzjlOaSA)
					{
						return 0f;
					}
					if (Mathf.Abs(num) <= 0.01f)
					{
						return 0f;
					}
					num = Mathf.Sign(num);
					num *= base.absoluteToRelativeSensitivity;
					CFedePkUvUwNoCAnclYqPuwntUxNA = ReInput.unscaledTime;
					break;
				}
				}
				return num;
			}

			private void wJjPIIRJfHhEbGedUconecGfiwzgB()
			{
				YZxUdzxmklZNPuQQfDdyVZJzmbxt = 0f;
				CFedePkUvUwNoCAnclYqPuwntUxNA = 0.0;
			}
		}

		internal readonly int oLUDKIBSDOGsiswKzVsPEXOleBcs;

		private bool KByWFLCBjjvqwXYVZFDfzPdklyjf;

		private int lZxGiiRCjWjNVgZWofZDCyZVhNIF;

		private readonly AList<Element> JlCnxdjSAFgokjnBJvAQVZXHNacj;

		private readonly AList<Button> cmXHQZIxDUukeRCdGAxvuSrRrVmb;

		private readonly AList<Axis> MNGRtxShqkbjICkiFyeohwkjacEvA;

		private readonly ReadOnlyCollection<Element> jyTJsuSvMygQOFvHEMJfNaFRYsZO;

		private readonly ReadOnlyCollection<Button> JWDZHTCtclgWxkfZDspagfjemahf;

		private readonly ReadOnlyCollection<Axis> EdOFFWWnUbTJOqFSwSejKneKmZV;

		private readonly List<Element.FpYmryamBHrXwQeAYWwGcYfNlIWr> dgXpaQHGYFRzhLcHKbMFiFHRdykd;

		private Action<int, bool> PqXakVaRwOYgGZsVqAMOlOpDdXBaA;

		private Action<int, float> qOAraJNLsScTmDedlGfRPjzQFgad;

		private Action<bool> QzPwGNYXPQUefVsEZhDuCXeCuzIW;

		public bool enabled
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return false;
				}
				return KByWFLCBjjvqwXYVZFDfzPdklyjf;
			}
			set
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				}
				else
				{
					if (KByWFLCBjjvqwXYVZFDfzPdklyjf == value)
					{
						return;
					}
					if (!value)
					{
						ClearVars();
					}
					KByWFLCBjjvqwXYVZFDfzPdklyjf = value;
					for (int i = 0; i < JlCnxdjSAFgokjnBJvAQVZXHNacj._count; i++)
					{
						JlCnxdjSAFgokjnBJvAQVZXHNacj[i].enabled = value;
					}
					if (QzPwGNYXPQUefVsEZhDuCXeCuzIW != null)
					{
						try
						{
							QzPwGNYXPQUefVsEZhDuCXeCuzIW(value);
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
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return -1;
				}
				return lZxGiiRCjWjNVgZWofZDCyZVhNIF;
			}
			set
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				}
				else if (lZxGiiRCjWjNVgZWofZDCyZVhNIF != value)
				{
					lZxGiiRCjWjNVgZWofZDCyZVhNIF = value;
					ClearVars();
				}
			}
		}

		public IList<Button> buttons
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return null;
				}
				return JWDZHTCtclgWxkfZDspagfjemahf;
			}
		}

		public IList<Axis> axes
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return null;
				}
				return EdOFFWWnUbTJOqFSwSejKneKmZV;
			}
		}

		public IList<Element> elements
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return null;
				}
				return jyTJsuSvMygQOFvHEMJfNaFRYsZO;
			}
		}

		public int buttonCount
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return 0;
				}
				if (cmXHQZIxDUukeRCdGAxvuSrRrVmb == null)
				{
					return 0;
				}
				return cmXHQZIxDUukeRCdGAxvuSrRrVmb._count;
			}
		}

		public int axisCount
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return 0;
				}
				if (MNGRtxShqkbjICkiFyeohwkjacEvA == null)
				{
					return 0;
				}
				return MNGRtxShqkbjICkiFyeohwkjacEvA._count;
			}
		}

		public int elementCount
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return 0;
				}
				if (JlCnxdjSAFgokjnBJvAQVZXHNacj == null)
				{
					return 0;
				}
				return JlCnxdjSAFgokjnBJvAQVZXHNacj._count;
			}
		}

		internal Player tYEyiSjpdwwbqdDLYhlcYJwwGWGV
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
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				}
				else
				{
					PqXakVaRwOYgGZsVqAMOlOpDdXBaA = (Action<int, bool>)Delegate.Combine(PqXakVaRwOYgGZsVqAMOlOpDdXBaA, value);
				}
			}
			remove
			{
				PqXakVaRwOYgGZsVqAMOlOpDdXBaA = (Action<int, bool>)Delegate.Remove(PqXakVaRwOYgGZsVqAMOlOpDdXBaA, value);
			}
		}

		public event Action<int, float> AxisValueChangedEvent
		{
			add
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				}
				else
				{
					qOAraJNLsScTmDedlGfRPjzQFgad = (Action<int, float>)Delegate.Combine(qOAraJNLsScTmDedlGfRPjzQFgad, value);
				}
			}
			remove
			{
				qOAraJNLsScTmDedlGfRPjzQFgad = (Action<int, float>)Delegate.Remove(qOAraJNLsScTmDedlGfRPjzQFgad, value);
			}
		}

		public event Action<bool> EnabledStateChangedEvent
		{
			add
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				}
				else
				{
					QzPwGNYXPQUefVsEZhDuCXeCuzIW = (Action<bool>)Delegate.Combine(QzPwGNYXPQUefVsEZhDuCXeCuzIW, value);
				}
			}
			remove
			{
				QzPwGNYXPQUefVsEZhDuCXeCuzIW = (Action<bool>)Delegate.Remove(QzPwGNYXPQUefVsEZhDuCXeCuzIW, value);
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
			oLUDKIBSDOGsiswKzVsPEXOleBcs = ReInput._id;
			lZxGiiRCjWjNVgZWofZDCyZVhNIF = P_0.playerId;
			KByWFLCBjjvqwXYVZFDfzPdklyjf = P_0.enabled;
			List<Element> list = new List<Element>();
			List<Element> list2 = new List<Element>();
			List<Button> list3 = new List<Button>();
			List<Axis> list4 = new List<Axis>();
			foreach (Element.Definition element in P_0.elements)
			{
				noRZOaiqNhQVUigJbcItGViYdGAm(element.vUlywBdeUIQdKKcXqgQIbseFiUogb(this), list, list2, list3, list4);
			}
			list.AddRange(list2);
			JlCnxdjSAFgokjnBJvAQVZXHNacj = new AList<Element>(list);
			cmXHQZIxDUukeRCdGAxvuSrRrVmb = new AList<Button>(list3);
			MNGRtxShqkbjICkiFyeohwkjacEvA = new AList<Axis>(list4);
			jyTJsuSvMygQOFvHEMJfNaFRYsZO = new ReadOnlyCollection<Element>(JlCnxdjSAFgokjnBJvAQVZXHNacj);
			JWDZHTCtclgWxkfZDspagfjemahf = new ReadOnlyCollection<Button>(cmXHQZIxDUukeRCdGAxvuSrRrVmb);
			EdOFFWWnUbTJOqFSwSejKneKmZV = new ReadOnlyCollection<Axis>(MNGRtxShqkbjICkiFyeohwkjacEvA);
			dgXpaQHGYFRzhLcHKbMFiFHRdykd = new List<Element.FpYmryamBHrXwQeAYWwGcYfNlIWr>();
			ReInput.UpdateEndedEvent += vjhEkIpbiwZRwstmkNxqMDjviCZ;
		}

		~PlayerController()
		{
			ReInput.UpdateEndedEvent -= vjhEkIpbiwZRwstmkNxqMDjviCZ;
		}

		public bool GetButton(int index)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			if ((uint)index >= (uint)cmXHQZIxDUukeRCdGAxvuSrRrVmb._count)
			{
				return false;
			}
			return cmXHQZIxDUukeRCdGAxvuSrRrVmb[index].value;
		}

		public bool GetButtonDown(int index)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			if ((uint)index >= (uint)cmXHQZIxDUukeRCdGAxvuSrRrVmb._count)
			{
				return false;
			}
			return cmXHQZIxDUukeRCdGAxvuSrRrVmb[index].justPressed;
		}

		public bool GetButtonUp(int index)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			if ((uint)index >= (uint)cmXHQZIxDUukeRCdGAxvuSrRrVmb._count)
			{
				return false;
			}
			return cmXHQZIxDUukeRCdGAxvuSrRrVmb[index].justReleased;
		}

		public float GetAxis(int index)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0f;
			}
			if ((uint)index >= (uint)MNGRtxShqkbjICkiFyeohwkjacEvA._count)
			{
				return 0f;
			}
			return MNGRtxShqkbjICkiFyeohwkjacEvA[index].value;
		}

		public float GetAxisRaw(int index)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0f;
			}
			if ((uint)index >= (uint)MNGRtxShqkbjICkiFyeohwkjacEvA._count)
			{
				return 0f;
			}
			return MNGRtxShqkbjICkiFyeohwkjacEvA[index].valueRaw;
		}

		public Element GetElement(int index)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			if ((uint)index >= (uint)JlCnxdjSAFgokjnBJvAQVZXHNacj._count)
			{
				return null;
			}
			return JlCnxdjSAFgokjnBJvAQVZXHNacj[index];
		}

		public T GetElement<T>(int index) where T : Element
		{
			return GetElement(index) as T;
		}

		private void vjhEkIpbiwZRwstmkNxqMDjviCZ(UpdateLoopType P_0)
		{
			Update(P_0);
			UpdateFinished();
		}

		protected virtual bool Update(UpdateLoopType updateLoop)
		{
			if (!KByWFLCBjjvqwXYVZFDfzPdklyjf)
			{
				return false;
			}
			bool flag = qOAraJNLsScTmDedlGfRPjzQFgad != null;
			bool flag2 = PqXakVaRwOYgGZsVqAMOlOpDdXBaA != null;
			for (int i = 0; i < JlCnxdjSAFgokjnBJvAQVZXHNacj._count; i++)
			{
				float num = 0f;
				if (flag && JlCnxdjSAFgokjnBJvAQVZXHNacj[i] is Axis)
				{
					Axis axis = JlCnxdjSAFgokjnBJvAQVZXHNacj[i] as Axis;
					num = ((axis.coordinateMode != AxisCoordinateMode.Absolute) ? 0f : axis.value);
				}
				JlCnxdjSAFgokjnBJvAQVZXHNacj[i].DsDuSUaDcVanpNAhDLIRqjKndMGi();
				if (flag2 && JlCnxdjSAFgokjnBJvAQVZXHNacj[i] is Button)
				{
					Button button = JlCnxdjSAFgokjnBJvAQVZXHNacj[i] as Button;
					if (button.justPressed && button.value)
					{
						dgXpaQHGYFRzhLcHKbMFiFHRdykd.Add(new Element.FpYmryamBHrXwQeAYWwGcYfNlIWr(ControllerElementType.Button, i, 1f));
					}
					else if (button.justReleased && !button.value)
					{
						dgXpaQHGYFRzhLcHKbMFiFHRdykd.Add(new Element.FpYmryamBHrXwQeAYWwGcYfNlIWr(ControllerElementType.Button, i, 0f));
					}
				}
				else if (flag && JlCnxdjSAFgokjnBJvAQVZXHNacj[i] is Axis)
				{
					dgXpaQHGYFRzhLcHKbMFiFHRdykd.Add(new Element.FpYmryamBHrXwQeAYWwGcYfNlIWr(ControllerElementType.Axis, i, (JlCnxdjSAFgokjnBJvAQVZXHNacj[i] as Axis).value - num));
				}
			}
			return true;
		}

		protected virtual void UpdateFinished()
		{
			int count = dgXpaQHGYFRzhLcHKbMFiFHRdykd.Count;
			if (count <= 0)
			{
				return;
			}
			for (int i = 0; i < count; i++)
			{
				Element.FpYmryamBHrXwQeAYWwGcYfNlIWr fpYmryamBHrXwQeAYWwGcYfNlIWr = dgXpaQHGYFRzhLcHKbMFiFHRdykd[i];
				if (fpYmryamBHrXwQeAYWwGcYfNlIWr.ugEcvEUjcYzrLriOHSDCiapaTNEm == ControllerElementType.Button)
				{
					try
					{
						PqXakVaRwOYgGZsVqAMOlOpDdXBaA(fpYmryamBHrXwQeAYWwGcYfNlIWr.tmcbqprIOUgJRYkEdFEZugQwfaOT, (fpYmryamBHrXwQeAYWwGcYfNlIWr.ANnyYrpgRHgHrBXsbJxMFrsUzupD > 0f) ? true : false);
					}
					catch (Exception ex)
					{
						Logger.LogError("An exception occurred in a listener of ButtonStateChangedEvent. This means an exception was thrown by your code.\n" + ex);
					}
				}
				else if (fpYmryamBHrXwQeAYWwGcYfNlIWr.ugEcvEUjcYzrLriOHSDCiapaTNEm == ControllerElementType.Axis)
				{
					try
					{
						qOAraJNLsScTmDedlGfRPjzQFgad(fpYmryamBHrXwQeAYWwGcYfNlIWr.tmcbqprIOUgJRYkEdFEZugQwfaOT, fpYmryamBHrXwQeAYWwGcYfNlIWr.ANnyYrpgRHgHrBXsbJxMFrsUzupD);
					}
					catch (Exception ex2)
					{
						Logger.LogError("An exception occurred in a listener of AxisValueChangedEvent. This means an exception was thrown by your code.\n" + ex2);
					}
				}
			}
			dgXpaQHGYFRzhLcHKbMFiFHRdykd.Clear();
		}

		protected virtual void ClearVars()
		{
			dgXpaQHGYFRzhLcHKbMFiFHRdykd.Clear();
		}

		internal void noRZOaiqNhQVUigJbcItGViYdGAm(Element P_0)
		{
			if (P_0 != null)
			{
				if (P_0 is Axis)
				{
					MNGRtxShqkbjICkiFyeohwkjacEvA.Add(P_0 as Axis);
				}
				else if (P_0 is Button)
				{
					cmXHQZIxDUukeRCdGAxvuSrRrVmb.Add(P_0 as Button);
				}
				JlCnxdjSAFgokjnBJvAQVZXHNacj.Add(P_0);
			}
		}

		private void noRZOaiqNhQVUigJbcItGViYdGAm(Element P_0, List<Element> P_1, List<Element> P_2, List<Button> P_3, List<Axis> P_4)
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
					(P_0 as CompoundElement).GGIMKibDSMSJMvuZcauMulkfyMyf(list);
					for (int i = 0; i < list.Count; i++)
					{
						noRZOaiqNhQVUigJbcItGViYdGAm(list[i], P_1, P_2, P_3, P_4);
					}
				}
				P_2.Add(P_0);
			}
			else
			{
				Logger.LogWarning("Unknown Element type encountered: " + P_0.GetType());
			}
		}

		internal static int bXjiRLKfveGrYifyXTArupYjztiT<_0001>(IList<_0001> P_0, Predicate<_0001> P_1, int P_2) where _0001 : Element
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
