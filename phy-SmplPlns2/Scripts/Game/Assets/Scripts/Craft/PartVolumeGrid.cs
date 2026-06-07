using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class PartVolumeGrid
	{
		public class VolumeCell
		{
			public PartData Part { get; set; }

			public int X { get; set; }

			public int Y { get; set; }

			public int Z { get; set; }
		}

		private Dictionary<int, VolumeCell> _cells;

		public float GridSize { get; private set; }

		public List<PartData> Parts { get; private set; }

		public int SizeX { get; set; }

		public int SizeY { get; set; }

		public int SizeZ { get; set; }

		public IEnumerable<VolumeCell> VolumeCells => _cells.Values;

		public Vector3 VolumeMin { get; set; }

		public PartVolumeGrid(IEnumerable<PartData> parts)
		{
			EditorCollider.GlobalUpdateId++;
			Parts = new List<PartData>();
			Parts.AddRange(parts);
			Vector3 vector = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
			Vector3 vector2 = new Vector3(float.MinValue, float.MinValue, float.MinValue);
			Vector3 vector3 = Vector3.zero;
			foreach (PartData part in Parts)
			{
				if (part.PartScript.HasModifier<WingScript>())
				{
					continue;
				}
				foreach (EditorCollider editorCollider in part.PartScript.EditorColliders)
				{
					if (editorCollider.IncludeInAero && part.DragType == PartDragType.Standard)
					{
						editorCollider.Update();
						Bounds bounds = editorCollider.Bounds;
						Vector3 min = bounds.min;
						Vector3 max = bounds.max;
						if (vector.x > min.x)
						{
							vector.x = min.x;
						}
						if (vector2.x < max.x)
						{
							vector2.x = max.x;
						}
						if (vector.y > min.y)
						{
							vector.y = min.y;
						}
						if (vector2.y < max.y)
						{
							vector2.y = max.y;
						}
						if (vector.z > min.z)
						{
							vector.z = min.z;
						}
						if (vector2.z < max.z)
						{
							vector2.z = max.z;
						}
						if (part.IsCockpit)
						{
							vector3 = editorCollider.Bounds.min;
						}
					}
				}
			}
			Vector3 vector4 = vector2 - vector;
			float num = vector4.x * vector4.y * vector4.z;
			if (num > 25000f)
			{
				Debug.LogFormat("Large aircraft detected ({0} cubic meters). Reducing precision of drag calculations", num);
				GridSize = 0.5f;
			}
			else
			{
				GridSize = 0.25f;
			}
			Vector3 vector5 = vector3 - vector;
			Vector3 vector6 = new Vector3
			{
				x = (int)(vector5.x / GridSize) + 1,
				y = (int)(vector5.y / GridSize) + 1,
				z = (int)(vector5.z / GridSize) + 1
			};
			vector6 *= GridSize;
			VolumeMin = vector3 - vector6;
			vector = VolumeMin;
			_cells = new Dictionary<int, VolumeCell>();
			foreach (PartData part2 in Parts)
			{
				if (part2.PartScript.HasModifier<WingScript>())
				{
					continue;
				}
				foreach (EditorCollider editorCollider2 in part2.PartScript.EditorColliders)
				{
					if (!editorCollider2.IncludeInAero || part2.DragType != PartDragType.Standard)
					{
						continue;
					}
					Vector3 min2 = editorCollider2.Bounds.min;
					Vector3 max2 = editorCollider2.Bounds.max;
					int num2 = (int)((min2.x + 0.05f - vector.x) / GridSize);
					int num3 = (int)((min2.y + 0.05f - vector.y) / GridSize);
					int num4 = (int)((min2.z + 0.05f - vector.z) / GridSize);
					int num5 = (int)((max2.x - 0.05f - vector.x) / GridSize);
					int num6 = (int)((max2.y - 0.05f - vector.y) / GridSize);
					int num7 = (int)((max2.z - 0.05f - vector.z) / GridSize);
					if (num5 < num2)
					{
						num5 = num2;
					}
					if (num6 < num3)
					{
						num6 = num3;
					}
					if (num7 < num4)
					{
						num7 = num4;
					}
					for (int i = num2; i <= num5; i++)
					{
						for (int j = num3; j <= num6; j++)
						{
							for (int k = num4; k <= num7; k++)
							{
								CreateCell(i, j, k).Part = part2;
							}
						}
					}
				}
			}
		}

		public VolumeCell CreateCell(int x, int y, int z)
		{
			int hash = GetHash(x, y, z);
			if (!_cells.ContainsKey(hash))
			{
				VolumeCell volumeCell = new VolumeCell();
				volumeCell.X = x;
				volumeCell.Y = y;
				volumeCell.Z = z;
				_cells[hash] = volumeCell;
				if (SizeX < x + 1)
				{
					SizeX = x + 1;
				}
				if (SizeY < y + 1)
				{
					SizeY = y + 1;
				}
				if (SizeZ < z + 1)
				{
					SizeZ = z + 1;
				}
			}
			return _cells[hash];
		}

		public GameObject CreateGameObjects()
		{
			GameObject gameObject = new GameObject("Volume Grid");
			gameObject.transform.position = Vector3.zero;
			gameObject.transform.localScale = Vector3.one;
			gameObject.transform.localRotation = Quaternion.identity;
			Vector3 vector = default(Vector3);
			foreach (VolumeCell value in _cells.Values)
			{
				vector.x = (float)value.X * GridSize + GridSize / 2f;
				vector.y = (float)value.Y * GridSize + GridSize / 2f;
				vector.z = (float)value.Z * GridSize + GridSize / 2f;
				GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				gameObject2.transform.parent = gameObject.transform;
				gameObject2.transform.position = vector + VolumeMin;
				gameObject2.transform.localScale = new Vector3(GridSize / 2f, GridSize / 2f, GridSize / 2f);
				gameObject2.transform.localRotation = Quaternion.identity;
			}
			GameObject gameObject3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
			gameObject3.transform.parent = gameObject.transform;
			gameObject3.transform.position = VolumeMin;
			gameObject3.transform.localScale = new Vector3(GridSize / 2f, GridSize / 2f, GridSize / 2f);
			gameObject3.transform.localRotation = Quaternion.identity;
			return gameObject;
		}

		public VolumeCell GetCell(int x, int y, int z)
		{
			int hash = GetHash(x, y, z);
			if (_cells.ContainsKey(hash))
			{
				return _cells[hash];
			}
			return null;
		}

		private int GetHash(int x, int y, int z)
		{
			return x * 2048 * 2048 + y * 2048 + z;
		}
	}
}
