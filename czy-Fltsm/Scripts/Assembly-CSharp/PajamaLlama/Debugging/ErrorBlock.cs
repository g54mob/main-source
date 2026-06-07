using System;
using System.Text;

namespace PajamaLlama.Debugging
{
	public static class ErrorBlock
	{
		private static StringBuilder _errors;

		private static bool _hasErrors;

		public static void Begin()
		{
			if (_errors == null)
			{
				_errors = new StringBuilder();
			}
			else
			{
				_errors.Clear();
			}
			_hasErrors = false;
		}

		public static void AppendError(string error)
		{
			_errors.AppendLine(error);
			_hasErrors = true;
		}

		public static void AppendErrorFormat(string formattedError, params object[] args)
		{
			AppendError(string.Format(formattedError, args));
		}

		public static void End()
		{
			if (_hasErrors)
			{
				throw new Exception(_errors.ToString());
			}
		}
	}
}
