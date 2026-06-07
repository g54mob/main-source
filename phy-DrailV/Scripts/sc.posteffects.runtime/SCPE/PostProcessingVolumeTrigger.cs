using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace SCPE
{
	[ExecuteInEditMode]
	public class PostProcessingVolumeTrigger : MonoBehaviour
	{
		[Header("Target volume")]
		public PostProcessVolume volume;

		[Space]
		public float decreaseSpeed = 1f;

		private float currentWeight;

		private void OnEnable()
		{
			if (volume == null)
			{
				volume = GetComponent<PostProcessVolume>();
				if ((bool)volume)
				{
					volume.weight = 0f;
				}
			}
			else
			{
				volume.weight = 0f;
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			Trigger();
		}

		public void Trigger()
		{
			currentWeight = 1f;
		}

		private void Update()
		{
			currentWeight = Mathf.Clamp01(currentWeight - Time.deltaTime * decreaseSpeed);
			if ((bool)volume)
			{
				volume.weight = currentWeight;
			}
		}
	}
}
