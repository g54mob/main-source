using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class HighlightersManager : MonoSingleton<HighlightersManager>
	{
		[SerializeField]
		private bool _active;

		[SerializeField]
		private UIHighlighter _highlighterPrefab;

		[SerializeField]
		private List<GameObject> _targets = new List<GameObject>();

		private Dictionary<GameObject, UIHighlighter> _highlightedTargets = new Dictionary<GameObject, UIHighlighter>();

		private Dictionary<HighlightChain, UIHighlighter> _highlightedChains = new Dictionary<HighlightChain, UIHighlighter>();

		private List<UIHighlighter> _unusedHighlighters = new List<UIHighlighter>();

		private void Start()
		{
			if (!_active)
			{
				return;
			}
			foreach (GameObject target in _targets)
			{
				Highlight(target);
			}
		}

		private UIHighlighter GetHighlighter()
		{
			if (!_active)
			{
				return null;
			}
			if (_unusedHighlighters.Count == 0)
			{
				UIHighlighter uIHighlighter = Object.Instantiate(_highlighterPrefab, base.transform);
				uIHighlighter.gameObject.SetActive(value: false);
				_unusedHighlighters.Add(uIHighlighter);
			}
			UIHighlighter uIHighlighter2 = _unusedHighlighters[0];
			_unusedHighlighters.Remove(uIHighlighter2);
			return uIHighlighter2;
		}

		public void Highlight(GameObject p_target)
		{
			if (_active && !_highlightedTargets.ContainsKey(p_target))
			{
				UIHighlighter highlighter = GetHighlighter();
				highlighter.gameObject.SetActive(value: true);
				highlighter.SetChain(null);
				highlighter.SetTarget(p_target);
				_highlightedTargets.Add(p_target, highlighter);
			}
		}

		public UIHighlighter Highlight(HighlightChain chain)
		{
			if (!_active)
			{
				return null;
			}
			if (_highlightedChains.ContainsKey(chain))
			{
				return _highlightedChains[chain];
			}
			UIHighlighter highlighter = GetHighlighter();
			highlighter.gameObject.SetActive(value: true);
			highlighter.SetChain(chain);
			highlighter.RefreshChain();
			_highlightedChains.Add(chain, highlighter);
			return highlighter;
		}

		public void StopHighlight(GameObject p_target)
		{
			if (_active && _highlightedTargets.ContainsKey(p_target))
			{
				UIHighlighter uIHighlighter = _highlightedTargets[p_target];
				_highlightedTargets.Remove(p_target);
				uIHighlighter.SetTarget(null);
				uIHighlighter.gameObject.SetActive(value: false);
				_unusedHighlighters.Add(uIHighlighter);
			}
		}

		public void StopHighlight(HighlightChain chain)
		{
			if (_active && _highlightedChains.ContainsKey(chain))
			{
				UIHighlighter uIHighlighter = _highlightedChains[chain];
				_highlightedChains.Remove(chain);
				uIHighlighter.SetTarget(null);
				uIHighlighter.gameObject.SetActive(value: false);
				_unusedHighlighters.Add(uIHighlighter);
			}
		}

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}
	}
}
