using UnityEngine;

namespace Minigames.Core
{
	public class ScrewFastener : MonoBehaviour, IFastener
	{
		public enum ScrewType
		{
			Flathead = 1,
			Phillips = 2,
			TriWing = 3,
			Square = 4
		}

		[SerializeField]
		private RectTransform _transform;

		[SerializeField]
		private ScrewType _screwType = ScrewType.Phillips;

		public RectTransform Transform => _transform;

		public int Slots => (int)_screwType;

		public float SlotAngle => 180f / (float)Slots;

		public ScrewType Type => _screwType;

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
