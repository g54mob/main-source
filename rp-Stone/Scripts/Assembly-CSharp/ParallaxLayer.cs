using UnityEngine;

[RequireComponent(typeof(TilingAsciiSprite))]
public class ParallaxLayer : MonoBehaviour
{
	public float parallaxScaleX = 1f;

	public float parallaxScaleY;

	[SerializeField]
	protected int parallaxX;

	[SerializeField]
	protected int parallaxY;

	private int prevParallaxX;

	private int prevParallaxY;

	private TilingAsciiSprite _sprite;

	private int initialScrollX;

	private int initialScrollY;

	public int ParallaxX
	{
		get
		{
			return parallaxX;
		}
		set
		{
			parallaxX = value;
			UpdateParallaxX();
		}
	}

	public int ParallaxY
	{
		get
		{
			return parallaxY;
		}
		set
		{
			parallaxY = value;
			UpdateParallaxY();
		}
	}

	public TilingAsciiSprite sprite => _sprite;

	protected virtual void UpdateParallaxX()
	{
		prevParallaxX = parallaxX;
		sprite.scrollX = initialScrollX + Mathf.FloorToInt((float)parallaxX * parallaxScaleX);
	}

	protected virtual void UpdateParallaxY()
	{
		prevParallaxY = parallaxY;
		sprite.scrollY = initialScrollY + Mathf.FloorToInt((float)parallaxY * parallaxScaleY);
	}

	protected virtual void Update()
	{
	}

	protected virtual void Awake()
	{
		_sprite = GetComponent<TilingAsciiSprite>();
		initialScrollX = _sprite.scrollX;
		initialScrollY = _sprite.scrollY;
	}
}
