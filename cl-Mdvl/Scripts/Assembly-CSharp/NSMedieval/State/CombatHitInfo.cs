namespace NSMedieval.State
{
	public struct CombatHitInfo
	{
		public float Damage { get; set; }

		public float ArmorDamage { get; set; }

		public bool Critical { get; set; }

		public bool HasBlocked { get; set; }

		public EquipmentInstance ItemThatBlocked { get; set; }

		public bool DidAnyDamage()
		{
			if (!(Damage > 0.01f))
			{
				return ArmorDamage > 0.01f;
			}
			return true;
		}
	}
}
