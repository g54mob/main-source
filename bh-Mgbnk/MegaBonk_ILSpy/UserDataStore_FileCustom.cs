using System.IO;
using System.Text;
using Rewired.Data;
using UnityEngine;

public class UserDataStore_FileCustom : UserDataStore_File
{
	protected override void SetInitialValues()
	{
		string controllersDir = SaveManager.GetControllersDir();
		base.__directory = controllersDir;
		if (base._initialized)
		{
			OnDataSourceChanged();
		}
		base._fileName = "controller_config.json";
		if (base._initialized)
		{
			OnDataSourceChanged();
		}
		bool flag = !base._initialized;
		base._dataFormat = DataFormat.Text;
		if (!flag)
		{
			OnDataSourceChanged();
		}
		string path = base.directory;
		string text = Path.Combine(path, base._fileName);
		string message = "Rewired save path set to: " + text;
		Debug.Log(message);
	}

	public void UpdatePath()
	{
		SetInitialValues();
	}

	public UserDataStore_FileCustom()
	{
		base._fileName = "RewiredSaveData.json";
		((UserDataStore_KeyValue)this)._isEnabled = true;
		((UserDataStore_KeyValue)this)._loadMouseAssignments = true;
		((UserDataStore_KeyValue)this)._allowImpreciseJoystickAssignmentMatching = true;
		StringBuilder sb = new StringBuilder();
		((UserDataStore_KeyValue)this)._sb = sb;
		((UserDataStore)this)._002Ector();
	}
}
