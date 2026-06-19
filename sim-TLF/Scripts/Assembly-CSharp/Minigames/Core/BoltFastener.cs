using UnityEngine;

namespace Minigames.Core
{
	public class BoltFastener : MonoBehaviour, IFastener
	{
		[SerializeField]
		private RectTransform _transform;

		[SerializeField]
		private int _sides = 6;

		public RectTransform Transform => _transform;

		public int Slots => _sides;

		public float SlotAngle => 360f / (float)_sides;

		public bool IsAlignedWith(ITool tool, float initialOffset, float tolerance)
		{
			float z = tool.Transform.localEulerAngles.z;
			float t = Mathf.DeltaAngle(_transform.localEulerAngles.z, z) - initialOffset;
			float slotAngle = SlotAngle;
			float num = Mathf.Repeat(t, slotAngle);
			if (num > slotAngle / 2f)
			{
				num = slotAngle - num;
			}
			return num <= tolerance;
		}

		public void Rotate(float angleDelta)
		{
			float z = _transform.localEulerAngles.z;
			_transform.localRotation = Quaternion.Euler(0f, 0f, z + angleDelta);
		}

		public float GetCurrentRotation()
		{
			return _transform.localEulerAngles.z;
		}
	}
}
