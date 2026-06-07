using Motorways.Models;
using UnityEngine;

namespace Motorways.Views
{
	public interface ICreativeModeEditableObject
	{
		Bounds GetBounds();

		bool IsConfirmable();

		BuildingLayout GetBuildingLayout();

		void Delete(bool isReplacement);

		Vector2 GetWorldPosition();

		Vector2Int GetTilePosition();

		Vector2 GetCenterForEditMenuPosition();

		bool CompletelyOutOfPlayArea(City city);

		EditMenuButtonType GetEditOptions();

		void Confirm();

		void Cancel();

		void SetGroupIndex(int groupIndex, bool isReplacement);

		int GetGroupIndex();

		ICreativeModeEditableObject GetGhostPreview(out bool isOriginalDeleted);

		void Flip(bool isReplacement);

		void UpgradeOrDowngrade(bool isReplacement);

		void Rotate(bool isReplacement);
	}
}
