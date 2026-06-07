using System;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[RequireComponent(typeof(RectTransform))]
	[DisallowMultipleComponent]
	public abstract class TouchControl : CustomControllerControl
	{
		private Canvas _canvas;

		private RectTransform __rectTransform;

		internal TouchController sXDUEouJAqCiibpvIluvhcZgetzN => aIdRCmPaDeGXwbkKhErvDnPFSYEkb() as TouchController;

		internal Canvas uupfWdcRYmQCktvgNQvwZsMtFvqy => _canvas;

		internal RectTransform vCJGjqsSTOYxIOmvZHZOSVVpifrv
		{
			get
			{
				Canvas canvas = uupfWdcRYmQCktvgNQvwZsMtFvqy;
				if (canvas == null)
				{
					return null;
				}
				return canvas.transform as RectTransform;
			}
		}

		internal RectTransform SeqvEgllFcYfioUgpBOnFeaUImqGA => __rectTransform ?? (__rectTransform = GetComponent<RectTransform>());

		bool CustomControllerControl.fWzcsqpjMiHugIFEsnxLnuyMnmGF => aIdRCmPaDeGXwbkKhErvDnPFSYEkb() as TouchController != null;

		[CustomObfuscation(rename = false)]
		internal TouchControl()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				iTLxuQvBCpqTflSXVaMLGIjEeYQQ(true, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnCanvasGroupChanged()
		{
			base.OnCanvasGroupChanged();
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				iTLxuQvBCpqTflSXVaMLGIjEeYQQ(false, true);
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnTransformParentChanged()
		{
			base.OnTransformParentChanged();
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				iTLxuQvBCpqTflSXVaMLGIjEeYQQ(false, true);
			}
		}

		internal virtual bool iedDOxkjfTrhublJdsoBBYzPiizQA()
		{
			if (!base.kQSdBYbKoLxckNhngUuODXUumNm())
			{
				return false;
			}
			if (!iTLxuQvBCpqTflSXVaMLGIjEeYQQ(true, true))
			{
				return false;
			}
			return true;
		}

		internal virtual void ssEsPiIOPSzIdOITKeljkvIlaxNt()
		{
			base.GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				iTLxuQvBCpqTflSXVaMLGIjEeYQQ(true, true);
			}
		}

		[CustomObfuscation(rename = false)]
		internal override IComponentController FindController()
		{
			return UnityTools.GetComponentInSelfOrParents<CustomController>(base.transform);
		}

		[CustomObfuscation(rename = false)]
		internal override Type GetRequiredControllerType()
		{
			return typeof(TouchController);
		}

		private bool iTLxuQvBCpqTflSXVaMLGIjEeYQQ(bool P_0, bool P_1)
		{
			_canvas = UnityTools.GetComponentInSelfOrParents<Canvas>(base.gameObject);
			if (_canvas == null)
			{
				if (P_0)
				{
					Logger.LogError("No Canvas was found. Touch controls must be a child of a Canvas.");
				}
				return false;
			}
			if (_canvas.renderMode == RenderMode.WorldSpace)
			{
				if (P_1)
				{
					Logger.LogError("Touch controls cannot be used with a world space Canvas. Change the canvas render mode to screen space.");
				}
				return false;
			}
			return true;
		}
	}
}
