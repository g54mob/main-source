using System;
using System.Collections.Generic;
using UnityEngine;

namespace Simulator
{
	[CreateAssetMenu(fileName = "Loca Variables Database", menuName = "Tabletop/Excel Databases/Loca Variables")]
	public class LocaVariableDatabase : ExcelDatabase
	{
		[Header("Miniature Database")]
		[SerializeField]
		private List<LocaVariable> m_datas;

		private Dictionary<string, IRuntimeLocaVariable> m_runtimeVariables;

		private static LocaVariableDatabase _instance;

		public override EExcelDatabase Type => EExcelDatabase.LOCA_VAR;

		public override Type ContentType => typeof(LocaVariable);

		private static LocaVariableDatabase Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = ExcelDatabaseSettings.GetDatabase(EExcelDatabase.LOCA_VAR) as LocaVariableDatabase;
					_instance.Init();
				}
				return _instance;
			}
		}

		private void Init()
		{
			m_runtimeVariables = new Dictionary<string, IRuntimeLocaVariable>();
			foreach (LocaVariable data in m_datas)
			{
				m_runtimeVariables.Add(data.name, IRuntimeLocaVariable.Create(data));
			}
		}

		public static bool TryGetVariableLiteralValue(string key, out string value)
		{
			if (Instance.m_runtimeVariables.TryGetValue(key, out var value2))
			{
				value = value2.GetLiteralValue();
				return true;
			}
			value = null;
			return false;
		}

		public static bool TryGetVariableIntValue(string key, out int value)
		{
			if (Instance.m_runtimeVariables.TryGetValue(key, out var value2))
			{
				return value2.TryGetIntValue(out value);
			}
			value = 0;
			return false;
		}

		public static bool TryGetVariableFloatValue(string key, out float value)
		{
			if (Instance.m_runtimeVariables.TryGetValue(key, out var value2))
			{
				return value2.TryGetFloatValue(out value);
			}
			value = 0f;
			return false;
		}

		public static void SetVariableValue(LocaVariable var, object value)
		{
			SetVariableValue(var.name, value);
		}

		public static void SetVariableValue(string key, object value)
		{
			Instance.m_runtimeVariables[key] = IRuntimeLocaVariable.Create(value);
		}
	}
}
