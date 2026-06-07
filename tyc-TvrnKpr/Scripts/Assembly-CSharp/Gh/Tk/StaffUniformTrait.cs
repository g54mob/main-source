using System;
using System.Collections.Generic;

namespace Gh.Tk
{
	public abstract class StaffUniformTrait : StaffTrait
	{
		private static Dictionary<string, Type> _uniformTraits;

		public string CorrespondingRole => null;

		public static void AddTraitForRoles(Staff target, string[] roles)
		{
		}

		protected StaffUniformTrait()
		{
		}

		protected StaffUniformTrait(Staff owner)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}

		public override void Init()
		{
		}

		private void ApplySkillModifiers()
		{
		}

		public override void OnRemoving()
		{
		}
	}
}
