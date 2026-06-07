using System;
using UnityEngine;

namespace GPUInstancerPro
{
	[HelpURL("https://wiki.gurbu.com/index.php?title=GPU_Instancer_Pro:GettingStarted#GPUI_Event_System")]
	public class GPUIEventSystem : MonoBehaviour
	{
		[SerializeField]
		public GPUICameraEvent OnPreCull;

		[SerializeField]
		public GPUICameraEvent OnPreRender;

		[SerializeField]
		public GPUICameraEvent OnPostRender;

		public static GPUIEventSystem Instance { get; private set; }

		private void Awake()
		{
			if (Instance != null && Instance != this)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Duplicate GPUI Event System detected. Destroying second event system.", Instance);
				UnityEngine.Object.Destroy(base.gameObject);
			}
			else if (Instance == null)
			{
				Instance = this;
			}
		}

		private void OnEnable()
		{
			GPUIRenderingSystem.InitializeRenderingSystem();
			GPUIRenderingSystem instance = GPUIRenderingSystem.Instance;
			instance.OnPreCull = (Action<GPUICameraData>)Delegate.Remove(instance.OnPreCull, new Action<GPUICameraData>(OnPreCull.Invoke));
			GPUIRenderingSystem instance2 = GPUIRenderingSystem.Instance;
			instance2.OnPreRender = (Action<GPUICameraData>)Delegate.Remove(instance2.OnPreRender, new Action<GPUICameraData>(OnPreRender.Invoke));
			GPUIRenderingSystem instance3 = GPUIRenderingSystem.Instance;
			instance3.OnPostRender = (Action<GPUICameraData>)Delegate.Remove(instance3.OnPostRender, new Action<GPUICameraData>(OnPostRender.Invoke));
			GPUIRenderingSystem instance4 = GPUIRenderingSystem.Instance;
			instance4.OnPreCull = (Action<GPUICameraData>)Delegate.Combine(instance4.OnPreCull, new Action<GPUICameraData>(OnPreCull.Invoke));
			GPUIRenderingSystem instance5 = GPUIRenderingSystem.Instance;
			instance5.OnPreRender = (Action<GPUICameraData>)Delegate.Combine(instance5.OnPreRender, new Action<GPUICameraData>(OnPreRender.Invoke));
			GPUIRenderingSystem instance6 = GPUIRenderingSystem.Instance;
			instance6.OnPostRender = (Action<GPUICameraData>)Delegate.Combine(instance6.OnPostRender, new Action<GPUICameraData>(OnPostRender.Invoke));
		}

		private void OnDisable()
		{
			if (GPUIRenderingSystem.IsActive)
			{
				GPUIRenderingSystem instance = GPUIRenderingSystem.Instance;
				instance.OnPreCull = (Action<GPUICameraData>)Delegate.Remove(instance.OnPreCull, new Action<GPUICameraData>(OnPreCull.Invoke));
				GPUIRenderingSystem instance2 = GPUIRenderingSystem.Instance;
				instance2.OnPreRender = (Action<GPUICameraData>)Delegate.Remove(instance2.OnPreRender, new Action<GPUICameraData>(OnPreRender.Invoke));
				GPUIRenderingSystem instance3 = GPUIRenderingSystem.Instance;
				instance3.OnPostRender = (Action<GPUICameraData>)Delegate.Remove(instance3.OnPostRender, new Action<GPUICameraData>(OnPostRender.Invoke));
			}
		}
	}
}
