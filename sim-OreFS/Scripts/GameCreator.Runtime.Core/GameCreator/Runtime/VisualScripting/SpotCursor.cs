using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Cursor")]
	[Image(typeof(IconCursor), ColorTheme.Type.Yellow)]
	[Category("UI/Cursor")]
	[Description("Changes the cursor image when hovering the Hotspot")]
	public class SpotCursor : Spot
	{
		[SerializeField]
		protected PropertyGetTexture m_Texture = new PropertyGetTexture();

		[SerializeField]
		protected PropertyGetPosition m_Origin = GetPositionVector2.Create();

		public override string Title => $"Change Cursor to {m_Texture}";

		[field: NonSerialized]
		private bool IsPointerHovering { get; set; }

		public override void OnPointerEnter(Hotspot hotspot)
		{
			base.OnPointerEnter(hotspot);
			IsPointerHovering = true;
			RefreshCursor(hotspot.IsActive && IsPointerHovering, hotspot.Args);
		}

		public override void OnPointerExit(Hotspot hotspot)
		{
			base.OnPointerExit(hotspot);
			IsPointerHovering = false;
			RefreshCursor(hotspot.IsActive && IsPointerHovering, hotspot.Args);
		}

		public override void OnDisable(Hotspot hotspot)
		{
			base.OnDisable(hotspot);
			if (hotspot.IsActive && IsPointerHovering)
			{
				RefreshCursor(customCursor: false, hotspot.Args);
			}
			IsPointerHovering = false;
		}

		private void RefreshCursor(bool customCursor, Args args)
		{
			if (customCursor)
			{
				Texture2D texture = m_Texture.Get(args) as Texture2D;
				Vector3 vector = m_Origin.Get(args).XY();
				Cursor.SetCursor(texture, vector, CursorMode.Auto);
			}
			else
			{
				Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
			}
		}
	}
}
