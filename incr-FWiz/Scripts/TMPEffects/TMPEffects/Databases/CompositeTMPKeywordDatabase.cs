using System.Collections.Generic;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.Databases
{
	public sealed class CompositeTMPKeywordDatabase : ITMPKeywordDatabase
	{
		private ITMPKeywordDatabase[] databases;

		public IEnumerable<ITMPKeywordDatabase> Databases => null;

		public CompositeTMPKeywordDatabase(ITMPKeywordDatabase[] databases)
		{
		}

		public bool TryGetFloat(string str, out float result)
		{
			result = default(float);
			return false;
		}

		public bool TryGetInt(string str, out int result)
		{
			result = default(int);
			return false;
		}

		public bool TryGetBool(string str, out bool result)
		{
			result = default(bool);
			return false;
		}

		public bool TryGetColor(string str, out Color result)
		{
			result = default(Color);
			return false;
		}

		public bool TryGetVector3(string str, out Vector3 result)
		{
			result = default(Vector3);
			return false;
		}

		public bool TryGetAnchor(string str, out Vector2 result)
		{
			result = default(Vector2);
			return false;
		}

		public bool TryGetAnimCurve(string str, out AnimationCurve result)
		{
			result = null;
			return false;
		}

		public bool TryGetUnityObject(string str, out Object result)
		{
			result = null;
			return false;
		}

		public bool TryGetOffsetProvider(string str, out ITMPOffsetProvider result)
		{
			result = null;
			return false;
		}
	}
}
