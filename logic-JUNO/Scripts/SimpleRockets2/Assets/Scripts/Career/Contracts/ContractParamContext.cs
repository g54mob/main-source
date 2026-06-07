namespace Assets.Scripts.Career.Contracts
{
	public class ContractParamContext
	{
		private IContractContext _contractContext;

		public ContractTemplate ContractTemplate { get; }

		public int NumCompletions { get; }

		public double PlayerMoney { get; }

		public int RepeatIndex { get; set; }

		public ContractParamContext(ContractTemplate contractTemplate, IContractContext contractContext)
		{
			ContractTemplate = contractTemplate;
			_contractContext = contractContext;
			NumCompletions = GetNumberOfCompletions(contractTemplate.Id);
			PlayerMoney = contractContext.Career.Money;
		}

		public int GetNumberOfCompletions(string id)
		{
			return _contractContext.GetNumberOfCompletions(id);
		}
	}
}
