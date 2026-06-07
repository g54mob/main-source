using UnityEngine;

public class MistManager : MonoBehaviour, IManagerPoolable
{
	private int birthTime;

	private int fadeTime;

	private int updateCount;

	private float deltaX;

	private float deltaY;

	private float deltaZ;

	private float startSize;

	private float endSize;

	private Color baseColor;

	private MeshFilter meshFilter;

	private Mesh mesh;

	private Color[] colors;

	private Vector3[] vertices;

	private Vector2[] uvs;

	private float size;

	private Renderer rend;

	private float randRot;

	public static MistManager GetMist(float worldX, float worldY, float worldZ, Color color, int birthTime, int fadeTime, float lowerSpeed, float upperSpeed)
	{
		return null;
	}

	public static MistManager GetMist(float worldX, float worldY, float worldZ, Color color, int birthTime, int fadeTime, Vector3 velocity)
	{
		return null;
	}

	public static MistManager GetMist(float worldX, float worldY, float worldZ, Color color)
	{
		return null;
	}

	public static void DestroyAll()
	{
	}

	public void TakenFromPool()
	{
	}

	public void ReturnedToPool()
	{
	}

	private void Awake()
	{
	}

	public void Init(float worldX, float worldY, float worldZ, Color color, int birthTime, int fadeTime, float lowerSpeed, float upperSpeed)
	{
	}

	public void Init(float worldX, float worldY, float worldZ, Color color, int birthTime, int fadeTime, Vector3 velocity)
	{
	}

	private void Init(float worldX, float worldY, float worldZ, Color color, int birthTime, int fadeTime)
	{
	}

	public void GameUpdate()
	{
	}

	private void LateUpdate()
	{
	}

	private void Finish()
	{
	}

	public void SetColor(Color c)
	{
	}

	public void SetSize(float size)
	{
	}

	private void OnDestroy()
	{
	}
}
