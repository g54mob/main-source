using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.Tools;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class ProtectorCreatureManager
	{
		private VillageMap map;

		private const int Radius = 6;

		private Vec3Int[] neighborsRadius;

		private int[] protectedNodes;

		private readonly object protectedNodesLock = new object();

		private readonly Dictionary<CreatureBase, bool> isCreatureProtecting = new Dictionary<CreatureBase, bool>();

		private readonly object isCreatureProtectingLock = new object();

		public bool IsProtected(int nodeIndex)
		{
			lock (protectedNodesLock)
			{
				return protectedNodes[nodeIndex] > 0;
			}
		}

		public void Initialize(VillageMap villageMap)
		{
			map = villageMap;
			neighborsRadius = ProtectorBuildingManager.CreateNeighbors(6);
			protectedNodes = new int[map.Size.x * map.Size.y * map.Size.z];
			MonoSingleton<WorkerController>.Instance.RemoveWorkerEvent += OnRemoveWorker;
			MonoSingleton<AnimalController>.Instance.RemovedAnimalEvent += OnRemovedAnimal;
			MonoSingleton<NPCController>.Instance.OnNPCRemovedEvent += OnNpcRemoved;
		}

		public void Dispose()
		{
			if (MonoSingleton<WorkerController>.IsInstantiated())
			{
				MonoSingleton<WorkerController>.Instance.RemoveWorkerEvent -= OnRemoveWorker;
			}
			if (MonoSingleton<AnimalController>.IsInstantiated())
			{
				MonoSingleton<AnimalController>.Instance.RemovedAnimalEvent -= OnRemovedAnimal;
			}
			if (MonoSingleton<NPCController>.IsInstantiated())
			{
				MonoSingleton<NPCController>.Instance.OnNPCRemovedEvent -= OnNpcRemoved;
			}
			map = null;
		}

		public void CreatureStateChanged(CreatureBase creature, MapNode oldNode, MapNode newNode)
		{
			bool flag = !creature.HasDied && !creature.HasDisposed && creature.IsProtectiveAgainstPredators;
			bool flag2 = false;
			lock (isCreatureProtectingLock)
			{
				flag2 = isCreatureProtecting.TryGetValue(creature, out var value) && value;
			}
			if (oldNode != null && flag2)
			{
				AddToProtected(oldNode.Position, -1);
			}
			if (newNode != null && flag)
			{
				AddToProtected(newNode.Position, 1);
			}
			lock (isCreatureProtectingLock)
			{
				isCreatureProtecting[creature] = flag;
			}
		}

		public void GetProtectors(Vec3Int position, ref List<CreatureBase> outputList)
		{
			outputList.Clear();
			Dictionary<int, HashSet<CreatureBase>> creaturesOnNodes = map.CreaturesOnNodes;
			Vec3Int[] array = neighborsRadius;
			for (int i = 0; i < array.Length; i++)
			{
				Vec3Int b = array[i];
				Vec3Int vec3Int = position + b;
				if (!GridDataIndexTools.InRange(vec3Int))
				{
					continue;
				}
				int key = GridDataIndexTools.FastTo1DIndex(vec3Int);
				if (!creaturesOnNodes.ContainsKey(key) || creaturesOnNodes[key] == null)
				{
					continue;
				}
				foreach (CreatureBase item in creaturesOnNodes[key])
				{
					if (item.IsProtectiveAgainstPredators)
					{
						outputList.Add(item);
					}
				}
			}
		}

		public void DrawGizmos()
		{
			Color color = Gizmos.color;
			Vector3 size = new Vector3(1f, 0.1f, 1f);
			lock (protectedNodesLock)
			{
				MapNode[] gridSpaceData = map.GridSpaceData;
				for (int i = 0; i < protectedNodes.Length; i++)
				{
					MapNode mapNode = gridSpaceData[i];
					if (protectedNodes[i] > 0)
					{
						Gizmos.color = Color.green * Mathf.Clamp01((float)(protectedNodes[i] + 1) / 4f);
						Gizmos.DrawCube(mapNode.WorldPosition, size);
					}
					if (protectedNodes[i] < 0)
					{
						Gizmos.color = Color.red * Mathf.Clamp01((float)(protectedNodes[i] + 1) / 4f);
						Gizmos.DrawCube(mapNode.WorldPosition, size);
					}
				}
			}
			Gizmos.color = color;
		}

		private void AddToProtected(Vec3Int position, int toAdd)
		{
			lock (protectedNodesLock)
			{
				int x = position.x;
				int y = position.y;
				int z = position.z;
				Vec3Int[] array = neighborsRadius;
				for (int i = 0; i < array.Length; i++)
				{
					Vec3Int vec3Int = array[i];
					int x2 = x + vec3Int.x;
					int y2 = y + vec3Int.y;
					int z2 = z + vec3Int.z;
					int num = GridDataIndexTools.FastTo1DIndex(x2, y2, z2);
					if (num == -1)
					{
						continue;
					}
					protectedNodes[num] += toAdd;
					if (!map.CreaturesOnNodes.TryGetValue(num, out var value) || value == null)
					{
						continue;
					}
					foreach (CreatureBase item in value)
					{
						item.OnPredatorProtectionChanged();
					}
				}
			}
		}

		private void OnRemoveWorker(HumanoidInstance humanoidInstance)
		{
			CreatureStateChanged(humanoidInstance, humanoidInstance.GetNode(), humanoidInstance.GetNode());
		}

		private void OnRemovedAnimal(AnimalInstance animalInstance)
		{
			CreatureStateChanged(animalInstance, animalInstance.GetNode(), animalInstance.GetNode());
		}

		private void OnNpcRemoved(HumanoidInstance humanoidInstance)
		{
			CreatureStateChanged(humanoidInstance, humanoidInstance.GetNode(), humanoidInstance.GetNode());
		}
	}
}
