using System;
using System.Collections.Generic;
using AwesomeTechnologies.BillboardSystem;
using AwesomeTechnologies.Utility.Culling;
using Unity.Jobs;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[Serializable]
	public class VegetationStudioCamera
	{
		public delegate void MultiOnVegetationCellVisibityChangedDelegate(VegetationStudioCamera vegetationStudioCamera, VegetationCell vegetationCell);

		public delegate void MultiOnVegetationDistanceBandChangeDelegate(VegetationStudioCamera vegetationStudioCamera, VegetationCell vegetationCell, int distanceBand, int previousDistanceBand);

		[SerializeField]
		public Camera SelectedCamera;

		public VegetationStudioCameraType VegetationStudioCameraType;

		public JobCullingGroup JobCullingGroup;

		public JobCullingGroup BillboardJobCullingGroup;

		public MultiOnVegetationCellVisibityChangedDelegate OnVegetationCellVisibleDelegate;

		public MultiOnVegetationCellVisibityChangedDelegate OnVegetationCellInvisibleDelegate;

		public MultiOnVegetationCellVisibityChangedDelegate OnPotentialCellInvisibleDelegate;

		public MultiOnVegetationDistanceBandChangeDelegate OnVegetationCellDistanceBandChangeDelegate;

		public bool RenderDirectToCamera;

		public bool RenderBillboardsOnly;

		public CameraCullingMode CameraCullingMode;

		public VegetationSystemPro VegetationSystemPro;

		private Vector3 _potentialCellsCenterPosition = new Vector3(0f, -10000f, 0f);

		private float _potentialCellPadding = 100f;

		private float _lastVegetationDistance;

		private bool _dirty;

		private Vector3 _floatingOriginOffset = new Vector3(0f, 0f, 0f);

		public GameObject WindSampler;

		private JobHandle _currentJobHandle;

		[NonSerialized]
		public List<VegetationStudioCameraRenderList> VegetationStudioCameraRenderList;

		[NonSerialized]
		public List<VegetationCell> PotentialVisibleVegetationCellList;

		public bool Enabled => IsEnabled();

		private bool IsEnabled()
		{
			bool isPlaying = Application.isPlaying;
			if (VegetationStudioCameraRenderList == null)
			{
				return false;
			}
			if (JobCullingGroup == null)
			{
				return false;
			}
			if (BillboardJobCullingGroup == null)
			{
				return false;
			}
			if (!isPlaying && VegetationStudioCameraType == VegetationStudioCameraType.SceneView)
			{
				return true;
			}
			if (VegetationStudioCameraType == VegetationStudioCameraType.Normal && !isPlaying)
			{
				return false;
			}
			if (SelectedCamera == null)
			{
				Debug.Log("no camera");
				return false;
			}
			if ((bool)SelectedCamera && SelectedCamera.enabled)
			{
				return SelectedCamera.gameObject.activeInHierarchy;
			}
			return false;
		}

		public VegetationStudioCamera(Camera selectedCamera)
		{
			SelectedCamera = selectedCamera;
		}

		private Vector3 GetCameraPosition()
		{
			return SelectedCamera.transform.position - _floatingOriginOffset;
		}

		public void SetFloatingOriginOffset(Vector3 floatingOriginOffset)
		{
			_floatingOriginOffset = floatingOriginOffset;
			JobCullingGroup?.SetFloatingOriginOffset(floatingOriginOffset);
			BillboardJobCullingGroup?.SetFloatingOriginOffset(floatingOriginOffset);
		}

		public VegetationStudioCamera(VegetationStudioCameraType vegetationStudioCameraType)
		{
		}

		private void OnChangedSceneViewCameraDelegate(Camera camera)
		{
			SelectedCamera = camera;
			Dispose();
		}

		public void SetDirty()
		{
			_dirty = true;
		}

		public void PreCullVegetation(bool forceUpdate)
		{
			if ((bool)SelectedCamera)
			{
				if (JobCullingGroup == null)
				{
					CreateCullingGroup();
				}
				if (BillboardJobCullingGroup == null)
				{
					CreateBillboardCullingGroup();
				}
				UpdatePotentialVisibleCells(forceUpdate);
				JobCullingGroup.CameraCullingMode = CameraCullingMode;
				BillboardJobCullingGroup.CameraCullingMode = CameraCullingMode;
				BillboardJobCullingGroup.AddShadowCells = false;
			}
		}

		public JobHandle ScheduleCullVegetationJob(JobHandle dependsOn)
		{
			if (JobCullingGroup == null)
			{
				return default(JobHandle);
			}
			_currentJobHandle = JobCullingGroup.Cull(dependsOn);
			_currentJobHandle = BillboardJobCullingGroup.Cull(_currentJobHandle);
			return _currentJobHandle;
		}

		public void ProcessEvents()
		{
			JobCullingGroup?.ProcessEvents();
			JobCullingGroup?.ProcessDistanceBandEvents();
		}

		public void PrepareRenderLists(List<VegetationPackagePro> vegetationSystemProList)
		{
			if (!ValidateVegetationStudioCameraRenderList(vegetationSystemProList))
			{
				DisposeVegetationStudioCameraRenderList();
			}
			if (VegetationStudioCameraRenderList == null)
			{
				VegetationStudioCameraRenderList = new List<VegetationStudioCameraRenderList>(vegetationSystemProList.Count);
				for (int i = 0; i <= vegetationSystemProList.Count - 1; i++)
				{
					VegetationStudioCameraRenderList.Add(new VegetationStudioCameraRenderList(vegetationSystemProList[i].VegetationInfoList.Count));
				}
			}
		}

		private void UpdatePotentialVisibleCells(bool forceUpdate)
		{
			Vector3 cameraPosition = GetCameraPosition();
			_potentialCellPadding = VegetationSystemPro.VegetationCellSize * 2f;
			bool flag = forceUpdate;
			if (PotentialVisibleVegetationCellList == null)
			{
				PotentialVisibleVegetationCellList = new List<VegetationCell>();
				flag = true;
			}
			if (Vector3.Distance(_potentialCellsCenterPosition, cameraPosition) > VegetationSystemPro.VegetationCellSize || Math.Abs(_lastVegetationDistance - VegetationSystemPro.VegetationSettings.GetTreeDistance()) > 0.1f || _dirty)
			{
				flag = true;
				_potentialCellsCenterPosition = cameraPosition;
				_lastVegetationDistance = VegetationSystemPro.VegetationSettings.GetTreeDistance();
			}
			if (!flag)
			{
				return;
			}
			_dirty = false;
			JobCullingGroup.VisibleCellIndexList.Clear();
			float num = VegetationSystemPro.VegetationSettings.GetTreeDistance() * 2f + _potentialCellPadding * 2f;
			Vector2 position = new Vector2(cameraPosition.x - num / 2f, cameraPosition.z - num / 2f);
			Rect rect = new Rect(position, new Vector2(num, num));
			if (OnPotentialCellInvisibleDelegate != null)
			{
				for (int i = 0; i <= PotentialVisibleVegetationCellList.Count - 1; i++)
				{
					VegetationCell vegetationCell = PotentialVisibleVegetationCellList[i];
					if (!vegetationCell.Rectangle.Overlaps(rect))
					{
						OnPotentialCellInvisibleDelegate(this, vegetationCell);
					}
				}
			}
			PotentialVisibleVegetationCellList.Clear();
			VegetationSystemPro.VegetationCellQuadTree.Query(rect, PotentialVisibleVegetationCellList);
			UpdateCullingGroup();
			if (VegetationSystemPro.LoadPotentialVegetationCells)
			{
				VegetationSystemPro.PredictiveCellLoader.ClearNonImportant();
				VegetationSystemPro.PredictiveCellLoader.PreloadArea(PotentialVisibleVegetationCellList, important: false);
			}
		}

		private void CreateCullingGroup()
		{
			JobCullingGroup?.Dispose();
			JobCullingGroup = new JobCullingGroup
			{
				TargetCamera = SelectedCamera
			};
			JobCullingGroup jobCullingGroup = JobCullingGroup;
			jobCullingGroup.OnStateChanged = (JobCullingGroup.StateChanged)Delegate.Combine(jobCullingGroup.OnStateChanged, new JobCullingGroup.StateChanged(OnStateChanged));
			JobCullingGroup jobCullingGroup2 = JobCullingGroup;
			jobCullingGroup2.OnDistanceBandStateChanged = (JobCullingGroup.StateChanged)Delegate.Combine(jobCullingGroup2.OnDistanceBandStateChanged, new JobCullingGroup.StateChanged(OnDistanceBandStateChanged));
		}

		private void CreateBillboardCullingGroup()
		{
			BillboardJobCullingGroup?.Dispose();
			BillboardJobCullingGroup = new JobCullingGroup
			{
				TargetCamera = SelectedCamera
			};
			UpdateBillboardCullingGroup();
		}

		public void UpdateBillboardCullingGroup()
		{
			if (BillboardJobCullingGroup != null)
			{
				float num = VegetationSystemPro.BillboardCellSize;
				if (!Application.isPlaying)
				{
					num = 200f;
				}
				BillboardJobCullingGroup.DistanceBandList.Clear();
				BillboardJobCullingGroup.DistanceBandList.Add(VegetationSystemPro.VegetationSettings.GetBillboardDistance() + num);
				BillboardJobCullingGroup.BundingSphereInfoList.Clear();
				if (BillboardJobCullingGroup.BundingSphereInfoList.Capacity < VegetationSystemPro.BillboardCellList.Count)
				{
					BillboardJobCullingGroup.BundingSphereInfoList.Capacity = VegetationSystemPro.BillboardCellList.Count;
				}
				for (int i = 0; i <= VegetationSystemPro.BillboardCellList.Count - 1; i++)
				{
					BoundingSphereInfo value = new BoundingSphereInfo
					{
						BoundingSphere = VegetationSystemPro.BillboardCellList[i].GetBoundingSphere(),
						LastVisisbility = -1,
						CurrentDistanceBand = -1,
						Enabled = 1
					};
					BillboardJobCullingGroup.BundingSphereInfoList.Add(value);
				}
			}
		}

		private void UpdateCullingGroup()
		{
			JobCullingGroup.DistanceBandList.Clear();
			JobCullingGroup.DistanceBandList.Add(VegetationSystemPro.VegetationSettings.GetVegetationDistance() + VegetationSystemPro.VegetationCellSize);
			JobCullingGroup.DistanceBandList.Add(VegetationSystemPro.VegetationSettings.GetTreeDistance() + VegetationSystemPro.VegetationCellSize);
			JobCullingGroup.BundingSphereInfoList.Clear();
			if (JobCullingGroup.BundingSphereInfoList.Capacity < PotentialVisibleVegetationCellList.Count)
			{
				JobCullingGroup.BundingSphereInfoList.Capacity = PotentialVisibleVegetationCellList.Count;
			}
			float additionalBoundingSphereRadius = VegetationSystemPro.AdditionalBoundingSphereRadius;
			for (int i = 0; i <= PotentialVisibleVegetationCellList.Count - 1; i++)
			{
				BoundingSphere boundingSphere = PotentialVisibleVegetationCellList[i].GetBoundingSphere();
				boundingSphere.radius += additionalBoundingSphereRadius;
				BoundingSphereInfo value = new BoundingSphereInfo
				{
					BoundingSphere = boundingSphere,
					LastVisisbility = 0,
					CurrentDistanceBand = -1,
					PreviousDistanceBand = -1,
					Enabled = PotentialVisibleVegetationCellList[i].EnabledInt
				};
				JobCullingGroup.BundingSphereInfoList.Add(value);
			}
		}

		public BoundingSphereInfo GetBoundingSphereInfo(int potentialVisibleVegetationCellIndex)
		{
			return JobCullingGroup.BundingSphereInfoList[potentialVisibleVegetationCellIndex];
		}

		private void OnStateChanged(JobCullingGroupEvent sphere)
		{
			if (sphere.IsVisible)
			{
				OnVegetationCellVisibleDelegate?.Invoke(this, PotentialVisibleVegetationCellList[sphere.Index]);
			}
			else
			{
				OnVegetationCellInvisibleDelegate?.Invoke(this, PotentialVisibleVegetationCellList[sphere.Index]);
			}
		}

		private void OnDistanceBandStateChanged(JobCullingGroupEvent sphere)
		{
			OnVegetationCellDistanceBandChangeDelegate?.Invoke(this, PotentialVisibleVegetationCellList[sphere.Index], sphere.CurrentDistanceBand, sphere.PreviousDistanceBand);
		}

		private void DisposeVegetationStudioCameraRenderList()
		{
			if (VegetationStudioCameraRenderList != null)
			{
				for (int i = 0; i <= VegetationStudioCameraRenderList.Count - 1; i++)
				{
					VegetationStudioCameraRenderList[i].Dispose();
				}
				VegetationStudioCameraRenderList.Clear();
			}
			VegetationStudioCameraRenderList = null;
		}

		private bool ValidateVegetationStudioCameraRenderList(List<VegetationPackagePro> vegetationPackageProList)
		{
			if (VegetationStudioCameraRenderList?.Count != vegetationPackageProList.Count)
			{
				return false;
			}
			for (int i = 0; i <= VegetationStudioCameraRenderList.Count - 1; i++)
			{
				if (VegetationStudioCameraRenderList[i].VegetationItemMergeMatrixList.Count != vegetationPackageProList[i].VegetationInfoList.Count)
				{
					return false;
				}
			}
			return true;
		}

		public void Dispose()
		{
			PotentialVisibleVegetationCellList?.Clear();
			JobCullingGroup?.Dispose();
			JobCullingGroup = null;
			BillboardJobCullingGroup?.Dispose();
			BillboardJobCullingGroup = null;
			DisposeVegetationStudioCameraRenderList();
			_potentialCellsCenterPosition = new Vector3(0f, -10000f, 0f);
		}

		public void RemoveDelegates()
		{
		}

		public void DrawVisibleCellGizmos()
		{
			if (JobCullingGroup == null)
			{
				return;
			}
			Gizmos.color = Color.white;
			for (int i = 0; i <= JobCullingGroup.VisibleCellIndexList.Length - 1; i++)
			{
				int index = JobCullingGroup.VisibleCellIndexList[i];
				if (PotentialVisibleVegetationCellList[index].Enabled)
				{
					Gizmos.color = GetDistanceBandColor(JobCullingGroup.BundingSphereInfoList[index].CurrentDistanceBand);
					Gizmos.DrawWireCube(PotentialVisibleVegetationCellList[index].VegetationCellBounds.center, PotentialVisibleVegetationCellList[index].VegetationCellBounds.size);
				}
			}
		}

		private Color GetDistanceBandColor(int distanceBand)
		{
			switch (distanceBand)
			{
			case 0:
				return Color.yellow;
			case 1:
				return Color.red;
			default:
				return Color.white;
			}
		}

		public void DrawVisibleBillboardCellGizmos()
		{
			if (BillboardJobCullingGroup != null)
			{
				Gizmos.color = Color.green;
				for (int i = 0; i <= BillboardJobCullingGroup.VisibleCellIndexList.Length - 1; i++)
				{
					int index = BillboardJobCullingGroup.VisibleCellIndexList[i];
					BillboardCell billboardCell = VegetationSystemPro.BillboardCellList[index];
					Gizmos.DrawWireCube(billboardCell.BilllboardCellBounds.center, billboardCell.BilllboardCellBounds.size);
				}
			}
		}

		public void DrawPotentialCellGizmos()
		{
			if (PotentialVisibleVegetationCellList == null)
			{
				return;
			}
			Gizmos.color = Color.green;
			for (int i = 0; i <= PotentialVisibleVegetationCellList.Count - 1; i++)
			{
				if (PotentialVisibleVegetationCellList[i].Enabled)
				{
					if (PotentialVisibleVegetationCellList[i].LoadedDistanceBand == 0)
					{
						Gizmos.color = Color.red;
					}
					else if (PotentialVisibleVegetationCellList[i].LoadedDistanceBand == 1)
					{
						Gizmos.color = Color.white;
					}
					else
					{
						Gizmos.color = Color.green;
					}
					Gizmos.DrawWireCube(PotentialVisibleVegetationCellList[i].VegetationCellBounds.center, PotentialVisibleVegetationCellList[i].VegetationCellBounds.size);
				}
			}
		}
	}
}
