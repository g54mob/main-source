using System.Collections.Generic;
using System.Linq;

namespace Restory.Gameplay.SaveLoad
{
	public class GameplayDataCleaner
	{
		private readonly HashSet<string> actualIds = new HashSet<string>();

		public void AddActualId(string id)
		{
			actualIds.Add(id);
		}

		public void Clean(Dictionary<string, object> states)
		{
			foreach (string item in states.Keys.ToList())
			{
				if (!actualIds.Contains(item))
				{
					states.Remove(item);
				}
			}
			actualIds.Clear();
		}
	}
}
