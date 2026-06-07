using System;
using Gilzoide.UpdateManager.Jobs.Internal;
using UnityEngine;

namespace Gilzoide.UpdateManager.Jobs
{
	public abstract class AJobBehaviour<TData> : MonoBehaviour, ITransformJobUpdatable<TData>, IInitialTransformJobDataProvider<TData>, IInitialJobDataProvider<TData> where TData : struct, IUpdateTransformJob
	{
		public virtual bool SynchronizeJobDataEveryFrame => false;

		public Transform Transform => base.transform;

		public virtual TData InitialJobData => default(TData);

		public TData JobData => this.GetJobData();

		protected virtual void OnEnable()
		{
			this.RegisterInManager(SynchronizeJobDataEveryFrame);
		}

		protected virtual void OnDisable()
		{
			this.UnregisterInManager();
		}
	}
	[Obsolete("Use AJobBehaviour<> and implement IBurstUpdateTransformJob<> in job definition instead.")]
	public abstract class AJobBehaviour<TData, TJob> : AJobBehaviour<TData> where TData : struct, IUpdateTransformJob where TJob : struct, IInternalUpdateTransformJob<TData>
	{
	}
}
