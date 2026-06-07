using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class VaporEmit : MonoBehaviour
{
	public enum Drift
	{
		Up = 0,
		ToTarget = 1,
		ToTargetExact = 2
	}

	private class Particle
	{
		public Vector3 p0;

		public Vector3 p1;

		public float t = 1f;

		public float tSpeed = 1f;

		public float random;

		public float page;

		public Particle()
		{
			random = UnityEngine.Random.value;
		}
	}

	private class CorpsePhotoParams
	{
		public int momentIndex = -1;

		public int particlePage;
	}

	[Serializable]
	public class KeySet
	{
		public float val0;

		public float t1;

		public float val1;

		public float t2;

		public float val2;

		public float val3;

		public float At(float t)
		{
			if (t < t1)
			{
				return Util.LerpScale(t, 0f, t1, val0, val1);
			}
			if (t < t2)
			{
				return Util.LerpScale(t, t1, t2, val1, val2);
			}
			return Util.LerpScale(t, t2, 1f, val2, val3);
		}
	}

	public bool forCorpsePhoto;

	public Drift drift;

	public Vector3 driftTarget;

	public Transform source;

	public Material material;

	public AudioClip audioClip;

	[Space]
	public int maxParticles = 100;

	public int numParticlesPerSecond = 10;

	public float particleSpeed = 0.25f;

	public float emitRadius = 0.25f;

	public float riseHeight = 1f;

	public float spawnBias = 0.1f;

	public float particleSizeMax = 0.1f;

	[Space]
	public KeySet scaleKeys;

	public KeySet alphaKeys;

	private bool emitting_;

	private List<Particle> particles;

	private Vector3[] points;

	private Color32[] colors;

	private Mesh mesh;

	private int numParticlesAlive;

	private float numParticlesToSpawnThisFrame;

	private AudioOneShot audioOneShot;

	private CorpsePhotoParams corpsePhotoParams = new CorpsePhotoParams();

	private bool emitForOneFrame;

	public bool emitting
	{
		get
		{
			return emitting_;
		}
		set
		{
			emitting_ = value;
			if (emitting_)
			{
				if (!base.enabled)
				{
					base.enabled = true;
				}
				if (audioClip != null && audioOneShot == null)
				{
					audioOneShot = AudioOneShot.Play(base.gameObject, audioClip, true);
					audioOneShot.volume = 0f;
				}
			}
			else
			{
				if (audioOneShot != null)
				{
					audioOneShot.Stop(0.25f);
					audioOneShot = null;
				}
				numParticlesToSpawnThisFrame = 0f;
			}
		}
	}

	private void Start()
	{
		particles = new List<Particle>();
		for (int i = 0; i < maxParticles; i++)
		{
			particles.Add(new Particle());
		}
		points = new Vector3[particles.Count * 4];
		colors = new Color32[particles.Count * 4];
		for (int j = 0; j < maxParticles; j++)
		{
			colors[j] = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
		}
		mesh = new Mesh();
		mesh.name = "Vapor Emitter";
		PointMeshBuilder pointMeshBuilder = new PointMeshBuilder();
		for (int k = 0; k < particles.Count; k++)
		{
			pointMeshBuilder.Add(Vector3.zero);
		}
		pointMeshBuilder.Apply(mesh);
		mesh.colors32 = colors;
		mesh.bounds = new Bounds(Vector3.zero, 100f * Vector3.one);
		mesh.MarkDynamic();
		MeshFilter meshFilter = base.gameObject.AddComponent<MeshFilter>();
		meshFilter.mesh = mesh;
		meshFilter.sharedMesh = mesh;
		MeshRenderer meshRenderer = base.gameObject.AddComponent<MeshRenderer>();
		meshRenderer.shadowCastingMode = ShadowCastingMode.Off;
		meshRenderer.receiveShadows = false;
		meshRenderer.lightProbeUsage = LightProbeUsage.Off;
		meshRenderer.reflectionProbeUsage = ReflectionProbeUsage.Off;
		meshRenderer.material = material;
		ApplyMaterialParams();
	}

	private void ApplyMaterialParams()
	{
		material.SetVector("_VaporParticleSizes", new Vector4(0f, 0f, particleSizeMax, particleSizeMax));
	}

	public void UpdateCorpseVapor(int momentIndex, Transform source_, Vector3 driftTarget_)
	{
		source = source_;
		driftTarget = driftTarget_;
		emitting = true;
		emitForOneFrame = true;
		if (momentIndex != corpsePhotoParams.momentIndex)
		{
			corpsePhotoParams.particlePage = 1 - corpsePhotoParams.particlePage;
			corpsePhotoParams.momentIndex = momentIndex;
		}
		material.SetFloat("_CorpsePhotoPage", corpsePhotoParams.particlePage);
		Rect uvRect = MomentPhotographer.GetUvRect(momentIndex);
		Vector4 value = new Vector4(uvRect.x, uvRect.y, uvRect.xMax, uvRect.yMax);
		material.SetVector("_CorpsePhotoUvBounds", value);
	}

	private void LateUpdate()
	{
		if (forCorpsePhoto && source != null)
		{
			Camera mainCamera = Player.instance.mainCamera;
			Vector3 vector = source.position + 0.1f * Vector3.up;
			Vector3 vector2 = mainCamera.WorldToViewportPoint(vector) * 2f - new Vector3(1f, 1f, 0f);
			Vector2 vector3 = 1.75f * Mathf.Abs((mainCamera.WorldToViewportPoint(vector + emitRadius * mainCamera.transform.right) * 2f - new Vector3(1f, 1f, 0f)).x - vector2.x) * new Vector2(1f, 1f);
			Vector2 vector4 = new Vector2(Util.LerpScale(Mathf.Cos(Clock.play.time), -1f, 1f, 0.9f, 1f), Util.LerpScale(Mathf.Sin(Clock.play.time * 1.111f), -1f, 1f, 0.9f, 1f));
			vector3.x *= vector4.x;
			vector3.y *= vector4.y;
			Vector4 value = new Vector4(vector2.x, vector2.y, vector3.x, vector3.y);
			material.SetVector("_CorpsePhotoPos", value);
		}
	}

	private void Update()
	{
		float deltaTime = Clock.play.deltaTime;
		if (emitting)
		{
			if (audioOneShot != null)
			{
				audioOneShot.volume = Mathf.Min(1f, audioOneShot.volume + 0.5f * Mathf.Max(1f / 30f, Clock.play.deltaTime));
			}
			numParticlesToSpawnThisFrame += (float)numParticlesPerSecond * deltaTime;
			int num = Mathf.FloorToInt(numParticlesToSpawnThisFrame);
			if (num > 0)
			{
				SpawnParticles(num);
			}
			numParticlesToSpawnThisFrame -= num;
			if (emitForOneFrame)
			{
				emitting = false;
				emitForOneFrame = false;
			}
		}
		numParticlesAlive = 0;
		Vector3 vector = Vector3.zero;
		for (int i = 0; i < particles.Count; i++)
		{
			Particle particle = particles[i];
			if (particle.t < 0.999f)
			{
				numParticlesAlive++;
				particle.t = Mathf.Min(1f, particle.t + deltaTime * particle.tSpeed);
				vector = Vector3.Lerp(particle.p0, particle.p1, particle.t);
			}
			points[i * 4] = vector;
			points[i * 4 + 1] = vector;
			points[i * 4 + 2] = vector;
			points[i * 4 + 3] = vector;
			byte g = (byte)(255f * scaleKeys.At(particle.t));
			byte r = (byte)(255f * alphaKeys.At(particle.t));
			Color32 color = new Color32(r, g, (byte)(particle.random * 255f), (byte)(particle.page * 255f));
			colors[i * 4] = color;
			colors[i * 4 + 1] = color;
			colors[i * 4 + 2] = color;
			colors[i * 4 + 3] = color;
		}
		mesh.vertices = points;
		mesh.colors32 = colors;
		mesh.UploadMeshData(false);
		if (!emitting && numParticlesAlive == 0 && numParticlesToSpawnThisFrame == 0f)
		{
			base.enabled = false;
		}
	}

	private void SpawnParticles(int count)
	{
		Vector3 position = source.position;
		Vector3 vector = Vector3.up;
		if (drift == Drift.ToTarget || drift == Drift.ToTargetExact)
		{
			vector = (driftTarget - position).normalized;
		}
		for (int i = 0; i < particles.Count; i++)
		{
			if (count <= 0)
			{
				break;
			}
			if (!(particles[i].t < 0.999f))
			{
				Particle particle = particles[i];
				particle.p0 = position + emitRadius * UnityEngine.Random.insideUnitSphere - vector * spawnBias;
				if (drift == Drift.ToTargetExact)
				{
					float num = Mathf.Min(riseHeight, Vector3.Distance(particle.p0, driftTarget));
					particle.p1 = particle.p0 + num * (driftTarget - particle.p0).normalized;
				}
				else
				{
					particle.p1 = particle.p0 + vector * riseHeight;
				}
				particle.t = 0f;
				particle.tSpeed = UnityEngine.Random.Range(0.8f, 1.2f) * particleSpeed / (particle.p0 - particle.p1).magnitude;
				particle.page = corpsePhotoParams.particlePage;
				count--;
			}
		}
	}
}
