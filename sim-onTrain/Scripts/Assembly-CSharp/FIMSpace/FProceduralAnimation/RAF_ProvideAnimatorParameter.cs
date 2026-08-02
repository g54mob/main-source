using FIMSpace.FGenerating;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class RAF_ProvideAnimatorParameter : RagdollAnimatorFeatureUpdate
	{
		private int _h_velocity = -1;

		private float _sd;

		public override bool UseUpdate => true;

		public override bool OnInit()
		{
			FUniversalVariable fUniversalVariable = base.InitializedWith.RequestVariable("Set Velocity For:", "");
			if (!string.IsNullOrWhiteSpace(fUniversalVariable.GetString()))
			{
				_h_velocity = Animator.StringToHash(fUniversalVariable.GetString());
			}
			return base.OnInit();
		}

		public override void Update()
		{
			if (base.InitializedWith.Enabled)
			{
				if (_h_velocity != -1)
				{
					float magnitude = base.ParentRagdollHandler.User_GetChainBonesVelocity(ERagdollChainType.Core).magnitude;
					float current = base.ParentRagdollHandler.Mecanim.GetFloat(_h_velocity);
					current = Mathf.SmoothDamp(current, magnitude, ref _sd, 0.125f, 10000f, base.ParentRagdollHandler.Delta);
					base.ParentRagdollHandler.Mecanim.SetFloat(_h_velocity, current);
				}
				base.Update();
			}
		}
	}
}
