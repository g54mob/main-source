using Assets.Scripts.Vizzy.UI.Elements;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Vizzy.UI
{
	public class ContextMenuScript : MonoBehaviour
	{
		private CanvasGroup _canvasGroup;

		private BlockElementScript _currentBlock;

		private IVizzyUI _vizzyUI;

		public BlockElementScript CurrentBlock
		{
			get
			{
				return _currentBlock;
			}
			set
			{
				_currentBlock = value;
				if (_currentBlock != null && _currentBlock.SupportsClone)
				{
					_canvasGroup.alpha = 1f;
					base.gameObject.SetActive(value: true);
					base.transform.position = _currentBlock.transform.position;
					base.transform.SetAsLastSibling();
					base.transform.localScale = new Vector3(0f, 1f, 1f);
					DOTween.To(() => base.transform.localScale.x, delegate(float x)
					{
						base.transform.localScale = new Vector3(x, 1f, 1f);
					}, 1f, 0.15f).SetEase(Ease.InOutSine);
				}
				else
				{
					base.gameObject.SetActive(value: false);
				}
			}
		}

		public void Initialize(IVizzyUI vizzyUI)
		{
			_vizzyUI = vizzyUI;
			base.transform.SetParent(vizzyUI.ProgramTransform);
		}

		public void OnBeginDrag(ContextMenuButtonScript contextMenuButton, PointerEventData eventData)
		{
			_currentBlock.StartClone(eventData, contextMenuButton.CloneChain);
			_canvasGroup.alpha = 0f;
		}

		public void OnDrag(ContextMenuButtonScript contextMenuButton, PointerEventData eventData)
		{
			((IDragHandler)_currentBlock).OnDrag(eventData);
		}

		public void OnEndDrag(ContextMenuButtonScript contextMenuButton, PointerEventData eventData)
		{
			((IEndDragHandler)_currentBlock).OnEndDrag(eventData);
			CurrentBlock = null;
			_vizzyUI.SelectedElement = null;
		}

		protected virtual void Awake()
		{
			_canvasGroup = GetComponent<CanvasGroup>();
		}

		protected virtual void Update()
		{
			if (_currentBlock != null)
			{
				base.transform.position = _currentBlock.transform.position;
			}
		}
	}
}
