using System;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public class DrawModeFilterElement : AbsFilterElement
	{
		[field: SerializeField]
		public ESurfacePaintingMode EnumTag { get; private set; }

		public override int GetIntTag()
		{
			return (int)EnumTag;
		}
	}
}
