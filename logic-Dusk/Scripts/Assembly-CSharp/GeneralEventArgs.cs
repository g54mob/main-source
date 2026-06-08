using System;
using UnityEngine;

public class GeneralEventArgs : EventArgs
{
	public float TimeStamp { get; private set; }

	public object Data { get; private set; }

	public GeneralEventArgs(object data)
	{
		Data = data;
		TimeStamp = Time.time;
	}

	public GeneralEventArgs()
	{
		TimeStamp = Time.time;
	}
}
