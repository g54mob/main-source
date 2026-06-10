using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	public class WallViewComponent : BasicBuildingBlockViewComponent
	{
		protected override void OnObjectPlacedOnMap(bool afterLoading = false)
		{
			base.OnObjectPlacedOnMap(afterLoading);
			base.BaseBuildingInstance.RefreshWalkableColliderEvent += OnRefreshWalkableCollider;
		}

		protected override void OnDisposedInternal()
		{
			base.OnDisposedInternal();
			float animationDuration = Random.Range(0.35f, 0.46f);
			base.BaseBuildingViewComponent.AnimateObjectDestroyed(animationDuration, delegate
			{
				if (navmeshSurface != null)
				{
					navmeshSurface.SetActive(value: false);
				}
				base.BaseBuildingViewComponent.OnAfterDisposedInternalEvent();
			});
		}

		private void OnRefreshWalkableCollider()
		{
			if (base.BaseBuildingInstance != null && !base.BaseBuildingInstance.HasDisposed && !(navmeshSurface == null))
			{
				navmeshSurface.SetActive(base.BaseBuildingInstance.CanPlaceNavmeshAbove());
			}
		}
	}
}
