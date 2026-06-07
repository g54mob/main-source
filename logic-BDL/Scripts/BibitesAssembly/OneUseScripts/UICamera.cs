using UnityEngine;

namespace OneUseScripts
{
	public class UICamera : MonoBehaviour
	{
		public static Camera cam;

		public void Awake()
		{
			cam = GetComponent<Camera>();
		}

		public void Init()
		{
			cam = GetComponent<Camera>();
		}
	}
}
