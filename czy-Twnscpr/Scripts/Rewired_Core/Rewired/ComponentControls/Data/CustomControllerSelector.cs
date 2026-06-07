using System;
using UnityEngine;

namespace Rewired.ComponentControls.Data
{
	[Serializable]
	[CustomClassObfuscation]
	public sealed class CustomControllerSelector
	{
		[SerializeField]
		[CustomObfuscation]
		private bool _findUsingSourceId;

		[CustomObfuscation]
		[SerializeField]
		private int _sourceId;

		[SerializeField]
		[CustomObfuscation]
		private bool _findUsingTag;

		[CustomObfuscation]
		[SerializeField]
		private string _tag;

		[SerializeField]
		[CustomObfuscation]
		private bool _findInPlayer;

		[CustomObfuscation]
		[SerializeField]
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

		private void DDSYIBWFCFbxtAeyTbUKilaTRGQv()
		{
		}
	}
}
