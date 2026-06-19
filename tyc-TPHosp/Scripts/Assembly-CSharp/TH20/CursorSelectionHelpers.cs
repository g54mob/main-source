using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public static class CursorSelectionHelpers
	{
		private const float CursorLength = 400f;

		private const float CursorRadiusSq = 16f;

		public static Character GetCharacterAtCursor(CharacterManager characterManager)
		{
			float num = float.MaxValue;
			Character result = null;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 origin = ray.origin;
			Vector3 b = ray.origin + ray.direction * 400f;
			foreach (Character allCharacter in characterManager.AllCharacters)
			{
				if (SquaredDistanceToLineSegment(origin, b, allCharacter.Position) < 16f && (allCharacter.IsSelectable() || allCharacter.CanHighlight()) && allCharacter.RayCast(ray, out var hit) && hit.distance < num)
				{
					num = hit.distance;
					result = allCharacter;
				}
			}
			return result;
		}

		public static MonoBeast GetMonoBeast(MonoBeastManager monoBeastManager)
		{
			MonoBeast result = null;
			float num = float.MaxValue;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 origin = ray.origin;
			Vector3 b = ray.origin + ray.direction * 400f;
			foreach (MonoBeast beast in monoBeastManager.Beasts)
			{
				if (SquaredDistanceToLineSegment(origin, b, beast.Position) < 16f && (beast.IsSelectable() || beast.CanHighlight()) && beast.RayCast(ray, out var hit) && hit.distance < num)
				{
					num = hit.distance;
					result = beast;
				}
			}
			return result;
		}

		public static Room GetPlot(WorldState worldState, InputManager inputManager)
		{
			Room result = null;
			float num = float.MaxValue;
			Ray ray = Camera.main.ScreenPointToRay(inputManager.GetMousePos());
			Plane plane = new Plane(Vector3.up, new Vector3(0f, 0f, 0f));
			foreach (HospitalPlot hospitalPlot in worldState.HospitalPlots)
			{
				plane.distance = 0f - hospitalPlot.Definition.FootprintYOffset;
				if (plane.Raycast(ray, out var enter))
				{
					GridCoord worldCoord = ray.GetPoint(enter).ToGridCoord();
					HospitalMap hospitalPlotAtWorldPosition = worldState.GetHospitalPlotAtWorldPosition(worldCoord);
					if (hospitalPlotAtWorldPosition != null && hospitalPlotAtWorldPosition.Room != null && enter < num && !hospitalPlotAtWorldPosition.Plot.IsHidden())
					{
						result = hospitalPlotAtWorldPosition.Room;
					}
				}
			}
			return result;
		}

		public static Room GetRoom(GridCoord coord, WorldState worldState)
		{
			Room roomAtWorldCoord = worldState.GetRoomAtWorldCoord(coord, includeHospital: true, includeClosedPlots: true);
			if (roomAtWorldCoord != null && roomAtWorldCoord.IsOpen && roomAtWorldCoord.Definition.IsHospitalOrBay && !roomAtWorldCoord.Definition.IsAmbulanceBayOnly)
			{
				return null;
			}
			return roomAtWorldCoord;
		}

		public static RoomItem GetItem(List<Room> rooms)
		{
			RoomItem result = null;
			float num = float.MaxValue;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 origin = ray.origin;
			Vector3 b = ray.origin + ray.direction * 400f;
			foreach (Room room in rooms)
			{
				foreach (RoomItem item in room.FloorPlan.Items)
				{
					if (SquaredDistanceToLineSegment(origin, b, item.WorldPosition) < 16f && item.Definition.ItemType != RoomItemDefinition.Type.Window && (item.IsSelectable() || item.AmbulanceConfig != null) && item.Visual.RayCast(ray, out var distance) && distance < num)
					{
						num = distance;
						result = item;
					}
				}
			}
			return result;
		}

		private static float SquaredDistanceToLineSegment(Vector3 A, Vector3 B, Vector3 P)
		{
			float num = P.x - A.x;
			float num2 = P.z - A.z;
			float num3 = B.x - A.x;
			float num4 = B.z - A.z;
			float num5 = num * num3 + num2 * num4;
			float num6 = num3 * num3 + num4 * num4;
			float num7 = num5 / num6;
			float num8 = ((num7 < 0f) ? A.x : ((num7 > 1f) ? B.x : (A.x + num3 * num7)));
			float num9 = ((num7 < 0f) ? A.z : ((num7 > 1f) ? B.z : (A.z + num4 * num7)));
			float num10 = num8 - P.x;
			float num11 = num9 - P.z;
			return num10 * num10 + num11 * num11;
		}
	}
}
