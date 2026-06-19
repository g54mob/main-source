using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class HospitalEventLog : MustCallDestroy
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public List<HospitalEvent.Config> EventConfigs;
		}

		private readonly Config _config;

		private readonly Level _level;

		private readonly List<HospitalEvent> _events;

		public Action OnEventAdded;

		public HospitalEventLog(Config config, Level level)
		{
			_config = config;
			_level = level;
			_events = new List<HospitalEvent>();
			RegisterEvents(restoreFromSave: false);
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			RegisterEvents(restoreFromSave: true);
		}

		private void RegisterEvents(bool restoreFromSave)
		{
			foreach (HospitalEvent.Config eventConfig in _config.EventConfigs)
			{
				eventConfig.RegisterEvents(_level, restoreFromSave);
			}
		}

		public override void Destroy()
		{
			foreach (HospitalEvent.Config eventConfig in _config.EventConfigs)
			{
				eventConfig.UnregisterEvents();
			}
			base.Destroy();
		}

		public void Update()
		{
			GameDate currentGameDate = _level.TimelineManager.CurrentGameDate;
			for (int num = _events.Count - 1; num >= 0; num--)
			{
				if (_events[num].HasExpired(currentGameDate))
				{
					_events.RemoveAt(num);
				}
			}
		}

		public void AddEvent(HospitalEvent hospitalEvent)
		{
			_events.Add(hospitalEvent);
			OnEventAdded.InvokeSafe();
		}

		public void GetEvents(ref List<HospitalEvent> events, Func<HospitalEvent, bool> evalFunc)
		{
			for (int num = _events.Count - 1; num >= 0; num--)
			{
				HospitalEvent hospitalEvent = _events[num];
				if (evalFunc(hospitalEvent))
				{
					events.Add(hospitalEvent);
				}
			}
		}
	}
}
