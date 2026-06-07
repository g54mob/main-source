using System;
using UnityEngine;

[RequireComponent(typeof(CouplingScanner))]
public class BufferControllerBase : MonoBehaviour
{
	[NonSerialized]
	public float bufferCompressionRange;

	[NonSerialized]
	public float sidewaysOffset;

	[NonSerialized]
	public float bufferWidth;
}
