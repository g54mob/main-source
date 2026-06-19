using UnityEngine;

namespace MyBox
{
	public class StateOnAwake : MonoBehaviour
	{
		public bool Active;

		public GameObject TargetObject;

		public Renderer TargetComponent;

		private void Awake()
		{
			if (TargetObject != null)
			{
				TargetObject.SetActive(Active);
			}
			if (TargetComponent != null)
			{
				TargetComponent.enabled = Active;
			}
		}
	}
}
