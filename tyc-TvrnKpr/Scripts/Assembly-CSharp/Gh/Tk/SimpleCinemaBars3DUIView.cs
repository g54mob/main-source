using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Gh.Tk
{
	public class SimpleCinemaBars3DUIView : MonoBehaviour
	{
		public List<RectTransform> bars;

		protected Tween _tween;

		public float showHideDuration;

		public Ease showHideEase;

		public bool IsShowing { get; private set; }

		protected virtual void Awake()
		{
		}

		protected virtual void OnResetUI(object sender, EventArgs e)
		{
		}

		public void ShowCinemaBars(bool skipTransition)
		{
		}

		public void HideCinemaBars(bool skipTransition)
		{
		}
	}
}
