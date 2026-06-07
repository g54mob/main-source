using System;
using Assets.Scripts.Flight.Combat;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Flight.UI.Targeting
{
	public class TargetingScriptXR : TargetingScript
	{
		[SerializeField]
		private GameObject _centerReticule;

		[SerializeField]
		private TextMeshProUGUI _lockWarning;

		[SerializeField]
		private Image _offscreenArrowSprite;

		[SerializeField]
		private Transform _offscreenIndicator;

		[SerializeField]
		private TextMeshProUGUI _offscreenLabel;

		[SerializeField]
		private GameObject _targetBoxClone;

		[SerializeField]
		private Transform _targets;

		public override Transform OffscreenIndicator => _offscreenIndicator;

		public override void EnableOffscreenIndicator(Vector3 screenPosition, float angle, string name, string text, Color color)
		{
			_offscreenActive = true;
			screenPosition.z = 0f;
			OffscreenIndicator.localPosition = screenPosition;
			OffscreenIndicator.localRotation = Quaternion.Euler(0f, 0f, angle);
			_offscreenArrowSprite.color = 0.75f * color;
			_offscreenLabel.text = name + "\n" + text;
			_offscreenLabel.color = color;
			_offscreenLabel.transform.localRotation = Quaternion.Euler(0f, 0f, 0f - angle);
		}

		protected override ITargetBox CreateTargetBox(TrackedTarget trackedTarget)
		{
			GameObject obj = UnityEngine.Object.Instantiate(_targetBoxClone);
			obj.transform.SetParent(_targets, worldPositionStays: false);
			obj.transform.localPosition = Vector3.zero;
			obj.transform.localScale = Vector3.one;
			obj.SetActive(value: true);
			TargetBoxScript component = obj.GetComponent<TargetBoxScript>();
			component.TargetingScript = this;
			component.TrackedTarget = trackedTarget;
			if (component.TrackedTarget.IsTracking)
			{
				component.gameObject.SetActive(value: true);
			}
			else
			{
				component.gameObject.SetActive(value: false);
			}
			return component;
		}

		protected override TargetingCircleScript CreateTargetingCircle(Transform targetingTransform)
		{
			throw new NotImplementedException();
		}

		protected override void EnableCenterReticle(bool enabled)
		{
			_centerReticule.SetActive(enabled);
		}

		protected override void EnableLockWarning(bool enable, string text)
		{
			_lockWarning.gameObject.SetActive(enable);
			if (enable)
			{
				_lockWarning.text = text;
			}
		}

		protected override void SetLockWarningText(string text)
		{
			_lockWarning.text = text;
		}

		protected override void Start()
		{
			base.Start();
			_targetBoxClone.SetActive(value: false);
		}

		protected override void Update()
		{
			base.Update();
		}

		private float DistanceAndDiameterToPixelSize(float distance, float diameter)
		{
			return diameter * 57.29578f * (float)Screen.height / (distance * base.MainCamera.fieldOfView);
		}
	}
}
