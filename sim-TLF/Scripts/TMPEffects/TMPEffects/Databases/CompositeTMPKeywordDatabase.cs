using System.Collections.Generic;
using System.Linq;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.Databases
{
	public sealed class CompositeTMPKeywordDatabase : ITMPKeywordDatabase
	{
		private ITMPKeywordDatabase[] databases;

		public IEnumerable<ITMPKeywordDatabase> Databases => databases.Where((ITMPKeywordDatabase db) => db != null);

		public CompositeTMPKeywordDatabase(ITMPKeywordDatabase[] databases)
		{
			this.databases = databases;
		}

		public bool TryGetFloat(string str, out float result)
		{
			for (int i = 0; i < databases.Length; i++)
			{
				ITMPKeywordDatabase iTMPKeywordDatabase = databases[i];
				if (iTMPKeywordDatabase != null && iTMPKeywordDatabase.TryGetFloat(str, out result))
				{
					return true;
				}
			}
			result = 0f;
			return false;
		}

		public bool TryGetInt(string str, out int result)
		{
			for (int i = 0; i < databases.Length; i++)
			{
				ITMPKeywordDatabase iTMPKeywordDatabase = databases[i];
				if (iTMPKeywordDatabase != null && iTMPKeywordDatabase.TryGetInt(str, out result))
				{
					return true;
				}
			}
			result = 0;
			return false;
		}

		public bool TryGetBool(string str, out bool result)
		{
			for (int i = 0; i < databases.Length; i++)
			{
				ITMPKeywordDatabase iTMPKeywordDatabase = databases[i];
				if (iTMPKeywordDatabase != null && iTMPKeywordDatabase.TryGetBool(str, out result))
				{
					return true;
				}
			}
			result = false;
			return false;
		}

		public bool TryGetColor(string str, out Color result)
		{
			for (int i = 0; i < databases.Length; i++)
			{
				ITMPKeywordDatabase iTMPKeywordDatabase = databases[i];
				if (iTMPKeywordDatabase != null && iTMPKeywordDatabase.TryGetColor(str, out result))
				{
					return true;
				}
			}
			result = default(Color);
			return false;
		}

		public bool TryGetVector3(string str, out Vector3 result)
		{
			for (int i = 0; i < databases.Length; i++)
			{
				ITMPKeywordDatabase iTMPKeywordDatabase = databases[i];
				if (iTMPKeywordDatabase != null && iTMPKeywordDatabase.TryGetVector3(str, out result))
				{
					return true;
				}
			}
			result = default(Vector3);
			return false;
		}

		public bool TryGetAnchor(string str, out Vector2 result)
		{
			for (int i = 0; i < databases.Length; i++)
			{
				ITMPKeywordDatabase iTMPKeywordDatabase = databases[i];
				if (iTMPKeywordDatabase != null && iTMPKeywordDatabase.TryGetAnchor(str, out result))
				{
					return true;
				}
			}
			result = default(Vector2);
			return false;
		}

		public bool TryGetAnimCurve(string str, out AnimationCurve result)
		{
			for (int i = 0; i < databases.Length; i++)
			{
				ITMPKeywordDatabase iTMPKeywordDatabase = databases[i];
				if (iTMPKeywordDatabase != null && iTMPKeywordDatabase.TryGetAnimCurve(str, out result))
				{
					return true;
				}
			}
			result = null;
			return false;
		}

		public bool TryGetUnityObject(string str, out Object result)
		{
			for (int i = 0; i < databases.Length; i++)
			{
				ITMPKeywordDatabase iTMPKeywordDatabase = databases[i];
				if (iTMPKeywordDatabase != null && iTMPKeywordDatabase.TryGetUnityObject(str, out result))
				{
					return true;
				}
			}
			result = null;
			return false;
		}

		public bool TryGetOffsetProvider(string str, out ITMPOffsetProvider result)
		{
			for (int i = 0; i < databases.Length; i++)
			{
				ITMPKeywordDatabase iTMPKeywordDatabase = databases[i];
				if (iTMPKeywordDatabase != null && iTMPKeywordDatabase.TryGetOffsetProvider(str, out result))
				{
					return true;
				}
			}
			result = null;
			return false;
		}
	}
}
