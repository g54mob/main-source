using System;
using UnityEngine;

namespace JUTPS.CharacterBrain
{
	[Serializable]
	public class JUAnimatorParameters
	{
		[Header("Default Layers IDs")]
		public int _BaseLayerIndex;

		public int _LegsLayerIndex = 1;

		public int _RightArmLayerIndex = 2;

		public int _LeftArmLayerIndex = 3;

		public int _BothArmsLayerIndex = 4;

		public int _SwitchWeaponLayerIndex = 5;

		public int _legsOverrideLayerIndex = 9;

		public int _fullBodyLayerIndex = 10;

		public int _torsoLayerIndex = 11;

		[Header("Default Parameters Names")]
		public string Moving = "Moving";

		public string Running = "Running";

		public string Speed = "Speed";

		public string HorizontalInput = "Horizontal";

		public string VerticalInput = "Vertical";

		public string IdleTurn = "IdleTurn";

		public string MovingTurn = "MovingTurn";

		public string Grounded = "Grounded";

		public string Jumping = "Jumping";

		public string ItemEquiped = "ItemEquiped";

		public string FireMode = "FireMode";

		public string Crouch = "Crouched";

		public string Prone = "Prone";

		public string Driving = "Driving";

		public string Dying = "Die";

		public string Punch = "Punch";

		public string Roll = "Roll";

		public string ReloadRightWeapon = "ReloadRightWeapon";

		public string ReloadLeftWeapon = "ReloadLeftWeapon";

		public string PullWeaponSlider = "PullWeaponSlider";

		public string LandingIntensity = "LandingIntensity";

		public string ItemWieldingRightHandPoseID = "ItemWieldingRightHandPoseID";

		public string ItemWieldingLeftHandPoseID = "ItemWieldingLeftHandPoseID";

		public string ItemsWieldingIdentifier = "ItemsWieldingIdentifier";
	}
}
