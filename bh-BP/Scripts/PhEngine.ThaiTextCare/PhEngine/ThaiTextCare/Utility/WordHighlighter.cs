using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace PhEngine.ThaiTextCare.Utility
{
	public class WordHighlighter : MonoBehaviour
	{
		[Header("Settings")]
		public float maxDistance;

		public HighlightMode highlightMode;

		public DuplicateHighlightMode duplicateHighlightMode;

		[Header("Components")]
		public Camera targetCamera;

		public Highlight highlightPrefab;

		[Header("Runtime")]
		[SerializeField]
		private List<WordHit> wordHitList;

		[SerializeField]
		private List<Highlight> highlightList;

		public IReadOnlyList<WordHit> WordHits => null;

		public IReadOnlyList<Highlight> Highlights => null;

		public event Action<Highlight> OnWordHighlighted
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<Highlight> OnDispose
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void HighlightWordFromMouse(TextMeshProUGUI text)
		{
		}

		public bool TryHighlightWordFromMouse(TextMeshProUGUI text, out WordHit hit)
		{
			hit = null;
			return false;
		}

		public bool TryAddHighlight(WordHit hit)
		{
			return false;
		}

		private Highlight[] GetExistingHighlightsOf(WordHit wordHit)
		{
			return null;
		}

		public Highlight AddHighlight(WordHit word)
		{
			return null;
		}

		public void RemoveHighlight(Highlight highlight)
		{
		}

		private void Dispose(Highlight highlight)
		{
		}

		[ContextMenu("DisposeAll")]
		public void DisposeAll()
		{
		}
	}
}
