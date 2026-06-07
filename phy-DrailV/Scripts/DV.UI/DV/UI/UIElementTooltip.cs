using DV.Localization;
using DV.UIFramework;
using UnityEngine;

namespace DV.UI
{
	[DisallowMultipleComponent]
	public class UIElementTooltip : MonoBehaviour, ITooltip
	{
		private const string SUFFIX_ENABLED = "__tooltip";

		private const string SUFFIX_DISABLED = "__tooltip_disabled";

		public IHoverable hoverable;

		public string enabledKey;

		public string disabledKey;

		protected IMarkable markable;

		protected TooltipHandler tooltipHandler;

		protected bool attemptedGetCustom;

		protected UIElementTooltipCustomText customText;

		private bool initialized;

		public ITooltipIcons TooltipIcons { get; private set; }

		private void Start()
		{
			tooltipHandler = base.transform.GetComponentInParentIncludingInactive<TooltipHandler>();
			if (tooltipHandler == null)
			{
				base.enabled = false;
				return;
			}
			if (hoverable == null)
			{
				hoverable = GetComponentInParent<IHoverable>();
			}
			if (hoverable == null)
			{
				Debug.LogWarning("Reference to IHoverable not found. Tooltip for '" + base.name + "' will be disabled.", this);
				base.enabled = false;
				return;
			}
			markable = hoverable as IMarkable;
			TooltipIcons = GetComponentInChildren<ITooltipIcons>(includeInactive: true);
			ResolveTranslationKeys();
			InitializeAdditional();
			initialized = true;
			SetupListeners(on: true);
		}

		protected virtual void InitializeAdditional()
		{
		}

		private void OnEnable()
		{
			if (initialized && markable != null && markable.IsMarked)
			{
				tooltipHandler.UpdateTooltipText();
			}
		}

		private void OnDisable()
		{
			if (initialized && markable != null && markable.IsMarked)
			{
				tooltipHandler.UpdateTooltipText();
			}
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				hoverable.MouseOverChanged += OnHoverChanged;
				hoverable.InteractabilityChanged += OnInteractabilityChanged;
				if (markable != null)
				{
					markable.MarkChanged += OnMarkChanged;
				}
			}
			else
			{
				hoverable.MouseOverChanged -= OnHoverChanged;
				hoverable.InteractabilityChanged -= OnInteractabilityChanged;
				if (markable != null)
				{
					markable.MarkChanged -= OnMarkChanged;
				}
			}
		}

		private void OnHoverChanged(IHoverable _)
		{
			if (tooltipHandler != null)
			{
				if (hoverable.IsMouseOvered)
				{
					tooltipHandler.AddTooltipAndUpdate(this);
				}
				else if (markable == null || !markable.IsMarked)
				{
					tooltipHandler.RemoveTooltipAndUpdate(this);
				}
			}
		}

		private void OnMarkChanged(IMarkable _)
		{
			if (tooltipHandler != null)
			{
				if (markable.IsMarked)
				{
					tooltipHandler.AddTooltipAndUpdate(this);
				}
				else if (!markable.IsMouseOvered)
				{
					tooltipHandler.RemoveTooltipAndUpdate(this);
				}
			}
		}

		private void OnInteractabilityChanged(IHoverable _)
		{
			OnHoverChanged(_);
		}

		public virtual string GetText()
		{
			if (!attemptedGetCustom)
			{
				attemptedGetCustom = true;
				customText = GetComponentInChildren<UIElementTooltipCustomText>(includeInactive: true);
				if (customText != null)
				{
					customText.TextChanged += OnCustomTextChanged;
				}
			}
			if (customText != null && customText.enabled)
			{
				return customText.GetText();
			}
			string result = (LocalizationAPI.HasTranslation(enabledKey) ? LocalizationAPI.L(enabledKey) : "");
			string text = (LocalizationAPI.HasTranslation(disabledKey) ? LocalizationAPI.L(disabledKey) : "");
			if (hoverable.IsInteractable || string.IsNullOrWhiteSpace(text))
			{
				return result;
			}
			return text;
		}

		private void OnCustomTextChanged(UIElementTooltipCustomText sender)
		{
			tooltipHandler.UpdateTooltipText();
		}

		public GameObject GetGameObject()
		{
			return base.gameObject;
		}

		private void ResolveTranslationKeys()
		{
			string _locKey = null;
			if (string.IsNullOrEmpty(enabledKey) && !string.IsNullOrEmpty(FindLoc()))
			{
				enabledKey = _locKey + "__tooltip";
			}
			if (string.IsNullOrEmpty(disabledKey) && !string.IsNullOrEmpty(FindLoc()))
			{
				disabledKey = _locKey + "__tooltip_disabled";
			}
			string FindLoc()
			{
				if (_locKey == null)
				{
					_locKey = hoverable.GetGameObject().GetComponentInChildren<Localize>(includeInactive: true)?.key ?? "";
				}
				return _locKey;
			}
		}
	}
}
