using System;
using UnityEngine;

namespace Rewired.ComponentControls.Data
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public class CustomControllerElementTargetSetForBoolean : CustomControllerElementTargetSet
	{
		private const int uVsAYCfNkncUEREajiGYIwQRjgb = 1;

		[Tooltip("The target element.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTarget _target = new CustomControllerElementTarget(new CustomControllerElementSelector
		{
			elementType = CustomControllerElementSelector.ElementType.Button
		})
		{
			valueRange = CustomControllerElementTarget.ValueRange.Positive,
			valueContribution = Pole.Positive
		};

		public CustomControllerElementTarget target
		{
			get
			{
				return _target;
			}
		}

		internal override int targetCount
		{
			get
			{
				return 1;
			}
		}

		internal override CustomControllerElementTarget this[int index]
		{
			get
			{
				if (index == 0)
				{
					return _target;
				}
				throw new IndexOutOfRangeException();
			}
		}

		internal CustomControllerElementTargetSetForBoolean()
		{
		}

		internal CustomControllerElementTargetSetForBoolean(CustomControllerElementTarget target)
		{
			_target = target;
		}

		internal override void ClearElementCaches()
		{
			if (_target == null)
			{
				while (true)
				{
					switch (0x1326D2FF ^ 0x1326D2FE)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			_target.ClearElementCaches();
		}
	}
}
