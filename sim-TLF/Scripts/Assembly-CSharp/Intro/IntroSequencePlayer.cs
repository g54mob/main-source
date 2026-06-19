using System;
using System.Collections;
using JSAM;
using Player;
using Services.Save.Player;
using TMPEffects.CharacterData;
using TMPEffects.Components;
using UI.HUD;
using UnityEngine;
using Zenject;

namespace Intro
{
	public class IntroSequencePlayer : MonoBehaviour
	{
		[SerializeField]
		private SoundFileObject _ambientSound;

		[SerializeField]
		private SoundFileObject _letterSound;

		[SerializeField]
		private SoundFileObject _typeSound;

		[SerializeField]
		private SoundFileObject _errorSound;

		[SerializeField]
		private SoundFileObject _successSound;

		[SerializeField]
		private SoundFileObject _completeSound;

		[SerializeField]
		private SoundFileObject _closeSound;

		[SerializeField]
		private TMPWriter _sideWriter;

		[SerializeField]
		private TMPWriter _headerWriter;

		[SerializeField]
		private TMPWriter _titleWriter;

		[SerializeField]
		private TMPWriter _descriptionWriter;

		[SerializeField]
		private Animator _sideWriterAnimator;

		[Space(5f)]
		[Header("Time Delays")]
		[SerializeField]
		private float _mainWritersClearDelay;

		[SerializeField]
		private float _descriptionDelay;

		[SerializeField]
		private float _titleDelay;

		[SerializeField]
		private float _headerDelay;

		[SerializeField]
		private float _leftWriterDisappearDelay;

		[SerializeField]
		private float _errorSoundDelay;

		[Inject]
		private PlayerHUDView _playerHUD;

		[Inject]
		private PlayerSaveService _playerSaveService;

		[Inject]
		private IPlayerInputService _playerInputService;

		public event Action OnIntroFinished;

		private void Start()
		{
			_playerHUD.StatsView.gameObject.SetActive(value: false);
			_playerHUD.InventoryView.gameObject.SetActive(value: false);
			AudioManager.PlaySound(_ambientSound);
			_sideWriter.gameObject.SetActive(value: true);
			_sideWriter.OnFinishWriter.AddListener(StartHeaderWriterWithDelay);
			_headerWriter.OnFinishWriter.AddListener(StartTitleWriteWithDelay);
			_titleWriter.OnFinishWriter.AddListener(StartDescriptionWriterWithDelay);
			_descriptionWriter.OnFinishWriter.AddListener(ClearWritersWithDelay);
			_playerInputService.DisableAllInput();
		}

		private void OnEnable()
		{
			_sideWriter.gameObject.SetActive(value: true);
			_sideWriter.OnCharacterShown.AddListener(SideWriterCharShow);
			_headerWriter.OnCharacterShown.AddListener(SideWriterCharShow);
			_titleWriter.OnCharacterShown.AddListener(TitleWriterCharShow);
			_descriptionWriter.OnCharacterShown.AddListener(SideWriterCharShow);
		}

		private void OnDisable()
		{
			AudioManager.StopSoundIfPlaying(_ambientSound);
			_playerInputService.EnableAllInput();
		}

		private void SideWriterCharShow(TMPWriter writer, CharData charData)
		{
			if (charData.info.index == 354 || charData.info.index == 399)
			{
				PlayErrorMessageWithDelay();
			}
			if (charData.info.index == 103)
			{
				PlayOKMessageWithDelay();
			}
			if (charData.info.index == 160)
			{
				PlayOKMessageWithDelay(delegate
				{
					_playerHUD.StatsView.gameObject.SetActive(value: true);
				});
			}
			_ = charData.info.index;
			_ = 205;
			if (charData.info.index == 266)
			{
				PlayOKMessageWithDelay(delegate
				{
					_playerHUD.InventoryView.gameObject.SetActive(value: true);
				});
			}
			if (charData.info.character != '.')
			{
				AudioManager.PlaySound(_letterSound);
			}
		}

		private void TitleWriterCharShow(TMPWriter writer, CharData charData)
		{
			if (charData.info.character != '.')
			{
				AudioManager.PlaySound(_typeSound);
			}
		}

		private void PlayErrorMessageWithDelay()
		{
			StartCoroutine(PlayErrorSound(_errorSoundDelay));
		}

		private void PlayOKMessageWithDelay(Action afterSound = null)
		{
			StartCoroutine(PlayOKSound(_errorSoundDelay, afterSound));
		}

		private IEnumerator PlayErrorSound(float delay)
		{
			yield return new WaitForSeconds(delay);
			AudioManager.PlaySound(_errorSound);
		}

		private IEnumerator PlayOKSound(float delay, Action afterSound = null)
		{
			yield return new WaitForSeconds(delay);
			AudioManager.PlaySound(_successSound);
			afterSound?.Invoke();
		}

		private void ClearWritersWithDelay(TMPWriter arg0)
		{
			StartCoroutine(ClearMainWriters(_mainWritersClearDelay));
		}

		private IEnumerator ClearMainWriters(float delay)
		{
			yield return new WaitForSeconds(delay);
			AudioManager.PlaySound(_completeSound);
			AudioManager.StopSoundIfPlaying(_ambientSound);
			_titleWriter.gameObject.SetActive(value: false);
			_headerWriter.gameObject.SetActive(value: false);
			_descriptionWriter.gameObject.SetActive(value: false);
			_playerInputService.EnableAllInput();
			this.OnIntroFinished?.Invoke();
		}

		private void StartDescriptionWriterWithDelay(TMPWriter arg0)
		{
			StartCoroutine(StartDescriptionWriter(_descriptionDelay));
		}

		private IEnumerator StartDescriptionWriter(float delay)
		{
			yield return new WaitForSeconds(delay);
			_descriptionWriter.gameObject.SetActive(value: true);
		}

		private void StartTitleWriteWithDelay(TMPWriter arg0)
		{
			StartCoroutine(StartTitleWriter(_titleDelay));
		}

		private IEnumerator StartTitleWriter(float delay)
		{
			yield return new WaitForSeconds(delay);
			_titleWriter.gameObject.SetActive(value: true);
		}

		private void StartHeaderWriterWithDelay(TMPWriter arg0)
		{
			StartCoroutine(StartHeaderWriter(_headerDelay));
		}

		private IEnumerator StartHeaderWriter(float delay)
		{
			_sideWriterAnimator.enabled = true;
			yield return new WaitForSeconds(_leftWriterDisappearDelay);
			_sideWriter.gameObject.SetActive(value: false);
			AudioManager.PlaySound(_closeSound);
			yield return new WaitForSeconds(delay);
			_headerWriter.gameObject.SetActive(value: true);
		}
	}
}
