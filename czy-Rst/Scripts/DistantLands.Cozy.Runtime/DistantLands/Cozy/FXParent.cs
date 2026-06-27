using UnityEngine;

namespace DistantLands.Cozy
{
	[ExecuteAlways]
	public class FXParent : MonoBehaviour
	{
		private void OnEnable()
		{
			if (base.transform.parent == null)
			{
				Object.DestroyImmediate(base.gameObject);
			}
		}
	}
}
