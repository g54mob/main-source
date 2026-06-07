using UnityEngine;

namespace Jundroo.DevConsole.Commands
{
	internal class ComponentCommandSegment : ConsoleCommandSegment
	{
		public Component Component { get; set; }

		public override ConsoleCommandSegment Clone(bool needsReevaluated)
		{
			needsReevaluated = needsReevaluated || Component == null;
			return new ComponentCommandSegment
			{
				Component = Component,
				CommandText = base.CommandText,
				CommandType = base.CommandType,
				Evaluated = (!needsReevaluated && base.Evaluated)
			};
		}
	}
}
