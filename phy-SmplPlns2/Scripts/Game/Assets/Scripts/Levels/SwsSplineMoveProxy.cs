using DG.Tweening;
using SWS;
using UnityEngine;

namespace Assets.Scripts.Levels
{
	public class SwsSplineMoveProxy : splineMove
	{
		[SerializeField]
		private Transform _targetObject;

		protected override void CreateTween()
		{
			base.CreateTween();
			tween.OnUpdate(OnUpdate);
			OnUpdate();
		}

		private void OnUpdate()
		{
			if (_targetObject != null)
			{
				_targetObject.SetPositionAndRotation(Utility.ConvertAbsoluteToFloatingOriginPosition(base.transform.position), base.transform.rotation);
			}
		}
	}
}
