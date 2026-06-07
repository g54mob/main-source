using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.GradientEditor
{
	public class GradientEditorScript : MonoBehaviour
	{
		[SerializeField]
		private Gradient _gradient;

		[SerializeField]
		private GradientViewer _viewerScript;

		[SerializeField]
		private GradientEditorHandleScript _alphaHandleTemplate;

		[SerializeField]
		private GradientHandleTrackScript _alphaTrack;

		[SerializeField]
		private GradientHandleTrackScript _colourTrack;

		[SerializeField]
		private GradientEditorHandleScript _colourHandleTemplate;

		[SerializeField]
		private Toggle _smoothGradientToggle;

		[SerializeField]
		private SliderInputGroup _positionInput;

		[SerializeField]
		private SliderInputGroup _alphaInput;

		[SerializeField]
		private ColourInputGroup _colourInput;

		[SerializeField]
		private GameObject[] _sharedKeyEditors;

		[SerializeField]
		private GameObject[] _alphaKeyEditors;

		[SerializeField]
		private GameObject[] _colourKeyEditors;

		[SerializeField]
		private Button _cancelButton;

		[SerializeField]
		private Button _saveButton;

		private List<GradientEditorHandleScript> _alphaHandles;

		private List<GradientEditorHandleScript> _colourHandles;

		private GradientEditorHandleScript _selected;

		private bool _hasAlpha = true;

		public bool AllowHDR
		{
			get
			{
				return _colourInput.AllowHDR;
			}
			set
			{
				_colourInput.AllowHDR = value;
			}
		}

		public bool HasAlpha
		{
			get
			{
				return _hasAlpha;
			}
			set
			{
				if (_hasAlpha == value)
				{
					return;
				}
				_hasAlpha = value;
				_viewerScript.AlphaHeight = (value ? 0.25f : 0f);
				if (value)
				{
					return;
				}
				foreach (GradientEditorHandleScript alphaHandle in _alphaHandles)
				{
					alphaHandle.Active = false;
					alphaHandle.Reserved = false;
				}
			}
		}

		public Gradient Gradient
		{
			get
			{
				return _gradient;
			}
			set
			{
				_gradient = value;
				Initialise();
			}
		}

		public event Action<bool> OnComplete;

		public void Initialise()
		{
			_viewerScript.Gradient = _gradient;
			_smoothGradientToggle.SetIsOnWithoutNotify(_gradient.mode == GradientMode.Blend);
			ClearHandles();
			GradientColorKey[] colorKeys = _gradient.colorKeys;
			foreach (GradientColorKey key in colorKeys)
			{
				AddHandle(key);
			}
			GradientAlphaKey[] alphaKeys = _gradient.alphaKeys;
			foreach (GradientAlphaKey key2 in alphaKeys)
			{
				AddHandle(key2);
			}
		}

		public void Redraw()
		{
			_gradient.SetKeys((from x in _colourHandles
				where x.Active
				orderby x.Position
				select x.ColorKey).ToArray(), (from x in _alphaHandles
				where x.Active
				orderby x.Position
				select x.AlphaKey).ToArray());
			_viewerScript.SetVerticesDirty();
		}

		public GradientEditorHandleScript AddHandle(GradientColorKey key)
		{
			GradientEditorHandleScript gradientEditorHandleScript = null;
			foreach (GradientEditorHandleScript colourHandle in _colourHandles)
			{
				if (colourHandle.CanReuse)
				{
					gradientEditorHandleScript = colourHandle;
					break;
				}
			}
			if (gradientEditorHandleScript == null)
			{
				gradientEditorHandleScript = UnityEngine.Object.Instantiate(_colourHandleTemplate.gameObject, _colourHandleTemplate.transform.parent).GetComponent<GradientEditorHandleScript>();
				_colourHandles.Add(gradientEditorHandleScript);
			}
			gradientEditorHandleScript.Active = true;
			gradientEditorHandleScript.ColorKey = key;
			return gradientEditorHandleScript;
		}

		public GradientEditorHandleScript AddHandle(GradientAlphaKey key)
		{
			if (!HasAlpha)
			{
				return null;
			}
			GradientEditorHandleScript gradientEditorHandleScript = null;
			foreach (GradientEditorHandleScript alphaHandle in _alphaHandles)
			{
				if (!alphaHandle.Active)
				{
					gradientEditorHandleScript = alphaHandle;
					break;
				}
			}
			if (gradientEditorHandleScript == null)
			{
				gradientEditorHandleScript = UnityEngine.Object.Instantiate(_alphaHandleTemplate.gameObject, _alphaHandleTemplate.transform.parent).GetComponent<GradientEditorHandleScript>();
				_alphaHandles.Add(gradientEditorHandleScript);
			}
			gradientEditorHandleScript.Active = true;
			gradientEditorHandleScript.AlphaKey = key;
			return gradientEditorHandleScript;
		}

		public void SetSelectedHandle(GradientEditorHandleScript handle, bool alpha)
		{
			if (_selected != null)
			{
				_selected.Selected = false;
			}
			_selected = handle;
			bool flag = handle != null;
			SetActivation(_sharedKeyEditors, flag);
			if (flag)
			{
				handle.Selected = true;
				handle.transform.SetAsLastSibling();
				handle.transform.SetAsLastSibling();
				SetActivation(_alphaKeyEditors, alpha);
				SetActivation(_colourKeyEditors, !alpha);
				UpdateSharedEditors();
				if (alpha)
				{
					UpdateAlphaEditor();
				}
				else
				{
					UpdateColourEditor();
				}
			}
			else
			{
				SetActivation(_alphaKeyEditors, activate: false);
				SetActivation(_colourKeyEditors, activate: false);
			}
		}

		private void UpdateSharedEditors()
		{
			_positionInput.Value = _selected.Position;
		}

		private void UpdateAlphaEditor()
		{
			_alphaInput.Value = _selected.Alpha;
		}

		private void UpdateColourEditor()
		{
			_colourInput.Colour = _selected.Color;
		}

		private void Awake()
		{
			_alphaHandleTemplate.Active = false;
			_alphaHandles = new List<GradientEditorHandleScript>();
			_alphaTrack.Handles = _alphaHandles;
			_colourHandleTemplate.Active = false;
			_colourHandles = new List<GradientEditorHandleScript>();
			_colourTrack.Handles = _colourHandles;
			_smoothGradientToggle.onValueChanged.AddListener(delegate(bool on)
			{
				_gradient.mode = ((!on) ? GradientMode.Fixed : GradientMode.Blend);
				Redraw();
			});
			_positionInput.OnValueChanged += delegate(float f)
			{
				_selected.Position = f;
				Redraw();
			};
			_alphaInput.OnValueChanged += delegate(float f)
			{
				_selected.Alpha = f;
				Redraw();
			};
			_colourInput.OnValueChanged += delegate(Color c)
			{
				_selected.Color = c;
				Redraw();
			};
			_cancelButton.onClick.AddListener(delegate
			{
				this.OnComplete?.Invoke(obj: false);
			});
			_saveButton.onClick.AddListener(delegate
			{
				this.OnComplete?.Invoke(obj: true);
			});
			SetSelectedHandle(null, alpha: false);
		}

		private void ClearHandles()
		{
			foreach (GradientEditorHandleScript colourHandle in _colourHandles)
			{
				colourHandle.Active = false;
				colourHandle.Reserved = false;
			}
			foreach (GradientEditorHandleScript alphaHandle in _alphaHandles)
			{
				alphaHandle.Active = false;
				alphaHandle.Reserved = false;
			}
		}

		private void SetActivation(GameObject[] objects, bool activate)
		{
			for (int i = 0; i < objects.Length; i++)
			{
				objects[i].SetActive(activate);
			}
		}

		private void Update()
		{
			if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
			{
				this.OnComplete?.Invoke(obj: false);
			}
		}
	}
}
