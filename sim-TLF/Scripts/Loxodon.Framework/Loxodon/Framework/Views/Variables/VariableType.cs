using System;

namespace Loxodon.Framework.Views.Variables
{
	[Serializable]
	public enum VariableType
	{
		Object = 0,
		GameObject = 1,
		Component = 2,
		Boolean = 3,
		Integer = 4,
		Float = 5,
		String = 6,
		Color = 7,
		Vector2 = 8,
		Vector3 = 9,
		Vector4 = 10
	}
}
