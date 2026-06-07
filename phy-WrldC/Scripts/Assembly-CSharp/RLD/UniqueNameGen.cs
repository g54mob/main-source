using System.Collections.Generic;

namespace RLD
{
	public static class UniqueNameGen
	{
		public static string Generate(string desiredName, IEnumerable<string> existingNames)
		{
			string text = desiredName;
			int num = 0;
			bool flag;
			do
			{
				flag = false;
				foreach (string existingName in existingNames)
				{
					if (existingName == text)
					{
						text = desiredName + num;
						num++;
						flag = true;
						break;
					}
				}
			}
			while (flag && num != int.MaxValue);
			return text;
		}
	}
}
