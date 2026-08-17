using System;
using System.Globalization;
using System.Text;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Engine.Progress;

public class ProgressTargetText : ProgressTarget
{
	public Text Text;

	public TargetVariable TargetVariable = TargetVariable.Progress;

	public bool WholeNumbers = true;

	public bool UseMultiplier;

	public float Multiplier = 100f;

	public string Prefix;

	public string Suffix = "%";

	private bool m_initialized;

	private float m_targetValue;

	private StringBuilder m_stringBuilder;

	public override void UpdateTarget(Progressor progressor)
	{
		//IL_0078: Expected O, but got I4
		//IL_00b2: Expected O, but got I4
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected O, but got Unknown
		bool flag = m_initialized;
		Progressor progressor2 = progressor;
		if (!flag)
		{
			UpdateReference();
			bool flag2 = m_stringBuilder != null;
			progressor2 = null;
			if (!flag2)
			{
				StringBuilder stringBuilder = new StringBuilder();
				m_stringBuilder = stringBuilder;
				progressor2 = null;
			}
			m_initialized = true;
		}
		Text text = Text;
		if ((object)Text == null || ((UnityEngine.Object)text).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Progressor progressor3 = (Progressor)TargetVariable;
		m_targetValue = 0f;
		bool flag3 = TargetVariable == TargetVariable.Value;
		float num;
		float targetValue;
		if (!flag3)
		{
			object obj = TargetVariable - 1;
			if (!flag3)
			{
				object obj2 = obj - 1;
				if (!flag3)
				{
					object obj3 = obj2 - 1;
					if (flag3)
					{
						num = progressor.Progress;
						progressor2 = null;
						progressor3 = progressor;
						goto IL_041c;
					}
					if ((nint)obj3 == 1)
					{
						float progress = progressor.Progress;
						bool flag4 = !UseMultiplier;
						float num2 = (m_targetValue = 1f - progress);
						progressor2 = null;
						progressor3 = progressor;
						if (!flag4)
						{
							num2 *= Multiplier;
							m_targetValue = num2;
							progressor2 = null;
							progressor3 = progressor;
						}
						goto IL_03fd;
					}
				}
				else
				{
					bool flag5 = !UseMultiplier;
					m_targetValue = progressor.m_maxValue;
					if (!flag5)
					{
						targetValue = progressor.m_maxValue * Multiplier;
						goto IL_0294;
					}
				}
			}
			else
			{
				bool flag6 = !UseMultiplier;
				m_targetValue = progressor.m_minValue;
				if (!flag6)
				{
					targetValue = progressor.m_minValue * Multiplier;
					goto IL_0294;
				}
			}
			goto IL_03ee;
		}
		num = progressor.m_currentValue;
		goto IL_041c;
		IL_03ee:
		StringBuilder stringBuilder2 = m_stringBuilder;
		int length = stringBuilder2.m_ChunkLength + stringBuilder2.m_ChunkOffset;
		StringBuilder stringBuilder3 = stringBuilder2.Remove(0, length);
		StringBuilder stringBuilder4 = stringBuilder3.Append(Prefix);
		Thread currentThread = Thread.CurrentThread;
		CultureInfo currentCultureNoAppX = currentThread.GetCurrentCultureNoAppX();
		NumberFormatInfo instance = NumberFormatInfo.GetInstance(currentCultureNoAppX);
		string value = System.Number.FormatSingle(m_targetValue, null, instance);
		StringBuilder stringBuilder5 = stringBuilder4.Append(value);
		StringBuilder stringBuilder6 = stringBuilder5.Append(Suffix);
		string text2 = stringBuilder6.ToString();
		Text.text = text2;
		return;
		IL_03fd:
		if (WholeNumbers)
		{
			targetValue = m_targetValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
			goto IL_0294;
		}
		goto IL_03ee;
		IL_041c:
		bool flag7 = !UseMultiplier;
		m_targetValue = num;
		if (!flag7)
		{
			float targetValue2 = num * Multiplier;
			m_targetValue = targetValue2;
		}
		goto IL_03fd;
		IL_0294:
		m_targetValue = targetValue;
		goto IL_03ee;
	}

	private void Reset()
	{
		UpdateReference();
	}

	private void Init()
	{
		UpdateReference();
		if (m_stringBuilder == null)
		{
			StringBuilder stringBuilder = new StringBuilder();
			m_stringBuilder = stringBuilder;
		}
		m_initialized = true;
	}

	private void UpdateReference()
	{
		Text text = Text;
		if ((object)Text == null || ((UnityEngine.Object)text).m_CachedPtr == (IntPtr)0)
		{
			Text component = GetComponent<Text>();
			Text = component;
		}
	}

	public ProgressTargetText()
	{
		StringBuilder stringBuilder = new StringBuilder();
		m_stringBuilder = stringBuilder;
	}
}
