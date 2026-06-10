using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Dictionary;
using NSMedieval.Enums;
using NSMedieval.Model;
using NSMedieval.StatsSystem;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	public class EntertainmentComponentBlueprint : NSEipix.Base.Model
	{
		private readonly BuildingType componentType = BuildingType.Shrine;

		[SerializeField]
		private string id;

		[SerializeField]
		private string interactAnimation;

		[SerializeField]
		private int interactAnimationVariationsCount;

		[SerializeField]
		private string interactTool;

		[SerializeField]
		private string toolSocket;

		[SerializeField]
		private List<string> workerEffectors;

		[SerializeField]
		private StringKeyPair statAffect = SerializableDictionary<string, float>.CreateNew<StringKeyPair>();

		[SerializeField]
		private string useGoal;

		[SerializeField]
		private SkillType addXpToSkill;

		[SerializeField]
		private int addXpAmount;

		[SerializeField]
		private TransformSettings sittingPosition;

		public BuildingType ComponentType => componentType;

		public string InteractAnimation => interactAnimation;

		public int InteractAnimationVariationsCount => interactAnimationVariationsCount;

		public string InteractTool => interactTool;

		public string ToolSocket => toolSocket;

		public List<string> WorkerEffectors => workerEffectors;

		public StringKeyPair StatAffect => statAffect;

		public string UseGoal => useGoal;

		public SkillType AddXpToSkill => addXpToSkill;

		public int AddXpAmount => addXpAmount;

		public TransformSettings SittingPosition => sittingPosition;

		public override string GetID()
		{
			return id;
		}
	}
}
