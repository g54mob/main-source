using UnityEngine;

namespace Presentation.MirroredUtils
{
	public class UnMirroredView : MonoBehaviour
	{
		private void Start()
		{
			if (base.transform.lossyScale.x < 0f)
			{
				base.transform.localScale = new Vector3(0f - base.transform.localScale.x, base.transform.localScale.y, base.transform.localScale.z);
			}
		}
	}
}
