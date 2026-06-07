using System;
using AirFishLab.ScrollingList.ContentManagement;
using UnityEngine;

namespace AirFishLab.ScrollingList.Demo
{
	[Serializable]
	public class StringStarData : IListContent
	{
		[SerializeField]
		private string _title;

		[SerializeField]
		private int _numOfStars;

		public string Title => _title;

		public int NumOfStars => _numOfStars;
	}
}
