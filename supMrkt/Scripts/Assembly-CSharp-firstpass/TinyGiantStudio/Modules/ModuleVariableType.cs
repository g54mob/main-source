using System;

namespace TinyGiantStudio.Modules
{
	[Serializable]
	public enum ModuleVariableType
	{
		@float = 0,
		@int = 1,
		@bool = 2,
		@string = 3,
		vector2 = 4,
		vector3 = 5,
		animationCurve = 6,
		gameObject = 7,
		physicMaterial = 8
	}
}
