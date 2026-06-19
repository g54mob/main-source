using UnityEngine;

namespace KrisDevelopment.AVS.Example
{
	[RequireComponent(typeof(CharacterController))]
	public class ExampleCharacterController : MonoBehaviour
	{
		private CharacterController controller;

		private void Start()
		{
			controller = GetComponent<CharacterController>();
		}

		private void Update()
		{
			controller.Move((base.transform.forward * Input.GetAxis("Vertical") + base.transform.right * Input.GetAxis("Horizontal") - Vector3.up) * 10f * Time.deltaTime);
		}
	}
}
