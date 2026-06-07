using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class EmphasisObj : MonoBehaviour
	{
		public Button button;

		public Image emphasisImage;

		public bool playOnAwake;

		public float defaultDuration;

		private Tween _tween;

		public bool IsPlaying => false;

		private void Awake()
		{
		}

		public void PlayEmphasis(float? duration = null, bool fade = true)
		{
		}

		public void StopEmphasis()
		{
		}
	}
}
