using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;

namespace Kitchen.Modules
{
	public class IconSetElement : Element
	{
		[SerializeField]
		private IconElement Template;

		[SerializeField]
		private Vector2 Direction;

		[SerializeField]
		private float Padding;

		private Bounds _BoundingBox;

		private readonly List<IconElement> Icons = new List<IconElement>();

		public override Bounds BoundingBox => _BoundingBox;

		public void Clear()
		{
			foreach (IconElement icon in Icons)
			{
				icon.Destroy();
			}
			Icons.Clear();
			_BoundingBox = default(Bounds);
		}

		public void Add(string icon, string description)
		{
			IconElement iconElement = Object.Instantiate(Template, Vector3.zero, Quaternion.identity, base.transform);
			iconElement.transform.localRotation = Quaternion.identity;
			iconElement.gameObject.layer = base.gameObject.layer;
			iconElement.Set(icon, description);
			Vector3 zero = Vector3.zero;
			if (BoundingBox.size.sqrMagnitude > 0.01f)
			{
				zero += BoundingBox.center + new Vector3(BoundingBox.extents.x * Direction.x, BoundingBox.extents.y * Direction.y, 0f);
				zero += ((zero.sqrMagnitude > 0f) ? (zero.normalized * Padding) : Vector3.zero);
				zero += new Vector3(iconElement.BoundingBox.extents.x * Direction.x, iconElement.BoundingBox.extents.y * Direction.y, 0f);
			}
			iconElement.transform.localPosition = zero;
			if (Icons.IsNullOrEmpty())
			{
				_BoundingBox = iconElement.BoundingBox;
			}
			Icons.Add(iconElement);
			_BoundingBox.Encapsulate(iconElement.BoundingBox);
		}

		public void Centre()
		{
			Vector3 center = _BoundingBox.center;
			foreach (IconElement icon in Icons)
			{
				icon.transform.localPosition -= center;
			}
		}
	}
}
