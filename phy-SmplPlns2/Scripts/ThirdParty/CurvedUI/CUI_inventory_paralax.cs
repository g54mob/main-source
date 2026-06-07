using UnityEngine;

namespace CurvedUI
{
	public class CUI_inventory_paralax : MonoBehaviour
	{
		[SerializeField]
		private Transform front;

		[SerializeField]
		private Transform back;

		private Vector3 initFG;

		private Vector3 initBG;

		public float change = 50f;

		private void Start()
		{
			initFG = front.position;
			initBG = back.position;
		}

		private void Update()
		{
			front.position = front.position.ModifyX(initFG.x + Input.mousePosition.x.Remap(0f, Screen.width, 0f - change, change));
			back.position = back.position.ModifyX(initBG.x - Input.mousePosition.x.Remap(0f, Screen.width, 0f - change, change));
			front.position = front.position.ModifyY(initFG.y + Input.mousePosition.y.Remap(0f, Screen.height, 0f - change, change) * (float)(Screen.height / Screen.width));
			back.position = back.position.ModifyY(initBG.y - Input.mousePosition.y.Remap(0f, Screen.height, 0f - change, change) * (float)(Screen.height / Screen.width));
		}
	}
}
