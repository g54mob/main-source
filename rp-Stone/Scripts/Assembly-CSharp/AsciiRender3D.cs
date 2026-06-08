using System.Collections.Generic;
using UnityEngine;
using standardcombo;

public class AsciiRender3D : AsciiRenderer
{
	public int bestFitMinCloumns = 58;

	public int bestFitMaxColumns = 92;

	public int bestFitMinRows = 25;

	public int bestFitMaxRows = 27;

	public bool initializeWithRandom;

	public AsciiCell3D[] cellPrefabs;

	private List<List<AsciiCell3D>> cells = new List<List<AsciiCell3D>>();

	private AsciiCell3D selectedCellPrefab;

	private AsciiSizer.Size[] availableFontSizes;

	private int lastScreenW;

	private int lastScreenH;

	private Dictionary<AsciiCell3D, Stack<AsciiCell3D>> pool;

	private void Start()
	{
		InitPool();
		InitFontSizes();
		lastScreenW = Screen.width;
		lastScreenH = Screen.height;
		ScreenSizeChanged();
	}

	public void ScreenSizeChanged()
	{
		RecycleAllCells();
		SelectDimensions();
		BuildGrid();
		CenterTransform();
	}

	private void RecycleAllCells()
	{
		for (int i = 0; i < cells.Count; i++)
		{
			List<AsciiCell3D> list = cells[i];
			for (int j = 0; j < list.Count; j++)
			{
				Recycle(list[j]);
			}
			list.Clear();
		}
		cells.Clear();
		width = 0;
		height = 0;
	}

	private void SelectDimensions()
	{
		AsciiSizer.Result result = AsciiSizer.FindBestSizes(availableFontSizes, Screen.width, Screen.height, bestFitMinCloumns, bestFitMaxColumns, bestFitMinRows, bestFitMaxRows);
		if (result.warning)
		{
			Utils.LogWarning(result.message);
		}
		else
		{
			Utils.Log(result.message);
		}
		width = result.gridSize.width;
		height = result.gridSize.height;
		selectedCellPrefab = cellPrefabs[result.fontIndex];
	}

	private void BuildGrid()
	{
		float x = selectedCellPrefab.transform.localScale.x;
		float y = selectedCellPrefab.transform.localScale.y;
		for (int i = 0; i < width; i++)
		{
			List<AsciiCell3D> list = new List<AsciiCell3D>();
			cells.Add(list);
			for (int j = 0; j < height; j++)
			{
				AsciiCell3D pooledInstance = GetPooledInstance(selectedCellPrefab);
				list.Add(pooledInstance);
				pooledInstance.transform.parent = base.transform;
				Vector3 localPosition = pooledInstance.transform.localPosition;
				localPosition.x = ((float)i + 0.5f) * x;
				localPosition.y = (0f - ((float)j + 0.5f)) * y;
				pooledInstance.transform.localPosition = localPosition;
				if (initializeWithRandom)
				{
					pooledInstance.SetValue(Random.Range(0, 256), defaultForegroundColor, defaultBackgroundColor);
				}
				else
				{
					pooledInstance.SetValue(0, defaultForegroundColor, defaultBackgroundColor);
				}
			}
		}
	}

	private void CenterTransform()
	{
		Transform obj = base.transform;
		Vector3 position = obj.position;
		float x = selectedCellPrefab.transform.localScale.x;
		float y = selectedCellPrefab.transform.localScale.y;
		float f = x * (float)width * 0.5f;
		float f2 = y * (float)height * 0.5f;
		position.x = -Mathf.RoundToInt(f);
		position.y = Mathf.RoundToInt(f2);
		position.z = 0f;
		obj.position = position;
	}

	public override void SetCell(int x, int y, int value, bool skipSafety = false)
	{
		if (skipSafety || CheckLimits(x, y))
		{
			cells[x][y].SetValue(value);
		}
	}

	public override void SetCell(int x, int y, int value, Color foreground, bool skipSafety = false)
	{
		if (skipSafety || CheckLimits(x, y))
		{
			cells[x][y].SetValue(value, foreground);
		}
	}

	public override void SetCell(int x, int y, int value, Color foreground, Color background, bool skipSafety = false)
	{
		if (skipSafety || CheckLimits(x, y))
		{
			cells[x][y].SetValue(value, foreground, background);
		}
	}

	public override void SetCell(int x, int y, char unicode, bool skipSafety = false)
	{
		if (skipSafety || CheckLimits(x, y))
		{
			AsciiCell3D asciiCell3D = cells[x][y];
			asciiCell3D.SetValue(32);
			asciiCell3D.SetUnicodeValue(unicode);
		}
	}

	public override void SetCell(int x, int y, char unicode, Color foreground, bool skipSafety = false)
	{
		if (skipSafety || CheckLimits(x, y))
		{
			AsciiCell3D asciiCell3D = cells[x][y];
			asciiCell3D.SetValue(32);
			asciiCell3D.SetUnicodeValue(unicode);
			asciiCell3D.SetForeground(foreground);
		}
	}

	public override void SetCell(int x, int y, char unicode, Color foreground, Color background, bool skipSafety = false)
	{
		if (skipSafety || CheckLimits(x, y))
		{
			AsciiCell3D asciiCell3D = cells[x][y];
			asciiCell3D.SetValue(32);
			asciiCell3D.SetUnicodeValue(unicode);
			asciiCell3D.SetForeground(foreground);
			asciiCell3D.SetBackground(background);
		}
	}

	private bool CheckLimits(int x, int y)
	{
		if (x >= base.clip.left && x < width - base.clip.right && y >= base.clip.top && y < height - base.clip.bottom && x >= 0 && y >= 0 && x < cells.Count)
		{
			return y < cells[x].Count;
		}
		return false;
	}

	public override IAsciiCell GetCell(int x, int y, bool skipSafety = false)
	{
		if (skipSafety)
		{
			return cells[x][y];
		}
		if (x < 0 || x >= cells.Count || y < 0 || y >= cells[x].Count)
		{
			return null;
		}
		return cells[x][y];
	}

	public override void Clear()
	{
		for (int i = base.clip.left; i < width - base.clip.right; i++)
		{
			for (int j = base.clip.top; j < height - base.clip.bottom; j++)
			{
				cells[i][j].SetValue(32, defaultForegroundColor, defaultBackgroundColor);
				cells[i][j].ClearInteractionLayer();
			}
		}
	}

	public override void Push()
	{
		ApplyPostEffects();
		for (int i = base.clip.left; i < width - base.clip.right; i++)
		{
			for (int j = base.clip.top; j < height - base.clip.bottom; j++)
			{
				cells[i][j].Push();
			}
		}
	}

	public override GridValue GetColumnAt(float x)
	{
		float num = 2f * Camera.main.orthographicSize * (float)Screen.width / (float)Screen.height;
		float num2 = (float)Screen.width / num;
		x -= (float)(Screen.width / 2) + base.transform.localPosition.x * num2;
		float num3 = selectedCellPrefab.transform.localScale.x * num2;
		float num4 = x / num3;
		int num5 = (int)num4;
		num4 -= (float)num5;
		return new GridValue(num5, num4);
	}

	public override GridValue GetRowAt(float y)
	{
		float num = Camera.main.orthographicSize * 2f;
		float num2 = (float)Screen.height / num;
		y = (float)Screen.height - y;
		y -= (float)(Screen.height / 2) - base.transform.localPosition.y * num2;
		float num3 = selectedCellPrefab.transform.localScale.y * num2;
		float num4 = y / num3;
		int num5 = (int)num4;
		num4 -= (float)num5;
		return new GridValue(num5, num4);
	}

	private void Update()
	{
		if (lastScreenW != Screen.width || lastScreenH != Screen.height)
		{
			lastScreenW = Screen.width;
			lastScreenH = Screen.height;
			ScreenSizeChanged();
		}
	}

	private void InitFontSizes()
	{
		int num = cellPrefabs.Length;
		availableFontSizes = new AsciiSizer.Size[num];
		for (int i = 0; i < num; i++)
		{
			AsciiCell3D asciiCell3D = cellPrefabs[i];
			if ((bool)asciiCell3D)
			{
				Vector3 localScale = asciiCell3D.transform.localScale;
				availableFontSizes[i] = new AsciiSizer.Size(Mathf.RoundToInt(localScale.x), Mathf.RoundToInt(localScale.y));
			}
		}
	}

	private void InitPool()
	{
		pool = new Dictionary<AsciiCell3D, Stack<AsciiCell3D>>();
		for (int i = 0; i < cellPrefabs.Length; i++)
		{
			AsciiCell3D asciiCell3D = cellPrefabs[i];
			if (asciiCell3D != null && !pool.ContainsKey(asciiCell3D))
			{
				Stack<AsciiCell3D> value = new Stack<AsciiCell3D>();
				pool.Add(asciiCell3D, value);
			}
		}
	}

	private AsciiCell3D GetPooledInstance(AsciiCell3D prefab)
	{
		Stack<AsciiCell3D> stack = pool[prefab];
		AsciiCell3D asciiCell3D;
		if (stack.Count <= 0)
		{
			asciiCell3D = Object.Instantiate(prefab);
			asciiCell3D.prefabReference = prefab;
		}
		else
		{
			asciiCell3D = stack.Pop();
			asciiCell3D.gameObject.SetActive(value: true);
		}
		asciiCell3D.SetValue(32, defaultForegroundColor, defaultBackgroundColor);
		asciiCell3D.Push();
		return asciiCell3D;
	}

	private void Recycle(AsciiCell3D cell)
	{
		cell.gameObject.SetActive(value: false);
		AsciiCell3D prefabReference = cell.prefabReference;
		pool[prefabReference].Push(cell);
	}
}
