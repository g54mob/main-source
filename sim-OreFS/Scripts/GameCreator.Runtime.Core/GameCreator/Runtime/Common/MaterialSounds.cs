using System;
using System.Collections.Generic;
using GameCreator.Runtime.Common.Audio;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class MaterialSounds
	{
		private static readonly Vector2 PITCH_VARIATION = new Vector2(-0.1f, 0.1f);

		private static readonly Vector2 PITCH_LERP_WEIGHT = new Vector2(0.5f, 1f);

		private static readonly Renderer[] RENDERERS = new Renderer[10];

		[SerializeField]
		private MaterialSoundsAsset m_SoundsAsset;

		[NonSerialized]
		private Dictionary<Texture, MaterialSoundTexture> m_LookupTable;

		public LayerMask LayerMask
		{
			get
			{
				if (!(m_SoundsAsset != null))
				{
					return 0;
				}
				return m_SoundsAsset.MaterialSounds.LayerMask;
			}
		}

		public static void Play(Args args, Vector3 point, Vector3 normal, GameObject hit, MaterialSoundsAsset materialSounds, float yaw)
		{
			if (!(materialSounds == null) && !(hit == null))
			{
				if (hit.Get<Collider>() is TerrainCollider)
				{
					PlayTerrain(args, point, normal, hit, materialSounds, yaw);
				}
				else
				{
					PlayMesh(args, point, normal, hit, materialSounds, yaw);
				}
			}
		}

		private static void PlayTerrain(Args args, Vector3 point, Vector3 normal, GameObject hit, MaterialSoundsAsset materialSounds, float yaw)
		{
			Terrain terrain = hit.Get<Terrain>();
			TerrainData terrainData = terrain.terrainData;
			float[] terrainWeights = GetTerrainWeights(point, terrainData, terrain.GetPosition());
			Texture texture = null;
			float num = 0f;
			for (int i = 0; i < terrainData.alphamapLayers; i++)
			{
				float num2 = ((i < terrainWeights.Length) ? terrainWeights[i] : 0f);
				Texture diffuseTexture = terrainData.terrainLayers[i].diffuseTexture;
				if (num2 > num)
				{
					texture = diffuseTexture;
					num = num2;
				}
				PlaySound(args, diffuseTexture, materialSounds);
			}
			if (texture != null)
			{
				PlayImpact(point, normal, texture, materialSounds, yaw);
			}
		}

		private static void PlayMesh(Args args, Vector3 point, Vector3 normal, GameObject hit, MaterialSoundsAsset materialSounds, float yaw)
		{
			int num = 1;
			RENDERERS[0] = hit.Get<Renderer>();
			if (RENDERERS[0] == null)
			{
				LODGroup lODGroup = hit.Get<LODGroup>();
				if (lODGroup != null && lODGroup.lodCount > 0)
				{
					Renderer[] renderers = lODGroup.GetLODs()[0].renderers;
					num = Mathf.Min(RENDERERS.Length, renderers.Length);
					for (int i = 0; i < renderers.Length; i++)
					{
						RENDERERS[i] = renderers[i];
					}
				}
			}
			for (int j = 0; j < num; j++)
			{
				Renderer renderer = RENDERERS[j];
				if (renderer == null)
				{
					continue;
				}
				Material[] sharedMaterials = renderer.sharedMaterials;
				foreach (Material material in sharedMaterials)
				{
					if (material.HasTexture(materialSounds.TextureID))
					{
						Texture texture = material.GetTexture(materialSounds.TextureID);
						if (!(texture == null))
						{
							PlaySound(args, texture, materialSounds);
							PlayImpact(point, normal, texture, materialSounds, yaw);
						}
					}
				}
			}
		}

		internal void OnStartup()
		{
			SetupSoundsTable();
		}

		internal void ChangeSoundsAsset(MaterialSoundsAsset materialSoundsAsset)
		{
			m_SoundsAsset = materialSoundsAsset;
			if (Application.isPlaying)
			{
				SetupSoundsTable();
			}
		}

		public void Play(Transform transform, RaycastHit hit, float speed, Args args, float yaw)
		{
			if (!(m_SoundsAsset == null))
			{
				if (hit.collider is TerrainCollider)
				{
					PlayTerrain(transform, args, hit, speed, yaw);
				}
				else
				{
					PlayMesh(transform, args, hit, m_SoundsAsset, speed, yaw);
				}
			}
		}

		private void PlayTerrain(Transform transform, Args args, RaycastHit hit, float speed, float yaw)
		{
			Terrain terrain = hit.collider.Get<Terrain>();
			TerrainData terrainData = terrain.terrainData;
			float[] terrainWeights = GetTerrainWeights(hit.point, terrainData, terrain.GetPosition());
			Texture texture = null;
			float num = 0f;
			for (int i = 0; i < terrainData.alphamapLayers; i++)
			{
				float num2 = ((i < terrainWeights.Length) ? terrainWeights[i] : 0f);
				Texture diffuseTexture = terrainData.terrainLayers[i].diffuseTexture;
				if (num2 > num)
				{
					texture = diffuseTexture;
					num = num2;
				}
				PlaySound(diffuseTexture, num2, speed, transform, args);
			}
			if (texture != null)
			{
				PlayImpact(texture, transform, hit, yaw);
			}
		}

		private void PlayMesh(Transform transform, Args args, RaycastHit hit, MaterialSoundsAsset materialSounds, float speed, float yaw)
		{
			int num = 1;
			RENDERERS[0] = hit.collider.Get<Renderer>();
			if (RENDERERS[0] == null)
			{
				LODGroup lODGroup = hit.collider.Get<LODGroup>();
				if (lODGroup != null && lODGroup.lodCount > 0)
				{
					Renderer[] renderers = lODGroup.GetLODs()[0].renderers;
					num = Mathf.Min(RENDERERS.Length, renderers.Length);
					for (int i = 0; i < renderers.Length; i++)
					{
						RENDERERS[i] = renderers[i];
					}
				}
			}
			for (int j = 0; j < num; j++)
			{
				Renderer renderer = RENDERERS[j];
				if (renderer == null)
				{
					continue;
				}
				Material[] sharedMaterials = renderer.sharedMaterials;
				foreach (Material material in sharedMaterials)
				{
					if (material.HasTexture(materialSounds.TextureID))
					{
						Texture texture = material.GetTexture(materialSounds.TextureID);
						if (!(texture == null))
						{
							PlaySound(texture, 1f, speed, transform, args);
							PlayImpact(texture, transform, hit, yaw);
						}
					}
				}
			}
		}

		private void SetupSoundsTable()
		{
			m_LookupTable = new Dictionary<Texture, MaterialSoundTexture>();
			if (m_SoundsAsset == null)
			{
				return;
			}
			MaterialSoundTexture[] materialSounds = m_SoundsAsset.MaterialSounds.MaterialSounds;
			foreach (MaterialSoundTexture materialSoundTexture in materialSounds)
			{
				Texture texture = materialSoundTexture.Texture;
				if (!(texture == null))
				{
					m_LookupTable[texture] = materialSoundTexture;
				}
			}
		}

		private void PlaySound(Texture texture, float weight, float speed, Transform target, Args args)
		{
			if (texture == null)
			{
				return;
			}
			float num = Mathf.Lerp(PITCH_LERP_WEIGHT.x, PITCH_LERP_WEIGHT.y, weight);
			IMaterialSound materialSound;
			AudioConfigSoundEffect audioConfigSoundEffect;
			if (m_LookupTable.TryGetValue(texture, out var value))
			{
				if (value.Audio == null)
				{
					return;
				}
				materialSound = value;
				audioConfigSoundEffect = AudioConfigSoundEffect.Create(value.Volume * weight * speed, new Vector2(num + PITCH_VARIATION.x, num + PITCH_VARIATION.y), 0f, TimeMode.UpdateMode.GameTime, SpatialBlending.Spatial, target.gameObject);
			}
			else
			{
				materialSound = m_SoundsAsset.MaterialSounds.DefaultSounds;
				audioConfigSoundEffect = AudioConfigSoundEffect.Create(materialSound.Volume * weight * speed, new Vector2(num + PITCH_VARIATION.x, num + PITCH_VARIATION.y), 0f, TimeMode.UpdateMode.GameTime, SpatialBlending.Spatial, target.gameObject);
			}
			if (!(audioConfigSoundEffect.Volume < float.Epsilon))
			{
				Singleton<AudioManager>.Instance.SoundEffect.Play(materialSound.Audio, audioConfigSoundEffect, args);
			}
		}

		private void PlayImpact(Texture texture, Transform transform, RaycastHit hit, float yaw)
		{
			if (texture == null)
			{
				return;
			}
			IMaterialSound materialSound;
			if (m_LookupTable.TryGetValue(texture, out var value))
			{
				if (value.Audio == null)
				{
					return;
				}
				materialSound = value;
			}
			else
			{
				materialSound = m_SoundsAsset.MaterialSounds.DefaultSounds;
			}
			GameObject gameObject = materialSound?.Impact.Create(hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal), null);
			if (gameObject != null)
			{
				gameObject.transform.localRotation *= Quaternion.Euler(0f, yaw, 0f);
			}
		}

		private static float[] GetTerrainWeights(Vector3 point, TerrainData data, Vector3 terrain)
		{
			float num = point.x - terrain.x;
			float num2 = point.z - terrain.z;
			int x = (int)(num / data.size.x * (float)data.alphamapWidth);
			int y = (int)(num2 / data.size.z * (float)data.alphamapHeight);
			float[,,] alphamaps = data.GetAlphamaps(x, y, 1, 1);
			float[] array = new float[alphamaps.GetUpperBound(2) + 1];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = alphamaps[0, 0, i];
			}
			return array;
		}

		private static void PlaySound(Args args, Texture texture, MaterialSoundsAsset materialSounds)
		{
			if (texture == null)
			{
				return;
			}
			MaterialSoundTexture[] materialSounds2 = materialSounds.MaterialSounds.MaterialSounds;
			foreach (MaterialSoundTexture materialSoundTexture in materialSounds2)
			{
				if (!(materialSoundTexture.Texture != texture) && !(materialSoundTexture.Audio == null))
				{
					AudioConfigSoundEffect audioConfigSoundEffect = AudioConfigSoundEffect.Create(materialSoundTexture.Volume, new Vector2(1f + PITCH_VARIATION.x, 1f + PITCH_VARIATION.y), 0f, TimeMode.UpdateMode.GameTime, SpatialBlending.Spatial, args.Self);
					if (!(audioConfigSoundEffect.Volume < float.Epsilon))
					{
						Singleton<AudioManager>.Instance.SoundEffect.Play(materialSoundTexture.Audio, audioConfigSoundEffect, args);
					}
					return;
				}
			}
			AudioConfigSoundEffect audioConfigSoundEffect2 = AudioConfigSoundEffect.Create(materialSounds.MaterialSounds.DefaultSounds.Volume, new Vector2(1f + PITCH_VARIATION.x, 1f + PITCH_VARIATION.y), 0f, TimeMode.UpdateMode.GameTime, SpatialBlending.Spatial, args.Self);
			if (!(audioConfigSoundEffect2.Volume < float.Epsilon))
			{
				Singleton<AudioManager>.Instance.SoundEffect.Play(materialSounds.MaterialSounds.DefaultSounds.Audio, audioConfigSoundEffect2, args);
			}
		}

		private static void PlayImpact(Vector3 point, Vector3 normal, Texture texture, MaterialSoundsAsset materialSounds, float yaw)
		{
			if (texture == null)
			{
				return;
			}
			MaterialSoundTexture[] materialSounds2 = materialSounds.MaterialSounds.MaterialSounds;
			int num = 0;
			if (num < materialSounds2.Length)
			{
				MaterialSoundTexture materialSoundTexture = materialSounds2[num];
				if (!(materialSoundTexture.Audio == null))
				{
					materialSoundTexture.Impact.Create(point, Quaternion.FromToRotation(Vector3.up, normal), null);
				}
			}
			else
			{
				GameObject gameObject = materialSounds.MaterialSounds.DefaultSounds?.Impact?.Create(point, Quaternion.FromToRotation(Vector3.up, normal), null);
				if (gameObject != null)
				{
					gameObject.transform.localRotation *= Quaternion.Euler(0f, yaw, 0f);
				}
			}
		}
	}
}
