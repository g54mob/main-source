namespace NSEipix.Base
{
	public abstract class Model
	{
		public virtual bool HideInGame => false;

		public virtual string[] FormerIDs => null;

		public static bool operator ==(Model m, Model n)
		{
			if ((object)m == n)
			{
				return true;
			}
			if ((object)m == null || (object)n == null)
			{
				return false;
			}
			return string.Equals(m.GetID(), n.GetID());
		}

		public static bool operator !=(Model m, Model n)
		{
			return !(m == n);
		}

		public override int GetHashCode()
		{
			string iD = GetID();
			if (!string.IsNullOrEmpty(iD))
			{
				return iD.GetHashCode();
			}
			return 0;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (!(obj is Model model))
			{
				return false;
			}
			return string.Equals(GetID(), model.GetID());
		}

		public bool Equals(Model m)
		{
			if ((object)m == null)
			{
				return false;
			}
			return string.Equals(GetID(), m.GetID());
		}

		public abstract string GetID();

		public override string ToString()
		{
			return GetID();
		}
	}
}
