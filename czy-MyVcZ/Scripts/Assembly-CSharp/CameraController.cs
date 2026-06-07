using System;
using System.Collections;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	private CinemachineVirtualCamera _virtualCamera;

	private Player _player;

	private bool _isShowMovingGuide;

	public event Action OnStartFocusOnAnimal;

	public event Action OnEndFocusOnAnimal;

	public event Func<int, AnimalPrefab> OnGetAnimalPrefab;

	public event Action OnStartFocusOnArea;

	public event Action OnEndFocusOnArea;

	public event Action OnStartFocusOnCamp;

	public event Action OnEndFocusOnCamp;

	public void Init(Player player)
	{
		_player = player;
	}

	public void FocusOnPlayer()
	{
		_virtualCamera.Follow = _player.transform;
		_virtualCamera.m_Lens.OrthographicSize = 7f;
	}

	public void FocusOnAnimal(AnimalPrefab animalPrefab)
	{
		_virtualCamera.Follow = animalPrefab.FocusPivot;
		_virtualCamera.m_Lens.OrthographicSize = 3f;
	}

	public void GuideToAnimalPos(Animal animal)
	{
		StartCoroutine(Co_GuideToAnimalPos(animal));
	}

	private IEnumerator Co_GuideToAnimalPos(Animal animal)
	{
		this.OnStartFocusOnAnimal?.Invoke();
		_virtualCamera.Follow = this.OnGetAnimalPrefab?.Invoke(animal.AnimalData.ID).transform;
		yield return new WaitForSeconds(3f);
		_virtualCamera.Follow = _player.transform;
		this.OnEndFocusOnAnimal?.Invoke();
		if (!_isShowMovingGuide)
		{
			yield return new WaitForSeconds(1f);
			MonoSingleton<ToastManager>.Instance.ShowToast(LocaleHelper.Get("TOAST_GUIDEPLACE"));
			_isShowMovingGuide = true;
		}
	}

	public void StartFocusOnArea(Transform area)
	{
		StartCoroutine(Co_FocusOnArea(area));
	}

	public IEnumerator Co_FocusOnArea(Transform area)
	{
		this.OnStartFocusOnArea?.Invoke();
		_virtualCamera.Follow = area;
		yield return new WaitForSeconds(3f);
		_virtualCamera.Follow = _player.transform;
		this.OnEndFocusOnArea?.Invoke();
	}

	public void StartFocusOnCamp(Transform camp)
	{
		StartCoroutine(Co_FocusOnCamp(camp));
	}

	public IEnumerator Co_FocusOnCamp(Transform camp)
	{
		this.OnStartFocusOnCamp?.Invoke();
		_virtualCamera.Follow = camp;
		yield return new WaitForSeconds(3f);
		_virtualCamera.Follow = _player.transform;
		this.OnEndFocusOnCamp?.Invoke();
	}
}
