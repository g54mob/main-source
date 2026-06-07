using System;
using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Engine.UI.Base
{
	[Serializable]
	public class UIContainer
	{
		public const bool DEFAULT_DISABLE_CANVAS = true;

		public const bool DEFAULT_DISABLE_GAME_OBJECT = true;

		public const bool DEFAULT_DISABLE_GRAPHIC_RAYCASTER = true;

		public const bool DEFAULT_ENABLED = true;

		public Canvas Canvas;

		public CanvasGroup CanvasGroup;

		public bool DisableCanvas;

		public bool DisableGameObject;

		public bool DisableGraphicRaycaster;

		public bool Enabled;

		public GraphicRaycaster GraphicRaycaster;

		public RectTransform RectTransform;

		public float StartAlpha;

		public Vector3 StartPosition;

		public Vector3 StartRotation;

		public Vector3 StartScale;

		public virtual void Disable()
		{
		}

		public virtual void Enable()
		{
		}

		public void FullScreen(bool resetScaleToOne)
		{
		}

		public virtual void Init()
		{
		}

		public virtual void Reset()
		{
		}

		public virtual void ResetAlpha()
		{
		}

		public virtual void ResetPosition()
		{
		}

		public virtual void ResetRotation()
		{
		}

		public virtual void ResetScale()
		{
		}

		public virtual void ResetToStartValues()
		{
		}

		public virtual void UpdateStartAlpha()
		{
		}

		public virtual void UpdateStartPosition()
		{
		}

		public virtual void UpdateStartRotation()
		{
		}

		public virtual void UpdateStartScale()
		{
		}

		public virtual void UpdateStartValues()
		{
		}
	}
}
