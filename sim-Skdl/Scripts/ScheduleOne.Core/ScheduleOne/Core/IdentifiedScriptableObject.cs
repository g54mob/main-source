using System;
using UnityEngine;

namespace ScheduleOne.Core
{
	public abstract class IdentifiedScriptableObject : ScriptableObject
	{
		[Serializable]
		private class SerializedGUID
		{
			[SerializeField]
			private string _guidString;

			public void Set(Guid guid)
			{
			}

			public Guid ToGuid()
			{
				return default(Guid);
			}
		}

		[HideInInspector]
		[SerializeField]
		private SerializedGUID _serializedGUID;

		public Guid GUID => default(Guid);

		public void SetGuid(Guid guid)
		{
		}
	}
}
