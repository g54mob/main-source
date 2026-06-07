using System;
using DG.Tweening;
using UnityEngine;

namespace Gh.Tk
{
	public class TimeSettingSlider3DUIView : MonoBehaviour
	{
		[SerializeField]
		private Transform[] _gameSpeedPositions;

		private Tweener _tweener;

		private Ease _easing;

		public void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnTimeSettingChanged(object sender, EventArgs e)
		{
		}

		private void UpdatePosition(Vector3 position)
		{
		}
	}
}
