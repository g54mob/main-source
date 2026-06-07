using System;
using System.Runtime.CompilerServices;
using UnityEngine.UIElements;

namespace Brewery.UI.Shared
{
	public class StationOutputManager
	{
		private VisualElement overlay;

		private VisualElement icon;

		private Label countLabel;

		private Label messageLabel;

		private Button collectButton;

		private Button continueButton;

		private readonly string singularMessage;

		private readonly string pluralMessage;

		private readonly string outputItemId;

		public bool IsVisible { get; private set; }

		public event Action OnCollectClicked
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

		public event Action OnContinueClicked
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

		public StationOutputManager(string outputItemId, string singularMessage, string pluralMessage)
		{
		}

		public void CacheReferences(VisualElement panelRoot)
		{
		}

		public void Show(int count)
		{
		}

		public void Hide()
		{
		}

		public void UpdateCount(int count)
		{
		}

		public Button GetCollectButton()
		{
			return null;
		}

		public Button GetContinueButton()
		{
			return null;
		}
	}
}
