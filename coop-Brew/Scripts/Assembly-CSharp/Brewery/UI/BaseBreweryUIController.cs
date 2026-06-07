using Brewery.UI.Components;
using UI;
using UI.Core;
using UnityEngine;
using UnityEngine.UIElements;

namespace Brewery.UI
{
	public abstract class BaseBreweryUIController : MonoBehaviour, IUIPanel
	{
		protected VisualElement root;

		protected VisualElement container;

		private bool isUIVisible;

		private const string DefaultStylesheetPath = "UI/Brewery";

		protected VisualTreeAsset template;

		protected StyleSheet breweryStyles;

		protected TabManager tabManager;

		protected BadgeManager badgeManager;

		[Header("UI Sounds")]
		[Tooltip("Enable default open/close sounds for this panel.")]
		[SerializeField]
		protected bool enableDefaultSounds;

		[Tooltip("Custom sounds to play when opening this panel (overrides default station sounds).")]
		[SerializeField]
		protected AudioClip[] customOpenClips;

		[Tooltip("Custom sounds to play when closing this panel (overrides default station sounds).")]
		[SerializeField]
		protected AudioClip[] customCloseClips;

		public bool IsShowing => false;

		public virtual string PanelId => null;

		public virtual int Priority => 0;

		public bool IsOpen => false;

		protected virtual PanelAnimSpeed PanelAnimationSpeed => default(PanelAnimSpeed);

		public void Close()
		{
		}

		protected virtual void Awake()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		protected abstract void RegisterSingleton();

		protected abstract VisualElement GetContainer();

		protected virtual void OnUIHiding()
		{
		}

		protected void BuildUIFromTemplate(string templatePath, string containerName, string stylesheetPath = null)
		{
		}

		protected void ShowUIInternal()
		{
		}

		public void HideUI()
		{
		}

		protected void RegisterKeyboardCallbacks()
		{
		}

		protected void UnregisterKeyboardCallbacks()
		{
		}

		private void HandleKeyDownEvent(KeyDownEvent evt)
		{
		}

		protected virtual void HandleCustomKeys(KeyDownEvent evt)
		{
		}
	}
}
