using System.Collections.Generic;
using UnityEngine;

namespace Brewery.Employee
{
	public class BreweryEmployeeHomePoint : MonoBehaviour
	{
		private const string TAG = "BREW_EMP|HOME";

		[SerializeField]
		private string homeId;

		private static readonly Dictionary<string, BreweryEmployeeHomePoint> homePoints;

		public string HomeId => null;

		public Vector3 Position => default(Vector3);

		public Quaternion Rotation => default(Quaternion);

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public static BreweryEmployeeHomePoint GetByHomeId(string id)
		{
			return null;
		}

		public static IReadOnlyDictionary<string, BreweryEmployeeHomePoint> GetAll()
		{
			return null;
		}

		private void OnDrawGizmos()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
