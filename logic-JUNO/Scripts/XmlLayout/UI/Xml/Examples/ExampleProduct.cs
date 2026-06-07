using System;
using UnityEngine;

namespace UI.Xml.Examples
{
	[Serializable]
	public class ExampleProduct
	{
		public float Price;

		public string Name = "";

		public int Quantity;

		public Sprite Image;

		public bool IsBestDeal;
	}
}
