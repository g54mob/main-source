using UnityEngine;

namespace Dreamteck.Splines
{
	public class ObjectControllerCustomRuleBase : ScriptableObject
	{
		protected ObjectController currentController;

		protected SplineSample currentSample;

		protected int currentObjectIndex;

		protected int totalObjects;

		protected float currentObjectPercent => 0f;

		public void SetContext(ObjectController context, SplineSample sample, int currentObject, int totalObjects)
		{
		}

		public virtual Vector3 GetOffset()
		{
			return default(Vector3);
		}

		public virtual Quaternion GetRotation()
		{
			return default(Quaternion);
		}

		public virtual Vector3 GetScale()
		{
			return default(Vector3);
		}
	}
}
