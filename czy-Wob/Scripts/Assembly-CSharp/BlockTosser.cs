using InControl;
using UnityEngine;

public class BlockTosser : MonoBehaviour
{
	public GameObject objectToToss;

	public float tossForce = 1000f;

	public float mass = 1000f;

	public float scale = 5f;

	public bool rotationJiggle;

	public bool modifyObject = true;

	public bool onRightClick;

	public bool onLeftClick = true;

	public bool fromObjectPos;

	private void Update()
	{
		HandleInput();
	}

	private void HandleInput()
	{
		if (onLeftClick && GameControls.actions.Interact.WasPressed)
		{
			TossBlock();
		}
		if (onRightClick && GameControls.actions.Cancel.WasPressed)
		{
			TossBlock();
		}
	}

	private void TossBlock()
	{
		if (fromObjectPos)
		{
			TossBlockFromObj();
		}
		else
		{
			TossBlockFromCamera();
		}
	}

	private void TossBlockFromCamera()
	{
		GameObject gameObject = Object.Instantiate(objectToToss, Camera.main.transform.position, Quaternion.identity);
		gameObject.transform.localPosition += new Vector3(0f, 1f, 0f);
		if (modifyObject)
		{
			gameObject.transform.localScale = new Vector3(scale, scale, scale);
			gameObject.GetComponent<Rigidbody>().mass = mass;
		}
		Vector3 position = new Vector3(InputManager.MouseProvider.GetPosition().x, InputManager.MouseProvider.GetPosition().y, 10f);
		gameObject.transform.LookAt(Camera.main.ScreenToWorldPoint(position));
		Vector3 force = gameObject.transform.forward * tossForce;
		gameObject.GetComponentInChildren<Rigidbody>().AddForce(force, ForceMode.Impulse);
		if (rotationJiggle)
		{
			gameObject.transform.rotation = Random.rotation;
		}
	}

	private void TossBlockFromObj()
	{
		GameObject gameObject = Object.Instantiate(objectToToss, base.transform.position, base.transform.rotation);
		if (modifyObject)
		{
			gameObject.transform.localScale = new Vector3(scale, scale, scale);
			gameObject.GetComponent<Rigidbody>().mass = mass;
		}
		Vector3 force = gameObject.transform.forward * tossForce;
		Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
		if (rigidbody == null)
		{
			rigidbody = gameObject.GetComponentInChildren<Rigidbody>();
		}
		rigidbody.AddForce(force, ForceMode.Impulse);
		if (rotationJiggle)
		{
			gameObject.transform.rotation = Random.rotation;
		}
	}
}
