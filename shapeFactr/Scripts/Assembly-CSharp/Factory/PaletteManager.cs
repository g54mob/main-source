using Factory.UI;
using Libs;
using ScriptableObjects.ScriptableObjectScripts.ExtendData;
using ScriptableObjects.ScriptableObjectScripts.Tile;
using UnityEngine;

namespace Factory
{
	public class PaletteManager : SingletonMonoBehaviour<PaletteManager>
	{
		private ArtifactPaletteCtrl _uiPalette;

		private MstMachineDataEntities _machineData;

		private ExtMachineData _extMachineData;

		private Dir.Rot _rot;

		private eMachine _machineId;

		private bool _isSelected;

		private ePrimaryMachineCategory _primaryMachineCategory;

		private eSecondaryMachineCategory _secondaryMachineCategory;

		private ePaletteCategory _paletteCategory;

		private Vector2Int _size;

		private bool _isProhibitFactory;

		public bool IsProhibitUpdateCurrentPalette { get; set; }

		public bool IsSelected => false;

		private void Start()
		{
		}

		public bool UpdateCurrentPalette(bool force = false, bool? updateProhibitFactoryMode = null)
		{
			return false;
		}

		public eMachine GetCurrentMachineID()
		{
			return default(eMachine);
		}

		public ePrimaryMachineCategory? GetCurrentNeighborPrimaryCategoryForExtractor()
		{
			return null;
		}

		public (TileDetailPack, bool) GetCurrentPalette(Dir.Rot? forceRot = null, int stretch = 0, int? joint = null, string[] partsNameForStream = null)
		{
			return default((TileDetailPack, bool));
		}

		public Vector2IntBundle GetCurrentCursorRect(Vector3Int gridPos)
		{
			return default(Vector2IntBundle);
		}

		public bool IsCurrenCostModeInfinity()
		{
			return false;
		}

		public bool GetCurrentStreamType()
		{
			return false;
		}

		public bool GetCurrentHasBillboard()
		{
			return false;
		}

		public eSecondaryMachineCategory GetCurrentSecondaryCategory()
		{
			return default(eSecondaryMachineCategory);
		}

		public bool GetCurrentDrawable()
		{
			return false;
		}

		public int GetCurrentPairSpaceMax()
		{
			return 0;
		}

		public (eMachine, Dir.Rot) GetCurrentMachineIDRot()
		{
			return default((eMachine, Dir.Rot));
		}

		public (eMachine, Dir.Rot?) SetCurrentMachineID(eMachine spuitId, Dir.Rot? spuitRot = null)
		{
			return default((eMachine, Dir.Rot?));
		}

		public void Clockwise(ClickMode? mode)
		{
		}

		public void Anticlockwise(ClickMode? mode)
		{
		}

		public void SwitchToggle()
		{
		}

		public bool IsRelocatableMachine()
		{
			return false;
		}
	}
}
