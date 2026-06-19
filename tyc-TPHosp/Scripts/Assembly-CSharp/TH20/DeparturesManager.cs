using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class DeparturesManager : MustCallDestroy
	{
		private readonly List<DepartureMethod> _departures;

		private Level _level;

		public DeparturesManager(Level level)
		{
			_departures = new List<DepartureMethod>();
			_level = level;
			CharacterEvents characterEvents = level.CharacterEvents;
			characterEvents.OnCharacterDestroyed = (Action<Character>)Delegate.Combine(characterEvents.OnCharacterDestroyed, new Action<Character>(OnCharacterDestroyed));
		}

		public void RestoreFromSave(Level level)
		{
			foreach (DepartureMethod departure in _departures)
			{
				departure.RestoreFromSave();
			}
			_level = level;
			CharacterEvents characterEvents = level.CharacterEvents;
			characterEvents.OnCharacterDestroyed = (Action<Character>)Delegate.Combine(characterEvents.OnCharacterDestroyed, new Action<Character>(OnCharacterDestroyed));
		}

		public DepartureMethod Add(Character character, DepartureMethodDefinition methodDefinition, IDepartedCallback callback)
		{
			foreach (DepartureMethod departure in _departures)
			{
				if (departure.Character == character)
				{
					departure.DepartedCallback = callback;
					return departure;
				}
			}
			DepartureMethod departureMethod = methodDefinition.Create(character, callback);
			_departures.Add(departureMethod);
			return departureMethod;
		}

		public void Update()
		{
			_departures.RemoveAll(delegate(DepartureMethod method)
			{
				if (!method.Update())
				{
					return false;
				}
				method.Destroy();
				return true;
			});
		}

		private void OnCharacterDestroyed(Character character)
		{
			DepartureMethod departureMethod = null;
			foreach (DepartureMethod departure in _departures)
			{
				if (departure.Character == character)
				{
					departureMethod = departure;
					break;
				}
			}
			if (departureMethod != null)
			{
				_departures.Remove(departureMethod);
				departureMethod.Destroy();
			}
		}

		public override void Destroy()
		{
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnCharacterDestroyed = (Action<Character>)Delegate.Remove(characterEvents.OnCharacterDestroyed, new Action<Character>(OnCharacterDestroyed));
			_departures.ClearAndCallDestroy();
			base.Destroy();
		}
	}
}
