using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[HelpURL("https://docs.gamecreator.io/gamecreator/characters/animation/states")]
	public class StateBasicLocomotion : StateOverrideAnimator
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
		private Stand8Points m_Stand8Points = new Stand8Points();

		[SerializeField]
		private Crouch8Points m_Land8Points = new Crouch8Points();

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

		private const string N_CROUCH_F = "Human@Crouch_Fast_F";

		private const string N_CROUCH_B = "Human@Crouch_Fast_B";

		private const string N_CROUCH_R = "Human@Crouch_Fast_R";

		private const string N_CROUCH_L = "Human@Crouch_Fast_L";

		private const string N_CROUCH_FR = "Human@Crouch_Fast_FR";

		private const string N_CROUCH_FL = "Human@Crouch_Fast_FL";

		private const string N_CROUCH_BR = "Human@Crouch_Fast_BR";

		private const string N_CROUCH_BL = "Human@Crouch_Fast_BL";

		private const string N_STAND_IDLE = "Human@Stand_Idle";

		private const string N_STAND_F = "Human@Stand_Fast_F";

		private const string N_STAND_B = "Human@Stand_Fast_B";

		private const string N_STAND_R = "Human@Stand_Fast_R";

		private const string N_STAND_L = "Human@Stand_Fast_L";

		private const string N_STAND_FR = "Human@Stand_Fast_FR";

		private const string N_STAND_FL = "Human@Stand_Fast_FL";

		private const string N_STAND_BR = "Human@Stand_Fast_BR";

		private const string N_STAND_BL = "Human@Stand_Fast_BL";

		protected sealed override void BeforeSerialize()
		{
			if (!(m_Controller == null))
			{
				m_Controller["Human@Stand_Idle"] = m_Stand8Points.m_Idle;
				m_Controller["Human@Stand_Fast_F"] = m_Stand8Points.m_Forward;
				m_Controller["Human@Stand_Fast_B"] = m_Stand8Points.m_Backward;
				m_Controller["Human@Stand_Fast_R"] = m_Stand8Points.m_Right;
				m_Controller["Human@Stand_Fast_L"] = m_Stand8Points.m_Left;
				m_Controller["Human@Stand_Fast_FR"] = m_Stand8Points.m_ForwardRight;
				m_Controller["Human@Stand_Fast_FL"] = m_Stand8Points.m_ForwardLeft;
				m_Controller["Human@Stand_Fast_BR"] = m_Stand8Points.m_BackwardRight;
				m_Controller["Human@Stand_Fast_BL"] = m_Stand8Points.m_BackwardLeft;
				m_Controller["Human@Stand_Fast_F"] = m_Stand8Points.m_Forward;
				m_Controller["Human@Stand_Fast_B"] = m_Stand8Points.m_Backward;
				m_Controller["Human@Stand_Fast_R"] = m_Stand8Points.m_Right;
				m_Controller["Human@Stand_Fast_L"] = m_Stand8Points.m_Left;
				m_Controller["Human@Stand_Fast_FR"] = m_Stand8Points.m_ForwardRight;
				m_Controller["Human@Stand_Fast_FL"] = m_Stand8Points.m_ForwardLeft;
				m_Controller["Human@Stand_Fast_BR"] = m_Stand8Points.m_BackwardRight;
				m_Controller["Human@Stand_Fast_BL"] = m_Stand8Points.m_BackwardLeft;
				m_Controller["Human@Crouch_Idle"] = m_Land8Points.m_Idle;
				m_Controller["Human@Crouch_Fast_F"] = m_Land8Points.m_Forward;
				m_Controller["Human@Crouch_Fast_B"] = m_Land8Points.m_Backward;
				m_Controller["Human@Crouch_Fast_R"] = m_Land8Points.m_Right;
				m_Controller["Human@Crouch_Fast_L"] = m_Land8Points.m_Left;
				m_Controller["Human@Crouch_Fast_FR"] = m_Land8Points.m_ForwardRight;
				m_Controller["Human@Crouch_Fast_FL"] = m_Land8Points.m_ForwardLeft;
				m_Controller["Human@Crouch_Fast_BR"] = m_Land8Points.m_BackwardRight;
				m_Controller["Human@Crouch_Fast_BL"] = m_Land8Points.m_BackwardLeft;
				m_Controller["Human@Crouch_Fast_F"] = m_Land8Points.m_Forward;
				m_Controller["Human@Crouch_Fast_B"] = m_Land8Points.m_Backward;
				m_Controller["Human@Crouch_Fast_R"] = m_Land8Points.m_Right;
				m_Controller["Human@Crouch_Fast_L"] = m_Land8Points.m_Left;
				m_Controller["Human@Crouch_Fast_FR"] = m_Land8Points.m_ForwardRight;
				m_Controller["Human@Crouch_Fast_FL"] = m_Land8Points.m_ForwardLeft;
				m_Controller["Human@Crouch_Fast_BR"] = m_Land8Points.m_BackwardRight;
				m_Controller["Human@Crouch_Fast_BL"] = m_Land8Points.m_BackwardLeft;
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
