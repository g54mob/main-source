using System.Collections.Generic;
using UnityEngine;

public class Tips : AutopediaPage
{
	private enum Type
	{
		Tip12 = 0,
		Tip1 = 1,
		Tip4 = 2,
		Tip14 = 3,
		Tip8 = 4,
		Tip9 = 5,
		Tip10 = 6,
		Tip6 = 7,
		Tip7 = 8,
		Tip11 = 9,
		Tip2 = 10,
		Tip3 = 11,
		Tip13 = 12,
		Total = 13
	}

	private BaseScrollView m_ScrollView;

	private List<BaseText> m_Texts;

	private List<BaseText> m_Dots;

	private void Awake()
	{
		m_ScrollView = base.transform.Find("BaseScrollView").GetComponent<BaseScrollView>();
		BaseText component = m_ScrollView.GetContent().transform.Find("DefaultTipText").GetComponent<BaseText>();
		component.SetActive(false);
		BaseText component2 = m_ScrollView.GetContent().transform.Find("DefaultTipDot").GetComponent<BaseText>();
		component2.SetActive(false);
		m_Texts = new List<BaseText>();
		m_Dots = new List<BaseText>();
		for (int i = 0; i < 13; i++)
		{
			BaseText baseText = Object.Instantiate(component, m_ScrollView.GetContent().transform);
			baseText.GetComponent<RectTransform>().offsetMin = new Vector2(10f, 0f);
			baseText.GetComponent<RectTransform>().offsetMax = new Vector2(-10f, 0f);
			Type type = (Type)i;
			string newText = "Tips" + type;
			baseText.SetTextFromID(newText);
			m_Texts.Add(baseText);
			BaseText baseText2 = Object.Instantiate(component2, m_ScrollView.GetContent().transform);
			baseText2.SetActive(true);
			m_Dots.Add(baseText2);
		}
	}

	private void UpdateText()
	{
		float num = 15f;
		float num2 = 0f;
		foreach (BaseText text in m_Texts)
		{
			text.SetActive(true);
			text.m_Text.ForceMeshUpdate(true);
			num2 += text.GetPreferredHeight() + num;
		}
		m_ScrollView.SetScrollSize(num2);
		float num3 = -10f;
		for (int i = 0; i < m_Texts.Count; i++)
		{
			BaseText baseText = m_Texts[i];
			baseText.GetComponent<RectTransform>().offsetMin = new Vector2(35f, num3 - baseText.GetPreferredHeight());
			baseText.GetComponent<RectTransform>().offsetMax = new Vector2(-10f, num3);
			m_Dots[i].transform.localPosition = new Vector3(10f, num3);
			num3 -= baseText.GetPreferredHeight() + num;
		}
	}

	private void Update()
	{
		UpdateText();
	}
}
