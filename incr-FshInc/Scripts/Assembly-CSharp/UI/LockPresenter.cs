using UnityEngine;

namespace UI
{
	public class LockPresenter : MonoBehaviour
	{
		public void PlayUnlockSound()
		{
			SoundManager.PlaySound("Padlock_Unlock");
			Debug.Log("Unlock sound played");
		}
	}
}
