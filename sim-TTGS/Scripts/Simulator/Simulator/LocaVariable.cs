using Dhs5.Utility.Databases;
using UnityEngine;

namespace Simulator
{
	public class LocaVariable : BaseDataContainerScriptableElement
	{
		public enum EType
		{
			INT = 0,
			FLOAT = 1,
			STRING = 2
		}

		[SerializeField]
		[ExcelDatabase(2, readOnly = true, width = 80f)]
		private EType m_type;

		[SerializeField]
		[ExcelDatabase(5, debugOnly = true)]
		private int m_intField;

		[SerializeField]
		[ExcelDatabase(6, debugOnly = true)]
		private float m_floatField;

		[SerializeField]
		[ExcelDatabase(7, debugOnly = true)]
		private string m_stringField;

		public EType Type => m_type;

		public int Int => m_intField;

		public float Float => m_floatField;

		public string String => m_stringField;
	}
}
