using Rhizomatic;
using UnityEngine;

namespace GRP
{
	public abstract class DomainScene : MonoBehaviour
	{
		public UhCamera camera;

		public Domain domain;

		protected virtual void Start()
		{
		}

		public void _Setup(Domain domain)
		{
		}

		public void _Dispose()
		{
		}

		protected virtual void Setup()
		{
		}

		protected virtual void OnDispose()
		{
		}
	}
	public abstract class DomainScene<TDomain> : DomainScene where TDomain : Domain
	{
		public new TDomain domain => null;
	}
}
