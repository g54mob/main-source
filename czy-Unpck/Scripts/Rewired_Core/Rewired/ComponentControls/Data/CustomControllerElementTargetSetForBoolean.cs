using System;
using UnityEngine;

namespace Rewired.ComponentControls.Data
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public class CustomControllerElementTargetSetForBoolean : CustomControllerElementTargetSet
	{
		private const int uLakcOjZPvCXqSXGKrZNxUaSejL = 1;

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

		public CustomControllerElementTarget target => _target;

		internal override int targetCount => 1;

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
			int num = -433990964;
			goto IL_000d;
			IL_000d:
			switch (num ^ -433990963)
			{
			case 3:
				break;
			default:
				return;
			case 1:
				return;
			case 2:
				goto IL_0032;
			case 0:
				return;
			}
			goto IL_0008;
			IL_0032:
			_target.ClearElementCaches();
			num = -433990963;
			goto IL_000d;
		}
	}
}
