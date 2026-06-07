using System;
using System.Collections.Generic;
using UnityEngine;

public class Vis : MonoBehaviour
{
	[Serializable]
	public struct Wide
	{
		public uint lo;

		public uint hi;

		public ulong decoded
		{
			get
			{
				return ((ulong)hi << 32) | lo;
			}
		}

		public Wide(ulong v)
		{
			lo = (uint)(v & 0xFFFFFFFFu);
			hi = (uint)(v / 4294967296L);
		}
	}

	[Serializable]
	public class Target
	{
		public ulong mask0;

		public ulong mask1;

		public Wide maskWide0;

		public Wide maskWide1;

		public GameObject go;

		public VisFade fade;
	}

	[Serializable]
	public struct Coord
	{
		public int x;

		public int y;

		public int z;

		public Coord(int x_, int y_, int z_)
		{
			x = x_;
			y = y_;
			z = z_;
		}

		public static Coord operator +(Coord a, Coord b)
		{
			return new Coord(a.x + b.x, a.y + b.y, a.z + b.z);
		}

		public static Coord operator -(Coord a, Coord b)
		{
			return new Coord(a.x - b.x, a.y - b.y, a.z - b.z);
		}
	}

	[Serializable]
	public class Cell
	{
		public List<int> visRegionIndexes = new List<int>();
	}

	[Serializable]
	public class Grid
	{
		public Coord min;

		public Coord max;

		public Coord count;

		public List<Cell> cells = new List<Cell>();
	}

	[Serializable]
	public class OcclusionPortalRegion
	{
		public ulong mask0;

		public ulong mask1;

		public Wide maskWide0;

		public Wide maskWide1;

		public OcclusionPortal portal;
	}

	public Vector3 gridCellSize = new Vector3(20f, 2.5f, 10f);

	[HideInInspector]
	public Vector3 gridCellSizeInverted;

	public int maxRegionsPerFrame = 10;

	public List<Target> targets = new List<Target>();

	public List<VisRegion> visRegions = new List<VisRegion>();

	public List<OcclusionPortalRegion> occlusionPortalRegions = new List<OcclusionPortalRegion>();

	public Grid grid;

	private Vector3 cameraPos;

	public ulong visibleMask0;

	public ulong visibleMask1;

	public Coord ToCoord(Vector3 p)
	{
		return new Coord
		{
			x = Mathf.FloorToInt(p.x * gridCellSizeInverted.x),
			y = Mathf.FloorToInt(p.y * gridCellSizeInverted.y),
			z = Mathf.FloorToInt(p.z * gridCellSizeInverted.z)
		};
	}

	private void Start()
	{
		foreach (Target target in targets)
		{
			target.mask0 = target.maskWide0.decoded;
			target.mask1 = target.maskWide1.decoded;
		}
		foreach (OcclusionPortalRegion occlusionPortalRegion in occlusionPortalRegions)
		{
			occlusionPortalRegion.mask0 = occlusionPortalRegion.maskWide0.decoded;
			occlusionPortalRegion.mask1 = occlusionPortalRegion.maskWide1.decoded;
		}
	}

	private void Update()
	{
		cameraPos = Player.instance.mainCamera.transform.position;
		visibleMask0 = 0uL;
		visibleMask1 = 0uL;
		foreach (OcclusionPortalRegion occlusionPortalRegion in occlusionPortalRegions)
		{
			if (occlusionPortalRegion.portal != null && occlusionPortalRegion.portal.open)
			{
				visibleMask0 |= occlusionPortalRegion.mask0;
				visibleMask1 |= occlusionPortalRegion.mask1;
			}
		}
		Coord coord = ToCoord(cameraPos) - grid.min;
		int num = coord.y * (grid.count.x * grid.count.z) + coord.x * grid.count.z + coord.z;
		if (num >= 0 && num < grid.cells.Count)
		{
			foreach (int visRegionIndex in grid.cells[num].visRegionIndexes)
			{
				ulong num2 = 0uL;
				ulong num3 = 0uL;
				if (visRegionIndex < 64)
				{
					num2 = (ulong)(1L << visRegionIndex);
				}
				else
				{
					num3 = (ulong)(1L << visRegionIndex - 64);
				}
				if (((visibleMask0 & num2) != num2 || (visibleMask1 & num3) != num3) && visRegions[visRegionIndex].Contains(cameraPos))
				{
					visibleMask0 |= num2;
					visibleMask1 |= num3;
				}
			}
		}
		foreach (Target target in targets)
		{
			bool flag = (target.mask0 & visibleMask0) != 0 || (target.mask1 & visibleMask1) != 0;
			if (target.fade != null)
			{
				target.fade.visible = flag;
			}
			else if (target.go.activeSelf != flag)
			{
				target.go.SetActive(flag);
			}
		}
	}

	public void DrawDebug()
	{
		DebugDrawer.World(delegate(DebugDrawer dd)
		{
			for (int i = 0; i < visRegions.Count; i++)
			{
				ulong num = 0uL;
				ulong num2 = 0uL;
				if (i < 64)
				{
					num = (ulong)(1L << i);
				}
				else
				{
					num2 = (ulong)(1L << i - 64);
				}
				if ((visibleMask0 & num) == num && (visibleMask0 & num2) == num2)
				{
					foreach (VisRegion.Box box in visRegions[i].boxes)
					{
						dd.DrawBounds(Color.red, box.localBounds, box.transform.localToWorldMatrix);
					}
				}
			}
		});
	}
}
