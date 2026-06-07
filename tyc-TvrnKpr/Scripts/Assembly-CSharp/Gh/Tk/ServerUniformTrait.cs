using System;

namespace Gh.Tk
{
	[RelatedSkills(new Type[] { typeof(ServerSkill) })]
	public class ServerUniformTrait : StaffUniformTrait
	{
		protected ServerUniformTrait()
		{
		}

		public ServerUniformTrait(Staff owner)
		{
		}
	}
}
