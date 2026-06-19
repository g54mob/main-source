using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign, ImplicitUseTargetFlags.Members)]
	[DontSaveAssetReference]
	public class StatusIcon : MonoBehaviour
	{
		public enum Type
		{
			NavBlocked = 0,
			Dying = 1,
			Cured = 2,
			TreatmentIneffective = 3,
			RageQuitting = 4,
			SentHome = 5,
			HealthLow = 6,
			Unhappy = 7,
			DecisionRequired = 8,
			DiagnosisExhausted = 9,
			TreatmentRoomRequired = 10,
			Toilet = 11,
			Hunger = 12,
			Thirst = 13,
			Boredom = 14,
			DropLitter = 15,
			Hot = 16,
			Cold = 17,
			StaffBreak = 18,
			StaffEnergyLow = 19,
			StaffIdle = 20,
			MaintenanceRequired = 21,
			MaintenanceWarning = 22,
			StaffRequired = 23,
			PromotionReady = 24,
			Promoted = 25,
			StaffFired = 26,
			StaffTraining = 27,
			StaffQualifications = 28,
			QueuePosition = 29,
			SpecialVIP = 30,
			WaitForBuiltRoom = 31,
			StaffChallenge = 32,
			StaffChallengeActive = 33,
			EpidemicTell = 34,
			Vaccinated = 35,
			InteractionQueuePosition = 36,
			AvailableProject = 37,
			MachineUpgrade = 38,
			TrainingLecternQualification = 39,
			FireExtinguisher = 40,
			StaffResigned = 41,
			ResearchProject = 42,
			MarketingCampaign = 43,
			SellInvalid = 44,
			VIP = 45,
			Fire = 46,
			InvalidItem = 47,
			Invalid = 48,
			RoderickCushion = 49
		}

		[SerializeField]
		private Type _type;

		[SerializeField]
		private float _iconYOffset = 2f;

		[SerializeField]
		private float _displayTime;

		[SerializeField]
		private InWorldHUDElement _inWorldHUDElement;

		[SerializeField]
		private Sprite _icon;

		[SerializeField]
		private LocalisedString _description;

		protected Level _level;

		private IStatusIconEmitter _emitter;

		private float _timeCreated;

		private int _priority;

		public Type IconType => _type;

		public int Priority => _priority;

		public float DisplayTime => _displayTime;

		public Sprite Icon => _icon;

		public LocalisedString Description => _description;

		public virtual void Initialise(IStatusIconEmitter emitter, Level level, int priority)
		{
			_level = level;
			_emitter = emitter;
			_priority = priority;
			_timeCreated = GameTime.unscaledTime;
			_inWorldHUDElement.Position = GetIconPosition();
			_inWorldHUDElement.CanBeHidden = true;
			_level.HUD.AddElement(_inWorldHUDElement, _level.HUD.InWorldTransform);
		}

		public void Destroy()
		{
			_level.HUD.RemoveElement(_inWorldHUDElement);
		}

		public void UpdatePosition()
		{
			_inWorldHUDElement.Position = GetIconPosition();
		}

		private Vector3 GetIconPosition()
		{
			return _emitter.GetStatusIconPosition() + Vector3.up * _iconYOffset;
		}

		public virtual bool HasTimedOut()
		{
			if (_displayTime > 0f)
			{
				return GameTime.unscaledTime >= _timeCreated + _displayTime;
			}
			return false;
		}

		public void ExtendTime()
		{
			_timeCreated = GameTime.unscaledTime;
		}
	}
}
