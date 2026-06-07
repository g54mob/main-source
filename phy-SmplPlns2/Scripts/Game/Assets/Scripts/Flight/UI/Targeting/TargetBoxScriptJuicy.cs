using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.Combat.Events;
using Assets.Scripts.Flight.Combat.Teams;
using Assets.Scripts.UI;
using Jundroo.Common.Cache;
using Jundroo.Common.Math;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Flight.UI.Targeting
{
	public class TargetBoxScriptJuicy : MonoBehaviour, ITargetBox
	{
		private TextWidget _distanceLabel;

		private CachedFloatString _distanceLabelCache = new CachedFloatString(10f, (float x) => x.Format(UnitType.LongDistance, solo: false, longName: false, "0.0"));

		private ImageWidget _lockSprite;

		private Camera _mainCamera;

		private TextWidget _nameLabel;

		private bool _occluded;

		private Widget _rootContainer;

		private ImageWidget _sprite;

		public bool SpriteEnabled
		{
			get
			{
				return _sprite.Visible;
			}
			set
			{
				_sprite.Visible = value;
			}
		}

		public TargetingScript TargetingScript { get; private set; }

		public TrackedTarget TrackedTarget { get; private set; }

		public Widget Widget { get; private set; }

		private Color SpriteColor => _sprite.Color.Base;

		public void Destroy()
		{
			TrackedTarget.IsTrackingChanged -= OnIsTrackingChanged;
			Widget.Destroy();
		}

		public void Initialize(TrackedTarget trackedTarget, TargetingScript targetingScript, Camera camera, Widget widget)
		{
			TrackedTarget = trackedTarget;
			TargetingScript = targetingScript;
			_mainCamera = camera;
			Widget = widget;
			_nameLabel = widget.FindWidget<TextWidget>("name-text");
			_distanceLabel = widget.FindWidget<TextWidget>("distance-text");
			_sprite = widget.FindWidget<ImageWidget>("box");
			_lockSprite = widget.FindWidget<ImageWidget>("target-lock-fill");
			_rootContainer = widget.FindWidget("target-root-container");
			Widget.EventHandler = this;
			trackedTarget.IsTrackingChanged += OnIsTrackingChanged;
		}

		public void SetActive(bool active)
		{
			Widget.Visible = active;
		}

		protected virtual void Awake()
		{
		}

		protected Vector2 GetLocalPoint(Vector3 screenPos)
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(base.transform.parent.GetComponent<RectTransform>(), screenPos, null, out var localPoint);
			return localPoint;
		}

		protected Vector3 GetScreenPos()
		{
			return _mainCamera.WorldToScreenPoint(TrackedTarget.Target.Position);
		}

		protected bool IsVisible(Vector3 screenPos)
		{
			return !(screenPos.z < 0f) && !(screenPos.x < 0f) && !(screenPos.x >= (float)_mainCamera.pixelWidth) && !(screenPos.y < 0f) && !(screenPos.y >= (float)_mainCamera.pixelHeight);
		}

		protected virtual void LateUpdate()
		{
			if (!TrackedTarget.Target.Visible)
			{
				_rootContainer.Visible = false;
			}
			else
			{
				if (TrackedTarget.Target.IsDead)
				{
					return;
				}
				Vector3 vector = GetScreenPos();
				if (vector.z < 0f)
				{
					SpriteEnabled = false;
				}
				else
				{
					SpriteEnabled = true;
				}
				string className = "selected";
				string className2 = "locked";
				string className3 = "acquiring";
				if (TrackedTarget.Target.TargetType == TargetType.Information)
				{
					Widget.EnableClass("information", enabled: true);
				}
				else if (TrackedTarget.Target.TargetType == TargetType.Laser)
				{
					Widget.EnableClass("laser", enabled: true);
				}
				else
				{
					Widget.EnableClass("friendly", TrackedTarget.AggressionLevel == AggressionLevel.Friendly);
					Widget.EnableClass("neutral", TrackedTarget.AggressionLevel == AggressionLevel.Neutral);
					Widget.EnableClass("enemy", TrackedTarget.AggressionLevel == AggressionLevel.Hostile);
				}
				bool flag = IsVisible(vector);
				_rootContainer.Visible = flag;
				bool visible = false;
				_lockSprite.Image.fillAmount = 0f;
				if (TrackedTarget.Selected)
				{
					Widget.AddClass(className);
					SpriteEnabled = true;
					visible = true;
					if (TrackedTarget.IsLocked)
					{
						Widget.AddClass(className2);
						_lockSprite.Image.fillAmount = 1f;
					}
					else
					{
						Widget.RemoveClass(className2);
					}
					if (TrackedTarget.IsAcquiring)
					{
						Widget.AddClass(className3);
						_lockSprite.Image.fillAmount = TrackedTarget.LockPercentage;
					}
					else
					{
						Widget.RemoveClass(className3);
					}
					_distanceLabel.Text = _distanceLabelCache.Update(TrackedTarget.Distance);
					if (!flag)
					{
						SpriteEnabled = false;
						visible = false;
						Vector3 vector2 = new Vector3(_mainCamera.pixelWidth, _mainCamera.pixelHeight, 0f) * 0.5f;
						Vector3 vector3 = vector - vector2;
						if (vector.z < 0f)
						{
							vector3 = -vector3;
						}
						vector3.z = 0f;
						Vector3 normalized = vector3.normalized;
						float a = float.MaxValue;
						if (normalized.x != 0f)
						{
							a = (vector2.x - (float)Mathf.Max(UserInterfaceScaleScript.Margins.left, UserInterfaceScaleScript.Margins.right)) / Mathf.Abs(normalized.x);
						}
						float b = float.MaxValue;
						if (normalized.y != 0f)
						{
							b = vector2.y / Mathf.Abs(normalized.y);
						}
						vector = Mathf.Min(a, b) * normalized + vector2;
						float angle = Mathf.Atan2(vector3.y, vector3.x) * 57.29578f;
						TargetingScript.EnableOffscreenIndicator(vector, angle, TrackedTarget.Target.Name, _distanceLabel.Text, SpriteColor);
					}
				}
				else if (Widget.RemoveClass(className))
				{
					Widget.RemoveClass(className2);
					Widget.RemoveClass(className3);
				}
				if (_occluded != TrackedTarget.Occluded)
				{
					_occluded = TrackedTarget.Occluded;
					if (_occluded)
					{
						_nameLabel.Text = "OBSCURED";
					}
					else
					{
						_nameLabel.Text = TrackedTarget.Target.Name;
					}
				}
				else
				{
					_nameLabel.Text = TrackedTarget.Target.Name;
				}
				_distanceLabel.Visible = visible;
				_nameLabel.Visible = true;
				vector.z = 0f;
				Widget.Rect.localPosition = GetLocalPoint(vector);
			}
		}

		protected virtual void Start()
		{
			_nameLabel.Text = TrackedTarget.Target.Name;
		}

		private void OnClicked(Widget widget)
		{
			TargetingSystem targetingSystem = TargetingScript.Aircraft?.TargetingSystem;
			if (targetingSystem != null && targetingSystem.CurrentTarget != TrackedTarget.Target)
			{
				targetingSystem.CurrentTarget = TrackedTarget.Target;
				Widget.SetIndex(0);
			}
		}

		private void OnIsTrackingChanged(object sender, TrackedTargetEventArgs e)
		{
			SetActive(e.TrackedTarget.IsTracking);
		}
	}
}
