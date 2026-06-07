using System.Collections.Generic;
using NBT.Tags;
using UnityEngine;

public class ScapePanel : MonoBehaviour
{
	public enum ITEM
	{
		CACTUS = 0,
		PALM = 1,
		PINE_TREE = 2,
		ALIEN_PLANT = 3,
		STUMP = 4
	}

	public class ScapeItem
	{
		public ITEM item;

		public int mapCell;

		public Vector3 _position;

		public Vector3 _scale;

		public Quaternion _rotation;

		public Matrix4x4 matrix;

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

		public Vector3 scale
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Quaternion rotation
		{
			get
			{
				return default(Quaternion);
			}
			set
			{
			}
		}

		public void Destroy(bool createStump, bool createMist)
		{
		}

		public void MoveItemToTerrain()
		{
		}

		public ScapeItem()
		{
		}

		public ScapeItem(ScapeItem si)
		{
		}

		public ScapeItem(ITEM item, int mapCell, Vector3 position, Quaternion rotation, Vector3 scale)
		{
		}

		private void UpdateMatrix()
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

	public const int MAX_ITEM = 1000;

	public const int BATCH = 4;

	public Mesh[] itemMeshes;

	public Material materialPlant;

	public Material materialRock;

	private Vector3[] scales;

	private Dictionary<int, ScapeItem>[] itemDicts;

	private List<Matrix4x4>[] itemMatrices;

	private ScapeItem[] scapeItemMap;

	private byte[] deadMap;

	private MaterialPropertyBlock mpb;

	private bool listDirty;

	private float RR;

	public static float SPIKE_SCALE;

	private float regrowRate;

	public void Awake()
	{
	}

	public void SetListDirty()
	{
	}

	public void SetDead(ITEM item, int mapCell)
	{
	}

	public void SetDead(ITEM item, int cellX, int cellY)
	{
	}

	public int GetItemCount(ITEM item)
	{
		return 0;
	}

	public int GetLifeCount()
	{
		return 0;
	}

	private ScapeItem AddItem(ITEM item, int mapCell)
	{
		return null;
	}

	public ScapeItem AddItem(ITEM item, int cellX, int cellY)
	{
		return null;
	}

	public ScapeItem GetItem(int cellX, int cellY)
	{
		return null;
	}

	private void RemoveItem(int mapCell)
	{
	}

	public void RemoveItem(int cellX, int cellY)
	{
	}

	private ScapeItem AddItem(ITEM item, int mapCell, Vector3 position, Quaternion rotation, Vector3 scale)
	{
		return null;
	}

	public void RemoveAllItems()
	{
	}

	public void StumpAll()
	{
	}

	public void RefreshSpikeStumps()
	{
	}

	private void UpdateMatrices()
	{
	}

	private void Update()
	{
	}

	public void GameUpdate()
	{
	}

	public List<ScapeItem> GetAllItems(bool copy = false)
	{
		return null;
	}

	public void SetAllItems(List<ScapeItem> items, bool clearFirst = false)
	{
	}

	public void ReadData(Tag baseTag)
	{
	}

	public void WriteData(TagCompound baseTag)
	{
	}
}
