using System;
using UnityEngine;

namespace PugWorldGen
{
	[Serializable]
	public class ParameterDefinition
	{
		[Serializable]
		public enum Type
		{
			Float = 0,
			Int = 1,
			Bool = 2,
			Range = 3,
			Distribution = 4
		}

		[Serializable]
		public enum DistributionCount
		{
			_2 = 2,
			_3 = 3,
			_4 = 4,
			_5 = 5,
			Variable = -1
		}

		[Serializable]
		public enum Exposure
		{
			None = 0,
			Limited = 1,
			Full = 2
		}

		[SerializeField]
		public string m_name;

		[SerializeField]
		private Type m_type;

		[SerializeField]
		private float m_defaultFloatValue;

		[SerializeField]
		private int m_defaultIntValue;

		[SerializeField]
		private bool m_defaultBoolValue;

		[SerializeField]
		private Vector2 m_defaultRangeValue = new Vector2(0f, 1f);

		[SerializeField]
		private Vector4 m_defaultDistributionValue = new Vector4(0.2f, 0.2f, 0.2f, 0.2f);

		[SerializeField]
		private bool m_limitRange;

		[SerializeField]
		private float m_rangeMinFloat;

		[SerializeField]
		private float m_rangeMaxFloat = 1f;

		[SerializeField]
		private int m_rangeMinInt;

		[SerializeField]
		private int m_rangeMaxInt = 10;

		[SerializeField]
		private DistributionCount m_distributionCount = DistributionCount._2;

		[SerializeField]
		private Exposure m_userExposed;

		[SerializeField]
		private int m_modificationLock;

		public string name => m_name;

		public Type type => m_type;

		public float defaultFloatValue => m_defaultFloatValue;

		public float defaultIntValue => m_defaultIntValue;

		public bool defaultBoolValue => m_defaultBoolValue;

		public Vector2 defaultRangeValue => m_defaultRangeValue;

		public Vector4 defaultDistributionValue => m_defaultDistributionValue;

		public DistributionCount distributionCount => m_distributionCount;

		public Exposure userExposed => m_userExposed;

		public int modificationLock => m_modificationLock;

		public bool limitRange => m_limitRange;

		public float rangeMinFloat => m_rangeMinFloat;

		public float rangeMaxFloat => m_rangeMaxFloat;

		public float rangeMinInt => m_rangeMinInt;

		public float rangeMaxInt => m_rangeMaxInt;

		public string GetTypeName()
		{
			return m_type switch
			{
				Type.Int => "int", 
				Type.Bool => "bool", 
				Type.Range => "Vector2", 
				Type.Distribution => "Vector4", 
				_ => "float", 
			};
		}

		public string GetShaderTypeName()
		{
			return m_type switch
			{
				Type.Int => "int", 
				Type.Bool => "bool", 
				Type.Range => "float2", 
				Type.Distribution => "float4", 
				_ => "float", 
			};
		}

		public void Lock()
		{
			m_modificationLock = 0;
		}
	}
}
