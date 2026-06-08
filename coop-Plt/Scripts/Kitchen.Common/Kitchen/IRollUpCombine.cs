namespace Kitchen
{
	public interface IRollUpCombine : IRollUp
	{
		bool CombineWith(IRollUp previous_update);
	}
}
