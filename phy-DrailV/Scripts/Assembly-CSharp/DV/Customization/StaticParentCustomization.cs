namespace DV.Customization
{
	public abstract class StaticParentCustomization<T> : SingletonCustomization<T>, IStaticParentCustomization where T : StaticParentCustomization<T>
	{
		public bool IsLODEnabled { get; private set; }

		protected override bool ShouldLODBeLoaded(CustomizerBase customizer)
		{
			return IsLODEnabled;
		}

		public void Enable()
		{
			IsLODEnabled = true;
			RecheckAllLODStates();
		}

		public void Disable()
		{
			IsLODEnabled = false;
			RecheckAllLODStates();
		}
	}
}
