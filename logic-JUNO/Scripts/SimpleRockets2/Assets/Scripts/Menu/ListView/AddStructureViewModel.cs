using System;
using System.Collections;
using System.Collections.Generic;
using ModApi;
using ModApi.Ui;
using UnityEngine;

namespace Assets.Scripts.Menu.ListView
{
	public class AddStructureViewModel : ListViewModel
	{
		public class StructureItem
		{
			public Color? Color { get; }

			public string Description { get; set; }

			public string Name { get; set; }

			public string PrefabPath { get; set; }

			public float? Tiling { get; }

			public StructureItem(string name, string prefabPath, string description, float? tiling = null, Color? color = null)
			{
				Name = name;
				PrefabPath = prefabPath;
				Description = description;
				Tiling = tiling;
				Color = color;
			}
		}

		public const string EmptyPrefabPath = "Flight/GameView/Structures/Empty";

		private AddStructureDetails _details;

		private GameMenuScript _gameMenuScript;

		public string PrimaryButtonText { get; set; } = "SELECT";

		public Action<StructureItem> StructureSelected { get; set; }

		public string Title { get; set; } = "Add Structure";

		public override IEnumerator LoadItems()
		{
			_details = new AddStructureDetails(base.ListView.ListViewDetails);
			List<StructureItem> obj = new List<StructureItem>
			{
				new StructureItem("Air Traffic Control Tower", "Flight/GameView/Structures/TowerATC", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Air Traffic Control Tower Basic", "Flight/GameView/Structures/TowerATCBasic", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Barrel Metal", "Flight/GameView/Structures/Barrel", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Base Moon", "Flight/GameView/Structures/MoonBase", "Rugged base designed to withstand unforgiving environments."),
				new StructureItem("Box Wooden", "Flight/GameView/Structures/BoxWooden", string.Empty, 1f, new Color32(byte.MaxValue, 212, 176, byte.MaxValue)),
				new StructureItem("Concrete Cube", "Flight/GameView/Structures/BaseCubePrimitive", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Concrete Cylinder", "Flight/GameView/Structures/BaseCylinderPrimitive", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Concrete Cylinder Hollow", "Flight/GameView/Structures/BaseCylinderHollowPrimitive", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Concrete Sphere", "Flight/GameView/Structures/BaseSpherePrimitive", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Crane", "Flight/GameView/Structures/Crane", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Door", "Flight/GameView/Structures/Door1", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Door Advanced", "Flight/GameView/Structures/Door3", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Door Double", "Flight/GameView/Structures/Door2", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Door Garage", "Flight/GameView/Structures/DoorGarage", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Door Garage Open", "Flight/GameView/Structures/DoorGarageOpen", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Fuel Tank Cylinder", "Flight/GameView/Structures/FuelTankCylinder", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Fuel Tank Large", "Flight/GameView/Structures/FuelTankLarge", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Fuel Tank Round", "Flight/GameView/Structures/FuelTankRound", string.Empty),
				new StructureItem("Hangar Advanced", "Flight/GameView/Structures/MoonBaseHangar", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Hangar Bunker", "Flight/GameView/Structures/HangarBunker", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Hangar Dome", "Flight/GameView/Structures/Hangar2", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Hangar General", "Flight/GameView/Structures/Hangar1", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Hangar Large", "Flight/GameView/Structures/Hangar3", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Hangar Large Garage", "Flight/GameView/Structures/Hangar4", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Hangar Reinforced Small", "Flight/GameView/Structures/HangarReinforcedSmall", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Hangar Reinforced Large", "Flight/GameView/Structures/HangarReinforcedLarge", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Hangar Rocket", "Flight/GameView/Structures/Hangar5", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Landing Pad", "Flight/GameView/Structures/HeliPad", string.Empty),
				new StructureItem("Launch Pad Large", "Flight/GameView/Structures/LaunchPadLarge", string.Empty),
				new StructureItem("Launch Pad Small", "Flight/GameView/Structures/LaunchPadSmall", string.Empty),
				new StructureItem("Launch Pad Tiny", "Flight/GameView/Structures/HangarPad", string.Empty),
				new StructureItem("Launch FX", "Flight/GameView/Structures/LaunchFX", "Detects engines and updates intensity of child Launch FX objects."),
				new StructureItem("Launch FX - Light", "Flight/GameView/Structures/LaunchFXLight", "Light that only affects launch FX particles.", null, new Color32(byte.MaxValue, 164, 0, byte.MaxValue)),
				new StructureItem("Launch FX - Pad", "Flight/GameView/Structures/LaunchFXPad", "Launch FX for a flat surface. Particles flow in the direction of the z-axis (blue arrow). Requires parent object to be a Launch FX."),
				new StructureItem("Launch FX - Trench", "Flight/GameView/Structures/LaunchFXTrench", "Launch FX for a flame trench. Particles flow in the direction of the z-axis (blue arrow). Requires parent object to be a Launch FX."),
				new StructureItem("Light Point", "Flight/GameView/Structures/LightPointLight", "It's a an invisible point light that only turns on at night. The range and intensity can be altered by changing the local scale x and y, respectively.", null, Color.white),
				new StructureItem("Light Spot", "Flight/GameView/Structures/LightSpotlight", "It's a an invisible spotlight that only turns on at night. The light direction is aligned with its z-axis (blue arrow). The range, intensity, and angle can be altered by changing the local scale x, y, and z components, respectively.", null, Color.white),
				new StructureItem("Light Stand", "Flight/GameView/Structures/LightPortable", string.Empty),
				new StructureItem("Outpost Large", "Flight/GameView/Structures/OutpostLarge", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Outpost Small", "Flight/GameView/Structures/OutpostSmall", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Pallet", "Flight/GameView/Structures/Pallet", string.Empty, 1f, new Color32(byte.MaxValue, 212, 176, byte.MaxValue)),
				new StructureItem("Pipe Bend", "Flight/GameView/Structures/PipeBend", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Pipe Corner", "Flight/GameView/Structures/PipeCorner", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Pipe Straight", "Flight/GameView/Structures/PipeStraight", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Railing Angle", "Flight/GameView/Structures/Railing45", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Railing Corner", "Flight/GameView/Structures/RailingCorner", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Railing Corner Angled", "Flight/GameView/Structures/RailingCorner45", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Railing End", "Flight/GameView/Structures/RailingEnd", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Railing Post", "Flight/GameView/Structures/RailingPost", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Railing Spanse", "Flight/GameView/Structures/RailingSpanse", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Raised Launch Pad", "Flight/GameView/Structures/LaunchPadRaised", "Raised launch site.", null, new Color32(99, 99, 99, byte.MaxValue)),
				new StructureItem("Road", "Flight/GameView/Structures/LaunchPadLargeTaxiWay", string.Empty),
				new StructureItem("Road Wide", "Flight/GameView/Structures/HangarTaxiway", string.Empty),
				new StructureItem("Runway Lights", "Flight/GameView/Structures/RunwayLights", "A row of particles set up to turn on only at night. The x scale controls the radius of the light, the y axis how long the strip is and the z axis how many lights are in it.", null, new Color32(byte.MaxValue, byte.MaxValue, 200, byte.MaxValue)),
				new StructureItem("Runway Large", "Flight/GameView/Structures/RunwayLarge", string.Empty),
				new StructureItem("Runway Ramp", "Flight/GameView/Structures/RunwayRamp", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Runway", "Flight/GameView/Structures/Runway", string.Empty),
				new StructureItem("Runway Cross Wind", "Flight/GameView/Structures/RunwayCrossWind", string.Empty),
				new StructureItem("Runway Primary", "Flight/GameView/Structures/PrimaryRunway", "New runway."),
				new StructureItem("Runway Desert Base", "Flight/GameView/Structures/DesertBaseRunway", "New runway."),
				new StructureItem("Runway Road", "Flight/GameView/Structures/RunwayRoad", "New runway."),
				new StructureItem("Satellite Dish", "Flight/GameView/Structures/SatelliteDish", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Shipping Container Closed", "Flight/GameView/Structures/ShippingCrateClosed", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Shipping Container Open", "Flight/GameView/Structures/ShippingCrateOpen", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Shipping Container Doors", "Flight/GameView/Structures/ShippingCrateDoors", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Ship Drone", "Flight/GameView/Structures/DroneShip", "Large drone ship for catching rockets in the ocean."),
				new StructureItem("Stairs", "Flight/GameView/Structures/HangarStairs", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Stairs Basic", "Flight/GameView/Structures/StairsBasic", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Strut Angle", "Flight/GameView/Structures/StrutAngle", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Strut Long", "Flight/GameView/Structures/StrutLong", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Strut Short", "Flight/GameView/Structures/StrutShort", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Strut Tower", "Flight/GameView/Structures/StrutsTower", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Taxiway", "Flight/GameView/Structures/LaunchPadSmallTaxiWay", string.Empty),
				new StructureItem("Vehicle Assembly Building", "Flight/GameView/Structures/VAB", string.Empty),
				new StructureItem("Village Terrace 2", "Flight/GameView/Structures/VillageTerrace2", string.Empty),
				new StructureItem("Village Terrace 3", "Flight/GameView/Structures/VillageTerrace3", string.Empty),
				new StructureItem("Water Tower", "Flight/GameView/Structures/WaterTower", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Water Tower Large", "Flight/GameView/Structures/WaterTowerTall", string.Empty, 1f, new Color32(100, 100, 100, byte.MaxValue)),
				new StructureItem("Window Large", "Flight/GameView/Structures/WindowLarge", string.Empty),
				new StructureItem("Window Medium", "Flight/GameView/Structures/WindowMedium", string.Empty),
				new StructureItem("Window Single", "Flight/GameView/Structures/WindowSmall", string.Empty),
				new StructureItem("Empty", "Flight/GameView/Structures/Empty", "Sometimes the most powerful structure to place is no structure at all.")
			};
			ListViewItemScript selectedItem = null;
			foreach (StructureItem item in obj)
			{
				base.ListView.CreateItem(item.Name, "Stock", item, null, ListViewScript.SpriteLoadLocation.Resources);
			}
			yield return new WaitForEndOfFrame();
			base.ListView.SelectedItem = selectedItem;
		}

		public override void OnListViewInitialized(ListViewScript listView)
		{
			base.OnListViewInitialized(listView);
			listView.Title = Title;
			listView.CanDelete = false;
			listView.PrimaryButtonText = PrimaryButtonText;
			listView.DisplayType = ListViewScript.ListViewDisplayType.ObjectPreview;
		}

		public override void OnPrimaryButtonClicked(ListViewItemScript selectedItem)
		{
			if (selectedItem != null)
			{
				StructureItem obj = selectedItem.ItemModel as StructureItem;
				StructureSelected?.Invoke(obj);
				base.ListView.Close();
			}
		}

		public override void UpdateDetails(ListViewItemScript item, Action completeCallback)
		{
			if (item != null)
			{
				StructureItem structure = item.ItemModel as StructureItem;
				_details.UpdateDetails(structure);
			}
			completeCallback?.Invoke();
		}

		public override void UpdatePreview(ListViewItemScript item, IListViewObjectViewer objectViewer, Action completeCallback)
		{
			if (base.ListView.SelectedItem?.ItemModel is StructureItem structureItem)
			{
				GameObject gameObject = Game.Instance.ResourceLoader.InstantiatePrefab(structureItem.PrefabPath);
				Utilities.ChangeLayersOfGameObjectAndChildrenRecursive(gameObject, 31);
				objectViewer.PreviewObject(gameObject, 0f, destroyWhenFinished: true, new Vector3(-45f, 0f, 0f));
			}
			else
			{
				objectViewer.PreviewObject(null);
			}
			completeCallback?.Invoke();
		}
	}
}
