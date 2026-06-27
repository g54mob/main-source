using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

namespace DistantLands.Cozy
{
	[ExecuteAlways]
	public class PlumeModule : CozyModule
	{
		private Vector3Int renderedCenterChunk;

		[Tooltip("Holds a reference to the cloud profile")]
		public PlumeProfile volumetricCloudProfile;

		private AnimationCurve cloudHeightRatio = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.45f, 1f), new Keyframe(0.75f, 0.35f));

		public GameObject cloudChunkPrefab;

		[Range(-1f, 1f)]
		[Tooltip("Adds an offset to your cloud coverage to allow for more or less clouds in your sky. -1 is no clouds and +1 is fully overcast")]
		public float coverageIntensityOffset;

		[Range(0f, 1f)]
		public float cloudCoverage;

		[Tooltip("Allows your clouds to bend towards or away from the horizon to give an effect of a round planet")]
		[Range(-0.2f, 0.2f)]
		public float bendToHorizonMultiplier = 0.1f;

		public Vector3 offset;

		public Transform matrixHolder;

		[Tooltip("Should the clouds generate colliders? Useful for culling light flares")]
		public bool useColliders = true;

		[Tooltip("Should the clouds cast shadows on the ground? Not recommended for low end devices")]
		public bool useShadows;

		[Tooltip("Should the clouds be culled inside triggers with the tag FX Block Zone")]
		public bool cullInsideTriggers;

		private Dictionary<Vector3Int, SetCloudPosition> chunks = new Dictionary<Vector3Int, SetCloudPosition>();

		private List<Vector3Int> heavyChunks = new List<Vector3Int>();

		[Tooltip("How many frames should pass before the noise renders again? A value of 0 renders every frame and a value of 30 renders once every 60 frames.")]
		[Range(0f, 60f)]
		public int framesBetweenRenders = 10;

		private int framesLeft;

		private void Awake()
		{
			InitializeModule();
			Generate();
		}

		public void Generate()
		{
			chunks.Clear();
			heavyChunks.Clear();
			if ((bool)matrixHolder)
			{
				Object.DestroyImmediate(matrixHolder.gameObject);
			}
			if (!volumetricCloudProfile)
			{
				Debug.Log("Be sure to setup your cloud profile in the PLUME settings! Defaulting to the default clouds.");
				volumetricCloudProfile = (PlumeProfile)Resources.Load("Profiles/Default Volumetric Clouds");
			}
			if (!cloudChunkPrefab)
			{
				cloudChunkPrefab = (GameObject)Resources.Load("Cloud Chunk");
			}
			renderedCenterChunk = new Vector3Int((int)(base.transform.position.x / volumetricCloudProfile.chunkSize), 0, (int)(base.transform.position.y / volumetricCloudProfile.chunkSize));
			matrixHolder = new GameObject().transform;
			matrixHolder.name = "Plume Matrix Holder";
			for (int i = -volumetricCloudProfile.renderDistance; i < volumetricCloudProfile.renderDistance; i++)
			{
				for (int j = -volumetricCloudProfile.renderDistance; j < volumetricCloudProfile.renderDistance; j++)
				{
					Vector3Int globalChunkPos = new Vector3Int(i + renderedCenterChunk.x, 0, j + renderedCenterChunk.z);
					CreateChunk(globalChunkPos);
				}
			}
		}

		public void CreateChunk(Vector3Int globalChunkPos)
		{
			SetCloudPosition component = Object.Instantiate(cloudChunkPrefab, matrixHolder).GetComponent<SetCloudPosition>();
			ResetChunk(globalChunkPos, component);
			chunks.Add(globalChunkPos, component);
		}

		public void MoveChunk(Vector3Int newChunkPos, Vector3Int oldChunkPos)
		{
			try
			{
				SetCloudPosition setCloudPosition = chunks[oldChunkPos];
				chunks.Add(newChunkPos, setCloudPosition);
				chunks.Remove(oldChunkPos);
				ResetChunk(newChunkPos, setCloudPosition);
				if (GetDensity(oldChunkPos, volumetricCloudProfile.noiseScale) > volumetricCloudProfile.normalReferenceHeight)
				{
					heavyChunks.Remove(oldChunkPos);
				}
				if (GetDensity(newChunkPos, volumetricCloudProfile.noiseScale) > volumetricCloudProfile.normalReferenceHeight)
				{
					heavyChunks.Add(newChunkPos);
				}
			}
			catch
			{
			}
		}

		private void ResetChunk(Vector3Int globalChunkPos, SetCloudPosition chunk)
		{
			chunk.plume = this;
			chunk.transform.position = new Vector3(volumetricCloudProfile.chunkSize * (float)globalChunkPos.x, volumetricCloudProfile.cloudHeight, volumetricCloudProfile.chunkSize * (float)globalChunkPos.z);
			float num = Mathf.Lerp(volumetricCloudProfile.minChunkHeight, volumetricCloudProfile.maxChunkHeight * 2f, cloudHeightRatio.Evaluate(Mathf.Clamp01(GetDensity(globalChunkPos, volumetricCloudProfile.noiseScale) + (cloudCoverage - 0.4f) * 1.8f)));
			chunk.transform.position += Vector3.up * (num / 2f + volumetricCloudProfile.cloudHeightDistrubution * GetDensity(globalChunkPos, volumetricCloudProfile.noiseScale / 2f));
			ParticleSystem particleSystem = chunk.system;
			if (cullInsideTriggers)
			{
				for (int i = 0; i < base.weatherSphere.cozyTriggers.Count; i++)
				{
					particleSystem.trigger.SetCollider(i, base.weatherSphere.cozyTriggers[i]);
				}
			}
			ParticleSystem.EmissionModule emission = particleSystem.emission;
			ParticleSystem.MainModule main = particleSystem.main;
			main.maxParticles = 10000;
			main.startSize = volumetricCloudProfile.cloudParticleSize;
			particleSystem.GetComponent<ParticleSystemRenderer>().shadowCastingMode = (useShadows ? ShadowCastingMode.On : ShadowCastingMode.Off);
			emission.rateOverTime = volumetricCloudProfile.chunkSize * volumetricCloudProfile.chunkSize * volumetricCloudProfile.cloudDensity * 0.0005f / main.startLifetime.constant * num / volumetricCloudProfile.chunkSize;
			if (emission.rateOverTime.constant < 5f)
			{
				emission.rateOverTime = 0f;
				chunk.collider.enabled = false;
			}
			else
			{
				chunk.collider.enabled = useColliders;
			}
			chunk.transform.localScale = new Vector3(volumetricCloudProfile.chunkSize, num, volumetricCloudProfile.chunkSize);
			particleSystem.Play();
			chunk.system = particleSystem;
			chunk.density = num;
			chunk.pos = globalChunkPos;
			chunk.Init();
		}

		public Vector3 GetClosestHeavy(Vector3 pos)
		{
			Vector3 vector = heavyChunks.OrderBy((Vector3Int e) => Vector3.SqrMagnitude(pos - e)).FirstOrDefault();
			return Vector3.Lerp(vector, pos, Vector3.SqrMagnitude(pos - vector) / (volumetricCloudProfile.normalizedDistance * volumetricCloudProfile.normalizedDistance));
		}

		public void AddNeededChunks(Vector3Int old, Vector3Int current)
		{
		}

		private void Update()
		{
			if (base.weatherSphere == null)
			{
				InitializeModule();
			}
			UpdateShaderVariables();
			if (!Application.isPlaying)
			{
				return;
			}
			if (matrixHolder == null)
			{
				Generate();
			}
			cloudCoverage = Mathf.Clamp01(base.weatherSphere.cloudCoverage + 0.15f + coverageIntensityOffset);
			if ((int)(base.transform.position.x / volumetricCloudProfile.chunkSize) - renderedCenterChunk.x != 0 || (int)(base.transform.position.z / volumetricCloudProfile.chunkSize) - renderedCenterChunk.z != 0)
			{
				Vector3Int vector3Int = new Vector3Int(Mathf.Clamp((int)(base.transform.position.x / volumetricCloudProfile.chunkSize) - renderedCenterChunk.x, -1, 1), 0, Mathf.Clamp((int)(base.transform.position.z / volumetricCloudProfile.chunkSize) - renderedCenterChunk.z, -1, 1));
				if (vector3Int.x != 0)
				{
					for (int i = -volumetricCloudProfile.renderDistance - 1; i < volumetricCloudProfile.renderDistance + 1; i++)
					{
						Vector3Int oldChunkPos = new Vector3Int(renderedCenterChunk.x - vector3Int.x * volumetricCloudProfile.renderDistance, 0, renderedCenterChunk.z + i);
						Vector3Int newChunkPos = new Vector3Int(renderedCenterChunk.x + vector3Int.x * volumetricCloudProfile.renderDistance, 0, renderedCenterChunk.z + i);
						MoveChunk(newChunkPos, oldChunkPos);
					}
					renderedCenterChunk += Vector3Int.right * vector3Int.x;
				}
				if (vector3Int.z != 0)
				{
					for (int j = -volumetricCloudProfile.renderDistance - 1; j < volumetricCloudProfile.renderDistance + 1; j++)
					{
						Vector3Int oldChunkPos2 = new Vector3Int(renderedCenterChunk.x + j, 0, renderedCenterChunk.z - vector3Int.z * volumetricCloudProfile.renderDistance);
						Vector3Int newChunkPos2 = new Vector3Int(renderedCenterChunk.x + j, 0, renderedCenterChunk.z + vector3Int.z * volumetricCloudProfile.renderDistance);
						MoveChunk(newChunkPos2, oldChunkPos2);
					}
					renderedCenterChunk += Vector3Int.forward * vector3Int.z;
				}
			}
			if (Application.isPlaying)
			{
				offset += volumetricCloudProfile.windSpeed * Time.deltaTime * 0.01f;
			}
			if (framesLeft < 0)
			{
				UpdateNoise();
				framesLeft = framesBetweenRenders;
			}
			else
			{
				framesLeft--;
			}
		}

		public void UpdateShaderVariables()
		{
			Shader.SetGlobalColor("PLUME_MainCloudColor", base.weatherSphere.cloudColor * Mathf.Lerp(volumetricCloudProfile.cloudShadowColorMultiplier, volumetricCloudProfile.cloudColorMultiplier, Mathf.Clamp01(base.weatherSphere.sunColor.r)));
			Shader.SetGlobalColor("PLUME_CloudShadowColor", base.weatherSphere.cloudColor * volumetricCloudProfile.cloudShadowColorMultiplier);
			Shader.SetGlobalFloat("PLUME_CloudBendMultiplier", bendToHorizonMultiplier);
		}

		public void UpdateNoise()
		{
			chunks.GetEnumerator();
			foreach (KeyValuePair<Vector3Int, SetCloudPosition> chunk in chunks)
			{
				SetCloudPosition value = chunk.Value;
				_ = value.system.shape;
				ParticleSystem.EmissionModule emission = value.system.emission;
				ParticleSystem.MainModule main = value.system.main;
				ParticleSystem.VelocityOverLifetimeModule velocityOverLifetime = value.system.velocityOverLifetime;
				float value2 = GetDensity(chunk.Key, volumetricCloudProfile.noiseScale) + (cloudCoverage - 0.4f) * 1.8f;
				float num = Mathf.Lerp(volumetricCloudProfile.minChunkHeight, volumetricCloudProfile.maxChunkHeight * 2f, cloudHeightRatio.Evaluate(Mathf.Clamp01(value2)));
				value.transform.localScale = new Vector3(volumetricCloudProfile.chunkSize, num, volumetricCloudProfile.chunkSize);
				emission.rateOverTime = volumetricCloudProfile.chunkSize * volumetricCloudProfile.chunkSize * volumetricCloudProfile.cloudDensity * 0.0005f / main.startLifetime.constant * num / volumetricCloudProfile.chunkSize;
				velocityOverLifetime.x = volumetricCloudProfile.windSpeed.x * volumetricCloudProfile.chunkSize * 0.1f;
				velocityOverLifetime.z = volumetricCloudProfile.windSpeed.y * volumetricCloudProfile.chunkSize * 0.1f;
				if (emission.rateOverTime.constant < 5f)
				{
					emission.rateOverTime = 0f;
					value.collider.enabled = false;
				}
			}
		}

		public float GetDensity(Vector3Int pos, float scale)
		{
			return (Mathf.PerlinNoise((float)pos.x / scale + volumetricCloudProfile.seed * 10000f + offset.x, (float)pos.z / scale + offset.z + (0f - volumetricCloudProfile.seed) * 1000f) - 0.5f) * 2f;
		}

		public override void DeinitializeModule()
		{
			if (matrixHolder != null)
			{
				Object.DestroyImmediate(matrixHolder.gameObject);
			}
			base.DeinitializeModule();
		}
	}
}
