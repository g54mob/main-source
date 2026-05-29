using System.Collections.Generic;
using Assets.Source.Item;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T7FuelRodItem : MonoBehaviour
	{
		[SerializeField]
		private SpringJoint2D _springPrefab;

		[SerializeField]
		private string _itemName;

		private SpringJoint2D _activeSpring;

		private bool _pickedUp;

		public ItemType Contained { get; private set; }

		private void Start()
		{
			if (!string.IsNullOrEmpty(_itemName))
			{
				SetItem(_itemName);
			}
		}

		private void Update()
		{
			if (PlayerControls.InteractRelease)
			{
				_pickedUp = false;
				if ((bool)_activeSpring)
				{
					Object.Destroy(_activeSpring.gameObject);
				}
			}
		}

		private void FixedUpdate()
		{
			if (_pickedUp)
			{
				float a = Vector2.Distance(_activeSpring.transform.position, base.transform.position);
				_activeSpring.distance = Mathf.Min(a, 0.5f);
				_activeSpring.attachedRigidbody.MovePosition(PlayerControls.MouseWorld);
			}
		}

		public void DetachAndStop()
		{
			base.enabled = false;
			if ((bool)_activeSpring)
			{
				Object.Destroy(_activeSpring.gameObject);
			}
		}

		private void OnMouseDown()
		{
			_pickedUp = true;
			_activeSpring = Object.Instantiate(_springPrefab);
			_activeSpring.connectedBody = GetComponent<Rigidbody2D>();
			_activeSpring.attachedRigidbody.MovePosition(PlayerControls.MouseWorld);
		}

		public void SetItem(ItemType type)
		{
			Contained = type;
			SpriteRenderer component = GetComponent<SpriteRenderer>();
			if ((bool)component)
			{
				component.sprite = type.Icon;
			}
			PolygonCollider2D component2 = GetComponent<PolygonCollider2D>();
			if ((bool)component2)
			{
				List<Vector2> list = new List<Vector2>();
				type.Icon.GetPhysicsShape(0, list);
				for (int i = 0; i < list.Count; i++)
				{
					list[i] = new Vector2(list[i].x * 0.8f, list[i].y * 0.8f);
				}
				component2.points = list.ToArray();
			}
		}
	}
}
