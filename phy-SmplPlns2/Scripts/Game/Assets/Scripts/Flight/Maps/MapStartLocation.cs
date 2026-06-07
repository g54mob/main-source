using UnityEngine;

namespace Assets.Scripts.Flight.Maps
{
	public class MapStartLocation : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("The initial forward airspeed of the player when starting at this map location (in meters per second).")]
		private float _initialSpeed;

		[SerializeField]
		[Tooltip("This is the name for this location that users will see in the map locations dialog box.")]
		private string _locationName;

		[SerializeField]
		[Tooltip("If set to true, this indicates that the player's aircraft should start situated on the ground at this location.")]
		private bool _startOnGround = true;

		public float InitialSpeed
		{
			get
			{
				return _initialSpeed;
			}
			set
			{
				_initialSpeed = value;
			}
		}

		public string LocationName
		{
			get
			{
				return _locationName;
			}
			set
			{
				_locationName = value;
			}
		}

		public bool StartOnGround
		{
			get
			{
				return _startOnGround;
			}
			set
			{
				_startOnGround = value;
			}
		}
	}
}
