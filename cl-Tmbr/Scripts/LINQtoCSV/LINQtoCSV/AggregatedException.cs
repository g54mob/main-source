using System;
using System.Collections.Generic;

namespace LINQtoCSV
{
	public class AggregatedException : LINQtoCSVException
	{
		public List<Exception> m_InnerExceptionsList;

		private int m_MaximumNbrExceptions = 100;

		public AggregatedException(string typeName, string fileName, int maximumNbrExceptions)
			: base(string.Format("There were 1 or more exceptions while reading data using type \"{0}\"." + LINQtoCSVException.FileNameMessage(fileName), typeName))
		{
			m_MaximumNbrExceptions = maximumNbrExceptions;
			m_InnerExceptionsList = new List<Exception>();
			Data["TypeName"] = typeName;
			Data["FileName"] = fileName;
			Data["InnerExceptionsList"] = m_InnerExceptionsList;
		}

		public void AddException(Exception e)
		{
			m_InnerExceptionsList.Add(e);
			if (m_MaximumNbrExceptions != -1 && m_InnerExceptionsList.Count >= m_MaximumNbrExceptions)
			{
				throw this;
			}
		}

		public void ThrowIfExceptionsStored()
		{
			if (m_InnerExceptionsList.Count > 0)
			{
				throw this;
			}
		}
	}
}
