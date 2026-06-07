using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camp : MonoBehaviour
{
	[SerializeField]
	protected CampType _campType;

	[SerializeField]
	protected Spot _spot_01;

	[SerializeField]
	protected Spot _spot_02;

	[SerializeField]
	protected Spot _spot_03;

	[SerializeField]
	protected Spot _spot_04;

	[SerializeField]
	protected Spot _spot_05;

	[SerializeField]
	protected GameObject _activeMusicIcon;

	protected bool _isHarmonyPlaying;

	protected bool _isPlayerInCamp;

	protected bool _isShowToast;

	public CampType CampType => _campType;

	protected void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && _isPlayerInCamp)
		{
			StartHarmony();
		}
	}

	protected void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			_isPlayerInCamp = true;
			_activeMusicIcon.SetActive(value: true);
			if (!_isShowToast)
			{
				MonoSingleton<ToastManager>.Instance.ShowToast(LocaleHelper.Get("CAMPSHOPUI_TOAST_CAMPGUIDE"));
				_isShowToast = true;
			}
		}
	}

	protected void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			_isPlayerInCamp = false;
			_activeMusicIcon.SetActive(value: false);
		}
	}

	public void StartHarmony()
	{
		if (!_isHarmonyPlaying)
		{
			_isHarmonyPlaying = true;
			StartCoroutine(Co_StartHarmony());
		}
	}

	protected virtual IEnumerator Co_StartHarmony()
	{
		yield return null;
	}

	protected IEnumerator Co_VoicePlay(params Spot[] spots)
	{
		List<AnimalPrefab> list = new List<AnimalPrefab>();
		for (int i = 0; i < spots.Length; i++)
		{
			AnimalPrefab animalPrefab = spots[i]?.GetCurrentAnimalPrefab();
			if (animalPrefab != null)
			{
				list.Add(animalPrefab);
			}
		}
		if (list.Count == 0)
		{
			Debug.Log($"{spots.Length}개의 spot 모두 비어있습니다.");
			yield break;
		}
		float num = float.MaxValue;
		foreach (AnimalPrefab item in list)
		{
			float voiceSpeed = item.GetVoiceSpeed();
			if (voiceSpeed < num)
			{
				num = voiceSpeed;
			}
		}
		foreach (AnimalPrefab item2 in list)
		{
			item2.PlayVoice();
			item2.AddIncome();
		}
		yield return new WaitForSeconds(1f / num);
	}
}
