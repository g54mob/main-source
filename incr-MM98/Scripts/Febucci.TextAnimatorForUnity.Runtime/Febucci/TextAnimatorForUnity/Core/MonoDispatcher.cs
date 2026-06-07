using UnityEngine;

namespace Febucci.TextAnimatorForUnity.Core
{
	internal class MonoDispatcher : MonoBehaviour
	{
		private static MonoDispatcher instance;

		public static MonoDispatcher Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new GameObject("Text Animator MonoDispatcher").AddComponent<MonoDispatcher>();
					Object.DontDestroyOnLoad(instance.gameObject);
					instance.hideFlags = HideFlags.HideAndDontSave;
				}
				return instance;
			}
		}
	}
}
