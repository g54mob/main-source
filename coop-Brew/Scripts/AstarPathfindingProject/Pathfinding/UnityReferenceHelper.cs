using UnityEngine;

namespace Pathfinding
{
	[ExecuteInEditMode]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/unityreferencehelper.html")]
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
