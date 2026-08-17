using System;

namespace Coherence;

[Serializable]
public struct Field
{
	public enum Type
	{
		Axis2D,
		Button,
		Axis,
		String,
		Axis3D,
		Rotation,
		Integer
	}

	public string name;

	public Type type;
}
