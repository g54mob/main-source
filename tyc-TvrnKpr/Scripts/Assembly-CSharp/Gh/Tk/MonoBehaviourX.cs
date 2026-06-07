using UnityEngine;

namespace Gh.Tk
{
	[PersistenceOptIn]
	[PersistenceIgnoreParent]
	public class MonoBehaviourX : MonoBehaviour, IUpdateable, IPersistable
	{
		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _updateCallsEnabled;

		private bool _startCalled;

		public bool EnableUpdateCalls
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual void Start()
		{
		}

		public virtual void OnDestroy()
		{
		}

		public virtual void OnEnable()
		{
		}

		public virtual void OnDisable()
		{
		}

		public virtual void UpdateObject()
		{
		}
	}
}
