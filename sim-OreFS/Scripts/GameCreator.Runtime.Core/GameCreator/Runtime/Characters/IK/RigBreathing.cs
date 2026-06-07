using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters.IK
{
	[Serializable]
	[Title("Breathing")]
	[Category("Breathing")]
	[Image(typeof(IconHeartBeat), ColorTheme.Type.Green)]
	[Description("Rotates the bones around the chest in a breathing motion fashion")]
	public class RigBreathing : TRigAnimatorIK
	{
		private const float REST_ANGLE_CHEST = 2f;

		private const float REST_ANGLE_UPPER_CHEST = 4f;

		public const string RIG_NAME = "RigBreathing";

		[SerializeField]
		private PropertyGetDecimal m_Exertion = new PropertyGetDecimal(1f);

		[SerializeField]
		private PropertyGetDecimal m_Rate = new PropertyGetDecimal(0.3f);

		public override string Title => "Breathe";

		public override string Name => "RigBreathing";

		public override bool RequiresHuman => true;

		public override bool DisableOnBusy => false;

		protected override void DoEnable(Character character)
		{
			base.DoEnable(character);
			character.EventBeforeLateUpdate -= OnLateUpdate;
			character.EventBeforeLateUpdate += OnLateUpdate;
		}

		protected override void DoDisable(Character character)
		{
			base.DoDisable(character);
			character.EventBeforeLateUpdate -= OnLateUpdate;
		}

		private void OnLateUpdate()
		{
			Transform boneTransform = base.Character.Animim.Animator.GetBoneTransform(HumanBodyBones.Chest);
			Transform boneTransform2 = base.Character.Animim.Animator.GetBoneTransform(HumanBodyBones.UpperChest);
			Transform boneTransform3 = base.Character.Animim.Animator.GetBoneTransform(HumanBodyBones.Neck);
			Transform boneTransform4 = base.Character.Animim.Animator.GetBoneTransform(HumanBodyBones.LeftShoulder);
			Transform boneTransform5 = base.Character.Animim.Animator.GetBoneTransform(HumanBodyBones.RightShoulder);
			float num = Mathf.Max(0f, (float)m_Exertion.Get(base.Args));
			float num2 = Mathf.Max(0f, (float)m_Rate.Get(base.Args));
			float num3 = Mathf.Sin(base.Character.Time.Time * MathF.PI * 2f * num2);
			Vector3 axis = boneTransform4.position - boneTransform5.position;
			float angle = num3 * num * 2f;
			float angle2 = num3 * num * 4f;
			boneTransform.Rotate(axis, angle, Space.World);
			boneTransform2.Rotate(axis, angle2, Space.World);
			float angle3 = num3 * num * -6f;
			boneTransform3.Rotate(axis, angle3, Space.World);
			boneTransform4.Rotate(axis, angle3, Space.World);
			boneTransform5.Rotate(axis, angle3, Space.World);
		}
	}
}
