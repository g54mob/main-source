using UnityEngine;

public class AsciiSpriteRow : AsciiObject
{
	private AsciiSprite _sprite;

	public AsciiSprite sprite
	{
		get
		{
			return _sprite;
		}
		set
		{
			_sprite = value;
			if (_sprite != null)
			{
				_sprite.Load();
				Width = _sprite.width;
				Height = _sprite.height;
			}
		}
	}

	public void Clear()
	{
		sprite = null;
	}

	public override void UpdateTic()
	{
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (sprite != null)
		{
			sprite.Draw(r, offsetX, offsetY);
		}
	}

	private void Awake()
	{
		sprite = GetComponentInChildren<AsciiSprite>();
	}

	private void OnDestroy()
	{
		if (sprite != null && sprite.gameObject != null && base.gameObject != sprite.gameObject)
		{
			Object.Destroy(sprite.gameObject);
		}
	}
}
