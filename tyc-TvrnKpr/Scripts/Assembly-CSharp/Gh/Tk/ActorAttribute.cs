namespace Gh.Tk
{
	public abstract class ActorAttribute : AiValueWithModifiers
	{
		public new Actor Owner
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		protected override void OnEffectiveValueChanged()
		{
		}
	}
}
