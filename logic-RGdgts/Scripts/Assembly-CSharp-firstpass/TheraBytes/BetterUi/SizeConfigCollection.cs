using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheraBytes.BetterUi
{
	[Serializable]
	public class SizeConfigCollection<T> : ISizeConfigCollection where T : class, IScreenConfigConnection
	{
		[SerializeField]
		private List<T> items;

		private bool sorted;

		public List<T> Items => null;

		public void Sort()
		{
		}

		public string GetCurrentConfigName()
		{
			return null;
		}

		public T GetCurrentItem(T fallback)
		{
			return null;
		}
	}
}
