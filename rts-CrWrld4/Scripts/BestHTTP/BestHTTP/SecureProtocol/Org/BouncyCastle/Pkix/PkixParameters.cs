using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Date;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509.Store;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Pkix
{
	public class PkixParameters
	{
		public const int PkixValidityModel = 0;

		public const int ChainValidityModel = 1;

		private ISet trustAnchors;

		private DateTimeObject date;

		private IList certPathCheckers;

		private bool revocationEnabled;

		private ISet initialPolicies;

		private bool explicitPolicyRequired;

		private bool anyPolicyInhibited;

		private bool policyMappingInhibited;

		private bool policyQualifiersRejected;

		private IX509Selector certSelector;

		private IList stores;

		private IX509Selector selector;

		private bool additionalLocationsEnabled;

		private IList additionalStores;

		private ISet trustedACIssuers;

		private ISet necessaryACAttributes;

		private ISet prohibitedACAttributes;

		private ISet attrCertCheckers;

		private int validityModel;

		private bool useDeltas;

		public virtual bool IsRevocationEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual bool IsExplicitPolicyRequired
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual bool IsAnyPolicyInhibited
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual bool IsPolicyMappingInhibited
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual bool IsPolicyQualifiersRejected
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual DateTimeObject Date
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual bool IsUseDeltasEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual int ValidityModel
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public virtual bool IsAdditionalLocationsEnabled => false;

		public PkixParameters(ISet trustAnchors)
		{
		}

		public virtual ISet GetTrustAnchors()
		{
			return null;
		}

		public virtual void SetTrustAnchors(ISet tas)
		{
		}

		public virtual X509CertStoreSelector GetTargetCertConstraints()
		{
			return null;
		}

		public virtual void SetTargetCertConstraints(IX509Selector selector)
		{
		}

		public virtual ISet GetInitialPolicies()
		{
			return null;
		}

		public virtual void SetInitialPolicies(ISet initialPolicies)
		{
		}

		public virtual void SetCertPathCheckers(IList checkers)
		{
		}

		public virtual IList GetCertPathCheckers()
		{
			return null;
		}

		public virtual void AddCertPathChecker(PkixCertPathChecker checker)
		{
		}

		public virtual object Clone()
		{
			return null;
		}

		protected virtual void SetParams(PkixParameters parameters)
		{
		}

		public virtual void SetStores(IList stores)
		{
		}

		public virtual void AddStore(IX509Store store)
		{
		}

		public virtual void AddAdditionalStore(IX509Store store)
		{
		}

		public virtual IList GetAdditionalStores()
		{
			return null;
		}

		public virtual IList GetStores()
		{
			return null;
		}

		public virtual void SetAdditionalLocationsEnabled(bool enabled)
		{
		}

		public virtual IX509Selector GetTargetConstraints()
		{
			return null;
		}

		public virtual void SetTargetConstraints(IX509Selector selector)
		{
		}

		public virtual ISet GetTrustedACIssuers()
		{
			return null;
		}

		public virtual void SetTrustedACIssuers(ISet trustedACIssuers)
		{
		}

		public virtual ISet GetNecessaryACAttributes()
		{
			return null;
		}

		public virtual void SetNecessaryACAttributes(ISet necessaryACAttributes)
		{
		}

		public virtual ISet GetProhibitedACAttributes()
		{
			return null;
		}

		public virtual void SetProhibitedACAttributes(ISet prohibitedACAttributes)
		{
		}

		public virtual ISet GetAttrCertCheckers()
		{
			return null;
		}

		public virtual void SetAttrCertCheckers(ISet attrCertCheckers)
		{
		}
	}
}
