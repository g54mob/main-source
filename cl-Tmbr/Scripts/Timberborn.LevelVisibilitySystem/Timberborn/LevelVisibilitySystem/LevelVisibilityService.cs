using System;
using Timberborn.MapStateSystem;
using Timberborn.SingletonSystem;
using Timberborn.TerrainSystem;
using UnityEngine;
using UnityEngine.Rendering;

namespace Timberborn.LevelVisibilitySystem
{
	internal class LevelVisibilityService : ILevelVisibilityService, IPostLoadableSingleton, ILoadableSingleton
	{
		private static readonly int MaxVisibleLevelProperty = Shader.PropertyToID("_MaxVisibleLevel");

		private static readonly GlobalKeyword UseLevelVisibilityKey = GlobalKeyword.Create("_USE_LEVEL_VISIBILITY");

		private readonly EventBus _eventBus;

		private readonly ITerrainService _terrainService;

		private readonly MapSize _mapSize;

		private int _minLevelHidingAnything;

		private int _maxLevelHidingAnything;

		private bool _isActive;

		private bool _isLoaded;

		public int MaxVisibleLevel { get; private set; }

		public bool LevelIsAtMin
		{
			get
			{
				if (_isActive)
				{
					return MaxVisibleLevel == _minLevelHidingAnything;
				}
				return true;
			}
		}

		public bool LevelIsAtMax => MaxVisibleLevel == MaxVisibleLevelLimit;

		public bool TerrainLevelIsAtMax => MaxVisibleLevel == MaxVisibleTerrainLevelLimit;

		private int MaxVisibleLevelLimit => _mapSize.TotalSize.z;

		private int MaxVisibleTerrainLevelLimit => _mapSize.TerrainSize.z;

		public event EventHandler<int> MaxVisibleLevelChanged;

		public LevelVisibilityService(EventBus eventBus, ITerrainService terrainService, MapSize mapSize)
		{
			_eventBus = eventBus;
			_terrainService = terrainService;
			_mapSize = mapSize;
		}

		public void Load()
		{
			MaxVisibleLevel = _mapSize.MaxGameTerrainHeight + _mapSize.MaxHeightAboveTerrain;
			_terrainService.MinMaxTerrainHeightChanged += delegate
			{
				if (_isActive)
				{
					SetLevelsWithAnythingHidable(_minLevelHidingAnything, _maxLevelHidingAnything);
				}
			};
		}

		public void PostLoad()
		{
			_isLoaded = true;
			ResetMaxVisibleLevel();
			SetLevelsWithAnythingHidable(_minLevelHidingAnything, _maxLevelHidingAnything);
		}

		public void SetMaxVisibleLevel(int newMaxVisibleLevel)
		{
			if (MaxVisibleLevel != newMaxVisibleLevel)
			{
				int newMaxVisibleLevel2 = ClampMaxVisibleLevel(newMaxVisibleLevel);
				InternalSetMaxVisibleLevel(newMaxVisibleLevel2);
			}
		}

		public void ResetMaxVisibleLevel()
		{
			InternalSetMaxVisibleLevel(Math.Max(MaxVisibleLevelLimit, MaxVisibleTerrainLevelLimit));
		}

		public bool BlockIsVisible(Vector3Int coordinates)
		{
			return coordinates.z <= MaxVisibleLevel;
		}

		public void SetLevelsWithAnythingHidable(int minLevel, int maxLevel)
		{
			_isActive = true;
			_minLevelHidingAnything = Math.Max(0, Math.Min(_terrainService.MinTerrainHeight, minLevel - 1));
			_maxLevelHidingAnything = Math.Max(_terrainService.MaxTerrainHeight - 1, maxLevel - 1);
			if (!LevelIsAtMax)
			{
				SetMaxVisibleLevel(ClampMaxVisibleLevel(MaxVisibleLevel));
			}
			_eventBus.Post(new HidingLevelsChangedEvent());
		}

		public void ResetLevelsWithAnythingHidable()
		{
			_isActive = false;
			_minLevelHidingAnything = 0;
			_maxLevelHidingAnything = 0;
			ResetMaxVisibleLevel();
			_eventBus.Post(new HidingLevelsChangedEvent());
		}

		private void InternalSetMaxVisibleLevel(int newMaxVisibleLevel)
		{
			int maxVisibleLevel = MaxVisibleLevel;
			if (_isLoaded && maxVisibleLevel != newMaxVisibleLevel)
			{
				MaxVisibleLevel = newMaxVisibleLevel;
				Shader.SetGlobalFloat(MaxVisibleLevelProperty, MaxVisibleLevel);
				Shader.SetKeyword(in UseLevelVisibilityKey, !LevelIsAtMax);
				this.MaxVisibleLevelChanged?.Invoke(this, MaxVisibleLevel);
				_eventBus.Post(new MaxVisibleLevelChangedEvent(maxVisibleLevel));
			}
		}

		private int ClampMaxVisibleLevel(int maxVisibleLevel)
		{
			if (maxVisibleLevel > MaxVisibleLevelLimit)
			{
				return MaxVisibleLevelLimit;
			}
			if (maxVisibleLevel < 0)
			{
				return 0;
			}
			if (_isActive)
			{
				if (maxVisibleLevel < _minLevelHidingAnything)
				{
					return _minLevelHidingAnything;
				}
				if (maxVisibleLevel > _maxLevelHidingAnything)
				{
					if (maxVisibleLevel <= MaxVisibleLevel)
					{
						return _maxLevelHidingAnything;
					}
					return MaxVisibleLevelLimit;
				}
			}
			return maxVisibleLevel;
		}
	}
}
