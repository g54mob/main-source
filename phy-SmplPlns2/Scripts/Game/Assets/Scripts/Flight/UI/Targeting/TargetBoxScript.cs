using Assets.Scripts.Flight.Combat;
using Assets.Scripts.UI;
using Jundroo.Common.Cache;
using Jundroo.Common.Math;
using UnityEngine;

namespace Assets.Scripts.Flight.UI.Targeting
{
	public abstract class TargetBoxScript : MonoBehaviour, ITargetBox
	{
		[SerializeField]
		protected Camera _mainCamera;

		private CachedFloatString _distanceLabelCache = new CachedFloatString(10f, (float x) => x.Format(UnitType.LongDistance, solo: false, longName: false, "0.0"));

		private bool _occluded;

		public TargetingScript TargetingScript { get; set; }

		public TrackedTarget TrackedTarget { get; set; }

		protected abstract Color DistanceLabelColor { get; set; }

		protected abstract GameObject DistanceLabelObject { get; }

		protected abstract string DistanceLabelText { get; set; }

		protected abstract Color NameLabelColor { get; set; }

		protected abstract GameObject NameLabelObject { get; }

		protected abstract string NameLabelText { get; set; }

		protected abstract Color SpriteColor { get; set; }

		protected abstract bool SpriteEnabled { get; set; }

		public void Destroy()
		{
			if (this != null)
			{
				base.gameObject.SetActive(value: false);
				Object.Destroy(base.gameObject);
				base.transform.SetParent(null);
			}
		}

		public virtual void SetActive(bool active)
		{
			base.gameObject.SetActive(active);
		}

		protected virtual void Awake()
		{
		}

		protected abstract Vector3 GetScreenPos();

		protected abstract Vector3 GetWorldPoint(Vector3 screenPos);

		protected abstract bool IsVisible(Vector3 screenPos);

		protected virtual void LateUpdate()
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
			bool active = false;
			if (TrackedTarget.Selected)
			{
				SetOrder(1);
				SpriteEnabled = true;
				active = true;
				if (TrackedTarget.Target.TargetType == TargetType.Information)
				{
					SpriteColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
				}
				else if (TrackedTarget.IsLocked)
				{
					if (TrackedTarget.IsFriendly)
					{
						SpriteColor = new Color(0f, 0f, 1f, 1f);
					}
					else
					{
						SpriteColor = new Color(1f, 0f, 0f, 1f);
					}
				}
				else if (TrackedTarget.IsAcquiring)
				{
					float a = Mathf.Cos(TrackedTarget.LockPercentage * TrackedTarget.LockPercentage * 10f);
					if (TrackedTarget.IsFriendly)
					{
						SpriteColor = new Color(0f, 0f, 1f, a);
					}
					else
					{
						SpriteColor = new Color(1f, 0f, 0f, a);
					}
				}
				else if (TrackedTarget.IsFriendly)
				{
					SpriteColor = new Color(0f, 0f, 1f, 1f);
				}
				else
				{
					SpriteColor = new Color32(0, byte.MaxValue, 22, byte.MaxValue);
				}
				DistanceLabelColor = SpriteColor;
				NameLabelColor = SpriteColor;
				DistanceLabelText = _distanceLabelCache.Update(TrackedTarget.Distance);
				if (!IsVisible(vector))
				{
					SpriteEnabled = false;
					active = false;
					Vector3 vector2 = new Vector3((float)_mainCamera.pixelWidth * UserInterfaceScaleScript.UserInterfaceScale, (float)_mainCamera.pixelHeight * UserInterfaceScaleScript.UserInterfaceScale, 0f) * 0.5f;
					Vector3 vector3 = vector - vector2;
					if (vector.z < 0f)
					{
						vector3 = -vector3;
					}
					Vector3 normalized = vector3.normalized;
					float a2 = float.MaxValue;
					if (normalized.x != 0f)
					{
						a2 = (vector2.x - (float)Mathf.Max(UserInterfaceScaleScript.Margins.left, UserInterfaceScaleScript.Margins.right)) / Mathf.Abs(normalized.x);
					}
					float b = float.MaxValue;
					if (normalized.y != 0f)
					{
						b = vector2.y / Mathf.Abs(normalized.y);
					}
					Vector3 vector4 = Mathf.Min(a2, b) * normalized;
					vector = vector4 + vector2;
					float angle = Mathf.Atan2(vector3.y, vector3.x) * 57.29578f;
					TargetingScript.EnableOffscreenIndicator(vector4, angle, TrackedTarget.Target.Name, DistanceLabelText, SpriteColor);
				}
			}
			else
			{
				SpriteColor = new Color32(128, 128, 128, byte.MaxValue);
				SetOrder(2);
			}
			if (_occluded != TrackedTarget.Occluded)
			{
				_occluded = TrackedTarget.Occluded;
				if (_occluded)
				{
					NameLabelText = "OBSCURED";
				}
				else
				{
					NameLabelText = TrackedTarget.Target.Name;
				}
			}
			else
			{
				NameLabelText = TrackedTarget.Target.Name;
			}
			DistanceLabelObject.SetActive(active);
			NameLabelObject.SetActive(active);
			vector.z = 0f;
			base.transform.position = GetWorldPoint(vector);
		}

		protected abstract void SetOrder(int order);

		protected virtual void Start()
		{
			SpriteColor = new Color32(0, 0, 0, 0);
			NameLabelText = TrackedTarget.Target.Name;
		}

		private void OnClick()
		{
			TargetingSystem targetingSystem = TargetingScript.Aircraft?.TargetingSystem;
			if (targetingSystem != null && targetingSystem.CurrentTarget != TrackedTarget.Target)
			{
				targetingSystem.CurrentTarget = TrackedTarget.Target;
			}
		}
	}
}
