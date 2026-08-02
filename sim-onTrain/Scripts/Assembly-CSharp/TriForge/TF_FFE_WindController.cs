using UnityEngine;

namespace TriForge
{
	[ExecuteInEditMode]
	public class TF_FFE_WindController : MonoBehaviour
	{
		[Range(0f, 1f)]
		public float WindStrength = 0.35f;

		[Range(0f, 3f)]
		public float LeafFlutterStrength = 1f;

		[Range(0f, 3f)]
		public float WindSpeed = 1f;

		public Texture2D WindMask;

		private Vector3 WindDirection;

		private void Start()
		{
			Shader.SetGlobalTexture("FFE_Wind_Mask", WindMask);
		}

		private void Update()
		{
			Shader.SetGlobalFloat("FFE_Wind_Strength", WindStrength);
			Shader.SetGlobalFloat("FFE_Leaf_Flutter", LeafFlutterStrength);
			Shader.SetGlobalFloat("FFE_Wind_Speed", WindSpeed);
			WindDirection = base.transform.right;
			Shader.SetGlobalVector("FFE_Wind_Direction", WindDirection);
		}
	}
}
