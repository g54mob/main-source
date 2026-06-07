using System;
using CTS.Core;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;

namespace CTS
{
	public struct MessageData
	{
		public Guid Id;

		public Sprite Icon;

		public LocalizedString Title;

		public LocalizedString Subtitle;

		public LocalizedString Description;

		public UnityEvent EndEvent;

		public StringKey DisplayMode;
	}
}
