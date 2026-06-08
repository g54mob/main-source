using System;
using UnityEngine;

namespace Rewired.ComponentControls.Data
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public class CustomControllerElementTargetSetForFloat : CustomControllerElementTargetSet
	{
		[Tooltip("Splits the value into positive and negative sides which can be assigned to different Custom Controller elements.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _splitValue;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The target element. This is unused if Split Value is enabled.")]
		private CustomControllerElementTarget _target = new CustomControllerElementTarget(new CustomControllerElementSelector
		{
			elementType = CustomControllerElementSelector.ElementType.Axis
		})
		{
			valueRange = CustomControllerElementTarget.ValueRange.Full
		};

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The positive target element. This is unused if Split Value is not enabled.")]
		private CustomControllerElementTarget _positiveTarget = new CustomControllerElementTarget(new CustomControllerElementSelector
		{
			elementType = CustomControllerElementSelector.ElementType.Button
		})
		{
			valueRange = CustomControllerElementTarget.ValueRange.Positive,
			valueContribution = Pole.Positive
		};

		[Tooltip("The negative target element. This is unused if Split Value is not enabled.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		public CustomControllerElementTarget target => _target;

		public CustomControllerElementTarget positiveTarget => _positiveTarget;

		public CustomControllerElementTarget negativeTarget => _negativeTarget;

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
					default:
						while (true)
						{
							switch (-1607227179 ^ -1607227180)
							{
							case 2:
								break;
							case 0:
								goto end_IL_0018;
							case 1:
								throw new IndexOutOfRangeException();
							default:
								goto end_IL_000b;
							}
							continue;
							end_IL_0018:
							break;
						}
						goto case 0;
					case 0:
						return _positiveTarget;
					case 1:
						{
							return _negativeTarget;
						}
						end_IL_000b:
						break;
					}
				}
				if (index == 0)
				{
					return _target;
				}
				throw new IndexOutOfRangeException();
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
			if (_target != null)
			{
				_target.ClearElementCaches();
			}
		}
	}
}
