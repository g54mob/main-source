using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace VampireSurvivors.UI;

public class TextReplacer : MonoBehaviour
{
	private TMP_FontAsset _Font;

	private List<Transform> _IgnorePages;

	public void Replace()
	{
		//IL_001c: Expected O, but got I4
		//IL_0025: Expected O, but got I4
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Expected O, but got Unknown
		TextMeshProUGUI[] array = UnityEngine.Object.FindObjectsOfType<TextMeshProUGUI>(includeInactive: true);
		object obj = 0;
		nint num3 = default(nint);
		nint num4;
		int num = default(int);
		int num5;
		for (object obj2 = 0; (nint)obj2 < array.Length; obj++, num3 = num4, num = num5, obj2 = obj)
		{
			List<Transform> ignorePages = _IgnorePages;
			TextMeshProUGUI textMeshProUGUI = array[obj];
			Transform value = array[obj].transform;
			if (ignorePages._size != 0)
			{
				num = ignorePages._size;
				int num2 = Array.IndexOf((object[])ignorePages._items, (object)value, 0, ignorePages._size);
				bool flag = num2 != -1;
				num3 = 0;
				num4 = 0;
				num5 = ignorePages._size;
				if (flag)
				{
					continue;
				}
			}
			array[obj].font = _Font;
			TMP_FontAsset font = _Font;
			array[obj].material = ((TMP_Asset)font).m_Material;
			if (((TMP_Text)textMeshProUGUI).m_VerticalAlignment != VerticalAlignmentOptions.Baseline)
			{
				((TMP_Text)textMeshProUGUI).m_VerticalAlignment = VerticalAlignmentOptions.Baseline;
				((TMP_Text)textMeshProUGUI).m_havePropertiesChanged = true;
				array[obj].SetVerticesDirty();
			}
			array[obj].SetAllDirty();
			GameObject gameObject = array[obj].gameObject;
			string text = ((UnityEngine.Object)gameObject).GetName();
			string message = "Updated : " + text;
			Debug.Log(message);
			num4 = num3;
			num5 = num;
		}
	}

	public TextReplacer()
	{
		List<Transform> ignorePages = new List<Transform>();
		_IgnorePages = ignorePages;
	}
}
