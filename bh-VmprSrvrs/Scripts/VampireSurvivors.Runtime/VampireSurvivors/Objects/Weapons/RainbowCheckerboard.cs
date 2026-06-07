using UnityEngine;

namespace VampireSurvivors.Objects.Weapons
{
	[DefaultExecutionOrder(960)]
	public class RainbowCheckerboard : GameMonoBehaviour
	{
		public float alpha;

		private bool _initialised;

		private Transform _cachedTransform;

		private Camera _mainCam;

		private Material _shaderRTMaterial;

		[SerializeField]
		private Mesh _quadMesh;

		[SerializeField]
		private RenderTexture _renderTexture;

		[SerializeField]
		private MeshRenderer _shaderMesh;

		[SerializeField]
		private MeshRenderer _blitRenderer;

		private float _angle;

		private void Start()
		{
		}

		private void Initialise()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected void LateUpdate()
		{
		}

		private void UpdateShader()
		{
		}
	}
}
