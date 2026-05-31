using Assets.Source.UI;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T8QuantumWidgetGem : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _renderer;

		[SerializeField]
		private LineRenderer _line;

		[SerializeField]
		private Sprite[] _sprites;

		private T8QuantumWidgetPuzzle _parent;

		private bool _mouseDown;

		public T8QuantumWidgetGem ConnectedTo { get; private set; }

		public int GemType { get; private set; }

		public bool Locked { get; private set; }

		public bool Selected => _parent.ActiveGem == this;

		private void Awake()
		{
			_parent = GetComponentInParent<T8QuantumWidgetPuzzle>();
		}

		public void SetGemType(int idx, Color c)
		{
			GemType = idx;
			_renderer.sprite = _sprites[idx];
			_renderer.color = c;
			_line.startColor = c;
			_line.endColor = c;
			Locked = false;
			_line.gameObject.SetActive(value: false);
		}

		private void Update()
		{
			if (Locked)
			{
				return;
			}
			if (Selected)
			{
				Vector2 mouseWorld = PlayerControls.MouseWorld;
				_line.SetPosition(1, new Vector3(mouseWorld.x - _line.transform.position.x, mouseWorld.y - _line.transform.position.y, 0f));
				_line.gameObject.SetActive(value: true);
				if (PlayerControls.InteractRelease)
				{
					T8QuantumWidgetGem t8QuantumWidgetGem = UIHelper.GetMouseOverGameObject()?.GetComponent<T8QuantumWidgetGem>();
					if ((bool)t8QuantumWidgetGem && t8QuantumWidgetGem != this)
					{
						_parent.FinalizePuzzle(t8QuantumWidgetGem);
					}
				}
				else if (PlayerControls.InputCancel)
				{
					_parent.DeactivateGem();
				}
			}
			else
			{
				_line.gameObject.SetActive(value: false);
			}
		}

		private void OnMouseDown()
		{
			if (!Locked)
			{
				_mouseDown = true;
			}
		}

		private void OnMouseUpAsButton()
		{
			if (!Locked)
			{
				_mouseDown = false;
				_parent.GemSelected(this);
			}
		}

		private void OnMouseExit()
		{
			if (_mouseDown)
			{
				_mouseDown = false;
				_parent.GemSelected(this);
			}
		}

		public void ConnectTo(T8QuantumWidgetGem other)
		{
			Locked = true;
			other.Locked = true;
			other._line.SetPosition(1, new Vector3(base.transform.position.x - other._line.transform.position.x, base.transform.position.y - other._line.transform.position.y, 0f));
		}
	}
}
