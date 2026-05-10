using System;
using Data.Objects;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Player.GameplayInput.ButtonsActions
{
	public abstract class ButtonActionData : SerializedScriptableObject
	{
		[SerializeField]
		private SerializedObjectDescriptor m_objectDescriptor;

		private SerializedObjectDescriptor xbq => null;

		public bjl xbr => null;

		[CanBeNull]
		public bjm xbs => null;

		public string xbt => null;

		public string xbu => null;

		[CanBeNull]
		public bjo xbv => null;

		public abstract Enum xbw { get; }

		public abstract Enum xbx { get; }

		public bool xby => false;
	}
}
