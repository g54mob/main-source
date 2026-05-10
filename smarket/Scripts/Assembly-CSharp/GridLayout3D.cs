using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GridLayout3D : MonoBehaviour
{
	[Serializable]
	public class GridLayout : ICloneable
	{
		public BoxSize boxSize;

		public int productCount;

		public Vector3 firstObjectPosition;

		public Vector3 productAngles;

		public Vector3 spacing;

		public Vector3Int productPlacement;

		public float scaleMultiplier;

		public GridLayout(GridLayout gridLayout)
		{
		}

		public object Clone()
		{
			return null;
		}
	}

	public ProductSO Product;

	[Space]
	public GridLayout CustomGridLayout;

	public bool IsBoxLayout;

	public bool GenerateBox;

	public bool OpenBox;

	private List<GameObject> m_Items;

	private bool m_SavedChanges;

	public bool SavedChanges
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void Validate()
	{
	}
}
