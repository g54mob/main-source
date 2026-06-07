using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sirenix.OdinInspector
{
	public class SelfValidationResult
	{
		public struct ContextMenuItem
		{
			public string Path;

			public bool On;

			public bool AddSeparatorBefore;

			public Action OnClick;
		}

		public enum ResultType
		{
			Error = 0,
			Warning = 1,
			Valid = 2
		}

		public struct ResultItem
		{
			public string Message;

			public ResultType ResultType;

			public SelfFix? Fix;

			public ResultItemMetaData[] MetaData;

			public Func<IEnumerable<ContextMenuItem>> OnContextClick;

			public Action OnSceneGUI;

			public UnityEngine.Object SelectionObject;

			public bool RichText;
		}

		public struct ResultItemMetaData
		{
			public string Name;

			public object Value;

			public Attribute[] Attributes;

			public ResultItemMetaData(string name, object value, params Attribute[] attributes)
			{
				Name = null;
				Value = null;
				Attributes = null;
			}
		}

		private static ResultItem NoResultItem;

		private ResultItem[] items;

		private int itemsCount;

		public int Count => 0;

		public ref ResultItem this[int index]
		{
			get
			{
				throw null;
			}
		}

		public ref ResultItem AddError(string error)
		{
			throw null;
		}

		public ref ResultItem AddWarning(string warning)
		{
			throw null;
		}

		public ref ResultItem Add(ValidatorSeverity severity, string message)
		{
			throw null;
		}

		public ref ResultItem Add(ResultItem item)
		{
			throw null;
		}
	}
}
