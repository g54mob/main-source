using System;
using System.Collections.Generic;
using UnityEngine;

namespace GRP
{
	public class Highlightable : MonoBehaviour
	{
		public List<Highlight> highlights;

		public Action onHighlightChanged;

		public void Clear()
		{
		}

		public void InsertHighlight(int index, Highlight highlight)
		{
		}

		public void AddHighlight(Highlight highlight)
		{
		}

		public void RemoveHighlight(Highlight highlight)
		{
		}
	}
}
