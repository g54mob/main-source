using System;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Flight.StartLocations
{
	public class StartLocation
	{
		public Vector3 DistributionAxis { get; set; }

		public string DynamicLocationId { get; set; }

		public Vector3 DynamicLocationPosition { get; set; }

		public StartLocationFlags Flags { get; set; }

		public string Id { get; set; }

		public float InitialThrottle { get; set; }

		public bool IsDynamic => DynamicLocationId != null;

		public float MaxDistributionAmount { get; set; }

		public string OverflowLocation { get; set; }

		public Vector3 Position { get; set; }

		public Vector3 Rotation { get; set; }

		public bool? StartOnGround { get; set; }

		public Vector3 Velocity { get; set; }

		protected bool IsReady
		{
			get
			{
				if (!IsDynamic)
				{
					return true;
				}
				return FlightSceneScript.Instance?.StartLocationManager.GetDynamicLocation(DynamicLocationId)?.isActiveAndEnabled == true;
			}
		}

		public StartLocation(Vector3 position, Vector3 rotation, float speed, bool? startOnGround)
			: this(position, rotation, Quaternion.Euler(rotation) * Vector3.forward * speed, startOnGround)
		{
		}

		public StartLocation(Vector3 position, Vector3 rotation, Vector3 velocity, bool? startOnGround, Vector3? distributionAxis = null, float? maxDistributionAmount = null)
		{
			Position = position;
			Rotation = rotation;
			Velocity = velocity;
			StartOnGround = startOnGround;
			DistributionAxis = distributionAxis ?? StartLocationData.DefaultDistributionAxis;
			MaxDistributionAmount = maxDistributionAmount ?? StartLocationData.DefaultMaxDistributionAmount;
		}

		public StartLocation(StartLocationData locationData)
		{
			Id = locationData.Id;
			Position = locationData.Position;
			Rotation = locationData.Rotation;
			Velocity = ((locationData.InitialSpeed > 0f) ? (Quaternion.Euler(Rotation) * Vector3.forward * locationData.InitialSpeed) : locationData.InitialVelocity);
			InitialThrottle = locationData.InitialThrottle;
			StartOnGround = locationData.StartOnGround;
			DistributionAxis = locationData.DistributionAxis;
			MaxDistributionAmount = locationData.MaxDistributionAmount;
			OverflowLocation = locationData.OverflowLocation;
			DynamicLocationId = locationData.DynamicLocationId;
			int num = (locationData.IsRunwayTakeoff ? 1 : 0);
			string displayName = locationData.DisplayName;
			Flags = (StartLocationFlags)(num | ((displayName != null && displayName.Contains("Final Approach", StringComparison.OrdinalIgnoreCase)) ? 2 : 0));
		}

		public void ReadyLocationSynchronously()
		{
			if (IsDynamic)
			{
				if (!IsReady)
				{
					throw new Exception("Attempted to synchronously ready a dynamic start location but the requested location '" + DynamicLocationId + "' was not yet loaded.");
				}
				ConvertDynamicLocation();
			}
		}

		public async UniTask<bool> WaitUntilReady(int timeout)
		{
			if (!IsDynamic)
			{
				return true;
			}
			try
			{
				if (!IsReady && !(await UniTaskEx.WaitUntilWithTimeout(() => IsReady, timeout)))
				{
					Debug.LogError("A timeout occurred while waiting for a dynamic start location to become ready. LocationID: " + DynamicLocationId);
					return false;
				}
				ConvertDynamicLocation();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				return false;
			}
			return true;
		}

		private void ConvertDynamicLocation()
		{
			if (!IsDynamic)
			{
				throw new NotSupportedException("Unable to convert the location because it is not a dynamic location.");
			}
			DynamicStartLocationScript dynamicStartLocationScript = FlightSceneScript.Instance?.StartLocationManager.GetDynamicLocation(DynamicLocationId);
			if (dynamicStartLocationScript == null)
			{
				throw new Exception("Unable to convert the dynamic start location '" + DynamicLocationId + "' because the location could not be found.");
			}
			Transform transform = dynamicStartLocationScript.transform;
			Position = Utility.ConvertFloatingOriginToAbsolutePosition(transform.TransformPoint(Position));
			Rotation = (transform.rotation * Quaternion.Euler(Rotation)).eulerAngles;
			DynamicStartLocationVelocityMode startVelocityMode = dynamicStartLocationScript.StartVelocityMode;
			if (startVelocityMode == DynamicStartLocationVelocityMode.InheritBodyVelocityAlways || (startVelocityMode == DynamicStartLocationVelocityMode.InheritBodyVelocityOnGround && (StartOnGround ?? (Velocity == Vector3.zero))))
			{
				Velocity = dynamicStartLocationScript.Body.linearVelocity;
			}
			DynamicLocationId = null;
			DynamicLocationPosition = default(Vector3);
		}
	}
}
