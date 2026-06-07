using System;
using UnityEngine;

namespace Rewired.ComponentControls.Data
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public class CustomControllerElementTargetSetForFloat : CustomControllerElementTargetSet
	{
		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Splits the value into positive and negative sides which can be assigned to different Custom Controller elements.")]
		private bool _splitValue;

		[CustomObfuscation(rename = false)]
		[Tooltip("The target element. This is unused if Split Value is enabled.")]
		[SerializeField]
		private CustomControllerElementTarget _target = new CustomControllerElementTarget(new CustomControllerElementSelector
		{
			elementType = CustomControllerElementSelector.ElementType.Axis
		})
		{
			valueRange = CustomControllerElementTarget.ValueRange.Full
		};

		[Tooltip("The positive target element. This is unused if Split Value is not enabled.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTarget _positiveTarget = new CustomControllerElementTarget(new CustomControllerElementSelector
		{
			elementType = CustomControllerElementSelector.ElementType.Button
		})
		{
			valueRange = CustomControllerElementTarget.ValueRange.Positive,
			valueContribution = Pole.Positive
		};

		[Tooltip("The negative target element. This is unused if Split Value is not enabled.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private CustomControllerElementTarget _negativeTarget = new CustomControllerElementTarget(new CustomControllerElementSelector
		{
			elementType = CustomControllerElementSelector.ElementType.Button
		})
		{
			valueRange = CustomControllerElementTarget.ValueRange.Negative,
			valueContribution = Pole.Positive
		};

		public bool splitValue
		{
			get
			{
				return _splitValue;
			}
			set
			{
				_splitValue = value;
			}
		}

		public CustomControllerElementTarget target
		{
			get
			{
				return _target;
			}
		}

		public CustomControllerElementTarget positiveTarget
		{
			get
			{
				return _positiveTarget;
			}
		}

		public CustomControllerElementTarget negativeTarget
		{
			get
			{
				return _negativeTarget;
			}
		}

		internal override int targetCount
		{
			get
			{
				if (!_splitValue)
				{
					return 1;
				}
				return 2;
			}
		}

		internal override CustomControllerElementTarget this[int index]
		{
			get
			{
				if (_splitValue)
				{
					switch (index)
					{
					case 0:
						goto IL_004b;
					case 1:
						return _negativeTarget;
					}
					goto IL_0018;
				}
				goto IL_003e;
				IL_003e:
				int num;
				if (index == 0)
				{
					num = 972524885;
					goto IL_001d;
				}
				throw new IndexOutOfRangeException();
				IL_004b:
				return _positiveTarget;
				IL_0018:
				num = 972524883;
				goto IL_001d;
				IL_001d:
				switch (num ^ 0x39F78D57)
				{
				case 0:
					break;
				case 1:
					goto IL_003e;
				case 3:
					goto IL_004b;
				case 4:
					throw new IndexOutOfRangeException();
				default:
					return _target;
				}
				goto IL_0018;
			}
		}

		internal CustomControllerElementTargetSetForFloat()
		{
		}

		internal CustomControllerElementTargetSetForFloat(CustomControllerElementTarget target)
		{
			_splitValue = false;
			_target = target;
		}

		internal CustomControllerElementTargetSetForFloat(CustomControllerElementTarget positiveTarget, CustomControllerElementTarget negativeTarget)
		{
			_splitValue = true;
			_positiveTarget = positiveTarget;
			_negativeTarget = negativeTarget;
		}

		internal override void ClearElementCaches()
		{
			if (_target == null)
			{
				while (true)
				{
					switch (0x2F1A5266 ^ 0x2F1A5267)
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
