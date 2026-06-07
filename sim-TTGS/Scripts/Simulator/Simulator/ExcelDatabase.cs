using System;
using UnityEngine;

namespace Simulator
{
	public abstract class ExcelDatabase : ScriptableObject
	{
		public abstract EExcelDatabase Type { get; }

		public abstract Type ContentType { get; }
	}
}
