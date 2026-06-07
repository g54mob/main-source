using UnityEngine;

public class PABillboardParticle : PAParticleMeshGenerator
{
	private const int MAX_PARTICLE_COUNT = 16250;

	protected static readonly Vector2[] quadUVs = new Vector2[4]
	{
		new Vector2(1f, 0f),
		new Vector2(1f, 1f),
		new Vector2(0f, 1f),
		new Vector2(0f, 0f)
	};

	protected static readonly Vector2[] quadOffsets = new Vector2[4]
	{
		new Vector2(-0.5f, -0.5f),
		new Vector2(-0.5f, 0.5f),
		new Vector2(0.5f, 0.5f),
		new Vector2(0.5f, -0.5f)
	};

	public override int GetMaximumParticleCount()
	{
		return 16250;
	}

	protected override int SetParticleCapacity(int count)
	{
		count = GetClampedParticleCount(count);
		int result = count;
		if (count * 4 > verts.Length)
		{
			result = verts.Length / 4;
		}
		SetArraySizes(count * 4, count * 6);
		return result;
	}

	protected override void UpdateDirection(PAParticleField settings, int startAt)
	{
		SkipRandomCalls(3, startAt);
		for (int i = startAt; i < settings.particleCount; i++)
		{
			Vector3 vector = new Vector3(GetRandomAndIncrement(-1f, 1f), GetRandomAndIncrement(-1f, 1f), GetRandomAndIncrement(-1f, 1f));
			for (int j = 0; j < 4; j++)
			{
				int num = i * 4 + j;
				verts[num] = vector;
			}
		}
	}

	protected override void UpdateColor(PAParticleField settings, int startAt)
	{
		SkipRandomCalls(1, startAt);
		for (int i = startAt; i < settings.particleCount; i++)
		{
			Color color = settings.colorVariation.Evaluate(GetRandomAndIncrement(0f, 1f));
			for (int j = 0; j < 4; j++)
			{
				int num = i * 4 + j;
				colors[num] = color;
			}
		}
	}

	protected override void UpdateSpeed(PAParticleField settings, int startAt)
	{
		SkipRandomCalls(2, startAt);
		for (int i = startAt; i < settings.particleCount; i++)
		{
			Vector2 vector = new Vector3(GetRandomAndIncrement(settings.minimumSpeed, 1f), GetRandomAndIncrement(settings.minSpinSpeed, 1f));
			for (int j = 0; j < 4; j++)
			{
				int num = i * 4 + j;
				normals[num].x = vector.x;
				normals[num].y = vector.y;
			}
		}
	}

	protected override void UpdateSurface(PAParticleField settings, int startAt)
	{
		SkipRandomCalls(3, startAt);
		float num = ((settings.textureType != PAParticleField.TextureType.Simple) ? ((float)settings.spriteColumns) : 1f);
		float num2 = ((settings.textureType != PAParticleField.TextureType.Simple) ? ((float)settings.spriteRows) : 1f);
		Vector2 b = new Vector2(1f / num, 1f / num2);
		for (int i = startAt; i < settings.particleCount; i++)
		{
			Vector2 vector = new Vector2((int)GetRandomAndIncrement(0f, num), (int)GetRandomAndIncrement(0f, num2));
			float randomAndIncrement = GetRandomAndIncrement(settings.minimumSize, 1f);
			for (int j = 0; j < 4; j++)
			{
				int num3 = i * 4 + j;
				uv0[num3] = Vector2.Scale(quadUVs[j] + vector, b);
				uv1[num3] = quadOffsets[j] * randomAndIncrement + settings.pivotOffset * randomAndIncrement;
			}
		}
	}

	protected override void UpdateTriangles(int startAt)
	{
		for (int i = startAt; i < triangles.Length / 6; i++)
		{
			triangles[i * 6] = i * 4 + 2;
			triangles[i * 6 + 1] = i * 4 + 1;
			triangles[i * 6 + 2] = i * 4;
			triangles[i * 6 + 3] = i * 4 + 2;
			triangles[i * 6 + 4] = i * 4;
			triangles[i * 6 + 5] = i * 4 + 3;
		}
	}

	protected override void UpdateIndicies()
	{
		float num = normals.Length / 4;
		for (int i = 0; i < normals.Length; i += 4)
		{
			float z = (float)(i / 4) / num;
			normals[i].z = z;
			normals[i + 1].z = z;
			normals[i + 2].z = z;
			normals[i + 3].z = z;
		}
	}
}
