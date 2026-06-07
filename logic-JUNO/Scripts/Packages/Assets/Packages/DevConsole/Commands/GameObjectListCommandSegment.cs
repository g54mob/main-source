using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Packages.DevConsole.Commands
{
	internal class GameObjectListCommandSegment : ConsoleCommandSegment
	{
		public List<GameObject> GameObjects { get; set; }

		public override ConsoleCommandSegment Clone(bool needsReevaluated)
		{
			return new GameObjectListCommandSegment
			{
				GameObjects = GameObjects.ToList(),
				CommandText = base.CommandText,
				CommandType = base.CommandType,
				Evaluated = (!needsReevaluated && base.Evaluated)
			};
		}
	}
}
