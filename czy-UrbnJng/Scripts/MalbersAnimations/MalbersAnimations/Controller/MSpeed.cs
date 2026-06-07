using System;
using MalbersAnimations.Scriptables;

namespace MalbersAnimations.Controller
{
	[Serializable]
	public struct MSpeed
	{
		public static readonly MSpeed Default = new MSpeed("Default", 1f, 4f, 4f);

		public string name;

		public FloatReference Vertical;

		public FloatReference position;

		public FloatReference lerpPosition;

		public FloatReference lerpPosAnim;

		public FloatReference rotation;

		public FloatReference lerpRotAnim;

		public FloatReference animator;

		public FloatReference lerpAnimator;

		public FloatReference strafeSpeed;

		public FloatReference lerpStrafe;

		public string Name
		{
			readonly get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}

		public MSpeed(MSpeed newSpeed)
		{
			name = newSpeed.name;
			position = newSpeed.position;
			lerpPosition = newSpeed.lerpPosition;
			lerpPosAnim = newSpeed.lerpPosAnim;
			rotation = newSpeed.rotation;
			lerpRotAnim = newSpeed.lerpRotAnim;
			animator = newSpeed.animator;
			lerpAnimator = newSpeed.lerpAnimator;
			Vertical = newSpeed.Vertical;
			strafeSpeed = newSpeed.strafeSpeed;
			strafeSpeed = newSpeed.strafeSpeed;
			lerpStrafe = newSpeed.lerpStrafe;
		}

		public MSpeed(string name, float lerpPos, float lerpanim)
		{
			this.name = name;
			Vertical = 1f;
			position = 0f;
			lerpPosition = lerpPos;
			lerpPosAnim = 4f;
			rotation = 0f;
			strafeSpeed = 0f;
			lerpRotAnim = 4f;
			lerpStrafe = 4f;
			animator = 1f;
			lerpAnimator = lerpanim;
		}

		public MSpeed(string name, float vertical, float lerpPos, float lerpanim)
		{
			this.name = name;
			Vertical = vertical;
			position = 0f;
			lerpPosition = lerpPos;
			lerpPosAnim = 4f;
			rotation = 0f;
			strafeSpeed = 0f;
			lerpRotAnim = 4f;
			lerpStrafe = 4f;
			animator = 1f;
			lerpAnimator = lerpanim;
		}

		public MSpeed(string name)
		{
			this.name = name;
			Vertical = 1f;
			position = 0f;
			lerpPosition = 4f;
			lerpPosAnim = 4f;
			rotation = 0f;
			strafeSpeed = 0f;
			lerpRotAnim = 4f;
			lerpStrafe = 4f;
			animator = 1f;
			lerpAnimator = 4f;
		}
	}
}
