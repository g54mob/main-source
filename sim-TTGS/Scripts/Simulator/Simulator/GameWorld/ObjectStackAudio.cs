using UnityEngine;

namespace Simulator.GameWorld
{
	public class ObjectStackAudio : MonoBehaviour
	{
		[SerializeField]
		private ObjectStack m_objectStack;

		private void OnEnable()
		{
			m_objectStack.PreStacked += OnStacked_PlayAudio;
		}

		private void OnDisable()
		{
			m_objectStack.PreStacked -= OnStacked_PlayAudio;
		}

		private void OnStacked_PlayAudio()
		{
			AudioManager.PlaySingleEvent(WorldAudioSettings.ShelfItemAdd);
		}
	}
}
