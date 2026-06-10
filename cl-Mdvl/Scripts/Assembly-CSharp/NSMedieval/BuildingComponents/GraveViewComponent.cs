using System;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(GraveComponent))]
	public class GraveViewComponent : ComponentBaseView
	{
		[SerializeField]
		private GameObject graveClosed;

		[SerializeField]
		private GameObject graveOpen;

		[NonSerialized]
		private GraveComponent graveComponent;

		public GraveComponentInstance ComponentInstance => graveComponent.ComponentInstance;

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			graveComponent = GetComponent<GraveComponent>();
		}

		protected override void OnComponentEnterFinishedState(bool afterLoading = false)
		{
			base.OnComponentEnterFinishedState();
			graveComponent.ComponentInstance.AddBodyEvent += OnAddBody;
			if (graveClosed != null)
			{
				MeshRenderer[] componentsInChildren = graveClosed.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
				MeshRenderer[] array = componentsInChildren;
				foreach (MeshRenderer item in array)
				{
					BaseBuildingViewComponent.FinishedMeshRenderers.Add(item);
				}
				BaseBuildingViewComponent.LayerObjectHide.AddComponentMeshRenderers(componentsInChildren);
			}
			if (afterLoading && ComponentInstance.HasBody())
			{
				CloseGrave();
			}
		}

		protected override void OnBuildingDisposed(IDisposable disposable)
		{
			if ((bool)graveOpen)
			{
				graveOpen.SetActive(value: false);
			}
			if ((bool)graveClosed)
			{
				graveClosed.SetActive(value: false);
			}
		}

		private void OnAddBody()
		{
			CloseGrave();
		}

		private void CloseGrave()
		{
			graveClosed.SetActive(value: true);
			if ((bool)graveOpen)
			{
				graveOpen.SetActive(value: false);
			}
		}
	}
}
