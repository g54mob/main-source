using System;
using UnityEngine;

namespace TH20
{
	[Serializable]
	public class ConversationFilterStaffType : ConversationFilter
	{
		[SerializeField]
		private StaffDefinition.Type _type;

		public bool IsValid(Character character)
		{
			if (_enabled)
			{
				if (character is Staff staff)
				{
					return staff.Definition._type == _type;
				}
				return false;
			}
			return true;
		}
	}
}
