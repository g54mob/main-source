using System;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
	public record NoticeParam
	{
		[CompilerGenerated]
		protected virtual Type EqualityContract
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
		}

		public eMessageId noticeId;

		public string title;

		public Sprite noticeIcon;

		public UnityAction onclickAction;

		public Func<bool> pushTiming;

		public Func<bool> forceDeleteTiming;

		public double timer;

		public bool checkDuplicate;

		public bool isPushDestory;

		public NoticeParam(string title, Sprite noticeIcon = null, UnityAction onclickAction = null, Func<bool> pushTiming = null, Func<bool> forceDeleteTiming = null, double timer = 0.0, bool checkDuplicate = false, bool isPushDestory = true)
		{
		}

		public NoticeParam(eMessageId id, Sprite noticeIcon = null, UnityAction onclickAction = null, Func<bool> pushTiming = null, Func<bool> forceDeleteTiming = null, double timer = 0.0, bool checkDuplicate = false, bool isPushDestory = true)
		{
		}

		[CompilerGenerated]
		public override string ToString()
		{
			return null;
		}

		[CompilerGenerated]
		protected virtual bool PrintMembers(StringBuilder builder)
		{
			return false;
		}

		[CompilerGenerated]
		public virtual bool Equals(NoticeParam? other)
		{
			return false;
		}

		[CompilerGenerated]
		protected NoticeParam(NoticeParam original)
		{
		}
	}
}
