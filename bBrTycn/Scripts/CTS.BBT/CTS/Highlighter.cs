using System;
using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class Highlighter : CTSSingleton<Highlighter>
	{
		[SerializeField]
		private HighlightObject _prefab;

		private readonly Dictionary<RectTransform, HighlightObject> _highlights = new Dictionary<RectTransform, HighlightObject>();

		private readonly Stack<HighlightObject> _pool = new Stack<HighlightObject>();

		public static event Action<RectTransform> Highlighted;

		public static event Action<RectTransform> StoppedHighlighting;

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}

		public bool IsHighlighted(RectTransform rectTransform)
		{
			return _highlights.ContainsKey(rectTransform);
		}

		public void Highlight(RectTransform rectTransform)
		{
			if (!IsHighlighted(rectTransform))
			{
				HighlightObject highlightObject = GetObject(rectTransform);
				_highlights[rectTransform] = highlightObject;
				highlightObject.transform.localPosition = Vector3.zero;
				highlightObject.gameObject.SetActive(value: true);
				Highlighter.Highlighted?.Invoke(rectTransform);
			}
		}

		public void StopHighlight(RectTransform rectTransform)
		{
			if (_highlights.TryGetValue(rectTransform, out var value))
			{
				value.Stop();
				_highlights.Remove(rectTransform);
				Highlighter.StoppedHighlighting?.Invoke(rectTransform);
			}
		}

		private HighlightObject GetObject(RectTransform parent)
		{
			while (_pool.Count > 0)
			{
				HighlightObject highlightObject = _pool.Pop();
				if (highlightObject != null)
				{
					highlightObject.transform.SetParent(parent);
					return highlightObject;
				}
			}
			return CTSFactory.Instantiate(_prefab, parent, instantiateInWorldSpace: false, false);
		}

		public void ReturnToPool(HighlightObject obj)
		{
			_pool.Push(obj);
		}
	}
}
