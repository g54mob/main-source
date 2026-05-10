using CTS.Core;

namespace CTS
{
	public class SaveFinanceGraph : SaveMonoSingleton<FinancialGraph>
	{
		public override void Save(ES3Settings settings)
		{
			if (MonoSingleton<FinancialGraph>.InstanceExists())
			{
				ES3.Save("FinancialGraph", MonoSingleton<FinancialGraph>.Instance.SaveGraph(), settings);
			}
		}

		public override void LoadPost(ES3Settings settings)
		{
			if (MonoSingleton<FinancialGraph>.InstanceExists())
			{
				MonoSingleton<FinancialGraph>.Instance.LoadGraph(ES3.Load("FinancialGraph", default(GraphSaveStruct), settings));
			}
		}
	}
}
