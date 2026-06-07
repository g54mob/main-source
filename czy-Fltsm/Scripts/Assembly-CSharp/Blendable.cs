using System;
using PajamaLlama.Generic;
using UnityEngine;

[Serializable]
public class Blendable<T> where T : UnityEngine.Object
{
	public RangedFloat Range;

	public T Target;
}
