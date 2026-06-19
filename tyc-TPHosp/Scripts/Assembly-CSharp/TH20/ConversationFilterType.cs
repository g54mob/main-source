using System;
using UnityEngine;

namespace TH20
{
	[Serializable]
	public class ConversationFilterType : ConversationFilter
	{
		[SerializeField]
		private bool _includeStaff;

		[SerializeField]
		private bool _includePatients;

		public bool IsValid(Character character)
		{
			if (_enabled)
			{
				if (_includeStaff && character is Staff)
				{
					return true;
				}
				if (_includePatients && character is Patient)
				{
					return true;
				}
				return false;
			}
			return true;
		}
	}
}
