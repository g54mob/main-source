using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class PopupUtilities : Kitchen.Utility
	{
		public Entity RequestManagedPopup(PopupType type)
		{
			Entity entity = base.EntityManager.CreateEntity(typeof(ManagePopups.CPopupRequest));
			base.EntityManager.SetComponentData(entity, new ManagePopups.CPopupRequest
			{
				PopupType = type
			});
			return entity;
		}

		public Entity RequestManagedPopup<T>(PopupType type, T data) where T : struct, IManagedPopupData
		{
			Entity entity = base.EntityManager.CreateEntity(typeof(ManagePopups.CPopupRequest));
			base.EntityManager.SetComponentData(entity, new ManagePopups.CPopupRequest
			{
				PopupType = type
			});
			base.EntityManager.AddComponentData(entity, data);
			return entity;
		}

		public Entity CreateGenericPopup(GenericChoiceType choice_type, PopupType popup_type, Vector2 location)
		{
			Entity entity = CreatePopup(ViewType.GenericChoicePopup, location, popup_type);
			base.EntityManager.AddComponentData(entity, new CGenericChoicePopup
			{
				Type = choice_type,
				TextSet = popup_type
			});
			return entity;
		}

		public Entity CreateGenericPopup<T>(GenericChoiceType choice_type, PopupType popup_type, Vector2 location) where T : struct, IComponentData
		{
			Entity entity = CreateGenericPopup(choice_type, popup_type, location);
			base.EntityManager.AddComponent<T>(entity);
			return entity;
		}

		public Entity CreatePopup(ViewType view_type, Vector2 location, PopupType type)
		{
			int priority = KitchenData.PopupPriority.Get(type);
			Entity entity = base.EntityManager.CreateEntity(typeof(CPopup), typeof(ManagePopups.CManagedPopup), typeof(CHideView), typeof(CPosition), typeof(CGamePauseRequest), typeof(CRequiresView), typeof(CCaptureInput));
			base.EntityManager.SetComponentData(entity, new CPosition(location));
			base.EntityManager.SetComponentData(entity, new ManagePopups.CManagedPopup
			{
				PopupType = type
			});
			base.EntityManager.SetComponentData(entity, new CRequiresView
			{
				ViewMode = ViewMode.Screen,
				Type = view_type
			});
			base.EntityManager.SetComponentData(entity, new CPopup
			{
				Priority = priority
			});
			base.EntityManager.SetComponentData(entity, new CCaptureInput
			{
				AllUsers = true
			});
			return entity;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
