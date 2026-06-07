using System.Reflection;

namespace Jundroo.DevConsole.Commands
{
	internal class MemberCommandSegment : ConsoleCommandSegment
	{
		public MemberInfo Member { get; set; }

		public override ConsoleCommandSegment Clone(bool needsReevaluated)
		{
			return new MemberCommandSegment
			{
				Member = Member,
				CommandText = base.CommandText,
				CommandType = base.CommandType,
				Evaluated = (!needsReevaluated && base.Evaluated)
			};
		}
	}
}
