using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.UI.InfoPanels
{
	public class RoomInfoPanel : InfoPanel
	{
		public Button3DUIView OpenScheduleButton;

		public RoomAssignmentButton3DUIView StaffAssignmentModeButton;

		[SerializeField]
		private Button3DUIView _zoneAsButton;

		[SerializeField]
		private Button3DUIView _policyButton;

		[SerializeField]
		private Container3DUIView _buttonContainer;

		public GameObject PreviewParent;

		private GameObject _model;

		[SerializeField]
		private RoomStars3DUIView _starsElement;

		public GameObject _nextPreviousButtonContainer;

		public Button3DUIView _nextButton;

		public Button3DUIView _previousButton;

		[SerializeField]
		protected TraitsContainer3DUIView _traitsContainer;

		[SerializeField]
		private UnlockRoomActionButton3DUIView _unlockRoomButton;

		[SerializeField]
		private Transform[] _elementsToDisableIfRoomIsLocked;

		private Room _room;

		public virtual Room Room
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal void InvalidateRoomLockedElementVisibility()
		{
		}

		protected IEnumerable<GameObjectX> GetObjectsToCycle()
		{
			return null;
		}

		private void OnCurrentZoneChanged(object sender, EventArgs<RoomZone> e)
		{
		}

		public virtual void Start()
		{
		}

		public void Refresh()
		{
		}

		public override void ShowInfo(GameObjectX gox)
		{
		}

		private void UpdateTraits()
		{
		}

		private void AiComponentRemoved(object sender, GameObjectX.GameObjectXEventArgs<AiComponent> e)
		{
		}

		private void AiComponentAdded(object sender, GameObjectX.GameObjectXEventArgs<AiComponent> e)
		{
		}

		protected override void Awake()
		{
		}
	}
}
