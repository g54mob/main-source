using System;
using System.Collections.Generic;
using NBT.Tags;
using UnityEngine;

public class GreenarPanel : MonoBehaviour
{
	public class GreenarItem
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

		public void Destroy(bool createMist)
		{
		}

		public GreenarItem()
		{
		}

		public GreenarItem(GreenarItem si)
		{
		}

		public GreenarItem(int mapCell, Vector3 position, Quaternion rotation, Vector3 scale)
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

	public Mesh itemMesh;

	public Material materialRock;

	private Vector3 scale;

	private Dictionary<int, GreenarItem> itemDict;

	private List<Matrix4x4> itemMatrices;

	private GreenarItem[] greenarItemMap;

	[NonSerialized]
	public int[] excavationMap;

	private MaterialPropertyBlock mpb;

	private bool listDirty;

	private float RR;

	public void Awake()
	{
	}

	public int GetItemCount()
	{
		return 0;
	}

	public GreenarItem AddItem(int cellX, int cellY)
	{
		return null;
	}

	public GreenarItem GetItem(int cellX, int cellY)
	{
		return null;
	}

	public void RemoveItem(int cellX, int cellY)
	{
	}

	private GreenarItem AddItem(int mapCell, Vector3 position, Quaternion rotation, Vector3 scale)
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

	public List<GreenarItem> GetAllItems(bool copy = false)
	{
		return null;
	}

	public void SetAllItems(List<GreenarItem> items, bool clearFirst = false)
	{
	}

	public void ReadData(Tag baseTag)
	{
	}

	public void WriteData(TagCompound baseTag)
	{
	}
}
