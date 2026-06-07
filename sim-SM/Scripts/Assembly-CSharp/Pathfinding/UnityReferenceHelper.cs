using UnityEngine;

namespace Pathfinding
{
	[ExecuteInEditMode]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_unity_reference_helper.php")]
	public class UnityReferenceHelper : MonoBehaviour
	{
		[HideInInspector]
		[SerializeField]
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
