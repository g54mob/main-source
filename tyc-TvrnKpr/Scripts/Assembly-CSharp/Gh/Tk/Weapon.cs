using LitJson;

namespace Gh.Tk
{
	public class Weapon : ShopItem
	{
		[PersistenceOptIn]
		[PersistenceObjectReference]
		public new WeaponTemplate Template
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		[JsonIgnore]
		public override string VisualKey => null;

		public Weapon()
		{
		}

		public Weapon(WeaponTemplate template, bool representsTemplate = false)
		{
		}

		protected override int GetCraftableTargetTier()
		{
			return 0;
		}
	}
}
