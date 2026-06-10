using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Types;
using UnityEngine;
using UnityEngine.Serialization;

namespace NSMedieval.Model
{
	[Serializable]
	public class Perk : NSEipix.Base.Model
	{
		[FormerlySerializedAs("perkCategory")]
		[SerializeField]
		private List<string> conflictsWith;

		[SerializeField]
		private string id;

		[SerializeField]
		private List<WorkerCharacteristicType> perkTypes = new List<WorkerCharacteristicType>();

		[SerializeField]
		private List<SkillValuePair> skillModifiers = new List<SkillValuePair>();

		[SerializeField]
		private List<AttributeModifierPair> attributeModifiers = new List<AttributeModifierPair>();

		[SerializeField]
		private List<StringIntPair> goalPreferences = new List<StringIntPair>();

		[SerializeField]
		private List<WorkerCharacteristicType> ignoreCharacteristicType = new List<WorkerCharacteristicType>();

		[SerializeField]
		private List<WorkerCharacteristicType> addCharacteristicTypeToIgnore = new List<WorkerCharacteristicType>();

		[SerializeField]
		private string effector;

		[SerializeField]
		private string[] bannedEffector;

		[SerializeField]
		private string[] allowedEffectors;

		[SerializeField]
		private int creationPointCost;

		[SerializeField]
		private bool forbidOnBirthday;

		[SerializeField]
		private bool forbidOnStart;

		[SerializeField]
		private bool forbidForNewSettler;

		[SerializeField]
		private bool forbidForNpc;

		[SerializeField]
		private string iconPath;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private bool hideInGame;

		[NonSerialized]
		private HashSet<string> conflictsWithSet;

		[NonSerialized]
		private bool conflictsWithSetInit;

		public LocKeys[] LocKeys => locKeys;

		public override bool HideInGame => hideInGame;

		public string[] AllowedEffectors => allowedEffectors;

		public string[] BannedEffector => bannedEffector;

		public string Effector => effector;

		public HashSet<string> ConflictsWith
		{
			get
			{
				if (!conflictsWithSetInit)
				{
					conflictsWithSetInit = true;
					conflictsWithSet = new HashSet<string>(conflictsWith);
				}
				return conflictsWithSet;
			}
		}

		public string Name => id;

		public List<WorkerCharacteristicType> PerkTypes => perkTypes;

		public List<SkillValuePair> SkillModifiers => skillModifiers;

		public List<AttributeModifierPair> AttributeModifiers => attributeModifiers;

		public List<WorkerCharacteristicType> IgnoreCharacteristicType => ignoreCharacteristicType;

		public List<WorkerCharacteristicType> AddCharacteristicTypeToIgnore => addCharacteristicTypeToIgnore;

		public int CreationPointCost => creationPointCost;

		public bool ForbidOnBirthday => forbidOnBirthday;

		public string IconPath => iconPath;

		public List<StringIntPair> GoalPreferences => goalPreferences;

		public bool ForbidOnStart => forbidOnStart;

		public bool ForbidForNewSettler => forbidForNewSettler;

		public bool ForbidForNpc => forbidForNpc;

		public override string GetID()
		{
			return id;
		}
	}
}
