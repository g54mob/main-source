using System.Collections.Generic;
using NBT.Tags;
using UnityEngine;

public class LandBasePanel : MonoBehaviour
{
	public class LandBaseItem
	{
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

		public void Destroy()
		{
		}

		public LandBaseItem()
		{
		}

		public LandBaseItem(LandBaseItem si)
		{
		}

		public LandBaseItem(int mapCell, Vector3 position, Quaternion rotation, Vector3 scale)
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

	public Material mat;

	private Dictionary<int, LandBaseItem> itemDicts;

	private List<Matrix4x4>[] itemMatrices;

	private MaterialPropertyBlock mpb;

	private bool listDirty;

	public void Awake()
	{
	}

	private LandBaseItem AddItem(int mapCell)
	{
		return null;
	}

	public LandBaseItem AddItem(int cellX, int cellY)
	{
		return null;
	}

	private void RemoveItem(int mapCell)
	{
	}

	public void RemoveItem(int cellX, int cellY)
	{
	}

	private LandBaseItem AddItem(int mapCell, Vector3 position, Quaternion rotation, Vector3 scale)
	{
		return null;
	}

	public void RemoveAllItems()
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
}
