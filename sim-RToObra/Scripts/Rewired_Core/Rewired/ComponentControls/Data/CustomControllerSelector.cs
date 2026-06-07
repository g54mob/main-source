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
		[CustomObfuscation(rename = false)]
		[Tooltip("If true, the Custom Controller will be searched for by its source controller id. This can be used with Find in Player and/or Find Using Tag to further refine the search parameters.")]
		private bool _findUsingSourceId = true;

		[CustomObfuscation(rename = false)]
		[Tooltip("The source id of the Custom Controller. This is used to find the Custom Controller if Find Using Source Id is True.")]
		[SerializeField]
		[FieldRange(0, int.MaxValue)]
		private int _sourceId;

		[Tooltip("If true, the Custom Controller will be found using the tag specified here. This can be used with Find in Player and/or Find Using Source Id to further refine the search parameters.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _findUsingTag;

		[SerializeField]
		[Tooltip("The tag on the Custom Controller you wish to use. This is used to find the Custom Controller.")]
		[CustomObfuscation(rename = false)]
		private string _tag;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If true, the Custom Controller will be searched for in the Player specified in the Player Id field. This can be used with Find Using Source Id and/or Find Using Tag to further refine the search parameters.")]
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
					wQiEPKGVkSYAiCZoyTUamohUIKKd();
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
				if (_sourceId != value)
				{
					_sourceId = value;
					wQiEPKGVkSYAiCZoyTUamohUIKKd();
				}
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
				if (_findUsingTag == value)
				{
					return;
				}
				while (true)
				{
					_findUsingTag = value;
					wQiEPKGVkSYAiCZoyTUamohUIKKd();
					int num = 1186740723;
					while (true)
					{
						switch (num ^ 0x46BC39F2)
						{
						case 0:
							goto IL_000a;
						default:
							return;
						case 2:
							break;
						case 1:
							return;
						}
						break;
						IL_000a:
						num = 1186740720;
					}
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
					wQiEPKGVkSYAiCZoyTUamohUIKKd();
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
					wQiEPKGVkSYAiCZoyTUamohUIKKd();
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
						switch (-672781472 ^ -672781471)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				_playerId = value;
				wQiEPKGVkSYAiCZoyTUamohUIKKd();
			}
		}

		internal Rewired.CustomController GetCustomController()
		{
			if (!ReInput.isReady)
			{
				return null;
			}
			if (findInPlayer)
			{
				Player player = ReInput.players.GetPlayer(playerId);
				if (player == null)
				{
					Logger.LogError("Invalid playerId " + playerId);
					return null;
				}
			}
			int num = 0;
			Rewired.CustomController customController = default(Rewired.CustomController);
			while (true)
			{
				int num2;
				int num3;
				if (num < ReInput.controllers.customControllerCount)
				{
					num2 = -376013485;
					num3 = num2;
				}
				else
				{
					num2 = -376013483;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -376013483)
					{
					case 2:
						num2 = -376013485;
						continue;
					case 1:
						break;
					case 3:
					{
						int num5;
						if (findUsingSourceId)
						{
							num2 = -376013488;
							num5 = num2;
						}
						else
						{
							num2 = -376013486;
							num5 = num2;
						}
						continue;
					}
					case 5:
						if (customController.sourceControllerId == sourceId)
						{
							num2 = -376013486;
							continue;
						}
						goto IL_0120;
					case 9:
						if (!(customController.tag != tag))
						{
							num2 = -376013487;
							continue;
						}
						goto IL_0120;
					case 4:
						if (!findInPlayer)
						{
							goto case 8;
						}
						if (ReInput.controllers.IsControllerAssignedToPlayer(customController.type, customController.id, playerId))
						{
							num2 = -376013475;
							continue;
						}
						goto IL_0120;
					case 8:
						return customController;
					case 6:
						customController = ReInput.controllers.CustomControllers[num];
						num2 = -376013482;
						continue;
					case 7:
					{
						int num4;
						if (!findUsingTag)
						{
							num2 = -376013487;
							num4 = num2;
						}
						else
						{
							num2 = -376013476;
							num4 = num2;
						}
						continue;
					}
					default:
						{
							return null;
						}
						IL_0120:
						num++;
						num2 = -376013484;
						continue;
					}
					break;
				}
			}
		}

		private void wQiEPKGVkSYAiCZoyTUamohUIKKd()
		{
		}
	}
}
