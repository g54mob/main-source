using System;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public class FurnitureFilterElement : AbsFilterElement
	{
		[field: SerializeField]
		public EFurnitureTags EnumTag { get; private set; }

		public override int GetIntTag()
		{
			return (int)EnumTag;
		}
	}
}
