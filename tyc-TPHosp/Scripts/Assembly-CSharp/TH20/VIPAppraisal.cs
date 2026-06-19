#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace TH20
{
	public class VIPAppraisal
	{
		private struct AppraisalResult
		{
			public float Result;

			public float NormalisedResult;

			public bool IsInRoom;
		}

		public enum Criteria
		{
			EnvironmentAttractiveness = 0,
			EnvironmentTemperature = 1,
			EnvironmentHygiene = 2,
			StaffHappiness = 3,
			StaffEnergy = 4,
			StaffRankQualification = 5,
			StaffGotFired = 6,
			PatientHappiness = 7,
			PatientHealth = 8,
			PatientRageQuitting = 9,
			PatientIsDead = 10,
			PatientIsCured = 11,
			PatientTreatmentIneffective = 12,
			RoomUnderstaffed = 13,
			ItemMaintenance = 14,
			WasteItems = 15,
			RoomPrestige = 16,
			TourTooShort = 17,
			HospitalEcoRating = 18
		}

		private readonly Visitor _visitor;

		private readonly Level _level;

		private readonly VIPAppraisalCriteriaRangesConfig _config;

		private readonly List<AppraisalResult>[] _appraisalTally;

		private readonly float[] _criteriaWeightings;

		private readonly VIPComponent _vipComponent;

		private Room _roomBeingAppraised;

		private float _roomTemperatureTotal;

		private float _roomHygieneTotal;

		private float _roomAttractivenessTotal;

		public VIPAppraisal(Visitor visitor, Level level, VIPAppraisalCriteriaRangesConfig config, VIPAppraisalCriteriaInterest interest)
		{
			_visitor = visitor;
			_level = level;
			_config = config;
			_vipComponent = _visitor.GetComponent<VIPComponent>();
			int length = Enum.GetValues(typeof(Criteria)).Length;
			_appraisalTally = new List<AppraisalResult>[length];
			for (int i = 0; i < length; i++)
			{
				_appraisalTally[i] = new List<AppraisalResult>();
			}
			FieldInfo[] fields = interest.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (fields.Length != length)
			{
				Logging.Error("RB: VIPAppraisal.Criteria.Count must equal VIPAppraisalCriteriaInterest.Count!  But it currently doesn't!  Fix this now otherwise the appraisal result will be incorrect.");
			}
			_criteriaWeightings = new float[fields.Length];
			for (int j = 0; j < _criteriaWeightings.Length; j++)
			{
				_criteriaWeightings[j] = (float)fields[j].GetValue(interest);
			}
		}

		public float CalculateCurrentScore()
		{
			float num = 0f;
			for (int i = 0; i < _appraisalTally.Length; i++)
			{
				for (int j = 0; j < _appraisalTally[i].Count; j++)
				{
					float num2 = _config.CorridorObservationMultiplier;
					if (_appraisalTally[i][j].IsInRoom)
					{
						num2 = _config.RoomObservationMultiplier;
					}
					num += _appraisalTally[i][j].NormalisedResult * _criteriaWeightings[i] * num2;
				}
			}
			return num;
		}

		public void SubmitAppraiseValue(Criteria criteria, bool inRoom, float value)
		{
			AppraisalResult item = new AppraisalResult
			{
				Result = value,
				NormalisedResult = NormaliseAppraisalValue(criteria, value),
				IsInRoom = inRoom
			};
			_appraisalTally[(int)criteria].Add(item);
		}

		private float NormaliseAppraisalValue(Criteria criteria, float value)
		{
			return criteria switch
			{
				Criteria.EnvironmentTemperature => NormaliseWithSweetSpot(value, _config.EnvironmentTemperatureMin, _config.EnvironmentTemperatureSweetSpotMin, _config.EnvironmentTemperatureSweetSpotMax, _config.EnvironmentTemperatureMax), 
				Criteria.EnvironmentAttractiveness => NormaliseWithMinMax(value, _config.EnvironmentAttractivenessMin, _config.EnvironmentAttractivenessMax), 
				Criteria.EnvironmentHygiene => NormaliseWithMinMax(value, _config.EnvironmentHygieneMin, _config.EnvironmentHygieneMax), 
				Criteria.StaffHappiness => NormaliseWithMinMax(value, _config.StaffHappinessMin, _config.StaffHappinessMax), 
				Criteria.StaffEnergy => NormaliseWithMinMax(value, _config.StaffEnergyMin, _config.StaffEnergyMax), 
				Criteria.StaffRankQualification => NormaliseWithMinMax(value, _config.StaffRankQualificationMin, _config.StaffRankQualificationMax), 
				Criteria.PatientHappiness => NormaliseWithMinMax(value, _config.PatientHappinessMin, _config.PatientHappinessMax), 
				Criteria.PatientHealth => NormaliseWithMinMax(value, _config.PatientHealthMin, _config.PatientHealthMax), 
				Criteria.ItemMaintenance => NormaliseWithMinMax(value, _config.ItemMaintenanceMin, _config.ItemMaintenanceMax), 
				Criteria.RoomPrestige => NormaliseWithMinMax(value, _config.RoomPrestigeMin, _config.RoomPrestigeMax), 
				Criteria.HospitalEcoRating => NormaliseWithMinMax(value, _config.HospitalEcoRatingMin, _config.HospitalEcoRatingMax), 
				_ => value, 
			};
		}

		private float NormaliseWithSweetSpot(float value, float min, float sweet_min, float sweet_max, float max)
		{
			if (value < sweet_min)
			{
				return NormaliseWithMinMax(value, min, sweet_min);
			}
			if (value > sweet_max)
			{
				return NormaliseWithMinMax(value, sweet_max, max);
			}
			return 1f;
		}

		private float NormaliseWithMinMax(float value, float min, float max)
		{
			if (max == min)
			{
				return 0f;
			}
			return Mathf.Clamp01((value - min) / (max - min)) * 2f - 1f;
		}

		public void AppraiseLocalArea()
		{
			Room roomUsing = _visitor.RoomUsing;
			if (!roomUsing.Definition.IsHospitalOrBay)
			{
				return;
			}
			float num = _vipComponent.Definition.AppraisalVisualRadius * _vipComponent.Definition.AppraisalVisualRadius;
			for (int i = 0; i < _level.CharacterManager.Patients.Count; i++)
			{
				Character character = _level.CharacterManager.Patients[i];
				if (character != _visitor && character.RoomUsing != null && character.RoomUsing.Definition.IsHospitalOrBay && Vector3.SqrMagnitude(_visitor.Position - character.Position) < num)
				{
					AppraiseCharacter(character, inRoom: false);
				}
			}
			for (int j = 0; j < roomUsing.FloorPlan.Items.Count; j++)
			{
				RoomItem roomItem = roomUsing.FloorPlan.Items[j];
				if (Vector3.SqrMagnitude(_visitor.Position - roomItem.WorldPosition) < num)
				{
					AppraiseRoomItem(roomItem, inRoom: false);
				}
			}
		}

		public void AppraiseRoom(Room room)
		{
			if (room == null)
			{
				return;
			}
			if (room.Definition.IsHospitalOrBay)
			{
				AppraiseLocalArea();
				return;
			}
			if (!room.IsStaffed() && room.QueueLength > 0)
			{
				SubmitAppraiseValue(Criteria.RoomUnderstaffed, inRoom: true, 1f);
			}
			for (int i = 0; i < room.CharactersUsing.Count; i++)
			{
				AppraiseCharacter(room.CharactersUsing[i], inRoom: true);
			}
			for (int j = 0; j < room.StaffMembers.Count; j++)
			{
				AppraiseStaff(room.StaffMembers[j], inRoom: true);
			}
			for (int k = 0; k < room.FloorPlan.Items.Count; k++)
			{
				AppraiseRoomItem(room.FloorPlan.Items[k], inRoom: true);
			}
			_roomBeingAppraised = room;
			_roomAttractivenessTotal = 0f;
			_roomHygieneTotal = 0f;
			_roomTemperatureTotal = 0f;
			RoomAlgorithms.IterateFreeRoomTiles(room.FloorPlan, ProcessRoomEnvironmentInformation);
			_roomBeingAppraised = null;
			int tileCount = room.FloorPlan.TileCount;
			if (tileCount > 0)
			{
				float value = _roomTemperatureTotal / (float)tileCount;
				float value2 = _roomAttractivenessTotal / (float)tileCount;
				float value3 = _roomHygieneTotal / (float)tileCount;
				SubmitAppraiseValue(Criteria.EnvironmentTemperature, inRoom: true, value);
				SubmitAppraiseValue(Criteria.EnvironmentAttractiveness, inRoom: true, value2);
				SubmitAppraiseValue(Criteria.EnvironmentHygiene, inRoom: true, value3);
			}
			float value4 = GameAlgorithms.CalculateRoomPrestige(room.FloorPlan).Level;
			SubmitAppraiseValue(Criteria.RoomPrestige, inRoom: true, value4);
		}

		public void AppraiseRoomItem(RoomItem item, bool inRoom)
		{
			if (item.MaintenanceLevel != null)
			{
				SubmitAppraiseValue(Criteria.ItemMaintenance, inRoom, item.MaintenanceLevel.Value());
			}
			if (item.GetComponent<RoomItemMaintenanceComponent>() != null && (item.Definition.MaintenanceDescription == JobMaintenance.JobDescription.Litter || item.Definition.MaintenanceDescription == JobMaintenance.JobDescription.MedicalWaste))
			{
				SubmitAppraiseValue(Criteria.WasteItems, inRoom, 1f);
			}
		}

		public void AppraiseCharacter(Character character, bool inRoom)
		{
			if (character != _visitor)
			{
				if (character is Staff)
				{
					AppraiseStaff((Staff)character, inRoom);
				}
				else if (character is Patient)
				{
					AppraisePatient((Patient)character, inRoom);
				}
			}
		}

		private void AppraiseStaff(Staff staff, bool inRoom)
		{
			if (!(staff is GuestTrainer) && staff.GetComponent<RoboJanitorComponent>() == null)
			{
				CharacterAttributes characterAttributes = staff.GetCharacterAttributes();
				SubmitAppraiseValue(Criteria.StaffHappiness, inRoom, characterAttributes.GetAttribute(CharacterAttributes.Type.Happiness).Value());
				SubmitAppraiseValue(Criteria.StaffEnergy, inRoom, characterAttributes.GetAttribute(CharacterAttributes.Type.Energy).Value());
				SubmitAppraiseValue(Criteria.StaffRankQualification, inRoom, staff.GetSalary());
				if (staff.CurrentMode == Staff.Mode.Fired)
				{
					SubmitAppraiseValue(Criteria.StaffGotFired, inRoom, 1f);
				}
			}
		}

		private void AppraisePatient(Patient patient, bool inRoom)
		{
			CharacterAttributes characterAttributes = patient.GetCharacterAttributes();
			SubmitAppraiseValue(Criteria.PatientHappiness, inRoom, characterAttributes.GetAttribute(CharacterAttributes.Type.Happiness).Value());
			SubmitAppraiseValue(Criteria.PatientHealth, inRoom, characterAttributes.GetAttribute(CharacterAttributes.Type.Health).Value());
			if (patient.CurrentMode == Patient.Mode.RageQuit)
			{
				SubmitAppraiseValue(Criteria.PatientRageQuitting, inRoom, 1f);
			}
			if (patient.CurrentMode == Patient.Mode.Dead)
			{
				SubmitAppraiseValue(Criteria.PatientIsDead, inRoom, 1f);
			}
			if (patient.TreatmentOutcome == Treatment.Outcome.Cured)
			{
				SubmitAppraiseValue(Criteria.PatientIsCured, inRoom, 1f);
			}
			if (patient.TreatmentOutcome == Treatment.Outcome.Ineffective)
			{
				SubmitAppraiseValue(Criteria.PatientTreatmentIneffective, inRoom, 1f);
			}
		}

		private void ProcessRoomEnvironmentInformation(int localX, int localY, bool free)
		{
			if (_roomBeingAppraised != null)
			{
				Vector3 worldPosition = new Vector3(_roomBeingAppraised.FloorPlan.Anchor.X + localX, _roomBeingAppraised.FloorPlan.Anchor.Y + localY, 0f);
				HospitalAttributeMap hospitalAttributeMap = _level.WorldState.HospitalAttributeMaps[0];
				_roomTemperatureTotal += hospitalAttributeMap.GetMapAttribute(worldPosition);
				HospitalAttributeMap hospitalAttributeMap2 = _level.WorldState.HospitalAttributeMaps[1];
				_roomAttractivenessTotal += hospitalAttributeMap2.GetMapAttribute(worldPosition);
				HospitalAttributeMap hospitalAttributeMap3 = _level.WorldState.HospitalAttributeMaps[2];
				_roomHygieneTotal += hospitalAttributeMap3.GetMapAttribute(worldPosition);
			}
		}

		public string PrintCurrentAppraisalBreakdown()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("");
			float num = 0f;
			for (int i = 0; i < _appraisalTally.Length; i++)
			{
				if (_appraisalTally[i].Count <= 0)
				{
					continue;
				}
				Criteria criteria = (Criteria)i;
				string text = criteria.ToString();
				stringBuilder.AppendLine(text);
				stringBuilder.AppendLine(new string('-', text.Length));
				for (int j = 0; j < _appraisalTally[i].Count; j++)
				{
					float num2 = _config.CorridorObservationMultiplier;
					if (_appraisalTally[i][j].IsInRoom)
					{
						num2 = _config.RoomObservationMultiplier;
					}
					num += _appraisalTally[i][j].NormalisedResult * _criteriaWeightings[i] * num2;
					string value = string.Format("{0}: {1} - Score ({2}) = {3} => {4} x ({5} x {6}) = {7}", j, _appraisalTally[i][j].IsInRoom ? "R" : "C", text, _appraisalTally[i][j].Result, _appraisalTally[i][j].NormalisedResult, _criteriaWeightings[i], _appraisalTally[i][j].IsInRoom ? _config.RoomObservationMultiplier : _config.CorridorObservationMultiplier, _appraisalTally[i][j].NormalisedResult * _criteriaWeightings[i]);
					stringBuilder.AppendLine(value);
				}
			}
			string text2 = "Final Score = " + num;
			stringBuilder.AppendLine(new string('=', text2.Length));
			stringBuilder.AppendLine(text2);
			return stringBuilder.ToString();
		}
	}
}
