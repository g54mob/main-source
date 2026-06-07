using UnityEngine;

namespace AllIn1VfxToolkit
{
	public class AllIn1LookAt : MonoBehaviour
	{
		private enum FaceDirection
		{
			Forward = 0,
			Up = 1,
			Right = 2
		}

		[SerializeField]
		private bool updateEveryFrame;

		[Space]
		[Header("Choose Target")]
		[SerializeField]
		private bool targetIsMainCamera;

		[SerializeField]
		private Transform target;

		[Space]
		[Header("Look At Direction")]
		[SerializeField]
		private FaceDirection faceDirection;

		[SerializeField]
		private bool negateDirection;

		private void Start()
		{
			if (targetIsMainCamera)
			{
				if ((object)Camera.main != null)
				{
					target = Camera.main.transform;
				}
				if (target == null)
				{
					Debug.LogError("No main camera was found, AllIn1LookAt component of " + base.gameObject.name + " will now be destroyed. Please double check your setup");
					Object.Destroy(this);
				}
			}
			else if (target == null)
			{
				Debug.LogError("No target was assigned, AllIn1LookAt component of " + base.gameObject.name + " will now be destroyed. Please double check your setup");
				Object.Destroy(this);
			}
			if (!updateEveryFrame)
			{
				LookAtCompute();
			}
		}

		private void Update()
		{
			if (updateEveryFrame)
			{
				LookAtCompute();
			}
		}

		private void LookAtCompute()
		{
			Vector3 vector = (target.position - base.transform.position).normalized;
			if (negateDirection)
			{
				vector = -vector;
			}
			switch (faceDirection)
			{
			case FaceDirection.Forward:
				base.transform.forward = vector;
				break;
			case FaceDirection.Up:
				base.transform.up = vector;
				break;
			case FaceDirection.Right:
				base.transform.right = vector;
				break;
			}
		}
	}
}
