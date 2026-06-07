using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class RAF_IgnoreCollisionWith : RagdollAnimatorFeatureBase
	{
		public override bool OnInit()
		{
			if (base.InitializedWith.customObjectList == null)
			{
				return false;
			}
			for (int i = 0; i < base.InitializedWith.customObjectList.Count; i++)
			{
				Collider collider = base.InitializedWith.customObjectList[i] as Collider;
				if (!(collider == null))
				{
					base.ParentRagdollHandler.IgnoreCollisionWith(collider);
				}
			}
			return true;
		}
	}
}
