using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[CreateAssetMenu(menuName = "Malbers Animations/Preset/Bone", order = 200)]
	public class BonePreset : ScriptableCoroutine
	{
		[Header("Smooth BlendShapes")]
		public FloatReference BlendTime = new FloatReference(1.5f);

		public AnimationCurve BlendCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		[Space]
		[Header("Attributes to modify")]
		public bool positions;

		public bool scales = true;

		[Space]
		[Header("Bones Properties")]
		public List<MiniTransform> Bones;

		public virtual void SmoothBlendBones(Transform root)
		{
			StartCoroutine(root, C_SmoothBlendBones(root, BlendTime, BlendCurve));
		}

		internal override void Evaluate(MonoBehaviour mono, Transform target, float time, AnimationCurve curve)
		{
			mono.StartCoroutine(C_SmoothBlendBones(target, time, curve));
		}

		private IEnumerator C_SmoothBlendBones(Transform root, float BlendTime, AnimationCurve BlendCurve)
		{
			List<Transform> list = root.GetComponentsInChildren<Transform>().ToList();
			List<MiniTransform> AnimalStartBones = new List<MiniTransform>();
			List<MiniTransform> AnimalEndBones = new List<MiniTransform>();
			List<Transform> AnimalBonesTransforms = new List<Transform>();
			AnimalStartBones.Add(new MiniTransform("Root", Vector3.zero, root.localScale));
			AnimalEndBones.Add(new MiniTransform("Root", Vector3.zero, Bones[0].Scale));
			AnimalBonesTransforms.Add(root);
			foreach (MiniTransform bone in Bones)
			{
				Transform transform = list.Find((Transform item) => item.name == bone.name);
				if ((bool)transform)
				{
					AnimalStartBones.Add(new MiniTransform(transform.name, transform.localPosition, transform.localScale));
					AnimalEndBones.Add(bone);
					AnimalBonesTransforms.Add(transform);
				}
			}
			float elapsedTime = 0f;
			while (BlendTime > 0f && elapsedTime <= BlendTime)
			{
				float t = BlendCurve.Evaluate(elapsedTime / BlendTime);
				if (scales)
				{
					root.localScale = Vector3.Lerp(AnimalStartBones[0].Scale, AnimalEndBones[0].Scale, t);
				}
				for (int num = 1; num < AnimalStartBones.Count; num++)
				{
					Vector3 localPosition = Vector3.Lerp(AnimalStartBones[num].Position, AnimalEndBones[num].Position, t);
					Vector3 localScale = Vector3.Lerp(AnimalStartBones[num].Scale, AnimalEndBones[num].Scale, t);
					Transform transform2 = AnimalBonesTransforms[num];
					if (scales)
					{
						transform2.localScale = localScale;
					}
					if (positions)
					{
						transform2.localPosition = localPosition;
					}
				}
				elapsedTime += Time.deltaTime;
				yield return null;
			}
			Load(root);
			yield return null;
			Stop(root);
		}

		public void Load(Transform root)
		{
			List<Transform> list = root.GetComponentsInChildren<Transform>().ToList();
			if (Bones[0].name == "Root" && scales)
			{
				root.localScale = Bones[0].Scale;
			}
			foreach (MiniTransform bone in Bones)
			{
				Transform transform = list.Find((Transform item) => item.name == bone.name);
				if ((bool)transform)
				{
					if (positions)
					{
						transform.localPosition = bone.Position;
					}
					if (scales)
					{
						transform.localScale = bone.Scale;
					}
				}
			}
		}
	}
}
