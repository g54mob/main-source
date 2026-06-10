using UnityEngine;

[CreateAssetMenu(fileName = "New Quad Data", menuName = "Super Text Mesh/Quad Data", order = 1)]
public class STMQuadData : ScriptableObject
{
	public Texture texture;

	[Tooltip("If a quad is a silhouette, it won't use the color from its texture, just the alpha. If it's a silhouette, it can be effected by text color.")]
	public bool silhouette;

	public bool overrideFilterMode;

	public FilterMode filterMode = FilterMode.Bilinear;

	public int columns = 1;

	public int rows = 1;

	public int iconIndex;

	public float animDelay;

	public int[] frames;

	public Vector2 size = Vector2.one;

	public Vector3 offset = Vector3.zero;

	public float advance;

	public Vector3 TopLeftVert => new Vector3(0f, size.y, 0f) + offset;

	public Vector3 TopRightVert => new Vector3(size.x, size.y, 0f) + offset;

	public Vector3 BottomRightVert => new Vector3(size.x, 0f, 0f) + offset;

	public Vector3 BottomLeftVert => new Vector3(0f, 0f, 0f) + offset;

	public Vector3 Middle => new Vector3(size.x * 0.5f, size.y * 0.5f, 0f) + offset;

	private Vector2 uvSize => new Vector2(1f / (float)columns, 1f / (float)rows);

	public Vector2 pixelSize => new Vector2(uvSize.x * (float)texture.width, uvSize.y * (float)texture.height);

	public Vector2 UvTopLeft(float myTime, int myIconIndex)
	{
		return new Vector2(0f, uvSize.y) + UvOffset(myTime, myIconIndex);
	}

	public Vector2 UvTopRight(float myTime, int myIconIndex)
	{
		return uvSize + UvOffset(myTime, myIconIndex);
	}

	public Vector2 UvBottomRight(float myTime, int myIconIndex)
	{
		return new Vector2(uvSize.x, 0f) + UvOffset(myTime, myIconIndex);
	}

	public Vector2 UvBottomLeft(float myTime, int myIconIndex)
	{
		return UvOffset(myTime, myIconIndex);
	}

	public Vector2 UvMiddle(float myTime, int myIconIndex)
	{
		return uvSize * 0.5f + UvOffset(myTime, myIconIndex);
	}

	private Vector2 UvOffset(float myTime, int myIconIndex)
	{
		FixColumnCount();
		if (myIconIndex < 0 && (columns > 1 || rows > 1) && animDelay > 0f && (float)frames.Length > 0f)
		{
			myIconIndex = frames[(int)Mathf.Floor(myTime / animDelay) % frames.Length];
		}
		else
		{
			myIconIndex = ((myIconIndex > -1) ? myIconIndex : iconIndex);
			myIconIndex %= columns * rows;
		}
		int num = (int)Mathf.Floor((float)myIconIndex / (float)columns);
		return new Vector2((float)(myIconIndex % columns) / (float)columns, (float)num / (float)rows);
	}

	private void OnValidate()
	{
		FixColumnCount();
	}

	private void FixColumnCount()
	{
		if (columns < 1)
		{
			columns = 1;
		}
		if (rows < 1)
		{
			rows = 1;
		}
	}
}
