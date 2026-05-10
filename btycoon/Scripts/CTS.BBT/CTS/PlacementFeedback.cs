using System.Collections.Generic;
using CTS.Core.Utilities;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class PlacementFeedback : MonoBehaviour
	{
		private List<PlacementFeedback> _children = new List<PlacementFeedback>();

		private readonly Dictionary<Renderer, Color> _originalColors = new Dictionary<Renderer, Color>();

		private bool _shown;

		private static readonly int _shaderBaseColor = Shader.PropertyToID("_BaseColor");

		private static readonly int _shaderColor = Shader.PropertyToID("_Color");

		[field: ShowNonSerializedField]
		public SpriteRenderer Renderer { get; private set; }

		[field: ShowNonSerializedField]
		public BoxCollider Box { get; private set; }

		[field: ShowNonSerializedField]
		public Renderer[] Renderers { get; private set; }

		public ReadOnlyList<PlacementFeedback> Children => _children;

		public void Setup(SpriteRenderer renderer, BoxCollider box)
		{
			Renderer = renderer;
			Renderer.material = Object.Instantiate(Renderer.material);
			Box = box;
			Vector3 localPosition = Box.transform.localPosition + box.center;
			localPosition.y = 0.01f;
			Renderer.transform.localPosition = localPosition;
			Renderer.size = new Vector2(box.size.x, box.size.z) * 10f;
		}

		public void SetRenderers(Renderer[] renderers)
		{
			Renderers = renderers;
			Renderer[] renderers2 = Renderers;
			foreach (Renderer renderer in renderers2)
			{
				if (renderer.sharedMaterial.HasProperty(_shaderBaseColor))
				{
					_originalColors[renderer] = renderer.sharedMaterial.GetColor(_shaderBaseColor);
				}
			}
		}

		public void SetRenderersColor(Color? color)
		{
			if (Renderers == null)
			{
				return;
			}
			if (!color.HasValue)
			{
				Renderer[] renderers = Renderers;
				foreach (Renderer renderer in renderers)
				{
					if (_originalColors.TryGetValue(renderer, out var value))
					{
						renderer.material.SetColor(_shaderBaseColor, value);
					}
				}
			}
			else
			{
				Renderer[] renderers = Renderers;
				for (int i = 0; i < renderers.Length; i++)
				{
					renderers[i].material.SetColor(_shaderBaseColor, color.Value);
				}
			}
		}

		public void Show(bool show)
		{
			_shown = show;
			if (Renderer != null && Renderer.gameObject != null)
			{
				Renderer?.gameObject.SetActive(show);
			}
			foreach (PlacementFeedback child in _children)
			{
				child.Show(show);
			}
		}

		public void SetColor(Color color)
		{
			if (Renderer != null && Renderer.gameObject != null)
			{
				Renderer?.material.SetColor(_shaderColor, color);
			}
			foreach (PlacementFeedback child in _children)
			{
				child.SetColor(color);
			}
		}

		public void AddChild(PlacementFeedback placementFeedback)
		{
			if (!_children.Contains(placementFeedback))
			{
				_children.Add(placementFeedback);
				if (_shown)
				{
					Show(show: true);
				}
			}
		}

		public void RemoveChild(PlacementFeedback placementFeedback)
		{
			_children.Remove(placementFeedback);
		}
	}
}
