using System;
using NSEipix.Base;
using NSMedieval.Terrain;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(SocketComponent))]
	public class VoxelBuildingComponent : BaseComponent
	{
		[NonSerialized]
		private SocketComponent socketComponent;

		protected override void OnDestroy()
		{
			base.OnDestroy();
			socketComponent = null;
		}

		protected override void OnBaseBuildingEnterFinishedState(bool afterLoading = false)
		{
			MonoSingleton<GroundController>.Instance.AddVoxel(base.OwnerBuilding);
			socketComponent?.ComponentInstance?.ReattachToVoxelAndDisposeComponent();
			base.OwnerBuilding.Map.BuildingsManagerMain.DestroyVoxelBuilding(base.OwnerBuilding);
		}

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			socketComponent = GetComponent<SocketComponent>();
		}
	}
}
