using System;
using UnityEngine;
using com.ootii.Data.Serializers;

namespace com.ootii.Base
{
	[Serializable]
	public class BaseScriptableObject : ScriptableObject, IBaseObject
	{
		public GUIDChangedDelegate GUIDChangedEvent;

		[HideInInspector]
		public string _GUID;

		[SerializationIgnore]
		public virtual string GUID
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[SerializationIgnore]
		public virtual string Name
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string GenerateGUID()
		{
			return null;
		}

		public virtual void OnGUIDChanged(string rOldGUID, string rNewGUID)
		{
		}
	}
}
