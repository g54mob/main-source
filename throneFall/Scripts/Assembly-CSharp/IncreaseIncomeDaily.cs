public class IncreaseIncomeDaily : IncomeModifyer, ISaveLoad
{
	private int incomeIncrease;

	private BuildSlot myBuildSlot;

	private bool initialized;

	private void Initialize()
	{
		if (!initialized)
		{
			myBuildSlot = GetComponent<BuildSlot>();
			myBuildSlot.Interactor.IncomeModifiers.Add(this);
			initialized = true;
		}
	}

	private void Start()
	{
		Initialize();
	}

	public override void OnDawn()
	{
		myBuildSlot.GoldIncome++;
		incomeIncrease++;
	}

	public void OnBeforeMainLoadPass(string guid)
	{
	}

	public void OnLoad(string guid)
	{
		Initialize();
		incomeIncrease = 0;
		MatchSaveLoadHandler.TryLoadValue(guid, "incomeIncrease", ref incomeIncrease);
		myBuildSlot.OnAfterDelayedLoadFinished.AddListener(ExecuteDelayedLoad);
	}

	private void ExecuteDelayedLoad()
	{
		Initialize();
		myBuildSlot.GoldIncome += incomeIncrease;
	}

	public void OnSave(string guid)
	{
		MatchSaveLoadHandler.SaveValue(guid, "incomeIncrease", incomeIncrease);
	}

	public void OnAfterMainLoadPass(string guid)
	{
	}
}
