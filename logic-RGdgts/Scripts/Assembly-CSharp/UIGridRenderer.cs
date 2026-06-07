using UnityEngine;
using UnityEngine.UI;

public class UIGridRenderer : MaskableGraphic
{
	public enum VerticalAlignment
	{
		Top = 0,
		Bottom = 1
	}

	private Material uiMaterial;

	[SerializeField]
	private Color _color;

	[SerializeField]
	private int _width;

	[SerializeField]
	private int _height;

	private Vector2Int _offset;

	[SerializeField]
	private VerticalAlignment _verticalAlignment;

	public override Material material
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public new Color color
	{
		get
		{
			return default(Color);
		}
		set
		{
		}
	}

	public int width
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int height
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public Vector2Int offset
	{
		get
		{
			return default(Vector2Int);
		}
		set
		{
		}
	}

	public VerticalAlignment verticalAlignment
	{
		get
		{
			return default(VerticalAlignment);
		}
		set
		{
		}
	}

	public override Texture mainTexture => null;

	private void SetUpMaterial(Material material)
	{
	}

	protected override void OnRectTransformDimensionsChange()
	{
	}

	private void AddQuad(VertexHelper vh, Vector2 corner1, Vector2 corner2, Vector2 uvCorner1, Vector2 uvCorner2, Color color)
	{
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
	}

	protected override void OnDestroy()
	{
	}
}
