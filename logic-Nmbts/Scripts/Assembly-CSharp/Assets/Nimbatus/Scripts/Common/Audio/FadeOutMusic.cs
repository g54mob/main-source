using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.Audio
{
	public class FadeOutMusic : MonoBehaviour
	{
		public void Start()
		{
			AudioController.FadeOutCategory("Music", 1f);
		}
	}
}
