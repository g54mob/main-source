namespace Amazon.Auth.AccessControlPolicy
{
	public class ActionIdentifier
	{
		private string actionName;

		public string ActionName
		{
			get
			{
				return actionName;
			}
			set
			{
				actionName = value;
			}
		}

		public ActionIdentifier(string actionName)
		{
			this.actionName = actionName;
		}

		public static implicit operator ActionIdentifier(string value)
		{
			return new ActionIdentifier(value);
		}

		public override bool Equals(object obj)
		{
			string b;
			if (obj is ActionIdentifier)
			{
				b = ((ActionIdentifier)obj).ActionName;
			}
			else
			{
				if (!(obj is string))
				{
					return false;
				}
				b = obj as string;
			}
			return string.Equals(ActionName, b);
		}

		public override int GetHashCode()
		{
			return ActionName.GetHashCode();
		}

		public override string ToString()
		{
			return ActionName;
		}
	}
}
