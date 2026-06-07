using System;
using System.Collections.Generic;
using NBT.Tags;
using UnityEngine;

public class Packet : MonoBehaviour
{
	public enum PACKET_TYPE
	{
		CONSTRUCTION = 0,
		AMMO = 1,
		WARE = 2
	}

	public static float SUPER_PACKET_SPEED_MUL;

	public Material wareMaterial;

	public const int atlas_cols = 28;

	public const int atlas_pad = 8;

	public const int atlas_isize = 128;

	public const int atlas_width = 1024;

	public const int atlas_height = 1024;

	[NonSerialized]
	public float PACKET_SPEED;

	[NonSerialized]
	public PACKET_TYPE type;

	[NonSerialized]
	public UnitManager currentSource;

	[NonSerialized]
	public UnitManager start;

	[NonSerialized]
	public UnitManager goal;

	private Path currentPath;

	private float currentDistance;

	[NonSerialized]
	public bool destroyed;

	[NonSerialized]
	public UnitManager oe;

	[NonSerialized]
	public float coordX;

	[NonSerialized]
	public float coordY;

	[NonSerialized]
	public int wareType;

	protected bool rotateWhenMoving;

	protected bool multipleRotationImages;

	private float _rotation;

	[NonSerialized]
	public float width;

	[NonSerialized]
	public float height;

	private Mesh mesh;

	private MeshFilter meshFilter;

	private Vector3[] vertices;

	private Vector2[] uvs;

	private Color32[] colors;

	private int[] triangles;

	private bool geometryCreated;

	private static Vector3[] v;

	private static Vector3[] n;

	private static int[] t;

	private Color32 NORMAL_COLOR;

	private Color32 AMMO_COLOR;

	private Color32 OPERATE_COLOR;

	private int cachedTravelPathIndex;

	private List<UnitManager> cachedTravelPath;

	private int hilightInterval;

	public float rotation
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public static Packet GetPackForLoad()
	{
		return null;
	}

	public static Packet GetPacket(PACKET_TYPE type, UnitManager currentSource, UnitManager goal, int wareType = 0)
	{
		return null;
	}

	public virtual void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void CreateGeometry()
	{
	}

	public static void CreateWareGeometry(float size, Mesh mesh)
	{
	}

	private void Start()
	{
	}

	public void Reset()
	{
	}

	public void Init(PACKET_TYPE type, UnitManager currentSource, UnitManager goal, int wareType)
	{
	}

	private void SetColor()
	{
	}

	private void CalculatePath()
	{
	}

	private void NextTarget()
	{
	}

	private void ReachGoal()
	{
	}

	public void DestroyPacket()
	{
	}

	public void Update()
	{
	}

	public void GameUpdate()
	{
	}

	private void Render()
	{
	}

	private void MakeTriangles(float x1, float z1, float x2, float z2, float height, int i)
	{
	}

	private static void SetFace(Vector3[] vertices, Vector3[] n, int[] t, int face, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
	{
	}

	public static void SetTexture(int num, Mesh mesh, bool quadGeometry = false)
	{
	}

	public static Vector2 GetUVUnscaled(int t)
	{
		return default(Vector2);
	}

	public void ReadData(Tag data)
	{
	}

	public virtual TagCompound WriteData()
	{
		return null;
	}
}
