using EasyTextEffects.Editor.MyBoxCopy.Attributes;
using UnityEngine;

namespace WorldEnvironment
{
	public class TransformDriver : MonoBehaviour
	{
		[SerializeField]
		private bool _drivePos;

		[SerializeField]
		private bool _driveRot;

		[SerializeField]
		private bool _driveScale;

		[Space(5f)]
		[SerializeField]
		private float MinValue;

		[SerializeField]
		private float MaxValue;

		[Space(5f)]
		[SerializeField]
		private bool _revert;

		[Space(5f)]
		[ConditionalField(new string[] { "_drivePos" })]
		[SerializeField]
		private Vector3 _minPos;

		[ConditionalField(new string[] { "_drivePos" })]
		[SerializeField]
		private Vector3 _maxPos;

		[Space(5f)]
		[ConditionalField(new string[] { "_driveRot" })]
		[SerializeField]
		private Vector3 _minRot;

		[ConditionalField(new string[] { "_driveRot" })]
		[SerializeField]
		private Vector3 _maxRot;

		[Space(5f)]
		[ConditionalField(new string[] { "_driveScale" })]
		[SerializeField]
		private Vector3 _minLocalScale;

		[ConditionalField(new string[] { "_driveScale" })]
		[SerializeField]
		private Vector3 _maxLocalScale;

		public void Drive(float value)
		{
			float num = Mathf.InverseLerp(MinValue, MaxValue, value);
			if (_revert)
			{
				num = 1f - num;
			}
			if (_drivePos)
			{
				base.transform.localPosition = Vector3.Lerp(_minPos, _maxPos, num);
			}
			if (_driveRot)
			{
				base.transform.localRotation = Quaternion.Lerp(Quaternion.Euler(_minRot), Quaternion.Euler(_maxRot), num);
			}
			if (_driveScale)
			{
				base.transform.localScale = Vector3.Lerp(_minLocalScale, _maxLocalScale, num);
			}
		}
	}
}
