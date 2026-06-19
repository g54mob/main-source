using System;
using UnityEngine;

namespace UniversalInventorySystem
{
	[Serializable]
	public class DurabilityImage
	{
		[SerializeField]
		public string imageName;

		[SerializeField]
		public Sprite sprite;

		[SerializeField]
		public int durability;
	}
}
