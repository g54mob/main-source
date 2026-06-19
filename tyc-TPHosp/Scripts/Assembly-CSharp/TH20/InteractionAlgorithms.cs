using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TH20
{
	public static class InteractionAlgorithms
	{
		public delegate bool ValidInteractionDelegate(ObjectInteraction interaction);

		private static readonly List<ObjectInteraction> _cachedObjectInteraction = new List<ObjectInteraction>(128);

		private static List<ObjectInteraction> _objectInteractionCache = new List<ObjectInteraction>(128);

		private static List<Vector3> _pathPoints = new List<Vector3>();

		private static readonly List<string> _validStartLocations = new List<string>();

		private static readonly List<RoomItem> _itemsInvalidatingInteractionStart = new List<RoomItem>();

		public static bool InteractionReachable(Character character, ObjectInteraction interaction)
		{
			if (character.RoomUsing != interaction.ParentRoomItem.OwningRoom)
			{
				return true;
			}
			return InteractionReachable(character.Level.WorldState.NavMesh, character.Position, interaction);
		}

		public static bool InteractionReachable(NavMesh navMesh, Vector3 startPos, ObjectInteraction interaction)
		{
			return navMesh.CanReach(startPos, interaction.WorldStartPosition);
		}

		public static bool InteractionReachable(NavMesh navMesh, Vector3 startPos, Vector3 endPos, Room startRoom, Room endRoom, out float pathDistance)
		{
			bool isHospitalOrBay = endRoom.Definition.IsHospitalOrBay;
			bool flag = startRoom?.Definition.IsHospitalOrBay ?? true;
			_pathPoints.Clear();
			if ((flag && isHospitalOrBay) || startRoom == endRoom)
			{
				_pathPoints.Add(startPos);
				_pathPoints.Add(endPos);
			}
			else
			{
				Vector3 item = ((endRoom.FloorPlan.Door != null) ? endRoom.FloorPlan.Door.WorldPosition : Vector3.zero);
				Vector3 item2 = ((endRoom.FloorPlan.Door != null) ? RoomItemAlgorithms.CalculateDoorEnter(endRoom.FloorPlan.Door) : Vector3.zero);
				Vector3 item3 = ((startRoom != null && startRoom.FloorPlan.Door != null) ? startRoom.FloorPlan.Door.WorldPosition : Vector3.zero);
				Vector3 item4 = ((startRoom != null && startRoom.FloorPlan.Door != null) ? RoomItemAlgorithms.CalculateDoorEnter(startRoom.FloorPlan.Door) : Vector3.zero);
				if (!flag && !isHospitalOrBay)
				{
					_pathPoints.Add(startPos);
					_pathPoints.Add(item3);
					_pathPoints.Add(item4);
					_pathPoints.Add(item2);
					_pathPoints.Add(item);
					_pathPoints.Add(endPos);
				}
				else if (flag)
				{
					_pathPoints.Add(startPos);
					_pathPoints.Add(item2);
					_pathPoints.Add(item);
					_pathPoints.Add(endPos);
				}
				else
				{
					_pathPoints.Add(startPos);
					_pathPoints.Add(item3);
					_pathPoints.Add(item4);
					_pathPoints.Add(endPos);
				}
			}
			pathDistance = 0f;
			for (int i = 0; i < _pathPoints.Count; i += 2)
			{
				Vector3 start = _pathPoints[i];
				Vector3 end = _pathPoints[i + 1];
				if (!navMesh.CanReach(start, end))
				{
					return false;
				}
				pathDistance += navMesh.GetLastNavPathLength();
			}
			return true;
		}

		public static bool DoesInteractionExistInLevel(string name, WorldState worldState, ValidInteractionDelegate validDelegate = null)
		{
			for (int i = 0; i < worldState.AllRooms.Count; i++)
			{
				foreach (RoomItem item in worldState.AllRooms[i].FloorPlan.Items)
				{
					foreach (ObjectInteraction interaction in item.Interactions)
					{
						if (interaction.Name == name && (validDelegate == null || validDelegate(interaction)))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public static void GetInteractionsByName(RoomItem item, string interactionName, ValidInteractionDelegate validDelegate, List<ObjectInteraction> results, bool excludeIfOnFire = false)
		{
			if (item.GetComponent<EntityNavFailedComponent>() != null)
			{
				return;
			}
			List<ObjectInteraction> interactions = item.Interactions;
			for (int i = 0; i < interactions.Count; i++)
			{
				ObjectInteraction objectInteraction = interactions[i];
				if (!(objectInteraction.Name != interactionName) && (!excludeIfOnFire || item.GetComponent<RoomItemFlammableComponent>() == null || !item.GetComponent<RoomItemFlammableComponent>().IsOnFire) && (validDelegate == null || validDelegate(objectInteraction)))
				{
					results.Add(objectInteraction);
				}
			}
		}

		public static ObjectInteraction GetBestInteractionByName(RoomItem item, string interactionName, Character character, ValidInteractionDelegate validDelegate)
		{
			float bestScore;
			return GetBestInteractionByName(item, interactionName, character, out bestScore, evalAttractiveness: false, validDelegate);
		}

		public static ObjectInteraction GetBestInteractionByName(RoomItem item, string interactionName, Character character, out float bestScore, bool evalAttractiveness, ValidInteractionDelegate validDelegate, bool excludeIfOnFire = false)
		{
			ObjectInteraction result = null;
			_cachedObjectInteraction.Clear();
			GetInteractionsByName(item, interactionName, validDelegate, _cachedObjectInteraction, excludeIfOnFire);
			Vector3 position = character.Position;
			HospitalAttributeMap attractiveMap = item.Level.WorldState.HospitalAttributeMaps[1];
			float interactionAttractivenessBoost = GameAlgorithms.Config.InteractionAttractivenessBoost;
			bestScore = float.PositiveInfinity;
			for (int i = 0; i < _cachedObjectInteraction.Count; i++)
			{
				ObjectInteraction objectInteraction = _cachedObjectInteraction[i];
				float num = Vector3.Distance(position, objectInteraction.WorldStartPosition);
				List<Character> queue = objectInteraction.Queue;
				int num2 = queue.Count;
				if (num2 != 0 && queue.Contains(character))
				{
					num2--;
				}
				if (num2 != 0)
				{
					num += (float)num2 * GameAlgorithms.Config.InteractionQueueScore;
				}
				if (objectInteraction.Interactor != null && objectInteraction.Interactor != character)
				{
					num += GameAlgorithms.Config.InteractionQueueScore;
				}
				if (objectInteraction.Reserved != null && objectInteraction.Reserved != character)
				{
					num += GameAlgorithms.Config.InteractionQueueScore * 0.5f;
				}
				if (evalAttractiveness)
				{
					num = EvaluateAttractiveness(attractiveMap, objectInteraction, num, interactionAttractivenessBoost);
				}
				if (num < bestScore)
				{
					bestScore = num;
					result = objectInteraction;
				}
			}
			_cachedObjectInteraction.Clear();
			return result;
		}

		public static ObjectInteraction GetClosestInteractionByName(RoomItem item, string interactionName, Vector3 position, ValidInteractionDelegate validDelegate)
		{
			float closestDist;
			return GetClosestInteractionByName(item, interactionName, position, out closestDist, evalAttractiveness: false, validDelegate);
		}

		public static ObjectInteraction GetClosestInteractionByName(RoomItem item, string interactionName, Vector3 position, out float closestDist, bool evalAttractiveness, ValidInteractionDelegate validDelegate)
		{
			ObjectInteraction result = null;
			_cachedObjectInteraction.Clear();
			GetInteractionsByName(item, interactionName, validDelegate, _cachedObjectInteraction);
			HospitalAttributeMap attractiveMap = item.Level.WorldState.HospitalAttributeMaps[1];
			float interactionAttractivenessBoost = GameAlgorithms.Config.InteractionAttractivenessBoost;
			closestDist = float.PositiveInfinity;
			for (int i = 0; i < _cachedObjectInteraction.Count; i++)
			{
				ObjectInteraction objectInteraction = _cachedObjectInteraction[i];
				float num = position.SquareDistance2D(objectInteraction.WorldStartPosition);
				if (evalAttractiveness)
				{
					num = EvaluateAttractiveness(attractiveMap, objectInteraction, num, interactionAttractivenessBoost);
				}
				if (num < closestDist)
				{
					closestDist = num;
					result = objectInteraction;
				}
			}
			_cachedObjectInteraction.Clear();
			return result;
		}

		private static float EvaluateAttractiveness(HospitalAttributeMap attractiveMap, ObjectInteraction interaction, float score, float interactionAttractivenessBoost)
		{
			float mapAttribute = attractiveMap.GetMapAttribute(interaction.WorldStartPosition);
			if (mapAttribute < 0f)
			{
				score *= (0f - mapAttribute) * interactionAttractivenessBoost;
			}
			else if (mapAttribute > 0f)
			{
				score /= (0f - mapAttribute) * interactionAttractivenessBoost;
			}
			return score;
		}

		public static ObjectInteraction GetRandomInteractionByName(string name, RoomItem roomItem, ValidInteractionDelegate validDelegate = null)
		{
			_objectInteractionCache.Clear();
			GetInteractionsByName(roomItem, name, validDelegate, _objectInteractionCache);
			ObjectInteraction result = null;
			if (_objectInteractionCache.Count > 0)
			{
				result = _objectInteractionCache.RandomItem();
			}
			_objectInteractionCache.Clear();
			return result;
		}

		public static ObjectInteraction GetRandomInteractionByName(string name, FloorPlan floorPlan, ValidInteractionDelegate validDelegate = null)
		{
			_objectInteractionCache.Clear();
			foreach (RoomItem item in floorPlan.Items)
			{
				GetInteractionsByName(item, name, validDelegate, _objectInteractionCache);
			}
			ObjectInteraction result = null;
			if (_objectInteractionCache.Count > 0)
			{
				result = _objectInteractionCache.RandomItem();
			}
			_objectInteractionCache.Clear();
			return result;
		}

		public static ObjectInteraction GetBestInteractionByName(string name, RoomItem roomItem, Character character, bool evalAttractiveness, ValidInteractionDelegate validDelegate = null)
		{
			float bestScore;
			return GetBestInteractionByName(roomItem, name, character, out bestScore, evalAttractiveness, validDelegate);
		}

		public static ObjectInteraction GetBestInteractionByName(string name, FloorPlan floorPlan, Character character, bool evalAttractiveness, ValidInteractionDelegate validDelegate = null, bool excludeIfOnFire = false)
		{
			float num = float.PositiveInfinity;
			ObjectInteraction result = null;
			for (int i = 0; i < floorPlan.Items.Count; i++)
			{
				float bestScore;
				ObjectInteraction bestInteractionByName = GetBestInteractionByName(floorPlan.Items[i], name, character, out bestScore, evalAttractiveness, validDelegate, excludeIfOnFire);
				if (bestScore < num)
				{
					num = bestScore;
					result = bestInteractionByName;
				}
			}
			return result;
		}

		public static ObjectInteraction GetClosestInteractionByName(string name, RoomItem roomItem, Vector3 position, bool evalAttractiveness, ValidInteractionDelegate validDelegate = null)
		{
			float closestDist;
			return GetClosestInteractionByName(roomItem, name, position, out closestDist, evalAttractiveness, validDelegate);
		}

		public static ObjectInteraction GetClosestInteractionByName(string name, FloorPlan floorPlan, Vector3 position, bool evalAttractiveness, ValidInteractionDelegate validDelegate = null)
		{
			float num = float.PositiveInfinity;
			ObjectInteraction result = null;
			for (int i = 0; i < floorPlan.Items.Count; i++)
			{
				float closestDist;
				ObjectInteraction closestInteractionByName = GetClosestInteractionByName(floorPlan.Items[i], name, position, out closestDist, evalAttractiveness, validDelegate);
				if (closestDist < num)
				{
					num = closestDist;
					result = closestInteractionByName;
				}
			}
			return result;
		}

		public static bool ValidateInteractionStartLocations(ItemValidateMode validateMode, RoomItem item, WorldState worldState, RoomBuildingNavMesh navMesh, List<RoomItem> invalidItems = null, Vector3 cellOffset = default(Vector3))
		{
			if (item.Interactions.Count == 0)
			{
				return true;
			}
			if (item.GetComponent<RoomItemSellInvalidComponent>() != null)
			{
				return true;
			}
			_validStartLocations.Clear();
			_itemsInvalidatingInteractionStart.Clear();
			Vector3? doorPos = null;
			if (validateMode == ItemValidateMode.Set && item.Definition.ItemType != RoomItemDefinition.Type.Door)
			{
				FloorPlan floorPlan = item.FloorPlan;
				if (floorPlan != null && floorPlan.Doors.Count != 0 && (!floorPlan.Definition.IsHospitalOrBay || !floorPlan.HospitalMap.HasMergedPlots))
				{
					RoomItem roomItem = floorPlan.Doors.RandomItem();
					if (roomItem.IsValid)
					{
						doorPos = (floorPlan.Definition.IsHospitalOrBay ? RoomItemAlgorithms.CalculateDoorEnter(roomItem) : roomItem.WorldPosition);
					}
				}
			}
			foreach (ObjectInteraction interaction in item.Interactions)
			{
				if (ValidateInteractionStart(validateMode, item, doorPos, interaction, worldState, navMesh, cellOffset))
				{
					_validStartLocations.AddUnique(interaction.StartSocketName);
				}
			}
			bool flag = _validStartLocations.Count >= item.Definition.MinValidInteractions;
			if (invalidItems != null && !flag)
			{
				invalidItems.AddRange(_itemsInvalidatingInteractionStart);
			}
			_itemsInvalidatingInteractionStart.Clear();
			return flag;
		}

		private static bool ValidateInteractionStart(ItemValidateMode validateMode, RoomItem item, Vector3? doorPos, ObjectInteraction interaction, WorldState worldState, RoomBuildingNavMesh roomNavMesh, Vector3 cellOffset = default(Vector3))
		{
			Vector3 vector = interaction.WorldStartPosition - cellOffset;
			GridCoord gridCoord = (vector - item.FloorPlan.Anchor.ToWorldPosition()).ToGridCoord();
			bool ignoreRoomCheck = interaction.Definition.IgnoreRoomCheck;
			if (!ignoreRoomCheck && !RoomAlgorithms.RoomContainsCoord(item.FloorPlan, gridCoord))
			{
				if (validateMode == ItemValidateMode.Set)
				{
					interaction.ValidStartPosition = false;
				}
				return false;
			}
			if (ignoreRoomCheck && worldState.GetHospitalMapAtWorldPosition(vector) == null)
			{
				if (validateMode == ItemValidateMode.Set)
				{
					interaction.ValidStartPosition = false;
				}
				return false;
			}
			List<RoomItem> collisionItemsAtCoord = item.FloorPlan.GetCollisionItemsAtCoord(gridCoord);
			if (collisionItemsAtCoord != null)
			{
				foreach (RoomItem item2 in collisionItemsAtCoord)
				{
					if (item2 == item || item2.Definition.IgnoreValidation)
					{
						continue;
					}
					List<ConvexPolygon> worldSpaceSolidShapes = item2.WorldSpaceSolidShapes;
					for (int i = 0; i < worldSpaceSolidShapes.Count; i++)
					{
						ConvexPolygon convexPolygon = worldSpaceSolidShapes[i];
						if (!convexPolygon.PointInPoly(vector.x, vector.z))
						{
							continue;
						}
						if (item2.GetComponent<RoomItemSellInvalidComponent>() != null)
						{
							return true;
						}
						if (validateMode == ItemValidateMode.Set)
						{
							interaction.ValidStartPosition = false;
							if (DebugVars.ShowDebugInfo.Value)
							{
								DebugDrawUtils.Marker(vector, Color.red);
								DebugDrawUtils.ConvexPolygon(convexPolygon, Color.red);
							}
						}
						_itemsInvalidatingInteractionStart.AddUnique(item);
						return false;
					}
				}
			}
			Vector3 worldStartPosition = interaction.WorldStartPosition;
			if (!ignoreRoomCheck)
			{
				if (roomNavMesh != null)
				{
					if (!roomNavMesh.ValidPosition(worldStartPosition, 0.175f))
					{
						if (validateMode == ItemValidateMode.Set)
						{
							interaction.ValidStartPosition = false;
						}
						return false;
					}
					if (doorPos.HasValue && !roomNavMesh.CanReach(worldStartPosition, doorPos.Value))
					{
						if (validateMode == ItemValidateMode.Set)
						{
							interaction.ValidStartPosition = false;
						}
						return false;
					}
				}
				if (roomNavMesh == null)
				{
					if (!UnityEngine.AI.NavMesh.SamplePosition(worldStartPosition, out var _, 0.175f, -1))
					{
						if (validateMode == ItemValidateMode.Set)
						{
							interaction.ValidStartPosition = false;
						}
						return false;
					}
					if (doorPos.HasValue && !worldState.NavMesh.CanReach(worldStartPosition, doorPos.Value))
					{
						if (validateMode == ItemValidateMode.Set)
						{
							interaction.ValidStartPosition = false;
						}
						return false;
					}
				}
			}
			if (validateMode == ItemValidateMode.Set)
			{
				interaction.ValidStartPosition = true;
			}
			return true;
		}
	}
}
