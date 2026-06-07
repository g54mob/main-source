using System;
using UnityEngine;

public class UIDisplayCtrl : MonoBehaviour
{
	[Flags]
	public enum eDefineType
	{
		None = 0,
		Trial = 1,
		Demo = 2
	}

	[SerializeField]
	[Tooltip("本番のみ表示する場合はNoneを選択")]
	private eDefineType enabledType;

	private void Awake()
	{
	}
}
