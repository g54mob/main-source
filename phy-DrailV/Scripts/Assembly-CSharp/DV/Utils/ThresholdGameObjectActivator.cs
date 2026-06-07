using System;
using UnityEngine;

namespace DV.Utils
{
	public class ThresholdGameObjectActivator : MonoBehaviour
	{
		[Serializable]
		public class ThresholdActivityDefinition
		{
			public GameObject targetObject;

			public float thresholdMin;

			public float thresholdMax;
		}

		[SerializeField]
		private ThresholdActivityDefinition[] objectsToToggle;

		private void Awake()
		{
			if (objectsToToggle == null || objectsToToggle.Length == 0)
			{
				Debug.LogError("Unexpected state: objectsToToggle not properly set. Destroying self!");
				UnityEngine.Object.Destroy(this);
			}
		}

		public void UpdateActiveStates(float value)
		{
			ThresholdActivityDefinition[] array = objectsToToggle;
			foreach (ThresholdActivityDefinition thresholdActivityDefinition in array)
			{
				if (!(thresholdActivityDefinition.targetObject == null))
				{
					bool active = value >= thresholdActivityDefinition.thresholdMin && value <= thresholdActivityDefinition.thresholdMax;
					thresholdActivityDefinition.targetObject.SetActive(active);
				}
			}
		}
	}
}
