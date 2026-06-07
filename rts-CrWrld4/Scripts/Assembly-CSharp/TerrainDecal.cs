using System;
using NBT.Tags;
using UnityEngine;

public class TerrainDecal : MonoBehaviour
{
	public enum TEXTUREMAPPING
	{
		LINEAR = 0,
		ANAMORPHIC = 1,
		ANAMORPHIC_TILE = 2
	}

	public enum ROTATION
	{
		FORWARD = 0,
		RIGHT = 1,
		BACK = 2,
		LEFT = 3
	}

	public class ClonePack
	{
		private TagCompound data;

		public ClonePack(TagCompound data)
		{
		}

		public void CloneData(TerrainDecal targetDecal)
		{
		}
	}

	private int _WIDTH;

	private int _HEIGHT;

	[NonSerialized]
	public int decalUID;

	public float TILEX;

	public float TILEY;

	public bool flat;

	public bool trackCreeper;

	public TEXTUREMAPPING textureMapping;

	public float floatBias;

	public bool showOnCliffs;

	public RectangleBorder rectangleBorder;

	private int _materialSlot;

	private Color32 color;

	private Vector3[] v;

	private Color32[] c;

	private Vector2[] u;

	private int[] t;

	private Mesh lmesh;

	private TEXTUREMAPPING lastTextureMapping;

	private bool _flipHorizontal;

	private bool _flipVertical;

	public ROTATION _rotation;

	private bool _selected;

	public int WIDTH
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int HEIGHT
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public bool visible
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public int cellX
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int cellY
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int materialSlot
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public bool flipHorizontal
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool flipVertical
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public ROTATION rotation
	{
		get
		{
			return default(ROTATION);
		}
		set
		{
		}
	}

	private bool selected
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public void ReassignDecalUID(int newUID)
	{
	}

	private void Awake()
	{
	}

	public void InformCurrentPosition(int cellX, int cellY)
	{
	}

	private void LateUpdate()
	{
	}

	public void DisableBorderDuringFinalization()
	{
	}

	public void Init()
	{
	}

	private void OnDestroy()
	{
	}

	private void UpdateIndicator()
	{
	}

	private void UpdateMesh()
	{
	}

	public void UpdateUVs()
	{
	}

	private void UpdateUVsAnamorphic(bool normalize)
	{
	}

	public Color GetColor()
	{
		return default(Color);
	}

	public void SetColor(Color32 color)
	{
	}

	private float GetHeight(int cellX, int cellY)
	{
		return 0f;
	}

	public ClonePack GetClonePack()
	{
		return null;
	}

	public void DestroyTerrainDecal()
	{
	}

	public void ReadData(Tag data)
	{
	}

	public TagCompound WriteData()
	{
		return null;
	}
}
