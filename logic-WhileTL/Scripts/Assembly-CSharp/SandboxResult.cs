using App.Data;

public class SandboxResult
{
	public int active;

	public App.Data.Result result;

	public SandboxResult()
	{
	}

	public bool IsActive()
	{
		return active == 1;
	}

	public void InitEmpty()
	{
		active = 0;
		result = new App.Data.Result();
		result.InitEmpty();
	}

	public App.Data.Result GetResult()
	{
		return result;
	}

	public App.Data.Result GetResultClone()
	{
		return Logic.Clone<App.Data.Result>(result);
	}

	public SandboxResult(int active, App.Data.Result result)
	{
		this.active = active;
		string json = Logic.SerializeObject(result);
		this.result = Logic.DeserializeObject<App.Data.Result>(json);
	}
}
