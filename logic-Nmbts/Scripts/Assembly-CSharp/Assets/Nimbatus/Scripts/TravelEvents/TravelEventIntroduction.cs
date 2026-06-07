using System;
using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.GalaxyMap.Shops;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.TravelEvents
{
	[Serializable]
	public class TravelEventIntroduction
	{
		public ETravelEventIntroduction Type;

		[ShowIf("ShowDescription", true)]
		public TranslationTerm Description;

		[ShowIf("Type", ETravelEventIntroduction.Animation, true)]
		public string AnimationName;

		[ShowIf("Type", ETravelEventIntroduction.Animation, true)]
		public bool LoopAnimation;

		[ShowIf("Type", ETravelEventIntroduction.Scene, true)]
		public string LocationSceneName;

		[ShowIf("Type", ETravelEventIntroduction.GiveConsequences, true)]
		public bool SkipOutcomeDisplay;

		[ShowIf("Type", ETravelEventIntroduction.GiveConsequences, true)]
		public List<TravelEventConsequence> Consequences = new List<TravelEventConsequence>();

		[ShowIf("Type", ETravelEventIntroduction.GiveConsequences, true)]
		public bool HasFallbackConsequences;

		[ShowIf("HasFallbackConsequences", true)]
		public List<TravelEventConsequence> FallbackConsequences = new List<TravelEventConsequence>();

		[ShowIf("Type", ETravelEventIntroduction.Choice, true)]
		public TranslationTerm ChoiceDescription;

		[Header("Buttons")]
		[VerticalGroup("Buttons", 0)]
		[VerticalGroup("Buttons/Good", 0)]
		[ShowIf("Type", ETravelEventIntroduction.Choice, true)]
		public TranslationTerm ConfirmButtonText;

		[VerticalGroup("Buttons/Good", 0)]
		[ShowIf("Type", ETravelEventIntroduction.Choice, true)]
		public ItemPrice ConfirmCost;

		[VerticalGroup("Buttons/Bad", 0)]
		[ShowIf("Type", ETravelEventIntroduction.Choice, true)]
		public TranslationTerm IgnoreButtonText;

		[VerticalGroup("Buttons/Bad", 0)]
		[ShowIf("Type", ETravelEventIntroduction.Choice, true)]
		public ItemPrice IgnoreCost;

		[Header("Outcomes")]
		[ShowIf("Type", ETravelEventIntroduction.Choice, true)]
		[Range(0f, 1f)]
		public float GoodOutcomeProbability = 1f;

		[VerticalGroup("Outcomes", 0)]
		[ShowIf("Type", ETravelEventIntroduction.Choice, true)]
		[VerticalGroup("Outcomes/Good", 0)]
		public List<TravelEventIntroduction> SubsequenceGood = new List<TravelEventIntroduction>();

		[ShowIf("Type", ETravelEventIntroduction.Choice, true)]
		[VerticalGroup("Outcomes/Bad", 0)]
		public List<TravelEventIntroduction> SubsequenceBad = new List<TravelEventIntroduction>();

		[ShowIf("Type", ETravelEventIntroduction.EndAnimation, true)]
		public float OutroSpeedMultiplier = 1f;

		[ShowIf("Type", ETravelEventIntroduction.EndAnimation, true)]
		public bool OverrideEndAnimation;

		[ShowIf("Type", ETravelEventIntroduction.EndAnimation, true)]
		[ShowIf("OverrideEndAnimation", true)]
		public string EndAnimation;

		[ShowIf("Type", ETravelEventIntroduction.EndAnimation, true)]
		[ShowIf("OverrideEndAnimation", true)]
		public float EndAnimationNimbatusSpeed;

		[ShowIf("Type", ETravelEventIntroduction.EndAnimation, true)]
		[ShowIf("OverrideEndAnimation", true)]
		public float EndAnimationParticleSpeed;

		[HideInInspector]
		public bool ShowDescription
		{
			get
			{
				return Type == ETravelEventIntroduction.Text;
			}
		}
	}
}
