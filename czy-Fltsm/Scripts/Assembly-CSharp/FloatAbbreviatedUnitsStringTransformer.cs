using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/String Transformer/Float Abbreviated Units")]
public class FloatAbbreviatedUnitsStringTransformer : FloatStringTransformer
{
	[Serializable]
	public struct Unit
	{
		public string UnitMark;

		public float Size;

		public float Divider;

		public string Format;

		public string ToString(float input)
		{
			return (input / Divider).ToString(Format) + UnitMark;
		}
	}

	[Header("Settings")]
	[Tooltip("The Units of this string **in descending order**.")]
	[SerializeField]
	private Unit[] _units = new Unit[0];

	public override string ReturnString(float input)
	{
		return ReturnUnit(input).ToString(input);
	}

	private Unit ReturnUnit(float amount)
	{
		float num = Mathf.Abs(amount);
		Unit[] units = _units;
		for (int i = 0; i < units.Length; i++)
		{
			Unit result = units[i];
			if (result.Size <= num)
			{
				return result;
			}
		}
		return default(Unit);
	}
}
