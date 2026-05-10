using System;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public class FurnitureStyleFilterElement : AbsFilterElement
	{
		[field: SerializeField]
		public EBarStyle EnumTag { get; private set; }

		public override int GetIntTag()
		{
			return (int)EnumTag;
		}
	}
}
