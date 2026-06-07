using App.Data;

public class SandboxData
{
	public int active;

	public App.Data.Data data;

	public SandboxData()
	{
	}

	public void InitEmpty()
	{
		active = 0;
		data = new App.Data.Data();
		data.InitEmpty();
	}

	public bool IsActive()
	{
		return active == 1;
	}

	public App.Data.Data GetData()
	{
		return data;
	}

	public App.Data.Data GetDataClone()
	{
		return Logic.Clone<App.Data.Data>(data);
	}

	public SandboxData(int active, App.Data.Data data)
	{
		this.active = active;
		string json = Logic.SerializeObject(data);
		this.data = Logic.DeserializeObject<App.Data.Data>(json);
	}
}
