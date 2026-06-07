using System;
using System.Collections;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[CreateAssetMenu(menuName = "Malbers Animations/Extras/Material Property Lerp", order = 2100)]
	public class MaterialPropertyLerpSO : ScriptableCoroutine
	{
		[Tooltip("Index of the Material")]
		public IntReference materialIndex = new IntReference();

		public FloatReference time = new FloatReference(1f);

		public AnimationCurve curve = new AnimationCurve(MTools.DefaultCurve);

		public StringReference propertyName;

		public MaterialPropertyType propertyType;

		public FloatReference FloatValue = new FloatReference(1f);

		public Color ColorValue = Color.white;

		[ColorUsage(true, true)]
		public Color ColorHDRValue = Color.white;

		public FloatReference StartMultiplier = new FloatReference(1f);

		[Tooltip("Clear the Emission Map while Lerp")]
		public bool clearEmissionMap;

		[Tooltip("Revert the Emission Map Color after Lerp")]
		public bool revertColorAfterLerp;

		private Texture cachedEmissionMap;

		public void LerpMaterial(Component go)
		{
			LerpMaterial(go.gameObject);
		}

		public void LerpMaterial(GameObject go)
		{
			IObjectCore componentInParent = go.GetComponentInParent<IObjectCore>();
			if (componentInParent != null)
			{
				go = componentInParent.transform.gameObject;
			}
			SkinnedMeshRenderer[] componentsInChildren = go.GetComponentsInChildren<SkinnedMeshRenderer>();
			MeshRenderer[] componentsInChildren2 = go.GetComponentsInChildren<MeshRenderer>();
			SkinnedMeshRenderer[] array = componentsInChildren;
			foreach (SkinnedMeshRenderer mesh in array)
			{
				LerpMaterial(mesh);
			}
			MeshRenderer[] array2 = componentsInChildren2;
			foreach (MeshRenderer mesh2 in array2)
			{
				LerpMaterial(mesh2);
			}
		}

		internal override void Evaluate(MonoBehaviour mono, Transform target, float time, AnimationCurve curve = null)
		{
			MeshRenderer component = target.GetComponent<MeshRenderer>();
			AnimationCurve animationCurve = curve ?? this.curve;
			switch (propertyType)
			{
			case MaterialPropertyType.Float:
				mono.StartCoroutine(LerperFloat(component, time, animationCurve));
				break;
			case MaterialPropertyType.Color:
				mono.StartCoroutine(LerperColor(component, ColorValue, time, animationCurve));
				break;
			case MaterialPropertyType.HDRColor:
				mono.StartCoroutine(LerperColor(component, ColorHDRValue, time, animationCurve));
				break;
			}
		}

		[Obsolete("Lerp is Obsolete, use LerpMaterial(Renderer) instead")]
		public virtual void Lerp(Renderer mesh)
		{
			LerpMaterial(mesh);
		}

		public virtual void LerpMaterial(Renderer mesh)
		{
			if (!mesh)
			{
				return;
			}
			if (!mesh.material.HasProperty(propertyName))
			{
				Debug.Log("The Material [" + mesh.material.name + "]  doesn't have the property [" + propertyName.Value + "]");
				return;
			}
			IEnumerator iCoroutine = null;
			switch (propertyType)
			{
			case MaterialPropertyType.Float:
				iCoroutine = LerperFloat(mesh, time, curve);
				break;
			case MaterialPropertyType.Color:
				iCoroutine = LerperColor(mesh, ColorValue, time, curve);
				break;
			case MaterialPropertyType.HDRColor:
				iCoroutine = LerperColor(mesh, ColorHDRValue, time, curve);
				break;
			}
			StartCoroutine(mesh, iCoroutine);
		}

		private IEnumerator LerperFloat(Renderer mesh, float time, AnimationCurve curve)
		{
			float elapsedTime = 0f;
			Material mat = mesh.materials[(int)materialIndex];
			while (elapsedTime <= time)
			{
				float num = curve.Evaluate(elapsedTime / time);
				mat.SetFloat(propertyName, num * (float)FloatValue);
				Debug.Log("value = " + num);
				elapsedTime += Time.deltaTime;
				yield return null;
			}
			mat.SetFloat(propertyName, curve.Evaluate(curve.keys[curve.keys.Length - 1].time));
			yield return null;
			Stop(mesh);
		}

		private IEnumerator LerperColor(Renderer mesh, Color FinalColor, float time, AnimationCurve curve)
		{
			float elapsedTime = 0f;
			Material mat = mesh.materials[(int)materialIndex];
			if (!mat.HasProperty(propertyName))
			{
				Debug.LogWarning("The Material [" + mat.name + "]  doesn't have the property [" + propertyName.Value + "] ");
				yield break;
			}
			Color OriginalColor = mat.GetColor(propertyName);
			Color StartingColor = OriginalColor * StartMultiplier;
			if (clearEmissionMap)
			{
				cachedEmissionMap = mat.GetTexture("_EmissionMap");
			}
			if (time > 0f)
			{
				while (elapsedTime <= time)
				{
					float t = curve.Evaluate(elapsedTime / time);
					Color value = Color.LerpUnclamped(StartingColor, FinalColor, t);
					if (clearEmissionMap)
					{
						mat.SetTexture("_EmissionMap", null);
					}
					mat.SetColor(propertyName, value);
					elapsedTime += Time.deltaTime;
					yield return null;
				}
			}
			mat.SetColor(value: (!revertColorAfterLerp) ? Color.LerpUnclamped(StartingColor, FinalColor, curve.Evaluate(1f)) : OriginalColor, name: propertyName);
			if (clearEmissionMap)
			{
				mat.SetTexture("_EmissionMap", cachedEmissionMap);
			}
			yield return null;
			Stop(mesh);
		}
	}
}
