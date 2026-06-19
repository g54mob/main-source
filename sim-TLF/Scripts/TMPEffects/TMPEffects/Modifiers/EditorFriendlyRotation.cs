using System;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.Modifiers
{
	[Serializable]
	public class EditorFriendlyRotation
	{
		public Vector3 eulerAngles = Vector3.zero;

		public TMPParameterTypes.TypedVector3 pivot = new TMPParameterTypes.TypedVector3(TMPParameterTypes.VectorType.Offset, Vector3.zero);

		public EditorFriendlyRotation()
		{
		}

		public EditorFriendlyRotation(Vector3 eulerAngles, TMPParameterTypes.TypedVector3 pivot)
		{
			this.eulerAngles = eulerAngles;
			this.pivot = pivot;
		}
	}
}
