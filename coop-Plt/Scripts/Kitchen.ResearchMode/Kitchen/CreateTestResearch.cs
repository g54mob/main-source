using KitchenData;
using UnityEngine;

namespace Kitchen
{
	public class CreateTestResearch : ResearchFirstFrameSystem
	{
		protected override void OnUpdate()
		{
			Create(AssetReference.ResearchAppliance, new Vector3(0f, 0f, 3f), Vector3.back);
			Create(base.Data.Get<Item>(AssetReference.ResearchFlask), new Vector3(2f, 0f, 0f), Vector3.back);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
