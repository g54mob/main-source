namespace Galaxy.Api
{
	public class IError
	{
		public enum Type
		{
			UNAUTHORIZED_ACCESS = 0,
			INVALID_ARGUMENT = 1,
			INVALID_STATE = 2,
			RUNTIME_ERROR = 3
		}
	}
}
