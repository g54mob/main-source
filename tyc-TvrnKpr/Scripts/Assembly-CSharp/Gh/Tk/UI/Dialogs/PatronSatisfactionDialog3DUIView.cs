using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class PatronSatisfactionDialog3DUIView : BaseDialog3DUIView
	{
		public PatronSatisfactionChart chart;

		public Button3DUIView closeButton;

		public Container3DUIView buttonContainer;

		[SerializeField]
		private PatronSatisfactionCategoryButton3DUIView categoryButtonTemplate;

		[SerializeField]
		private Transform _starButtonsParent;

		[SerializeField]
		private DissolveArea3DUIView _dissolveArea;

		private AnimationEventObserver _animationEventObserver;

		private Button3DUIView[] _starButtons;

		private static List<int> _activeTiers;

		private string _currentCategory;

		private Dictionary<string, int> _averageSatisfactionByCategory;

		protected override void Awake()
		{
		}

		private void OnStarButtonClicked(int tier)
		{
		}

		private void UpdateTierBrackets()
		{
		}

		public void Start()
		{
		}

		private static IEnumerable<string> GetCategories()
		{
			return null;
		}

		protected override void CloseInternal(ShowHideAnimationSpeed speed)
		{
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		private void UpdateTextDissolves()
		{
		}

		protected override void Closed()
		{
		}

		private void Refresh()
		{
		}

		private void RefreshPatronStars()
		{
		}

		private void RefreshFilterButtons()
		{
		}

		private void RefreshWithFilter()
		{
		}

		private void UpdateFilterButtonStates()
		{
		}
	}
}
