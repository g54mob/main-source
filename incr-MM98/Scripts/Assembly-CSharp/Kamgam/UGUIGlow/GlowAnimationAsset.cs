using UnityEngine;

namespace Kamgam.UGUIGlow
{
	public abstract class GlowAnimationAsset : ScriptableObject
	{
		protected IGlowAnimation _animation;

		protected virtual T getAnimation<T>(out bool createdNewCopy) where T : IGlowAnimation, new()
		{
			if (_animation == null)
			{
				T val = createAnimation<T>();
				_animation = val;
				createdNewCopy = true;
			}
			else
			{
				createdNewCopy = false;
			}
			return (T)_animation;
		}

		protected virtual T getAnimation<T>() where T : IGlowAnimation, new()
		{
			bool createdNewCopy;
			return getAnimation<T>(out createdNewCopy);
		}

		public abstract IGlowAnimation GetAnimation();

		protected T createAnimation<T>() where T : IGlowAnimation, new()
		{
			T val = new T();
			_animation = val;
			return val;
		}
	}
}
