using UnityEngine;

public class GameRecorderViewerUnit : MonoBehaviour
{
	public struct Vault
	{
		public int unitUID;

		public Vector3 position;

		public int sizeX;

		public int sizeY;

		public int rotation;

		public Color32 color;

		public int overrideImage;

		public Vault(GameRecorderViewerUnit grvu)
		{
			unitUID = 0;
			position = default(Vector3);
			sizeX = 0;
			sizeY = 0;
			rotation = 0;
			color = default(Color32);
			overrideImage = 0;
		}

		public Vault(int unitType, Vector3 position, int sizeX, int sizeY, int rotation, Color32 color, int overrideImage)
		{
			unitUID = 0;
			this.position = default(Vector3);
			this.sizeX = 0;
			this.sizeY = 0;
			this.rotation = 0;
			this.color = default(Color32);
			this.overrideImage = 0;
		}
	}

	public int lifeToSelfDestruct;

	private int _unitUID;

	private int _sizeX;

	private int _sizeY;

	private int _rotation;

	private Color32 _color;

	private int _overrideImage;

	private Mesh mesh;

	public int unitUID
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public Vector3 position
	{
		get
		{
			return default(Vector3);
		}
		set
		{
		}
	}

	public int sizeX
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int sizeY
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int rotation
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public Color32 color
	{
		get
		{
			return default(Color32);
		}
		set
		{
		}
	}

	public int overrideImage
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public void Awake()
	{
	}

	public void InitFromVault(Vault v)
	{
	}

	public Vault GetVault()
	{
		return default(Vault);
	}

	private void SetSize()
	{
	}

	private void SetColor(Color32 color)
	{
	}

	protected void SetColor(Color32 color, Mesh m)
	{
	}

	private void SetUnitImage(int unitTypePos)
	{
	}

	public void DestroyUnit()
	{
	}
}
