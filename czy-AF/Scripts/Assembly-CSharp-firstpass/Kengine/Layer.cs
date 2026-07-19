using UnityEngine;

namespace Kengine
{
	[AddComponentMenu("Kengine/Modifier/Track")]
	public class Layer : MonoBehaviour
	{
		[Header("Layers")]
		[Range(0f, 1f)]
		public float index;

		public bool changePitch;

		public AudioSegment[] audioSegments;

		private void Update()
		{
			_ = audioSegments.Length;
			AudioSegment[] array = audioSegments;
			foreach (AudioSegment audioSegment in array)
			{
				Color color = audioSegment.audioGradient.Evaluate(index);
				audioSegment.audioSource.volume = color.a;
				if (changePitch)
				{
					audioSegment.audioSource.pitch = 0.45f + (color.a + index / 2f);
				}
			}
		}
	}
}
