using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class CreateDecoTextDialog3DUIView : SimpleInputDialog3DUIView
	{
		public static float letterSpacing;

		public static float spaceSize;

		public Dictionary<char, string> characterPrefabs;

		protected override void Awake()
		{
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		private void InitCharacterPrefabs()
		{
		}

		private void CreateTextDecoration(string text)
		{
		}

		private Bounds CalculateBounds(Transform buildableTransform)
		{
			return default(Bounds);
		}
	}
}
