using System;
using Factory;
using Motorways.Commands;
using Motorways.Models;
using Server;
using UnityEngine;

namespace Motorways.Views
{
	[System.Serializable]
	public class CreativeModeEditableDestination : MonoBehaviour, ICreativeModeEditableObject
	{
		private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("CreativeModeEditableDestination");

		[SerializeField]
		public DestinationView view;

		[SerializeField]
		private EditMenuButtonType EditOptions;

		[SerializeField]
		private EditMenuButtonType BoatTerminalEditOptions;

		private IScope _scope;

		private int _groupIndex = -1;

		private TileDirection drivewayDirection;

		private bool _isDouble;

		public bool IsDouble => _isDouble;

		public bool IsTrainStation => view.Model.IsTrainStation;

		public bool IsBoatTerminal => view.Model.IsBoatTerminal;

		public void Initialize(IScope scope, bool isDouble)
		{
			_scope = scope;
			_isDouble = isDouble;
		}

		public Bounds GetBounds()
		{
			return view.GetBounds();
		}

		public void Delete(bool isReplacement)
		{
			if (Diagnostics.Verify(_scope.Get<City>().GameMode == GameMode.Creative, "We shouldn't be deleting destinations out of creative mode!"))
			{
				if (view.Model.Carpark.SupportsTwoDestinations && view.Model.Carpark.ActiveDestinationCount > 1)
				{
					_scope.Get<ISimulation>().ScheduleCommand(RemoveDestinationCommand.Create(_scope, view.Model));
				}
				else
				{
					_scope.Get<ISimulation>().ScheduleCommand(RemoveCarparkCommand.Create(_scope, view.Model.Carpark));
				}
			}
		}

		public BuildingLayout GetBuildingLayout()
		{
			if (view.Model.Carpark.Alignment == TileAlignment.Vertical)
			{
				return BuildingLayout.BuildingToSide;
			}
			return BuildingLayout.BuildingAbove;
		}

		public bool IsConfirmable()
		{
			return true;
		}

		public Vector2 GetWorldPosition()
		{
			return view.transform.position;
		}

		public Vector2Int GetTilePosition()
		{
			return view.Model.TileModels[0].Tile.Coordinates;
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
			if (IsBoatTerminal)
			{
				CarparkModel carpark = view.Model.Carpark;
				if (carpark.SupportsTwoDestinations && carpark.ActiveDestinationCount > 1)
				{
					return BoatTerminalEditOptions | EditMenuButtonType.Delete;
				}
				return BoatTerminalEditOptions;
			}
			return EditOptions;
		}

		public void Confirm()
		{
		}

		public void Cancel()
		{
		}

		public int GetGroupIndex()
		{
			return view.Model.GroupIndex;
		}

		public void SetGroupIndex(int groupIndex, bool isOriginalDeleted)
		{
		}

		public void Flip(bool isReplacement)
		{
			Log.Error("Flip called on a CreativeModeEditableDestination, but this should have been diverted to a ghost preview.");
		}

		public void UpgradeOrDowngrade(bool isReplacement)
		{
			Log.Error("UpgradeOrDowngrade called on a CreativeModeEditableDestination, but this should have been diverted to a ghost preview.");
		}

		public void Rotate(bool isReplacement)
		{
			Log.Error("Rotate called on a CreativeModeEditableDestination, but this should have been diverted to a ghost preview.");
		}

		public ICreativeModeEditableObject GetGhostPreview(out bool isOriginalDeleted)
		{
			isOriginalDeleted = true;
			DraftDestination draftDestination = _scope.Get<DraftDestination>();
			draftDestination.InitializeWithExistingView(_scope, view);
			_scope.Get<ISimulation>().ScheduleCommand(RemoveCarparkCommand.Create(_scope, view.Model.Carpark));
			return draftDestination;
		}
	}
}
