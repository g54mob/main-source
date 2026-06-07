using System;
using UnityEngine;

namespace TinyGiantStudio.Modules
{
	[Serializable]
	public class VariableHolder
	{
		public string variableName;

		public ModuleVariableType type;

		public float floatValue;

		public int intValue;

		public bool boolValue;

		public string stringValue;

		public Vector2 vector2Value;

		public Vector3 vector3Value;

		public AnimationCurve animationCurve;

		public GameObject gameObjectValue;

		public PhysicsMaterial physicMaterialValue;

		public string hideIf;

		public string tooltip;
	}
}
