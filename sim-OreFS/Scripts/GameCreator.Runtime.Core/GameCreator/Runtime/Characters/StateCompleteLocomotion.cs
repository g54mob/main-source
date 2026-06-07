using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[HelpURL("https://docs.gamecreator.io/gamecreator/characters/animation/states")]
	public class StateCompleteLocomotion : StateOverrideAnimator
	{
		private enum AirborneMode
		{
			Single = 0,
			Vertical = 1,
			Directional = 2
		}

		[SerializeField]
		private AirborneMode m_AirborneMode;

		[SerializeField]
		private Stand16Points m_Stand16Points = new Stand16Points();

		[SerializeField]
		private Crouch16Points m_Land16Points = new Crouch16Points();

		[SerializeField]
		private AirborneSingle m_AirborneSingle = new AirborneSingle();

		[SerializeField]
		private AirborneVertical m_AirborneVertical = new AirborneVertical();

		[SerializeField]
		private AirborneDirectional m_AirborneDirectional = new AirborneDirectional();

		private const string N_AIR_UP_I = "Human@Air_Up_I";

		private const string N_AIR_UP_F = "Human@Air_Up_F";

		private const string N_AIR_UP_B = "Human@Air_Up_B";

		private const string N_AIR_UP_R = "Human@Air_Up_R";

		private const string N_AIR_UP_L = "Human@Air_Up_L";

		private const string N_AIR_DOWN_I = "Human@Air_Down_I";

		private const string N_AIR_DOWN_F = "Human@Air_Down_F";

		private const string N_AIR_DOWN_B = "Human@Air_Down_B";

		private const string N_AIR_DOWN_R = "Human@Air_Down_R";

		private const string N_AIR_DOWN_L = "Human@Air_Down_L";

		private const string N_CROUCH_IDLE = "Human@Crouch_Idle";

		private const string N_CROUCH_FAST_F = "Human@Crouch_Fast_F";

		private const string N_CROUCH_FAST_B = "Human@Crouch_Fast_B";

		private const string N_CROUCH_FAST_R = "Human@Crouch_Fast_R";

		private const string N_CROUCH_FAST_L = "Human@Crouch_Fast_L";

		private const string N_CROUCH_FAST_FR = "Human@Crouch_Fast_FR";

		private const string N_CROUCH_FAST_FL = "Human@Crouch_Fast_FL";

		private const string N_CROUCH_FAST_BR = "Human@Crouch_Fast_BR";

		private const string N_CROUCH_FAST_BL = "Human@Crouch_Fast_BL";

		private const string N_CROUCH_SLOW_F = "Human@Crouch_Slow_F";

		private const string N_CROUCH_SLOW_B = "Human@Crouch_Slow_B";

		private const string N_CROUCH_SLOW_R = "Human@Crouch_Slow_R";

		private const string N_CROUCH_SLOW_L = "Human@Crouch_Slow_L";

		private const string N_CROUCH_SLOW_FR = "Human@Crouch_Slow_FR";

		private const string N_CROUCH_SLOW_FL = "Human@Crouch_Slow_FL";

		private const string N_CROUCH_SLOW_BR = "Human@Crouch_Slow_BR";

		private const string N_CROUCH_SLOW_BL = "Human@Crouch_Slow_BL";

		private const string N_STAND_IDLE = "Human@Stand_Idle";

		private const string N_STAND_FAST_F = "Human@Stand_Fast_F";

		private const string N_STAND_FAST_B = "Human@Stand_Fast_B";

		private const string N_STAND_FAST_R = "Human@Stand_Fast_R";

		private const string N_STAND_FAST_L = "Human@Stand_Fast_L";

		private const string N_STAND_FAST_FR = "Human@Stand_Fast_FR";

		private const string N_STAND_FAST_FL = "Human@Stand_Fast_FL";

		private const string N_STAND_FAST_BR = "Human@Stand_Fast_BR";

		private const string N_STAND_FAST_BL = "Human@Stand_Fast_BL";

		private const string N_STAND_SLOW_F = "Human@Stand_Slow_F";

		private const string N_STAND_SLOW_B = "Human@Stand_Slow_B";

		private const string N_STAND_SLOW_R = "Human@Stand_Slow_R";

		private const string N_STAND_SLOW_L = "Human@Stand_Slow_L";

		private const string N_STAND_SLOW_FR = "Human@Stand_Slow_FR";

		private const string N_STAND_SLOW_FL = "Human@Stand_Slow_FL";

		private const string N_STAND_SLOW_BR = "Human@Stand_Slow_BR";

		private const string N_STAND_SLOW_BL = "Human@Stand_Slow_BL";

		protected sealed override void BeforeSerialize()
		{
			if (!(m_Controller == null))
			{
				m_Controller["Human@Stand_Idle"] = m_Stand16Points.m_Idle;
				m_Controller["Human@Stand_Fast_F"] = m_Stand16Points.m_ForwardFast;
				m_Controller["Human@Stand_Fast_B"] = m_Stand16Points.m_BackwardFast;
				m_Controller["Human@Stand_Fast_R"] = m_Stand16Points.m_RightFast;
				m_Controller["Human@Stand_Fast_L"] = m_Stand16Points.m_LeftFast;
				m_Controller["Human@Stand_Fast_FR"] = m_Stand16Points.m_ForwardRightFast;
				m_Controller["Human@Stand_Fast_FL"] = m_Stand16Points.m_ForwardLeftFast;
				m_Controller["Human@Stand_Fast_BR"] = m_Stand16Points.m_BackwardRightFast;
				m_Controller["Human@Stand_Fast_BL"] = m_Stand16Points.m_BackwardLeftFast;
				m_Controller["Human@Stand_Slow_F"] = m_Stand16Points.m_ForwardSlow;
				m_Controller["Human@Stand_Slow_B"] = m_Stand16Points.m_BackwardSlow;
				m_Controller["Human@Stand_Slow_R"] = m_Stand16Points.m_RightSlow;
				m_Controller["Human@Stand_Slow_L"] = m_Stand16Points.m_LeftSlow;
				m_Controller["Human@Stand_Slow_FR"] = m_Stand16Points.m_ForwardRightSlow;
				m_Controller["Human@Stand_Slow_FL"] = m_Stand16Points.m_ForwardLeftSlow;
				m_Controller["Human@Stand_Slow_BR"] = m_Stand16Points.m_BackwardRightSlow;
				m_Controller["Human@Stand_Slow_BL"] = m_Stand16Points.m_BackwardLeftSlow;
				m_Controller["Human@Crouch_Idle"] = m_Land16Points.m_Idle;
				m_Controller["Human@Crouch_Fast_F"] = m_Land16Points.m_ForwardFast;
				m_Controller["Human@Crouch_Fast_B"] = m_Land16Points.m_BackwardFast;
				m_Controller["Human@Crouch_Fast_R"] = m_Land16Points.m_RightFast;
				m_Controller["Human@Crouch_Fast_L"] = m_Land16Points.m_LeftFast;
				m_Controller["Human@Crouch_Fast_FR"] = m_Land16Points.m_ForwardRightFast;
				m_Controller["Human@Crouch_Fast_FL"] = m_Land16Points.m_ForwardLeftFast;
				m_Controller["Human@Crouch_Fast_BR"] = m_Land16Points.m_BackwardRightFast;
				m_Controller["Human@Crouch_Fast_BL"] = m_Land16Points.m_BackwardLeftFast;
				m_Controller["Human@Crouch_Slow_F"] = m_Land16Points.m_ForwardSlow;
				m_Controller["Human@Crouch_Slow_B"] = m_Land16Points.m_BackwardSlow;
				m_Controller["Human@Crouch_Slow_R"] = m_Land16Points.m_RightSlow;
				m_Controller["Human@Crouch_Slow_L"] = m_Land16Points.m_LeftSlow;
				m_Controller["Human@Crouch_Slow_FR"] = m_Land16Points.m_ForwardRightSlow;
				m_Controller["Human@Crouch_Slow_FL"] = m_Land16Points.m_ForwardLeftSlow;
				m_Controller["Human@Crouch_Slow_BR"] = m_Land16Points.m_BackwardRightSlow;
				m_Controller["Human@Crouch_Slow_BL"] = m_Land16Points.m_BackwardLeftSlow;
				switch (m_AirborneMode)
				{
				case AirborneMode.Single:
					m_Controller["Human@Air_Up_I"] = m_AirborneSingle.m_OnAir;
					m_Controller["Human@Air_Up_F"] = m_AirborneSingle.m_OnAir;
					m_Controller["Human@Air_Up_B"] = m_AirborneSingle.m_OnAir;
					m_Controller["Human@Air_Up_R"] = m_AirborneSingle.m_OnAir;
					m_Controller["Human@Air_Up_L"] = m_AirborneSingle.m_OnAir;
					m_Controller["Human@Air_Down_I"] = m_AirborneSingle.m_OnAir;
					m_Controller["Human@Air_Down_F"] = m_AirborneSingle.m_OnAir;
					m_Controller["Human@Air_Down_B"] = m_AirborneSingle.m_OnAir;
					m_Controller["Human@Air_Down_R"] = m_AirborneSingle.m_OnAir;
					m_Controller["Human@Air_Down_L"] = m_AirborneSingle.m_OnAir;
					break;
				case AirborneMode.Vertical:
					m_Controller["Human@Air_Up_I"] = m_AirborneVertical.m_Up;
					m_Controller["Human@Air_Up_F"] = m_AirborneVertical.m_Up;
					m_Controller["Human@Air_Up_B"] = m_AirborneVertical.m_Up;
					m_Controller["Human@Air_Up_R"] = m_AirborneVertical.m_Up;
					m_Controller["Human@Air_Up_L"] = m_AirborneVertical.m_Up;
					m_Controller["Human@Air_Down_I"] = m_AirborneVertical.m_Down;
					m_Controller["Human@Air_Down_F"] = m_AirborneVertical.m_Down;
					m_Controller["Human@Air_Down_B"] = m_AirborneVertical.m_Down;
					m_Controller["Human@Air_Down_R"] = m_AirborneVertical.m_Down;
					m_Controller["Human@Air_Down_L"] = m_AirborneVertical.m_Down;
					break;
				case AirborneMode.Directional:
					m_Controller["Human@Air_Up_I"] = m_AirborneDirectional.m_UpIdle;
					m_Controller["Human@Air_Up_F"] = m_AirborneDirectional.m_UpForward;
					m_Controller["Human@Air_Up_B"] = m_AirborneDirectional.m_UpBackward;
					m_Controller["Human@Air_Up_R"] = m_AirborneDirectional.m_UpRight;
					m_Controller["Human@Air_Up_L"] = m_AirborneDirectional.m_UpLeft;
					m_Controller["Human@Air_Down_I"] = m_AirborneDirectional.m_DownIdle;
					m_Controller["Human@Air_Down_F"] = m_AirborneDirectional.m_DownForward;
					m_Controller["Human@Air_Down_B"] = m_AirborneDirectional.m_DownBackward;
					m_Controller["Human@Air_Down_R"] = m_AirborneDirectional.m_DownRight;
					m_Controller["Human@Air_Down_L"] = m_AirborneDirectional.m_DownLeft;
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
		}

		protected sealed override void AfterSerialize()
		{
		}
	}
}
