using Loxodon.Framework.Views.Animations;
using UnityEngine;

namespace Loxodon.Framework.Views
{
	public interface IUIView : IView
	{
		RectTransform RectTransform { get; }

		float Alpha { get; set; }

		bool Interactable { get; set; }

		CanvasGroup CanvasGroup { get; }

		IAnimation EnterAnimation { get; set; }

		IAnimation ExitAnimation { get; set; }
	}
}
