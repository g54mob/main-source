using CTS.Core;
using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	public class CanvasIsOpenCondition : MonoCondition
	{
		public enum EValid
		{
			Open = 0,
			Close = 1
		}

		[SerializeField]
		private StringKey _canvasKey;

		[SerializeField]
		private EValid _condition;

		public override bool IsConditionValid()
		{
			if (!MonoSingleton<CanvasGroupManager>.TryGetInstance(out var outInstance))
			{
				return true;
			}
			if (!outInstance.TryGet(_canvasKey, out var controller))
			{
				return true;
			}
			if (_condition == EValid.Close)
			{
				return !controller.IsShown;
			}
			return controller.IsShown;
		}
	}
}
