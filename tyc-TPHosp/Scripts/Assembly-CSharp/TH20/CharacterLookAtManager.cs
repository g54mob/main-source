using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class CharacterLookAtManager
	{
		private const int MaxPerFrame = 10;

		private int _lastProcessed;

		private readonly List<LookAtPOI> _POI;

		private readonly CharacterManager _characterManager;

		[DontSave]
		private List<Character> _charactersCache;

		public CharacterLookAtManager(CharacterManager characterManager)
		{
			_POI = new List<LookAtPOI>();
			_characterManager = characterManager;
			_charactersCache = new List<Character>(512);
		}

		public void RestoreFromSave()
		{
			_charactersCache = new List<Character>(512);
		}

		public void Update()
		{
			if (Time.deltaTime <= 0f)
			{
				return;
			}
			int num = _lastProcessed;
			int i = 0;
			int num2 = Mathf.Min(10, _POI.Count);
			if (num >= _POI.Count)
			{
				num = 0;
			}
			for (; i < num2; i++)
			{
				LookAtPOI lookAtPOI = _POI[num];
				_charactersCache.Clear();
				_characterManager.GetCharactersWithinDistance(lookAtPOI.Position, lookAtPOI.Radius, lookAtPOI.Source.GetRoomIn(), _charactersCache);
				foreach (Character item in _charactersCache)
				{
					if (lookAtPOI.Source.GetOwner() != item && lookAtPOI.GetInterest(item.Position) > 0f)
					{
						item.GetOrAddComponent<LookAtComponent>().AddPOI(lookAtPOI);
					}
				}
				_charactersCache.Clear();
				num++;
				if (num >= _POI.Count)
				{
					num = 0;
				}
			}
			_lastProcessed = num;
		}

		public void AddGlobalPOI(LookAtPOI poi)
		{
			_POI.Add(poi);
		}

		public void RemoveGlobalPOI(LookAtPOI poi)
		{
			_POI.Remove(poi);
			foreach (Character allCharacter in _characterManager.AllCharacters)
			{
				allCharacter.GetComponent<LookAtComponent>()?.RemovePOI(poi);
			}
		}
	}
}
