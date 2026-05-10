using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "AI/Satisfaction Point List")]
	public class AgentSatisfactionPoints : ScriptableObject
	{
		[SerializeField]
		private SerializableDictionary<StringKey, int> _points = new SerializableDictionary<StringKey, int>();

		public int GetPointValue(StringKey key)
		{
			if (_points.TryGetValue(key, out var value))
			{
				return value;
			}
			return 0;
		}
	}
}
