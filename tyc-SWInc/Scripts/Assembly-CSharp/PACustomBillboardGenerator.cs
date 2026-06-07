using System.Collections.Generic;
using UnityEngine;

public class PACustomBillboardGenerator : PABillboardParticle, PAICustomParticleGenerator
{
	public List<PACustomParticle> particles;

	[HideInInspector]
	[SerializeField]
	private Mesh particleMesh;

	private Vector2[] particleUVs = new Vector2[4];

	protected override void UpdateCache(PAParticleField settings)
	{
	}

	protected override int SetParticleCapacity(int count)
	{
		return particles.Count;
	}

	private void Awake()
	{
		PAParticleField component = GetComponent<PAParticleField>();
		if ((bool)component && component.generatorType != PAParticleField.ParticleType.Custom)
		{
			component.generatorType = PAParticleField.ParticleType.Custom;
		}
	}

	private void OnValidate()
	{
		PAParticleField component = GetComponent<PAParticleField>();
		if ((bool)component && component.generatorType != PAParticleField.ParticleType.Custom)
		{
			component.generatorType = PAParticleField.ParticleType.Custom;
		}
		particles.ForEach(delegate(PACustomParticle obj)
		{
			obj.SetDefaultValuesIfUninitialized();
		});
	}

	[ContextMenu("Apply Particles")]
	public void ApplyParticles()
	{
		if (particles != null && particles.Count > 0)
		{
			int num = 4;
			SetArraySizes(particles.Count * num, particles.Count * 3 * 2);
			for (int i = 0; i < particles.Count; i++)
			{
				PACustomParticle pACustomParticle = particles[i];
				SetOriginDirection(i, pACustomParticle.originDirection);
				SetSize(i, pACustomParticle.size);
				SetColor(i, pACustomParticle.color);
				SetSpeed(i, pACustomParticle.speed);
				SetSpinSpeed(i, pACustomParticle.spinSpeed);
				SetUV(i, pACustomParticle.uv);
				SetIndex(i, (float)i / (float)particles.Count);
			}
		}
		else
		{
			SetArraySizes(0, 0);
		}
		UpdateTriangles(0);
		if (particleMesh == null)
		{
			particleMesh = GetComponent<MeshFilter>().sharedMesh;
		}
		FillMesh(particleMesh);
	}

	private void SetOriginDirection(int particleIndex, Vector3 direction)
	{
		for (int i = 0; i < 4; i++)
		{
			int num = particleIndex * 4 + i;
			verts[num] = direction;
		}
	}

	private void SetSpeed(int particleIndex, float speed)
	{
		for (int i = 0; i < 4; i++)
		{
			int num = particleIndex * 4 + i;
			normals[num].x = speed;
		}
	}

	private void SetSpinSpeed(int particleIndex, float spinSpeed)
	{
		for (int i = 0; i < 4; i++)
		{
			int num = particleIndex * 4 + i;
			normals[num].y = spinSpeed;
		}
	}

	private void SetColor(int particleIndex, Color color)
	{
		for (int i = 0; i < 4; i++)
		{
			int num = particleIndex * 4 + i;
			colors[num] = color;
		}
	}

	private void SetUV(int particleIndex, Rect uv)
	{
		particleUVs[0] = new Vector2(uv.x + uv.width, uv.y);
		particleUVs[1] = new Vector2(uv.x + uv.width, uv.y + uv.height);
		particleUVs[2] = new Vector2(uv.x, uv.y + uv.height);
		particleUVs[3] = new Vector2(uv.x, uv.y);
		for (int i = 0; i < 4; i++)
		{
			int num = particleIndex * 4 + i;
			uv0[num] = particleUVs[i];
		}
	}

	private void SetSize(int particleIndex, float size)
	{
		for (int i = 0; i < 4; i++)
		{
			int num = particleIndex * 4 + i;
			uv1[num] = PABillboardParticle.quadOffsets[i] * size;
		}
	}

	private void SetIndex(int particleIndex, float normalizedIndex)
	{
		for (int i = 0; i < 4; i++)
		{
			int num = particleIndex * 4 + i;
			normals[num].z = normalizedIndex;
		}
	}
}
