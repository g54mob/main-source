using System;
using System.Collections.Generic;
using System.Reflection;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.FloatingOverlaySystem;
using NSMedieval.Goap;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Tutorial;
using NSMedieval.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.View;
using NSMedieval.Village;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.Manager
{
	public class AdditionalMenuManager : MonoSingleton<AdditionalMenuManager>, IObserver
	{
		public class AdditionalMenuInstance
		{
			private readonly IAdditionalMenuOwner owner;

			private readonly AdditionalMenuFloatingElement element;

			private readonly ClickDetection clickDetection;

			private readonly List<AdditionalMenuItemBase> items;

			private GameObject selectedIndicator;

			public IAdditionalMenuOwner Owner => owner;

			public AdditionalMenuFloatingElement Element => element;

			public ClickDetection ClickDetection => clickDetection;

			public List<AdditionalMenuItemBase> Items => items;

			public GameObject SelectedIndicator
			{
				get
				{
					return selectedIndicator;
				}
				set
				{
					selectedIndicator = value;
				}
			}

			public AdditionalMenuInstance(IAdditionalMenuOwner owner, AdditionalMenuFloatingElement element, ClickDetection clickDetection)
			{
				this.owner = owner;
				this.element = element;
				this.clickDetection = clickDetection;
				items = new List<AdditionalMenuItemBase>();
			}
		}

		private AdditionalMenuInstance currentMenu;

		public AdditionalMenuInstance CurrentMenu => currentMenu;

		public bool ShowMenu(IAdditionalMenuOwner owner)
		{
			if (TutorialManager.IsTutorialActive && !MonoSingleton<TutorialManager>.Instance.AllowAdditionalMenu)
			{
				HideAll();
				return false;
			}
			if (currentMenu != null)
			{
				HideAll();
			}
			if (owner.GetAsTarget() != null && owner.GetAsTarget().HasDisposed)
			{
				HideAll();
				return false;
			}
			AdditionalMenuItemData byID = Repository<AdditionalMenuRepository, AdditionalMenuItemData>.Instance.GetByID(owner.GetAdditionalMenuId());
			bool isEnabled;
			if (byID == null)
			{
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(63, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AdditionalMenuManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("AdditionalMenuItemData '");
					messageBuilder.AppendFormatted(owner.GetAdditionalMenuId());
					messageBuilder.AppendLiteral("' not found in AdditionalMenuRepository");
				}
				Log.Warning(messageBuilder);
				HideAll();
				return false;
			}
			if (byID.MenuItems == null || byID.MenuItems.Length == 0)
			{
				HideAll();
				return false;
			}
			AdditionalMenuFloatingElement additionalMenuFloatingElement;
			try
			{
				additionalMenuFloatingElement = FloatingElementFactory.ProduceAdditionalMenuElement(owner.GetGuiOverlayHookTransform());
				if (additionalMenuFloatingElement == null)
				{
					HideAll();
					Log.Info("*** overlayElement is null ***", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AdditionalMenuManager.cs");
					isEnabled = false;
					return isEnabled;
				}
				FloatingElementHolder elementHolder = MonoSingleton<FloatingOverlayManager>.Instance.GetElementHolder(owner.GetGuiOverlayHookTransform(), additionalMenuFloatingElement.HolderType);
				if (elementHolder == null)
				{
					HideAll();
					Log.Info("*** holder is null ***", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AdditionalMenuManager.cs");
					isEnabled = false;
					return isEnabled;
				}
				elementHolder.HoldPosition = !owner.ShouldMenuFollowHookTransform();
				elementHolder.RefreshPosition();
				ScreenBoundsReposition(additionalMenuFloatingElement, elementHolder);
				ClickDetection component = additionalMenuFloatingElement.GetComponent<ClickDetection>();
				currentMenu = new AdditionalMenuInstance(owner, additionalMenuFloatingElement, component);
				currentMenu.Owner.OnDisposedEvent += OnCurrentMenuDisposed;
			}
			catch (Exception)
			{
				Log.Error("Exception happened in AdditionalMenuManager.ShowMenu.", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AdditionalMenuManager.cs");
				bool isEnabled2;
				FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(8, 1, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AdditionalMenuManager.cs");
				if (isEnabled2)
				{
					messageBuilder2.AppendLiteral("Object: ");
					messageBuilder2.AppendFormatted(GameObjectUtils.GetNameWithPath(owner.GetGuiOverlayHookTransform()));
				}
				Log.Error(messageBuilder2);
				throw;
			}
			PooledDictionary<string, int> janitor = DictionaryPool<string, int>.GetJanitor();
			try
			{
				string[] menuItems = byID.MenuItems;
				foreach (string key in menuItems)
				{
					if (!AdditionalMenuItemMap.Constuctors.TryGetValue(key, out var value))
					{
						continue;
					}
					ParameterInfo[] parameters = value.GetParameters();
					AdditionalMenuItemBase additionalMenuItemBase;
					if (parameters.Length == 2 && parameters[1].ParameterType == typeof(int))
					{
						int value2;
						int num = (janitor.TryGetValue(key, out value2) ? value2 : 0);
						additionalMenuItemBase = (AdditionalMenuItemBase)value.Invoke(new object[2] { owner, num });
					}
					else
					{
						additionalMenuItemBase = (AdditionalMenuItemBase)value.Invoke(new object[1] { owner });
					}
					if (!janitor.TryAdd(key, 1))
					{
						janitor[key]++;
					}
					if (!string.IsNullOrEmpty(additionalMenuItemBase.Text) && additionalMenuItemBase.Setup(additionalMenuFloatingElement, byID))
					{
						if (!string.IsNullOrEmpty(additionalMenuItemBase.MenuTitle))
						{
							additionalMenuFloatingElement.SetTitle(additionalMenuItemBase.MenuTitle);
						}
						currentMenu.Items.Add(additionalMenuItemBase);
					}
				}
				if (currentMenu.Items.Count == 0)
				{
					HideAll();
					isEnabled = false;
					return isEnabled;
				}
				SpawnOwnerIndicator();
				isEnabled = true;
				return isEnabled;
			}
			finally
			{
				((IDisposable)janitor/*cast due to .constrained prefix*/).Dispose();
			}
		}

		private void ScreenBoundsReposition(AdditionalMenuFloatingElement overlayElement, FloatingElementHolder holder)
		{
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				if ((bool)overlayElement && (bool)holder)
				{
					RectTransform component = overlayElement.GetComponent<RectTransform>();
					LayoutRebuilder.ForceRebuildLayoutImmediate(component);
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(26, 4, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AdditionalMenuManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("holder: ");
						messageBuilder.AppendFormatted(holder.transform.position.y);
						messageBuilder.AppendLiteral(" element: p: ");
						messageBuilder.AppendFormatted(component.position.y);
						messageBuilder.AppendLiteral(" a: ");
						messageBuilder.AppendFormatted(component.anchoredPosition.y);
						messageBuilder.AppendLiteral(" ");
						messageBuilder.AppendFormatted(Screen.height);
					}
					Log.Trace(messageBuilder);
					float num = component.anchoredPosition.x;
					float num2 = component.anchoredPosition.y;
					if (component.transform.position.x + component.sizeDelta.x > (float)Screen.width)
					{
						float num3 = component.transform.position.x + component.sizeDelta.x - (float)Screen.width;
						num = component.anchoredPosition.x - num3;
						messageBuilder = new FVLogTraceInterpolationHandler(26, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AdditionalMenuManager.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("pos: ");
							messageBuilder.AppendFormatted(component.position);
							messageBuilder.AppendLiteral(" size: ");
							messageBuilder.AppendFormatted(component.sizeDelta);
							messageBuilder.AppendLiteral(", xBleed: ");
							messageBuilder.AppendFormatted(num3);
							messageBuilder.AppendLiteral(" x: ");
							messageBuilder.AppendFormatted(num);
						}
						Log.Trace(messageBuilder);
					}
					if (component.transform.position.y - component.sizeDelta.y < 0f)
					{
						float num4 = component.transform.position.y - component.sizeDelta.y;
						num2 = component.anchoredPosition.y - num4;
						messageBuilder = new FVLogTraceInterpolationHandler(26, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AdditionalMenuManager.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("pos: ");
							messageBuilder.AppendFormatted(component.position);
							messageBuilder.AppendLiteral(" size: ");
							messageBuilder.AppendFormatted(component.sizeDelta);
							messageBuilder.AppendLiteral(", yBleed: ");
							messageBuilder.AppendFormatted(num4);
							messageBuilder.AppendLiteral(" y: ");
							messageBuilder.AppendFormatted(num2);
						}
						Log.Trace(messageBuilder);
					}
					float num5 = 30f;
					if (component.transform.position.y + num5 > (float)Screen.height)
					{
						float num6 = (float)Screen.height - component.transform.position.y + num5;
						num2 = component.anchoredPosition.y - num6;
						messageBuilder = new FVLogTraceInterpolationHandler(26, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AdditionalMenuManager.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("pos: ");
							messageBuilder.AppendFormatted(component.position);
							messageBuilder.AppendLiteral(" size: ");
							messageBuilder.AppendFormatted(component.sizeDelta);
							messageBuilder.AppendLiteral(", yBleed: ");
							messageBuilder.AppendFormatted(num6);
							messageBuilder.AppendLiteral(" y: ");
							messageBuilder.AppendFormatted(num2);
						}
						Log.Trace(messageBuilder);
					}
					component.anchoredPosition = new Vector2(num, num2);
				}
			});
		}

		public bool ShowMenu(IAdditionalMenuOwner firstOwner, IAdditionalMenuOwner secondOwner)
		{
			if (currentMenu != null)
			{
				HideAll();
			}
			if (firstOwner.GetAsTarget() != null && firstOwner.GetAsTarget().HasDisposed)
			{
				HideAll();
				return false;
			}
			AdditionalMenuFloatingElement additionalMenuFloatingElement = FloatingElementFactory.ProduceAdditionalMenuElement(firstOwner.GetGuiOverlayHookTransform());
			FloatingElementHolder elementHolder = MonoSingleton<FloatingOverlayManager>.Instance.GetElementHolder(firstOwner.GetGuiOverlayHookTransform(), additionalMenuFloatingElement.HolderType);
			elementHolder.HoldPosition = !firstOwner.ShouldMenuFollowHookTransform();
			elementHolder.RefreshPosition();
			ClickDetection component = additionalMenuFloatingElement.GetComponent<ClickDetection>();
			currentMenu = new AdditionalMenuInstance(firstOwner, additionalMenuFloatingElement, component);
			currentMenu.Owner.OnDisposedEvent += OnCurrentMenuDisposed;
			AdditionalMenuItemData byID = Repository<AdditionalMenuRepository, AdditionalMenuItemData>.Instance.GetByID(firstOwner.GetAdditionalMenuId());
			AdditionalMenuItemData byID2 = Repository<AdditionalMenuRepository, AdditionalMenuItemData>.Instance.GetByID(secondOwner.GetAdditionalMenuId());
			if (byID == null)
			{
				Log.Warning("Additional menu item data for agent " + firstOwner.GetAdditionalMenuId(), "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AdditionalMenuManager.cs");
			}
			if (byID2 == null)
			{
				Log.Warning("Additional menu item data for agent " + secondOwner.GetAdditionalMenuId(), "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AdditionalMenuManager.cs");
			}
			using PooledList<string> pooledList = ListPool<string>.GetJanitor();
			if (byID != null)
			{
				pooledList.AddRange(byID.MenuItems);
			}
			if (byID2 != null)
			{
				pooledList.AddRange(byID2.MenuItems);
			}
			if (pooledList.Count == 0)
			{
				HideAll();
				return false;
			}
			foreach (string item in pooledList)
			{
				Dictionary<string, ConstructorInfo> constuctors = AdditionalMenuItemMap.Constuctors;
				if (!constuctors.ContainsKey(item))
				{
					continue;
				}
				AdditionalMenuItemBase additionalMenuItemBase = (AdditionalMenuItemBase)constuctors[item].Invoke(new object[1] { firstOwner });
				if (!string.IsNullOrEmpty(additionalMenuItemBase.Text) && additionalMenuItemBase.Setup(additionalMenuFloatingElement, byID))
				{
					if (!string.IsNullOrEmpty(additionalMenuItemBase.MenuTitle))
					{
						additionalMenuFloatingElement.SetTitle(additionalMenuItemBase.MenuTitle);
					}
					currentMenu.Items.Add(additionalMenuItemBase);
				}
			}
			if (currentMenu.Items.Count == 0)
			{
				HideAll();
				return false;
			}
			SpawnOwnerIndicator();
			return true;
		}

		public void HideAll()
		{
			if (currentMenu == null)
			{
				return;
			}
			foreach (AdditionalMenuItemBase item in currentMenu.Items)
			{
				item.Dispose();
			}
			DestroyOwnerIndicator();
			UnityEngine.Object.Destroy(currentMenu.Element);
			currentMenu.Owner.OnDisposedEvent -= OnCurrentMenuDisposed;
			currentMenu = null;
		}

		public bool IsBlockingInput()
		{
			if (currentMenu == null || currentMenu.ClickDetection == null)
			{
				return false;
			}
			return currentMenu.ClickDetection.IsMouseOverElement;
		}

		public bool IsMenuShown()
		{
			return currentMenu != null;
		}

		private void OnCurrentMenuDisposed(IDisposable disposable)
		{
			HideAll();
		}

		private void SpawnOwnerIndicator()
		{
			if (currentMenu == null)
			{
				return;
			}
			if (currentMenu.SelectedIndicator != null)
			{
				DestroyOwnerIndicator();
			}
			GameObject byAddress = MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress("menu_shown_indicator");
			if (byAddress == null)
			{
				return;
			}
			SelectableObject selectableObject = currentMenu.Owner as SelectableObject;
			GameObject gameObject = null;
			if (selectableObject != null)
			{
				gameObject = UnityEngine.Object.Instantiate(byAddress);
				WorldObject asWorldObject = selectableObject.GetAsWorldObject();
				if (asWorldObject != null)
				{
					gameObject.transform.position = asWorldObject.GetCentralPosition();
				}
				else
				{
					gameObject.GetComponent<MenuShownIndicator>().FollowTarget(selectableObject.transform);
				}
			}
			else
			{
				IGoapTargetable goapTargetable = currentMenu.Owner?.GetAsTarget();
				if (goapTargetable != null)
				{
					gameObject = UnityEngine.Object.Instantiate(byAddress, goapTargetable.GetPosition(), Quaternion.identity);
				}
			}
			if (!(gameObject == null))
			{
				currentMenu.SelectedIndicator = gameObject;
			}
		}

		private void DestroyOwnerIndicator()
		{
			if (!(currentMenu?.SelectedIndicator == null))
			{
				UnityEngine.Object.Destroy(currentMenu.SelectedIndicator);
				currentMenu.SelectedIndicator = null;
			}
		}
	}
}
