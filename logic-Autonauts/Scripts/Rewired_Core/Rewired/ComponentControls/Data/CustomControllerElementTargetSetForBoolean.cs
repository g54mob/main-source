using System;
using UnityEngine;

namespace Rewired.ComponentControls.Data
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public class CustomControllerElementTargetSetForBoolean : CustomControllerElementTargetSet
	{
		private const int LMcTEXPxyfZsppKpHYJGjeSVGlq = 1;

		[Tooltip("The target element.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
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
				goto IL_0008;
			}
			goto IL_0032;
			IL_0008:
			int num = -1140204103;
			goto IL_000d;
			IL_000d:
			switch (num ^ -1140204102)
			{
			case 0:
				break;
			default:
				return;
			case 3:
				return;
			case 2:
				goto IL_0032;
			case 1:
				return;
			}
			goto IL_0008;
			IL_0032:
			_target.ClearElementCaches();
			num = -1140204101;
			goto IL_000d;
		}
	}
}
