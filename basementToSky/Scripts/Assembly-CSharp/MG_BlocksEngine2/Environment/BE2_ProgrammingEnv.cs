using System.Collections.Generic;
using MG_BlocksEngine2.Block;
using MG_BlocksEngine2.DragDrop;
using MG_BlocksEngine2.UI;
using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.Environment
{
	public class BE2_ProgrammingEnv : MonoBehaviour, I_BE2_ProgrammingEnv
	{
		private Transform _transform;

		private RectTransform _rectTransform;

		public BE2_TargetObject targetObject;

		[SerializeField]
		private bool _visible = true;

		private CanvasGroup _parentCanvasGroup;

		private GraphicRaycaster _parentGraphicRaycaster;

		public Transform Transform
		{
			get
			{
				if (!_transform)
				{
					return base.transform;
				}
				return _transform;
			}
		}

		public List<I_BE2_Block> BlocksList { get; set; }

		public I_BE2_TargetObject TargetObject => targetObject;

		public bool Visible
		{
			get
			{
				return _visible;
			}
			set
			{
				_visible = value;
				if (base.gameObject.scene.name != null && (bool)_parentCanvasGroup)
				{
					if (value)
					{
						_parentCanvasGroup.alpha = 1f;
						_parentCanvasGroup.blocksRaycasts = true;
					}
					else
					{
						_parentCanvasGroup.alpha = 0f;
						_parentCanvasGroup.blocksRaycasts = false;
					}
				}
			}
		}

		private void OnValidate()
		{
			_parentCanvasGroup = GetComponentInParent<CanvasGroup>();
			Visible = _visible;
		}

		private void Awake()
		{
			if ((bool)targetObject)
			{
				targetObject.ProgrammingEnv = this;
			}
			_transform = base.transform;
			_rectTransform = GetComponent<RectTransform>();
			UpdateBlocksList();
			_parentCanvasGroup = GetComponentInParent<CanvasGroup>();
			_parentGraphicRaycaster = _parentCanvasGroup.GetComponent<GraphicRaycaster>();
		}

		private void Start()
		{
			BE2_DragDropManager.Instance.Raycaster.AddRaycaster(_parentGraphicRaycaster);
		}

		public void UpdateBlocksList()
		{
			BlocksList = new List<I_BE2_Block>();
			foreach (Transform item in Transform)
			{
				if (item.gameObject.activeSelf)
				{
					I_BE2_Block component = item.GetComponent<I_BE2_Block>();
					if (component != null)
					{
						BlocksList.Add(component);
					}
				}
			}
		}

		public void OpenContextMenu()
		{
			BE2_UI_ContextMenuManager.instance.OpenContextMenu(1, this);
		}

		public void ClearBlocks()
		{
			BlocksList = new List<I_BE2_Block>();
			foreach (Transform item in Transform)
			{
				if (item.gameObject.activeSelf)
				{
					I_BE2_Block component = item.GetComponent<I_BE2_Block>();
					if (component != null)
					{
						Object.Destroy(component.Transform.gameObject);
					}
				}
			}
			UpdateBlocksList();
		}
	}
}
