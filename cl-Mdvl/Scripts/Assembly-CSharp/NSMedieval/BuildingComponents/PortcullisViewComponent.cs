using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	public class PortcullisViewComponent : ComponentBaseView
	{
		[SerializeField]
		private DoorComponent doorComponent;

		[SerializeField]
		private List<MeshRenderer> meshRenderersForWorldPositionY;

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			doorComponent.AfterComponentPlacedEvent += OnAfterComponentPlaced;
		}

		private void OnAfterComponentPlaced()
		{
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				BaseBuildingInstance baseBuildingInstance = doorComponent?.BaseBuildingViewComponent?.BaseBuildingInstance;
				if (baseBuildingInstance == null || meshRenderersForWorldPositionY == null)
				{
					return;
				}
				float y = baseBuildingInstance.WorldPosition.y;
				foreach (MeshRenderer item in meshRenderersForWorldPositionY)
				{
					item.material.SetFloat("_WorldPositionY", y);
				}
			});
		}
	}
}
