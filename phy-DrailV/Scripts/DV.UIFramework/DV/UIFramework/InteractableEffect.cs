using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UIFramework
{
	[RequireComponent(typeof(IHoverable))]
	public class InteractableEffect : MonoBehaviour
	{
		public const string ICON_PREFIX = "[icon]";

		public const string TMPRO_PREFIX = "[text]";

		private const float NON_INTERACTABLE_ALPHA = 0.4f;

		private const float ANIM_DURATION = 0.1f;

		public List<Graphic> graphicsToFade = new List<Graphic>();

		public bool skipAutoAssign;

		private IHoverable interactable;

		private TextMeshProUGUI[] tmPros;

		private void Awake()
		{
			if (!TryGetComponent<IHoverable>(out interactable))
			{
				Debug.LogError("No IHoverable found on InteractableEffect!", this);
				return;
			}
			if (graphicsToFade == null)
			{
				graphicsToFade = new List<Graphic>();
			}
			if (!skipAutoAssign)
			{
				Util.FindInChildrenAndAddMultiple(base.gameObject, "[icon]", graphicsToFade, logMissing: false);
				Util.FindInChildrenAndAddMultiple(base.gameObject, "[text]", graphicsToFade, logMissing: false);
			}
			SetupListeners(on: true);
		}

		private void OnEnable()
		{
			OnInteractableChanged(interactable);
		}

		private void OnDestroy()
		{
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				interactable.InteractabilityChanged += OnInteractableChanged;
			}
			else
			{
				interactable.InteractabilityChanged -= OnInteractableChanged;
			}
		}

		private void OnInteractableChanged(IHoverable sender)
		{
			foreach (Graphic item in graphicsToFade)
			{
				item.CrossFadeAlpha(sender.IsInteractable ? 1f : 0.4f, 0.1f, ignoreTimeScale: true);
			}
		}
	}
}
