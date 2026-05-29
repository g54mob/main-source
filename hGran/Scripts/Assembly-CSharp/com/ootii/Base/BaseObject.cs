using System;

namespace com.ootii.Base
{
	[Serializable]
	public class BaseObject : IBaseObject
	{
		public GUIDChangedDelegate GUIDChangedEvent;

		public string _GUID;

		public string _Name;

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

		public BaseObject()
		{
		}

		public BaseObject(string rGUID)
		{
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
