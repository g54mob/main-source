using System;

namespace PajamaLlama.Flotsam.Morale
{
	public abstract class DayTimedMoraleEffect : MoraleEffect
	{
		[Serializable]
		public class DayTimedPersistentData : BasePersistentData
		{
			public int CurrentDay;

			public bool Active;

			public DayTimedPersistentData(DayTimedMoraleEffect moraleEffect)
				: base(moraleEffect)
			{
				CurrentDay = moraleEffect.CurrentDay;
				Active = moraleEffect.Active;
			}
		}

		public int Days = 3;

		public int CurrentDay { get; private set; }

		public bool Active { get; private set; }

		public override void Initialize(Agent agent, MoraleEffect properties)
		{
			base.Initialize(agent, properties);
			CurrentDay = 0;
			GameEventDispatcher.AddListener(GameEventType.DayEnded, OnDayEnd);
		}

		public override void Destroy()
		{
			GameEventDispatcher.RemoveListener(GameEventType.DayEnded, OnDayEnd);
		}

		private void OnDayEnd(GameEvent gameEvent)
		{
			if (IsActive())
			{
				CurrentDay++;
				if (CurrentDay >= Days)
				{
					Deactivate();
				}
			}
		}

		protected override void Activate()
		{
			CurrentDay = 0;
			Active = true;
			base.Activate();
		}

		protected override void Deactivate()
		{
			Active = false;
			base.Deactivate();
		}

		public override bool IsActive()
		{
			if (Active)
			{
				return CurrentDay < Days;
			}
			return false;
		}

		public override void Restore(BasePersistentData persistentData)
		{
			if (persistentData.TryReturnCast<DayTimedPersistentData>(out var persistentData2))
			{
				CurrentDay = persistentData2.CurrentDay;
				Active = persistentData2.Active;
				return;
			}
			throw new NotImplementedException();
		}

		public override BasePersistentData ReturnPersistentData()
		{
			return new DayTimedPersistentData(this);
		}
	}
}
