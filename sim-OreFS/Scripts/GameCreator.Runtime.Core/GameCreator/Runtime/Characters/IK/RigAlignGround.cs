using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters.IK
{
	[Serializable]
	[Title("Align Body with Ground")]
	[Category("Align Body with Ground")]
	[Image(typeof(IconFloorNormal), ColorTheme.Type.Green)]
	[Description("Aligns the entire model with the normal vector from the ground")]
	public class RigAlignGround : TRigAnimatorIK
	{
		public const string RIG_NAME = "RigAlignGround";

		[NonSerialized]
		private AnimVector3 m_Normal;

		[SerializeField]
		private float m_SmoothTime = 0.25f;

		[SerializeField]
		private float m_MaxAngle = 35f;

		public override string Title => "Align with Ground";

		public override string Name => "RigAlignGround";

		public override bool RequiresHuman => false;

		public override bool DisableOnBusy => false;

		protected override void DoEnable(Character character)
		{
			base.DoEnable(character);
			m_Normal = new AnimVector3(Vector3.up, m_SmoothTime);
		}

		protected override void DoUpdate(Character character)
		{
			base.DoUpdate(character);
			Vector3 vector = character.transform.InverseTransformDirection(character.Driver.FloorNormal);
			float deltaTime = character.Time.DeltaTime;
			m_Normal.UpdateWithDelta((character.Driver.IsGrounded && vector.magnitude >= 0.5f) ? vector : Vector3.up, deltaTime);
			Vector3 toDirection = Vector3.MoveTowards(Vector3.up, m_Normal.Current, m_MaxAngle);
			Quaternion rotation = Quaternion.FromToRotation(Vector3.up, toDirection);
			character.Animim.Rotation = rotation;
			character.Animim.ApplyMannequinRotation();
		}
	}
}
