using System;
using CTS.UI;
using UnityEngine;

[Serializable]
public class DestructionFilterElement : AbsFilterElement
{
	[field: SerializeField]
	public EDestructionMode EnumTag { get; private set; }

	public override int GetIntTag()
	{
		return (int)EnumTag;
	}
}
