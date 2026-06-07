using UnityEngine;

public class TurnableSpriteRenderer : TurnableRenderer
{
	public TurnableSprite turnableSprite;

	public bool disableSpriteRotation;

	private SpriteShadow shadow;

	private SpriteRenderer spriteRenderer;

	private bool _init;

	public override bool enabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public override int sortingLayerID
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public override string sortingLayerName
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public override int sortingOrder
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public override SpriteMaskInteraction maskInteraction
	{
		get
		{
			return default(SpriteMaskInteraction);
		}
		set
		{
		}
	}

	public Material sharedMaterial
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	private void Init()
	{
	}

	public override void SetRotation(int rotationI)
	{
	}

	public void Refresh()
	{
	}

	public static implicit operator SpriteRenderer(TurnableSpriteRenderer tsr)
	{
		return null;
	}

	private void LateUpdate()
	{
	}

	public void SetColor(int colorI)
	{
	}
}
