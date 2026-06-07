namespace MalbersAnimations
{
	public interface IMDamagerSet
	{
		void ActivateDamager(int ID, int profile);

		void DamagerAnimationStart(int hash);

		void DamagerAnimationEnd(int hash);
	}
}
