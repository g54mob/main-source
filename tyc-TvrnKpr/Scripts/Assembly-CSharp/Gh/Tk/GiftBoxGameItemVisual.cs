using System;

namespace Gh.Tk
{
	public class GiftBoxGameItemVisual : GameItemVisual
	{
		public static EventHandler GiftBoxGameItemVisualsChanged;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public new GiftBoxItem GameItem
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[PersistenceOptIn]
		public bool IsReadyToOpen { get; set; }

		protected GiftBoxGameItemVisual()
		{
		}

		public override void Awake()
		{
		}

		private void OnClicked()
		{
		}

		private void OpenBox(float delay)
		{
		}

		public override void Start()
		{
		}

		public override void OnDestroy()
		{
		}
	}
}
