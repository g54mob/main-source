using System;
using System.Collections.Generic;
using System.Linq;
using DV.Utils;
using UnityEngine;

namespace DV.Highlighting
{
	public abstract class AGeneralHighlighter : SingletonBehaviour<AGeneralHighlighter>
	{
		public enum HighlightType
		{
			Generic = 0,
			Sign = 1,
			Control = 2,
			Item = 3
		}

		public class HighlightTypeRuntimeValues
		{
			public Func<bool> condition;

			public HashSet<(Renderer renderer, bool useObstructedMaterial)> renderers = new HashSet<(Renderer, bool)>();
		}

		public static readonly Color DEFAULT_COLOR = Color.white;

		private List<(Renderer renderer, bool useObstructedMaterial)> toBeRemovedList = new List<(Renderer, bool)>();

		protected Dictionary<HighlightType, HighlightTypeRuntimeValues> highlightTypeRuntimeHelpers = new Dictionary<HighlightType, HighlightTypeRuntimeValues>();

		public int CurrentlyHighlightedCount
		{
			get
			{
				int num = 0;
				foreach (HighlightTypeRuntimeValues value in highlightTypeRuntimeHelpers.Values)
				{
					num += value.renderers.Count;
				}
				return num;
			}
		}

		public new static string AllowAutoCreate()
		{
			return null;
		}

		public void RefreshConditions()
		{
			foreach (HighlightType key in highlightTypeRuntimeHelpers.Keys)
			{
				RefreshCondition(key);
			}
		}

		public void RefreshCondition(HighlightType type)
		{
			if (highlightTypeRuntimeHelpers.TryGetValue(type, out var value) && !value.condition())
			{
				ClearHighlights(type);
			}
		}

		public void ClearHighlights(HighlightType type)
		{
			if (!highlightTypeRuntimeHelpers.TryGetValue(type, out var value))
			{
				return;
			}
			foreach (var item in value.renderers.ToList())
			{
				if ((bool)item.renderer)
				{
					ToggleHighlight(on: false, item.renderer, type, item.useObstructedMaterial, forced: true);
				}
			}
			value.renderers.Clear();
		}

		public void PruneNullHighlights()
		{
			foreach (HighlightTypeRuntimeValues value in highlightTypeRuntimeHelpers.Values)
			{
				foreach (var renderer in value.renderers)
				{
					if (!renderer.renderer)
					{
						toBeRemovedList.Add(renderer);
					}
				}
				foreach (var toBeRemoved in toBeRemovedList)
				{
					value.renderers.Remove(toBeRemoved);
				}
				toBeRemovedList.Clear();
			}
		}

		public void ToggleHighlight(bool on, Renderer renderer, HighlightType type, bool useObstructedMaterial, bool forced = false)
		{
			ToggleHighlight(on, renderer, type, useObstructedMaterial, DEFAULT_COLOR, forced);
		}

		public void ToggleHighlight(bool on, Renderer renderer, HighlightType type, bool useObstructedMaterial, Color color, bool forced = false)
		{
			if (highlightTypeRuntimeHelpers.TryGetValue(type, out var value) && (forced || value.condition()) && !(renderer == null))
			{
				if (on)
				{
					AddHighlight(renderer, useObstructedMaterial, color);
					value.renderers.Add((renderer, useObstructedMaterial));
				}
				else
				{
					RemoveHighlight(renderer, useObstructedMaterial);
					value.renderers.Remove((renderer, useObstructedMaterial));
				}
				PruneNullHighlights();
			}
		}

		public void ToggleHighlight(bool on, HighlightTag tag, HighlightType type, bool useObstructedMaterial, bool forced = false)
		{
			ToggleHighlight(on, tag, type, useObstructedMaterial, DEFAULT_COLOR, forced);
		}

		public void ToggleHighlight(bool on, HighlightTag tag, HighlightType type, bool useObstructedMaterial, Color color, bool forced = false)
		{
			if (tag == null || tag.renderers == null)
			{
				return;
			}
			foreach (Renderer renderer in tag.renderers)
			{
				ToggleHighlight(on, renderer, type, useObstructedMaterial, color, forced);
			}
		}

		protected abstract void AddHighlight(Renderer renderer, bool useObstructedMaterial, Color color);

		protected abstract void RemoveHighlight(Renderer renderer, bool useObstructedMaterial);
	}
}
