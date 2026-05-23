using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace LVA.Puppeteers.Humanoid
{
	[Serializable]
	public class HumanoidAnimationReferences
	{
		[field: SerializeField]
		public Animator Animator { get; private set; }

		public rg rnf
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		[field: SerializeField]
		public HumanoidPuppeteerBoneMapHandler ArmatureOriginal { get; private set; }

		[field: SerializeField]
		public HumanoidPuppeteerBoneMapHandler ArmatureReprojection { get; private set; }

		[field: SerializeField]
		public qv Pipeline { get; private set; }

		public void gns(HumanoidPuppeteerReferences a)
		{
		}

		public void gnt()
		{
		}
	}
}
