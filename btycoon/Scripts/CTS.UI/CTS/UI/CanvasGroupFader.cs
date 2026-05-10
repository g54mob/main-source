using System;
using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS.UI
{
	public class CanvasGroupFader : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private CanvasGroup _canvasGroup;

		private Dictionary<UnityEngine.Object, float> _fades = new Dictionary<UnityEngine.Object, float>();

		protected override void OnEnabled()
		{
			base.OnEnabled();
			UpdateFade();
		}

		public void AddFade(UnityEngine.Object parent, float fadeValue)
		{
			_fades[parent] = fadeValue;
			UpdateFade();
		}

		public void RemoveFade(UnityEngine.Object parent)
		{
			if (_fades.ContainsKey(parent))
			{
				_fades.Remove(parent);
				UpdateFade();
			}
		}

		private void UpdateFade()
		{
			float num = 1f;
			foreach (KeyValuePair<UnityEngine.Object, float> fade in _fades)
			{
				fade.Deconstruct(out var _, out var value);
				float val = value;
				num = Math.Min(num, val);
			}
			_canvasGroup.alpha = num;
		}
	}
}
