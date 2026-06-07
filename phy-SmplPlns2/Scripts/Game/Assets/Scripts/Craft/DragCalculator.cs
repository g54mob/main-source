using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Design;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class DragCalculator
	{
		private class Cell
		{
			public bool Collision { get; set; }

			public float Drag { get; set; }

			public Vector3i GridPosition { get; set; }

			public float LateralDrag { get; set; }

			public PartData Part { get; set; }

			public Vector3 Position { get; set; }

			public float StartDrag { get; set; }

			public bool StartOfCollision { get; set; }

			public float TotalDrag => Drag + LateralDrag;

			public int Turbulence { get; set; }

			public float TurbulenceDrag { get; set; }

			public Cell(int x, int y, int z, Vector3 position)
			{
				GridPosition = new Vector3i(x, y, z);
				Position = position;
			}
		}

		private class Slice
		{
			public List<Cell> Cells { get; set; }

			public Slice()
			{
				Cells = new List<Cell>();
			}
		}

		private float[] _area = new float[6];

		private Cell[,,] _cells;

		private Vector3i _directionForward;

		private Vector3i _directionRight;

		private Vector3i _directionUp;

		private PartVolumeGrid _volume;

		private Vector3 _volumeMin;

		public int Border { get; private set; }

		public PartDrag.DragDirection Direction { get; set; }

		public float GridSize { get; private set; }

		public float WindDrag { get; private set; }

		private int SizeX { get; set; }

		private int SizeY { get; set; }

		private int SizeZ { get; set; }

		public DragCalculator(IEnumerable<PartData> parts)
		{
			PartVolumeGrid partVolumeGrid = (_volume = new PartVolumeGrid(parts));
			Border = 1;
			GridSize = partVolumeGrid.GridSize;
			WindDrag = GridSize * GridSize;
			_volumeMin = partVolumeGrid.VolumeMin;
			_volumeMin -= new Vector3(GridSize * (float)Border, GridSize * (float)Border, GridSize * (float)Border);
			SizeX = partVolumeGrid.SizeX + Border * 2;
			SizeY = partVolumeGrid.SizeY + Border * 2;
			SizeZ = partVolumeGrid.SizeZ + Border * 2;
			_cells = new Cell[SizeX, SizeY, SizeZ];
			for (int i = 0; i < SizeX; i++)
			{
				for (int j = 0; j < SizeY; j++)
				{
					for (int k = 0; k < SizeZ; k++)
					{
						Vector3 position = new Vector3
						{
							x = (float)i * GridSize + GridSize / 2f + _volumeMin.x,
							y = (float)j * GridSize + GridSize / 2f + _volumeMin.y,
							z = (float)k * GridSize + GridSize / 2f + _volumeMin.z
						};
						_cells[i, j, k] = new Cell(i, j, k, position);
					}
				}
			}
			foreach (PartData part in parts)
			{
				part.PartDrag.ClearVolume();
			}
			foreach (PartVolumeGrid.VolumeCell volumeCell in partVolumeGrid.VolumeCells)
			{
				int num = volumeCell.X + Border;
				int num2 = volumeCell.Y + Border;
				int num3 = volumeCell.Z + Border;
				_cells[num, num2, num3].Part = volumeCell.Part;
				volumeCell.Part.PartDrag.AddVolume();
			}
		}

		public void CalculateDrag()
		{
			CalculateDrag(PartDrag.DragDirection.Downward, mirror: true);
			CalculateDrag(PartDrag.DragDirection.Leftward, mirror: false);
			CalculateDrag(PartDrag.DragDirection.Rightward, mirror: false);
			CalculateDrag(PartDrag.DragDirection.Forward, mirror: true);
		}

		public float CalculateDragCount(PartDrag.DragDirection direction)
		{
			CalculateDrag(direction, mirror: false);
			float num = 0f;
			foreach (PartData part in _volume.Parts)
			{
				num += part.PartDrag.GetDrag(direction);
			}
			float num2 = 0.001f;
			return num / num2;
		}

		public void CreateGameObjects()
		{
			GameObject gameObject = new GameObject("Marching Grid");
			gameObject.transform.position = Vector3.zero;
			gameObject.transform.localScale = Vector3.one;
			gameObject.transform.localRotation = Quaternion.identity;
			Vector3 position = default(Vector3);
			for (int i = Border; i < SizeX - Border; i++)
			{
				for (int j = Border; j < SizeY - Border; j++)
				{
					for (int k = Border; k < SizeZ - Border; k++)
					{
						Cell cell = _cells[i, j, k];
						if (cell.Collision)
						{
							position.x = (float)cell.GridPosition.x * GridSize + GridSize / 2f;
							position.y = (float)cell.GridPosition.y * GridSize + GridSize / 2f;
							position.z = (float)cell.GridPosition.z * GridSize + GridSize / 2f;
							position += _volumeMin;
							Color white = Color.white;
							float num = cell.TotalDrag / WindDrag;
							if (num < 0f)
							{
								num = 0f;
							}
							white.r = num;
							white.g = num;
							white.b = num;
							Material material = UnityEngine.Object.Instantiate(Resources.Load("Designer/Materials/DesignerPartDrag")) as Material;
							material.color = new Color(1f, 0f, 0f, num);
							if (!cell.StartOfCollision)
							{
								material.color = new Color(0f, 1f, 0f, num);
							}
							GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
							gameObject2.name = "Cell";
							_ = cell.Part;
							DragDebugScript dragDebugScript = gameObject2.AddComponent<DragDebugScript>();
							dragDebugScript.Collision = cell.Collision;
							dragDebugScript.StartCollision = cell.StartOfCollision;
							dragDebugScript.Drag = cell.Drag / WindDrag;
							dragDebugScript.LateralDrag = cell.LateralDrag;
							gameObject2.transform.parent = gameObject.transform;
							gameObject2.transform.position = position;
							gameObject2.transform.localScale = new Vector3(GridSize / 2f, GridSize / 2f, GridSize / 2f);
							gameObject2.transform.localRotation = Quaternion.identity;
							gameObject2.GetComponent<MeshRenderer>().material = material;
						}
					}
				}
			}
		}

		private void CalculateDrag(PartDrag.DragDirection direction, bool mirror)
		{
			Direction = direction;
			_area[(int)direction] = 0f;
			Cell[,,] cells = _cells;
			foreach (Cell cell in cells)
			{
				cell.Drag = 0f;
				cell.StartDrag = 0f;
				cell.LateralDrag = 0f;
				cell.TurbulenceDrag = 0f;
				cell.Collision = false;
				cell.StartOfCollision = false;
			}
			List<Slice> list = CreateSlices(direction);
			foreach (Cell cell3 in list[0].Cells)
			{
				cell3.Drag = WindDrag;
				cell3.StartDrag = cell3.Drag;
			}
			foreach (Slice item in list)
			{
				foreach (Cell cell4 in item.Cells)
				{
					if (!IsBorderCell(cell4))
					{
						if (cell4.Part == null)
						{
							Cell[] neighbors = new Cell[4]
							{
								GetCellAbove(cell4),
								GetCellBelow(cell4),
								GetCellLeft(cell4),
								GetCellRight(cell4)
							};
							Diffuse(cell4, neighbors);
							CalculateTurbulence(cell4, neighbors);
						}
					}
					else
					{
						cell4.StartDrag = WindDrag;
						cell4.Drag = WindDrag;
					}
				}
				foreach (Cell cell5 in item.Cells)
				{
					if (cell5.Part == null || cell5.Collision || !(cell5.Drag > 0f))
					{
						continue;
					}
					Cell cellLast = GetCellLast(cell5);
					if (Collision(cell5, cellLast) || cell5.Part.IsUsingConstantDrag)
					{
						cell5.StartOfCollision = true;
						cell5.Collision = true;
						_area[(int)direction] += GridSize * GridSize;
						Cell cellNext = GetCellNext(cell5);
						while (cellNext.Part == cell5.Part)
						{
							cellNext.Collision = true;
							cellNext = GetCellNext(cellNext);
						}
					}
				}
				foreach (Cell cell6 in item.Cells)
				{
					Cell cellNext2 = GetCellNext(cell6);
					if (!cell6.Collision && !cellNext2.Collision)
					{
						cellNext2.StartDrag = cell6.Drag;
						cellNext2.Drag = cell6.Drag;
						cellNext2.LateralDrag = cell6.LateralDrag * 0f;
						cellNext2.Turbulence = Math.Max(cell6.Turbulence - 1, 0);
					}
				}
			}
			foreach (PartData part in _volume.Parts)
			{
				part.PartDrag.SetDrag(direction, 0f, 0f);
			}
			cells = _cells;
			foreach (Cell cell2 in cells)
			{
				if (cell2.StartOfCollision)
				{
					cell2.Part.PartDrag.AddHit(direction);
					if (cell2.Part.IsUsingConstantDrag)
					{
						cell2.Part.PartDrag.SetDrag(direction, cell2.Part.PartType.ConstantDrag * cell2.Part.DragScale, 0f);
					}
					else
					{
						cell2.Part.PartDrag.AddDrag(direction, cell2.TotalDrag * cell2.Part.DragScale, null, 0f);
					}
				}
				if (cell2.Part != null)
				{
					cell2.Part.PartDrag.AddDrag(direction, cell2.TurbulenceDrag * cell2.Part.DragScale, null, 0f);
				}
			}
			if (!mirror)
			{
				return;
			}
			foreach (PartData part2 in _volume.Parts)
			{
				float drag = part2.PartDrag.GetDrag(direction);
				part2.PartDrag.SetDrag(PartDrag.OppositeDirection(direction), drag, 0f);
			}
		}

		private void CalculateTurbulence(Cell cell, Cell[] neighbors)
		{
			float num = (float)(cell.Turbulence - 5) * 0.001f;
			if (num < 0f)
			{
				num = 0f;
			}
			if (num > 0.01f)
			{
				num = 0.01f;
			}
			float num2 = cell.TotalDrag / WindDrag;
			foreach (Cell cell2 in neighbors)
			{
				if (cell2.Part != null)
				{
					cell.Turbulence++;
					cell2.TurbulenceDrag += 0.001f * num2;
				}
			}
		}

		private bool Collision(Cell cell, Cell lastCell)
		{
			Dictionary<GameObject, int> dictionary = new Dictionary<GameObject, int>();
			int num = 20;
			foreach (EditorCollider editorCollider in cell.Part.PartScript.EditorColliders)
			{
				GameObject gameObject = editorCollider.Collider.gameObject;
				if (!dictionary.ContainsKey(gameObject))
				{
					dictionary.Add(gameObject, gameObject.layer);
				}
				gameObject.layer = num;
			}
			int layerMask = 1 << num;
			float drag = cell.Drag;
			Ray ray = new Ray(lastCell.Position, cell.Position - lastCell.Position);
			bool result = false;
			if (Physics.Raycast(ray, out var hitInfo, float.PositiveInfinity, layerMask))
			{
				DiffuseLateralDrag(cell, ray.direction, hitInfo.normal, drag, 1f);
				result = true;
			}
			foreach (EditorCollider editorCollider2 in cell.Part.PartScript.EditorColliders)
			{
				GameObject gameObject2 = editorCollider2.Collider.gameObject;
				gameObject2.layer = (dictionary.ContainsKey(gameObject2) ? dictionary[gameObject2] : 21);
			}
			return result;
		}

		private List<Slice> CreateSlices(PartDrag.DragDirection direction)
		{
			List<Slice> list = new List<Slice>();
			switch (direction)
			{
			case PartDrag.DragDirection.Forward:
			{
				for (int num7 = SizeZ - 1; num7 >= Border; num7--)
				{
					Slice slice5 = new Slice();
					for (int num8 = 0; num8 < SizeX; num8++)
					{
						for (int num9 = 0; num9 < SizeY; num9++)
						{
							slice5.Cells.Add(_cells[num8, num9, num7]);
						}
					}
					list.Add(slice5);
				}
				_directionRight = new Vector3i(1, 0, 0);
				_directionUp = new Vector3i(0, 1, 0);
				_directionForward = new Vector3i(0, 0, -1);
				break;
			}
			case PartDrag.DragDirection.Backward:
			{
				for (int n = 0; n < SizeZ - Border; n++)
				{
					Slice slice3 = new Slice();
					for (int num2 = 0; num2 < SizeX; num2++)
					{
						for (int num3 = 0; num3 < SizeY; num3++)
						{
							slice3.Cells.Add(_cells[num2, num3, n]);
						}
					}
					list.Add(slice3);
				}
				_directionRight = new Vector3i(1, 0, 0);
				_directionUp = new Vector3i(0, 1, 0);
				_directionForward = new Vector3i(0, 0, 1);
				break;
			}
			case PartDrag.DragDirection.Upward:
			{
				for (int num10 = SizeY - 1; num10 >= Border; num10--)
				{
					Slice slice6 = new Slice();
					for (int num11 = 0; num11 < SizeX; num11++)
					{
						for (int num12 = 0; num12 < SizeZ; num12++)
						{
							slice6.Cells.Add(_cells[num11, num10, num12]);
						}
					}
					list.Add(slice6);
				}
				_directionRight = new Vector3i(1, 0, 0);
				_directionUp = new Vector3i(0, 0, 1);
				_directionForward = new Vector3i(0, -1, 0);
				break;
			}
			case PartDrag.DragDirection.Downward:
			{
				for (int k = 0; k < SizeY - Border; k++)
				{
					Slice slice2 = new Slice();
					for (int l = 0; l < SizeX; l++)
					{
						for (int m = 0; m < SizeZ; m++)
						{
							slice2.Cells.Add(_cells[l, k, m]);
						}
					}
					list.Add(slice2);
				}
				_directionRight = new Vector3i(1, 0, 0);
				_directionUp = new Vector3i(0, 0, 1);
				_directionForward = new Vector3i(0, 1, 0);
				break;
			}
			case PartDrag.DragDirection.Leftward:
			{
				for (int num4 = 0; num4 < SizeX - Border; num4++)
				{
					Slice slice4 = new Slice();
					for (int num5 = 0; num5 < SizeY; num5++)
					{
						for (int num6 = 0; num6 < SizeZ; num6++)
						{
							slice4.Cells.Add(_cells[num4, num5, num6]);
						}
					}
					list.Add(slice4);
				}
				_directionRight = new Vector3i(0, 0, 1);
				_directionUp = new Vector3i(0, 1, 0);
				_directionForward = new Vector3i(1, 0, 0);
				break;
			}
			case PartDrag.DragDirection.Rightward:
			{
				for (int num = SizeX - 1; num >= Border; num--)
				{
					Slice slice = new Slice();
					for (int i = 0; i < SizeY; i++)
					{
						for (int j = 0; j < SizeZ; j++)
						{
							slice.Cells.Add(_cells[num, i, j]);
						}
					}
					list.Add(slice);
				}
				_directionRight = new Vector3i(0, 0, 1);
				_directionUp = new Vector3i(0, 1, 0);
				_directionForward = new Vector3i(-1, 0, 0);
				break;
			}
			}
			return list;
		}

		private void Diffuse(Cell cell, Cell[] neighbors)
		{
			float num = 0f;
			int num2 = 0;
			foreach (Cell cell2 in neighbors)
			{
				if (cell2.Part == null)
				{
					num += cell2.StartDrag;
					num2++;
				}
			}
			num -= (float)num2 * cell.StartDrag;
			cell.Drag = cell.StartDrag + 0.2f * num;
		}

		private void DiffuseLateralDrag(Cell cell, Vector3 wind, Vector3 normal, float drag, float dragScale)
		{
			float num = (drag - Mathf.Abs(Vector3.Dot(wind, normal)) * drag) * dragScale;
			cell.Drag -= num;
			float num2 = Vector3.Dot(_directionRight.ToVector3(), normal);
			Cell cell2 = cell;
			int num3 = 0;
			int num4 = 0;
			Cell cell3 = null;
			while (cell2.Part == cell.Part)
			{
				Cell cell4 = null;
				if (num2 > 0.1f)
				{
					cell4 = GetCellRight(cell2);
				}
				else if (num2 < -0.1f)
				{
					cell4 = GetCellLeft(cell2);
				}
				else
				{
					float num5 = Vector3.Dot(_directionUp.ToVector3(), normal);
					if (num5 > 0.1f)
					{
						cell4 = GetCellAbove(cell2);
					}
					else if (num5 < -0.1f)
					{
						cell4 = GetCellBelow(cell2);
					}
				}
				if (cell4 != null)
				{
					if (cell3 == null)
					{
						cell3 = cell4;
					}
					num3++;
					if (cell4.Part != null && cell4.Part != cell.Part)
					{
						num4++;
					}
				}
				cell2 = GetCellNext(cell2);
			}
			if (num3 > 0)
			{
				float num6 = num * (float)num4 / (float)num3;
				cell.LateralDrag += num6 * 1.25f;
				if (cell3.Part == null)
				{
					cell3.LateralDrag += num - num6;
				}
			}
		}

		private Cell GetCellAbove(Cell cell)
		{
			Vector3i vector3i = cell.GridPosition + _directionUp;
			return _cells[vector3i.x, vector3i.y, vector3i.z];
		}

		private Cell GetCellBelow(Cell cell)
		{
			Vector3i vector3i = cell.GridPosition - _directionUp;
			return _cells[vector3i.x, vector3i.y, vector3i.z];
		}

		private Cell GetCellLast(Cell cell)
		{
			Vector3i vector3i = cell.GridPosition - _directionForward;
			return _cells[vector3i.x, vector3i.y, vector3i.z];
		}

		private Cell GetCellLeft(Cell cell)
		{
			Vector3i vector3i = cell.GridPosition - _directionRight;
			return _cells[vector3i.x, vector3i.y, vector3i.z];
		}

		private Cell GetCellNext(Cell cell)
		{
			Vector3i vector3i = cell.GridPosition + _directionForward;
			return _cells[vector3i.x, vector3i.y, vector3i.z];
		}

		private Cell GetCellRight(Cell cell)
		{
			Vector3i vector3i = cell.GridPosition + _directionRight;
			return _cells[vector3i.x, vector3i.y, vector3i.z];
		}

		private bool IsBorderCell(Cell cell)
		{
			if (cell.GridPosition.x >= Border && cell.GridPosition.y >= Border && cell.GridPosition.z >= Border && cell.GridPosition.x < SizeX - Border && cell.GridPosition.y < SizeY - Border)
			{
				return cell.GridPosition.z >= SizeZ - Border;
			}
			return true;
		}
	}
}
