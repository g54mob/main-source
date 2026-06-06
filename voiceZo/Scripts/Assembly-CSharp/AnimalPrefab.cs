using UnityEngine;

public class AnimalPrefab : MonoBehaviour
{
	[SerializeField]
	private AudioClip _voiceClip;

	private AnimalCanvas _animalCanvas;

	private Animator _animator;

	private AudioSource _audioSource;

	private const float BASE_ANIMATION_LENGTH = 1f;

	private bool _isAdoptProcessing;

	private float _incomeTimer;

	private readonly string FOCUS_PIVOT_NAME = "FocusPivot";

	private bool _isInCamp;

	private AudioClip _costumeVoiceClip;

	private bool _isApplyCostumeVoiceClip;

	public Animal Animal { get; private set; }

	public Transform FocusPivot { get; private set; }

	private void Update()
	{
		AddIncomePerInterval();
	}

	public void Init(Animal animal)
	{
		Animal = animal;
		Animal.OnVoiceChanged += ChangeVoiceClip;
		Animal.OnChangeIsAdoptProcessing += ChangeIsAdoptProcessing;
		Animal.OnPlayVoice += PlayVoice;
		_animator = GetComponent<Animator>();
		_audioSource = GetComponent<AudioSource>();
		_animalCanvas = GetComponentInChildren<AnimalCanvas>();
		_animalCanvas.Init(animal);
		FocusPivot = base.transform.Find(FOCUS_PIVOT_NAME);
		ChangeIsAdoptProcessing(isAdoptProcessing: false);
		_incomeTimer = Random.Range(0f, Animal.AnimalData.IncomeInterval);
	}

	public void Release()
	{
		Animal.OnVoiceChanged -= ChangeVoiceClip;
		Animal.OnChangeIsAdoptProcessing -= ChangeIsAdoptProcessing;
		Animal.OnPlayVoice -= PlayVoice;
		Animal = null;
		_animalCanvas.Release();
	}

	private void AddIncomePerInterval()
	{
		if (_isInCamp)
		{
			return;
		}
		_incomeTimer += Time.deltaTime;
		if (_incomeTimer >= (float)Animal.AnimalData.IncomeInterval / _audioSource.pitch)
		{
			if (!_isInCamp)
			{
				AddIncome();
			}
			if (!_isAdoptProcessing && !_isInCamp)
			{
				PlayVoice();
			}
			_incomeTimer %= (float)Animal.AnimalData.IncomeInterval / _audioSource.pitch;
		}
	}

	public void AddIncome()
	{
		Animal.AddIncomePerSecond(Animal.GetIncome());
		if (!_isAdoptProcessing)
		{
			_animalCanvas.PlayIncomeTextAnim();
		}
	}

	public void PlayVoice()
	{
		float num = ((!_isAdoptProcessing) ? _audioSource.pitch : 1f);
		AudioClip audioClip = ((!_isApplyCostumeVoiceClip) ? _voiceClip : ((!_isAdoptProcessing) ? _costumeVoiceClip : _voiceClip));
		float value = 1f / audioClip.length * num;
		_animator.SetFloat("voiceSpeed", value);
		_audioSource.clip = audioClip;
		_audioSource.Play();
		_animator.SetTrigger("voice");
	}

	public void ChangeMuteState(bool isMute)
	{
		_audioSource.mute = isMute;
	}

	public void ChangeVoiceClip(AudioClip voiceClip)
	{
		_voiceClip = voiceClip;
	}

	private void ChangeIsAdoptProcessing(bool isAdoptProcessing)
	{
		_isAdoptProcessing = isAdoptProcessing;
	}

	public void SetNameCanvasSortingOrder(int sortingOrder)
	{
		_animalCanvas.SetNameCanvasSortingOrder(sortingOrder);
	}

	public void SetPitch(float pitch)
	{
		_audioSource.pitch = pitch;
	}

	public float GetVoiceSpeed()
	{
		return 1f / _voiceClip.length * _audioSource.pitch;
	}

	public void SetIsInCamp(bool isInCamp)
	{
		_isInCamp = isInCamp;
	}

	public void SetCostumeVoice(AudioClip voiceClip)
	{
		_costumeVoiceClip = voiceClip;
		_isApplyCostumeVoiceClip = true;
	}

	public void ResetCostumeVoice()
	{
		_isApplyCostumeVoiceClip = false;
		_costumeVoiceClip = null;
	}

	public AudioClip GetVoiceClip()
	{
		return _voiceClip;
	}
}
