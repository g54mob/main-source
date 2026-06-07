using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class UnlockView : MonoBehaviour, ILocalable
{
	[SerializeField]
	private TextMeshProUGUI _nameText;

	[SerializeField]
	private Image _animalIcon;

	[SerializeField]
	private Image _animalShadowIcon;

	private Animal _animal;

	private Action<Animal> _onFinishUnlockView;

	private void OnEnable()
	{
		LocaleHelper.SubscribeLocaleChanged(OnLocaleChanged);
	}

	private void OnDisable()
	{
		LocaleHelper.UnsubscribeLocaleChanged(OnLocaleChanged);
	}

	public void Show(Animal animal, Action<Animal> onFinishUnlockView)
	{
		_animal = animal;
		_onFinishUnlockView = onFinishUnlockView;
		_nameText.text = LocaleHelper.Get(animal.AnimalData.NameLocalKey);
		_animalIcon.sprite = Resources.Load<Sprite>(animal.AnimalData.IconPath);
		_animalShadowIcon.sprite = Resources.Load<Sprite>(animal.AnimalData.IconShadowPath);
		base.gameObject.SetActive(value: true);
	}

	public void Hide()
	{
		_animal = null;
		_onFinishUnlockView = null;
		base.gameObject.SetActive(value: false);
	}

	public void OnFinishUnlockView()
	{
		_onFinishUnlockView?.Invoke(_animal);
		Hide();
	}

	public void OnSoundPlay()
	{
		MonoSingleton<SoundManager>.Instance.PlaySFX(SFXType.SFX_UnlockAnimal);
	}

	public void OnLocaleChanged(Locale locale)
	{
		if (_animal != null)
		{
			_nameText.text = LocaleHelper.Get(_animal.AnimalData.NameLocalKey);
		}
	}
}
