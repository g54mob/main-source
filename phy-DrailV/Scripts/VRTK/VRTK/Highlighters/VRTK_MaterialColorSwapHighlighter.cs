using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK.Highlighters
{
	[AddComponentMenu("VRTK/Scripts/Interactions/Highlighters/VRTK_MaterialColorSwapHighlighter")]
	public class VRTK_MaterialColorSwapHighlighter : VRTK_BaseHighlighter
	{
		[Tooltip("The emission colour of the texture will be the highlight colour but this percent darker.")]
		public float emissionDarken = 50f;

		[Tooltip("A custom material to use on the highlighted object.")]
		public Material customMaterial;

		protected Dictionary<string, Material[]> originalSharedRendererMaterials = new Dictionary<string, Material[]>();

		protected Dictionary<string, Material[]> originalRendererMaterials = new Dictionary<string, Material[]>();

		protected Dictionary<string, Coroutine> faderRoutines = new Dictionary<string, Coroutine>();

		protected bool resetMainTexture;

		public override void Initialise(Color? color = null, GameObject affectObject = null, Dictionary<string, object> options = null)
		{
			objectToAffect = ((affectObject != null) ? affectObject : base.gameObject);
			originalSharedRendererMaterials.Clear();
			originalRendererMaterials.Clear();
			faderRoutines.Clear();
			resetMainTexture = GetOption<bool>(options, "resetMainTexture");
			ResetHighlighter();
		}

		public override void ResetHighlighter()
		{
			StoreOriginalMaterials();
		}

		public override void Highlight(Color? color, float duration = 0f)
		{
			if (color.HasValue)
			{
				ChangeToHighlightColor(color.Value, duration);
			}
		}

		public override void Unhighlight(Color? color = null, float duration = 0f)
		{
			if (objectToAffect == null)
			{
				return;
			}
			if (faderRoutines != null)
			{
				foreach (KeyValuePair<string, Coroutine> faderRoutine in faderRoutines)
				{
					StopCoroutine(faderRoutine.Value);
				}
				faderRoutines.Clear();
			}
			Renderer[] componentsInChildren = objectToAffect.GetComponentsInChildren<Renderer>(includeInactive: true);
			foreach (Renderer renderer in componentsInChildren)
			{
				string key = renderer.gameObject.GetInstanceID().ToString();
				Material[] dictionaryValue = VRTK_SharedMethods.GetDictionaryValue(originalRendererMaterials, key);
				if (dictionaryValue != null)
				{
					Material[] dictionaryValue2 = VRTK_SharedMethods.GetDictionaryValue(originalSharedRendererMaterials, key);
					if (dictionaryValue2 != null)
					{
						renderer.materials = dictionaryValue;
						renderer.sharedMaterials = dictionaryValue2;
					}
				}
			}
		}

		protected virtual void StoreOriginalMaterials()
		{
			originalSharedRendererMaterials.Clear();
			originalRendererMaterials.Clear();
			Renderer[] componentsInChildren = objectToAffect.GetComponentsInChildren<Renderer>(includeInactive: true);
			foreach (Renderer renderer in componentsInChildren)
			{
				string key = renderer.gameObject.GetInstanceID().ToString();
				VRTK_SharedMethods.AddDictionaryValue(originalSharedRendererMaterials, key, renderer.sharedMaterials, overwriteExisting: true);
				VRTK_SharedMethods.AddDictionaryValue(originalRendererMaterials, key, renderer.materials, overwriteExisting: true);
				renderer.sharedMaterials = VRTK_SharedMethods.GetDictionaryValue(originalSharedRendererMaterials, key);
			}
		}

		protected virtual void ChangeToHighlightColor(Color color, float duration = 0f)
		{
			Renderer[] componentsInChildren = objectToAffect.GetComponentsInChildren<Renderer>(includeInactive: true);
			foreach (Renderer renderer in componentsInChildren)
			{
				Material[] array = new Material[renderer.materials.Length];
				for (int j = 0; j < renderer.materials.Length; j++)
				{
					Material material = renderer.materials[j];
					if (customMaterial != null)
					{
						material = (array[j] = customMaterial);
					}
					string key = material.GetInstanceID().ToString();
					Coroutine dictionaryValue = VRTK_SharedMethods.GetDictionaryValue(faderRoutines, key);
					if (dictionaryValue != null)
					{
						StopCoroutine(dictionaryValue);
						faderRoutines.Remove(key);
					}
					material.EnableKeyword("_EMISSION");
					if (resetMainTexture && material.HasProperty("_MainTex"))
					{
						renderer.material.SetTexture("_MainTex", Texture2D.whiteTexture);
					}
					if (!material.HasProperty("_Color"))
					{
						continue;
					}
					if (duration > 0f)
					{
						VRTK_SharedMethods.AddDictionaryValue(faderRoutines, key, StartCoroutine(CycleColor(material, material.color, color, duration)), overwriteExisting: true);
						continue;
					}
					material.color = color;
					if (material.HasProperty("_EmissionColor"))
					{
						material.SetColor("_EmissionColor", VRTK_SharedMethods.ColorDarken(color, emissionDarken));
					}
				}
				if (customMaterial != null)
				{
					renderer.materials = array;
				}
			}
		}

		protected virtual IEnumerator CycleColor(Material material, Color startColor, Color endColor, float duration)
		{
			float elapsedTime = 0f;
			while (elapsedTime <= duration)
			{
				elapsedTime += Time.deltaTime;
				if (material.HasProperty("_Color"))
				{
					material.color = Color.Lerp(startColor, endColor, elapsedTime / duration);
				}
				if (material.HasProperty("_EmissionColor"))
				{
					material.SetColor("_EmissionColor", Color.Lerp(startColor, VRTK_SharedMethods.ColorDarken(endColor, emissionDarken), elapsedTime / duration));
				}
				yield return null;
			}
		}
	}
}
