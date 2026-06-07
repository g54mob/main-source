using UnityEngine;

namespace Pathfinding
{
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_unity_reference_helper.php")]
	[ExecuteInEditMode]
	public class UnityReferenceHelper : MonoBehaviour
	{
		[SerializeField]
		[HideInInspector]
		private string guid;

		public string GetGUID()
		{
			return null;
		}

		public void Awake()
		{
		}

		public void Reset()
		{
		}
	}
}
