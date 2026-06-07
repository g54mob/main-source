using UnityEngine;

namespace Dreamteck.Splines
{
	public class ObjectControllerCustomRuleBase : ScriptableObject
	{
		protected ObjectController currentController;

		protected SplineSample currentSample;

		protected int currentObjectIndex;

		protected int totalObjects;

		protected float currentObjectPercent => (float)currentObjectIndex / (float)(totalObjects - 1);

		public void SetContext(ObjectController context, SplineSample sample, int currentObject, int totalObjects)
		{
			currentController = context;
			currentSample = sample;
			currentObjectIndex = currentObject;
			this.totalObjects = totalObjects;
		}

		public virtual Vector3 GetOffset()
		{
			return currentSample.position;
		}

		public virtual Quaternion GetRotation()
		{
			return currentSample.rotation;
		}

		public virtual Vector3 GetScale()
		{
			return Vector3.one * currentSample.size;
		}
	}
}
