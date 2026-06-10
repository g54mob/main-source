using System;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class ResourceOrderPair
	{
		[SerializeField]
		private string resourceId;

		[SerializeField]
		private OrderType orders;

		public string ResourceId => resourceId;

		public OrderType Orders => orders;
	}
}
