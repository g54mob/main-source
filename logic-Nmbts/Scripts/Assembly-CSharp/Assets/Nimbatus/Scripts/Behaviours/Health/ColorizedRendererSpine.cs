using Spine;
using Spine.Unity;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.Health
{
	public class ColorizedRendererSpine : ColorizedRenderer
	{
		private readonly Skeleton _skeleton;

		public ColorizedRendererSpine(SkeletonRenderer renderer)
		{
			_skeleton = renderer.skeleton;
		}

		public ColorizedRendererSpine(SkeletonAnimation anim)
		{
			_skeleton = anim.skeleton;
		}

		public override void SetColor(Color color)
		{
			foreach (Slot slot in _skeleton.Slots)
			{
				slot.SetColor(color);
			}
		}
	}
}
