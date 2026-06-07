using Assets.Scripts.Flight.MapView.Items;
using Assets.Scripts.Flight.MapView.UI;
using ModApi.Flight.UI;
using ModApi.Math;
using ModApi.Scripts.State.Validation;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Flight.MapView.Targeting
{
	public class EncounterInfoScript : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler, IScrollHandler
	{
		public const string DistanceTextName = "Dist";

		public const string DvTextName = "Dv";

		public const string HoverContentsName = "HoverContents";

		public const string TimeTextName = "Time";

		private bool _captured;

		private bool _clicked;

		private TextMeshProUGUI _distanceText;

		private TextMeshProUGUI _dvText;

		private GameObject _hoverContents;

		private bool _hovering;

		private float _hoverStartTime;

		private Image _iconImage;

		private TextMeshProUGUI _secondsInFutureText;

		public static Color CapturedIconColor { get; }

		public static Color NotCapturedIconColor { get; }

		public bool AlwaysShowContents { get; set; }

		public Canvas Canvas { get; private set; }

		public CanvasGroup CanvasGroup { get; private set; }

		public bool Captured
		{
			get
			{
				return _captured;
			}
			set
			{
				_captured = value;
				_iconImage.color = (value ? CapturedIconColor : NotCapturedIconColor);
			}
		}

		public bool Clicked
		{
			get
			{
				return _clicked;
			}
			set
			{
				_clicked = value;
			}
		}

		public double DeltaVelocity
		{
			get
			{
				return double.Parse(_dvText.text);
			}
			set
			{
				_dvText.text = Units.GetVelocityString((int)value);
			}
		}

		public double Distance
		{
			get
			{
				return double.Parse(_distanceText.text);
			}
			set
			{
				_distanceText.text = Units.GetDistanceString((float)value);
			}
		}

		public double SecondsInFuture
		{
			get
			{
				return double.Parse(_secondsInFutureText.text);
			}
			set
			{
				_secondsInFutureText.text = Units.GetRelativeTimeString(value);
			}
		}

		static EncounterInfoScript()
		{
			CapturedIconColor = new Color(0.27f, 0.78f, 0.42f);
			NotCapturedIconColor = Color.white;
		}

		public void AddContextMenuItem(IContextMenu contextMenu)
		{
			string text = (Clicked ? "Hide Encounter Info" : "Show Encounter Info");
			contextMenu.AddContextMenuItem(text, _iconImage.sprite, _iconImage.color, delegate
			{
				OnClicked();
			});
		}

		public void Initialize()
		{
			Canvas = GetComponentInParent<Canvas>(includeInactive: true);
			CanvasGroup = GetComponent<CanvasGroup>();
			_iconImage = GetComponentInChildren<Image>();
			_hoverContents = base.transform.Find("HoverContents").gameObject;
			_hoverContents.SetActive(value: false);
			_distanceText = _hoverContents.transform.Find("Dist").GetComponent<TextMeshProUGUI>();
			_dvText = _hoverContents.transform.Find("Dv").GetComponent<TextMeshProUGUI>();
			_secondsInFutureText = _hoverContents.transform.Find("Time").GetComponent<TextMeshProUGUI>();
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			MapItemsAtPointerPosition visibleMapItemsAtPointer = ((MapViewScript)Game.Instance.FlightScene.ViewManager.MapViewManager.MapView).MapViewUi.GetVisibleMapItemsAtPointer(eventData, this);
			if (visibleMapItemsAtPointer.ItemCount == 0)
			{
				OnClicked();
				return;
			}
			IContextMenu contextMenu = Game.Instance.FlightScene.FlightSceneUI.ContextMenu;
			if (visibleMapItemsAtPointer.PlayerCraft != null)
			{
				visibleMapItemsAtPointer.PlayerCraft.AddContextMenuItem(contextMenu, eventData);
			}
			if (visibleMapItemsAtPointer.ManeuverNodeManager != null)
			{
				IGameStateValidator validator = Game.Instance.GameState.Validator;
				if (!validator.IsCareerMode || validator.IsItemAvailable("Map.Maneuver"))
				{
					visibleMapItemsAtPointer.ManeuverNodeManager.AddContextMenuItems(contextMenu, eventData);
				}
			}
			AddContextMenuItem(contextMenu);
			foreach (EncounterInfoScript encounterInfo in visibleMapItemsAtPointer.EncounterInfos)
			{
				encounterInfo.AddContextMenuItem(contextMenu);
			}
			foreach (MapItemCanvasScript mapItem in visibleMapItemsAtPointer.MapItems)
			{
				mapItem.MapItem.AddContextMenuItem(contextMenu, eventData);
			}
			contextMenu.ShowContextMenu(eventData.position);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			_hovering = true;
			_hoverStartTime = Time.unscaledTime;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			_hovering = false;
			_hoverStartTime = float.MaxValue;
		}

		public void OnScroll(PointerEventData eventData)
		{
			(MapViewManagerScript.Instance?.MapView as MapViewScript)?.MapCameraScript?.OnScroll(eventData);
		}

		private void OnClicked()
		{
			_clicked = !_clicked;
		}

		private void Update()
		{
			bool flag = _hovering && Time.unscaledTime > _hoverStartTime + 0.15f;
			if (AlwaysShowContents || flag || _clicked)
			{
				if (!_hoverContents.activeSelf)
				{
					_hoverContents.SetActive(value: true);
				}
			}
			else if (_hoverContents.activeSelf)
			{
				_hoverContents.SetActive(value: false);
			}
		}
	}
}
