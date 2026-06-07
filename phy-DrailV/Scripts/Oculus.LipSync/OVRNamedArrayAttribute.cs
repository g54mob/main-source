using UnityEngine;

public class OVRNamedArrayAttribute : PropertyAttribute
{
	public readonly string[] names;

	public OVRNamedArrayAttribute(string[] names)
	{
		this.names = names;
	}
}
