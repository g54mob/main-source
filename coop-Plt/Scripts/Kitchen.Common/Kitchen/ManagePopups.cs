using System.Collections.Generic;
using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class ManagePopups : GenericSystemBase
	{
		public struct CManagedPopup : IComponentData
		{
			public PopupType PopupType;
		}

		public struct CPopupRequest : IComponentData
		{
			public PopupType PopupType;
		}

		private EntityQuery Requests;

		private EntityQuery Popups;

		private readonly Dictionary<PopupType, PopupManager> Managers = new Dictionary<PopupType, PopupManager>();

		protected override void Initialise()
		{
			base.Initialise();
			Requests = GetEntityQuery(typeof(CPopupRequest));
			Popups = GetEntityQuery(typeof(CManagedPopup));
		}

		public override void PostInitialisation()
		{
			base.PostInitialisation();
			foreach (ComponentSystemBase system in base.World.Systems)
			{
				if (system is PopupManager popupManager)
				{
					Managers.Add(popupManager.ManagedType, popupManager);
				}
			}
		}

		protected override void OnUpdate()
		{
			using NativeArray<CManagedPopup> nativeArray = Popups.ToComponentDataArray<CManagedPopup>(Allocator.Temp);
			using NativeArray<Entity> nativeArray2 = Popups.ToEntityArray(Allocator.Temp);
			for (int i = 0; i < nativeArray2.Length; i++)
			{
				if (Managers.TryGetValue(nativeArray[i].PopupType, out var value))
				{
					if (value.UpdatePopup(nativeArray2[i]))
					{
						SetComponent(nativeArray2[i], new CPopup
						{
							Dismiss = true
						});
					}
				}
				else
				{
					Debug.LogWarning($"Unmanaged popup present with identifier {nativeArray[i].PopupType} (entity {nativeArray2[i]})");
					SetComponent(nativeArray2[i], new CPopup
					{
						Dismiss = true
					});
				}
			}
			using NativeArray<CPopupRequest> nativeArray3 = Requests.ToComponentDataArray<CPopupRequest>(Allocator.Temp);
			using NativeArray<Entity> nativeArray4 = Requests.ToEntityArray(Allocator.Temp);
			for (int j = 0; j < nativeArray4.Length; j++)
			{
				if (Managers.TryGetValue(nativeArray3[j].PopupType, out var value2))
				{
					value2.CreateNewPopup(nativeArray4[j]);
				}
				else
				{
					Debug.LogWarning($"Unmanaged popup requested with identifier {nativeArray[j].PopupType} (entity {nativeArray2[j]})");
				}
			}
			base.EntityManager.DestroyEntity(Requests);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
