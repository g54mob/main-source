using System;
using System.Collections.Generic;
using Shapes;
using UnityEngine;

namespace Gh.Tk
{
	public static class Activities_Goto
	{
		private static Color _noPathColorStart;

		private static Color _noPathColorEnd;

		public static Activity GoNear(Vector3 position, bool slowDownAtTheEnd, float minDistance = 2f, Func<Activity, bool> endCondition = null, bool leaveAP = true)
		{
			return null;
		}

		private static Activity GotoPosition(Vector3 position, float rotation, bool slowDownAtTheEnd, float stoppingDistance = 0f, Func<Activity, bool> endCondition = null, bool leaveAP = false)
		{
			return null;
		}

		private static Activity GotoPosition(Vector3 position, float rotation, float stoppingDistance, bool slowDownAtTheEnd, Func<Activity, bool> endCondition, bool leaveAP = false, bool teleportAtEnd = false)
		{
			return null;
		}

		private static void ShowNoPath(Vector3 position, Actor actor, ref Line noPathLine)
		{
		}

		private static void HideNoPath(Actor actor, ref Line line)
		{
		}

		private static Activity GotoGameObject(GameObject gameObject, float rotation, bool slowDownAtTheEnd)
		{
			return null;
		}

		public static Activity GotoServeSpotForPatron(Patron patron, Actor actor)
		{
			return null;
		}

		internal static Activity GotoGameObjectXTarget(GameObjectXMatchInfo info, bool slowDownAtTheEnd)
		{
			return null;
		}

		public static Activity GotoUse(GameObjectX target, Actor actor, string reason = null, bool ignoreQueue = false)
		{
			return null;
		}

		public static Activity SitDownIfNeeded(AccessPoint ap)
		{
			return null;
		}

		private static Activity GetOvercrowdedAbortActivity(GameObjectX target, IEnumerable<AccessPoint> waitPoints, Actor actor)
		{
			return null;
		}

		public static Activity GotoUse(GameObjectXMatchInfo matchInfo, Actor actor, bool ignoreQueue = false)
		{
			return null;
		}
	}
}
