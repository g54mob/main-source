using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public static class TargetPicker
	{
		public static GameObjectXMatchInfo GetBestMatchNearActor(IEnumerable<GameObjectX> candidates, Actor actor, string reason = null, Func<GameObjectX, float> additionalRatingMethod = null, bool ignoreDistance = false, bool ignoreQueues = false)
		{
			return null;
		}

		public static GameObjectXMatchInfo GetBestMatchNearGox(IEnumerable<GameObjectX> candidates, Actor actor, GameObjectX gox, string reason = null, Func<GameObjectX, float> additionalRatingMethod = null)
		{
			return null;
		}

		public static GameObjectXMatchInfo GetBestSAPNearPatron(Patron patron, Actor actor, string reason = null, Func<GameObjectX, float> additionalRatingMethod = null)
		{
			return null;
		}

		public static GameObjectXMatchInfo GetBestMatchNearActor(GameObjectX candidate, Actor actor, string reason = null, Func<GameObjectX, float> additionalRatingMethod = null, bool ignoreDistance = false, bool ignoreQueues = false)
		{
			return null;
		}

		public static GameObjectXMatchInfo GetBestMatchNearPosition(GameObjectX candidate, Actor actor, Vector3 position, string reason = null, Func<GameObjectX, float> additionalRatingMethod = null)
		{
			return null;
		}

		private static GameObjectXMatchInfo GetBestMatch(GameObjectX candidate, Actor actor, Vector3 position, bool useAccessPointForDistanceCalculation, string reason = null, Func<GameObjectX, float> additionalRatingMethod = null, bool ignoreDistance = false, bool ignoreQueues = false)
		{
			return null;
		}

		private static float CalculateAPPenalty(Actor actor, AccessPoint ap)
		{
			return 0f;
		}

		public static IEnumerable<AccessPoint> GetAvailableAccessPoints(GameObjectX candidate, Actor actor, string reason, bool ignoreQueues = false)
		{
			return null;
		}

		public static IEnumerable<AccessPoint> GetAccessPoints(GameObjectX candidate, AccessPoint.AccessType type, string reason)
		{
			return null;
		}

		public static IEnumerable<AccessPoint> GetAccessPoints(GameObjectX candidate, Actor actor, string reason)
		{
			return null;
		}

		private static IEnumerable<AccessPoint> GetAccessPoints(string reason, IEnumerable<AccessPoint> allAccessPoints)
		{
			return null;
		}

		private static GameObjectXMatchInfo GetBestMatchInternal(GameObjectX candidate, Func<AccessPoint, float> ratingMethod, Actor actor, string reason, Func<GameObjectX, float> additionalRatingMethod, bool ignoreQueues = false)
		{
			return null;
		}
	}
}
