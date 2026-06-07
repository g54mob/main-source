using UnityEngine;
using UnityEngine.UIElements;

namespace Brewery.Map
{
	public class MapHoverTooltipController : MonoBehaviour
	{
		private const string TEMPLATE_PATH = "UI/MapHoverTooltip";

		private const string STYLESHEET_PATH = "UI/MapHoverTooltip";

		private VisualElement tooltipRoot;

		private Label titleLabel;

		private Label subtitleLabel;

		private VisualElement sectionsContainer;

		private VisualElement resetProgressSection;

		private Label resetLabel;

		private ProgressBar resetProgressBar;

		private UIDocument uiDocument;

		private bool isInitialized;

		private IMapIconHoverProvider currentProvider;

		private Vector2 currentScreenPosition;

		public static MapHoverTooltipController Instance { get; private set; }

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Initialize()
		{
		}

		public void ShowTooltip(IMapIconHoverProvider provider, Vector2 screenPosition)
		{
		}

		public void HideTooltip()
		{
		}

		public void RefreshContent()
		{
		}

		public void UpdatePosition(Vector2 screenPosition)
		{
		}

		private void AddSection(HoverInfoSection section)
		{
		}

		private void PositionTooltip(Vector2 screenPosition)
		{
		}

		public void ShowResetProgress(string vehicleName)
		{
		}

		public void UpdateResetProgress(float progress)
		{
		}

		public void HideResetProgress()
		{
		}

		public bool IsResetProgressVisible()
		{
			return false;
		}

		private void OnDestroy()
		{
		}
	}
}
