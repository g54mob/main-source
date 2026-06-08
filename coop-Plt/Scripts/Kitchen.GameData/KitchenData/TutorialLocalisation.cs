using System;
using System.Collections.Generic;
using Sirenix.Serialization;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "Tutorial Text Localisation", menuName = "Kitchen/Localisation/Tutorial Text")]
	public class TutorialLocalisation : LocalisationSet<TutorialText>
	{
		[OdinSerialize]
		public LocalisationObject<TutorialText> Info;

		[NonSerialized]
		[HideInInspector]
		public Dictionary<TutorialMessage, TutorialDetails> Text;

		public TutorialDetails this[TutorialMessage i]
		{
			get
			{
				if (Text.TryGetValue(i, out var value))
				{
					return value;
				}
				return default(TutorialDetails);
			}
		}

		public override LocalisationObject<TutorialText> LocalisationInfo => Info;

		protected override void InitialiseDefaults()
		{
		}

		public override bool Localise(Locale locale, StringSubstitutor subs)
		{
			if (Info == null)
			{
				return false;
			}
			TutorialText tutorialText = Info.Get(locale);
			if (tutorialText == null)
			{
				return false;
			}
			Text = new Dictionary<TutorialMessage, TutorialDetails>();
			foreach (KeyValuePair<TutorialMessage, TutorialDetails> item in tutorialText.Text)
			{
				Text.Add(item.Key, new TutorialDetails
				{
					Description = subs.Parse(item.Value.Description)
				});
			}
			return true;
		}
	}
}
