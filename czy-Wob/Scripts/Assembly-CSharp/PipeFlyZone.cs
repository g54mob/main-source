using System.Collections.Generic;
using UnityEngine;

public class PipeFlyZone : MonoBehaviour
{
	public bool pipeJoint;

	public bool pipePortal;

	public bool pipePortalExit;

	public Vector3 newGrav = Physics.gravity;

	private int segmentIndex = -1;

	private float scaleFactor = 1f;

	private float gravMultiplier = 200f;

	private float magnitudeMin = 10f;

	private Pipe.PipeSegmentType segmentDir;

	private Pipe.PipeSegmentType prevSegmentDir;

	private List<string> launchables = new List<string>
	{
		Tags.POOP,
		Tags.EGG,
		Tags.TOY,
		Tags.FOOD,
		Tags.DIRT_CLUMP,
		Tags.CAPSULE,
		Tags.DOG_CORE,
		Tags.COCOON,
		Tags.SEED_PACKET,
		Tags.DEN_UPGRADE,
		Tags.VACUUM,
		Tags.SNOWBALL,
		Tags.GIFT
	};

	private Pipe pipeRef;

	private void Start()
	{
		pipeRef = base.transform.root.GetComponent<Pipe>();
		UpdateGravity();
	}

	private void Update()
	{
		UpdateGravity();
	}

	public void SetSegmentDir(Pipe.PipeSegmentType dir)
	{
		segmentDir = dir;
	}

	public void SetPrevSegmentDir(Pipe.PipeSegmentType prevDir)
	{
		prevSegmentDir = prevDir;
	}

	public void SetGravScaleFactor(float scaleFactor)
	{
		this.scaleFactor = scaleFactor;
	}

	public void SetSegmentIndex(int newIndex)
	{
		segmentIndex = newIndex;
	}

	private void UpdateGravity()
	{
		if (pipeJoint)
		{
			Vector3 vector = base.transform.forward;
			if (pipeRef.DefaultDirection())
			{
				switch (segmentDir)
				{
				case Pipe.PipeSegmentType.Up:
					vector = Vector3.up;
					break;
				case Pipe.PipeSegmentType.Down:
					vector = Vector3.down;
					break;
				case Pipe.PipeSegmentType.Left:
					vector = Vector3.left;
					break;
				case Pipe.PipeSegmentType.Right:
					vector = Vector3.right;
					break;
				case Pipe.PipeSegmentType.Forward:
					vector = Vector3.back;
					break;
				case Pipe.PipeSegmentType.Backward:
					vector = Vector3.forward;
					break;
				}
			}
			else
			{
				switch (prevSegmentDir)
				{
				case Pipe.PipeSegmentType.Up:
					vector = Vector3.down;
					break;
				case Pipe.PipeSegmentType.Down:
					vector = Vector3.up;
					break;
				case Pipe.PipeSegmentType.Left:
					vector = Vector3.right;
					break;
				case Pipe.PipeSegmentType.Right:
					vector = Vector3.left;
					break;
				case Pipe.PipeSegmentType.Forward:
					vector = Vector3.forward;
					break;
				case Pipe.PipeSegmentType.Backward:
					vector = Vector3.back;
					break;
				}
			}
			newGrav = vector * gravMultiplier * scaleFactor;
		}
		else
		{
			if (pipePortal && !pipePortalExit)
			{
				newGrav = -base.transform.up * gravMultiplier * scaleFactor;
			}
			else
			{
				newGrav = base.transform.up * gravMultiplier * scaleFactor;
			}
			if (!pipeRef.DefaultDirection())
			{
				newGrav = pipeRef.ReverseSegmentGravity(newGrav, segmentIndex);
			}
		}
	}

	private void OnTriggerStay(Collider collider)
	{
		string text = collider.transform.root.gameObject.tag;
		string text2 = collider.transform.root.GetChild(0).tag;
		if (text == Tags.DOG)
		{
			GameObject gameObject = collider.gameObject;
			Rigidbody component = gameObject.GetComponent<Rigidbody>();
			while (component == null && gameObject != null)
			{
				gameObject = gameObject.transform.parent.gameObject;
				component = gameObject.GetComponent<Rigidbody>();
			}
			LaunchDog(collider.transform.root.gameObject, component);
		}
		else if (launchables.Contains(text))
		{
			LaunchObj(collider.gameObject);
		}
		else if (text == Tags.CLICKABLE_OBJECT && text2 == Tags.EGG)
		{
			LaunchObj(collider.gameObject);
		}
	}

	private void LaunchDog(GameObject dog, Rigidbody hitBody)
	{
		Vector3 vector = newGrav * Time.fixedDeltaTime;
		hitBody.AddForce(vector, ForceMode.Impulse);
		if (pipeRef != null && !pipeRef.IsObjectBeingGrabbed(dog) && hitBody.velocity.magnitude < magnitudeMin)
		{
			hitBody.AddForce(vector * 10f, ForceMode.Impulse);
		}
	}

	private void LaunchObj(GameObject obj)
	{
		float num = 1f;
		Gravboost component = obj.GetComponent<Gravboost>();
		Rigidbody rigidbody = obj.GetComponent<Rigidbody>();
		if (rigidbody == null)
		{
			rigidbody = obj.transform.root.gameObject.GetComponentInChildren<Rigidbody>();
			if (rigidbody == null)
			{
				Debug.LogError("Attempting to launch an object without an easily accessible rigidbody.");
				return;
			}
		}
		if (component != null)
		{
			num = 2f;
		}
		Vector3 vector = newGrav * num * (rigidbody.mass / 10f) * Time.fixedDeltaTime;
		rigidbody.AddForce(vector, ForceMode.Impulse);
		if (pipeRef != null && !pipeRef.IsObjectBeingGrabbed(obj.transform.root.gameObject) && rigidbody.velocity.magnitude < magnitudeMin)
		{
			rigidbody.AddForce(vector * 100f, ForceMode.Impulse);
		}
	}
}
