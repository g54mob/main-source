using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SuperTextMesh))]
public class STMRubyText : MonoBehaviour
{
	[Serializable]
	public class Ruby
	{
		public char ch;

		public string text;
	}

	public SuperTextMesh stm;

	public bool autoParse = true;

	public float verticalOffset;

	public float rubyTextSize = 0.25f;

	public Ruby[] ruby;

	private List<SuperTextMesh> rubyText = new List<SuperTextMesh>();

	private string[] split;

	private SuperTextMesh tempStm;

	private Vector3 tmpPos;

	public void OnEnable()
	{
		stm.OnCustomEvent += Event;
		if (autoParse)
		{
			stm.OnPreParse += Parse;
		}
		stm.OnRebuildEvent += ClearRubyText;
	}

	public void OnDisable()
	{
		stm.OnCustomEvent -= Event;
		if (autoParse)
		{
			stm.OnPreParse -= Parse;
		}
		stm.OnRebuildEvent -= ClearRubyText;
	}

	public void Reset()
	{
		stm = GetComponent<SuperTextMesh>();
	}

	public void Parse(STMTextContainer x)
	{
		for (int i = 0; i < x.text.Length; i++)
		{
			for (int j = 0; j < ruby.Length; j++)
			{
				if (x.text[i] == ruby[j].ch)
				{
					x.text = x.text.Insert(i, "<e=rt," + ruby[j].text + ">");
					i += 7 + ruby[j].text.Length;
				}
			}
		}
	}

	public void Event(string text, STMTextInfo info)
	{
		split = text.Split(',');
		if (split.Length == 2 && split[0] == "rt")
		{
			tempStm = new GameObject().AddComponent<SuperTextMesh>();
			tempStm.t.SetParent(base.transform);
			tempStm.t.name = split[1];
			tmpPos.x = info.Middle.x;
			tmpPos.y = info.pos.y + info.size.y + verticalOffset;
			tempStm.t.localPosition = tmpPos;
			tempStm.size = rubyTextSize;
			tempStm.font = stm.font;
			tempStm.color = stm.color;
			tempStm.anchor = TextAnchor.LowerCenter;
			tempStm.alignment = SuperTextMesh.Alignment.Center;
			tempStm.autoWrap = info.RelativeWidth;
			tempStm.bestFit = SuperTextMesh.BestFitMode.OverLimit;
			tempStm.text = split[1];
			rubyText.Add(tempStm);
		}
	}

	public void ClearRubyText()
	{
		Debug.Log("rebuild was called! clearing " + rubyText.Count + " objects!");
		for (int i = 0; i < rubyText.Count; i++)
		{
			UnityEngine.Object.Destroy(rubyText[i].gameObject);
		}
		rubyText.Clear();
	}
}
