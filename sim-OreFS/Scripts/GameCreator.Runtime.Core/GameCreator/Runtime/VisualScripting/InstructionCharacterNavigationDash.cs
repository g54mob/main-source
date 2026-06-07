using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Dash")]
	[Description("Moves the Character in the chosen direction for a brief period of time")]
	[Category("Characters/Navigation/Dash")]
	[Parameter("Direction", "Vector oriented towards the desired direction")]
	[Parameter("Velocity", "Velocity the Character moves throughout the whole movement")]
	[Parameter("Duration", "Defines the duration it takes to move forward at a constant velocity")]
	[Parameter("Wait to Finish", "If true this Instruction waits until the dash is completed")]
	[Parameter("Mode", "Whether to use Cardinal Animations (4 clips for each direction) or a single one")]
	[Parameter("Animation Speed", "Determines the speed coefficient applied to the animation played")]
	[Parameter("Transition In", "The time it takes to blend into the animation")]
	[Parameter("Transition Out", "The time it takes to blend out of the animation")]
	[Example("The Transition Out parameter is also used to determine the movement blend between the dash and the character's intended movement. Higher values will make characters take longer to regain control after dashing")]
	[Keywords(new string[] { "Leap", "Blink", "Roll", "Flash" })]
	[Image(typeof(IconCharacterDash), ColorTheme.Type.Blue)]
	public class InstructionCharacterNavigationDash : TInstructionCharacterNavigation
	{
		[Serializable]
		public struct DashAnimation
		{
			public enum AnimationMode
			{
				CardinalAnimation = 0,
				SingleAnimation = 1
			}

			[SerializeField]
			private AnimationMode m_Mode;

			[SerializeField]
			private AnimationClip m_AnimationForward;

			[SerializeField]
			private AnimationClip m_AnimationBackward;

			[SerializeField]
			private AnimationClip m_AnimationRight;

			[SerializeField]
			private AnimationClip m_AnimationLeft;

			[SerializeField]
			private AnimationClip m_Animation;

			public AnimationMode Mode => m_Mode;

			public AnimationClip GetClip(float angle)
			{
				AnimationClip result;
				switch (m_Mode)
				{
				case AnimationMode.CardinalAnimation:
					if (angle <= 45f)
					{
						if (!(angle >= -45f))
						{
							if (!(angle > -135f))
							{
								goto IL_004f;
							}
							result = m_AnimationRight;
						}
						else
						{
							result = m_AnimationForward;
						}
					}
					else
					{
						if (!(angle < 135f))
						{
							goto IL_004f;
						}
						result = m_AnimationLeft;
					}
					goto IL_0056;
				case AnimationMode.SingleAnimation:
					return m_Animation;
				default:
					{
						throw new ArgumentOutOfRangeException();
					}
					IL_0056:
					return result;
					IL_004f:
					result = m_AnimationBackward;
					goto IL_0056;
				}
			}
		}

		private const int DIRECTION_KEY = 5;

		[SerializeField]
		private PropertyGetDirection m_Direction = GetDirectionCharactersMoving.Create;

		[SerializeField]
		private PropertyGetDecimal m_Velocity = new PropertyGetDecimal(20f);

		[SerializeField]
		private PropertyGetDecimal m_Duration = new PropertyGetDecimal(0.25f);

		[SerializeField]
		[Range(0f, 1f)]
		private float m_Gravity = 1f;

		[SerializeField]
		private bool m_WaitToFinish = true;

		[SerializeField]
		private DashAnimation m_DashAnimation;

		[SerializeField]
		private float m_AnimationSpeed = 1f;

		[SerializeField]
		private float m_TransitionIn = 0.1f;

		[SerializeField]
		private float m_TransitionOut = 0.2f;

		public override string Title => $"Dash {m_Character} towards {m_Direction}";

		protected override async Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null || character.Busy.AreLegsBusy)
			{
				return;
			}
			Vector3 vector = m_Direction.Get(args);
			if (vector == Vector3.zero)
			{
				vector = character.transform.forward;
			}
			float speed = (float)m_Velocity.Get(args);
			float duration = (float)m_Duration.Get(args);
			if (!character.Dash.CanDash())
			{
				return;
			}
			Task task = character.Dash.Execute(vector, speed, m_Gravity, duration, m_TransitionOut);
			character.Busy.MakeLegsBusy();
			float angle = Vector3.SignedAngle(vector, character.transform.forward, Vector3.up);
			AnimationClip clip = m_DashAnimation.GetClip(angle);
			if (clip != null)
			{
				ConfigGesture config = new ConfigGesture(0f, clip.length, m_AnimationSpeed, rootMotion: false, m_TransitionIn, m_TransitionOut);
				character.Gestures.CrossFade(clip, null, BlendMode.Blend, config, stopPreviousGestures: true);
				if (m_DashAnimation.Mode == DashAnimation.AnimationMode.SingleAnimation)
				{
					character.Kernel.Facing.SetLayerDirection(5, vector, Math.Max(clip.length - m_TransitionOut, 0f));
				}
			}
			if (m_WaitToFinish)
			{
				await task;
			}
		}
	}
}
