namespace Alekrus.UnivarsalPlatform
{
	public class ResultArgs
	{
		public IResult Result { get; }

		public ResultArgs(IResult parResult)
		{
			Result = parResult;
		}
	}
}
