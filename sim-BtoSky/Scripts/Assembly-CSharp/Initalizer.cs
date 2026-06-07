using System.Collections.Generic;
using System.Linq;
using Suburb;
using UnityEngine;

public class Initalizer : MonoBehaviour
{
	[SerializeField]
	private Transform[] trashPos;

	[SerializeField]
	private GameObject grassPos;

	[SerializeField]
	private SimpleOpenClose garageDoor;

	[SerializeField]
	private Shelf garageShelf;

	[SerializeField]
	private Transform garageStuffPos;

	[SerializeField]
	private Transform garageTpPos;

	public List<GameObject> currentGarageStuff = new List<GameObject>();

	private void Start()
	{
		ES3AutoSaveMgr.OnBeforeSave += ES3AutoSaveMgr_OnBeforeSave;
		QuestManager.S.trashPos = trashPos;
		QuestManager.S.grassPos = grassPos;
		QuestManager.S.garageDoor = garageDoor;
		QuestManager.S.garageShelf = garageShelf;
		QuestManager.S.garageStuffPos = garageStuffPos;
		QuestManager.S.garageTpPos = garageTpPos;
		currentGarageStuff = ES3.Load("Init_CurrentGarageStuff", currentGarageStuff);
		currentGarageStuff = currentGarageStuff.Where((GameObject item) => item != null).ToList();
		QuestManager.S.currentGarageStuff.Clear();
		QuestManager.S.currentGarageStuff = currentGarageStuff;
	}

	private void OnDestroy()
	{
		ES3AutoSaveMgr.OnBeforeSave -= ES3AutoSaveMgr_OnBeforeSave;
	}

	private void ES3AutoSaveMgr_OnBeforeSave()
	{
		SaveData();
	}

	private void SaveData()
	{
		ES3.Save("Init_CurrentGarageStuff", currentGarageStuff);
	}

	private void Update()
	{
	}
}
