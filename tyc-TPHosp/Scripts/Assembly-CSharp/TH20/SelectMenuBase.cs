using System;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public abstract class SelectMenuBase : InWorldMenuObject
	{
		protected override void Setup(ICursorSelectable objectSelected, Level level)
		{
			base.Setup(objectSelected, level);
			MetagameMap metagameMap = base.Level.MetagameMap;
			metagameMap.OnOpen = (Action)Delegate.Combine(metagameMap.OnOpen, new Action(OnMetagameMapOpen));
			CameraEvents cameraEvents = base.Level.CameraEvents;
			cameraEvents.OnCameraPan = (Action<float>)Delegate.Combine(cameraEvents.OnCameraPan, new Action<float>(OnCameraPan));
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnCursorSelectObject = (Action<ICursorSelectable>)Delegate.Combine(buildEvents.OnCursorSelectObject, new Action<ICursorSelectable>(OnCursorSelectObject));
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnStaffPickup = (Action<Staff, JobApplicant>)Delegate.Combine(characterEvents.OnStaffPickup, new Action<Staff, JobApplicant>(OnStaffPickup));
			CharacterEvents characterEvents2 = base.Level.CharacterEvents;
			characterEvents2.OnStaffDestroyed = (Action<Staff>)Delegate.Combine(characterEvents2.OnStaffDestroyed, new Action<Staff>(CloseOnStaffAction));
			if (objectSelected.GetCameraTrackObject() != null)
			{
				base.Level.CameraLogic.TrackObject(objectSelected.GetCameraTrackObject().transform);
			}
		}

		public override void Destroy()
		{
			MetagameMap metagameMap = base.Level.MetagameMap;
			metagameMap.OnOpen = (Action)Delegate.Remove(metagameMap.OnOpen, new Action(OnMetagameMapOpen));
			CameraEvents cameraEvents = base.Level.CameraEvents;
			cameraEvents.OnCameraPan = (Action<float>)Delegate.Remove(cameraEvents.OnCameraPan, new Action<float>(OnCameraPan));
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnCursorSelectObject = (Action<ICursorSelectable>)Delegate.Remove(buildEvents.OnCursorSelectObject, new Action<ICursorSelectable>(OnCursorSelectObject));
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnStaffPickup = (Action<Staff, JobApplicant>)Delegate.Remove(characterEvents.OnStaffPickup, new Action<Staff, JobApplicant>(OnStaffPickup));
			CharacterEvents characterEvents2 = base.Level.CharacterEvents;
			characterEvents2.OnStaffDestroyed = (Action<Staff>)Delegate.Remove(characterEvents2.OnStaffDestroyed, new Action<Staff>(CloseOnStaffAction));
			base.Destroy();
		}

		protected override void Update()
		{
			base.Update();
			if (base.Level != null && base.Level.InputManager.GetMouseQuickOnScene(MouseButton.Right))
			{
				CloseMenu();
			}
		}

		public override void CloseMenu()
		{
			if (!IsClosing())
			{
				base.CloseMenu();
				base.Level.InputManager.Flush();
				base.Level.CameraLogic.TrackObject(null);
			}
		}

		protected override void OnMenuOpen(MenuBase menu)
		{
			if (!(menu is HoverMenuBase))
			{
				base.OnMenuOpen(menu);
			}
		}

		private void OnMetagameMapOpen()
		{
			base.HUD.DestroyMenu(this);
		}

		private void OnCameraPan(float distance)
		{
			base.Level.CameraLogic.TrackObject(null);
		}

		private void OnCursorSelectObject(ICursorSelectable cursorSelectable)
		{
			if (cursorSelectable != base.ObjectSelected)
			{
				CloseMenu();
			}
		}

		private void OnStaffPickup(Staff staff, JobApplicant jobApplicant)
		{
			CloseOnStaffAction(staff);
		}

		private void CloseOnStaffAction(Staff staff)
		{
			if (staff == base.ObjectSelected)
			{
				CloseMenu();
			}
		}
	}
}
