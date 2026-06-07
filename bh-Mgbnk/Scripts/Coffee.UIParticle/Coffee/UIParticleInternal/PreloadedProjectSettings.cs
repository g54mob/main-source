using UnityEngine;

namespace Coffee.UIParticleInternal
{
	public abstract class PreloadedProjectSettings : ScriptableObject
	{
	}
	public abstract class PreloadedProjectSettings<T> : PreloadedProjectSettings where T : PreloadedProjectSettings<T>
	{
		private static T s_Instance;

		public static T instance => null;

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}
	}
}
