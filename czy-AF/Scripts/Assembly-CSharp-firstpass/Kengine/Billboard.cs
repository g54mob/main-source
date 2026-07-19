using UnityEngine;

namespace Kengine
{
	[AddComponentMenu("Kengine/Modifier/Billboard")]
	public class Billboard : MonoBehaviour
	{
		public bool flip;

		private void Update()
		{
			if (flip)
			{
				base.transform.rotation = Quaternion.LookRotation(base.transform.position + Camera.main.transform.position);
			}
			else
			{
				base.transform.rotation = Quaternion.LookRotation(base.transform.position - Camera.main.transform.position);
			}
		}
	}
}
