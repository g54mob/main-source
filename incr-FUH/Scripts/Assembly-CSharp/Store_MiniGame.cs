using System.Collections.Generic;
using UnityEngine;

public class Store_MiniGame : MonoBehaviour
{
	public enum StageEnum
	{
		None = 0,
		Part1 = 1,
		Ending = 2
	}

	public AnimationSprite Belt;

	public List<GameObject> BoxTemplate;

	public GameObject BoxStart;

	public GameObject BoxEnd;

	private int _boxIndex;

	private GameObject _currentBox;

	private StageEnum _stage;

	private Color _mainColor = Color.white;

	private bool _isSuccess;

	public bool IsSuccess => _isSuccess;

	private void Start()
	{
		foreach (GameObject item in BoxTemplate)
		{
			item.SetActive(value: false);
		}
		DisplayNewBox(BoxTemplate[_boxIndex]);
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
		if (_currentBox != null)
		{
			_currentBox.transform.position += new Vector3(0.01f, 0f, 0f);
			if (_currentBox.transform.position.x > BoxEnd.transform.position.x)
			{
				RemoveBoxAddNew();
			}
		}
	}

	public void SetParent(Store parent)
	{
	}

	public void ChangeStage(StageEnum newStage)
	{
		if (_stage != newStage)
		{
			_stage = newStage;
			_isSuccess = false;
			switch (_stage)
			{
			case StageEnum.None:
				_isSuccess = false;
				break;
			case StageEnum.Part1:
			case StageEnum.Ending:
				break;
			}
		}
	}

	public void BoxClick()
	{
		RemoveBoxAddNew();
	}

	private void RemoveBoxAddNew()
	{
		_currentBox.SetActive(value: false);
		Object.Destroy(_currentBox);
		_currentBox = null;
		_boxIndex++;
		if (_boxIndex >= BoxTemplate.Count)
		{
			_boxIndex = 0;
		}
		DisplayNewBox(BoxTemplate[_boxIndex]);
	}

	private void DisplayNewBox(GameObject boxTemplate)
	{
		_currentBox = Object.Instantiate(boxTemplate, boxTemplate.transform.parent);
		_currentBox.GetComponent<Store_Box>().ParentStore = this;
		_currentBox.transform.position = new Vector3(BoxStart.transform.position.x, boxTemplate.transform.position.y, boxTemplate.transform.position.z);
		_currentBox.SetActive(value: true);
	}
}
