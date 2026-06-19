using UnityEngine;

namespace JSAM
{
	public abstract class BaseAudioFeedback<T> : MonoBehaviour where T : BaseAudioFileObject
	{
		[SerializeField]
		[HideInInspector]
		protected T audio;

		[SerializeField]
		protected bool advancedMode;
	}
}
