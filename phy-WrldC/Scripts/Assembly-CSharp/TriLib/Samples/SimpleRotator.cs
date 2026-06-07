using UnityEngine;

namespace TriLib.Samples
{
	public class SimpleRotator : MonoBehaviour
	{
		protected void Update()
		{
			base.transform.Rotate(-10f * Time.deltaTime, -10f * Time.deltaTime, 0f);
		}
	}
}
