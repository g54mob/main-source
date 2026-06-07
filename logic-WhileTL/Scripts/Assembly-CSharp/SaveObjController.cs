using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class SaveObjController : ActiveComponent
{
	public class SaveObjComparer : IComparer<SaveObjController>
	{
		public enum KeyEnum
		{
			Nickname = 0,
			Info = 1,
			Time = 2,
			Score = 3,
			Money = 4
		}

		public bool reverse;

		public KeyEnum Key { get; set; }

		public SaveObjComparer(KeyEnum key = KeyEnum.Time, bool reverse = false)
		{
			Key = key;
			this.reverse = reverse;
		}

		private IComparable GetKey(SaveObjController obj)
		{
			return Key switch
			{
				KeyEnum.Nickname => obj.previewData.showName, 
				KeyEnum.Time => obj.previewData.date, 
				KeyEnum.Score => obj.previewData.buggleScore, 
				KeyEnum.Money => obj.previewData.money, 
				_ => obj.previewData.info, 
			};
		}

		public int Compare(SaveObjController x, SaveObjController y)
		{
			if (!x.notHide && y.notHide)
			{
				return -1;
			}
			if (x.notHide && !y.notHide)
			{
				return 1;
			}
			if (!x.notHide && !y.notHide)
			{
				return 0;
			}
			IComparable key = GetKey(x);
			IComparable key2 = GetKey(y);
			int num = key.CompareTo(key2);
			if (reverse)
			{
				return -num;
			}
			return num;
		}
	}

	[SceneBind("Name")]
	public Text Name;

	[SceneBind("Task")]
	public Text Task;

	[SceneBind("Money")]
	public Text Money;

	[SceneBind("Startups")]
	public Text Startups;

	[SceneBind("Version")]
	public Text Version;

	[SceneBind("Buggle")]
	public Text Buggle;

	[SceneBind("DateTime")]
	public Text DateTime;

	[SceneBind("NewGame")]
	public Image NewGame;

	[SceneBind("Info")]
	public Text Info;

	[SceneBind("LayerInfo")]
	public Image LayerInfo;

	[SceneBind("LayerGame")]
	public Image LayerGame;

	[SceneBind("Delete")]
	public Toggle Delete;

	public bool selected;

	public bool notHide;

	private PreviewData previewData;

	public int idPreview;

	public Text GetTextFieldByKey(SaveObjComparer.KeyEnum key)
	{
		return key switch
		{
			SaveObjComparer.KeyEnum.Nickname => Name, 
			SaveObjComparer.KeyEnum.Time => DateTime, 
			SaveObjComparer.KeyEnum.Score => Buggle, 
			SaveObjComparer.KeyEnum.Money => Money, 
			_ => Info, 
		};
	}

	private void OnChangeDelete(bool click)
	{
		selected = click;
	}

	public void SetDeleteMode(bool flag)
	{
		if (!flag)
		{
			selected = false;
		}
		Delete.gameObject.SetActive(flag && notHide);
	}

	public void Init(int id)
	{
		PreviewData pr = ActiveComponent.Model.globalSaves.Preview[id];
		idPreview = id;
		Init(pr);
	}

	public void Init(PreviewData pr)
	{
		base.OnInit();
		previewData = pr;
		notHide = true;
		selected = false;
		SceneBindContainer.BindObjects(this, base.transform);
		Delete.gameObject.SetActive(value: false);
		if (pr == null)
		{
			notHide = false;
			Name.gameObject.SetActive(value: false);
			Task.gameObject.SetActive(value: false);
			Version.gameObject.SetActive(value: false);
			Startups.gameObject.SetActive(value: false);
			Money.gameObject.SetActive(value: false);
			Buggle.gameObject.SetActive(value: false);
			DateTime.gameObject.SetActive(value: false);
			NewGame.gameObject.SetActive(value: true);
			Info.gameObject.SetActive(value: false);
			return;
		}
		base.gameObject.name = pr.saveName;
		Delete.onValueChanged.AddListener(OnChangeDelete);
		Delete.isOn = false;
		Name.text = pr.showName;
		Info.text = pr.info;
		Task.gameObject.SetActive(value: false);
		Version.text = pr.version;
		Startups.text = pr.startupsNumber + " / " + ActiveComponent._staticData.Settings.MaxStartups;
		Money.text = pr.money + "$";
		Buggle.text = pr.buggleScore.ToString();
		try
		{
			DateTime.text = pr.date.AsString();
		}
		catch
		{
			DateTime.text = "";
		}
		NewGame.gameObject.SetActive(value: false);
	}

	public void Hide()
	{
		Delete.gameObject.SetActive(value: false);
		Name.gameObject.SetActive(value: false);
		Task.gameObject.SetActive(value: false);
		Version.gameObject.SetActive(value: false);
		Startups.gameObject.SetActive(value: false);
		Money.gameObject.SetActive(value: false);
		Buggle.gameObject.SetActive(value: false);
		DateTime.gameObject.SetActive(value: false);
		NewGame.gameObject.SetActive(value: false);
		LayerInfo.gameObject.SetActive(value: false);
		LayerGame.gameObject.SetActive(value: false);
		GetComponent<Button>().enabled = false;
	}
}
