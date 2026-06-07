using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Craft.Program.Instructions;
using UnityEngine;

namespace ModApi.Craft.Program
{
	public class ProgramNode
	{
		private ProgramExpression[] _expressions;

		[SerializeField]
		[ProgramNodeProperty]
		private string _style;

		public Vector2? EditorPosition { get; set; }

		public IReadOnlyList<ProgramExpression> Expressions => _expressions;

		public string Style
		{
			get
			{
				return _style;
			}
			set
			{
				_style = value;
			}
		}

		public static void ExecuteActionOnTree<T>(ProgramNode root, Action<T> action) where T : ProgramNode
		{
			if (root == null)
			{
				return;
			}
			if (root is T obj)
			{
				action(obj);
			}
			foreach (ProgramExpression expression in root.Expressions)
			{
				ExecuteActionOnTree(expression, action);
			}
			if (root is ProgramInstruction programInstruction)
			{
				ExecuteActionOnTree(programInstruction.FirstChild, action);
				ExecuteActionOnTree(programInstruction.Next, action);
			}
		}

		public ProgramExpression GetExpression(int index)
		{
			if (index < _expressions.Length)
			{
				return _expressions[index];
			}
			Debug.LogErrorFormat("Expression index of {0} is out of range 0-{1} for node {2} with style: {3}", index, _expressions.Length, GetType().Name, Style);
			return null;
		}

		public virtual List<ListItemInfo> GetListItems(string listId)
		{
			return null;
		}

		public virtual string GetListValue(string listId)
		{
			return null;
		}

		public void InitializeExpressions(params ProgramExpression[] expressions)
		{
			_expressions = expressions;
		}

		public virtual void OnDeserialized(XElement xml)
		{
			EditorPosition = xml.GetVector2AttributeOrNull("pos");
		}

		public virtual void OnSerialized(XElement xml)
		{
			if (EditorPosition.HasValue)
			{
				xml.SetAttribute("pos", EditorPosition.Value);
			}
		}

		public void SetExpression(int index, ProgramExpression programExpression)
		{
			if (index >= 0 && index < _expressions.Length)
			{
				_expressions[index] = programExpression;
				return;
			}
			throw new ArgumentException($"Expression index of {index} is out of range [0-{_expressions.Length})");
		}

		public virtual void SetListValue(string listId, string value)
		{
		}
	}
}
