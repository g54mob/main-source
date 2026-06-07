using System;
using System.Linq;
using Assets.Scripts.UI;
using Jundroo.Common.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.GuiNew
{
	public class DialogScript : MonoBehaviour
	{
		public delegate void DialogDelegate(DialogScript dialog);

		[SerializeField]
		private Button _cancelButton;

		private Text _cancelLabel;

		private bool _initialized;

		[SerializeField]
		private Text _label;

		[SerializeField]
		private Button _okayButton;

		private Text _okayLabel;

		private bool _showCancel;

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

		public Canvas Canvas { get; private set; }

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

		public static DialogScript CreateDialog(bool showCancel = true, Canvas canvas = null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load("Gui/Dialog")) as GameObject;
			Canvas loadingScreenCanvas = Game.Instance.SceneManager.LoadingScreenCanvas;
			canvas = canvas ?? (from x in UnityEngine.Object.FindObjectsByType<Canvas>(FindObjectsInactive.Exclude, FindObjectsSortMode.None)
				where x != loadingScreenCanvas
				select x).FirstOrDefault() ?? (from x in UnityEngine.Object.FindObjectsByType<Canvas>(FindObjectsInactive.Include, FindObjectsSortMode.None)
				where x != loadingScreenCanvas
				select x).FirstOrDefault();
			if (canvas == null)
			{
				Debug.LogException(new Exception("Unable to find a canvas for a dialog script."));
			}
			else
			{
				gameObject.transform.SetParent(canvas.transform);
			}
			gameObject.transform.localPosition = default(Vector3);
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			DialogScript component = gameObject.GetComponent<DialogScript>();
			component.Canvas = canvas;
			component._showCancel = showCancel;
			component.Initialize();
			component.OkayButtonText = "OKAY";
			component.CancelButtonText = "CANCEL";
			return component;
		}

		public void Close()
		{
			base.gameObject.SetActive(value: false);
			UnityEngine.Object.Destroy(base.gameObject);
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
				_cancelLabel = _cancelButton.GetComponentInChildren<Text>();
				_okayLabel = _okayButton.GetComponentInChildren<Text>();
				if (!_showCancel)
				{
					_cancelButton.gameObject.SetActive(value: false);
					_okayButton.transform.localPosition = new Vector3(0f, _okayButton.transform.localPosition.y, _okayButton.transform.localPosition.z);
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
