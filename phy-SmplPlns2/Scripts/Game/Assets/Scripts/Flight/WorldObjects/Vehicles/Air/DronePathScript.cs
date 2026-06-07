using SWS;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Air
{
	public class DronePathScript : MonoBehaviour
	{
		private PathManager _pathManager;

		[SerializeField]
		private Transform[] _startingPoints;

		public PathManager PathManager
		{
			get
			{
				if (_pathManager == null)
				{
					_pathManager = GetComponent<PathManager>();
				}
				return _pathManager;
			}
		}

		public Transform[] StartingPoints => _startingPoints;
	}
}
