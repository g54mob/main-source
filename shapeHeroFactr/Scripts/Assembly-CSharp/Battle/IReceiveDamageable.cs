namespace Battle
{
	public interface IReceiveDamageable
	{
		int CutDamage { get; set; }

		bool ReceiveDamage(int unitAttackPoint, eLuggage giverLuggage, bool displayDamage = true, bool isAdditionalDamage = true);
	}
}
