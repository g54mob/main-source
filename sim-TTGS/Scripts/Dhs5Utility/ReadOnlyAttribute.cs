using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
public class ReadOnlyAttribute : PropertyAttribute
{
	public readonly string param;

	public readonly bool inverse;

	public readonly bool canWriteInEditor;

	public readonly bool canWriteAtRuntime;

	public ReadOnlyAttribute(bool canWriteInEditor = false, bool canWriteAtRuntime = false)
	{
		this.canWriteInEditor = canWriteInEditor;
		this.canWriteAtRuntime = canWriteAtRuntime;
	}

	public ReadOnlyAttribute(string param, bool inverse = false)
	{
		this.param = param;
		this.inverse = inverse;
	}
}
