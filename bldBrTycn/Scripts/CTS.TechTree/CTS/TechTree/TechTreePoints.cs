using System;
using CTS.Core;
using UnityEngine;

namespace CTS.TechTree
{
	public class TechTreePoints : CTSSingleton<TechTreePoints>
	{
		public int MaxPoints { get; private set; } = 999;

		public int CurrentPoints { get; private set; }

		public static event Action OnGainResearchPoints;

		public static event Action OnLooseResearchPoints;

		public static event Action<int> ResearchPointsGained;

		public void LoadPoints(int points)
		{
			CurrentPoints = Mathf.Clamp(points, 0, MaxPoints);
			TechTreePoints.OnGainResearchPoints?.Invoke();
		}

		public void SetPoints(int pointsToSet)
		{
			if (CurrentPoints != pointsToSet)
			{
				if (CurrentPoints > pointsToSet)
				{
					SpendPoints(CurrentPoints - pointsToSet);
				}
				else
				{
					TryToAddPoints(pointsToSet - CurrentPoints);
				}
			}
		}

		public bool TryToAddPoints(int pointsToAdd)
		{
			if (pointsToAdd <= 0)
			{
				return false;
			}
			if (CurrentPoints >= MaxPoints)
			{
				return false;
			}
			CurrentPoints = Mathf.Min(CurrentPoints + pointsToAdd, MaxPoints);
			TechTreePoints.OnGainResearchPoints?.Invoke();
			TechTreePoints.ResearchPointsGained?.Invoke(pointsToAdd);
			return true;
		}

		public void SpendPoints(int pointsToSpend)
		{
			if (pointsToSpend > 0)
			{
				CurrentPoints = Mathf.Max(CurrentPoints - pointsToSpend, 0);
				TechTreePoints.OnLooseResearchPoints?.Invoke();
			}
		}

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}
	}
}
