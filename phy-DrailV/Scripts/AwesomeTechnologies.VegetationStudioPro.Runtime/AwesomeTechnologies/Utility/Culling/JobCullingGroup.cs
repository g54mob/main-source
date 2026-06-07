using AwesomeTechnologies.VegetationSystem;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace AwesomeTechnologies.Utility.Culling
{
	public class JobCullingGroup
	{
		public delegate void StateChanged(JobCullingGroupEvent sphere);

		public NativeList<float> DistanceBandList;

		public NativeList<BoundingSphereInfo> BundingSphereInfoList;

		public NativeList<int> VisibleCellIndexList;

		public CameraCullingMode CameraCullingMode;

		public bool AddShadowCells;

		public NativeArray<Plane> FrustumPlanes;

		private NativeList<int> _eventList;

		private NativeList<int> _distanceBandEventList;

		private static readonly Plane[] FrustumPlaneArray = new Plane[6];

		private Vector3 _floatingOriginOffset = new Vector3(0f, 0f, 0f);

		public Camera TargetCamera { get; set; }

		public StateChanged OnStateChanged { get; set; }

		public StateChanged OnDistanceBandStateChanged { get; set; }

		public JobCullingGroup()
		{
			DistanceBandList = new NativeList<float>(10, Allocator.Persistent);
			BundingSphereInfoList = new NativeList<BoundingSphereInfo>(Allocator.Persistent);
			FrustumPlanes = new NativeArray<Plane>(6, Allocator.Persistent);
			_eventList = new NativeList<int>(Allocator.Persistent);
			_distanceBandEventList = new NativeList<int>(Allocator.Persistent);
			VisibleCellIndexList = new NativeList<int>(Allocator.Persistent);
		}

		public void SetFloatingOriginOffset(Vector3 floatingOriginOffset)
		{
			_floatingOriginOffset = floatingOriginOffset;
		}

		private Vector3 GetTargetCameraPosition()
		{
			return TargetCamera.transform.position;
		}

		public void Dispose()
		{
			if (DistanceBandList.IsCreated)
			{
				DistanceBandList.Dispose();
			}
			if (BundingSphereInfoList.IsCreated)
			{
				BundingSphereInfoList.Dispose();
			}
			if (FrustumPlanes.IsCreated)
			{
				FrustumPlanes.Dispose();
			}
			if (_eventList.IsCreated)
			{
				_eventList.Dispose();
			}
			if (_distanceBandEventList.IsCreated)
			{
				_distanceBandEventList.Dispose();
			}
			if (VisibleCellIndexList.IsCreated)
			{
				VisibleCellIndexList.Dispose();
			}
		}

		public JobHandle Cull(JobHandle dependsOn)
		{
			_eventList.Clear();
			_distanceBandEventList.Clear();
			if (TargetCamera == null)
			{
				return dependsOn;
			}
			if (BundingSphereInfoList.Length == 0)
			{
				return dependsOn;
			}
			GeometryUtility.CalculateFrustumPlanes(TargetCamera, FrustumPlaneArray);
			for (int i = 0; i <= 5; i++)
			{
				FrustumPlanes[i] = FrustumPlaneArray[i];
			}
			Vector3 targetCameraPosition = GetTargetCameraPosition();
			BoundingSphereCullJob jobData = new BoundingSphereCullJob
			{
				BoundingSphereInfoList = BundingSphereInfoList,
				DistanceReferencePoint = targetCameraPosition,
				DistancesList = DistanceBandList,
				FrustumPlanes = FrustumPlanes,
				NoFrustumCulling = (CameraCullingMode == CameraCullingMode.Complete360),
				AddShadowCells = AddShadowCells,
				FloatingOriginOffset = _floatingOriginOffset
			};
			int length = BundingSphereInfoList.Length;
			VisibleCellIndexList.Clear();
			JobHandle dependsOn2 = jobData.Schedule(length, 32, dependsOn);
			JobHandle dependsOn3 = new BoundingSphereVisibleJob
			{
				BoundingSphereInfoList = BundingSphereInfoList
			}.ScheduleAppend(VisibleCellIndexList, length, 100, dependsOn2);
			dependsOn3 = new BoundingSphereEventJob
			{
				BoundingSphereInfoList = BundingSphereInfoList
			}.ScheduleAppend(_eventList, length, 100, dependsOn3);
			return new BoundingSphereDistanceBandEventJob
			{
				BoundingSphereInfoList = BundingSphereInfoList
			}.ScheduleAppend(_distanceBandEventList, length, 100, dependsOn3);
		}

		public void ProcessEvents()
		{
			for (int i = 0; i <= _eventList.Length - 1; i++)
			{
				int index = _eventList[i];
				BoundingSphereInfo value = BundingSphereInfoList[index];
				if (OnStateChanged != null)
				{
					JobCullingGroupEvent sphere = new JobCullingGroupEvent
					{
						IsVisible = (value.Visibility == 1),
						Index = index,
						CurrentDistanceBand = value.CurrentDistanceBand,
						PreviousDistanceBand = value.PreviousDistanceBand
					};
					OnStateChanged(sphere);
				}
				value.LastVisisbility = value.Visibility;
				BundingSphereInfoList[index] = value;
			}
		}

		public void ProcessDistanceBandEvents()
		{
			for (int i = 0; i <= _distanceBandEventList.Length - 1; i++)
			{
				int index = _distanceBandEventList[i];
				BoundingSphereInfo value = BundingSphereInfoList[index];
				if (OnDistanceBandStateChanged != null)
				{
					JobCullingGroupEvent sphere = new JobCullingGroupEvent
					{
						IsVisible = (value.Visibility == 1),
						Index = index,
						CurrentDistanceBand = value.CurrentDistanceBand,
						PreviousDistanceBand = value.PreviousDistanceBand
					};
					OnDistanceBandStateChanged(sphere);
				}
				value.PreviousDistanceBand = value.CurrentDistanceBand;
				BundingSphereInfoList[index] = value;
			}
		}
	}
}
