using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T9AICoreNode : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _node;

		[SerializeField]
		private LineRenderer _line;

		[SerializeField]
		private Color _successColor;

		[SerializeField]
		private Color _failColor;

		private T9AICorePuzzle _parent;

		private bool _mouseDown;

		public T9AICoreNode NextNode { get; private set; }

		public T9AICoreNode PrevNode { get; private set; }

		private void Awake()
		{
			_parent = GetComponentInParent<T9AICorePuzzle>();
		}

		private void Update()
		{
			if (_parent.ActiveNode == this)
			{
				Vector2 mouseWorld = PlayerControls.MouseWorld;
				_line.SetPosition(1, new Vector3(mouseWorld.x - _line.transform.position.x, mouseWorld.y - _line.transform.position.y, 0f));
			}
		}

		public void LinkNodeTo(T9AICoreNode node)
		{
			NextNode = node;
			node.PrevNode = this;
			_line.SetPosition(1, node.transform.position - _line.transform.position);
			_node.color = _successColor;
			_line.startColor = _successColor;
			_line.endColor = _successColor;
		}

		public void PuzzleSolved()
		{
			_node.color = _successColor;
			ClearActive();
		}

		public void PuzzleFailed()
		{
			_node.color = _failColor;
			_line.startColor = _failColor;
			_line.endColor = _failColor;
		}

		public void ClearActive()
		{
			_line.gameObject.SetActive(value: false);
		}

		private void OnMouseDown()
		{
			if (!_parent.ActiveNode)
			{
				_mouseDown = true;
			}
		}

		private void OnMouseExit()
		{
			if (_mouseDown)
			{
				_startClick();
			}
		}

		private void OnMouseUpAsButton()
		{
			_startClick();
		}

		private void _startClick()
		{
			_mouseDown = false;
			_parent.NodeClicked(this);
			_line.gameObject.SetActive(value: true);
		}
	}
}
