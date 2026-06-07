using UnityEngine;
using UnityEngine.Video;

namespace VampireSurvivors.App.UI
{
	public class MenuBackgroundController : MonoBehaviour
	{
		[SerializeField]
		private VideoPlayer _VideoPlayer;

		[SerializeField]
		private GameObject _StaticBackground;

		private void Awake()
		{
		}

		private void OnPrepareCompleted(VideoPlayer source)
		{
		}
	}
}
