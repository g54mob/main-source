using Assets.Scripts.Flight.StartLocations;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.ActivityFramework
{
	public class StartingLocationScript : MonoBehaviour
	{
		[SerializeField]
		private float _maxDistributionAmount;

		[SerializeField]
		private float _speed;

		[SerializeField]
		private bool _startOnGround = true;

		[field: SerializeField]
		public NetworkedActivityTeamIds TeamID { get; set; }

		public StartLocationData CreateStartLocationData()
		{
			return new StartLocationData
			{
				Rotation = base.transform.eulerAngles,
				Position = Utility.ConvertFloatingOriginToAbsolutePosition(base.transform.position),
				MaxDistributionAmount = _maxDistributionAmount,
				StartOnGround = _startOnGround,
				InitialSpeed = _speed
			};
		}

		[ContextMenu("Log Start Location XML")]
		private void LogStartLocationXml()
		{
			Debug.Log(CreateStartLocationData().GenerateXml().ToString());
		}
	}
}
