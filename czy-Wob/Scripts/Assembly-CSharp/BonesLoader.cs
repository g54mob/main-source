using System.Collections.Generic;
using ClockStone;
using UnityEngine;

public class BonesLoader : MonoBehaviour
{
	public GameObject bonePrefab;

	public float elementDelay = 0.1f;

	public BoneArrow arrowTopRef;

	public BoneArrow arrowBotRef;

	public FileInfoLoader fileInfoRef;

	public Transform boneHolderTransform;

	public CoreButtonUnityGUI backButtonRef;

	public float scaleInTime = 0.25f;

	public float scaleOutTime = 0.15f;

	public List<Sprite> boneSprites;

	private int bonesLoaded;

	private int arrowsToLoad;

	private bool selfLoaded;

	protected List<Segment> currentEases = new List<Segment>();

	private ScalableUIContainer.LoadCallback pageLoadCallback;

	private int totalPages = 1;

	private int currentPage = 1;

	private float rowsPerPage = 2f;

	private float elementsPerRow = 3f;

	private int endIndexForPage;

	private int startIndexForPage;

	private int numElementsOnPage;

	private bool showingFileInfo;

	private List<GameObject> bones = new List<GameObject>();

	private ScalableUIContainer.LoadCallback callback;

	private Inchworm inchwormRef;

	private void Awake()
	{
		showingFileInfo = false;
		fileInfoRef.SetBonesRef(this);
		inchwormRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		arrowTopRef.LockArrow();
		arrowBotRef.LockArrow();
		CreateBones();
		currentPage = 1;
		Load();
	}

	private void Update()
	{
		if (GameControls.actions.CloseMenu.WasPressed && !showingFileInfo)
		{
			OnBackButtonPressed();
		}
	}

	public void OnBackButtonPressed()
	{
		SingletonMonoBehaviour<AudioController>.Instance.GetComponent<MusicPlaylistController>().OnReEnterMainMenu();
		Object.Destroy(base.gameObject);
	}

	private void CreateBones()
	{
		for (int num = bones.Count - 1; num >= 0; num--)
		{
			Object.Destroy(bones[num]);
		}
		bones.Clear();
		float num2 = 575f;
		float num3 = 375f;
		float num4 = 10f;
		List<string> allSaveFilePaths = SaveLoadManager.GetAllSaveFilePaths();
		for (int i = 0; i < allSaveFilePaths.Count + 1; i++)
		{
			int num5 = i / (int)elementsPerRow % (int)rowsPerPage;
			float num6 = (float)i % elementsPerRow;
			GameObject gameObject = Object.Instantiate(bonePrefab, boneHolderTransform);
			int index = i % boneSprites.Count;
			gameObject.transform.localPosition = new Vector3(num2 * num6, (0f - num3) * (float)num5, 0f);
			float z = ((i % 2 == 0) ? num4 : (0f - num4));
			gameObject.transform.GetChild(0).localRotation = Quaternion.Euler(0f, 0f, z);
			gameObject.transform.localScale = Vector3.zero;
			bones.Add(gameObject);
			BoneFile component = gameObject.GetComponent<BoneFile>();
			component.SetBonesRef(this);
			component.SetGraphic(boneSprites[index]);
			if (i == 0)
			{
				component.MarkNewFile();
			}
			else
			{
				component.SetAssociatedFile(allSaveFilePaths[i - 1]);
			}
		}
		totalPages = Mathf.FloorToInt((float)Mathf.Max(bones.Count - 1, 0) / (elementsPerRow * rowsPerPage)) + 1;
	}

	private int GetNumElementsOnCurrentPage()
	{
		int num = (int)(elementsPerRow * rowsPerPage);
		int num2 = startIndexForPage + num;
		if (num2 < bones.Count)
		{
			return num;
		}
		return num - (num2 - bones.Count);
	}

	public void Load()
	{
		CancelCurrentEases();
		LoadBonePage(currentPage, OnSelfLoadComplete);
	}

	public void Refresh()
	{
		LockAllInteractables();
		CreateBones();
		currentPage = 1;
		LoadBonePage(1, UnlockAllInteractables);
	}

	public void RemoveAllBonesButtons()
	{
		for (int i = 0; i < bones.Count; i++)
		{
			if (bones[i] != null)
			{
				BoneFile component = bones[i].GetComponent<BoneFile>();
				if (component != null)
				{
					Object.Destroy(component);
				}
			}
		}
	}

	private void OnSelfLoadComplete()
	{
		CallCallback();
		if (NeedUpArrow())
		{
			arrowTopRef.UnlockArrow();
		}
		if (NeedDownArrow())
		{
			arrowBotRef.UnlockArrow();
		}
		selfLoaded = true;
		OnPageLoadComplete();
	}

	public void OnFileInfoHidden()
	{
		showingFileInfo = false;
		UnlockAllInteractables();
	}

	private void LockAllInteractables()
	{
		if (NeedUpArrow())
		{
			arrowTopRef.LockArrow();
		}
		if (NeedDownArrow())
		{
			arrowBotRef.LockArrow();
		}
		backButtonRef.interactable = false;
		for (int i = startIndexForPage; i < endIndexForPage; i++)
		{
			if (bones[i] != null)
			{
				bones[i].GetComponent<BoneFile>().Lock();
			}
		}
	}

	private void UnlockAllInteractables()
	{
		if (NeedUpArrow())
		{
			arrowTopRef.UnlockArrow();
		}
		if (NeedDownArrow())
		{
			arrowBotRef.UnlockArrow();
		}
		backButtonRef.interactable = true;
		for (int i = startIndexForPage; i < endIndexForPage; i++)
		{
			if (bones[i] != null)
			{
				bones[i].GetComponent<BoneFile>().Unlock();
			}
		}
	}

	public void ShowFileInfo(string file, Sprite s)
	{
		showingFileInfo = true;
		LockAllInteractables();
		fileInfoRef.SetAssociatedFile(file, s);
		fileInfoRef.Load(OnFileInfoLoaded);
	}

	private void OnFileInfoLoaded()
	{
	}

	public void PageUp()
	{
		LoadBonePage(currentPage - 1);
	}

	public void PageDown()
	{
		LoadBonePage(currentPage + 1);
	}

	private void UnloadBonePage()
	{
		if (NeedUpArrow())
		{
			arrowTopRef.LockArrow();
		}
		if (NeedDownArrow())
		{
			arrowBotRef.LockArrow();
		}
		for (int i = startIndexForPage; i < endIndexForPage; i++)
		{
			bones[i].GetComponent<BoneFile>().Lock();
			bones[i].transform.localScale = Vector3.zero;
		}
	}

	private void LoadBonePage(int newPage, ScalableUIContainer.LoadCallback newCallback = null)
	{
		CancelCurrentEases();
		if (currentPage > 0 && currentPage != newPage)
		{
			UnloadBonePage();
		}
		bonesLoaded = 0;
		arrowsToLoad = 0;
		currentPage = newPage;
		startIndexForPage = (currentPage - 1) * (int)(elementsPerRow * rowsPerPage);
		numElementsOnPage = GetNumElementsOnCurrentPage();
		endIndexForPage = startIndexForPage + numElementsOnPage;
		pageLoadCallback = newCallback;
		float num = 0f;
		for (int i = startIndexForPage; i < endIndexForPage; i++)
		{
			bones[i].transform.localScale = Vector3.zero;
			bones[i].GetComponent<BoneFile>().Unlock();
			currentEases.Add(inchwormRef.RequestEaseToScale(bones[i], Vector3.one, scaleInTime, Inchworm.EaseStyle.ElasticOut, OnBoneLoadComplete, Inchworm.EasePriority.Normal, num));
			num += elementDelay;
		}
		if (NeedUpArrow())
		{
			arrowsToLoad++;
			arrowTopRef.UnlockArrow();
			arrowTopRef.transform.localScale = Vector3.zero;
			currentEases.Add(inchwormRef.RequestEaseToScale(arrowTopRef.gameObject, Vector3.one, scaleInTime, Inchworm.EaseStyle.ElasticOut, OnUpArrowLoadComplete));
		}
		if (NeedDownArrow())
		{
			arrowsToLoad++;
			arrowBotRef.UnlockArrow();
			arrowBotRef.transform.localScale = Vector3.zero;
			currentEases.Add(inchwormRef.RequestEaseToScale(arrowBotRef.gameObject, Vector3.one, scaleInTime, Inchworm.EaseStyle.ElasticOut, OnDownArrowLoadComplete));
		}
	}

	private bool NeedUpArrow()
	{
		return currentPage > 1;
	}

	private bool NeedDownArrow()
	{
		return currentPage < totalPages;
	}

	private bool PageLoadDone()
	{
		if (arrowsToLoad <= 0 && bonesLoaded >= numElementsOnPage)
		{
			return true;
		}
		return false;
	}

	private void OnUpArrowLoadComplete()
	{
		arrowsToLoad--;
		if (PageLoadDone())
		{
			OnPageLoadComplete();
		}
	}

	private void OnDownArrowLoadComplete()
	{
		arrowsToLoad--;
		if (PageLoadDone())
		{
			OnPageLoadComplete();
		}
	}

	private void OnBoneLoadComplete()
	{
		bonesLoaded++;
		if (PageLoadDone())
		{
			OnPageLoadComplete();
		}
	}

	private void OnPageLoadComplete()
	{
		CancelCurrentEases();
		if (pageLoadCallback != null)
		{
			ScalableUIContainer.LoadCallback loadCallback = pageLoadCallback;
			pageLoadCallback = null;
			loadCallback();
		}
		if (selfLoaded)
		{
			for (int i = startIndexForPage; i < endIndexForPage; i++)
			{
				bones[i].GetComponent<BoneFile>().Unlock();
			}
		}
	}

	private void CancelCurrentEases()
	{
		for (int num = currentEases.Count - 1; num >= 0; num--)
		{
			Segment segment = currentEases[num];
			inchwormRef.CancelAndFinishEase(ref segment);
			segment = null;
			currentEases.RemoveAt(num);
		}
	}

	protected virtual void CallCallback()
	{
		if (callback != null)
		{
			callback();
			callback = null;
		}
	}
}
