using System;
using UnityEngine;

[Serializable]
public class AttributeContainer
{
	[SerializeReference]
	public object Value;

	public AttributeContainer(object value)
	{
	}
}
