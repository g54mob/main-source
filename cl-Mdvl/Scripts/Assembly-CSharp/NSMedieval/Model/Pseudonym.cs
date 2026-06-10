using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class Pseudonym : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private List<SkillValuePair> skillModifiers = new List<SkillValuePair>();

		[SerializeField]
		private float religiousAlignment;

		[SerializeField]
		private List<WorkerCharacteristicType> ignoreCharacteristicType = new List<WorkerCharacteristicType>();

		[SerializeField]
		private List<WorkerCharacteristicType> addCharacteristicTypeToIgnore = new List<WorkerCharacteristicType>();

		[SerializeField]
		private int creationPointCost;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private bool hideInGame;

		[SerializeField]
		private List<StringIntPair> goalPreferences = new List<StringIntPair>();

		public LocKeys[] LocKeys => locKeys;

		public override bool HideInGame => hideInGame;

		public List<SkillValuePair> SkillModifiers => skillModifiers;

		public float ReligiousAlignment => religiousAlignment;

		public List<WorkerCharacteristicType> IgnoreCharacteristicType => ignoreCharacteristicType;

		public List<WorkerCharacteristicType> AddCharacteristicTypeToIgnore => addCharacteristicTypeToIgnore;

		public int CreationPointCost => creationPointCost;

		public List<StringIntPair> GoalPreferences => goalPreferences;

		public override string GetID()
		{
			return id;
		}
	}
}
