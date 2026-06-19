using System;
using FullInspector.Generated.SharedInstance;
using UnityEngine;

namespace TH20
{
	[Serializable]
	public class ConversationFilterIllness : ConversationFilter
	{
		[SerializeField]
		private SharedInstance_TH20TH20_IllnessDefinition _illness;

		public bool IsValid(Character character)
		{
			if (_enabled)
			{
				if (character is Patient patient)
				{
					return patient.Illness == _illness.Instance;
				}
				return false;
			}
			return true;
		}
	}
}
