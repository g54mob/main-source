using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Options;
using Assets.Scripts.Flight.MapView.Orbits;
using ModApi;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Flight.MapView.UI
{
	public static class UiUtils
	{
		public struct UIComponentVisibility
		{
			public float Visibility;

			public float VisibilityUnclamped;

			public UIComponentVisibility(float visibility, float visibilityUnclamped)
			{
				Visibility = visibility;
				VisibilityUnclamped = visibilityUnclamped;
			}
		}

		public static Image CreateUiIcon(Canvas parentCanvas, string iconName, bool clickable, Vector2? pivot = null)
		{
			GameObject gameObject = new GameObject(iconName);
			gameObject.transform.SetParent(parentCanvas.transform, worldPositionStays: false);
			Image image = gameObject.AddComponent<Image>();
			image.raycastTarget = clickable;
			image.gameObject.layer = parentCanvas.gameObject.layer;
			image.sprite = LoadIconSprite(iconName);
			if (pivot.HasValue)
			{
				image.GetComponent<RectTransform>().pivot = pivot.Value;
			}
			image.SetNativeSize();
			return image;
		}

		public static TextMeshProUGUI CreateUiText(Transform parent, string name, bool clickable, TextAlignmentOptions alignment)
		{
			GameObject gameObject = new GameObject(name);
			TextMeshProUGUI textMeshProUGUI = gameObject.AddComponent<TextMeshProUGUI>();
			textMeshProUGUI.font = Resources.Load<TMP_FontAsset>("Ui/Fonts/Roboto/Roboto-Regular SDF");
			textMeshProUGUI.raycastTarget = clickable;
			textMeshProUGUI.gameObject.layer = parent.gameObject.layer;
			textMeshProUGUI.alignment = alignment;
			textMeshProUGUI.enableWordWrapping = false;
			IMapOptions mapOptions = MapViewManagerScript.Instance.Ioc.Resolve<IMapOptions>();
			if (mapOptions != null)
			{
				textMeshProUGUI.fontSize = mapOptions.FontSizeValue;
				MapOptionsFontSizeScript.Create(textMeshProUGUI, mapOptions);
			}
			else
			{
				textMeshProUGUI.fontSize = 14f;
				Debug.LogWarning("Unable to retrieve the map options from the IOC container.");
			}
			gameObject.transform.SetParent(parent, worldPositionStays: false);
			return textMeshProUGUI;
		}

		public static Color GetRandomOrbitLineColor()
		{
			return Random.ColorHSV(0f, 1f, 0.4f, 0.6f, 0.4f, 0.6f);
		}

		public static Color GetSortedOrbitLineColor(int index)
		{
			return Color.HSVToRGB(0.002777777f * (float)((210 + index * 150) % 360), 0.4f, 0.6f);
		}

		public static Sprite LoadIconSprite(string iconName)
		{
			return Resources.Load<Sprite>("Flight/MapView/Icons/" + iconName);
		}

		public static UIComponentVisibility UpdateUiComponentFromCurrentPosition(Component component, MapOrbitInfo orbitInfo, IDrawModeProvider drawModeProvider, IMapViewCoordinateConverter coordinateConverter, Canvas uiCanvas, Camera uiCamera, float maxDist)
		{
			Vector3d solarPosition = ((orbitInfo.OrbitNode.Parent != null) ? drawModeProvider.DrawMode.GetSolarPositionAtCurrent(orbitInfo) : ((Vector3d)Vector3.zero));
			return UpdateUiComponent(component, solarPosition, coordinateConverter, uiCanvas, uiCamera, maxDist, Vector2.zero);
		}

		public static UIComponentVisibility UpdateUiComponentFromNu(Component component, double nu, MapOrbitInfo orbitInfo, IDrawModeProvider drawModeProvider, IMapViewCoordinateConverter coordinateConverter, Canvas uiCanvas, Camera uiCamera, float maxDist, Vector2 offset)
		{
			Vector3d solarPositionFromNu = drawModeProvider.DrawMode.GetSolarPositionFromNu(orbitInfo, nu);
			return UpdateUiComponent(component, solarPositionFromNu, coordinateConverter, uiCanvas, uiCamera, maxDist, offset);
		}

		public static UIComponentVisibility UpdateUiComponentFromPoint(Component component, IOrbitPoint point, MapOrbitInfo orbitInfo, IDrawModeProvider drawModeProvider, IMapViewCoordinateConverter coordinateConverter, Canvas uiCanvas, Camera uiCamera, float maxDist)
		{
			Vector3d solarPosition = drawModeProvider.DrawMode.GetSolarPosition(orbitInfo, point);
			return UpdateUiComponent(component, solarPosition, coordinateConverter, uiCanvas, uiCamera, maxDist, Vector2.zero);
		}

		internal static void UiComponentSetEnabled(Component uiComponent, bool enabled)
		{
			if (uiComponent.gameObject.activeSelf != enabled)
			{
				uiComponent.gameObject.SetActive(enabled);
			}
		}

		private static UIComponentVisibility UpdateUiComponent(Component component, Vector3d solarPosition, IMapViewCoordinateConverter coordinateConverter, Canvas uiCanvas, Camera uiCamera, float maxDist, Vector2 offset)
		{
			Vector3 vector = (Vector3)coordinateConverter.ConvertSolarToMapView(solarPosition);
			Vector3 vector2 = Utilities.GameWorldToScreenPoint(uiCamera, vector);
			float num = 1f - (vector - uiCamera.transform.position).magnitude / maxDist * 0.65f;
			float num2 = Mathf.Clamp01(num);
			if (vector2.z < 0f)
			{
				UiComponentSetEnabled(component, enabled: false);
			}
			else
			{
				bool enabled = true;
				component.transform.position = (Vector2)vector2 + offset * uiCanvas.scaleFactor;
				if (component is Image)
				{
					Image image = component as Image;
					image.color = new Color(image.color.r, image.color.g, image.color.b, num2);
				}
				else if (component is CanvasGroup)
				{
					(component as CanvasGroup).alpha = num2;
					enabled = num2 > 0f;
				}
				UiComponentSetEnabled(component, enabled);
			}
			return new UIComponentVisibility(num2, num);
		}
	}
}
