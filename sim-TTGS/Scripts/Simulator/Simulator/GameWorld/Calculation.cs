using System;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Serializable]
	public struct Calculation
	{
		[SerializeField]
		private EOperator m_operator;

		[SerializeField]
		private float m_value;

		[SerializeField]
		private EValueType m_valueType;

		public EOperator Operator => m_operator;

		public float Value => m_value;

		public EValueType ValueType => m_valueType;

		public Calculation(EOperator operatorType, float value, EValueType valueType)
		{
			m_operator = operatorType;
			m_value = value;
			m_valueType = valueType;
		}

		public Calculation(Calculation calculation)
		{
			m_operator = calculation.m_operator;
			m_value = calculation.m_value;
			m_valueType = calculation.ValueType;
		}

		public float ComputeValue(float initialValue)
		{
			return OperatorResult.ComputeValue(initialValue, m_value, m_valueType, m_operator);
		}

		public float ComputeValue(float initialValue, float addedValue)
		{
			return OperatorResult.ComputeValue(initialValue, addedValue, m_valueType, m_operator);
		}

		public Calculation ReverseOperator()
		{
			return m_operator switch
			{
				EOperator.ADD => new Calculation(EOperator.SUBTRACT, m_value, m_valueType), 
				EOperator.SUBTRACT => new Calculation(EOperator.ADD, m_value, m_valueType), 
				EOperator.MULTIPLY => new Calculation(EOperator.DIVIDE, m_value, m_valueType), 
				EOperator.DIVIDE => new Calculation(EOperator.MULTIPLY, m_value, m_valueType), 
				_ => new Calculation(this), 
			};
		}
	}
}
