using System.Collections.Generic;
using UnityEngine;
using standardcombo;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class AsciiRenderProcedural : MonoBehaviour
{
	public struct Clip
	{
		public int top;

		public int bottom;

		public int left;

		public int right;
	}

	public struct GridValue
	{
		public int value;

		public float remainder;

		public GridValue(int v, float r)
		{
			value = v;
			remainder = r;
		}
	}

	public int width = 46;

	public int height = 25;

	public AsciiSizer.Size fontSize;

	private Stack<Clip> clipStack = new Stack<Clip>();

	public Color defaultForegroundColor = Color.white;

	public Color defaultBackgroundColor = Color.black;

	private List<IPostAsciiRendererEffect> postEffects = new List<IPostAsciiRendererEffect>();

	public int bestFitMinCloumns = 58;

	public int bestFitMaxColumns = 92;

	public int bestFitMinRows = 25;

	public int bestFitMaxRows = 27;

	public AsciiCellProcedural[] cellPrefabs;

	public AsciiCellProcedural[] antiAliasCells;

	private List<List<AsciiCellProcedural>> cells = new List<List<AsciiCellProcedural>>();

	private AsciiCellProcedural selectedCellPrefab;

	private AsciiSizer.Size[] availableFontSizes;

	private Mesh mesh;

	private Vector3[] vertices;

	private Vector3[] normals;

	private Vector2[] UVs;

	private Color[] fgColors;

	private Vector4[] bgColors;

	private Vector3[] cellOrigins;

	private int lastWidth;

	private int lastHeight;

	private float lastTimeSizeChanged = -999f;

	private int lastScreenW;

	private int lastScreenH;

	private Stack<AsciiCellProcedural> pool;

	public Clip clip { get; private set; }

	public void InvertDefaultColors()
	{
		Color color = defaultForegroundColor;
		defaultForegroundColor = defaultBackgroundColor;
		defaultBackgroundColor = color;
	}

	public bool IsClipped(int x, int y)
	{
		if (x >= clip.left && x < width - clip.right && y >= clip.top)
		{
			return y >= height - clip.bottom;
		}
		return true;
	}

	public void PushClip(Clip c, bool computeIntersection = true)
	{
		if (computeIntersection)
		{
			c.top = Mathf.Max(c.top, clip.top);
			c.bottom = Mathf.Max(c.bottom, clip.bottom);
			c.left = Mathf.Max(c.left, clip.left);
			c.right = Mathf.Max(c.right, clip.right);
		}
		clipStack.Push(c);
		clip = c;
	}

	public void PopClip()
	{
		if (clipStack.Count > 0)
		{
			clipStack.Pop();
		}
		if (clipStack.Count > 0)
		{
			clip = clipStack.Peek();
		}
		else
		{
			clip = default(Clip);
		}
	}

	public void ResetClip()
	{
		while (clipStack.Count > 0)
		{
			clipStack.Pop();
		}
		clip = default(Clip);
	}

	public void ApplyPostEffects()
	{
		for (int i = 0; i < postEffects.Count; i++)
		{
			postEffects[i].ApplyPostEffect(this);
		}
	}

	public void AddPostEffect(IPostAsciiRendererEffect effect)
	{
		if (!postEffects.Contains(effect))
		{
			postEffects.Add(effect);
		}
	}

	public void RemovePostEffect(IPostAsciiRendererEffect effect)
	{
		postEffects.Remove(effect);
	}

	public List<List<AsciiCellProcedural>> GetAllCells()
	{
		return cells;
	}

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
		SelectDimensions();
		if (lastWidth != width || lastHeight != height)
		{
			lastWidth = width;
			lastHeight = height;
			RecycleAllCells();
			BuildGrid();
		}
		CenterTransform();
	}

	private void RecycleAllCells()
	{
		for (int i = 0; i < cells.Count; i++)
		{
			List<AsciiCellProcedural> list = cells[i];
			for (int j = 0; j < list.Count; j++)
			{
				Recycle(list[j]);
			}
			list.Clear();
		}
		cells.Clear();
	}

	private void SelectDimensions()
	{
		AsciiSizer.Result result = AsciiSizer.FindBestSizes(availableFontSizes, Screen.width, Screen.height, bestFitMinCloumns, bestFitMaxColumns, bestFitMinRows, bestFitMaxRows);
		float num = 1f;
		if (AdditionalSettings.isAntiAlias && result.warning && result.fontIndex < availableFontSizes.Length - 1)
		{
			num = cellPrefabs[result.fontIndex + 1].scaleY * (float)bestFitMaxRows / (float)Screen.height;
			int screenWidth = Mathf.FloorToInt((float)Screen.width * num);
			int screenHeight = Mathf.FloorToInt((float)Screen.height * num);
			result = AsciiSizer.FindBestSizes(availableFontSizes, screenWidth, screenHeight, bestFitMinCloumns, bestFitMaxColumns, bestFitMinRows, bestFitMaxRows);
			selectedCellPrefab = antiAliasCells[result.fontIndex];
		}
		else
		{
			selectedCellPrefab = cellPrefabs[result.fontIndex];
		}
		if (result.warning)
		{
			Utils.LogWarning(result.message);
		}
		else
		{
			Utils.LogIfEditor(result.message);
		}
		width = result.gridSize.width;
		height = result.gridSize.height;
		fontSize = result.fontSize;
		GetComponent<MeshRenderer>().material = selectedCellPrefab.material;
		Vector3 localScale = base.transform.localScale;
		localScale.x = selectedCellPrefab.scaleX;
		localScale.y = selectedCellPrefab.scaleY;
		base.transform.localScale = localScale / num;
	}

	private void BuildGrid()
	{
		for (int i = 0; i < width; i++)
		{
			List<AsciiCellProcedural> list = new List<AsciiCellProcedural>();
			cells.Add(list);
			for (int j = 0; j < height; j++)
			{
				AsciiCellProcedural pooledInstance = GetPooledInstance(selectedCellPrefab);
				list.Add(pooledInstance);
				pooledInstance.SetValue(0, defaultForegroundColor, defaultBackgroundColor);
				pooledInstance.SetGridPosition(i, j);
			}
		}
		BuildMesh();
	}

	private void CenterTransform()
	{
		Transform obj = base.transform;
		Vector3 position = obj.position;
		float x = obj.localScale.x;
		float y = obj.localScale.y;
		float f = x * (float)width * 0.5f;
		float f2 = y * (float)height * 0.5f;
		position.x = -Mathf.RoundToInt(f);
		position.y = Mathf.RoundToInt(f2);
		position.z = 0f;
		obj.position = position;
	}

	public void SetCell(int x, int y, int value, bool skipSafety = false)
	{
		if (skipSafety || CheckLimits(x, y))
		{
			AsciiCellProcedural asciiCellProcedural = cells[x][y];
			asciiCellProcedural.Value = value;
			asciiCellProcedural.unicodeValue = '\0';
		}
	}

	public void SetCell(int x, int y, int value, Color foreground, bool skipSafety = false)
	{
		if (skipSafety || CheckLimits(x, y))
		{
			AsciiCellProcedural asciiCellProcedural = cells[x][y];
			asciiCellProcedural.Value = value;
			asciiCellProcedural.foregroundColor = foreground;
			asciiCellProcedural.unicodeValue = '\0';
		}
	}

	public void SetCell(int x, int y, int value, Color foreground, Color background, bool skipSafety = false)
	{
		if (skipSafety || CheckLimits(x, y))
		{
			AsciiCellProcedural asciiCellProcedural = cells[x][y];
			asciiCellProcedural.Value = value;
			asciiCellProcedural.foregroundColor = foreground;
			asciiCellProcedural.backgroundColor = background;
			asciiCellProcedural.unicodeValue = '\0';
		}
	}

	public void SetCell(int x, int y, char unicode, bool skipSafety = false)
	{
		if (skipSafety || CheckLimits(x, y))
		{
			AsciiCellProcedural asciiCellProcedural = cells[x][y];
			asciiCellProcedural.Value = 32;
			asciiCellProcedural.unicodeValue = unicode;
		}
	}

	public void SetCell(int x, int y, char unicode, Color foreground, bool skipSafety = false)
	{
		if (skipSafety || CheckLimits(x, y))
		{
			AsciiCellProcedural asciiCellProcedural = cells[x][y];
			asciiCellProcedural.Value = 32;
			asciiCellProcedural.unicodeValue = unicode;
			asciiCellProcedural.foregroundColor = foreground;
		}
	}

	public void SetCell(int x, int y, char unicode, Color foreground, Color background, bool skipSafety = false)
	{
		if (skipSafety || CheckLimits(x, y))
		{
			AsciiCellProcedural asciiCellProcedural = cells[x][y];
			asciiCellProcedural.Value = 32;
			asciiCellProcedural.unicodeValue = unicode;
			asciiCellProcedural.foregroundColor = foreground;
			asciiCellProcedural.backgroundColor = background;
		}
	}

	private bool CheckLimits(int x, int y)
	{
		if (x >= clip.left && x < width - clip.right && y >= clip.top && y < height - clip.bottom && x >= 0 && y >= 0 && x < cells.Count)
		{
			return y < cells[x].Count;
		}
		return false;
	}

	public AsciiCellProcedural GetCell(int x, int y, bool skipSafety = false)
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

	public void Clear()
	{
		int left = clip.left;
		int num = width - clip.right;
		int top = clip.top;
		int num2 = height - clip.bottom;
		for (int i = left; i < num; i++)
		{
			List<AsciiCellProcedural> list = cells[i];
			for (int j = top; j < num2; j++)
			{
				AsciiCellProcedural asciiCellProcedural = list[j];
				asciiCellProcedural.Value = 32;
				asciiCellProcedural.foregroundColor = defaultForegroundColor;
				asciiCellProcedural.backgroundColor = defaultBackgroundColor;
				asciiCellProcedural.unicodeValue = '\0';
				asciiCellProcedural.ClearInteractionLayer();
			}
		}
	}

	public void Push()
	{
		ApplyPostEffects();
		int num = width;
		int num2 = Mathf.Max(0, clip.left);
		int num3 = Mathf.Min(cells.Count, width - clip.right);
		int num4 = Mathf.Max(0, clip.top);
		int num5 = Mathf.Min(cells[0].Count, height - clip.bottom);
		Vector3 vector = default(Vector3);
		Vector4 vector2 = default(Vector4);
		for (int i = num4; i < num5; i++)
		{
			int num6 = i * 4 * num;
			for (int j = num2; j < num3; j++)
			{
				int num7 = j * 4 + num6;
				AsciiCellProcedural asciiCellProcedural = cells[j][i];
				int value = asciiCellProcedural.GetValue();
				int num8 = value % 16;
				int num9 = 15 - value / 16;
				float num10 = (float)num8 / 16f;
				float num11 = (float)num9 / 16f;
				float num12 = (float)(num8 + 1) / 16f;
				float num13 = (float)(num9 + 1) / 16f;
				UVs[num7].x = num10;
				UVs[num7].y = num13;
				UVs[++num7].x = num12;
				UVs[num7].y = num13;
				UVs[++num7].x = num10;
				UVs[num7].y = num11;
				UVs[++num7].x = num12;
				UVs[num7].y = num11;
				num7 -= 3;
				vector.x = (num10 + num12) / 2f;
				vector.y = (num11 + num13) / 2f;
				vector.z = 0f;
				Color foreground = asciiCellProcedural.GetForeground();
				Color background = asciiCellProcedural.GetBackground();
				vector2.x = background.r;
				vector2.y = background.g;
				vector2.z = background.b;
				vector2.w = background.a;
				for (int k = 0; k < 4; k++)
				{
					fgColors[num7 + k] = foreground;
					bgColors[num7 + k] = vector2;
					cellOrigins[num7 + k] = vector;
				}
			}
		}
		mesh.uv = UVs;
		mesh.colors = fgColors;
		mesh.tangents = bgColors;
		mesh.normals = cellOrigins;
	}

	public GridValue GetColumnAt(float x)
	{
		float num = 2f * Camera.main.orthographicSize * (float)Screen.width / (float)Screen.height;
		float num2 = (float)Screen.width / num;
		x -= (float)(Screen.width / 2) + base.transform.localPosition.x * num2;
		float num3 = base.transform.localScale.x * num2;
		float num4 = x / num3;
		int num5 = (int)num4;
		num4 -= (float)num5;
		return new GridValue(num5, num4);
	}

	public GridValue GetRowAt(float y)
	{
		float num = Camera.main.orthographicSize * 2f;
		float num2 = (float)Screen.height / num;
		y = (float)Screen.height - y;
		y -= (float)(Screen.height / 2) - base.transform.localPosition.y * num2;
		float num3 = base.transform.localScale.y * num2;
		float num4 = y / num3;
		int num5 = (int)num4;
		num4 -= (float)num5;
		return new GridValue(num5, num4);
	}

	private void Update()
	{
		if ((lastScreenW != Screen.width || lastScreenH != Screen.height) && lastTimeSizeChanged < Time.realtimeSinceStartup - 0.2f)
		{
			lastTimeSizeChanged = Time.realtimeSinceStartup;
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
			AsciiCellProcedural asciiCellProcedural = cellPrefabs[i];
			if (asciiCellProcedural != null)
			{
				availableFontSizes[i] = new AsciiSizer.Size(Mathf.RoundToInt(asciiCellProcedural.scaleX), Mathf.RoundToInt(asciiCellProcedural.scaleY));
			}
		}
	}

	private void BuildMesh()
	{
		MeshFilter component = GetComponent<MeshFilter>();
		mesh = new Mesh();
		mesh.name = "Procedural Ascii Mesh";
		component.mesh = mesh;
		int num = height;
		int num2 = width;
		int num3 = num * num2 * 4;
		if (vertices == null || num3 > vertices.Length)
		{
			vertices = new Vector3[num3];
			normals = new Vector3[num3];
			for (int i = 0; i < num3; i++)
			{
				normals[i] = Vector3.back;
			}
			UVs = new Vector2[num3];
			fgColors = new Color[num3];
			bgColors = new Vector4[num3];
			cellOrigins = new Vector3[num3];
		}
		for (int j = 0; j < num; j++)
		{
			int num4 = j * 4 * num2;
			for (int k = 0; k < num2; k++)
			{
				int num5 = k * 4 + num4;
				vertices[num5] = new Vector3(k, -j, 0f);
				vertices[num5 + 1] = new Vector3(k + 1, -j, 0f);
				vertices[num5 + 2] = new Vector3(k, -j - 1, 0f);
				vertices[num5 + 3] = new Vector3(k + 1, -j - 1, 0f);
			}
		}
		mesh.vertices = vertices;
		mesh.normals = normals;
		int[] array = new int[num * num2 * 6];
		int num6 = num2 * 6;
		for (int l = 0; l < num; l++)
		{
			int num7 = l * 4 * num2;
			int num8 = l * num6;
			for (int m = 0; m < num2; m++)
			{
				int num9 = m * 4 + num7;
				int num10 = m * 6 + num8;
				array[num10] = num9;
				array[num10 + 1] = num9 + 1;
				array[num10 + 2] = num9 + 2;
				array[num10 + 3] = num9 + 3;
				array[num10 + 4] = num9 + 2;
				array[num10 + 5] = num9 + 1;
			}
		}
		mesh.triangles = array;
		Clear();
		Push();
	}

	private void InitPool()
	{
		pool = new Stack<AsciiCellProcedural>();
	}

	private AsciiCellProcedural GetPooledInstance(AsciiCellProcedural prefab)
	{
		AsciiCellProcedural asciiCellProcedural = ((pool.Count > 0) ? pool.Pop() : new AsciiCellProcedural());
		asciiCellProcedural.material = prefab.material;
		asciiCellProcedural.scaleX = prefab.scaleX;
		asciiCellProcedural.scaleY = prefab.scaleY;
		asciiCellProcedural.SetValue(32, defaultForegroundColor, defaultBackgroundColor);
		return asciiCellProcedural;
	}

	private void Recycle(AsciiCellProcedural cell)
	{
		pool.Push(cell);
	}
}
