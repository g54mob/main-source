using System;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public class ConstructionModeFilterElement : AbsFilterElement
	{
		[field: SerializeField]
		public EConstructionMode EnumTag { get; private set; }

		public override int GetIntTag()
		{
			return (int)EnumTag;
		}
	}
}
