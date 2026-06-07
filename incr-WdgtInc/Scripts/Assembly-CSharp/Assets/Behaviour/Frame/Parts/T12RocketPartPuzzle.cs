using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T12RocketPartPuzzle : MonoBehaviour
	{
		[SerializeField]
		private Rect _boxRect;

		[SerializeField]
		private float _minY;

		[SerializeField]
		private float _maxY;

		[SerializeField]
		private SpriteRenderer _hider;

		private ActiveWorldFrame _parent;

		private bool _mouseDown;

		private bool _resetting;

		private float _craftTimer;

		private void Start()
		{
			_parent = GetComponentInParent<ActiveWorldFrame>();
		}

		private void Update()
		{
			if (_craftTimer > 0f)
			{
				_craftTimer -= Time.deltaTime;
				if (_craftTimer <= 0f)
				{
					_hider.gameObject.SetActive(value: false);
				}
				return;
			}
			if (_mouseDown)
			{
				_mouseDown = false;
			}
			else
			{
				float num = Mathf.Clamp(base.transform.localPosition.y + Time.deltaTime * 2f, _minY, _maxY);
				base.transform.localPosition = new Vector3(0f, num, 0.5f);
				if (num == _maxY)
				{
					_resetting = false;
				}
			}
			if (base.transform.localPosition.y != _minY)
			{
				return;
			}
			T7FuelRodItem t7FuelRodItem = null;
			T7FuelRodItem t7FuelRodItem2 = null;
			Collider2D[] array = Physics2D.OverlapBoxAll(_boxRect.position, _boxRect.size, 0f);
			for (int i = 0; i < array.Length; i++)
			{
				T7FuelRodItem component = array[i].GetComponent<T7FuelRodItem>();
				if ((bool)component && component.Contained.Identifier == "omega_project_casing")
				{
					t7FuelRodItem = component;
				}
				else if ((bool)component && component.Contained.Identifier == "omega_project_shielding")
				{
					t7FuelRodItem2 = component;
				}
			}
			if (!t7FuelRodItem)
			{
				_parent.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "@T12RocketPartCasing");
				_resetting = true;
				return;
			}
			if (!t7FuelRodItem2)
			{
				_parent.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "@T12RocketPartShielding");
				_resetting = true;
				return;
			}
			UISounds.CraftStep();
			_hider.gameObject.SetActive(value: true);
			_craftTimer = 2f;
			Object.Destroy(t7FuelRodItem.gameObject);
			Object.Destroy(t7FuelRodItem2.gameObject);
			_parent.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
			_resetting = true;
		}

		private void OnMouseDrag()
		{
			if (!_resetting)
			{
				_mouseDown = true;
				float value = PlayerControls.MouseWorld.y + 1.155f - base.transform.parent.position.y;
				base.transform.localPosition = new Vector3(0f, Mathf.Clamp(value, _minY, _maxY), 0.5f);
			}
		}

		private void OnDrawGizmos()
		{
			Gizmos.DrawWireCube(_boxRect.position, _boxRect.size);
		}
	}
}
