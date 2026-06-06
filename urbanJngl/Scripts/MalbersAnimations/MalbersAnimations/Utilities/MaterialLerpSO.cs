using System.Collections;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[CreateAssetMenu(menuName = "Malbers Animations/Extras/Material Lerp", order = 2100)]
	public class MaterialLerpSO : ScriptableCoroutine
	{
		[Tooltip("Next material to lerp to")]
		public Material ToMaterial;

		[Tooltip("Index of the Material")]
		public int materialIndex;

		[Tooltip("Time to lerp the materials")]
		public FloatReference time = new FloatReference(1f);

		[Tooltip("Curve to apply to the lerping")]
		public AnimationCurve curve = new AnimationCurve(MTools.DefaultCurve);

		public virtual void Lerp(Renderer mesh)
		{
			Stop(mesh);
			StartCoroutine(mesh, Lerper(mesh, time, curve));
		}

		public void Lerp(Component go)
		{
			Lerp(go.gameObject);
		}

		public void Lerp(GameObject go)
		{
			SkinnedMeshRenderer[] componentsInChildren = go.transform.root.GetComponentsInChildren<SkinnedMeshRenderer>();
			MeshRenderer[] componentsInChildren2 = go.transform.root.GetComponentsInChildren<MeshRenderer>();
			SkinnedMeshRenderer[] array = componentsInChildren;
			foreach (SkinnedMeshRenderer mesh in array)
			{
				Lerp(mesh);
			}
			MeshRenderer[] array2 = componentsInChildren2;
			foreach (MeshRenderer mesh2 in array2)
			{
				Lerp(mesh2);
			}
		}

		public virtual void LerpForever(Renderer mesh)
		{
			StartCoroutine(mesh, LerperForever(mesh));
		}

		internal override void Evaluate(MonoBehaviour mono, Transform target, float time, AnimationCurve curve)
		{
			mono.StartCoroutine(Lerper(target.GetComponent<Renderer>(), time, curve));
		}

		private IEnumerator Lerper(Renderer mesh, float time, AnimationCurve curve)
		{
			float elapsedTime = 0f;
			Material rendererMaterial = mesh.sharedMaterials[materialIndex];
			while (elapsedTime <= time)
			{
				float t = curve.Evaluate(elapsedTime / time);
				mesh.material.Lerp(rendererMaterial, ToMaterial, t);
				elapsedTime += Time.deltaTime;
				yield return null;
			}
			mesh.material.Lerp(rendererMaterial, ToMaterial, curve.Evaluate(curve.keys[curve.keys.Length - 1].time));
			yield return null;
			Stop(mesh);
		}

		private IEnumerator LerperForever(Renderer mesh)
		{
			float elapsedTime = 0f;
			Material rendererMaterial = mesh.sharedMaterials[materialIndex];
			while (true)
			{
				float t = curve.Evaluate(elapsedTime / (float)time % 1f);
				mesh.material.Lerp(rendererMaterial, ToMaterial, t);
				elapsedTime += Time.deltaTime;
				yield return null;
			}
		}
	}
}
