namespace CTS
{
	public class PowersButton : InterfaceElement
	{
		public static PowersButton Instance { get; private set; }

		protected override void Awake()
		{
			base.Awake();
			Instance = this;
		}

		private void OnDestroy()
		{
			Instance = null;
		}
	}
}
