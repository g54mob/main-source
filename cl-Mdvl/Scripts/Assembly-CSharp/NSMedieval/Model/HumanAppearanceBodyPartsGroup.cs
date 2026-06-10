using System;
using System.Collections.Generic;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class HumanAppearanceBodyPartsGroup
	{
		[SerializeField]
		private string groupName;

		[SerializeField]
		private List<string> allowedItems;

		public string GroupName => groupName;

		public List<string> AllowedItems => allowedItems;
	}
}
