using System.Collections.Generic;

namespace Services
{
	public class SceneItemIdGenerator : ISceneItemIdGenerator
	{
		private readonly Dictionary<string, int> _nameCounters = new Dictionary<string, int>();

		private readonly HashSet<string> _usedIds = new HashSet<string>();

		public string Generate(string gameObjectName)
		{
			if (!_nameCounters.ContainsKey(gameObjectName))
			{
				_nameCounters[gameObjectName] = 0;
				_usedIds.Add(gameObjectName);
				return gameObjectName;
			}
			_nameCounters[gameObjectName]++;
			string text = $"{gameObjectName}_{_nameCounters[gameObjectName]}";
			_usedIds.Add(text);
			return text;
		}

		public void Release(string id)
		{
			_usedIds.Remove(id);
		}
	}
}
