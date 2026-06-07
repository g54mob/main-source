using System;
using Factory;
using Motorways.Commands;
using Motorways.Models;
using Server;
using UnityEngine;

namespace Motorways.Views
{
	[System.Serializable]
	public class CreativeModeEditableHouse : MonoBehaviour, ICreativeModeEditableObject
	{
		private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("CreativeModeEditableHouse");

		[SerializeField]
		public HouseView view;

		[SerializeField]
		private EditMenuButtonType _editOptions;

		private IScope _scope;

		private int _groupIndex = -1;

		private TileDirection _drivewayDirection;

		public int GroupIndex => _groupIndex;

		public TileDirection DrivewayDirection => _drivewayDirection;

		public void Initialize(IScope scope, int groupIndex, TileDirection drivewayDirection)
		{
			_scope = scope;
			_groupIndex = groupIndex;
			_drivewayDirection = drivewayDirection;
		}

		public Bounds GetBounds()
		{
			return view.GetBounds();
		}

		public void Delete(bool isReplacement)
		{
			_scope.Get<ISimulation>().ScheduleCommand(RemoveHouseCommand.Create(_scope, view.Model));
		}

		public bool IsConfirmable()
		{
			return true;
		}

		public BuildingLayout GetBuildingLayout()
		{
			return BuildingLayout.BuildingAbove;
		}

		public Vector2 GetWorldPosition()
		{
			return view.transform.position;
		}

		public Vector2Int GetTilePosition()
		{
			return view.tilePosition;
		}

		public Vector2 GetCenterForEditMenuPosition()
		{
			return GetWorldPosition();
		}

		public bool CompletelyOutOfPlayArea(City city)
		{
			return false;
		}

		public EditMenuButtonType GetEditOptions()
		{
			return _editOptions;
		}

		public void Confirm()
		{
		}

		public void Cancel()
		{
		}

		public int GetGroupIndex()
		{
			throw new NotImplementedException();
		}

		public void SetGroupIndex(int groupIndex, bool isReplacement)
		{
			throw new NotImplementedException();
		}

		public ICreativeModeEditableObject GetGhostPreview(out bool isOriginalDeleted)
		{
			isOriginalDeleted = true;
			DraftHouse draftHouse = _scope.Get<DraftHouse>();
			draftHouse.InitializeWithExistingView(_scope, view);
			Delete(isReplacement: false);
			return draftHouse;
		}

		public void Flip(bool isReplacement)
		{
			Diagnostics.FailAssert("Flip called on a DraftHouse, but only makes sense on Single Destinations!");
		}

		public void Rotate(bool isReplacement)
		{
			Diagnostics.FailAssert("Rotate called on a DraftHouse, but only makes sense on Destinations!");
		}

		public void UpgradeOrDowngrade(bool isReplacement)
		{
			Log.Error("UpgradeOrDowngrade called on a DraftHouse, but only makes sense on Destinations!");
		}
	}
}
