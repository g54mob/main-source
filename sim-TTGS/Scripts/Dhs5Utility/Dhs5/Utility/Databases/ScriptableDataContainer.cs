using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.Utility.Databases
{
	public abstract class ScriptableDataContainer : BaseDataContainer
	{
		[SerializeField]
		private List<ScriptableObject> m_content;

		public override int Count => m_content.Count;

		public override Object GetDataAtIndex(int index)
		{
			if (m_content.IsIndexValid(index))
			{
				return m_content[index];
			}
			return null;
		}

		public override bool TryGetDataByUID(int uid, out Object obj)
		{
			foreach (ScriptableObject item in m_content)
			{
				if (item is IDataContainerElement dataContainerElement && dataContainerElement.UID == uid)
				{
					obj = item;
					return true;
				}
			}
			obj = null;
			return false;
		}
	}
}
