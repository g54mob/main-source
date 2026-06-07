namespace Gh.Tk
{
	public abstract class DislikesRoleTrait : SkillTraitBase
	{
		[PersistenceOptIn]
		private readonly string _dislikedRole;

		protected DislikesRoleTrait()
		{
		}

		protected DislikesRoleTrait(Staff owner, string dislikedRole)
		{
		}

		public override void Init()
		{
		}

		private void OnCurrentlyWorkingAsRoleChanged(object sender, EventArgs<string> e)
		{
		}

		private void OnCurrentRoleChanged(object sender, EventArgs<Staff> e)
		{
		}

		private void UpdateHappiness()
		{
		}

		public override void OnRemoving()
		{
		}
	}
}
