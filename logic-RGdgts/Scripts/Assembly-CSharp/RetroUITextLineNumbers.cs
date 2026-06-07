using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RetroUITextLineNumbers : MaskableGraphic, ISerializationCallbackReceiver
{
	public class FgColorAttribute
	{
		public Color color;

		public FgColorAttribute(Color color)
		{
		}
	}

	public class BgColorAttribute
	{
		public Color color;

		public bool textOnly;

		public BgColorAttribute(Color color, bool textOnly)
		{
		}
	}

	public class UnderlineAttribute
	{
	}

	public RetroUIText uiText;

	[SerializeField]
	private Color _color;

	[SerializeField]
	private RetroUIText.HorizontalAlignment _horizontalAlignment;

	[SerializeField]
	private int _leftMargin;

	[SerializeField]
	private int _rightMargin;

	private static Material uiMaterial;

	[SerializeField]
	private TMP_FontAsset _font;

	private TMP_Character sampleChar;

	private int charWidth;

	private int charHeight;

	private int horizontalAdvance;

	[NonSerialized]
	public bool inspectorApplyModifiedProperties;

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

	public RetroUIText.HorizontalAlignment horizontalAlignment
	{
		get
		{
			return default(RetroUIText.HorizontalAlignment);
		}
		set
		{
		}
	}

	public int leftMargin
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int rightMargin
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

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

	public TMP_FontAsset font
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public override Texture mainTexture => null;

	protected override void OnRectTransformDimensionsChange()
	{
	}

	private void RefreshFontMetrics()
	{
	}

	protected override void Start()
	{
	}

	protected override void OnDestroy()
	{
	}

	private void AddQuad(VertexHelper vh, Vector2 corner1, Vector2 corner2, Vector2 uvCorner1, Vector2 uvCorner2, Color color)
	{
	}

	private float GetHorizontalAlignOffset(string text)
	{
		return 0f;
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
	}

	public void OnBeforeSerialize()
	{
	}

	public void OnAfterDeserialize()
	{
	}

	public RetroUIText.TextData.VisibleLine OverlapPoint(Vector2 point)
	{
		return null;
	}

	public void Test1()
	{
	}

	public void Test2()
	{
	}

	public void Test3()
	{
	}
}
