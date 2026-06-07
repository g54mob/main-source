using DV.CabControls.Spec;
using DV.HUD;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public abstract class ALocoControlStep : ALocoTutorialStep
	{
		public InteriorControlsManager.ControlType ControlType { get; private set; }

		public static bool IsPositive(QTSemantic semantic)
		{
			switch (semantic)
			{
			case QTSemantic.Engage:
			case QTSemantic.EngageCW:
			case QTSemantic.GentlyEngage:
			case QTSemantic.FullyEngage:
			case QTSemantic.GoForward:
			case QTSemantic.SetToNotch1:
			case QTSemantic.SetToNotch2:
				return true;
			default:
				return false;
			}
		}

		public static bool IsLightSwitch(InteriorControlsManager.ControlType type)
		{
			if ((uint)(type - 8) <= 1u || type == InteriorControlsManager.ControlType.CabLight || (uint)(type - 27) <= 1u)
			{
				return true;
			}
			return false;
		}

		public static bool IsSteamerTwoStateSwitch(InteriorControlsManager.ControlType type)
		{
			if ((uint)(type - 38) <= 2u)
			{
				return true;
			}
			return false;
		}

		public static bool IsBrake(InteriorControlsManager.ControlType type)
		{
			if (type == InteriorControlsManager.ControlType.TrainBrake || (uint)(type - 4) <= 1u || type == InteriorControlsManager.ControlType.DynamicBrake)
			{
				return true;
			}
			return false;
		}

		public static bool IsAccelerator(InteriorControlsManager.ControlType type)
		{
			if (type == InteriorControlsManager.ControlType.Throttle)
			{
				return true;
			}
			return false;
		}

		public ALocoControlStep(TrainCar loco, InteriorControlsManager.ControlType controlType, AQuickTutorialMessage message, QTSemantic semantic, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
			: base(loco, message, semantic, attentionPoint, attentionOffset, shouldRecheck)
		{
			ControlType = controlType;
		}

		protected override QTVerb GetVerb()
		{
			if (base.Semantic == QTSemantic.Look)
			{
				return QTVerb.Look;
			}
			if (base.Semantic == QTSemantic.Open)
			{
				return QTVerb.Open;
			}
			if (base.Semantic == QTSemantic.Close)
			{
				return QTVerb.Close;
			}
			if (ControlType == InteriorControlsManager.ControlType.StarterControl && IsPositive(base.Semantic))
			{
				if (base.Control is Lever || base.Control is Rotary)
				{
					return QTVerb.EngageCW;
				}
				return QTVerb.Enable;
			}
			if (base.Control is Button)
			{
				if (ControlType == InteriorControlsManager.ControlType.Lubricator)
				{
					return QTVerb.Hold;
				}
				return QTVerb.Press;
			}
			bool flag = base.Control is Lever;
			bool flag2 = base.Control is Rotary;
			bool flag3 = base.Control is Wheel;
			if (flag || flag2 || flag3)
			{
				if (IsSteamerTwoStateSwitch(ControlType))
				{
					if (!IsPositive(base.Semantic))
					{
						return QTVerb.Disable;
					}
					return QTVerb.Enable;
				}
				if (IsLightSwitch(ControlType))
				{
					if (base.Semantic == QTSemantic.Engage)
					{
						return QTVerb.Enable;
					}
					if (base.Semantic == QTSemantic.Disengage)
					{
						return QTVerb.Disable;
					}
					if (IsPositive(base.Semantic))
					{
						if (!flag)
						{
							return QTVerb.EngageCW;
						}
						return QTVerb.Push;
					}
					if (base.Semantic == QTSemantic.GoBackward || base.Semantic == QTSemantic.EngageCCW)
					{
						if (!flag)
						{
							return QTVerb.EngageCCW;
						}
						return QTVerb.Pull;
					}
					return QTVerb.Disable;
				}
				if (ControlType == InteriorControlsManager.ControlType.Reverser)
				{
					if (IsPositive(base.Semantic))
					{
						return QTVerb.SetToForward;
					}
					if (base.Semantic == QTSemantic.SetToNeutral)
					{
						return QTVerb.SetToNeutral;
					}
					if (base.Semantic == QTSemantic.SetCloserToNeutral)
					{
						return QTVerb.SetCloserToNeutral;
					}
					return QTVerb.SetToReverse;
				}
				if (IsBrake(ControlType))
				{
					if (base.Semantic == QTSemantic.GentlyEngage)
					{
						return QTVerb.Brake_GentlyEngage;
					}
					if (IsPositive(base.Semantic))
					{
						return QTVerb.Brake_FullyEngage;
					}
					return QTVerb.Brake_Disengage;
				}
				if (IsAccelerator(ControlType))
				{
					if (base.Semantic == QTSemantic.GentlyEngage)
					{
						return QTVerb.Accel_GentlyEngage;
					}
					if (IsPositive(base.Semantic))
					{
						return QTVerb.Accel_FullyEngage;
					}
					return QTVerb.Accel_Disengage;
				}
				switch (base.Semantic)
				{
				case QTSemantic.EngageCW:
					return QTVerb.EngageCW;
				case QTSemantic.EngageCCW:
					return QTVerb.EngageCCW;
				case QTSemantic.Engage:
					return QTVerb.Apply;
				case QTSemantic.FullyEngage:
					return QTVerb.FullyApply;
				case QTSemantic.GentlyEngage:
					return QTVerb.GentlyApply;
				case QTSemantic.Disengage:
					return QTVerb.Release;
				case QTSemantic.GoForward:
				case QTSemantic.GoBackward:
					return QTVerb.Pull;
				case QTSemantic.SetToNeutral:
					return QTVerb.SetToNeutral;
				case QTSemantic.SetToNotch1:
					return QTVerb.SetToGear1;
				case QTSemantic.SetToNotch2:
					return QTVerb.SetToGear2;
				default:
					return QTVerb.Pull;
				}
			}
			if (base.Control is ToggleSwitch)
			{
				if (IsPositive(base.Semantic))
				{
					return QTVerb.Enable;
				}
				return QTVerb.Disable;
			}
			return QTVerb.None;
		}
	}
}
