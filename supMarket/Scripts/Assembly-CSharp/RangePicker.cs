using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class RangePicker : MonoBehaviour
{
	[SerializeField]
	private Vector2Int m_Range;

	private int m_Value;

	[SerializeField]
	private TMP_Text m_Text;

	public Vector2Int Range
	{
		get
		{
			return default(Vector2Int);
		}
		set
		{
		}
	}

	public int Value
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public event Action<int> ValueChanged
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void ClampValue()
	{
	}

	private void UpdateUI()
	{
	}

	private void Start()
	{
	}

	public void TryAdd(int valueOffset)
	{
	}
}
