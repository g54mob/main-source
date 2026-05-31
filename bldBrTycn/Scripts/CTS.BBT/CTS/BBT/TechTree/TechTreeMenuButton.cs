using System;

namespace CTS.BBT.TechTree
{
	public class TechTreeMenuButton : InterfaceButton
	{
		public static TechTreeMenuButton Instance { get; private set; }

		public static event Action OnTechTreeButtonClicked;

		protected override void Awake()
		{
			base.Awake();
			Instance = this;
		}

		protected override void OnButtonClick()
		{
			base.OnButtonClick();
			TechTreeMenuButton.OnTechTreeButtonClicked?.Invoke();
		}

		private void OnDestroy()
		{
			Instance = null;
		}
	}
}
