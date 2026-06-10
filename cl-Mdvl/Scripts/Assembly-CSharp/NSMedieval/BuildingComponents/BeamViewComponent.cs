using System;
using FoxyVoxel.Logging;
using NSEipix;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(BeamComponent))]
	public class BeamViewComponent : ComponentBaseView
	{
		[NonSerialized]
		private BeamComponent beamComponent;

		[SerializeField]
		private GameObject[] scalableElements;

		[SerializeField]
		private GameObject[] movableSupportRight;

		[SerializeField]
		private GameObject[] movableSupportLeft;

		private Collider[] clickColliders;

		private BeamComponentInstance BeamComponentInstance => beamComponent.ComponentInstance;

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			beamComponent = GetComponent<BeamComponent>();
			beamComponent.AfterComponentPlacedEvent += OnAfterComponentPlaced;
			beamComponent.EnableCollidersEvent += OnEnableColliders;
			clickColliders = BaseBuildingViewComponent.Blueprint.GetComponentsInChildren<Collider>();
			BaseBuildingViewComponent.ClickCollider = base.gameObject.GetComponent<Collider>();
			BaseBuildingViewComponent.LayerObjectHide.SetupColliders(clickColliders);
			UpdateOcclusionBoundingBox();
		}

		protected override void OnBuildingDisposed(IDisposable disposable)
		{
			base.OnBuildingDisposed(disposable);
			beamComponent.EnableCollidersEvent -= OnEnableColliders;
		}

		private void OnEnableColliders(bool value)
		{
			if (value)
			{
				BaseBuildingViewComponent.LayerObjectHide.ActivateColliders();
			}
			else
			{
				BaseBuildingViewComponent.LayerObjectHide.ForceDeactivateColliders();
			}
			UpdateOcclusionBoundingBox();
		}

		private void SetupPositionAndScale(Vector3 rightOffset, Vector3 leftOffset, Vector3 scale)
		{
			leftOffset.y = movableSupportLeft[0].transform.localPosition.y;
			rightOffset.y = movableSupportRight[0].transform.localPosition.y;
			GameObject[] array = movableSupportLeft;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].transform.localPosition = leftOffset;
			}
			array = movableSupportRight;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].transform.localPosition = rightOffset;
			}
			array = scalableElements;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].transform.localScale = scale;
			}
			GetComponent<Shaker>()?.Initialize();
			UpdateOcclusionBoundingBox();
		}

		private void SynchronizeTransformWithBeamInstance()
		{
			if (this == null)
			{
				Log.Warning("BeamViewComponent is null. This is a fail-safe.", "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Beams\\BeamViewComponent.cs");
				return;
			}
			Vec3Int vec3Int = BeamComponentInstance.StartSocketGridPosition.ToVec3IntWorld();
			Vec3Int vec3Int2 = BeamComponentInstance.EndSocketGridPosition.ToVec3IntWorld();
			Vector3 position;
			float num;
			if (vec3Int.x != vec3Int2.x)
			{
				position = new Vector3((float)(vec3Int.x + vec3Int2.x) / 2f, vec3Int.y, vec3Int.z);
				num = Mathf.Abs(vec3Int.x - vec3Int2.x) - 1;
			}
			else
			{
				position = new Vector3(vec3Int2.x, vec3Int2.y, (float)(vec3Int.z + vec3Int2.z) / 2f);
				num = Mathf.Abs(vec3Int.z - vec3Int2.z) - 1;
			}
			base.transform.position = position;
			SetupPositionAndScale(new Vector3((0f - num) / 2f, 0f, 0f), new Vector3(num / 2f, 0f, 0f), new Vector3(num, 1f, 1f));
		}

		protected override void OnComponentEnterFoundationState()
		{
			if (!(BaseBuildingViewComponent == null) && BaseBuildingViewComponent.BaseBuildingInstance != null && !BaseBuildingViewComponent.BaseBuildingInstance.HasDisposed)
			{
				base.OnComponentEnterFoundationState();
				clickColliders = BaseBuildingViewComponent.Foundation.GetComponentsInChildren<Collider>(includeInactive: true);
				BaseBuildingViewComponent.LayerObjectHide.SetupColliders(clickColliders);
				BaseBuildingViewComponent.OnPlayParticlesFromColliderVolume("foundation_appear");
				UpdateOcclusionBoundingBox();
			}
		}

		protected override void OnComponentEnterFinishedState(bool afterLoading = false)
		{
			base.OnComponentEnterFinishedState(afterLoading);
			SetupClickColliders();
		}

		private void OnAfterComponentPlaced()
		{
			if (!(BaseBuildingViewComponent == null) && BaseBuildingViewComponent.BaseBuildingInstance != null && !BaseBuildingViewComponent.BaseBuildingInstance.HasDisposed)
			{
				SynchronizeTransformWithBeamInstance();
				clickColliders = BaseBuildingViewComponent.Blueprint.GetComponentsInChildren<Collider>();
				BaseBuildingViewComponent.ClickCollider = base.gameObject.GetComponent<Collider>();
				BaseBuildingViewComponent.LayerObjectHide.SetupColliders(clickColliders);
				UpdateOcclusionBoundingBox();
			}
		}

		private void SetupClickColliders()
		{
			clickColliders = BaseBuildingViewComponent.Finished.GetComponentsInChildren<Collider>(includeInactive: true);
			BaseBuildingViewComponent.LayerObjectHide.SetupColliders(clickColliders);
			Collider[] array = clickColliders;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enabled = true;
			}
			UpdateOcclusionBoundingBox();
		}

		private void UpdateOcclusionBoundingBox()
		{
			Bounds bounds = clickColliders[0].bounds;
			for (int i = 0; i < clickColliders.Length; i++)
			{
				bounds.Encapsulate(clickColliders[i].bounds);
			}
			bounds.center -= BaseBuildingViewComponent.transform.position;
			BaseBuildingViewComponent.OcclusionLocalSpaceBoundingBox = bounds;
		}
	}
}
