using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Graphics;

public class TileSprite : GameMonoBehaviour
{
	private SpriteRenderer _spriteRenderer;

	private SpriteScroller _spriteScroller;

	private float _xScrollSpeed;

	private float _yScrollSpeed;

	private float _xScrollOffset;

	private float _yScrollOffset;

	private float _tileWidth;

	private float _tileHeight;

	private float _tileScaleX;

	private float _tileScaleY;

	public SpriteRenderer SpriteRenderer
	{
		get
		{
			return _spriteRenderer;
		}
		set
		{
			_spriteRenderer = value;
		}
	}

	public SpriteScroller SpriteScroller
	{
		get
		{
			return _spriteScroller;
		}
		set
		{
			_spriteScroller = value;
		}
	}

	public float TileWidth
	{
		get
		{
			//IL_0014: Expected F4, but got O
			Vector2 size = _spriteRenderer.size;
			return (float)size;
		}
		set
		{
			_tileWidth = value;
			Vector2 size = _spriteRenderer.size;
			Vector2 size2 = default(Vector2);
			_spriteRenderer.size = size2;
		}
	}

	public float TileHeight
	{
		get
		{
			Vector2 size = _spriteRenderer.size;
			float result = default(float);
			return result;
		}
		set
		{
			_tileHeight = value;
			Vector2 size = _spriteRenderer.size;
			Vector2 size2 = default(Vector2);
			_spriteRenderer.size = size2;
		}
	}

	public unsafe float TileScaleX
	{
		get
		{
			return _tileScaleX;
		}
		set
		{
			_tileScaleX = value;
			if ((object)_spriteRenderer != null)
			{
				Vector2 size = _spriteRenderer.size;
				if ((object)_spriteRenderer != null)
				{
					Vector2 size2 = default(Vector2);
					_spriteRenderer.size = size2;
					if ((object)_spriteRenderer != null)
					{
						Transform transform = _spriteRenderer.transform;
						if ((object)transform != null)
						{
							bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							float ret;
							Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
							bool flag2 = (object)_spriteRenderer == null;
							Transform transform2 = _spriteRenderer.transform;
							bool flag3 = (object)transform2 == null;
							bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&ret));
							return;
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	public float TileScaleY
	{
		get
		{
			return _tileScaleY;
		}
		set
		{
			_tileScaleY = value;
			if ((object)_spriteRenderer != null)
			{
				Vector2 size = _spriteRenderer.size;
				if ((object)_spriteRenderer != null)
				{
					Vector2 size2 = default(Vector2);
					_spriteRenderer.size = size2;
					if ((object)_spriteRenderer != null)
					{
						Transform transform = _spriteRenderer.transform;
						if ((object)transform != null)
						{
							bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
							bool flag2 = (object)_spriteRenderer == null;
							Transform transform2 = _spriteRenderer.transform;
							bool flag3 = (object)transform2 == null;
							bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref ret);
							return;
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	public void SetLocalY(float yPos)
	{
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	public void SetFlipY(bool flip)
	{
		_spriteRenderer.flipY = flip;
	}

	public void SetFrame(string frameName, string textureName)
	{
		Sprite sprite = SpriteManager.GetSprite(frameName, textureName);
		_spriteRenderer.sprite = sprite;
		_spriteScroller.SpriteUpdated();
	}

	public void SetScrollOffsetX(float pos, bool cumulative = true)
	{
		float num = default(float);
		if (cumulative)
		{
			num += _xScrollOffset;
		}
		_xScrollOffset = num;
		_spriteScroller.SetScrollOffsetX(num);
	}

	public void SetScrollOffsetY(float pos, bool cumulative = true)
	{
		float num = default(float);
		if (cumulative)
		{
			num += _yScrollOffset;
		}
		_yScrollOffset = num;
		_spriteScroller.SetScrollOffsetY(num);
	}

	public void SetScrollSpeedX(float speed)
	{
		_xScrollSpeed = speed;
		_spriteScroller.SetScrollSpeedX(speed);
	}

	public void SetScrollSpeedY(float speed)
	{
		_yScrollSpeed = speed;
		_spriteScroller.SetScrollSpeedY(speed);
	}

	public void SetVisible(bool visible)
	{
		_spriteRenderer.enabled = visible;
	}

	public void destroy()
	{
		GameObject obj = base.gameObject;
		UnityEngine.Object.Destroy(obj, 0f);
	}

	public TileSprite SetDepth(int depth)
	{
		if ((object)_spriteRenderer != null)
		{
			_spriteRenderer.sortingOrder = depth;
			return this;
		}
		return (TileSprite)(object)new NullReferenceException();
	}

	public TileSprite SetTileScale(float xScale, float? yScale = null)
	{
		//IL_000e: Expected O, but got I4
		float? num;
		float tileScaleY;
		if ((object)yScale == null)
		{
			num = (float?)(object)1;
			tileScaleY = xScale;
		}
		else
		{
			num = yScale;
			float num2 = default(float);
			tileScaleY = num2;
		}
		TileScaleX = xScale;
		if ((object)num != null)
		{
			TileScaleY = tileScaleY;
			return this;
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		TileSprite result = default(TileSprite);
		return result;
	}

	public TileSprite SetName(string newName)
	{
		GameObject gameObject = base.gameObject;
		if ((object)gameObject != null)
		{
			((UnityEngine.Object)gameObject).SetName(newName);
			return this;
		}
		return (TileSprite)(object)new NullReferenceException();
	}

	public TileSprite SetMaterial(MaterialType materialType)
	{
		Material material = MaterialManager.GetMaterial(materialType);
		if ((object)_spriteRenderer != null)
		{
			((Renderer)_spriteRenderer).SetMaterial(material);
			return this;
		}
		return (TileSprite)(object)new NullReferenceException();
	}

	public TileSprite()
	{
		//IL_004c: Expected I, but got O
		_tileWidth = 1f;
		_tileHeight = 1f;
		_tileScaleX = 1f;
		_tileScaleY = 1f;
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
