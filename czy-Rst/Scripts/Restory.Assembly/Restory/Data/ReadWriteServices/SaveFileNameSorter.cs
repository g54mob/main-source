using System.Collections.Generic;
using System.IO;
using System.Linq;
using Restory.Data.SaveLoad;

namespace Restory.Data.ReadWriteServices
{
	internal class SaveFileNameSorter : IComparer<string>
	{
		private readonly SaveSystemSettings settings;

		public SaveFileNameSorter(SaveSystemSettings settings)
		{
			this.settings = settings;
		}

		public int Compare(string leftValue, string rightValue)
		{
			if (string.Equals(leftValue, rightValue))
			{
				return 0;
			}
			if (string.IsNullOrEmpty(leftValue) || string.IsNullOrEmpty(rightValue))
			{
				return -2;
			}
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(leftValue);
			string fileNameWithoutExtension2 = Path.GetFileNameWithoutExtension(rightValue);
			long result = -1L;
			if (!fileNameWithoutExtension.Contains(settings.IterationSeparator))
			{
				long.TryParse(fileNameWithoutExtension.Split(settings.DateTimeSeparator).Last(), out result);
			}
			int result2 = -1;
			int.TryParse(fileNameWithoutExtension.Split(settings.IterationSeparator).Last(), out result2);
			long result3 = -1L;
			if (!fileNameWithoutExtension2.Contains(settings.IterationSeparator))
			{
				long.TryParse(fileNameWithoutExtension2.Split(settings.DateTimeSeparator).Last(), out result3);
			}
			int result4 = -1;
			int.TryParse(fileNameWithoutExtension2.Split(settings.IterationSeparator).Last(), out result4);
			if (result > 0 && result3 > 0)
			{
				if (result > result3)
				{
					return 1;
				}
				if (result == result3)
				{
					return 0;
				}
				if (result < result3)
				{
					return -1;
				}
			}
			if (result2 > 0 && result4 > 0)
			{
				if (result2 > result4)
				{
					return 1;
				}
				if (result2 == result4)
				{
					return 0;
				}
				if (result2 < result4)
				{
					return -1;
				}
			}
			if (result2 > 0 && result3 > 0)
			{
				return 1;
			}
			if (result > 0 && result3 > 0)
			{
				return -1;
			}
			return 0;
		}
	}
}
