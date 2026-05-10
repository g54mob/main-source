using System;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public class BuildableFilterElement : AbsFilterElement
	{
		[field: SerializeField]
		public BuildableElementSO.EBuildableType EnumTag { get; private set; }

		public override int GetIntTag()
		{
			return (int)EnumTag;
		}
	}
}
