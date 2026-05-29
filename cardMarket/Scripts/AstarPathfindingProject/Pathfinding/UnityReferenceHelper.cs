using Pathfinding.Util;
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
			return guid;
		}

		public void Awake()
		{
			Reset();
		}

		public void Reset()
		{
			if (string.IsNullOrEmpty(guid))
			{
				guid = Guid.NewGuid().ToString();
				Debug.Log("Created new GUID - " + guid, this);
			}
			else
			{
				if (base.gameObject.scene.name == null)
				{
					return;
				}
				UnityReferenceHelper[] array = UnityCompatibility.FindObjectsByTypeUnsorted<UnityReferenceHelper>();
				foreach (UnityReferenceHelper unityReferenceHelper in array)
				{
					if (unityReferenceHelper != this && guid == unityReferenceHelper.guid)
					{
						guid = Guid.NewGuid().ToString();
						Debug.Log("Created new GUID - " + guid, this);
						break;
					}
				}
			}
		}
	}
}
