using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnityTypeExtensions
{
	public static bool IsCloserTo(this Vector3 t, Vector3 other)
	{
		return Vector3.Distance(t, other) < 0.001f;
	}

	public static void Shuffle<T>(this IList<T> list)
	{
		int num = list.Count;
		while (num > 1)
		{
			num--;
			int index = Random.Range(0, num + 1);
			T value = list[index];
			list[index] = list[num];
			list[num] = value;
		}
	}

	public static T GetRandomItem<T>(this T[] list)
	{
		return list[Random.Range(0, list.Length)];
	}

	public static T GetRandomItem<T>(this List<T> list)
	{
		return list[Random.Range(0, list.Count)];
	}

	public static T LastItem<T>(this List<T> list)
	{
		return list[list.Count - 1];
	}

	public static T FirstItem<T>(this List<T> list)
	{
		return list[0];
	}

	public static bool TryAdd<T>(this HashSet<T> list, T item)
	{
		if (!list.Contains(item))
		{
			list.Add(item);
			return true;
		}
		return false;
	}

	public static bool TryAdd<T>(this List<T> list, T item)
	{
		if (!list.Contains(item))
		{
			list.Add(item);
			return true;
		}
		return false;
	}

	public static bool TryRemove<T>(this List<T> list, T item)
	{
		if (list.Contains(item))
		{
			list.Remove(item);
			return true;
		}
		return false;
	}

	public static void TryAddRange<T>(this List<T> list, List<T> range)
	{
		foreach (T item in range)
		{
			list.TryAdd(item);
		}
	}

	public static bool TryAdd<T1, T2>(this IDictionary<T1, T2> d, T1 key, T2 value)
	{
		if (!d.ContainsKey(key))
		{
			d.Add(key, value);
			return true;
		}
		return false;
	}

	public static IEnumerator WaitForAnimationLegacy(Animation animation)
	{
		do
		{
			yield return new WaitForEndOfFrame();
		}
		while (animation.isPlaying);
	}

	public static IEnumerator WhilePlayingLegacy(this Animation animation)
	{
		do
		{
			yield return new WaitForEndOfFrame();
		}
		while (animation.isPlaying);
	}

	public static IEnumerator WhilePlayingLegacy(this Animation animation, string animationName)
	{
		animation.PlayQueued(animationName);
		return animation.WhilePlayingLegacy();
	}

	public static IEnumerator WaitForSound(AudioSource s)
	{
		do
		{
			yield return new WaitForEndOfFrame();
		}
		while (s.isPlaying);
	}

	public static IEnumerator WhilePlaying(this AudioSource s)
	{
		do
		{
			yield return new WaitForEndOfFrame();
		}
		while (s.isPlaying);
	}

	public static IEnumerator WhilePlaying(this AudioSource s, AudioClip c)
	{
		s.PlayOneShot(c);
		return s.WhilePlaying();
	}

	public static float GetCurrentTime(this Animator animator)
	{
		AnimatorStateInfo currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
		return currentAnimatorStateInfo.length * currentAnimatorStateInfo.normalizedTime;
	}

	public static IEnumerator WaitForAnimation(this Animator animator, string layerName, string stateName)
	{
		int hash = UnityUtils.HashOnLayer(layerName, stateName);
		_ = animator.GetCurrentAnimatorStateInfo(0).nameHash;
		animator.Play(hash);
		yield return new WaitForEndOfFrame();
		int nameHash;
		do
		{
			yield return new WaitForEndOfFrame();
			nameHash = animator.GetCurrentAnimatorStateInfo(0).nameHash;
		}
		while (nameHash == hash);
	}

	public static IEnumerator WaitForAnimation(this Animator animator, string stateName)
	{
		return animator.WaitForAnimation("Base Layer", stateName);
	}

	public static void Play(this Animator animator, string stateName)
	{
		int stateNameHash = UnityUtils.HashOnLayer("Base Layer", stateName);
		_ = animator.GetCurrentAnimatorStateInfo(0).nameHash;
		animator.Play(stateNameHash);
	}

	public static void Reset(this Animator animator)
	{
		int stateNameHash = UnityUtils.HashOnLayer("Base Layer", "Empty");
		_ = animator.GetCurrentAnimatorStateInfo(0).nameHash;
		animator.Play(stateNameHash);
	}
}
