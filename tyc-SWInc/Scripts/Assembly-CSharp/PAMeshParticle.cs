using UnityEngine;

public class PAMeshParticle : PAParticleMeshGenerator
{
	private const int MAX_VERT_COUNT = 65536;

	[HideInInspector]
	public Mesh inputMesh;

	public override int GetMaximumParticleCount()
	{
		if ((bool)inputMesh)
		{
			return (int)(65536f / (float)inputMesh.vertexCount);
		}
		return 16250;
	}

	public override float GetParticleBaseSize()
	{
		if ((bool)inputMesh)
		{
			return Mathf.Max(inputMesh.bounds.size.x, Mathf.Max(inputMesh.bounds.size.y, inputMesh.bounds.size.z));
		}
		return base.GetParticleBaseSize();
	}

	public override void UpdateMesh(Mesh mesh, PAParticleField settings)
	{
		inputMesh = settings.inputMesh;
		if ((bool)inputMesh)
		{
			base.UpdateMesh(mesh, settings);
		}
	}

	protected override int SetParticleCapacity(int count)
	{
		count = GetClampedParticleCount(count);
		int result = count;
		if (count * inputMesh.vertexCount > verts.Length)
		{
			result = verts.Length / inputMesh.vertexCount;
		}
		int vertCount = count * inputMesh.vertexCount;
		int triCount = count * inputMesh.triangles.Length;
		SetArraySizes(vertCount, triCount);
		return result;
	}

	protected override void UpdateDirection(PAParticleField settings, int startAt)
	{
		int clampedParticleCount = GetClampedParticleCount(settings.particleCount);
		SkipRandomCalls(6, startAt);
		for (int i = startAt; i < clampedParticleCount; i++)
		{
			float y = Vector3ToFloat(new Vector3(GetRandomAndIncrement(-1f, 1f), GetRandomAndIncrement(-1f, 1f), GetRandomAndIncrement(-1f, 1f)));
			for (int j = 0; j < inputMesh.vertexCount; j++)
			{
				int num = i * inputMesh.vertexCount + j;
				if (num >= normals.Length)
				{
					Debug.Log("An error has occurred in PAMeshParticle", base.gameObject);
				}
				uv1[num].y = y;
			}
		}
	}

	protected override void UpdateColor(PAParticleField settings, int startAt)
	{
		int clampedParticleCount = GetClampedParticleCount(settings.particleCount);
		SkipRandomCalls(1, startAt);
		for (int i = startAt; i < clampedParticleCount; i++)
		{
			Color color = settings.colorVariation.Evaluate(GetRandomAndIncrement(0f, 1f));
			for (int j = 0; j < inputMesh.vertexCount; j++)
			{
				int num = i * inputMesh.vertexCount + j;
				if (inputMesh.colors.Length != 0)
				{
					colors[num] = inputMesh.colors[j] * color;
				}
				else
				{
					colors[num] = color;
				}
			}
		}
	}

	protected override void UpdateSurface(PAParticleField settings, int startAt = 0)
	{
		int clampedParticleCount = GetClampedParticleCount(settings.particleCount);
		float num = ((settings.textureType != PAParticleField.TextureType.Simple) ? ((float)settings.spriteColumns) : 1f);
		float num2 = ((settings.textureType != PAParticleField.TextureType.Simple) ? ((float)settings.spriteRows) : 1f);
		Vector2 b = new Vector2(1f / num, 1f / num2);
		SkipRandomCalls(3, startAt);
		for (int i = startAt; i < clampedParticleCount; i++)
		{
			float randomAndIncrement = GetRandomAndIncrement(settings.minimumSize, 1f);
			Vector2 vector = new Vector2((int)GetRandomAndIncrement(0f, num), (int)GetRandomAndIncrement(0f, num2));
			for (int j = 0; j < inputMesh.vertexCount; j++)
			{
				int num3 = i * inputMesh.vertexCount + j;
				verts[num3] = inputMesh.vertices[j] * randomAndIncrement;
				if (inputMesh.normals.Length != 0)
				{
					uv1[num3].x = Vector3ToFloat(inputMesh.normals[j].normalized * 0.9f);
				}
				if (inputMesh.tangents.Length != 0)
				{
					tangents[num3] = inputMesh.tangents[j];
				}
				if (inputMesh.uv.Length != 0)
				{
					uv0[num3] = Vector2.Scale(inputMesh.uv[j] + vector, b);
				}
			}
		}
	}

	protected override void UpdateTriangles(int startAt)
	{
		int num = triangles.Length / inputMesh.triangles.Length;
		for (int i = startAt; i < num; i++)
		{
			for (int j = 0; j < inputMesh.triangles.Length; j++)
			{
				int num2 = i * inputMesh.triangles.Length + j;
				triangles[num2] = inputMesh.triangles[j] + inputMesh.vertexCount * i;
			}
		}
	}

	protected override void UpdateSpeed(PAParticleField settings, int startAt)
	{
		int clampedParticleCount = GetClampedParticleCount(settings.particleCount);
		SkipRandomCalls(2, startAt);
		for (int i = startAt; i < clampedParticleCount; i++)
		{
			Vector2 vector = new Vector3(GetRandomAndIncrement(settings.minimumSpeed, 1f), GetRandomAndIncrement(settings.minSpinSpeed, 1f));
			Vector3 c = settings.rotationAxis;
			if (!settings.customRotationAxis)
			{
				c = new Vector3(GetRandomAndIncrement(-1f, 1f), GetRandomAndIncrement(-1f, 1f), GetRandomAndIncrement(-1f, 1f)).normalized;
			}
			float z = Vector3ToFloat(c);
			for (int j = 0; j < inputMesh.vertexCount; j++)
			{
				int num = i * inputMesh.vertexCount + j;
				normals[num].x = vector.x;
				normals[num].y = vector.y;
				normals[num].z = z;
			}
		}
	}

	public static float Vector3ToFloat(Vector3 c)
	{
		c = (c + Vector3.one) * 0.5f;
		return Vector3.Dot(new Vector3(Mathf.Round(c.x * 255f), Mathf.Round(c.y * 255f), Mathf.Round(c.z * 255f)), new Vector3(65536f, 256f, 1f));
	}
}
