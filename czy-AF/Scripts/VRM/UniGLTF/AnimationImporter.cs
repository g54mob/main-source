using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UniGLTF
{
	public static class AnimationImporter
	{
		private enum TangentMode
		{
			Linear = 0,
			Constant = 1,
			Cubicspline = 2
		}

		public delegate float[] ReverseZ(float[] current, float[] last);

		private static TangentMode GetTangentMode(string interpolation)
		{
			if (interpolation == glTFAnimationTarget.Interpolations.LINEAR.ToString())
			{
				return TangentMode.Linear;
			}
			if (interpolation == glTFAnimationTarget.Interpolations.STEP.ToString())
			{
				return TangentMode.Constant;
			}
			if (interpolation == glTFAnimationTarget.Interpolations.CUBICSPLINE.ToString())
			{
				return TangentMode.Cubicspline;
			}
			throw new NotImplementedException();
		}

		private static void CalculateTangent(List<Keyframe> keyframes, int current)
		{
			int num = current - 1;
			if (num >= 0 && current < keyframes.Count)
			{
				float outTangent = (keyframes[current].value - keyframes[num].value) / (keyframes[current].time - keyframes[num].time);
				keyframes[num] = new Keyframe(keyframes[num].time, keyframes[num].value, keyframes[num].inTangent, outTangent);
				float inTangent = (keyframes[num].value - keyframes[current].value) / (keyframes[num].time - keyframes[current].time);
				keyframes[current] = new Keyframe(keyframes[current].time, keyframes[current].value, inTangent, 0f);
			}
		}

		public static Quaternion GetShortest(Quaternion last, Quaternion rot)
		{
			if ((double)Quaternion.Dot(last, rot) > 0.0)
			{
				return rot;
			}
			return new Quaternion(0f - rot.x, 0f - rot.y, 0f - rot.z, 0f - rot.w);
		}

		public static void SetAnimationCurve(AnimationClip targetClip, string relativePath, string[] propertyNames, float[] input, float[] output, string interpolation, Type curveType, ReverseZ reverse)
		{
			TangentMode tangentMode = GetTangentMode(interpolation);
			int num = propertyNames.Length;
			AnimationCurve[] array = new AnimationCurve[num];
			List<Keyframe>[] array2 = new List<Keyframe>[num];
			int num2 = num;
			int num3 = 0;
			float[] array3 = new float[num];
			if (array3.Length == 4)
			{
				array3[3] = 1f;
			}
			for (num3 = 0; num3 < input.Length; num3++)
			{
				float time = input[num3];
				int num4 = 0;
				if (tangentMode == TangentMode.Cubicspline)
				{
					num4 = num3 * num2 * 3;
					float[] array4 = new float[num];
					for (int i = 0; i < array4.Length; i++)
					{
						array4[i] = output[num4 + num2 + i];
					}
					float[] array5 = reverse(array4, array3);
					array3 = array5;
					for (int j = 0; j < array2.Length; j++)
					{
						if (array2[j] == null)
						{
							array2[j] = new List<Keyframe>();
						}
						array2[j].Add(new Keyframe(time, array5[j], output[num4 + j], output[num4 + j + num2 * 2]));
					}
					continue;
				}
				num4 = num3 * num2;
				float[] array6 = new float[num];
				for (int k = 0; k < array6.Length; k++)
				{
					array6[k] = output[num4 + k];
				}
				float[] array7 = reverse(array6, array3);
				array3 = array7;
				for (int l = 0; l < array2.Length; l++)
				{
					if (array2[l] == null)
					{
						array2[l] = new List<Keyframe>();
					}
					switch (tangentMode)
					{
					case TangentMode.Linear:
						array2[l].Add(new Keyframe(time, array7[l], 0f, 0f));
						if (array2[l].Count > 0)
						{
							CalculateTangent(array2[l], array2[l].Count - 1);
						}
						break;
					case TangentMode.Constant:
						array2[l].Add(new Keyframe(time, array7[l], 0f, float.PositiveInfinity));
						break;
					}
				}
			}
			for (int m = 0; m < array.Length; m++)
			{
				array[m] = new AnimationCurve();
				for (int n = 0; n < array2[m].Count; n++)
				{
					array[m].AddKey(array2[m][n]);
				}
				targetClip.SetCurve(relativePath, curveType, propertyNames[m], array[m]);
			}
		}

		public static List<AnimationClip> ImportAnimationClip(ImporterContext ctx)
		{
			List<AnimationClip> list = new List<AnimationClip>();
			for (int i = 0; i < ctx.GLTF.animations.Count; i++)
			{
				AnimationClip animationClip = new AnimationClip();
				animationClip.ClearCurves();
				animationClip.legacy = true;
				animationClip.name = ctx.GLTF.animations[i].name;
				if (string.IsNullOrEmpty(animationClip.name))
				{
					animationClip.name = "legacy_" + i;
				}
				animationClip.wrapMode = WrapMode.Loop;
				glTFAnimation glTFAnimation2 = ctx.GLTF.animations[i];
				if (string.IsNullOrEmpty(glTFAnimation2.name))
				{
					glTFAnimation2.name = $"animation:{i}";
				}
				foreach (glTFAnimationChannel channel in glTFAnimation2.channels)
				{
					string relativePath = ctx.Nodes[channel.target.node].RelativePathFrom(ctx.Root.transform);
					switch (channel.target.path)
					{
					case "translation":
					{
						glTFAnimationSampler glTFAnimationSampler4 = glTFAnimation2.samplers[channel.sampler];
						float[] arrayFromAccessor5 = ctx.GLTF.GetArrayFromAccessor<float>(glTFAnimationSampler4.input);
						Vector3[] arrayFromAccessor6 = ctx.GLTF.GetArrayFromAccessor<Vector3>(glTFAnimationSampler4.output);
						float[] array2 = new float[arrayFromAccessor6.Count() * 3];
						ArrayExtensions.Copy(new ArraySegment<Vector3>(arrayFromAccessor6), new ArraySegment<float>(array2));
						SetAnimationCurve(animationClip, relativePath, new string[3] { "localPosition.x", "localPosition.y", "localPosition.z" }, arrayFromAccessor5, array2, glTFAnimationSampler4.interpolation, typeof(Transform), (float[] values, float[] last) => new Vector3(values[0], values[1], values[2]).ReverseZ().ToArray());
						break;
					}
					case "rotation":
					{
						glTFAnimationSampler glTFAnimationSampler3 = glTFAnimation2.samplers[channel.sampler];
						float[] arrayFromAccessor3 = ctx.GLTF.GetArrayFromAccessor<float>(glTFAnimationSampler3.input);
						Vector4[] arrayFromAccessor4 = ctx.GLTF.GetArrayFromAccessor<Vector4>(glTFAnimationSampler3.output);
						float[] array = new float[arrayFromAccessor4.Count() * 4];
						ArrayExtensions.Copy(new ArraySegment<Vector4>(arrayFromAccessor4), new ArraySegment<float>(array));
						SetAnimationCurve(animationClip, relativePath, new string[4] { "localRotation.x", "localRotation.y", "localRotation.z", "localRotation.w" }, arrayFromAccessor3, array, glTFAnimationSampler3.interpolation, typeof(Transform), (float[] values, float[] last) => GetShortest(rot: new Quaternion(values[0], values[1], values[2], values[3]).ReverseZ(), last: new Quaternion(last[0], last[1], last[2], last[3])).ToArray());
						animationClip.EnsureQuaternionContinuity();
						break;
					}
					case "scale":
					{
						glTFAnimationSampler glTFAnimationSampler5 = glTFAnimation2.samplers[channel.sampler];
						float[] arrayFromAccessor7 = ctx.GLTF.GetArrayFromAccessor<float>(glTFAnimationSampler5.input);
						Vector3[] arrayFromAccessor8 = ctx.GLTF.GetArrayFromAccessor<Vector3>(glTFAnimationSampler5.output);
						float[] array3 = new float[arrayFromAccessor8.Count() * 3];
						ArrayExtensions.Copy(new ArraySegment<Vector3>(arrayFromAccessor8), new ArraySegment<float>(array3));
						SetAnimationCurve(animationClip, relativePath, new string[3] { "localScale.x", "localScale.y", "localScale.z" }, arrayFromAccessor7, array3, glTFAnimationSampler5.interpolation, typeof(Transform), (float[] values, float[] last) => values);
						break;
					}
					case "weights":
					{
						glTFNode glTFNode2 = ctx.GLTF.nodes[channel.target.node];
						_ = ctx.GLTF.meshes[glTFNode2.mesh];
						List<string> list2 = new List<string>();
						SkinnedMeshRenderer component = ctx.Nodes[channel.target.node].GetComponent<SkinnedMeshRenderer>();
						if (component == null)
						{
							break;
						}
						for (int j = 0; j < component.sharedMesh.blendShapeCount; j++)
						{
							list2.Add(component.sharedMesh.GetBlendShapeName(j));
						}
						string[] propertyNames = (from x in list2
							where !string.IsNullOrEmpty(x)
							select "blendShape." + x).ToArray();
						glTFAnimationSampler glTFAnimationSampler2 = glTFAnimation2.samplers[channel.sampler];
						float[] arrayFromAccessor = ctx.GLTF.GetArrayFromAccessor<float>(glTFAnimationSampler2.input);
						float[] arrayFromAccessor2 = ctx.GLTF.GetArrayFromAccessor<float>(glTFAnimationSampler2.output);
						SetAnimationCurve(animationClip, relativePath, propertyNames, arrayFromAccessor, arrayFromAccessor2, glTFAnimationSampler2.interpolation, typeof(SkinnedMeshRenderer), delegate(float[] values, float[] last)
						{
							for (int k = 0; k < values.Length; k++)
							{
								values[k] *= 100f;
							}
							return values;
						});
						break;
					}
					default:
						Debug.LogWarningFormat("unknown path: {0}", channel.target.path);
						break;
					}
				}
				list.Add(animationClip);
			}
			return list;
		}

		public static void ImportAnimation(ImporterContext ctx)
		{
			if (ctx.GLTF.animations == null || !ctx.GLTF.animations.Any())
			{
				return;
			}
			Animation animation = ctx.Root.AddComponent<Animation>();
			ctx.AnimationClips = ImportAnimationClip(ctx);
			foreach (AnimationClip animationClip in ctx.AnimationClips)
			{
				animation.AddClip(animationClip, animationClip.name);
			}
			if (ctx.AnimationClips.Count > 0)
			{
				animation.clip = ctx.AnimationClips.First();
			}
		}
	}
}
