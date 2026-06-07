using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters.IK
{
	[Serializable]
	[Title("Align Feet with Ground")]
	[Category("Align Feet with Ground")]
	[Image(typeof(IconFootprint), ColorTheme.Type.Green)]
	[Description("IK system that allows the Character to correctly align their feet to uneven terrain. It also avoids character's feet from penetrating the floor. Requires a humanoid character")]
	public class RigFeetPlant : TRigAnimatorIK
	{
		public const string RIG_NAME = "RigFeetPlant";

		[SerializeField]
		private float m_FootOffset;

		[SerializeField]
		private LayerMask m_FootMask = -5;

		[SerializeField]
		private float m_SmoothTime = 0.25f;

		[NonSerialized]
		private FootPlant m_LimbFootL;

		[NonSerialized]
		private FootPlant m_LimbFootR;

		public override string Title => "Align Feet with Ground";

		public override string Name => "RigFeetPlant";

		public override bool RequiresHuman => true;

		public override bool DisableOnBusy => false;

		internal float FootOffset => m_FootOffset;

		internal LayerMask FootMask => m_FootMask;

		internal float SmoothTime => m_SmoothTime;

		protected override void DoEnable(Character character)
		{
			base.DoEnable(character);
			m_LimbFootL = new FootPlant(HumanBodyBones.LeftFoot, AvatarIKGoal.LeftFoot, this, 0);
			m_LimbFootR = new FootPlant(HumanBodyBones.RightFoot, AvatarIKGoal.RightFoot, this, 1);
		}

		protected override void DoUpdate(Character character)
		{
			base.DoUpdate(character);
			m_LimbFootL.Update();
			m_LimbFootR.Update();
		}
	}
}
