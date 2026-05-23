using Libs;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class SkipWaveButton : SingletonMonoBehaviour<SkipWaveButton>
	{
		public CanvasGroup canvasGroup;

		public Image pushEffectImage;

		public float skipStartTime;

		public float skipFinishTime;

		private float _longPushTimer;

		private bool _isPush;

		private Vector3 _initialScale;

		private bool _pushOk;

		public bool PushOk
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void PointerDown()
		{
		}

		public void PointerUp()
		{
		}
	}
}
