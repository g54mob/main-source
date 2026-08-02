using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace BloodEffectsPack
{
	public class ProjectorPrioritySetter_URP : MonoBehaviour
	{
		private int priority;

		private void OnEnable()
		{
			SetPriority();
		}

		private void Update()
		{
		}

		public void SetPriority()
		{
			DecalProjector component = GetComponent<DecalProjector>();
			if (component == null)
			{
				Debug.LogError("No DecalProjector component found on this GameObject.");
				return;
			}
			float time = Time.time;
			priority = Mathf.RoundToInt(time / 0.25f % 101f) - 50;
			component.material.SetFloat("_DrawOrder", priority);
		}
	}
}
