using System;
using Cpp2ILInjected;
using PhaserPort;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects;

public class TilingBackground : GameMonoBehaviour
{
	private Stage _stage;

	private Vector2 _initialOffset;

	private float _timeOffset;

	private bool _canScroll;

	private TileSprite _bgtile;

	private Color _dayColor;

	private Color _nightColor;

	private float _yMul;

	private const float DayCycleDuration = 900f;

	private bool _003CRunTimeHue_003Ek__BackingField;

	public TileSprite bgtile => _bgtile;

	public bool RunTimeHue
	{
		get
		{
			return _003CRunTimeHue_003Ek__BackingField;
		}
		set
		{
			_003CRunTimeHue_003Ek__BackingField = value;
		}
	}

	public void Init(Stage stage)
	{
		_stage = stage;
		Stage stage2 = _stage;
		if ((object)_stage != null && ((UnityEngine.Object)stage2).m_CachedPtr != (IntPtr)0)
		{
			Color color = default(Color);
			_dayColor = color;
			_yMul = 1f;
			_nightColor = color;
			Camera main = Camera.main;
			int2 renderTextureSize = CameraExtensions.GetRenderTextureSize(main);
			object obj = (object)renderTextureSize >> 32;
			float tileWidth = (float)renderTextureSize / 100f;
			float tileHeight = (float)obj / 100f;
			GameObject go = base.gameObject;
			string spriteName = default(string);
			TileSpriteBuilder tileSpriteBuilder = RenderingExtensions.AddTileSprite(go, 0f, 0f, null, spriteName);
			tileSpriteBuilder._depth = -32768f;
			tileSpriteBuilder._depthMul = 1f;
			tileSpriteBuilder._tileWidth = tileWidth;
			tileSpriteBuilder._tileHeight = tileHeight;
			Stage stage3 = _stage;
			StageData stageData = stage3._stageData;
			tileSpriteBuilder._name = stageData._003CBGTextureName_003Ek__BackingField;
			TileSprite tileSprite = tileSpriteBuilder.Build();
			_bgtile = tileSprite;
			TileSprite tileSprite2 = _bgtile;
			Stage stage4 = _stage;
			StageData stageData2 = stage4._stageData;
			bool flag = stageData2._003ChasLights_003Ek__BackingField;
			MaterialType type = MaterialType.ScrollableSpriteLit;
			if (!flag)
			{
				type = MaterialType.ScrollableSprite;
			}
			Material material = MaterialManager.GetMaterial(type);
			((Renderer)tileSprite2._spriteRenderer).SetMaterial(material);
			TileSprite tileSprite3 = _bgtile;
			tileSprite3._spriteRenderer.sortingLayerName = "Backgrounds";
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			if (config._003CSelectedInverse_003Ek__BackingField)
			{
				GameManager core2 = GM.Core;
				PlayerOptionsData config2 = core2._playerOptions.Config;
				if (config2._003CVisuallyInvertStages_003Ek__BackingField)
				{
					StageData stageData3 = stage._stageData;
					if (stageData3._003CallowVisualInversion_003Ek__BackingField)
					{
						TileSprite tileSprite4 = _bgtile;
						tileSprite4._spriteRenderer.flipY = true;
						_yMul = -1f;
					}
				}
				_dayColor = color;
				_nightColor = color;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 954 Invalid \"Jump target not found in method: 0x186E92AC0\"");
		}
		Debug.LogError("Stage passed into this class is NULL");
	}

	private void LateUpdate()
	{
		if (_canScroll)
		{
			ProcessTiling();
		}
	}

	public unsafe void DayNightHue()
	{
		//IL_0013: Expected I, but got O
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_0163: Invalid comparison between I4 and F4
		//IL_010a: Expected F4, but got I4
		//IL_01c7->IL01c7: Incompatible stack heights: 1 vs 0
		if (!_003CRunTimeHue_003Ek__BackingField)
		{
			return;
		}
		nint num = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v3 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num2 = 0;
		GameManager core = GM.Core;
		float num3 = core._003CSurvivedSeconds_003Ek__BackingField + _timeOffset;
		float num4 = num3 / 900f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		float num5 = core._003CSurvivedSeconds_003Ek__BackingField + _timeOffset;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
		object obj2 = default(object);
		object obj = obj2 & 1;
		float num6 = ((obj == null) ? num5 : (900f - num5));
		float num7 = num6 / 900f;
		if (!(0f > num7))
		{
			if (num7 > 1f)
			{
				num7 = 1f;
			}
		}
		else
		{
			num7 = 0f;
		}
		TileSprite tileSprite = _bgtile;
		object spriteRenderer = tileSprite._spriteRenderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rbx_v7 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rbx_v7 (System.Object)+10]");
		float value = default(float);
		SpriteRenderer.set_color_Injected((IntPtr)0, ref *(Color*)(&value));
	}

	public unsafe void SetBackgroundTilesTint(Color color)
	{
		TileSprite tileSprite = _bgtile;
		if ((object)_bgtile != null)
		{
			TileSprite spriteRenderer = (TileSprite)(object)tileSprite._spriteRenderer;
			if ((object)tileSprite._spriteRenderer != null)
			{
				bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
				float value = default(float);
				SpriteRenderer.set_color_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, ref *(Color*)(&value));
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void SetVisible(bool visible)
	{
		TileSprite tileSprite = _bgtile;
		tileSprite._spriteRenderer.enabled = visible;
	}

	public void ToggleScrolling(bool value)
	{
		_canScroll = value;
	}

	public void ResetAndStopDayNightHue()
	{
		TileSprite tileSprite = _bgtile;
		_003CRunTimeHue_003Ek__BackingField = false;
		if ((object)_bgtile != null)
		{
			TileSprite spriteRenderer = (TileSprite)(object)tileSprite._spriteRenderer;
			if ((object)tileSprite._spriteRenderer != null)
			{
				bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
				Color value = default(Color);
				SpriteRenderer.set_color_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, ref value);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void ProcessTiling()
	{
		//IL_0398->IL02ed: Incompatible stack heights: 1 vs 0
		//IL_01a1->IL02ed: Incompatible stack heights: 1 vs 0
		//IL_01d0->IL02ed: Incompatible stack heights: 1 vs 0
		//IL_0258->IL039d: Incompatible stack heights: 2 vs 1
		//IL_0422->IL039d: Incompatible stack heights: 8 vs 1
		float2 cameraCenter = RenderingHelper.GetCameraCenter();
		float num = (float)cameraCenter * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003890");
		object obj = default(object);
		float num2 = (float)obj * 100f;
		float num3 = num / 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003890");
		TileSprite tileSprite = _bgtile;
		float num4 = num2 / 100f;
		if ((object)_bgtile != null)
		{
			float scrollOffsetX = (tileSprite._xScrollOffset = num3 + (float)_initialOffset);
			if ((object)tileSprite._spriteScroller != null)
			{
				tileSprite._spriteScroller.SetScrollOffsetX(scrollOffsetX);
				TileSprite tileSprite2 = _bgtile;
				if ((object)_bgtile != null)
				{
					float num5 = num4 * _yMul;
					float num6 = num5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.TilingBackground)+34]");
					float scrollOffsetY = (tileSprite2._yScrollOffset = num6 + 0f);
					if ((object)tileSprite2._spriteScroller != null)
					{
						tileSprite2._spriteScroller.SetScrollOffsetY(scrollOffsetY);
						if ((object)_bgtile != null)
						{
							Transform transform = _bgtile.transform;
							if ((object)transform != null)
							{
								bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Vector3 value = default(Vector3);
								Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
								GameManager core = GM.Core;
								if ((object)GM.Core != null)
								{
									Stage stage = core._stage;
									if ((object)core._stage != null)
									{
										StageData stageData = stage._stageData;
										if (stage._stageData != null)
										{
											if (stageData._003ChasLights_003Ek__BackingField)
											{
												GameManager core2 = GM.Core;
												Stage stage2 = core2._stage;
												StageData baseStageData = stage2._baseStageData;
												bool flag2 = stage2._baseStageData == null;
												if (!baseStageData._003ChasCharacterSpotlight_003Ek__BackingField)
												{
													GameManager core3 = GM.Core;
													bool flag3 = (object)core3._Spotlight2D == null;
													Transform transform2 = core3._Spotlight2D.transform;
													bool flag4 = (object)_bgtile == null;
													Transform transform3 = _bgtile.transform;
													bool flag5 = (object)transform3 == null;
													bool flag6 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
													Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out value);
													bool flag7 = (object)transform2 == null;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v723 @ rax_v42 (UnityEngine.Transform)+10]");
													bool flag8 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v723 @ rax_v42 (UnityEngine.Transform)+10]");
													Vector3 value2 = default(Vector3);
													Transform.set_position_Injected((IntPtr)0, ref value2);
												}
											}
											return;
										}
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

	public TilingBackground()
	{
		//IL_000f: Expected O, but got I8
		//IL_006a: Expected I, but got O
		_initialOffset = (Vector2)3204112712L;
		_ = 1085653647;
		_canScroll = true;
		Color color = default(Color);
		_dayColor = color;
		_yMul = 1f;
		_003CRunTimeHue_003Ek__BackingField = true;
		base._onResumeSent = true;
		_nightColor = color;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rcx_v14 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
