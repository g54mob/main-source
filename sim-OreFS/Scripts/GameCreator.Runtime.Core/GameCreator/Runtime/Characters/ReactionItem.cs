using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Image(typeof(IconReaction), ColorTheme.Type.TextLight)]
	public class ReactionItem : TPolymorphicItem<ReactionItem>
	{
		private const float INFINITE = 9999f;

		[SerializeField]
		private EnablerFloat m_MinPower = new EnablerFloat(isEnabled: false, 1f);

		[SerializeField]
		private ReactionDirection m_Direction;

		[SerializeField]
		private RunConditionsList m_Conditions = new RunConditionsList();

		[SerializeField]
		private AvatarMask m_AvatarMask;

		[SerializeField]
		private EnablerFloat m_CancelTime = new EnablerFloat(isEnabled: false, 0.5f);

		[SerializeField]
		private ReactionRotation m_Rotation;

		[SerializeField]
		[Range(0f, 1f)]
		private float m_Gravity = 1f;

		[SerializeField]
		private ReactionAnimations m_Animations = new ReactionAnimations();

		public AnimationClip AnimationClip => m_Animations.AnimationClip;

		public AvatarMask AvatarMask => m_AvatarMask;

		public float CancelTime
		{
			get
			{
				if (!m_CancelTime.IsEnabled)
				{
					return 9999f;
				}
				return m_CancelTime.Value;
			}
		}

		public ReactionRotation Rotation => m_Rotation;

		public float Gravity => m_Gravity;

		public override string Title
		{
			get
			{
				string text = TextUtils.Humanize(m_Direction).ToLower();
				string text3;
				if (m_Direction != ReactionDirection.FromAny)
				{
					object arg = char.ToUpper(text[0]);
					string text2 = text;
					text3 = $"{arg}{text2.Substring(1, text2.Length - 1)}";
				}
				else
				{
					object arg2 = char.ToUpper(text[0]);
					string text2 = text;
					text3 = $"{arg2}{text2.Substring(1, text2.Length - 1)} direction";
				}
				text = text3;
				string text4 = (m_MinPower.IsEnabled ? $" with Power ≥ {m_MinPower.Value}" : "");
				string text5 = m_Conditions.ToString();
				string text6;
				if (string.IsNullOrEmpty(text5))
				{
					text6 = text5;
				}
				else
				{
					object arg3 = char.ToLower(text5[0]);
					string text2 = text5;
					text6 = $" and {arg3}{text2.Substring(1, text2.Length - 1)}";
				}
				text5 = text6;
				return text + text4 + text5;
			}
		}

		public bool CheckPower(float power)
		{
			if (m_MinPower.IsEnabled)
			{
				return m_MinPower.Value <= power;
			}
			return true;
		}

		public bool CheckDirection(Vector3 direction)
		{
			Vector3 vector = Vector3.Scale(direction, Vector3Plane.NormalUp);
			return m_Direction switch
			{
				ReactionDirection.FromAny => true, 
				ReactionDirection.FromTop => direction.y <= -0.5f, 
				ReactionDirection.FromBottom => direction.y >= 0.5f, 
				ReactionDirection.FromLeft => vector.x >= 0.5f, 
				ReactionDirection.FromRight => vector.x <= -0.5f, 
				ReactionDirection.FromFront => vector.z <= -0.5f, 
				ReactionDirection.FromBack => vector.z >= 0.5f, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		public bool CheckConditions(Args args)
		{
			return m_Conditions.Check(args);
		}
	}
}
