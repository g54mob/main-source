using UnityEngine;

namespace Brewery.Employee
{
	[ExecuteAlways]
	public class EmployeeHomePoint : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("Unique ID for this home location (referenced by EmployeeScriptableObject)")]
		private string homeId;

		public string HomeId => null;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}
	}
}
