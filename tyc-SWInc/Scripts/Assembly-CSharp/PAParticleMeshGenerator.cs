using UnityEngine;

public class PAParticleMeshGenerator : MonoBehaviour, ISerializationCallbackReceiver
{
	public static class RandomWrapper
	{
		private static int m_Seed;

		public static Random.State cachedState;

		public static int seed
		{
			get
			{
				return m_Seed;
			}
		}

		public static void CacheState()
		{
			cachedState = Random.state;
		}

		public static void RestoreState()
		{
			Random.state = cachedState;
		}

		public static void SetState(int seed)
		{
			Random.InitState(seed);
			m_Seed = seed;
			Random.Range(0f, 0f);
		}
	}

	private const int DATA_STRUCTURE_VERSION = 2;

	[HideInInspector]
	[SerializeField]
	protected Vector3[] verts;

	[HideInInspector]
	[SerializeField]
	protected Vector3[] normals;

	[HideInInspector]
	[SerializeField]
	protected Vector4[] tangents;

	[HideInInspector]
	[SerializeField]
	protected Vector2[] uv0;

	[HideInInspector]
	[SerializeField]
	protected Vector2[] uv1;

	[HideInInspector]
	[SerializeField]
	protected Color[] colors;

	[HideInInspector]
	[SerializeField]
	protected int[] triangles;

	[SerializeField]
	[HideInInspector]
	private int dataStructureVersion;

	public void OnBeforeSerialize()
	{
		PAParticleField component = GetComponent<PAParticleField>();
		if ((bool)component && component.clearCacheInBuilds)
		{
			ClearCache();
		}
	}

	public void OnAfterDeserialize()
	{
	}

	protected void CacheSeed()
	{
		RandomWrapper.CacheState();
	}

	private void SetSeed(int seed)
	{
		RandomWrapper.SetState(seed);
	}

	protected float GetRandomAndIncrement(float min, float max)
	{
		float result = Random.Range(min, max);
		RandomWrapper.SetState(RandomWrapper.seed + 1);
		return result;
	}

	protected void ResetSeed()
	{
		RandomWrapper.RestoreState();
	}

	public virtual int GetMaximumParticleCount()
	{
		return 16250;
	}

	public virtual float GetParticleBaseSize()
	{
		return 1f;
	}

	protected void SkipRandomCalls(int callsPerParticle, int count)
	{
		for (int i = 0; i < callsPerParticle * count; i++)
		{
			GetRandomAndIncrement(0f, 0f);
		}
	}

	public virtual void UpdateMesh(Mesh mesh, PAParticleField settings)
	{
		UpdateCache(settings);
		FillMesh(mesh);
	}

	protected virtual void UpdateCache(PAParticleField settings)
	{
		CacheSeed();
		int clampedParticleCount = GetClampedParticleCount(settings.particleCount);
		int num = -1;
		if (verts == null || verts.Length == 0 || dataStructureVersion != 2)
		{
			verts = new Vector3[0];
			normals = new Vector3[0];
			tangents = new Vector4[0];
			uv0 = new Vector2[0];
			uv1 = new Vector2[0];
			colors = new Color[0];
			triangles = new int[0];
			num = 0;
		}
		if ((settings.meshIsDirtyMask & MeshFlags.Count) != MeshFlags.None || num == 0)
		{
			num = SetParticleCapacity(clampedParticleCount);
			if (num == clampedParticleCount)
			{
				return;
			}
			UpdateIndicies();
			UpdateTriangles(num);
		}
		if ((settings.meshIsDirtyMask & MeshFlags.Seed) != MeshFlags.None || num != -1)
		{
			SetSeed(settings.seed);
			UpdateDirection(settings, Mathf.Max(0, num));
		}
		if ((settings.meshIsDirtyMask & MeshFlags.Surface) != MeshFlags.None || num != -1)
		{
			SetSeed(settings.seed);
			UpdateSurface(settings, Mathf.Max(0, num));
		}
		if ((settings.meshIsDirtyMask & MeshFlags.Speed) != MeshFlags.None || num != -1)
		{
			SetSeed(settings.seed);
			UpdateSpeed(settings, Mathf.Max(0, num));
		}
		if ((settings.meshIsDirtyMask & MeshFlags.Color) != MeshFlags.None || num != -1)
		{
			SetSeed(settings.seed);
			UpdateColor(settings, Mathf.Max(0, num));
		}
		ResetSeed();
		dataStructureVersion = 2;
	}

	protected void FillMesh(Mesh mesh)
	{
		mesh.Clear();
		mesh.vertices = verts;
		mesh.normals = normals;
		mesh.tangents = tangents;
		mesh.uv = uv0;
		mesh.uv2 = uv1;
		mesh.colors = colors;
		mesh.triangles = triangles;
	}

	public int GetClampedParticleCount(int count)
	{
		int maximumParticleCount = GetMaximumParticleCount();
		if (count > maximumParticleCount)
		{
			return maximumParticleCount;
		}
		return count;
	}

	protected virtual int SetParticleCapacity(int count)
	{
		return -1;
	}

	protected void SetArraySizes(int vertCount, int triCount)
	{
		Vector3[] array = new Vector3[vertCount];
		Vector3[] array2 = new Vector3[vertCount];
		Vector4[] array3 = new Vector4[vertCount];
		Vector2[] array4 = new Vector2[vertCount];
		Vector2[] array5 = new Vector2[vertCount];
		Color[] array6 = new Color[vertCount];
		int[] array7 = new int[triCount];
		int num = Mathf.Min(verts.Length, vertCount);
		for (int i = 0; i < num; i++)
		{
			array[i] = verts[i];
			array2[i] = normals[i];
			array3[i] = tangents[i];
			array4[i] = uv0[i];
			array5[i] = uv1[i];
			array6[i] = colors[i];
		}
		num = Mathf.Min(triangles.Length, triCount);
		for (int j = 0; j < num; j++)
		{
			array7[j] = triangles[j];
		}
		verts = array;
		normals = array2;
		tangents = array3;
		uv0 = array4;
		uv1 = array5;
		colors = array6;
		triangles = array7;
	}

	protected virtual void UpdateDirection(PAParticleField settings, int startAt)
	{
	}

	protected virtual void UpdateSurface(PAParticleField settings, int startAt)
	{
	}

	protected virtual void UpdateSpeed(PAParticleField settings, int startAt)
	{
	}

	protected virtual void UpdateColor(PAParticleField settings, int startAt)
	{
	}

	protected virtual void UpdateIndicies()
	{
	}

	protected virtual void UpdateTriangles(int startAt)
	{
	}

	public void ClearCache()
	{
		verts = new Vector3[0];
		normals = new Vector3[0];
		tangents = new Vector4[0];
		uv0 = new Vector2[0];
		uv1 = new Vector2[0];
		colors = new Color[0];
		triangles = new int[0];
	}

	public void CheckDataStructureVersion()
	{
		if (dataStructureVersion != 2)
		{
			UpdateCache(GetComponent<PAParticleField>());
		}
	}
}
