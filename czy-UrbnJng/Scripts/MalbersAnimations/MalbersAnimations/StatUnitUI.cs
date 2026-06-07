using System;
using System.Collections.Generic;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/UI/Stat Unit UI")]
	public class StatUnitUI : MonoBehaviour
	{
		[Header("Data")]
		[Tooltip("Current Value of the Stat")]
		public FloatReference value = new FloatReference(10f);

		[Tooltip("Max Value of the Stat")]
		public IntReference maxValue = new IntReference(10);

		[Tooltip("Section the Max Value. E.g if Max Value is 100 and Divider is 10 it will show 10 Units ")]
		[Min(1f)]
		public int Divider = 1;

		public StatUnit Unit;

		[Header("Animation")]
		[Min(0f)]
		public float FillTime = 0.1f;

		public bool FillSequence = true;

		[Min(0f)]
		public float EmptyTime = 0.1f;

		public bool EmptySequence = true;

		public float DefaultScale = 1f;

		private List<StatUnit> Units;

		private int lasUnit;

		private int MaxValue => (int)maxValue / Divider;

		private float Value => (float)value / (float)Divider;

		private void Awake()
		{
			InitializeUnits();
			UpdateUnits();
		}

		private void InitializeUnits()
		{
			Units = new List<StatUnit>();
			for (int i = 0; i < MaxValue; i++)
			{
				StatUnit statUnit = UnityEngine.Object.Instantiate(Unit, base.transform);
				statUnit.name = statUnit.name.Replace("(Clone)", $"({i + 1})");
				Units.Add(statUnit);
				statUnit.transform.localScale = Vector3.one * DefaultScale;
			}
		}

		private void UpdateUnits()
		{
			for (int i = 0; i < (int)Value; i++)
			{
				Units[i].Full.fillAmount = 1f;
			}
			for (int j = (int)Value; j < MaxValue; j++)
			{
				Units[j].Full.fillAmount = 0f;
			}
			int num = Mathf.Clamp((int)Value, 0, MaxValue);
			if (Value - (float)num > 0f)
			{
				Units[Mathf.Clamp(num, 0, MaxValue - 1)].Full.fillAmount = Value - (float)(int)Value;
			}
			LastUnitScaler((int)Value, num);
		}

		private void Scaler(StatUnit unit, bool value)
		{
			unit.SetScaler(value);
			unit.ResetScale();
		}

		public void SetValue(float newValue)
		{
			newValue = Mathf.Clamp(newValue, 0f, (int)maxValue);
			if (newValue == Value)
			{
				return;
			}
			foreach (StatUnit unit3 in Units)
			{
				Scaler(unit3, value: false);
			}
			bool num = (float)value < newValue;
			float num2 = Value;
			value = newValue;
			int UnitID = Mathf.Clamp((int)Value, 0, MaxValue - 1);
			lasUnit = Mathf.Clamp((int)num2, 0, MaxValue - 1);
			float num3 = 0f;
			if (num)
			{
				for (int i = (int)num2; i < (int)Value; i++)
				{
					StatUnit unit = Units[i];
					if (!(FillTime > 0f))
					{
						continue;
					}
					if (FillSequence)
					{
						this.Delay_Action(num3, delegate
						{
							unit.SetFillValue(1f, FillTime);
						});
						num3 += FillTime;
					}
					else
					{
						unit.SetFillValue(1f, FillTime);
					}
				}
			}
			else
			{
				for (int num4 = Mathf.Clamp((int)num2, 0, MaxValue - 1); num4 > (int)Value; num4--)
				{
					StatUnit unit2 = Units[num4];
					if (EmptySequence)
					{
						this.Delay_Action(num3, delegate
						{
							unit2.SetFillValue(0f, EmptyTime);
						});
						num3 += EmptyTime;
					}
					else
					{
						unit2.SetFillValue(0f, EmptyTime);
					}
				}
			}
			this.Delay_Action(num3, delegate
			{
				int num5 = Mathf.Clamp(UnitID, 0, MaxValue);
				Units[num5].SetFillValue(Value - (float)UnitID, EmptyTime);
				if (lasUnit < num5)
				{
					Units[lasUnit].SetFillValue(1f, 0f);
				}
				LastUnitScaler(UnitID, num5);
			});
		}

		private void LastUnitScaler(int UnitID, int ClampUnit)
		{
			if (Value - (float)UnitID > 0f)
			{
				Units[Mathf.Clamp(ClampUnit, 0, MaxValue - 1)].SetScaler(va: true);
			}
			else
			{
				Units[Mathf.Clamp(ClampUnit - 1, 0, MaxValue - 1)].SetScaler(va: true);
			}
		}

		public void SetMaxValue(int maxValue)
		{
			bool flag = MaxValue < maxValue;
			int num = MaxValue;
			this.maxValue = maxValue;
			if (num == MaxValue)
			{
				return;
			}
			if (flag)
			{
				for (int i = num; i < MaxValue; i++)
				{
					StatUnit statUnit = UnityEngine.Object.Instantiate(Unit, base.transform);
					statUnit.name = statUnit.name.Replace("(Clone)", $"({i + 1})");
					Units.Add(statUnit);
					statUnit.transform.localScale = Vector3.one * DefaultScale;
				}
				return;
			}
			if (MaxValue < 0)
			{
				this.maxValue = 0;
			}
			for (int num2 = num - 1; num2 >= MaxValue; num2--)
			{
				StatUnit statUnit2 = Units[num2];
				Units.Remove(statUnit2);
				UnityEngine.Object.Destroy(statUnit2.gameObject);
			}
			SetValue(Value);
		}

		public void ResetToMax()
		{
			SetValue(MaxValue);
		}

		private void OnEnable()
		{
			if (!maxValue.UseConstant && maxValue.Variable != null)
			{
				IntVar variable = maxValue.Variable;
				variable.OnValueChanged = (Action<int>)Delegate.Combine(variable.OnValueChanged, new Action<int>(SetMaxValue));
			}
			if (!value.UseConstant && value.Variable != null)
			{
				FloatVar variable2 = value.Variable;
				variable2.OnValueChanged = (Action<float>)Delegate.Combine(variable2.OnValueChanged, new Action<float>(SetValue));
			}
		}

		private void OnDisable()
		{
			if (!maxValue.UseConstant && maxValue.Variable != null)
			{
				IntVar variable = maxValue.Variable;
				variable.OnValueChanged = (Action<int>)Delegate.Remove(variable.OnValueChanged, new Action<int>(SetMaxValue));
			}
			if (!value.UseConstant && value.Variable != null)
			{
				FloatVar variable2 = value.Variable;
				variable2.OnValueChanged = (Action<float>)Delegate.Remove(variable2.OnValueChanged, new Action<float>(SetValue));
			}
		}
	}
}
