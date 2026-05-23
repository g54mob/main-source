using Libs;
using ScriptableObjects.ScriptableObjectScripts.Tile;
using UI;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Factory
{
	public class TileCursor : MonoBehaviour
	{
		[SerializeField]
		private TileBase cursorTile;

		[SerializeField]
		private Color okCursorColor;

		[SerializeField]
		private Color ngCursorColor;

		[SerializeField]
		private Color clearCursorColor;

		[SerializeField]
		private float reloadSecond;

		[SerializeField]
		private CursorMiniGuideCtrl miniGuidePrefab;

		private CursorMiniGuideCtrl miniGuideObj;

		[SerializeField]
		private CursorSideCtrl cursorSideCtrlPrefab;

		private CursorSideCtrl cursorSideCtrlObj;

		private Camera mainCamera;

		private Vector2IntBundle cursorGridRect;

		private ClickStartInfo _clickInfo;

		private ErasingInfo _erasingInfo;

		private Vector2IntBundle lastPreviewGrid;

		private int lastLineDifference;

		private bool lastSetOk;

		private int lastSetOkFrame;

		private bool lastSoldOut;

		private bool relocatablePutMachineDialog;

		private bool altarOfSpiritSelect;

		private bool prevGridRectDrawing;

		private Plane plane;

		private TileDetailPack _tileDetailPack;

		private eErrorId? lastReservedError;

		private bool lastProhibitRemoveMachine;

		private bool _clickInfoReleased;

		private bool _cursorReloadFinished;

		private bool _justSoldOut;

		private bool _justPut;

		private bool _paletteChanged;

		private bool _cursorRotated;

		private bool _inPlaceRotated;

		private bool _relocatableRemoved;

		private bool _justRemovedInstant;

		private bool _justRemovedTimer;

		private int? _cursorReloadFrame;

		private DTileBase2 portTile;

		private DTileBase2 routeGuideTile;

		private DTileBase2 portGuideProductTile;

		private DTileBase2 portGuideConveyerTile;

		private DTileBase2 portGuidePipeTile;

		[SerializeField]
		private float mousePosZ;

		private Vector3 mousePosition;

		private ScreenToWorldBySnapCamera _bySnapCamera;

		private string dumpCursorGrid;

		private ScriptableObjectReader.eCursorSet _currentSet;

		private InputActionController input;

		private ClickStartInfo ClickInfo
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private float GetCameraZoom()
		{
			return 0f;
		}

		private void Update()
		{
		}

		private void SetBridge1(PaletteManager palette, Vector3Int gridPos)
		{
		}

		private bool IsBridgeGamepadRelease()
		{
			return false;
		}

		private bool CheckManaOk(PaletteManager palette)
		{
			return false;
		}

		private void ShowNotEnoughError(PaletteManager palette)
		{
		}

		private void UpdateCursor(bool force = false)
		{
		}

		private string DumpCursor(bool verbose = true, bool dumpMouse = false, bool log = false)
		{
			return null;
		}
	}
}
