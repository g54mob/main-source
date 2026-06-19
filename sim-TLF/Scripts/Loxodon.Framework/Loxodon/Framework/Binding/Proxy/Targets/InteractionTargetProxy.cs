using System;
using System.Threading;
using Loxodon.Framework.Interactivity;
using Loxodon.Log;
using UnityEngine;

namespace Loxodon.Framework.Binding.Proxy.Targets
{
	public class InteractionTargetProxy : TargetProxyBase, IObtainable
	{
		private class PostArgs
		{
			public object sender;

			public InteractionEventArgs args;

			public PostArgs(object sender, InteractionEventArgs args)
			{
				this.sender = sender;
				this.args = args;
			}
		}

		protected static readonly ILog log = LogManager.GetLogger(typeof(InteractionTargetProxy));

		protected static readonly Exception INVALID_OPERATION_EXCEPTION = new InvalidOperationException("The window or view has been disabled, so the operation is invalid.");

		private readonly EventHandler<InteractionEventArgs> handler;

		private readonly IInteractionAction interactionAction;

		private SendOrPostCallback postCallback;

		public override Type Type => typeof(EventHandler<InteractionEventArgs>);

		public override BindingMode DefaultMode => BindingMode.OneWayToSource;

		public InteractionTargetProxy(object target, IInteractionAction interactionAction)
			: base(target)
		{
			this.interactionAction = interactionAction;
			handler = OnRequest;
		}

		public object GetValue()
		{
			return handler;
		}

		public TValue GetValue<TValue>()
		{
			return (TValue)GetValue();
		}

		private void OnRequest(object sender, InteractionEventArgs args)
		{
			if (UISynchronizationContext.InThread)
			{
				if (Check(Target, args))
				{
					interactionAction.OnRequest(sender, args);
				}
				return;
			}
			if (postCallback == null)
			{
				postCallback = delegate(object state)
				{
					PostArgs postArgs = (PostArgs)state;
					if (Check(Target, postArgs.args))
					{
						interactionAction.OnRequest(postArgs.sender, postArgs.args);
					}
				};
			}
			UISynchronizationContext.Post(postCallback, new PostArgs(sender, args));
		}

		private bool Check(object target, InteractionEventArgs args)
		{
			if (target == null || target is Behaviour { isActiveAndEnabled: false })
			{
				if (log.IsErrorEnabled)
				{
					log.Error("The window or view has been disabled, so the operation is invalid.", INVALID_OPERATION_EXCEPTION);
				}
				if (args is AsyncInteractionEventArgs e)
				{
					e.Source.SetException(INVALID_OPERATION_EXCEPTION);
				}
				else
				{
					args.Callback?.Invoke();
				}
				return false;
			}
			return true;
		}
	}
}
