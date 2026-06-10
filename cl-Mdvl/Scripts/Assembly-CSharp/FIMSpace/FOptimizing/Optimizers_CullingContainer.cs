using UnityEngine;

namespace FIMSpace.FOptimizing
{
	public class Optimizers_CullingContainer
	{
		private int MaxSlots = 1000;

		public bool Destroying;

		public int ID { get; private set; }

		public bool HaveFreeSlots => HighestIndex < MaxSlots - 1;

		public CullingGroup CullingGroup { get; private set; }

		public Optimizer_Base[] Optimizers { get; private set; }

		public BoundingSphere[] CullingSpheres { get; private set; }

		public int BoundingCount { get; private set; }

		public float[] DistanceLevels { get; private set; }

		public int HighestIndex { get; private set; }

		public int LowestFreeIndex { get; private set; }

		public int SlotsTaken { get; private set; }

		public Optimizers_CullingContainer(int maxSlots)
		{
			MaxSlots = maxSlots;
			SlotsTaken = 0;
			Optimizers = new Optimizer_Base[MaxSlots];
			HighestIndex = 0;
		}

		public void InitializeContainer(int id, float[] distances, Camera targetCamera)
		{
			ID = id;
			DistanceLevels = new float[distances.Length + 2];
			DistanceLevels[0] = Mathf.Epsilon;
			for (int i = 1; i < distances.Length + 1; i++)
			{
				DistanceLevels[i] = distances[i - 1];
			}
			DistanceLevels[DistanceLevels.Length - 1] = distances[^1] * 1.5f;
			CullingGroup = new CullingGroup
			{
				targetCamera = targetCamera
			};
			CullingSpheres = new BoundingSphere[MaxSlots];
			CullingGroup.SetBoundingSpheres(CullingSpheres);
			BoundingCount = 0;
			HighestIndex = -1;
			LowestFreeIndex = -1;
			CullingGroup.SetBoundingSphereCount(BoundingCount);
			CullingGroup.onStateChanged = CullingGroupStateChanged;
			CullingGroup.SetBoundingDistances(DistanceLevels);
			if ((bool)targetCamera)
			{
				CullingGroup.SetDistanceReferencePoint(targetCamera.transform);
			}
		}

		public void SetNewCamera(Camera cam)
		{
			if (cam == null)
			{
				return;
			}
			CullingGroup.targetCamera = cam;
			CullingGroup.SetDistanceReferencePoint(cam.transform);
			for (int i = 0; i < Optimizers.Length; i++)
			{
				if (!(Optimizers[i] == null))
				{
					Optimizers[i].RefreshCamera(cam);
				}
			}
		}

		public bool AddOptimizer(Optimizer_Base optimizer)
		{
			if (!HaveFreeSlots)
			{
				return false;
			}
			if (!optimizer.UseMultiShape)
			{
				int num = HighestIndex + 1;
				CullingSpheres[num].position = optimizer.GetReferencePosition();
				CullingSpheres[num].radius = optimizer.GetDetectionRadiusRaw() * Optimizer_Base.GetScaler(optimizer.transform);
				Optimizers[num] = optimizer;
				optimizer.AssignToContainer(this, num, ref CullingSpheres[num]);
				HighestIndex++;
				BoundingCount++;
				CullingGroup.SetBoundingSphereCount(BoundingCount);
				SlotsTaken++;
			}
			else
			{
				int[] array = new int[optimizer.Shapes.Count];
				for (int i = 0; i < optimizer.Shapes.Count; i++)
				{
					int num2 = (array[i] = HighestIndex + 1);
					if (optimizer.Shapes[i].transform == null)
					{
						CullingSpheres[num2].radius = optimizer.Shapes[i].radius * optimizer.DetectionRadius;
						CullingSpheres[num2].position = optimizer.transform.TransformPoint(optimizer.Shapes[i].position);
					}
					else
					{
						CullingSpheres[num2].position = optimizer.Shapes[i].transform.TransformPoint(optimizer.Shapes[i].position);
						CullingSpheres[num2].radius = optimizer.Shapes[i].radius * optimizer.DetectionRadius;
					}
					Optimizers[num2] = optimizer;
					HighestIndex++;
					BoundingCount++;
					CullingGroup.SetBoundingSphereCount(BoundingCount);
					SlotsTaken++;
				}
				optimizer.AssignToContainer(this, array);
			}
			return true;
		}

		public void RemoveOptimizer(Optimizer_Base optimizer)
		{
			if (Optimizers == null)
			{
				return;
			}
			if (!optimizer.UseMultiShape)
			{
				LowestFreeIndex = optimizer.ContainerSphereId;
				CullingSpheres[LowestFreeIndex].radius = 0f;
				Optimizers[LowestFreeIndex] = null;
				MoveStackOptimizerToFreeSlot();
				SlotsTaken--;
				CullingGroup.SetBoundingSphereCount(BoundingCount);
				return;
			}
			for (int i = 0; i < optimizer.ContainerSphereIds.Length; i++)
			{
				_ = LowestFreeIndex;
				LowestFreeIndex = optimizer.ContainerSphereIds[i];
				CullingSpheres[LowestFreeIndex].radius = 0f;
				Optimizers[LowestFreeIndex] = null;
				MoveStackOptimizerToFreeSlot();
				SlotsTaken--;
				CullingGroup.SetBoundingSphereCount(BoundingCount);
			}
		}

		private void MoveStackOptimizerToFreeSlot()
		{
			Optimizer_Base optimizer_Base = Optimizers[HighestIndex];
			Optimizers[HighestIndex] = null;
			HighestIndex--;
			BoundingCount--;
			if (optimizer_Base == null)
			{
				return;
			}
			int lowestFreeIndex = LowestFreeIndex;
			LowestFreeIndex = HighestIndex + 1;
			if (lowestFreeIndex < 0 || lowestFreeIndex >= CullingSpheres.Length)
			{
				return;
			}
			if (!optimizer_Base.UseMultiShape)
			{
				CullingSpheres[lowestFreeIndex].position = optimizer_Base.GetReferencePosition();
				CullingSpheres[lowestFreeIndex].radius = optimizer_Base.GetDetectionRadiusRaw() * Optimizer_Base.GetScaler(optimizer_Base.transform);
				Optimizers[lowestFreeIndex] = optimizer_Base;
				optimizer_Base.AssignToContainer(this, lowestFreeIndex, ref CullingSpheres[lowestFreeIndex]);
				return;
			}
			int num = -1;
			for (int i = 0; i < optimizer_Base.ContainerSphereIds.Length; i++)
			{
				if (optimizer_Base.ContainerSphereIds[i] == HighestIndex + 1)
				{
					num = i;
					break;
				}
			}
			if (num != -1)
			{
				optimizer_Base.ContainerSphereIds[num] = lowestFreeIndex;
				if (optimizer_Base.Shapes[num].transform == null)
				{
					CullingSpheres[lowestFreeIndex].position = optimizer_Base.transform.TransformPoint(optimizer_Base.Shapes[num].position);
				}
				else
				{
					CullingSpheres[lowestFreeIndex].position = optimizer_Base.Shapes[num].transform.TransformPoint(optimizer_Base.Shapes[num].position);
				}
				CullingSpheres[lowestFreeIndex].radius = optimizer_Base.Shapes[num].radius * optimizer_Base.DetectionRadius;
				Optimizers[lowestFreeIndex] = optimizer_Base;
				optimizer_Base.AssignToContainer(this, lowestFreeIndex, ref CullingSpheres[lowestFreeIndex]);
			}
		}

		private void CullingGroupStateChanged(CullingGroupEvent cullingEvent)
		{
			if (Optimizers[cullingEvent.index] != null)
			{
				Optimizers[cullingEvent.index].CullingGroupStateChanged(cullingEvent);
			}
		}

		public void Dispose()
		{
			CullingGroup.Dispose();
			CullingGroup = null;
			Optimizers = null;
		}

		public static int GetId(float[] distances)
		{
			float num = distances.Length * 179;
			num += distances[0];
			if (distances.Length > 1)
			{
				num += distances[1];
				if (distances.Length > 2)
				{
					num += distances[2];
					if (distances.Length > 3)
					{
						num += distances[3];
						if (distances.Length > 4)
						{
							num += distances[4];
							if (distances.Length > 5)
							{
								num += distances[5];
								if (distances.Length > 6)
								{
									num += distances[6];
									if (distances.Length > 7)
									{
										num += distances[7];
									}
								}
							}
						}
					}
				}
			}
			return num.GetHashCode();
		}
	}
}
