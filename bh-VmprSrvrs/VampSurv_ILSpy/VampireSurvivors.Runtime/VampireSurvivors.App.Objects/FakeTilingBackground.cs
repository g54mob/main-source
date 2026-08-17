using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;

namespace VampireSurvivors.App.Objects;

public class FakeTilingBackground : GameMonoBehaviour
{
	private TileSprite _bgTile;

	private float _speedFactor;

	public TileSprite BgTile => _bgTile;

	public float SpeedFactor
	{
		get
		{
			return _speedFactor;
		}
		set
		{
			_speedFactor = value;
		}
	}

	protected override void OnUpdate()
	{
		TileSprite bgTile = _bgTile;
		float speedFactor = 0.5f / bgTile._tileScaleX;
		_speedFactor = speedFactor;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		TileSprite bgTile2 = _bgTile;
		float scrollOffsetX = (bgTile2._xScrollOffset = (float)renderer.screenCenter * _speedFactor);
		bgTile2._spriteScroller.SetScrollOffsetX(scrollOffsetX);
		TileSprite bgTile3 = _bgTile;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v9 (PhaserScene+Renderer)+38]");
		float scrollOffsetY = (bgTile3._yScrollOffset = 0f * _speedFactor);
		bgTile3._spriteScroller.SetScrollOffsetY(scrollOffsetY);
	}

	public void MakeBackground(string textureName, Stage stage)
	{
		//IL_0157: Expected O, but got I4
		if ((object)this != null)
		{
			GameObject go = base.gameObject;
			string spriteName = default(string);
			TileSpriteBuilder tileSpriteBuilder = RenderingExtensions.AddTileSprite(go, 0f, 0f, null, spriteName);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null)
				{
					PhaserScene.Renderer renderer = s_scene._renderer;
					if (s_scene._renderer != null && (object)GM.Core != null)
					{
						PhaserScene s_scene2 = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null)
						{
							PhaserScene.Renderer renderer2 = s_scene2._renderer;
							if (s_scene2._renderer != null && tileSpriteBuilder != null)
							{
								tileSpriteBuilder._tileWidth = renderer.width;
								tileSpriteBuilder._tileHeight = renderer2.height;
								TileSpriteBuilder tileSpriteBuilder2 = tileSpriteBuilder.SetScale(1f);
								if (tileSpriteBuilder2 != null)
								{
									tileSpriteBuilder2._spritePivot = (Vector2?)(object)1;
									_ = 0.5f;
									tileSpriteBuilder2._depth = -32768f;
									tileSpriteBuilder2._depthMul = 1f;
									TileSprite bgTile = tileSpriteBuilder2.Build();
									_bgTile = bgTile;
									if ((object)_bgTile != null)
									{
										Transform transform = _bgTile.transform;
										bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
										Vector3 value = default(Vector3);
										Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
										_bgTile.SetVisible(visible: false);
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public FakeTilingBackground()
	{
		//IL_002b: Expected I, but got O
		_speedFactor = 1f;
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
