using System;
using System.Collections.Generic;
using Assets.Scripts.Flight.MapView.Items;
using Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes;
using Assets.Scripts.Flight.MapView.Targeting;
using Assets.Scripts.Flight.MapView.UI.Inspector;
using Assets.Scripts.Ui;
using ModApi;
using ModApi.Ioc;
using UI.Xml;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Flight.MapView.UI.Controllers
{
	public class MapViewUiController : XmlLayoutController
	{
		private IIocContainer _ioc;

		public MapViewScript MapView { get; private set; }

		public MapViewInspectorScript MapViewInspector { get; private set; }

		public SearchPanel SearchPanel { get; set; }

		public static MapViewUiController Create(IIocContainer ioc, Transform parent, MapViewScript mapView)
		{
			GameObject obj = UiUtilities.CreateUiGameObject("MapViewUi", parent);
			XmlLayout xmlLayout = obj.AddComponent<XmlLayout>();
			MapViewUiController mapViewUiController = obj.AddComponent<MapViewUiController>();
			mapViewUiController.Initialize(ioc, mapView);
			Game.Instance.UserInterface.BuildUserInterfaceFromResource("Ui/Xml/Map/MapViewUi", xmlLayout);
			return mapViewUiController;
		}

		public MapItemsAtPointerPosition GetVisibleMapItemsAtPointer(PointerEventData pointerEventData, object itemToIgnore)
		{
			MapItemsAtPointerPosition mapItemsAtPointerPosition = new MapItemsAtPointerPosition(pointerEventData.position);
			try
			{
				MapItemCanvasScript mapItemCanvasScript = itemToIgnore as MapItemCanvasScript;
				EncounterInfoScript encounterInfoScript = itemToIgnore as EncounterInfoScript;
				ManeuverNodeManagerScript maneuverNodeManagerScript = itemToIgnore as ManeuverNodeManagerScript;
				Ray ray = Utilities.ScreenPointToRay(MapView.MapCamera, pointerEventData.position);
				if (MapView.PlayerCraft.GetComponentInChildren<Collider>().Raycast(ray, out var _, float.MaxValue))
				{
					mapItemsAtPointerPosition.PlayerCraft = MapView.PlayerCraft;
				}
				GraphicRaycaster[] componentsInChildren = base.transform.parent.GetComponentsInChildren<GraphicRaycaster>(includeInactive: false);
				foreach (GraphicRaycaster obj in componentsInChildren)
				{
					List<RaycastResult> list = new List<RaycastResult>();
					obj.Raycast(pointerEventData, list);
					foreach (RaycastResult item in list)
					{
						MapItemCanvasScript componentInParent = item.gameObject.GetComponentInParent<MapItemCanvasScript>();
						if (componentInParent != null)
						{
							MapItem mapItem = componentInParent.MapItem;
							if ((object)mapItem != null && mapItem.SupportsContextMenuSelection)
							{
								if (componentInParent != mapItemCanvasScript)
								{
									Image image = componentInParent.MapItem?.ItemIcon;
									if (image != null && image.isActiveAndEnabled && image.color.a > 0f)
									{
										mapItemsAtPointerPosition.MapItems.Add(componentInParent);
									}
								}
								continue;
							}
						}
						EncounterInfoScript componentInParent2 = item.gameObject.GetComponentInParent<EncounterInfoScript>();
						if (componentInParent2 != null)
						{
							if (componentInParent2 != encounterInfoScript)
							{
								mapItemsAtPointerPosition.EncounterInfos.Add(componentInParent2);
							}
							continue;
						}
						ManeuverNodeManagerScript componentInParent3 = item.gameObject.GetComponentInParent<ManeuverNodeManagerScript>();
						if (componentInParent3 != null && componentInParent3 != maneuverNodeManagerScript)
						{
							mapItemsAtPointerPosition.ManeuverNodeManager = componentInParent3;
						}
					}
				}
			}
			catch (Exception exception)
			{
				Debug.LogError("Unable to get visible map items at pointer position");
				Debug.LogException(exception);
			}
			return mapItemsAtPointerPosition;
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			base.LayoutRebuilt(parseResult);
			if (!Game.InPlanetStudioScene)
			{
				SearchPanel = new SearchPanel(_ioc, MapView.Context, this, base.xmlLayout.GetElementById("search-panel"));
			}
			MapViewInspector = MapViewInspectorScript.Create(_ioc, MapView.Context);
			MapViewInspector.Visible = true;
		}

		private void Initialize(IIocContainer ioc, MapViewScript mapView)
		{
			_ioc = ioc;
			MapView = mapView;
		}

		private void OnDestroy()
		{
			SearchPanel?.OnDestroy();
		}
	}
}
