using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class AccordionButton3DUIView : Button3DUIView
	{
		[SerializeField]
		private Transform _spinTransform;

		private Tween _spinTween;

		public bool selectOnClicked;

		public List<GameObject> objectsToToggle;

		public Container3DUIView parentToUpdate;

		public override void CheckState()
		{
		}

		private void SetToggleObjects(bool active)
		{
		}

		public override void OnClicked()
		{
		}

		protected override void OnDisable()
		{
		}
	}
}
