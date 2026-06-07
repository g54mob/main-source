using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class SaveUniqueID
	{
		[SerializeField]
		protected Save m_Save;

		[SerializeField]
		protected UniqueID m_UniqueID;

		public bool SaveValue => m_Save.Value;

		public IdString Get => m_UniqueID.Get;

		public IdString Set
		{
			set
			{
				if (!m_Save.Value)
				{
					m_UniqueID.Set = value;
				}
			}
		}

		public SaveUniqueID()
		{
			m_Save = new Save();
			m_UniqueID = new UniqueID();
		}

		public SaveUniqueID(bool save)
			: this()
		{
			m_Save = new Save(save);
		}

		public SaveUniqueID(bool save, string defaultUniqueID)
			: this(save)
		{
			m_UniqueID = new UniqueID(defaultUniqueID);
		}
	}
}
