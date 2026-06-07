using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Menu.LevelMenuVR.ListView
{
	public class ToggleButtonScript : MonoBehaviour
	{
		private Button _button;

		[SerializeField]
		private Image _image;

		private Color32 _initialImageColor;

		public Action<ToggleButtonScript> Callback { get; set; }

		public void SetButtonStates(bool visible, bool selected)
		{
			base.gameObject.SetActive(visible);
			_image.color = (selected ? new Color32(0, 120, byte.MaxValue, byte.MaxValue) : _initialImageColor);
			if (base.gameObject.activeInHierarchy)
			{
				StartCoroutine(UpdateButtonEffects(selected));
			}
		}

		protected virtual void Awake()
		{
			_button = GetComponentInChildren<Button>(includeInactive: true);
			_initialImageColor = _image.color;
			_button.onClick.AddListener(delegate
			{
				Callback?.Invoke(this);
			});
		}

		private IEnumerator UpdateButtonEffects(bool selected)
		{
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			if (TryGetComponent<ButtonEffectsScript>(out var component))
			{
				component.SoundEffect = ((!selected) ? ButtonEffectsScript.ButtonSoundEffectType.Success : ButtonEffectsScript.ButtonSoundEffectType.Normal);
			}
		}
	}
}
