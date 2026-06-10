using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Tools;
using NSMedieval.Village.Map;
using Unity.Collections;
using UnityEngine;

namespace NSMedieval.Fire
{
	[Serializable]
	public class FireParticleSystems : MonoBehaviour
	{
		[NonSerialized]
		private Dictionary<int, List<string>> prefabNamesByFlameType = new Dictionary<int, List<string>>();

		[NonSerialized]
		private Dictionary<int, List<ParticleSystem>> particleSystemInstancesByFireType = new Dictionary<int, List<ParticleSystem>>();

		[NonSerialized]
		private Dictionary<int, Mesh> meshByFlameType = new Dictionary<int, Mesh>();

		[NonSerialized]
		private Dictionary<int, List<Vector3>> meshVerticesByFlameType = new Dictionary<int, List<Vector3>>();

		[NonSerialized]
		private VillageMap map;

		private bool needRefreshMesh;

		public void Initialize(VillageMap map)
		{
			this.map = map;
			base.transform.localPosition = Vector3.zero;
			InitFromFireSettings();
			MonoSingleton<FireController>.Instance.FireAddedEvent += OnFireAdded;
			MonoSingleton<FireController>.Instance.FireRemovedEvent += OnFireRemoved;
			needRefreshMesh = true;
		}

		private void InitFromFireSettings()
		{
			prefabNamesByFlameType = new Dictionary<int, List<string>>();
			particleSystemInstancesByFireType = new Dictionary<int, List<ParticleSystem>>();
			meshByFlameType = new Dictionary<int, Mesh>();
			meshVerticesByFlameType = new Dictionary<int, List<Vector3>>();
			foreach (FireSettings.FireParticleSettings particleSetting in Repository<FireSettingsData, FireSettings>.Instance.GetData<FireSettings>().ParticleSettings)
			{
				int flameType = particleSetting.FlameType;
				Mesh mesh = new Mesh();
				meshByFlameType.Add(flameType, mesh);
				particleSystemInstancesByFireType.Add(flameType, new List<ParticleSystem>());
				prefabNamesByFlameType.Add(flameType, new List<string>(particleSetting.ParticlePrefabs));
				meshVerticesByFlameType.Add(flameType, new List<Vector3> { Vector3.zero });
				mesh.SetVertices(meshVerticesByFlameType[flameType]);
				foreach (string item in prefabNamesByFlameType[flameType])
				{
					GameObject obj = UnityEngine.Object.Instantiate(MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress(item), base.transform, worldPositionStays: true);
					obj.transform.localPosition = Vector3.zero;
					obj.name = $"{flameType}_{item}";
					ParticleSystem component = obj.GetComponent<ParticleSystem>();
					particleSystemInstancesByFireType[flameType].Add(component);
					ParticleSystem.EmissionModule emission = component.emission;
					emission.rateOverTimeMultiplier = 0f;
					ParticleSystem.ShapeModule shape = component.shape;
					shape.mesh = mesh;
				}
			}
		}

		private void OnDestroy()
		{
			map = null;
			foreach (int key in particleSystemInstancesByFireType.Keys)
			{
				particleSystemInstancesByFireType[key].Clear();
			}
			particleSystemInstancesByFireType.Clear();
			foreach (List<Vector3> value in meshVerticesByFlameType.Values)
			{
				value.Clear();
			}
			meshVerticesByFlameType.Clear();
			foreach (Mesh value2 in meshByFlameType.Values)
			{
				UnityEngine.Object.Destroy(value2);
			}
			meshByFlameType.Clear();
			foreach (List<string> value3 in prefabNamesByFlameType.Values)
			{
				value3.Clear();
			}
			prefabNamesByFlameType.Clear();
			if (MonoSingleton<FireController>.IsInstantiated())
			{
				MonoSingleton<FireController>.Instance.FireAddedEvent -= OnFireAdded;
				MonoSingleton<FireController>.Instance.FireRemovedEvent -= OnFireRemoved;
			}
		}

		private void OnFireAdded(NativeParallelHashSet<int> obj)
		{
			needRefreshMesh = true;
		}

		private void OnFireRemoved(NativeParallelHashSet<int> obj)
		{
			needRefreshMesh = true;
		}

		private void Update()
		{
			if (!needRefreshMesh)
			{
				return;
			}
			FireSimLogic fireSimLogic = map.FireSimLogic;
			if (!fireSimLogic.FirstFireTickDone)
			{
				return;
			}
			needRefreshMesh = false;
			foreach (List<Vector3> value in meshVerticesByFlameType.Values)
			{
				value.Clear();
			}
			fireSimLogic.NodesOnFireSafeOperation(SetMeshVertices);
			foreach (int key in particleSystemInstancesByFireType.Keys)
			{
				foreach (ParticleSystem item in particleSystemInstancesByFireType[key])
				{
					if (meshVerticesByFlameType[key].Count > 0)
					{
						meshByFlameType[key].SetVertices(meshVerticesByFlameType[key]);
					}
					ParticleSystem.EmissionModule emission = item.emission;
					emission.rateOverTimeMultiplier = fireSimLogic.GetFlameCount(key);
				}
			}
		}

		private void SetMeshVertices(NativeArray<int> nodeIndicesOnFire, int nodeIndicesOnFireCount, NativeArray<float> flameData, NativeArray<byte> flameTypeArray)
		{
			for (int i = 0; i < nodeIndicesOnFireCount; i++)
			{
				int index = nodeIndicesOnFire[i];
				int key = flameTypeArray[i];
				float x = GridDataIndexTools.GetX(index);
				float y = GridDataIndexTools.GetY(index) * World.MapBlockHeight;
				float z = GridDataIndexTools.GetZ(index);
				meshVerticesByFlameType[key].Add(new Vector3(x, y, z));
			}
		}
	}
}
