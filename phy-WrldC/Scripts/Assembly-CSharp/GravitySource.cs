using UnityEngine;

public class GravitySource : MonoBehaviour
{
	[SerializeField]
	private float gravity = 9.81f;

	private Rigidbody[] allRigidbodies;

	private void Awake()
	{
		ActionState.Instance.OnActionStartEvent += OnActionStartHandler;
		ActionState.Instance.OnActionEndEvent += OnActionEndHandler;
	}

	private void OnActionStartHandler()
	{
		Rigidbody[] array = GameManager.Instance.MainCreationController.view.GetAllRigidbodies();
		Rigidbody[] allLevelRigidbodies = GameManager.Instance.LevelManager.GetAllLevelRigidbodies();
		allRigidbodies = new Rigidbody[array.Length + allLevelRigidbodies.Length];
		array.CopyTo(allRigidbodies, 0);
		allLevelRigidbodies.CopyTo(allRigidbodies, array.Length);
	}

	private void OnActionEndHandler()
	{
		allRigidbodies = null;
	}

	private void FixedUpdate()
	{
		if (allRigidbodies == null)
		{
			return;
		}
		for (int i = 0; i < allRigidbodies.Length; i++)
		{
			Rigidbody rigidbody = allRigidbodies[i];
			if (!rigidbody.isKinematic)
			{
				rigidbody.AddForce((base.transform.position - rigidbody.transform.position).normalized * gravity, ForceMode.Acceleration);
			}
		}
	}
}
