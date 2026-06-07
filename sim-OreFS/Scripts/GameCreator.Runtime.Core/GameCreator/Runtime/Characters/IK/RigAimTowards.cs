using System;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters.IK
{
	[Serializable]
	[Title("Aim Pitch (Obsolete)")]
	[Category("Aim Pitch (Obsolete)")]
	[Image(typeof(IconAimTarget), ColorTheme.Type.Red)]
	[Description("Obsolete: Use Shooter IK. Aims with the bone upwards and downwards based on the rotation of an object")]
	public class RigAimTowards : TRigAnimatorIK
	{
		public const string RIG_NAME = "RigAimTowards";

		[SerializeField]
		private float m_SmoothTime = 0.1f;

		[SerializeField]
		private Bone m_Bone = new Bone(HumanBodyBones.Chest);

		[SerializeField]
		private PropertyGetGameObject m_From = GetGameObjectCameraMain.Create;

		[NonSerialized]
		private AnimFloat m_Pitch;

		public override string Title => $"Aim with {m_Bone} from {m_From}";

		public override string Name => "RigAimTowards";

		public override bool RequiresHuman => false;

		public override bool DisableOnBusy => false;

		protected float SmoothTime => m_SmoothTime / 57.29578f;

		protected override void DoEnable(Character character)
		{
			if (m_Pitch == null)
			{
				m_Pitch = new AnimFloat(0f, SmoothTime);
			}
			character.EventBeforeLateUpdate -= OnLateUpdate;
			character.EventBeforeLateUpdate += OnLateUpdate;
			base.DoEnable(character);
		}

		protected override void DoDisable(Character character)
		{
			character.EventBeforeLateUpdate -= OnLateUpdate;
			base.DoDisable(character);
		}

		protected override void DoUpdate(Character character)
		{
			base.DoUpdate(character);
			Transform transform = m_From.Get<Transform>(base.Args);
			float num = ((transform != null) ? transform.localRotation.eulerAngles.x : m_Pitch.Target);
			num -= ((num >= 180f) ? 360f : 0f);
			num += ((num <= -180f) ? 360f : 0f);
			m_Pitch.UpdateWithDelta(num, SmoothTime, character.Time.DeltaTime);
		}

		private void OnLateUpdate()
		{
			Transform transform = m_Bone.GetTransform(base.Character.Animim.Animator);
			if (!(transform == null))
			{
				Quaternion quaternion = Quaternion.Euler(m_Pitch.Current, 0f, 0f);
				transform.localRotation *= quaternion;
			}
		}
	}
}
