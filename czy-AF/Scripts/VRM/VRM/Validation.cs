namespace VRM
{
	public struct Validation
	{
		public readonly bool CanExport;

		public readonly string Message;

		private Validation(bool canExport, string message)
		{
			CanExport = canExport;
			Message = message;
		}

		public static Validation Error(string msg)
		{
			return new Validation(canExport: false, msg);
		}

		public static Validation Warning(string msg)
		{
			return new Validation(canExport: true, msg);
		}
	}
}
