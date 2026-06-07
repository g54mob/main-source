using System;
using UnityEngine;

namespace PajamaLlama.Distribution
{
	[Serializable]
	public class SerializeFieldPickingList<T> : PickingListBase<T>
	{
		[SerializeField]
		private T[] _items;

		public override T[] Items => _items;
	}
}
