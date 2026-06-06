using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class DrifterAttributeModifier
{
	[SerializeField]
	[FormerlySerializedAs("_type")]
	public DrifterAttributes.AttributeType Type = DrifterAttributes.AttributeType.Construction;

	[SerializeField]
	[FormerlySerializedAs("_modifier")]
	public int Modifier;

	public int Affinity;

	public override string ToString()
	{
		string text = "";
		if (Modifier > 0)
		{
			text += "+";
		}
		return text + Modifier;
	}
}
