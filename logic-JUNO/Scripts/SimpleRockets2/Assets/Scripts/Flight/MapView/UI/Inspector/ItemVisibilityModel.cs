using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Items;
using ModApi.Ioc;
using ModApi.Scripts.State.Validation;
using ModApi.State.MapView;
using ModApi.Ui.Inspector;

namespace Assets.Scripts.Flight.MapView.UI.Inspector
{
	public class ItemVisibilityModel
	{
		private MapItemDataDefaults _craftDefaults;

		private LabelButtonModel _iconsVisibilityButton;

		private MapItemDataSet _mapItemDataSet;

		private MapOrbitNode _mapOrbitNode;

		private IMapStateProvider _mapState;

		private LabelButtonModel _orbitLineVisibilityButton;

		private MapItemDataPlanetDefaults _planetDefaults;

		private LabelButtonModel _sphereOfInfluenceVisibilityButton;

		private MapItemDataDefaults _structureDefaults;

		public GroupModel Group { get; set; }

		public ItemVisibilityModel(IIocContainer ioc, IMapViewContext mapViewContext, bool isFlightScene)
		{
			_mapState = ioc.Resolve<IMapStateProvider>(mapViewContext);
			_mapState.Data.MapItemDataSet.CraftDefaults.AnyDefaultValueChanged += delegate
			{
				UpdateUi();
			};
			_mapState.Data.MapItemDataSet.PlanetDefaults.AnyDefaultValueChanged += delegate
			{
				UpdateUi();
			};
			Group = new GroupModel("Item Visibility");
			_orbitLineVisibilityButton = new LabelButtonModel("Selected Orbit", OnOrbitLineVisibilityclicked);
			_orbitLineVisibilityButton.DetermineVisibility = delegate
			{
				MapOrbitNode mapOrbitNode = _mapOrbitNode;
				return (object)mapOrbitNode != null && mapOrbitNode.Data?.SupportsOrbitLines == true;
			};
			_iconsVisibilityButton = new LabelButtonModel("Selected Icon", OnIconsVisibilityClicked);
			_sphereOfInfluenceVisibilityButton = new LabelButtonModel("Selected SOI", OnSphereOfInfluenceVisibilityClicked);
			Group.Add(_orbitLineVisibilityButton);
			Group.Add(_iconsVisibilityButton);
			Group.Add(_sphereOfInfluenceVisibilityButton);
			TextButtonModel item = new TextButtonModel("Reset All Custom", delegate
			{
				ResetNodesToDefaults();
			});
			Group.Add(item);
			_mapItemDataSet = _mapState.Data.MapItemDataSet;
			IGameStateValidator validator = Game.Instance.GameState.Validator;
			_craftDefaults = _mapItemDataSet.CraftDefaults;
			ToggleModel item2 = new ToggleModel("Craft Orbits", () => _craftDefaults.ShowOrbitLines, delegate(bool x)
			{
				if (validator.IsItemAvailable("Map.Lines"))
				{
					_craftDefaults.ShowOrbitLines = x;
				}
				else
				{
					_craftDefaults.ShowOrbitLines = false;
					Game.Instance.UserInterface.CreateMessageDialog().MessageText = "You haven't unlocked the orbit lines yet. You can unlock them in the Tech Tree.";
				}
			});
			ToggleModel item3 = new ToggleModel("Craft Icons", () => _craftDefaults.ShowIcons, delegate(bool x)
			{
				_craftDefaults.ShowIcons = x;
			});
			_planetDefaults = _mapItemDataSet.PlanetDefaults;
			ToggleModel item4 = new ToggleModel("Planet Orbits", () => _planetDefaults.ShowOrbitLines, delegate(bool x)
			{
				if (validator.IsItemAvailable("Map.Lines"))
				{
					_planetDefaults.ShowOrbitLines = x;
				}
				else
				{
					_planetDefaults.ShowOrbitLines = false;
					Game.Instance.UserInterface.CreateMessageDialog().MessageText = "You haven't unlocked the orbit lines yet. You can unlock them in the Tech Tree.";
				}
			});
			ToggleModel item5 = new ToggleModel("Planet Icons", () => _planetDefaults.ShowIcons, delegate(bool x)
			{
				_planetDefaults.ShowIcons = x;
			});
			ToggleModel item6 = new ToggleModel("Planet SOIs", () => _planetDefaults.ShowSpheresOfInfluence, delegate(bool x)
			{
				_planetDefaults.ShowSpheresOfInfluence = x;
			});
			_structureDefaults = _mapItemDataSet.StructureDefaults;
			ToggleModel item7 = new ToggleModel("Structure Icons", () => _structureDefaults.ShowIcons, delegate(bool x)
			{
				_structureDefaults.ShowIcons = x;
			});
			TextButtonModel item8 = new TextButtonModel("Toggle All", delegate
			{
				ToggleAllDefaults();
			});
			TextButtonModel item9 = new TextButtonModel("Reset Defaults", delegate
			{
				ResetVisibilityDefaults();
			});
			if (isFlightScene)
			{
				Group.Add(item2);
				Group.Add(item3);
			}
			Group.Add(item4);
			Group.Add(item5);
			Group.Add(item6);
			if (isFlightScene)
			{
				Group.Add(item7);
			}
			Group.Add(item8);
			Group.Add(item9);
		}

		public void ItemChanged(InspectorItemViewModel newItem)
		{
			if (_mapOrbitNode != null)
			{
				_mapOrbitNode.Data.AnyPropertyChanged -= UpdateUi;
			}
			if (newItem.IsChainableOrbit)
			{
				_mapOrbitNode = newItem.ChainableOrbit.ListNode.List.First.Value as MapOrbitNode;
			}
			else
			{
				_mapOrbitNode = newItem.MapOrbitNode;
			}
			_sphereOfInfluenceVisibilityButton.Visible = _mapOrbitNode is MapPlanet;
			_mapOrbitNode.Data.AnyPropertyChanged += UpdateUi;
			UpdateUi();
		}

		private static void UpdateVisibilityButton(LabelButtonModel button, bool? rawValue, bool defaultedValue)
		{
			string text = (defaultedValue ? "on" : "off");
			button.ButtonLabel = (rawValue.HasValue ? text : "default");
		}

		private void OnIconsVisibilityClicked(LabelButtonModel button)
		{
			MapItemData mapItemData = _mapOrbitNode?.Data;
			if (mapItemData != null)
			{
				Group.Visible = true;
				mapItemData.ShowIconsRaw = MapUtils.GetNextBool(mapItemData.ShowIconsRaw);
				UpdateVisibilityButton(button, mapItemData.ShowIconsRaw, mapItemData.ShowIcons);
			}
			else
			{
				Group.Visible = false;
			}
		}

		private void OnOrbitLineVisibilityclicked(LabelButtonModel button)
		{
			bool flag = Game.Instance.GameState.Validator.IsItemAvailable("Map.Lines");
			MapItemData data = _mapOrbitNode.Data;
			data.ShowOrbitLineRaw = (flag ? MapUtils.GetNextBool(_mapOrbitNode.Data.ShowOrbitLineRaw) : ((bool?)null));
			UpdateVisibilityButton(button, data.ShowOrbitLineRaw, data.ShowOrbitLine);
			if (!flag)
			{
				Game.Instance.UserInterface.CreateMessageDialog().MessageText = "You haven't unlocked the orbit lines yet. You can unlock them in the Tech Tree.";
			}
		}

		private void OnSphereOfInfluenceVisibilityClicked(LabelButtonModel button)
		{
			MapItemData mapItemData = _mapOrbitNode?.Data;
			if (mapItemData != null)
			{
				mapItemData.ShowSphereOfInfluenceRaw = MapUtils.GetNextBool(mapItemData.ShowSphereOfInfluenceRaw);
				UpdateVisibilityButton(button, mapItemData.ShowSphereOfInfluenceRaw, mapItemData.ShowSphereOfInfluence);
			}
		}

		private void ResetNodesToDefaults()
		{
			_mapItemDataSet.ResetAllNodesToDefaults();
		}

		private void ResetVisibilityDefaults()
		{
			_mapItemDataSet.ResetDefaults();
		}

		private void ToggleAllDefaults()
		{
			bool flag = Game.Instance.GameState.Validator.IsItemAvailable("Map.Lines");
			_craftDefaults.ShowIcons = !_craftDefaults.ShowIcons;
			_craftDefaults.ShowOrbitLines = flag && !_craftDefaults.ShowOrbitLines;
			_planetDefaults.ShowIcons = !_planetDefaults.ShowIcons;
			_planetDefaults.ShowOrbitLines = flag && !_planetDefaults.ShowOrbitLines;
			_planetDefaults.ShowSpheresOfInfluence = !_planetDefaults.ShowSpheresOfInfluence;
			_structureDefaults.ShowIcons = !_structureDefaults.ShowIcons;
		}

		private void UpdateUi()
		{
			MapItemData data = _mapOrbitNode.Data;
			UpdateVisibilityButton(_orbitLineVisibilityButton, data.ShowOrbitLineRaw, data.ShowOrbitLine);
			UpdateVisibilityButton(_iconsVisibilityButton, data.ShowIconsRaw, data.ShowIcons);
			UpdateVisibilityButton(_sphereOfInfluenceVisibilityButton, data.ShowSphereOfInfluenceRaw, data.ShowSphereOfInfluence);
		}
	}
}
