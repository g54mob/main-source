using System;
using UnityEngine;

namespace Dhs5.Utility.Databases
{
	[Serializable]
	public class DataPicker
	{
		[SerializeField]
		private BaseDataContainer m_container;

		[SerializeField]
		private int m_currentSelectionUID;

		public bool TryGetObject(out UnityEngine.Object obj)
		{
			if (m_container != null && m_currentSelectionUID > 0)
			{
				return m_container.TryGetDataByUID(m_currentSelectionUID, out obj);
			}
			obj = null;
			return false;
		}

		public bool TryGetData<T>(out T objOfTypeT) where T : UnityEngine.Object, IDataContainerElement
		{
			if (m_container != null && m_currentSelectionUID > 0)
			{
				return m_container.TryGetDataByUID(m_currentSelectionUID, out objOfTypeT);
			}
			objOfTypeT = null;
			return false;
		}
	}
	[Serializable]
	public class DataPicker<DatabaseType> where DatabaseType : BaseDataContainer
	{
		[SerializeField]
		private DatabaseType m_container;

		[SerializeField]
		private int m_currentSelectionUID;

		public bool TryGetObject(out UnityEngine.Object obj)
		{
			if (m_container != null && m_currentSelectionUID > 0)
			{
				return m_container.TryGetDataByUID(m_currentSelectionUID, out obj);
			}
			obj = null;
			return false;
		}

		public bool TryGetData<T>(out T objOfTypeT) where T : UnityEngine.Object, IDataContainerElement
		{
			if (m_container != null && m_currentSelectionUID > 0)
			{
				return m_container.TryGetDataByUID(m_currentSelectionUID, out objOfTypeT);
			}
			objOfTypeT = null;
			return false;
		}
	}
}
