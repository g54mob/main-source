using UnityEngine;

public class MenuCamera : MonoBehaviour
{
	public Transform defaultTransform;

	public Transform characterSelectionTransform;

	private Transform currentTransform;

	public Camera camera;

	private void Start()
	{
		camera.useOcclusionCulling = false;
		currentTransform = defaultTransform;
	}

	public void GoToCharacters()
	{
		currentTransform = characterSelectionTransform;
	}

	public void GoToMain()
	{
		currentTransform = defaultTransform;
	}

	private unsafe void Update()
	{
		//IL_0075: Invalid comparison between I4 and F4
		//IL_00c0: Expected F4, but got I4
		//IL_00d2: Expected O, but got Ref
		//IL_0142: Expected O, but got Ref
		//IL_0142: Expected O, but got Ref
		//IL_0158: Expected O, but got Ref
		Transform transform = base.transform;
		Transform transform2 = base.transform;
		Vector3 position = transform2.position;
		Vector3 position2 = currentTransform.position;
		float deltaTime = Time.deltaTime;
		float num = deltaTime * 1.5f;
		if (!(0f > num))
		{
			if (num > 1f)
			{
				num = 1f;
			}
		}
		else
		{
			num = 0f;
		}
		float num2 = default(float);
		transform.position = (Vector3)(&num2);
		Transform transform3 = base.transform;
		Transform transform4 = base.transform;
		Quaternion rotation = transform4.rotation;
		Quaternion rotation2 = currentTransform.rotation;
		float deltaTime2 = Time.deltaTime;
		float t = deltaTime2 * 1.5f;
		float num3 = default(float);
		Quaternion quaternion = Quaternion.Lerp((Quaternion)(&num3), (Quaternion)(&num2), t);
		transform3.rotation = (Quaternion)(&num3);
	}
}
