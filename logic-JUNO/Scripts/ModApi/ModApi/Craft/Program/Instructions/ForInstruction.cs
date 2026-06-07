using System;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class ForInstruction : LoopInstruction
	{
		[ProgramNodeProperty]
		private string _var = "i";

		public override bool SupportsChildren => true;

		public string VariableName
		{
			get
			{
				return _var;
			}
			set
			{
				_var = value;
			}
		}

		public override ProgramInstruction Execute(IThreadContext context)
		{
			double num = 0.0;
			double numberValue = GetExpression(2).Evaluate(context).NumberValue;
			if (!context.HasInstructionState(this))
			{
				num = GetExpression(0).Evaluate(context).NumberValue;
			}
			else
			{
				num = context.GetInstructionState(this);
				num += numberValue;
			}
			context.SetInstructionState(this, num);
			int num2 = (int)GetExpression(1).Evaluate(context).NumberValue;
			if ((numberValue > 0.0 && num <= (double)num2) || (numberValue < 0.0 && num >= (double)num2))
			{
				context.PushStackFrame(this);
				context.CreateLocalVariable(_var).Value.NumberValue = num;
				return base.FirstChild;
			}
			return base.Next;
		}
	}
}
