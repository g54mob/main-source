using System;
using System.Collections;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Scenes.Startup;
using UnityEngine;

namespace Assets.Scripts.Flight.Cameras
{
	public class FlyByCameraController : CameraController
	{
		private const float FlyByVantagePointSecondsOut = 2f;

		private float _flyByDistanceThresholdToStartNew;

		private Vector3 _flyByVantagePoint;

		private float _flyByVantageStartTime;

		private Func<IRigidBody> _targetBody;

		private Func<Transform> _targetTransform;

		public FlyByCameraController(CameraManagerScript cameraManager, PartScript target)
			: base(cameraManager)
		{
			Initialize(cameraManager, () => target.transform, () => target.Body.RigidBody);
		}

		public FlyByCameraController(CameraManagerScript cameraManager, CameraVantageScript cameraVantage)
			: base(cameraManager)
		{
			base.CameraVantage = cameraVantage;
			Initialize(cameraManager, () => cameraVantage.TransformToTrack, () => cameraVantage.RigidBody);
		}

		public FlyByCameraController(CameraManagerScript cameraManager, Func<Transform> transform, Func<IRigidBody> body)
			: base(cameraManager)
		{
			Initialize(cameraManager, transform, body);
		}

		public override void AircraftRepositioned()
		{
			StartNewFlyByVantage();
		}

		public override void OnDeselected()
		{
			FloatingOriginScript.FloatOriginEnabled = true;
		}

		public override void OnDestroy()
		{
			GameWorld.Instance.FloatingOriginChanged -= OnFloatingOriginChanged;
		}

		public override void OnSelected()
		{
			FloatingOriginScript.FloatOriginEnabled = false;
			StartNewFlyByVantage();
		}

		public override void Update(int frameCount)
		{
			Transform transform = _targetTransform();
			base.CameraManager.CameraFocalPosition.position = transform.position;
			base.CameraTransform.position = _flyByVantagePoint;
			float num = Time.time - _flyByVantageStartTime;
			if ((Vector3.Distance(_flyByVantagePoint, transform.position) > _flyByDistanceThresholdToStartNew && num > 4f) || num > 8f)
			{
				StartNewFlyByVantage();
				_flyByVantageStartTime = Time.time;
			}
			if (UnityEngine.Input.GetKeyUp(KeyCode.F9) && !SimplePlanesDevConsoleScript.IsConsoleOpen)
			{
				StartNewFlyByVantage();
				_flyByVantageStartTime = Time.time;
			}
			base.CameraTransform.LookAt(transform, Vector3.up);
		}

		private void Initialize(CameraManagerScript cameraManager, Func<Transform> transform, Func<IRigidBody> body)
		{
			base.Name = "Fly-By View";
			_targetTransform = transform;
			_targetBody = body;
			base.RequiresDopplerFix = false;
			GameWorld.Instance.FloatingOriginChanged += OnFloatingOriginChanged;
		}

		private void OnFloatingOriginChanged(object sender, FloatingOriginChangedEventArgs e)
		{
			if (base.IsSelected)
			{
				_flyByVantagePoint -= e.NewFloatingOriginOffset - e.OldFloatingOriginOffset;
			}
		}

		private IEnumerator SetDopplarAtEndOfNextFrameAndDisableFloatingOrigin(float dopplar)
		{
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			if (base.IsSelected)
			{
				FloatingOriginScript.FloatOriginEnabled = false;
			}
		}

		private void StartNewFlyByVantage()
		{
			Transform transform = _targetTransform();
			IRigidBody rigidBody = _targetBody();
			if (rigidBody.velocity.magnitude < 5f)
			{
				float num = 20f;
				_flyByVantagePoint = transform.position + transform.forward * num;
				_flyByDistanceThresholdToStartNew = num * 1.5f;
			}
			else
			{
				Vector3 vector = rigidBody.velocity.normalized * Mathf.Min(rigidBody.velocity.magnitude, 1000f);
				_flyByVantagePoint = transform.position + vector * 3f;
				_flyByDistanceThresholdToStartNew = vector.magnitude * 2f * 2f;
			}
			float num2 = GameWorld.Instance.FloatingOriginSeaLevel.GetValueOrDefault() + 5f;
			if (Physics.Raycast(new Ray(_flyByVantagePoint + Vector3.up * 10000f, Vector3.down), out var hitInfo, float.PositiveInfinity, 1048576))
			{
				num2 = hitInfo.point.y + 5f;
			}
			if (_flyByVantagePoint.y <= num2)
			{
				_flyByVantagePoint.y = num2;
			}
			FloatingOriginScript.FloatOriginEnabled = true;
			base.CameraManager.StartCoroutine(SetDopplarAtEndOfNextFrameAndDisableFloatingOrigin(0.25f));
		}
	}
}
