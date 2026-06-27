using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Gameplay.Common;
using Restory.ObjectPools;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface.GameplayOverlay
{
	public class GUI_GameplayOverlayCanvas : MonoBehaviour, IDisposable
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		private GlobalObjectPool objectPool;

		private readonly Dictionary<GameObject, HashSet<GUI_ScreenObjectBase>> modelViewsDictionary = new Dictionary<GameObject, HashSet<GUI_ScreenObjectBase>>();

		public CanvasGroup CanvasGroup => canvasGroup;

		[Inject]
		private void Construct(GlobalObjectPool objectPool)
		{
			this.objectPool = objectPool;
		}

		public void Dispose()
		{
			objectPool = null;
			modelViewsDictionary.Clear();
		}

		public bool ContainsModal(GameObject modal)
		{
			return modelViewsDictionary.ContainsKey(modal);
		}

		public GUI_ScreenObjectBase Show(GameObject model, GameObject viewPrefab, GameObject actor = null, Transform parent = null)
		{
			if (!model || !viewPrefab || objectPool == null)
			{
				return null;
			}
			GUI_ScreenObjectBase gUI_ScreenObjectBase = GetViewInstance(model, viewPrefab);
			if (gUI_ScreenObjectBase != null)
			{
				if (!parent && gUI_ScreenObjectBase.transform.parent != base.transform)
				{
					gUI_ScreenObjectBase.transform.SetParent(base.transform);
				}
				else if ((bool)parent && gUI_ScreenObjectBase.transform.parent != parent)
				{
					gUI_ScreenObjectBase.transform.SetParent(parent);
				}
			}
			else
			{
				gUI_ScreenObjectBase = objectPool.GetObject<GUI_ScreenObjectBase>(viewPrefab, (parent != null) ? parent : base.transform);
			}
			if (gUI_ScreenObjectBase == null)
			{
				Debug.LogError("<color=red>[GUI_GameplayOverlayCanvas] Failed to instantiate view: " + viewPrefab.name + "</color>");
				return null;
			}
			if (!(gUI_ScreenObjectBase is GUI_SingleObjectModalBase gUI_SingleObjectModalBase))
			{
				if (gUI_ScreenObjectBase is GUI_InteractionModalBase gUI_InteractionModalBase)
				{
					gUI_InteractionModalBase.Initialize(model, actor);
				}
			}
			else
			{
				gUI_SingleObjectModalBase.Initialize(model);
			}
			if (!modelViewsDictionary.TryGetValue(model, out var value))
			{
				value = new HashSet<GUI_ScreenObjectBase>();
				modelViewsDictionary.Add(model, value);
			}
			value.Add(gUI_ScreenObjectBase);
			gUI_ScreenObjectBase.Show();
			UpdateViewsVisability(model);
			return gUI_ScreenObjectBase;
		}

		public void HideAll(GameObject model)
		{
			if (model == null || !modelViewsDictionary.TryGetValue(model, out var value))
			{
				return;
			}
			foreach (GUI_ScreenObjectBase item in value)
			{
				if (item != null)
				{
					item.Hide();
				}
			}
		}

		public void Close(GameObject model, GameObject viewPrefab)
		{
			if (!(model == null) && !(viewPrefab == null) && modelViewsDictionary.TryGetValue(model, out var value) && !value.All((GUI_ScreenObjectBase x) => x.SourcePrefab != viewPrefab))
			{
				GUI_ScreenObjectBase gUI_ScreenObjectBase = value.FirstOrDefault((GUI_ScreenObjectBase x) => x.SourcePrefab == viewPrefab);
				if (gUI_ScreenObjectBase != null)
				{
					gUI_ScreenObjectBase.Close();
				}
				UpdateViewsVisability(model);
			}
		}

		public void CloseAll(GameObject model)
		{
			if (model == null || !modelViewsDictionary.TryGetValue(model, out var value))
			{
				return;
			}
			foreach (GUI_ScreenObjectBase item in value)
			{
				if (item != null)
				{
					item.Close();
				}
			}
			UpdateViewsVisability(model);
		}

		public void Remove(GameObject model, GUI_ScreenObjectBase viewInstance)
		{
			if (model != null && modelViewsDictionary.TryGetValue(model, out var value))
			{
				value.Remove(viewInstance);
				UpdateViewsVisability(model);
			}
		}

		public GUI_ScreenObjectBase GetViewInstance(GameObject model, GameObject viewPrefab)
		{
			if ((bool)model && (bool)viewPrefab && modelViewsDictionary.TryGetValue(model, out var value))
			{
				foreach (GUI_ScreenObjectBase item in value)
				{
					if (item.SourcePrefab == viewPrefab)
					{
						return item;
					}
				}
				return null;
			}
			return null;
		}

		public GUI_ScreenObjectBase GetViewInstance(GUI_ScreenObjectBase viewPrefab)
		{
			foreach (HashSet<GUI_ScreenObjectBase> value in modelViewsDictionary.Values)
			{
				GUI_ScreenObjectBase gUI_ScreenObjectBase = value?.FirstOrDefault((GUI_ScreenObjectBase x) => x.SourcePrefab == viewPrefab.gameObject);
				if ((bool)gUI_ScreenObjectBase)
				{
					return gUI_ScreenObjectBase;
				}
			}
			return null;
		}

		public bool Contains(GameObject model, GameObject viewPrefab)
		{
			if (model != null && modelViewsDictionary.TryGetValue(model, out var value))
			{
				return value.Any((GUI_ScreenObjectBase x) => x.SourcePrefab == viewPrefab);
			}
			return false;
		}

		public void UpdateViewsVisability(GameObject model)
		{
			if (model == null)
			{
				Debug.LogException(new Exception("GUI_GameplayOverlayCanvas can't complete UpdateViewsVisability. Reason: model is null"));
				return;
			}
			if (!modelViewsDictionary.TryGetValue(model, out var value) || value.Count == 0)
			{
				modelViewsDictionary.Remove(model);
				return;
			}
			List<GUI_ScreenObjectBase> source = value.Where((GUI_ScreenObjectBase x) => x != null && x.Element != null).ToList();
			if (!source.Any())
			{
				modelViewsDictionary.Remove(model);
				return;
			}
			PriorityType priorityType = source.Max((GUI_ScreenObjectBase x) => x.Element.Priority);
			foreach (GUI_ScreenObjectBase item in value)
			{
				if (!(item == null))
				{
					GUI_CanvasElement element = item.Element;
					bool active = !element || element.Priority == priorityType;
					item.gameObject.SetActive(active);
				}
			}
		}
	}
}
