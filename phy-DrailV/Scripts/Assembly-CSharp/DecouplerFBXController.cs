using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecouplerFBXController : MonoBehaviour
{
	public const int MAX_CARS = 18;

	[Range(0f, 18f)]
	public int numFrontCars;

	[Range(0f, 18f)]
	public int numRearCars;

	public int blinkFlagsFront;

	public int blinkFlagsRear;

	[Range(-18f, 18f)]
	public int selectedCoupler;

	private GameObject[] frontCars;

	private GameObject[] rearCars;

	private GameObject[] frontCouplers;

	private GameObject[] rearCouplers;

	private bool blinkOn;

	private void Start()
	{
		List<Transform> list = new List<Transform>(base.transform.Find("indicator elements").GetComponentsInChildren<Transform>(includeInactive: true));
		List<Transform> list2 = list.FindAll((Transform t) => t.gameObject.name.StartsWith("Car"));
		List<Transform> list3 = list.FindAll((Transform t) => t.gameObject.name.StartsWith("Coupler"));
		List<GameObject> list4 = new List<GameObject>();
		List<GameObject> list5 = new List<GameObject>();
		for (int num = 0; num < list2.Count; num++)
		{
			GameObject item = list2[num].gameObject;
			if (num % 2 == 0)
			{
				list5.Add(item);
			}
			else
			{
				list4.Add(item);
			}
		}
		List<GameObject> list6 = new List<GameObject>();
		List<GameObject> list7 = new List<GameObject>();
		for (int num2 = 0; num2 < list3.Count; num2++)
		{
			GameObject item2 = list3[num2].gameObject;
			if (num2 % 2 == 0)
			{
				list7.Add(item2);
			}
			else
			{
				list6.Add(item2);
			}
		}
		frontCars = list4.ToArray();
		rearCars = list5.ToArray();
		frontCouplers = list6.ToArray();
		rearCouplers = list7.ToArray();
		GameObject[] array = frontCars;
		for (int num3 = 0; num3 < array.Length; num3++)
		{
			array[num3].SetActive(value: false);
		}
		array = rearCars;
		for (int num3 = 0; num3 < array.Length; num3++)
		{
			array[num3].SetActive(value: false);
		}
		array = frontCouplers;
		for (int num3 = 0; num3 < array.Length; num3++)
		{
			array[num3].SetActive(value: false);
		}
		array = rearCouplers;
		for (int num3 = 0; num3 < array.Length; num3++)
		{
			array[num3].SetActive(value: false);
		}
		StartCoroutine(Blink());
	}

	private IEnumerator Blink()
	{
		while (true)
		{
			yield return WaitFor.Seconds(0.15f);
			blinkOn = !blinkOn;
		}
	}

	private void Update()
	{
		for (int i = 0; i < frontCars.Length; i++)
		{
			bool flag = ((blinkFlagsFront >> i) & 1) == 0 || blinkOn;
			frontCars[i].SetActive(flag && i < numFrontCars);
		}
		for (int j = 0; j < rearCars.Length; j++)
		{
			bool flag2 = ((blinkFlagsRear >> j) & 1) == 0 || blinkOn;
			rearCars[j].SetActive(flag2 && j < numRearCars);
		}
		for (int k = 0; k < rearCouplers.Length; k++)
		{
			rearCouplers[k].SetActive(-k == selectedCoupler + 1);
		}
		for (int l = 0; l < frontCouplers.Length; l++)
		{
			frontCouplers[l].SetActive(l == selectedCoupler - 1);
		}
	}
}
