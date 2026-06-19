namespace TH20
{
	public abstract class EntityTickComponent : EntityComponent
	{
		private bool _enabled;

		private string _cachedTypeName;

		public string CachedTypeName
		{
			get
			{
				if (_cachedTypeName == null)
				{
					_cachedTypeName = GetType().Name;
				}
				return _cachedTypeName;
			}
		}

		protected EntityTickComponent()
		{
			_enabled = true;
		}

		public virtual void Tick()
		{
		}

		public virtual void LateTick()
		{
		}

		public bool IsComponentTickEnabled()
		{
			return _enabled;
		}

		public void SetComponentTickEnabled(bool enabled)
		{
			_enabled = enabled;
		}
	}
}
