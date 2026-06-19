using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class TannoyManager : MustCallDestroy
	{
		public static Action<string> OnAnnouncementQueueRequest;

		private const string Tannoy_DoctorRequired_8bit = "Tannoy:DoctorRequired:8bit";

		private const string Tannoy_DoctorRequired_AnimalMag = "Tannoy:DoctorRequired:AnimalMag";

		private const string Tannoy_DoctorRequired_Cardio = "Tannoy:DoctorRequired:Cardio";

		private const string Tannoy_DoctorRequired_Clown = "Tannoy:DoctorRequired:Clown";

		private const string Tannoy_DoctorRequired_Cubism = "Tannoy:DoctorRequired:Cubism";

		private const string Tannoy_DoctorRequired_Decrypter = "Tannoy:DoctorRequired:Decrypter";

		private const string Tannoy_DoctorRequired_Delux = "Tannoy:DoctorRequired:Delux";

		private const string Tannoy_DoctorRequired_DNA = "Tannoy:DoctorRequired:DNA";

		private const string Tannoy_DoctorRequired_DocOff = "Tannoy:DoctorRequired:DocOff";

		private const string Tannoy_DoctorRequired_Fluid = "Tannoy:DoctorRequired:Fluid";

		private const string Tannoy_DoctorRequired_GenDiag = "Tannoy:DoctorRequired:GenDiag";

		private const string Tannoy_DoctorRequired_GP = "Tannoy:DoctorRequired:GP";

		private const string Tannoy_DoctorRequired_MRI = "Tannoy:DoctorRequired:MRI";

		private const string Tannoy_DoctorRequired_Pandemic = "Tannoy:DoctorRequired:Pandemic";

		private const string Tannoy_DoctorRequired_Psychiatry = "Tannoy:DoctorRequired:Psychiatry";

		private const string Tannoy_DoctorRequired_Research = "Tannoy:DoctorRequired:Research";

		private const string Tannoy_DoctorRequired_Shock = "Tannoy:DoctorRequired:Shock";

		private const string Tannoy_DoctorRequired_Surgery = "Tannoy:DoctorRequired:Surgery";

		private const string Tannoy_DoctorRequired_Training = "Tannoy:DoctorRequired:Training";

		private const string Tannoy_DoctorRequired_TurtleHead = "Tannoy:DoctorRequired:TurtleHead";

		private const string Tannoy_DoctorRequired_Xray = "Tannoy:DoctorRequired:Xray";

		private const string Tannoy_DoctorRequired_Frankie = "Tannoy:DoctorRequired:Frankie";

		private const string Tannoy_DoctorRequired_Screwball = "Tannoy:DoctorRequired:Screwball";

		private const string Tannoy_DoctorRequired_Astro = "Tannoy:DoctorRequired:Astro";

		private const string Tannoy_DoctorRequired_Tech = "Tannoy:DoctorRequired:Tech";

		private const string Tannoy_DoctorRequired_ToySoldier = "Tannoy:DoctorRequired:ToySoldier";

		private const string Tannoy_DoctorRequired_Stunt = "Tannoy:DoctorRequired:Stunt";

		private const string Tannoy_DoctorRequired_Hives = "Tannoy:DoctorRequired:Hives";

		private const string Tannoy_DoctorRequired_Snowballed = "Tannoy:DoctorRequired:Snowballed";

		private const string Tannoy_DoctorRequired_UnderTheWeather = "Tannoy:DoctorRequired:UnderTheWeather";

		private const string Tannoy_NurseRequired_Cardio = "Tannoy:NurseRequired:Cardio";

		private const string Tannoy_NurseRequired_Chromatherapy = "Tannoy:NurseRequired:Chromatherapy";

		private const string Tannoy_NurseRequired_Clown = "Tannoy:NurseRequired:Clown";

		private const string Tannoy_NurseRequired_Decrypter = "Tannoy:NurseRequired:Decrypter";

		private const string Tannoy_NurseRequired_Fluid = "Tannoy:NurseRequired:Fluid";

		private const string Tannoy_NurseRequired_Fracture = "Tannoy:NurseRequired:Fracture";

		private const string Tannoy_NurseRequired_GenDiag = "Tannoy:NurseRequired:GenDiag";

		private const string Tannoy_NurseRequired_Injection = "Tannoy:NurseRequired:Injection";

		private const string Tannoy_NurseRequired_Pharmacy = "Tannoy:NurseRequired:Pharmacy";

		private const string Tannoy_NurseRequired_Surgery = "Tannoy:NurseRequired:Surgery";

		private const string Tannoy_NurseRequired_Training = "Tannoy:NurseRequired:Training";

		private const string Tannoy_NurseRequired_Ward = "Tannoy:NurseRequired:Ward";

		private const string Tannoy_NurseRequired_BarkingMad = "Tannoy:NurseRequired:BarkingMad";

		private const string Tannoy_NurseRequired_Robotzilla = "Tannoy:NurseRequired:Robotzilla";

		private const string Tannoy_NurseRequired_BlankLooks = "Tannoy:NurseRequired:BlankLooks";

		private const string Tannoy_NurseRequired_Explorer = "Tannoy:NurseRequired:Explorer";

		private const string Tannoy_NurseRequired_Cardboard = "Tannoy:NurseRequired:Cardboard";

		private const string Tannoy_NurseRequired_Frog = "Tannoy:NurseRequired:Frog";

		private const string Tannoy_NurseRequired_Pinocchio = "Tannoy:NurseRequired:Pinocchio";

		private const string Tannoy_NurseRequired_Scarecrow = "Tannoy:NurseRequired:Scarecrow";

		private const string Tannoy_NurseRequired_PlantWard = "Tannoy:NurseRequired:PlantWard";

		private const string Tannoy_NurseRequired_Stunt = "Tannoy:NurseRequired:Stunt";

		private const string Tannoy_NurseRequired_Mud = "Tannoy:NurseRequired:Mud";

		private const string Tannoy_NurseRequired_Hives = "Tannoy:NurseRequired:Hives";

		private const string Tannoy_NurseRequired_Snowballed = "Tannoy:NurseRequired:Snowballed";

		private const string Tannoy_NurseRequired_UnderTheWeather = "Tannoy:NurseRequired:UnderTheWeather";

		private const string Tannoy_AssistantRequired_Cafe = "Tannoy:AssistantRequired:Cafe";

		private const string Tannoy_AssistantRequired_Kiosk = "Tannoy:AssistantRequired:Kiosk";

		private const string Tannoy_AssistantRequired_Marketing = "Tannoy:AssistantRequired:Marketing";

		private const string Tannoy_AssistantRequired_Reception = "Tannoy:AssistantRequired:Reception";

		private const string Tannoy_AssistantRequired_Training = "Tannoy:AssistantRequired:Training";

		private const string Tannoy_AssistantRequired_TimeTunnel = "Tannoy:AssistantRequired:TimeTunnel";

		private const string Tannoy_CleanupRequired_8bit = "Tannoy:CleanupRequired:8bit";

		private const string Tannoy_CleanupRequired_AnimalMag = "Tannoy:CleanupRequired:AnimalMag";

		private const string Tannoy_CleanupRequired_Cafe = "Tannoy:CleanupRequired:Cafe";

		private const string Tannoy_CleanupRequired_Cardio = "Tannoy:CleanupRequired:Cardio";

		private const string Tannoy_CleanupRequired_Chromatherapy = "Tannoy:CleanupRequired:Chromatherapy";

		private const string Tannoy_CleanupRequired_Clown = "Tannoy:CleanupRequired:Clown";

		private const string Tannoy_CleanupRequired_Cubism = "Tannoy:CleanupRequired:Cubism";

		private const string Tannoy_CleanupRequired_Delux = "Tannoy:CleanupRequired:Delux";

		private const string Tannoy_CleanupRequired_DNA = "Tannoy:CleanupRequired:DNA";

		private const string Tannoy_CleanupRequired_Fluid = "Tannoy:CleanupRequired:Fluid";

		private const string Tannoy_CleanupRequired_GenDiag = "Tannoy:CleanupRequired:GenDiag";

		private const string Tannoy_CleanupRequired_GP = "Tannoy:CleanupRequired:GP";

		private const string Tannoy_CleanupRequired_Injection = "Tannoy:CleanupRequired:Injection";

		private const string Tannoy_CleanupRequired_Marketing = "Tannoy:CleanupRequired:Marketing";

		private const string Tannoy_CleanupRequired_MRI = "Tannoy:CleanupRequired:MRI";

		private const string Tannoy_CleanupRequired_Mummy = "Tannoy:CleanupRequired:Mummy";

		private const string Tannoy_CleanupRequired_Pandemic = "Tannoy:CleanupRequired:Pandemic";

		private const string Tannoy_CleanupRequired_Pharmacy = "Tannoy:CleanupRequired:Pharmacy";

		private const string Tannoy_CleanupRequired_Psych = "Tannoy:CleanupRequired:Psych";

		private const string Tannoy_CleanupRequired_Reception = "Tannoy:CleanupRequired:Reception";

		private const string Tannoy_CleanupRequired_Research = "Tannoy:CleanupRequired:Research";

		private const string Tannoy_CleanupRequired_Shock = "Tannoy:CleanupRequired:Shock";

		private const string Tannoy_CleanupRequired_StaffRoom = "Tannoy:CleanupRequired:StaffRoom";

		private const string Tannoy_CleanupRequired_Surgery = "Tannoy:CleanupRequired:Surgery";

		private const string Tannoy_CleanupRequired_TurtleHead = "Tannoy:CleanupRequired:TurtleHead";

		private const string Tannoy_CleanupRequired_Ward = "Tannoy:CleanupRequired:Ward";

		private const string Tannoy_CleanupRequired_Xray = "Tannoy:CleanupRequired:Xray";

		private const string Tannoy_CleanupRequired_BarkingMad = "Tannoy:CleanupRequired:BarkingMad";

		private const string Tannoy_CleanupRequired_Robotzilla = "Tannoy:CleanupRequired:Robotzilla";

		private const string Tannoy_CleanupRequired_Frankie = "Tannoy:CleanupRequired:Frankie";

		private const string Tannoy_CleanupRequired_BlankLooks = "Tannoy:CleanupRequired:BlankLooks";

		private const string Tannoy_CleanupRequired_Explorer = "Tannoy:CleanupRequired:Explorer";

		private const string Tannoy_CleanupRequired_Screwball = "Tannoy:CleanupRequired:Screwball";

		private const string Tannoy_CleanupRequired_Cardboard = "Tannoy:CleanupRequired:Cardboard";

		private const string Tannoy_CleanupRequired_Frog = "Tannoy:CleanupRequired:Frog";

		private const string Tannoy_CleanupRequired_Astro = "Tannoy:CleanupRequired:Astro";

		private const string Tannoy_CleanupRequired_Scarecrow = "Tannoy:CleanupRequired:Scarecrow";

		private const string Tannoy_CleanupRequired_Pinocchio = "Tannoy:CleanupRequired:Pinocchio";

		private const string Tannoy_CleanupRequired_Tech = "Tannoy:CleanupRequired:Tech";

		private const string Tannoy_CleanupRequired_PlantWard = "Tannoy:CleanupRequired:PlantWard";

		private const string Tannoy_CleanupRequired_Stunt = "Tannoy:CleanupRequired:Stunt";

		private const string Tannoy_CleanupRequired_Mud = "Tannoy:CleanupRequired:Mud";

		private const string Tannoy_CleanupRequired_ToySoldier = "Tannoy:CleanupRequired:ToySoldier";

		private const string Tannoy_CleanupRequired_Litter = "Tannoy:CleanupRequired:Litter";

		private const string Tannoy_CleanupRequired_Sick = "Tannoy:CleanupRequired:Sick";

		private const string Tannoy_CleanupRequired_Urine = "Tannoy:CleanupRequired:Urine";

		private const string Tannoy_CleanupRequired_Urine2 = "Tannoy:CleanupRequired:Urine2";

		private const string Tannoy_Misc_HospitalIsHaunted = "Tannoy:Misc:HospitalIsHaunted";

		private const string Tannoy_Maintenance_8bit = "Tannoy:Maintenance:8bit";

		private const string Tannoy_Maintenance_AnimalMag = "Tannoy:Maintenance:AnimalMag";

		private const string Tannoy_Maintenance_Cardio = "Tannoy:Maintenance:Cardio";

		private const string Tannoy_Maintenance_Chromatherapy = "Tannoy:Maintenance:Chromatherapy";

		private const string Tannoy_Maintenance_Cubism = "Tannoy:Maintenance:Cubism";

		private const string Tannoy_Maintenance_Clown = "Tannoy:Maintenance:Clown";

		private const string Tannoy_Maintenance_Delux = "Tannoy:Maintenance:Delux";

		private const string Tannoy_Maintenance_DNA = "Tannoy:Maintenance:DNA";

		private const string Tannoy_Maintenance_Fluid = "Tannoy:Maintenance:Fluid";

		private const string Tannoy_Maintenance_GenDiag = "Tannoy:Maintenance:GenDiag";

		private const string Tannoy_Maintenance_Injection = "Tannoy:Maintenance:Injection";

		private const string Tannoy_Maintenance_MRI = "Tannoy:Maintenance:MRI";

		private const string Tannoy_Maintenance_Mummy = "Tannoy:Maintenance:Mummy";

		private const string Tannoy_Maintenance_Pandemic = "Tannoy:Maintenance:Pandemic";

		private const string Tannoy_Maintenance_Pharmacy = "Tannoy:Maintenance:Pharmacy";

		private const string Tannoy_Maintenance_Research = "Tannoy:Maintenance:Research";

		private const string Tannoy_Maintenance_Shock = "Tannoy:Maintenance:Shock";

		private const string Tannoy_Maintenance_Toilet = "Tannoy:Maintenance:Toilet";

		private const string Tannoy_Maintenance_TurtleHead = "Tannoy:Maintenance:TurtleHead";

		private const string Tannoy_Maintenance_Xray = "Tannoy:Maintenance:Xray";

		private const string Tannoy_Maintenance_BarkingMad = "Tannoy:Maintenance:BarkingMad";

		private const string Tannoy_Maintenance_Robotzilla = "Tannoy:Maintenance:Robotzilla";

		private const string Tannoy_Maintenance_Frankie = "Tannoy:Maintenance:Frankie";

		private const string Tannoy_Maintenance_BlankLooks = "Tannoy:Maintenance:BlankLooks";

		private const string Tannoy_Maintenance_Explorer = "Tannoy:Maintenance:Explorer";

		private const string Tannoy_Maintenance_Screwball = "Tannoy:Maintenance:Screwball";

		private const string Tannoy_Maintenance_Cardboard = "Tannoy:Maintenance:Cardboard";

		private const string Tannoy_Maintenance_Frog = "Tannoy:Maintenance:Frog";

		private const string Tannoy_Maintenance_Astro = "Tannoy:Maintenance:Astro";

		private const string Tannoy_Maintenance_Pinocchio = "Tannoy:Maintenance:Pinocchio";

		private const string Tannoy_Maintenance_Scarecrow = "Tannoy:Maintenance:Scarecrow";

		private const string Tannoy_Maintenance_Tech = "Tannoy:Maintenance:Tech";

		private const string Tannoy_Maintenance_Stunt = "Tannoy:Maintenance:Stunt";

		private const string Tannoy_Maintenance_Mud = "Tannoy:Maintenance:Mud";

		private const string Tannoy_Maintenance_ToySoldier = "Tannoy:Maintenance:ToySoldier";

		private const string Tannoy_Maintenance_TimeTunnel = "Tannoy:Maintenance:TimeTunnel";

		private const string Tannoy_Maintenance_Ambulance = "Tannoy:Maintenance:Ambulance";

		private const string Tannoy_MaintenanceClownCar_ = "Tannoy:Maintenance:ClownCar";

		private const string Tannoy_Maintenance_Colin = "Tannoy:Maintenance:Colin";

		private const string Tannoy_Maintenance_DaVinci = "Tannoy:Maintenance:DaVinci";

		private const string Tannoy_Maintenance_DuckBlimp = "Tannoy:Maintenance:DuckBlimp";

		private const string Tannoy_Maintenance_Hives = "Tannoy:Maintenance:Hives";

		private const string Tannoy_Maintenance_MonsterTruck = "Tannoy:Maintenance:MonsterTruck";

		private const string Tannoy_Maintenance_PortaLoo = "Tannoy:Maintenance:PortaLoo";

		private const string Tannoy_Maintenance_Snowballed = "Tannoy:Maintenance:Snowballed";

		private const string Tannoy_Maintenance_UnderTheWeather = "Tannoy:Maintenance:UnderTheWeather";

		private const string Tannoy_Maintenance_Bin = "Tannoy:Maintenance:Bin";

		private const string Tannoy_Maintenance_Plant = "Tannoy:Maintenance:Plant";

		private const string Tannoy_Maintenance_Vending = "Tannoy:Maintenance:Vending";

		private const string Tannoy_Event_Celebrity = "Tannoy:Event:Celebrity";

		private const string Tannoy_Event_Earthquake = "Tannoy:Event:Earthquake";

		private const string Tannoy_Event_EpidemicFail = "Tannoy:Event:EpidemicFail";

		private const string Tannoy_Event_EpidemicStart = "Tannoy:Event:EpidemicStart";

		private const string Tannoy_Event_EpidemicSuccess = "Tannoy:Event:EpidemicSuccess";

		private const string Tannoy_Event_Explosion = "Tannoy:Event:Explosion";

		private const string Tannoy_Event_FilmStar = "Tannoy:Event:FilmStar";

		private const string Tannoy_Event_Fire = "Tannoy:Event:Fire";

		private const string Tannoy_Event_HealthInspector = "Tannoy:Event:HealthInspector";

		private const string Tannoy_Event_HealthMinister = "Tannoy:Event:HealthMinister";

		private const string Tannoy_Event_Mayor = "Tannoy:Event:Mayor";

		private const string Tannoy_Event_PopStar = "Tannoy:Event:PopStar";

		private const string Tannoy_Event_Reporter = "Tannoy:Event:Reporter";

		private const string Tannoy_Event_RivalExec = "Tannoy:Event:RivalExec";

		private const string Tannoy_LowMoney = "Tannoy:LowMoney";

		private const string Tannoy_MarketingComplete = "Tannoy:MarketingComplete";

		private const string Tannoy_ResearchComplete = "Tannoy:ResearchComplete";

		private const string Tannoy_TrainingComplete = "Tannoy:TrainingComplete";

		private const string Tannoy_Quit_Assistant = "Tannoy:Quit:Assistant";

		private const string Tannoy_Quit_Doctor = "Tannoy:Quit:Doctor";

		private const string Tannoy_Quit_Janitor = "Tannoy:Quit:Janitor";

		private const string Tannoy_Quit_Nurse = "Tannoy:Quit:Nurse";

		private const string Tannoy_Quit_Rage = "Tannoy:Quit:Rage";

		private const string Tannoy_General = "Tannoy:General";

		private const string Tannoy_General_Art = "Tannoy:General:Art";

		private const string Tannoy_General_Bin = "Tannoy:General:Bin";

		private const string Tannoy_General_Cafe = "Tannoy:General:Cafe";

		private const string Tannoy_General_Cold = "Tannoy:General:Cold";

		private const string Tannoy_General_HandSanitiser = "Tannoy:General:HandSanitiser";

		private const string Tannoy_General_Hot = "Tannoy:General:Hot";

		private const string Tannoy_General_Kiosk = "Tannoy:General:Kiosk";

		private const string Tannoy_General_NoFireExtinguishers = "Tannoy:Event:NoFireExtinguishers";

		private const string Tannoy_General_Plant = "Tannoy:General:Plant";

		private const string Tannoy_General_StaffRoom = "Tannoy:General:StaffRoom";

		private const string Tannoy_General_Toilet = "Tannoy:General:Toilet";

		private const string Tannoy_General_Vending = "Tannoy:General:Vending";

		private const string Tannoy_General_Ward = "Tannoy:General:Ward";

		private const string Tannoy_General_Xray = "Tannoy:General:Xray";

		private const string Tannoy_General_Research = "Tannoy:General:Research";

		private const float StaffScheduleCheckInterval = 30f;

		private float _timeUntilNextStaffScheduleCheck;

		private float _timeSinceLastAnnouncement;

		private float _timeToPlayNextGeneralAnnouncement;

		private Level _level;

		private TannoyManagerConfig _config;

		[DontSave]
		private AudioEmitter _currentAudioEmitter;

		private readonly Queue<string> _queuedTannoySFX = new Queue<string>();

		private List<string> _lastTannoyMessages;

		public TannoyManager(Level level, TannoyManagerConfig config)
		{
			_config = config;
			_level = level;
			_timeSinceLastAnnouncement = config.MinimumAnnouncementDelay;
			_lastTannoyMessages = new List<string>();
			_timeToPlayNextGeneralAnnouncement = UnityEngine.Random.Range(_config.MinGeneralAnnouncementTime, _config.MaxGeneralAnnouncementTime);
			OnAnnouncementQueueRequest = (Action<string>)Delegate.Combine(OnAnnouncementQueueRequest, new Action<string>(EnqueueAnnouncement));
			App app = _level.Metagame.App;
			app.OnLevelLoadStarting = (Action)Delegate.Combine(app.OnLevelLoadStarting, new Action(OnLevelLoadStarting));
		}

		public void RestoreFromSave(Level level, TannoyManagerConfig config)
		{
			_config = config;
			_level = level;
			if (_lastTannoyMessages == null)
			{
				_lastTannoyMessages = new List<string>();
			}
			OnAnnouncementQueueRequest = (Action<string>)Delegate.Combine(OnAnnouncementQueueRequest, new Action<string>(EnqueueAnnouncement));
			App app = _level.Metagame.App;
			app.OnLevelLoadStarting = (Action)Delegate.Combine(app.OnLevelLoadStarting, new Action(OnLevelLoadStarting));
		}

		public override void Destroy()
		{
			OnAnnouncementQueueRequest = (Action<string>)Delegate.Remove(OnAnnouncementQueueRequest, new Action<string>(EnqueueAnnouncement));
			App app = _level.Metagame.App;
			app.OnLevelLoadStarting = (Action)Delegate.Remove(app.OnLevelLoadStarting, new Action(OnLevelLoadStarting));
			base.Destroy();
		}

		private void EnqueueAnnouncement(string soundEventName)
		{
			if (!string.IsNullOrEmpty(soundEventName) && _queuedTannoySFX.Count < _config.MaxAnnouncementQueueLength)
			{
				_queuedTannoySFX.Enqueue(soundEventName);
			}
		}

		private bool TryEnqueueAnnouncement(string soundEventName)
		{
			if (_queuedTannoySFX.Contains(soundEventName))
			{
				return false;
			}
			if (_currentAudioEmitter != null && !_currentAudioEmitter.Finished && _currentAudioEmitter.AudioEvent.EventName == soundEventName)
			{
				return false;
			}
			EnqueueAnnouncement(soundEventName);
			return true;
		}

		private void OnLevelLoadStarting()
		{
			if (IsAnnouncing())
			{
				_currentAudioEmitter.Stop();
			}
		}

		public void Update()
		{
			if (_level.GameTime.IsSuperPaused || _level.GameTime.IsPausedByMenu || _level.Radio.IsDJTalking())
			{
				return;
			}
			_timeUntilNextStaffScheduleCheck -= ((Time.timeScale == 0f) ? 0f : Time.unscaledDeltaTime);
			if (_timeUntilNextStaffScheduleCheck < 0f)
			{
				CheckStaffWorkScheduleForAnnouncements();
				_timeUntilNextStaffScheduleCheck = 30f;
			}
			if (_currentAudioEmitter == null || _currentAudioEmitter.Finished)
			{
				_timeSinceLastAnnouncement += ((Time.timeScale == 0f) ? 0f : Time.unscaledDeltaTime);
			}
			if (_timeSinceLastAnnouncement > _timeToPlayNextGeneralAnnouncement)
			{
				_timeToPlayNextGeneralAnnouncement = UnityEngine.Random.Range(_config.MinGeneralAnnouncementTime, _config.MaxGeneralAnnouncementTime);
				List<string> list = new List<string>();
				while (list.Count < 50)
				{
					list.Add("Tannoy:General");
				}
				if (_level.WorldState.GetRoomItemsWithMaintenanceDescription(JobMaintenance.JobDescription.OutOfStock).Count > 0)
				{
					list.Add("Tannoy:General:Vending");
				}
				if (_level.WorldState.GetRoomItemsWithMaintenanceDescription(JobMaintenance.JobDescription.WiltedPlant).Count > 0)
				{
					list.Add("Tannoy:General:Plant");
				}
				if (_level.WorldState.GetRoomItemsWithMaintenanceDescription(JobMaintenance.JobDescription.Litter).Count > 0)
				{
					list.Add("Tannoy:General:Bin");
				}
				if (GameAlgorithms.DoesHospitalHaveRoom(_level.WorldState, RoomDefinition.Type.Toilets))
				{
					list.Add("Tannoy:General:Toilet");
				}
				if (GameAlgorithms.DoesHospitalHaveRoom(_level.WorldState, RoomDefinition.Type.StaffRoom))
				{
					list.Add("Tannoy:General:StaffRoom");
				}
				if (GameAlgorithms.DoesHospitalHaveRoom(_level.WorldState, RoomDefinition.Type.Ward))
				{
					list.Add("Tannoy:General:Ward");
				}
				if (GameAlgorithms.DoesHospitalHaveRoom(_level.WorldState, RoomDefinition.Type.Cafe))
				{
					list.Add("Tannoy:General:Cafe");
				}
				if (GameAlgorithms.DoesHospitalHaveRoom(_level.WorldState, RoomDefinition.Type.XRay))
				{
					list.Add("Tannoy:General:Xray");
				}
				if (GameAlgorithms.DoesHospitalHaveRoom(_level.WorldState, RoomDefinition.Type.Research))
				{
					list.Add("Tannoy:General:Research");
				}
				int index = 0;
				if (list.Count > 50)
				{
					index = new System.Random().Next(0, list.Count);
				}
				string soundEventName = list[index];
				TryEnqueueAnnouncement(soundEventName);
				_lastTannoyMessages.Add("Tannoy:General");
			}
			if (_timeSinceLastAnnouncement > _config.MinimumAnnouncementDelay && _queuedTannoySFX.Count > 0 && (_currentAudioEmitter == null || _currentAudioEmitter.Finished))
			{
				_currentAudioEmitter = AudioManager.Instance.Play(_queuedTannoySFX.Dequeue());
				_timeSinceLastAnnouncement = 0f;
			}
		}

		public bool IsAnnouncing()
		{
			if (_currentAudioEmitter != null)
			{
				return !_currentAudioEmitter.Finished;
			}
			return false;
		}

		private void CheckStaffWorkScheduleForAnnouncements()
		{
			if (_lastTannoyMessages.Count > 5)
			{
				_lastTannoyMessages.RemoveAt(0);
			}
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			foreach (Job allJob in _level.StaffWorkScheduler.AllJobs)
			{
				if (!allJob.Available())
				{
					continue;
				}
				if (allJob is JobRoom jobRoom)
				{
					if (jobRoom.Room.QueueLength == 0)
					{
						switch (jobRoom.StaffRequired().Definition._type)
						{
						case StaffDefinition.Type.Doctor:
							switch (jobRoom.Room.Definition._type)
							{
							case RoomDefinition.Type.Training:
								if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:Training"))
								{
									list.Add("Tannoy:DoctorRequired:Training");
									_lastTannoyMessages.Add("Tannoy:DoctorRequired:Training");
								}
								break;
							case RoomDefinition.Type.Research:
								if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:Research"))
								{
									list.Add("Tannoy:DoctorRequired:Research");
									_lastTannoyMessages.Add("Tannoy:DoctorRequired:Research");
								}
								break;
							}
							break;
						case StaffDefinition.Type.Nurse:
							if (jobRoom.Room.Definition._type == RoomDefinition.Type.Training && !_lastTannoyMessages.Contains("Tannoy:NurseRequired:Training"))
							{
								list.Add("Tannoy:NurseRequired:Training");
								_lastTannoyMessages.Add("Tannoy:NurseRequired:Training");
							}
							break;
						case StaffDefinition.Type.Assistant:
							switch (jobRoom.Room.Definition._type)
							{
							case RoomDefinition.Type.Marketing:
								if (!_lastTannoyMessages.Contains("Tannoy:AssistantRequired:Marketing"))
								{
									list.Add("Tannoy:AssistantRequired:Marketing");
									_lastTannoyMessages.Add("Tannoy:AssistantRequired:Marketing");
								}
								break;
							case RoomDefinition.Type.Cafe:
								if (!_lastTannoyMessages.Contains("Tannoy:AssistantRequired:Cafe"))
								{
									list.Add("Tannoy:AssistantRequired:Cafe");
									_lastTannoyMessages.Add("Tannoy:AssistantRequired:Cafe");
								}
								break;
							case RoomDefinition.Type.Training:
								if (!_lastTannoyMessages.Contains("Tannoy:AssistantRequired:Training"))
								{
									list.Add("Tannoy:AssistantRequired:Training");
									_lastTannoyMessages.Add("Tannoy:AssistantRequired:Training");
								}
								break;
							}
							break;
						}
					}
					if (jobRoom.Room.QueueLength <= 0)
					{
						continue;
					}
					switch (jobRoom.StaffRequired().Definition._type)
					{
					case StaffDefinition.Type.Doctor:
						switch (jobRoom.Room.Definition._type)
						{
						case RoomDefinition.Type.EightBitClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:8bit"))
							{
								list.Add("Tannoy:DoctorRequired:8bit");
								_lastTannoyMessages.Add("Tannoy:DoctorRequired:8bit");
							}
							break;
						case RoomDefinition.Type.AnimalMagnetismClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:AnimalMag"))
							{
								list.Add("Tannoy:DoctorRequired:AnimalMag");
								_lastTannoyMessages.Add("Tannoy:DoctorRequired:AnimalMag");
							}
							break;
						case RoomDefinition.Type.Cardiography:
							if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:Cardio"))
							{
								list.Add("Tannoy:DoctorRequired:Cardio");
								_lastTannoyMessages.Add("Tannoy:DoctorRequired:Cardio");
							}
							break;
						case RoomDefinition.Type.ClownClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:Clown"))
							{
								list.Add("Tannoy:DoctorRequired:Clown");
								_lastTannoyMessages.Add("Tannoy:DoctorRequired:Clown");
							}
							break;
						case RoomDefinition.Type.ClinicCubism:
							if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:Cubism"))
							{
								list.Add("Tannoy:DoctorRequired:Cubism");
								_lastTannoyMessages.Add("Tannoy:DoctorRequired:Cubism");
							}
							break;
						case RoomDefinition.Type.MummyClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:Decrypter"))
							{
								list.Add("Tannoy:DoctorRequired:Decrypter");
								_lastTannoyMessages.Add("Tannoy:DoctorRequired:Decrypter");
							}
							break;
						case RoomDefinition.Type.LightHeaded:
							if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:Delux"))
							{
								list.Add("Tannoy:DoctorRequired:Delux");
								_lastTannoyMessages.Add("Tannoy:DoctorRequired:Delux");
							}
							break;
						case RoomDefinition.Type.DNAAnalysis:
							if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:DNA"))
							{
								list.Add("Tannoy:DoctorRequired:DNA");
								_lastTannoyMessages.Add("Tannoy:DoctorRequired:DNA");
							}
							break;
						case RoomDefinition.Type.FluidAnalysis:
							if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:Fluid"))
							{
								list.Add("Tannoy:DoctorRequired:Fluid");
								_lastTannoyMessages.Add("Tannoy:DoctorRequired:Fluid");
							}
							break;
						case RoomDefinition.Type.GPOffice:
							if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:GP"))
							{
								list.Add("Tannoy:DoctorRequired:GP");
								_lastTannoyMessages.Add("Tannoy:DoctorRequired:GP");
							}
							break;
						case RoomDefinition.Type.GeneralDiagnosis:
							if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:GenDiag"))
							{
								list.Add("Tannoy:DoctorRequired:GenDiag");
								_lastTannoyMessages.Add("Tannoy:DoctorRequired:GenDiag");
							}
							break;
						case RoomDefinition.Type.MRIScanner:
							if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:MRI"))
							{
								list.Add("Tannoy:DoctorRequired:MRI");
								_lastTannoyMessages.Add("Tannoy:DoctorRequired:MRI");
							}
							break;
						case RoomDefinition.Type.PandemicClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:Pandemic"))
							{
								list.Add("Tannoy:DoctorRequired:Pandemic");
								_lastTannoyMessages.Add("Tannoy:DoctorRequired:Pandemic");
							}
							break;
						case RoomDefinition.Type.Psychiatry:
							if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:Psychiatry"))
							{
								list.Add("Tannoy:DoctorRequired:Psychiatry");
								_lastTannoyMessages.Add("Tannoy:DoctorRequired:Psychiatry");
							}
							break;
						case RoomDefinition.Type.ElectricShockClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:Shock"))
							{
								list.Add("Tannoy:DoctorRequired:Shock");
								_lastTannoyMessages.Add("Tannoy:DoctorRequired:Shock");
							}
							break;
						case RoomDefinition.Type.OperatingTheater:
							if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:Surgery"))
							{
								list.Add("Tannoy:DoctorRequired:Surgery");
								_lastTannoyMessages.Add("Tannoy:DoctorRequired:Surgery");
							}
							break;
						case RoomDefinition.Type.Training:
							if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:Training"))
							{
								list.Add("Tannoy:DoctorRequired:Training");
								_lastTannoyMessages.Add("Tannoy:DoctorRequired:Training");
							}
							break;
						case RoomDefinition.Type.TurtleHeadClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:TurtleHead"))
							{
								list.Add("Tannoy:DoctorRequired:TurtleHead");
								_lastTannoyMessages.Add("Tannoy:DoctorRequired:TurtleHead");
							}
							break;
						case RoomDefinition.Type.XRay:
							if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:Xray"))
							{
								list.Add("Tannoy:DoctorRequired:Xray");
								_lastTannoyMessages.Add("Tannoy:DoctorRequired:Xray");
							}
							break;
						case RoomDefinition.Type.FrankensteinClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:Frankie"))
							{
								list.Add("Tannoy:DoctorRequired:Frankie");
								_lastTannoyMessages.Add("Tannoy:DoctorRequired:Frankie");
							}
							break;
						case RoomDefinition.Type.EightBallClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:Screwball"))
							{
								list.Add("Tannoy:DoctorRequired:Screwball");
								_lastTannoyMessages.Add("Tannoy:DoctorRequired:Screwball");
							}
							break;
						case RoomDefinition.Type.AstroClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:Astro"))
							{
								list.Add("Tannoy:DoctorRequired:Astro");
								_lastTannoyMessages.Add("Tannoy:DoctorRequired:Astro");
							}
							break;
						case RoomDefinition.Type.TechClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:Tech"))
							{
								list.Add("Tannoy:DoctorRequired:Tech");
								_lastTannoyMessages.Add("Tannoy:DoctorRequired:Tech");
							}
							break;
						case RoomDefinition.Type.ToySoldierClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:ToySoldier"))
							{
								list.Add("Tannoy:DoctorRequired:ToySoldier");
								_lastTannoyMessages.Add("Tannoy:DoctorRequired:ToySoldier");
							}
							break;
						case RoomDefinition.Type.StuntmanClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:Stunt"))
							{
								list.Add("Tannoy:DoctorRequired:Stunt");
								_lastTannoyMessages.Add("Tannoy:DoctorRequired:Stunt");
							}
							break;
						case RoomDefinition.Type.HivesClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:Hives"))
							{
								list.Add("Tannoy:DoctorRequired:Hives");
								_lastTannoyMessages.Add("Tannoy:DoctorRequired:Hives");
							}
							break;
						case RoomDefinition.Type.SnowballedClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:Snowballed"))
							{
								list.Add("Tannoy:DoctorRequired:Snowballed");
								_lastTannoyMessages.Add("Tannoy:DoctorRequired:Snowballed");
							}
							break;
						case RoomDefinition.Type.UnderTheWeatherClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:DoctorRequired:UnderTheWeather"))
							{
								list.Add("Tannoy:DoctorRequired:UnderTheWeather");
								_lastTannoyMessages.Add("Tannoy:DoctorRequired:UnderTheWeather");
							}
							break;
						}
						break;
					case StaffDefinition.Type.Nurse:
						switch (jobRoom.Room.Definition._type)
						{
						case RoomDefinition.Type.Cardiography:
							if (!_lastTannoyMessages.Contains("Tannoy:NurseRequired:Cardio"))
							{
								list.Add("Tannoy:NurseRequired:Cardio");
								_lastTannoyMessages.Add("Tannoy:NurseRequired:Cardio");
							}
							break;
						case RoomDefinition.Type.Chromatherapy:
							if (!_lastTannoyMessages.Contains("Tannoy:NurseRequired:Chromatherapy"))
							{
								list.Add("Tannoy:NurseRequired:Chromatherapy");
								_lastTannoyMessages.Add("Tannoy:NurseRequired:Chromatherapy");
							}
							break;
						case RoomDefinition.Type.ClownClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:NurseRequired:Clown"))
							{
								list.Add("Tannoy:NurseRequired:Clown");
								_lastTannoyMessages.Add("Tannoy:NurseRequired:Clown");
							}
							break;
						case RoomDefinition.Type.MummyClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:NurseRequired:Decrypter"))
							{
								list.Add("Tannoy:NurseRequired:Decrypter");
								_lastTannoyMessages.Add("Tannoy:NurseRequired:Decrypter");
							}
							break;
						case RoomDefinition.Type.FluidAnalysis:
							if (!_lastTannoyMessages.Contains("Tannoy:NurseRequired:Fluid"))
							{
								list.Add("Tannoy:NurseRequired:Fluid");
								_lastTannoyMessages.Add("Tannoy:NurseRequired:Fluid");
							}
							break;
						case RoomDefinition.Type.FractureWard:
							if (!_lastTannoyMessages.Contains("Tannoy:NurseRequired:Fracture"))
							{
								list.Add("Tannoy:NurseRequired:Fracture");
								_lastTannoyMessages.Add("Tannoy:NurseRequired:Fracture");
							}
							break;
						case RoomDefinition.Type.GeneralDiagnosis:
							if (!_lastTannoyMessages.Contains("Tannoy:NurseRequired:GenDiag"))
							{
								list.Add("Tannoy:NurseRequired:GenDiag");
								_lastTannoyMessages.Add("Tannoy:NurseRequired:GenDiag");
							}
							break;
						case RoomDefinition.Type.InjectionRoom:
							if (!_lastTannoyMessages.Contains("Tannoy:NurseRequired:Injection"))
							{
								list.Add("Tannoy:NurseRequired:Injection");
								_lastTannoyMessages.Add("Tannoy:NurseRequired:Injection");
							}
							break;
						case RoomDefinition.Type.Pharmacy:
							if (!_lastTannoyMessages.Contains("Tannoy:NurseRequired:Pharmacy"))
							{
								list.Add("Tannoy:NurseRequired:Pharmacy");
								_lastTannoyMessages.Add("Tannoy:NurseRequired:Pharmacy");
							}
							break;
						case RoomDefinition.Type.OperatingTheater:
							if (!_lastTannoyMessages.Contains("Tannoy:NurseRequired:Surgery"))
							{
								list.Add("Tannoy:NurseRequired:Surgery");
								_lastTannoyMessages.Add("Tannoy:NurseRequired:Surgery");
							}
							break;
						case RoomDefinition.Type.Training:
							if (!_lastTannoyMessages.Contains("Tannoy:NurseRequired:Training"))
							{
								list.Add("Tannoy:NurseRequired:Training");
								_lastTannoyMessages.Add("Tannoy:NurseRequired:Training");
							}
							break;
						case RoomDefinition.Type.Ward:
							if (!_lastTannoyMessages.Contains("Tannoy:NurseRequired:Ward"))
							{
								list.Add("Tannoy:NurseRequired:Ward");
								_lastTannoyMessages.Add("Tannoy:NurseRequired:Ward");
							}
							break;
						case RoomDefinition.Type.DogClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:NurseRequired:BarkingMad"))
							{
								list.Add("Tannoy:NurseRequired:BarkingMad");
								_lastTannoyMessages.Add("Tannoy:NurseRequired:BarkingMad");
							}
							break;
						case RoomDefinition.Type.RobotMonsterClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:NurseRequired:Robotzilla"))
							{
								list.Add("Tannoy:NurseRequired:Robotzilla");
								_lastTannoyMessages.Add("Tannoy:NurseRequired:Robotzilla");
							}
							break;
						case RoomDefinition.Type.BlankLooksClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:NurseRequired:BlankLooks"))
							{
								list.Add("Tannoy:NurseRequired:BlankLooks");
								_lastTannoyMessages.Add("Tannoy:NurseRequired:BlankLooks");
							}
							break;
						case RoomDefinition.Type.ExplorerClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:NurseRequired:Explorer"))
							{
								list.Add("Tannoy:NurseRequired:Explorer");
								_lastTannoyMessages.Add("Tannoy:NurseRequired:Explorer");
							}
							break;
						case RoomDefinition.Type.CardboardClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:NurseRequired:Cardboard"))
							{
								list.Add("Tannoy:NurseRequired:Cardboard");
								_lastTannoyMessages.Add("Tannoy:NurseRequired:Cardboard");
							}
							break;
						case RoomDefinition.Type.FrogClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:NurseRequired:Frog"))
							{
								list.Add("Tannoy:NurseRequired:Frog");
								_lastTannoyMessages.Add("Tannoy:NurseRequired:Frog");
							}
							break;
						case RoomDefinition.Type.PinocchioClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:NurseRequired:Pinocchio"))
							{
								list.Add("Tannoy:NurseRequired:Pinocchio");
								_lastTannoyMessages.Add("Tannoy:NurseRequired:Pinocchio");
							}
							break;
						case RoomDefinition.Type.ScarecrowClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:NurseRequired:Scarecrow"))
							{
								list.Add("Tannoy:NurseRequired:Scarecrow");
								_lastTannoyMessages.Add("Tannoy:NurseRequired:Scarecrow");
							}
							break;
						case RoomDefinition.Type.PlantWardClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:NurseRequired:PlantWard"))
							{
								list.Add("Tannoy:NurseRequired:PlantWard");
								_lastTannoyMessages.Add("Tannoy:NurseRequired:PlantWard");
							}
							break;
						case RoomDefinition.Type.StuntmanClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:NurseRequired:Stunt"))
							{
								list.Add("Tannoy:NurseRequired:Stunt");
								_lastTannoyMessages.Add("Tannoy:NurseRequired:Stunt");
							}
							break;
						case RoomDefinition.Type.MudPersonClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:NurseRequired:Mud"))
							{
								list.Add("Tannoy:NurseRequired:Mud");
								_lastTannoyMessages.Add("Tannoy:NurseRequired:Mud");
							}
							break;
						case RoomDefinition.Type.HivesClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:NurseRequired:Hives"))
							{
								list.Add("Tannoy:NurseRequired:Hives");
								_lastTannoyMessages.Add("Tannoy:NurseRequired:Hives");
							}
							break;
						case RoomDefinition.Type.SnowballedClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:NurseRequired:Snowballed"))
							{
								list.Add("Tannoy:NurseRequired:Snowballed");
								_lastTannoyMessages.Add("Tannoy:NurseRequired:Snowballed");
							}
							break;
						case RoomDefinition.Type.UnderTheWeatherClinic:
							if (!_lastTannoyMessages.Contains("Tannoy:NurseRequired:UnderTheWeather"))
							{
								list.Add("Tannoy:NurseRequired:UnderTheWeather");
								_lastTannoyMessages.Add("Tannoy:NurseRequired:UnderTheWeather");
							}
							break;
						}
						break;
					case StaffDefinition.Type.Assistant:
						switch (jobRoom.Room.Definition._type)
						{
						case RoomDefinition.Type.Cafe:
							if (!_lastTannoyMessages.Contains("Tannoy:AssistantRequired:Cafe"))
							{
								list.Add("Tannoy:AssistantRequired:Cafe");
								_lastTannoyMessages.Add("Tannoy:AssistantRequired:Cafe");
							}
							break;
						case RoomDefinition.Type.Marketing:
							if (!_lastTannoyMessages.Contains("Tannoy:AssistantRequired:Marketing"))
							{
								list.Add("Tannoy:AssistantRequired:Marketing");
								_lastTannoyMessages.Add("Tannoy:AssistantRequired:Marketing");
							}
							break;
						case RoomDefinition.Type.Reception:
							if (!_lastTannoyMessages.Contains("Tannoy:AssistantRequired:Reception") && jobRoom.Room.QueueLength >= 4)
							{
								list.Add("Tannoy:AssistantRequired:Reception");
								_lastTannoyMessages.Add("Tannoy:AssistantRequired:Reception");
							}
							break;
						case RoomDefinition.Type.Training:
							if (!_lastTannoyMessages.Contains("Tannoy:NurseRequired:Training"))
							{
								list.Add("Tannoy:NurseRequired:Training");
								_lastTannoyMessages.Add("Tannoy:NurseRequired:Training");
							}
							break;
						case RoomDefinition.Type.TimeTunnel:
							if (!_lastTannoyMessages.Contains("Tannoy:AssistantRequired:TimeTunnel"))
							{
								list.Add("Tannoy:AssistantRequired:TimeTunnel");
								_lastTannoyMessages.Add("Tannoy:AssistantRequired:TimeTunnel");
							}
							break;
						}
						break;
					}
				}
				if (allJob is JobGhost && !_lastTannoyMessages.Contains("Tannoy:Misc:HospitalIsHaunted"))
				{
					list2.Add("Tannoy:Misc:HospitalIsHaunted");
					_lastTannoyMessages.Add("Tannoy:Misc:HospitalIsHaunted");
				}
				if (!(allJob is JobMaintenance { Item: var item }))
				{
					continue;
				}
				if (item != null && item.OwningRoom != null && (item.Definition.MaintenanceDescription == JobMaintenance.JobDescription.BrokenMachine || item.Definition.MaintenanceDescription == JobMaintenance.JobDescription.BlockedToilet))
				{
					switch (item.OwningRoom.Definition._type)
					{
					case RoomDefinition.Type.EightBitClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:8bit"))
						{
							list2.Add("Tannoy:Maintenance:8bit");
							_lastTannoyMessages.Add("Tannoy:Maintenance:8bit");
						}
						break;
					case RoomDefinition.Type.AnimalMagnetismClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:AnimalMag"))
						{
							list2.Add("Tannoy:Maintenance:AnimalMag");
							_lastTannoyMessages.Add("Tannoy:Maintenance:AnimalMag");
						}
						break;
					case RoomDefinition.Type.Cardiography:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:Cardio"))
						{
							list2.Add("Tannoy:Maintenance:Cardio");
							_lastTannoyMessages.Add("Tannoy:Maintenance:Cardio");
						}
						break;
					case RoomDefinition.Type.Chromatherapy:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:Chromatherapy"))
						{
							list2.Add("Tannoy:Maintenance:Chromatherapy");
							_lastTannoyMessages.Add("Tannoy:Maintenance:Chromatherapy");
						}
						break;
					case RoomDefinition.Type.ClownClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:Clown"))
						{
							list2.Add("Tannoy:Maintenance:Clown");
							_lastTannoyMessages.Add("Tannoy:Maintenance:Clown");
						}
						break;
					case RoomDefinition.Type.LightHeaded:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:Delux"))
						{
							list2.Add("Tannoy:Maintenance:Delux");
							_lastTannoyMessages.Add("Tannoy:Maintenance:Delux");
						}
						break;
					case RoomDefinition.Type.DNAAnalysis:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:DNA"))
						{
							list2.Add("Tannoy:Maintenance:DNA");
							_lastTannoyMessages.Add("Tannoy:Maintenance:DNA");
						}
						break;
					case RoomDefinition.Type.FluidAnalysis:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:Fluid"))
						{
							list2.Add("Tannoy:Maintenance:Fluid");
							_lastTannoyMessages.Add("Tannoy:Maintenance:Fluid");
						}
						break;
					case RoomDefinition.Type.GeneralDiagnosis:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:GenDiag"))
						{
							list2.Add("Tannoy:Maintenance:GenDiag");
							_lastTannoyMessages.Add("Tannoy:Maintenance:GenDiag");
						}
						break;
					case RoomDefinition.Type.InjectionRoom:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:Injection"))
						{
							list2.Add("Tannoy:Maintenance:Injection");
							_lastTannoyMessages.Add("Tannoy:Maintenance:Injection");
						}
						break;
					case RoomDefinition.Type.MRIScanner:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:MRI"))
						{
							list2.Add("Tannoy:Maintenance:MRI");
							_lastTannoyMessages.Add("Tannoy:Maintenance:MRI");
						}
						break;
					case RoomDefinition.Type.MummyClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:Mummy"))
						{
							list2.Add("Tannoy:Maintenance:Mummy");
							_lastTannoyMessages.Add("Tannoy:Maintenance:Mummy");
						}
						break;
					case RoomDefinition.Type.PandemicClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:Pandemic"))
						{
							list2.Add("Tannoy:Maintenance:Pandemic");
							_lastTannoyMessages.Add("Tannoy:Maintenance:Pandemic");
						}
						break;
					case RoomDefinition.Type.Pharmacy:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:Pharmacy"))
						{
							list2.Add("Tannoy:Maintenance:Pharmacy");
							_lastTannoyMessages.Add("Tannoy:Maintenance:Pharmacy");
						}
						break;
					case RoomDefinition.Type.Research:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:Research"))
						{
							list2.Add("Tannoy:Maintenance:Research");
							_lastTannoyMessages.Add("Tannoy:Maintenance:Research");
						}
						break;
					case RoomDefinition.Type.ClinicCubism:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:Cubism"))
						{
							list2.Add("Tannoy:Maintenance:Cubism");
							_lastTannoyMessages.Add("Tannoy:Maintenance:Cubism");
						}
						break;
					case RoomDefinition.Type.ElectricShockClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:Shock"))
						{
							list2.Add("Tannoy:Maintenance:Shock");
							_lastTannoyMessages.Add("Tannoy:Maintenance:Shock");
						}
						break;
					case RoomDefinition.Type.Toilets:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:Toilet"))
						{
							list2.Add("Tannoy:Maintenance:Toilet");
							_lastTannoyMessages.Add("Tannoy:Maintenance:Toilet");
						}
						break;
					case RoomDefinition.Type.TurtleHeadClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:TurtleHead"))
						{
							list2.Add("Tannoy:Maintenance:TurtleHead");
							_lastTannoyMessages.Add("Tannoy:Maintenance:TurtleHead");
						}
						break;
					case RoomDefinition.Type.XRay:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:Xray"))
						{
							list2.Add("Tannoy:Maintenance:Xray");
							_lastTannoyMessages.Add("Tannoy:Maintenance:Xray");
						}
						break;
					case RoomDefinition.Type.DogClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:BarkingMad"))
						{
							list2.Add("Tannoy:Maintenance:BarkingMad");
							_lastTannoyMessages.Add("Tannoy:Maintenance:BarkingMad");
						}
						break;
					case RoomDefinition.Type.RobotMonsterClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:Robotzilla"))
						{
							list2.Add("Tannoy:Maintenance:Robotzilla");
							_lastTannoyMessages.Add("Tannoy:Maintenance:Robotzilla");
						}
						break;
					case RoomDefinition.Type.FrankensteinClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:Frankie"))
						{
							list2.Add("Tannoy:Maintenance:Frankie");
							_lastTannoyMessages.Add("Tannoy:Maintenance:Frankie");
						}
						break;
					case RoomDefinition.Type.EightBallClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:Screwball"))
						{
							list2.Add("Tannoy:Maintenance:Screwball");
							_lastTannoyMessages.Add("Tannoy:Maintenance:Screwball");
						}
						break;
					case RoomDefinition.Type.ExplorerClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:Explorer"))
						{
							list2.Add("Tannoy:Maintenance:Explorer");
							_lastTannoyMessages.Add("Tannoy:Maintenance:Explorer");
						}
						break;
					case RoomDefinition.Type.BlankLooksClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:BlankLooks"))
						{
							list2.Add("Tannoy:Maintenance:BlankLooks");
							_lastTannoyMessages.Add("Tannoy:Maintenance:BlankLooks");
						}
						break;
					case RoomDefinition.Type.CardboardClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:Cardboard"))
						{
							list2.Add("Tannoy:Maintenance:Cardboard");
							_lastTannoyMessages.Add("Tannoy:Maintenance:Cardboard");
						}
						break;
					case RoomDefinition.Type.FrogClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:Frog"))
						{
							list2.Add("Tannoy:Maintenance:Frog");
							_lastTannoyMessages.Add("Tannoy:Maintenance:Frog");
						}
						break;
					case RoomDefinition.Type.AstroClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:Astro"))
						{
							list2.Add("Tannoy:Maintenance:Astro");
							_lastTannoyMessages.Add("Tannoy:Maintenance:Astro");
						}
						break;
					case RoomDefinition.Type.PinocchioClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:Pinocchio"))
						{
							list2.Add("Tannoy:Maintenance:Pinocchio");
							_lastTannoyMessages.Add("Tannoy:Maintenance:Pinocchio");
						}
						break;
					case RoomDefinition.Type.ScarecrowClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:Scarecrow"))
						{
							list2.Add("Tannoy:Maintenance:Scarecrow");
							_lastTannoyMessages.Add("Tannoy:Maintenance:Scarecrow");
						}
						break;
					case RoomDefinition.Type.TechClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:Tech"))
						{
							list2.Add("Tannoy:Maintenance:Tech");
							_lastTannoyMessages.Add("Tannoy:Maintenance:Tech");
						}
						break;
					case RoomDefinition.Type.StuntmanClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:Stunt"))
						{
							list2.Add("Tannoy:Maintenance:Stunt");
							_lastTannoyMessages.Add("Tannoy:Maintenance:Stunt");
						}
						break;
					case RoomDefinition.Type.MudPersonClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:Mud"))
						{
							list2.Add("Tannoy:Maintenance:Mud");
							_lastTannoyMessages.Add("Tannoy:Maintenance:Mud");
						}
						break;
					case RoomDefinition.Type.ToySoldierClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:ToySoldier"))
						{
							list2.Add("Tannoy:Maintenance:ToySoldier");
							_lastTannoyMessages.Add("Tannoy:Maintenance:ToySoldier");
						}
						break;
					case RoomDefinition.Type.TimeTunnel:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:TimeTunnel"))
						{
							list2.Add("Tannoy:Maintenance:TimeTunnel");
							_lastTannoyMessages.Add("Tannoy:Maintenance:TimeTunnel");
						}
						break;
					case RoomDefinition.Type.HivesClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:Hives"))
						{
							list2.Add("Tannoy:Maintenance:Hives");
							_lastTannoyMessages.Add("Tannoy:Maintenance:Hives");
						}
						break;
					case RoomDefinition.Type.SnowballedClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:Snowballed"))
						{
							list2.Add("Tannoy:Maintenance:Snowballed");
							_lastTannoyMessages.Add("Tannoy:Maintenance:Snowballed");
						}
						break;
					case RoomDefinition.Type.UnderTheWeatherClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:UnderTheWeather"))
						{
							list2.Add("Tannoy:Maintenance:UnderTheWeather");
							_lastTannoyMessages.Add("Tannoy:Maintenance:UnderTheWeather");
						}
						break;
					case RoomDefinition.Type.AmbulanceBay:
						if (!_lastTannoyMessages.Contains("Tannoy:Maintenance:Ambulance"))
						{
							list2.Add("Tannoy:Maintenance:Ambulance");
							_lastTannoyMessages.Add("Tannoy:Maintenance:Ambulance");
						}
						break;
					}
				}
				if (item != null && item.OwningRoom != null && (item.Definition.MaintenanceDescription == JobMaintenance.JobDescription.Litter || item.Definition.MaintenanceDescription == JobMaintenance.JobDescription.MedicalWaste) && item.Definition.DebugTag != "Bin")
				{
					switch (item.OwningRoom.Definition._type)
					{
					case RoomDefinition.Type.EightBitClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:8bit"))
						{
							list2.Add("Tannoy:CleanupRequired:8bit");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:8bit");
						}
						break;
					case RoomDefinition.Type.AnimalMagnetismClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:AnimalMag"))
						{
							list2.Add("Tannoy:CleanupRequired:AnimalMag");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:AnimalMag");
						}
						break;
					case RoomDefinition.Type.Cardiography:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Cardio"))
						{
							list2.Add("Tannoy:CleanupRequired:Cardio");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Cardio");
						}
						break;
					case RoomDefinition.Type.Cafe:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Cafe"))
						{
							list2.Add("Tannoy:CleanupRequired:Cafe");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Cafe");
						}
						break;
					case RoomDefinition.Type.Chromatherapy:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Chromatherapy"))
						{
							list2.Add("Tannoy:CleanupRequired:Chromatherapy");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Chromatherapy");
						}
						break;
					case RoomDefinition.Type.ClownClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Clown"))
						{
							list2.Add("Tannoy:CleanupRequired:Clown");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Clown");
						}
						break;
					case RoomDefinition.Type.LightHeaded:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Delux"))
						{
							list2.Add("Tannoy:CleanupRequired:Delux");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Delux");
						}
						break;
					case RoomDefinition.Type.DNAAnalysis:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:DNA"))
						{
							list2.Add("Tannoy:CleanupRequired:DNA");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:DNA");
						}
						break;
					case RoomDefinition.Type.FluidAnalysis:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Fluid"))
						{
							list2.Add("Tannoy:CleanupRequired:Fluid");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Fluid");
						}
						break;
					case RoomDefinition.Type.GeneralDiagnosis:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:GenDiag"))
						{
							list2.Add("Tannoy:CleanupRequired:GenDiag");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:GenDiag");
						}
						break;
					case RoomDefinition.Type.GPOffice:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:GP"))
						{
							list2.Add("Tannoy:CleanupRequired:GP");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:GP");
						}
						break;
					case RoomDefinition.Type.InjectionRoom:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Injection"))
						{
							list2.Add("Tannoy:CleanupRequired:Injection");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Injection");
						}
						break;
					case RoomDefinition.Type.Marketing:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Marketing"))
						{
							list2.Add("Tannoy:CleanupRequired:Marketing");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Marketing");
						}
						break;
					case RoomDefinition.Type.MRIScanner:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:MRI"))
						{
							list2.Add("Tannoy:CleanupRequired:MRI");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:MRI");
						}
						break;
					case RoomDefinition.Type.MummyClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Mummy"))
						{
							list2.Add("Tannoy:CleanupRequired:Mummy");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Mummy");
						}
						break;
					case RoomDefinition.Type.PandemicClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Pandemic"))
						{
							list2.Add("Tannoy:CleanupRequired:Pandemic");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Pandemic");
						}
						break;
					case RoomDefinition.Type.Pharmacy:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Pharmacy"))
						{
							list2.Add("Tannoy:CleanupRequired:Pharmacy");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Pharmacy");
						}
						break;
					case RoomDefinition.Type.Psychiatry:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Psych"))
						{
							list2.Add("Tannoy:CleanupRequired:Psych");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Psych");
						}
						break;
					case RoomDefinition.Type.Research:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Research"))
						{
							list2.Add("Tannoy:CleanupRequired:Research");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Research");
						}
						break;
					case RoomDefinition.Type.ClinicCubism:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Cubism"))
						{
							list2.Add("Tannoy:CleanupRequired:Cubism");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Cubism");
						}
						break;
					case RoomDefinition.Type.ElectricShockClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Shock"))
						{
							list2.Add("Tannoy:CleanupRequired:Shock");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Shock");
						}
						break;
					case RoomDefinition.Type.StaffRoom:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:StaffRoom"))
						{
							list2.Add("Tannoy:CleanupRequired:StaffRoom");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:StaffRoom");
						}
						break;
					case RoomDefinition.Type.OperatingTheater:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Surgery"))
						{
							list2.Add("Tannoy:CleanupRequired:Surgery");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Surgery");
						}
						break;
					case RoomDefinition.Type.TurtleHeadClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:TurtleHead"))
						{
							list2.Add("Tannoy:CleanupRequired:TurtleHead");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:TurtleHead");
						}
						break;
					case RoomDefinition.Type.XRay:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Xray"))
						{
							list2.Add("Tannoy:CleanupRequired:Xray");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Xray");
						}
						break;
					case RoomDefinition.Type.DogClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:BarkingMad"))
						{
							list2.Add("Tannoy:CleanupRequired:BarkingMad");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:BarkingMad");
						}
						break;
					case RoomDefinition.Type.RobotMonsterClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Robotzilla"))
						{
							list2.Add("Tannoy:CleanupRequired:Robotzilla");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Robotzilla");
						}
						break;
					case RoomDefinition.Type.FrankensteinClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Frankie"))
						{
							list2.Add("Tannoy:CleanupRequired:Frankie");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Frankie");
						}
						break;
					case RoomDefinition.Type.BlankLooksClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:BlankLooks"))
						{
							list2.Add("Tannoy:CleanupRequired:BlankLooks");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:BlankLooks");
						}
						break;
					case RoomDefinition.Type.ExplorerClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Explorer"))
						{
							list2.Add("Tannoy:CleanupRequired:Explorer");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Explorer");
						}
						break;
					case RoomDefinition.Type.EightBallClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Screwball"))
						{
							list2.Add("Tannoy:CleanupRequired:Screwball");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Screwball");
						}
						break;
					case RoomDefinition.Type.CardboardClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Cardboard"))
						{
							list2.Add("Tannoy:CleanupRequired:Cardboard");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Cardboard");
						}
						break;
					case RoomDefinition.Type.FrogClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Frog"))
						{
							list2.Add("Tannoy:CleanupRequired:Frog");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Frog");
						}
						break;
					case RoomDefinition.Type.AstroClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Astro"))
						{
							list2.Add("Tannoy:CleanupRequired:Astro");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Astro");
						}
						break;
					case RoomDefinition.Type.PinocchioClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Pinocchio"))
						{
							list2.Add("Tannoy:CleanupRequired:Pinocchio");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Pinocchio");
						}
						break;
					case RoomDefinition.Type.ScarecrowClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Scarecrow"))
						{
							list2.Add("Tannoy:CleanupRequired:Scarecrow");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Scarecrow");
						}
						break;
					case RoomDefinition.Type.TechClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Tech"))
						{
							list2.Add("Tannoy:CleanupRequired:Tech");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Tech");
						}
						break;
					case RoomDefinition.Type.PlantWardClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:PlantWard"))
						{
							list2.Add("Tannoy:CleanupRequired:PlantWard");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:PlantWard");
						}
						break;
					case RoomDefinition.Type.StuntmanClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Stunt"))
						{
							list2.Add("Tannoy:CleanupRequired:Stunt");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Stunt");
						}
						break;
					case RoomDefinition.Type.MudPersonClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Mud"))
						{
							list2.Add("Tannoy:CleanupRequired:Mud");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Mud");
						}
						break;
					case RoomDefinition.Type.ToySoldierClinic:
						if (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:ToySoldier"))
						{
							list2.Add("Tannoy:CleanupRequired:ToySoldier");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:ToySoldier");
						}
						break;
					default:
						if (item.Definition.MaintenanceDescription == JobMaintenance.JobDescription.Litter && !_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Litter"))
						{
							list2.Add("Tannoy:CleanupRequired:Litter");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Litter");
						}
						if (item.Definition.MaintenanceDescription == JobMaintenance.JobDescription.MedicalWaste && item.Definition.DebugTag == "Vomit 1" && !_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Sick"))
						{
							list2.Add("Tannoy:CleanupRequired:Sick");
							_lastTannoyMessages.Add("Tannoy:CleanupRequired:Sick");
						}
						else if (item.Definition.MaintenanceDescription == JobMaintenance.JobDescription.MedicalWaste && (!_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Urine2") || !_lastTannoyMessages.Contains("Tannoy:CleanupRequired:Urine")) && new System.Random().Next(0, 4) == 1)
						{
							if (GameAlgorithms.DoesHospitalHaveRoom(_level.WorldState, RoomDefinition.Type.Toilets))
							{
								list2.Add("Tannoy:CleanupRequired:Urine2");
								_lastTannoyMessages.Add("Tannoy:CleanupRequired:Urine2");
							}
							else
							{
								list2.Add("Tannoy:CleanupRequired:Urine");
								_lastTannoyMessages.Add("Tannoy:CleanupRequired:Urine");
							}
						}
						break;
					}
				}
				if (item != null && item.OwningRoom != null && item.Definition.MaintenanceDescription == JobMaintenance.JobDescription.WiltedPlant && !_lastTannoyMessages.Contains("Tannoy:Maintenance:Plant"))
				{
					list2.Add("Tannoy:Maintenance:Plant");
					_lastTannoyMessages.Add("Tannoy:Maintenance:Plant");
				}
				if (item != null && item.OwningRoom != null && item.Definition.MaintenanceDescription == JobMaintenance.JobDescription.OutOfStock && !_lastTannoyMessages.Contains("Tannoy:Maintenance:Vending"))
				{
					list2.Add("Tannoy:Maintenance:Vending");
					_lastTannoyMessages.Add("Tannoy:Maintenance:Vending");
				}
				if (item != null && item.OwningRoom != null && item.Definition.DebugTag == "Bin" && !_lastTannoyMessages.Contains("Tannoy:Maintenance:Bin"))
				{
					list2.Add("Tannoy:Maintenance:Bin");
					_lastTannoyMessages.Add("Tannoy:Maintenance:Bin");
				}
			}
			if (list.Count > 0 || list2.Count > 0)
			{
				if (list.Count <= 0)
				{
					TryEnqueueAnnouncement(list2.RandomItem());
				}
				else if (list2.Count <= 0)
				{
					TryEnqueueAnnouncement(list.RandomItem());
				}
				else if (RandomUtils.GlobalRandomInstance.NextDouble() <= 0.5)
				{
					TryEnqueueAnnouncement(list.RandomItem());
				}
				else
				{
					TryEnqueueAnnouncement(list2.RandomItem());
				}
			}
		}
	}
}
