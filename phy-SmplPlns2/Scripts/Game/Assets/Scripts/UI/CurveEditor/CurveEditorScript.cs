using System;
using System.Collections.Generic;
using System.Linq;
using Jundroo.Common.Platform;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Vectrosity;

namespace Assets.Scripts.UI.CurveEditor
{
	public class CurveEditorScript : MonoBehaviour
	{
		[SerializeField]
		private bool _autoFitSecondaryCurve = true;

		private Action<AnimationCurve> _callback;

		[SerializeField]
		private Button _cancelButton;

		[SerializeField]
		private AnimationCurve _curve;

		[SerializeField]
		private Button _deleteButton;

		[SerializeField]
		private int _divisions = 100;

		[SerializeField]
		private GridScript _gridScript;

		[SerializeField]
		private EditorHandlesScript _handles;

		private InputHandlerScript _inputHandler;

		[SerializeField]
		private Button _insertAfterButton;

		[SerializeField]
		private Button _insertBeforeButton;

		[SerializeField]
		private RectTransform _keyContainer;

		private List<KeyScript> _keyScripts = new List<KeyScript>();

		[SerializeField]
		private GameObject _keyTemplate;

		private Vector2 _lastSize;

		[SerializeField]
		private Texture _lineTexture;

		[SerializeField]
		private Color _mainColour = Color.red;

		[SerializeField]
		private float _minZoom = 0.0001f;

		[SerializeField]
		private Color _outOfBoundsColour = Color.grey;

		[SerializeField]
		private Button _recentreViewButton;

		[SerializeField]
		private Button _saveButton;

		[SerializeField]
		private Color _secondaryColour = Color.cyan;

		private AnimationCurve _secondaryCurve;

		private Func<AnimationCurve, AnimationCurve> _secondaryCurveGenerator;

		private TextMeshProUGUI _secondaryLabel;

		private VectorLine _secondaryVectorLine;

		[SerializeField]
		private GameObject _sidePanel;

		[SerializeField]
		private Toggle _tangentLinkedToggle;

		[SerializeField]
		private TMP_InputField _timeInput;

		[SerializeField]
		private TMP_InputField _valueInput;

		private VectorLine _vectorLine;

		[SerializeField]
		private Vector2 _viewportOffset = Vector2.zero;

		[SerializeField]
		private Vector2 _viewportScale = Vector2.one;

		[SerializeField]
		private RectTransform _visulisationTransform;

		[SerializeField]
		private Toggle _weightedLeftToggle;

		[SerializeField]
		private Toggle _weightedRightToggle;

		[SerializeField]
		private GameObject _wrappingSettings;

		public float AspectRatio
		{
			get
			{
				Vector2 vector = _visulisationTransform.rect.size / _viewportScale;
				return vector.y / vector.x;
			}
		}

		public Vector2 CurveToPixelScale => _visulisationTransform.rect.size / _viewportScale;

		public bool StartMethodCalled { get; set; }

		public Vector2 CurveToPixel(Vector2 curve)
		{
			return curve * _visulisationTransform.rect.size / _viewportScale - _viewportOffset;
		}

		public void KeyClicked(KeyScript key)
		{
			foreach (KeyScript keyScript in _keyScripts)
			{
				keyScript.Selected = key == keyScript;
			}
			UpdateKeyEditors();
		}

		public void KeyMoved(KeyScript keyScript, Vector2 newPos)
		{
			KeyClicked(keyScript);
			Vector2 vector = PixelToCurve(newPos);
			int num = _keyScripts.IndexOf(keyScript);
			if (num == -1)
			{
				keyScript.gameObject.SetActive(value: false);
			}
			Keyframe keyframe = _curve.keys[num];
			keyframe.time = vector.x;
			keyframe.value = vector.y;
			int num2 = MoveKeyGooder(num, keyframe);
			if (num2 != num)
			{
				_keyScripts.Remove(keyScript);
				_keyScripts.Insert(num2, keyScript);
			}
			UpdateLine();
		}

		public void LaunchEditor(AnimationCurve curve, Action<AnimationCurve> callback)
		{
			_callback = callback;
			_curve = new AnimationCurve(curve.keys);
			_curve.postWrapMode = curve.postWrapMode;
			_curve.preWrapMode = curve.preWrapMode;
			_keyScripts.ForEach(delegate(KeyScript x)
			{
				x.Selected = false;
			});
			Initialise();
			CentreViewport();
			Invoke("CentreViewport", 0.01f);
		}

		public void OnTangentsChanged(Keyframe keyframe, int index)
		{
			_curve.MoveKey(index, keyframe);
			UpdateLine();
		}

		public Vector2 PixelToCurve(Vector2 pixel)
		{
			return (pixel + _viewportOffset) * _viewportScale / _visulisationTransform.rect.size;
		}

		public void PrepareGrabbableElement(Transform transform)
		{
			if (Device.IsMobileBuild)
			{
				transform.localScale = new Vector3(2f, 2f, 1f);
				if (base.transform.TryGetComponent<Image>(out var component))
				{
					component.raycastPadding = new Vector4(-10f, -10f, -10f, -10f);
				}
			}
		}

		public void SetupSecondaryCurve(Func<AnimationCurve, AnimationCurve> generator)
		{
			_secondaryCurveGenerator = generator;
			if (_curve != null)
			{
				UpdateLine();
			}
		}

		[ContextMenu("Update Line")]
		public void UpdateLine()
		{
			if (_curve != null)
			{
				if (_vectorLine?.rectTransform == null)
				{
					Initialise();
				}
				if (_secondaryCurveGenerator != null)
				{
					_secondaryCurve = _secondaryCurveGenerator(_curve);
				}
				Vector2 size = _visulisationTransform.rect.size;
				Vector2 min = PixelToCurve(Vector2.zero);
				Vector2 max = PixelToCurve(size);
				RenderLine(_curve, min, max, size, _vectorLine);
				_vectorLine.Draw();
				if (_secondaryVectorLine != null)
				{
					RenderSecondaryLine(min, max, size);
					_secondaryVectorLine.Draw();
				}
				UpdateKeys();
				UpdateKeyEditors();
				_gridScript.UpdateGrids(min, max, size, this);
			}
		}

		[ContextMenu("Centre Viewport")]
		private void CentreViewport()
		{
			Keyframe[] keys = _curve.keys;
			if (keys.Length == 0)
			{
				_viewportOffset = Vector2.zero;
				_viewportScale = Vector2.one;
				UpdateLine();
				return;
			}
			if (keys.Length == 1)
			{
				_viewportScale = Vector2.one;
				_viewportOffset = Vector2.zero;
				_viewportOffset = CurveToPixel(new Vector2(keys[0].time, keys[0].value)) - CurveToPixel(Vector2.one / 2f);
				UpdateLine();
				return;
			}
			Vector2 vector = new Vector2(keys[0].time, keys[0].value);
			Vector2 vector2 = vector;
			Keyframe[] array = keys;
			for (int i = 0; i < array.Length; i++)
			{
				Keyframe keyframe = array[i];
				vector.x = Mathf.Min(vector.x, keyframe.time);
				vector2.x = Mathf.Max(vector2.x, keyframe.time);
				vector.y = Mathf.Min(vector.y, keyframe.value);
				vector2.y = Mathf.Max(vector2.y, keyframe.value);
			}
			_viewportScale = new Vector2(Mathf.Max(_minZoom, vector2.x - vector.x), Mathf.Max(_minZoom, vector2.y - vector.y));
			_viewportOffset = Vector2.zero;
			_viewportOffset = CurveToPixel(vector);
			ZoomWindow(-1f, _visulisationTransform.rect.size / 2f);
		}

		private KeyScript CreateKeyScript(Keyframe key)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(_keyTemplate);
			gameObject.transform.SetParent(_keyContainer);
			gameObject.transform.SetAsFirstSibling();
			gameObject.SetActive(value: true);
			KeyScript component = gameObject.GetComponent<KeyScript>();
			component.UpdateFrom(key, this);
			PrepareGrabbableElement(gameObject.transform);
			return component;
		}

		private void DeleteKey()
		{
			if (_curve.length > 2 && GetSelected(out var _, out var index))
			{
				_curve.RemoveKey(index);
				_keyScripts[index].Selected = false;
				UpdateLine();
			}
		}

		private bool GetSelected(out Keyframe k, out int index)
		{
			KeyScript keyScript = _keyScripts.FirstOrDefault((KeyScript s) => s.Selected);
			if (keyScript != null)
			{
				index = _keyScripts.IndexOf(keyScript);
				k = _curve.keys[index];
				return true;
			}
			index = -1;
			k = default(Keyframe);
			return false;
		}

		private void Initialise()
		{
			if (_vectorLine == null || _vectorLine.rectTransform == null)
			{
				_vectorLine = VectorLine.SetLine(Color.red, Vector2.zero, Vector2.one);
				_vectorLine.joins = Joins.Weld;
				_vectorLine.lineType = LineType.Discrete;
				_vectorLine.lineWidth = 4f;
				_vectorLine.texture = _lineTexture;
				_vectorLine.lineType = LineType.Continuous;
				_vectorLine.SetCanvas(GetComponentInParent<Canvas>());
				RectTransform rectTransform = _vectorLine.rectTransform;
				rectTransform.SetParent(_visulisationTransform);
				rectTransform.SetSiblingIndex(1);
				rectTransform.anchorMin = Vector2.zero;
				rectTransform.anchorMax = Vector2.zero;
				rectTransform.anchoredPosition = Vector2.zero;
				rectTransform.localScale = Vector3.one;
			}
			if (_secondaryVectorLine == null || _secondaryVectorLine.rectTransform == null)
			{
				_secondaryVectorLine = VectorLine.SetLine(_secondaryColour, Vector2.zero, Vector2.one);
				_secondaryVectorLine.joins = Joins.Weld;
				_secondaryVectorLine.lineType = LineType.Discrete;
				_secondaryVectorLine.lineWidth = 2f;
				_secondaryVectorLine.texture = _lineTexture;
				_secondaryVectorLine.lineType = LineType.Continuous;
				_secondaryVectorLine.SetCanvas(GetComponentInParent<Canvas>());
				RectTransform rectTransform2 = _secondaryVectorLine.rectTransform;
				rectTransform2.SetParent(_visulisationTransform);
				rectTransform2.SetSiblingIndex(0);
				rectTransform2.anchorMin = Vector2.zero;
				rectTransform2.anchorMax = Vector2.zero;
				rectTransform2.anchoredPosition = Vector2.zero;
				rectTransform2.localScale = Vector3.one;
			}
			if (_secondaryLabel == null)
			{
				GameObject gameObject = new GameObject("SecondaryValueLabel");
				gameObject.transform.SetParent(_visulisationTransform, worldPositionStays: false);
				_secondaryLabel = gameObject.AddComponent<TextMeshProUGUI>();
				if (_valueInput != null && _valueInput.textComponent != null)
				{
					_secondaryLabel.font = _valueInput.textComponent.font;
					_secondaryLabel.fontSize = _valueInput.textComponent.fontSize * 0.8f;
				}
				_secondaryLabel.color = _secondaryColour;
				_secondaryLabel.alignment = TextAlignmentOptions.BottomLeft;
				RectTransform rectTransform3 = _secondaryLabel.rectTransform;
				rectTransform3.anchorMin = Vector2.zero;
				rectTransform3.anchorMax = Vector2.zero;
				rectTransform3.pivot = Vector2.zero;
				rectTransform3.sizeDelta = new Vector2(200f, 50f);
			}
			UpdateLine();
		}

		private void InsertKey(bool before)
		{
			if (GetSelected(out var k, out var index))
			{
				int num = index + ((!before) ? 1 : (-1));
				float num2 = ((num < 0 || num >= _curve.length) ? (k.time + (before ? (-0.1f) : 0.1f)) : ((_curve[num].time + k.time) / 2f));
				float num3 = (_curve.Evaluate(num2 + 0.005f) - _curve.Evaluate(num2 - 0.005f)) / 0.01f;
				Keyframe key = new Keyframe(num2, _curve.Evaluate(num2), num3, num3, 0.5f, 0.5f);
				key.tangentMode = 0;
				key.weightedMode = WeightedMode.None;
				int index2 = _curve.AddKey(key);
				KeyScript keyScript = CreateKeyScript(key);
				keyScript.Selected = true;
				_keyScripts.ForEach(delegate(KeyScript x)
				{
					x.Selected = false;
				});
				_keyScripts.Insert(index2, keyScript);
				UpdateLine();
			}
		}

		private int MoveKeyGooder(int index, Keyframe keyframe)
		{
			Keyframe[] keys = _curve.keys;
			for (int i = 0; i < keys.Length; i++)
			{
				if (keys[i].time == keyframe.time)
				{
					keyframe.time = keys[index].time;
				}
			}
			keys[index] = keyframe;
			_curve.keys = keys;
			keys = _curve.keys;
			for (int j = 0; j < keys.Length; j++)
			{
				if (keys[j].time == keyframe.time)
				{
					return j;
				}
			}
			return -1;
		}

		private void OnCancel()
		{
			MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.MessageText = "Please confirm that you wish to discard your changes.";
			messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
			{
				d.Close();
				_callback?.Invoke(null);
			};
		}

		private bool OnDrag(PointerEventData eventData)
		{
			_viewportOffset -= eventData.delta;
			UpdateLine();
			return true;
		}

		private bool OnPointerClick(PointerEventData eventData)
		{
			if (!eventData.dragging)
			{
				KeyClicked(null);
				return true;
			}
			return false;
		}

		private void OnSave()
		{
			_callback?.Invoke(_curve);
		}

		private bool OnScroll(PointerEventData eventData)
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(_visulisationTransform, eventData.position, null, out var localPoint);
			ZoomWindow(eventData.scrollDelta.y, localPoint);
			return true;
		}

		private void RenderLine(AnimationCurve curve, Vector2 min, Vector2 max, Vector2 scale, VectorLine line)
		{
			List<Vector2> points = line.points2;
			points.Clear();
			Vector2 vector = new Vector2(0f, curve.Evaluate(min.x));
			bool flag = vector.y >= min.y && vector.y <= max.y;
			float num = -1f;
			float num2 = -1f;
			int? num3 = null;
			if (curve.keys.Length > 1)
			{
				float time = curve.keys[0].time;
				if (time > max.x)
				{
					line.color = _outOfBoundsColour;
					num = -1f;
					num2 = -1f;
				}
				else
				{
					line.color = _mainColour;
					if (time > min.x)
					{
						num = Mathf.FloorToInt(Mathf.InverseLerp(min.x, max.x, time) * (float)_divisions);
					}
					time = curve.keys[curve.keys.Length - 1].time;
					if (time < max.x)
					{
						num2 = Mathf.CeilToInt(Mathf.InverseLerp(min.x, max.x, time) * (float)_divisions);
					}
				}
			}
			else
			{
				line.SetColor(_outOfBoundsColour);
			}
			int? num4 = null;
			int num5 = 0;
			Keyframe[] keys = curve.keys;
			for (int i = 0; i < keys.Length; i++)
			{
				Keyframe keyframe = keys[i];
				if (keyframe.time > min.x && keyframe.time < max.x)
				{
					num4 = num5;
					break;
				}
				num5++;
			}
			for (int j = 0; j < _divisions; j++)
			{
				float num6 = (float)(j + 1) / (float)_divisions;
				float num7 = Mathf.Lerp(min.x, max.x, num6);
				float num8;
				if (num4.HasValue && curve.keys[num4.Value].time < num7)
				{
					Keyframe keyframe2 = curve.keys[num4.Value];
					num8 = keyframe2.value;
					num7 = keyframe2.time;
					num6 = Mathf.InverseLerp(min.x, max.x, num7);
					j--;
					num4++;
					if (num4.Value == curve.length || curve.keys[num4.Value].time > max.x)
					{
						num4 = null;
					}
				}
				else
				{
					num8 = curve.Evaluate(num7);
				}
				bool flag2 = num8 <= max.y && num8 >= min.y;
				if (flag2 && flag)
				{
					points.Add(new Vector2(vector.x * scale.x, Mathf.InverseLerp(min.y, max.y, vector.y) * scale.y));
					points.Add(new Vector2(num6 * scale.x, Mathf.InverseLerp(min.y, max.y, num8) * scale.y));
				}
				else if (flag)
				{
					points.Add(new Vector2(vector.x * scale.x, Mathf.InverseLerp(min.y, max.y, vector.y) * scale.y));
					float value = ((num8 > min.y) ? max.y : min.y);
					float t = Mathf.InverseLerp(vector.y, num8, value);
					points.Add(new Vector2(Mathf.Lerp(vector.x, num6, t) * scale.x, (num8 > min.y) ? scale.y : 0f));
				}
				else if (flag2)
				{
					float value2 = ((vector.y > min.y) ? max.y : min.y);
					float t2 = Mathf.InverseLerp(vector.y, num8, value2);
					points.Add(new Vector2(Mathf.Lerp(vector.x, num6, t2) * scale.x, (vector.y > min.y) ? scale.y : 0f));
					points.Add(new Vector2(num6 * scale.x, Mathf.InverseLerp(min.y, max.y, num8) * scale.y));
				}
				if ((float)j == num)
				{
					line.SetColor(_outOfBoundsColour, 0, points.Count / 2 - 2);
				}
				if ((float)j == num2)
				{
					num3 = points.Count / 2 - 1;
				}
				vector = new Vector2(num6, num8);
				flag = flag2;
			}
			if (num3.HasValue)
			{
				line.SetColor(_outOfBoundsColour, num3.Value, points.Count / 2);
			}
		}

		private void RenderSecondaryLine(Vector2 min, Vector2 max, Vector2 size)
		{
			if (_secondaryCurve == null)
			{
				if (_secondaryVectorLine != null)
				{
					_secondaryVectorLine.points2.Clear();
				}
				if (_secondaryLabel != null)
				{
					_secondaryLabel.text = string.Empty;
				}
			}
			else
			{
				if (_secondaryVectorLine == null)
				{
					return;
				}
				List<Vector2> points = _secondaryVectorLine.points2;
				points.Clear();
				_secondaryVectorLine.color = _secondaryColour;
				float num = 1f;
				float num2 = 0f;
				if (_autoFitSecondaryCurve)
				{
					if (_secondaryCurve.length > 0)
					{
						Keyframe[] keys = _secondaryCurve.keys;
						for (int i = 0; i < keys.Length; i++)
						{
							Keyframe keyframe = keys[i];
							if (keyframe.value > num2)
							{
								num2 = keyframe.value;
							}
						}
						if (num2 <= 0.0001f)
						{
							num2 = 1f;
						}
					}
					else
					{
						num2 = 1f;
					}
					num = 1f / num2;
				}
				if (_secondaryLabel != null)
				{
					if (_autoFitSecondaryCurve)
					{
						_secondaryLabel.text = $"Max: {num2:0.00}";
						Vector2 anchoredPosition = CurveToPixel(new Vector2(1f, 1f));
						_secondaryLabel.rectTransform.anchoredPosition = anchoredPosition;
					}
					else
					{
						_secondaryLabel.text = string.Empty;
					}
				}
				Vector2 item = Vector2.zero;
				bool flag = true;
				Vector2 vector = size / _viewportScale;
				Vector2 viewportOffset = _viewportOffset;
				for (int j = 0; j < _divisions; j++)
				{
					float t = (float)j / (float)(_divisions - 1);
					float num3 = Mathf.Lerp(min.x, max.x, t);
					float num4 = _secondaryCurve.Evaluate(num3) * num;
					float x = num3 * vector.x - viewportOffset.x;
					float y = num4 * vector.y - viewportOffset.y;
					Vector2 vector2 = new Vector2(x, y);
					if (!flag)
					{
						points.Add(item);
						points.Add(vector2);
					}
					item = vector2;
					flag = false;
				}
			}
		}

		private void ScaleWindow(Vector2 mousePos, float scale)
		{
			Vector2 vector = (UnityEngine.Input.GetKey(KeyCode.LeftShift) ? new Vector2(1f, scale) : ((!UnityEngine.Input.GetKey(KeyCode.LeftControl)) ? new Vector2(scale, scale) : new Vector2(scale, 1f)));
			Vector2 vector2 = _viewportScale * vector;
			vector = vector2 / _viewportScale;
			_viewportOffset = (mousePos + _viewportOffset) / vector - mousePos;
			_viewportScale = vector2;
			UpdateLine();
		}

		private void SetKeyTime(string time)
		{
			if (float.TryParse(time, out var result) && GetSelected(out var k, out var index))
			{
				k.time = result;
				MoveKeyGooder(index, k);
				UpdateKeyHandles(k, index);
				UpdateKeys();
				UpdateLineOnly();
			}
		}

		private void SetKeyValue(string value)
		{
			if (float.TryParse(value, out var result) && GetSelected(out var k, out var index))
			{
				k.value = result;
				MoveKeyGooder(index, k);
				UpdateKeyHandles(k, index);
				UpdateKeys();
				UpdateLineOnly();
			}
		}

		private void SetLeftTangentWeighted(bool weighted)
		{
			if (!GetSelected(out var k, out var index))
			{
				return;
			}
			if (weighted)
			{
				if (k.weightedMode == WeightedMode.None)
				{
					k.weightedMode = WeightedMode.In;
				}
				else if (k.weightedMode == WeightedMode.Out)
				{
					k.weightedMode = WeightedMode.Both;
				}
			}
			else if (k.weightedMode == WeightedMode.Both)
			{
				k.weightedMode = WeightedMode.Out;
			}
			else if (k.weightedMode == WeightedMode.In)
			{
				k.weightedMode = WeightedMode.None;
			}
			_curve.MoveKey(index, k);
			UpdateKeyHandles(k, index);
			UpdateLineOnly();
		}

		private void SetRightTangentWeighted(bool weighted)
		{
			if (!GetSelected(out var k, out var index))
			{
				return;
			}
			if (weighted)
			{
				if (k.weightedMode == WeightedMode.None)
				{
					k.weightedMode = WeightedMode.Out;
				}
				else if (k.weightedMode == WeightedMode.In)
				{
					k.weightedMode = WeightedMode.Both;
				}
			}
			else if (k.weightedMode == WeightedMode.Both)
			{
				k.weightedMode = WeightedMode.In;
			}
			else if (k.weightedMode == WeightedMode.Out)
			{
				k.weightedMode = WeightedMode.None;
			}
			_curve.MoveKey(index, k);
			UpdateKeyHandles(k, index);
			UpdateLineOnly();
		}

		private void SetTangentsLinked(bool value)
		{
			if (GetSelected(out var k, out var index))
			{
				k.tangentMode = ((!value) ? 1 : 0);
				if (value)
				{
					float inTangent = (k.outTangent = (k.inTangent + k.outTangent) / 2f);
					k.inTangent = inTangent;
				}
				_curve.MoveKey(index, k);
				UpdateKeyHandles(k, index);
				UpdateLineOnly();
			}
		}

		private void SetWrapMode(string mode)
		{
			if (GetSelected(out var _, out var index) && Enum.TryParse<WrapMode>(mode.Replace("Clamp", "ClampForever"), out var result))
			{
				if (index == 0)
				{
					_curve.preWrapMode = result;
				}
				if (index == _curve.length - 1)
				{
					_curve.postWrapMode = result;
				}
				UpdateLineOnly();
			}
		}

		private void Start()
		{
			InputResponder inputResponder = new InputResponder("CurveEditor");
			_inputHandler = base.gameObject.AddComponent<InputHandlerScript>();
			_inputHandler.AddInputResponder(inputResponder);
			inputResponder.OnDrag = OnDrag;
			inputResponder.OnScroll = OnScroll;
			inputResponder.OnPointerClick = OnPointerClick;
			_tangentLinkedToggle.onValueChanged.AddListener(SetTangentsLinked);
			_weightedLeftToggle.onValueChanged.AddListener(SetLeftTangentWeighted);
			_weightedRightToggle.onValueChanged.AddListener(SetRightTangentWeighted);
			_timeInput.onEndEdit.AddListener(SetKeyTime);
			_valueInput.onEndEdit.AddListener(SetKeyValue);
			_recentreViewButton.onClick.AddListener(CentreViewport);
			_saveButton.onClick.AddListener(OnSave);
			_cancelButton.onClick.AddListener(OnCancel);
			_insertBeforeButton.onClick.AddListener(delegate
			{
				InsertKey(before: true);
			});
			_insertAfterButton.onClick.AddListener(delegate
			{
				InsertKey(before: false);
			});
			_deleteButton.onClick.AddListener(DeleteKey);
		}

		private void Update()
		{
			if (_vectorLine != null)
			{
				if (_visulisationTransform == null)
				{
					_visulisationTransform = GetComponent<RectTransform>();
				}
				if (_visulisationTransform.rect.size != _lastSize)
				{
					UpdateLine();
					_lastSize = _visulisationTransform.rect.size;
				}
				if (UnityEngine.Input.GetKeyDown(KeyCode.Delete))
				{
					DeleteKey();
				}
			}
		}

		private void UpdateKeyEditors()
		{
			if (GetSelected(out var k, out var index))
			{
				_handles.gameObject.SetActive(value: true);
				UpdateKeyHandles(k, index);
				_sidePanel.SetActive(value: true);
				_timeInput.SetTextWithoutNotify(k.time.ToString());
				_valueInput.SetTextWithoutNotify(k.value.ToString());
				_deleteButton.interactable = _curve.length > 2;
			}
			else
			{
				_handles.gameObject.SetActive(value: false);
				_sidePanel.SetActive(value: false);
			}
		}

		private void UpdateKeyHandles(Keyframe k, int index)
		{
			_handles.UpdateFrom(k, (index == 0) ? ((Keyframe?)null) : new Keyframe?(_curve.keys[index - 1]), (index == _curve.keys.Length - 1) ? ((Keyframe?)null) : new Keyframe?(_curve.keys[index + 1]), index);
		}

		private void UpdateKeys()
		{
			int i;
			for (i = 0; i < _curve.keys.Length && i < _keyScripts.Count; i++)
			{
				_keyScripts[i].UpdateFrom(_curve.keys[i], this);
				_keyScripts[i].gameObject.SetActive(value: true);
			}
			for (int j = i; j < _keyScripts.Count; j++)
			{
				_keyScripts[j].gameObject.SetActive(value: false);
			}
			for (; i < _curve.keys.Length; i++)
			{
				KeyScript item = CreateKeyScript(_curve.keys[i]);
				_keyScripts.Add(item);
			}
		}

		private void UpdateLineOnly()
		{
			if (_secondaryCurveGenerator != null)
			{
				_secondaryCurve = _secondaryCurveGenerator(_curve);
			}
			Vector2 size = _visulisationTransform.rect.size;
			Vector2 min = PixelToCurve(Vector2.zero);
			Vector2 max = PixelToCurve(size);
			RenderLine(_curve, min, max, size, _vectorLine);
			_vectorLine.Draw();
			if (_secondaryVectorLine != null)
			{
				RenderSecondaryLine(min, max, size);
				_secondaryVectorLine.Draw();
			}
		}

		private void ZoomWindow(float scrollDelta, Vector2 mousePos)
		{
			float scale = Mathf.Pow(1.25f, 0f - scrollDelta);
			ScaleWindow(mousePos, scale);
		}
	}
}
