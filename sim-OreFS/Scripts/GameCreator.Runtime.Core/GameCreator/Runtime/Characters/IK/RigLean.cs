using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters.IK
{
	[Serializable]
	[Title("Lean with Momentum")]
	[Category("Lean with Momentum")]
	[Image(typeof(IconCharacterWalk), ColorTheme.Type.Green)]
	[Description("Forces Characters to lean towards the acceleration direction and towards the opposite direction when decelerating")]
	public class RigLean : TRigAnimatorIK
	{
		public const string RIG_NAME = "RigLeanMomentum";

		[NonSerialized]
		private Vector3 m_LastMoveDirection;

		[NonSerialized]
		private LeanSection[] m_LeanSections;

		[SerializeField]
		private float m_InclineSpine = 5f;

		[SerializeField]
		private float m_InclineLowerChest = 10f;

		[SerializeField]
		private float m_InclineUpperChest = 5f;

		[SerializeField]
		private float m_DeclineSpine = -10f;

		[SerializeField]
		private float m_DeclineLowerChest = -5f;

		[SerializeField]
		private float m_DeclineUpperChest = 5f;

		[SerializeField]
		private float m_RollSpine = 5f;

		[SerializeField]
		private float m_RollLowerChest = 5f;

		[SerializeField]
		private float m_RollUpperChest = 10f;

		public override string Title => "Lean with Momentum";

		public override string Name => "RigLeanMomentum";

		public override bool RequiresHuman => true;

		public override bool DisableOnBusy => true;

		protected override void DoEnable(Character character)
		{
			base.DoEnable(character);
			m_LeanSections = new LeanSection[3]
			{
				new LeanSection(this, HumanBodyBones.Spine, m_RollSpine, m_DeclineSpine, m_InclineSpine),
				new LeanSection(this, HumanBodyBones.UpperChest, m_RollLowerChest, m_DeclineLowerChest, m_InclineLowerChest),
				new LeanSection(this, HumanBodyBones.Chest, m_RollUpperChest, m_DeclineUpperChest, m_InclineUpperChest)
			};
			m_LastMoveDirection = character.Driver.LocalMoveDirection;
		}

		protected override void DoUpdate(Character character)
		{
			base.DoUpdate(character);
			float deltaTime = character.Time.DeltaTime;
			float num = character.Driver.LocalMoveDirection.z - m_LastMoveDirection.z;
			num = ((deltaTime > float.Epsilon) ? (num / deltaTime) : 0f);
			m_LastMoveDirection = character.Driver.LocalMoveDirection;
			float num2 = ((num >= 0f) ? Mathf.InverseLerp(0f, character.Motion.LinearSpeed, num) : Mathf.InverseLerp(0f, 0f - character.Motion.LinearSpeed, num));
			float num3 = Mathf.InverseLerp(0f, character.Motion.LinearSpeed, Math.Abs(character.Driver.LocalMoveDirection.x));
			num2 *= (float)Math.Sign(num);
			num3 *= (float)Math.Sign(character.Driver.LocalMoveDirection.x);
			LeanSection[] leanSections = m_LeanSections;
			for (int i = 0; i < leanSections.Length; i++)
			{
				leanSections[i].Update(num2, num3);
			}
		}
	}
}
