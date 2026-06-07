using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Variables
{
	[CreateAssetMenu(menuName = "Variables/SciencePointLibrary", fileName = "SciencePointLibrary", order = 0)]
	public class SciencePointLibrarySO : ScriptableObject
	{
		private Dictionary<Color, int> _sciencePoints = new Dictionary<Color, int>();

		public Action<Color, int> OnSciencePointAdded = delegate
		{
		};

		public Dictionary<Color, int> SciencePoints => _sciencePoints;

		public void AddSciencePoints(Color color, int amount)
		{
			if (!_sciencePoints.TryAdd(color, amount))
			{
				_sciencePoints[color] += amount;
			}
			OnSciencePointAdded(color, _sciencePoints[color]);
		}
	}
}
