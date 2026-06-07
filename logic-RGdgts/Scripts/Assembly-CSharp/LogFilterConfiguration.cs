using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

[CreateAssetMenu]
public class LogFilterConfiguration : SerializedScriptableObject
{
	[NonSerialized]
	[OdinSerialize]
	public LogFilter filter;
}
