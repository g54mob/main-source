using System;
using System.Collections;
using System.Collections.Generic;
using Suburb;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
	public static QuestManager S;

	public bool toTheNextQuest;

	[Header("Quest List")]
	public List<QuestData> quests = new List<QuestData>();

	public List<QuestData> parttime = new List<QuestData>();

	public GameObject[] questsItems;

	private QuestData currentParttime;

	public int currentQuestIndex;

	public int currentPartTimeIndex = -1;

	public Transform[] trashPos;

	public GameObject trashBag;

	public GameObject grassPos;

	public SimpleOpenClose garageDoor;

	public SimpleOpenClose junkshopDoor;

	public GameObject junkshopTarp;

	public Shelf garageShelf;

	public GameObject[] garageStuff;

	public List<GameObject> currentGarageStuff = new List<GameObject>();

	public Transform garageStuffPos;

	public Transform garageTpPos;

	public Transform kickOutTpPos;

	[SerializeField]
	private HashSet<float> triggeredMilestones = new HashSet<float>();

	private readonly float[] milestones = new float[6] { 50f, 250f, 1000f, 1500f, 2500f, 5000f };

	public float highRecord;

	private bool mileStoneReached;

	public event Action<QuestData> OnQuestStarted;

	public event Action<QuestData> OnQuestCompleted;

	public event Action OnNewsPaperDeliveryStarted;

	public event Action OnNewsPaperDelivered;

	public event Action OnNewsPaperDeliveryCompleted;

	public event Action OnCleanUpStarted;

	public event Action OnTrashBagCleaned;

	public event Action OnCleanUpCompleted;

	public event Action OnMowingStarted;

	public event Action OnGrassCutted;

	public event Action OnMowingCompleted;

	public event Action OnGarageCleaningStart;

	public event Action OnCookingDeliveryStart;

	public event Action OnGarageCleaned;

	public event Action OnGarageCleaningCompleted;

	public event Action OnParttimeOccupied;

	public event Action OnQuestRewarded;

	public event Action OnPowerRocketUnlocked;

	public event Action OnRocketChipUnlocked;

	public event Action OnCompleteDemo;

	public event Action<float> OnRocketRecord;

	private void SaveQmData()
	{
		ES3.Save("Qm_QuestList", quests);
		ES3.Save("Qm_PartTimeList", parttime);
		ES3.Save("Qm_CurrentParttime", currentParttime);
		ES3.Save("Qm_QuestIndex", currentQuestIndex);
		ES3.Save("Qm_ParttimeIndex", currentPartTimeIndex);
		ES3.Save("Qm_TriggeredMileStones", triggeredMilestones);
	}

	private void LoadQmData()
	{
		quests = ES3.Load("Qm_QuestList", quests);
		parttime = ES3.Load("Qm_PartTimeList", parttime);
		currentParttime = ES3.Load("Qm_CurrentParttime", currentParttime);
		if (currentParttime != null && currentParttime.questName == "")
		{
			currentParttime = null;
		}
		currentQuestIndex = ES3.Load("Qm_QuestIndex", 0);
		currentPartTimeIndex = ES3.Load("Qm_ParttimeIndex", -1);
		triggeredMilestones = ES3.Load("Qm_TriggeredMileStones", triggeredMilestones);
	}

	private void OnValidate()
	{
		if (toTheNextQuest)
		{
			toTheNextQuest = false;
			CompleteQuest(QuestType.MainQuest);
		}
	}

	private void Awake()
	{
		if (S == null)
		{
			S = this;
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		LoadQmData();
	}

	private void Start()
	{
		GameManager.S.OnCameraInstalled += S_OnCameraInstalled;
		RocketBox.OnRocketBoxInteracted += RocketBox_OnRocketBoxInteracted;
		RocketAndRcBox.OnRcBoxInteracted += RocketAndRcBox_OnRcBoxInteracted;
		WingGizmo.OnWingRotated += WingGizmo_OnWingRotated;
		Block_DeployParachute.OnParachuteDeploy += Block_DeployParachute_OnParachuteDeploy;
		ModuleSlotGizmo.OnModuleSlotGizmoClicked += ModuleSlotGizmo_OnModuleSlotGizmoClicked;
		TearDownController.OnTeardownComplete += TearDownController_OnTeardownComplete;
		GameManager.S.OnPaintingDone += S_OnPaintingDone;
		GameManager.S.OnJunkScaleSell += S_OnJunkScaleSell;
		GameManager.S.OnFurnitureObtained += S_OnFurnitureObtained;
		ES3AutoSaveMgr.OnBeforeSave += ES3AutoSaveMgr_OnBeforeSave;
		GameManager.S.OnPlayerEat += Gm_OnPlayerEat;
		GameManager.S.OnStartParttime += Gm_OnStartParttime;
		GameManager.S.OnRocketLaunch += S_OnRocketLaunch;
		GameManager.S.OnPlayerLevelUp += Gm_OnPlayerLevelUp;
		StickyNoteUI.OnReadStickyNoteDone += StickyNoteUI_OnReadStickyNoteDone;
		PauseUI.OnSaveAndQuit += PauseUI_OnSaveAndQuit;
		QuestUI.OnMotorQuestCompleted += QuestUI_OnMotorQuestCompleted;
		QuestUI.OnWingQuestCompleted += QuestUI_OnWingQuestCompleted;
		OnQuestRewarded += QuestManager_OnQuestRewarded;
		MyTubeUI.OnVideoUploaded += MyTubeUI_OnVideoUploaded;
	}

	private IEnumerator DelayedOpenJunkshopDoor()
	{
		yield return null;
		junkshopDoor.Interact();
	}

	private void ES3AutoSaveMgr_OnBeforeSave()
	{
		SaveQmData();
	}

	private void OnDestroy()
	{
		GameManager.S.OnCameraInstalled -= S_OnCameraInstalled;
		RocketBox.OnRocketBoxInteracted -= RocketBox_OnRocketBoxInteracted;
		RocketAndRcBox.OnRcBoxInteracted -= RocketAndRcBox_OnRcBoxInteracted;
		WingGizmo.OnWingRotated -= WingGizmo_OnWingRotated;
		Block_DeployParachute.OnParachuteDeploy -= Block_DeployParachute_OnParachuteDeploy;
		ModuleSlotGizmo.OnModuleSlotGizmoClicked -= ModuleSlotGizmo_OnModuleSlotGizmoClicked;
		TearDownController.OnTeardownComplete -= TearDownController_OnTeardownComplete;
		GameManager.S.OnPaintingDone -= S_OnPaintingDone;
		GameManager.S.OnJunkScaleSell -= S_OnJunkScaleSell;
		GameManager.S.OnFurnitureObtained -= S_OnFurnitureObtained;
		GameManager.S.OnPlayerEat -= Gm_OnPlayerEat;
		GameManager.S.OnStartParttime -= Gm_OnStartParttime;
		GameManager.S.OnRocketLaunch -= S_OnRocketLaunch;
		GameManager.S.OnPlayerLevelUp -= Gm_OnPlayerLevelUp;
		StickyNoteUI.OnReadStickyNoteDone -= StickyNoteUI_OnReadStickyNoteDone;
		PauseUI.OnSaveAndQuit -= PauseUI_OnSaveAndQuit;
		MyTubeUI.OnVideoUploaded -= MyTubeUI_OnVideoUploaded;
		QuestUI.OnMotorQuestCompleted -= QuestUI_OnMotorQuestCompleted;
		QuestUI.OnWingQuestCompleted -= QuestUI_OnWingQuestCompleted;
		OnQuestRewarded -= QuestManager_OnQuestRewarded;
	}

	private void S_OnRocketLaunch(int obj)
	{
		if (currentQuestIndex == 3)
		{
			CompleteQuest(QuestType.MainQuest);
			GameManager.S.BasementUnlocked();
		}
		else if (currentQuestIndex == 5)
		{
			CompleteQuest(QuestType.MainQuest);
			GameManager.S.ParentsRoomUnlocked();
		}
		else if (currentQuestIndex == 14 && obj == 1)
		{
			CompleteQuest(QuestType.MainQuest);
		}
	}

	private void PauseUI_OnSaveAndQuit()
	{
		SaveQmData();
		UnityEngine.Object.Destroy(base.gameObject);
	}

	private void Gm_OnStartParttime(QuestData obj, Transform questboard)
	{
		if (currentParttime == null)
		{
			AudioManager.S.PlaySFX(AudioManager.S.questStart);
			currentParttime = obj;
			if (obj.questType == QuestType.Newspaper)
			{
				currentPartTimeIndex = 0;
				List<GameObject> list = new List<GameObject>();
				list.Add(questsItems[1]);
				GameManager.S.DeliveryArrived(list);
				this.OnNewsPaperDeliveryStarted?.Invoke();
			}
			else if (obj.questType == QuestType.Trash)
			{
				currentPartTimeIndex = 1;
				Transform[] array = trashPos;
				foreach (Transform transform in array)
				{
					UnityEngine.Object.Instantiate(trashBag, transform.position, UnityEngine.Random.rotation);
				}
				this.OnCleanUpStarted?.Invoke();
			}
			else if (obj.questType == QuestType.Mowing)
			{
				currentPartTimeIndex = 2;
				foreach (Transform item2 in grassPos.transform)
				{
					item2.gameObject.SetActive(value: true);
				}
				this.OnMowingStarted?.Invoke();
			}
			else if (obj.questType == QuestType.GarageCleaning)
			{
				currentPartTimeIndex = 3;
				garageDoor.Interact();
				garageShelf.ClearShelf();
				foreach (Transform item3 in garageShelf.transform)
				{
					item3.gameObject.layer = LayerMask.NameToLayer("Interactable");
				}
				GameObject[] array2 = garageStuff;
				for (int i = 0; i < array2.Length; i++)
				{
					GameObject item = UnityEngine.Object.Instantiate(array2[i], garageStuffPos.position + UnityEngine.Random.insideUnitSphere, UnityEngine.Random.rotation);
					currentGarageStuff.Add(item);
				}
				this.OnGarageCleaningStart?.Invoke();
			}
			else if (obj.questType == QuestType.Cooking)
			{
				currentPartTimeIndex = 4;
				QuestData questData = parttime[currentPartTimeIndex];
				int[] array3 = new int[4] { 13, 14, 16, 17 };
				int num = UnityEngine.Random.Range(0, array3.Length);
				questData.pay = array3[num];
				Debug.Log("퀘스트 시작: " + questData.questName);
				this.OnQuestStarted?.Invoke(questData);
			}
			questboard.SetAsLastSibling();
		}
		else
		{
			this.OnParttimeOccupied?.Invoke();
			AudioManager.S.PlaySFX(AudioManager.S.notEnoughMoney);
		}
	}

	private void StickyNoteUI_OnReadStickyNoteDone()
	{
		if (currentQuestIndex == 0)
		{
			StickyNote.OnReadStickyNote -= StickyNoteUI_OnReadStickyNoteDone;
			CompleteQuest(QuestType.MainQuest);
			GameManager.S.MyRoomUnlocked();
		}
	}

	private void Gm_OnPlayerEat()
	{
		if (currentQuestIndex == 1)
		{
			CompleteQuest(QuestType.MainQuest);
			GameManager.S.OnPlayerEat -= Gm_OnPlayerEat;
			List<GameObject> list = new List<GameObject>();
			list.Add(questsItems[0]);
			GameManager.S.DeliveryArrived(list);
			GameManager.S.EntracneUnlocked();
		}
	}

	private void RocketBox_OnRocketBoxInteracted()
	{
		if (currentQuestIndex == 2)
		{
			CompleteQuest(QuestType.MainQuest);
		}
	}

	private void QuestUI_OnWingQuestCompleted()
	{
		if (currentQuestIndex == 4)
		{
			CompleteQuest(QuestType.MainQuest);
		}
	}

	private void MilestoneReached(float milestone)
	{
		if (milestone == 50f)
		{
			if (currentQuestIndex == 8)
			{
				CompleteQuest(QuestType.MainQuest);
				GameManager.S.CookingTableUnlocked();
				FirstPersonController.S.MoneyUpdated(2f);
				triggeredMilestones.Add(milestone);
			}
		}
		else if (milestone == 250f)
		{
			if (currentQuestIndex == 10)
			{
				CompleteQuest(QuestType.MainQuest);
				List<GameObject> list = new List<GameObject>();
				list.Add(questsItems[2]);
				GameManager.S.DeliveryArrived(list);
				triggeredMilestones.Add(milestone);
			}
		}
		else if (milestone == 1000f)
		{
			if (currentQuestIndex == 13)
			{
				FirstPersonController.S.MoneyUpdated(5f);
				CompleteQuest(QuestType.MainQuest);
				triggeredMilestones.Add(milestone);
				this.OnPowerRocketUnlocked?.Invoke();
			}
		}
		else if (milestone == 1500f)
		{
			if (currentQuestIndex == 16)
			{
				CompleteQuest(QuestType.MainQuest);
				triggeredMilestones.Add(milestone);
				GameManager.S.PartTimeUnlocked();
				GameManager.S.isJunkShopDoorUnlocked = true;
				junkshopDoor.Interact();
			}
		}
		else if (milestone == 2500f)
		{
			if (currentQuestIndex == 18)
			{
				CompleteQuest(QuestType.MainQuest);
				triggeredMilestones.Add(milestone);
				junkshopTarp.SetActive(value: false);
				GameManager.S.TearDownUnlocked();
			}
		}
		else if (milestone == 5000f && currentQuestIndex == 24)
		{
			CompleteQuest(QuestType.MainQuest);
			triggeredMilestones.Add(milestone);
			this.OnCompleteDemo?.Invoke();
		}
	}

	private void S_OnFurnitureObtained(Furniture obj)
	{
		if (currentQuestIndex == 6 && obj.itemName == "Camera")
		{
			CompleteQuest(QuestType.MainQuest);
			GameManager.S.VideoUnlocked();
			GameManager.S.OnFurnitureObtained -= S_OnFurnitureObtained;
		}
	}

	private void MyTubeUI_OnVideoUploaded()
	{
		if (currentQuestIndex == 7)
		{
			CompleteQuest(QuestType.MainQuest);
		}
	}

	private void Gm_OnPlayerLevelUp(object sender, EventArgs e)
	{
		if (currentQuestIndex == 9)
		{
			GameManager.S.OnPlayerLevelUp -= Gm_OnPlayerLevelUp;
			CompleteQuest(QuestType.MainQuest);
		}
	}

	private void RocketAndRcBox_OnRcBoxInteracted()
	{
		if (currentQuestIndex == 11)
		{
			CompleteQuest(QuestType.MainQuest);
		}
	}

	private void S_OnJunkScaleSell()
	{
		if (currentQuestIndex == 12)
		{
			CompleteQuest(QuestType.MainQuest);
		}
	}

	private void QuestUI_OnMotorQuestCompleted()
	{
		if (currentQuestIndex == 15)
		{
			CompleteQuest(QuestType.MainQuest);
		}
	}

	private void S_OnPaintingDone()
	{
	}

	private void QuestManager_OnQuestRewarded()
	{
		if (currentQuestIndex == 17)
		{
			CompleteQuest(QuestType.MainQuest);
		}
	}

	private void TearDownController_OnTeardownComplete(Chips obj)
	{
		if (currentQuestIndex == 19)
		{
			CompleteQuest(QuestType.MainQuest);
		}
	}

	private void ModuleSlotGizmo_OnModuleSlotGizmoClicked(ModuleSlotGizmo arg1, GameObject arg2)
	{
		if (currentQuestIndex == 20)
		{
			CompleteQuest(QuestType.MainQuest);
		}
	}

	private void S_OnCameraInstalled()
	{
		if (currentQuestIndex == 21)
		{
			CompleteQuest(QuestType.MainQuest);
		}
	}

	private void Block_DeployParachute_OnParachuteDeploy()
	{
		if (currentQuestIndex == 22)
		{
			Block_DeployParachute.OnParachuteDeploy -= Block_DeployParachute_OnParachuteDeploy;
			CompleteQuest(QuestType.MainQuest);
		}
	}

	private void WingGizmo_OnWingRotated()
	{
		if (currentQuestIndex == 23)
		{
			WingGizmo.OnWingRotated -= WingGizmo_OnWingRotated;
			CompleteQuest(QuestType.MainQuest);
		}
	}

	public QuestData GetCurrentQuest()
	{
		if (currentQuestIndex >= quests.Count)
		{
			return null;
		}
		return quests[currentQuestIndex];
	}

	public void StartQuest(int index)
	{
		if (index < quests.Count)
		{
			currentQuestIndex = index;
			QuestData questData = quests[currentQuestIndex];
			AudioManager.S.PlaySFX(AudioManager.S.questStart);
			Debug.Log("퀘스트 시작: " + questData.questName);
			this.OnQuestStarted?.Invoke(questData);
		}
	}

	public void CompleteQuest(QuestType type)
	{
		QuestData currentQuest = GetCurrentQuest();
		if (currentQuest != null && currentQuest.questType == type)
		{
			currentQuest.isCompleted = true;
			Debug.Log("퀘스트 완료: " + currentQuest.questName);
			this.OnQuestCompleted?.Invoke(currentQuest);
			AudioManager.S.PlaySFX(AudioManager.S.questDone);
			StartCoroutine(NextQuest());
		}
	}

	private IEnumerator NextQuest()
	{
		yield return new WaitForSeconds(2f);
		currentQuestIndex++;
		StartQuest(currentQuestIndex);
	}

	public void NewspaperDelivered()
	{
		this.OnNewsPaperDelivered?.Invoke();
	}

	public void TrashbagCleaned()
	{
		this.OnTrashBagCleaned?.Invoke();
	}

	public void NewspaperDeliveryCompleted()
	{
		this.OnNewsPaperDeliveryCompleted?.Invoke();
		currentParttime.isCompleted = true;
		StartCoroutine(DelayedRewardQuestStart());
	}

	public void CleanUpCompleted()
	{
		currentParttime.isCompleted = true;
		StartCoroutine(DelayedRewardQuestStart());
		this.OnCleanUpCompleted?.Invoke();
	}

	public void GrassCutted()
	{
		this.OnGrassCutted?.Invoke();
	}

	public void MowingCompleted()
	{
		currentParttime.isCompleted = true;
		StartCoroutine(DelayedRewardQuestStart());
		this.OnMowingCompleted?.Invoke();
	}

	public void GarageCleaned(GameObject stuff)
	{
		currentGarageStuff.Remove(stuff);
		this.OnGarageCleaned?.Invoke();
	}

	public void GarageCleaningCompleted()
	{
		garageDoor.Interact();
		this.OnGarageCleaningCompleted?.Invoke();
		currentParttime.isCompleted = true;
		FirstPersonController.S.canControl = false;
	}

	public void GarageFadeOutDone()
	{
		FirstPersonController.S.transform.position = garageTpPos.position;
		FirstPersonController.S.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
		StartCoroutine(ClearGarage());
		StartCoroutine(DelayedRewardQuestStart());
	}

	public void KickedOutFadeOutDone()
	{
		FirstPersonController.S.transform.position = kickOutTpPos.position;
		FirstPersonController.S.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
	}

	private IEnumerator DelayedRewardQuestStart()
	{
		AudioManager.S.PlaySFX(AudioManager.S.questDone);
		yield return new WaitForSeconds(1.5f);
		PartTimeRewardQuestStart();
	}

	public void PartTimeRewardQuestStart()
	{
		if (currentPartTimeIndex < parttime.Count)
		{
			QuestData questData = parttime[currentPartTimeIndex];
			Debug.Log("퀘스트 시작: " + questData.questName);
			this.OnQuestStarted?.Invoke(questData);
		}
	}

	private IEnumerator ClearGarage()
	{
		yield return new WaitForSeconds(3f);
		foreach (GameObject item in currentGarageStuff)
		{
			UnityEngine.Object.Destroy(item);
		}
		currentGarageStuff.Clear();
		garageShelf.ClearShelf();
	}

	public void GivePartTimeReward()
	{
		AudioManager.S.PlaySFX(AudioManager.S.money);
		this.OnQuestRewarded?.Invoke();
		if (GameManager.S.intelPerkList[2])
		{
			StartCoroutine(DelayedReward());
			int num = Mathf.FloorToInt((float)currentParttime.pay * 1.5f);
			FirstPersonController.S.ticket += num;
			GameManager.S.TicketUpdated();
		}
		else
		{
			FirstPersonController.S.ticket += currentParttime.pay;
			GameManager.S.TicketUpdated();
		}
		currentParttime.isCompleted = false;
		currentParttime = null;
		currentPartTimeIndex = -1;
	}

	private IEnumerator DelayedReward()
	{
		yield return null;
		FirstPersonController.S.AddExp(5);
	}

	public QuestData GetCurrnetPartTime()
	{
		return currentParttime;
	}

	public int GetCurrentPartTimeReward()
	{
		return currentParttime.pay;
	}

	public void UpdateRecord(float newRecord)
	{
		this.OnRocketRecord?.Invoke(newRecord);
		if (!mileStoneReached)
		{
			float[] array = milestones;
			foreach (float num in array)
			{
				if (newRecord >= num && !triggeredMilestones.Contains(num))
				{
					MilestoneReached(num);
					mileStoneReached = true;
				}
			}
		}
		if (!(newRecord <= highRecord))
		{
			highRecord = newRecord;
		}
	}

	public void ResetMileStoneReached()
	{
		mileStoneReached = false;
	}
}
