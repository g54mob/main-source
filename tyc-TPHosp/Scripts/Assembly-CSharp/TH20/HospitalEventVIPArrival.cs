using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventVIPArrival : HospitalEvent
	{
		public new class Config : HospitalEvent.Config
		{
			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnVisitorSpawned = (Action<Visitor>)Delegate.Combine(characterEvents.OnVisitorSpawned, new Action<Visitor>(OnVisitorSpawned));
			}

			public override void UnregisterEvents()
			{
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnVisitorSpawned = (Action<Visitor>)Delegate.Remove(characterEvents.OnVisitorSpawned, new Action<Visitor>(OnVisitorSpawned));
			}

			private void OnVisitorSpawned(Visitor visitor)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventVIPArrival
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					_icon = visitor.Definition._icon,
					_VIPName = visitor.CharacterName
				});
			}
		}

		private Sprite _icon;

		private CharacterName _VIPName;

		public override Sprite GetEventIcon()
		{
			return _icon;
		}

		public override string GetDescription()
		{
			return ScriptLocalization.HospitalEvent.VIPArrival_CS.Replace("{[NAME]}", _VIPName.GetCharacterName());
		}
	}
}
