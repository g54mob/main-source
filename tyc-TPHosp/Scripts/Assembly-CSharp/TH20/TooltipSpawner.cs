using System;
using JetBrains.Annotations;
using TH20.UI;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class TooltipSpawner : MonoBehaviour
	{
		[SerializeField]
		private float _hoverTime = 0.5f;

		[SerializeField]
		private GameObject _prefab;

		[SerializeField]
		private string _tooltipText;

		[SerializeField]
		private LocalisedString _tooltipLocalisedString;

		[SerializeField]
		private bool _anchorToMouse = true;

		[SerializeField]
		private Vector3 _anchorOffset;

		[SerializeField]
		private Transform _anchorObject;

		[Tooltip("Used for tooltips on 3D objects")]
		[SerializeField]
		private Collider _collider;

		private float _cursorTime;

		private GameObject _instance;

		private Tooltip _tooltip;

		private Action<Tooltip> _dataProvider;

		private Func<bool> _shouldShowFunc;

		public float HoverTime
		{
			get
			{
				return _hoverTime;
			}
			set
			{
				_hoverTime = value;
			}
		}

		public string TooltipText
		{
			get
			{
				return _tooltipText;
			}
			set
			{
				_tooltipText = value;
			}
		}

		public string TooltipLocText
		{
			get
			{
				if (_tooltipLocalisedString.Term == null)
				{
					return "";
				}
				return _tooltipLocalisedString.Translation;
			}
		}

		public string TooltipTerm
		{
			get
			{
				return _tooltipLocalisedString.Term;
			}
			set
			{
				_tooltipLocalisedString.Term = value;
			}
		}

		public bool AnchorToMouse
		{
			get
			{
				return _anchorToMouse;
			}
			set
			{
				_anchorToMouse = value;
			}
		}

		public Vector3 AnchorOffset
		{
			get
			{
				return _anchorOffset;
			}
			set
			{
				_anchorOffset = value;
			}
		}

		public GameObject Prefab
		{
			get
			{
				return _prefab;
			}
			set
			{
				_prefab = value;
			}
		}

		private void Awake()
		{
			TooltipManager.Instance.Register(this);
		}

		public void SetDataProvider(Action<Tooltip> dataProvider)
		{
			_dataProvider = dataProvider;
		}

		public void SetShouldShowFunc(Func<bool> shouldShow)
		{
			_shouldShowFunc = shouldShow;
		}

		private void OnDestroy()
		{
			Hide();
			if (TooltipManager.Instance != null)
			{
				TooltipManager.Instance.Unregister(this);
			}
		}

		public void CursorOver(Transform root, Vector3 mousePosition)
		{
			_cursorTime = Mathf.Min(_cursorTime + Time.unscaledDeltaTime, _hoverTime);
			if (!(_cursorTime >= _hoverTime) || (_shouldShowFunc != null && !_shouldShowFunc()))
			{
				return;
			}
			if (_instance == null)
			{
				_instance = UnityEngine.Object.Instantiate(_prefab);
				_instance.transform.SetParent(root, worldPositionStays: false);
				_instance.transform.SetAsLastSibling();
				GameObjectUtils.SetActive(_instance, isActive: false);
				_tooltip = _instance.GetComponent<Tooltip>();
				string text = "";
				if (_tooltipLocalisedString.Term != null && !string.IsNullOrEmpty(_tooltipLocalisedString.Term))
				{
					text = _tooltipLocalisedString.Translation;
				}
				if (text.IsNullOrEmpty() && !_tooltipText.IsNullOrEmpty())
				{
					text = _tooltipText;
				}
				_tooltip.Text = text;
				if (_dataProvider == null && string.IsNullOrEmpty(_tooltip.Text))
				{
					Hide();
				}
			}
			if (_tooltip != null && _dataProvider != null)
			{
				_dataProvider.InvokeSafe(_tooltip);
				if (string.IsNullOrEmpty(_tooltip.Text))
				{
					Hide();
				}
			}
			if (_instance != null)
			{
				if (_anchorToMouse)
				{
					_instance.transform.position = mousePosition + _anchorOffset;
				}
				else if (_anchorObject == null)
				{
					_instance.transform.position = base.gameObject.transform.position + _anchorOffset;
				}
				else
				{
					_instance.transform.position = _anchorObject.position + _anchorOffset;
				}
				ValidatePositionForScreenDimensions();
				GameObjectUtils.SetActive(_instance, isActive: true);
			}
		}

		public void ValidatePositionForScreenDimensions()
		{
			Vector3 position = _instance.transform.position;
			RectTransform component = _instance.GetComponent<RectTransform>();
			Vector2 pivot = component.pivot;
			Rect screenSpaceRect = component.GetScreenSpaceRect();
			float num = screenSpaceRect.width * pivot.x;
			float num2 = screenSpaceRect.width * (1f - pivot.x);
			float num3 = screenSpaceRect.height * (1f - pivot.y);
			float num4 = screenSpaceRect.height * pivot.y;
			if (num > 0f && position.x < num)
			{
				position.x = num;
			}
			if (num2 > 0f && position.x > (float)Screen.width - num2)
			{
				position.x = (float)Screen.width - num2;
			}
			if (num4 > 0f && position.y < num4)
			{
				position.y = num4;
			}
			if (num3 > 0f && position.y > (float)Screen.height - num3)
			{
				position.y = (float)Screen.height - num3;
			}
			_instance.transform.position = position;
		}

		public void CursorOut()
		{
			if (_cursorTime > 0f)
			{
				_cursorTime = 0f;
				Hide();
			}
		}

		private void Hide()
		{
			if (_instance != null)
			{
				_tooltip.Close();
				_instance = null;
				_tooltip = null;
			}
		}

		public bool RayCast(Ray ray, float rayLength, out float distance)
		{
			if (base.enabled && _collider != null && _collider.Raycast(ray, out var hitInfo, rayLength))
			{
				distance = hitInfo.distance;
				return true;
			}
			distance = 0f;
			return false;
		}
	}
}
