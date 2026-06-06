using System.Collections;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[CreateAssetMenu(menuName = "Malbers Animations/Preset/BlendShape", order = 200)]
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/utilities/blend-shapes/blend-shape-preset")]
	public class BlendShapePreset : ScriptableCoroutine
	{
		[Header("Smooth BlendShapes")]
		public FloatReference BlendTime = new FloatReference(1.5f);

		public AnimationCurve BlendCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		[Space]
		[Header("Blend Shapes Weights")]
		public float[] blendShapes;

		public void Load(SkinnedMeshRenderer mesh)
		{
			int num = Mathf.Min(mesh.sharedMesh.blendShapeCount, blendShapes.Length);
			for (int i = 0; i < num; i++)
			{
				mesh.SetBlendShapeWeight(i, blendShapes[i]);
			}
		}

		public virtual void SmoothBlend(SkinnedMeshRenderer mesh)
		{
			StartCoroutine(mesh, C_SmoothBlend(mesh, BlendTime, BlendCurve));
		}

		internal override void Evaluate(MonoBehaviour mono, Transform target, float time, AnimationCurve curve = null)
		{
			mono.StartCoroutine(C_SmoothBlend(target.GetComponent<SkinnedMeshRenderer>(), time, curve));
		}

		protected IEnumerator C_SmoothBlend(SkinnedMeshRenderer mesh, float BlendTime, AnimationCurve BlendCurve)
		{
			float elapsedTime = 0f;
			int Length = Mathf.Min(mesh.sharedMesh.blendShapeCount, blendShapes.Length, blendShapes.Length);
			float[] StartBlends = new float[mesh.sharedMesh.blendShapeCount];
			int num = 0;
			for (int i = 0; i < Length; i++)
			{
				StartBlends[i] = mesh.GetBlendShapeWeight(i);
				if (StartBlends[i] == blendShapes[i])
				{
					num++;
				}
			}
			if (num == Length)
			{
				Debug.Log("Loading same BlendShape preset. Ignore");
				yield return null;
				Stop(mesh);
				yield break;
			}
			while (BlendTime > 0f && elapsedTime <= BlendTime)
			{
				float t = BlendCurve.Evaluate(elapsedTime / BlendTime);
				for (int j = 0; j < Length; j++)
				{
					float value = Mathf.Lerp(StartBlends[j], blendShapes[j], t);
					mesh.SetBlendShapeWeight(j, value);
				}
				elapsedTime += Time.deltaTime;
				yield return null;
			}
			Load(mesh);
			BlendShape blendShape = mesh.transform.FindComponent<BlendShape>();
			if ((bool)blendShape)
			{
				blendShape.LoadPreset(this);
				blendShape.SetShapesCount();
			}
			yield return null;
			Stop(mesh);
		}
	}
}
