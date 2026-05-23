#define ENABLE_DEBUG_LOGS
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Presentation.UI.LoadingScreen
{
	public class LoadingScreenProgressUI : MonoBehaviour
	{
		[SerializeField]
		private LoadingScreenProgressVariableSO _loadingScreenProgressVariable;

		[SerializeField]
		private RectTransform _progressIcon;

		[SerializeField]
		[Range(0f, 1f)]
		private float _currProgress01;

		[Header("Sprites")]
		[SerializeField]
		private Image _iconImage;

		[SerializeField]
		private Sprite[] _iconSprites;

		[SerializeField]
		private Sprite _rareRandomIconSprite;

		[SerializeField]
		private Image _fgImage;

		[SerializeField]
		private Sprite[] _fgSprites = new Sprite[0];

		private int _step;

		private void OnEnable()
		{
			_loadingScreenProgressVariable.ValueChanged += UpdateProgress;
			_step = 0;
			UpdateProgress(_loadingScreenProgressVariable.Value);
			if (Random.Range(0, 1000) == 0)
			{
				_iconImage.sprite = _rareRandomIconSprite;
			}
			else
			{
				_iconImage.sprite = _iconSprites[GetRandomSpriteIndex()];
			}
			_iconImage.SetNativeSize();
		}

		private int GetRandomSpriteIndex()
		{
			float num = Mathf.Min(Random.value, 0.99999f);
			return Mathf.FloorToInt(num * num * (float)_iconSprites.Length);
		}

		private void OnDisable()
		{
			_loadingScreenProgressVariable.ValueChanged -= UpdateProgress;
		}

		private void UpdateProgress(LoadingScreenProgressVariableSO.Values values)
		{
			base.gameObject.SetActive(!values.Hide);
			if (base.gameObject.activeSelf)
			{
				float x = (_progressIcon.parent as RectTransform).sizeDelta.x;
				Vector2 anchoredPosition = _progressIcon.anchoredPosition;
				anchoredPosition.x = x * values.Progress01;
				_progressIcon.anchoredPosition = anchoredPosition;
				_fgImage.sprite = _fgSprites[_step % _fgSprites.Length];
				_step++;
			}
		}

		private void OnValidate()
		{
			UpdateProgress(new LoadingScreenProgressVariableSO.Values(hide: false, _currProgress01));
		}

		[Button(null, EButtonEnableMode.Always)]
		private void TestIconSpriteOdds()
		{
			int[] array = new int[_iconSprites.Length];
			for (int i = 0; i < 100000; i++)
			{
				array[GetRandomSpriteIndex()]++;
			}
			for (int j = 0; j < _iconSprites.Length; j++)
			{
				this.Log($"{_iconSprites[j].name}: {Mathf.RoundToInt((float)array[j] / 1000f)}%", "TestIconSpriteOdds", 86);
			}
		}
	}
}
