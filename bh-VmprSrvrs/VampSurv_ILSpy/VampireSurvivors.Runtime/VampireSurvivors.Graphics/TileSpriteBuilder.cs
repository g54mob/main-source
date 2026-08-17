using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;

namespace VampireSurvivors.Graphics;

public class TileSpriteBuilder
{
	private Vector2 _pos;

	private Vector3 _scale;

	private string _textureName;

	private string _spriteName;

	private Vector2? _spritePivot;

	private float _depth;

	private float _depthMul;

	private float _alpha;

	private Transform _parent;

	private string _name;

	private float _tileWidth;

	private float _tileHeight;

	private BlendMode _blendMode;

	public TileSpriteBuilder SetPosition(float x, float y)
	{
		//IL_000a: Expected O, but got F4
		_pos = (Vector2)x;
		return this;
	}

	public TileSpriteBuilder SetScale(float scale)
	{
		//IL_0013: Expected I, but got O
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v2 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rdx_v1 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		float num3 = 0f * scale;
		Vector3 scale2 = default(Vector3);
		_scale = scale2;
		return this;
	}

	public TileSpriteBuilder SetScale(float xScale, float yScale)
	{
		Vector3 scale = default(Vector3);
		_scale = scale;
		_ = 1f;
		return this;
	}

	public TileSpriteBuilder SetSpriteInfo(string textureName, string spriteName)
	{
		_textureName = textureName;
		_spriteName = spriteName;
		return this;
	}

	public TileSpriteBuilder SetSpritePivot(Vector2? pivot)
	{
		_spritePivot = pivot;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [pivot @ rdx (System.Nullable`1<UnityEngine.Vector2>)+8]");
		_ = 0;
		return this;
	}

	public TileSpriteBuilder SetDepth(float depth, float depthMul = 1f)
	{
		_depth = depth;
		_depthMul = depthMul;
		return this;
	}

	public TileSpriteBuilder SetAlpha(float alpha)
	{
		_alpha = alpha;
		return this;
	}

	public TileSpriteBuilder SetParent(Transform parent)
	{
		_parent = parent;
		return this;
	}

	public TileSpriteBuilder SetName(string name)
	{
		_name = name;
		return this;
	}

	public TileSpriteBuilder SetTileSize(float width, float height)
	{
		_tileWidth = width;
		_tileHeight = height;
		return this;
	}

	public TileSpriteBuilder SetBlendMode(BlendMode blendMode)
	{
		_blendMode = blendMode;
		return this;
	}

	public TileSprite Build()
	{
		//IL_00ed->IL0107: Incompatible stack heights: 0 vs 1
		string name = _name;
		string name2;
		if (_name != null)
		{
			bool flag = name._stringLength > 0;
			name2 = _name;
			if (flag)
			{
				goto IL_0188;
			}
		}
		name2 = "TileSprite";
		goto IL_0188;
		IL_0158:
		throw new NullReferenceException();
		IL_0188:
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, name2);
		if ((object)gameObject != null)
		{
			Transform transform = gameObject.transform;
			Transform parent = _parent;
			if ((object)_parent != null && ((UnityEngine.Object)parent).m_CachedPtr != (IntPtr)0)
			{
				if ((object)transform == null)
				{
					goto IL_0158;
				}
				transform.SetParent(_parent, worldPositionStays: false);
			}
			else
			{
				bool flag2 = (object)transform == null;
			}
			bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value2 = default(Vector3);
			Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
			TileSprite tileSprite = gameObject.AddComponent<TileSprite>();
			GenerateSpriteRenderer(tileSprite);
			bool flag5 = (object)tileSprite == null;
			GameObject gameObject2 = tileSprite.gameObject;
			bool flag6 = (object)gameObject2 == null;
			SpriteScroller spriteScroller = gameObject2.AddComponent<SpriteScroller>();
			return tileSprite;
		}
		goto IL_0158;
	}

	private void GenerateSpriteRenderer(TileSprite tileSprite)
	{
		//IL_0258: Expected O, but got I4
		//IL_02ec: Expected O, but got I4
		//IL_029e: Expected O, but got I4
		//IL_017b: Expected O, but got I4
		//IL_035a: Expected O, but got I4
		GameObject gameObject = tileSprite.gameObject;
		SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
		string spriteName = _spriteName;
		Sprite sprite;
		bool flag = default(bool);
		Vector2 vector = default(Vector2);
		if (_spriteName != null && spriteName._stringLength > 0)
		{
			string textureName = _textureName;
			if ((object)_spritePivot == null)
			{
				if (_textureName != null && textureName._stringLength > 0)
				{
					sprite = SpriteManager.GetSprite(_spriteName, _textureName);
					flag = false;
				}
				else
				{
					sprite = SpriteManager.GetUnpackedSprite(_spriteName);
					if ((object)sprite == null)
					{
						sprite = SpriteManager.GetSprite(_spriteName);
					}
				}
				goto IL_0166;
			}
			if (_textureName != null && textureName._stringLength > 0)
			{
				if ((object)_spritePivot != null)
				{
					sprite = SpriteManager.GetSprite(_spriteName, vector, _textureName);
					flag = false;
					goto IL_0166;
				}
			}
			else if ((object)_spritePivot != null)
			{
				sprite = SpriteManager.GetUnpackedSprite(_spriteName, vector);
				goto IL_0166;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
			return;
		}
		string text = (string)flag;
		goto IL_025d;
		IL_02f6:
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(spriteRenderer, _alpha);
		float num = _depthMul * _depth;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		int sortingOrder = default(int);
		spriteRenderer.sortingOrder = sortingOrder;
		SpriteRenderer spriteRenderer3 = RenderingExtensions.SetTileMode(spriteRenderer);
		object obj = _blendMode - 1;
		bool flag2 = obj == null;
		MaterialType type = (MaterialType)((flag2 ? 1 : 0) + 10);
		Material material = MaterialManager.GetMaterial(type);
		((Renderer)spriteRenderer).SetMaterial(material);
		tileSprite._spriteRenderer = spriteRenderer;
		tileSprite._tileWidth = _tileWidth;
		Vector2 size = tileSprite._spriteRenderer.size;
		tileSprite._spriteRenderer.size = vector;
		tileSprite._tileHeight = _tileHeight;
		Vector2 size2 = tileSprite._spriteRenderer.size;
		tileSprite._spriteRenderer.size = vector;
		return;
		IL_0166:
		spriteRenderer.sprite = sprite;
		text = (string)flag;
		goto IL_025d;
		IL_025d:
		Sprite sprite2 = spriteRenderer.sprite;
		object obj2;
		if ((object)sprite2 != null)
		{
			bool flag3 = ((UnityEngine.Object)sprite2).m_CachedPtr != (IntPtr)0;
			obj2 = 0;
			if (flag3)
			{
				goto IL_02f6;
			}
		}
		text = _textureName;
		string message = "TileSpriteBuilder: No sprite found for sprite " + _spriteName + " in texture " + _textureName;
		Debug.LogError(message);
		obj2 = 0;
		goto IL_02f6;
	}

	private void GenerateSpriteScroller(TileSprite tileSprite)
	{
		GameObject gameObject = tileSprite.gameObject;
		SpriteScroller spriteScroller = gameObject.AddComponent<SpriteScroller>();
		tileSprite._spriteScroller = spriteScroller;
	}

	public TileSpriteBuilder()
	{
		//IL_0013: Expected I, but got O
		//IL_004e: Expected I, but got O
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		_pos = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rdx_v1 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		nint num3 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v4 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num4 = 0;
		_scale = Vector3.oneVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		_ = 0;
		_depthMul = 1f;
		_alpha = 1f;
		_tileWidth = 1f;
		_tileHeight = 1f;
	}
}
