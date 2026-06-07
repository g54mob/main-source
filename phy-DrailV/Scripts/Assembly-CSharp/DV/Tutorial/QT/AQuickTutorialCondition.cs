namespace DV.Tutorial.QT
{
	public abstract class AQuickTutorialCondition
	{
		public virtual void Start()
		{
		}

		public abstract string Check();

		public virtual void Deactivate()
		{
		}

		public bool CheckAsBool()
		{
			return Check() == string.Empty;
		}
	}
}
