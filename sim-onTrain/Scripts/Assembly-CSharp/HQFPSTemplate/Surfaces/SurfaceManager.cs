using System.Collections.Generic;
using HQFPSTemplate.Pooling;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HQFPSTemplate.Surfaces
{
	public class SurfaceManager : Singleton<SurfaceManager>
	{
		[SerializeField]
		private bool m_SpatializeAudio;

		[SerializeField]
		private AudioSource m_AudioSourceTemplate;

		[SerializeField]
		private SurfaceInfo m_DefaultSurface;

		[Space]
		[SerializeField]
		private string m_SurfacesPath = "Surfaces/";

		private SurfaceInfo[] m_Surfaces;

		private Dictionary<Collider, TerrainInfo> m_SceneTerrains;

		public static void SpawnEffect(RaycastHit hitInfo, SurfaceEffects effectType, float audioVolume)
		{
			SpawnEffect(hitInfo, effectType, audioVolume, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
		}

		public static void SpawnEffect(RaycastHit hitInfo, SurfaceEffects effectType, float audioVolume, Vector3 position, Quaternion rotation)
		{
			SurfaceInfo surfaceInfo = Singleton<SurfaceManager>.Instance.Internal_GetSurfaceInfo(hitInfo);
			if (!(surfaceInfo != null))
			{
				return;
			}
			PoolableObject poolableObject = Singleton<PoolingManager>.Instance.GetObject(surfaceInfo.GetInstanceID().ToString() + effectType);
			if (poolableObject != null)
			{
				poolableObject.transform.position = position;
				poolableObject.transform.rotation = rotation;
				if (hitInfo.collider != null)
				{
					poolableObject.transform.SetParent(hitInfo.collider.transform, worldPositionStays: true);
				}
				poolableObject.GetComponent<SurfaceEffect>().Play(audioVolume);
			}
		}

		public static void SpawnEffect(int surfaceId, SurfaceEffects effectType, float audioVolume, Vector3 position, Quaternion rotation)
		{
			SurfaceInfo surfaceWithId = Singleton<SurfaceManager>.Instance.GetSurfaceWithId(surfaceId);
			PoolableObject poolableObject = Singleton<PoolingManager>.Instance.GetObject(surfaceWithId.GetInstanceID().ToString() + effectType);
			if (poolableObject != null)
			{
				poolableObject.transform.position = position;
				poolableObject.transform.rotation = rotation;
				poolableObject.GetComponent<SurfaceEffect>().Play(audioVolume);
			}
		}

		public static SurfaceInfo GetSurfaceInfo(RaycastHit hitInfo)
		{
			if (Singleton<SurfaceManager>.Instance == null)
			{
				return null;
			}
			return Singleton<SurfaceManager>.Instance.Internal_GetSurfaceInfo(hitInfo);
		}

		private SurfaceInfo Internal_GetSurfaceInfo(RaycastHit hitInfo)
		{
			if (m_Surfaces.Length == 0)
			{
				return null;
			}
			if (hitInfo.collider.TryGetComponent<SurfaceIdentity>(out var component))
			{
				if (component.Surface != null)
				{
					SurfaceInfo[] surfaces = m_Surfaces;
					foreach (SurfaceInfo surfaceInfo in surfaces)
					{
						if (surfaceInfo.name == component.Surface.name)
						{
							return surfaceInfo;
						}
					}
				}
				return null;
			}
			Texture texture;
			if (m_SceneTerrains.TryGetValue(hitInfo.collider, out var value))
			{
				float[] terrainTextureMix = GetTerrainTextureMix(hitInfo.point, value.Data, value.Position);
				int terrainTextureIndex = GetTerrainTextureIndex(terrainTextureMix);
				texture = value.GetSplatmapPrototypeId(terrainTextureIndex);
			}
			else
			{
				texture = GetMeshTextureId(hitInfo.collider, hitInfo.triangleIndex);
			}
			if (texture != null)
			{
				for (int j = 0; j < m_Surfaces.Length; j++)
				{
					if (m_Surfaces[j].HasTexture(texture))
					{
						return m_Surfaces[j];
					}
				}
			}
			return m_DefaultSurface;
		}

		private SurfaceInfo GetSurfaceWithId(int surfaceId)
		{
			if (m_Surfaces.Length > surfaceId && surfaceId >= 0)
			{
				return m_Surfaces[surfaceId];
			}
			return null;
		}

		protected override void Awake()
		{
			base.Awake();
			m_Surfaces = Resources.LoadAll<SurfaceInfo>(m_SurfacesPath);
			for (int i = 0; i < m_Surfaces.Length; i++)
			{
				string text = m_Surfaces[i].name;
				m_Surfaces[i] = Object.Instantiate(m_Surfaces[i]);
				m_Surfaces[i].name = text;
				m_Surfaces[i].CacheTextures();
			}
			SceneManager.sceneLoaded += CacheTerrains;
			SceneManager.sceneLoaded += OnSceneLoadedRecachePools;
			CacheTerrains(default(Scene), LoadSceneMode.Single);
		}

		private void Start()
		{
			CacheSurfaceEffects();
		}

		private void OnSceneLoadedRecachePools(Scene scene, LoadSceneMode mode)
		{
			CacheSurfaceEffects();
		}

		private void CacheSurfaceEffects()
		{
			SurfaceInfo[] surfaces = m_Surfaces;
			foreach (SurfaceInfo surfaceInfo in surfaces)
			{
				string text = surfaceInfo.GetInstanceID().ToString();
				CreatePoolForEffect(surfaceInfo.name + "_" + SurfaceEffects.SoftFootstep, surfaceInfo.SoftFootstepEffect, 25, 50, autoShrink: true, text + SurfaceEffects.SoftFootstep);
				CreatePoolForEffect(surfaceInfo.name + "_" + SurfaceEffects.HardFootstep, surfaceInfo.HardFootstepEffect, 25, 50, autoShrink: true, text + SurfaceEffects.HardFootstep);
				CreatePoolForEffect(surfaceInfo.name + "_" + SurfaceEffects.FallImpact, surfaceInfo.FallImpactEffect, 25, 50, autoShrink: true, text + SurfaceEffects.FallImpact);
				CreatePoolForEffect(surfaceInfo.name + "_" + SurfaceEffects.BulletHit, surfaceInfo.BulletHitEffect, 50, 100, autoShrink: true, text + SurfaceEffects.BulletHit);
				CreatePoolForEffect(surfaceInfo.name + "_" + SurfaceEffects.Slash, surfaceInfo.SlashEffect, 25, 50, autoShrink: true, text + SurfaceEffects.Slash);
				CreatePoolForEffect(surfaceInfo.name + "_" + SurfaceEffects.Stab, surfaceInfo.StabEffect, 25, 50, autoShrink: true, text + SurfaceEffects.Stab);
				if (m_DefaultSurface != null && m_DefaultSurface.name == surfaceInfo.name)
				{
					m_DefaultSurface = surfaceInfo;
				}
			}
		}

		private void CreatePoolForEffect(string name, SurfaceInfo.EffectPair effectPair, int poolSizeMin, int poolSizeMax, bool autoShrink, string poolId)
		{
			if (!(Singleton<PoolingManager>.Instance == null))
			{
				GameObject gameObject = new GameObject(name);
				gameObject.AddComponent<SurfaceEffect>().Init(effectPair.AudioEffect, effectPair.VisualEffect, m_SpatializeAudio);
				if (m_AudioSourceTemplate != null)
				{
					AudioSource component = gameObject.GetComponent<AudioSource>();
					component.outputAudioMixerGroup = m_AudioSourceTemplate.outputAudioMixerGroup;
					component.spatialBlend = m_AudioSourceTemplate.spatialBlend;
					component.minDistance = m_AudioSourceTemplate.minDistance;
					component.maxDistance = m_AudioSourceTemplate.maxDistance;
					component.rolloffMode = m_AudioSourceTemplate.rolloffMode;
					component.spatialize = m_AudioSourceTemplate.spatialize;
					component.dopplerLevel = m_AudioSourceTemplate.dopplerLevel;
					component.spread = m_AudioSourceTemplate.spread;
					component.priority = m_AudioSourceTemplate.priority;
				}
				Singleton<PoolingManager>.Instance.CreatePool(gameObject, poolSizeMin, poolSizeMin, autoShrink, poolId, 5f);
				Object.Destroy(gameObject);
			}
		}

		private void CacheTerrains(Scene scene, LoadSceneMode loadSceneMode)
		{
			m_SceneTerrains = new Dictionary<Collider, TerrainInfo>();
			Terrain[] array = Object.FindObjectsOfType<Terrain>();
			for (int i = 0; i < array.Length; i++)
			{
				TerrainCollider component = array[i].GetComponent<TerrainCollider>();
				if (!(component == null))
				{
					m_SceneTerrains.Add(component, new TerrainInfo(array[i]));
				}
			}
		}

		private Texture GetMeshTextureId(Collider collider, int triangleIndex)
		{
			Renderer component = collider.GetComponent<Renderer>();
			MeshCollider meshCollider = collider as MeshCollider;
			if (!component || !component.sharedMaterial || !component.sharedMaterial.mainTexture)
			{
				return null;
			}
			if (!meshCollider || meshCollider.convex)
			{
				return component.material.mainTexture;
			}
			Mesh sharedMesh = meshCollider.sharedMesh;
			int num = -1;
			int num2 = sharedMesh.triangles[triangleIndex * 3];
			int num3 = sharedMesh.triangles[triangleIndex * 3 + 1];
			int num4 = sharedMesh.triangles[triangleIndex * 3 + 2];
			for (int i = 0; i < sharedMesh.subMeshCount; i++)
			{
				int[] triangles = sharedMesh.GetTriangles(i);
				for (int j = 0; j < triangles.Length; j += 3)
				{
					if (triangles[j] == num2 && triangles[j + 1] == num3 && triangles[j + 2] == num4)
					{
						num = i;
						break;
					}
				}
				if (num != -1)
				{
					break;
				}
			}
			return component.materials[num].mainTexture;
		}

		private float[] GetTerrainTextureMix(Vector3 worldPos, TerrainData terrainData, Vector3 terrainPos)
		{
			int x = (int)((worldPos.x - terrainPos.x) / terrainData.size.x * (float)terrainData.alphamapWidth);
			int y = (int)((worldPos.z - terrainPos.z) / terrainData.size.z * (float)terrainData.alphamapHeight);
			float[,,] alphamaps = terrainData.GetAlphamaps(x, y, 1, 1);
			float[] array = new float[alphamaps.GetUpperBound(2) + 1];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = alphamaps[0, 0, i];
			}
			return array;
		}

		private int GetTerrainTextureIndex(float[] textureMix)
		{
			float num = 0f;
			int result = 0;
			for (int i = 0; i < textureMix.Length; i++)
			{
				if (textureMix[i] > num)
				{
					result = i;
					num = textureMix[i];
				}
			}
			return result;
		}
	}
}
