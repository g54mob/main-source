using System;
using UnityEngine;

namespace Rewired.ComponentControls.Data
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public class CustomControllerElementTargetSetForFloat : CustomControllerElementTargetSet
	{
		[Tooltip("Splits the value into positive and negative sides which can be assigned to different Custom Controller elements.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[Tooltip("The positive target element. This is unused if Split Value is not enabled.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
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
						break;
					case 1:
						return _negativeTarget;
					default:
						throw new IndexOutOfRangeException();
					}
				}
				else
				{
					while (true)
					{
						IL_005b:
						int num = -1036388278;
						while (true)
						{
							switch (num ^ -1036388274)
							{
							case 3:
								num = -1036388273;
								continue;
							case 1:
								break;
							case 2:
								goto IL_005b;
							case 4:
								goto IL_0064;
							default:
								return _target;
							}
							break;
							IL_0064:
							if (index == 0)
							{
								num = -1036388274;
								continue;
							}
							throw new IndexOutOfRangeException();
						}
						break;
					}
				}
				return _positiveTarget;
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
			while (true)
			{
				int num = -1368830986;
				while (true)
				{
					switch (num ^ -1368830985)
					{
					case 3:
						break;
					case 1:
						_splitValue = true;
						num = -1368830987;
						continue;
					case 2:
						_positiveTarget = positiveTarget;
						num = -1368830985;
						continue;
					default:
						_negativeTarget = negativeTarget;
						return;
					}
					break;
				}
			}
		}

		internal override void ClearElementCaches()
		{
			if (_target == null)
			{
				return;
			}
			while (true)
			{
				_target.ClearElementCaches();
				int num = 1347601174;
				while (true)
				{
					switch (num ^ 0x5052C317)
					{
					case 0:
						goto IL_0009;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_0009:
					num = 1347601173;
				}
			}
		}
	}
}
