using System;

namespace Gh.Tk
{
	public class AttachedBehaviour : MonoBehaviourX, IReferenceableObject, ICustomSaveState, ILateRestoreState
	{
		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private string _hierarchy;

		[PersistenceOptIn]
		public virtual int Id { get; set; }

		public GameObjectX TargetObject { get; set; }

		public bool IsStillLoading { get; private set; }

		private void UpdateHierarchy()
		{
		}

		public override void Start()
		{
		}

		public void FetchTargetObject()
		{
		}

		private void UpdateTargetObject(object sender, EventArgs e)
		{
		}

		public virtual void Awake()
		{
		}

		public override void UpdateObject()
		{
		}

		protected virtual void UpdateInternal()
		{
		}

		public virtual void SaveState(IDataStore data)
		{
		}

		public virtual void RestoreState(IDataStore data)
		{
		}

		public void LateRestoreState(IDataStore data)
		{
		}

		protected virtual void LateRestoreStateInternal(IDataStore data)
		{
		}
	}
}
