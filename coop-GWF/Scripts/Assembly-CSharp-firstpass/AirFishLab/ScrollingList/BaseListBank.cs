using AirFishLab.ScrollingList.ContentManagement;
using UnityEngine;

namespace AirFishLab.ScrollingList
{
	public abstract class BaseListBank : MonoBehaviour, IListBank
	{
		public abstract IListContent GetListContent(int index);

		public abstract int GetContentCount();
	}
}
