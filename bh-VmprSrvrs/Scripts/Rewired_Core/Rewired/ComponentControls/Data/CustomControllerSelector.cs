using System;
using Rewired.Utils.Attributes;
using UnityEngine;

namespace Rewired.ComponentControls.Data
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public sealed class CustomControllerSelector
	{
		[Tooltip("If true, the Custom Controller will be searched for by its source controller id. This can be used with Find in Player and/or Find Using Tag to further refine the search parameters.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _findUsingSourceId;

		[Tooltip("The source id of the Custom Controller. This is used to find the Custom Controller if Find Using Source Id is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0, 2147483647)]
		private int _sourceId;

		[Tooltip("If true, the Custom Controller will be found using the tag specified here. This can be used with Find in Player and/or Find Using Source Id to further refine the search parameters.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _findUsingTag;

		[Tooltip("The tag on the Custom Controller you wish to use. This is used to find the Custom Controller.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _tag;

		[Tooltip("If true, the Custom Controller will be searched for in the Player specified in the Player Id field. This can be used with Find Using Source Id and/or Find Using Tag to further refine the search parameters.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _findInPlayer;

		[Tooltip("The Player Id of the Player that owns the Custom Controller.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _playerId;

		public bool findUsingSourceId
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int sourceId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool findUsingTag
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public string tag
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool findInPlayer
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int playerId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		internal Rewired.CustomController GetCustomController()
		{
			return null;
		}

		private void QuOFkZkIIqyRxGBRglDJoVNnmIilA()
		{
		}
	}
}
