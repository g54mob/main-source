using System.Collections.Generic;

namespace Gh.Tk.UI.InfoPanels
{
	public abstract class InfoPanel : ShowHideAnimation3DUIView
	{
		public DevCommentaryMarkerMonoBehaviour[] devCommentaryMarkerSlots;

		public bool isBlockingNotificationArea;

		private bool _isInfoElementsInitialized;

		protected List<IGoxInfoElement> _goxInfoElements;

		protected override void Awake()
		{
		}

		protected void OnInfoPanelTargetSwitched()
		{
		}

		public virtual void ShowInfo(GameObjectX gox)
		{
		}

		public virtual void ShowInfo(MapMarker mapMarker)
		{
		}

		private void RefreshDevCommentaries(GameObjectX gox)
		{
		}

		protected override void PlayOnOpenSound(ShowHideAnimationSpeed speed)
		{
		}

		protected override void PlayOnCloseSound(ShowHideAnimationSpeed speed)
		{
		}

		public override void Open(ShowHideAnimationSpeed speed)
		{
		}

		protected override void OnDisable()
		{
		}

		protected override void CloseInternal(ShowHideAnimationSpeed speed)
		{
		}

		protected override bool CanOpen(ShowHideAnimationSpeed speed)
		{
			return false;
		}

		protected override bool CanClose(ShowHideAnimationSpeed speed, bool forceClose)
		{
			return false;
		}

		private void InitInfoElements()
		{
		}

		protected void SetInfoElements(GameObjectX gox)
		{
		}

		protected void RefreshInfoElements()
		{
		}
	}
}
