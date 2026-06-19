using System;
using System.Collections.Generic;
using TH20.UI;
using UnityEngine;

namespace TH20
{
	public interface IRibbonMenuView
	{
		void EnableGrid();

		void EnableTable();

		void SetToggleGridButtonActive(bool active);

		void SwapToggleToGridIcon();

		void SwapToggleToTableIcon();

		void DestroyAllListItems();

		void SetTableHeadersActive(bool active);

		void SetTableRowHeight(float rowHeight);

		void SetTableRowFilter(Func<RectTransform, bool> filter);

		void SetTableColumnHeaders(RectTransform columnHeaders);

		void SetTableColumnDefinitions(List<Table.ColumnDefinition> columnDefinitions);

		void SetTableDirtyLayout();

		GameObject InstantiateAsRowInTable(GameObject row);

		void ResortTable();

		GameObject InstantiateAsCellInGrid(GameObject row);

		void RecalulateGridHeight();

		int GetNumOfGridColumns();

		float GetGridCellWidth();

		float GetGridCellSpacingHorizontal();

		void FilterGridCells(Func<RectTransform, bool> filter);

		void TransitionBody(ref RibbonMenuBodyAnimator.Target target, GameObject[] gameObjectsToEnable);

		void SetStaffTypeButtonsActive(bool active);

		void PlaySelectItemSFX();

		void PlayFailUnlockingItemSFX();

		void PlaySelectInactiveItemSFX();

		void PlayUnlockItemSFX();

		float GetScrollVerticalPosition();

		void ResetScrollVerticalPosition(float position = 1f);
	}
}
