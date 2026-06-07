using ModApi.Levels;
using ModApi.Levels.Requirements;

namespace Assets.Scripts.Levels.Requirements
{
	public class ParentRequirement : LevelRequirement
	{
		public string ParentName { get; set; }

		public ParentRequirement(ILevel level, string parentName)
			: base(level)
		{
			ParentName = parentName;
			UpdateName();
		}

		protected override void OnFlightUpdate()
		{
			base.OnFlightUpdate();
			base.DisplayValue = base.Level.PlayerCraft.CraftNode.Parent.Name;
			if (base.Level.PlayerCraft.CraftNode.Parent.Name == ParentName)
			{
				base.Status = LevelRequirementStatus.Pass;
			}
			else
			{
				base.Status = LevelRequirementStatus.Incomplete;
			}
		}

		private void UpdateName()
		{
			base.Name = $"Sphere of Influence = {ParentName}";
		}
	}
}
