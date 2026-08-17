using Assets.Scripts.Actors.Player;
using Cpp2ILInjected;
using UnityEngine;

public class DisableOutOfCameraRange : MonoBehaviour
{
	private float repeatTime = 0.5f;

	public float range = 50f;

	private float sqrRange;

	private bool isVisible;

	public bool useXZVector;

	public GameObject[] objectsToUse;

	private void Start()
	{
		//IL_003c: Expected O, but got I4
		//IL_0045: Expected O, but got I4
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183171FDD]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		GameObject[] array = objectsToUse;
		isVisible = false;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < array.Length)
		{
			array[obj].SetActive(value: false);
			obj++;
			obj2 = obj;
		}
		float num = range * range;
		sqrRange = num;
		float time = Random.Range(0f, repeatTime);
		InvokeRepeating("SlowUpdate", time, repeatTime);
	}

	private void SlowUpdate()
	{
		CheckVisibility();
	}

	private unsafe void CheckVisibility()
	{
		//IL_00a1: Expected O, but got Ref
		//IL_00f6: Expected O, but got Ref
		//IL_01ec: Expected O, but got I4
		//IL_01f5: Expected O, but got I4
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Expected O, but got Unknown
		float x;
		float y;
		float z;
		Vector3 vector;
		if (!useXZVector)
		{
			Transform transform = MyPlayer.Instance.transform;
			Vector3 position = transform.position;
			x = position.x;
			y = position.y;
			z = position.z;
			Transform transform2 = base.transform;
			vector = transform2.position;
		}
		else
		{
			Transform transform3 = MyPlayer.Instance.transform;
			Vector3 position2 = transform3.position;
			float num = default(float);
			Vector3 vector2 = VectorExtensions.XZVector((Vector3)(&num));
			x = vector2.x;
			y = vector2.y;
			z = vector2.z;
			Transform transform4 = base.transform;
			Vector3 position3 = transform4.position;
			vector = VectorExtensions.XZVector((Vector3)(&num));
		}
		float num2 = x - vector.x;
		float num3 = y - vector.y;
		float num4 = z - vector.z;
		float num5 = num2 * num2;
		float num6 = num3 * num3;
		float num7 = num4 * num4;
		float num8 = num6 + num5;
		float num9 = num8 + num7;
		if (!isVisible)
		{
			if (sqrRange > num9)
			{
				GameObject[] array = objectsToUse;
				isVisible = true;
				object obj = 0;
				object obj2 = 0;
				while ((nint)obj < array.Length)
				{
					array[obj2].SetActive(value: true);
					obj2++;
					obj = obj2;
				}
				return;
			}
			if (!isVisible)
			{
				return;
			}
		}
		if (num9 > sqrRange)
		{
			Hide();
		}
	}

	private void Hide()
	{
		//IL_0023: Expected O, but got I4
		//IL_002c: Expected O, but got I4
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		GameObject[] array = objectsToUse;
		isVisible = false;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < array.Length)
		{
			array[obj2].SetActive(value: false);
			obj2++;
			obj = obj2;
		}
	}

	private void Show()
	{
		//IL_0023: Expected O, but got I4
		//IL_002c: Expected O, but got I4
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		GameObject[] array = objectsToUse;
		isVisible = true;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < array.Length)
		{
			array[obj2].SetActive(value: true);
			obj2++;
			obj = obj2;
		}
	}
}
