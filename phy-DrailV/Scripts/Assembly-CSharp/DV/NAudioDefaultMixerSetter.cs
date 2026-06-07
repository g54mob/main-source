using DV.Utils;
using UnityEngine;
using UnityEngine.Audio;

namespace DV
{
	[ExecutionOrder(-10000)]
	public class NAudioDefaultMixerSetter : MonoBehaviour
	{
		public AudioMixerGroup default2DMixer;

		public AudioMixerGroup default3DMixer;

		private void Awake()
		{
			NAudio.Default2DMixerGroup = default2DMixer;
			NAudio.Default3DMixerGroup = default3DMixer;
		}
	}
}
