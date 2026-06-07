using System.Collections.Generic;
using DV.Highlighting;
using DV.Utils;
using UnityEngine;

namespace DV.Interaction
{
	[RequireComponent(typeof(Grabber))]
	public class GrabberHoverHighlight : MonoBehaviour
	{
		private IGrabberRaycaster grabberRaycaster;

		private Grabber grabber;

		private AGrabHandler oldHandler;

		private readonly List<Renderer> renderers = new List<Renderer>();

		private void Awake()
		{
			grabberRaycaster = GetComponent<IGrabberRaycaster>();
			grabber = GetComponent<Grabber>();
			grabberRaycaster.Hovered += OnHover;
			grabberRaycaster.UnHovered += OnUnHover;
		}

		private void Update()
		{
		}

		private void OnHover(AGrabHandler grabHandler)
		{
			GameObject gameObject = grabHandler.gameObject;
			AGeneralHighlighter.HighlightType type = ((gameObject.GetComponent<GrabHandlerItem>() != null) ? AGeneralHighlighter.HighlightType.Item : AGeneralHighlighter.HighlightType.Control);
			if (GetRenderers(gameObject, renderers))
			{
				foreach (Renderer renderer in renderers)
				{
					SingletonBehaviour<AGeneralHighlighter>.Instance.ToggleHighlight(on: true, renderer, type, useObstructedMaterial: true);
				}
			}
			else
			{
				Clear();
			}
			IHoverReaction[] components = gameObject.GetComponents<IHoverReaction>();
			for (int i = 0; i < components.Length; i++)
			{
				components[i].OnHovered();
			}
		}

		private void OnUnHover(AGrabHandler grabHandler)
		{
			GameObject gameObject = ((grabHandler != null) ? grabHandler.gameObject : null);
			if (gameObject != null)
			{
				IHoverReaction[] components = gameObject.GetComponents<IHoverReaction>();
				for (int i = 0; i < components.Length; i++)
				{
					components[i].OnUnhovered();
				}
			}
			Clear();
		}

		private void Clear()
		{
			SingletonBehaviour<AGeneralHighlighter>.Instance.ClearHighlights(AGeneralHighlighter.HighlightType.Item);
			SingletonBehaviour<AGeneralHighlighter>.Instance.ClearHighlights(AGeneralHighlighter.HighlightType.Control);
		}

		private bool GetRenderers(GameObject go, List<Renderer> results)
		{
			renderers.Clear();
			HighlightTag componentInChildren = go.GetComponentInChildren<HighlightTag>();
			if (componentInChildren != null)
			{
				renderers.AddRange(componentInChildren.renderers);
			}
			else
			{
				Renderer componentInChildren2 = go.GetComponentInChildren<Renderer>();
				if (componentInChildren2 != null)
				{
					renderers.Add(componentInChildren2);
				}
			}
			return results.Count != 0;
		}
	}
}
