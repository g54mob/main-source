using UnityEngine;

public class AsciiCell3D : MonoBehaviour, IAsciiCell
{
	private Mesh mesh;

	private Color[] colors;

	private Vector4[] tangents;

	private Vector2[] uv;

	private int value;

	private Color _foregroundColor;

	private Color _backgroundColor;

	private int lastValue;

	private Color lastForegroundColor;

	private Color lastBackgroundColor;

	private int gridPosX;

	private int gridPosY;

	private ICellInteractable interactableObject;

	private char unicodeValue;

	public AsciiCell3D prefabReference { get; set; }

	public Color foregroundColor => _foregroundColor;

	public Color backgroundColor => _backgroundColor;

	private void Awake()
	{
		mesh = GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;
		colors = new Color[vertices.Length];
		uv = new Vector2[vertices.Length];
		tangents = new Vector4[vertices.Length];
	}

	public int GetValue()
	{
		return value;
	}

	public void SetValue(int asciiValue)
	{
		value = asciiValue;
	}

	public void SetValue(int asciiValue, Color foreground)
	{
		value = asciiValue;
		_foregroundColor = foreground;
	}

	public void SetValue(int asciiValue, Color foreground, Color background)
	{
		value = asciiValue;
		_foregroundColor = foreground;
		_backgroundColor = background;
	}

	public Color GetForeground()
	{
		return _foregroundColor;
	}

	public Color GetBackground()
	{
		return _backgroundColor;
	}

	public void SetBackground(Color color)
	{
		_backgroundColor = color;
	}

	public void SetForeground(Color color)
	{
		_foregroundColor = color;
	}

	public void SetGridPosition(int x, int y)
	{
		gridPosX = x;
		gridPosY = y;
	}

	public void SetInteractionLayer(ICellInteractable interactableObject, int priority = 0)
	{
		this.interactableObject = interactableObject;
	}

	public ICellInteractable GetInteractionLayer()
	{
		return interactableObject;
	}

	public int GetInteractionPriority()
	{
		return 0;
	}

	public void ClearInteractionLayer()
	{
		interactableObject = null;
	}

	public void SetUnicodeValue(char value)
	{
		unicodeValue = value;
	}

	public char GetUnicodeValue()
	{
		return unicodeValue;
	}

	public void Push()
	{
		bool flag = false;
		if (lastValue != value)
		{
			lastValue = value;
			flag = true;
			float a = (float)value / 256f;
			for (int i = 0; i < colors.Length; i++)
			{
				colors[i].a = a;
			}
		}
		if (lastForegroundColor != _foregroundColor)
		{
			lastForegroundColor = _foregroundColor;
			flag = true;
			for (int j = 0; j < colors.Length; j++)
			{
				colors[j].r = _foregroundColor.r;
				colors[j].g = _foregroundColor.g;
				colors[j].b = _foregroundColor.b;
			}
		}
		if (flag)
		{
			mesh.colors = colors;
		}
		if (lastBackgroundColor != _backgroundColor)
		{
			lastBackgroundColor = _backgroundColor;
			for (int k = 0; k < tangents.Length; k++)
			{
				tangents[k].w = _backgroundColor.r;
				uv[k].x = _backgroundColor.g;
				uv[k].y = _backgroundColor.b;
			}
			mesh.tangents = tangents;
			mesh.uv2 = uv;
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.Minus))
		{
			float num = (Input.GetKeyDown(KeyCode.Equals) ? 0.1f : (-0.1f));
			Color color = new Color(tangents[0].w, uv[0].x, uv[0].y);
			if (Input.GetKey(KeyCode.R))
			{
				color.r = Mathf.Clamp01(color.r + num);
			}
			if (Input.GetKey(KeyCode.G))
			{
				color.g = Mathf.Clamp01(color.g + num);
			}
			if (Input.GetKey(KeyCode.B))
			{
				color.b = Mathf.Clamp01(color.b + num);
			}
			for (int i = 0; i < tangents.Length; i++)
			{
				tangents[i].w = color.r;
				uv[i].x = color.g;
				uv[i].y = color.b;
			}
			mesh.tangents = tangents;
			mesh.uv2 = uv;
		}
	}
}
