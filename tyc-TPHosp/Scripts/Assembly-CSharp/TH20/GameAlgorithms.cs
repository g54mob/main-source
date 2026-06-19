#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;

namespace TH20
{
	public static class GameAlgorithms
	{
		private class CalculateMarketRateSalaryParam
		{
			public float Percent;
		}

		private class CalculateDesiredSalaryParameter
		{
			public float Percent;
		}

		private static CharacterAttributes.Needs _tempNeeds = new CharacterAttributes.Needs();

		private static List<Room> _roomsCache = new List<Room>(128);

		private static GameAlgorithmsConfig _config;

		private static CalculateMarketRateSalaryParam _calculateMarketRateSalaryParam = new CalculateMarketRateSalaryParam();

		private static CalculateDesiredSalaryParameter _calculateDesiredSalaryParameter = new CalculateDesiredSalaryParameter
		{
			Percent = 0f
		};

		private static List<RoomModifierTrainingRate> _roomModifierTrainingRateCached = new List<RoomModifierTrainingRate>(32);

		public static GameAlgorithmsConfig Config => _config;

		public static void Initialise(GameAlgorithmsConfig config)
		{
			_config = config;
			_tempNeeds = new CharacterAttributes.Needs();
		}

		public static void Destroy()
		{
			_tempNeeds = null;
			_config = null;
		}

		public static Staff FindStaffLikelyToSeePatient(Room room)
		{
			if (room == null)
			{
				return null;
			}
			Staff staff = room.StaffMembers.Find((Staff s) => s.Definition._type == StaffDefinition.Type.Doctor);
			if (staff == null)
			{
				staff = room.StaffMembers.Find((Staff s) => s.Definition._type == StaffDefinition.Type.Nurse);
			}
			return staff;
		}

		public static TreatmentCalculationBreakdown CalculateEstimatedTreatmentOutcome(Patient patient, Staff staff, Room room, RoomItem roomItem = null)
		{
			float diagnosisCertainty = patient.DiagnosisCertainty;
			float num = ((room != null && staff != null) ? staff.GetTreatmentSkillRating(room) : 0f);
			float num2 = room?.TreatmentModifier ?? 0f;
			IllnessDefinition.TreatmentType bestTreatmentType = patient.Illness.GetBestTreatmentType(room?.Definition, patient.Level.ResearchManager);
			float num3 = bestTreatmentType?._effectiveness ?? 0f;
			float num4 = bestTreatmentType?._effectivenessMax ?? 0f;
			float num5 = 0f;
			float num6 = 0f;
			if (room != null)
			{
				if (roomItem != null)
				{
					float roomItemEffectiveness = 0f;
					roomItem.IterateModifiers(delegate(RoomModifierTreatment treatment)
					{
						if (!treatment.RoomWide)
						{
							roomItemEffectiveness += treatment.Percentage / 100f;
						}
					});
					num2 += roomItemEffectiveness;
					num5 = num2;
					num6 = num2;
				}
				else
				{
					foreach (RoomItem item in room.FloorPlan.Items)
					{
						float roomItemEffectiveness2 = 0f;
						item.IterateModifiers(delegate(RoomModifierTreatment treatment)
						{
							if (!treatment.RoomWide)
							{
								roomItemEffectiveness2 += treatment.Percentage / 100f;
							}
						});
						if (num5 <= 0f && num6 <= 0f)
						{
							num5 = num2 + roomItemEffectiveness2;
							num6 = num2 + roomItemEffectiveness2;
							continue;
						}
						float num7 = num2 + roomItemEffectiveness2;
						if (num7 > num6)
						{
							num6 = num7;
						}
						if (num7 < num5)
						{
							num5 = num7;
						}
					}
				}
			}
			float a = num + num5;
			a = Mathf.Min(a, 1f);
			float num8 = Mathf.Lerp(num3, num4, a);
			float minChanceOfSuccess = diagnosisCertainty * num8 / 100f;
			float a2 = num + num6;
			a2 = Mathf.Min(a2, 1f);
			float num9 = Mathf.Lerp(num3, num4, a2);
			float chanceOfSuccess = diagnosisCertainty * num9 / 100f;
			return new TreatmentCalculationBreakdown
			{
				MinChanceOfSuccess = minChanceOfSuccess,
				ChanceOfSuccess = chanceOfSuccess,
				DiagnosisCertainty = diagnosisCertainty,
				StaffSkill = num * 100f,
				RoomModifiers = num6 * 100f,
				MinTreatmentEffectiveness = num3,
				MaxTreatmentEffectiveness = num4
			};
		}

		public static Treatment.Outcome CalculateTreatmentOutcome(Patient patient, Staff staff, Room room)
		{
			Treatment.Outcome result = Treatment.Outcome.Cured;
			staff.GetTreatmentSkillRating(room);
			TreatmentCalculationBreakdown treatmentCalculationBreakdown = CalculateEstimatedTreatmentOutcome(patient, staff, room, (patient.Interaction != null) ? patient.Interaction.ParentRoomItem : null);
			if (!patient.Level.ToughLuckBalancer.GetResult(treatmentCalculationBreakdown.ChanceOfSuccess / 100f))
			{
				result = (patient.Level.ToughLuckBalancer.GetResult(patient.Illness._treatmentChanceOfDeathOnFailure / 100f) ? Treatment.Outcome.Death : Treatment.Outcome.Ineffective);
			}
			return result;
		}

		public static Room GetBestRoomOfType(WorldState worldState, RoomDefinition.Type type, RoomUseType useType, Character character)
		{
			if (character.GameObject == null || character.HasBeenDestroyed())
			{
				Logging.Error(LogChannels.Building, "Trying to use character {0} which has been destroyed", character);
			}
			Room result = null;
			float num = float.MaxValue;
			Vector3 position = character.Position;
			Room goingToRoom = character.GoingToRoom;
			_roomsCache.Clear();
			worldState.GetRoomsOfType(type, includeClosed: false, _roomsCache);
			foreach (Room item in _roomsCache)
			{
				if (item.WhoCanUse.IsMember(character) && item.CanBeUsedFor(useType) && item.CanBeUsedFor(character))
				{
					float num2 = CalculateRoomScore(character, item, goingToRoom, position);
					if (num2 < num)
					{
						result = item;
						num = num2;
					}
				}
			}
			_roomsCache.Clear();
			return result;
		}

		public static float CalculateRoomScore(Character character, Room room, Room roomGoingTo, Vector3 position)
		{
			float num = (float)room.QueueLength * _config.RoomScoreQueueLength;
			if (room == roomGoingTo)
			{
				num = (float)room.PositionInQueue(character) * _config.RoomScorePositionScore;
			}
			Vector3 b = ((room.FloorPlan.Door != null) ? room.FloorPlan.Door.WorldPosition : room.Center);
			float num2 = Vector3.Distance(position, b) * _config.RoomScoreDistanceFactor;
			float num3 = (room.IsFullyStaffed() ? 0f : _config.RoomScoreNotFullyStaffed);
			float num4 = (room.IsFunctional() ? 0f : _config.RoomScoreRoomNotFunctional);
			return num + num2 + num3 + num4;
		}

		public static int CalculatePurchaseCostOfRoom(FloorPlan floorPlan, bool isNewRoom)
		{
			int num = 0;
			if (floorPlan != null)
			{
				if (isNewRoom)
				{
					num += floorPlan.Definition._cost;
				}
				foreach (RoomItem item in floorPlan.Items)
				{
					if (!item.HasBeenPurchased)
					{
						num += item.Cost;
					}
				}
			}
			return num;
		}

		public static int CalculatePurchaseCostOfRoomTemplate(RoomTemplateFloorPlan floorPlan)
		{
			int num = 0;
			if (floorPlan != null)
			{
				num += floorPlan.Definition._cost;
				foreach (RoomTemplateItem item in floorPlan.Items)
				{
					if (!item.IsHospitalWindow)
					{
						if (item.Definition != null && item.Definition.Instance != null)
						{
							num += item.Definition.Instance.GetCost();
						}
						else if (item.UGCDefinition != null)
						{
							num += item.UGCDefinition.GetCost();
						}
					}
				}
			}
			return num;
		}

		public static int CalculateSellCostOfRoom(FloorPlan floorPlan)
		{
			int num = 0;
			if (floorPlan != null)
			{
				num += floorPlan.Definition._cost;
				foreach (RoomItem item in floorPlan.Items)
				{
					if (item.HasBeenPurchased)
					{
						num += item.SellValue();
					}
				}
			}
			return num;
		}

		public static int CalculateRoomItemsRefund(FloorPlan floorPlan)
		{
			int num = 0;
			if (floorPlan != null)
			{
				foreach (RoomItem item in floorPlan.Items)
				{
					if (item.HasBeenPurchased)
					{
						num += item.SellValue();
					}
				}
			}
			return num;
		}

		public static RoomPrestige CalculateRoomPrestige(FloorPlan floorPlan)
		{
			int num = 0;
			float num2 = 0f;
			float progress = 0f;
			RoomPrestigeLevel roomPrestigeLevel = _config.RoomPrestigeLevels[num];
			if (floorPlan != null)
			{
				float num3 = 0f;
				float num4 = CalculateRoomTilePrestige(floorPlan);
				foreach (RoomItem item in floorPlan.Items)
				{
					num3 += item.Prestige;
				}
				num2 = num3 + num4;
				for (int i = 0; i < _config.RoomPrestigeLevels.Length; i++)
				{
					RoomPrestigeLevel roomPrestigeLevel2 = _config.RoomPrestigeLevels[i];
					if (num2 >= (float)roomPrestigeLevel2.Points)
					{
						num = i;
						roomPrestigeLevel = roomPrestigeLevel2;
					}
				}
				if (num == _config.RoomPrestigeLevels.Length - 1)
				{
					progress = 0f;
				}
				else
				{
					int points = _config.RoomPrestigeLevels[num + 1].Points;
					int num5 = roomPrestigeLevel?.Points ?? 0;
					float num6 = points - num5;
					progress = (num2 - (float)num5) / num6;
				}
			}
			return new RoomPrestige
			{
				Level = num + 1,
				Points = num2,
				Progress = progress,
				Data = roomPrestigeLevel
			};
		}

		public static float CalculateAverageRoomPrestige(Level level)
		{
			int num = 0;
			float num2 = 0f;
			foreach (Room allRoom in level.WorldState.AllRooms)
			{
				if (!allRoom.Definition.IsHospitalOrBay && !allRoom.Definition.IsHospitalUnbuilt && allRoom.IsInBoughtPlot())
				{
					num2 += (float)CalculateRoomPrestige(allRoom.FloorPlan).Level;
					num++;
				}
			}
			if (num == 0)
			{
				return 0f;
			}
			return num2 / (float)num;
		}

		private static float CalculateRoomTilePrestige(FloorPlan floorPlan)
		{
			RoomDefinition definition = floorPlan.Definition;
			int a = floorPlan.TileCount - definition._minSizeX * definition._minSizeY;
			a = Mathf.Max(0, Mathf.Min(a, definition.MaxPrestigePerCell));
			a *= definition.PrestigePerExtraCell;
			return a;
		}

		private static DiagnosisCalculationBreakdown GetDiagnosisCertainty(Patient patient, Room room, ResearchManager researchManager)
		{
			DiagnosisCalculationBreakdown breakdown = default(DiagnosisCalculationBreakdown);
			float diagnosisCertainty = patient.Illness.GetDiagnosisCertainty(room, patient, researchManager, ref breakdown);
			breakdown.Certainty = Mathf.Min(diagnosisCertainty, 100f);
			return breakdown;
		}

		public static DiagnosisCalculationBreakdown GetDiagnosisCertainty(Patient patient, Room room, Staff staff, ResearchManager researchManager)
		{
			DiagnosisCalculationBreakdown breakdown = default(DiagnosisCalculationBreakdown);
			float diagnosisCertainty = patient.Illness.GetDiagnosisCertainty(room, patient, researchManager, ref breakdown);
			breakdown.StaffMultiplier = staff.GetDiagnosisMultiplier(room);
			breakdown.Certainty = Mathf.Min(diagnosisCertainty * breakdown.StaffMultiplier, 100f);
			return breakdown;
		}

		public static Room GetNextDiagnosisRoom(List<Room> rooms, Patient patient, ResearchManager researchManager, int furtherDiagnosisChoiceCount)
		{
			if (rooms.Count == 0)
			{
				return null;
			}
			rooms.Shuffle(RandomUtils.GlobalRandomInstance);
			rooms.Sort(delegate(Room lhs, Room rhs)
			{
				float certainty = GetDiagnosisCertainty(patient, lhs, researchManager).Certainty;
				float certainty2 = GetDiagnosisCertainty(patient, rhs, researchManager).Certainty;
				if (certainty < certainty2)
				{
					return 1;
				}
				return (certainty > certainty2) ? (-1) : 0;
			});
			int num = RandomUtils.GlobalRandomInstance.Next(0, furtherDiagnosisChoiceCount);
			if (num < rooms.Count)
			{
				return rooms[num];
			}
			return rooms[rooms.Count - 1];
		}

		public static Room GetNextDiagnosisRoom(List<Room> rooms, Patient patient, Staff staff, ResearchManager researchManager)
		{
			if (rooms.Count == 0)
			{
				return null;
			}
			rooms.Shuffle(RandomUtils.GlobalRandomInstance);
			rooms.Sort(delegate(Room lhs, Room rhs)
			{
				float certainty = GetDiagnosisCertainty(patient, lhs, staff, researchManager).Certainty;
				float certainty2 = GetDiagnosisCertainty(patient, rhs, staff, researchManager).Certainty;
				if (certainty < certainty2)
				{
					return 1;
				}
				return (certainty > certainty2) ? (-1) : 0;
			});
			int num = RandomUtils.GlobalRandomInstance.Next(0, (staff.RankDefinition != null) ? staff.RankDefinition.FurtherDiagnosisChoiceCount : 0);
			if (num < rooms.Count)
			{
				return rooms[num];
			}
			return rooms[rooms.Count - 1];
		}

		private static bool CharacterCanUseInteractionsInRoom(Character character, Room room)
		{
			if (room == null || !room.IsOpen)
			{
				return false;
			}
			if (room.WhoCanUse.IsMember(character) && (room.Definition.IsHospitalOrBay || (!room.IsAtMaxCapacity() && room.FloorPlan.Door != null)))
			{
				if (room.Definition._allowPatientsNeedsSatisfaction && character is Patient)
				{
					return true;
				}
				if (character is Staff staff && (room.Definition._allowStaffNeedsSatisfaction || room.IsStaffMember(staff)) && (!staff.IsIdleInWorkRoom() || room == staff.RoomUsing))
				{
					return true;
				}
			}
			return false;
		}

		public static ObjectInteraction GetBestInteractionThatSatisfiesNeed(Character character, CharacterAttributes.Type need, bool urgent, out Room roomOut)
		{
			ObjectInteraction interactionOut = null;
			Room roomOut2 = character.RoomUsing;
			if (character.Level.WorldState.NeedSatisfyingRoomItems[(int)need] != null)
			{
				bool num = !urgent && character.QueuingAtRoom != null;
				float needSearchRadius = GetNeedSearchRadius(character, need, urgent);
				Vector3 characterPosition = character.Position;
				if (num && RoomAlgorithms.GetQueueTransform(character, character.QueuingAtRoom, out var position, out var _))
				{
					characterPosition = position;
				}
				FindBestNeedInteractionWithinRadius(character, (int)need, characterPosition, needSearchRadius, out interactionOut, out roomOut2);
				if (num && interactionOut == null)
				{
					needSearchRadius = GetNeedSearchRadius(character, need, urgent: false);
					FindBestNeedInteractionWithinRadius(character, (int)need, character.Position, needSearchRadius, out interactionOut, out roomOut2);
				}
			}
			roomOut = roomOut2;
			return interactionOut;
		}

		private static float GetNeedSearchRadius(Character character, CharacterAttributes.Type need, bool urgent)
		{
			float num;
			switch (need)
			{
			case CharacterAttributes.Type.Hunger:
			case CharacterAttributes.Type.Thirst:
				num = (urgent ? Config.UrgentSearchRadiusFood : Config.OpportunisticSearchRadiusFood);
				break;
			case CharacterAttributes.Type.Toilet:
				num = (urgent ? Config.UrgentSearchRadiusToilet : Config.OpportunisticSearchRadiusToilet);
				break;
			case CharacterAttributes.Type.Boredom:
				num = (urgent ? Config.UrgentSearchRadiusBoredom : Config.OpportunisticSearchRadiusBoredom);
				break;
			case CharacterAttributes.Type.Litter:
				num = (urgent ? Config.UrgentSearchRadiusLitter : Config.OpportunisticSearchRadiusLitter);
				break;
			default:
				num = (urgent ? Config.UrgentSearchRadiusDefault : Config.OpportunisticSearchRadiusDefault);
				break;
			}
			float num2 = 1f;
			int queuePosition = character.GetQueuePosition();
			if (Config.SearchRadiusQueuePositionMultipliers.ValidIndex(queuePosition))
			{
				num2 = Config.SearchRadiusQueuePositionMultipliers[queuePosition];
			}
			return num * num2;
		}

		private static void FindBestNeedInteractionWithinRadius(Character character, int needIndex, Vector3 characterPosition, float radius, out ObjectInteraction interactionOut, out Room roomOut)
		{
			float num = float.MaxValue;
			Room roomUsing = character.RoomUsing;
			int queuePosition = character.GetQueuePosition();
			NavMesh navMesh = character.Level.WorldState.NavMesh;
			List<KeyValuePair<RoomItem, float>>[] needSatisfyingRoomItems = character.Level.WorldState.NeedSatisfyingRoomItems;
			interactionOut = null;
			roomOut = null;
			foreach (KeyValuePair<RoomItem, float> item in needSatisfyingRoomItems[needIndex])
			{
				RoomItem key = item.Key;
				if (!CharacterCanUseInteractionsInRoom(character, key.OwningRoom) || !key.IsFunctional() || !key.Definition.ValidQueuePositionForNeed(queuePosition))
				{
					continue;
				}
				Room owningRoom = key.OwningRoom;
				foreach (ObjectInteraction interaction in key.Interactions)
				{
					if (interaction.Type == InteractionAttributeModifier.Type.Use && interaction.Valid && (radius <= 0f || Vector3.Distance(characterPosition, interaction.WorldStartPosition) <= radius) && InteractionAlgorithms.InteractionReachable(navMesh, characterPosition, interaction.WorldStartPosition, roomUsing, owningRoom, out var pathDistance) && pathDistance <= radius)
					{
						float value = item.Value;
						float num2 = pathDistance / value;
						if (interaction.IsAvailable(character))
						{
							num2 *= Config.NeedScoreInteractionAvailable;
						}
						int queueLength = interaction.GetQueueLength();
						if (queueLength != 0)
						{
							num2 *= (float)queueLength * Config.NeedScoreQueueLengthMultiplier;
						}
						if (owningRoom != roomUsing)
						{
							num2 *= Config.NeedScoreInDifferentRoomMultiplier;
						}
						if (num2 <= num)
						{
							num = num2;
							interactionOut = interaction;
							roomOut = key.OwningRoom;
						}
					}
				}
			}
		}

		public static CharacterAttributes.Type GetCharacterUrgentNeed(Character character)
		{
			character.GetCharacterAttributes().GetNeeds(_config.UrgentNeedThreshold, ref _tempNeeds);
			CharacterAttributes.Type result = ((_tempNeeds.Count != 0) ? _tempNeeds[0].Key : CharacterAttributes.Type.None);
			_tempNeeds.Clear();
			return result;
		}

		public static CharacterAttributes.Type GetCharacterOpportunisticNeed(Character character)
		{
			character.GetCharacterAttributes().GetNeeds(_config.OpportunisticNeedThreshold, ref _tempNeeds);
			CharacterAttributes.Type result = ((_tempNeeds.Count != 0) ? _tempNeeds[0].Key : CharacterAttributes.Type.None);
			_tempNeeds.Clear();
			return result;
		}

		public static float GetCharacterHappinessModifierFromNeeds(Character character, out CharacterAttributes.Type topNeed, out bool urgent)
		{
			float num = 0f;
			character.GetCharacterAttributes().GetNeeds(_config.OpportunisticNeedThreshold, ref _tempNeeds);
			foreach (KeyValuePair<CharacterAttributes.Type, AttributeFloat> tempNeed in _tempNeeds)
			{
				num = ((!(tempNeed.Value.Value() >= _config.UrgentNeedThreshold)) ? (num + character.Definition.GetOpportunisticNeedHappinessModifer(tempNeed.Key)) : (num + character.Definition.GetUrgentNeedHappinessModifer(tempNeed.Key)));
			}
			topNeed = ((_tempNeeds.Count != 0) ? _tempNeeds[0].Key : CharacterAttributes.Type.None);
			if (topNeed == CharacterAttributes.Type.None)
			{
				urgent = false;
			}
			else
			{
				urgent = _tempNeeds[0].Value.Value() >= _config.UrgentNeedThreshold;
			}
			_tempNeeds.Clear();
			return num;
		}

		public static bool GetCharacterNeedInteraction(Character character, out CharacterAttributes.Type needType, out ExternalBehavior behaviour, out ObjectInteraction interaction, out Room room)
		{
			CharacterAttributes characterAttributes = character.GetCharacterAttributes();
			characterAttributes.GetNeeds(_config.UrgentNeedThreshold, ref _tempNeeds);
			for (int i = 0; i < _tempNeeds.Count; i++)
			{
				needType = _tempNeeds[i].Key;
				interaction = GetBestInteractionThatSatisfiesNeed(character, needType, urgent: true, out room);
				if (interaction != null)
				{
					ExternalBehavior externalBehavior = ((room != null) ? room.Definition.GetSatisfactionOverride(needType, interaction.ParentRoomItem) : null);
					if (needType == CharacterAttributes.Type.Toilet && character.Visual.CustomisationOption?.BehaviourSatisfyToiletOverride != null)
					{
						externalBehavior = character.Visual.CustomisationOption.BehaviourSatisfyToiletOverride;
					}
					behaviour = ((externalBehavior != null) ? externalBehavior : character.Definition.GetSatisfactionBehaviour(needType));
					if (needType == CharacterAttributes.Type.Nausea)
					{
						CustomisationOption customisationOption = character.Visual.CustomisationOption;
						if ((object)customisationOption != null && customisationOption.DisallowNauseaFulfilment)
						{
							behaviour = null;
						}
					}
					if (behaviour != null)
					{
						_tempNeeds.Clear();
						return true;
					}
				}
				behaviour = character.Definition.GetSatisfactionFailureBehaviour(needType);
				if (needType == CharacterAttributes.Type.Nausea)
				{
					CustomisationOption customisationOption2 = character.Visual.CustomisationOption;
					if ((object)customisationOption2 != null && customisationOption2.DisallowNauseaFulfilment)
					{
						behaviour = null;
					}
				}
				if (behaviour != null)
				{
					_tempNeeds.Clear();
					return true;
				}
			}
			characterAttributes.GetNeeds(_config.OpportunisticNeedThreshold, ref _tempNeeds);
			for (int j = 0; j < _tempNeeds.Count; j++)
			{
				needType = _tempNeeds[j].Key;
				interaction = GetBestInteractionThatSatisfiesNeed(character, needType, urgent: false, out room);
				if (interaction == null)
				{
					continue;
				}
				ExternalBehavior externalBehavior2 = ((room != null) ? room.Definition.GetSatisfactionOverride(needType, interaction.ParentRoomItem) : null);
				if (needType == CharacterAttributes.Type.Toilet && character.Visual.CustomisationOption?.BehaviourSatisfyToiletOverride != null)
				{
					externalBehavior2 = character.Visual.CustomisationOption.BehaviourSatisfyToiletOverride;
				}
				behaviour = ((externalBehavior2 != null) ? externalBehavior2 : character.Definition.GetSatisfactionBehaviour(needType));
				if (needType == CharacterAttributes.Type.Nausea)
				{
					CustomisationOption customisationOption3 = character.Visual.CustomisationOption;
					if ((object)customisationOption3 != null && customisationOption3.DisallowNauseaFulfilment)
					{
						behaviour = null;
					}
				}
				_tempNeeds.Clear();
				return true;
			}
			room = null;
			behaviour = null;
			interaction = null;
			needType = CharacterAttributes.Type.None;
			_tempNeeds.Clear();
			return false;
		}

		private static float BoostScoreBasedOnRoom(Staff staff, Room room, float score)
		{
			if (room != null && staff != null && staff.JobBoostModifiers != null)
			{
				foreach (CharacterModifier jobBoostModifier in staff.JobBoostModifiers)
				{
					if (jobBoostModifier is QualificationJobRoomScoreBoost qualificationJobRoomScoreBoost && qualificationJobRoomScoreBoost.RoomType == room.Definition._type)
					{
						score *= qualificationJobRoomScoreBoost.ScoreBoost;
					}
				}
			}
			return score;
		}

		private static float BoostScoreBasedOnMaintenanceJob(Staff staff, RoomItem roomItem, float score)
		{
			if (roomItem != null && staff != null && staff.JobBoostModifiers != null)
			{
				foreach (CharacterModifier jobBoostModifier in staff.JobBoostModifiers)
				{
					if (jobBoostModifier is QualificationJobMaintenanceScoreBoost qualificationJobMaintenanceScoreBoost && qualificationJobMaintenanceScoreBoost.MaintenanceType == roomItem.Definition.MaintenanceDescription)
					{
						score *= qualificationJobMaintenanceScoreBoost.ScoreBoost;
					}
				}
			}
			return score;
		}

		private static float GetJobPriorityBoost(Job job, Staff staff)
		{
			if (job.HighPriority || job is JobAmbulance)
			{
				return _config.JobPriorityScoreBoost;
			}
			if (staff != null && job.JobStartedFromDrop && staff == job.GetStaff())
			{
				return _config.JobPriorityScoreBoost;
			}
			return 1f;
		}

		public static float CalculateRoomJobScore(Room room, Staff staff, Staff assignedStaff, JobRoom job)
		{
			float num = (float)room.QueueLength * _config.JobQueueScore;
			float jobPriorityBoost = GetJobPriorityBoost(job, staff);
			bool num2 = room.Definition._type == RoomDefinition.Type.Reception;
			if (num2)
			{
				num += 0.1f;
			}
			if (!num2 && staff != null && assignedStaff == staff && room.QueueLength == 0)
			{
				num *= _config.JobEmptyQueueScoreMultiplier;
			}
			num += (float)room.NumPeopleUsing<Patient>() * _config.JobQueueScore * 2f;
			if (!room.IsFunctional())
			{
				num *= _config.JobNonFunctionalRoomScoreMultiplier;
			}
			if (assignedStaff != null && assignedStaff != staff)
			{
				num *= _config.JobAlreadyAssignedMultiplier;
			}
			if (!num2)
			{
				int jobRoomIndex = room.GetJobRoomIndex(job);
				if (jobRoomIndex > 0)
				{
					jobRoomIndex = Mathf.Min(jobRoomIndex - 1, _config.JobIndexScoreMultipliers.Length - 1);
					num *= _config.JobIndexScoreMultipliers[jobRoomIndex];
				}
			}
			jobPriorityBoost = BoostScoreBasedOnRoom(staff, room, jobPriorityBoost);
			return num * jobPriorityBoost;
		}

		public static float CalculateServiceJobScore(RoomItem item, Staff staff, Job job)
		{
			float num = 0.1f + (float)item.QueueLength * _config.JobQueueScore;
			float jobScoreDistanceMultiplier = GetJobScoreDistanceMultiplier(staff, job.GetWorldPosition());
			float num2 = ((staff == null) ? 1f : ((item.OwningRoom == staff.RoomUsing) ? _config.JobSameRoomAsJobScoreBoost : 1f));
			float jobPriorityBoost = GetJobPriorityBoost(job, staff);
			if (item.GetComponent<RoomItemReceptionComponent>() != null)
			{
				num *= 2f;
			}
			jobPriorityBoost = BoostScoreBasedOnRoom(staff, item.OwningRoom, jobPriorityBoost);
			return num * jobScoreDistanceMultiplier * num2 * jobPriorityBoost;
		}

		public static float CalculateMaintenanceJobScore(RoomItem item, Staff staff, JobMaintenance job)
		{
			float num = ((staff != null && job == staff.CurrentJob) ? _config.JobMaintenanceCurrentJobBoost : 1f);
			float num2 = _config.JobMaintenanceBaseJobScore * job.MaintenanceValue / 100f;
			float jobScoreDistanceMultiplier = GetJobScoreDistanceMultiplier(staff, job.GetWorldPosition());
			float num3 = ((staff == null) ? 1f : ((item.OwningRoom == staff.RoomUsing) ? _config.JobSameRoomAsJobScoreBoost : 1f));
			float score = BoostScoreBasedOnRoom(score: GetJobPriorityBoost(job, staff), staff: staff, room: item.OwningRoom);
			score = BoostScoreBasedOnMaintenanceJob(staff, item, score);
			return num2 * num * jobScoreDistanceMultiplier * num3 * item.Definition.JanitorPriority * score;
		}

		public static float CalculateUpgradeJobScore(RoomItem item, Staff staff, Job job)
		{
			float jobScoreDistanceMultiplier = GetJobScoreDistanceMultiplier(staff, job.GetWorldPosition());
			float score = ((staff == null) ? 1f : ((item.OwningRoom == staff.RoomUsing) ? _config.JobSameRoomAsJobScoreBoost : 1f));
			float jobPriorityBoost = GetJobPriorityBoost(job, staff);
			score = BoostScoreBasedOnRoom(staff, item.OwningRoom, score);
			return _config.JobUpgradeScore * jobScoreDistanceMultiplier * score * item.Definition.JanitorPriority * jobPriorityBoost;
		}

		public static float CalculateResearchJobScore(Room room, Staff staff, Job job)
		{
			int numProjects = 0;
			float jobPriorityBoost = GetJobPriorityBoost(job, staff);
			float jobScoreDistanceMultiplier = GetJobScoreDistanceMultiplier(staff, job.GetWorldPosition());
			RoomAlgorithms.IterateRoomItemsWithComponent(room, delegate(ResearchProjectComponent component)
			{
				if (component.Project != null)
				{
					numProjects++;
				}
			});
			jobPriorityBoost = BoostScoreBasedOnRoom(staff, room, jobPriorityBoost);
			return _config.JobResearchScore * (float)numProjects * jobScoreDistanceMultiplier * jobPriorityBoost;
		}

		public static float CalculateMarketingJobScore(Room room, Staff staff, Job job)
		{
			RoomLogicMarketing component = room.GetComponent<RoomLogicMarketing>();
			float num = ((component != null && component.IsProjectAssigned()) ? _config.JobMarketingScore : 0f);
			int num2 = room.NumStaffWorkingInRoom(staff) + 1;
			float jobPriorityBoost = GetJobPriorityBoost(job, staff);
			float jobScoreDistanceMultiplier = GetJobScoreDistanceMultiplier(staff, job.GetWorldPosition());
			jobPriorityBoost = BoostScoreBasedOnRoom(staff, room, jobPriorityBoost);
			return num / (float)num2 * jobScoreDistanceMultiplier * jobPriorityBoost;
		}

		public static float CalculateGhostJobScore(GhostComponent ghostComponent, Staff staff, Job job)
		{
			Character character = ghostComponent.GetOwner() as Character;
			float jobScoreDistanceMultiplier = GetJobScoreDistanceMultiplier(staff, job.GetWorldPosition());
			float num = ((staff == null || character == null) ? 1f : ((character.RoomUsing == staff.RoomUsing) ? _config.JobSameRoomAsJobScoreBoost : 1f));
			float jobPriorityBoost = GetJobPriorityBoost(job, staff);
			return _config.JobGhostScore * jobScoreDistanceMultiplier * num * jobPriorityBoost;
		}

		public static float CalculateFireJobScore(RoomItem item, Staff staff, JobFire job)
		{
			float jobScoreDistanceMultiplier = GetJobScoreDistanceMultiplier(staff, job.GetWorldPosition());
			float num = ((staff == null) ? 1f : ((item.OwningRoom == staff.RoomUsing) ? _config.JobSameRoomAsJobScoreBoost : 1f));
			float jobPriorityBoost = GetJobPriorityBoost(job, staff);
			float num2 = ((staff != null && staff.GetComponent<HasFireExtinguisherComponent>() != null) ? _config.JobFireHasExtinguisherBoost : 1f);
			jobPriorityBoost *= num2;
			return _config.JobFireScore * jobScoreDistanceMultiplier * num * item.Definition.JanitorPriority * jobPriorityBoost;
		}

		public static float CalculateJobAmbulanceScore(RoomItem item, Staff staff, JobAmbulance job)
		{
			float jobScoreDistanceMultiplier = GetJobScoreDistanceMultiplier(staff, job.GetWorldPosition());
			float num = ((staff == null) ? 1f : ((item.OwningRoom == staff.RoomUsing) ? _config.JobSameRoomAsJobScoreBoost : 1f));
			float jobPriorityBoost = GetJobPriorityBoost(job, staff);
			return _config.JobAmbulanceScore * jobScoreDistanceMultiplier * num * item.Definition.JanitorPriority * jobPriorityBoost;
		}

		public static float GetJobScoreDistanceMultiplier(Staff staff, Vector3 jobPosition)
		{
			float num = ((staff != null) ? jobPosition.SquareDistance2D(staff.Position) : 0f);
			return 1f - num / (num + _config.JobDistanceMagicNumber);
		}

		public static float GetJobScoreDistanceMultiplierV1(Staff staff, Vector3 jobPosition)
		{
			float a = ((staff != null) ? jobPosition.SquareDistance2D(staff.Position) : 1f);
			a = Mathf.Max(a, _config.JobMinDistanceScore);
			return 1f / a;
		}

		public static float GetDiagnosisDuration(IllnessDefinition illness, Room room, Staff doctor, ResearchManager researchManager)
		{
			return illness.GetDiagnosisDuration(room, researchManager);
		}

		public static float GetReceptionDuration(Staff receptionist)
		{
			return _config.JobAssistantReceptionDuration / receptionist.GetServiceMultiplier(null);
		}

		public static float GetKioskDuration(Staff assistant)
		{
			return _config.JobAssistantKioskDuration / assistant.GetServiceMultiplier(null);
		}

		public static int CalculateMarketRateSalary(StaffDefinition definition, int rank, float XP, List<QualificationSlot> qualifications)
		{
			_calculateMarketRateSalaryParam.Percent = 0f;
			int salary = definition.GetSalary(rank, XP);
			foreach (QualificationSlot qualification in qualifications)
			{
				if (qualification.IsComplete())
				{
					qualification.Definition.IterateModifiersOfType(_calculateMarketRateSalaryParam, delegate(CalculateMarketRateSalaryParam param, CharacterModifierSalary modifier)
					{
						param.Percent += modifier.Percent;
					});
				}
			}
			return salary + Mathf.CeilToInt((float)salary / 100f * _calculateMarketRateSalaryParam.Percent);
		}

		public static int CalculateDesiredSalary(StaffDefinition definition, int rank, float XP, List<QualificationSlot> qualifications, CharacterTraits traits, float premiumMultiplier)
		{
			int num = CalculateMarketRateSalary(definition, rank, XP, qualifications);
			_calculateDesiredSalaryParameter.Percent = 0f;
			traits.IterateAllModifiers(_calculateDesiredSalaryParameter, delegate(CalculateDesiredSalaryParameter p, CharacterModifierSalary modifier, CharacterTraitDefinition trait)
			{
				p.Percent += modifier.Percent;
			});
			return (int)((float)(num + Mathf.CeilToInt((float)num / 100f * _calculateDesiredSalaryParameter.Percent)) * premiumMultiplier);
		}

		public static float CalculatePaySatisfactionValue(StaffDefinition definition, float percentDifference, out StaffDefinition.Satisfaction satisfactionLevel)
		{
			satisfactionLevel = CalculatePaySatisfactionLevel(percentDifference);
			return satisfactionLevel switch
			{
				StaffDefinition.Satisfaction.VeryUnhappy => definition.PaySatisfactionVeryUnhappy, 
				StaffDefinition.Satisfaction.Unhappy => definition.PaySatisfactionUnhappy, 
				StaffDefinition.Satisfaction.Satisfied => definition.PaySatisfactionSatisfied, 
				StaffDefinition.Satisfaction.Happy => definition.PaySatisfactionHappy, 
				StaffDefinition.Satisfaction.VeryHappy => definition.PaySatisfactionVeryHappy, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		public static StaffDefinition.Satisfaction CalculatePaySatisfactionLevel(float percentDifference)
		{
			if (percentDifference < -0.2f)
			{
				return StaffDefinition.Satisfaction.VeryUnhappy;
			}
			if (percentDifference < -0.1f)
			{
				return StaffDefinition.Satisfaction.Unhappy;
			}
			if (percentDifference < 0.1f)
			{
				return StaffDefinition.Satisfaction.Satisfied;
			}
			if (percentDifference < 0.2f)
			{
				return StaffDefinition.Satisfaction.Happy;
			}
			return StaffDefinition.Satisfaction.VeryHappy;
		}

		public static bool DoesHospitalHaveRoom(WorldState worldState, RoomDefinition.Type roomType)
		{
			foreach (Room allRoom in worldState.AllRooms)
			{
				if (allRoom.Definition._type == roomType)
				{
					return true;
				}
			}
			return false;
		}

		public static void PassHygieneBetweenCharacters(Character character1, Character character2)
		{
			bool flag = false;
			if (character1 == null)
			{
				flag = true;
				Logging.Error("PassHygieneBetweenCharacters: Character 1 was null");
			}
			if (character2 == null)
			{
				flag = true;
				Logging.Error("PassHygieneBetweenCharacters: Character 2 was null");
			}
			if (!flag)
			{
				AttributeFloat attribute = character1.GetCharacterAttributes().GetAttribute(CharacterAttributes.Type.Hygiene);
				AttributeFloat attribute2 = character2.GetCharacterAttributes().GetAttribute(CharacterAttributes.Type.Hygiene);
				if (attribute != null && attribute2 != null)
				{
					float num = attribute.Value();
					float num2 = attribute2.Value();
					AttributeFloat attributeFloat = ((num > num2) ? attribute : attribute2);
					float num3 = Mathf.Abs(num - num2);
					attributeFloat.Modify((0f - num3) * _config.PersonToPersonHygieneMultiplier, 1f);
				}
			}
		}

		public static float CalculateTrainingPointLearnRate(Staff trainer, Staff trainee, int classSize, Room room)
		{
			if (trainer == null || trainee == null || classSize == 0)
			{
				return 0f;
			}
			float trainingLearningSpeed = trainee.GetTrainingLearningSpeed();
			float trainingTeachingSpeed = trainer.GetTrainingTeachingSpeed();
			float num = 1f - (float)(classSize - 1) / (float)(classSize + 40);
			float num2 = 1f;
			_roomModifierTrainingRateCached.Clear();
			foreach (RoomItem item in room.FloorPlan.Items)
			{
				item.GetRoomModifiersOfType(_roomModifierTrainingRateCached);
				foreach (RoomModifierTrainingRate item2 in _roomModifierTrainingRateCached)
				{
					num2 += item2.Percentage / 100f;
				}
				_roomModifierTrainingRateCached.Clear();
			}
			return trainingLearningSpeed * trainingTeachingSpeed * num * num2;
		}

		public static float CalculateTrainingCourseProgress(QualificationDefinition course, List<Staff> trainees)
		{
			float num = 0f;
			if (course != null && trainees.Count != 0)
			{
				foreach (Staff trainee in trainees)
				{
					QualificationSlot qualificationSlot = trainee.GetQualificationSlot(course);
					if (qualificationSlot != null)
					{
						num += qualificationSlot.FractionComplete;
					}
				}
				num /= (float)trainees.Count;
			}
			return num;
		}

		public static bool AnyStaffCompletedQualification(Level level, QualificationDefinition qualification)
		{
			foreach (Staff staffMember in level.CharacterManager.StaffMembers)
			{
				if (staffMember.CurrentMode != Staff.Mode.Fired && staffMember.CurrentMode != Staff.Mode.Resigned && staffMember.HasCompletedQualification(qualification))
				{
					return true;
				}
			}
			return false;
		}

		public static float CalculateHygieneEnvironmentRating(Level level)
		{
			float num = level.CharacterManager.CalculateEnvironmentRating(CharacterAttributes.Type.Hygiene) * Config.HygieneRatingCharacterWeight;
			return ((float)level.WorldState.GetEnvironmentRating(HospitalAttributeMap.Attribute.Hygiene) * Config.HygieneRatingEnvironmentWeight + num) / (Config.HygieneRatingCharacterWeight + Config.HygieneRatingEnvironmentWeight);
		}

		public static int CalculateEnvironmentThermalComfort(Level level)
		{
			int num = 0;
			int num2 = 0;
			float environmentThermalComfortMinimum = Config.EnvironmentThermalComfortMinimum;
			float environmentThermalComfortMaximum = Config.EnvironmentThermalComfortMaximum;
			HospitalAttributeMap hospitalAttributeMap = level.WorldState.HospitalAttributeMaps[0];
			foreach (Room allRoom in level.WorldState.AllRooms)
			{
				if (allRoom.Definition.IsNoDataRoom || !allRoom.IsInBoughtPlot() || allRoom.IsInEnergyGeneratingPlot())
				{
					continue;
				}
				FloorPlan floorPlan = allRoom.FloorPlan;
				for (int i = 0; i < floorPlan.Height(); i++)
				{
					for (int j = 0; j < floorPlan.Width(); j++)
					{
						if (floorPlan[j, i])
						{
							Vector3 worldPosition = (new GridCoord(j, i) + floorPlan.Anchor).ToWorldPosition();
							float mapAttribute = hospitalAttributeMap.GetMapAttribute(worldPosition);
							if (mapAttribute >= environmentThermalComfortMinimum && mapAttribute <= environmentThermalComfortMaximum)
							{
								num2++;
							}
							num++;
						}
					}
				}
			}
			if (num == 0)
			{
				return 0;
			}
			return num2 * 100 / num;
		}

		public static int CalculateCharactersThermalComfort(Level level)
		{
			int num = 0;
			int num2 = 0;
			HospitalAttributeMap hospitalAttributeMap = level.WorldState.HospitalAttributeMaps[0];
			foreach (Character allCharacter in level.CharacterManager.AllCharacters)
			{
				float mapAttribute = hospitalAttributeMap.GetMapAttribute(allCharacter.Position);
				CharacterDefinition.EnvironmentHappiness environmentHappinessModifier = allCharacter.Definition.GetEnvironmentHappinessModifier(HospitalAttributeMap.Attribute.Temperature);
				if (mapAttribute >= environmentHappinessModifier.StableMin && mapAttribute <= environmentHappinessModifier.StableMax)
				{
					num2++;
				}
				num++;
			}
			if (num == 0)
			{
				return 0;
			}
			return num2 * 100 / num;
		}

		public static bool IsCharacterHappyToPay(Character character, int amount, int baseAmount)
		{
			if (character is Staff)
			{
				return true;
			}
			AttributeFloat happiness = character.Happiness;
			if (happiness != null)
			{
				int num = amount - baseAmount;
				float num2 = ((num > 0) ? Config.CharacterOverChargedHappiness : Config.CharacterUnderChargedHappiness);
				float characterChargedHappinessBalance = Config.CharacterChargedHappinessBalance;
				float num3 = num2 * (float)Mathf.Abs(num) / ((float)Mathf.Abs(num) + characterChargedHappinessBalance);
				happiness.Modify(num3, 1f);
				if (happiness.Value() <= Config.CharacterMinHappinessForOvercharge && num3 < 0f)
				{
					return false;
				}
			}
			return true;
		}
	}
}
