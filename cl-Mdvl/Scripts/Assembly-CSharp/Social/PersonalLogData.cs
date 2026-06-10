using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Model;
using UnityEngine;

namespace Social
{
	[Serializable]
	public class PersonalLogData : Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private List<ConversationVariant> variant;

		public List<ConversationVariant> Variant => variant;

		public override string GetID()
		{
			return id;
		}

		public LocKeys[] GetVariantLocKeys(string variantId)
		{
			for (int i = 0; i < variant.Count; i++)
			{
				ConversationVariant conversationVariant = variant[i];
				if (conversationVariant.VariantId.Equals(variantId))
				{
					return conversationVariant.LocKeys;
				}
			}
			return null;
		}
	}
}
