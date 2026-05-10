using System;
using TMPro;
using UnityEngine;

public class SystemDate : MonoBehaviour
{
	[SerializeField]
	private TMP_Text m_DateText;

	[SerializeField]
	private TMP_Text m_TimeText;

	[SerializeField]
	private float m_UpdateInterval;

	private WaitForSecondsRealtime m_Interval;

	private DateTime m_Time;

	private void Start()
	{
	}

	private void UpdateDate()
	{
	}
}
