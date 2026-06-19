using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class HighlightManager : MustCallDestroy
	{
		[DontSave]
		private float _remainingHighlightedTime;

		[DontSave]
		private float _alpha;

		[DontSave]
		private List<Renderer> _multipleHighlightCached;

		public void HighlightObject(ICursorSelectable selected)
		{
			if (!(selected is IMultipleHighlight multipleHighlight))
			{
				HighlightObject(selected.GetHighlightGameObject());
				return;
			}
			if (_multipleHighlightCached == null)
			{
				_multipleHighlightCached = new List<Renderer>(128);
			}
			multipleHighlight.GetMultipleHighlightGameObjects(_multipleHighlightCached);
			HighlightObjects(_multipleHighlightCached);
			_multipleHighlightCached.Clear();
		}

		public void HighlightObject(Renderer renderer)
		{
			_remainingHighlightedTime = 0.2f;
			if (!HighlightRendererProxy.Instance.AreEqual(renderer))
			{
				_alpha = 0f;
				HighlightRendererProxy.Instance.Clear();
				HighlightRendererProxy.Instance.Register(renderer);
			}
		}

		private void HighlightObjects(List<Renderer> renderers)
		{
			_remainingHighlightedTime = 0.2f;
			if (!HighlightRendererProxy.Instance.AreEqual(renderers))
			{
				_alpha = 0f;
				HighlightRendererProxy.Instance.Clear();
				HighlightRendererProxy.Instance.Register(renderers);
			}
		}

		public void Update()
		{
			_remainingHighlightedTime -= Time.unscaledDeltaTime;
			if (_remainingHighlightedTime > 0f)
			{
				_alpha += 5f * Time.unscaledDeltaTime;
			}
			else
			{
				_alpha -= 5f * Time.unscaledDeltaTime;
			}
			_alpha = Mathf.Clamp01(_alpha);
			HighlightRendererProxy.Instance.Alpha = _alpha;
			if (_alpha <= 0f && _remainingHighlightedTime <= 0f)
			{
				HighlightRendererProxy.Instance.Clear();
			}
		}

		public override void Destroy()
		{
			HighlightRendererProxy.Instance.Alpha = 1f;
			HighlightRendererProxy.Instance.Clear();
			base.Destroy();
		}
	}
}
