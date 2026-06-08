using System;
using System.Collections.Generic;
using Sirenix.Serialization;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "Popup Text Localisation", menuName = "Kitchen/Localisation/Popup Text")]
	public class PopupTextLocalisation : LocalisationSet<PopupText>
	{
		[OdinSerialize]
		public LocalisationObject<PopupText> Info;

		[NonSerialized]
		[HideInInspector]
		public Dictionary<PopupType, PopupDetails> Text;

		public PopupDetails this[PopupType i]
		{
			get
			{
				if (Text.TryGetValue(i, out var value))
				{
					return value;
				}
				return default(PopupDetails);
			}
		}

		public PopupDetails this[PopupType i, float f]
		{
			get
			{
				if (Text.TryGetValue(i, out var value))
				{
					return new PopupDetails
					{
						Title = string.Format(value.Title, f),
						Description = string.Format(value.Description, f)
					};
				}
				return default(PopupDetails);
			}
		}

		public override LocalisationObject<PopupText> LocalisationInfo => Info;

		protected override void InitialiseDefaults()
		{
		}

		public override bool Localise(Locale locale, StringSubstitutor subs)
		{
			if (Info == null)
			{
				return false;
			}
			PopupText popupText = Info.Get(locale);
			if (popupText == null)
			{
				return false;
			}
			Text = new Dictionary<PopupType, PopupDetails>();
			foreach (KeyValuePair<PopupType, PopupDetails> item in popupText.Text)
			{
				Text.Add(item.Key, new PopupDetails
				{
					Title = subs.Parse(item.Value.Title),
					Description = subs.Parse(item.Value.Description)
				});
			}
			return true;
		}
	}
}
