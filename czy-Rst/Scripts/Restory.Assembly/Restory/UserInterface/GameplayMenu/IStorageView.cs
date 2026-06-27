using UnityEngine;

namespace Restory.UserInterface.GameplayMenu
{
	public interface IStorageView
	{
		bool AllowItemExport { get; }

		bool AllowItemImport { get; }

		bool CanDivideStacks { get; }

		bool CanSortStacks { get; }

		RectTransform LocalPanelTarget { get; }

		Vector2 LocalPanelPivot { get; }

		bool AllowItemImportViaActivator { get; }

		void UpdateView();

		void UpdateItemsPositions();
	}
}
