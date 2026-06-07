using System;
using UnityEngine;

namespace Rewired.Glyphs.UnityUI
{
	[AddComponentMenu("Rewired/Glyphs/Unity UI/Unity UI Player Controller Element Glyph")]
	public class UnityUIPlayerControllerElementGlyph : UnityUIPlayerControllerElementGlyphBase
	{
		[SerializeField]
		[Tooltip("The Player id.")]
		private int _playerId;

		[SerializeField]
		[Tooltip("The Action name.")]
		private string _actionName;

		[Tooltip("The second Action name for 2D Actions. (Optional)")]
		[SerializeField]
		private string _actionName2;

		[NonSerialized]
		private int _actionId;

		[NonSerialized]
		private bool _actionIdCached;

		[NonSerialized]
		private int _actionId2;

		[NonSerialized]
		private bool _actionId2Cached;

		public override int playerId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public override int actionId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public override int actionId2
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public string actionName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string actionName2
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void CacheActionId()
		{
		}

		private void CacheActionId2()
		{
		}
	}
}
