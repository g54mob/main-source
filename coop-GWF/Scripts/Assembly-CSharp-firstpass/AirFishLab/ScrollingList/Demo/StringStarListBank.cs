using AirFishLab.ScrollingList.ContentManagement;
using UnityEngine;

namespace AirFishLab.ScrollingList.Demo
{
	public class StringStarListBank : BaseListBank
	{
		[SerializeField]
		private StringStarData[] _datas;

		public override IListContent GetListContent(int index)
		{
			return _datas[index];
		}

		public override int GetContentCount()
		{
			return _datas.Length;
		}
	}
}
