using System.Collections;
using I2.Loc;
using TH20;
using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlotScreen : MonoBehaviour
{
	public delegate void ChooseSaveSlotFunction(int index);

	[SerializeField]
	private Button _backing;

	[SerializeField]
	private Button _backing2;

	[SerializeField]
	private DynamicButton _cancelButton;

	[SerializeField]
	private Transform _saveSlotContainer;

	[SerializeField]
	private GameObject _saveSlotPrefab;

	[SerializeField]
	private float _delayBetweenSlots = 0.3f;

	[SerializeField]
	private float _slotSlideInTime = 0.5f;

	[SerializeField]
	private float _slotStartingX = -1000f;

	[SerializeField]
	private float _endXOffsetFromCentre = 392f;

	[SerializeField]
	private float _slotStartingRotation = -45f;

	private readonly SaveSlotElement[] _saveSlots = new SaveSlotElement[3];

	private SaveSystem _saveSystem;

	private MessageBox _messageBox;

	private ChooseSaveSlotFunction _loadSaveSlotFunction;

	private ChooseSaveSlotFunction _startNewSlotFunction;

	public void Show(SaveSystem saveSystem, MessageBox messageBox, ChooseSaveSlotFunction loadSaveSlotFunction, ChooseSaveSlotFunction startNewSlotFunction)
	{
		_saveSystem = saveSystem;
		_messageBox = messageBox;
		_loadSaveSlotFunction = loadSaveSlotFunction;
		_startNewSlotFunction = startNewSlotFunction;
		base.gameObject.SetActive(value: true);
	}

	private void Awake()
	{
		_backing.onClick.AddListener(Hide);
		_cancelButton.onPrimaryDown.AddListener(Hide);
		ShowBacking2(bShow: false);
		GameObjectUtils.DestroyChildren(_saveSlotContainer.gameObject);
		float y = _saveSlotPrefab.transform.localPosition.y;
		for (int i = 0; i < 3; i++)
		{
			SaveSlotElement component = Object.Instantiate(_saveSlotPrefab, new Vector3(_slotStartingX, y, _saveSlotPrefab.transform.localPosition.z), _saveSlotPrefab.transform.rotation, _saveSlotContainer).GetComponent<SaveSlotElement>();
			_saveSlots[i] = component;
		}
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
		for (int i = 0; i < 3; i++)
		{
			if (_saveSlots[i] != null)
			{
				_saveSlots[i].Clear();
			}
		}
	}

	private void OnEnable()
	{
		float y = _saveSlotPrefab.transform.localPosition.y;
		for (int i = 0; i < 3; i++)
		{
			Transform transform = _saveSlots[i].transform;
			transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
			_saveSlots[i].gameObject.SetActive(value: false);
			MetagameSaveHeader metagameSaveHeaderForSlot = _saveSystem.GetMetagameSaveHeaderForSlot(i);
			if (metagameSaveHeaderForSlot != null)
			{
				int indexCopy = i;
				_saveSlots[i].SetupWithSave(metagameSaveHeaderForSlot, delegate
				{
					SlotClickedForLoad(indexCopy);
				}, delegate
				{
					SlotClickedForDelete(indexCopy);
				});
			}
			else
			{
				int indexCopy2 = i;
				_saveSlots[i].SetupEmpty(delegate
				{
					SlotClickedForNewGame(indexCopy2);
				});
			}
		}
		StartCoroutine(SlideAllSlotsIn());
	}

	private void SlotClickedForLoad(int slotIndex)
	{
		_loadSaveSlotFunction(slotIndex);
		Hide();
	}

	private void ShowBacking2(bool bShow)
	{
		if (_backing2 != null)
		{
			_backing2.gameObject.SetActive(bShow);
		}
	}

	private void SlotClickedForDelete(int slotIndex)
	{
		ShowBacking2(bShow: true);
		_messageBox.SetUseNonFrostedPanelData(bUseNonFrostedPanelData: true);
		_messageBox.ShowAsYesNo(ScriptLocalization.Menu_Messages.Delete_Save_File_Title_CS, ScriptLocalization.Menu_Messages.Delete_Save_File_Body_CS, ScriptLocalization.Menu_Messages.Yes_Button_CS, ScriptLocalization.Menu_Messages.No_Button_CS, delegate
		{
			SlotConfirmedForDelete(slotIndex);
		}, delegate
		{
			SlotCancelledForDelete(slotIndex);
		});
	}

	private void SlotConfirmedForDelete(int slotIndex)
	{
		_saveSystem.DeleteMetagameAndLevelSavesInSlot(slotIndex);
		_saveSlots[slotIndex].Clear();
		_saveSlots[slotIndex].SetupEmpty(delegate
		{
			SlotClickedForNewGame(slotIndex);
		});
		ShowBacking2(bShow: false);
	}

	private void SlotCancelledForDelete(int slotIndex)
	{
		ShowBacking2(bShow: false);
	}

	private void SlotClickedForNewGame(int slotIndex)
	{
		_startNewSlotFunction(slotIndex);
		Hide();
	}

	private IEnumerator SlideAllSlotsIn()
	{
		int i = 0;
		while (i < _saveSlots.Length)
		{
			StartCoroutine(SlideSlotIn(_saveSlots[i].transform, i));
			yield return new WaitForSecondsRealtime(_delayBetweenSlots);
			int num = i + 1;
			i = num;
		}
	}

	private IEnumerator SlideSlotIn(Transform slot, int index)
	{
		float t = 0f;
		float endX = Mathf.Lerp(0f - _endXOffsetFromCentre, _endXOffsetFromCentre, (float)index / ((float)_saveSlots.Length - 1f));
		slot.localPosition = new Vector3(_slotStartingX, slot.localPosition.y, slot.localPosition.z);
		slot.gameObject.SetActive(value: true);
		for (; t < _slotSlideInTime; t += Time.unscaledDeltaTime)
		{
			float p = Mathf.Clamp01(t / _slotSlideInTime);
			slot.localPosition = new Vector3(Mathf.LerpUnclamped(_slotStartingX, endX, EasingsUtils.ExponentialEaseOut(p)), slot.localPosition.y, slot.localPosition.z);
			slot.localEulerAngles = new Vector3(0f, 0f, Mathf.LerpUnclamped(_slotStartingRotation, 0f, EasingsUtils.BackEaseOut(p)));
			yield return null;
		}
		slot.localEulerAngles = new Vector3(0f, 0f, 0f);
		slot.localPosition = new Vector3(endX, slot.localPosition.y, slot.localPosition.z);
	}
}
