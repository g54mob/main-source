using System.Collections.Generic;

namespace UniJSON
{
	public class JsonSchemaValidationContext
	{
		private Stack<string> m_stack = new Stack<string>();

		public bool EnableDiagnosisForNotRequiredFields;

		public JsonSchemaValidationContext(object o)
		{
			Push(o.GetType().Name);
		}

		public ActionDisposer Push(object o)
		{
			m_stack.Push(o.ToString());
			return new ActionDisposer(Pop);
		}

		public void Pop()
		{
			m_stack.Pop();
		}

		public bool IsEmpty()
		{
			return m_stack.Count == 1;
		}

		public override string ToString()
		{
			return string.Join(".", m_stack.ToArray(), 0, m_stack.Count);
		}
	}
}
