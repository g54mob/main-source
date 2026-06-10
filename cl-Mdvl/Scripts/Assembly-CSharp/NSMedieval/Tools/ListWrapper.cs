using System;
using System.Collections.Generic;
using UnityEngine;

namespace NSMedieval.Tools
{
	[Serializable]
	public abstract class ListWrapper<T>
	{
		[SerializeField]
		private List<T> items;

		public List<T> Items => items;
	}
}
