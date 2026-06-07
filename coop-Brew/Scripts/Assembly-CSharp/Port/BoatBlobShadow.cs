using UnityEngine;

namespace Port
{
	public class BoatBlobShadow : MonoBehaviour
	{
		[Header("Shadow Settings")]
		[Tooltip("Shadow size (X = width, Y = length)")]
		[SerializeField]
		private Vector2 shadowSize;

		[Tooltip("Shadow color")]
		[SerializeField]
		private Color shadowColor;

		[Tooltip("Height offset above water surface")]
		[SerializeField]
		private float waterOffset;

		[Tooltip("Fixed Y position of the water surface (set to your water plane height)")]
		[SerializeField]
		private float waterHeight;

		[Tooltip("Auto-detect water height from boat's starting Y position")]
		[SerializeField]
		private bool autoDetectWaterHeight;

		[Header("Softness")]
		[Tooltip("How soft/faded the shadow edges are (0 = hard circle, higher = softer)")]
		[SerializeField]
		[Range(0f, 1f)]
		private float edgeSoftness;

		[Header("Debug")]
		[Tooltip("Enable to tweak values in realtime. Disable for performance.")]
		[SerializeField]
		private bool realtimePreview;

		private GameObject shadowQuad;

		private Material shadowMaterial;

		private Texture2D shadowTexture;

		private Vector2 prevSize;

		private Color prevColor;

		private float prevSoftness;

		private float prevWaterOffset;

		private float prevWaterHeight;

		private void Start()
		{
		}

		private void LateUpdate()
		{
		}

		private bool ValuesChanged()
		{
			return false;
		}

		private void CacheValues()
		{
		}

		private void UpdateShadow()
		{
		}

		private void CreateShadow()
		{
		}

		private void RegenerateTexture()
		{
		}

		private Material CreateShadowMaterial()
		{
			return null;
		}

		private void OnDestroy()
		{
		}
	}
}
