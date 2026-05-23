using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

namespace Deform
{
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/DeformableManager")]
	public class DeformableManager : MonoBehaviour
	{
		private static readonly string DEF_MANAGER_NAME = "DefaultDeformableManager";

		private static DeformableManager defaultInstance;

		public bool update = true;

		private HashSet<IDeformable> deformables = new HashSet<IDeformable>();

		private HashSet<IDeformable> immediateDeformables = new HashSet<IDeformable>();

		private HashSet<IDeformable> addedDeformables = new HashSet<IDeformable>();

		public static DeformableManager GetDefaultManager(bool createIfMissing)
		{
			if (defaultInstance == null && createIfMissing)
			{
				defaultInstance = new GameObject(DEF_MANAGER_NAME).AddComponent<DeformableManager>();
				Object.DontDestroyOnLoad(defaultInstance.gameObject);
			}
			return defaultInstance;
		}

		private void Update()
		{
			if (update)
			{
				CompleteDeformables(deformables);
				ScheduleDeformables(deformables);
				ScheduleDeformables(immediateDeformables);
			}
			foreach (IDeformable addedDeformable in addedDeformables)
			{
				if (addedDeformable != null)
				{
					if (addedDeformable.UpdateFrequency == UpdateFrequency.Default)
					{
						deformables.Add(addedDeformable);
					}
					else
					{
						immediateDeformables.Add(addedDeformable);
					}
				}
			}
			addedDeformables.Clear();
		}

		private void LateUpdate()
		{
			if (update)
			{
				CompleteDeformables(immediateDeformables);
			}
		}

		private void OnDisable()
		{
			CompleteDeformables(deformables);
			CompleteDeformables(immediateDeformables);
		}

		public void ScheduleDeformables(HashSet<IDeformable> deformables)
		{
			foreach (IDeformable deformable in deformables)
			{
				deformable.PreSchedule();
			}
			foreach (IDeformable deformable2 in deformables)
			{
				deformable2.Schedule();
			}
			JobHandle.ScheduleBatchedJobs();
		}

		public void CompleteDeformables(HashSet<IDeformable> deformables)
		{
			foreach (IDeformable deformable in deformables)
			{
				deformable.Complete();
				deformable.ApplyData();
			}
		}

		public void AddDeformable(IDeformable deformable)
		{
			addedDeformables.Add(deformable);
			deformable.ForceImmediateUpdate();
			deformable.PreSchedule();
			deformable.Schedule();
		}

		public void RemoveDeformable(IDeformable deformable)
		{
			addedDeformables.Remove(deformable);
			deformables.Remove(deformable);
			immediateDeformables.Remove(deformable);
		}
	}
}
