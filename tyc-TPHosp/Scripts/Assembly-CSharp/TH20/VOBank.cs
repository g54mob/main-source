using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[CreateAssetMenu(menuName = "TH20/Configs/VO Bank", order = 1105)]
	public class VOBank : ScriptableObjectWithID
	{
		[Serializable]
		public class Item
		{
			public string Tag;

			public AudioClip English;

			public AudioClip German;

			public AudioClip Chinese;
		}

		public List<Item> Bank;
	}
}
