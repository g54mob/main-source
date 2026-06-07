using System;
using AirFishLab.ScrollingList.ContentManagement;
using UnityEngine;

namespace AirFishLab.ScrollingList.Demo
{
	[Serializable]
	public class SpriteStringData : IListContent
	{
		[SerializeField]
		private Sprite _sprite;

		[SerializeField]
		private string _title;

		public Sprite sprite => _sprite;

		public string title => _title;
	}
}
