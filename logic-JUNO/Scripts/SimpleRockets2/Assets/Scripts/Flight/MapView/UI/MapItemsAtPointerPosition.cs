using System.Collections.Generic;
using Assets.Scripts.Flight.MapView.Items;
using Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes;
using Assets.Scripts.Flight.MapView.Targeting;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.UI
{
	public class MapItemsAtPointerPosition
	{
		public List<EncounterInfoScript> EncounterInfos { get; private set; }

		public int ItemCount => MapItems.Count + EncounterInfos.Count + ((!(PlayerCraft == null)) ? 1 : 0) + ((!(ManeuverNodeManager == null)) ? 1 : 0);

		public ManeuverNodeManagerScript ManeuverNodeManager { get; set; }

		public List<MapItemCanvasScript> MapItems { get; private set; }

		public MapPlayerCraft PlayerCraft { get; set; }

		public Vector2 PointerScreenPosition { get; private set; }

		public MapItemsAtPointerPosition(Vector2 pointerScreenPosition)
		{
			PointerScreenPosition = pointerScreenPosition;
			MapItems = new List<MapItemCanvasScript>();
			EncounterInfos = new List<EncounterInfoScript>();
		}
	}
}
