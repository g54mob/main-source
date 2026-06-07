using UnityEngine;
using UnityEngine.Rendering;

namespace PilotoStudio
{
	[RequireComponent(typeof(ParticleSystem))]
	public class DistortionGrabber : MonoBehaviour
	{
		private static readonly int OpaqueTexID;

		private static readonly int TempTexID;

		private Camera _camera;

		private CommandBuffer _buffer;

		private ParticleSystem _fx;

		private bool _active;

		private void Awake()
		{
		}

		private void LateUpdate()
		{
		}

		private void EnableEffect()
		{
		}

		private void DisableEffect()
		{
		}

		private void OnDisable()
		{
		}
	}
}
