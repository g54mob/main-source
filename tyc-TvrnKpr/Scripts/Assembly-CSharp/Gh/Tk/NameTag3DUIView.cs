using System;
using DG.Tweening;
using Gh.Tk.UI;
using UnityEngine;

namespace Gh.Tk
{
	public class NameTag3DUIView : MonoBehaviour
	{
		[SerializeField]
		private TextBlock3DUIView _textBlock;

		[SerializeField]
		private Transform _scalerTransform;

		private Tween _transitionTween;

		[SerializeField]
		private float _introTransitionDuration;

		[SerializeField]
		private Ease _introTransitionEase;

		public float minDistanceFromCamera;

		public float maxDistanceFromCamera;

		public float minScale;

		public float maxScale;

		public void SetData(string name)
		{
		}

		private void AddListeners()
		{
		}

		public void RemoveListeners()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnDialogOpening(object sender, EventArgs e)
		{
		}

		private void OnDialogClosed(object sender, EventArgs e)
		{
		}

		private void OnPauseMenuStateChanged(object sender, EventArgs e)
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		private void ScaleNameTag()
		{
		}

		private void PlayIntroAnimation()
		{
		}
	}
}
