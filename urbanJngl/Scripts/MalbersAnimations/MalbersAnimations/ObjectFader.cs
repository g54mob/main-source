using System.Collections;
using System.Collections.Generic;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	public class ObjectFader : MonoBehaviour
	{
		[Tooltip("The transform of the player character. Don't place the Transform too low, otherwise the ground will eventually be effected. Use the head instead.")]
		[SerializeField]
		private TransformVar player;

		[Tooltip("The layer(s) that can obstruct the view of the player.")]
		[SerializeField]
		private LayerMask obstructionLayer;

		[Tooltip("The duration over which the fade effect occurs.")]
		[SerializeField]
		private float fadeDuration = 0.5f;

		[Range(0f, 1f)]
		[Tooltip("The target alpha value for faded objects. Should be between 0 (completely transparent) and 1 (completely opaque).")]
		[SerializeField]
		private float fadeAmount = 0.5f;

		private Dictionary<Renderer, Coroutine> fadeCoroutines = new Dictionary<Renderer, Coroutine>();

		private void Update()
		{
			CheckForObstructions();
		}

		private void CheckForObstructions()
		{
			List<Renderer> list = new List<Renderer>();
			Vector3 direction = player.Value.position - Camera.main.transform.position;
			float maxDistance = Vector3.Distance(Camera.main.transform.position, player.Value.position);
			RaycastHit[] array = Physics.RaycastAll(Camera.main.transform.position, direction, maxDistance, obstructionLayer);
			foreach (RaycastHit raycastHit in array)
			{
				Renderer component = raycastHit.collider.GetComponent<Renderer>();
				if (component != null)
				{
					list.Add(component);
					if (!fadeCoroutines.ContainsKey(component) || fadeCoroutines[component] == null)
					{
						fadeCoroutines[component] = StartCoroutine(FadeTo(component, fadeAmount, fadeDuration));
					}
				}
			}
			foreach (Renderer item in new List<Renderer>(fadeCoroutines.Keys))
			{
				if (!list.Contains(item))
				{
					if (fadeCoroutines[item] != null)
					{
						StopCoroutine(fadeCoroutines[item]);
					}
					fadeCoroutines[item] = StartCoroutine(FadeTo(item, 1f, fadeDuration));
				}
			}
		}

		private IEnumerator FadeTo(Renderer renderer, float targetAlpha, float duration)
		{
			List<Material> materials = new List<Material>(renderer.materials);
			List<float> startAlphas = new List<float>();
			foreach (Material item in materials)
			{
				startAlphas.Add(item.color.a);
			}
			float elapsed = 0f;
			while (elapsed < duration)
			{
				elapsed += Time.deltaTime;
				float a = Mathf.Lerp(startAlphas[0], targetAlpha, elapsed / duration);
				foreach (Material item2 in materials)
				{
					Color color = item2.color;
					color.a = a;
					item2.color = color;
					item2.SetInt("_SrcBlend", 5);
					item2.SetInt("_DstBlend", 10);
					item2.SetInt("_ZWrite", 0);
					item2.DisableKeyword("_ALPHATEST_ON");
					item2.EnableKeyword("_ALPHABLEND_ON");
					item2.DisableKeyword("_ALPHAPREMULTIPLY_ON");
					item2.renderQueue = 3000;
				}
				yield return null;
			}
			foreach (Material item3 in materials)
			{
				Color color2 = item3.color;
				color2.a = targetAlpha;
				item3.color = color2;
			}
			fadeCoroutines[renderer] = null;
		}
	}
}
