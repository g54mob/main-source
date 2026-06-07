using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public class RoundRobinUpdateManager
	{
		private Dictionary<string, List<IRoundRobinUpdate>> _updateGroups = new Dictionary<string, List<IRoundRobinUpdate>>();

		public void Register(IRoundRobinUpdate script)
		{
			if (!_updateGroups.ContainsKey(script.RoundRobinGroupKey))
			{
				_updateGroups[script.RoundRobinGroupKey] = new List<IRoundRobinUpdate>();
			}
			_updateGroups[script.RoundRobinGroupKey].Add(script);
		}

		public void Unregister(IRoundRobinUpdate script)
		{
			if (_updateGroups.ContainsKey(script.RoundRobinGroupKey))
			{
				_updateGroups[script.RoundRobinGroupKey].Remove(script);
				if (_updateGroups[script.RoundRobinGroupKey].Count == 0)
				{
					_updateGroups.Remove(script.RoundRobinGroupKey);
				}
			}
		}

		public void Update()
		{
			foreach (KeyValuePair<string, List<IRoundRobinUpdate>> updateGroup in _updateGroups)
			{
				List<IRoundRobinUpdate> value = updateGroup.Value;
				for (int num = value.Count - 1; num >= 0; num--)
				{
					if (value[num] == null || value[num].IsDestroyed)
					{
						value.RemoveAt(num);
					}
					else
					{
						bool isActiveThisFrame = Time.frameCount % value.Count == num;
						value[num].OnRoundRobinUpdate(isActiveThisFrame);
					}
				}
				if (value.Count == 0)
				{
					_updateGroups.Remove(updateGroup.Key);
				}
			}
		}
	}
}
