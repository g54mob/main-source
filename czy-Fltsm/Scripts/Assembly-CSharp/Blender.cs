using System;
using UnityEngine;
using UnityEngine.PajamaLlama;

[Serializable]
public class Blender<T, BT> where T : UnityEngine.Object where BT : Blendable<T>
{
	[SerializeField]
	[NamedArrayElement(new string[] { "Target" })]
	private BT[] _blendables;

	protected BT[] Blendables => _blendables;

	public void Blend(float value)
	{
		ListPool<BT>.List list = ListPool<BT>.Get();
		using (list)
		{
			BT[] blendables = _blendables;
			foreach (BT val in blendables)
			{
				if (val.Range.ReturnContainsValue(value))
				{
					list.Add(val);
				}
			}
			BT val2;
			BT val3;
			if (list.Count == 0)
			{
				val2 = (val3 = _blendables[0]);
			}
			else if (list.Count == 1)
			{
				val2 = (val3 = list[0]);
			}
			else
			{
				if (list.Count != 2)
				{
					throw new NotSupportedException("Blending between more then 2 blendables is not supported! Make sure no more then 2 Blendable ranges overlap.");
				}
				val2 = list[0];
				val3 = list[1];
			}
			Blend(val2.Target, val3.Target, ReturnBlendProgress(val2, val3, value));
		}
	}

	protected virtual void Blend(T from, T to, float value)
	{
		throw new NotImplementedException();
	}

	private float ReturnBlendProgress(BT from, BT to, float value)
	{
		if (from.Target == to.Target)
		{
			return 0f;
		}
		if (to.Range.Minimum == from.Range.Maximum)
		{
			return 1f;
		}
		if (to.Range.Minimum < from.Range.Maximum)
		{
			float num = from.Range.Maximum - to.Range.Minimum;
			value -= to.Range.Minimum;
			return value / num;
		}
		return -1f;
	}
}
