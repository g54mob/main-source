using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gh.Tk
{
	public class LevelEditor : MonoBehaviour
	{
		public enum LevelEditorMode
		{
			Zones = 0,
			Atmosphere = 1,
			General = 2
		}

		public enum LevelEditorZoneMode
		{
			Inside = 0,
			Outside = 1,
			Clear = 2,
			Atmosphere = 3
		}

		private LevelEditorZoneMode _currentZoneMode;

		private GameObject _currentTemplate;

		private int _lastX;

		private int _lastZ;

		private int _expandingStep;

		private GameObject _parent;

		private InputAction _leftButton;

		private GridController _gc;

		private RoomController _rc;

		private string _currentOverlayId;

		private LevelEditorMode _currentMode;

		private List<TileData> _tilesToCheck;

		private bool _gridDirty;

		private bool _includeRng;

		private bool _includeTavern;

		private bool _includeTavernMenu;

		private bool _includeTime;

		private bool _includePatrons;

		private bool _includeSpecialUseActors;

		private bool _includeAlerts;

		private bool _includeEvents;

		private bool _includeStory;

		private bool _includeGazette;

		private bool _includeResearch;

		private bool _includeStaff;

		private bool _includeNotHiredStaff;

		private bool _includeEntertainmentController;

		private bool _includeMerchant;

		private bool _setBuildCostsToZero;

		private bool _showOutsideWalls;

		public LevelEditorMode CurrentMode
		{
			get
			{
				return default(LevelEditorMode);
			}
			private set
			{
			}
		}

		public LevelEditorZoneMode CurrentZoneMode
		{
			get
			{
				return default(LevelEditorZoneMode);
			}
			set
			{
			}
		}

		public bool IncludeRng
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IncludeTavern
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IncludeTavernMenu
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IncludeTime
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IncludePatrons
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IncludeSpecialUseActors
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IncludeAlerts
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IncludeEvents
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IncludeStory
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IncludeGazette
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IncludeResearch
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IncludeStaff
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IncludeNotHiredStaff
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IncludeEntertainmentController
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IncludeMerchant
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool SetBuildCostsToZero
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool ShowOutsideWalls
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float AtmosphereValue { get; set; }

		public static event EventHandler<ValueChangedEventArgs<LevelEditorMode>> CurrentModeChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler GeneralSettingChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<ValueChangedEventArgs<LevelEditorZoneMode>> CurrentZoneModeChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void Start()
		{
		}

		public void SwitchTo(LevelEditorMode mode)
		{
		}

		public void Update()
		{
		}

		private void UpdateExpandingStepVisual()
		{
		}

		private void Refresh()
		{
		}

		private void ShowEquilibriumVisuals()
		{
		}

		private void InstantiateInsideOutsideVisuals()
		{
		}

		private void RemoveVisuals()
		{
		}

		private void SetEquilibrium(int x, int y, int z, sbyte equilibrium)
		{
		}

		private void SetEntry(int x, int y, int z, LevelEditorZoneMode mode)
		{
		}

		private GameObject InstantiateVisual(float x, float y, float z, LevelEditorZoneMode mode)
		{
			return null;
		}

		private void UpdatePosition()
		{
		}

		private void SwitchCursorVisual(LevelEditorZoneMode mode)
		{
		}

		private void UpdateCurrentTemplate(LevelEditorZoneMode mode)
		{
		}

		private GameObject GetZoneModeObject(LevelEditorZoneMode mode)
		{
			return null;
		}

		private void UIController_AtmosphereOverlayChanged(object sender, EventArgs e)
		{
		}

		private void UpdateWalls(TileData tile)
		{
		}

		private void UpdateWalls(TileData tile, TileData neighbour, TileData.Direction direction)
		{
		}
	}
}
