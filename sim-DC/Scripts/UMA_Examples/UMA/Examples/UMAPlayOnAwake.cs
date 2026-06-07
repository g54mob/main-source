using UMA.CharacterSystem;
using UnityEngine;
using UnityEngine.Playables;

namespace UMA.Examples
{
	public class UMAPlayOnAwake : MonoBehaviour
	{
		public PlayableDirector playableDirector;

		private DynamicCharacterAvatar avatar;

		private void Start()
		{
		}

		public void OnCharacterCreated(UMAData umaData)
		{
		}
	}
}
