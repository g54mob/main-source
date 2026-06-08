using System;
using System.Collections.Generic;
using Controllers;
using Platforms;
using UnityEngine;

namespace Kitchen
{
	public class LocalViewRouter : IViewRouter
	{
		private struct CachedBroadcast
		{
			public ViewIdentifier View;

			public IViewData Data;

			public MessageType Type;

			public int Lifetime;
		}

		private AssetDirectory AssetDirectory;

		private Dictionary<ViewType, GameObject> Containers;

		private EntityViewManager Manager;

		private Transform UIContainer;

		private ViewBoundsMaintainer BoundsMaintainer;

		private Bounds UICamBounds;

		private IViewRouter ResponseTarget;

		private HashSet<ViewIdentifier> SuppressErrors = new HashSet<ViewIdentifier>();

		private Queue<CachedBroadcast> CachedBroadcasts;

		private Dictionary<ViewIdentifier, UpdateViewPositionData> PositionCache = new Dictionary<ViewIdentifier, UpdateViewPositionData>();

		public LocalViewRouter(AssetDirectory directory, EntityViewManager manager, Transform ui_container, ViewBoundsMaintainer bounds_maintainer, Bounds ui_bounds)
		{
			AssetDirectory = directory;
			UIContainer = ui_container;
			Manager = manager;
			BoundsMaintainer = bounds_maintainer;
			Containers = new Dictionary<ViewType, GameObject>();
			CachedBroadcasts = new Queue<CachedBroadcast>();
			UpdateBounds(ui_bounds);
		}

		public void UpdateBounds(Bounds ui_bounds)
		{
			UICamBounds = ui_bounds;
		}

		public void SetBroadcastTarget(IViewRouter router)
		{
			ResponseTarget = router;
		}

		public void Update()
		{
			int count = CachedBroadcasts.Count;
			for (int i = 0; i < count; i++)
			{
				CachedBroadcast cachedBroadcast = CachedBroadcasts.Dequeue();
				if (cachedBroadcast.Lifetime > 0 && !HandleUpdate(cachedBroadcast.View, cachedBroadcast.Data, cachedBroadcast.Type))
				{
					CacheUpdate(cachedBroadcast.View, cachedBroadcast.Data, cachedBroadcast.Type, cachedBroadcast.Lifetime - 1);
				}
			}
			foreach (KeyValuePair<ViewIdentifier, IObjectView> entityView in Manager.EntityViews)
			{
				entityView.Value.PerformUpdate();
				if (entityView.Value is IResponsiveObject responsiveObject && responsiveObject.HasStateUpdate(out var state))
				{
					BroadcastCommand(new ResponseUpdateCommand(state, responsiveObject.ResponseType, entityView.Key));
				}
			}
			UpdateScreenPositions();
		}

		public void BroadcastUpdate<T>(ViewIdentifier id, T data, MessageType type = MessageType.ViewUpdate) where T : IViewData
		{
			if (!HandleUpdate(id, data, type))
			{
				CacheUpdate(id, data, type, 10);
			}
		}

		private void CacheUpdate(ViewIdentifier entity, IViewData data, MessageType type, int lifetime)
		{
			CachedBroadcasts.Enqueue(new CachedBroadcast
			{
				View = entity,
				Data = data,
				Type = type,
				Lifetime = lifetime - 1
			});
		}

		private bool HandleUpdate<T>(ViewIdentifier e, T data, MessageType type = MessageType.ViewUpdate) where T : IViewData
		{
			try
			{
				IObjectView view2;
				switch (type)
				{
				case MessageType.ViewUpdate:
					if (!GetView(e, out view2))
					{
						return false;
					}
					UpdateView(e, data);
					return true;
				case MessageType.ViewPositionUpdate:
					if (!GetView(e, out view2))
					{
						return false;
					}
					if (data is UpdateViewPositionData pos)
					{
						UpdateViewPosition(e, pos);
					}
					return true;
				case MessageType.ViewReparent:
					if (!GetView(e, out view2))
					{
						return false;
					}
					if (data is ItemHolderView.ItemHolderData data2)
					{
						if (!data2.Item.IsNullEntity && !GetView(data2.Item, out view2))
						{
							return false;
						}
						UpdateViewParent(e, data2);
					}
					return true;
				case MessageType.SpecificViewUpdate:
					if (!GetView(e, out view2))
					{
						return false;
					}
					if (data is ISpecificViewData specific_view_data)
					{
						if (!UpdateSpecificView(e, specific_view_data))
						{
							return false;
						}
					}
					else
					{
						Debug.LogWarning($"Specific broadcast contained non-specific data {e}");
					}
					return true;
				case MessageType.CreateView:
					if (data is CreateViewData createViewData)
					{
						CreateNewView(e, createViewData.ViewType, createViewData.ViewMode, createViewData.IsRedraw);
					}
					else
					{
						Debug.LogWarning("Create view broadcast without create view data");
					}
					return true;
				case MessageType.DestroyView:
					if (!GetView(e, out view2))
					{
						return false;
					}
					if (data is DestroyViewData destroyViewData)
					{
						if (destroyViewData.PurgeCacheOnly)
						{
							return true;
						}
						RemoveView(e);
					}
					else
					{
						Debug.LogWarning("Destroy view broadcast without destroy view data");
					}
					return true;
				case MessageType.MaintainInBounds:
				{
					if (!GetView(e, out var view))
					{
						return false;
					}
					if (data is MaintainInViewData mvd)
					{
						mvd.View = e;
						MaintainInView(mvd, view);
					}
					else
					{
						Debug.LogWarning("Maintain in view broadcast without correct data");
					}
					return true;
				}
				default:
					return true;
				}
			}
			catch (Exception arg)
			{
				if (PlatformSettings.IsEditor)
				{
					if (SuppressErrors.Contains(e))
					{
						return false;
					}
					SuppressErrors.Add(e);
				}
				Debug.LogError($"Failed to update view {e}/{type}");
				Debug.LogError($"Failed to update view {arg}/{type}");
				return false;
			}
		}

		public void BroadcastCommand<T>(T update) where T : ICommandUpdate
		{
			ICommandUpdate commandUpdate = update;
			if (commandUpdate == null || !(commandUpdate.SourceIdentifier != InputSourceIdentifier.Identifier))
			{
				ResponseTarget?.BroadcastCommand(update);
			}
		}

		private GameObject GetPrefab(ViewType view_type)
		{
			return AssetDirectory.ViewPrefabs[view_type];
		}

		private bool GetView(ViewIdentifier e, out IObjectView view)
		{
			return Manager.EntityViews.TryGetValue(e, out view);
		}

		private void UpdateScreenPositions()
		{
			foreach (KeyValuePair<ViewIdentifier, UpdateViewPositionData> item in PositionCache)
			{
				if (GetView(item.Key, out var view))
				{
					view.SetPosition(MapPositionToGameSpace(item.Value));
				}
			}
		}

		private void RemoveFromPositionCache(ViewIdentifier identifier)
		{
			PositionCache.Remove(identifier);
		}

		private void UpdateView<T>(ViewIdentifier entity, T data) where T : IViewData
		{
			if (GetView(entity, out var view) && view is IUpdatableObject updatableObject)
			{
				try
				{
					updatableObject.UpdateData(data);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		private void UpdateViewPosition(ViewIdentifier id, UpdateViewPositionData pos)
		{
			if (Manager.EntityViews.TryGetValue(id, out var value))
			{
				value.SetPosition(MapPositionToGameSpace(pos));
				if (pos.Mode != ViewMode.World)
				{
					PositionCache[id] = pos;
				}
			}
		}

		private UpdateViewPositionData MapPositionToGameSpace(UpdateViewPositionData pos)
		{
			if (pos.Mode == ViewMode.World)
			{
				return pos;
			}
			if (pos.Mode == ViewMode.WorldToScreen)
			{
				pos.Position = ViewHelpers.WorldToScreen(Camera.main, pos.Position);
			}
			pos.Position = ViewHelpers.ScaleToBounds(UICamBounds, pos.Position);
			return pos;
		}

		private void UpdateViewParent(ViewIdentifier id, ItemHolderView.ItemHolderData data)
		{
			if (Manager.EntityViews.TryGetValue(id, out var value))
			{
				if (!Manager.EntityViews.TryGetValue(data.Item, out var value2))
				{
					value2 = null;
				}
				RemoveFromPositionCache(id);
				value.SetHeldItem(value2, data.IsStorage ? data.StorageIndex : (-1), data.IsTool);
			}
		}

		private bool UpdateSpecificView<T>(ViewIdentifier id, T specific_view_data) where T : ISpecificViewData
		{
			if (Manager.EntityViews.TryGetValue(id, out var value))
			{
				IUpdatableObject relevantSubview = specific_view_data.GetRelevantSubview(value);
				if (relevantSubview == null)
				{
					return false;
				}
				if (relevantSubview is MonoBehaviour monoBehaviour && monoBehaviour == null)
				{
					return false;
				}
				try
				{
					relevantSubview.UpdateData(specific_view_data);
				}
				catch (Exception message)
				{
					Debug.LogWarning(message);
				}
				if (relevantSubview is ISpecificViewResponse specificViewResponse)
				{
					specificViewResponse.SetCallback(delegate(IResponseData r, Type t)
					{
						BroadcastCommand(new ResponseUpdateCommand(r, t, id));
					});
				}
				return true;
			}
			return false;
		}

		private void MaintainInView(MaintainInViewData mvd, IObjectView view)
		{
			BoundsMaintainer?.Update(view, mvd);
		}

		private void RemoveView(ViewIdentifier id)
		{
			if (Manager.EntityViews.TryGetValue(id, out var value))
			{
				value.Remove();
				Manager.EntityViews.Remove(id);
			}
			RemoveFromPositionCache(id);
		}

		private IObjectView CreateNewView(ViewIdentifier id, ViewType view_type, ViewMode view_mode, bool is_redraw = false)
		{
			if (Manager.EntityViews.ContainsKey(id))
			{
				if (is_redraw)
				{
					return Manager.EntityViews[id];
				}
				Manager.EntityViews[id].Remove();
				Manager.EntityViews.Remove(id);
			}
			bool flag = view_mode == ViewMode.Screen || view_mode == ViewMode.WorldToScreen;
			GameObject gameObject = null;
			try
			{
				gameObject = UnityEngine.Object.Instantiate(GetPrefab(view_type));
			}
			catch (Exception message)
			{
				Debug.LogError($"Failed to instantiate {view_type}");
				Debug.LogError(message);
				return null;
			}
			if (PlatformSettings.IsEditor)
			{
				gameObject.name = $"{view_type} - {id.Identifier}";
			}
			if (flag)
			{
				gameObject.transform.parent = UIContainer;
				gameObject.transform.localPosition = Vector3.zero;
			}
			else
			{
				if (!Containers.TryGetValue(view_type, out var value))
				{
					value = new GameObject($"{view_type}");
					Containers[view_type] = value;
				}
				gameObject.transform.parent = value.transform;
			}
			IObjectView component = gameObject.GetComponent<IObjectView>();
			try
			{
				component.Initialise();
			}
			catch (Exception arg)
			{
				Debug.LogError($"Failed to initialise view {gameObject.name}: {arg}");
			}
			Manager.EntityViews.Add(id, component);
			return component;
		}

		public void Dispose()
		{
			foreach (KeyValuePair<ViewType, GameObject> container in Containers)
			{
				if (PlatformSettings.IsEditor)
				{
					UnityEngine.Object.DestroyImmediate(container.Value);
				}
				else
				{
					UnityEngine.Object.Destroy(container.Value);
				}
			}
			CachedBroadcasts.Clear();
		}
	}
}
