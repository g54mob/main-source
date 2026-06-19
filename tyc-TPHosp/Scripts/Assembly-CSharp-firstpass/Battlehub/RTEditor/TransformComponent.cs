using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Battlehub.RTEditor
{
	public class TransformComponent : MonoBehaviour
	{
		public Toggle EnableDisableToggle;

		public GameObject TransformComponentUI;

		public InputField PositionX;

		public InputField PositionY;

		public InputField PositionZ;

		public InputField RotationX;

		public InputField RotationY;

		public InputField RotationZ;

		public InputField ScaleX;

		public InputField ScaleY;

		public InputField ScaleZ;

		public Button Reset;

		private Transform[] m_transforms;

		private HashSet<GameObject> m_selectedGameObjects = new HashSet<GameObject>();

		private bool m_handleTransformChange = true;

		private void Awake()
		{
			RuntimeSelection.SelectionChanged += OnRuntimeSelectionChanged;
		}

		private void OnDestroy()
		{
			RuntimeSelection.SelectionChanged -= OnRuntimeSelectionChanged;
		}

		private void OnEnable()
		{
			ExposeToEditor.TransformChanged += OnTransformChanged;
			PositionX.onValueChanged.AddListener(OnPositionXChanged);
			PositionY.onValueChanged.AddListener(OnPositionYChanged);
			PositionZ.onValueChanged.AddListener(OnPositionZChanged);
			RotationX.onValueChanged.AddListener(OnRotationXChanged);
			RotationY.onValueChanged.AddListener(OnRotationYChanged);
			RotationZ.onValueChanged.AddListener(OnRotationZChanged);
			ScaleX.onValueChanged.AddListener(OnScaleXChanged);
			ScaleY.onValueChanged.AddListener(OnScaleYChanged);
			ScaleZ.onValueChanged.AddListener(OnScaleZChanged);
			PositionX.onEndEdit.AddListener(OnEndEdit);
			PositionY.onEndEdit.AddListener(OnEndEdit);
			PositionZ.onEndEdit.AddListener(OnEndEdit);
			RotationX.onEndEdit.AddListener(OnEndEdit);
			RotationY.onEndEdit.AddListener(OnEndEdit);
			RotationZ.onEndEdit.AddListener(OnEndEdit);
			ScaleX.onEndEdit.AddListener(OnEndEdit);
			ScaleY.onEndEdit.AddListener(OnEndEdit);
			ScaleZ.onEndEdit.AddListener(OnEndEdit);
			Reset.onClick.AddListener(OnResetClick);
			EnableDisableToggle.onValueChanged.AddListener(OnEnableDisableValueChanged);
			OnRuntimeSelectionChanged(null);
		}

		private void OnDisable()
		{
			ExposeToEditor.TransformChanged -= OnTransformChanged;
			PositionX.onValueChanged.RemoveListener(OnPositionXChanged);
			PositionY.onValueChanged.RemoveListener(OnPositionYChanged);
			PositionZ.onValueChanged.RemoveListener(OnPositionZChanged);
			RotationX.onValueChanged.RemoveListener(OnRotationXChanged);
			RotationY.onValueChanged.RemoveListener(OnRotationYChanged);
			RotationZ.onValueChanged.RemoveListener(OnRotationZChanged);
			ScaleX.onValueChanged.RemoveListener(OnScaleXChanged);
			ScaleY.onValueChanged.RemoveListener(OnScaleYChanged);
			ScaleZ.onValueChanged.RemoveListener(OnScaleZChanged);
			PositionX.onEndEdit.RemoveListener(OnEndEdit);
			PositionY.onEndEdit.RemoveListener(OnEndEdit);
			PositionZ.onEndEdit.RemoveListener(OnEndEdit);
			RotationX.onEndEdit.RemoveListener(OnEndEdit);
			RotationY.onEndEdit.RemoveListener(OnEndEdit);
			RotationZ.onEndEdit.RemoveListener(OnEndEdit);
			ScaleX.onEndEdit.RemoveListener(OnEndEdit);
			ScaleY.onEndEdit.RemoveListener(OnEndEdit);
			ScaleZ.onEndEdit.RemoveListener(OnEndEdit);
			Reset.onClick.RemoveListener(OnResetClick);
			EnableDisableToggle.onValueChanged.RemoveListener(OnEnableDisableValueChanged);
		}

		private void HandlePositionChanged()
		{
			if (m_handleTransformChange && m_transforms != null && m_transforms.Length != 0 && float.TryParse(PositionX.text, out var result) && float.TryParse(PositionY.text, out var result2) && float.TryParse(PositionZ.text, out var result3))
			{
				for (int i = 0; i < m_transforms.Length; i++)
				{
					m_transforms[i].position = new Vector3(result, result2, result3);
				}
			}
		}

		private void HandleRotationChanged()
		{
			if (m_handleTransformChange && m_transforms != null && m_transforms.Length != 0 && float.TryParse(RotationX.text, out var result) && float.TryParse(RotationY.text, out var result2) && float.TryParse(RotationZ.text, out var result3))
			{
				for (int i = 0; i < m_transforms.Length; i++)
				{
					m_transforms[i].rotation = Quaternion.Euler(result, result2, result3);
				}
			}
		}

		private void HandleScaleChanged()
		{
			if (m_handleTransformChange && m_transforms != null && m_transforms.Length != 0 && float.TryParse(ScaleX.text, out var result) && float.TryParse(ScaleY.text, out var result2) && float.TryParse(ScaleZ.text, out var result3))
			{
				for (int i = 0; i < m_transforms.Length; i++)
				{
					m_transforms[i].localScale = new Vector3(result, result2, result3);
				}
			}
		}

		private void EndEditField(InputField field)
		{
			if (!float.TryParse(field.text, out var _))
			{
				field.text = "0";
			}
		}

		private void OnEndEdit(string value)
		{
			EndEditField(PositionX);
			EndEditField(PositionY);
			EndEditField(PositionZ);
			EndEditField(RotationX);
			EndEditField(RotationY);
			EndEditField(RotationZ);
			EndEditField(ScaleX);
			EndEditField(ScaleY);
			EndEditField(ScaleZ);
		}

		private void OnPositionXChanged(string value)
		{
			HandlePositionChanged();
		}

		private void OnPositionYChanged(string value)
		{
			HandlePositionChanged();
		}

		private void OnPositionZChanged(string value)
		{
			HandlePositionChanged();
		}

		private void OnRotationXChanged(string value)
		{
			HandleRotationChanged();
		}

		private void OnRotationYChanged(string value)
		{
			HandleRotationChanged();
		}

		private void OnRotationZChanged(string value)
		{
			HandleRotationChanged();
		}

		private void OnScaleXChanged(string value)
		{
			HandleScaleChanged();
		}

		private void OnScaleYChanged(string value)
		{
			HandleScaleChanged();
		}

		private void OnScaleZChanged(string value)
		{
			HandleScaleChanged();
		}

		private void OnTransformChanged(ExposeToEditor obj)
		{
			if (m_selectedGameObjects.Contains(obj.gameObject))
			{
				m_handleTransformChange = false;
				UpdateAllFields();
				m_handleTransformChange = true;
			}
		}

		private void OnRuntimeSelectionChanged(Object[] unselected)
		{
			GameObject[] gameObjects = RuntimeSelection.gameObjects;
			if (gameObjects == null)
			{
				m_selectedGameObjects.Clear();
				EnableDisableToggle.gameObject.SetActive(value: false);
				TransformComponentUI.gameObject.SetActive(value: false);
				m_transforms = null;
				return;
			}
			m_selectedGameObjects.Clear();
			m_transforms = (from g in gameObjects
				where g.GetComponent<ExposeToEditor>()
				select g.GetComponent<Transform>() into t
				where t.GetType() == typeof(Transform)
				select t).ToArray();
			for (int num = 0; num < m_transforms.Length; num++)
			{
				m_selectedGameObjects.Add(m_transforms[num].gameObject);
			}
			if (m_transforms.Length != 0)
			{
				EnableDisableToggle.gameObject.SetActive(value: true);
				TransformComponentUI.gameObject.SetActive(value: true);
				m_handleTransformChange = false;
				UpdateAllFields();
				m_handleTransformChange = true;
			}
			else
			{
				EnableDisableToggle.gameObject.SetActive(value: false);
				TransformComponentUI.gameObject.SetActive(value: false);
			}
		}

		private void UpdateAllFields()
		{
			IEnumerable<float> values = m_transforms.Select((Transform t) => t.position.x);
			IEnumerable<float> values2 = m_transforms.Select((Transform t) => t.position.y);
			IEnumerable<float> values3 = m_transforms.Select((Transform t) => t.position.z);
			IEnumerable<float> values4 = m_transforms.Select((Transform t) => t.rotation.eulerAngles.x);
			IEnumerable<float> values5 = m_transforms.Select((Transform t) => t.rotation.eulerAngles.y);
			IEnumerable<float> values6 = m_transforms.Select((Transform t) => t.rotation.eulerAngles.z);
			IEnumerable<float> values7 = m_transforms.Select((Transform t) => t.localScale.x);
			IEnumerable<float> values8 = m_transforms.Select((Transform t) => t.localScale.y);
			IEnumerable<float> values9 = m_transforms.Select((Transform t) => t.localScale.z);
			SetFieldValue(PositionX, values);
			SetFieldValue(PositionY, values2);
			SetFieldValue(PositionZ, values3);
			SetFieldValue(RotationX, values4);
			SetFieldValue(RotationY, values5);
			SetFieldValue(RotationZ, values6);
			SetFieldValue(ScaleX, values7);
			SetFieldValue(ScaleY, values8);
			SetFieldValue(ScaleZ, values9);
			EnableDisableToggle.isOn = m_transforms.All((Transform t) => t.gameObject.activeSelf);
		}

		private void SetFieldValue(InputField field, IEnumerable<float> values)
		{
			if (values.Any((float p) => p != values.First()))
			{
				field.text = string.Empty;
			}
			else
			{
				field.text = values.First().ToString();
			}
		}

		private void OnResetClick()
		{
			float num = 0f;
			float num2 = 1f;
			PositionX.text = num.ToString();
			PositionY.text = num.ToString();
			PositionZ.text = num.ToString();
			RotationX.text = num.ToString();
			RotationY.text = num.ToString();
			RotationZ.text = num.ToString();
			ScaleX.text = num2.ToString();
			ScaleY.text = num2.ToString();
			ScaleZ.text = num2.ToString();
		}

		private void OnEnableDisableValueChanged(bool value)
		{
			for (int i = 0; i < m_transforms.Length; i++)
			{
				m_transforms[i].gameObject.SetActive(value);
			}
		}
	}
}
