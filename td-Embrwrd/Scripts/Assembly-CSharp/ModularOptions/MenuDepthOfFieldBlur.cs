using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace ModularOptions
{
	[AddComponentMenu("Modular Options/Misc/Menu Depth Of Field Blur")]
	public sealed class MenuDepthOfFieldBlur : MonoBehaviour
	{
		[Tooltip("Reference to global baseline profile.")]
		public VolumeProfile postProcessingProfile;

		[Range(0.01f, 9f)]
		public float focusDistance;

		private DepthOfField dof;

		private float normalFocusDistance;

		private bool dofActive;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}
	}
}
