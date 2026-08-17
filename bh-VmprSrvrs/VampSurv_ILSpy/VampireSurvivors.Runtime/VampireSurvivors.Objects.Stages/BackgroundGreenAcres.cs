using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using PhaserPort;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundGreenAcres : BackgroundManager
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__9_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CFallOffTheEdge_003Eb__9_0()
		{
			//IL_0108: Expected O, but got I
			//IL_01ac: Expected O, but got I
			//IL_01e1: Expected O, but got I
			//IL_0201: Expected O, but got I
			//IL_02f3: Expected I, but got O
			//IL_036b: Expected O, but got I4
			//IL_03fe->IL037e: Incompatible stack heights: 1 vs 0
			//IL_009a->IL037e: Incompatible stack heights: 1 vs 0
			//IL_0420->IL037e: Incompatible stack heights: 1 vs 0
			//IL_00ee->IL037e: Incompatible stack heights: 1 vs 0
			//IL_012a->IL037e: Incompatible stack heights: 1 vs 0
			//IL_0159->IL037e: Incompatible stack heights: 1 vs 0
			//IL_0197->IL037e: Incompatible stack heights: 1 vs 0
			//IL_01cc->IL037e: Incompatible stack heights: 1 vs 0
			//IL_0445->IL037e: Incompatible stack heights: 1 vs 0
			//IL_0249->IL037e: Incompatible stack heights: 1 vs 0
			//IL_0278->IL037e: Incompatible stack heights: 1 vs 0
			//IL_02a7->IL037e: Incompatible stack heights: 1 vs 0
			//IL_02c4->IL037e: Incompatible stack heights: 1 vs 0
			//IL_0338->IL037e: Incompatible stack heights: 1 vs 0
			//IL_0316->IL0316: Incompatible stack heights: 2 vs 1
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				TilingBackground bgMan = core._bgMan;
				if ((object)core._bgMan != null)
				{
					TileSprite bgtile = bgMan._bgtile;
					bgMan._003CRunTimeHue_003Ek__BackingField = false;
					SpriteRenderer spriteRenderer = bgtile._spriteRenderer;
					bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
					Color value = default(Color);
					SpriteRenderer.set_color_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, ref value);
					GameManager core2 = GM.Core;
					if ((object)GM.Core != null)
					{
						TilingBackground bgMan2 = core2._bgMan;
						if ((object)core2._bgMan != null)
						{
							SpriteRenderer bgtile2 = (SpriteRenderer)(object)bgMan2._bgtile;
							if ((object)bgMan2._bgtile != null)
							{
								Sprite unpackedSprite = SpriteManager.GetUnpackedSprite("bg_ram");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rbx_v8 (UnityEngine.SpriteRenderer)+28]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rbx_v8 (UnityEngine.SpriteRenderer)+28]");
									((SpriteRenderer)0).sprite = unpackedSprite;
									GameManager core3 = GM.Core;
									if ((object)GM.Core != null)
									{
										TilingBackground bgMan3 = core3._bgMan;
										if ((object)core3._bgMan != null)
										{
											TileSprite tileSprite = RenderingExtensions.SetScale(bgMan3._bgtile, 1f);
											SpriteRenderer core4 = (SpriteRenderer)(object)GM.Core;
											if ((object)GM.Core != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rbx_v10 (UnityEngine.SpriteRenderer)+278]");
												SpriteRenderer spriteRenderer2 = (SpriteRenderer)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rbx_v10 (UnityEngine.SpriteRenderer)+278]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rbx_v11 (UnityEngine.SpriteRenderer)+40]");
													SpriteRenderer spriteRenderer3 = (SpriteRenderer)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rbx_v11 (UnityEngine.SpriteRenderer)+40]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rbx_v12 (UnityEngine.SpriteRenderer)+28]");
														SpriteRenderer spriteRenderer4 = RenderingExtensions.SetAlpha((SpriteRenderer)0, 0f);
														TweenConfig tweenConfig = new TweenConfig();
														object[] array = new object[1];
														GameManager core5 = GM.Core;
														if ((object)GM.Core != null)
														{
															TilingBackground bgMan4 = core5._bgMan;
															if ((object)core5._bgMan != null)
															{
																TileSprite bgtile3 = bgMan4._bgtile;
																if ((object)bgMan4._bgtile != null && array != null)
																{
																	if ((object)bgtile3._spriteRenderer != null)
																	{
																		nint num = (nint)array;
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																		object obj = default(object);
																		bool flag2 = obj == null;
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																	if (tweenConfig != null)
																	{
																		tweenConfig.targets = array;
																		tweenConfig.duration = 500f;
																		tweenConfig.alpha = (float?)(object)1;
																		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
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
								}
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private bool _checkForEdgeOfTheWorld;

	private bool _canFallOffTheEdge;

	private float _worldEndX;

	private float _worldEndY;

	private bool _isOffTheEdge;

	private BgmType _savedBGM;

	private BgmModType _savedBgmMod;

	private TileSprite _missingBg;

	public override void Create()
	{
		base.Create();
		_checkForEdgeOfTheWorld = false;
		_isOffTheEdge = false;
		_worldEndX = -184.31999f;
		_worldEndY = -184.31999f;
		base._003CxxlBatsDefeated_003Ek__BackingField = 0;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				goto IL_00a2;
			}
		}
		Vector2 pos = default(Vector2);
		float value = default(float);
		ItemType relicType = default(ItemType);
		bool validatePickups = default(bool);
		Pickup pickup = GM.Core.MakeStagePickup(pos, ItemType.RELIC, WeaponType.VOID, value, relicType, validatePickups);
		goto IL_00a2;
		IL_00a2:
		List<StageType> validUnlockedStages = Stage.GetValidUnlockedStages();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rax_v10 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+18]");
		if ((nint)0 < (nint)5)
		{
			return;
		}
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		if (!config2._003CSelectedHurry_003Ek__BackingField)
		{
			return;
		}
		GameManager core3 = GM.Core;
		PlayerOptionsData config3 = core3._playerOptions.Config;
		if (config3._003CSelectedHyper_003Ek__BackingField)
		{
			GameManager core4 = GM.Core;
			PlayerOptionsData config4 = core4._playerOptions.Config;
			if (config4.HasCollectedItem(ItemType.RELIC_YELLOW))
			{
				_checkForEdgeOfTheWorld = true;
			}
		}
	}

	public unsafe void FallOffTheEdge()
	{
		//IL_008c: Expected O, but got I
		//IL_0c9d: Expected O, but got I
		//IL_0d29: Expected I4, but got I8
		//IL_02fd: Expected O, but got I
		//IL_0342: Expected O, but got I
		//IL_0352: Expected O, but got I
		//IL_03c5: Expected O, but got I
		//IL_03f6: Expected O, but got I
		//IL_0441: Expected O, but got I
		//IL_0451: Expected O, but got I
		//IL_04c7: Expected O, but got I
		//IL_04ac: Expected O, but got I4
		//IL_0682: Expected O, but got I
		//IL_0788: Expected O, but got I
		//IL_079d: Expected O, but got I
		//IL_0773: Expected O, but got I
		//IL_073d: Expected O, but got I
		//IL_08a3: Expected O, but got I
		//IL_0705: Expected O, but got I
		//IL_08b8: Expected O, but got I
		//IL_088e: Expected O, but got I
		//IL_0858: Expected O, but got I
		//IL_09be: Expected O, but got I
		//IL_0820: Expected O, but got I
		//IL_09d3: Expected O, but got I
		//IL_09a9: Expected O, but got I
		//IL_0973: Expected O, but got I
		//IL_0ad9: Expected O, but got I
		//IL_093b: Expected O, but got I
		//IL_0ac4: Expected O, but got I
		//IL_0a8e: Expected O, but got I
		//IL_0a56: Expected O, but got I
		//IL_0bd6: Expected I, but got O
		//IL_0c3c: Expected O, but got I4
		//IL_0c4a: Expected O, but got I4
		//IL_0c9e->IL0c9e: Incompatible stack heights: 4 vs 0
		//IL_037e->IL0def: Incompatible stack heights: 19 vs 17
		//IL_04b1->IL0e2f: Incompatible stack heights: 22 vs 23
		//IL_0763->IL0e78: Incompatible stack heights: 33 vs 32
		//IL_087e->IL0ed5: Incompatible stack heights: 35 vs 34
		//IL_0999->IL0f32: Incompatible stack heights: 37 vs 36
		//IL_0ab4->IL0f83: Incompatible stack heights: 39 vs 38
		//IL_0bf9->IL0bf9: Incompatible stack heights: 44 vs 43
		//IL_0c8b->IL0c8b: Incompatible stack heights: 44 vs 0
		while (true)
		{
			if (_canFallOffTheEdge)
			{
				_isOffTheEdge = true;
				GameManager.SfxVolumeFactor = 0.65f;
				GameManager core = GM.Core;
				bool flag = (object)GM.Core == null;
				TilingBackground bgMan = core._bgMan;
				bool flag2 = (object)core._bgMan == null;
				object bgtile = bgMan._bgtile;
				bool flag3 = (object)bgMan._bgtile == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ rbx_v8 (System.Object)+28]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ rbx_v8 (System.Object)+28]");
				bool flag4 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ rbx_v9 (System.Object)+10]");
				if ((nint)0 != 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ rbx_v8 (System.Object)+28]");
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(0);
				continue;
			}
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ rbx_v9 (System.Object)+10]");
		Renderer.set_sortingOrder_Injected((IntPtr)0, -32767);
		Camera main = Camera.main;
		int2 renderTextureSize = CameraExtensions.GetRenderTextureSize(main);
		object obj2 = (object)renderTextureSize >> 32;
		float tileHeight = (float)obj2 / 100f;
		float tileWidth = (float)renderTextureSize / 100f;
		GameObject go = base.gameObject;
		string spriteName = default(string);
		TileSpriteBuilder tileSpriteBuilder = RenderingExtensions.AddTileSprite(go, 0f, 0f, null, spriteName);
		bool flag5 = tileSpriteBuilder == null;
		tileSpriteBuilder._depth = -32768f;
		tileSpriteBuilder._depthMul = 1f;
		tileSpriteBuilder._tileWidth = tileWidth;
		tileSpriteBuilder._tileHeight = tileHeight;
		tileSpriteBuilder._name = "_MISSING";
		TileSprite missingBg = tileSpriteBuilder.Build();
		_missingBg = missingBg;
		bool flag6 = (object)_missingBg == null;
		Transform transform = _missingBg.transform;
		GameManager core2 = GM.Core;
		bool flag7 = (object)GM.Core == null;
		GameSessionData gameSessionData = core2._gameSessionData;
		bool flag8 = core2._gameSessionData == null;
		bool flag9 = (object)gameSessionData._activeCharacter == null;
		Transform transform2 = gameSessionData._activeCharacter.transform;
		bool flag10 = (object)transform2 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v860 @ rax_v61 (UnityEngine.Transform)+10]");
		bool flag11 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v860 @ rax_v61 (UnityEngine.Transform)+10]");
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator ret;
		Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
		bool flag12 = (object)transform == null;
		bool flag13 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		TileSprite missingBg2 = _missingBg;
		bool flag14 = (object)_missingBg == null;
		bool flag15 = (object)missingBg2._spriteRenderer == null;
		missingBg2._spriteRenderer.sortingLayerName = "Backgrounds";
		GameManager core3 = GM.Core;
		bool flag16 = (object)GM.Core == null;
		bool flag17 = core3._characters == null;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		while (enumerator.MoveNext())
		{
			object obj3 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1486 @ rbx_v33 (System.Object)+E0]");
			SpriteTrail spriteTrail = (SpriteTrail)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1486 @ rbx_v33 (System.Object)+E0]");
			bool flag18 = (nint)0 == 0;
			spriteTrail._MaxHistory = 300;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1486 @ rbx_v33 (System.Object)+E0]");
			((SpriteTrail)0).InitialiseGhosts(expandExisting: true);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1486 @ rbx_v33 (System.Object)+E0]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1486 @ rbx_v33 (System.Object)+E0]");
			bool flag19 = (nint)0 == 0;
			_ = 1065353216;
		}
		bool flag20 = (object)GM.Core == null;
		GM.Core.EraseEnemies();
		Transform core4 = (Transform)(object)GM.Core;
		bool flag21 = (object)GM.Core == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rsi_v15 (UnityEngine.Transform)+B8]");
		Transform transform3 = (Transform)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rsi_v15 (UnityEngine.Transform)+B8]");
		bool flag22 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rsi_v16 (UnityEngine.Transform)+70]");
		Transform transform4 = (Transform)0;
		List<EnemyType?> list = new List<EnemyType?>();
		bool flag23 = list == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1927 @ rax_v83 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1927 @ rax_v83 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1927 @ rax_v83 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1927 @ rax_v83 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		bool flag24 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1927 @ rax_v83 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rdx_v38+18]");
		if (num >= 0)
		{
			list.AddWithResize((EnemyType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1927 @ rax_v83 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj7 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1927 @ rax_v83 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rdx_v38+18]");
			bool flag25 = num2 >= 0;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rsi_v16 (UnityEngine.Transform)+70]");
		bool flag26 = (nint)0 == 0;
		GameManager core5 = GM.Core;
		bool flag27 = (object)GM.Core == null;
		Stage stage = core5._stage;
		bool flag28 = (object)core5._stage == null;
		StageData stageData = stage._stageData;
		bool flag29 = stage._stageData == null;
		stageData._003Cminimum_003Ek__BackingField = 10;
		GameManager core6 = GM.Core;
		bool flag30 = (object)GM.Core == null;
		Stage stage2 = core6._stage;
		bool flag31 = (object)core6._stage == null;
		StageData stageData2 = stage2._stageData;
		bool flag32 = stage2._stageData == null;
		GameManager core7 = GM.Core;
		Stage stage3 = core7._stage;
		StageData stageData3 = stage3._stageData;
		core6._stage.UpdateEnemyPools(stageData2._003Cenemies_003Ek__BackingField, stageData3._003Cbosses_003Ek__BackingField);
		object core8 = GM.Core;
		bool flag33 = (object)GM.Core == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v393 @ rbx_v22 (System.Object)+90]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v393 @ rbx_v22 (System.Object)+90]");
		bool flag34 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ rbx_v23 (System.Object)+68]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ rbx_v23 (System.Object)+58]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ rbx_v23 (System.Object)+78]");
				object obj9;
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ rbx_v23 (System.Object)+78]");
					obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2096 @ rax_v96+2CC]");
					if ((nint)0 != 0)
					{
						goto IL_0e78;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ rbx_v23 (System.Object)+50]");
				obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ rbx_v23 (System.Object)+50]");
				bool flag35 = (nint)0 == 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ rbx_v23 (System.Object)+58]");
				object obj9 = 0;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ rbx_v23 (System.Object)+68]");
			object obj9 = 0;
		}
		goto IL_0e78;
		IL_0e78:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2096 @ rax_v96+68]");
		_savedBGM = BgmType.BGM_Forest;
		object core9 = GM.Core;
		bool flag36 = (object)GM.Core == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ rbx_v24 (System.Object)+90]");
		object obj10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ rbx_v24 (System.Object)+90]");
		bool flag37 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rbx_v25 (System.Object)+68]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rbx_v25 (System.Object)+58]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rbx_v25 (System.Object)+78]");
				object obj11;
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rbx_v25 (System.Object)+78]");
					obj11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2181 @ rax_v100+2CC]");
					if ((nint)0 != 0)
					{
						goto IL_0ed5;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rbx_v25 (System.Object)+50]");
				obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rbx_v25 (System.Object)+50]");
				bool flag38 = (nint)0 == 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rbx_v25 (System.Object)+58]");
				object obj11 = 0;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rbx_v25 (System.Object)+68]");
			object obj11 = 0;
		}
		goto IL_0ed5;
		IL_0f83:
		_ = 0;
		bool flag39 = (object)GM.Core == null;
		GM.Core.SetupMusicBanger();
		_canFallOffTheEdge = false;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		GameManager core10 = GM.Core;
		bool flag40 = (object)GM.Core == null;
		TilingBackground bgMan2 = core10._bgMan;
		bool flag41 = (object)core10._bgMan == null;
		bool flag42 = (object)bgMan2._bgtile == null;
		Transform transform5 = bgMan2._bgtile.transform;
		bool flag43 = array == null;
		if ((object)transform5 != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj12 = default(object);
			bool flag44 = obj12 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		bool flag45 = tweenConfig == null;
		tweenConfig.targets = array;
		tweenConfig.scaleX = (float?)(object)1;
		tweenConfig.scaleY = (float?)(object)1;
		tweenConfig.duration = 10000f;
		TweenCallback onComplete = _003C_003Ec._003C_003E9__9_0;
		if (_003C_003Ec._003C_003E9__9_0 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__9_0 = delegate
			{
				//IL_0108: Expected O, but got I
				//IL_01ac: Expected O, but got I
				//IL_01e1: Expected O, but got I
				//IL_0201: Expected O, but got I
				//IL_02f3: Expected I, but got O
				//IL_036b: Expected O, but got I4
				//IL_03fe->IL037e: Incompatible stack heights: 1 vs 0
				//IL_009a->IL037e: Incompatible stack heights: 1 vs 0
				//IL_0420->IL037e: Incompatible stack heights: 1 vs 0
				//IL_00ee->IL037e: Incompatible stack heights: 1 vs 0
				//IL_012a->IL037e: Incompatible stack heights: 1 vs 0
				//IL_0159->IL037e: Incompatible stack heights: 1 vs 0
				//IL_0197->IL037e: Incompatible stack heights: 1 vs 0
				//IL_01cc->IL037e: Incompatible stack heights: 1 vs 0
				//IL_0445->IL037e: Incompatible stack heights: 1 vs 0
				//IL_0249->IL037e: Incompatible stack heights: 1 vs 0
				//IL_0278->IL037e: Incompatible stack heights: 1 vs 0
				//IL_02a7->IL037e: Incompatible stack heights: 1 vs 0
				//IL_02c4->IL037e: Incompatible stack heights: 1 vs 0
				//IL_0338->IL037e: Incompatible stack heights: 1 vs 0
				//IL_0316->IL0316: Incompatible stack heights: 2 vs 1
				GameManager core13 = GM.Core;
				if ((object)GM.Core != null)
				{
					TilingBackground bgMan3 = core13._bgMan;
					if ((object)core13._bgMan != null)
					{
						TileSprite bgtile2 = bgMan3._bgtile;
						bgMan3._003CRunTimeHue_003Ek__BackingField = false;
						SpriteRenderer spriteRenderer = bgtile2._spriteRenderer;
						bool flag52 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
						Color value2 = default(Color);
						SpriteRenderer.set_color_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, ref value2);
						GameManager core14 = GM.Core;
						if ((object)GM.Core != null)
						{
							TilingBackground bgMan4 = core14._bgMan;
							if ((object)core14._bgMan != null)
							{
								SpriteRenderer bgtile3 = (SpriteRenderer)(object)bgMan4._bgtile;
								if ((object)bgMan4._bgtile != null)
								{
									Sprite unpackedSprite = SpriteManager.GetUnpackedSprite("bg_ram");
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rbx_v8 (UnityEngine.SpriteRenderer)+28]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rbx_v8 (UnityEngine.SpriteRenderer)+28]");
										((SpriteRenderer)0).sprite = unpackedSprite;
										GameManager core15 = GM.Core;
										if ((object)GM.Core != null)
										{
											TilingBackground bgMan5 = core15._bgMan;
											if ((object)core15._bgMan != null)
											{
												TileSprite tileSprite = RenderingExtensions.SetScale(bgMan5._bgtile, 1f);
												SpriteRenderer core16 = (SpriteRenderer)(object)GM.Core;
												if ((object)GM.Core != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rbx_v10 (UnityEngine.SpriteRenderer)+278]");
													SpriteRenderer spriteRenderer2 = (SpriteRenderer)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rbx_v10 (UnityEngine.SpriteRenderer)+278]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rbx_v11 (UnityEngine.SpriteRenderer)+40]");
														SpriteRenderer spriteRenderer3 = (SpriteRenderer)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rbx_v11 (UnityEngine.SpriteRenderer)+40]");
														if ((nint)0 != 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rbx_v12 (UnityEngine.SpriteRenderer)+28]");
															SpriteRenderer spriteRenderer4 = RenderingExtensions.SetAlpha((SpriteRenderer)0, 0f);
															TweenConfig tweenConfig2 = new TweenConfig();
															object[] array2 = new object[1];
															GameManager core17 = GM.Core;
															if ((object)GM.Core != null)
															{
																TilingBackground bgMan6 = core17._bgMan;
																if ((object)core17._bgMan != null)
																{
																	TileSprite bgtile4 = bgMan6._bgtile;
																	if ((object)bgMan6._bgtile != null && array2 != null)
																	{
																		if ((object)bgtile4._spriteRenderer != null)
																		{
																			nint num4 = (nint)array2;
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																			object obj17 = default(object);
																			bool flag53 = obj17 == null;
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																		if (tweenConfig2 != null)
																		{
																			tweenConfig2.targets = array2;
																			tweenConfig2.duration = 500f;
																			tweenConfig2.alpha = (float?)(object)1;
																			MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
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
									}
								}
							}
						}
					}
				}
				throw new NullReferenceException();
			});
		}
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		return;
		IL_0f32:
		_ = 25;
		object core11 = GM.Core;
		bool flag46 = (object)GM.Core == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ rbx_v28 (System.Object)+90]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ rbx_v28 (System.Object)+90]");
		bool flag47 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ rbx_v29 (System.Object)+68]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ rbx_v29 (System.Object)+58]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ rbx_v29 (System.Object)+78]");
				object obj14;
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ rbx_v29 (System.Object)+78]");
					obj14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2349 @ rax_v107+2CC]");
					if ((nint)0 != 0)
					{
						goto IL_0f83;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ rbx_v29 (System.Object)+50]");
				obj14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ rbx_v29 (System.Object)+50]");
				bool flag48 = (nint)0 == 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ rbx_v29 (System.Object)+58]");
				object obj14 = 0;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ rbx_v29 (System.Object)+68]");
			object obj14 = 0;
		}
		goto IL_0f83;
		IL_0ed5:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2181 @ rax_v100+6C]");
		_savedBgmMod = BgmModType.Normal;
		object core12 = GM.Core;
		bool flag49 = (object)GM.Core == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ rbx_v26 (System.Object)+90]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ rbx_v26 (System.Object)+90]");
		bool flag50 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v396 @ rbx_v27 (System.Object)+68]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v396 @ rbx_v27 (System.Object)+58]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v396 @ rbx_v27 (System.Object)+78]");
				object obj16;
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v396 @ rbx_v27 (System.Object)+78]");
					obj16 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2266 @ rax_v104+2CC]");
					if ((nint)0 != 0)
					{
						goto IL_0f32;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v396 @ rbx_v27 (System.Object)+50]");
				obj16 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v396 @ rbx_v27 (System.Object)+50]");
				bool flag51 = (nint)0 == 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v396 @ rbx_v27 (System.Object)+58]");
				object obj16 = 0;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v396 @ rbx_v27 (System.Object)+68]");
			object obj16 = 0;
		}
		goto IL_0f32;
	}

	public unsafe void ResetTilemap()
	{
		//IL_0478: Expected O, but got I4
		//IL_0056: Expected O, but got I
		//IL_012b: Expected O, but got I
		//IL_02d5: Expected O, but got I4
		//IL_03a5: Expected I, but got O
		//IL_03f7: Expected O, but got I4
		//IL_0413: Expected O, but got I4
		//IL_0070->IL0070: Incompatible stack heights: 1 vs 0
		//IL_03c8->IL03c8: Incompatible stack heights: 1 vs 0
		_isOffTheEdge = false;
		List<StageType> validUnlockedStages = Stage.GetValidUnlockedStages();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+18]");
		bool flag = (nint)0 < (nint)2;
		StageType stageType = StageType.FOREST;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+18]");
			object obj = UnityEngine.Random.RandomRangeInt(0, 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+18]");
			bool flag2 = (nint)obj >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rcx_v76+20+v178 @ rax_v104*4]");
			stageType = StageType.FOREST;
		}
		GM.Core.EraseEnemies();
		GameManager core = GM.Core;
		Stage stage = core._stage;
		if (core._stage.GetStageDataForMinute(stage._currentMinute, stageType, out var stageJsonObject))
		{
			object obj3 = stageJsonObject.ToObject<object>();
			GameManager core2 = GM.Core;
			Stage stage2 = core2._stage;
			StageData stageData = stage2._stageData;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v978 @ rax_v75 (System.Object)+150]");
			stageData._003Cenemies_003Ek__BackingField = (List<EnemyType?>)0;
			GameManager core3 = GM.Core;
			Stage stage3 = core3._stage;
			StageData stageData2 = stage3._stageData;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v978 @ rax_v75 (System.Object)+140]");
			stageData2._003Cminimum_003Ek__BackingField = 0;
		}
		GameManager core4 = GM.Core;
		Stage stage4 = core4._stage;
		StageData stageData3 = stage4._stageData;
		GameManager core5 = GM.Core;
		Stage stage5 = core5._stage;
		StageData stageData4 = stage5._stageData;
		core4._stage.UpdateEnemyPools(stageData3._003Cenemies_003Ek__BackingField, stageData4._003Cbosses_003Ek__BackingField);
		GameManager core6 = GM.Core;
		PlayerOptionsData config = core6._playerOptions.Config;
		List<CharacterType> list = config._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rcx_v26 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		int num;
		PlayerOptionsData playerOptionsData;
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rcx_v26 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj4 = default(object);
			bool flag3 = (nint)obj4 != -1;
			playerOptionsData = null;
			if (flag3)
			{
				goto IL_032c;
			}
		}
		GameManager core7 = GM.Core;
		PlayerOptionsData config2 = core7._playerOptions.Config;
		bool flag4 = core7._playerOptions.UnlockSecret(SecretType.EdgeOfTheWorld, config2);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = -1000f;
		soundConfig.Rate = 0.5f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ThingFound, soundConfig, 0f, 10, time);
		num = 10;
		playerOptionsData = config2;
		goto IL_032c;
		IL_032c:
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		GameManager core8 = GM.Core;
		TilingBackground bgMan = core8._bgMan;
		Transform transform = bgMan._bgtile.transform;
		if ((object)transform != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			bool flag5 = obj5 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.scaleX = (float?)(object)1;
		tweenConfig.duration = 10000f;
		tweenConfig.scaleY = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			//IL_00b0: Expected O, but got I4
			//IL_00b8: Expected O, but got Ref
			//IL_019b: Expected I, but got O
			//IL_01f1: Expected O, but got I4
			GameManager core9 = GM.Core;
			TilingBackground bgMan2 = core9._bgMan;
			TileSprite bgtile = bgMan2._bgtile;
			Sprite unpackedSprite = SpriteManager.GetUnpackedSprite("bg_forest");
			bgtile._spriteRenderer.sprite = unpackedSprite;
			GameManager core10 = GM.Core;
			TilingBackground bgMan3 = core10._bgMan;
			TileSprite tileSprite = RenderingExtensions.SetScale(bgMan3._bgtile, 1f);
			GameManager core11 = GM.Core;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj6 = 0;
				List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			GameManager core12 = GM.Core;
			TilingBackground bgMan4 = core12._bgMan;
			TileSprite bgtile2 = bgMan4._bgtile;
			SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(bgtile2._spriteRenderer, 0f);
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			GameManager core13 = GM.Core;
			TilingBackground bgMan5 = core13._bgMan;
			TileSprite bgtile3 = bgMan5._bgtile;
			if ((object)bgtile3._spriteRenderer != null)
			{
				nint num3 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj7 = default(object);
				if (obj7 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.alpha = (float?)(object)1;
			tweenConfig2.duration = 500f;
			MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
			GameManager core14 = GM.Core;
			PlayerOptions playerOptions = core14._playerOptions;
			PlayerOptionsData playerOptionsData2;
			if (playerOptions._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions._hostGameConfig == null)
				{
					if (playerOptions._currentAdventureSaveData != null)
					{
						PlayerOptionsData currentAdventureSaveData = playerOptions._currentAdventureSaveData;
						if ((object)currentAdventureSaveData._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							playerOptionsData2 = currentAdventureSaveData;
							goto IL_0471;
						}
					}
					playerOptionsData2 = playerOptions._mainGameConfig;
				}
				else
				{
					playerOptionsData2 = playerOptions._hostGameConfig;
				}
			}
			else
			{
				playerOptionsData2 = playerOptions._onlineClientWithRunDataConfig;
			}
			goto IL_0471;
			IL_04b3:
			PlayerOptionsData playerOptionsData3;
			playerOptionsData3._003CSelectedBGMMod_003Ek__BackingField = _savedBgmMod;
			GM.Core.SetupMusicBanger();
			return;
			IL_0471:
			playerOptionsData2._003CSelectedBGM_003Ek__BackingField = _savedBGM;
			GameManager core15 = GM.Core;
			PlayerOptions playerOptions2 = core15._playerOptions;
			if (playerOptions2._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions2._hostGameConfig == null)
				{
					if (playerOptions2._currentAdventureSaveData != null)
					{
						PlayerOptionsData currentAdventureSaveData2 = playerOptions2._currentAdventureSaveData;
						if ((object)currentAdventureSaveData2._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							playerOptionsData3 = currentAdventureSaveData2;
							goto IL_04b3;
						}
					}
					playerOptionsData3 = playerOptions2._mainGameConfig;
				}
				else
				{
					playerOptionsData3 = playerOptions2._hostGameConfig;
				}
			}
			else
			{
				playerOptionsData3 = playerOptions2._onlineClientWithRunDataConfig;
			}
			goto IL_04b3;
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	public override void CheckMinute(int minute)
	{
		//IL_0064: Expected O, but got I
		//IL_00be: Expected O, but got I
		//IL_00a3: Expected O, but got I4
		if (_isOffTheEdge)
		{
			GameManager core = GM.Core;
			Stage stage = core._stage;
			StageData stageData = stage._stageData;
			List<EnemyType?> list = new List<EnemyType?>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rdx_v5+18]");
			if (num >= 0)
			{
				list.AddWithResize((EnemyType?)(object)1);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
				object obj2 = (nint)0 + (nint)1;
				_ = 1;
			}
			stageData._003Cenemies_003Ek__BackingField = list;
			GameManager core2 = GM.Core;
			Stage stage2 = core2._stage;
			StageData stageData2 = stage2._stageData;
			if (stageData2._003Cminimum_003Ek__BackingField > 20)
			{
				GameManager core3 = GM.Core;
				Stage stage3 = core3._stage;
				StageData stageData3 = stage3._stageData;
				stageData3._003Cminimum_003Ek__BackingField = 20;
			}
			GameManager core4 = GM.Core;
			Stage stage4 = core4._stage;
			StageData stageData4 = stage4._stageData;
			if (500f > stageData4._003Cfrequency_003Ek__BackingField)
			{
				GameManager core5 = GM.Core;
				Stage stage5 = core5._stage;
				StageData stageData5 = stage5._stageData;
				stageData5._003Cfrequency_003Ek__BackingField = 500f;
			}
			GameManager core6 = GM.Core;
			Stage stage6 = core6._stage;
			StageData stageData6 = stage6._stageData;
			GameManager core7 = GM.Core;
			Stage stage7 = core7._stage;
			StageData stageData7 = stage7._stageData;
			core6._stage.UpdateEnemyPools(stageData6._003Cenemies_003Ek__BackingField, stageData7._003Cbosses_003Ek__BackingField);
		}
	}

	protected override void OnDestroy()
	{
		GameManager.SfxVolumeFactor = 1f;
		base.OnDestroy();
	}

	protected override void OnUpdate()
	{
		//IL_024c: Invalid comparison between F4 and O
		//IL_029d: Invalid comparison between F4 and O
		//IL_025e->IL01f3: Incompatible stack heights: 1 vs 0
		//IL_00f7->IL01c7: Incompatible stack heights: 1 vs 0
		//IL_0126->IL01c7: Incompatible stack heights: 1 vs 0
		//IL_0148->IL01c7: Incompatible stack heights: 1 vs 0
		//IL_0177->IL01c7: Incompatible stack heights: 1 vs 0
		//IL_02af->IL01f3: Incompatible stack heights: 2 vs 0
		//IL_019c->IL01f3: Incompatible stack heights: 2 vs 0
		base.OnUpdate();
		if (_checkForEdgeOfTheWorld && _canFallOffTheEdge)
		{
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				GameSessionData gameSessionData = core._gameSessionData;
				if (core._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
				{
					Transform transform = gameSessionData._activeCharacter.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
						float worldEndX = _worldEndX;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)worldEndX) <= System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref ret))
						{
							goto IL_01f3;
						}
						GameManager core2 = GM.Core;
						if ((object)GM.Core != null)
						{
							GameSessionData gameSessionData2 = core2._gameSessionData;
							if (core2._gameSessionData != null && (object)gameSessionData2._activeCharacter != null)
							{
								Transform transform2 = gameSessionData2._activeCharacter.transform;
								if ((object)transform2 != null)
								{
									bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
									Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
									float worldEndY = _worldEndY;
									object obj = default(object);
									if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)worldEndY) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
									{
										FallOffTheEdge();
										_canFallOffTheEdge = false;
									}
									goto IL_01f3;
								}
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
		goto IL_01f3;
		IL_01f3:
		if (_isOffTheEdge && base._003CxxlBatsDefeated_003Ek__BackingField >= 128)
		{
			ResetTilemap();
		}
	}

	private void LateUpdate()
	{
		//IL_013d->IL0107: Incompatible stack heights: 1 vs 0
		TileSprite missingBg = _missingBg;
		if ((object)_missingBg == null || ((UnityEngine.Object)missingBg).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		float2 cameraCenter = RenderingHelper.GetCameraCenter();
		float num = (float)cameraCenter * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
		object obj = default(object);
		float num2 = (float)obj * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
		if ((object)_missingBg != null)
		{
			Transform transform = _missingBg.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void _003CResetTilemap_003Eb__10_0()
	{
		//IL_00b0: Expected O, but got I4
		//IL_00b8: Expected O, but got Ref
		//IL_019b: Expected I, but got O
		//IL_01f1: Expected O, but got I4
		GameManager core = GM.Core;
		TilingBackground bgMan = core._bgMan;
		TileSprite bgtile = bgMan._bgtile;
		Sprite unpackedSprite = SpriteManager.GetUnpackedSprite("bg_forest");
		bgtile._spriteRenderer.sprite = unpackedSprite;
		GameManager core2 = GM.Core;
		TilingBackground bgMan2 = core2._bgMan;
		TileSprite tileSprite = RenderingExtensions.SetScale(bgMan2._bgtile, 1f);
		GameManager core3 = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		GameManager core4 = GM.Core;
		TilingBackground bgMan3 = core4._bgMan;
		TileSprite bgtile2 = bgMan3._bgtile;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(bgtile2._spriteRenderer, 0f);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		GameManager core5 = GM.Core;
		TilingBackground bgMan4 = core5._bgMan;
		TileSprite bgtile3 = bgMan4._bgtile;
		if ((object)bgtile3._spriteRenderer != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.alpha = (float?)(object)1;
		tweenConfig.duration = 500f;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		GameManager core6 = GM.Core;
		PlayerOptions playerOptions = core6._playerOptions;
		PlayerOptionsData playerOptionsData;
		if (playerOptions._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions._hostGameConfig == null)
			{
				if (playerOptions._currentAdventureSaveData != null)
				{
					PlayerOptionsData currentAdventureSaveData = playerOptions._currentAdventureSaveData;
					if ((object)currentAdventureSaveData._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						playerOptionsData = currentAdventureSaveData;
						goto IL_0471;
					}
				}
				playerOptionsData = playerOptions._mainGameConfig;
			}
			else
			{
				playerOptionsData = playerOptions._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
		}
		goto IL_0471;
		IL_04b3:
		PlayerOptionsData playerOptionsData2;
		playerOptionsData2._003CSelectedBGMMod_003Ek__BackingField = _savedBgmMod;
		GM.Core.SetupMusicBanger();
		return;
		IL_0471:
		playerOptionsData._003CSelectedBGM_003Ek__BackingField = _savedBGM;
		GameManager core7 = GM.Core;
		PlayerOptions playerOptions2 = core7._playerOptions;
		if (playerOptions2._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions2._hostGameConfig == null)
			{
				if (playerOptions2._currentAdventureSaveData != null)
				{
					PlayerOptionsData currentAdventureSaveData2 = playerOptions2._currentAdventureSaveData;
					if ((object)currentAdventureSaveData2._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						playerOptionsData2 = currentAdventureSaveData2;
						goto IL_04b3;
					}
				}
				playerOptionsData2 = playerOptions2._mainGameConfig;
			}
			else
			{
				playerOptionsData2 = playerOptions2._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData2 = playerOptions2._onlineClientWithRunDataConfig;
		}
		goto IL_04b3;
	}
}
