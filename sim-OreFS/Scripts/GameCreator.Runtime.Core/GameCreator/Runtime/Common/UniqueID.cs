using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class UniqueID
	{
		[SerializeField]
		private IdString m_SerializedID;

		public IdString Get => m_SerializedID;

		public IdString Set
		{
			set
			{
				m_SerializedID = value;
			}
		}

		public UniqueID()
		{
			m_SerializedID = new IdString(GenerateID());
		}

		public UniqueID(string defaultID)
		{
			defaultID = (string.IsNullOrEmpty(defaultID) ? GenerateID() : defaultID);
			m_SerializedID = new IdString(defaultID);
		}

		public static string GenerateID()
		{
			return Guid.NewGuid().ToString("D");
		}

		public override string ToString()
		{
			return m_SerializedID.String;
		}

		public override bool Equals(object obj)
		{
			return Get.Equals(obj);
		}

		public override int GetHashCode()
		{
			return Get.GetHashCode();
		}
	}
}
