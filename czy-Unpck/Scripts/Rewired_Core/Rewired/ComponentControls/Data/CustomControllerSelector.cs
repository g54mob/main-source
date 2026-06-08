using System;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using UnityEngine;

namespace Rewired.ComponentControls.Data
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public sealed class CustomControllerSelector
	{
		[SerializeField]
		[Tooltip("If true, the Custom Controller will be searched for by its source controller id. This can be used with Find in Player and/or Find Using Tag to further refine the search parameters.")]
		[CustomObfuscation(rename = false)]
		private bool _findUsingSourceId = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The source id of the Custom Controller. This is used to find the Custom Controller if Find Using Source Id is True.")]
		[FieldRange(0, int.MaxValue)]
		private int _sourceId;

		[SerializeField]
		[Tooltip("If true, the Custom Controller will be found using the tag specified here. This can be used with Find in Player and/or Find Using Source Id to further refine the search parameters.")]
		[CustomObfuscation(rename = false)]
		private bool _findUsingTag;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The tag on the Custom Controller you wish to use. This is used to find the Custom Controller.")]
		private string _tag;

		[CustomObfuscation(rename = false)]
		[Tooltip("If true, the Custom Controller will be searched for in the Player specified in the Player Id field. This can be used with Find Using Source Id and/or Find Using Tag to further refine the search parameters.")]
		[SerializeField]
		private bool _findInPlayer;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The Player Id of the Player that owns the Custom Controller.")]
		private int _playerId;

		public bool findUsingSourceId
		{
			get
			{
				return _findUsingSourceId;
			}
			set
			{
				if (_findUsingSourceId != value)
				{
					_findUsingSourceId = value;
					wWklIWMVIReShFCdZhfAVVyDQgX();
				}
			}
		}

		public int sourceId
		{
			get
			{
				return _sourceId;
			}
			set
			{
				value = MathTools.Max(0, value);
				if (_sourceId == value)
				{
					while (true)
					{
						switch (-853663765 ^ -853663767)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				_sourceId = value;
				wWklIWMVIReShFCdZhfAVVyDQgX();
			}
		}

		public bool findUsingTag
		{
			get
			{
				return _findUsingTag;
			}
			set
			{
				if (_findUsingTag != value)
				{
					_findUsingTag = value;
					wWklIWMVIReShFCdZhfAVVyDQgX();
				}
			}
		}

		public string tag
		{
			get
			{
				return _tag;
			}
			set
			{
				if (!(_tag == value))
				{
					_tag = value;
					wWklIWMVIReShFCdZhfAVVyDQgX();
				}
			}
		}

		public bool findInPlayer
		{
			get
			{
				return _findInPlayer;
			}
			set
			{
				if (_findInPlayer != value)
				{
					_findInPlayer = value;
					wWklIWMVIReShFCdZhfAVVyDQgX();
				}
			}
		}

		public int playerId
		{
			get
			{
				return _playerId;
			}
			set
			{
				if (_playerId == value)
				{
					while (true)
					{
						switch (0x68CEFC61 ^ 0x68CEFC63)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				_playerId = value;
				wWklIWMVIReShFCdZhfAVVyDQgX();
			}
		}

		internal Rewired.CustomController GetCustomController()
		{
			if (!ReInput.isReady)
			{
				goto IL_0007;
			}
			int num;
			if (findInPlayer)
			{
				num = 348715926;
				goto IL_000c;
			}
			goto IL_00cc;
			IL_000c:
			Rewired.CustomController customController = default(Rewired.CustomController);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x14C8FB94)
				{
				case 8:
					break;
				case 4:
					return null;
				case 2:
					goto IL_0059;
				case 10:
					goto IL_0091;
				case 3:
					goto IL_00ad;
				case 7:
					return null;
				case 1:
					goto IL_00d8;
				case 0:
					if (findInPlayer)
					{
						goto IL_0100;
					}
					goto case 9;
				case 9:
					return customController;
				case 6:
					customController = ReInput.controllers.CustomControllers[num2];
					num = 348715925;
					continue;
				default:
					if (num2 >= ReInput.controllers.customControllerCount)
					{
						return null;
					}
					goto case 6;
				}
				break;
				IL_0100:
				if (ReInput.controllers.IsControllerAssignedToPlayer(customController.type, customController.id, playerId))
				{
					num = 348715933;
					continue;
				}
				goto IL_012a;
				IL_0059:
				Player player = ReInput.players.GetPlayer(playerId);
				if (player == null)
				{
					Logger.LogError("Invalid playerId " + playerId);
					num = 348715923;
					continue;
				}
				goto IL_00cc;
				IL_00d8:
				if (!findUsingSourceId)
				{
					goto IL_0091;
				}
				if (customController.sourceControllerId == sourceId)
				{
					num = 348715934;
					continue;
				}
				goto IL_012a;
				IL_012a:
				num2++;
				num = 348715921;
				continue;
				IL_0091:
				int num3;
				if (findUsingTag)
				{
					num = 348715927;
					num3 = num;
				}
				else
				{
					num = 348715924;
					num3 = num;
				}
				continue;
				IL_00ad:
				if (!(customController.tag != tag))
				{
					num = 348715924;
					continue;
				}
				goto IL_012a;
			}
			goto IL_0007;
			IL_00cc:
			num2 = 0;
			num = 348715921;
			goto IL_000c;
			IL_0007:
			num = 348715920;
			goto IL_000c;
		}

		private void wWklIWMVIReShFCdZhfAVVyDQgX()
		{
		}
	}
}
