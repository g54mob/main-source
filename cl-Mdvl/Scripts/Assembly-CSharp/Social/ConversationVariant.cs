using System;
using NSMedieval.Model;
using UnityEngine;

namespace Social
{
	[Serializable]
	public struct ConversationVariant
	{
		[SerializeField]
		private string variantId;

		[SerializeField]
		private LocKeys[] locKeys;

		public string VariantId => variantId;

		public LocKeys[] LocKeys => locKeys;
	}
}
