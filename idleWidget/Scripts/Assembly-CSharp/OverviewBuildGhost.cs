using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;
using Assets.Source.UI;
using Assets.Source.World;
using UnityEngine;

public class OverviewBuildGhost : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer _sprite;

	[SerializeField]
	private SpriteRenderer _icon;

	private bool _reopenBuildMenu;

	private WorldOverviewCell _relocateCell;

	private WorldFrame _frame;

	private bool _isCopy;

	private Vector2Int _worldPosition;

	public Vector2Int CopySlaveOffset { get; private set; }

	private void Awake()
	{
		UITooltip.TooltipEnabled = false;
	}

	private void OnDestroy()
	{
		UITooltip.TooltipEnabled = true;
		if ((bool)_relocateCell)
		{
			_relocateCell.SetRelocating(r: false);
		}
		else if (OverviewUI.Instance.FullScreenActive && _reopenBuildMenu)
		{
			OverviewUI.Instance.ToggleBuildMenu(show: true);
		}
	}

	public void SetFrame(FramePrefabSet prefab, WorldFrame frame)
	{
		_reopenBuildMenu = OverviewUI.Instance.BuildMenuActive;
		_frame = frame;
		_sprite.sprite = prefab.OverviewSprite;
		_icon.sprite = frame.Icon;
	}

	public void SetRelocateFrame(WorldOverviewCell cell)
	{
		_relocateCell = cell;
		SetFrame(WorldManager.Instance.GetFramePrefabSet(cell.Frame.PrefabName), cell.Frame);
		cell.SetRelocating(r: true);
	}

	private void Update()
	{
		if (PlayerControls.InputCancel)
		{
			OverviewUI.Instance.StopBuildGhost();
			return;
		}
		bool isMouseOverUi = UIHelper.IsMouseOverUi;
		Vector2 mouseWorld = PlayerControls.MouseWorld;
		base.transform.position = mouseWorld;
		_sprite.enabled = !isMouseOverUi;
		if (PlayerControls.InteractRelease && !isMouseOverUi)
		{
			Vector2Int mousePosition = WorldOverview.MousePosition;
			if (!CheckCanBuildAtPosition(mousePosition))
			{
				OverviewUI.Instance.ShowWarning(base.transform, "Space occupied!");
				if (!PlayerControls.ModifierShift)
				{
					Object.Destroy(base.gameObject);
				}
				return;
			}
			if ((bool)_relocateCell)
			{
				DoRelocateToPosition(mousePosition);
			}
			else
			{
				if (_isCopy)
				{
					DoCopyAtPosition(mousePosition);
				}
				else
				{
					DoBuildAtPosition(mousePosition);
				}
				if (!PlayerControls.ModifierShift)
				{
					OverviewUI.Instance.StopBuildGhost();
				}
			}
		}
		if (_worldPosition != WorldOverview.MousePosition)
		{
			_worldPosition = WorldOverview.MousePosition;
			OverviewBuildGhost[] componentsInChildren = GetComponentsInChildren<OverviewBuildGhost>(includeInactive: true);
			foreach (OverviewBuildGhost overviewBuildGhost in componentsInChildren)
			{
				Vector2Int pos = _worldPosition + overviewBuildGhost.CopySlaveOffset;
				SpriteRenderer icon = overviewBuildGhost._icon;
				Color color = (overviewBuildGhost._sprite.color = (WorldMap.Current.CanBuildAtPosition(pos, overviewBuildGhost._frame) ? Color.white : Color.red));
				icon.color = color;
			}
		}
	}

	private bool CheckCanBuildAtPosition(Vector2Int pos)
	{
		if (!WorldMap.Current.CanBuildAtPosition(pos, _frame))
		{
			return false;
		}
		OverviewBuildGhost[] componentsInChildren = GetComponentsInChildren<OverviewBuildGhost>(includeInactive: true);
		foreach (OverviewBuildGhost overviewBuildGhost in componentsInChildren)
		{
			if (!WorldMap.Current.CanBuildAtPosition(pos + overviewBuildGhost.CopySlaveOffset, overviewBuildGhost._frame))
			{
				return false;
			}
		}
		return true;
	}

	private void DoRelocateToPosition(Vector2Int pos)
	{
		WorldFrame worldFrame = _relocateCell?.Frame ?? _frame;
		WorldMap.Current.RemoveFrame(worldFrame);
		if (worldFrame.Construction == null)
		{
			worldFrame.StartConstruction(new Dictionary<ItemType, int>());
		}
		WorldMap.Current.AddFrame(worldFrame, pos);
		WorldOverview.Instance.AddCell(worldFrame);
		Object.Destroy(base.gameObject);
		UISounds.CraftFinished();
	}

	private void DoBuildAtPosition(Vector2Int pos, bool includeUpgrades = false)
	{
		IEnumerable<KeyValuePair<ItemType, int>> purchaseCost = _frame.GetPurchaseCost();
		WorldFrame worldFrame = WorldFrame.Create(_frame.Identifier);
		worldFrame.StartConstruction(purchaseCost);
		WorldMap.Current.AddFrame(worldFrame, pos);
		if (includeUpgrades)
		{
			for (int i = 0; i < _frame.AutoWorkerCount; i++)
			{
				if (_frame.GetAutoWorker(i) != null)
				{
					worldFrame.PurchaseAutoWorker(new WorldAnchor(WorldAnchorType.AutoWorker, i));
				}
			}
			foreach (FrameUpgrade availableUpgrade in _frame.GetAvailableUpgrades())
			{
				if (_frame.HasUpgrade(availableUpgrade) || _frame.GetUpgradeConstruction(availableUpgrade) != null)
				{
					worldFrame.PurchaseUpgrade(new WorldAnchor(WorldAnchorType.Upgrade, availableUpgrade.FrameOrdinal));
				}
			}
			worldFrame.CopyFrom(_frame);
		}
		WorldOverview.Instance.AddCell(worldFrame);
	}

	private void DoCopyAtPosition(Vector2Int pos)
	{
		if (GamePlayer.Current.HasTech(OverviewUI.MoveAreaTech) && PlayerControls.ModifierControl)
		{
			OverviewBuildGhost[] componentsInChildren = GetComponentsInChildren<OverviewBuildGhost>(includeInactive: true);
			foreach (OverviewBuildGhost overviewBuildGhost in componentsInChildren)
			{
				overviewBuildGhost.DoRelocateToPosition(pos + overviewBuildGhost.CopySlaveOffset);
			}
		}
		else
		{
			OverviewBuildGhost[] componentsInChildren = GetComponentsInChildren<OverviewBuildGhost>(includeInactive: true);
			foreach (OverviewBuildGhost overviewBuildGhost2 in componentsInChildren)
			{
				overviewBuildGhost2.DoBuildAtPosition(pos + overviewBuildGhost2.CopySlaveOffset, includeUpgrades: true);
			}
		}
	}

	public void SetIsCopy(bool copy)
	{
		_isCopy = copy;
	}

	internal void SetCopySlave(Vector2Int offset)
	{
		CopySlaveOffset = offset;
		base.enabled = false;
		base.transform.localPosition = new Vector3((float)offset.x * 1.5f, (float)offset.y * 1.5f, 0f);
	}
}
