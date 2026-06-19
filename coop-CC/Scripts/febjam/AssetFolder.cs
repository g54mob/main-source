using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class AssetFolder<T> : ISerializationCallbackReceiver where T : UnityEngine.Object
{
	[NonSerialized]
	private UnityEngine.Object _folder;

	public List<T> assets = new List<T>();

	public void OnBeforeSerialize()
	{
	}

	public void OnAfterDeserialize()
	{
	}
}
