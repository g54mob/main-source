using System;
using System.Text;

namespace GameCreator.Runtime.Common
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
	public class CategoryAttribute : Attribute, ISearchable
	{
		private static readonly char[] SEPARATOR = new char[1] { '/' };

		public string Name { get; }

		public string[] Path { get; }

		public string SearchText => ToString(" ");

		public int SearchPriority => 8;

		public CategoryAttribute(string category)
		{
			string[] array = category.Split(SEPARATOR);
			Name = array[^1];
			Path = new string[array.Length - 1];
			for (int i = 0; i < array.Length - 1; i++)
			{
				Path[i] = array[i];
			}
		}

		public override string ToString()
		{
			return ToString("/");
		}

		public string ToString(string separator)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string[] path = Path;
			foreach (string value in path)
			{
				stringBuilder.Append(value).Append(separator);
			}
			stringBuilder.Append(Name);
			return stringBuilder.ToString();
		}
	}
}
