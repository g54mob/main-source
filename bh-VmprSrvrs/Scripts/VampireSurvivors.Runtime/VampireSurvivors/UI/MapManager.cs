using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Pickups;
using Zenject;

namespace VampireSurvivors.UI
{
	public class MapManager : MonoBehaviour
	{
		[SerializeField]
		private GameObject _Grid;

		[SerializeField]
		private GameObject _MapIcon;

		[SerializeField]
		private GameObject _Player;

		[SerializeField]
		private Image _Foreground;

		[SerializeField]
		private List<Image> _ForegroundSupports;

		[SerializeField]
		private Image _MapStaticBackgroundImage;

		[SerializeField]
		private RectTransform _DetailedMapContainer;

		[SerializeField]
		private CanvasGroup _CanvasGroup;

		[SerializeField]
		private float _AlphaWhileArcanaInfoShown;

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

		private Dictionary<ItemType, ItemData> AllItemData => null;

		private Dictionary<WeaponType, List<WeaponData>> AllWeaponData => null;

		[Inject]
		private void Construct(GameSessionData session, DataManager data, GameManager gameManager, PlayerOptions playerOptions)
		{
		}

		private void Awake()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		public void SetPickups()
		{
		}

		public void ReduceAlphaOnArcanaInfoShown()
		{
		}

		public void ResetToDefaultAlpha()
		{
		}

		private bool IsMinorItem(Pickup pickupItem)
		{
			return false;
		}

		private List<Pickup> GetAllWorldItems()
		{
			return null;
		}

		public void ZoomIn()
		{
		}

		public void ZoomOut()
		{
		}

		public void Populate()
		{
		}

		private void AddPickupFadingTweens()
		{
		}

		private void DrawMapBackground(StageData stageData)
		{
		}

		private void MakeGrid()
		{
		}

		private GameObject MakeGridLine(bool vertical, float pos)
		{
			return null;
		}

		private void AddMinorItems()
		{
		}

		private void AddPlayers()
		{
		}

		private bool ShouldSkipDrawingPickup(Pickup pickupItem, Dictionary<int2, int> positionBuckets)
		{
			return false;
		}

		private void AddTreasureChests()
		{
		}

		private void AddStagePickups()
		{
		}

		private void AddMapTokens()
		{
		}

		private void AddEventTargets()
		{
		}

		private GameObject SpawnItemOnMap(Sprite s, Vector2 tPos, float scale = 1f)
		{
			return null;
		}

		private void ClearIcons()
		{
		}

		private void ClearGrid()
		{
		}

		private void InitMultiMaps(StageData stageData)
		{
		}

		private void InitDetailedMap(StageData stageData)
		{
		}

		private void ShowDetailedMap(StageData stageData)
		{
		}
	}
}
