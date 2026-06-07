using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Code.Animals
{
	public class AnimalProperties : ActorProperties
	{
		[Header("Names")]
		[SerializeField]
		[FormerlySerializedAs("NameGenerators")]
		private NameGenerator[] _nameGenerators;

		[Header("Visuals")]
		[SerializeField]
		[FormerlySerializedAs("BirdPortraits")]
		public List<Sprite> _portraits = new List<Sprite>();

		[Header("Scouting")]
		[SerializeField]
		private WorldMapScoutingId _scoutingId;

		public List<Sprite> Portraits => _portraits;

		public WorldMapScoutingId ScoutingId => _scoutingId;

		public string GenerateName()
		{
			return FlotsamGame.Random(_nameGenerators).ReturnName();
		}
	}
}
