using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land
{
	public class SimpleWheel
	{
		private float _currentWheelRotation;

		private float _damper;

		private bool _isDestroyed;

		private Transform _parent;

		private float _prevCompression;

		private float _radius;

		private Rigidbody _rigidBody;

		private float _springForce;

		private Transform _wheel;

		private Vector3 _wheelAxis;

		private Transform _wheelContainer;

		private Vector3 _wheelNeutralRotation;

		private float _wheelRotationRate;

		public bool Grounded { get; private set; }

		public bool IsDestroyed => _isDestroyed;

		public bool IsOnRoad { get; private set; }

		public SimpleWheel(Transform wheel, Rigidbody rigidBody, float springForce, float damper, Vector3 wheelAxis)
		{
			_springForce = springForce;
			_damper = damper;
			_rigidBody = rigidBody;
			_wheel = wheel;
			_parent = rigidBody.transform;
			_wheelAxis = wheelAxis;
			GameObject gameObject = new GameObject("WheelContainer");
			_wheelContainer = gameObject.transform;
			_wheelContainer.SetParent(wheel.parent);
			_wheelContainer.SetPositionAndRotation(wheel.position, wheel.rotation);
			_wheelContainer.localScale = Vector3.one;
			wheel.SetParent(_wheelContainer, worldPositionStays: true);
			_wheelNeutralRotation = _wheel.localEulerAngles;
			CalculateWheelDimensions();
		}

		public unsafe static NativeArray<RaycastCommand> BuildRaycastCommands(List<SimpleWheel> wheels)
		{
			NativeArray<RaycastCommand> nativeArray = new NativeArray<RaycastCommand>(wheels.Count, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
			int layerMask = 9441280;
			Vector3 down = Vector3.down;
			QueryParameters queryParameters = new QueryParameters(layerMask, hitMultipleFaces: false, QueryTriggerInteraction.Ignore);
			PhysicsScene defaultPhysicsScene = Physics.defaultPhysicsScene;
			void* unsafePtr = nativeArray.GetUnsafePtr();
			for (int i = 0; i < wheels.Count; i++)
			{
				SimpleWheel simpleWheel = wheels[i];
				float distance = simpleWheel._radius * 2f;
				Vector3 position = simpleWheel._wheelContainer.position;
				position.y += simpleWheel._radius;
				ref RaycastCommand reference = ref UnsafeUtility.ArrayElementAsRef<RaycastCommand>(unsafePtr, i);
				reference.from = position;
				reference.direction = down;
				reference.queryParameters = queryParameters;
				reference.distance = distance;
				reference.physicsScene = defaultPhysicsScene;
			}
			return nativeArray;
		}

		public void OnDestroy()
		{
			_isDestroyed = true;
		}

		public void RotateWheel(float currentForwardVelocity)
		{
			_currentWheelRotation += _wheelRotationRate * currentForwardVelocity * Time.deltaTime;
			_currentWheelRotation %= 360f;
			_wheel.localEulerAngles = _wheelNeutralRotation + _wheelAxis * _currentWheelRotation;
		}

		public void UpdateSuspension(ref RaycastCommand raycastCommand, ref RaycastHit raycastResult)
		{
			if (!_isDestroyed)
			{
				IsOnRoad = false;
				Grounded = false;
				Collider collider = raycastResult.collider;
				if (collider != null)
				{
					float num = Mathf.Clamp01(raycastCommand.distance - raycastResult.distance);
					float num2 = num * _springForce;
					float num3 = num - _prevCompression;
					_prevCompression = num;
					num2 += num3 / Time.fixedDeltaTime * _damper;
					num2 = Mathf.Clamp(num2, -50f, 50f);
					_rigidBody.AddForceAtPosition(new Vector3(0f, num2, 0f), raycastCommand.from, ForceMode.Acceleration);
					IsOnRoad = collider.gameObject.layer == 12;
					Grounded = true;
					_wheel.localPosition = new Vector3(0f, num, 0f);
				}
			}
		}

		private void CalculateWheelDimensions()
		{
			MeshRenderer componentInChildren = _wheelContainer.GetComponentInChildren<MeshRenderer>();
			_radius = 0.4f;
			if (componentInChildren != null)
			{
				_radius = Mathf.Max(componentInChildren.localBounds.size.x, componentInChildren.localBounds.size.y, componentInChildren.localBounds.size.z) * 0.5f * _wheel.lossyScale.x;
			}
			float num = 2f * _radius * MathF.PI;
			_wheelRotationRate = 1f / num * 360f;
		}
	}
}
