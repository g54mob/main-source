using System.Collections.Generic;
using NBT.Tags;
using UnityEngine;

public class CollectorZone : MonoBehaviour
{
	public struct ColonizedCell
	{
		public int cx;

		public int cy;

		public ColonizedCell(int cx, int cy)
		{
			this.cx = 0;
			this.cy = 0;
		}
	}

	public UnitManager owner;

	private Mesh mesh;

	private MeshFilter meshFilter;

	private const float SQUARE_SIZE = 0.501f;

	public static int RANGE;

	private int currentRadius;

	private int currentLoc;

	private List<ColonizedCell> colonizedCells;

	private HashSet<int> colonizedCellSet;

	private bool _deploy;

	private int currentDelay;

	private int deployCellX;

	private int deployCellY;

	private bool _offline;

	private Color32 defaultColor;

	private Color32 lowEfficiencyColor;

	private Color32 ownershipColor;

	private bool hilightOwnership;

	private bool lastColorWasOwnership;

	private float lastEfficiency;

	public bool deploy
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool offline
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	private void LateUpdate()
	{
	}

	public int GetColonizedCellCount()
	{
		return 0;
	}

	public void HighlightOwnership()
	{
	}

	private bool ColonizeCellWorldCoordinate(int wx, int wy)
	{
		return false;
	}

	private bool ColonizeIndividualCell(int cx, int cy)
	{
		return false;
	}

	public void DecolonizeCellWorldCoordinate(int wx, int wy)
	{
	}

	public void GameUpdate()
	{
	}

	public void Refresh()
	{
	}

	public void RefreshLite()
	{
	}

	public bool IsCellColonized(int wx, int wy)
	{
		return false;
	}

	public void Clear()
	{
	}

	private void ColonizeCellImmediate(int cx, int cy)
	{
	}

	private bool GetNextCell(out int cx, out int cy, int maxRad)
	{
		cx = default(int);
		cy = default(int);
		return false;
	}

	public static bool IsLegalTerrain(int cx, int cy, int baseX, int baseY, int RANGE)
	{
		return false;
	}

	private void UpdateMesh()
	{
	}

	private void RefreshColors(bool force)
	{
	}

	public void OnDestroy()
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
