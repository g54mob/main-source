using I18n;
using UnityEngine;

namespace Gh.Tk.UI.InfoPanels
{
	public class PropInfoPanel : GameObjectXInfoPanel
	{
		public TextMeshProI18n QueueInfo;

		private MovePropActionButton3DUIView _moveButton;

		private SellPropActionButton3DUIView _sellButton;

		private TrashPropActionButton3DUIView _trashButton;

		private PriceButtonInfoPanel3DUIView _priceButton;

		private AdditionalOptionsActionButton3DUIView _contextMenuButton;

		[SerializeField]
		private Button3DUIView _scheduleActionButton;

		private DisableGoxActionButton3DUIView _disableGoxActionButton;

		[SerializeField]
		protected Stars3DUIView _starsElement;

		private PropStatBlock3DUIView _propStatBlock;

		public override GameObjectX Gox
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override void Awake()
		{
		}

		public virtual void Start()
		{
		}

		protected void OnIsBrokenChanged(object sender, EventArgs<bool> e)
		{
		}

		protected void OnIsDeadChanged(object sender, EventArgs<bool> e)
		{
		}

		public override void Refresh()
		{
		}

		private void RefreshStars()
		{
		}

		private void RefreshQueueInfoPanel()
		{
		}

		private void RefreshUsagePricePanel()
		{
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}
	}
}
