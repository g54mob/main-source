using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class AdditionalMenuItemData : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private string[] menuItems;

		public string[] MenuItems => menuItems;

		public override string GetID()
		{
			return id;
		}
	}
}
