using System;
using UnityEngine;
using UnityEngine.Events;

public class CModUnitControl : MonoBehaviour
{
	public class OnChangeEvent : UnityEvent<int, int>
	{
	}

	public OnChangeEvent onChange;

	[NonSerialized]
	public int slot;

	public virtual string text { get; set; }

	public virtual int state { get; set; }

	public virtual string[] options { get; set; }
}
