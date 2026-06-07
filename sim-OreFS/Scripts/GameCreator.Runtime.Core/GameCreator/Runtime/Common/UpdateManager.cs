using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[AddComponentMenu("")]
	public class UpdateManager : Singleton<UpdateManager>
	{
		[AddComponentMenu("")]
		public abstract class TUpdateRegistry : MonoBehaviour
		{
			private event Action EventUpdate;

			private event Action EventLateUpdate;

			private event Action EventFixedUpdate;

			public void SubscribeUpdate(Action action)
			{
				EventUpdate += action;
			}

			public void SubscribeLateUpdate(Action action)
			{
				EventLateUpdate += action;
			}

			public void SubscribeFixedUpdate(Action action)
			{
				EventFixedUpdate += action;
			}

			public void UnsubscribeUpdate(Action action)
			{
				EventUpdate -= action;
				DestroyUpdateRegistry();
			}

			public void UnsubscribeLateUpdate(Action action)
			{
				EventLateUpdate -= action;
				DestroyUpdateRegistry();
			}

			public void UnsubscribeFixedUpdate(Action action)
			{
				EventFixedUpdate -= action;
				DestroyUpdateRegistry();
			}

			private void DestroyUpdateRegistry()
			{
				if (this.EventUpdate == null && this.EventLateUpdate == null && this.EventFixedUpdate == null)
				{
					base.enabled = false;
				}
			}

			protected void OnUpdate()
			{
				this.EventUpdate?.Invoke();
			}

			protected void OnLateUpdate()
			{
				this.EventLateUpdate?.Invoke();
			}

			protected void OnFixedUpdate()
			{
				this.EventFixedUpdate?.Invoke();
			}
		}

		[AddComponentMenu("")]
		[DefaultExecutionOrder(0)]
		public class UpdateRegistryDefault : TUpdateRegistry
		{
			private void Update()
			{
				OnUpdate();
			}

			private void LateUpdate()
			{
				OnLateUpdate();
			}

			private void FixedUpdate()
			{
				OnFixedUpdate();
			}
		}

		[AddComponentMenu("")]
		[DefaultExecutionOrder(1)]
		public class UpdateRegistryDefaultLater : TUpdateRegistry
		{
			private void Update()
			{
				OnUpdate();
			}

			private void LateUpdate()
			{
				OnLateUpdate();
			}

			private void FixedUpdate()
			{
				OnFixedUpdate();
			}
		}

		[AddComponentMenu("")]
		[DefaultExecutionOrder(-1)]
		public class UpdateRegistryDefaultEarlier : TUpdateRegistry
		{
			private void Update()
			{
				OnUpdate();
			}

			private void LateUpdate()
			{
				OnLateUpdate();
			}

			private void FixedUpdate()
			{
				OnFixedUpdate();
			}
		}

		[AddComponentMenu("")]
		[DefaultExecutionOrder(-50)]
		public class UpdateRegistryFirst : TUpdateRegistry
		{
			private void Update()
			{
				OnUpdate();
			}

			private void LateUpdate()
			{
				OnLateUpdate();
			}

			private void FixedUpdate()
			{
				OnFixedUpdate();
			}
		}

		[AddComponentMenu("")]
		[DefaultExecutionOrder(-49)]
		public class UpdateRegistryFirstLater : TUpdateRegistry
		{
			private void Update()
			{
				OnUpdate();
			}

			private void LateUpdate()
			{
				OnLateUpdate();
			}

			private void FixedUpdate()
			{
				OnFixedUpdate();
			}
		}

		[AddComponentMenu("")]
		[DefaultExecutionOrder(-51)]
		public class UpdateRegistryFirstEarlier : TUpdateRegistry
		{
			private void Update()
			{
				OnUpdate();
			}

			private void LateUpdate()
			{
				OnLateUpdate();
			}

			private void FixedUpdate()
			{
				OnFixedUpdate();
			}
		}

		[AddComponentMenu("")]
		[DefaultExecutionOrder(50)]
		public class UpdateRegistryLast : TUpdateRegistry
		{
			private void Update()
			{
				OnUpdate();
			}

			private void LateUpdate()
			{
				OnLateUpdate();
			}

			private void FixedUpdate()
			{
				OnFixedUpdate();
			}
		}

		[AddComponentMenu("")]
		[DefaultExecutionOrder(51)]
		public class UpdateRegistryLastLater : TUpdateRegistry
		{
			private void Update()
			{
				OnUpdate();
			}

			private void LateUpdate()
			{
				OnLateUpdate();
			}

			private void FixedUpdate()
			{
				OnFixedUpdate();
			}
		}

		[AddComponentMenu("")]
		[DefaultExecutionOrder(49)]
		public class UpdateRegistryLastEarlier : TUpdateRegistry
		{
			private void Update()
			{
				OnUpdate();
			}

			private void LateUpdate()
			{
				OnLateUpdate();
			}

			private void FixedUpdate()
			{
				OnFixedUpdate();
			}
		}

		[NonSerialized]
		private Dictionary<int, TUpdateRegistry> m_Updates;

		protected override void OnCreate()
		{
			base.OnCreate();
			m_Updates = new Dictionary<int, TUpdateRegistry>();
		}

		public static void SubscribeUpdate(Action action, int order)
		{
			Singleton<UpdateManager>.Instance.RequireRegistry(order).SubscribeUpdate(action);
		}

		public static void SubscribeLateUpdate(Action action, int order)
		{
			Singleton<UpdateManager>.Instance.RequireRegistry(order).SubscribeLateUpdate(action);
		}

		public static void SubscribeFixedUpdate(Action action, int order)
		{
			Singleton<UpdateManager>.Instance.RequireRegistry(order).SubscribeFixedUpdate(action);
		}

		public static void UnsubscribeUpdate(Action action, int order)
		{
			if (Singleton<UpdateManager>.Instance.m_Updates.TryGetValue(order, out var value))
			{
				value.UnsubscribeUpdate(action);
			}
		}

		public static void UnsubscribeLateUpdate(Action action, int order)
		{
			if (Singleton<UpdateManager>.Instance.m_Updates.TryGetValue(order, out var value))
			{
				value.UnsubscribeLateUpdate(action);
			}
		}

		public static void UnsubscribeFixedUpdate(Action action, int order)
		{
			if (Singleton<UpdateManager>.Instance.m_Updates.TryGetValue(order, out var value))
			{
				value.UnsubscribeFixedUpdate(action);
			}
		}

		private TUpdateRegistry RequireRegistry(int order)
		{
			if (!m_Updates.TryGetValue(order, out var value))
			{
				m_Updates.Add(order, null);
			}
			if (value == null)
			{
				Type type = order switch
				{
					0 => typeof(UpdateRegistryDefault), 
					1 => typeof(UpdateRegistryDefaultLater), 
					-1 => typeof(UpdateRegistryDefaultEarlier), 
					-50 => typeof(UpdateRegistryFirst), 
					-49 => typeof(UpdateRegistryFirstLater), 
					-51 => typeof(UpdateRegistryFirstEarlier), 
					50 => typeof(UpdateRegistryLast), 
					51 => typeof(UpdateRegistryLastLater), 
					49 => typeof(UpdateRegistryLastEarlier), 
					_ => throw new ArgumentException($"Invalid Execution Order {order}"), 
				};
				value = (TUpdateRegistry)base.gameObject.Require(type);
				m_Updates[order] = value;
			}
			if (!value.enabled)
			{
				value.enabled = true;
			}
			return value;
		}
	}
}
