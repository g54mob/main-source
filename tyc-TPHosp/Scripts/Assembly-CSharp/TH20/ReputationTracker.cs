using System;
using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using UnityConsole;
using UnityEngine;
using UnityEngine.Serialization;

namespace TH20
{
	public class ReputationTracker : MustCallDestroy, IGameEventsBase
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public float MedicalRepWeight = 1f;

			public float PatientRepWeight = 1f;

			public float PricesRepWeight = 1f;

			public float StaffRepWeight = 1f;

			public float SpecialRepWeight = 1f;

			[InspectorMargin(8)]
			public float StaffReputationRate = 1f;

			public float PatientReputationRate = 1f;

			[InspectorMargin(8)]
			[FormerlySerializedAs("OverallPowK")]
			public float OverallReputationPowK = 0.1f;

			[FormerlySerializedAs("OverallPowE")]
			public float OverallReputationPowE = 2f;

			[InspectorMargin(8)]
			[InspectorHeader("Per Illness Config")]
			public float IllnessReputationPowK = 0.1f;

			public float IllnessReputationPowE = 2f;

			public float IllnessReputationMin = -1000f;

			public float IllnessReputationMax = 1000f;

			public float IllnessDecayRateOverTime;

			[InspectorMargin(8)]
			[InspectorHeader("Total Illnesses Config")]
			public float MedicalReputationPowK = 0.1f;

			public float MedicalReputationPowE = 2f;

			public float MedicalReputationMin = -1000000f;

			public float MedicalReputationMax = 1000000f;

			[InspectorMargin(8)]
			public float StaffReputationPowK = 0.1f;

			public float StaffReputationPowE = 2f;

			public float StaffReputationMin = -1000000f;

			public float StaffReputationMax = 1000000f;

			[InspectorMargin(8)]
			public float PatientReputationPowK = 0.1f;

			public float PatientReputationPowE = 2f;

			public float PatientReputationMin = -1000000f;

			public float PatientReputationMax = 1000000f;

			[InspectorMargin(8)]
			public float SpecialReputationPowK = 0.1f;

			public float SpecialReputationPowE = 2f;

			public float SpecialReputationMin = -1000f;

			public float SpecialReputationMax = 1000f;

			public float SpecialDecayRateOverTime;

			[InspectorMargin(8)]
			public float PriceReputationPowK = 0.1f;

			public float PriceReputationPowE = 2f;

			public float PricesReputationMin = -1000000f;

			public float PricesReputationMax = 1000000f;

			public float PricesDecayRateOverTime;
		}

		public class IllnessRecord
		{
			public float Reputation;

			public float Normalised;
		}

		public Action<float> OnReputationAwarded;

		public Action<float> OnReputationChangedEvent;

		private readonly Config _config;

		private readonly Level _level;

		private float _overallReputation;

		private float _normalisedOverallReputation;

		private float _totalMedicalReputation;

		private float _normalisedMedicalReputation = 0.5f;

		private float _totalPatientReputation;

		private float _desiredTotalPatientReputation;

		private float _totalStaffReputation;

		private float _desiredTotalStaffReputation;

		private float _normalisedStaffReputation;

		private float _totalPricesReputation;

		private float _totalSpecialReputation;

		private readonly Dictionary<IllnessDefinition, IllnessRecord> _illnessReputations;

		[DontSave]
		private GUIStyle _debugGUIStyle;

		public float OverallReputation => _normalisedOverallReputation;

		public float StaffReputation => _normalisedStaffReputation;

		public float MedicalReputation => _normalisedMedicalReputation;

		public float PatientReputation => Normalise(_totalPatientReputation, _config.PatientReputationPowK, _config.PatientReputationPowE);

		public float SpecialReputation => Normalise(_totalSpecialReputation, _config.SpecialReputationPowK, _config.SpecialReputationPowE);

		public float PriceReputation => Normalise(_totalPricesReputation, _config.PriceReputationPowK, _config.PriceReputationPowE);

		public Dictionary<IllnessDefinition, IllnessRecord> IllnessReputations => _illnessReputations;

		public float TotalSpecialReputation
		{
			get
			{
				return _totalSpecialReputation;
			}
			set
			{
				_totalSpecialReputation = value;
				CalculateOverallHospitalReputation();
			}
		}

		private static float Normalise(float v, float k, float e)
		{
			return 1f / (1f + Mathf.Pow(e, (0f - v) * k));
		}

		private static float ConvertPercentToRange(float value)
		{
			return (value * 2f - 100f) / 100f;
		}

		public ReputationTracker(Config config, Level level)
		{
			GameEventsRegistry.RegisterLevelEvent(this);
			_config = config;
			_level = level;
			_illnessReputations = new Dictionary<IllnessDefinition, IllnessRecord>();
			Level level2 = _level;
			level2.PostConstruct = (Action)Delegate.Combine(level2.PostConstruct, new Action(RegisterEvents));
			ConsoleCommandsDatabase.RegisterCommand("ModifyReputation", "Changes special reputation by some amount", "ModifyReputation Amount, e.g. ModifyReputation -100", Debug_ModifyReputation);
		}

		private void RegisterEvents()
		{
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnPatientDied = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientDied, new Action<Patient>(OnPatientDied));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnPatientRageQuit = (Action<Patient>)Delegate.Combine(characterEvents2.OnPatientRageQuit, new Action<Patient>(OnPatientRageQuit));
			CharacterEvents characterEvents3 = _level.CharacterEvents;
			characterEvents3.OnPatientReceivedTreatment = (Action<Patient, Staff, Room>)Delegate.Combine(characterEvents3.OnPatientReceivedTreatment, new Action<Patient, Staff, Room>(OnPatientReceivedTreatment));
			CharacterEvents characterEvents4 = _level.CharacterEvents;
			characterEvents4.OnPatientSentHome = (Action<Patient>)Delegate.Combine(characterEvents4.OnPatientSentHome, new Action<Patient>(OnPatientSentHome));
			CharacterEvents characterEvents5 = _level.CharacterEvents;
			characterEvents5.OnPatientTimeTunnel = (Action<Patient>)Delegate.Combine(characterEvents5.OnPatientTimeTunnel, new Action<Patient>(OnPatientTimeTunnel));
			FinanceManager financeManager = _level.FinanceManager;
			financeManager.OnCharacterChargedForInteraction = (Action<Character, FinanceModifier, int, int>)Delegate.Combine(financeManager.OnCharacterChargedForInteraction, new Action<Character, FinanceModifier, int, int>(OnCharacterChargedForInteraction));
			FinanceManager financeManager2 = _level.FinanceManager;
			financeManager2.OnPatientChargedForDiagnosis = (FinanceManager.PatientChargedForDiagnosisDelegate)Delegate.Combine(financeManager2.OnPatientChargedForDiagnosis, new FinanceManager.PatientChargedForDiagnosisDelegate(OnPatientChargedForDiagnosis));
			FinanceManager financeManager3 = _level.FinanceManager;
			financeManager3.OnPatientChargedForTreatment = (FinanceManager.PatientChargedForTreatmentDelegate)Delegate.Combine(financeManager3.OnPatientChargedForTreatment, new FinanceManager.PatientChargedForTreatmentDelegate(OnPatientChargedForTreatment));
			MarketingManager marketingManager = _level.MarketingManager;
			marketingManager.OnApplyGeneralCampaign = (Action<GeneralMarketingCampaignDefinition, float>)Delegate.Combine(marketingManager.OnApplyGeneralCampaign, new Action<GeneralMarketingCampaignDefinition, float>(OnApplyGeneralCampaign));
			MarketingManager marketingManager2 = _level.MarketingManager;
			marketingManager2.OnApplyIllnessCampaign = (Action<IllnessMarketingCampaignDefinition, float>)Delegate.Combine(marketingManager2.OnApplyIllnessCampaign, new Action<IllnessMarketingCampaignDefinition, float>(OnApplyIllnessCampaign));
		}

		public override void Destroy()
		{
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnPatientDied = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientDied, new Action<Patient>(OnPatientDied));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnPatientRageQuit = (Action<Patient>)Delegate.Remove(characterEvents2.OnPatientRageQuit, new Action<Patient>(OnPatientRageQuit));
			CharacterEvents characterEvents3 = _level.CharacterEvents;
			characterEvents3.OnPatientReceivedTreatment = (Action<Patient, Staff, Room>)Delegate.Remove(characterEvents3.OnPatientReceivedTreatment, new Action<Patient, Staff, Room>(OnPatientReceivedTreatment));
			CharacterEvents characterEvents4 = _level.CharacterEvents;
			characterEvents4.OnPatientSentHome = (Action<Patient>)Delegate.Remove(characterEvents4.OnPatientSentHome, new Action<Patient>(OnPatientSentHome));
			CharacterEvents characterEvents5 = _level.CharacterEvents;
			characterEvents5.OnPatientTimeTunnel = (Action<Patient>)Delegate.Remove(characterEvents5.OnPatientTimeTunnel, new Action<Patient>(OnPatientTimeTunnel));
			FinanceManager financeManager = _level.FinanceManager;
			financeManager.OnCharacterChargedForInteraction = (Action<Character, FinanceModifier, int, int>)Delegate.Remove(financeManager.OnCharacterChargedForInteraction, new Action<Character, FinanceModifier, int, int>(OnCharacterChargedForInteraction));
			FinanceManager financeManager2 = _level.FinanceManager;
			financeManager2.OnPatientChargedForDiagnosis = (FinanceManager.PatientChargedForDiagnosisDelegate)Delegate.Remove(financeManager2.OnPatientChargedForDiagnosis, new FinanceManager.PatientChargedForDiagnosisDelegate(OnPatientChargedForDiagnosis));
			FinanceManager financeManager3 = _level.FinanceManager;
			financeManager3.OnPatientChargedForTreatment = (FinanceManager.PatientChargedForTreatmentDelegate)Delegate.Remove(financeManager3.OnPatientChargedForTreatment, new FinanceManager.PatientChargedForTreatmentDelegate(OnPatientChargedForTreatment));
			MarketingManager marketingManager = _level.MarketingManager;
			marketingManager.OnApplyGeneralCampaign = (Action<GeneralMarketingCampaignDefinition, float>)Delegate.Remove(marketingManager.OnApplyGeneralCampaign, new Action<GeneralMarketingCampaignDefinition, float>(OnApplyGeneralCampaign));
			MarketingManager marketingManager2 = _level.MarketingManager;
			marketingManager2.OnApplyIllnessCampaign = (Action<IllnessMarketingCampaignDefinition, float>)Delegate.Remove(marketingManager2.OnApplyIllnessCampaign, new Action<IllnessMarketingCampaignDefinition, float>(OnApplyIllnessCampaign));
			ConsoleCommandsDatabase.UnRegisterCommand("ModifyReputation");
			base.Destroy();
		}

		public void VerifyEvents()
		{
			OnReputationAwarded.VerifyIsNull();
			OnReputationChangedEvent.VerifyIsNull();
		}

		public void Update(float deltaTime)
		{
			UpdateReputationDecay(deltaTime);
			CalculateStaffReputation(deltaTime);
			CalculatePatientReputation(deltaTime);
			CalculateOverallHospitalReputation();
		}

		private void CalculateOverallHospitalReputation()
		{
			_overallReputation = _totalMedicalReputation * _config.MedicalRepWeight;
			_overallReputation += _totalPatientReputation * _config.PatientRepWeight;
			_overallReputation += _totalPricesReputation * _config.PricesRepWeight;
			_overallReputation += _totalStaffReputation * _config.StaffRepWeight;
			_overallReputation += _totalSpecialReputation * _config.SpecialRepWeight;
			float num = Normalise(_overallReputation, _config.OverallReputationPowK, _config.OverallReputationPowE);
			if (num > _normalisedOverallReputation || num < _normalisedOverallReputation)
			{
				_normalisedOverallReputation = num;
				OnReputationChangedEvent.InvokeSafe(_normalisedOverallReputation);
			}
		}

		private void UpdateReputationDecay(float deltaTime)
		{
			_totalMedicalReputation = 0f;
			foreach (IllnessRecord value in _illnessReputations.Values)
			{
				value.Reputation = DecayValue(value.Reputation, _config.IllnessDecayRateOverTime, deltaTime);
				value.Normalised = Normalise(value.Reputation, _config.IllnessReputationPowK, _config.IllnessReputationPowE);
				_totalMedicalReputation += value.Reputation;
			}
			_totalPricesReputation = DecayValue(_totalPricesReputation, _config.PricesDecayRateOverTime, deltaTime);
			_totalSpecialReputation = DecayValue(_totalSpecialReputation, _config.SpecialDecayRateOverTime, deltaTime);
			_totalMedicalReputation = Mathf.Clamp(_totalMedicalReputation, _config.MedicalReputationMin, _config.MedicalReputationMax);
			_normalisedMedicalReputation = Normalise(_totalMedicalReputation, _config.MedicalReputationPowK, _config.MedicalReputationPowE);
		}

		private static float DecayValue(float value, float rate, float deltaTime)
		{
			if (!(value < 0f))
			{
				return Mathf.Max(value - rate * deltaTime, 0f);
			}
			return Mathf.Min(value + rate * deltaTime, 0f);
		}

		private void CalculateStaffReputation(float deltaTime)
		{
			_desiredTotalStaffReputation = 0f;
			foreach (Staff staffMember in _level.CharacterManager.StaffMembers)
			{
				if (staffMember.Happiness != null)
				{
					_desiredTotalStaffReputation += ConvertPercentToRange(staffMember.Happiness.Value());
				}
			}
			float num = (_desiredTotalStaffReputation - _totalStaffReputation) * deltaTime * _config.StaffReputationRate;
			_totalStaffReputation = Mathf.Clamp(_totalStaffReputation + num, _config.StaffReputationMin, _config.StaffReputationMax);
			if (float.IsNaN(_totalStaffReputation) || float.IsInfinity(_totalStaffReputation))
			{
				_totalStaffReputation = _desiredTotalStaffReputation;
			}
			_normalisedStaffReputation = Normalise(_totalStaffReputation, _config.StaffReputationPowK, _config.StaffReputationPowE);
		}

		private void CalculatePatientReputation(float deltaTime)
		{
			_desiredTotalPatientReputation = 0f;
			foreach (Patient patient in _level.CharacterManager.Patients)
			{
				if (patient.Happiness != null)
				{
					_desiredTotalPatientReputation += ConvertPercentToRange(patient.Happiness.Value());
				}
			}
			float num = (_desiredTotalPatientReputation - _totalPatientReputation) * deltaTime * _config.PatientReputationRate;
			_totalPatientReputation = Mathf.Clamp(_totalPatientReputation + num, _config.PatientReputationMin, _config.PatientReputationMax);
		}

		private void ModifySpecialReputation(float amount)
		{
			_totalSpecialReputation = Mathf.Clamp(_totalSpecialReputation + amount, _config.SpecialReputationMin, _config.SpecialReputationMax);
		}

		private void ModifyMedicalReputation(IllnessDefinition illness, float amount)
		{
			if (!_illnessReputations.ContainsKey(illness))
			{
				_illnessReputations.Add(illness, new IllnessRecord());
			}
			IllnessRecord illnessRecord = _illnessReputations[illness];
			illnessRecord.Reputation = Mathf.Clamp(illnessRecord.Reputation + amount, _config.IllnessReputationMin, _config.IllnessReputationMax);
			illnessRecord.Normalised = Normalise(illnessRecord.Reputation, _config.IllnessReputationPowK, _config.IllnessReputationPowE);
		}

		private ConsoleCommandResult Debug_ModifyReputation(params string[] args)
		{
			return ConsoleCommandHelpers.ExtractFloat(ModifySpecialReputation, args);
		}

		public void AwardReputation(float amount)
		{
			ModifySpecialReputation(amount);
			OnReputationAwarded.InvokeSafe(amount);
		}

		private void OnPatientDied(Patient patient)
		{
			ModifyMedicalReputation(patient.Illness, patient.Illness.GetTreatmentReputationModifier(Treatment.Outcome.Death));
		}

		private void OnPatientRageQuit(Patient patient)
		{
			ModifyMedicalReputation(patient.Illness, patient.Illness._reputationPatientRageQuit);
		}

		private void OnPatientReceivedTreatment(Patient patient, Staff doctor, Room room)
		{
			ModifyMedicalReputation(patient.Illness, patient.Illness.GetTreatmentReputationModifier(patient.TreatmentOutcome));
		}

		private void OnPatientSentHome(Patient patient)
		{
			ModifyMedicalReputation(patient.Illness, patient.Illness._reputationPatientWaitTooLong);
		}

		private void OnPatientTimeTunnel(Patient patient)
		{
			ModifyMedicalReputation(patient.Illness, patient.Illness._reputationTreatmentSentHome);
		}

		private void OnCharacterChargedForInteraction(Character character, FinanceModifier financeModifier, int amount, int baseAmount)
		{
			if (character is Patient)
			{
				OnPatientCharged(amount, baseAmount);
			}
		}

		private void OnPatientChargedForDiagnosis(Patient patient, Staff staff, Room room, float certaintyIncrement, int amount, int baseAmount)
		{
			OnPatientCharged(amount, baseAmount);
		}

		private void OnPatientChargedForTreatment(Patient patient, Staff staff, Room room, int amount, int baseAmount)
		{
			OnPatientCharged(amount, baseAmount);
		}

		private void OnPatientCharged(int amount, int baseAmount)
		{
			int num = amount - baseAmount;
			_totalPricesReputation = Mathf.Clamp(_totalPricesReputation - (float)num, _config.PricesReputationMin, _config.PricesReputationMax);
		}

		public float GetIllnessReputation(IllnessDefinition illness)
		{
			if (_illnessReputations.ContainsKey(illness))
			{
				return _illnessReputations[illness].Normalised;
			}
			return 0.5f;
		}

		private void OnApplyGeneralCampaign(GeneralMarketingCampaignDefinition definition, float amount)
		{
			AwardReputation(amount);
		}

		private void OnApplyIllnessCampaign(IllnessMarketingCampaignDefinition definition, float amount)
		{
			foreach (IllnessDefinition illness in definition.GetIllnesses(_level))
			{
				ModifyMedicalReputation(illness, amount);
			}
		}

		public void RestoreFromSave(CharacterManager characterManager)
		{
			RegisterEvents();
		}

		public void DebugGUI()
		{
			if (DebugVars.ShowReputationTrackerInfo.Value)
			{
				string empty = string.Empty;
				if (_debugGUIStyle == null)
				{
					_debugGUIStyle = new GUIStyle(GUI.skin.box)
					{
						alignment = TextAnchor.LowerLeft,
						font = Font.CreateDynamicFontFromOSFont("Consolas", 12),
						fontStyle = FontStyle.Bold
					};
				}
				empty += "REPUTATION TRACKER\n";
				empty += $"\n    Prices = {StringUtils.FormatFloat(_totalPricesReputation, prefixPlus: true),8}";
				empty += $"\n   Special = {StringUtils.FormatFloat(_totalSpecialReputation, prefixPlus: true),8}";
				empty += $"\n   Patient = {StringUtils.FormatFloat(_totalPatientReputation, prefixPlus: true),8}       Desired = {StringUtils.FormatFloat(_desiredTotalPatientReputation, prefixPlus: true),8}";
				empty += $"\n   Medical = {StringUtils.FormatFloat(_totalMedicalReputation, prefixPlus: true),8}    Normalised = {StringUtils.FormatFloat(_normalisedMedicalReputation, prefixPlus: true),8}";
				empty += $"\n     Staff = {StringUtils.FormatFloat(_totalStaffReputation, prefixPlus: true),8}       Desired = {StringUtils.FormatFloat(_desiredTotalStaffReputation, prefixPlus: true),8}    Normalised = {StringUtils.FormatFloat(_normalisedStaffReputation, prefixPlus: true),8}";
				empty += $"\n   Overall = {StringUtils.FormatFloat(_overallReputation, prefixPlus: true),8}    Normalised = {StringUtils.FormatFloat(_normalisedOverallReputation, prefixPlus: true),8}";
				Vector2 vector = _debugGUIStyle.CalcSize(new GUIContent(empty));
				GUI.Box(new Rect(0f, (float)Screen.height - vector.y, vector.x, vector.y), empty, _debugGUIStyle);
			}
		}
	}
}
