using System;
using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence.Achievements;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.DronePerks
{
	public class DronePerk : SerializedScriptableObject
	{
		[SerializeField]
		[ReadOnly]
		public string UniqueId;

		public TranslationTerm Name;

		public TranslationTerm Description;

		public bool OverrideEffectDescription;

		[ShowIf("OverrideEffectDescription", true)]
		public TranslationTerm EffectDescription;

		public Texture2D Icon;

		public Texture2D Image;

		public DronePartStarterSet StarterSet;

		public List<DroneEffectSetting> Effects = new List<DroneEffectSetting>();

		public EAchievement SurvivalModeAchievement;

		public bool Hidden;

		public string GetDetailedTooltip()
		{
			return LabelHelper.Blue + Name;
		}

		public string GetEffectDescription()
		{
			if (OverrideEffectDescription)
			{
				return EffectDescription.GetTranslation();
			}
			string text = "";
			if (Effects == null)
			{
				return text;
			}
			for (int i = 0; i < Effects.Count; i++)
			{
				text += Effects[i].Effect.GetDescription();
				if (i < Effects.Count - 1)
				{
					text += LabelHelper.NewLine;
				}
			}
			return text;
		}

		[ContextMenu("GenerateNewUniqueId")]
		public void GenerateNewUniqueId()
		{
			UniqueId = Guid.NewGuid().ToString();
		}
	}
}
