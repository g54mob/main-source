using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Assets.Packages.DevConsole.Commands
{
	internal class MemberListCommandSegment : ConsoleCommandSegment
	{
		public List<MemberInfo> Members { get; set; }

		public override ConsoleCommandSegment Clone(bool needsReevaluated)
		{
			return new MemberListCommandSegment
			{
				Members = Members.ToList(),
				CommandText = base.CommandText,
				CommandType = base.CommandType,
				Evaluated = (!needsReevaluated && base.Evaluated)
			};
		}
	}
}
