using System;
using System.Collections.Generic;
using UnityEngine;

public class BoxGridLayout3D : MonoBehaviour
{
	[Serializable]
	public class GridLayout : ICloneable
	{
		public BoxSize boxSize;

		public int boxCount;

		public Vector3 firstBoxPosition;

		public Vector3 boxAngle;

		public Vector3 spacing;

		public Vector2Int itemPlacement;

		public float scaleMultiplier;

		public GridLayout(GridLayout gridLayout)
		{
		}

		public object Clone()
		{
			return null;
		}
	}

	public BoxSO Box;

	[Space]
	public GridLayout CustomGridLayout;

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
