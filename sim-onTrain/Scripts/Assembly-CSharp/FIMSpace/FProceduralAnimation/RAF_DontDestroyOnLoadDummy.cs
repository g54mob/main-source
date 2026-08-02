using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class RAF_DontDestroyOnLoadDummy : RagdollAnimatorFeatureBase
	{
		public override bool OnInit()
		{
			Object.DontDestroyOnLoad(base.ParentRagdollHandler.Dummy_Container);
			return base.OnInit();
		}
	}
}
