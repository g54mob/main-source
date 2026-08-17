using System;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatContainer : MonoBehaviour
{
	public TextMeshProUGUI t_stat;

	public RawImage bar;

	private float value;

	public unsafe void SetStat(EStatCategory statCategory, float value)
	{
		//IL_004e: Expected O, but got Ref
		//IL_0044: Expected O, but got Ref
		object obj = default(object);
		string s = ((Enum)(&obj)).ToString();
		string text = EnumUtility.EnumToReadable(s);
		t_stat.text = text;
		this.value = value;
		Color statCategoryColor = MyColorUtility.GetStatCategoryColor(statCategory);
		object obj2 = default(object);
		bar.color = (Color)(&obj2);
	}

	private unsafe void Update()
	{
		//IL_005c: Invalid comparison between I4 and F4
		//IL_00a7: Expected F4, but got I4
		//IL_00b9: Expected O, but got Ref
		Transform transform = bar.transform;
		Transform transform2 = bar.transform;
		Vector3 localScale = transform2.localScale;
		float deltaTime = Time.deltaTime;
		float num = deltaTime * 8f;
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
		transform.localScale = (Vector3)(&num2);
	}
}
