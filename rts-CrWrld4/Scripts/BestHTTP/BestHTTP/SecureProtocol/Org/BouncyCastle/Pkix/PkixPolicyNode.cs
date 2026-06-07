using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Pkix
{
	public class PkixPolicyNode
	{
		protected IList mChildren;

		protected int mDepth;

		protected ISet mExpectedPolicies;

		protected PkixPolicyNode mParent;

		protected ISet mPolicyQualifiers;

		protected string mValidPolicy;

		protected bool mCritical;

		public virtual int Depth => 0;

		public virtual IEnumerable Children => null;

		public virtual bool IsCritical
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual ISet PolicyQualifiers => null;

		public virtual string ValidPolicy => null;

		public virtual bool HasChildren => false;

		public virtual ISet ExpectedPolicies
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual PkixPolicyNode Parent
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public PkixPolicyNode(IList children, int depth, ISet expectedPolicies, PkixPolicyNode parent, ISet policyQualifiers, string validPolicy, bool critical)
		{
		}

		public virtual void AddChild(PkixPolicyNode child)
		{
		}

		public virtual void RemoveChild(PkixPolicyNode child)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public virtual string ToString(string indent)
		{
			return null;
		}

		public virtual object Clone()
		{
			return null;
		}

		public virtual PkixPolicyNode Copy()
		{
			return null;
		}
	}
}
