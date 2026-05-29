using System;
using Assets.Source.Player;
using Assets.Source.World;
using TMPro;
using UnityEngine;

public class OverviewUI : FullScreenUI
{
	public static TechNode CopyAreaTech = "t5_copy_paste";

	public static TechNode MoveAreaTech = "t5_area_move";

	[SerializeField]
	private OverviewPurchaseMenu _purchaseMenu;

	[SerializeField]
	private OverviewBuildGhost _buildGhostPrefab;

	[SerializeField]
	private OverviewCopyGhost _copyGhostPrefab;

	[SerializeField]
	private RectTransform _deconstructButton;

	[SerializeField]
	private RectTransform _deconstructBorder;

	[SerializeField]
	private RectTransform _copyButton;

	[SerializeField]
	private RectTransform _upgradeButton;

	[SerializeField]
	private RectTransform _shiftGuideText;

	[SerializeField]
	private RectTransform _controlGuideText;

	[SerializeField]
	private TMP_Text _placementGuideText;

	private OverviewCopyGhost _currentCopyGhost;

	private OverviewBuildGhost _currentBuildGhost;

	public static OverviewUI Instance { get; private set; }

	public static bool HasGhost => Instance._currentBuildGhost;

	[field: SerializeField]
	public TraversableView Traversable { get; private set; }

	public bool DeconstructActive { get; private set; }

	public bool CopyActive => _currentCopyGhost;

	public bool BuildMenuActive => _purchaseMenu.gameObject.activeSelf;

	private void Awake()
	{
		Instance = this;
	}

	private void Update()
	{
		if (base.FullScreenActive)
		{
			if (Input.GetKeyDown(KeyCode.C))
			{
				ToggleCopy();
			}
			if (Input.GetKeyDown(KeyCode.X))
			{
				ToggleDeconstruct();
			}
			if (Input.GetMouseButtonDown(1))
			{
				StopDeconstruct();
			}
		}
	}

	public void ToggleDeconstruct()
	{
		if (GamePlayer.Current.HasTech("t1_deconstruct"))
		{
			UISounds.CraftStep();
			DeconstructActive = !DeconstructActive;
			_deconstructBorder.gameObject.SetActive(DeconstructActive);
			if (DeconstructActive)
			{
				ToggleBuildMenu(show: false);
				StopCopy();
				StopBuildGhost();
			}
			UITooltip.Refresh();
		}
	}

	public void StopDeconstruct()
	{
		if (DeconstructActive)
		{
			ToggleDeconstruct();
		}
	}

	public void DoAutoUpgrade()
	{
		GamePlayer.Current.DoAutoUpgrade = !GamePlayer.Current.DoAutoUpgrade;
		UITooltip.Refresh();
	}

	public void ToggleCopy()
	{
		if (GamePlayer.Current.HasTech(CopyAreaTech))
		{
			UISounds.CraftStep();
			if (CopyActive)
			{
				UnityEngine.Object.Destroy(_currentCopyGhost.gameObject);
			}
			else
			{
				_currentCopyGhost = UnityEngine.Object.Instantiate(_copyGhostPrefab, Traversable.transform);
			}
			if (CopyActive)
			{
				ToggleBuildMenu(show: false);
				StopDeconstruct();
				StopBuildGhost();
			}
		}
	}

	public void StopCopy()
	{
		if (CopyActive)
		{
			ToggleCopy();
		}
	}

	public void ToggleBuildMenu()
	{
		if (!base.FullScreenActive)
		{
			ToggleBuildMenu(show: true);
		}
		else
		{
			ToggleBuildMenu(!BuildMenuActive);
		}
	}

	public void ToggleBuildMenu(bool show)
	{
		if (show && !BuildMenuActive)
		{
			GameUI.Inventory.Hide();
			GameUI.Construction.Hide();
			GameUI.Instance.HideBuildTutorial();
			UISounds.WindowOpen();
		}
		else if (!show && BuildMenuActive)
		{
			UISounds.WindowClose();
		}
		if (show && !base.FullScreenActive)
		{
			GameUI.Instance.ShowFullScreenUI(this);
		}
		if (show)
		{
			_purchaseMenu.UpdateContents();
		}
		_purchaseMenu.gameObject.SetActive(show);
		if (show)
		{
			StopDeconstruct();
			StopCopy();
			StopBuildGhost();
		}
	}

	public void ShowPurchaseGhost(FramePrefabSet prefab, WorldFrame frame, bool isCopy = false)
	{
		UISounds.Button();
		if ((bool)_currentBuildGhost)
		{
			UnityEngine.Object.Destroy(_currentBuildGhost.gameObject);
		}
		_currentBuildGhost = UnityEngine.Object.Instantiate(_buildGhostPrefab, Traversable.transform);
		_currentBuildGhost.SetFrame(prefab, frame);
		if (isCopy)
		{
			_currentBuildGhost.SetIsCopy(copy: true);
		}
		ToggleBuildMenu(show: false);
		StopCopy();
		StopDeconstruct();
		_shiftGuideText.gameObject.SetActive(value: true);
		if (frame.PlacementTech != null && GamePlayer.Current.HasTech(frame.PlacementTech))
		{
			_placementGuideText.text = frame.PlacementTech.Description;
		}
		else
		{
			_placementGuideText.text = "Can be placed on any unobstructed tile.";
		}
	}

	public void ShowRelocateGhost(WorldOverviewCell cell)
	{
		if (cell.Frame.Construction == null && !CopyActive && !DeconstructActive && !_currentBuildGhost)
		{
			UISounds.TurnPage();
			_currentBuildGhost = UnityEngine.Object.Instantiate(_buildGhostPrefab, Traversable.transform);
			_currentBuildGhost.SetRelocateFrame(cell);
			ToggleBuildMenu(show: false);
			StopCopy();
			StopDeconstruct();
		}
	}

	public void ShowCopyAreaGhost(Vector2Int startPosition, Vector2Int endPosition)
	{
		Vector2Int vector2Int = new Vector2Int(Math.Min(startPosition.x, endPosition.x), Math.Min(startPosition.y, endPosition.y));
		Vector2Int vector2Int2 = new Vector2Int(Math.Max(startPosition.x, endPosition.x), Math.Max(startPosition.y, endPosition.y));
		OverviewBuildGhost overviewBuildGhost = null;
		int num = 0;
		int num2 = 0;
		for (int i = vector2Int.x; i <= vector2Int2.x; i++)
		{
			for (int j = vector2Int.y; j <= vector2Int2.y; j++)
			{
				WorldFrame frame = WorldMap.Current.GetFrame(new Vector2Int(i, j));
				if (frame != null)
				{
					FramePrefabSet framePrefabSet = WorldManager.Instance.GetFramePrefabSet(frame.PrefabName);
					if (overviewBuildGhost == null)
					{
						overviewBuildGhost = (_currentBuildGhost = UnityEngine.Object.Instantiate(_buildGhostPrefab, Traversable.transform));
						overviewBuildGhost.SetFrame(framePrefabSet, frame);
						overviewBuildGhost.SetIsCopy(copy: true);
						num = i - vector2Int.x;
						num2 = j - vector2Int.y;
					}
					else
					{
						OverviewBuildGhost overviewBuildGhost2 = UnityEngine.Object.Instantiate(_buildGhostPrefab, overviewBuildGhost.transform);
						overviewBuildGhost2.SetFrame(framePrefabSet, frame);
						overviewBuildGhost2.SetCopySlave(new Vector2Int(i - vector2Int.x - num, j - vector2Int.y - num2));
					}
				}
			}
		}
		_shiftGuideText.gameObject.SetActive(value: true);
		_placementGuideText.text = "";
		if (GamePlayer.Current.HasTech(MoveAreaTech))
		{
			_controlGuideText.gameObject.SetActive(value: true);
		}
	}

	public void StopBuildGhost()
	{
		if ((bool)_currentBuildGhost)
		{
			UnityEngine.Object.Destroy(_currentBuildGhost.gameObject);
		}
		_shiftGuideText.gameObject.SetActive(value: false);
		_controlGuideText.gameObject.SetActive(value: false);
	}

	public override void OnFullScreenActivate()
	{
		base.OnFullScreenActivate();
		GamePlayer.Current.RecentInOverview = true;
		_deconstructButton.gameObject.SetActive(GamePlayer.Current.HasTech("t1_deconstruct"));
		_copyButton.gameObject.SetActive(GamePlayer.Current.HasTech("t5_copy_paste"));
		_upgradeButton.gameObject.SetActive(GamePlayer.Current.HasTech("t8_auto_upgrade"));
	}

	public override void OnFullScreenDeactivate()
	{
		base.OnFullScreenDeactivate();
		StopDeconstruct();
		ToggleBuildMenu(show: false);
		if ((bool)_currentBuildGhost)
		{
			UnityEngine.Object.Destroy(_currentBuildGhost.gameObject);
			_currentBuildGhost = null;
		}
		if ((bool)_currentCopyGhost)
		{
			UnityEngine.Object.Destroy(_currentCopyGhost.gameObject);
			_currentCopyGhost = null;
		}
		_shiftGuideText.gameObject.SetActive(value: false);
		_controlGuideText.gameObject.SetActive(value: false);
	}

	public override bool ProcessEscape()
	{
		if ((bool)_currentBuildGhost)
		{
			StopBuildGhost();
			return true;
		}
		if (BuildMenuActive)
		{
			ToggleBuildMenu(show: false);
			return true;
		}
		if (CopyActive)
		{
			StopCopy();
			return true;
		}
		if (DeconstructActive)
		{
			StopDeconstruct();
			return true;
		}
		return false;
	}
}
