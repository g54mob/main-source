using System;
using Sirenix.Serialization;
using UnityEngine;

namespace KitchenData
{
	public abstract class LocalisedGameDataObject<T> : GameDataObject, ILocalised where T : Localisation
	{
		[OdinSerialize]
		public LocalisationObject<T> Info;

		[NonSerialized]
		[HideInInspector]
		public T Localisation;

		public override bool Localise(Locale locale, StringSubstitutor subs)
		{
			if (Info == null)
			{
				return false;
			}
			Localisation = Info.Get(locale);
			if (Localisation == null)
			{
				return false;
			}
			ProcessLocalisation(subs);
			return true;
		}

		protected virtual void ProcessLocalisation(StringSubstitutor subs)
		{
		}

		public virtual void Export(LocalisationContext context)
		{
			context.CurrentSourceID = ID;
			context.CurrentSourceName = base.name;
			foreach (Locale locale in context.Locales)
			{
				T val = Info.Get(locale);
				if (val != null)
				{
					val.Export(context);
				}
			}
		}

		public virtual void Import(LocalisationContext context)
		{
		}
	}
}
