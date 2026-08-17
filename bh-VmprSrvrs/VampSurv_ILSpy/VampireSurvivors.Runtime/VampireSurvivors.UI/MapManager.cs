using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Stages;

namespace VampireSurvivors.UI;

public class MapManager : MonoBehaviour
{
	[StructLayout((LayoutKind)3)]
	private struct _003C_003Ec__DisplayClass61_0
	{
		public string frameName;

		public string textureName;
	}

	private GameObject _Grid;

	private GameObject _MapIcon;

	private GameObject _Player;

	private Image _Foreground;

	private List<Image> _ForegroundSupports;

	private Image _MapStaticBackgroundImage;

	private RectTransform _DetailedMapContainer;

	private CanvasGroup _CanvasGroup;

	private float _AlphaWhileArcanaInfoShown = 0.6f;

	private GameSessionData _session;

	private DataManager _data;

	private GameManager _gameManager;

	private PlayerOptions _playerOptions;

	private List<GameObject> _smallSprites;

	private List<GameObject> _spawned;

	private List<GameObject> _gridLines;

	private MultiTargetTween _pickupFadeTweens;

	private float _width;

	private float _height;

	private float _zoom;

	private float _manualZoomFactor;

	private float _manualZoomStep;

	private float _manualZoomOutCap;

	private float _manualZoomInCap;

	private float _mapRatioX;

	private float _mapRatioY;

	private float _mapSpriteWidth;

	private float _mapSpriteHeight;

	private Sprite _detailedMapSprite;

	private Dictionary<int2, int> _positionBuckets;

	private const float DefaultMapRatio = 1f;

	private const float DefaultMapSize = 512f;

	private const float DefaultPhaserZoom = 0.17f;

	private const float BaselineMapScale = 5.882353f;

	private const float PhaserToUnityAdjustment = 9.625f;

	private const float DefaultPixelsPerTile = 1.6f;

	private ItemType[] _minorItemTypes;

	private Dictionary<ItemType, ItemData> AllItemData
	{
		get
		{
			DataManager data = _data;
			if (_data != null)
			{
				return data._003CAllItems_003Ek__BackingField;
			}
			return (Dictionary<ItemType, ItemData>)(object)new NullReferenceException();
		}
	}

	private Dictionary<WeaponType, List<WeaponData>> AllWeaponData
	{
		get
		{
			if (_data != null)
			{
				return _data.GetConvertedWeapons();
			}
			return (Dictionary<WeaponType, List<WeaponData>>)(object)new NullReferenceException();
		}
	}

	private void Construct(GameSessionData session, DataManager data, GameManager gameManager, PlayerOptions playerOptions)
	{
		_session = session;
		_data = data;
		_gameManager = gameManager;
		PlayerOptions playerOptions2 = default(PlayerOptions);
		_playerOptions = playerOptions2;
	}

	private void Awake()
	{
		RectTransform rectTransform = _Foreground.rectTransform;
		LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
		Canvas.ForceUpdateCanvases();
	}

	private void OnDisable()
	{
		ClearIcons();
		ClearGrid();
	}

	private void OnDestroy()
	{
		ClearIcons();
		ClearGrid();
	}

	public void SetPickups()
	{
		//IL_0177->IL0177: Incompatible stack heights: 3 vs 0
		List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
		bool flag2;
		PlayerOptionsData playerOptionsData;
		bool flag3;
		for (; enumerator.MoveNext(); flag2 = playerOptionsData == null, Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdi_v4 (System.Object)+10]"), flag3 = (nint)0 == 0, Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdi_v4 (System.Object)+10]"), GameObject.SetActive_Injected((IntPtr)0, playerOptionsData._003CShowSmallMapIcons_003Ek__BackingField))
		{
			object obj = null;
			PlayerOptions playerOptions = _playerOptions;
			bool flag = _playerOptions == null;
			if (playerOptions._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions._hostGameConfig == null)
				{
					if (playerOptions._currentAdventureSaveData != null)
					{
						playerOptionsData = playerOptions._currentAdventureSaveData;
						if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							continue;
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
		}
	}

	public void ReduceAlphaOnArcanaInfoShown()
	{
		_CanvasGroup.alpha = _AlphaWhileArcanaInfoShown;
	}

	public void ResetToDefaultAlpha()
	{
		_CanvasGroup.alpha = 1f;
	}

	private bool IsMinorItem(Pickup pickupItem)
	{
		if ((object)pickupItem != null && ((UnityEngine.Object)pickupItem).m_CachedPtr != (IntPtr)0 && _minorItemTypes != null)
		{
			return Enumerable.Contains((IEnumerable<System.Int32Enum>)(object)_minorItemTypes, (System.Int32Enum)pickupItem._003CPickupType_003Ek__BackingField);
		}
		return false;
	}

	private List<Pickup> GetAllWorldItems()
	{
		return PickupManager.GetAllPickupsOfTypes(_minorItemTypes);
	}

	public void ZoomIn()
	{
		float num = _manualZoomFactor - _manualZoomStep;
		float manualZoomFactor = _manualZoomInCap;
		if (_manualZoomInCap < num)
		{
			manualZoomFactor = num;
		}
		_manualZoomFactor = manualZoomFactor;
		Populate();
	}

	public void ZoomOut()
	{
		float num = _manualZoomStep + _manualZoomFactor;
		float manualZoomFactor = _manualZoomOutCap;
		if (_manualZoomOutCap > num)
		{
			manualZoomFactor = num;
		}
		_manualZoomFactor = manualZoomFactor;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 22 Invalid \"Jump target not found in method: 0x186D12220\"");
	}

	public void Populate()
	{
		//IL_007c: Expected O, but got I
		//IL_0091: Expected O, but got I
		//IL_015e: Expected F4, but got O
		//IL_0184: Expected F4, but got I4
		//IL_01e1: Expected O, but got I
		//IL_01f8: Expected O, but got I
		//IL_029e: Expected O, but got I
		//IL_02b3: Expected O, but got I
		//IL_02ed: Expected O, but got I
		//IL_04a6->IL04a6: Incompatible stack heights: 2 vs 0
		//IL_0139->IL04b7: Incompatible stack heights: 2 vs 1
		//IL_01fe->IL01fe: Incompatible stack heights: 2 vs 1
		//IL_02d8->IL03ad: Incompatible stack heights: 2 vs 1
		//IL_03ad->IL03ad: Incompatible stack heights: 2 vs 1
		//IL_0569->IL0569: Incompatible stack heights: 4 vs 1
		//IL_0385->IL03ad: Incompatible stack heights: 2 vs 1
		float num;
		ItemType itemType = default(ItemType);
		while (true)
		{
			ClearIcons();
			ClearGrid();
			Dictionary<StageType, List<StageData>> convertedStages = _data.GetConvertedStages();
			PlayerOptionsData config = _playerOptions.Config;
			object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).get_Item((System.Int32Enum)config._003CSelectedStage_003Ek__BackingField);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v8 (System.Object)+18]");
			bool flag = (nint)0 <= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v8 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rax_v11+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rax_v11+20]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v575 @ rax_v14+148]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v8 (System.Object)+18]");
					bool flag2 = (nint)0 <= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v575 @ rax_v14+148]");
					if ((nint)0 != 0)
					{
						num = 0.17f / (float)itemType;
						break;
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
					continue;
				}
			}
			num = 0.5f;
			break;
		}
		_zoom = num;
		float zoom = _manualZoomFactor * num;
		_zoom = zoom;
		RectTransform component = GetComponent<RectTransform>();
		Vector2 sizeDelta = component.sizeDelta;
		_width = (float)sizeDelta;
		RectTransform component2 = GetComponent<RectTransform>();
		Vector2 sizeDelta2 = component2.sizeDelta;
		_height = (float)itemType;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v8 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v8 (System.Object)+18]");
			bool flag3 = (nint)0 <= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v8 (System.Object)+10]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdx_v37+20]");
			InitDetailedMap((StageData)0);
		}
		MakeGrid();
		AddMinorItems();
		AddTreasureChests();
		AddStagePickups();
		AddMapTokens();
		AddEventTargets();
		AddPickupFadingTweens();
		AddPlayers();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v8 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v8 (System.Object)+18]");
			bool flag4 = (nint)0 <= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v8 (System.Object)+10]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v57+20]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rcx_v43+B0]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rcx_v43+B0]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v58+6C]");
				if ((nint)0 != 0)
				{
					GameManager core = GM.Core;
					PlayerOptionsData config2 = core._playerOptions.Config;
					if (config2.HasCollectedItem(itemType))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96630");
						StageData stageData = default(StageData);
						ShowDetailedMap(stageData);
						goto IL_0569;
					}
				}
				GameObject gameObject = _DetailedMapContainer.gameObject;
				gameObject.SetActive(value: false);
			}
		}
		goto IL_0569;
		IL_0569:
		List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
		bool flag6;
		PlayerOptionsData playerOptionsData;
		bool flag7;
		for (; enumerator.MoveNext(); flag6 = playerOptionsData == null, Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v708 @ rsi_v7 (System.Object)+10]"), flag7 = (nint)0 == 0, Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v708 @ rsi_v7 (System.Object)+10]"), GameObject.SetActive_Injected((IntPtr)0, playerOptionsData._003CShowSmallMapIcons_003Ek__BackingField))
		{
			object obj8 = null;
			PlayerOptions playerOptions = _playerOptions;
			bool flag5 = _playerOptions == null;
			if (playerOptions._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions._hostGameConfig == null)
				{
					if (playerOptions._currentAdventureSaveData != null)
					{
						playerOptionsData = playerOptions._currentAdventureSaveData;
						if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							continue;
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
		}
	}

	private void AddPickupFadingTweens()
	{
		//IL_017b: Expected O, but got I4
		//IL_01cf: Expected I4, but got I8
		//IL_00d1: Expected I, but got O
		List<GameObject> smallSprites = _smallSprites;
		if (_smallSprites != null)
		{
			if (smallSprites._size <= 0)
			{
				return;
			}
			List<Image> list = new List<Image>();
			if (_smallSprites != null)
			{
				List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
				while (enumerator.MoveNext())
				{
					Image image = null;
					if ((object)image != null && ((UnityEngine.Object)image).m_CachedPtr != (IntPtr)0)
					{
						bool flag = list == null;
						nint num = (nint)typeof(UnityEngine.Object);
						if (flag)
						{
							throw new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A77500");
					}
				}
				if (list != null)
				{
					Image[] targets = list.ToArray();
					if (_pickupFadeTweens != null)
					{
						_pickupFadeTweens.Kill();
					}
					TweenConfig tweenConfig = new TweenConfig();
					if (tweenConfig != null)
					{
						tweenConfig.targets = targets;
						tweenConfig.alpha = (float?)(object)1;
						tweenConfig.yoyo = true;
						Func<int, float> staggerDelay = Tweens.Stagger(500f);
						tweenConfig.staggerDelay = staggerDelay;
						tweenConfig.duration = 1000f;
						tweenConfig.repeat = -1;
						MultiTargetTween pickupFadeTweens = Tweens.Add(tweenConfig);
						_pickupFadeTweens = pickupFadeTweens;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void DrawMapBackground(StageData stageData)
	{
		GameObject gameObject = _MapStaticBackgroundImage.gameObject;
		gameObject.SetActive(value: false);
		GameManager core = GM.Core;
		Stage stage = core._stage;
		BackgroundManager fancyBg = stage._fancyBg;
		bool flag = (object)stage._fancyBg == null;
		string text = "";
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)fancyBg).m_CachedPtr == (IntPtr)0;
			text = "";
			if (!flag2)
			{
				GameManager core2 = GM.Core;
				Stage stage2 = core2._stage;
				string detailedMapStaticBackgroundImage = stage2._fancyBg.GetDetailedMapStaticBackgroundImage(stageData);
				text = detailedMapStaticBackgroundImage;
			}
		}
		if (text != null && text._stringLength > 0)
		{
			Sprite sprite = SpriteManager.GetSprite(text);
			_MapStaticBackgroundImage.sprite = sprite;
			Image mapStaticBackgroundImage = _MapStaticBackgroundImage;
			if ((object)_MapStaticBackgroundImage != null && ((UnityEngine.Object)mapStaticBackgroundImage).m_CachedPtr != (IntPtr)0)
			{
				GameObject gameObject2 = _MapStaticBackgroundImage.gameObject;
				gameObject2.SetActive(value: true);
			}
		}
	}

	private unsafe void MakeGrid()
	{
		//IL_099c: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a1: Expected O, but got Unknown
		//IL_09a5: Unsupported input type for neg.
		//IL_09a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09aa: Expected O, but got Unknown
		//IL_09b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b8: Expected O, but got Unknown
		//IL_0634: Unsupported input type for neg.
		//IL_0634: Unknown result type (might be due to invalid IL or missing references)
		//IL_0639: Expected O, but got Unknown
		//IL_04fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0502: Expected O, but got Unknown
		//IL_0661: Unknown result type (might be due to invalid IL or missing references)
		//IL_0666: Expected O, but got Unknown
		//IL_055b: Expected O, but got I4
		//IL_060f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0614: Expected O, but got Unknown
		//IL_05b8: Expected O, but got I
		//IL_0743: Unknown result type (might be due to invalid IL or missing references)
		//IL_0748: Expected O, but got Unknown
		//IL_0a21: Expected O, but got Ref
		//IL_0a2e: Expected O, but got I
		//IL_0892->IL0765: Incompatible stack heights: 1 vs 0
		//IL_0423->IL0765: Incompatible stack heights: 1 vs 0
		//IL_0653->IL0764: Incompatible stack heights: 1 vs 0
		//IL_0ae9->IL0765: Incompatible stack heights: 1 vs 0
		//IL_0bc2->IL0765: Incompatible stack heights: 1 vs 0
		//IL_0ba4->IL0765: Incompatible stack heights: 1 vs 0
		//IL_0578->IL0765: Incompatible stack heights: 1 vs 0
		//IL_048c->IL0765: Incompatible stack heights: 1 vs 0
		//IL_06cf->IL0765: Incompatible stack heights: 1 vs 0
		//IL_04bb->IL0765: Incompatible stack heights: 1 vs 0
		//IL_04e5->IL0765: Incompatible stack heights: 1 vs 0
		//IL_0764->IL0764: Incompatible stack heights: 1 vs 0
		//IL_0a33->IL0897: Incompatible stack heights: 2 vs 1
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null)
			{
				object fancyBg = stage._fancyBg;
				if ((object)stage._fancyBg != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rbx_v6 (System.Object)+10]");
					if ((nint)0 != 0)
					{
						GameManager core2 = GM.Core;
						if ((object)GM.Core != null)
						{
							Stage stage2 = core2._stage;
							if ((object)core2._stage != null && (object)stage2._fancyBg != null)
							{
								if (stage2._fancyBg.GetMap_DrawGrid())
								{
									goto IL_011d;
								}
								return;
							}
						}
						goto IL_0765;
					}
				}
				goto IL_011d;
			}
		}
		goto IL_0765;
		IL_0897:
		float num = _zoom * _width;
		float num2 = _width * 0.5f;
		float num4;
		float num3 = num4 * 100f;
		float num5 = num3 / num;
		float num6 = num5 * 9.625f;
		float num7 = num6 * _mapRatioX;
		float num8 = num2 / num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
		float num9 = _zoom * _height;
		float num11;
		float num10 = num11 * 100f;
		float num12 = num10 / num9;
		float num13 = _height * 0.5f;
		float num14 = num12 * 9.625f;
		float num15 = num14 * _mapRatioX;
		float num16 = num13 / num15;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
		object obj2 = default(object);
		object obj = obj2 + 2;
		object obj3 = 0 - obj2;
		object obj5 = default(object);
		object obj4 = obj5 + 1;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
		{
			goto IL_0630;
		}
		object obj7;
		object obj6 = obj7 ^ -0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
		float num17 = num4 * 100f;
		while (true)
		{
			float num18 = _zoom * _width;
			List<object> gridLines = (List<object>)(object)_gridLines;
			float num19 = (float)obj3 * num4;
			float num20 = num19 + (float)obj6;
			float num21 = num20 / num4;
			float num22 = num21 * num17;
			float num23 = num22 / num18;
			float num24 = num23 * 9.625f;
			num7 = num24 * _mapRatioX;
			GameObject gameObject = MakeGridLine(vertical: true, num7);
			if (_gridLines == null)
			{
				break;
			}
			int version = gridLines._version + 1;
			gridLines._version = version;
			MultiplayerManager items = (MultiplayerManager)(object)gridLines._items;
			object obj8 = gridLines._size;
			if (gridLines._items == null)
			{
				break;
			}
			if (gridLines._size >= (nint)items._signalBus)
			{
				((List<object>)(object)_gridLines).AddWithResize((object)gameObject);
				GameObject gameObject2 = (GameObject)0;
				obj8 = gameObject;
				items = (MultiplayerManager)(object)_gridLines;
			}
			else
			{
				int size = gridLines._size + 1;
				gridLines._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				GameObject gameObject2 = gameObject;
			}
			obj3++;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
			{
				continue;
			}
			goto IL_0630;
		}
		goto IL_0765;
		IL_011d:
		GameManager core3 = GM.Core;
		GameManager core5;
		if ((object)GM.Core != null)
		{
			Stage stage3 = core3._stage;
			if ((object)core3._stage != null)
			{
				object tilingTileset = stage3._tilingTileset;
				if ((object)stage3._tilingTileset != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rbx_v9 (System.Object)+10]");
					if ((nint)0 != 0)
					{
						GameManager core4 = GM.Core;
						if ((object)GM.Core != null)
						{
							Stage stage4 = core4._stage;
							if ((object)core4._stage != null)
							{
								TilingTileset tilingTileset2 = stage4._tilingTileset;
								if ((object)stage4._tilingTileset != null)
								{
									num4 = tilingTileset2._sizeX;
									core5 = GM.Core;
									goto IL_0289;
								}
							}
						}
						goto IL_0765;
					}
				}
				core5 = GM.Core;
				bool flag = (object)GM.Core == null;
				num4 = 20.48f;
				if (!flag)
				{
					goto IL_0289;
				}
			}
		}
		goto IL_0765;
		IL_0765:
		throw new NullReferenceException();
		IL_0811:
		GameSessionData session = _session;
		if (_session != null && (object)session._activeCharacter != null)
		{
			Transform transform = session._activeCharacter.transform;
			if ((object)transform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v36 (UnityEngine.Transform)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v36 (UnityEngine.Transform)+10]");
				Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
				GameManager core6 = GM.Core;
				if ((object)GM.Core != null)
				{
					MultiplayerManager items = core6._multiplayer;
					if (core6._multiplayer != null)
					{
						bool isOnlineMultiplayer = core6._multiplayer.IsOnlineMultiplayer;
						bool flag3 = !isOnlineMultiplayer;
						obj7 = ret;
						object obj8 = null;
						if (flag3)
						{
							goto IL_0897;
						}
						if ((object)OnlineStageManager._instance != null)
						{
							int mySeatNumber = OnlineStageManager._instance.GetMySeatNumber();
							if ((object)OnlineStageManager._instance != null)
							{
								VampireSurvivors.Objects.Characters.CharacterController characterForSeatNumber = OnlineStageManager._instance.GetCharacterForSeatNumber(mySeatNumber);
								if ((object)characterForSeatNumber != null)
								{
									Transform transform2 = characterForSeatNumber.transform;
									if ((object)transform2 != null)
									{
										bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
										Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
										obj7 = ret;
										GameObject gameObject2 = null;
										obj8 = (object)(&ret);
										items = (MultiplayerManager)(nint)((UnityEngine.Object)transform2).m_CachedPtr;
										goto IL_0897;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0765;
		IL_0289:
		Stage stage5 = core5._stage;
		if ((object)core5._stage == null)
		{
			goto IL_0765;
		}
		object tilingTileset3 = stage5._tilingTileset;
		bool flag5 = (object)stage5._tilingTileset == null;
		num11 = 20.48f;
		if (!flag5)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rbx_v10 (System.Object)+10]");
			bool flag6 = (nint)0 == 0;
			num11 = 20.48f;
			if (!flag6)
			{
				GameManager core7 = GM.Core;
				if ((object)GM.Core != null)
				{
					Stage stage6 = core7._stage;
					if ((object)core7._stage != null)
					{
						TilingTileset tilingTileset4 = stage6._tilingTileset;
						if ((object)stage6._tilingTileset != null)
						{
							num11 = tilingTileset4._sizeY;
							goto IL_0811;
						}
					}
				}
				goto IL_0765;
			}
		}
		goto IL_0811;
		IL_0630:
		object obj9 = 0 - obj4;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
		{
			return;
		}
		object obj11 = default(object);
		object obj10 = obj11 ^ -0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
		float num25 = num11 * 100f;
		while (true)
		{
			float num26 = _zoom * _height;
			List<object> gridLines2 = (List<object>)(object)_gridLines;
			float num27 = (float)obj9 * num11;
			float num28 = num27 + (float)obj10;
			float num29 = num28 / num11;
			float num30 = num29 * num25;
			float num31 = num30 / num26;
			float num32 = num31 * 9.625f;
			float pos = num32 * _mapRatioY;
			GameObject item = MakeGridLine(vertical: false, pos);
			if (_gridLines == null)
			{
				break;
			}
			int version2 = gridLines2._version + 1;
			gridLines2._version = version2;
			object[] items2 = gridLines2._items;
			if (gridLines2._items == null)
			{
				break;
			}
			if (gridLines2._size >= items2.Length)
			{
				((List<object>)(object)_gridLines).AddWithResize((object)item);
			}
			else
			{
				int size2 = gridLines2._size + 1;
				gridLines2._size = size2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			obj9++;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
			{
				return;
			}
		}
		goto IL_0765;
	}

	private unsafe GameObject MakeGridLine(bool vertical, float pos)
	{
		//IL_00f4: Expected O, but got Ref
		string spriteName = default(string);
		Image image = RenderingExtensions.AddImage(_Grid, 0f, 0f, "UI", spriteName);
		if ((object)image != null)
		{
			RectTransform rectTransform = image.rectTransform;
			if (vertical)
			{
			}
			if ((object)rectTransform != null)
			{
				Vector2 vector = default(Vector2);
				rectTransform.sizeDelta = vector;
				float yScale;
				float xScale;
				if (vertical)
				{
					yScale = _height;
					xScale = 1f;
				}
				else
				{
					xScale = _width;
					yScale = 1f;
				}
				Image image2 = RenderingExtensions.SetScale(image, xScale, yScale);
				Color color = image.color;
				object obj = default(object);
				image.color = (Color)(&obj);
				RectTransform rectTransform2 = image.rectTransform;
				Vector2 anchoredPosition = ((!vertical) ? vector : vector);
				if ((object)rectTransform2 != null)
				{
					rectTransform2.anchoredPosition = anchoredPosition;
					return image.gameObject;
				}
			}
		}
		return (GameObject)(object)new NullReferenceException();
	}

	private unsafe void AddMinorItems()
	{
		//IL_00e0: Expected O, but got Ref
		List<GameObject> smallSprites = _smallSprites;
		int version = smallSprites._version + 1;
		smallSprites._version = version;
		smallSprites._size = 0;
		if (smallSprites._size > 0)
		{
			Array.Clear(smallSprites._items, 0, smallSprites._size);
		}
		List<Pickup> allPickupsOfTypes = PickupManager.GetAllPickupsOfTypes(_minorItemTypes);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047EF80");
		Pickup pickup = null;
		List<Pickup> list = allPickupsOfTypes;
		List<Pickup>.Enumerator enumerator = default(List<Pickup>.Enumerator);
		if (enumerator.MoveNext())
		{
			Pickup pickup2 = null;
			DataManager data = _data;
			bool flag = _data == null;
			List<Pickup>.Enumerator enumerator2 = (List<Pickup>.Enumerator)(&enumerator);
			if (!flag)
			{
				enumerator2 = (List<Pickup>.Enumerator)data._003CAllItems_003Ek__BackingField;
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
	}

	private unsafe void AddPlayers()
	{
		//IL_00dc: Expected O, but got I4
		//IL_0122: Expected O, but got I4
		//IL_0153: Expected O, but got I4
		//IL_022a: Expected I, but got O
		//IL_0332->IL0293: Incompatible stack heights: 1 vs 0
		//IL_0251->IL0313: Incompatible stack heights: 2 vs 1
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		IEnumerable<PlayerInfo> enumerable = OnlineStageManager._instance.IterateSeats();
		bool flag = enumerable == null;
		List<object> list = new List<object>(enumerable);
		int num = 0;
		int num2 = 0;
		List<PlayerInfo> list2 = default(List<PlayerInfo>);
		PlayerInfo playerInfo = default(PlayerInfo);
		PlayerInfo playerInfo2 = default(PlayerInfo);
		Sprite s = default(Sprite);
		Vector2 vector = default(Vector2);
		float value = default(float);
		float num6 = default(float);
		while (num2 < list._size)
		{
			int mySeatNumber = OnlineStageManager._instance.GetMySeatNumber();
			if (num != mySeatNumber)
			{
				((List<PlayerInfo>)(object)list)._002Ector((IEnumerable<PlayerInfo>)num);
				if (list2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v685 @ rax_v26 (System.Collections.Generic.List`1<VampireSurvivors.PlayerInfo>)+10]");
					if ((nint)0 != 0)
					{
						((List<PlayerInfo>)(object)list)._002Ector((IEnumerable<PlayerInfo>)num);
						VampireSurvivors.Objects.Characters.CharacterController characterController = playerInfo.CharacterController;
						float2 position = characterController.position;
						((List<PlayerInfo>)(object)list)._002Ector((IEnumerable<PlayerInfo>)num);
						VampireSurvivors.Objects.Characters.CharacterController characterController2 = playerInfo2.CharacterController;
						float2 position2 = characterController2.position;
						GameObject gameObject = SpawnItemOnMap(s, vector);
						float num4;
						if ((bool)gameObject)
						{
							Transform transform = gameObject.transform;
							Vector3 localScale = transform.localScale;
							float num3 = (float)vector / 1.5f;
							num4 = localScale.z / 1.5f;
							bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
							Image component = gameObject.GetComponent<Image>();
							Image component2 = gameObject.GetComponent<Image>();
							Color slotColor = ((MultiplayerManager)(object)component2).GetSlotColor(num);
							nint num5 = (nint)component;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v83 @ r9_v4 (Il2CppClass<System.Collections.Generic.IEnumerable`1<VampireSurvivors.PlayerInfo>>)+2A8] (should have been resolved before IL gen)");
							num++;
							num2 = num;
							continue;
						}
						Debug.LogWarning("Couldn't spawn player item on map!");
						num4 = num6;
						float num7 = 1f;
					}
				}
			}
			num++;
			num2 = num;
		}
	}

	private bool ShouldSkipDrawingPickup(Pickup pickupItem, Dictionary<int2, int> positionBuckets)
	{
		//IL_011a: Expected I4, but got O
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected I4, but got Unknown
		if ((object)pickupItem != null)
		{
			float2 cachedPosition = pickupItem.cachedPosition;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			object obj = default(object);
			float num = (float)obj * 0.2f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			if (positionBuckets != null)
			{
				int num2 = positionBuckets.FindEntry((int2)cachedPosition);
				if (num2 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9FE40");
					object obj2 = default(object);
					if ((nint)obj2 <= 5)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9FE40");
						object obj3 = default(object);
						int value = obj3 + 1;
						bool flag = positionBuckets.TryInsert((int2)cachedPosition, value, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
						return false;
					}
					return true;
				}
				bool flag2 = positionBuckets.TryInsert((int2)cachedPosition, 1, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				return false;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe void AddTreasureChests()
	{
		//IL_004f: Expected O, but got Ref
		ItemType[] types = new ItemType[1];
		_ = 8;
		List<Pickup> allPickupsOfTypes = PickupManager.GetAllPickupsOfTypes(types);
		List<Pickup>.Enumerator enumerator = default(List<Pickup>.Enumerator);
		if (enumerator.MoveNext())
		{
			Component component = null;
			DataManager data = _data;
			bool flag = _data == null;
			List<Pickup>.Enumerator enumerator2 = (List<Pickup>.Enumerator)(&enumerator);
			if (!flag)
			{
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
	}

	private void AddStagePickups()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047EF80");
		List<Pickup>.Enumerator enumerator = default(List<Pickup>.Enumerator);
		while (enumerator.MoveNext())
		{
			Pickup pickup = null;
			if (!ShouldSkipDrawingPickup(null, _positionBuckets))
			{
				_003C_003Ec__DisplayClass61_0 obj = (_003C_003Ec__DisplayClass61_0)"";
				throw new NullReferenceException();
			}
		}
	}

	private unsafe void AddMapTokens()
	{
		//IL_0013: Expected O, but got I4
		//IL_002e: Expected O, but got I4
		//IL_0036: Expected O, but got Ref
		GameManager core = GM.Core;
		object obj = 0;
		List<MapToken>.Enumerator mapTokens = (List<MapToken>.Enumerator)core._mapTokens;
		List<MapToken>.Enumerator enumerator = default(List<MapToken>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj2 = 0;
			List<MapToken>.Enumerator enumerator2 = (List<MapToken>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	private void AddEventTargets()
	{
		GameManager core = GM.Core;
		if ((object)GM.Core == null || ((UnityEngine.Object)core).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		GameManager core2 = GM.Core;
		Stage stage = core2._stage;
		if ((object)core2._stage == null || ((UnityEngine.Object)stage).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		GameManager core3 = GM.Core;
		Stage stage2 = core3._stage;
		if (stage2._stageEventManager != null)
		{
			GameManager core4 = GM.Core;
			Stage stage3 = core4._stage;
			StageEventManager stageEventManager = stage3._stageEventManager;
			List<StageEventManager.EventTargetInstace>.Enumerator enumerator = default(List<StageEventManager.EventTargetInstace>.Enumerator);
			if (stageEventManager._eventTargets != null && enumerator.MoveNext())
			{
				Sprite sprite = SpriteManager.GetSprite("ExclamationMark", "UI");
				throw new NullReferenceException();
			}
		}
	}

	private unsafe GameObject SpawnItemOnMap(Sprite s, Vector2 tPos, float scale = 1f)
	{
		//IL_0008: Expected O, but got Ref
		//IL_045a: Expected O, but got Ref
		//IL_010c: Expected O, but got Ref
		//IL_04e7: Expected O, but got I
		//IL_07ad: Invalid comparison between I4 and F4
		//IL_0611: Expected O, but got I
		//IL_07e6: Invalid comparison between I4 and F4
		//IL_073d: Expected O, but got Ref
		//IL_05a6: Expected O, but got Ref
		//IL_06dd: Expected O, but got Ref
		//IL_04a8->IL03cd: Incompatible stack heights: 1 vs 0
		//IL_01e6->IL03cd: Incompatible stack heights: 1 vs 0
		//IL_07d8->IL03cd: Incompatible stack heights: 1 vs 0
		//IL_0242->IL03cd: Incompatible stack heights: 1 vs 0
		//IL_02ef->IL03cd: Incompatible stack heights: 1 vs 0
		//IL_0271->IL03cd: Incompatible stack heights: 1 vs 0
		//IL_0319->IL03cd: Incompatible stack heights: 1 vs 0
		//IL_029b->IL03cd: Incompatible stack heights: 1 vs 0
		//IL_0355->IL03cd: Incompatible stack heights: 1 vs 0
		//IL_07a4->IL0819: Incompatible stack heights: 6 vs 0
		//IL_05d7->IL04ad: Incompatible stack heights: 2 vs 1
		//IL_072f->IL07f8: Incompatible stack heights: 2 vs 1
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameManager core = GM.Core;
		GameObject gameObject = default(GameObject);
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null)
			{
				Transform fancyBg = (Transform)(object)stage._fancyBg;
				if ((object)stage._fancyBg == null || ((UnityEngine.Object)fancyBg).m_CachedPtr == (IntPtr)0)
				{
					goto IL_0145;
				}
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null)
				{
					Stage stage2 = core2._stage;
					if ((object)core2._stage != null && (object)stage2._fancyBg != null)
					{
						Vector3 worldPosition = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
						_ = 0;
						if (stage2._fancyBg.ShouldShowPickupIconOnMap(worldPosition))
						{
							goto IL_0145;
						}
						gameObject = null;
						goto IL_0819;
					}
				}
			}
		}
		goto IL_03cd;
		IL_04ad:
		float num = _width;
		float num2 = _width * _zoom;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-29]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-31]");
		object obj3 = num3 - 0;
		float num4 = _width * 0.5f;
		float num5 = (float)obj3 * 100f;
		float num6 = num5 / num2;
		float num7 = num6 * 9.625f;
		float num8 = num7 * _mapRatioX;
		float num9 = num4 - num8;
		if (_width > num9)
		{
			num = num9;
		}
		if (0f < num)
		{
			goto IL_07bf;
		}
		float num10 = _height;
		float num11 = _height * _zoom;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-25]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-2D]");
		object obj4 = num12 - 0;
		float num13 = _height * 0.5f;
		float num14 = (float)obj4 * 100f;
		float num15 = num14 / num11;
		float num16 = num15 * 9.625f;
		float num17 = num16 * _mapRatioY;
		float num18 = num13 - num17;
		if (_height > num18)
		{
			num10 = num18;
		}
		if (!(0f < num10))
		{
			gameObject = UnityEngine.Object.Instantiate(parent: base.transform, original: _MapIcon);
			if ((object)gameObject != null)
			{
				RectTransform component = gameObject.GetComponent<RectTransform>();
				if ((object)component != null)
				{
					Vector2 anchoredPosition = default(Vector2);
					component.anchoredPosition = anchoredPosition;
					Image component2 = component.GetComponent<Image>();
					if ((object)component2 != null)
					{
						component2.sprite = s;
						_ = 0;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rax_v53 (UnityEngine.RectTransform)+10]");
						bool flag = (nint)0 == 0;
						object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rax_v53 (UnityEngine.RectTransform)+10]");
						Transform.get_localScale_Injected((IntPtr)0, out *(Vector3*)obj5);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-25]");
						float num19 = 0f * scale;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-21]");
						float num20 = 0f * scale;
						goto IL_07f8;
					}
				}
			}
			goto IL_03cd;
		}
		goto IL_07f8;
		IL_0145:
		GameSessionData session = _session;
		if (_session != null && (object)session._activeCharacter != null)
		{
			Transform transform = session._activeCharacter.transform;
			if ((object)transform != null)
			{
				_ = 0;
				_ = 0;
				bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj6);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-9]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-11]");
				_ = 0;
				GameManager core3 = GM.Core;
				if ((object)GM.Core != null && core3._multiplayer != null)
				{
					if (!core3._multiplayer.IsOnlineMultiplayer)
					{
						goto IL_04ad;
					}
					goto IL_07bf;
				}
			}
		}
		goto IL_03cd;
		IL_03cd:
		throw new NullReferenceException();
		IL_07f8:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rax_v53 (UnityEngine.RectTransform)+10]");
		bool flag3 = (nint)0 == 0;
		object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rax_v53 (UnityEngine.RectTransform)+10]");
		Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj7);
		bool flag4 = _spawned == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
		bool flag5 = (object)_Player == null;
		Transform transform2 = _Player.transform;
		bool flag6 = (object)transform2 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1210 @ rax_v67 (UnityEngine.Transform)+10]");
		bool flag7 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1210 @ rax_v67 (UnityEngine.Transform)+10]");
		Transform.SetAsLastSibling_Injected((IntPtr)0);
		goto IL_0819;
		IL_07bf:
		if ((object)OnlineStageManager._instance != null)
		{
			int mySeatNumber = OnlineStageManager._instance.GetMySeatNumber();
			if ((object)OnlineStageManager._instance != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterForSeatNumber = OnlineStageManager._instance.GetCharacterForSeatNumber(mySeatNumber);
				if ((object)characterForSeatNumber != null)
				{
					Transform transform3 = characterForSeatNumber.transform;
					if ((object)transform3 != null)
					{
						_ = 0;
						_ = 0;
						bool flag8 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
						object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
						Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Vector3*)obj8);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-11]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-9]");
						_ = 0;
						goto IL_04ad;
					}
				}
			}
		}
		goto IL_03cd;
		IL_0819:
		return gameObject;
	}

	private void ClearIcons()
	{
		//IL_00a3: Expected I4, but got O
		MultiTargetTween pickupFadeTweens = _pickupFadeTweens;
		if (_pickupFadeTweens != null)
		{
			_pickupFadeTweens.Kill();
		}
		_pickupFadeTweens = null;
		if (_spawned != null)
		{
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			while (enumerator.MoveNext())
			{
				UnityEngine.Object.Destroy(null, 0f);
			}
			pickupFadeTweens = (MultiTargetTween)(object)_spawned;
			if (_spawned != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rcx_v4 (VampireSurvivors.Framework.PhaserTweens.MultiTargetTween)+1C]");
				_ = (nint)0 + (nint)1;
				pickupFadeTweens.delays = null;
				if ((nint)pickupFadeTweens.delays > 0)
				{
					Array.Clear((Array)(object)pickupFadeTweens.tweens, 0, (int)pickupFadeTweens.delays);
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void ClearGrid()
	{
		//IL_0087: Expected I4, but got O
		//IL_0087: Expected O, but got I
		bool flag = _gridLines == null;
		MapManager mapManager = this;
		if (!flag)
		{
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			while (enumerator.MoveNext())
			{
				UnityEngine.Object.Destroy(null, 0f);
			}
			mapManager = (MapManager)(object)_gridLines;
			if (_gridLines != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rcx_v2 (VampireSurvivors.UI.MapManager)+1C]");
				_ = (nint)0 + (nint)1;
				((MonoBehaviour)mapManager).m_CancellationTokenSource = null;
				if ((nint)((MonoBehaviour)mapManager).m_CancellationTokenSource > 0)
				{
					Array.Clear((Array)(nint)((UnityEngine.Object)mapManager).m_CachedPtr, 0, (int)((MonoBehaviour)mapManager).m_CancellationTokenSource);
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void InitMultiMaps(StageData stageData)
	{
		//IL_0526->IL03fc: Incompatible stack heights: 1 vs 0
		//IL_058d->IL03fc: Incompatible stack heights: 2 vs 0
		//IL_0267->IL03fc: Incompatible stack heights: 2 vs 0
		//IL_0296->IL03fc: Incompatible stack heights: 2 vs 0
		//IL_02db->IL03fc: Incompatible stack heights: 2 vs 0
		//IL_032b->IL03fc: Incompatible stack heights: 2 vs 0
		//IL_035a->IL03fc: Incompatible stack heights: 2 vs 0
		//IL_0614->IL044c: Incompatible stack heights: 2 vs 0
		//IL_03c7->IL03fc: Incompatible stack heights: 2 vs 0
		//IL_03e9->IL03fc: Incompatible stack heights: 2 vs 0
		_mapRatioY = 1f;
		_mapRatioX = 1f;
		_mapSpriteHeight = 512f;
		_mapSpriteWidth = 512f;
		string text;
		if (stageData != null)
		{
			if (stageData._003Ctileset_003Ek__BackingField == null)
			{
				return;
			}
			Tileset tileset = stageData._003Ctileset_003Ek__BackingField;
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				Stage stage = core._stage;
				if ((object)core._stage != null)
				{
					BackgroundManager fancyBg = stage._fancyBg;
					bool flag = (object)stage._fancyBg == null;
					text = tileset._003CdetailsTexture_003Ek__BackingField;
					if (!flag)
					{
						bool flag2 = ((UnityEngine.Object)fancyBg).m_CachedPtr == (IntPtr)0;
						text = tileset._003CdetailsTexture_003Ek__BackingField;
						if (!flag2)
						{
							GameManager core2 = GM.Core;
							if ((object)GM.Core != null)
							{
								Stage stage2 = core2._stage;
								if ((object)core2._stage != null && (object)stage2._fancyBg != null)
								{
									string detailedMap = stage2._fancyBg.GetDetailedMap(stageData);
									text = detailedMap;
									goto IL_0481;
								}
							}
							goto IL_03fc;
						}
					}
					goto IL_0481;
				}
			}
		}
		goto IL_03fc;
		IL_03fc:
		throw new NullReferenceException();
		IL_0481:
		if (text == null || text._stringLength <= 0)
		{
			return;
		}
		Sprite sprite = SpriteManager.GetSprite(text);
		_detailedMapSprite = sprite;
		Sprite detailedMapSprite = _detailedMapSprite;
		if ((object)_detailedMapSprite == null || ((UnityEngine.Object)detailedMapSprite).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		object detailedMapSprite2 = _detailedMapSprite;
		if ((object)_detailedMapSprite != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdi_v11 (System.Object)+10]");
			bool flag3 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdi_v11 (System.Object)+10]");
			Sprite.get_rect_Injected((IntPtr)0, out Rect _);
			object detailedMapSprite3 = _detailedMapSprite;
			float mapSpriteWidth = default(float);
			_mapSpriteWidth = mapSpriteWidth;
			if ((object)_detailedMapSprite != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v12 (System.Object)+10]");
				bool flag4 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v12 (System.Object)+10]");
				Sprite.get_rect_Injected((IntPtr)0, out Rect _);
				float mapSpriteHeight = default(float);
				_mapSpriteHeight = mapSpriteHeight;
				GameManager core3 = GM.Core;
				if ((object)GM.Core != null)
				{
					Stage stage3 = core3._stage;
					if ((object)core3._stage != null)
					{
						TilingTileset tilingTileset = stage3._tilingTileset;
						if ((object)stage3._tilingTileset != null)
						{
							GameManager core4 = GM.Core;
							Stage stage4 = core4._stage;
							SuperMap defaultMap = stage4._tilingTileset.DefaultMap;
							if ((object)defaultMap != null)
							{
								float num = tilingTileset._sizeX * 100f;
								GameManager core5 = GM.Core;
								float num2 = num / (float)defaultMap.m_TileWidth;
								if ((object)GM.Core != null)
								{
									Stage stage5 = core5._stage;
									if ((object)core5._stage != null)
									{
										object fancyBg2 = stage5._fancyBg;
										if ((object)stage5._fancyBg != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdi_v13 (System.Object)+10]");
											if ((nint)0 != 0)
											{
												GameManager core6 = GM.Core;
												if ((object)GM.Core == null || (object)core6._stage == null)
												{
													goto IL_03fc;
												}
												num2 = 51200f;
											}
										}
										float num3 = 512f / _mapSpriteHeight;
										float num4 = _mapSpriteWidth / num2;
										float num5 = num4 / 1.6f;
										_mapRatioX = (_mapRatioY = num3 * num5);
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_03fc;
	}

	private void InitDetailedMap(StageData stageData)
	{
		//IL_048e->IL0364: Incompatible stack heights: 1 vs 0
		//IL_04f5->IL0364: Incompatible stack heights: 2 vs 0
		//IL_0267->IL0364: Incompatible stack heights: 2 vs 0
		//IL_0296->IL0364: Incompatible stack heights: 2 vs 0
		//IL_02db->IL0364: Incompatible stack heights: 2 vs 0
		//IL_0364->IL03b4: Incompatible stack heights: 2 vs 0
		_mapRatioY = 1f;
		_mapRatioX = 1f;
		_mapSpriteHeight = 512f;
		_mapSpriteWidth = 512f;
		string text;
		if (stageData != null)
		{
			if (stageData._003Ctileset_003Ek__BackingField == null)
			{
				return;
			}
			Tileset tileset = stageData._003Ctileset_003Ek__BackingField;
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				Stage stage = core._stage;
				if ((object)core._stage != null)
				{
					BackgroundManager fancyBg = stage._fancyBg;
					bool flag = (object)stage._fancyBg == null;
					text = tileset._003CdetailsTexture_003Ek__BackingField;
					if (!flag)
					{
						bool flag2 = ((UnityEngine.Object)fancyBg).m_CachedPtr == (IntPtr)0;
						text = tileset._003CdetailsTexture_003Ek__BackingField;
						if (!flag2)
						{
							GameManager core2 = GM.Core;
							if ((object)GM.Core != null)
							{
								Stage stage2 = core2._stage;
								if ((object)core2._stage != null && (object)stage2._fancyBg != null)
								{
									string detailedMap = stage2._fancyBg.GetDetailedMap(stageData);
									text = detailedMap;
									goto IL_03e9;
								}
							}
							goto IL_0364;
						}
					}
					goto IL_03e9;
				}
			}
		}
		goto IL_0364;
		IL_0364:
		throw new NullReferenceException();
		IL_03e9:
		if (text == null || text._stringLength <= 0)
		{
			return;
		}
		Sprite sprite = SpriteManager.GetSprite(text);
		_detailedMapSprite = sprite;
		Sprite detailedMapSprite = _detailedMapSprite;
		if ((object)_detailedMapSprite == null || ((UnityEngine.Object)detailedMapSprite).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		object detailedMapSprite2 = _detailedMapSprite;
		if ((object)_detailedMapSprite != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdi_v11 (System.Object)+10]");
			bool flag3 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdi_v11 (System.Object)+10]");
			Sprite.get_rect_Injected((IntPtr)0, out Rect _);
			object detailedMapSprite3 = _detailedMapSprite;
			float mapSpriteWidth = default(float);
			_mapSpriteWidth = mapSpriteWidth;
			if ((object)_detailedMapSprite != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rdi_v12 (System.Object)+10]");
				bool flag4 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rdi_v12 (System.Object)+10]");
				Sprite.get_rect_Injected((IntPtr)0, out Rect _);
				float mapSpriteHeight = default(float);
				_mapSpriteHeight = mapSpriteHeight;
				GameManager core3 = GM.Core;
				if ((object)GM.Core != null)
				{
					Stage stage3 = core3._stage;
					if ((object)core3._stage != null)
					{
						TilingTileset tilingTileset = stage3._tilingTileset;
						if ((object)stage3._tilingTileset != null)
						{
							GameManager core4 = GM.Core;
							Stage stage4 = core4._stage;
							SuperMap defaultMap = stage4._tilingTileset.DefaultMap;
							if ((object)defaultMap != null)
							{
								float num = tilingTileset._sizeX * 100f;
								float num2 = num / (float)defaultMap.m_TileWidth;
								float num3 = 512f / _mapSpriteHeight;
								float num4 = _mapSpriteWidth / num2;
								float num5 = num4 / 1.6f;
								_mapRatioX = (_mapRatioY = num5 * num3);
								return;
							}
						}
					}
				}
			}
		}
		goto IL_0364;
	}

	private unsafe void ShowDetailedMap(StageData stageData)
	{
		//IL_0008: Expected O, but got Ref
		//IL_00be: Expected I, but got O
		//IL_00d0: Expected I, but got O
		//IL_02fe: Expected O, but got I
		//IL_024e: Expected I, but got O
		//IL_03cd: Expected O, but got I
		//IL_05b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05be: Expected O, but got Unknown
		//IL_03fe: Expected O, but got I
		//IL_0427: Expected I, but got O
		//IL_045b: Expected I, but got O
		//IL_046d: Expected I, but got O
		//IL_047f: Expected I, but got O
		//IL_0491: Expected I, but got O
		//IL_04a6: Expected O, but got I
		//IL_04c6: Expected F4, but got I4
		//IL_0922: Expected O, but got I
		//IL_0944: Expected O, but got Ref
		//IL_094c: Expected I, but got O
		//IL_08fd: Expected O, but got F4
		//IL_0905: Expected O, but got F4
		//IL_07dc: Expected O, but got Ref
		//IL_0bf3: Expected I, but got O
		//IL_0c05: Expected I, but got O
		//IL_0ffd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1002: Expected O, but got Unknown
		//IL_106d: Expected O, but got Ref
		//IL_0c92: Expected O, but got Ref
		//IL_0cc4: Expected I, but got O
		//IL_0d39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d3e: Expected O, but got Unknown
		//IL_0d6e: Expected O, but got F4
		//IL_044e->IL0f0e: Incompatible stack heights: 18 vs 15
		//IL_04cb->IL0f0e: Incompatible stack heights: 18 vs 15
		//IL_0dab->IL0dab: Incompatible stack heights: 29 vs 2
		//IL_0787->IL07fc: Incompatible stack heights: 28 vs 27
		//IL_0b2e->IL0d9c: Incompatible stack heights: 30 vs 29
		//IL_0951->IL0f29: Incompatible stack heights: 29 vs 24
		//IL_0912->IL0f44: Incompatible stack heights: 29 vs 28
		//IL_07fc->IL0827: Incompatible stack heights: 30 vs 28
		//IL_0aea->IL101d: Incompatible stack heights: 38 vs 29
		//IL_0d97->IL123b: Incompatible stack heights: 47 vs 29
		//IL_0d9c->IL0d9c: Incompatible stack heights: 47 vs 29
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Sprite detailedMapSprite = _detailedMapSprite;
		float num2;
		object obj4;
		Vector2 vector = default(Vector2);
		Vector2 vector2;
		Image foreground2;
		Vector2 vector3;
		Vector2 vector4;
		Vector2 vector5;
		if ((object)_detailedMapSprite != null && ((UnityEngine.Object)detailedMapSprite).m_CachedPtr != (IntPtr)0)
		{
			float num = _zoom * 5.882353f;
			num2 = 1f / num;
			bool flag = (object)_Foreground == null;
			_Foreground.sprite = _detailedMapSprite;
			Sprite foreground = (Sprite)(object)_Foreground;
			bool flag2 = (object)_Foreground == null;
			nint num3 = (nint)foreground;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1389 @ r8_v24 (Il2CppClass<UnityEngine.Sprite>)+298] (should have been resolved before IL gen)");
			nint num4 = (nint)foreground;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1398 @ rax_v63 (Il2CppClass<UnityEngine.Sprite>)+2A8] (should have been resolved before IL gen)");
			Image image = RenderingExtensions.SetScale(_Foreground, num2);
			Sprite detailedMapSprite2 = _detailedMapSprite;
			bool flag3 = (object)_detailedMapSprite == null;
			bool flag4 = ((UnityEngine.Object)detailedMapSprite2).m_CachedPtr == (IntPtr)0;
			Sprite.get_rect_Injected(((UnityEngine.Object)detailedMapSprite2).m_CachedPtr, out Rect _);
			Sprite detailedMapSprite3 = _detailedMapSprite;
			bool flag5 = (object)_detailedMapSprite == null;
			bool flag6 = ((UnityEngine.Object)detailedMapSprite3).m_CachedPtr == (IntPtr)0;
			Sprite.get_rect_Injected(((UnityEngine.Object)detailedMapSprite3).m_CachedPtr, out Rect _);
			GameManager core = GM.Core;
			bool flag7 = (object)GM.Core == null;
			Stage stage = core._stage;
			bool flag8 = (object)core._stage == null;
			bool flag9 = (object)stage._tilingTileset == null;
			GameManager core2 = GM.Core;
			Stage stage2 = core2._stage;
			TilingTileset tilingTileset = stage2._tilingTileset;
			float num5 = tilingTileset._sizeY;
			GameManager core3 = GM.Core;
			bool flag10 = core3._multiplayer == null;
			bool num6;
			bool num7;
			bool num8;
			ArcadeSprite arcadeSprite;
			if (core3._multiplayer.IsOnlineMultiplayer)
			{
				bool flag11 = (object)OnlineStageManager._instance == null;
				num6 = flag11;
				int mySeatNumber = OnlineStageManager._instance.GetMySeatNumber();
				bool flag12 = (object)OnlineStageManager._instance == null;
				num7 = flag12;
				VampireSurvivors.Objects.Characters.CharacterController characterForSeatNumber = OnlineStageManager._instance.GetCharacterForSeatNumber(mySeatNumber);
				bool flag13 = (object)characterForSeatNumber == null;
				num8 = flag13;
				nint num9 = unchecked((nint)null);
				arcadeSprite = characterForSeatNumber;
			}
			else
			{
				GameManager core4 = GM.Core;
				bool flag14 = (object)GM.Core == null;
				num6 = flag14;
				GameSessionData gameSessionData = core4._gameSessionData;
				bool flag15 = core4._gameSessionData == null;
				num7 = flag15;
				arcadeSprite = gameSessionData._activeCharacter;
				bool flag16 = (object)gameSessionData._activeCharacter == null;
				nint num9 = 0;
				num8 = flag16;
			}
			float2 position = arcadeSprite.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+74]");
			object obj3 = 0;
			_ = 0;
			GameManager core5 = GM.Core;
			bool flag17 = (object)GM.Core == null;
			Stage stage3 = core5._stage;
			bool flag18 = (object)core5._stage == null;
			Sprite fancyBg = (Sprite)(object)stage3._fancyBg;
			bool flag19 = (object)stage3._fancyBg == null;
			obj4 = null;
			if (!flag19)
			{
				bool flag20 = ((UnityEngine.Object)fancyBg).m_CachedPtr == (IntPtr)0;
				obj4 = null;
				if (!flag20)
				{
					Sprite core6 = (Sprite)(object)GM.Core;
					bool flag21 = (object)GM.Core == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ rbx_v38 (UnityEngine.Sprite)+B8]");
					Sprite sprite = (Sprite)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ rbx_v38 (UnityEngine.Sprite)+B8]");
					bool flag22 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ rbx_v39 (UnityEngine.Sprite)+228]");
					Sprite sprite2 = (Sprite)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ rbx_v39 (UnityEngine.Sprite)+228]");
					bool flag23 = (nint)0 == 0;
					nint num10 = (nint)sprite2;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2795 @ rdx_v93 (Il2CppClass<UnityEngine.Sprite>)+348] (should have been resolved before IL gen)");
					object obj5 = default(object);
					bool flag24 = obj5 == null;
					obj4 = null;
					if (!flag24)
					{
						nint num11 = (nint)sprite2;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2874 @ rdx_v95 (Il2CppClass<UnityEngine.Sprite>)+398] (should have been resolved before IL gen)");
						nint num12 = (nint)sprite2;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2879 @ rdx_v97 (Il2CppClass<UnityEngine.Sprite>)+3A8] (should have been resolved before IL gen)");
						nint num13 = (nint)sprite2;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2884 @ rax_v218 (Il2CppClass<UnityEngine.Sprite>)+3B8] (should have been resolved before IL gen)");
						nint num14 = (nint)sprite2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+74]");
						obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2888 @ rdx_v100 (Il2CppClass<UnityEngine.Sprite>)+3C8] (should have been resolved before IL gen)");
						object obj6 = default(object);
						obj4 = obj6;
						num5 = 0f;
					}
				}
			}
			bool flag25 = (object)_Foreground == null;
			RectTransform rectTransform = _Foreground.rectTransform;
			Vector2 properSize = Extensions.GetProperSize(rectTransform);
			bool flag26 = (object)_Foreground == null;
			RectTransform rectTransform2 = _Foreground.rectTransform;
			bool flag27 = (object)rectTransform2 == null;
			Vector2 sizeDelta = rectTransform2.sizeDelta;
			bool flag28 = (object)_Foreground == null;
			RectTransform rectTransform3 = _Foreground.rectTransform;
			bool flag29 = (object)rectTransform3 == null;
			rectTransform3.sizeDelta = vector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+8C]");
			float num15 = 0f * -0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+8C]");
			object obj7 = 0 * obj3;
			float num16 = (float)obj7 / num5;
			float num17 = num15 - num16;
			float num18 = num17 * num2;
			bool flag30 = (object)_DetailedMapContainer == null;
			_DetailedMapContainer.anchoredPosition = vector;
			GameManager core7 = GM.Core;
			bool flag31 = (object)GM.Core == null;
			bool flag32 = core7._playerOptions == null;
			PlayerOptionsData config = core7._playerOptions.Config;
			bool flag33 = config == null;
			bool flag34 = !config._003CSelectedInverse_003Ek__BackingField;
			vector2 = sizeDelta;
			vector3 = vector;
			vector4 = vector;
			vector5 = vector;
			if (!flag34)
			{
				GameManager core8 = GM.Core;
				bool flag35 = (object)GM.Core == null;
				bool flag36 = core8._playerOptions == null;
				PlayerOptionsData config2 = core8._playerOptions.Config;
				bool flag37 = config2 == null;
				if (config2._003CVisuallyInvertStages_003Ek__BackingField)
				{
					bool flag38 = stageData == null;
					if (stageData._003CallowVisualInversion_003Ek__BackingField)
					{
						bool flag39 = (object)_Foreground == null;
						Transform transform = _Foreground.transform;
						bool flag40 = (object)transform == null;
						transform.localEulerAngles = (Vector3)(&vector2);
						foreground2 = _Foreground;
						vector2 = vector;
						num18 = 180f;
						goto IL_0827;
					}
				}
				foreground2 = _Foreground;
				bool flag41 = stageData == null;
				vector2 = sizeDelta;
				goto IL_0827;
			}
			goto IL_0f29;
		}
		bool flag42 = (object)_DetailedMapContainer == null;
		GameObject gameObject = _DetailedMapContainer.gameObject;
		bool flag43 = (object)gameObject == null;
		gameObject.SetActive(value: false);
		return;
		IL_0f44:
		bool flag44 = (object)foreground2 == null;
		Vector2 ret3 = default(Vector2);
		foreground2.color = (Color)(&ret3);
		nint num19 = (nint)foreground2;
		goto IL_0f29;
		IL_0827:
		if (stageData._003Cinverse_003Ek__BackingField != null)
		{
			StageModifiers stageModifiers = stageData._003Cinverse_003Ek__BackingField;
			if ((object)stageModifiers._003Ctint_003Ek__BackingField != null)
			{
				bool flag45 = (object)stageModifiers._003Ctint_003Ek__BackingField == null;
				object obj8 = (object?)stageModifiers._003Ctint_003Ek__BackingField >> 32;
				object obj9 = obj8 >> 16;
				object obj10 = obj8 >> 8;
				float num20 = (float)obj9 / 255f;
				float num18 = (float)obj10 / 255f;
				float num21 = (float)obj8 / 255f;
				vector3 = (Vector2)num20;
				vector4 = (Vector2)num21;
				vector5 = vector;
				goto IL_0f44;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		vector5 = (Vector2)0;
		vector3 = vector;
		vector4 = vector;
		goto IL_0f44;
		IL_0f29:
		bool flag46 = (object)_Foreground == null;
		GameObject gameObject2 = _Foreground.gameObject;
		bool flag47 = (object)gameObject2 == null;
		gameObject2.SetActive(value: true);
		bool flag48 = (object)_DetailedMapContainer == null;
		GameObject gameObject3 = _DetailedMapContainer.gameObject;
		bool flag49 = (object)gameObject3 == null;
		gameObject3.SetActive(value: true);
		List<Image> foregroundSupports = _ForegroundSupports;
		bool flag50 = _ForegroundSupports == null;
		object obj11 = null;
		object obj12 = null;
		while ((nint)obj12 < foregroundSupports._size)
		{
			List<Image> foregroundSupports2 = _ForegroundSupports;
			bool flag51 = _ForegroundSupports == null;
			bool flag52 = (nint)obj11 >= foregroundSupports2._size;
			Image[] items = foregroundSupports2._items;
			bool flag53 = foregroundSupports2._items == null;
			bool flag54 = (nint)obj11 >= items.Length;
			object obj13 = items[obj11];
			bool flag55 = (object)items[obj11] == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rsi_v36 (System.Object)+10]");
			bool flag56 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rsi_v36 (System.Object)+10]");
			IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
			GameObject gameObject4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
			bool flag57 = (object)gameObject4 == null;
			bool flag58 = ((UnityEngine.Object)gameObject4).m_CachedPtr == (IntPtr)0;
			GameObject.SetActive_Injected(((UnityEngine.Object)gameObject4).m_CachedPtr, false);
			foregroundSupports = _ForegroundSupports;
			obj11++;
			bool flag59 = _ForegroundSupports == null;
			obj12 = obj11;
		}
		bool flag60 = (nint)obj4 <= 0;
		object obj14 = null;
		if (!flag60)
		{
			Quaternion quaternion2 = default(Quaternion);
			bool flag79;
			do
			{
				List<Image> foregroundSupports3 = _ForegroundSupports;
				bool flag61 = _ForegroundSupports == null;
				if ((nint)obj14 >= foregroundSupports3._size)
				{
					break;
				}
				bool flag62 = (nint)obj14 >= foregroundSupports3._size;
				Image[] items2 = foregroundSupports3._items;
				bool flag63 = foregroundSupports3._items == null;
				bool flag64 = (nint)obj14 >= items2.Length;
				object obj15 = items2[obj14];
				bool flag65 = (object)items2[obj14] == null;
				items2[obj14].sprite = _detailedMapSprite;
				nint num22 = (nint)obj15;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3364 @ r8_v37 (Il2CppClass<System.Object>)+298] (should have been resolved before IL gen)");
				nint num23 = (nint)obj15;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3375 @ rax_v118 (Il2CppClass<System.Object>)+2A8] (should have been resolved before IL gen)");
				Image image2 = RenderingExtensions.SetScale(items2[obj14], num2);
				RectTransform rectTransform4 = items2[obj14].rectTransform;
				bool flag66 = (object)rectTransform4 == null;
				bool flag67 = ((UnityEngine.Object)rectTransform4).m_CachedPtr == (IntPtr)0;
				object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 136));
				RectTransform.set_sizeDelta_Injected(((UnityEngine.Object)rectTransform4).m_CachedPtr, ref *(Vector2*)obj16);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rbx_v35 (System.Object)+10]");
				bool flag68 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rbx_v35 (System.Object)+10]");
				IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
				Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
				object foreground3 = _Foreground;
				bool flag69 = (object)_Foreground == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rsi_v31 (System.Object)+10]");
				bool flag70 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rsi_v31 (System.Object)+10]");
				IntPtr gcHandlePtr3 = Component.get_transform_Injected((IntPtr)0);
				Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
				bool flag71 = (object)transform3 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v535 @ rax_v135 (UnityEngine.Transform)+10]");
				bool flag72 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v535 @ rax_v135 (UnityEngine.Transform)+10]");
				Transform.get_localRotation_Injected((IntPtr)0, out *(Quaternion*)(&ret3));
				Vector3 eulerAngles = quaternion2.eulerAngles;
				bool flag73 = (object)transform2 == null;
				transform2.localEulerAngles = (Vector3)(&vector2);
				bool flag74 = (object)_Foreground == null;
				Color color = _Foreground.color;
				num19 = (nint)obj15;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v250 @ r9_v24 (Il2CppClass<System.Object>)+2A8] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rbx_v35 (System.Object)+10]");
				bool flag75 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rbx_v35 (System.Object)+10]");
				IntPtr gcHandlePtr4 = Component.get_gameObject_Injected((IntPtr)0);
				GameObject gameObject5 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr4);
				bool flag76 = (object)gameObject5 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ rax_v150 (UnityEngine.GameObject)+10]");
				bool flag77 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ rax_v150 (UnityEngine.GameObject)+10]");
				GameObject.SetActive_Injected((IntPtr)0, true);
				float num24 = (float)obj14 + 1f;
				float num25 = num24 * 0.5f;
				double num26 = Math.Ceiling(num25);
				RectTransform rectTransform5 = items2[obj14].rectTransform;
				bool flag78 = (object)rectTransform5 == null;
				rectTransform5.anchoredPosition = vector;
				obj14++;
				object obj17 = obj14;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+70]");
				flag79 = (nint)obj17 < 0;
				float r = color.r;
				vector2 = (Vector2)eulerAngles.x;
				vector3 = vector;
				vector4 = vector;
				float num18 = num2;
				vector5 = vector;
			}
			while (flag79);
		}
		DrawMapBackground(stageData);
	}

	public MapManager()
	{
		List<GameObject> smallSprites = new List<GameObject>();
		_smallSprites = smallSprites;
		List<GameObject> spawned = new List<GameObject>();
		_spawned = spawned;
		List<GameObject> gridLines = new List<GameObject>();
		_gridLines = gridLines;
		_zoom = 0.5f;
		_manualZoomFactor = 1f;
		_manualZoomStep = 0.1f;
		_manualZoomOutCap = 5f;
		_manualZoomInCap = 0.1f;
		Dictionary<int2, int> positionBuckets = null;
		EqualityComparer<int2> equalityComparer = EqualityComparer<int2>.Default;
		if (equalityComparer != null)
		{
			_ = 0;
		}
		_positionBuckets = positionBuckets;
		_minorItemTypes = new ItemType[21]
		{
			ItemType.VACUUM,
			ItemType.ROSARY,
			ItemType.OROLOGION,
			ItemType.NFT,
			ItemType.ROAST,
			ItemType.CLOVER,
			ItemType.GILDED,
			ItemType.GOLDFINGER,
			ItemType.SORBETTO,
			ItemType.PICKUP_REROLL_DICE,
			ItemType.SV_DRAFT1,
			ItemType.SV_DRAFT2,
			ItemType.SV_DRAFT3,
			ItemType.FB_RAPIDFIRE,
			ItemType.FB_BARRIER,
			ItemType.FB_GRENADE,
			ItemType.TP_KARMA_COIN,
			ItemType.TP_NEUTRON_BOMB,
			ItemType.TP_MIRROR_OF_TRUTH,
			ItemType.TP_WALL_CHICKEN,
			ItemType.TP_HEART_REFRESH
		};
	}

	private unsafe void _003CAddStagePickups_003Eg__SetDefaultMerchantFrames_007C61_0(ref _003C_003Ec__DisplayClass61_0 P_0)
	{
		Debug.LogWarning("[AdventureMerchant] There is no data available for the AdventureMerchant to show it's correct sprite");
		DataManager data = _data;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)data._003CAllItems_003Ek__BackingField).get_Item((System.Int32Enum)29);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v7 (System.Object)+38]");
		ref _003C_003Ec__DisplayClass61_0 reference = ref *(_003C_003Ec__DisplayClass61_0*)null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v7 (System.Object)+30]");
		_ = 0;
	}

	private unsafe void _003CAddStagePickups_003Eg__SetDefaultMerchantFrames_007C61_1(ref _003C_003Ec__DisplayClass61_0 P_0)
	{
		DataManager data = _data;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)data._003CAllItems_003Ek__BackingField).get_Item((System.Int32Enum)29);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v5 (System.Object)+38]");
		ref _003C_003Ec__DisplayClass61_0 reference = ref *(_003C_003Ec__DisplayClass61_0*)null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v5 (System.Object)+30]");
		_ = 0;
	}
}
