using DG.Tweening;
using UnityEngine;

namespace Simulator.GameWorld
{
	public static class StackableExtensions
	{
		public static void Anchor(this IStackable stackable, Transform anchor, Vector3 localPosition)
		{
			stackable.transform.SetParent(anchor, worldPositionStays: true);
			stackable.transform.SetLocalPositionAndRotation(localPosition, Quaternion.identity);
		}

		public static Tween AnimatedAnchor(this IStackable stackable, Transform anchor, AnimationPath path, float duration)
		{
			stackable.transform.SetParent(anchor, worldPositionStays: true);
			Sequence sequence = DOTween.Sequence();
			Vector3[] array = path;
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = anchor.InverseTransformPoint(array[i]);
			}
			sequence.Append(stackable.transform.DOLocalPath(array, duration));
			sequence.Join(stackable.transform.DOLocalRotate(Vector3.zero, duration));
			return sequence;
		}
	}
}
