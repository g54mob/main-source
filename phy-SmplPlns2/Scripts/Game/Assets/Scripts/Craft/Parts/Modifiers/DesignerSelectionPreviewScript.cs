using Assets.Scripts.Design;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class DesignerSelectionPreviewScript : PartModifierScript
	{
		private DesignerSelectionPreviewData _data;

		private GameObject _myPreviewObject;

		private bool _selected;

		public void Initialize(DesignerSelectionPreviewData selectionPreview)
		{
			_data = selectionPreview;
			if (string.IsNullOrWhiteSpace(_data.PrefabPath) || base.LoadContext != CraftLoadContext.Designer)
			{
				Object.Destroy(this);
			}
		}

		protected virtual void OnDestroy()
		{
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				if (Designer.Instance != null)
				{
					Designer.Instance.SelectedPartChangedEvent -= OnSelectedPartChanged;
				}
				OnDeselectedInDesigner();
			}
		}

		protected virtual void Start()
		{
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				Designer.Instance.SelectedPartChangedEvent += OnSelectedPartChanged;
				OnSelectedPartChanged(Designer.Instance.SelectedPart);
			}
		}

		private void OnDeselectedInDesigner()
		{
			if (_myPreviewObject != null)
			{
				_myPreviewObject.SetActive(value: false);
			}
		}

		private void OnSelectedInDesigner()
		{
			if (_myPreviewObject != null)
			{
				_myPreviewObject.SetActive(value: true);
				_myPreviewObject.transform.SetParent(null);
				_myPreviewObject.transform.localScale = Vector3.one;
				_myPreviewObject.transform.SetParent(base.transform, worldPositionStays: true);
				_myPreviewObject.transform.localPosition = Vector3.zero;
				_myPreviewObject.transform.localRotation = Quaternion.Euler(_data.Rotation);
				_myPreviewObject.transform.position += base.transform.rotation * _data.Offset;
			}
			else
			{
				_myPreviewObject = Object.Instantiate(Resources.Load<GameObject>(_data.PrefabPath), base.transform, worldPositionStays: true);
				_myPreviewObject.transform.localPosition = Vector3.zero;
				_myPreviewObject.transform.localRotation = Quaternion.Euler(_data.Rotation);
				_myPreviewObject.transform.position += base.transform.rotation * _data.Offset;
			}
		}

		private void OnSelectedPartChanged(PartScript newPart)
		{
			bool flag = newPart == base.PartScript;
			if (flag != _selected)
			{
				_selected = flag;
				if (flag)
				{
					OnSelectedInDesigner();
				}
				else
				{
					OnDeselectedInDesigner();
				}
			}
		}
	}
}
