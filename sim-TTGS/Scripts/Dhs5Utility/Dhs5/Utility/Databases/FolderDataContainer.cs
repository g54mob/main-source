using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.Utility.Databases
{
	public abstract class FolderDataContainer : BaseDataContainer
	{
		[SerializeField]
		[FolderPicker]
		private string m_folderName;

		[SerializeField]
		private List<Object> m_folderContent;

		public override int Count => m_folderContent.Count;

		public override Object GetDataAtIndex(int index)
		{
			if (m_folderContent.IsIndexValid(index))
			{
				return GetObjectAsDataContainerElement(m_folderContent[index]) as Object;
			}
			return null;
		}

		public override bool TryGetDataByUID(int uid, out Object obj)
		{
			foreach (Object item in m_folderContent)
			{
				IDataContainerElement objectAsDataContainerElement = GetObjectAsDataContainerElement(item);
				if (objectAsDataContainerElement.UID == uid)
				{
					obj = objectAsDataContainerElement as Object;
					return true;
				}
			}
			obj = null;
			return false;
		}
	}
}
