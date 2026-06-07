using System;
using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Engine.Themes
{
	[AddComponentMenu("Doozy/Themes/Targets/Sprite Target Selectable", 13)]
	[DefaultExecutionOrder(-100)]
	public class SpriteTargetSelectable : ThemeTarget
	{
		public Guid HighlightedSpritePropertyId;

		public Guid PressedSpritePropertyId;

		public Guid SelectedSpritePropertyId;

		public Guid DisabledSpritePropertyId;

		public Selectable Selectable;

		[SerializeField]
		private byte[] HighlightedPropertyIdSerializedGuid;

		[SerializeField]
		private byte[] PressedPropertyIdSerializedGuid;

		[SerializeField]
		private byte[] SelectedPropertyIdSerializedGuid;

		[SerializeField]
		private byte[] DisabledPropertyIdSerializedGuid;

		protected override void OnValidate()
		{
		}

		public override void OnBeforeSerialize()
		{
		}

		public override void OnAfterDeserialize()
		{
		}

		public override void UpdateTarget(ThemeData theme)
		{
		}

		private void Reset()
		{
		}

		private void UpdateReference()
		{
		}
	}
}
