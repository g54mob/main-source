using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	[DontSave]
	public class HospitalPlotFootprintPerimeter : MustCallDestroy
	{
		private struct Wall
		{
			public GridCoord pos;

			public GridDirection rot;
		}

		private Transform _root;

		private GameObject[] _prefabs;

		private float _offset;

		private bool _noRotation;

		private Dictionary<int, GameObject> _instances = new Dictionary<int, GameObject>();

		public Dictionary<int, GameObject>.ValueCollection Instances => _instances.Values;

		public HospitalPlotFootprintPerimeter(GameObject[] prefabs, float offset, bool noRotation)
		{
			_prefabs = prefabs;
			_offset = offset;
			_noRotation = noRotation;
			_root = new GameObject("Perimeter").transform;
		}

		public void Refresh(bool[,] floorPlan, GridCoord anchor)
		{
			if (_prefabs.IsEmpty())
			{
				return;
			}
			int length = floorPlan.GetLength(0);
			int length2 = floorPlan.GetLength(1);
			bool[,] array = new bool[length, length2];
			for (int i = 0; i < length2; i++)
			{
				for (int j = 0; j < length; j++)
				{
					if (!floorPlan[j, i])
					{
						array[j, i] = true;
					}
				}
			}
			List<Wall> list = new List<Wall>();
			for (int k = 0; k < length2; k++)
			{
				for (int l = 0; l < length; l++)
				{
					if (array[l, k] && l > 0 && l < length - 1 && k > 0 && k < length2 - 1)
					{
						bool flag = array[l, k - 1];
						bool flag2 = array[l + 1, k];
						bool flag3 = array[l, k + 1];
						bool num = array[l - 1, k];
						if (!flag)
						{
							list.Add(new Wall
							{
								pos = new GridCoord(l, k) + anchor,
								rot = GridDirection.NegY
							});
						}
						if (!flag2)
						{
							list.Add(new Wall
							{
								pos = new GridCoord(l, k) + anchor,
								rot = GridDirection.PosX
							});
						}
						if (!flag3)
						{
							list.Add(new Wall
							{
								pos = new GridCoord(l, k) + anchor,
								rot = GridDirection.PosY
							});
						}
						if (!num)
						{
							list.Add(new Wall
							{
								pos = new GridCoord(l, k) + anchor,
								rot = GridDirection.NegX
							});
						}
					}
				}
			}
			List<int> list2 = new List<int>();
			foreach (KeyValuePair<int, GameObject> instance in _instances)
			{
				GridCoord gridCoord = instance.Value.transform.position.ToGridCoord();
				bool flag4 = false;
				foreach (Wall item2 in list)
				{
					if (item2.pos == gridCoord)
					{
						flag4 = true;
						break;
					}
				}
				if (!flag4)
				{
					list2.Add(CoordKey(gridCoord.X, gridCoord.Y));
				}
			}
			for (int num2 = list.Count - 1; num2 >= 0; num2--)
			{
				Wall item = list[num2];
				int key = CoordKey(item.pos.X, item.pos.Y);
				if (_instances.ContainsKey(key))
				{
					list.Remove(item);
				}
			}
			foreach (int item3 in list2)
			{
				Object.Destroy(_instances[item3]);
				_instances.Remove(item3);
			}
			foreach (Wall item4 in list)
			{
				AddWall(item4.pos, item4.rot);
			}
		}

		private static int CoordKey(int x, int y)
		{
			return x + (y << 16);
		}

		private static int CoordHash(int x, int y)
		{
			int num = x * 374761393 + y * 668265263;
			int num2 = (num ^ (num >> 13)) * 1274126177;
			return num2 ^ (num2 >> 16);
		}

		private void AddWall(GridCoord worldPos, GridDirection direction)
		{
			int key = CoordKey(worldPos.X, worldPos.Y);
			if (!_instances.ContainsKey(key))
			{
				int num = CoordHash(worldPos.X, worldPos.Y);
				int num2 = num % _prefabs.Length;
				Vector3 position = worldPos.ToWorldPosition() + _offset * direction.DirectionVector();
				Quaternion rotation = Quaternion.Euler(0f, _noRotation ? direction.YawRotation() : ((float)(num % 360)), 0f);
				GameObject value = Object.Instantiate(_prefabs[num2], position, rotation, _root);
				_instances.Add(key, value);
			}
		}

		public override void Destroy()
		{
			Object.Destroy(_root.gameObject);
			base.Destroy();
		}
	}
}
