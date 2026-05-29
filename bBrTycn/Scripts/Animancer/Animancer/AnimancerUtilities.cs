using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Animancer
{
	public static class AnimancerUtilities
	{
		public const bool IsAnimancerPro = true;

		public static float Wrap01(float value)
		{
			double num = value;
			value = (float)(num - Math.Floor(num));
			if (!(value < 1f))
			{
				return 0f;
			}
			return value;
		}

		public static float Wrap(float value, float length)
		{
			double num = value;
			double num2 = length;
			value = (float)(num - Math.Floor(num / num2) * num2);
			if (!(value < length))
			{
				return 0f;
			}
			return value;
		}

		public static float Round(float value)
		{
			return (float)Math.Round(value, MidpointRounding.AwayFromZero);
		}

		public static float Round(float value, float multiple)
		{
			return Round(value / multiple) * multiple;
		}

		public static bool IsFinite(this float value)
		{
			if (!float.IsNaN(value))
			{
				return !float.IsInfinity(value);
			}
			return false;
		}

		public static bool IsFinite(this double value)
		{
			if (!double.IsNaN(value))
			{
				return !double.IsInfinity(value);
			}
			return false;
		}

		public static bool IsFinite(this Vector2 value)
		{
			if (value.x.IsFinite())
			{
				return value.y.IsFinite();
			}
			return false;
		}

		public static string ToStringOrNull(object obj)
		{
			if (obj == null)
			{
				return "Null";
			}
			if (obj is UnityEngine.Object obj2 && obj2 == null)
			{
				return $"Null ({obj.GetType()})";
			}
			return obj.ToString();
		}

		public static void CopyExactArray<T>(T[] copyFrom, ref T[] copyTo)
		{
			if (copyFrom == null)
			{
				copyTo = null;
				return;
			}
			int length = copyFrom.Length;
			SetLength(ref copyTo, length);
			Array.Copy(copyFrom, copyTo, length);
		}

		public static void Swap<T>(this T[] array, int a, int b)
		{
			T val = array[a];
			array[a] = array[b];
			array[b] = val;
		}

		public static bool IsNullOrEmpty<T>(this T[] array)
		{
			if (array != null)
			{
				return array.Length == 0;
			}
			return true;
		}

		public static bool SetLength<T>(ref T[] array, int length)
		{
			if (array == null || array.Length != length)
			{
				array = new T[length];
				return true;
			}
			return false;
		}

		public static bool IsValid(this AnimancerNode node)
		{
			return node?.IsValid ?? false;
		}

		public static bool IsValid(this ITransitionDetailed transition)
		{
			return transition?.IsValid ?? false;
		}

		public static AnimancerState CreateStateAndApply(this ITransition transition, AnimancerPlayable root = null)
		{
			AnimancerState animancerState = transition.CreateState();
			animancerState.SetRoot(root);
			transition.Apply(animancerState);
			return animancerState;
		}

		public static void RemovePlayable(Playable playable, bool destroy = true)
		{
			if (!playable.IsValid())
			{
				return;
			}
			Playable input = playable.GetInput(0);
			if (!input.IsValid())
			{
				if (destroy)
				{
					playable.Destroy();
				}
				return;
			}
			PlayableGraph graph = playable.GetGraph();
			Playable output = playable.GetOutput(0);
			if (output.IsValid())
			{
				if (destroy)
				{
					playable.Destroy();
				}
				else
				{
					graph.Disconnect(output, 0);
					graph.Disconnect(playable, 0);
				}
				graph.Connect(input, 0, output, 0);
			}
			else
			{
				if (destroy)
				{
					playable.Destroy();
				}
				else
				{
					graph.Disconnect(playable, 0);
				}
				graph.GetOutput(0).SetSourcePlayable(input);
			}
		}

		public static bool HasEvent(IAnimationClipCollection source, string functionName)
		{
			HashSet<AnimationClip> hashSet = ObjectPool.AcquireSet<AnimationClip>();
			source.GatherAnimationClips(hashSet);
			foreach (AnimationClip item in hashSet)
			{
				if (HasEvent(item, functionName))
				{
					ObjectPool.Release(hashSet);
					return true;
				}
			}
			ObjectPool.Release(hashSet);
			return false;
		}

		public static bool HasEvent(AnimationClip clip, string functionName)
		{
			AnimationEvent[] events = clip.events;
			for (int num = events.Length - 1; num >= 0; num--)
			{
				if (events[num].functionName == functionName)
				{
					return true;
				}
			}
			return false;
		}

		public static void CalculateThresholdsFromAverageVelocityXZ(this MixerState<Vector2> mixer)
		{
			mixer.ValidateThresholdCount();
			for (int num = mixer.ChildCount - 1; num >= 0; num--)
			{
				AnimancerState child = mixer.GetChild(num);
				if (child != null)
				{
					Vector3 averageVelocity = child.AverageVelocity;
					mixer.SetThreshold(num, new Vector2(averageVelocity.x, averageVelocity.z));
				}
			}
		}

		public static void CopyParameterValue(Animator copyFrom, Animator copyTo, AnimatorControllerParameter parameter)
		{
			switch (parameter.type)
			{
			case AnimatorControllerParameterType.Float:
				copyTo.SetFloat(parameter.nameHash, copyFrom.GetFloat(parameter.nameHash));
				break;
			case AnimatorControllerParameterType.Int:
				copyTo.SetInteger(parameter.nameHash, copyFrom.GetInteger(parameter.nameHash));
				break;
			case AnimatorControllerParameterType.Bool:
			case AnimatorControllerParameterType.Trigger:
				copyTo.SetBool(parameter.nameHash, copyFrom.GetBool(parameter.nameHash));
				break;
			default:
				throw CreateUnsupportedArgumentException(parameter.type);
			}
		}

		public static void CopyParameterValue(AnimatorControllerPlayable copyFrom, AnimatorControllerPlayable copyTo, AnimatorControllerParameter parameter)
		{
			switch (parameter.type)
			{
			case AnimatorControllerParameterType.Float:
				copyTo.SetFloat(parameter.nameHash, copyFrom.GetFloat(parameter.nameHash));
				break;
			case AnimatorControllerParameterType.Int:
				copyTo.SetInteger(parameter.nameHash, copyFrom.GetInteger(parameter.nameHash));
				break;
			case AnimatorControllerParameterType.Bool:
			case AnimatorControllerParameterType.Trigger:
				copyTo.SetBool(parameter.nameHash, copyFrom.GetBool(parameter.nameHash));
				break;
			default:
				throw CreateUnsupportedArgumentException(parameter.type);
			}
		}

		public static object GetParameterValue(Animator animator, AnimatorControllerParameter parameter)
		{
			switch (parameter.type)
			{
			case AnimatorControllerParameterType.Float:
				return animator.GetFloat(parameter.nameHash);
			case AnimatorControllerParameterType.Int:
				return animator.GetInteger(parameter.nameHash);
			case AnimatorControllerParameterType.Bool:
			case AnimatorControllerParameterType.Trigger:
				return animator.GetBool(parameter.nameHash);
			default:
				throw CreateUnsupportedArgumentException(parameter.type);
			}
		}

		public static object GetParameterValue(AnimatorControllerPlayable playable, AnimatorControllerParameter parameter)
		{
			switch (parameter.type)
			{
			case AnimatorControllerParameterType.Float:
				return playable.GetFloat(parameter.nameHash);
			case AnimatorControllerParameterType.Int:
				return playable.GetInteger(parameter.nameHash);
			case AnimatorControllerParameterType.Bool:
			case AnimatorControllerParameterType.Trigger:
				return playable.GetBool(parameter.nameHash);
			default:
				throw CreateUnsupportedArgumentException(parameter.type);
			}
		}

		public static void SetParameterValue(Animator animator, AnimatorControllerParameter parameter, object value)
		{
			switch (parameter.type)
			{
			case AnimatorControllerParameterType.Float:
				animator.SetFloat(parameter.nameHash, (float)value);
				break;
			case AnimatorControllerParameterType.Int:
				animator.SetInteger(parameter.nameHash, (int)value);
				break;
			case AnimatorControllerParameterType.Bool:
				animator.SetBool(parameter.nameHash, (bool)value);
				break;
			case AnimatorControllerParameterType.Trigger:
				if ((bool)value)
				{
					animator.SetTrigger(parameter.nameHash);
				}
				else
				{
					animator.ResetTrigger(parameter.nameHash);
				}
				break;
			default:
				throw CreateUnsupportedArgumentException(parameter.type);
			}
		}

		public static void SetParameterValue(AnimatorControllerPlayable playable, AnimatorControllerParameter parameter, object value)
		{
			switch (parameter.type)
			{
			case AnimatorControllerParameterType.Float:
				playable.SetFloat(parameter.nameHash, (float)value);
				break;
			case AnimatorControllerParameterType.Int:
				playable.SetInteger(parameter.nameHash, (int)value);
				break;
			case AnimatorControllerParameterType.Bool:
				playable.SetBool(parameter.nameHash, (bool)value);
				break;
			case AnimatorControllerParameterType.Trigger:
				if ((bool)value)
				{
					playable.SetTrigger(parameter.nameHash);
				}
				else
				{
					playable.ResetTrigger(parameter.nameHash);
				}
				break;
			default:
				throw CreateUnsupportedArgumentException(parameter.type);
			}
		}

		public static NativeArray<T> CreateNativeReference<T>() where T : struct
		{
			return new NativeArray<T>(1, Allocator.Persistent);
		}

		public static NativeArray<TransformStreamHandle> ConvertToTransformStreamHandles(IList<Transform> transforms, Animator animator)
		{
			int count = transforms.Count;
			NativeArray<TransformStreamHandle> result = new NativeArray<TransformStreamHandle>(count, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			for (int i = 0; i < count; i++)
			{
				result[i] = animator.BindStreamTransform(transforms[i]);
			}
			return result;
		}

		public static string GetUnsupportedMessage<T>(T value)
		{
			return $"Unsupported {typeof(T).FullName}: {value}";
		}

		public static ArgumentException CreateUnsupportedArgumentException<T>(T value)
		{
			return new ArgumentException(GetUnsupportedMessage(value));
		}

		public static T AddAnimancerComponent<T>(this Animator animator) where T : Component, IAnimancerComponent
		{
			T val = animator.gameObject.AddComponent<T>();
			val.Animator = animator;
			return val;
		}

		public static T GetOrAddAnimancerComponent<T>(this Animator animator) where T : Component, IAnimancerComponent
		{
			if (animator.TryGetComponent<T>(out var component))
			{
				return component;
			}
			return animator.AddAnimancerComponent<T>();
		}

		public static T GetComponentInParentOrChildren<T>(this GameObject gameObject) where T : class
		{
			T componentInParent = gameObject.GetComponentInParent<T>();
			if (componentInParent != null)
			{
				return componentInParent;
			}
			return gameObject.GetComponentInChildren<T>();
		}

		public static bool GetComponentInParentOrChildren<T>(this GameObject gameObject, ref T component) where T : class
		{
			if (component != null && (!(component is UnityEngine.Object obj) || obj != null))
			{
				return false;
			}
			component = gameObject.GetComponentInParentOrChildren<T>();
			return component != null;
		}

		[Conditional("UNITY_ASSERTIONS")]
		public static void Assert(bool condition, object message)
		{
		}

		[Conditional("UNITY_EDITOR")]
		public static void SetDirty(UnityEngine.Object target)
		{
		}

		[Conditional("UNITY_EDITOR")]
		public static void EditModeSampleAnimation(this AnimationClip clip, Component component, float time = 0f)
		{
		}

		[Conditional("UNITY_EDITOR")]
		public static void EditModePlay(this AnimationClip clip, Component component)
		{
		}

		public static void Gather(this ICollection<AnimationClip> clips, AnimationClip clip)
		{
			if (clip != null && !clips.Contains(clip))
			{
				clips.Add(clip);
			}
		}

		public static void Gather(this ICollection<AnimationClip> clips, IList<AnimationClip> gatherFrom)
		{
			if (gatherFrom != null)
			{
				for (int num = gatherFrom.Count - 1; num >= 0; num--)
				{
					clips.Gather(gatherFrom[num]);
				}
			}
		}

		public static void Gather(this ICollection<AnimationClip> clips, IEnumerable<AnimationClip> gatherFrom)
		{
			if (gatherFrom == null)
			{
				return;
			}
			foreach (AnimationClip item in gatherFrom)
			{
				clips.Gather(item);
			}
		}

		public static void GatherFromAsset(this ICollection<AnimationClip> clips, PlayableAsset asset)
		{
			if (!(asset == null))
			{
				MethodInfo method = asset.GetType().GetMethod("GetRootTracks");
				if (method != null && typeof(IEnumerable).IsAssignableFrom(method.ReturnType) && method.GetParameters().Length == 0)
				{
					object obj = method.Invoke(asset, null);
					GatherFromTracks(clips, obj as IEnumerable);
				}
			}
		}

		private static void GatherFromTracks(ICollection<AnimationClip> clips, IEnumerable tracks)
		{
			if (tracks == null)
			{
				return;
			}
			foreach (object track in tracks)
			{
				if (track == null)
				{
					continue;
				}
				Type type = track.GetType();
				MethodInfo method = type.GetMethod("GetClips");
				if (method != null && typeof(IEnumerable).IsAssignableFrom(method.ReturnType) && method.GetParameters().Length == 0 && method.Invoke(track, null) is IEnumerable enumerable)
				{
					foreach (object item in enumerable)
					{
						PropertyInfo property = item.GetType().GetProperty("animationClip");
						if (property != null && property.PropertyType == typeof(AnimationClip))
						{
							MethodInfo getMethod = property.GetGetMethod();
							clips.Gather(getMethod.Invoke(item, null) as AnimationClip);
						}
					}
				}
				MethodInfo method2 = type.GetMethod("GetChildTracks");
				if (method2 != null && typeof(IEnumerable).IsAssignableFrom(method2.ReturnType) && method2.GetParameters().Length == 0)
				{
					object obj = method2.Invoke(track, null);
					GatherFromTracks(clips, obj as IEnumerable);
				}
			}
		}

		public static void GatherFromSource(this ICollection<AnimationClip> clips, IAnimationClipSource source)
		{
			if (source != null)
			{
				List<AnimationClip> list = ObjectPool.AcquireList<AnimationClip>();
				source.GetAnimationClips(list);
				clips.Gather(list);
				ObjectPool.Release(list);
			}
		}

		public static void GatherFromSource(this ICollection<AnimationClip> clips, IEnumerable source)
		{
			if (source == null)
			{
				return;
			}
			foreach (object item in source)
			{
				clips.GatherFromSource(item);
			}
		}

		public static bool GatherFromSource(this ICollection<AnimationClip> clips, object source)
		{
			if (TryGetWrappedObject<AnimationClip>(source, out var wrapped))
			{
				clips.Gather(wrapped);
				return true;
			}
			if (TryGetWrappedObject<IAnimationClipCollection>(source, out var wrapped2))
			{
				wrapped2.GatherAnimationClips(clips);
				return true;
			}
			if (TryGetWrappedObject<IAnimationClipSource>(source, out var wrapped3))
			{
				clips.GatherFromSource(wrapped3);
				return true;
			}
			if (TryGetWrappedObject<IEnumerable>(source, out var wrapped4))
			{
				clips.GatherFromSource(wrapped4);
				return true;
			}
			return false;
		}

		public static bool TryGetFrameRate(object clipSource, out float frameRate)
		{
			HashSet<AnimationClip> set;
			using (ObjectPool.Disposable.AcquireSet(out set))
			{
				set.GatherFromSource(clipSource);
				if (set.Count == 0)
				{
					frameRate = float.NaN;
					return false;
				}
				frameRate = float.NaN;
				foreach (AnimationClip item in set)
				{
					if (float.IsNaN(frameRate))
					{
						frameRate = item.frameRate;
					}
					else if (frameRate != item.frameRate)
					{
						frameRate = float.NaN;
						return false;
					}
				}
				return frameRate > 0f;
			}
		}

		public static T Clone<T>(this T original) where T : class, ICopyable<T>, new()
		{
			if (original == null)
			{
				return null;
			}
			T val = new T();
			val.CopyFrom(original);
			return val;
		}

		public static bool TryGetAverageAngularSpeed(object motion, out float averageAngularSpeed)
		{
			if (motion is Motion motion2)
			{
				averageAngularSpeed = motion2.averageAngularSpeed;
				return true;
			}
			if (TryGetWrappedObject<IMotion>(motion, out var wrapped))
			{
				averageAngularSpeed = wrapped.AverageAngularSpeed;
				return true;
			}
			averageAngularSpeed = 0f;
			return false;
		}

		public static bool TryGetAverageVelocity(object motion, out Vector3 averageVelocity)
		{
			if (motion is Motion motion2)
			{
				averageVelocity = motion2.averageSpeed;
				return true;
			}
			if (TryGetWrappedObject<IMotion>(motion, out var wrapped))
			{
				averageVelocity = wrapped.AverageVelocity;
				return true;
			}
			averageVelocity = default(Vector3);
			return false;
		}

		public static bool IsValid(this ITransition transition)
		{
			if (transition == null)
			{
				return false;
			}
			if (TryGetWrappedObject<ITransitionDetailed>(transition, out var wrapped))
			{
				return wrapped.IsValid;
			}
			return true;
		}

		public static bool TryGetIsLooping(object motionOrTransition, out bool isLooping)
		{
			if (motionOrTransition is Motion motion)
			{
				isLooping = motion.isLooping;
				return true;
			}
			if (TryGetWrappedObject<ITransitionDetailed>(motionOrTransition, out var wrapped))
			{
				isLooping = wrapped.IsLooping;
				return true;
			}
			isLooping = false;
			return false;
		}

		public static bool TryGetLength(object motionOrTransition, out float length)
		{
			if (motionOrTransition is AnimationClip animationClip)
			{
				length = animationClip.length;
				return true;
			}
			if (TryGetWrappedObject<ITransitionDetailed>(motionOrTransition, out var wrapped))
			{
				length = wrapped.MaximumDuration;
				return true;
			}
			length = 0f;
			return false;
		}

		public static object GetWrappedObject(object wrapper)
		{
			while (wrapper is IWrapper wrapper2)
			{
				wrapper = wrapper2.WrappedObject;
			}
			return wrapper;
		}

		public static bool TryGetWrappedObject<T>(object wrapper, out T wrapped) where T : class
		{
			while (true)
			{
				wrapped = wrapper as T;
				if (wrapped != null)
				{
					return true;
				}
				if (!(wrapper is IWrapper wrapper2))
				{
					break;
				}
				wrapper = wrapper2.WrappedObject;
			}
			return false;
		}
	}
}
