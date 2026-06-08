using KitchenData;
using UnityEngine;

namespace Kitchen
{
	public class CreateTutorialTrigger : FranchiseFirstFrameSystem
	{
		protected override void OnUpdate()
		{
			Create(base.Data.Get<Appliance>(AssetReference.TutorialTrigger), new Vector3(5f, 0f, 7f), Vector3.left);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
