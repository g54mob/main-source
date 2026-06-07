using UnityEngine;

namespace CTS
{
	[DefaultExecutionOrder(100)]
	public class TriggerDebugEditor : MonoBehaviour
	{
		private void Start()
		{
			base.gameObject.GetComponent<Renderer>().enabled = false;
		}
	}
}
