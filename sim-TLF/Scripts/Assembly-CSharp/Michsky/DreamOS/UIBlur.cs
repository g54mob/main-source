using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace Michsky.DreamOS
{
	[ExecuteInEditMode]
	public class UIBlur : MonoBehaviour
	{
		[Header("Resources")]
		public Material blurMaterial;

		[Header("Settings")]
		[Range(0f, 10f)]
		public float blurValue = 5f;

		[Range(0.1f, 50f)]
		public float animationSpeed = 25f;

		public string customProperty = "_Size";

		private float currentBlurValue;

		private void Awake()
		{
			if (!(GraphicsSettings.defaultRenderPipeline != null) && !(blurMaterial == null))
			{
				if (customProperty == null)
				{
					customProperty = "_Size";
				}
				blurMaterial.SetFloat(customProperty, 0f);
			}
		}

		public void BlurInAnim()
		{
			if (!(GraphicsSettings.defaultRenderPipeline != null) && base.gameObject.activeInHierarchy)
			{
				StopCoroutine("BlurOut");
				StopCoroutine("BlurIn");
				StartCoroutine("BlurIn");
			}
		}

		public void BlurOutAnim()
		{
			if (!(GraphicsSettings.defaultRenderPipeline != null) && base.gameObject.activeInHierarchy)
			{
				StopCoroutine("BlurIn");
				StopCoroutine("BlurOut");
				StartCoroutine("BlurOut");
			}
		}

		public void SetBlurValue(float cbv)
		{
			blurValue = cbv;
		}

		private IEnumerator BlurIn()
		{
			currentBlurValue = blurMaterial.GetFloat(customProperty);
			while (currentBlurValue <= blurValue)
			{
				currentBlurValue += Time.deltaTime * animationSpeed;
				if (currentBlurValue >= blurValue)
				{
					currentBlurValue = blurValue;
				}
				blurMaterial.SetFloat(customProperty, currentBlurValue);
				yield return null;
			}
		}

		private IEnumerator BlurOut()
		{
			currentBlurValue = blurMaterial.GetFloat(customProperty);
			while (currentBlurValue >= 0f)
			{
				currentBlurValue -= Time.deltaTime * animationSpeed;
				if (currentBlurValue <= 0f)
				{
					currentBlurValue = 0f;
				}
				blurMaterial.SetFloat(customProperty, currentBlurValue);
				yield return null;
			}
		}
	}
}
