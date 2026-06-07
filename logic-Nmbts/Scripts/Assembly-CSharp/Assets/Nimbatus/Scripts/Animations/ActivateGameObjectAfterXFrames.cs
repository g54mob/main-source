using UnityEngine;

namespace Assets.Nimbatus.Scripts.Animations
{
	public class ActivateGameObjectAfterXFrames : MonoBehaviour
	{
		public GameObject GameObject;

		public int FrameCount;

		private int _frames;

		private void Update()
		{
			_frames++;
			if (_frames >= FrameCount)
			{
				GameObject.SetActive(true);
			}
		}
	}
}
