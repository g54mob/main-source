using System;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.Modifiers
{
	[Serializable]
	public class EditorFriendlyRotation
	{
		public Vector3 eulerAngles;

		public TMPParameterTypes.TypedVector3 pivot;

		public EditorFriendlyRotation()
		{
		}

		public EditorFriendlyRotation(Vector3 eulerAngles, TMPParameterTypes.TypedVector3 pivot)
		{
		}
	}
}
