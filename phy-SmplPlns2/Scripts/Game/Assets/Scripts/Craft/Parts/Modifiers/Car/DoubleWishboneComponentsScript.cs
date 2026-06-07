using System;
using Assets.Scripts.Craft.Parts.Modifiers.Powertrain;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Car
{
	public class DoubleWishboneComponentsScript : MonoBehaviour, IWheelSuspensionComponents
	{
		[Serializable]
		private class WheelSuspensionAttachPoint
		{
			[field: SerializeField]
			public bool RepositionAttachedParts { get; set; }

			[field: SerializeField]
			public Transform Transform { get; set; }
		}

		private ConnectingAssemblyScript[] _connectingAssemblies;

		private Vector3 _initialLinkPosition;

		[SerializeField]
		private Transform _linkTransform;

		[SerializeField]
		private Transform _scaleRoot;

		[SerializeField]
		private ConnectingAssemblyScript _shockAssembly;

		[SerializeField]
		private Transform _shockBottomCylinder;

		[SerializeField]
		private Transform _shockStart;

		private Vector3 _shockStartPosition;

		[SerializeField]
		private Transform _shockTarget;

		private Vector3 _shockTargetPosition;

		[SerializeField]
		private Transform _shockTopCylinder;

		private float _springLength = -1f;

		[SerializeField]
		private Transform _steeringAssembly;

		[SerializeField]
		private float _stiffnessCoilMax = 0.63f;

		[SerializeField]
		private Transform _stiffnessCollar;

		[SerializeField]
		private float _stiffnessCollarMin = 0.13f;

		private JWheelSuspensionScript _suspension;

		private UpdateAttachPointsScript _updateAttachPoints;

		private bool _updateConnectingAssemblies;

		public void Initialize(JWheelSuspensionScript suspension)
		{
			_suspension = suspension;
			_initialLinkPosition = _linkTransform.localPosition;
			_shockStartPosition = _shockStart.localPosition;
			_shockTargetPosition = _shockTarget.localPosition;
			_connectingAssemblies = GetComponentsInChildren<ConnectingAssemblyScript>(includeInactive: true);
			_updateAttachPoints = GetComponent<UpdateAttachPointsScript>();
		}

		public void UpdateComponents(bool repositionWheels)
		{
			_scaleRoot.localScale = _suspension.Data.Size * Vector3.one;
			float num = (_suspension.Data.RideHeightScale * 0.2f + _suspension.Data.Extension * 0.5f) * 0.8f;
			_shockTopCylinder.localScale = new Vector3(1f, 1f, num);
			_shockBottomCylinder.localScale = new Vector3(1f, 1f, num * 1.2f);
			float num2 = _stiffnessCollarMin + Mathf.Lerp(0f, _stiffnessCoilMax * num, Mathf.Clamp01(_suspension.Data.Stiffness / 2.5f));
			Vector3 localPosition = _stiffnessCollar.localPosition;
			localPosition.z = num2;
			_stiffnessCollar.localPosition = localPosition;
			_shockAssembly.ComponentStart.Length = num2 + 0.01f;
			Vector3 shockStartPosition = _shockStartPosition;
			Vector3 shockTargetPosition = _shockTargetPosition;
			float t = Mathf.Clamp01((_suspension.Data.ShockPosition + 1f) / 2f);
			shockStartPosition.x = Mathf.Lerp(0f - shockStartPosition.x, shockStartPosition.x, t);
			shockTargetPosition.x = Mathf.Lerp(0f - shockTargetPosition.x, shockTargetPosition.x, t);
			_shockStart.localPosition = shockStartPosition;
			_shockTarget.localPosition = shockTargetPosition;
			if (_suspension.PartScript.LoadContext == CraftLoadContext.Designer)
			{
				UpdateSuspensionVisuals(_suspension.Data.SuspensionLength, forceUpdate: true);
				_updateAttachPoints.UpdateAttachPoints(_suspension.PartScript, repositionWheels);
			}
		}

		public void UpdateSuspensionVisuals(JWheelScript wheel, AttachPointData attachPoint)
		{
			UpdateSuspensionVisuals(wheel.WheelCollider.SpringLength);
			_steeringAssembly.localEulerAngles = new Vector3(0f, wheel.WheelCollider.SteerAngle, 0f);
		}

		protected virtual void LateUpdate()
		{
			if (!_suspension.PartScript.Culled && _updateConnectingAssemblies)
			{
				UpdateConnectingAssemblies();
			}
		}

		private void UpdateConnectingAssemblies()
		{
			_updateConnectingAssemblies = false;
			Vector3 localPosition = _linkTransform.transform.localPosition;
			localPosition.z = _initialLinkPosition.z * _suspension.Data.Extension;
			localPosition.y = (0f - (_suspension.Data.RideHeight + (_springLength - _suspension.Data.SuspensionLength))) / _scaleRoot.localScale.y;
			_linkTransform.localPosition = localPosition;
			ConnectingAssemblyScript[] connectingAssemblies = _connectingAssemblies;
			foreach (ConnectingAssemblyScript connectingAssemblyScript in connectingAssemblies)
			{
				if (connectingAssemblyScript.gameObject.activeSelf)
				{
					connectingAssemblyScript.UpdateComponents();
				}
			}
		}

		private void UpdateSuspensionVisuals(float springLength, bool forceUpdate = false)
		{
			if (forceUpdate || Mathf.Abs(_springLength - springLength) > 0.01f)
			{
				_springLength = springLength;
				if (forceUpdate)
				{
					UpdateConnectingAssemblies();
				}
				else
				{
					_updateConnectingAssemblies = true;
				}
			}
		}
	}
}
