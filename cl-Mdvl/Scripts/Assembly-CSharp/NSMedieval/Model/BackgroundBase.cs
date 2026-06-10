using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class BackgroundBase : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private List<SkillValuePair> skillModifiers = new List<SkillValuePair>();

		[SerializeField]
		private float religiousAlignment;

		[SerializeField]
		private List<ActionTagType> blockedActionTags = new List<ActionTagType>();

		[SerializeField]
		private List<WorkerCharacteristicType> ignoreCharacteristicType = new List<WorkerCharacteristicType>();

		[SerializeField]
		private List<WorkerCharacteristicType> addCharacteristicTypeToIgnore = new List<WorkerCharacteristicType>();

		[SerializeField]
		private string effector;

		[SerializeField]
		private string[] bannedEffector;

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

		public string[] BannedEffector => bannedEffector;

		public List<SkillValuePair> SkillModifiers => skillModifiers;

		public float ReligiousAlignment => religiousAlignment;

		public List<ActionTagType> BlockedActionTags => blockedActionTags;

		public List<WorkerCharacteristicType> IgnoreCharacteristicType => ignoreCharacteristicType;

		public List<WorkerCharacteristicType> AddCharacteristicTypeToIgnore => addCharacteristicTypeToIgnore;

		public string Effector => effector;

		public int CreationPointCost => creationPointCost;

		public List<StringIntPair> GoalPreferences => goalPreferences;

		public override string GetID()
		{
			return id;
		}
	}
}
