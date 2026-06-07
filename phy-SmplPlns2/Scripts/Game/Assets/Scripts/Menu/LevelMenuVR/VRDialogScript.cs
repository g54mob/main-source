using System.Linq;
using Assets.Scripts.UI;
using Jundroo.Common.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Menu.LevelMenuVR
{
	public class VRDialogScript : MonoBehaviour
	{
		public delegate void DialogDelegate(VRDialogScript dialog);

		[SerializeField]
		private Button _cancelButton;

		private TextMeshProUGUI _cancelLabel;

		private bool _initialized;

		[SerializeField]
		private TextMeshProUGUI _label;

		[SerializeField]
		private Button _okayButton;

		private TextMeshProUGUI _okayLabel;

		private bool _showCancel;

		private bool _showOkay;

		public string CancelButtonText
		{
			get
			{
				return _cancelLabel.text;
			}
			set
			{
				_cancelLabel.text = value;
			}
		}

		public string MessageText
		{
			get
			{
				return _label.text;
			}
			set
			{
				_label.text = value;
			}
		}

		public string OkayButtonText
		{
			get
			{
				return _okayLabel.text;
			}
			set
			{
				_okayLabel.text = value;
			}
		}

		public object UserData { get; set; }

		public event DialogDelegate OnCancel;

		public event DialogDelegate OnOkay;

		public static VRDialogScript CreateDialog(bool showOkay = true, bool showCancel = true, RectTransform parent = null)
		{
			GameObject gameObject = Object.Instantiate(Resources.Load("Menu/VR/Dialog")) as GameObject;
			if (parent != null)
			{
				gameObject.transform.SetParent(parent);
			}
			else
			{
				Canvas canvas = (from y in Object.FindObjectsByType<VrDialogPreferredCanvas>(FindObjectsSortMode.None)
					select y.GetComponent<Canvas>()).FirstOrDefault();
				if (canvas == null)
				{
					canvas = (from y in Object.FindObjectsByType<Canvas>(FindObjectsSortMode.None)
						where y.renderMode == RenderMode.WorldSpace
						select y).FirstOrDefault();
				}
				if (canvas != null)
				{
					gameObject.transform.SetParent(canvas.transform);
				}
				else
				{
					Debug.LogError("Could not find suitable WorldSpace canvas for VRDialogScript");
				}
			}
			gameObject.transform.localPosition = default(Vector3);
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			gameObject.transform.localRotation = Quaternion.identity;
			VRDialogScript component = gameObject.GetComponent<VRDialogScript>();
			component._showOkay = showOkay;
			component._showCancel = showCancel;
			component.Initialize();
			component.OkayButtonText = "OKAY";
			component.CancelButtonText = "CANCEL";
			return component;
		}

		public void Close()
		{
			base.gameObject.SetActive(value: false);
			Object.Destroy(base.gameObject);
		}

		protected virtual void Start()
		{
			Initialize();
			base.gameObject.AddMissingComponent<CanvasGroup>();
			RectTransform component = GetComponent<RectTransform>();
			component.offsetMin = Vector2.zero;
			component.offsetMax = Vector2.zero;
		}

		protected virtual void Update()
		{
			if (UnityEngine.Input.GetKeyDown(KeyCode.Escape) && _showCancel)
			{
				CancelClicked();
			}
		}

		private void CancelClicked()
		{
			Game.Instance.UserInterface.Sound.PlaySound(UISound.ButtonClick);
			if (this.OnCancel == null)
			{
				Close();
			}
			else
			{
				this.OnCancel(this);
			}
		}

		private void Initialize()
		{
			if (!_initialized)
			{
				_initialized = true;
				_cancelLabel = _cancelButton.GetComponentInChildren<TextMeshProUGUI>();
				_okayLabel = _okayButton.GetComponentInChildren<TextMeshProUGUI>();
				_cancelButton.gameObject.SetActive(_showCancel);
				_okayButton.gameObject.SetActive(_showOkay);
				if (_showCancel != _showOkay)
				{
					Button button = (_showOkay ? _okayButton : _cancelButton);
					button.transform.localPosition = new Vector3(0f, button.transform.localPosition.y, button.transform.localPosition.z);
				}
				_cancelButton.onClick.AddListener(delegate
				{
					CancelClicked();
				});
				_okayButton.onClick.AddListener(delegate
				{
					OkayClicked();
				});
			}
		}

		private void OkayClicked()
		{
			Game.Instance.UserInterface.Sound.PlaySound(UISound.ButtonClick);
			if (this.OnOkay == null)
			{
				Close();
			}
			else
			{
				this.OnOkay(this);
			}
		}
	}
}
