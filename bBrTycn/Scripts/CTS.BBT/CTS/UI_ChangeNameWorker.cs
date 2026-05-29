using System.Collections;
using CTS.Core;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace CTS
{
	public class UI_ChangeNameWorker : MonoBehaviour
	{
		private string _newName;

		[Foldout("Dev")]
		[SerializeField]
		private TMP_InputField _inputFieldText;

		[Foldout("Dev")]
		[SerializeField]
		private Button _buttonRename;

		[SerializeField]
		private InputActionAsset _assetPlayerInput;

		[SerializeField]
		private AnimationCurve _alphaBlinkCurve;

		[SerializeField]
		private float _speedBlink;

		[SerializeField]
		private Color _colorRename;

		[SerializeField]
		private Color _colorNotRename;

		[SerializeField]
		private AgentIdentityPanel _agentIdentityPanel;

		[SerializeField]
		private TMP_Text _placeHolderText;

		private string _lastName;

		private bool _wantToBlink;

		private float _placeHolderAlpha;

		private float _currenTime;

		public void NameChange()
		{
			if (EventSystem.current != null)
			{
				EventSystem current = EventSystem.current;
				if (current.alreadySelecting)
				{
					if (current.currentSelectedGameObject == _inputFieldText.gameObject)
					{
						StartCoroutine(Delayco());
						return;
					}
				}
				else
				{
					EventSystem.current.SetSelectedGameObject(null);
					_inputFieldText.interactable = false;
				}
			}
			if (_inputFieldText.text == "")
			{
				_inputFieldText.text = _lastName;
			}
			else
			{
				_newName = _inputFieldText.text;
				_lastName = _newName;
				_inputFieldText.text = _lastName;
				_placeHolderText.text = _lastName;
				_agentIdentityPanel.ChangeName(_lastName);
			}
			if (MonoSingleton<MainCamera>.InstanceExists())
			{
				MainCamera instance = MonoSingleton<MainCamera>.Instance;
				instance.Movements.enabled = true;
				instance.CameraRotation.enabled = true;
				instance.Zoom.enabled = true;
				EnableInputAsset();
			}
			_wantToBlink = false;
			_inputFieldText.textComponent.color = ChangeColor(_colorNotRename, 1f);
			_placeHolderText.color = ChangeColor(_colorNotRename, _placeHolderAlpha);
		}

		private IEnumerator Delayco()
		{
			yield return new WaitForEndOfFrame();
			_inputFieldText.interactable = false;
			NameChange();
		}

		public void NameCanBeChange(bool worker, string nameworker)
		{
			_buttonRename.gameObject.SetActive(worker);
			_inputFieldText.gameObject.SetActive(worker);
			_inputFieldText.text = nameworker;
		}

		public void SetName(AgentIdentityPanel agentIdentity)
		{
			_inputFieldText.interactable = false;
			_agentIdentityPanel = agentIdentity;
			_inputFieldText.caretBlinkRate = _speedBlink;
			_placeHolderAlpha = _placeHolderText.color.a;
			_newName = _placeHolderText.text;
			_lastName = _newName;
			_inputFieldText.text = _lastName;
			if (_placeHolderText.color != _colorNotRename)
			{
				_inputFieldText.textComponent.color = ChangeColor(_colorNotRename, 1f);
				_placeHolderText.color = ChangeColor(_colorNotRename, _placeHolderAlpha);
			}
			OnUpper();
		}

		public void FocusPlayerImage()
		{
			_wantToBlink = true;
			_inputFieldText.interactable = true;
			_inputFieldText.textComponent.color = ChangeColor(_colorRename, 1f);
			_placeHolderText.color = ChangeColor(_colorRename, _placeHolderAlpha);
			_inputFieldText.Select();
			MainCamera instance = MonoSingleton<MainCamera>.Instance;
			if (instance != null)
			{
				instance.Zoom.enabled = false;
				instance.Movements.enabled = false;
				instance.CameraRotation.enabled = false;
				DisableInputAsset();
			}
		}

		private Color ChangeColor(Color color, float alpha)
		{
			return new Color(color.r, color.g, color.b, alpha);
		}

		public void OnUpper()
		{
			_inputFieldText.text = _inputFieldText.text.ToUpper();
			_placeHolderText.text = _placeHolderText.text.ToUpper();
		}

		public void StopBlingk()
		{
			_wantToBlink = false;
			_inputFieldText.textComponent.color = ChangeColor(_colorRename, 1f);
		}

		public void ChangeAlpha()
		{
			_currenTime += Time.deltaTime * _speedBlink;
			if (_currenTime > 1f)
			{
				_currenTime -= 1f;
			}
			float alpha = Mathf.Clamp01(_alphaBlinkCurve.Evaluate(_currenTime));
			_inputFieldText.textComponent.color = ChangeColor(_colorRename, alpha);
		}

		private void Update()
		{
			if (_wantToBlink)
			{
				ChangeAlpha();
			}
		}

		public void DisableInputAsset()
		{
			_assetPlayerInput.Disable();
		}

		public void EnableInputAsset()
		{
			_assetPlayerInput.Enable();
		}
	}
}
