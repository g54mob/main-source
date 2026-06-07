using UnityEngine;

public class TerrainRangeIndicator : MonoBehaviour
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

	private int _WIDTH;

	private int _HEIGHT;

	public float TILEX;

	public float TILEY;

	public bool flat;

	public bool trackCreeper;

	public TEXTUREMAPPING textureMapping;

	public float floatBias;

	public bool showOnCliffs;

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

	private void Awake()
	{
	}

	private void LateUpdate()
	{
	}

	public void Init()
	{
	}

	private void OnDestroy()
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
}
