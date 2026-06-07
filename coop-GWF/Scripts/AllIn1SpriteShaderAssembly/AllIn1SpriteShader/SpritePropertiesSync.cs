using UnityEngine;
using UnityEngine.Rendering;

namespace AllIn1SpriteShader
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(SpriteRenderer))]
	public class SpritePropertiesSync : MonoBehaviour
	{
		public enum CastShadowMode
		{
			[InspectorName("Off")]
			OFF = 0,
			[InspectorName("One Sided")]
			ONE_SIDED = 1,
			[InspectorName("Two Sided")]
			TWO_SIDED = 2
		}

		private static int PROPID_SPRITE_FLIP = Shader.PropertyToID("_SpriteFlip");

		public SpriteRenderer spr;

		public bool isMaterialDrivenByAnimator;

		[SerializeField]
		private CastShadowMode shadowCastingMode = CastShadowMode.TWO_SIDED;

		private MaterialPropertyBlock matPropBlock;

		public void Start()
		{
			if (spr == null)
			{
				spr = GetComponent<SpriteRenderer>();
			}
			if (spr == null)
			{
				Debug.LogWarning("Sprite Renderer is null in SpritePropertiesSync-" + base.gameObject.name, base.gameObject);
				base.enabled = false;
			}
			else
			{
				matPropBlock = new MaterialPropertyBlock();
				UpdateRendererShadowCastingMode();
			}
		}

		private void LateUpdate()
		{
			if (spr == null || spr.sharedMaterial == null)
			{
				Debug.LogError("Incorrect setup in SpritePropertiesSync-" + base.gameObject.name, base.gameObject);
				base.enabled = false;
			}
			else
			{
				UpdateMaterial();
			}
		}

		private void UpdateRendererShadowCastingMode()
		{
			switch (shadowCastingMode)
			{
			case CastShadowMode.OFF:
				spr.shadowCastingMode = ShadowCastingMode.Off;
				break;
			case CastShadowMode.ONE_SIDED:
				spr.shadowCastingMode = ShadowCastingMode.On;
				break;
			case CastShadowMode.TWO_SIDED:
				spr.shadowCastingMode = ShadowCastingMode.TwoSided;
				break;
			}
		}

		private void UpdateMaterial()
		{
			spr.GetPropertyBlock(matPropBlock);
			float num = (spr.flipX ? (-1f) : 1f);
			float num2 = (spr.flipY ? (-1f) : 1f);
			Vector3 localScale = spr.transform.localScale;
			float z = Mathf.Sign(localScale.x * localScale.y * localScale.z * num * num2);
			Vector4 value = new Vector4(num, num2, num, num2);
			if (Application.isPlaying && isMaterialDrivenByAnimator)
			{
				value.x = 1f;
				value.y = 1f;
			}
			value.z = z;
			matPropBlock.SetVector(PROPID_SPRITE_FLIP, value);
			spr.SetPropertyBlock(matPropBlock);
		}
	}
}
