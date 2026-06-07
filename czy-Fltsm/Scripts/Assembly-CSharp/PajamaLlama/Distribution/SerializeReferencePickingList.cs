using System;
using UnityEngine;

namespace PajamaLlama.Distribution
{
	[Serializable]
	public class SerializeReferencePickingList<T> : PickingListBase<T>
	{
		[SerializeReference]
		[InstantiateSerializeReference]
		private T[] _items;

		public override T[] Items => _items;
	}
}
