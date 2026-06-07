using System;
using System.Linq;
using System.Text;

namespace GameCreator.Runtime.Common
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
	public class ExampleAttribute : Attribute
	{
		public string Content { get; }

		public ExampleAttribute(string content)
		{
			int num = content.Trim(Environment.NewLine[0]).TakeWhile(char.IsWhiteSpace).Count();
			StringBuilder stringBuilder = new StringBuilder(Environment.NewLine);
			for (int i = 0; i < num; i++)
			{
				stringBuilder.Append(' ');
			}
			content = content.Replace(stringBuilder.ToString(), Environment.NewLine);
			Content = content.Trim(Environment.NewLine[0], ' ');
		}
	}
}
