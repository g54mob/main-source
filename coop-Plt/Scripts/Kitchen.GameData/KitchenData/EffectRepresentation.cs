using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "Effect Representation", menuName = "Kitchen/Effect Representation", order = 3)]
	public class EffectRepresentation : LocalisedGameDataObject<EffectInfo>
	{
		public string Name;

		public string Description;

		public string Icon;

		protected override void InitialiseDefaults()
		{
		}

		public override bool Localise(Locale locale, StringSubstitutor subs)
		{
			if (Info == null)
			{
				return false;
			}
			EffectInfo effectInfo = Info.Get(locale);
			if (effectInfo == null)
			{
				return false;
			}
			Name = subs.Parse(effectInfo.Name);
			Description = subs.Parse(effectInfo.Description);
			Icon = subs.Parse(effectInfo.Icon);
			return true;
		}
	}
}
