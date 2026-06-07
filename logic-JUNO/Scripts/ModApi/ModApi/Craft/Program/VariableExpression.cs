using System;

namespace ModApi.Craft.Program
{
	[Serializable]
	public class VariableExpression : ProgramExpression
	{
		[ProgramNodeProperty]
		private bool _list;

		[ProgramNodeProperty]
		private bool _local;

		[ProgramNodeProperty]
		private string _variableName;

		public override bool IsBoolean => false;

		public bool IsDefinition { get; set; }

		public bool IsList => _list;

		public bool IsLocal
		{
			get
			{
				return _local;
			}
			set
			{
				_local = value;
			}
		}

		public string VariableName
		{
			get
			{
				return _variableName;
			}
			set
			{
				_variableName = value;
			}
		}

		public VariableExpression(bool list = false)
		{
			_list = list;
		}

		public override ExpressionResult Evaluate(IThreadContext context)
		{
			if (_local)
			{
				Variable localVariable = context.GetLocalVariable(VariableName);
				if (localVariable != null)
				{
					return localVariable.Value;
				}
				context.Log.LogError($"Could not find local variable with name '{VariableName}'", context);
				return new ExpressionResult();
			}
			return context.GetOrCreateGlobalVariable(VariableName).Value;
		}
	}
}
