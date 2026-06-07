using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
	public List<GameObject> Parts;

	private int _currentPart = -1;

	private int _maxPart;

	public TMP_Text PartText;

	private static bool _disableTutorial;

	public static TutorialController Instance;

	private void Start()
	{
		Instance = this;
		base.gameObject.SetActive(value: false);
	}

	private void DisplayPart(bool forceLoad = false)
	{
		bool flag = false;
		if (!_disableTutorial && (!base.gameObject.activeSelf || forceLoad) && _currentPart < _maxPart - 1)
		{
			_currentPart++;
			if (!base.gameObject.activeSelf)
			{
				base.transform.localScale = Vector3.zero;
				flag = true;
			}
			base.gameObject.SetActive(value: true);
			if (flag)
			{
				base.transform.DOScale(1f, 0.25f);
			}
			GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ui_tutorial_pop);
			for (int i = 0; i < Parts.Count; i++)
			{
				Parts[i].SetActive(i == _currentPart);
			}
			PartText.text = _currentPart + 1 + "/" + Parts.Count;
		}
	}

	public void ClosePart()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_button1_click);
		base.gameObject.SetActive(value: false);
		DisplayPart();
	}

	public void EnablePart(int newPart)
	{
		if (_maxPart < newPart)
		{
			_maxPart = newPart;
			DisplayPart();
		}
	}

	public void SkipTutorial()
	{
		_disableTutorial = true;
		base.gameObject.SetActive(value: false);
	}

	public static void DisableTutorial()
	{
		if (Instance != null)
		{
			Instance.SkipTutorial();
		}
		else
		{
			_disableTutorial = true;
		}
	}
}
