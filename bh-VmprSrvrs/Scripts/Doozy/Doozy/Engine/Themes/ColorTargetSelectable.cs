using System;
using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Engine.Themes
{
	[AddComponentMenu("Doozy/Themes/Targets/Color Target Selectable", 13)]
	[DefaultExecutionOrder(-100)]
	public class ColorTargetSelectable : ThemeTarget
	{
		public Guid NormalColorPropertyId;

		public Guid HighlightedColorPropertyId;

		public Guid PressedColorPropertyId;

		public Guid SelectedColorPropertyId;

		public Guid DisabledColorPropertyId;

		public Selectable Selectable;

		[SerializeField]
		private byte[] NormalPropertyIdSerializedGuid;

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
