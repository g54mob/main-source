using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK.Highlighters
{
	[AddComponentMenu("VRTK/Scripts/Interactions/Highlighters/VRTK_MaterialPropertyBlockColorSwapHighlighter")]
	public class VRTK_MaterialPropertyBlockColorSwapHighlighter : VRTK_MaterialColorSwapHighlighter
	{
		protected Dictionary<string, MaterialPropertyBlock> originalMaterialPropertyBlocks = new Dictionary<string, MaterialPropertyBlock>();

		protected Dictionary<string, MaterialPropertyBlock> highlightMaterialPropertyBlocks = new Dictionary<string, MaterialPropertyBlock>();

		public override void Initialise(Color? color = null, GameObject affectObject = null, Dictionary<string, object> options = null)
		{
			objectToAffect = ((affectObject != null) ? affectObject : base.gameObject);
			originalMaterialPropertyBlocks.Clear();
			highlightMaterialPropertyBlocks.Clear();
			base.Initialise(color, affectObject, options);
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
				MaterialPropertyBlock dictionaryValue = VRTK_SharedMethods.GetDictionaryValue(originalMaterialPropertyBlocks, key);
				if (dictionaryValue != null)
				{
					renderer.SetPropertyBlock(dictionaryValue);
				}
			}
		}

		protected override void StoreOriginalMaterials()
		{
			originalMaterialPropertyBlocks.Clear();
			highlightMaterialPropertyBlocks.Clear();
			Renderer[] componentsInChildren = objectToAffect.GetComponentsInChildren<Renderer>(includeInactive: true);
			foreach (Renderer obj in componentsInChildren)
			{
				string key = obj.gameObject.GetInstanceID().ToString();
				MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
				obj.GetPropertyBlock(materialPropertyBlock);
				VRTK_SharedMethods.AddDictionaryValue(originalMaterialPropertyBlocks, key, materialPropertyBlock, overwriteExisting: true);
				MaterialPropertyBlock materialPropertyBlock2 = new MaterialPropertyBlock();
				obj.GetPropertyBlock(materialPropertyBlock2);
				VRTK_SharedMethods.AddDictionaryValue(highlightMaterialPropertyBlocks, key, materialPropertyBlock2, overwriteExisting: true);
			}
		}

		protected override void ChangeToHighlightColor(Color color, float duration = 0f)
		{
			Renderer[] componentsInChildren = objectToAffect.GetComponentsInChildren<Renderer>(includeInactive: true);
			foreach (Renderer renderer in componentsInChildren)
			{
				string key = renderer.gameObject.GetInstanceID().ToString();
				if (VRTK_SharedMethods.GetDictionaryValue(originalMaterialPropertyBlocks, key) != null)
				{
					Coroutine dictionaryValue = VRTK_SharedMethods.GetDictionaryValue(faderRoutines, key);
					if (dictionaryValue != null)
					{
						StopCoroutine(dictionaryValue);
						faderRoutines.Remove(key);
					}
					MaterialPropertyBlock materialPropertyBlock = highlightMaterialPropertyBlocks[key];
					renderer.GetPropertyBlock(materialPropertyBlock);
					if (resetMainTexture)
					{
						materialPropertyBlock.SetTexture("_MainTex", Texture2D.whiteTexture);
					}
					if (duration > 0f)
					{
						VRTK_SharedMethods.AddDictionaryValue(faderRoutines, key, StartCoroutine(CycleColor(renderer, materialPropertyBlock, color, duration)), overwriteExisting: true);
						continue;
					}
					materialPropertyBlock.SetColor("_Color", color);
					materialPropertyBlock.SetColor("_EmissionColor", VRTK_SharedMethods.ColorDarken(color, emissionDarken));
					renderer.SetPropertyBlock(materialPropertyBlock);
				}
			}
		}

		protected virtual IEnumerator CycleColor(Renderer renderer, MaterialPropertyBlock highlightMaterialPropertyBlock, Color endColor, float duration)
		{
			float elapsedTime = 0f;
			while (elapsedTime <= duration)
			{
				elapsedTime += Time.deltaTime;
				Color a = highlightMaterialPropertyBlock.GetVector("_Color");
				highlightMaterialPropertyBlock.SetColor("_Color", Color.Lerp(a, endColor, elapsedTime / duration));
				highlightMaterialPropertyBlock.SetColor("_EmissionColor", Color.Lerp(a, endColor, elapsedTime / duration));
				if (!renderer)
				{
					break;
				}
				renderer.SetPropertyBlock(highlightMaterialPropertyBlock);
				yield return null;
			}
		}
	}
}
