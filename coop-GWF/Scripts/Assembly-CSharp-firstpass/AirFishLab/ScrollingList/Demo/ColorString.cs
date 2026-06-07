using System;
using AirFishLab.ScrollingList.ContentManagement;
using UnityEngine;

namespace AirFishLab.ScrollingList.Demo
{
	[Serializable]
	public class ColorString : IListContent
	{
		public Color color;

		public string name;
	}
}
