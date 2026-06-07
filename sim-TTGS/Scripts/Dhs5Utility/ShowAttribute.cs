using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
public class ShowAttribute : PropertyAttribute
{
	public readonly string param;

	public readonly bool inverse;

	public ShowAttribute(string param, bool inverse = false)
	{
		this.param = param;
		this.inverse = inverse;
	}
}
