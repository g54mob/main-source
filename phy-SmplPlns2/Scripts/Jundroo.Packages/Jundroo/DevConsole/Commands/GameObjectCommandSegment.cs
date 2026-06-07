using UnityEngine;

namespace Jundroo.DevConsole.Commands
{
	internal class GameObjectCommandSegment : ConsoleCommandSegment
	{
		public GameObject GameObject { get; set; }

		public override ConsoleCommandSegment Clone(bool needsReevaluated)
		{
			needsReevaluated = needsReevaluated || GameObject == null;
			return new GameObjectCommandSegment
			{
				GameObject = GameObject,
				CommandText = base.CommandText,
				CommandType = base.CommandType,
				Evaluated = (!needsReevaluated && base.Evaluated)
			};
		}
	}
}
