using UnityEngine;

public class MotherboardLayerRenderer : MonoBehaviour
{
	public enum Channel
	{
		ColorMap = -1,
		NormalMap = 0,
		AmbientOcclusion = 1
	}

	public Motherboard.Layer layer;

	private MotherboardShape shape;

	private Sprite _sprite;

	private SpriteRenderer spriteRenderer;

	private Texture2D colorMapTexture;

	private Texture2D normalMapTexture;

	private Texture2D ambientOcclusionTexture;

	public MotherboardSection testSection;

	public MotherboardSection testCornerSection;

	private static Vector2[] uvsBuffer;

	public Material material { get; private set; }

	public Sprite sprite => null;

	public bool visible
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public string sortingLayerName
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public int sortingLayerID
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int sortingOrder
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public SpriteMaskInteraction maskInteraction
	{
		get
		{
			return default(SpriteMaskInteraction);
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	public void Init()
	{
	}

	public void Refresh()
	{
	}

	public void Refresh(MotherboardShape shape)
	{
	}

	public static Texture2D RenderShape(MotherboardShape shape, Motherboard.Layer layer, Channel channel, Texture2D texture = null)
	{
		return null;
	}

	private static void RenderSprite(Sprite sprite, Vector2 position, int rotation, bool flipX, Channel channel)
	{
	}

	private void OnDestroy()
	{
	}
}
