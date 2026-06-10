using System;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(BaseBuildingViewComponent))]
	public class BasicBuildingBlockViewComponent : MonoBehaviour
	{
		[SerializeField]
		protected GameObject navmeshSurface;

		[NonSerialized]
		private BaseBuildingViewComponent baseBuildingViewComponent;

		protected BaseBuildingInstance BaseBuildingInstance => baseBuildingViewComponent.BaseBuildingInstance;

		protected BaseBuildingViewComponent BaseBuildingViewComponent => baseBuildingViewComponent;

		protected virtual void Awake()
		{
			baseBuildingViewComponent = GetComponent<BaseBuildingViewComponent>();
		}

		protected virtual void OnEnable()
		{
			baseBuildingViewComponent.EnterPoolEvent += OnEnterPool;
			baseBuildingViewComponent.ExitPoolEvent += OnExitPool;
			baseBuildingViewComponent.ReturnToBlueprintEvent += OnReturnToBlueprint;
			baseBuildingViewComponent.BaseBuildingEnterFoundationStateEvent += OnBaseBuildingEnterFoundationState;
			baseBuildingViewComponent.BaseBuildingEnterFinishedStateEvent += OnBaseBuildingEnterFinishedState;
			baseBuildingViewComponent.DisposedInternalEvent += OnDisposedInternal;
			baseBuildingViewComponent.ObjectPlacedOnMapEvent += OnObjectPlacedOnMap;
		}

		protected virtual void OnDisable()
		{
			if (!(baseBuildingViewComponent == null))
			{
				baseBuildingViewComponent.EnterPoolEvent -= OnEnterPool;
				baseBuildingViewComponent.ExitPoolEvent -= OnExitPool;
				baseBuildingViewComponent.ReturnToBlueprintEvent -= OnReturnToBlueprint;
				baseBuildingViewComponent.BaseBuildingEnterFoundationStateEvent -= OnBaseBuildingEnterFoundationState;
				baseBuildingViewComponent.BaseBuildingEnterFinishedStateEvent -= OnBaseBuildingEnterFinishedState;
				baseBuildingViewComponent.DisposedInternalEvent -= OnDisposedInternal;
				baseBuildingViewComponent.ObjectPlacedOnMapEvent -= OnObjectPlacedOnMap;
			}
		}

		protected virtual void OnObjectPlacedOnMap(bool afterLoading = false)
		{
			base.gameObject.layer = LayerMask.NameToLayer("BuildableSurface");
			navmeshSurface.SetActive(value: false);
		}

		protected void OnEnterPool()
		{
			navmeshSurface.SetActive(value: false);
		}

		protected void OnExitPool()
		{
		}

		protected void OnReturnToBlueprint()
		{
		}

		protected virtual void OnBaseBuildingEnterFoundationState()
		{
		}

		protected virtual void OnBaseBuildingEnterFinishedState()
		{
			if (BaseBuildingInstance != null && !BaseBuildingInstance.HasDisposed && !(navmeshSurface == null))
			{
				navmeshSurface.SetActive(BaseBuildingInstance.CanPlaceNavmeshAbove());
			}
		}

		protected virtual void OnDisposedInternal()
		{
		}
	}
}
