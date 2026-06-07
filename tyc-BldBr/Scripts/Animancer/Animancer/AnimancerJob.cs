using UnityEngine.Animations;

namespace Animancer
{
	public abstract class AnimancerJob<T> where T : struct, IAnimationJob
	{
		protected T _Job;

		protected AnimationScriptPlayable _Playable;

		protected void CreatePlayable(AnimancerPlayable animancer)
		{
			_Playable = animancer.InsertOutputJob(_Job);
		}

		public virtual void Destroy()
		{
			AnimancerUtilities.RemovePlayable(_Playable);
		}
	}
}
