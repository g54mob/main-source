using ModApi;
using ModApi.Audio;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Flight.UI
{
	public class NavSphereInterfaceScript : MonoBehaviour
	{
		private const int NavSphereLayer = 27;

		[SerializeField]
		private Camera _camera;

		[SerializeField]
		private NavSphereDiscScript _discHeading;

		[SerializeField]
		private NavSphereDiscScript _discPitch;

		private bool _eventHandled;

		private bool _headingVisible = true;

		private bool _headingLocked;

		private NavSphereDiscScript _highlightedDisc;

		private NavSphereIndicatorScript _highlightedIndicator;

		private float _hitRadius = 0.85f;

		private Vector3 _initialCameraPosition;

		private InputResponder _inputResponder = new InputResponder("NavSphereInterfaceScript");

		[SerializeField]
		private NavSphereScript _navSphere;

		private RaycastHit[] _raycastHits = new RaycastHit[4];

		private NavSphereDiscScript _selectedDisc;

		private int _soundDiscAngle;

		private float _soundTimer;

		private float _startDiscAngle;

		private float _startRayAngle;

		public bool HeadingVisible
		{
			set
			{
				_headingVisible = value;
				_discHeading.ColliderEnabled = value;
				_discHeading.Hidden = !value;
				_discPitch.HiddenAlt = !value;
			}
		}

		public InputResponder InputResponder => _inputResponder;

		public bool Visible
		{
			get
			{
				return base.gameObject.activeSelf;
			}
			set
			{
				base.gameObject.SetActive(value);
				_camera.gameObject.SetActive(value);
			}
		}

		private NavSphereDiscScript HighlightedDisc
		{
			get
			{
				return _highlightedDisc;
			}
			set
			{
				if (_highlightedDisc != value)
				{
					if (_highlightedDisc != null)
					{
						_highlightedDisc.Highlighted = false;
					}
					_highlightedDisc = value;
					if (_highlightedDisc != null)
					{
						_highlightedDisc.Highlighted = true;
					}
				}
			}
		}

		private NavSphereIndicatorScript HighlightedIndicator
		{
			get
			{
				return _highlightedIndicator;
			}
			set
			{
				if (_highlightedIndicator != value)
				{
					if (_highlightedIndicator != null)
					{
						_highlightedIndicator.Highlighted = false;
					}
					_highlightedIndicator = value;
					if (_highlightedIndicator != null)
					{
						_highlightedIndicator.Highlighted = true;
					}
				}
			}
		}

		public void LockIndicator(NavSphereIndicatorScript indicator)
		{
			if (indicator != null)
			{
				if (_navSphere.LockedIndicator == indicator.IndicatorType)
				{
					FlightSceneScript.Instance.FlightSceneUI.ShowMessage($"Unlocked {indicator.Name}");
					_navSphere.UnlockHeading();
				}
				else
				{
					FlightSceneScript.Instance.FlightSceneUI.ShowMessage($"Locked {indicator.Name}");
					_navSphere.LockedIndicator = indicator.IndicatorType;
				}
			}
			else if (_navSphere.LockedIndicator.HasValue)
			{
				_navSphere.UnlockHeading();
			}
		}

		public bool OnDrag(PointerEventData eventData)
		{
			bool result = false;
			if (_selectedDisc != null)
			{
				result = HandleEvent(eventData);
			}
			return result;
		}

		public bool OnPointerDown(PointerEventData eventData)
		{
			return HandleEvent(eventData);
		}

		public bool OnPointerUp(PointerEventData eventData)
		{
			if (_selectedDisc != null)
			{
				_selectedDisc.Selected = false;
				_selectedDisc.HideMarkings();
				_selectedDisc = null;
				Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Flight.NavSphereReleased);
			}
			HighlightedDisc = null;
			_eventHandled = false;
			_discPitch.ColliderEnabled = true;
			_discHeading.ColliderEnabled = _headingVisible;
			return false;
		}

		public void SetScale(float scale)
		{
			_camera.transform.localPosition = _initialCameraPosition / scale;
			float magnitude = _camera.transform.localPosition.magnitude;
			_discHeading.SetCameraDistance(magnitude);
			_discPitch.SetCameraDistance(magnitude);
		}

		protected virtual void Awake()
		{
			_inputResponder.OnDrag = OnDrag;
			_inputResponder.OnPointerDown = OnPointerDown;
			_inputResponder.OnPointerUp = OnPointerUp;
			_inputResponder.IsResponding = () => base.gameObject.activeSelf;
		}

		protected virtual void Start()
		{
			_initialCameraPosition = _camera.transform.localPosition;
			SetScale(1f);
		}

		protected virtual void Update()
		{
			if (_selectedDisc == null)
			{
				if (_headingLocked != _navSphere.HeadingLocked)
				{
					_headingLocked = _navSphere.HeadingLocked;
					_discPitch.Locked = _headingLocked;
					_discHeading.Locked = _headingLocked;
				}
				Vector2 screenPosition = new Vector2(UnityEngine.Input.mousePosition.x, UnityEngine.Input.mousePosition.y);
				HighlightedIndicator = GetIndicatorAtScreenPosition(screenPosition);
				HighlightedDisc = GetDiscAtScreenPosition(screenPosition);
			}
			_discHeading.Animate(Time.unscaledDeltaTime);
			_discPitch.Animate(Time.unscaledDeltaTime);
			if (_soundTimer > 0f)
			{
				_soundTimer -= Time.unscaledDeltaTime;
			}
		}

		private NavSphereDiscScript GetDiscAtScreenPosition(Vector2 screenPosition)
		{
			NavSphereDiscScript result = null;
			Ray ray = Utilities.ScreenPointToRay(_camera, screenPosition);
			int num;
			for (num = Physics.RaycastNonAlloc(ray, _raycastHits, 10000f, 134217728); num == _raycastHits.Length; num = Physics.RaycastNonAlloc(ray, _raycastHits, 10000f, 134217728))
			{
				_raycastHits = new RaycastHit[_raycastHits.Length * 2];
			}
			if (num == 2 && _raycastHits[0].distance > _raycastHits[1].distance)
			{
				RaycastHit raycastHit = _raycastHits[1];
				_raycastHits[1] = _raycastHits[0];
				_raycastHits[0] = raycastHit;
			}
			for (int i = 0; i < num; i++)
			{
				Vector3 vector = _raycastHits[i].collider.transform.InverseTransformPoint(_raycastHits[i].point);
				vector.y = 0f;
				if (vector.magnitude > _hitRadius)
				{
					result = _raycastHits[i].collider.GetComponent<NavSphereDiscScript>();
					break;
				}
			}
			return result;
		}

		private NavSphereIndicatorScript GetIndicatorAtScreenPosition(Vector2 screenPosition)
		{
			NavSphereIndicatorScript result = null;
			_discHeading.ColliderEnabled = false;
			_discPitch.ColliderEnabled = false;
			if (Physics.Raycast(Utilities.ScreenPointToRay(_camera, screenPosition), out var hitInfo, 10000f, 134217728))
			{
				result = hitInfo.collider.GetComponent<NavSphereIndicatorScript>();
			}
			_discPitch.ColliderEnabled = true;
			_discHeading.ColliderEnabled = _headingVisible;
			_discPitch.ColliderEnabled = true;
			return result;
		}

		private bool HandleEvent(PointerEventData eventData)
		{
			if (_eventHandled)
			{
				return true;
			}
			if (eventData.button != PointerEventData.InputButton.Left)
			{
				return false;
			}
			Ray ray = Utilities.ScreenPointToRay(_camera, eventData.position);
			bool result = false;
			if (_selectedDisc == null)
			{
				NavSphereIndicatorScript indicatorAtScreenPosition = GetIndicatorAtScreenPosition(eventData.position);
				if (indicatorAtScreenPosition != null)
				{
					LockIndicator(indicatorAtScreenPosition);
					result = (_eventHandled = true);
				}
				else
				{
					NavSphereDiscScript discAtScreenPosition = GetDiscAtScreenPosition(eventData.position);
					if (discAtScreenPosition != null && discAtScreenPosition.CalculateRayIntersectionAngle(ray, out _startRayAngle, initialRayCast: true))
					{
						LockIndicator(null);
						_selectedDisc = discAtScreenPosition;
						_selectedDisc.ShowMarkings(ray.direction);
						_startDiscAngle = _selectedDisc.Angle;
						_soundDiscAngle = (int)_selectedDisc.Angle;
						_discPitch.ColliderEnabled = false;
						_discHeading.ColliderEnabled = false;
						discAtScreenPosition.Selected = true;
						Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Flight.NavSpherePressed);
						result = true;
					}
				}
			}
			else
			{
				float angle = 0f;
				if (_selectedDisc.CalculateRayIntersectionAngle(ray, out angle, initialRayCast: false))
				{
					float num = angle - _startRayAngle;
					if (num > 180f)
					{
						num -= 360f;
					}
					else if (num < -180f)
					{
						num += 360f;
					}
					float num2 = _navSphere.Pitch;
					float num3 = _navSphere.Heading;
					if (_selectedDisc.DiscType == NavSphereDiscType.Heading)
					{
						num3 = _startDiscAngle + num;
						int num4 = (int)num3;
						if (_selectedDisc.Flipped)
						{
							num4 += 180;
						}
						num4 = (int)Utilities.LimitAngle180(num4);
						if (num4 < 0)
						{
							num4 += 360;
						}
						FlightSceneScript.Instance.FlightSceneUI.ShowMessage($"Heading: {num4}°");
					}
					else
					{
						num2 = _startDiscAngle + num;
						int num5 = (int)Utilities.LimitAngle180(num2);
						if (num5 > 90)
						{
							num5 = 90 - (num5 - 90);
						}
						else if (num5 < -90)
						{
							num5 = -90 - (num5 + 90);
						}
						FlightSceneScript.Instance.FlightSceneUI.ShowMessage($"Pitch: {num5}°");
					}
					_navSphere.LockHeading(num2, num3);
					result = true;
					if (_soundDiscAngle != (int)_selectedDisc.Angle && _soundTimer <= 0f)
					{
						_soundDiscAngle = (int)_selectedDisc.Angle;
						_soundTimer = 0.05f;
						Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Flight.NavSphereMoved);
					}
				}
			}
			return result;
		}
	}
}
