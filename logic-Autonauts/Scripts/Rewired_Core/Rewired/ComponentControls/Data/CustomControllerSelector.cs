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

		[CustomObfuscation(rename = false)]
		[FieldRange(0, int.MaxValue)]
		[SerializeField]
		[Tooltip("The source id of the Custom Controller. This is used to find the Custom Controller if Find Using Source Id is True.")]
		private int _sourceId;

		[CustomObfuscation(rename = false)]
		[Tooltip("If true, the Custom Controller will be found using the tag specified here. This can be used with Find in Player and/or Find Using Source Id to further refine the search parameters.")]
		[SerializeField]
		private bool _findUsingTag;

		[Tooltip("The tag on the Custom Controller you wish to use. This is used to find the Custom Controller.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
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
				if (_findUsingSourceId == value)
				{
					return;
				}
				while (true)
				{
					_findUsingSourceId = value;
					TzavSRkIcUdUXyGrWDQoLGzUgZXD();
					int num = 2022791180;
					while (true)
					{
						switch (num ^ 0x7891580C)
						{
						case 2:
							goto IL_000a;
						default:
							return;
						case 1:
							break;
						case 0:
							return;
						}
						break;
						IL_000a:
						num = 2022791181;
					}
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
				while (true)
				{
					switch (0x1E6CEFE5 ^ 0x1E6CEFE7)
					{
					case 0:
						continue;
					case 2:
						if (_sourceId == value)
						{
							return;
						}
						break;
					}
					break;
				}
				_sourceId = value;
				TzavSRkIcUdUXyGrWDQoLGzUgZXD();
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
					TzavSRkIcUdUXyGrWDQoLGzUgZXD();
					int num = -1942078554;
					while (true)
					{
						switch (num ^ -1942078554)
						{
						case 2:
							goto IL_000a;
						default:
							return;
						case 1:
							break;
						case 0:
							return;
						}
						break;
						IL_000a:
						num = -1942078553;
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
				if (_tag == value)
				{
					return;
				}
				while (true)
				{
					_tag = value;
					int num = 1126154460;
					while (true)
					{
						switch (num ^ 0x431FC0DC)
						{
						case 2:
							goto IL_000f;
						case 1:
							break;
						default:
							TzavSRkIcUdUXyGrWDQoLGzUgZXD();
							return;
						}
						break;
						IL_000f:
						num = 1126154461;
					}
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
					TzavSRkIcUdUXyGrWDQoLGzUgZXD();
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
					return;
				}
				while (true)
				{
					_playerId = value;
					int num = -1612802202;
					while (true)
					{
						switch (num ^ -1612802201)
						{
						case 0:
							goto IL_000a;
						case 2:
							break;
						default:
							TzavSRkIcUdUXyGrWDQoLGzUgZXD();
							return;
						}
						break;
						IL_000a:
						num = -1612802203;
					}
				}
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
				goto IL_0014;
			}
			goto IL_00d4;
			IL_00d4:
			int num = 0;
			int num2 = -538790503;
			goto IL_0019;
			IL_0014:
			num2 = -538790502;
			goto IL_0019;
			IL_0019:
			Rewired.CustomController customController = default(Rewired.CustomController);
			while (true)
			{
				switch (num2 ^ -538790500)
				{
				case 0:
					break;
				case 4:
					if (findInPlayer)
					{
						goto IL_004d;
					}
					goto case 1;
				case 1:
					return customController;
				case 3:
					if (!findUsingTag)
					{
						goto case 4;
					}
					goto IL_0087;
				case 6:
					goto IL_00a4;
				case 2:
					customController = ReInput.controllers.CustomControllers[num];
					if (!findUsingSourceId)
					{
						goto case 3;
					}
					goto IL_00f9;
				default:
					if (num >= ReInput.controllers.customControllerCount)
					{
						return null;
					}
					goto case 2;
				}
				break;
				IL_00f9:
				if (customController.sourceControllerId == sourceId)
				{
					num2 = -538790497;
					continue;
				}
				goto IL_0074;
				IL_0074:
				num++;
				num2 = -538790503;
				continue;
				IL_0087:
				if (!(customController.tag != tag))
				{
					num2 = -538790504;
					continue;
				}
				goto IL_0074;
				IL_004d:
				if (ReInput.controllers.IsControllerAssignedToPlayer(customController.type, customController.id, playerId))
				{
					num2 = -538790499;
					continue;
				}
				goto IL_0074;
			}
			goto IL_0014;
			IL_00a4:
			Player player = ReInput.players.GetPlayer(playerId);
			if (player == null)
			{
				Logger.LogError("Invalid playerId " + playerId);
				return null;
			}
			goto IL_00d4;
		}

		private void TzavSRkIcUdUXyGrWDQoLGzUgZXD()
		{
		}
	}
}
