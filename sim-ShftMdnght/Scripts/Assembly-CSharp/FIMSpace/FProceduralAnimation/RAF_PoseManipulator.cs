using FIMSpace.FGenerating;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class RAF_PoseManipulator : RagdollAnimatorFeatureUpdate
	{
		private FUniversalVariable tolerMinV;

		private FUniversalVariable tolerMaxV;

		private FUniversalVariable addDampV;

		private FUniversalVariable springChangeV;

		private FUniversalVariable reverseLogicV;

		public override bool UseFixedUpdate => true;

		public override bool OnInit()
		{
			tolerMinV = base.InitializedWith.RequestVariable("Tolerance Min", 3f);
			tolerMaxV = base.InitializedWith.RequestVariable("Tolerance Max", 45f);
			addDampV = base.InitializedWith.RequestVariable("Add Damping", 100f);
			springChangeV = base.InitializedWith.RequestVariable("Spring Change", 0f);
			reverseLogicV = base.InitializedWith.RequestVariable("Reverse Logic", false);
			return base.OnInit();
		}

		public override void FixedUpdate()
		{
			if (!base.InitializedWith.Enabled)
			{
				return;
			}
			float num = (base.ParentRagdollHandler.IsInFallingMode ? base.ParentRagdollHandler.DampingValueOnFall : base.ParentRagdollHandler.DampingValue);
			num *= base.ParentRagdollHandler.MusclesPower * base.ParentRagdollHandler.musclesPowerMultiplier;
			float baseSpringValue = GetBaseSpringValue();
			float powerMultiplicator = GetPowerMultiplicator();
			float b = tolerMinV.GetFloat();
			float num2 = tolerMaxV.GetFloat();
			if (reverseLogicV.GetBool())
			{
				b = num2;
				num2 = tolerMinV.GetFloat();
			}
			float num3 = addDampV.GetFloat();
			float num4 = springChangeV.GetFloat();
			foreach (RagdollBonesChain chain in base.ParentRagdollHandler.Chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					float value = Quaternion.Angle(boneSetup.PhysicalDummyBone.rotation, boneSetup.BoneProcessor.AnimatorRotation);
					float num5 = Mathf.InverseLerp(num2, b, value);
					float num6 = num5 * num3;
					JointDrive slerpDrive = boneSetup.Joint.slerpDrive;
					slerpDrive.positionDamper = ((boneSetup.OverrideSpringDamp != 0f) ? boneSetup.OverrideSpringDamp : num) + num6;
					if (num4 != 0f)
					{
						float num7 = powerMultiplicator * baseSpringValue * chain.MusclesForce * boneSetup.ForceMultiplier + boneSetup.MusclesBoost * baseSpringValue * base.ParentRagdollHandler.targetMusclesPower;
						slerpDrive.positionSpring = ((boneSetup.OverrideSpringPower != 0f) ? boneSetup.OverrideSpringPower : num7) + num5 * num4;
					}
					boneSetup.Joint.slerpDrive = slerpDrive;
				}
			}
		}

		private float GetBaseSpringValue()
		{
			float num = 0f;
			if (base.ParentRagdollHandler.AnimatingMode == RagdollHandler.EAnimatingMode.Standing)
			{
				return base.ParentRagdollHandler.GetCurrentMainSpringsValue;
			}
			return (!base.ParentRagdollHandler.OverrideSpringsValueOnFall.HasValue) ? base.ParentRagdollHandler.GetCurrentMainSpringsValue : base.ParentRagdollHandler.OverrideSpringsValueOnFall.Value;
		}

		private float GetPowerMultiplicator()
		{
			return base.ParentRagdollHandler.targetMusclesPower * base.ParentRagdollHandler.targetMusclesPower;
		}
	}
}
