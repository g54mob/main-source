using TMPro;
using UnityEngine;

namespace TH20
{
	public class SoundTest : MonoBehaviour
	{
		[SerializeField]
		private TMP_InputField _inputField;

		[SerializeField]
		private GameObject _validEventName;

		[SerializeField]
		private GameObject _invalidEventName;

		private InputManager _inputManager;

		private GameObject _soundTestGameObject;

		private AudioEmitter _previousAudioEmitter;

		public void Setup(InputManager inputManager)
		{
			_inputManager = inputManager;
			_inputField.onValueChanged.AddListener(OnValueChanged);
			_inputField.onSelect.AddListener(OnSelect);
			_inputField.onDeselect.AddListener(OnDeselect);
		}

		private void OnSelect(string value)
		{
			_inputManager.Enabled = false;
		}

		private void OnDeselect(string value)
		{
			_inputManager.Enabled = true;
		}

		private void OnValueChanged(string value)
		{
			if (AudioManager.Instance != null)
			{
				bool flag = AudioManager.Instance.DoesSoundEventExist(value);
				_validEventName.SetActive(flag);
				_invalidEventName.SetActive(!flag);
			}
		}

		protected void Update()
		{
			if (!_inputManager.GetMouseDownOnScene(MouseButton.Left))
			{
				return;
			}
			if (_soundTestGameObject == null)
			{
				_soundTestGameObject = new GameObject("Sound Test Gameobject");
			}
			if (_previousAudioEmitter != null && !_previousAudioEmitter.Finished)
			{
				_previousAudioEmitter.Stop(playOutro: false);
			}
			if (AudioManager.Instance != null)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (new Plane(Vector3.up, Vector3.zero).Raycast(ray, out var enter))
				{
					_soundTestGameObject.transform.position = ray.GetPoint(enter);
					_previousAudioEmitter = AudioManager.Instance.Play(_inputField.text, _soundTestGameObject);
				}
			}
		}
	}
}
