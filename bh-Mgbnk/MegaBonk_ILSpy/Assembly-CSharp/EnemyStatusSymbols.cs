using System.Collections.Generic;
using UnityEngine;

public class EnemyStatusSymbols : MonoBehaviour
{
	public GameObject elite;

	public GameObject boss;

	public GameObject challenge;

	public GameObject bossMinimapIcon;

	public float size;

	public float padding;

	public unsafe void Set(bool isElite, bool isBoss, bool isChallenge)
	{
		//IL_015b: Expected O, but got Ref
		elite.SetActive(isElite);
		boss.SetActive(isBoss);
		challenge.SetActive(isChallenge);
		bossMinimapIcon.SetActive(isBoss);
		List<Transform> list = new List<Transform>();
		if (isElite)
		{
			Transform item = elite.transform;
			list.Add(item);
		}
		if (isBoss)
		{
			Transform item2 = boss.transform;
			list.Add(item2);
		}
		if (isChallenge)
		{
			Transform item3 = challenge.transform;
			list.Add(item3);
		}
		int num = 0;
		int num2 = 0;
		float num3 = default(float);
		while (num < list._size)
		{
			Transform transform = list.get_Item(num2);
			transform.localPosition = (Vector3)(&num3);
			num2++;
			num = num2;
		}
	}
}
